using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class CalystoSqlErrorMessageTests
	{
		string str1 = "Conversion failed when converting the nvarchar value '[[[ErrorCode]]]{{{This is error code}}}[[[SystemMessage]]]{{{Date can not be older than 2018-09-30 20:19:56}}}[[[CustomerMessage]]]{{{Datum dokumenta ne može biti stariji od 2018-09-30 20:19:56}}}' to data type int.";
		string resCustomer = "Datum dokumenta ne može biti stariji od 2018-09-30 20:19:56";
		string resSystem = "Date can not be older than 2018-09-30 20:19:56";
		string resErrorCode = "This is error code";

		[TestMethod()]
		public void TryExtractCustomerErrorTest()
		{
			if (CalystoSqlErrorMessage.TryExtractCustomerError(new Exception(str1), out string errmsg))
			{
				Assert.AreEqual(resCustomer, errmsg);
			}
			else
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void TryExtractSystemErrorTest()
		{
			var list = CalystoSqlErrorMessage.FromException(new Exception("some error", new Exception(str1)));
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual(1, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.SystemMessage).Count());
			Assert.AreEqual(1, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.ErrorCode).Count());
			Assert.AreEqual(1, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.CustomerMessage).Count());
			Assert.AreEqual(resSystem, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.SystemMessage).Select(o => o.Value).First());
			Assert.AreEqual(resCustomer, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.CustomerMessage).Select(o => o.Value).First());
			Assert.AreEqual(resErrorCode, list.Where(o => o.Kind == CalystoSqlErrorMessage.KindEnum.ErrorCode).Select(o => o.Value).First());
		}
	}
}