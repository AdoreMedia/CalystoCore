using System;
using System.Web;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Web.SessionState;
using Calysto.Web.UI;
using System.Collections.Specialized;
using System.Net;
using System.Collections.Generic;
using Calysto.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services
{
	class WsjsTypeHandler : IHttpHandler // , IRequiresSessionState // include this interface to enable session
	{
		public void ProcessRequest(HttpContext context)
		{
			// some browsers convert all to upper case or lower case, this way we test it
			AjaxQueryStringHelper astr = AjaxQueryStringHelperForms.Parse(context);

			if (!astr.isCasingOK)
			{
				// browser changes url chars case, processing is not possible
				context.Response.Cache.SetNoStore();
				context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
				context.Response.Cache.SetExpires(DateTime.Now.AddDays(-100));
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			}
			else
			{
				Task.Run(async () =>
				{
					// has to be invoked from the same thread for the HttpContext.Current to be available (if used inside of user code)
					// or set Current = context in here
					HttpContext.Current = context;

					CalystoResponse resp1 = await new CalystoAjaxHandlerForms(context).ProcessRequestAsync(astr);
					if (resp1 != null)
						await new CalystoResponseHandler(context).FlushResponseAsync(resp1);
				}).Wait();
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}


	}

}
