using Calysto.Threading;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Calysto.CCFServices.Transport.Http
{
	public class HttpTransportServer : HttpTransport, ICCFTransportServer
	{
		public int ParallelRequestsMax { get; set; } = 10;

		public HttpTransportServer(string url) : base(url)
		{
		}

		#region server side - receiving request

		public event Action<TransportRequest> OnRequestDataReceived;

		public void NotifyRequestDataReceived(TransportRequest request)
		{
			this.OnRequestDataReceived?.Invoke(request);
		}

		#endregion

		#region server side - receiving request

		HttpListener _listener;

		/// <summary>
		/// Listener can be started only with elevated privileges.
		/// </summary>
		public void StartListening()
		{
			_listener = new HttpListener();
			_listener.Prefixes.Add(this.Url);
			_listener.Start();
			this.BeginGetContext();
		}

		public void StopListening()
		{
			try { _listener?.Stop(); } catch { }
			try { _listener?.Close(); } catch { }
			try { _listener?.Abort(); } catch { }
			_listener = null;
		}

		private int _entrances = 0;
		private object _rwlock = new object();
		private Thread _thrLoop;

		private void BeginGetContext()
		{
			_thrLoop = new Thread(() =>
			{
				int errors = 0;

				while (!this.IsDisposed && _listener != null && errors++ < 20)
				{
					try
					{
						lock (_rwlock)
						{
							++_entrances;

							while (_entrances > this.ParallelRequestsMax)
							{
								Monitor.Wait(_rwlock, 2000);
							}
						}

						HttpListenerContext context = _listener.GetContext();
						if (context != null)
						{
							errors = 0; // reset errors

							Thread thr1 = new Thread(() =>
							  {
								  try
								  {
									  ProcessListenerRequestWorker(context);
								  }
								  catch (Exception ex3)
								  {
									  Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex3);
								  }

								  lock (_rwlock)
								  {
									  --_entrances;
									  Monitor.Pulse(_rwlock);
								  }

							  }).StartBackground();
						}
					}
					catch (Exception ex2)
					{
						Calysto.Diagnostics.CalystoLogger.Current.Exception(this, () => ex2);
					}
				}

			}).StartBackground();
		}

		private void ProcessListenerRequestWorker(HttpListenerContext context)
		{		
			if (context.Request.Headers[this.HEADER_KEY] == this.HEADER_VALUE)
			{
				MemoryStream ms = new MemoryStream();
				context.Request.InputStream.CopyTo(ms);

				// samo IP jer se remote port mijenja na svakom requestu (ne moze se reusati interni socket u WebClient-u)
				this.NotifyRequestDataReceived(new TransportRequest()
				{
					Data = ms.ToArray(),
					RemoteAddress = context.Request.RemoteEndPoint?.Address + "",
					FnSendResponse = (byte[] responseData) =>
					{
						//context.Response.Headers.Add(HttpRequestHeader.ContentLength, (responseData?.Length ?? 0).ToString());
						context.Response.ContentLength64 = responseData?.Length ?? 0;
						context.Response.ContentType = "application/octet-stream";
						context.Response.OutputStream.Write(responseData, 0, responseData.Length);
						context.Response.OutputStream.Flush();
						context.Response.Close(); // obavezno Close(), bez Close() nece poslati response
					}
				});
			}
			else
			{
				context.Response.StatusCode = 403;
				context.Response.Close();
			}
		}

		#endregion

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();

			try
			{
				this.StopListening();
			}
			catch { }
		}

	}
}