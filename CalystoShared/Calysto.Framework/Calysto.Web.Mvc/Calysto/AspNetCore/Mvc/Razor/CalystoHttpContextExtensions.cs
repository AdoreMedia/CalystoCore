using Calysto.AspNetCore.Mvc.Utility;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Calysto.AspNetCore.Mvc.Razor
{
	public static class CalystoHttpContextExtensions
	{
		public static bool IncludeOnce<TKey>(this HttpContext context, TKey key)
		{
			lock (context.Items)
			{
				if (context.Items.ContainsKey(key))
					return false;

				context.Items.Add(key, true);
				return true;
			}
		}


		/// <summary>
		/// Create complete virtual path with base path. Verify if action and controller exists. Return generated url path.
		/// Throw exception if path is invalid.
		/// </summary>
		public static string GetPathByActionSafe(this HttpContext context, string controllerTypeName, string action = "Index")
		{
			var res1 = CalystoMvcUtility.CreateControllerActionSafe(controllerTypeName, action);

			//create path with base path, base path info takes from Context
			return CalystoMvcHostingEnvironment.Current.LinkGenerator.GetPathByAction(context, res1.action, res1.controller);
		}

		/// <summary>
		/// Create complete uri with http. Verify if action and controller exists. Return generated url path.
		/// Throw exception if path is invalid.
		/// </summary>
		public static string GetUriByActionSafe(this HttpContext context, string controllerTypeName, string action = "Index")
		{
			var res1 = CalystoMvcUtility.CreateControllerActionSafe(controllerTypeName, action);

			// create http:// full uri, base path info takes from Context
			return CalystoMvcHostingEnvironment.Current.LinkGenerator.GetUriByAction(context, res1.action, res1.controller);
		}
	}
}

