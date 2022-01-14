using Calysto.Web.UI.Direct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalystoWebTests.Calysto.Web.UI.Direct
{
	[TestClass()]
	public class CalystoHtmlElementTests
	{
		[TestMethod()]
		public void CalystoHtmlElementTest1()
		{
			CalystoHtmlElement element = new CalystoHtmlElement("div")
			.AddClass("formItem")
			.AddChildren(
				new CalystoHtmlElement("div").ApplyStyle("color:green;").SetInnerHtml("Redirecting..."),
				new CalystoHtmlElement("img").SetAttribute("src", "/image.gif").AddClass("my-image"),
				new CalystoHtmlElement("script").SetInnerHtml(
					new CalystoDirectUtility()
					.SetWindowLocation("/some-url", 1000)
					.ToJavaScript()
				)
			);

			string html1 = element.ToHtml();
			string expected1 = "<div class=\"formItem\"><div style=\"color:green\">Redirecting...</div><img class=\"my-image\" src=\"/image.gif\" /><script>setTimeout(function(){window.location=\"/some-url\"}, 1000);</script></div>";

			Assert.AreEqual(expected1, html1);
		}

		[ExpectedException(typeof(InvalidOperationException))]
		[TestMethod()]
		public void CalystoHtmlElementTest2()
		{
			var element = new CalystoHtmlElement("img").SetAttribute("src", "/image.gif").AddClass("my-image").AddChildren(
					new CalystoHtmlElement("span")
				);

			string html1 = element.ToHtml();

			Assert.Fail("Exception should be thrown since 'img' element may not have children.");
		}
	}
}