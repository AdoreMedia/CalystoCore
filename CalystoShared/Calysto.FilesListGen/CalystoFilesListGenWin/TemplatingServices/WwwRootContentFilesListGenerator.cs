using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;

namespace Calysto.Text.TemplatingServices
{
	public class WwwRootContentFilesListGenerator : ProjectFilesListGenerator
	{
		string _assemblyName;

		public WwwRootContentFilesListGenerator(string rootDir, string namespaceName, string className, List<string> fileExtensions, List<string> startDirsList, string assemblyName)
			: base(rootDir, namespaceName, className, fileExtensions, startDirsList)
		{
			if (assemblyName.EndsWith(".dll", System.StringComparison.OrdinalIgnoreCase))
				assemblyName = assemblyName.Substring(0, assemblyName.Length - 4);

			_assemblyName = assemblyName;
		}

		protected virtual string GetWwwRootContentFilePath(string file)
		{
			string f1 = base.GetRootRelativeFilePath(file);

			// produce path like this: "./_content/Calysto.Blazor/ts/Calysto.Blazor.Interop.js"
			return f1.Replace("~/wwwroot/", $"./_content/{_assemblyName}/");
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

