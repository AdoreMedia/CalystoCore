using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Calysto.ISO7064.Tests
{
	[TestClass()]
	public class OibValidatorTests
	{
		[TestMethod()]
		public void IsOIBValidTest1()
		{
			string[] res = new string[] {
				CheckDigits.CalculateNumericCheckDigit("5555566666", false), //MOD 11,10
				CheckDigits.CalculateNumericCheckDigit("1111122222", false), //MOD 11,10
				CheckDigits.CalculateNumericCheckDigit("111122222", false), //MOD 11,10
				CheckDigits.CalculateNumericCheckDigit("0111122222", false), //MOD 11,10
				CheckDigits.CalculateNumericCheckDigit("12345", false), //MOD 11,10
				CheckDigits.CalculateNumericCheckDigit("12345", true), //MOD 97,10
				CheckDigits.CalculateAlphaCheckDigit("ABCDEFG", false), //MOD 27,26
				CheckDigits.CalculateAlphaCheckDigit("ABCDEFG", true), //MOD 661,26
				CheckDigits.CalculateAlphanumericCheckDigit("ABCD1234", false), //MOD 37,36
				CheckDigits.CalculateAlphanumericCheckDigit("ABCD1234", true) //MOD 1271,36
			};

			string res1 = string.Join(";", res);
			Assert.AreEqual("55555666667;11111222224;1111222229;01111222223;123450;1234520;ABCDEFGS;ABCDEFGAZ;ABCD1234N;ABCD1234KP", res1);
		}

		[TestMethod()]
		public void IsOIBValidTest2()
		{
			bool res1 = OibValidator.IsOIBValid("12345123451");
			Assert.AreEqual(false, res1);
		}

		[TestMethod()]
		public void IsOIBValidTest3()
		{
			bool res1 = OibValidator.IsOIBValid("55555666667");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void IsOIBValidTest4()
		{
			bool res1 = OibValidator.IsOIBValid("06396371159");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void GenerateOIBTest()
		{
			string res1 = OibValidator.GenerateOIB("12345123451");
			Assert.AreEqual("12345123454", res1);
		}

		[TestMethod()]
		public void SignOIBTest()
		{
			string res1 = OibValidator.GenerateOIB("12345123451");
			Assert.AreEqual("12345123454", res1);
		}
	}
}