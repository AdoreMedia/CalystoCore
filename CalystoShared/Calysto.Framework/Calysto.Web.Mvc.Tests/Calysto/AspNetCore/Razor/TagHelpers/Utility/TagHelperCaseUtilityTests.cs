using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.AspNetCore.Razor.TagHelpers.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.AspNetCore.Razor.TagHelpers.Utility.Tests
{
	[TestClass()]
	public class TagHelperCaseUtilityTests
	{
		[TestMethod()]
		public void AttributeToPropertyNameTest()
		{
			string res1 = TagHelperCaseUtility.AttributeToPropertyName("z-index-duo");
			Assert.AreEqual("ZIndexDuo", res1);
		}

		[TestMethod()]
		public void PropertyToAttributeNameTest()
		{
			string res1 = TagHelperCaseUtility.PropertyToAttributeName("ZIndexDuo");
			Assert.AreEqual("z-index-duo", res1);
		}
	}
}