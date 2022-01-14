using Calysto.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq.Tests
{
	[TestClass()]
	public class EnumerableExtensionsTests
	{
		[TestMethod()]
		public void OrderByKeyTest()
		{
			var list1 = Enumerable.Range(1, 50).ToList();
			var list2 = list1.OrderByKey("1523fadsghasdf516847231hdsa';lhwoeriqweotfvksfjdwasghasdfdsaui9565464").ToList();
			string str1 = list2.ToStringJoined();
			Assert.AreEqual("2811623321422192151720182961127507132548343951442469102431364744303340373581226454143323849", str1);

		}
	}
}
