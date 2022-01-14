using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading;

/****************************************************************************************
	Powering up CalystoRazorViewEngine:
	- inside ConfigureServices() add next lines:

	public void ConfigureServices(IServiceCollection services)
	{
		...
		services.RemoveAll<IRazorViewEngine>();
		services.AddSingleton<IRazorViewEngine, CalystoRazorViewEngine>();
		...
	}

****************************************************************************************/

namespace Calysto.AspNetCore.Mvc.ViewEngines
{
	/// <summary>
	/// Search for view in all referenced assemblies and try to match using EndsWith(...) pattern.
	/// Match is considered successful, only if single result is found.
	/// </summary>
	public class CalystoRazorViewEngine : RazorViewEngine, IRazorViewEngine, IViewEngine
	{
		HashSet<string> _viewsCache;

		public CalystoRazorViewEngine(
			IRazorPageFactoryProvider pageFactory,
			IRazorPageActivator pageActivator,
			HtmlEncoder htmlEncoder,
			IOptions<RazorViewEngineOptions> optionsAccessor,
			ILoggerFactory loggerFactory,
			DiagnosticListener diagnosticListener)
			: base(pageFactory, pageActivator, htmlEncoder, optionsAccessor, loggerFactory, diagnosticListener)
		{
			_viewsCache = new CalystoMvcViewsHelper().FindAllViews(Assembly.GetEntryAssembly());

			// .net core 3.1
			//_razorViewEngine = new RazorViewEngine(pageFactory, pageActivator, htmlEncoder, optionsAccessor, loggerFactory, diagnosticListener);

			// .net standard 2.0 doesn't show the right constructor, so use reflection:
			//_razorViewEngine = CalystoActivator.CreateInstance<RazorViewEngine>(new object[]{ pageFactory, pageActivator, htmlEncoder, optionsAccessor, loggerFactory, diagnosticListener});
		}

		#region resolved views cache

		private string GetValueOrNew(Dictionary<string, string> dic, string key, Func<string> func)
		{
			if (!dic.TryGetValue(key, out string val1))
			{
				lock (dic)
				{
					if (!dic.TryGetValue(key, out val1))
					{
						val1 = func.Invoke();
						dic.Add(key, val1);
					}
				}
			}
			return val1;
		}

		#endregion

		public static string CombinePaths(params string[] paths)
		{
			List<string> previous = null;

			foreach(string path in paths)
			{
				List<string>current = path.TrimStart('~', '/').Split('/').Where(o => !string.IsNullOrEmpty(o)).ToList();
				if (previous == null || path.StartsWith("/") || path.StartsWith("~/"))
				{
					// start new path
					previous = current;
				}
				else
				{
					string previousLast = previous?.LastOrDefault();
					if (previousLast?.EndsWith(".cshtml") == true)
						previous.RemoveAt(previous.Count - 1);

					foreach (string curr in current)
					{
						if(curr == "~")
						{
							previous = new List<string>();
						}
						else if (curr == "..")
						{
							previous?.RemoveAt(previous.Count - 1);
						}
						else
						{
							previous.Add(curr);
						}
					}
				}
			}
			return "/" + string.Join("/", previous);
		}

		#region page or layout resolving

		public new string GetAbsolutePath(string executingFilePath, string pagePath)
		{
			if (string.IsNullOrEmpty(executingFilePath))
				return base.GetAbsolutePath(executingFilePath, pagePath);
			else
				return CombinePaths(executingFilePath, pagePath);
		}

		Dictionary<string, string> _getPageCache = new Dictionary<string, string>();
		
		public new RazorPageResult GetPage(string executingFilePath, string pagePath)
		{
			string key = executingFilePath
				+ " -> " + pagePath
				+ " -> " + Thread.CurrentThread.CurrentCulture.Name
				+ " -> " + Thread.CurrentThread.CurrentUICulture.Name;

			string path2 = GetValueOrNew(_getPageCache, key, () =>
			{
				string path1 = this.GetAbsolutePath(executingFilePath, pagePath);
				foreach (string candidate in GetLocalizedNames(path1))
				{
					if (_viewsCache.Contains(candidate))
					{
						// we have exact match
						return candidate;
					}
				}
				return null;
			});

			if(path2 != null)
				return base.GetPage(null, path2);
			else
				return base.GetPage(executingFilePath, pagePath);
		}

		Dictionary<string, string> _findPageCache = new Dictionary<string, string>();

		public new RazorPageResult FindPage(ActionContext context, string pageName)
		{
			// invoked when resolving Layout
			// pageName e.g. "_Shared/_Layout" will use localization
			// pageName "_Shared/_Layout.cshtml" will use exact file
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (pageName == null)
				throw new ArgumentNullException(nameof(pageName));

			string key = context.ActionDescriptor.DisplayName
				+ " -> " + pageName
				+ " -> " + Thread.CurrentThread.CurrentCulture.Name
				+ " -> " + Thread.CurrentThread.CurrentUICulture.Name;

			string name1 = GetValueOrNew(_findPageCache, key, () =>
			{
				return ResolveToExistingViewPath(context, pageName);
			});

			if (name1 != null)
			{
				return base.GetPage(null, name1);
			}
			else
			{
				return base.FindPage(context, name1);
			}
		}

		#endregion

		#region view resolving

		Dictionary<string, string> _getViewCache = new Dictionary<string, string>();

