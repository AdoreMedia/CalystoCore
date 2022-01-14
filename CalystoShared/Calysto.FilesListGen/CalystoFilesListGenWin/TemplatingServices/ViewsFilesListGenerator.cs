using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;

namespace Calysto.Text.TemplatingServices
{
	public class ViewsListGenerator : ProjectFilesListGenerator
	{
		public ViewsListGenerator(string rootDirectory, string namespaceName, string className, List<string> startDirsList)
			: base(rootDirectory, namespaceName, className, new List<string>() { ".cshtml" }, startDirsList)
		{
		}

		protected override IEnumerable<string> GenerateMembers()
		{
			foreach (string file in this.GetSourceFiles().Distinct().OrderBy(o => o))
			{
				yield return $"		public static string {this.GetPropertyName(file, true)} => _provider.GetExistingView(\"{this.GetRootRelativeFilePath(file, true).Trim('~')}\");";
			}
		}

		public override string GenerateClass()
		{
			return $@"using System.Reflection;
using Calysto.AspNetCore.Mvc.ViewEngines;

namespace {_namespaceName}
{{
	public static class {_className}
	{{
		private static ViewsListProvider _provider = new ViewsListProvider(Assembly.GetExecutingAssembly());

{GenerateMembers().ToStringJoined("\r\n")}
	}}
}}
";
		}
	}
}

