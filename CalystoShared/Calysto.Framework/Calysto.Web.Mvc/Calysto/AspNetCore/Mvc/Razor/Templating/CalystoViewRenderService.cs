using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Calysto.AspNetCore.Mvc.Razor.Templating
{
	public interface ICalystoViewRenderService
	{
		Task<string> RenderToStringAsync(
			string viewName,
			object model = null,
			ViewDataDictionary viewDataDictionary = null,
			bool isMainPage = false,
			bool useCurrentContext = false);
	}

	public class CalystoViewRenderService : ICalystoViewRenderService
	{
		IRazorViewEngine _razorViewEngine;
		ITempDataProvider _tempDataProvider;
		IServiceProvider _serviceProvider;
		IHttpContextAccessor _httpContextAccessor;
		LinkGenerator _linkGenerator;

		public CalystoViewRenderService(
			IRazorViewEngine razorViewEngine,
			IHttpContextAccessor httpContextAccessor,
			ITempDataProvider tempDataProvider,
			IServiceProvider serviceProvider,
			LinkGenerator linkGenerator
		)
		{
			_linkGenerator = linkGenerator;
			_razorViewEngine = razorViewEngine;
			_httpContextAccessor = httpContextAccessor;
			_tempDataProvider = tempDataProvider;
			_serviceProvider = serviceProvider;
		}

		class MyRouter : IRouter
		{
			private LinkGenerator _linkGenerator;

			public MyRouter(LinkGenerator linkGenerator)
			{
				this._linkGenerator = linkGenerator;
			}

			public VirtualPathData GetVirtualPath(VirtualPathContext context)
			{
				string area = (string)context.Values["area"];
				string controller = (string)context.Values["controller"];
				string action = (string)context.Values["action"];

				// create relative path without base path, base path is added by framework
				string path = _linkGenerator.GetPathByAction(action, controller);

				return new VirtualPathData(this, path, new RouteValueDictionary());
			}

			public Task RouteAsync(RouteContext context)
			{
				throw new NotImplementedException();
			}
		}

		public async Task<string> RenderToStringAsync(
			string viewName,
			object model = null,
			ViewDataDictionary viewDataDictionary = null,
			bool isMainPage = false,
			bool useCurrentContext = false)
		{
			HttpContext httpContext = (useCurrentContext ? _httpContextAccessor.HttpContext : null) ?? new DefaultHttpContext { RequestServices = _serviceProvider };

			if (!useCurrentContext)
			{
				// _httpContextAccessor.HttpContext is scoped, it will be disposed, so we have to copy paths for link generator
				// this way this method may be invoked from different thread, we don't have to worry if _httpContextAccessor.HttpContext is disposed
				HttpRequest request1 = _httpContextAccessor.HttpContext?.Request;
				if (request1 != null)
				{
					// we need paths for link generator
					httpContext.Request.PathBase = request1.PathBase;
					httpContext.Request.Path = request1.Path.Value;
					httpContext.Request.QueryString = request1.QueryString;
					httpContext.Request.Scheme = request1.Scheme;
				}
			}

			RouteData routeData = new RouteData();
			MyRouter router = new MyRouter(_linkGenerator);
			routeData.PushState(router, new RouteValueDictionary(), new RouteValueDictionary());

			var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

			using (var sw = new StringWriter())
			{
				var viewResult = this.FindView(actionContext, viewName, isMainPage);

				var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
				{
					Model = model
				};

				var viewContext = new ViewContext(
					actionContext,
					viewResult.View,
					viewDictionary,
					new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
					sw,
					new HtmlHelperOptions()
				);

				await viewResult.View.RenderAsync(viewContext);

				return sw.ToString();
			}
		}

		private ViewEngineResult FindView(ActionContext actionContext, string viewName, bool isMainPage)
		{
			var result = _razorViewEngine.GetView(null, viewName, isMainPage);
			if (result?.Success == true)
				return result;

			result = _razorViewEngine.FindView(actionContext, viewName, isMainPage);
			if (result?.Success == true)
				return result;

			throw new ArgumentNullException($"{viewName} does not match any available view");
		}
	}
}
