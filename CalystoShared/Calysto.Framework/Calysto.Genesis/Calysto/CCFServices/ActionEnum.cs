using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.CCFServices
{
	public enum ActionEnum
	{
		Unknown = 0,
		InvokeOnce = 1,
		SubscribeEvent = 2,
		UnsubscribeEvent = 3,
		EventTriggered = 4
	}
}
