using System;

namespace Calysto.CCFServices.Transport.Tcp
{
	public class TcpTransport : ICCFTransport
	{
		public event Action<Func<string>> OnLog;

		public void NotifyLog(Func<string> fn) => this.OnLog?.Invoke(fn);

		public string Host { get; }
		public int Port { get; }

		public TcpTransport(string host, int port)
		{
			this.Host = host;
			this.Port = port;
		}

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;

			this.OnLog = null;
		}

	}
}