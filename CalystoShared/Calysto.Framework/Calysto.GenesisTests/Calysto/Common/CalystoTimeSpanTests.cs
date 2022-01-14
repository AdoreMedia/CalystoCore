using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calysto.Common.Tests
{
	[TestClass()]
	public class CalystoTimeSpanTests
	{
		[TestMethod()]
		public void CalystoTimeSpanTest1()
		{
			var ts1 = new CalystoTimeSpan(new DateTime(1998, 1, 3), new DateTime(2018, 12, 8, 11, 35, 22));
			Assert.AreEqual("20y 11m 5d 11:35:22", ts1.FormatedTime);
			Assert.AreEqual(false, ts1.IsNegative);
		}

		[TestMethod()]
		public void CalystoTimeSpanTest2()
		{
			var ts2 = new CalystoTimeSpan(new DateTime(1998, 1, 10), new DateTime(2018, 12, 8, 11, 35, 22));
			Assert.AreEqual("20y 10m 28d 11:35:22", ts2.FormatedTime);
			Assert.AreEqual(false, ts2.IsNegative);
		}

		[TestMethod()]
		public void CalystoTimeSpanTest3()
		{
			var ts3 = new CalystoTimeSpan(new DateTime(1998, 1, 10), new DateTime(1998, 1, 10));
			Assert.AreEqual("0y 0m 0d 00:00:00", ts3.FormatedTime);
			Assert.AreEqual(false, ts3.IsNegative);
		}

		[TestMethod()]
		public void CalystoTimeSpanTest4()
		{
			var ts4 = new CalystoTimeSpan(new DateTime(2018, 12, 8, 11, 35, 22), new DateTime(1998, 1, 10));
			Assert.AreEqual("20y 10m 28d 11:35:22", ts4.FormatedTime);
			Assert.AreEqual(true, ts4.IsNegative);
		}
	}
}