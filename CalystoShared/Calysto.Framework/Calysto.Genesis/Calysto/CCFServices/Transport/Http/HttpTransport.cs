namespace Calysto.CCFServices.Transport.Http
{
	public abstract class HttpTransport : ICCFTransport
	{
		public string Url { get; private set; }

		public HttpTransport(string url)
		{
			Url = url;
		}

		public int ChunkSize { get; set; } = 81920;
		public string HEADER_KEY => "X-Request-With";
		public string HEADER_VALUE => "CCFHttpTransport";

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;
		}
	}
}