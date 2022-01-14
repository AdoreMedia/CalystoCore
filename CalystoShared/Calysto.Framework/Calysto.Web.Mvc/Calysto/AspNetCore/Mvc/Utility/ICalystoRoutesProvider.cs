using System.Collections.Generic;

namespace Calysto.AspNetCore.Mvc.Utility
{
	public interface ICalystoRoutesProvider
	{
		IEnumerable<CalystoRouteDetails> GetRoutes();
	}
}
