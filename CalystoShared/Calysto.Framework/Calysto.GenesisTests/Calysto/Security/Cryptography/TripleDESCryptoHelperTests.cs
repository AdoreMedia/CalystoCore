using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calysto.Security.Cryptography.Tests
{
	[TestClass()]
	public class TripleDESCryptoHelperTests
	{
		[TestMethod()]
		public void TripleDESCryptoHelperTest1()
		{
			string str1 = "this is my string and my content is this";
			TripleDESCryptoHelper a1 = new TripleDESCryptoHelper("pass12345");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("tC1go2w+2kiiMmA7hdPm2jtn8U+FPnJQWSZOHY0QuegOxNfArWXngsi8q0DNxtyI", res1);

			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			TripleDESCryptoHelper a2 = new TripleDESCryptoHelper("pass12345");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				TripleDESCryptoHelper a3 = new TripleDESCryptoHelper("oth5erpass555");
				string res4 = a3.DecryptToString(Convert.FromBase64String(res1));
				Assert.Fail("should throw exception");
			}
			catch
			{
				Assert.IsTrue(true);
			}
		}

		[TestMethod()]
		public void TripleDESCryptoHelperTest2()
		{
			string str1 = "this is my string and my content is this";
			TripleDESCryptoHelper a1 = new TripleDESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("AwAxUgG9qfbV0nX5nbWaPhZ4x3/TXpCuSNmOvpyG81bMaMHHqdbkh3YJhIT6lggi", res1);

			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			TripleDESCryptoHelper a2 = new TripleDESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				TripleDESCryptoHelper a3 = new TripleDESCryptoHelper("oth5erpass555");
				string res4 = a3.DecryptToString(Convert.FromBase64String(res1));
				Assert.Fail("should throw exception");
			}
			catch
			{
				Assert.IsTrue(true);
			}
		}
	}
}