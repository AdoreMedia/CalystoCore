using Calysto.IO;
using Calysto.Linq;
using Calysto.Utility;
using Calysto.Web.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Calysto.Web.CalystoPhysicalPaths;

namespace Calysto.Web
{
	public class CalystoPhysicalPathHelper : CalystoVirtualPathHelper
	{
		public CalystoPhysicalPathHelper(string appRelativePath) : base(appRelativePath)
		{
		}

		private IEnumerable<string> GetSearchPhysicalPaths(string tildeRelativePath, SearchLocation item)
		{
			if (string.IsNullOrEmpty(tildeRelativePath))
				throw new ArgumentException($"Can not resolve physical file location from empty path.");

			string path1 = tildeRelativePath.TrimStart('~', '/', '\\');

			// appRelative path dozvoliti samo ako pocinje sa jednim od _webRootPaths-a
			// ne smijemo dopusiti da se mogu dohvacati fileovi is app roota

			string appRootPath = CalystoPhysicalPaths.Current.ContentRoot;

			if (item.IsAbsolute)
			{
				yield return CalystoTools.NormalizeDirectorySeparatorChar(Path.Combine(item.Path, path1));
			}
			else if (appRootPath != null)
			{
				if (string.IsNullOrEmpty(appRootPath))
					throw new InvalidOperationException($"ApplicationRootPath has to be assigned using .RegisterApplicationRootPath(...) method.");

				// item.Path is app relative path
				if (tildeRelativePath.StartsWith(item.Path, StringComparison.OrdinalIgnoreCase))
					yield return CalystoTools.NormalizeDirectorySeparatorChar(Path.Combine(appRootPath, path1));

				// path1 is subdirectory of web root directory
				yield return CalystoTools.NormalizeDirectorySeparatorChar(Path.Combine(appRootPath, item.Path.Trim('~', '/', '\\'), path1));
			}
		}

		enum LocationKind
		{
			Embedded,
			Physical
		}

		private CalystoFileInfo FindFileWorker(List<KeyValuePair<LocationKind, string>> searchedPaths, bool searchPhysical, bool searchEmbedded)
		{
			string tildeRelativePath = null;
			string embededFile = null;
			// ne treba lock jer se lokacije dodaju samo na startu aplikacije
			var locations = CalystoPhysicalPaths.Current.Locations.Where(o => (searchPhysical && o.Path != null) || (searchEmbedded && o.Assembly != null));
			// trazimo po redoslijedu kojim su lokacije dodane
			foreach (var loc in locations)
			{
				if(loc.Assembly != null)
				{
					if (embededFile == null)
					{
						embededFile = this.ToEmbeddedPath();
						searchedPaths.Add(new KeyValuePair<LocationKind, string>(LocationKind.Embedded, embededFile));
					}

					var items = EmbeddedFileProvider.GetFilesInfos(new[] { loc.Assembly })
						.Where(o => o.FilePath.EndsWith(embededFile, StringComparison.OrdinalIgnoreCase))
						.Distinct(o => o.ContentHash)
						.ToList();

					if (items.Count > 1)
						throw new Exception($"Multiple embedded files with different content found: \r\n" + items.Select(o => o.FilePath).ToStringJoined("\r\n"));
					else if (items.Count == 1)
						return new EmbeddedFileInfo(items.First().FilePath, items.First().Assembly);
					// else not found, continue to the next location
				}
				else if(loc.Path != null)
				{
					if (tildeRelativePath == null)
					{
						tildeRelativePath = this.ToAppRelativeUrlPath();
					}

					var paths = this.GetSearchPhysicalPaths(tildeRelativePath, loc)
						.Distinct()
						.Select(o =>
						{
							searchedPaths.Add(new KeyValuePair<LocationKind, string>(LocationKind.Physical, o));
							return o;
						})
						.Where(o => File.Exists(o))
						.Select(o => new PhysicalFileInfo(o))
						.Distinct(o => o.ContentHash)
						.ToList();

					if (paths.Count > 1)
						throw new Exception("Multiple physical files with different content found: \r\n" + paths.Select(o => o.FilePath).ToStringJoined("\r\n"));
					else if (paths.Count == 1)
						return paths.First();
					// else not found, continue to the next location
				}
				else
				{
					throw new InvalidOperationException();
				}
			}

			return null;
		}

		/// <summary>
		/// Find file. Throw exception if file not found or multiple files found.
		/// </summary>
		/// <param name="searchPhysical"></param>
		/// <param name="searchEmbedded"></param>
		/// <param name="silentIfFileNotFound">if true, will return null if file not found, without throwin exception</param>
		/// <returns></returns>
		public CalystoFileInfo FindFile(bool searchPhysical = true, bool searchEmbedded = true, bool silentIfFileNotFound = false)
		{
			List<KeyValuePair<LocationKind, string>> searchedPaths = new List<KeyValuePair<LocationKind, string>>();

			var info = this.FindFileWorker(searchedPaths, searchPhysical, searchEmbedded);

			if (info == null)
			{
				if (silentIfFileNotFound)
				{
					return null;
				}

				throw new FileNotFoundException($@"FileNotFoundException: {this.ToAppRelativeUrlPath()}
Searched locations:
{string.Join("\r\n", searchedPaths.Select(kv=>kv.Key + ": " + kv.Value))}");
			}
			else
			{
				return info;
			}
		}

	}
}
