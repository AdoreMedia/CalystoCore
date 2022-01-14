using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Calysto.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections.Concurrent;
using Calysto.Common;

namespace Calysto.Net.Sockets
{
	public static class SocketConstants
	{
		// alocate up to 85000 bytes, to place data into Small Objects Heap
		//https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/large-object-heap

		public const int SEND_BUFFER_SIZE = 65536 / 2; // 32768
		public const int RECEIVER_BUFFER_SIZE = 65536;
		public const int READER_CHUNK_SIZE = 65536 / 4; // 16384
		public const int SENDER_CHUNK_SIZE = 65536 / 2; // 32768
	}

	/// <summary>
	/// Callbacks are used for async methods. Sync methods throw exception.
	/// </summary>
	/// <typeparam name="TInstance"></typeparam>
	public abstract class ClientSocketBase<TInstance> : IDisposable
		where TInstance : ClientSocketBase<TInstance>
	{
		ClientStatistics _statistics;
		public virtual ClientStatistics Statistics => _statistics;

		protected virtual int ReceiveTimeoutMs { get; set; }

		Socket _socket;
		public Socket Socket => _socket;

		object _receiverLock = new object();

		SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		public bool IsSocketConnected => _socket?.Connected == true;

		public event Action<TInstance, Exception> OnException;
		public event Func<TInstance, byte[], Task> OnDataReceived;
		public event Action<TInstance, int> OnSendCompleted;
		public event Action<TInstance, int> OnDataChunkSent;
		public event Action<TInstance> OnDisposed;
		public event Func<TInstance, Task> OnReceiveTimeout;
		public event Func<TInstance, Task> OnShouldDisconnect;
		public event Action<TInstance> OnIdleTimeout;

		protected virtual void NotifyException(Func<Exception> fn) => this.OnException?.Invoke((TInstance)this, fn.Invoke());
		protected virtual void NotifyDisposed() => this.OnDisposed?.Invoke((TInstance)this);
		protected virtual Task NotifyReceiveTimeout() => this.OnReceiveTimeout?.Invoke((TInstance)this) ?? Task.CompletedTask;
		protected virtual void NotifySendCompleted(int totalSent) => this.OnSendCompleted?.Invoke((TInstance)this, totalSent);
		protected virtual void NotifyIdleTimeout() => this.OnIdleTimeout?.Invoke((TInstance)this);

		private CalystoTimer _disposeTimer;

		private bool _notifyShouldDisconnectSent;

		protected virtual async Task NotifyShouldDisconnect()
		{
			// moramo biti sigurni da se event okida samo jednom jer se iz eventa salje command disconnect tunnel
			if (_notifyShouldDisconnectSent)
				return;
			
			_notifyShouldDisconnectSent = true;

			if (this.OnShouldDisconnect != null)
			{
				// ako nesto pukne u OnShouldDisconnect, nek iz ovog timera pokrene dispose
				_disposeTimer = new CalystoTimer(s => this.Dispose()).Start(10000); 

				await this.OnShouldDisconnect.Invoke((TInstance)this);
			}
			else
				this.Dispose();
		}

		protected virtual async Task NotifyDataReceived(byte[] data)
		{
			this.StartIdleTimeout();
			if(this.OnDataReceived != null)
				await this.OnDataReceived.Invoke((TInstance)this, data);
		}

		protected virtual void NotifyDataChunkSent(int len)
		{
			this.StartIdleTimeout();
			this.OnDataChunkSent?.Invoke((TInstance)this, len);
		}

		protected ClientSocketBase(Socket socket = null)
		{
			_socket = socket;
			_statistics = new ClientStatistics(ref _socket); // initialy socket may be null

			if (socket?.Connected == true)
				this.Statistics.MarkConnected();

			_idleTimeout = new CalystoTimer(timer => this.NotifyIdleTimeout());
		}

		#region dispose

		~ClientSocketBase() => this.Dispose();

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			try { _disposeTimer?.Dispose(); } catch { }
			_disposeTimer = null;

			if (this.IsDisposed) return;
			this.IsDisposed = true;

			// must invoke Disconnect(), this way it send to other side disconnect comand and socket will disconnect
			try { _socket?.Disconnect(false); } catch { }
			try { _socket?.Close(); } catch { }
			try { _socket?.Dispose(); } catch { }
			_socket = null;

			try { _semaphore?.Dispose(); } catch { }

			try { _statistics?.Dispose(); } catch { }
			////_statistics = null; // nek ostane instanca jer se i nakon diposed, moze nesto pisati, npr. tunnelClient.Statistics.AddNote(() => "TunnelPeer_OnDisposed");
			
			try { _reciveTimeoutTimer?.Dispose(); } catch { }
			_reciveTimeoutTimer = null;

			try { _idleTimeout?.Dispose(); } catch { }
			_idleTimeout = null;

			try
			{
				this.NotifyDisposed();
			}
			catch { }

			this.OnDataChunkSent = null;
			this.OnDataReceived = null;
			this.OnDisposed = null;
			this.OnException = null;
			this.OnIdleTimeout = null;
			this.OnReceiveTimeout = null;
			this.OnSendCompleted = null;
			this.OnShouldDisconnect = null;
		}


