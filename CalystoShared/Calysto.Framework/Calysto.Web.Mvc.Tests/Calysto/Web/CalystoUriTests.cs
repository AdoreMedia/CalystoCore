using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Calysto.Common.Extensions;
using Calysto.Linq;

namespace Calysto.Web.Tests
{
	[TestClass()]
	public class CalystoUriTests
	{
		private void TestDiagnosticString(CalystoUri uri, string expected)
		{
			string s1 = uri.GetType().GetProperties().Select(prop => prop.Name + ":" + prop.GetValue(uri)).ToStringJoined("$");
			Assert.AreEqual(expected, s1);
		}

		[TestMethod()]
		public void Test01()
		{
			TestDiagnosticString(new CalystoUri("https://85.114.41.97/"),
				"Scheme:https$Username:$Password:$Host:85.114.41.97$Port:$PathBase:$Path:/$Query:$Hash:");
		}

		[TestMethod()]
		public void Test02()
		{
			TestDiagnosticString(new CalystoUri("http://domena.com:43/nesto/dva/dru.aspx?qu=3&gr=3#dd=rel"),
				"Scheme:http$Username:$Password:$Host:domena.com$Port:43$PathBase:$Path:/nesto/dva/dru.aspx$Query:?qu=3&gr=3$Hash:#dd=rel");
		}

		[TestMethod()]
		public void Test03()
		{
			TestDiagnosticString(new CalystoUri("http://domaena.com:233/../dva.aspx?a=10&b=22#dva"),
				"Scheme:http$Username:$Password:$Host:domaena.com$Port:233$PathBase:$Path:/../dva.aspx$Query:?a=10&b=22$Hash:#dva");
		}

		[TestMethod()]
		public void Test04()
		{
			TestDiagnosticString(new CalystoUri("http://domain.com/?m=10"),
				"Scheme:http$Username:$Password:$Host:domain.com$Port:$PathBase:$Path:/$Query:?m=10$Hash:");
		}

		[TestMethod()]
		public void Test05()
		{
			TestDiagnosticString(new CalystoUri("http://username:password@www.nesto.com:1233/mypath/bill.aspx?a=10&b=20#c=3&c=4"),
				"Scheme:http$Username:username$Password:password$Host:www.nesto.com$Port:1233$PathBase:$Path:/mypath/bill.aspx$Query:?a=10&b=20$Hash:#c=3&c=4");
		}

		[TestMethod()]
		public void Test06()
		{
			TestDiagnosticString(new CalystoUri("/"),
				"Scheme:$Username:$Password:$Host:$Port:$PathBase:$Path:/$Query:$Hash:");
		}

		[TestMethod()]
		public void Test07()
		{
			TestDiagnosticString(new CalystoUri("/some/path.aspx"),
				"Scheme:$Username:$Password:$Host:$Port:$PathBase:$Path:/some/path.aspx$Query:$Hash:");
		}

		[TestMethod()]
		public void Test08()
		{
			TestDiagnosticString(new CalystoUri("?q=13&b=32"),
				"Scheme:$Username:$Password:$Host:$Port:$PathBase:$Path:$Query:?q=13&b=32$Hash:");
		}

		[TestMethod()]
		public void CalystoUriTest()
		{
			TestDiagnosticString(new CalystoUri("https://www.eprivrednik.eu/potvrda-email-adrese?s=17&e=smogovci2004@gmx.net&k=a1494324843524c"),
				"Scheme:https$Username:www.eprivrednik.eu/potvrda-email-adrese?s=17&e=smogovci2004$Password:$Host:gmx.net&k=a1494324843524c$Port:$PathBase:$Path:$Query:$Hash:");
		}

		[TestMethod()]
		public void CalystoUriTest01()
		{
			TestDiagnosticString(new CalystoUri("https://localhost:43232/MyDir/PageX.aspx?PackageID=29&AllInclusive=1&StepNo=3"),
				"Scheme:https$Username:$Password:$Host:localhost$Port:43232$PathBase:$Path:/MyDir/PageX.aspx$Query:?PackageID=29&AllInclusive=1&StepNo=3$Hash:");
		}
	}
}