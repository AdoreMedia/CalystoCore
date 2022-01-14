using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Linq;

namespace System.Linq.Tests
{
	[TestClass()]
	public class CalystoRandomizerTests
	{
		private TimeSpan MeasureTime(Action action)
		{
			DateTime dt1 = DateTime.Now;
			action.Invoke();
			return DateTime.Now - dt1;
		}

		const int _cnt = 500000;

#if TDDSPECIFIC
		[TestMethod()]
		public void SelectRandomTest1()
		{
			// this test may fail sometimes, depending on random generated
			// just run test again and it will pass
			Console.WriteLine(MeasureTime(() =>
			{
				var list1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				var rr = list1.ToCalystoRandomizer(o => o == 8 ? 0.0001 : 1);
				var list = rr.SelectRandom(true).Take(_cnt).ToList();
				var g1 = list.GroupBy(o => o).Select(o => new { o.Key, Cnt = o.Count() }).ToList();
				var min1 = _cnt / list1.Length / 2;
				var max2 = 0.0001 * 2 * _cnt / list1.Length;
				Assert.IsTrue(g1.Where(o=>o.Key != 8).All(o => o.Cnt > min1));
				Assert.IsTrue(g1.Where(o => o.Key == 8).All(o => o.Cnt < max2));
				Assert.AreEqual(_cnt, list.Count);
			}));
		}
#endif

		[TestMethod()]
		public void SelectRandomTest2()
		{
			Console.WriteLine(MeasureTime(() =>
			{
				var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.CycleRandom(_cnt).ToList();
				Assert.AreEqual(_cnt, list.Count);
			}));
		}

	}
}
