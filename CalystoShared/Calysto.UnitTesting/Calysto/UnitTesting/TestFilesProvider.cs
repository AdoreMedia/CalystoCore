using Calysto.UnitTesting.Infrastructure;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Calysto.UnitTesting
{
	public class TestFilesProvider2
	{
		public string RootDirectory { get; private set; }

		public string CreateAbsolutePath(string rootDirectoryRelativePath)
		{
			return Path.Combine(this.RootDirectory, rootDirectoryRelativePath);
		}

		/// <summary>
		/// Result file name only
		/// </summary>
		string _fileName;

		public string GetFilePath(DirectoryNameEnum directory) => Path.Combine(RootDirectory, directory.ToString(), _fileName);

		public TestFileInfo Input { get; private set; }
		public TestFileInfo Actual { get; private set; }
		public TestFileInfo Expected { get; private set; }

		/// <summary>
		/// Find in ancestor directory where .csproj file is
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		/// <exception cref="FileNotFoundException"></exception>
		private static FileInfo FindProjectFileInfo2(Assembly assembly = null)
		{
			assembly = assembly ?? Assembly.GetExecutingAssembly();
			string dir1 = Path.GetDirectoryName(assembly.Location);
			DirectoryInfo dd2 = new DirectoryInfo(dir1);
			int loops1 = 0;
			while (loops1++ < 5 && dd2 != null)
			{
				FileInfo[] files = dd2.GetFiles("*.csproj");
				if (files.Any())
				{
					return files.First();
				}
				dd2 = dd2.Parent;
			}
			throw new FileNotFoundException("*.csproj");
		}

		private string RemoveEndingSlash(string str)
		{
			return str.TrimEnd('/', '\\');
		}

		public TestFilesProvider2(string inputFilePath)
		{
			if (Path.IsPathRooted(inputFilePath))
			{
				RootDirectory = Path.GetDirectoryName(inputFilePath);
			}
			else
			{
				string rootPath = FindProjectFileInfo2().DirectoryName;
				string dirName = Path.GetDirectoryName(inputFilePath);
				RootDirectory = Path.Combine(rootPath, dirName);
			}

			RootDirectory = this.RemoveEndingSlash(RootDirectory);

			Enum.GetNames(typeof(DirectoryNameEnum)).ToList().ForEach(name =>
			{
				if (RootDirectory.EndsWith(name, StringComparison.OrdinalIgnoreCase))
					RootDirectory = RootDirectory.Remove(RootDirectory.Length - name.Length);
			});

			_fileName = Path.GetFileName(inputFilePath);
			this.Input = new TestFileInfo(this.GetFilePath(DirectoryNameEnum.Input));
			this.Actual = new TestFileInfo(this.GetFilePath(DirectoryNameEnum.Actual));
			this.Expected = new TestFileInfo(this.GetFilePath(DirectoryNameEnum.Expected));
		}

		/// <summary>
		/// Add sufix to Actual and Expected files.
		/// </summary>
		/// <param name="outputFilesSufix"></param>
		/// <returns></returns>
		public TestFilesProvider2 AppendOutputFilesSufix(string outputFilesSufix)
		{
			this.Actual = new TestFileInfo(this.Actual.FullPath + outputFilesSufix);
			this.Expected = new TestFileInfo(this.Expected.FullPath + outputFilesSufix);
			return this;
		}

		/// <summary>
		/// Save actual content than compare with expected content usint compareAction.
		/// </summary>
		/// <param name="compareAction">(expected, actual) => { .... } </param>
		/// <param name="actualContent">Actual content</param>
		public void Assert(Action<string, string> compareAction, string actualContent)
		{
			this.Actual.Save(actualContent);
			compareAction.Invoke(this.Expected.Read().Text, actualContent);
		}

		public void Assert(Action<string, string> compareAction, byte[] actualContent)
		{
			this.Actual.Save(actualContent);
			string exp1 = Convert.ToBase64String(this.Expected.Read().Bytes);
			string actual1 = Convert.ToBase64String(actualContent);
			compareAction.Invoke(exp1, actual1);
		}

		public string ReadInputText() => this.Input.Read().Text;
		public string ReadInputText(string fileName) => this.Input.Read(fileName).Text;
		public byte[] ReadInputBytes() => this.Input.Read().Bytes;
		public byte[] ReadInputBytes(string fileName) => this.Input.Read(fileName).Bytes;

	}

}
