using System.IO;

namespace Calysto.UnitTesting.Infrastructure
{
	public class FileReadResult
	{
		public byte[] Bytes => File.ReadAllBytes(_fullPath);
		public string Text => File.ReadAllText(_fullPath);
		private string _fullPath;

		public FileReadResult(string fullPath)
		{
			_fullPath = fullPath;
		}
	}
}
