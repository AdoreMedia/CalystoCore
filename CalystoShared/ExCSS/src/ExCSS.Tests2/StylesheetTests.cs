using Calysto.Xml.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calysto.Linq;
using Calysto.UnitTesting;
using System.Reflection;
using System.Web;

namespace ExCSS.Tests2
{
	[TestClass]
	public class StylesheetTests
	{
		string _root = "TestFiles";

		[TestMethod]
		public void ParseStylesheetTest001()
		{
			// bootstrap.css parsing
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".css"));
			StylesheetParser parser = new StylesheetParser();
			Stylesheet ss = parser.Parse(provider.ReadInputText());

			var list1 = ss.Children.OfType<StyleRule>().ToList();

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void ParseStylesheetTest002()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".css"));
			StylesheetParser parser = new StylesheetParser();
			Stylesheet ss = parser.Parse(provider.ReadInputText());

			var list1 = ss.Children.OfType<StyleRule>().ToList();

			Assert.IsTrue(true);
		}

		private static string CreateCssText(string current, string append)
		{
			return current.Trim(';') + ";" + append.Replace('"', '\'');
		}

		private static string CreateInlinedCss(string html)
		{
			CalystoXmlDocument doc = CalystoXmlDocument.ParseHtml(html);

			string css1 = "";

			foreach (var item in doc.Query("//style"))
			{
				css1 += item.InnerText + "\r\n";
				item.InnerText = "";
			}

			StylesheetParser parser = new StylesheetParser();
			Stylesheet ss = parser.Parse(css1);
			var list1 = ss.Children.OfType<StyleRule>().ToList();

			foreach (var item in list1)
			{
				doc.DescendantNodes().Query(item.SelectorText).ForEach(el => el.Style = CreateCssText(el.Style, item.Style.CssText));
			}

			return doc.OutterXml;
		}

		[TestMethod]
		public void ParseStylesheetTest003()
		{
			TestFilesProvider2 provider = new TestFilesProvider2(Path.Combine(_root, MethodInfo.GetCurrentMethod().Name + ".html"));

			string html2 = CreateInlinedCss(provider.ReadInputText());

			provider.Assert(Assert.AreEqual, html2);

		}



	}
}
