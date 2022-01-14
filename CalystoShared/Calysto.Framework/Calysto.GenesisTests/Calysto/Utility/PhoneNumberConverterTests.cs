using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class PhoneNumberConverterTests
	{
		[TestMethod()]
		public void TryParsePhonesTest1()
		{
			bool success = PhoneNumberConverter.TryParsePhones("+38591111333", out string res1, "385", true);
			Assert.IsTrue(success);
			Assert.AreEqual("+38591111333", res1);
		}

		[TestMethod()]
		public void TryParsePhonesTest2()
		{
			bool success = PhoneNumberConverter.TryParsePhones("+38591111333, +38591111444,", out string res1, "385", true);
			Assert.IsTrue(success);
			Assert.AreEqual("+38591111333, +38591111444", res1);
		}

		[TestMethod()]
		public void TryParsePhonesTest3()
		{
			bool success = PhoneNumberConverter.TryParsePhones("+38591111333; +38591111444", out string res1, "385", true);
			Assert.IsTrue(success);
			Assert.AreEqual("+38591111333, +38591111444", res1);
		}

		[TestMethod()]
		public void TryParsePhonesTest4()
		{
			bool success = PhoneNumberConverter.TryParsePhones("091/111-333; 091 111 444", out string res1, "385", true);
			Assert.IsTrue(success);
			Assert.AreEqual("+38591111333, +38591111444", res1);
		}

		[TestMethod()]
		public void TryParsePhonesTest5()
		{
			bool success = PhoneNumberConverter.TryParsePhones("+385 (0) 91/111-333; 00 385 (0) 91 111-444", out string res1, "385", true);
			Assert.IsTrue(success);
			Assert.AreEqual("+38591111333, +38591111444", res1);
		}

		[TestMethod()]
		public void TryParsePhonesTest6()
		{
			string str1 = " 01 / 4664 175; DOSTAVA: 091 / 2002 944; + 385 (01) / 4668 888; 01 / 4666 111,+38644/568012, +385 0044/568000, (098) 354 680, 0996854879, 020/ 418633";
			string expected1 = "38514664175, 385912002944, 38514668888, 38514666111, 38644568012, 38544568000, 38598354680, 385996854879, 38520418633";

			bool success = PhoneNumberConverter.TryParsePhones(str1, out string parsed1, "385", false);
			Assert.IsTrue(success);
			Assert.AreEqual(expected1, parsed1);
		}
	}

}
