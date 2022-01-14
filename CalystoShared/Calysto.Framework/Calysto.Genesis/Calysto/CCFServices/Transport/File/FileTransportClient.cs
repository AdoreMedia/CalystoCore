using System;
using System.IO;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.FileSystem
{
	public class FileTransportClient : FileTransport, ICCFTransportClient
	{
		public event Action<ProgressEventArgs> OnProgress;
		public event Action<byte[]> OnDataReceived;

		public FileTransportClient()
		{
		}

		private static string CreateErrorFileName(string path)
		{
			return path + ".error";
		}

		public async Task SendRequestAsync(byte[] sendData)
		{
			string file = Path.GetFileName(Path.GetTempFileName());
			string requestFile = Path.Combine(this.RequestDirectory, file);
			string responseFile = Path.Combine(this.ResponseDirectory, file);

			FileSystemWatcher watcher = new FileSystemWatcher(this.ResponseDirectory);
			watcher.EnableRaisingEvents = true;
			watcher.Changed += (object sender, FileSystemEventArgs e) =>
			{
				bool isData = e.Name == file;
				bool isError = e.Name == CreateErrorFileName(file);
				if (isData || isError)
				{
					watcher.EnableRaisingEvents = false;
					if (File.Exists(e.FullPath))
					{
						this.OnProgress?.Invoke(new ProgressEventArgs(100, 100));
						if (isData)
						{
							byte[] resp = File.ReadAllBytes(e.FullPath);
							this.DeleteFiles(requestFile, responseFile);
							this.OnDataReceived?.Invoke(resp);
						}
						else if (isError)
						{
							byte[] err = File.ReadAllBytes(e.FullPath);
							this.DeleteFiles(requestFile, responseFile);
							this.OnDataReceived?.Invoke(err);
						}
					}

					// cleanup
					watcher.Dispose();

					this.DeleteFiles(requestFile, responseFile);
				}
			};

			// write request file
			File.WriteAllBytes(requestFile, sendData);

			await Task.CompletedTask;
		}

		private void DeleteFiles(string requestFile, string responseFile)
		{
			File.Delete(requestFile);
			File.Delete(CreateErrorFileName(requestFile));
			File.Delete(responseFile);
			File.Delete(CreateErrorFileName(responseFile));
		}

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();

			this.OnProgress = null;
		}
	}
}