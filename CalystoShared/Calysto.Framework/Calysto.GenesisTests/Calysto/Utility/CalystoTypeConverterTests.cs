using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class CalystoTypeConverterTests
	{
		[TestMethod()]
		public void TryChangeTypeTest1()
		{
			int? a1 = -10;
			if(!CalystoTypeConverter.TryChangeType<int>(a1, out int res1))
				Assert.Fail();

			Assert.AreEqual(-10, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest111()
		{
			long? a1 = -10;
			if (!CalystoTypeConverter.TryChangeType<int>(a1, out int res1))
				Assert.Fail();

			Assert.AreEqual(-10, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest11()
		{
			int a1 = -10;
			if (!CalystoTypeConverter.TryChangeType<int?>(a1, out int? res1))
				Assert.Fail();

			Assert.AreEqual(-10, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest12()
		{
			if (!CalystoTypeConverter.TryChangeType<int?>("-10", out int? res1))
				Assert.Fail();

			Assert.AreEqual(-10, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest13()
		{
			if (!CalystoTypeConverter.TryChangeType<DateTime?>("2020-12-22T15:52:53.123456", out DateTime? res1))
				Assert.Fail();

			DateTime exp1 = new DateTime(2020, 12, 22, 15, 52, 53).Add(TimeSpan.FromMilliseconds(123.456));
			Assert.AreEqual(exp1, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest14()
		{
			if (!CalystoTypeConverter.TryChangeType<float?>("-10.235", out float? res1))
				Assert.Fail();

			Assert.AreEqual((float)-10.235, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest15()
		{
			if (!CalystoTypeConverter.TryChangeType<double?>("-10.235", out double? res1))
				Assert.Fail();

			Assert.AreEqual((double)-10.235, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest16()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal?>("-10.235", out decimal? res1))
				Assert.Fail();

			Assert.AreEqual((decimal)-10.235, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest17()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal?>("null", out decimal? res1))
				Assert.Fail();

			Assert.AreEqual(null, res1);
		}


		[TestMethod()]
		public void TryChangeTypeTest171()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal?>("", out decimal? res1))
				Assert.Fail();

			Assert.AreEqual(null, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest18()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal>("null", out decimal res1))
				Assert.AreEqual(0, res1); // must return false, can not convert "null" into decimal
			else
				Assert.Fail();
		}

		[TestMethod()]
		public void TryChangeTypeTest19()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal>("", out decimal res1))
				Assert.AreEqual(0, res1); // must return false, can not convert "" into decimal
			else
				Assert.Fail();
		}

		[TestMethod()]
		public void TryChangeTypeTest20()
		{
			if (!CalystoTypeConverter.TryChangeType<decimal>(null, out decimal res1))
				Assert.AreEqual(0, res1); // must return false, can not convert null into decimal
			else
				Assert.Fail();
		}

		[TestMethod()]
		public void TryChangeTypeTest2()
		{
			if (!CalystoTypeConverter.TryChangeType<bool>(1, out bool res1))
				Assert.Fail();

			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest3()
		{
			if (!CalystoTypeConverter.TryChangeType<bool>(0, out bool res1))
				Assert.Fail();

			Assert.AreEqual(false, res1);
		}

		[TestMethod()]
		public void TryChangeTypeTest4()
		{
			if (!CalystoTypeConverter.TryChangeType<bool>("1", out bool res1))
				Assert.Fail();

			Assert.AreEqual(true, res1);
		}

	}
}