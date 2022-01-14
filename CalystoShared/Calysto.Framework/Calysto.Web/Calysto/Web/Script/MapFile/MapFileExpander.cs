using Calysto.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.Web.Script.MapFile
{
	/// <summary>
	/// Read map file defined by # sourceMappingURL=... in CSS or JS files, and include map content instead of url in # sourceMappingURL=...
	/// It is required to include map content into main js or css file for WebView2 since there is no way to load map file later when requested from WebView2.
	/// </summary>
	public class MapFileExpander
	{
		private string _mainFilePath;
		private string _mainContent;

		public MapFileExpander(string mainFileAbsolutePath, string mainContent)
		{
			_mainFilePath = mainFileAbsolutePath;
			_mainContent = mainContent;
		}

		private string GetAbsolutePath2(string path)
		{
			path = path.TrimStart('/', '\\', '~');

			if (!Path.IsPathRooted(path))
				return Path.Combine(Path.GetDirectoryName(_mainFilePath), path);
			else
				return path;
		}

		private string GetAbsolutePathNormalized(string path)
		{
			return CalystoTools.NormalizeDirectorySeparatorChar(this.GetAbsolutePath2(path));
		}

		Regex _re1 = new Regex("# sourceMappingURL=(?<file>[\\w_\\-\\~\\\\\\.\\~ ]+)");

		private bool TryGetMapFileRelativePath(string fileContent, out string mapFilePath)
		{
			Match m1 = _re1.Match(fileContent);
			if (m1.Success)
			{
				mapFilePath = this.GetAbsolutePathNormalized(m1.Groups["file"].Value);
				return true;
			}
			else
			{
				mapFilePath = null;
				return false;
			}
		}

		private string GetContentType()
		{
			string ext1 = Path.GetExtension(_mainFilePath);
			if (ext1 == ".js")
				return "application/json";
			else if (ext1 == ".css")
				return "text/css";
			else
				throw new NotSupportedException(ext1);
		}

		private string InsertMapContent(string mainFileContent, string mapContent)
		{
			return _re1.Replace(mainFileContent, m =>
			{
				// js: # sourceMappingURL=data:application/json;base64,...
				// css: # sourceMappingURL=data:text/css;base64,...
				return $"# sourceMappingURL=data:{this.GetContentType()};base64," + Convert.ToBase64String(Encoding.UTF8.GetBytes(mapContent));
			});
		}

		// js file map content: {"version":3,"file":"file.js","sourceRoot":"","sources":["file.ts"],"names":[],"mappings":"...","sourcesContent":[...]}
		// css file map content: {"version": 3,"file": "_includes.css","sources": ["_includes.scss"],"names": [],"mappings": "...","sourcesContent":[...]}
		// sourcesContent je opcionalni property koji postoji samo ako je content source fileova ukljucen u map file

		// mainFile last line content
		// for JS: //# sourceMappingURL=Engine.complete.js.map
		// for CSS: /*# sourceMappingURL=_includes.css.map */

		public string GetFileContent()
		{
			bool includeMapContent = true;
			bool includeSourcesContent = true;
			string mainFileAbsolutePath = this.GetAbsolutePathNormalized(_mainFilePath);

			if (!File.Exists(mainFileAbsolutePath))
				return _mainContent;

			string mainContent1 = File.ReadAllText(mainFileAbsolutePath);

			if (includeMapContent && File.Exists(mainFileAbsolutePath + ".map") && this.TryGetMapFileRelativePath(mainContent1, out string mapFilePath) && File.Exists(mapFilePath))
			{
				string mapContent = File.ReadAllText(this.GetAbsolutePathNormalized(mapFilePath));
				if (includeSourcesContent)
				{
					MapFileModel mapItem = Calysto.Serialization.Json.JsonSerializer.Deserialize<MapFileModel>(mapContent);
					if (mapItem.sources?.Count > 0 && mapItem.sources?.Count != mapItem.sourcesContent?.Count)
					{
						mapItem.sourcesContent = mapItem.sources.Select(srcFile =>
						{
							string path2 = this.GetAbsolutePathNormalized(srcFile);
							return File.ReadAllText(path2);
						}).ToList();
					}
					mapContent = Calysto.Serialization.Json.JsonSerializer.Serialize(mapItem);
				}
				mainContent1 = this.InsertMapContent(mainContent1, mapContent);
			}
			return mainContent1;
		}
	}
}
