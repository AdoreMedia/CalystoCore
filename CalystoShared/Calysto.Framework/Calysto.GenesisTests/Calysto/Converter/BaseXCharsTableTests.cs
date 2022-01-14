using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Converter.Tests
{
	[TestClass()]
	public class BaseXCharsTableTests
	{
		[TestMethod()]
		public void CreateRandomTableTest()
		{
			string str1 = Calysto.Converter.BaseXCharsTable.RandomRFCTable64;
			Assert.IsTrue(str1.Length > 50);
			Assert.IsTrue(str1.Length < 100);
		}
	}
}
