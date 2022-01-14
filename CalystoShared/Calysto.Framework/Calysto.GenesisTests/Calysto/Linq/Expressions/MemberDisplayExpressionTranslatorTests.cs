using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Calysto.Linq.Expressions.Tests
{
	[TestClass()]
	public class MemberDisplayExpressionTranslatorTests
	{
		[TestCleanup]
		public void Cleanup()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
		}

		[TestMethod()]
		public void TranslateTest1()
		{
			var translator = new MemberDisplayExtractor<Driver2>(o => o.Owner.Name1);
			string name1 = translator.GetName();
			Assert.AreEqual("Name1", name1);
		}

		[TestMethod()]
		public void TranslateTest2()
		{
			var translator = new MemberDisplayExtractor<Driver1>(o=>o.Name1);
			string name1 = translator.GetName();
			Assert.AreEqual("Name1", name1);
		}

		[TestMethod()]
		public void TranslateTest3()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
			var translator = new MemberDisplayExtractor<Driver2>(o=>o.Owner.Name5);
			string name1 = translator.GetName();
			Assert.AreEqual("Birth date", name1);
		}

		[TestMethod()]
		public void TranslateTest4()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");
			var translator = new MemberDisplayExtractor<Driver2>(o=>o.Owner.Name5);
			string name1 = translator.GetName();
			Assert.AreEqual("Datum rođenja", name1);
		}

		class Driver1
		{
			[Display(Name = nameof(Resources.CalystoLabelsResources.BirthDate_Label), ResourceType = typeof(Resources.CalystoLabelsResources))]
			public string Name5;

			public string Name1;
			public string Name3;
			public string Age { get; set; }
			public bool DoSomeWork() { return false; }
		}

		class Driver2
		{
			public string Name2;
			public string Name4;
			public string Age2 { get; set; }
			public Driver1 Owner { get; set; }
		}
	}
}