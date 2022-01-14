using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calysto.Security.Cryptography.Tests
{
	[TestClass()]
	public class DESCryptoHelperTests
	{
		[TestMethod()]
		public void DESCryptoHelperTest1()
		{
			string str1 = "this is my string and my content is this";
			DESCryptoHelper a1 = new DESCryptoHelper("pass12345");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("3Oph1sVjbx8QYA1Jgr1Z3g58RXHnpaeaBaAsZOloDspPYfDt1KsqtGomtEza3Ujq", res1);

			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			DESCryptoHelper a2 = new DESCryptoHelper("pass12345");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				DESCryptoHelper a3 = new DESCryptoHelper("oth5erpass555");
				string res4 = a3.DecryptToString(Convert.FromBase64String(res1));
				Assert.Fail("should throw exception");
			}
			catch
			{
				Assert.IsTrue(true);
			}
		}

		[TestMethod()]
		public void DESCryptoHelperTest2()
		{
			string str1 = "this is my string and my content is this";
			DESCryptoHelper a1 = new DESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res1 = Convert.ToBase64String(a1.Encrypt(str1));
			Assert.AreEqual("5UE6aaRUSThAJhFUvHTrs2sndkpp+wasmH2XNwoIHPJWVUzssKdNSbyKb+vi+089", res1);

			string res2 = a1.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res2);

			DESCryptoHelper a2 = new DESCryptoHelper("$#@!_)(#@%^@RWEYgsdfhsdUEWRyewr4231");
			string res3 = a2.DecryptToString(Convert.FromBase64String(res1));
			Assert.AreEqual(str1, res3);

			try
			{
				// should throw exception
				DESCryptoHelper a3 = new DESCryptoHelper("oth5erpass555");
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