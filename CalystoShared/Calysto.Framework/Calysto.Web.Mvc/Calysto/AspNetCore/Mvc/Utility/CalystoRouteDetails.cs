using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Mvc.Utility
{
	public class CalystoRouteDetails
	{
		public Func<string> GetRouteName;
		public Func<string> GetRoutePattern;
		public Func<ControllerActionItem> GetRouteDefaults;

		public Func<string> GetLinkName;
		public Func<string> GetLinkVirtualPath;
		public Func<string> GetPageTitle;
		public Func<string> GetPageKeywords;
		public Func<string> GetPageDescription;

		public Func<bool> IsAccessGranted;

	}
}
