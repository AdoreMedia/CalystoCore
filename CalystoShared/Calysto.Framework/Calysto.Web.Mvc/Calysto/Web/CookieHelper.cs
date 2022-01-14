using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Calysto.Web
{
	public static class CookieHelper
	{
		/// <summary>
		/// Remove www and set dot at the beginning.
		/// </summary>
		/// <param name="domain"></param>
		/// <returns></returns>
		public static string AdjustDomain(string domain)
		{
			if (string.IsNullOrEmpty(domain))
				return null;

			if (domain.StartsWith(".www"))
				domain = domain.Substring(4);
			else if (domain.StartsWith("www"))
				domain = domain.Substring(3);

			if (string.IsNullOrEmpty(domain))
				return null;

			if (!domain.StartsWith("."))
				domain = "." + domain;

			return domain;
		}

		public static bool TryGetCookieValue(string cookieName, out string result)
		{
			return CalystoMvcHostingEnvironment.Current.HttpContext.Request.Cookies.TryGetValue(cookieName, out result);
		}

		public static bool HasCookie(string cookieName)
		{
			return TryGetCookieValue(cookieName, out string result);
		}

		public static void SetCookie(string cookieName, string value, CookieOptions options = null)
		{
			if (options != null)
			{
				options.Domain = AdjustDomain(options.Domain);
				CalystoMvcHostingEnvironment.Current.HttpContext.Response.Cookies.Append(cookieName, value, options);
			}
			else
			{
				CalystoMvcHostingEnvironment.Current.HttpContext.Response.Cookies.Append(cookieName, value);
			}
		}

		public static void DeleteCookie(string cookieName)
		{
			CalystoMvcHostingEnvironment.Current.HttpContext.Response.Cookies.Delete(cookieName);
		}

		public static class Json
		{
			public static bool TryGetCookieValue<T>(string cookieName, out T result)
			{
				if (CookieHelper.TryGetCookieValue(cookieName, out string value))
				{
					try
					{
						result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
						return true;
					}
					catch
					{
						CalystoMvcHostingEnvironment.Current.HttpContext.Response.Cookies.Delete(cookieName);
					}
				}
				result = default(T);
				return false;
			}

			public static void AppendCookie<T>(string cookieName, T value, CookieOptions options = null)
			{
				string json = JsonConvert.SerializeObject(value);
				CookieHelper.SetCookie(cookieName, json, options);
			}
		}
	}
}