		#endregion

		public virtual async Task ConnectAsync(string serverHost, int port, Func<Socket> fnCreateSocket = null)
		{
			if (this.IsSocketConnected)
				throw new InvalidOperationException("Already connected.");

			Socket socket1 = _socket ?? fnCreateSocket?.Invoke() ?? new Socket(SocketType.Stream, ProtocolType.Tcp);

			if(socket1.SendBufferSize != SocketConstants.SEND_BUFFER_SIZE)
				socket1.SendBufferSize = SocketConstants.SEND_BUFFER_SIZE;

			if(socket1.ReceiveBufferSize != SocketConstants.RECEIVER_BUFFER_SIZE)
				socket1.ReceiveBufferSize = SocketConstants.RECEIVER_BUFFER_SIZE;

			// nek pronadje prvi IPAddress na koji ce se uspjesno spojiti
			Exception lastEx = null;
			foreach (var dns1 in Calysto.Net.CalystoDnsHelper.Current.ResolveAddresses(serverHost))
			{
				if (this.IsDisposed)
					return;

				try
				{
					await socket1.ConnectAsync(dns1.Address, port);
					if (socket1?.Connected == true)
					{
						dns1.AddToCache();

						this.Statistics.Hostname = serverHost;
						this.Statistics.DnsAddress = dns1.Address.ToString();

						this.Statistics.MarkConnected();
						_socket = socket1;
						return; // ok
					}
				}
				catch (Exception ex1)
				{
					lastEx = ex1;
				}

				dns1.RemoveFromCache();
			}

			throw new Exception("Failed TCP socket connect to " + serverHost + ":" + port, lastEx);
		}

		#region receive sync

		public async Task<int> ReceiveAsync(ArraySegment<byte> array1)
		{
			if (this.IsDisposed || !this.IsSocketConnected)
				return 0;
			int len1 = await this._socket.ReceiveAsync(array1, SocketFlags.None);
			this.Statistics.MarkReceived(len1);
			return len1;
		}

		public async Task<int> ReceiveAsync(byte[] buffer)
		{
			if (this.IsDisposed || !this.IsSocketConnected)
				return 0;
			return await this.ReceiveAsync(new ArraySegment<byte>(buffer));
		}

		#endregion

		#region receiver with callback

		bool _isReceiving = false;

		/// <summary>
		/// Begin receiving and will invoke events on data received.
		/// </summary>
		/// <returns></returns>
		public virtual async Task BeginReceiveAsync()
		{
			if (this.IsDisposed) return;

			if (!this.IsSocketConnected)
				throw new InvalidOperationException("Socket not connected.");

			lock (_receiverLock)
			{
				if (_isReceiving)
					return; // already started
				else
					_isReceiving = true;
			}

			// do not await for return and do not keep returned Task, this way we ensure func context will be released for GC to collect it
			this.ReceiveWorker();

			await Task.CompletedTask;
		}

		CalystoTimer _reciveTimeoutTimer;

		private byte[] GetAvailableData(ArraySegment<byte> array1, int len1)
		{
			byte[] data1 = new byte[len1];
			Array.Copy(array1.Array, data1, len1);
			return data1;
		}

		int _zeroReads = 0;

