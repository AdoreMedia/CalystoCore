using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DllUnitTest
{
	public class TestDirectoryService
	{
		string _rootDirectory;
		string _subdirectoryName;

		public TestDirectoryService(string rootDirectory, string subdirectoryName)
		{
			_rootDirectory = rootDirectory;
			_subdirectoryName = subdirectoryName;
		}

		public string InputDirectory => Path.Combine(_rootDirectory, _subdirectoryName, "Input");
		public string OutputDirectory => Path.Combine(_rootDirectory, _subdirectoryName, "Output");
		public string ExpectedDirectory => Path.Combine(_rootDirectory, _subdirectoryName, "Expected");

		public string CreateFilePath(Func<TestDirectoryService, string> directory, string fileName) => Path.Combine(directory(this), fileName);
	}
}
