using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading;
using Calysto.Utility;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Xml.Parser;

namespace Calysto.Xml.Parser
{
	[TestClass]
	public class XmlParserTests
	{
		[TestMethod]
		public void LinqTest1()
		{
			string html = File.ReadAllText("Calysto\\Xml\\Parser\\XmlTestFiles\\" + "parse-test-hourly.html");
			
			CalystoXmlDocument doc = CalystoXmlDocument.Parse(html);

			string city = doc
				.DescendantNodes(o => o.TagName == "ul" && o.Id == "country-breadcrumbs")
				.DescendantNodes(o => o.TagName == "li" && o.Class == "last")
				.Select(o => o.InnerText)
				.FirstOrDefault();

			var dataTable = doc.DescendantNodes(o => o.TagName == "table" && o.Class == "data").First();
			var temperatureNode = dataTable.DescendantNodes(o => o.TagName == "tr" && o.Class == "temp");
			var temperatureValues = temperatureNode.DescendantNodes(o => o.TagName == "td").Select(o => o.InnerText.Replace("&#176;", "").Trim()).ToList();
			var realFeelValues = temperatureNode.NextSiblings(o => o.Class == "realfeel").Take(1).DescendantNodes(o => o.TagName == "td").Select(o => o.InnerText.Replace("&#176;", "").Trim()).ToList();
			var windSpeedValues = dataTable.DescendantNodes(o => o.TagName == "th" && o.InnerText.StartsWith("Wind")).Take(1).ParentNodes().ChildNodes(o => o.TagName == "td").Select(o => o.InnerText).ToList();
			var hourValues = dataTable.DescendantNodes(o => o.TagName == "thead").Take(1).DescendantNodes(o => o.TagName == "th").Skip(1).ChildNodes(o => o.NodeType == CalystoXmlNodeType.Text).Select(o => o.InnerText).ToList();
			var forecastTds = dataTable.DescendantNodes(o => o.TagName == "tr" && o.Class == "forecast").ChildNodes(o => o.TagName == "td").ToList();
			var forecastValues = forecastTds.Select(o => o.InnerText.Trim()).ToList();
			var isNightValues = forecastTds.Select(o => o.Class.Contains("night")).ToList();
			var imageClass = dataTable.DescendantNodes(o => o.TagName == "tr" && o.Class == "forecast").DescendantNodes(o => o.TagName == "div" && o.Class.StartsWith("icon")).Select(o => o.Class.Replace("icon", "").Trim()).ToList();
			var preivousSibblings = doc.DescendantNodes(o => o.Class == "sub-list home-garden-list").Take(1).PreviousSiblings().ToList();
			var nextSibblings = doc.DescendantNodes(o => o.Class == "sub-list home-garden-list").Take(1).NextSiblings().ToList();

			var q1 = doc.Query("//table.data//tr.temp//td:skip(5):take(10)").ToList();
			var q2 = doc.Query("//th[class=first]:first").ToList();
			var q3 = doc.Query("//th[class=first]^tr[class=realfeel]").ToList();

			if (!(preivousSibblings.Count == 9 && nextSibblings.Count == 9 && temperatureValues.Count == 8 && realFeelValues.Count == 8 && windSpeedValues.Count == 8 && hourValues.Count == 8 && forecastTds.Count == 8 && forecastValues.Count == 8 && isNightValues.Count == 8 && imageClass.Count == 8 && q1.Count == 3 && q2.Count == 1 && q3.Count == 2))
			{
				throw new Exception("XmlLinq self-test failed in LinqTest1()");
			}
		}

		class TestFile
		{
			public int Number { get; set; }
			public string OriginalContent { get; set; }
			public string ExpectedContent { get; set; }
			public CalystoSourceKindEnum Kind { get; set; }
			public string FileOriginal { get; set; }
			public string FileExpected { get; set; }

			public TestFile(int number, string originalFile, string expectedFile, CalystoSourceKindEnum kind)
			{
				this.Number = number;
				this.OriginalContent = File.ReadAllText("Calysto\\Xml\\Parser\\XmlTestFiles\\" + originalFile);
				this.ExpectedContent = File.ReadAllText("Calysto\\Xml\\Parser\\XmlTestFiles\\" + expectedFile);
				this.Kind = kind;
				this.FileOriginal = originalFile;
				this.FileExpected = expectedFile;
			}
		}

		private void RunTest(TestFile tt)
		{
			Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; // serialization of decimal latitude and longitue id json test

			CalystoXmlDocument doc = CalystoXmlDocument.Parse(tt.OriginalContent, tt.Kind);

			Assert.AreEqual(tt.ExpectedContent, doc.OutterXml);
		}

		[TestMethod]
		public void XmlParseTest1() => RunTest(new TestFile(1, "AppSetting.xml", "AppSetting.xml", CalystoSourceKindEnum.Xml));

		[TestMethod]
		public void XmlParseTest2() => RunTest(new TestFile(2, "AppSetting_reader.xml", "AppSetting_reader.xml", CalystoSourceKindEnum.Xml));

		[TestMethod]
		public void XmlParseTest3() => RunTest(new TestFile(3, "rssexample.xml", "rssexample.xml", CalystoSourceKindEnum.Xml));

		[TestMethod]
		public void XmlParseTest4() => RunTest(new TestFile(4, "sampleRss091.xml", "sampleRss091.xml", CalystoSourceKindEnum.Xml));

		[TestMethod]
		public void XmlParseTest5() => RunTest(new TestFile(5, "WebForm2.aspx", "WebForm2.aspx.expected.aspx", CalystoSourceKindEnum.Html));

		[TestMethod]
		public void XmlParseTest6() => RunTest(new TestFile(6, "geolocation.xml", "geolocation.xml", CalystoSourceKindEnum.Xml));

		[TestMethod]
		public void XmlParseTest7() => RunTest(new TestFile(7, "file_json.json", "file_json.json.expected.xml", CalystoSourceKindEnum.Json));

		[TestMethod]
		public void XmlParseTest8() => RunTest(new TestFile(8, "html5test.html", "html5test_expected.html", CalystoSourceKindEnum.Html));

	}
}
