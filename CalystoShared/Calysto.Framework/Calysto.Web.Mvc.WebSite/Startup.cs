using Calysto.AspNetCore.Authentication.Basic;
using Calysto.AspNetCore.Authentication.Cookie;
using Calysto.AspNetCore.Authorization.Policy;
using Calysto.AspNetCore.Http;
using Calysto.Timers;
using Calysto.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Calysto.AspNetCore.Middlewares;
using System.Threading;
using System.Globalization;
using Calysto.AspNetCore.Mvc.DataAnnotations.AttributeAdapterProviders;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using Calysto.Resources;
using Calysto.Common.Extensions;
using Calysto.Web.Hosting;
using Calysto.Web.EnvDTE;
using Calysto.AspNetCore.Mvc.Razor.Templating;
using Calysto.Web.TestSite.Web.CalystoUI.Ajax;
using Calysto.Blazor.Utility;
using Calysto.IO;
using Calysto.Web.UI;

namespace Calysto.Genesis.WebSite
{
	public class LocalizableInjectingDisplayNameProvider : IDisplayMetadataProvider
	{
		private IStringLocalizer _stringLocalizer;
		private Type _injectableType;

		public LocalizableInjectingDisplayNameProvider(IStringLocalizer stringLocalizer, Type injectableType)
		{
			_stringLocalizer = stringLocalizer;
			_injectableType = injectableType;
		}

		public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
		{
			// ignore non-properties and types that do not match some model base type
			if (context.Key.ContainerType == null ||
				!_injectableType.IsAssignableFrom(context.Key.ContainerType))
				return;

			// In the code below I assume that expected use of field name will be:
			// 1 - [Display] or Name not set when it is ok to fill with the default translation from the resource file
			// 2 - [Display(Name = x)]set to a specific key in the resources file to override my defaults

			var propertyName = context.Key.Name;
			var modelName = context.Key.ContainerType.Name;

			// sanity check 
			if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(modelName))
				return;

			var fallbackName = propertyName + "_FieldName";
			// If explicit name is missing, will try to fall back to generic widely known field name,
			// which should exist in resources (such as "Name_FieldName", "Id_FieldName", "Version_FieldName", "DateCreated_FieldName" ...)

			var name = fallbackName;

			// If Display attribute was given, use the last of it
			// to extract the name to use as resource key
			foreach (var attribute in context.PropertyAttributes)
			{
				var tAttr = attribute as DisplayAttribute;
				if (tAttr != null)
				{
					// Treat Display.Name as resource name, if it's set,
					// otherwise assume default. 
					name = tAttr.Name ?? fallbackName;
				}
			}

			// At first, attempt to retrieve model specific text
			var localized = _stringLocalizer[name];

			// Final attempt - default name from property alone
			if (localized.ResourceNotFound)
				localized = _stringLocalizer[fallbackName];

			// If not found yet, then give up, leave initially determined name as it is
			var text = localized.ResourceNotFound ? name : localized;