		private void ReceiveWorker()
		{
			Task.Run(async () =>
			{
				_zeroReads = 0;
				int rounds1 = 0;
				ArraySegment<byte> array1 = BuffersManager.GetAvailableBuffer(SocketConstants.READER_CHUNK_SIZE);
				try
				{
					while (!this.IsDisposed && this.IsSocketConnected)
					{
						if (_reciveTimeoutTimer == null && this.ReceiveTimeoutMs > 0)
							this._reciveTimeoutTimer = new CalystoTimer(timer => this.NotifyReceiveTimeout());

						_reciveTimeoutTimer?.Start(this.ReceiveTimeoutMs);

						int len1 = await this.ReceiveAsync(array1);

						if (len1 > 0)
						{
							_zeroReads = 0;
							_reciveTimeoutTimer?.Abort();

							await this.NotifyDataReceived(this.GetAvailableData(array1, len1));

						}
						////else if (++_zeroReads < 5)
						////{
						////	// zero read, but successful, let's repeat
						////	Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => $"zero reads {_zeroReads}, will retry");
						////}
						else
						{
							Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => $"zero read, should disconnect");
							await this.NotifyShouldDisconnect();
							return; // exit while
						}

						if (rounds1++ > 10)
						{
							// this way we restart worker method and release objects for GC held by while loop
							this.ReceiveWorker();
							return;
						}
					}
				}
				catch (System.Net.Sockets.SocketException)
				{
					// An existing connection was forcibly closed by the remote host
					if (!this.IsDisposed)
					{
						await this.NotifyShouldDisconnect();
					}
				}
				catch (Exception ex2)
				{
					if (!this.IsDisposed)
					{
						Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex2);
						this.NotifyException(() => ex2);
						await this.NotifyShouldDisconnect();
					}
				}
				finally
				{
					BuffersManager.ReleaseBuffer(array1);
				}
			});
		}

		#endregion

		#region sender async

		private static IEnumerable<byte[]> GetDataChunks(int maxLength, IEnumerable<byte[]> list)
		{
			//Calysto.Common.CalystoArrayBuffer<byte> buffer = new Common.CalystoArrayBuffer<byte>();
			//foreach (var item in list)
			//{
			//	buffer.Add(item);
			//}

			//byte[] data = null;
			//while ((data = buffer.Read(maxLength))?.Length > 0)
			//{
			//	yield return data;
			//}

			foreach (var data1 in list)
			{
				if (data1?.Length >= maxLength)
				{
					int totalLength = data1.Length;
					int sentLength = 0;
					int leftLength;
					int chunkLength;
					while (sentLength < totalLength)
					{
						leftLength = totalLength - sentLength;
						chunkLength = Math.Min(leftLength, maxLength);
						byte[] chunkData = new byte[chunkLength];
						Array.Copy(data1, sentLength, chunkData, 0, chunkLength);
						yield return chunkData;
						sentLength += chunkLength;
					}
				}
				else
				{
					yield return data1;
				}
			}
		}

		int _zeroSends = 0;

		public virtual async Task SendAsync(IEnumerable<byte[]> list)
		{
			if (this.IsDisposed || !this.IsSocketConnected) return;

			try
			{
				await _semaphore.WaitAsync();

				int totalSent = 0;

				foreach (byte[] data1 in GetDataChunks(SocketConstants.SENDER_CHUNK_SIZE, list))
				{
					if (this.IsDisposed || !this.IsSocketConnected) return;

					int sent1 = await _socket.SendAsync(new ArraySegment<byte>(data1), SocketFlags.None);

					if (sent1 > 0)
					{
						totalSent += sent1;
						_zeroSends = 0;

						this.Statistics.MarkSent(sent1);

						this.NotifyDataChunkSent(sent1);
					}
					else if (++_zeroSends < 5)
					{
						// zero read, but successful, let's repeat
						Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => $"zero sends {_zeroSends}, will retry");
					}
					else
					{
						Calysto.Diagnostics.CalystoLogger.Current.Diagnostic(this, () => "zero sends, should disconnect");
						await this.NotifyShouldDisconnect();
						return;
					}
				}

				this.NotifySendCompleted(totalSent);
			}
			catch (Exception ex)
			{
				if (!this.IsDisposed)
				{
					Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex);
					this.NotifyException(() => ex);
					await this.NotifyShouldDisconnect();
				}
			}
			finally
			{
				_semaphore.Release();
			}
		}

		public virtual async Task SendAsync(string str) => await this.SendAsync(Encoding.UTF8.GetBytes(str));

		public virtual async Task SendAsync(byte[] data) => await this.SendAsync(new List<byte[]> { data });

		#endregion

		CalystoTimer _idleTimeout;

		public int IdleTimeoutMs { get; set; }

		public void StartIdleTimeout(int timeoutMs)
		{
			if(this.OnIdleTimeout != null && timeoutMs > 0)
				_idleTimeout?.Start(timeoutMs);
		}

		public void StartIdleTimeout() => this.StartIdleTimeout(this.IdleTimeoutMs);
	}
}
