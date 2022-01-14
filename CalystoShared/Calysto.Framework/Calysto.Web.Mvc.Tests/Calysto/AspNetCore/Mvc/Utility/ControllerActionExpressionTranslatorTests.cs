using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Calysto.AspNetCore.Mvc.Utility.CalystoMvcUtility1.Tests
{
	[TestClass()]
	public class ControllerActionExpressionTranslatorTests
	{
		[TestMethod()]
		public void TranslateTest1()
		{
			var res1 = new ControllerActionExpressionTranslator().Translate<Driver2, int>(o => o.Owner.DoSomeWork);
			Assert.AreEqual("Driver1", res1.DeclaringType.Name);
			Assert.AreEqual("DoSomeWork", res1.Name);
		}

		[ExpectedException(typeof(NullReferenceException))]
		[TestMethod()]
		public void TranslateTest2()
		{
			// it test if route exists and will throw exception since there is no routes from unittest
			var res2 = CalystoMvcUtility.UseTranslatorSafe(t => t.Translate<Driver2, int>(m => m.Owner.DoSomeWork));
			Assert.AreEqual("Owner", res2.controller);
			Assert.AreEqual("DoSomeWork", res2.action);
		}

		class Driver1
		{
			public string Name;
			public string Age { get; set; }
			public IActionResult DoSomeWork(int a) { return null; }
		}

		class Driver2
		{
			public string Name2;
			public string Age2 { get; set; }
			public Driver1 Owner { get; set; }
		}
	}


}