			context.DisplayMetadata.DisplayName = () => text;
		}

	}

	public class LocalizableValidationMetadataProvider : IValidationMetadataProvider
	{
		private IStringLocalizer _stringLocalizer;
		private Type _injectableType;

		public LocalizableValidationMetadataProvider(IStringLocalizer stringLocalizer, Type injectableType)
		{
			_stringLocalizer = stringLocalizer;
			_injectableType = injectableType;
		}

		public void CreateValidationMetadata(ValidationMetadataProviderContext context)
		{
			// ignore non-properties and types that do not match some model base type
			if (context.Key.ContainerType == null ||
				!_injectableType.IsAssignableFrom(context.Key.ContainerType))
				return;

			// In the code below I assume that expected use of ErrorMessage will be:
			// 1 - not set when it is ok to fill with the default translation from the resource file
			// 2 - set to a specific key in the resources file to override my defaults
			// 3 - never set to a final text value
			var propertyName = context.Key.Name;
			var modelName = context.Key.ContainerType.Name;

			// sanity check 
			if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(modelName))
				return;

			foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
			{
				var tAttr = attribute as ValidationAttribute;
				if (tAttr != null)
				{
					// at first, assume the text to be generic error
					var errorName = tAttr.GetType().Name;
					var fallbackName = errorName + "_ValidationError";
					// Will look for generic widely known resource keys like
					// MaxLengthAttribute_ValidationError
					// RangeAttribute_ValidationError
					// EmailAddressAttribute_ValidationError
					// RequiredAttribute_ValidationError
					// etc.

					// Treat errormessage as resource name, if it's set,
					// otherwise assume default.
					var name = tAttr.ErrorMessage ?? fallbackName;

					// At first, attempt to retrieve model specific text
					var localized = _stringLocalizer[name];

					// Some attributes come with texts already preset (breaking the rule 3), 
					// even if we didn't do that explicitly on the attribute.
					// For example [EmailAddress] has entire message already filled in by MVC.
					// Therefore we first check if we could find the value by the given key;
					// if not, then fall back to default name.

					// Final attempt - default name from property alone
					if (localized.ResourceNotFound) // missing key or prefilled text
						localized = _stringLocalizer[fallbackName];

					// If not found yet, then give up, leave initially determined name as it is
					var text = localized.ResourceNotFound ? name : localized;

					tAttr.ErrorMessage = text;
				}
			}
		}
	}

	public class Startup
	{
#if DEBUG
		public const bool IsDebugDefined = true;
#else
		public const bool IsDebugDefined = false;
#endif

		public static IHttpContextAccessor ContextAccessor;
		public static IWebHostEnvironment HostEnvironment;
		public static IActionDescriptorCollectionProvider ControllerActionDescriptorProvider;
		public static LinkGenerator LinkGenerator;
		public static StopWatch StopWatch = new StopWatch().UsingThis(config =>
		{
			config.OnMark += mark =>
			{
				Trace.WriteLine(mark.Statistics);
				Console.WriteLine(mark.Statistics);
			};
		});

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.Replace(new ServiceDescriptor())
			StopWatch.Mark("starting ConfigureServices()");

			services.AddTransient<IAjaxService, AjaxService>();

			services.Configure<RazorViewEngineOptions>(options =>
			{
				// configure where to search for view files: 
				// {2}: area name, {1}: controller name, {0}: action name
				//options.AreaViewLocationFormats.Clear();
				//options.AreaViewLocationFormats.Add("/MyAreas/{2}/Views/{1}/{0}.cshtml");
				//options.AreaViewLocationFormats.Add("/MyAreas/{2}/Views/Shared/{0}.cshtml");
				//options.AreaViewLocationFormats.Add("~/Web/{2}/{1}/{0}.cshtml");
				options.ViewLocationFormats.Add("~/Web/CalystoUI/{1}/{0}.cshtml");
				options.ViewLocationFormats.Add("~/Web/{1}/{0}.cshtml");
			});

			services.AddResponseCaching();
			services.AddRazorPages();
			services.AddControllersWithViews();
			services.AddHttpContextAccessor();
			services.AddScoped<ICalystoViewRenderService, CalystoViewRenderService>();

			services.AddAuthentication("MainScheme")
				.AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("RoutesScheme", options =>
				{
					options.Realm = "Access to routes page.";
					options.ValidateUser = (user, pass) =>
					{
						if (user == "routes" && pass == "routes")
							return new Claim[] {
								new Claim(ClaimTypes.Name, user),
								new Claim(ClaimTypes.Role, "routes1")
							};
						else
							return null;
					};
				})
				.AddScheme<CalystoCookieAuthenticationOptions, CalystoCookieAuthenticationHandler>("MainScheme", options =>
				{
					options.CookieName = "_mainscheme";
					options.EcryptionKey = "fsda843262#$#GSD";
				});
			
			services.AddSingleton<IAuthorizationHandler, PolicyAuthorizationHandler>();
			services.AddAuthorization(options =>
			{
				options.AddPolicy("GrownPerson1", policy => policy.Requirements.Add(new PolicyAuthorizationRequirement()
				{
					Policy = "GrownPerson1",
					FuncIsAuthorized = (AuthorizationHandlerContext context, PolicyAuthorizationRequirement requirement) =>
					{
						if (context.User?.Identity?.IsAuthenticated == true)
						{
							var birth = context.User.FindFirst(ClaimTypes.DateOfBirth);
							if (birth?.Value != null)
								return (DateTime.Now - DateTimeExtensions.ParseISOTDateTimeString(birth.Value)).TotalDays > 18 * 365;
						}
						return false;
					}
				}));

			});

			//// validate token globaly, don't need to set attribute on each method
			services.AddMvc(options =>
			{
				options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
				//options.Conventions.Add(new RoutePrefixConvention());
				//options.Conventions.Add(new NamespaceRoutingConvention());
				options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((value, name) => string.Format(CalystoAnnotationsResources.ValidationAttribute_ValidationError, value));

				options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((value) => string.Format(CalystoAnnotationsResources.ValidationAttribute_ValidationError, value));

				//options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor((a) => "custom SetMissingBindRequiredValueAccessor {0}");
				//options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "custom SetMissingKeyOrValueAccessor");
				//options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "custom SetMissingRequestBodyRequiredValueAccessor");
				//options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((a) => "custom SetNonPropertyAttemptedValueIsInvalidAccessor {0}");
				//options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "custom SetNonPropertyUnknownValueIsInvalidAccessor");
				//options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "custom SetNonPropertyValueMustBeANumberAccessor");
				//options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((a) => "custom SetUnknownValueIsInvalidAccessor {0}");
				//options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((a) => "custom SetValueIsInvalidAccessor {0}");
				//options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((a) => "custom SetValueMustBeANumberAccessor {0}");
			})
			.AddViewLocalization()
			.AddMvcLocalization()
			.AddDataAnnotationsLocalization(options =>
			{
				//options.DataAnnotationLocalizerProvider = (type, factory) =>
				//{
				//	//return factory.Create(typeof(Calysto.ComponentModel.DataAnnotations.CalystoDataAnnotations));
				//	return new MyLocalizer(typeof(Calysto.ComponentModel.DataAnnotations.CalystoDataAnnotations));
				//};
			});

			services.AddLocalization();

			services.AddSingleton<Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider, CalystoValidationAttributeAdapterProvider>();

			StopWatch.Mark("ending ConfigureServices()");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,
						IServiceScopeFactory scopeFactory,
						IWebHostEnvironment env,
						IHttpContextAccessor cx,
						IActionDescriptorCollectionProvider actionDescriptor,
						LinkGenerator linkGenerator
		)
		{
			StopWatch.Mark("starting Configure()");

			HostEnvironment = env;
			ContextAccessor = cx;
			ControllerActionDescriptorProvider = actionDescriptor;
			LinkGenerator = linkGenerator;

			if (IsDebugDefined)
			{
				Calysto.Utility.CalystoTools.IsDebugDefined = Startup.IsDebugDefined;
				CalystoFileInfo.CacheDuration = TimeSpan.FromSeconds(0);
				CalystoScriptManager.DefaultConfig.PreprocessorDefinedWords.Add("DEBUG");
			}
			else
			{
				CalystoScriptManager.DefaultConfig.Bundle = true;
				CalystoScriptManager.DefaultConfig.Compression = Microsoft.Ajax.Utilities.Css2.MinifyModeEnum.Minify;
			}

			CalystoPhysicalPaths paths = new CalystoPhysicalPaths(env.ContentRootPath).SetAsCurrent();

			// if app is started in debug from VS, WebLib is not published, so include original location before ~/WebLib/
			if (Startup.IsDebugDefined)
			{
				paths.RegisterSearchDirectory(EnvDTECalystoWeb.ProjectDir + "WebLib\\", true);
				paths.RegisterSearchDirectory(EnvDTECalystoWeb.ProjectDir, true);
			}

			paths.RegisterSearchAssembly(typeof(CalystoPhysicalPathHelper).Assembly);
			paths.RegisterSearchAssembly(Assembly.GetExecutingAssembly());
			// dodajem i blazor assemblie da varira server version prema njima: CalystoPhysicalPaths.Current?.AssembliesSignature
			paths.RegisterSearchAssembly(typeof(Calysto.Blazor.Utility.BrowserContext).Assembly);
			paths.RegisterSearchAssembly(typeof(CalystoBlazorWasm.Client.App).Assembly);

			paths.RegisterSearchDirectory("~/Web/");
			paths.RegisterSearchDirectory("~/WebLib/");
			paths.RegisterSearchDirectory("~/wwwroot/");

			CalystoMvcHostingEnvironment hosting = new CalystoMvcHostingEnvironment();
			CalystoHostingEnvironment.Current = hosting;
			hosting.SetPrivateValue(o => o.ServiceScopeFactory, scopeFactory);
			hosting.SetPrivateValue(o => o.ContextAccessor, cx);
			//hosting.SetPrivateValue(o => o.PathProvider, paths);
			//hosting.SetPrivateValue(o => o.ContentRootPath, env.ContentRootPath);
			//hosting.SetPrivateValue(o => o.WebRootPath, env.WebRootPath);
			hosting.SetPrivateValue(o => o.ActionDescriptorCollectionProvider, actionDescriptor);
			hosting.SetPrivateValue(o => o.LinkGenerator, linkGenerator);
			hosting.SetPrivateValue(o => o.SessionProvider, new CalystoSessionProvider("_ssidwts", TimeSpan.FromMinutes(20), "yw437rweuwrewywqe"));
			// assign events
			hosting.OnException += CalystoEnvironment_OnException;
			hosting.OnLog += CalystoEnvironment_OnLog;

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.Use(async (context, next) =>
			{
				// invoke once to ensure HostingAbsoluteUri is created
				var req1 = CalystoHostingEnvironment.Current.HostingAbsoluteUri;

				await next();
			});

			app.UseRequestLocalization(s=>s.SetDefaultCulture("hr-HR"));

			//app.UseMiddleware<CalystoStaticFilesMiddleware>();

			app.Use(async (context, next) =>
			{
				System.Globalization.CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hr-HR");
				System.Globalization.CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("hr-HR");
				Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");

				//int index1;
				//if ((index1 = context.Request.Path.Value.IndexOf("~/")) >= 0)
				//{
				//	// if images are relative in css, we have e.g. /path/~/img/file.jpg
				//	context.Request.Path = context.Request.Path.Value.Substring(index1 + 1); // remove ~ only
				//}

				await next();
			});

			app.UseBlazorFrameworkFiles();

			app.UseStaticFiles(new StaticFileOptions(new Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions()
			{
				
			})
			{
			});

			app.UseWebSockets();

			app.UseCalystoStaticFiles(setup =>
			{
				setup.DisallowCaching = info =>
				{
					// don't allow caching of files in some directory
					return info.FilePath.Contains("\\nesto\\");
				};

				setup.PrepareHeaders = context =>
				{
					// setup output headers
				};

			});

			//// Set up custom content types -associating file extension to MIME type
			//// po defaultu, nema handleara za less i sass fileove pa se vraca 404 not found.
			//var provider = new FileExtensionContentTypeProvider();
			//// Add new mappings
			//provider.Mappings[".scss"] = "application/x-msdownload";
			//provider.Mappings[".less"] = "application/x-msdownload";
			////provider.Mappings[".htm3"] = "text/html";
			////provider.Mappings[".image"] = "image/png";
			////// Replace an existing mapping
			////provider.Mappings[".rtf"] = "application/x-msdownload";
			////// Remove MP4 videos.
			////provider.Mappings.Remove(".mp4");

			//string webLibRoot = CalystoTools.IsLocalMachine ? EnvDTECalystoWebTypeScript.ProjectDir : Directory.GetCurrentDirectory();

			//app.UseStaticFiles(new StaticFileOptions()
			//{
			//	ContentTypeProvider = provider,
			//	FileProvider = new PhysicalFileProvider(Path.Combine(webLibRoot, "WebLib")) // Calysto.Web.WebLib
			//});

			//app.UseStaticFiles(new StaticFileOptions()
			//{
			//	ContentTypeProvider = provider,
			//	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Web")), // current project Web
			//});

			//app.UseDirectoryBrowser(new DirectoryBrowserOptions()
			//{
			//	FileProvider = new PhysicalFileProvider(
			//		Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
			//	RequestPath = new PathString("/MyImages")
			//});

			app.UseResponseCaching();
			
			/*
			app.Use(async (context, next) =>
			{
				// CacheControl will be set if any property in CacheControlHeaderValue() is set
				context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
				{
					//Public = true,
					MustRevalidate = false,
					//MaxAge = TimeSpan.FromSeconds(10)
				};
				//context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "*" };

				await next();
			});
			*/
			/*
			app.Use(async (context, next) =>
			{
				var template2 = TemplateParser.Parse("random/{min:int}/{max:int}");
				var template = TemplateParser.Parse("random/{min}/{max}");
				var matcher = new TemplateMatcher(template, null);
				var values = new RouteValueDictionary();
				if (matcher.TryMatch(context.Request.Path, values))
				{
					if (int.TryParse(values["min"] as string, out int min))
					{

					}
				}
				await next();
			});
			*/

			//app.Use(async (context, next) =>
			//{
			//	CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("sr-Latn-CS");
			//	await next();
			//});

			app.UseHttpsRedirection();

			//app.UseStaticFiles(new StaticFileOptions() {
			//	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Sites\\Adore")),
			//	RequestPath = "/adore"
			//});

			app.UseMiddleware<MyTestMiddleware>();
			//app.UseMiddleware<CalystoContextInitializatorMiddleware>();
			app.UseMiddleware<CalystoScriptMiddleware>();

			app.Use(async (context, next) =>
			{
				//context.Request.Path = "/prefix" + context.Request.Path.Value;
				//var dd = context.GetRouteData();
				//dd.Values.Add("nn", "kk");
				//var ep = context.GetEndpoint();
				//var serv = context.RequestServices.GetService<IHttpControllerSelector>();
				await next();
			});

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.Use(async (context, next) =>
			{
				var endpoint = context.GetEndpoint();

				if (endpoint == null)
					throw new InvalidOperationException("EndPoint can not be resolved.");

				Console.WriteLine($"Endpoint: {endpoint?.DisplayName}");

				if (endpoint is RouteEndpoint routeEndpoint)
				{
					Console.WriteLine("Endpoint has route pattern: " +
						routeEndpoint.RoutePattern.RawText);
				}

				foreach (var metadata in endpoint?.Metadata)
				{
					Console.WriteLine($"Endpoint has metadata: {metadata}");
				}

				await next();
			});

			//app.UseMiddleware<CalystoHtmlMinifierModuleMiddleware>();

			/*
			app.Use(next => context =>
			{
				var endpoint = context.GetEndpoint();
				if (endpoint is null)
				{
					return Task.CompletedTask;
				}

				Console.WriteLine($"Endpoint: {endpoint.DisplayName}");

				if (endpoint is RouteEndpoint routeEndpoint)
				{
					Console.WriteLine("Endpoint has route pattern: " +
						routeEndpoint.RoutePattern.RawText);
				}

				foreach (var metadata in endpoint.Metadata)
				{
					Console.WriteLine($"Endpoint has metadata: {metadata}");
				}

				return Task.CompletedTask;
			});
			*/

			app.UseEndpoints(endpoints =>
			{
				//	endpoints.MapGet("/page1", async context =>
				//	{
				//		await context.Response.WriteAsync("Hello world!");
				//	});

				//	// Using metadata to configure the audit policy.
				//	endpoints.MapGet("/sensitive", async context =>
				//	{
				//		await context.Response.WriteAsync("sensitive data");
				//	});

				//	endpoints.MapAreaControllerRoute(
				//	   name: "MyAreaProducts",
				//	   areaName: "CalystoUI",
				//		pattern: "{area:exists}/{controller=Flexbox}/{action=Index}");

				//endpoints.MapAreaControllerRoute(
				//	   name: "MyAreaProducts",
				//	   areaName: "Products",
				//	   pattern: "Products/{controller=Home}/{action=Index}/{id?}");

				//	endpoints.MapAreaControllerRoute(
				//		name: "MyAreaServices",
				//		areaName: "Services",
				//		pattern: "Services/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}"
					//defaults: new { area = "vs" }
					//constraints: new { area = "vs" }
				);

				endpoints.MapRazorPages();
				//endpoints.MapControllers();
				endpoints.MapFallbackToPage("/_Home");
				//endpoints.MapFallbackToFile("index.html");
			});

			StopWatch.Mark("ending Configure()");

			//var previousSelector = app.ApplicationServices.GetService(typeof(IHttpControllerSelector)) as IHttpControllerSelector;
			//app.ApplicationServices.Replace(typeof(IHttpControllerSelector), new CustomSelector(config) { PreviousSelector = previousSelector });

		}
		private void CalystoEnvironment_OnLog(object arg1, Func<string> arg2)
		{
			//throw new NotImplementedException();
		}

		private void CalystoEnvironment_OnException(object arg1, Func<Exception> arg2)
		{
			// throw arg2();
		}
	}



	public class MyTestMiddleware
	{
		private readonly RequestDelegate _next;

		public MyTestMiddleware(RequestDelegate next)
		{
			Startup.StopWatch.Mark("inside MyTestMiddleware() ctor");
			_next = next;
		}

		public async Task Invoke(HttpContext context,
						   IHttpContextAccessor httpContextAccessor,
						   LinkGenerator linkGenerator,
						   IActionDescriptorCollectionProvider controllerActionDescriptor)
		{
			if (Startup.ContextAccessor != httpContextAccessor)
				throw new Exception("ContextAccessor is not singleton.");

			if (Startup.LinkGenerator != linkGenerator)
				throw new Exception("LinkGenerator is not singleton.");

			if (Startup.ControllerActionDescriptorProvider != controllerActionDescriptor)
				throw new Exception("ControllerActionDescription is not singleton.");

			Startup.StopWatch.Mark("MyTestMiddleware() before next");
			await _next.Invoke(context);
			Startup.StopWatch.Mark("MyTestMiddleware() after next");
		}
	}
}

