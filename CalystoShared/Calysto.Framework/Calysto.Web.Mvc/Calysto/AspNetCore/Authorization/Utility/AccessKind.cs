using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Authorization.Utility
{
	public enum AccessKind
	{
		Unknown,
		Public,
		AllowAnonymous,
		Authorized,
		Forbidden
	}
}