		public new ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
		{
			string key = executingFilePath
				+ " -> " + viewPath
				+ " -> " + Thread.CurrentThread.CurrentCulture.Name
				+ " -> " + Thread.CurrentThread.CurrentUICulture.Name;

			string path2 = GetValueOrNew(_getViewCache, key, () =>
			{
				string path1 = this.GetAbsolutePath(executingFilePath, viewPath);
				foreach (string candidate in GetLocalizedNames(path1))
				{
					if (_viewsCache.Contains(candidate))
					{
						// we have exact match
						return candidate;
					}
				}
				return null;
			});

			if (path2 != null)
				return base.GetView(null, path2, isMainPage);
			else
				return base.GetView(executingFilePath, viewPath, isMainPage);
		}

		Dictionary<string, string> _findViewCache = new Dictionary<string, string>();

		public new ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
		{
			// viewName is full path "/Views/Home/Index.cshtml" or action name "Index"

			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (viewName == null)
				throw new ArgumentNullException(nameof(viewName));

			string key = context.ActionDescriptor.DisplayName
				+ " -> " + viewName
				+ " -> " + Thread.CurrentThread.CurrentCulture.Name
				+ " -> " + Thread.CurrentThread.CurrentUICulture.Name;

			string name1 = GetValueOrNew(_findViewCache, key, () =>
			{
				return ResolveToExistingViewPath(context, viewName);
			});

			if (name1 != null)
			{
				return base.GetView(null, name1, isMainPage);
			}
			else
			{
				return base.FindView(context, name1, isMainPage);
			}
		}

		#endregion

		#region resolver engine

		private string ResolveToExistingViewPath(ActionContext context, string viewName)
		{
			// if we have viewName with slash, it has manually set path, so try to get it, or show error if not found
			// if viewName doesn't have slash, viewName is action (method) name inside controller
			// name shortening is not allowed if we have exact path with slash
			bool allowNameShortening = !viewName.Contains("/") && !viewName.EndsWith(".cshtml");

			var candidates = CreateCandidates(context, viewName, allowNameShortening);

			List<string> multiresults = new List<string>();

			foreach (string candidate in GetCandidateNames(candidates, allowNameShortening))
			{
				if (_viewsCache.Contains(candidate))
				{
					// we have exact match
					return candidate;
				}
				else
				{
					var res2 = _viewsCache.Where(o => o.EndsWith(candidate)).Take(5).ToList();
					if (res2.Count == 1)
					{
						return res2.First();
					}
					else if (res2.Count > 1)
					{
						// we have multiple results, can't use it, continue foreach loop
						multiresults.AddRange(res2);
					}
				}
			}

			if (!multiresults.Any())
				throw new FileNotFoundException($"View {viewName} for {context.ActionDescriptor?.DisplayName} can not be found.");
			else
				throw new Exception($"View {viewName} for {context.ActionDescriptor?.DisplayName} resolves to multiple views:\r\n{string.Join("\r\n", multiresults)}");
		}

		private IEnumerable<string> CreateCandidates(ActionContext context, string viewName, bool allowNameShortening)
		{
			string cleanedViewName = CleanViewName(viewName);
			if (!allowNameShortening)
			{
				// we have exact path, it may not be shorten
				yield return cleanedViewName;
			}
			else
			{
				// may return null if actionDescriptor is null
				string name1 = CreateViewPathFromActionDescriptor(context.ActionDescriptor as ControllerActionDescriptor, cleanedViewName);
				if (name1 != null)
					yield return name1;
				else
					yield return cleanedViewName;
			}
		}

		private string CleanViewName(string viewName)
		{
			return viewName?.TrimStart('~', '.');
		}

		private IEnumerable<string> GetCandidateNames(IEnumerable<string> candidates, bool allowNameShortening)
		{
			foreach (string name in candidates)
			{
				foreach (string name2 in GetLocalizedNames(name))
					yield return name2;
			}
			// if still not found, tear down names and will try to match using with EndsWith(...)
			// this is very unsafe, it may select wrong file
			if (allowNameShortening)
			{
				foreach (string name in candidates)
				{
					var parts = name.Split('/').ToList();
					while (parts.Count > 2) // to be safe, at least 2 parts must be left after removal
					{
						parts.RemoveAt(0);
						foreach (string name2 in GetLocalizedNames(string.Join("/", parts)))
							yield return name2;
					}
				}
			}
		}

		private IEnumerable<string> GetLocalizedNames(string name)
		{
			string str1 = name;

			if (!str1.StartsWith("/"))
				str1 = "/" + str1;

			if (!str1.EndsWith(".cshtml"))
			{
				yield return str1 + "." + CultureInfo.CurrentCulture.Name + ".cshtml";
				yield return str1 + "." + CultureInfo.CurrentCulture.TwoLetterISOLanguageName + ".cshtml";
				yield return str1 + ".cshtml";
			}
			else
			{
				yield return str1;
			}
		}

		private string CreateViewPathFromActionDescriptor(ControllerActionDescriptor actionDescriptor, string viewName)
		{
			// if called from calysto web service, actionDescriptor is null
			if (actionDescriptor == null)
				return null;

			string actionName = string.IsNullOrEmpty(viewName) ? actionDescriptor.MethodInfo.Name : viewName;

			string str1 = actionDescriptor.MethodInfo.DeclaringType.Namespace + "." + actionName;
			string str2 = str1.Replace(".", "/");
			return str2;
		}

		#endregion

	}
}
