using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using Calysto.Utility;

namespace Calysto.IO
{
	public class EmbeddedFileProvider
	{
		public static IEnumerable<EmbeddedFileInfo> GetFilesInfos(IEnumerable<Assembly> assemblies)
		{
			return assemblies.SelectMany(assembly =>
			{
				var names = assembly.GetManifestResourceNames();
				return names.Where(k => !string.IsNullOrEmpty(k)).Select(k => new EmbeddedFileInfo(k, assembly));
			});
		}

		/// <summary>
		/// Find resource with name ending with resourceName. Throw exception if file not found.
		/// </summary>
		/// <param name="assemblies"></param>
		/// <param name="resourceName"></param>
		/// <param name="silentIfFileNotFound"></param>
		/// <returns></returns>
		public static EmbeddedFileInfo GetSingleFileInfo(IEnumerable<Assembly> assemblies, string resourceName, bool silentIfFileNotFound = false)
		{
			var items = GetFilesInfos(assemblies).Where(o => o != null && o.FilePath.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase)).ToList();

			if (items.Count == 1)
			{
				return items.First();
			}
			else if (items.Count > 1)
			{
				throw new Exception("Multiple embedded files found: " + string.Join(";\r\n", items.Select(o => o.FilePath)));
			}
			else if (!silentIfFileNotFound)
			{
				throw new FileNotFoundException("Embedded file not found: " + resourceName);
			}
			
			return null;
		}

		public static byte[] GetFileBytes(IEnumerable<Assembly> assemblies, string resourceName)
		{
			return GetSingleFileInfo(assemblies, resourceName).FileBytes;
		}

		/// <summary>
		/// Detect encoding. Use UTF8 if BOM is not found.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="resourceName"></param>
		/// <returns></returns>
		public static string GetFileText(Assembly[] assemblies, string resourceName)
		{
			return GetSingleFileInfo(assemblies, resourceName).FileText;
		}

		/// <summary>
		/// Convert physical filename into embedded filename.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string CreateEmbeddedFilePath(string fileName)
		{
			// embedded file: "-" in directories is replaced with "_" , but  "-" in filename is not replaced
			string str = (fileName ?? "").Replace("/", "\\").Trim('~', '/', '\\', '.', ' ', '\r', '\n', '\t');

			string dir = Path.GetDirectoryName(str).Replace("-", "_").Replace("/", ".").Replace("\\", ".");

			if (!string.IsNullOrEmpty(dir))
				dir += ".";

			string file = Path.GetFileName(str);
			return "." + dir + file;
		}

	}
}