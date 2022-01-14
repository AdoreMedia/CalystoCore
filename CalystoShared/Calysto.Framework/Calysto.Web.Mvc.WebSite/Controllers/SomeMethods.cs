using Microsoft.AspNetCore.Mvc;
using Calysto.Web;
using Calysto.Web.Script.Services;
using Calysto.TypeLite;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Calysto.Web.Hosting;

namespace Calysto.Genesis.WebSite.Controllers
{
	[TsClass]
	public class SomeMethods
	{
		[Authorize]
		[NonAction]
		[CalystoWebMethod()]
		public string GetAgeString(int age)
		{
			return "godine: " + age;
		}

		[AllowAnonymous]
		[NonAction]
		[CalystoWebMethod()]
		public string GetAgeString2(int age)
		{
			return "godine: " + age;
		}

		[NonAction]
		[CalystoWebMethod()]
		public string GetHtmlString(int age)
		{
			//throw new UnauthorizedAccessException("nemate dopustenje");
			return CalystoMvcHostingEnvironment.Current.RenderToStringAsync("~/Views/Partial/My1.cshtml", new List<string>() { "ja", "ti", "on" }).Result;
		}
	
	}
}
