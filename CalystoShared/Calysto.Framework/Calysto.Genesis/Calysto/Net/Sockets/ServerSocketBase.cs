using Calysto.Common;
using Calysto.Diagnostics;
using Calysto.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.Net.Sockets
{
	/// <summary>
	/// Callbacks are used for async methods. Sync methods throw exception.
	/// </summary>
	/// <typeparam name="TServer"></typeparam>
	public abstract class ServerSocketBase<TServer> : IDisposable
		where TServer : ServerSocketBase<TServer>
	{
		Socket _listener;

		public event Func<TServer, Socket, Task> OnClientConnected;
		public event Action<TServer, Exception> OnException;
		public event Action<TServer> OnDisposed;

		protected virtual Task NotifyClientConnected(Socket client) => this.OnClientConnected?.Invoke((TServer)this, client) ?? Task.CompletedTask;
		protected virtual void NotifyDisposed() => this.OnDisposed?.Invoke((TServer)this);
		protected virtual void NotifyException(Func<Exception> fn) => this.OnException?.Invoke((TServer)this, fn.Invoke());

		public int Port => _listener == null ? -1 : ((IPEndPoint)(_listener.LocalEndPoint)).Port;

		public string LoopbackUrl => _listener == null ? null : ("http://" + IPAddress.Loopback + ":" + +this.Port);

		protected ServerSocketBase()
		{
		}

		public void StartListening(int port, Func<Socket> fnCreateSocket = null)
		{
			this.StartListening(new[] { new IPEndPoint(IPAddress.Any, port) }, fnCreateSocket);
		}

		public void StartListening(IEnumerable<IPEndPoint> epoints, Func<Socket> fnCreateSocket = null)
		{
			if (_listener != null)
				throw new Exception("Already listening.");
			else
			{
				// have to instantinate listener before entering async part because it is invokes this.LoopbackUrl in RequestInterceptor for ProxyChain
				_listener = fnCreateSocket?.Invoke() ?? new Socket(SocketType.Stream, ProtocolType.Tcp);
				Exception ex1 = null;
				foreach (IPEndPoint ep in epoints)
				{
					try
					{
						_listener.Bind(ep);
						_listener.Listen(2000);
						ex1 = null;
						break;
					}
					catch(Exception ex)
					{
						ex1 = ex;
					}
				}

				if(ex1 != null)
				{
					throw ex1;
				}
			}

			Task.Run(async () =>
			{
				int errors = 0;
				////int cnt = 0;
				while (!this.IsDisposed && _listener != null && errors++ < 10) // server has always Connected == false
				{
					try
					{
						// ovako je najbrze, nek kreira evente i pokrene reader task za novi socket, sve iz istog taska
						// ako se ovo pokrece u novom tasku, jako se uspori sve
						await Task.Run(async () =>
						{
							Socket client = await _listener.AcceptAsync();
							if (client != null)
							{
								// reset errors
								errors = 0;
								////Console.WriteLine($"SocketBase {cnt++} as {this.GetType().Name}");
								// has to be run in new task because there may be a lot of code inside to run, like in HttpProxyServer
								if (client.SendBufferSize != SocketConstants.SEND_BUFFER_SIZE)
									client.SendBufferSize = SocketConstants.SEND_BUFFER_SIZE;

								if (client.ReceiveBufferSize != SocketConstants.RECEIVER_BUFFER_SIZE)
									client.ReceiveBufferSize = SocketConstants.RECEIVER_BUFFER_SIZE;

								// method returns void, so do not reference returned task,
								// if referenced, it prevents GC from collecting expired objects since it is in while loop, so rereference would be never out of scope and released
								// do not await for return, this way we ensure func context will be released for GC to collect it
								HandleClientConnectedAsync(client);
							}
						});
					}
					catch (Exception ex)
					{
						this.NotifyException(() => ex);
					}
				}
			});
		}

		/// <summary>
		/// Assign events to client socket and start new reader task.
		/// </summary>
		/// <param name="client"></param>
		/// <returns></returns>
		private async void HandleClientConnectedAsync(Socket client)
		{
			////if (this.GetType().Name == "EntranceServer")
			////	await Task.Delay(5000);
			
			if (client?.Connected == true) // it comes here on listener.Close() invoked, but with Connected == false
			{
				try
				{
					await this.NotifyClientConnected(client);
				}
				catch (Exception ex1)
				{
					TryDispose(client);
					this.NotifyException(() => ex1);
				}
			}
			else
			{
				TryDispose(client);
			}
		}

		private void TryDispose(Socket client)
		{
			try
			{
				if (client?.Connected == true)
				{
					client?.Disconnect(false);
				}
			}	catch { }
			try { client?.Close(); } catch { }
			try { client?.Dispose(); } catch { }
		}

		~ServerSocketBase() => this.Dispose();

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;

			try
			{
				TryDispose(_listener);
				_listener = null;
			}
			catch { }

			try
			{
				this.NotifyDisposed();
			}
			catch { }

			this.OnClientConnected = null;
			this.OnDisposed = null;
			this.OnException = null;

		}
	}
}
