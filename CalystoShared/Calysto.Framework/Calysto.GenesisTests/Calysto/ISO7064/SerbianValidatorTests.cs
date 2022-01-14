using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Calysto.ISO7064.Tests
{
	[TestClass()]
	public class SerbianValidatorTests
	{
		[TestMethod()]
		public void IsPIBValidTest2()
		{
			bool res1 = SerbianValidator.IsPIBValid("112313116");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void IsPIBValidTest3()
		{
			bool res1 = SerbianValidator.IsPIBValid("112313157");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void IsPIBInvalidTest4()
		{
			bool res1 = SerbianValidator.IsPIBValid("112313158");
			Assert.AreEqual(false, res1);
		}

		[TestMethod()]
		public void GeneratePIBTest()
		{
			string res1 = SerbianValidator.GeneratePIB("11231320");
			Assert.AreEqual("112313204", res1);
		}

		[TestMethod()]
		public void SignPIBTest()
		{
			string res1 = SerbianValidator.GeneratePIB("11231344");
			Assert.AreEqual("112313446", res1);
		}


		[TestMethod()]
		public void IsCompanyMBValidTest1()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("21614645");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void IsCompanyMBInvalidTest2()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("21614654");
			Assert.AreEqual(false, res1);
		}

		[TestMethod()]
		public void IsCompanyMBValidTest3()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("21647900");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void GenerateCompanyMBTest3()
		{
			string res1 = SerbianValidator.GenerateCompanyMB("2161464");
			Assert.AreEqual("21614645", res1);
		}


		[TestMethod()]
		public void IsPreduzetnikMBValidTest1()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("66019420");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void IsPreduzetnikMBInvalidTest2()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("66019307");
			Assert.AreEqual(false, res1);
		}

		[TestMethod()]
		public void IsPreduzetnikMBValidTest3()
		{
			bool res1 = SerbianValidator.IsCompanyMBValid("66019454");
			Assert.AreEqual(true, res1);
		}

		[TestMethod()]
		public void GeneratePreduzetnikMBTest3()
		{
			string res1 = SerbianValidator.GenerateCompanyMB("6601945");
			Assert.AreEqual("66019454", res1);
		}

	}
}