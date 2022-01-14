using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq.SortedLookup.Tests
{
	[TestClass()]
	public class CalystoSortedLookupTests
	{
		public class Item1
		{
			public int MinValue;
			public int MaxValue;
		}

		private static IEnumerable<Item1> GetTestItems()
		{
			return Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});
		}

		#region creation speed comparison

		[TestMethod()]
		public void CalystoSortedLookupTest1()
		{
			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(GetTestItems(), o => o.MinValue);
		}

		#endregion

		#region search speed comparison

		[TestMethod()]
		public void CalystoSortedLookupTest2()
		{
			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(GetTestItems(), o => o.MinValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				//var res1 = helper1.FindLowerKeyIndex(31);
				//var res2 = helper1.FindLowerKeyIndex(31);
				var res1 = helper1.WhereKeyInRange(-24, 31).Select(o => o.MinValue).ToList();
				Assert.AreEqual(11, res1.Count);
			}
		}

		[TestMethod()]
		public void WhereValueInRangeTest2()
		{
			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(GetTestItems(), o => o.MinValue);

			for (int n1 = 0; n1 < 1000; n1++)
			{
				var res1 = helper1.WhereKeyInRange(-24, 31).Select(o => o.MinValue).ToList();
				Assert.AreEqual(11, res1.Count);
			}
		}

		#endregion

		[TestMethod()]
		public void WhereKeyInRangeTest1()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});

			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(list1, o => o.MinValue);

			for (int n1 = 0; n1 < 100; n1++)
			{
				var res1 = helper1.WhereKeyInRange(-24, 31).Select(o => o.MinValue).ToList();
				Assert.AreEqual(11, res1.Count);
			}
		}

		[TestMethod()]
		public void WhereKeyInRangeTest2()
		{
			var list1 = Enumerable.Range(100, 1).Select(o => new Item1()
			{
				MinValue = o,
				MaxValue = o,
			});

			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(list1, o => o.MinValue);

			for (int n1 = 0; n1 < 100; n1++)
			{
				var res1 = helper1.WhereKeyInRange(101, 101).Select(o => o.MinValue).ToList();
				Assert.AreEqual(0, res1.Count);

				var res2 = helper1.WhereKeyInRange(90, 101).Select(o => o.MinValue).ToList();
				Assert.AreEqual(1, res2.Count);

				var res3 = helper1.WhereKeyInRange(10, 99).Select(o => o.MinValue).ToList();
				Assert.AreEqual(0, res3.Count);

				var res4 = helper1.WhereKeyInRange(100, 100).Select(o => o.MinValue).ToList();
				Assert.AreEqual(1, res4.Count);

			}
		}

		[TestMethod()]
		public void WhereKeyInRangeTest3()
		{
			var list1 = Enumerable.Range(-100000, 200000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			});

			CalystoSortedLookup<int, Item1> helper1 = new CalystoSortedLookup<int, Item1>(list1, o => o.MinValue);

			for (int n1 = 0; n1 < 100; n1++)
			{
				var res1 = helper1.WhereKeyInRange(-24, 31).Select(o => o.MinValue).ToList();
				Assert.AreEqual(11, res1.Count);
			}

			// add new items
			Enumerable.Range(-1000, 2000).Select(o => new Item1()
			{
				MinValue = o * 5,
				MaxValue = 100 + o * 5
			}).ForEach(o => helper1.Add(o));

			for (int n1 = 0; n1 < 10000; n1++)
			{
				var res1 = helper1.WhereKeyInRange(-24, 31).Select(o => o.MinValue).ToList();
				Assert.AreEqual(22, res1.Count);
			}
		}

		//[TestMethod()]
		//public void WhereKeyInRangeTest4()
		//{
		//	SortedList<long, string> list1 = new SortedList<long, string>();
		//	list1.Add(123, "123");
		//	list1.Add(1, "1");
		//	list1.Add(500, "500");

		//	SortedDictionary<long, string> dic1 = new SortedDictionary<long, string>();
		//	dic1.Add(123, "123");
		//	dic1.Add(1, "1");
		//	dic1.Add(500, "500");

		//	Dictionary<long, string> dic2 = new Dictionary<long, string>();
		//	dic2.Add(123, "123");
		//	dic2.Add(1, "1");
		//	dic2.Add(500, "500");

		//}

	}
}