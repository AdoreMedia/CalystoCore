using Calysto.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace Calysto.AspNetCore.Mvc.Routing
{
	public class CalystoAjaxFormSubmitAttribute : ActionMethodSelectorAttribute
	{
		public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
		{
			return routeContext.HttpContext.Request.IsClaystoAjaxFormSubmit();
		}
	}
}
