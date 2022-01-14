using System.IO;

namespace Calysto.UnitTesting.Infrastructure
{
	public class TestFileInfo
	{
		public string FullPath { get; }

		public string DirectoryPath { get; set; }

		public TestFileInfo(string fileFullPath)
		{
			this.FullPath = fileFullPath;
			this.DirectoryPath = Path.GetDirectoryName(fileFullPath);
		}

		private void EnsureDirectoryExists()
		{
			if (!Directory.Exists(this.DirectoryPath))
				Directory.CreateDirectory(this.DirectoryPath);
		}

		public void Save(string text)
		{
			this.EnsureDirectoryExists();
			File.WriteAllText(this.FullPath, text);
		}

		public void Save(byte[] data)
		{
			this.EnsureDirectoryExists();
			File.WriteAllBytes(this.FullPath, data);
		}

		public FileReadResult Read() => new FileReadResult(this.FullPath);

		public FileReadResult Read(string fileName) => new FileReadResult(Path.Combine(this.DirectoryPath, fileName));
	}
}
