using System;
using Calysto.Utility;
using Calysto.IO;
using Calysto.Web.Hosting;

namespace Calysto.Web
{
	public class CalystoVirtualPathHelper
	{
		#region public convert to methods

		string _appRelative;
		/// <summary>
		/// Actually, it creates tilde path ~/ which may not be always app relative path since we have to search for file inside web root directories.
		/// There is no test if it is real app relative path.
		/// </summary>
		/// <returns></returns>
		public string ToAppRelativeUrlPath() => _appRelative ?? (_appRelative = CreateTildeRelativePath(this._path));

		string _virtualPath;
		public string ToVirtualUrlPath()
		{
			return _virtualPath ?? (_virtualPath = CombineToVirtualPath(GetPathBase(), this.ToAppRelativeUrlPath()));
		}

		string _absoluteUrl;
		public string ToAbsoluteUrl()
		{
			if (_absoluteUrl == null)
			{
				if (this.TryCreateAbsoluteUrl(out string url, true))
				{
					_absoluteUrl = url;
				}
				else
				{
					throw new InvalidOperationException("Absolute url can not be created");
				}
			}
			return _absoluteUrl;
		}

		/// <summary>
		/// Absolute url can be created if HttpContext is available.
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public bool TryCreateAbsoluteUrl(out string url, bool exceptionIfFailed = false)
		{
			if(this.TryGetBaseUri(out CalystoUri uri, exceptionIfFailed))
			{
				url = uri.GetSchemeHostPathBase().Trim('/') + CombineToVirtualPath(this.ToAppRelativeUrlPath());
				return true;
			}
			else
			{
				url = null;
				return false;
			}
		}

		string _physicalPath;
		public string ToPhysicalPath()
		{
			return _physicalPath ?? (_physicalPath = CombineToPhysicalPath(CalystoPhysicalPaths.Current.ContentRoot, this.ToAppRelativeUrlPath()));
		}

		public string _embeddePath;
		public string ToEmbeddedPath() => _embeddePath ?? (_embeddePath = EmbeddedFileProvider.CreateEmbeddedFilePath(this.ToAppRelativeUrlPath()));

		#endregion

		#region public static methods

		/// <summary>
		/// create ~/path..., it may not be always app relative path.
		/// </summary>
		/// <param name="anyPath"></param>
		/// <returns></returns>
		private string CreateTildeRelativePath(string anyPath)
		{
			string str1 = anyPath;
			int index;
			if ((index = anyPath.LastIndexOf("/~/")) >= 0)
			{
				// image files in css are prefixed with ~/ so url created on client looks like this:
				// ~/_resources/SiteSpecific/eregistar/css/~/Site81936/_resources/images/background/bg-43252.jpg
				// http://localhost/ArizonaWebCore/_resources/SiteSpecific/eregistar/css/~/_resources/images/background/bg-43252.jpg
				str1 = anyPath.Substring(index + 1);
			}

			if (str1.StartsWith("~/"))
				return str1;

			// remove base part
			string basePath = GetPathBase();
			if (anyPath.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
				str1 = anyPath.Substring(basePath.Length);

			if (str1.StartsWith("~/"))
				return str1;
			else if (str1.StartsWith("/"))
				return "~" + str1;
			else
				return "~/" + str1;
		}

		private bool TryGetBaseUri(out CalystoUri uri, bool exceptionIfFailed)
		{
			uri = CalystoHostingEnvironment.Current?.HostingAbsoluteUri ?? CalystoHostingEnvironment.GetUnittest2CalystoUri();
			if (uri != null)
			{
				return true;
			}
			else if (exceptionIfFailed)
			{
				throw new InvalidOperationException("HttpContext not available");
			}
			else
			{
				uri = null;
				return false;
			}
		}

		private string GetPathBase()
		{
			if (this.TryGetBaseUri(out CalystoUri uri, true))
				return uri.PathBase;
			else
				throw new InvalidOperationException("HttpContext not available");
		}

		/// <summary>
		/// Combine app relative or virtual paths.
		/// Replaces multiple slashes with single one.
		/// Replaces left slahs with right one.
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		public static string CombineToVirtualPath(params string[] paths)
		{
			string str1 = string.Join("/", paths)
				.Replace("~/", "/")
				.Replace("~\\", "/")
				.Replace("\\", "/")
				.TrimEnd('/');

			if (string.IsNullOrEmpty(str1) || str1 == "~")
				str1 += "/";

			return CalystoTools.NormalizeDirectorySeparatorChar(str1, '/');
		}

		public static string CombineToPhysicalPath(params string[] paths)
		{
			string str1 = string.Join("\\", paths)
				.Replace("~\\", "\\")
				.Replace("~/", "\\");

			return CalystoTools.NormalizeDirectorySeparatorChar(str1);
		}

		#endregion

		protected string _path;

		/// <summary>
		/// Create from virtual or app relative path.
		/// </summary>
		/// <param name="path"></param>
		public CalystoVirtualPathHelper(string path)
		{
			_path = path;
		}

	}
}


