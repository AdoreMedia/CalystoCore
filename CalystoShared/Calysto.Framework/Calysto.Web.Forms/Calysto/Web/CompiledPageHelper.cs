using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace Calysto.Web
{
	/// <summary>
	/// For ASP.NET tested with .NET framework up to v 4.7.2
	/// </summary>
	public class CompiledPageHelper
	{
		static MethodInfo mSetIntrinsics;
		static MethodInfo mFrameworkInitialize;
		static MethodInfo mPerformPreInit;
		static MethodInfo mInitRecursive;
		////static FieldInfo mDesingMode;
		////static FieldInfo mDesingModeChecked;
		static FieldInfo mInOnFormRender;

		static CompiledPageHelper()
		{
			var methods1 = typeof(Page).GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			mSetIntrinsics = methods1.Where(o => o.Name == "SetIntrinsics" && o.GetParameters().Count() == 2).FirstOrDefault();
			mFrameworkInitialize = methods1.Where(o => o.Name == "FrameworkInitialize" && o.GetParameters().Count() == 0).FirstOrDefault();
			mPerformPreInit = methods1.Where(o => o.Name == "PerformPreInit" && o.GetParameters().Count() == 0).FirstOrDefault();
			mInitRecursive = methods1.Where(o => o.Name == "InitRecursive" && o.GetParameters().Count() == 1).FirstOrDefault();
			////mDesingMode = typeof(Page).GetField("_designMode", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			////mDesingModeChecked = typeof(Page).GetField("_designModeChecked", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			mInOnFormRender = typeof(Page).GetField("_inOnFormRender", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
		}

		HttpContext _context;

		public CompiledPageHelper(HttpContext context = null)
		{
			this._context = context;
		}

		private void InitializeFramework(Page page)
		{
			HttpContext context = this._context;
			if(context == null)
			{
				// ovo ipak nece raditi jer ne zna kako prevesti ~/ u physical file path
				HttpRequest req = new HttpRequest("dummy.file.aspx", "http://dummy.file.aspx", "");
				StringWriter sw = new StringWriter();
				HttpResponse resp = new HttpResponse(sw);
				context = new HttpContext(req, resp);
			}
			mSetIntrinsics.Invoke(page, new object[] { context, false });
			mFrameworkInitialize.Invoke(page, null);
			////mDesingMode.SetValue(page, true); // set design mode so it will allow rendering of TextBox without form element
			////mDesingModeChecked.SetValue(page, true); // set design mode so it will allow rendering of TextBox without form element
			mInOnFormRender.SetValue(page, true); // true: it will allow rendering of TextBox without form element
			mPerformPreInit.Invoke(page, null); // load default controls values from aspx file, any later step after this one is not required
			////mInitRecursive.Invoke(page, new object[] { null });
		}

		public T LoadPage<T>(string virtualPath) where T : Page
		{
			T page = (T)BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(T));
			InitializeFramework(page);
			return page;
		}

		public T LoadPage<T>(Type pageType) where T : Page
		{
			T page = (T)Activator.CreateInstance(pageType);
			InitializeFramework(page);
			return page;
		}

		public T LoadControl<T>(string virtualPath) where T : UserControl
		{
			Page p = new Page();
			InitializeFramework(p); // to have this.Request in page
			return (T)p.LoadControl(virtualPath); // load default controls values from ascx file
		}

		public T LoadControl<T>(Type controlType) where T : UserControl
		{
			Page p = new Page();
			InitializeFramework(p); // to have this.Request in page
			return (T)p.LoadControl(controlType, null);
		}
	}
}
