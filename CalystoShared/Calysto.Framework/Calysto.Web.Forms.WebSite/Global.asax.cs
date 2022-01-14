using Calysto.IO;
using Calysto.Web.EnvDTE;
using Calysto.Web.Hosting;
using Calysto.Web.UI;
using System;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace Calysto.Web.Forms.WebSite
{
	public class Global : HttpApplication
	{
#if DEBUG
		public const bool IsDebugDefined = true;
#else
		public const bool IsDebugDefined = false;
#endif

		void Application_Start(object sender, EventArgs e)
		{
			if (IsDebugDefined)
			{
				Calysto.Utility.CalystoTools.IsDebugDefined = Global.IsDebugDefined;
				CalystoFileInfo.CacheDuration = TimeSpan.FromSeconds(0);
				CalystoScriptManager.DefaultConfig.PreprocessorDefinedWords.Add("DEBUG");
			}
			else
			{
				CalystoScriptManager.DefaultConfig.Bundle = true;
				CalystoScriptManager.DefaultConfig.Compression = Microsoft.Ajax.Utilities.Css2.MinifyModeEnum.Minify;
			}

			CalystoPhysicalPaths paths = new CalystoPhysicalPaths(HostingEnvironment.ApplicationPhysicalPath).SetAsCurrent();
			// if app is started in debug from VS, WebLib is not published, so include original location before ~/WebLib/
			if (IsDebugDefined)
			{
				paths.RegisterSearchDirectory(EnvDTECalystoWeb.ProjectDir + "WebLib\\", true);
				paths.RegisterSearchDirectory(EnvDTECalystoWeb.ProjectDir, true);
			}

			paths.RegisterSearchAssembly(typeof(EnvDTECalystoWeb).Assembly);
			paths.RegisterSearchAssembly(typeof(CalystoPhysicalPathHelper).Assembly);
			paths.RegisterSearchAssembly(Assembly.GetExecutingAssembly());

			paths.RegisterSearchDirectory("~/CalystoWebControlsTests/");
			paths.RegisterSearchDirectory("~/WebLib/");
			paths.RegisterSearchDirectory("~/Web/");

			CalystoFormsHostingEnvironment hosting = new CalystoFormsHostingEnvironment();
			CalystoHostingEnvironment.Current = hosting;
			//hosting.SetPrivateValue(o => o.PathProvider, paths);
			//hosting.SetPrivateValue(o => o.ContentRootPath, System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath);
			//hosting.SetPrivateValue(o => o.WebRootPath, System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath);
			// assign events
			hosting.OnException += CalystoEnvironment_OnException;
			hosting.OnLog += CalystoEnvironment_OnLog;
		}

		private void CalystoEnvironment_OnLog(object arg1, Func<string> arg2)
		{
			//throw new NotImplementedException();
		}

		private void CalystoEnvironment_OnException(object arg1, Func<Exception> arg2)
		{
			// throw arg2();
		}

		protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			//if (CalystoScriptManager.BuildKind == BuildKindEnum.Release)
			{
				//Calysto.Web.Filter.ResponseFilterHelper.Current.ApplyIfHtml(true, true, true);
			}
		}

		protected void Application_PostAcquireRequestState(object sender, EventArgs e)
		{

		}

		protected void Application_PreSendRequestContent(object sender, EventArgs e)
		{

		}

		protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
		{

		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			// invoke to ensure HostingAbsoluteUri is created;
			var req1 = CalystoFormsHostingEnvironment.Current.HostingAbsoluteUri;
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}