using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;

namespace Calysto.Text.TemplatingServices
{
	public class StartDirRelativeFilesListGenerator : ProjectFilesListGenerator
	{
		public StartDirRelativeFilesListGenerator(string rootDir, string namespaceName, string className, List<string> fileExtensions, List<string> startDirsList)
			: base(rootDir, namespaceName, className, fileExtensions, startDirsList)
		{
		}

		protected virtual string GetWwwRootContentFilePath(string file)
		{
			string f1 = base.GetRootRelativeFilePath(file);

			// create relative paths from wwwroot
			// must have <base="/root/" /> in html defined, files are without slash at start, relative to base url
			foreach(string startDir in _startDirsList)
			{
				string f2 = base.GetRootRelativeFilePath(startDir);

				if (f1.StartsWith(f2, System.StringComparison.OrdinalIgnoreCase))
				{
					return f1.Replace(f2, "").TrimStart('/', ' ');
				}
			}
			throw new System.InvalidOperationException();
		}

		protected override IEnumerable<string> GenerateMembers()
		{
			foreach (string file in this.GetSourceFiles().Distinct().OrderBy(o => o))
			{
				yield return $"		public const string {this.GetPropertyName(file)} = \"{this.GetWwwRootContentFilePath(file)}\";";
			}
		}

	}
}

