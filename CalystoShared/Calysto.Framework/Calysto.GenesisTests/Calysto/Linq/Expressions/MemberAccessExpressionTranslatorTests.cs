using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Calysto.Linq.Expressions.Tests
{
	[TestClass()]
	public class MemberAccessExpressionTranslatorTests
	{
		[TestMethod()]
		public void TranslateTest()
		{
			string res1 = this.TranslatePath<Driver2>(o => o.Owner.Name);
			Assert.AreEqual("Owner.Name", res1);
		}

		private string TranslatePath<TModel>(Expression<Func<TModel, object>> selector)
		{
			var visitor = new MemberPropertyPathExtractor<TModel>();
			return visitor.GetPath(selector);
		}

		class Driver1
		{
			public string Name;
			public string Age { get; set; }
			public bool DoSomeWork() { return false; }
		}

		class Driver2
		{
			public string Name2;
			public string Age2 { get; set; }
			public Driver1 Owner { get; set; }
		}
	}
}