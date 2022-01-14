namespace Calysto.Web
{
	export class CalystoVirtualPathHelper
	{
		private _path: string;
		public constructor(path: string)
		{
			this._path = path;
		}

		//#region public convert to methods

		private _appRelative: string;
		public ToAppRelativeUrlPath() { return this._appRelative ?? (this._appRelative = CalystoVirtualPathHelper.CreateAppRelativePath(this._path)); }

		private _virtualPath: string;
		public ToVirtualUrlPath() { return this._virtualPath ?? (this._virtualPath = CalystoVirtualPathHelper.CombineToVirtualPath([CalystoVirtualPathHelper.GetBasePath(), this.ToAppRelativeUrlPath()])); }

		//#endregion

		//#region public static methods

		/// <summary>
		/// create ~/path...
		/// </summary>
		/// <param name="anyPath"></param>
		/// <returns></returns>
		private static CreateAppRelativePath(anyPath: string)
		{
			let str1 = anyPath;
			let index;
			if ((index = anyPath.lastIndexOf("/~/")) >= 0)
			{
				// image files in css are prefixed with ~/ so url created on client looks like this:
				// ~/_resources/SiteSpecific/eregistar/css/~/_resources/images/background/bg-43252.jpg
				// http://localhost/ArizonaWebCore/_resources/SiteSpecific/eregistar/css/~/_resources/images/background/bg-43252.jpg
				str1 = anyPath.Substring(index + 1);
			}

			if (str1.StartsWith("~/"))
				return str1;

			// remove base part
			let basePath = CalystoVirtualPathHelper.GetBasePath();
			if (anyPath.StartsWith(basePath, true))
				str1 = anyPath.Substring(basePath.length);

			if (str1.StartsWith("~/"))
				return str1;
			else if (str1.StartsWith("/"))
				return "~" + str1;
			else
				return "~/" + str1;
		}

		/// <summary>
		/// Combine app relative or virtual paths.
		/// Replaces multiple slashes with single one.
		/// Replaces left slahs with right one.
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		private static CombineToVirtualPath(paths: string[])
		{
			let str1 = paths.join("/")
				.ReplaceAll("~/", "/")
				.ReplaceAll("\\", "/")
				.TrimEnd(['/']);

			if (String.IsNullOrEmpty(str1) || str1 == "~")
				str1 += "/";

			return str1.replace(new RegExp("[/]{2,}", "g"), "/");
		}


		private static GetBasePath()
		{
			let basePath = Calysto.Core.Constants.UrlPathBase || "";
			if (basePath == "/")
				return "";
			else if (basePath.EndsWith("/"))
				return basePath.TrimEnd(['/']);
			else
				return basePath;
		}
	}
}