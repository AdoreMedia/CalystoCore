using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Calysto.Linq;
using Calysto.Common.Extensions;

namespace Calysto.Common.Tests
{
	[TestClass()]
	public class ExceptionExtensionsTests
	{
		[TestMethod()]
		public void NextExceptionsTest()
		{
			// #1 is the most inner or base exception
			var ex1 = new Exception("#5", new Exception("#4", new Exception("#3", new Exception("#2", new Exception("#1")))));

			Assert.AreEqual("#1", ex1.GetBaseException().Message);
			Assert.AreEqual("#1", ex1.Unwind().First.Value.Message);
			Assert.AreEqual("#5", ex1.Unwind().Last.Value.Message);

			string res1 = ex1.Unwind().First.NextNodes(true).Skip(2).Select(o => o.Value.Message).ToStringJoined(";");
			Assert.AreEqual("#3;#4;#5", res1);

			string res2 = ex1.Unwind().First.NextNodes(false).Skip(2).Select(o => o.Value.Message).ToStringJoined(";");
			Assert.AreEqual("#4;#5", res2);
		}

		[TestMethod()]
		public void PreviousExceptionsTest()
		{
			// #1 is the most inner or base exception
			var ex1 = new Exception("#5", new Exception("#4", new Exception("#3", new Exception("#2", new Exception("#1")))));

			Assert.AreEqual("#1", ex1.GetBaseException().Message);
			Assert.AreEqual("#1", ex1.Unwind().First.Value.Message);
			Assert.AreEqual("#5", ex1.Unwind().Last.Value.Message);

			string res1 = ex1.Unwind().Last.PreviousNodes(true).Skip(2).Select(o => o.Value.Message).ToStringJoined(";");
			Assert.AreEqual("#3;#2;#1", res1);

			string res2 = ex1.Unwind().Last.PreviousNodes(false).Skip(2).Select(o => o.Value.Message).ToStringJoined(";");
			Assert.AreEqual("#2;#1", res2);
		}
	}
}