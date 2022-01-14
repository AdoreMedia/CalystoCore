using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace Calysto.Security.Cryptography.Tests
{
	[TestClass()]
	public class AESCryptoHelperTests
	{
		[TestMethod()]
		public void AESCryptoHelperTest1()
		{
			string str1 = "this is my string and my content is this";
			AESCryptoHelper a1 = new AESCryptoHelper("pass12345");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("gq3tUTEV53qjI86TJT+0fo4eAcaTu2Z/kwCJyjC5bUQsVT4liZzbl0xDZdf7cELk", res1);

			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			AESCryptoHelper a2 = new AESCryptoHelper("pass12345");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				AESCryptoHelper a3 = new AESCryptoHelper("oth5erpass555");
				string res4 = a3.DecryptToString(Convert.FromBase64String(res1));
				Assert.Fail("should throw exception");
			}
			catch
			{
				Assert.IsTrue(true);
			}
		}

		[TestMethod()]
		public void AESCryptoHelperTest2()
		{
			string str1 = "this is my string and my content is this";
			AESCryptoHelper a1 = new AESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("z6KakVcOWh2XKAadtv5nlAymna86vgNx93xtkifsSNMc0CyBtOt7SZXBcVcrjd0R", res1);
			 
			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			AESCryptoHelper a2 = new AESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				AESCryptoHelper a3 = new AESCryptoHelper("oth5erpass555");
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