using System.Linq;
using System.Reflection;
using Calysto.AspNetCore.Authorization.Utility;
using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using Calysto.Web.TestSite.Web.VS.Routes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace Calysto.Web.TestSite.Web.VS.Routes
{
	//[Authorize(AuthenticationSchemes = "MainScheme")]
	//[Route("diag")]
	//[Area("area")]
	public class RoutesController : Controller
	{
		private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
		private readonly LinkGenerator _linkGenerator;

		public RoutesController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, LinkGenerator linkGenerator)
		{
			_linkGenerator = linkGenerator;
			_actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
		}

		public IActionResult Index()
		{
			var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
				.OfType<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()
				.Select(p => new RouteInfo()
				{
					DisplayName = p.DisplayName,
					ControllerName = p.ControllerName,
					ActionName = p.ActionName,
					AttributeRouteTemplate = p.AttributeRouteInfo?.Template,
					AttributeRouteName = p.AttributeRouteInfo?.Name,
					Authorize = p.EndpointMetadata.OfType<AuthorizeAttribute>().ToList(), // sadrzi attibut od controllera i od akcije
					AllowAnonymous = p.EndpointMetadata.OfType<AllowAnonymousAttribute>().ToList(),
					NoAction = p.EndpointMetadata.OfType<NonActionAttribute>().Any(), // ako metoda ima NoAction, nece ni biti ovdje
					ActionVirtualPath = _linkGenerator.GetPathByAction(this.HttpContext, p.ActionName, p.ControllerName)
				}).Select(TestAuthorization).OrderBy(o => o.DisplayName).ToList();

			this.ViewData["Title"] = "All Routes";
			return View(routes);
		}

		public IActionResult WebMethods()
		{
			var routes = this.GetType().Module.GetTypes()
				.Where(o => o.GetCustomAttribute<TsClassAttribute>() != null)
				.SelectMany(type => type.GetMethods()
					.Where(o => o.GetCustomAttribute<CalystoWebMethodAttribute>() != null)
					.Select(GetRouteInfo)
				).Select(TestAuthorization).OrderBy(o => o.DisplayName).ToList();

			this.ViewData["Title"] = "Web Methods";
			return View("Index", routes);
		}

		private RouteInfo GetRouteInfo(MethodInfo method)
		{
			return new RouteInfo()
			{
				DisplayName = method.DeclaringType.FullName + "." + method.Name,
				ControllerName = method.DeclaringType.Name,
				ActionName = method.Name,
				Authorize = method.DeclaringType.GetCustomAttributes<AuthorizeAttribute>()
							.Concat(method.GetCustomAttributes<AuthorizeAttribute>()).ToList(),
				AllowAnonymous = method.DeclaringType.GetCustomAttributes<AllowAnonymousAttribute>()
							.Concat(method.GetCustomAttributes<AllowAnonymousAttribute>()).ToList(),
				NoAction = method.GetCustomAttributes<NonActionAttribute>().Any(),
				ActionVirtualPath = _linkGenerator.GetPathByAction(method.Name, method.DeclaringType.Name)
			};
		}

		private RouteInfo TestAuthorization(RouteInfo info)
		{
			info.Access = CalystoAuthorizationHelper.CheckAuthorization(null, info.Authorize, info.AllowAnonymous);
			return info;
		}

	}
}
