using System.IO;
using System.Reflection;

namespace Calysto.IO
{
	public class EmbeddedFileInfo : CalystoFileInfo
	{
		protected override byte[] ReadFileBytes()
		{
			using (Stream s = this.Assembly.GetManifestResourceStream(this.FilePath))
			{
				using (MemoryStream ms = new MemoryStream())
				{
					s.CopyTo(ms);
					return ms.ToArray();
				}
			}
		}

		public Assembly Assembly { get; }

		public override byte[] FileBytes => _fileBytes ?? (_fileBytes = ReadFileBytes());

		/// <summary>
		/// Embedded file, use ContentHash
		/// </summary>
		/// <returns></returns>
		public override string GetFileLastWriteTimeHash() => "em" + this.ContentHash;

		public EmbeddedFileInfo(string path, Assembly assembly) : base(path)
		{
			this.Assembly = assembly;
		}
	}
}
