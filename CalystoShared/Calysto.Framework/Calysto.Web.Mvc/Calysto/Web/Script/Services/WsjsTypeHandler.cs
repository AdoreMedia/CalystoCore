using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services
{
	class WsjsTypeHandler : IHttpHandler // , IRequiresSessionState // include this interface to enable session
	{
		public async Task ProcessRequestAsync(HttpContext context)
		{
			// some browsers convert all to upper case or lower case, this way we test it
			AjaxQueryStringHelper astr = AjaxQueryStringHelperMvc.Parse(context);

			if (!astr.isCasingOK)
			{
				// browser changes url chars case, processing is not possible
				var headers = context.Response.GetTypedHeaders();
				headers.Expires = DateTime.Now.AddDays(-100);
				headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue() { NoStore = true, NoCache = true, Public = true };
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			}
			else
			{
				CalystoResponse resp1 = await new CalystoAjaxHandlerMvc(context).ProcessRequestAsync(astr);

				if (resp1 != null)
					await new CalystoResponseHandler(context).FlushResponseAsync(resp1);
			}
		}
	}

}
