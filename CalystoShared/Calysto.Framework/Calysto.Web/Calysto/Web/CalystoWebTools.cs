using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calysto.Web
{
	public class CalystoWebTools
	{
		#region ParseCssStyleValues

		public static List<KeyValuePair<string, string>> ParseCssStyleValues(string style)
		{
			// should parse style like this:
			// background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAAICAQAAACxSAwfAAAAUklEQ…BbClcIUcSAw21QhXxfIIrwKAMpfNsEUYRXGVCEFc6CQwBqq4CCCtU4VgAAAABJRU5ErkJggg==),-webkit-linear-gradient(#ededed,#ededed 38%,#dedede);

			return new Regex("(?<name>[^:;]+):(?<value>(([\\(][^\\)]+[\\)])|[^:;])*)").Matches(style ?? "").Cast<Match>()
				.Select(m => new KeyValuePair<string, string>(m.Groups["name"].Value.Trim(), m.Groups["value"].Value.Trim()))
				.Where(o => !string.IsNullOrEmpty(o.Key)).ToList();
		}

		#endregion

		#region Create JS namespace using functions

		/// <summary>
		/// Create namespace using nested functions, like TypeScript does.
		/// </summary>
		/// <param name="fullPath">Part1.Part2.Part3.Part4</param>
		/// <returns></returns>
		public static string CreateJsNamespace(string fullPath)
		{
			var parts = fullPath.Split('.').ToList();
			return CreateRoot(parts);
		}

		private static string CreateRoot(List<string> parts)
		{
			string name = parts.FirstOrDefault();
			if (name == null)
				return null;

			parts.RemoveAt(0);
			return $@"var {name};
(function({name}){{
	{CreateNested(parts, name)}				
}})({name} || ({name} = {{}}));";
		}

		private static string CreateNested(List<string> parts, string parentName)
		{
			string name = parts.FirstOrDefault();
			if (name == null)
				return null;
			parts.RemoveAt(0);
			return $@"var {name};
(function({name}){{
	{CreateNested(parts, name)}				
}})({name} = {parentName}.{name} || ({parentName}.{name} = {{}}));";
		}

		#endregion

	}
}


