using Calysto.Threading;
using System;
using System.IO;
using System.Threading;

namespace Calysto.CCFServices.Transport.FileSystem
{
	public class FileTransportServer: FileTransport, ICCFTransportServer
	{
		public int ParallelRequestsMax { get; set; } = 10;

		public event Action<TransportRequest> OnRequestDataReceived;

		public FileTransportServer()
		{
		}

		private int _entrances = 0;
		private object _rwlock = new object();
		private FileSystemWatcher _serverWatcher;

		private void ReleaseOne()
		{
			lock (_rwlock)
			{
				--_entrances;
				Monitor.Pulse(_rwlock);
			}
		}

		private static string CreateErrorFileName(string path)
		{
			return path + ".error";
		}

		public void StartListening()
		{
			_serverWatcher = new FileSystemWatcher(this.RequestDirectory);
			_serverWatcher.EnableRaisingEvents = true;
			// kad se file kreira, prvo okine Created, ali tad se jos ne moze procitati jer nije upisan sadrzaj filea
			// Changed okida nakon sto se upise sadrzaj, i to vise puta pa treba file obrisati nakon sto se procita prvi puta
			_serverWatcher.Changed += (object sender, FileSystemEventArgs e) =>
			{
				string respPath = Path.Combine(this.ResponseDirectory, e.Name);
				string errorRespPath = CreateErrorFileName(respPath);
				byte[] data = null;

				// unutar locka provjeri da li file postoji, procitaj ga i obrisi, da ne cita vise puta isti file
				lock (_rwlock)
				{
					++_entrances;
					while (_entrances > this.ParallelRequestsMax)
					{
						Monitor.Wait(_rwlock, 2000);
					}

					if (!File.Exists(e.FullPath))
					{
						this.ReleaseOne();
						return;
					}

					try
					{
						data = File.ReadAllBytes(e.FullPath);
						File.Delete(e.FullPath);
					}
					catch (Exception ex2)
					{
						File.WriteAllText(errorRespPath, ex2.ToString());
						this.ReleaseOne();
						return;
					}
				}

				Thread thr1 = new Thread(() =>
				{
					try
					{
						this.OnRequestDataReceived?.Invoke(new TransportRequest()
						{
							Data = data,
							FnSendResponse = (byte[] reponseData) =>
							{
								File.WriteAllBytes(respPath, reponseData);
								this.ReleaseOne();
							}
						});
					}
					catch(Exception ex1)
					{
						File.WriteAllText(errorRespPath, ex1.ToString());
						this.ReleaseOne();
					}

				}).StartBackground();
			};
		}

		public void StopListening()
		{
			_serverWatcher?.Dispose();
		}

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();

			this.StopListening();

			this.OnRequestDataReceived = null;
		}

	}
}