using System;
using System.IO;

namespace Calysto.CCFServices.Transport.FileSystem
{
	public abstract class FileTransport: ICCFTransport
	{
		public string DirectoryPath => Path.GetTempPath();
		public string RequestDirectory => Path.Combine(this.DirectoryPath, "FileTransport", "Request");
		public string ResponseDirectory => Path.Combine(this.DirectoryPath, "FileTransport", "Response");

		public FileTransport()
		{
			// ensure directories exists
			if (!Directory.Exists(this.RequestDirectory))
				Directory.CreateDirectory(this.RequestDirectory);

			if (!Directory.Exists(this.ResponseDirectory))
				Directory.CreateDirectory(this.ResponseDirectory);
		}

		public bool IsDisposed { get; private set; }

		public virtual void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;
		}

		public ICCFTransportServer CreateServer()
		{
			throw new NotImplementedException();
		}

		public ICCFTransportClient CreateClient()
		{
			throw new NotImplementedException();
		}

	}
}