using System;
using System.Web;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Web.SessionState;

namespace Calysto.Web.Script.Services
{
	class WsjsTypeHandlerWithSession : WsjsTypeHandler, IRequiresSessionState // include this interface to enable session
	{

	}

}
