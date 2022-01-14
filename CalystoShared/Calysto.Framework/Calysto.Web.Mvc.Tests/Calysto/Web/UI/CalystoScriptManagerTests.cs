using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Common.Extensions;
using System.Diagnostics;
using Calysto.Web.UI;
using Calysto.Web;
using Calysto.Web.EnvDTE;
using Calysto.Web.Hosting;

namespace CalystoWebTests.Calysto.Web.UI
{
	[TestClass()]
	public class CalystoScriptManagerTests
	{
		// every method will try to generate js and css code, if any file is missing, will throw exception

		static CalystoScriptManagerTests()
		{
			var paths = new CalystoPhysicalPaths(EnvDTECalystoWeb.ProjectDir).SetAsCurrent();
			paths.RegisterSearchDirectory(EnvDTECalystoWeb.ProjectDir, true);
		}

		[TestMethod()]
		public void GetJavascriptTagTest1()
		{
			var cc = new CalystoScriptManager().UsingThis(m => m.RegisterEngineJS());
			string res1 = cc.GetJavascriptTag();
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 100);
		}

		[TestMethod()]
		public void GetJavascriptTagTest2()
		{
			var cc = new CalystoScriptManager().UsingThis(m => m.RegisterEngineJS());
			string res1 = cc.GetJavascriptTag();
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 100);
		}

		[TestMethod()]
		public void GetJavascriptTagTest3()
		{
			var cc = new CalystoScriptManager().UsingThis(m => m.RegisterEngineJS());
			string res1 = cc.GetJavascriptTag();
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 100);
		}

		[TestMethod()]
		public void GetCssTagTest()
		{
			var cc = new CalystoScriptManager().UsingThis(m =>m.RegisterEngineCSS());
			string res1 = cc.GetCssTag();
			//string exp1 = "\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"/[winapp1]/calystoscQ0rWY-calystores.axd?t=Q0rWYt0AK4n_7r9p_RGBlg\" />";
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 70);
		}

		[TestMethod()]
		public void GetJavascriptCodeTest()
		{
			var cc = new CalystoScriptManager().UsingThis(m => m.RegisterEngineJS());
			string res1 = cc.GetJavascriptCode();
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 1000, $"res1.Length is {res1.Length}, content {res1}");
		}

		[TestMethod()]
		public void GetCssCodeTest()
		{
			var cc = new CalystoScriptManager().UsingThis(m => m.RegisterEngineCSS());
			string res1 = cc.GetCssCode();
			Trace.WriteLine(res1);
			Assert.IsTrue(res1.Length > 1000, $"res1.Length is {res1.Length}");
		}


	}
}