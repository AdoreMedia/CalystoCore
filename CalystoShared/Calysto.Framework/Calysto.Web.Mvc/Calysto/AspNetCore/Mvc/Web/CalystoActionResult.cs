using Calysto.Web;
using Calysto.Web.Script.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Mvc.Web
{
	public class CalystoActionResult : IActionResult
	{
		CalystoResponse _resp;
		public CalystoActionResult(CalystoResponse resp)
		{
			_resp = resp;
		}

		public Task ExecuteResultAsync(ActionContext context)
		{
			// we have to sent text/plain for old browsers to insert it into iframe,
			// json will not be inserted, instedad, browser asks user to save received content
			// must be text/html because text/plain add <pre>...</pre> arround content
			return new CalystoResponseHandler(context.HttpContext).FlushResponseAsync(_resp);
		}
	}
}
