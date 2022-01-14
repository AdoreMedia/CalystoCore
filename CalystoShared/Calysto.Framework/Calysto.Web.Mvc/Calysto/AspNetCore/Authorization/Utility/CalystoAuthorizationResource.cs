using Microsoft.AspNetCore.Authorization;

namespace Calysto.AspNetCore.Authorization.Utility
{
	public class CalystoAuthorizationResource
	{
		public AuthorizeAttribute Authorize;
		public object TargetInstance;
	}
}
