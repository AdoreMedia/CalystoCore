using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Calysto.Linq;
using System.Text.RegularExpressions;
using Calysto.Common.Extensions;
using Calysto.Utility;

namespace Calysto.Text.TemplatingServices
{
	public class ProjectFilesListGenerator
	{
		public readonly List<string> Exclude = new List<string>() { "bin", "obj" };
		public readonly List<string> Subdirectories = new List<string>();
		protected string _namespaceName;
		protected string _className;
		protected List<string> _fileExtensionsList;
		protected List<string> _startDirsList;
		protected string _rootDir;

		public ProjectFilesListGenerator(string rootDir, string namespaceName, string className, List<string> fileExtensions, List<string> startDirsList)
		{
			_rootDir = rootDir;
			_fileExtensionsList = fileExtensions.Select(o => o.Trim(' ', '*', '.', ',', ';')).Where(o => !string.IsNullOrWhiteSpace(o)).Select(o => o.StartsWith(".") ? o : "." + o).ToList();
			_startDirsList = startDirsList?.ToList() ?? new List<string>() { CalystoTools.NormalizeDirectorySeparatorChar(rootDir) };
			_namespaceName = namespaceName;
			_className = className;
		}

		private IEnumerable<string> GetExcludedDirectories()
		{
			foreach (string str in this.Exclude)
				yield return Path.DirectorySeparatorChar + str.Trim(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
		}

		protected IEnumerable<string> GetSourceFiles()
		{
			List<string> excludedDirs = this.GetExcludedDirectories().ToList();

			foreach (string startDir in _startDirsList)
			{
				foreach (string fileExt in _fileExtensionsList)
				{
					foreach (string filePath in Directory.EnumerateFiles(startDir, "*" + fileExt, SearchOption.AllDirectories))
					{
						if (!excludedDirs.Any(dir => filePath.Contains(dir, true)))
						{
							yield return filePath;
						}
					}
				}
			}
		}

		public virtual string GenerateClass()
		{
			return $@"namespace {_namespaceName}
{{
	public static class {_className}
	{{
{GenerateMembers().ToStringJoined("\r\n")}
	}}
}}
";
		}

		protected string GetRootRelativeFilePath(string filePath, bool removeExtension = false)
		{
			// file path is relative to root directory
			string str1 = "~/" + filePath.Substring(_rootDir.Length).Trim('\\', '/').Replace("\\", "/");

			// used when creating [view]: .cshtml path has to be without extension, engine will create path variations with culture info, e.g. path.en-US.cshtml
			if (removeExtension)
				str1 = Path.ChangeExtension(str1, "").TrimEnd('.');

			return str1;
		}

		protected string GetPropertyName(string filePath, bool removeExtension = false)
		{
			// property name starts root Web
			// remove extension from property name
			return this.GetRootRelativeFilePath(filePath, removeExtension).Trim('~', '.', ',', '/', '\\', ' ')
				.Replace(" ", "_")
				.Replace(".", "_")
				.Replace("/", "_")
				.Replace("\\", "_")
				.Replace("-", "_")
				.Replace("@", "_");
		}

		protected virtual IEnumerable<string> GenerateMembers()
		{
			foreach (string file in this.GetSourceFiles().Distinct().OrderBy(o => o))
			{
				yield return $"		public const string {this.GetPropertyName(file)} = \"{this.GetRootRelativeFilePath(file)}\";";
			}
		}
	}
}

