using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Calysto.AspNetCore.Mvc.Utility
{
	public class ControllerActionItem
		{
			public string area { get; set; }
			public string controller { get; set; }
			public string action { get; set; }
		}

	public static class ControllerActionItemExtensions
	{
		public static string ToVirtualPath(this ControllerActionItem item)
		{
			HttpContext context = CalystoMvcHostingEnvironment.Current.HttpContext;
			return CalystoMvcHostingEnvironment.Current.LinkGenerator.GetPathByAction(context, item.action, item.controller);
		}

		public static string ToAbsoluteUri(this ControllerActionItem item)
		{
			HttpContext context = CalystoMvcHostingEnvironment.Current.HttpContext;
			return CalystoMvcHostingEnvironment.Current.LinkGenerator.GetPathByAction(context, item.action, item.controller);
		}
	}
}
