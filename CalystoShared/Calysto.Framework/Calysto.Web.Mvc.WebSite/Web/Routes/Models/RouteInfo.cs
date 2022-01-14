using Calysto.AspNetCore.Authorization.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Calysto.Web.TestSite.Web.VS.Routes.Models
{
	public class RouteInfo
	{
		public string DisplayName;
		public string ControllerName;
		public string ActionName;
		public string AttributeRouteTemplate;
		public string AttributeRouteName;
		public string ActionVirtualPath;

		public List<AuthorizeAttribute> Authorize;
		public List<AllowAnonymousAttribute> AllowAnonymous;
		public AccessKind Access;
		public bool NoAction;
	}
}
