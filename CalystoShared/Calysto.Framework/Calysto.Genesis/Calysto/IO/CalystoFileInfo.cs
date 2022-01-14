using Calysto.Utility;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Calysto.IO
{
	public abstract class CalystoFileInfo
	{
		public static TimeSpan CacheDuration { get; set; } = TimeSpan.FromSeconds(60);

		public string FilePath { get; protected set; }

		public string Extension { get; private set; }

		protected virtual byte[] ReadFileBytes() => File.ReadAllBytes(this.FilePath);

		protected byte[] _fileBytes;
		public virtual byte[] FileBytes => _fileBytes ?? (_fileBytes = ReadFileBytes());

		protected string _fileText;
		public virtual string FileText => _fileText ?? (_fileText = FileEncodingHelper.DecodeToString(this.FileBytes));

		protected string _base64String;
		public virtual string Base64String => _base64String ?? (_base64String = System.Convert.ToBase64String(this.FileBytes));

		protected string _contentHash;
		/// <summary>
		/// Calculate hash from FileBytes
		/// </summary>
		public virtual string ContentHash => _contentHash ?? (_contentHash = Convert.ToBase64String(MD5.Create().ComputeHash(this.FileBytes)));

		private DateTime? _resultExpiration;
		private DateTime? _previousFileWriteTime;
		private string _timeHash;

		private bool ShouldReadFromFile() => _timeHash == null || _resultExpiration.GetValueOrDefault() < DateTime.Now || !_previousFileWriteTime.HasValue;

		/// <summary>
		/// Used when this instance is cached. Read physical file last write time. If changed, will invalidate FileContent, FileText, ContentHash
		/// </summary>
		/// <returns></returns>
		public virtual string GetFileLastWriteTimeHash()
		{
			// ideja je da se omoguci replace filea u runtimeu, npr. vecem fileu treba vise vremena da se uplodira na server,
			// a dok se uploadira, treba koristiti staru cachiranu verziju

			// ako se file bas replacea s novom verzijom, citanje file-a ce bacati exception
			// zato cemo dopustiti da ne procita, ali samo ako je vec prije uspio procitati time
			// ako jos nema _lastWriteTime, a ne moze procitati file, nek baci exception

			if (this.ShouldReadFromFile())
			{
				lock (this)
				{
					if (this.ShouldReadFromFile())
					{
						try
						{
							// nek ne cita sljedecih x sekundi
							if (CalystoTools.IsDebugDefined)
							{
								_resultExpiration = DateTime.Now.AddMinutes(-10);
							}
							else
							{
								_resultExpiration = DateTime.Now.AddSeconds(CacheDuration.TotalSeconds);
							}

							FileInfo fi1 = new FileInfo(this.FilePath);
							if (!fi1.Exists)
								throw new FileNotFoundException(this.FilePath);

							DateTime freshTime = fi1.LastWriteTime; // ako file ne postoji, vraca datum 1.1.1601.
							if (freshTime.Year < 1900)
								throw new FileLoadException(this.FilePath);

							if (freshTime != _previousFileWriteTime)
							{
								byte[] data1 = this.ReadFileBytes(); // ako je file zauzet, npr. uploadira se na server, nek ovdje baci ex i zadrzi staru vrijednost
								_fileBytes = data1;
								_fileText = null;
								_base64String = null;
								_contentHash = null;
								_previousFileWriteTime = freshTime; // tek kad je uspjesno procitao file, zapisi novo vrijeme, sve dok nije zapisano, pokusavat ce procitati novi sadrzaj iz filea
							}

							_timeHash = "ph" + _previousFileWriteTime.Value.Ticks.ToString();
						}
						catch
						{
							// ako jos nije uspio nikad procitati, nek baci exception
							if (_previousFileWriteTime == null)
								throw;
						}
					}
				}
			}

			return _timeHash;
		}

		public CalystoFileInfo(string filePath)
		{
			this.FilePath = filePath;
			this.Extension = Path.GetExtension(filePath);
		}
	}
}
