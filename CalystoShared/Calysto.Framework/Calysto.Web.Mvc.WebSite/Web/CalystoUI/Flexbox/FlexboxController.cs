using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calysto.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;

namespace Calysto.Web.TestSite.Web.CalystoUI.Flexbox
{
	public class FlexboxController : Controller
	{
		public IActionResult Index()
		{
			var dic = new Dictionary<string, object>() { { "age", 1234 }, {"name", "janko" } };

			return View();
		}

		public IActionResult GetContent2([FromQuery] int age, [FromQuery] string name)
		{
			if (!this.Request.IsClaystoAjax())
				throw new InvalidOperationException();

			Thread.Sleep(2000);
			return this.Ok($"received age: {age} and name: {name}");
		}
	}
}
