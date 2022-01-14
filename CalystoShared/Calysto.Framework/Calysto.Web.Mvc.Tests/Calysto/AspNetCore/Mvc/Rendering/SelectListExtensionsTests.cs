using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalystoWebTests.AspNetCore.Mvc.Rendering.Tests
{
	[TestClass()]
	public class SelectListExtensionsTests
	{
		[TestMethod()]
		public void ToInnerHtmlTest1()
		{
			string html = GetListItems().ToInnerHtml();

			string expected = "<option value=\"valopt1\">opt1</option><option selected=\"selected\" value=\"valopt2\">opt2</option><option disabled=\"disabled\" value=\"valopt3\">opt3</option><optgroup label=\"group1\"><option value=\"valopt4\">opt4</option><option value=\"valopt5\">opt5</option><option value=\"valopt6\">opt6</option></optgroup><optgroup disabled=\"disabled\" label=\"group1\"><option value=\"valopt7\">opt7</option><option value=\"valopt8\">opt8</option><option value=\"valopt9\">opt9</option></optgroup><option value=\"valopt10\">opt10</option><option selected=\"selected\" value=\"valopt11\">opt11</option><option disabled=\"disabled\" value=\"valopt12\">opt12</option>";

			Assert.AreEqual(expected, html);
		}

		public IEnumerable<SelectListItem> GetListItems()
		{
			yield return new SelectListItem("opt1", "valopt1");
			yield return new SelectListItem("opt2", "valopt2", true);
			yield return new SelectListItem("opt3", "valopt3", false, true);

			yield return new SelectListItem("opt4", "valopt4") { Group = new SelectListGroup() { Name = "group1" } };
			yield return new SelectListItem("opt5", "valopt5") { Group = new SelectListGroup() { Name = "group1" } };
			yield return new SelectListItem("opt6", "valopt6") { Group = new SelectListGroup() { Name = "group1" } };

			yield return new SelectListItem("opt7", "valopt7") { Group = new SelectListGroup() { Name = "group1", Disabled = true } };
			yield return new SelectListItem("opt8", "valopt8") { Group = new SelectListGroup() { Name = "group1", Disabled = true } };
			yield return new SelectListItem("opt9", "valopt9") { Group = new SelectListGroup() { Name = "group1", Disabled = true } };

			yield return new SelectListItem("opt10", "valopt10");
			yield return new SelectListItem("opt11", "valopt11", true);
			yield return new SelectListItem("opt12", "valopt12", false, true);
		}
	}
}