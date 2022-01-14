using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Security.Cryptography.Tests
{
	[TestClass()]
	public class CalystoCertificationTests
	{
		[TestMethod()]
		public void SignTest1()
		{
			CalystoCertification cert = new CalystoCertification("some secret word");

			string txt1 = "this is sample text";
			string signedTxt1 = cert.Sign(txt1);
			Assert.AreEqual("[[[WKeNVZlksnd69V9SANtlag==]]]this is sample text", signedTxt1);

			if(cert.TryDecode(signedTxt1, out string res1))
			{
				Assert.AreEqual(txt1, res1);
			}
			else
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void SignTest2()
		{
			CalystoCertification cert1 = new CalystoCertification("secret word 1");

			string txt1 = "this is sample text 333";
			string signedTxt1 = cert1.Sign(txt1);
			Assert.AreEqual("[[[AQOHmY4G0AL6On5Rf9TCGw==]]]this is sample text 333", signedTxt1);

			if (cert1.TryDecode(signedTxt1, out string res1))
			{
				Assert.AreEqual(txt1, res1);
			}
			else
			{
				Assert.Fail();
			}
		}

		[TestMethod()]
		public void SignTest3()
		{
			CalystoCertification cert1 = new CalystoCertification("secret word 1");

			// empty or null string
			if (cert1.TryDecode(null, out string res2))
			{
				Assert.Fail("empty or null string should return false");
			}
		}

		[TestMethod()]
		public void SignTest4()
		{
			CalystoCertification cert1 = new CalystoCertification("secret word 1");

			string txt1 = "this is sample text 333";
			string signedTxt1 = cert1.Sign(txt1);
			Assert.AreEqual("[[[AQOHmY4G0AL6On5Rf9TCGw==]]]this is sample text 333", signedTxt1);

			// text changed
			if (cert1.TryDecode(signedTxt1 + "2", out string res1))
			{
				Assert.Fail();
			}
		}
	}
}