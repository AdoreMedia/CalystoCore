using Calysto.Common;
using Calysto.Timers;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Net.Sockets
{
	public abstract class UdpClientSocketBase<TInstance> : IDisposable
		where TInstance : UdpClientSocketBase<TInstance>
	{
		protected bool _isServer;
		private bool _isSharedSocket;
		protected UdpClient _udpClient;
		public UdpClient UdpClient => _udpClient;

		// nakon sto jednom procita endpoints, zapamti ih, i nakon sto se pozove Dispose
		// udp client ima samo localEP, nikad nema remoteEP
		public virtual string EndPointsKey { get; set; }

		/// <summary>
		/// Set server socket which will not be disposed where this instance is disposed.
		/// </summary>
		/// <param name="client"></param>
		public void SetSharedSocket(UdpClient client)
		{
			_isSharedSocket = true;
			_udpClient = client;
		}

		public event Action<TInstance, Exception> OnException;
		public event Func<TInstance, UdpDataReceivedBlock, Task> OnDataReceived;
		public event Action<TInstance, int> OnSendCompleted;
		public event Action<TInstance> OnDisposed;
		public event Func<TInstance, Task> OnShouldDisconnect;
		public event Func<TInstance, Task> OnServerShouldDisconnect;
		public event Action<TInstance> OnIdleTimeout;

		protected virtual void NotifyException(Func<Exception> fn) => this.OnException?.Invoke((TInstance)this, fn.Invoke());
		protected virtual void NotifyDisposed() => this.OnDisposed?.Invoke((TInstance)this);
		protected virtual void NotifyIdleTimeout() => this.OnIdleTimeout?.Invoke((TInstance)this);

		protected virtual async Task NotifyShouldDisconnect()
		{
			if (this.OnShouldDisconnect != null)
				await this.OnShouldDisconnect.Invoke((TInstance)this);
			else
				this.Dispose();
		}

		protected virtual async Task NotifyServerShouldDisconnect()
		{
			if (this.OnServerShouldDisconnect != null)
				await this.OnServerShouldDisconnect.Invoke((TInstance)this);
			else
				this.Dispose();
		}

		protected virtual async Task NotifyDataReceived(UdpDataReceivedBlock block)
		{
			this.StartIdleTimeout();
			if (this.OnDataReceived != null)
				await this.OnDataReceived.Invoke((TInstance)this, block);
		}

		protected virtual void NotifySendCompleted(int len)
		{
			this.StartIdleTimeout();
			this.OnSendCompleted?.Invoke((TInstance)this, len);
		}

		public int IdleTimeoutMs { get; set; }

		public void StartIdleTimeout(int timeoutMs)
		{
			if (timeoutMs > 0)
				_idleTimeout.Start(timeoutMs);
		}

		public void StartIdleTimeout() => this.StartIdleTimeout(this.IdleTimeoutMs);

		CalystoTimer _idleTimeout;

		public UdpClientSocketBase()
		{
			_idleTimeout = new CalystoTimer(timer => this.NotifyIdleTimeout());
		}

		#region disposing

		~UdpClientSocketBase() => this.Dispose();

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;

			if(_isSharedSocket)
			{
				_udpClient = null;
			}
			else
			{
				try { _udpClient?.Client?.Close(); } catch { }
				try { _udpClient?.Client?.Dispose(); } catch { }
				try { _udpClient?.Close(); } catch { }
				try { _udpClient?.Dispose(); } catch { }
				try { _senderSemaphore?.Close(); } catch { }
				try { _senderSemaphore?.Dispose(); } catch { }
				_senderSemaphore = null;
				try { _idleTimeout?.Dispose(); } catch { }
				_idleTimeout = null;
			}

			this.NotifyDisposed();

			this.OnDataReceived = null;
			this.OnDisposed = null;
			this.OnException = null;
			this.OnIdleTimeout = null;
			this.OnSendCompleted = null;
			this.OnShouldDisconnect = null;
			this.OnServerShouldDisconnect = null;
		}

		#endregion

		#region receiving

		/// <summary>
		/// Ako port nije zadan, odabrat ce port by the system.
		/// </summary>
		/// <param name="port">if 0, will auto assign port</param>
		public virtual void BeginReceive(int port = 0)
		{
			if (_udpClient != null)
				throw new Exception("Already listening.");

			if (_udpClient == null)
				_udpClient = new UdpClient(port);

			Task.Run(() => this.ReceiveWorker());
		}

		private async Task ReceiveWorker()
		{
			while (!this.IsDisposed && _udpClient != null)
			{
				try
				{
					var result1 = await _udpClient.ReceiveAsync();

					var block1 = new UdpDataReceivedBlock(_udpClient, result1.Buffer, (IPEndPoint)_udpClient.Client.LocalEndPoint, result1.RemoteEndPoint);

					await this.NotifyDataReceived(block1);
				}
				catch (Exception ex)
				{
					if (this.IsDisposed)
					{
						// nothing
					}
					else
					{
						this.NotifyException(() => ex);
						await this.NotifyShouldDisconnect();
						return; // exit while
					}
				}
			}
		}

		#endregion

		#region send

		public virtual async Task SendToAsync(string hostname, int port, byte[] data)
		{
			Exception lastEx = null;
			foreach (var dns1 in Calysto.Net.CalystoDnsHelper.Current.ResolveAddresses(hostname))
			{
				if (this.IsDisposed)
					return;

				try
				{
					await this.SendToAsync(new IPEndPoint(dns1.Address, port), data);
					
					dns1.AddToCache();

					return; // ok
				}
				catch (Exception ex1)
				{
					lastEx = ex1;
				}

				dns1.RemoveFromCache();
			}

			throw new Exception("Failed UDP socket connect to " + hostname + ":" + port, lastEx);
		}

		public virtual async Task SendToAsync(IPEndPoint toEP, string str) => await this.SendToAsync(toEP, Encoding.UTF8.GetBytes(str));

		Semaphore _senderSemaphore = new Semaphore(1, 1);

		public virtual async Task SendToAsync(IPEndPoint toEP, byte[] data)
		{
			try
			{
				_senderSemaphore.WaitOne();

				if (_udpClient == null)
					_udpClient = new UdpClient();

				int len1 = await _udpClient.SendAsync(data, data.Length, toEP);

				this.NotifySendCompleted(len1);
			}
			catch(Exception ex)
			{
				this.NotifyException(() => ex);
				await this.NotifyShouldDisconnect();
			}
			finally
			{
				_senderSemaphore.Release();
			}
		}

		#endregion
	}

}

