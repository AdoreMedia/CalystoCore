using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calysto.Web.Script.Services;
using Calysto.TypeLite;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System;
using Calysto.Web.TestSite.Web.VS.Home.Models;
using Calysto.AspNetCore.Mvc.Razor;
using Calysto.AspNetCore.Mvc.Web;
using Calysto.Web.UI.Direct;
using Calysto.Web.Hosting;

namespace Calysto.Web.TestSite.Web.VS.Home
{
	//[Route("prefix")]
	//[Area("vs")]
	[TsClass]
	//[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		IAuthenticationSchemeProvider _schemeProvider;
		public HomeController(ILogger<HomeController> logger, IAuthenticationSchemeProvider schemeProvider)
		{
			_logger = logger;
			_schemeProvider = schemeProvider;
		}

		[HttpPost()]
		[ValidateAntiForgeryToken]
		public IActionResult Login(LoginViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				var claims = new[] { new Claim(ClaimTypes.Name, model.Username), new Claim(ClaimTypes.Role, "role1") };
				var identity = new ClaimsIdentity(claims, "MainScheme");
				var principal = new ClaimsPrincipal(identity);
				this.HttpContext.SignInAsync(principal);
				//return this.CalystoResult(new CalystoResponse().UseDirectUtility(f => 
				//	f.Alert("Login successful.\r\nPlease wait, page is reloading...")
				//	.ReloadWindowLocation(2000)
				//));
				var response = new CalystoResponse();
				response.UseDirectQuery("#" + nameof(LoginViewModel), f => f.SetInnerHtml("Loggin successful. Page is reloading...").ApplyStyle("font-size:20px;color:green;padding:5px 0;"));

				response.UseDirectQuery("button", f => f.SetEnabled(false));

				response.UseDirectUtility(f => f.ReloadWindowLocation(1000));

				return this.CalystoResult(response);

				return View("Index", new LoginViewModel());
			}
			else
			{
				return View("Index", model);
			}
		}

		[ValidateAntiForgeryToken]
		public IActionResult Logout()
		{
			if (this.HttpContext.User.Identity.IsAuthenticated)
			{
				this.HttpContext.SignOutAsync();
				var response = new CalystoResponse();
				response.UseDirectQuery("#" + nameof(LoginViewModel), f => f.SetInnerHtml("Logout successful. Reloading...").ApplyStyle("font-size:20px; color:orange; padding:5px 0;"));

				response.UseDirectQuery("button", f => f.SetEnabled(false));

				response.UseDirectUtility(f => f.ReloadWindowLocation(1000));
				
				return this.CalystoResult(response);
			}

			return View("Index", new LoginViewModel());
		}

		public IActionResult DelayTest()
		{
			if (this.HttpContext.Request.IsClaystoAjaxFormSubmit())
				Thread.Sleep(2000);

			return this.Ok("Delay successful");
		}

		public IActionResult InvokeError()
		{
			return this.Unauthorized("you are not authorized");
		}

		public IActionResult InvokeException()
		{
			throw new Exception("this is exception");
		}

		public IActionResult Test222()
		{
			return this.Ok("ovo je ok");
		}

		public IActionResult Redirect()
		{
			return this.RedirectToAction(nameof(Test222));
		}


		[HttpPost()]
		//[ValidateAntiForgeryToken]
		public IActionResult Login2(LoginViewModel model)
		{
			if (this.ModelState.IsValid)
			{
				return Ok("primljeno");
			}
			else
			{
				return View("Index", model);
			}
		}

		[CalystoWebMethod]
		public string CheckLoginModel(LoginViewModel model)
		{
			//var res1 = this.TryValidateModel(model);
			//System.Web.Mvc.Controller.TryValidateModel(u)

			List<ValidationResult> list = new List<ValidationResult>();
			ValidationContext vc = new ValidationContext(model);
			var res2 = Validator.TryValidateObject(model, vc, list);

			return "model received";
		}

		[Authorize]
		[NonAction]
		[CalystoWebMethod()]
		public string GetAgeString1(int age)
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
		public string GetHtmlString1(int age)
		{
			return CalystoMvcHostingEnvironment.Current.RenderToStringAsync("~/Web/Home/Privacy.cshtml", new List<string>() { "ja", "ti", "on" }, isMainPage: true).Result;
		}

		[NonAction]
		[CalystoWebMethod()]
		public string GetHtmlString2(int age)
		{
			return CalystoMvcHostingEnvironment.Current.RenderToStringAsync("~/Web/Home/Index.cshtml", new List<string>() { "ja", "ti", "on" }).Result;
		}

		[Authorize(Roles = "role22")]
		[NonAction]
		[CalystoWebMethod()]
		public string GetHtmlString3(int age)
		{
			//return CalystoContext.Current.RenderToStringAsync("~/Views/Partial/My1.cshtml", new List<string>() { "ja", "ti", "on" }).Result;
			return CalystoMvcHostingEnvironment.Current.RenderToStringAsync("~/Web/Home/Privacy.cshtml", new List<string>() { "ja", "ti", "on" }, isMainPage: true).Result;
		}


		[Authorize(Roles = "main1, role2")]
		//[Authorize(AuthenticationSchemes = "Scheme2", Policy = "GrownPerson1", Roles = "role1, role2" )]
		public IActionResult Index2()
		{
			return Content("ovo je index2");
		}

		[Authorize]
		public IActionResult Index3()
		{
			return Content("ovo je index3");
		}

		[HttpGet]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[AllowAnonymous]
		public IActionResult Index()
		{
			//return Ok("ovo je index");
			return View(new LoginViewModel());
		}

		[AllowAnonymous]
		public IActionResult DirectJson()
		{
			return this.CalystoResult(s=>s.UseDirectQuery("div", a=>a.ApplyStyle("border:solid 1px green")));
		}

		[AllowAnonymous]
		public IActionResult DirectHtml()
		{
			return Ok("this is ok");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
