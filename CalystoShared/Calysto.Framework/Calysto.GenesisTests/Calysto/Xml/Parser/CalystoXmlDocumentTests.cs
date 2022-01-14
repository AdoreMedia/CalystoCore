using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Xml.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calysto.Xml.Parser.Tests
{
	[TestClass()]
	public class CalystoXmlDocumentTests
	{
		[TestMethod()]
		public void ParseJsonTest()
		{
			string json1 = File.ReadAllText("Calysto\\Xml\\Parser\\XmlTestFiles\\Mingorp1.json");

			CalystoXmlDocument doc = CalystoXmlDocument.ParseJson(json1);

			var list1 = doc.ChildNodes().Where(o => o.TagName == "aaData").ChildNodes().ToList();
			Assert.AreEqual(25, list1.Count);

			int totalCnt = doc.ChildNodes().Where(o => o.TagName == "iTotalRecords").Select(o => Convert.ToInt32(o.InnerText)).FirstOrDefault();
			Assert.AreEqual(86710, totalCnt);

			var list = doc.ChildNodes().Where(o => o.TagName == "aaData").ChildNodes().ToList().Select(o => new
			{
				StranicaIdAtMingorp = o.ChildNodes().Skip(0).Take(1).Select(k => Convert.ToInt32(k.InnerText)).FirstOrDefault(),
				MingorpRedniBroj = o.ChildNodes().Skip(1).Take(1).Select(k => Convert.ToInt32(k.InnerText.Replace(".", ""))).FirstOrDefault(),
				RedniBr = o.ChildNodes().Skip(2).Select(k=>k.InnerText).FirstOrDefault(),
				MBO = o.ChildNodes().Skip(3).Select(k => k.InnerText).FirstOrDefault(),
				Naziv = o.ChildNodes().Skip(4).Select(k => k.InnerText).FirstOrDefault(),
				Stanje = o.ChildNodes().Skip(5).Select(k => k.InnerText).FirstOrDefault(),
			}).Where(o =>
				o.MBO?.Length > 4
				&& o.StranicaIdAtMingorp > 0
				&& o.MingorpRedniBroj > 0
				&& o.Naziv?.Length > 0
				&& o.Stanje?.Length > 0)
			.ToList();

			Assert.AreEqual(25, list.Count);
		}
	}
}