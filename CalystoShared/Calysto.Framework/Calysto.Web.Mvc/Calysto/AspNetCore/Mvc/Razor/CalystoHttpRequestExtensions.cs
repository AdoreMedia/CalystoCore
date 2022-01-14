using Calysto.Web.Script.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;

namespace Calysto.AspNetCore.Mvc.Razor
{
	public static class CalystoHttpRequestExtensions
	{
		public static bool IsClaystoAjaxFormSubmit(this HttpRequest request)
		{
			return request?.Headers.TryGetValue(WsjsHeaderConstants.XCalystoAjaxFormKey, out StringValues value) == true
				&& value + "" == WsjsHeaderConstants.XCalystoAjaxFormValue;
		}

		public static bool IsClaystoAjaxRequest(this HttpRequest request)
		{
			return request?.Headers.TryGetValue(WsjsHeaderConstants.XAjaxHeaderKey, out StringValues value) == true
				&& value + "" == WsjsHeaderConstants.XAjaxHeaderValue;
		}

		//public static bool IsClaystoAjaxLoad(this HttpRequest request)
		//{
		//	return request?.Headers.TryGetValue(WsjsHeaderConstants.XCalystoAjaxLoadKey, out StringValues value) == true
		//		&& value + "" == WsjsHeaderConstants.XCalystoAjaxLoadValue;
		//}

		/// <summary>
		/// Is any of IsClaystoAjaxFormSubmit() or IsClaystoAjaxRequest()
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static bool IsClaystoAjax(this HttpRequest request)
		{
			return request.IsClaystoAjaxFormSubmit() || request.IsClaystoAjaxRequest(); // || request.IsClaystoAjaxLoad();
		}

		/// <summary>
		/// Returns ~/ path.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string GetAppRelativePath(this HttpRequest request)
		{
			string path = request.Path.Value;
			if (path.StartsWith("~/"))
				return path;
			else if (path.StartsWith("/"))
				return "~" + path;
			else if (string.IsNullOrEmpty(path))
				return "~/";
			else
				throw new ArgumentException(path);
		}

		/// <summary>
		/// Returns virtual path (PathBase + Path) with / at start.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string GetVirtualPath(this HttpRequest request)
		{
			return request.PathBase + request.Path;
		}
	}
}

