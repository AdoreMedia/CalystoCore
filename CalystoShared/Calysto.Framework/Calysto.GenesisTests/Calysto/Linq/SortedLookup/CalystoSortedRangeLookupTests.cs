using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq.SortedLookup.Tests
{
	[TestClass()]
	public class CalystoSortedRangeLookupTests
	{
		public class Item1
		{
			public int MinValue;
			public int MaxValue;
		}

		private static IEnumerable<Item1> GetTestItems()
		{
			byte n1 = 0;

			return Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = o * 5 + ((n1++) % 100)
			});
		}

		[TestMethod()]
		public void WhereValueInRangeTest1()
		{
			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(GetTestItems(), o => o.MinValue, o => o.MaxValue);
		}

		[TestMethod()]
		public void WhereKeyRangeContainsTest1()
		{
			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(GetTestItems(), o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.IsTrue(res1.Count > 0);
				Assert.IsTrue(res1.Count < 100);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest12()
		{
			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(GetTestItems(), o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.IsTrue(res1.Count > 0);
				Assert.IsTrue(res1.Count < 100);
			}
		}

		private static IEnumerable<Item1> GetTestItems2()
		{
			yield return new Item1() { MinValue = 10, MaxValue = 100 };
			yield return new Item1() { MinValue = 10, MaxValue = 10 };
			yield return new Item1() { MinValue = 30, MaxValue = 100 };
			yield return new Item1() { MinValue = 31, MaxValue = 100 };
			yield return new Item1() { MinValue = 32, MaxValue = 100 };
			yield return new Item1() { MinValue = 33, MaxValue = 100 };
			yield return new Item1() { MinValue = 33, MaxValue = 99 };
			yield return new Item1() { MinValue = 33, MaxValue = 98 };
			yield return new Item1() { MinValue = 33, MaxValue = 97 };
		}

		[TestMethod()]
		public void WhereKeyRangeContainsTest2()
		{
			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(GetTestItems2(), o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.IsTrue(res1.Count > 0);
				Assert.IsTrue(res1.Count < 100);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest13()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = new Random().Next(1, 100) + o
			});

			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(list1, o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.IsTrue(res1.Count > 0);
				Assert.IsTrue(res1.Count < 100);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest2()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});

			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(list1, o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.AreEqual(20, res1.Count);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest3()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});

			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(list1, o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31, 51).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.AreEqual(16, res1.Count);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest4()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});

			CalystoSortedRangeLookup<int, Item1> helper1 = new CalystoSortedRangeLookup<int, Item1>(list1, o => o.MinValue, o => o.MaxValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31, 51).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.AreEqual(16, res1.Count);
			}

			// add new items
			Enumerable.Range(-10000, 20000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			}).ForEach(o => helper1.Add(o));

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyRangeContains(31, 51).Select(o => new { o.MinValue, o.MaxValue }).OrderBy(o => o.MinValue).ToList();
				Assert.AreEqual(32, res1.Count);
			}

		}

		[TestMethod]
		public void TestMethod1()
		{
			// samo speed test
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			}).ToList();

			for (int n1 = 0; n1 < 10; n1++)
			{
				var res1 = list1.Where(o => o.MinValue >= -24 && o.MaxValue <= 310).ToList();
				Assert.AreEqual(47, res1.Count);
			}
		}
	}
}