using System.Collections.Generic;
using Calysto.Linq;

namespace Calysto.Web.Script.MapFile
{
	public class MapFileCache
	{
		static Dictionary<string, string> _dic = new Dictionary<string, string>();

		public static string GetFileScriptWithMap(string absoluteFilePath, string scriptContent)
		{
			return _dic.GetValueOrAdd(absoluteFilePath + "***" + scriptContent, key =>
			{
				MapFileExpander expander = new MapFileExpander(absoluteFilePath, scriptContent);
				return expander.GetFileContent();
			});
		}
	}
}
