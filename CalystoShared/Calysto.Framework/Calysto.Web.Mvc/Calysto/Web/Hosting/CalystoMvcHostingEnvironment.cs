using Calysto.AspNetCore.Http;
using Calysto.AspNetCore.Middlewares;
using Calysto.AspNetCore.Mvc.Razor.Templating;
using Calysto.Common.Extensions;
using Calysto.Linq;
using Calysto.Linq.Expressions;
using Calysto.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

/**************************************************************
 * We're extracting interface with get properties only 
 * and Current return interface, not the instance,
 * to prevent accidental property assignment.
 * **************************************************************/
namespace Calysto.Web.Hosting
{
	/// <summary>
	/// Variables has to be initialized in Startup.cx
	/// </summary>
	public class CalystoMvcHostingEnvironment : CalystoHostingEnvironment
	{
		public static new CalystoMvcHostingEnvironment Current => (CalystoMvcHostingEnvironment) CalystoHostingEnvironment.Current;

		public void SetPrivateValue<TValue>(Expression<Func<CalystoMvcHostingEnvironment, TValue>> pathSelector, TValue value)
		{
			var path1 = new MemberPropertyPathExtractor<CalystoMvcHostingEnvironment>();
			string pathStr = path1.GetPath(pathSelector);
			Calysto.Data.CalystoDataBinder.Private.SetValue(this, pathStr, value);
		}

		private ContextItemsAccessor _accessor;
		public override ContextItemsAccessor ContextItemsAccessor => _accessor ?? (_accessor = new ContextItemsAccessorMvc(() => this.HttpContext));

		public IActionDescriptorCollectionProvider ActionDescriptorCollectionProvider { get; private set; }

		public LinkGenerator LinkGenerator { get; private set; }

		public CalystoSessionProvider SessionProvider { get; private set; }

		public IHttpContextAccessor ContextAccessor { get; private set; }

		public IServiceScopeFactory ServiceScopeFactory { get; set; }

		public async Task<string> RenderToStringAsync(
			string viewName,
			object model = null,
			ViewDataDictionary viewDataDictionary = null,
			bool isMainPage = false,
			bool useCurrentContext = false)
		{
			using (IServiceScope scope = ServiceScopeFactory.CreateScope())
			{
				var serv1 = scope.ServiceProvider.GetRequiredService<ICalystoViewRenderService>();
				return await serv1.RenderToStringAsync(viewName, model, viewDataDictionary, isMainPage, useCurrentContext);
			}
		}

		public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
		{
			using (IServiceScope scope = ServiceScopeFactory.CreateScope())
			{
				var serv1 = scope.ServiceProvider.GetRequiredService<IAuthorizationService>();
				return await serv1.AuthorizeAsync(user, resource, policyName);
			}
		}

		public async Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string scheme)
		{
			using (IServiceScope scope = ServiceScopeFactory.CreateScope())
			{
				var serv1 = scope.ServiceProvider.GetRequiredService<IAuthenticationService>();
				return await serv1.AuthenticateAsync(context, scheme);
			}
		}

		public HttpContext HttpContext => this.ContextAccessor?.HttpContext; // at Unittest there is no context

		public ReadOnlyCollection<ControllerActionDescriptor> ControllerActionDescriptors => this.ActionDescriptorCollectionProvider.ActionDescriptors.Items
			.OfType<ControllerActionDescriptor>()
			.ToList().AsReadOnly();

		private BrowserCompression _browserCompression;

		public BrowserCompression BrowserCompression => _browserCompression
			?? (_browserCompression = BrowserCompression.Detect(this.HttpContext.Request.Headers["Accept-Encoding"] + ""));

		private CalystoUri _hostingAbsoluteUri;

		public override CalystoUri HostingAbsoluteUri => _hostingAbsoluteUri ?? (this.HttpContext == null ? null : (_hostingAbsoluteUri = new CalystoUriMvc(this.HttpContext)));
	}
}
