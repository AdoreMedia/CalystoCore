using Calysto.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class CalystoToolsTests
	{
		[TestMethod()]
		public void IsLocalMachineTest()
		{
			bool res1 = CalystoTools.IsLocalMachine;
			Trace.Write(res1);
			Assert.AreEqual(true, res1, "Unittest has to be run on local machine, ALWAYS.");
		}

		[TestMethod()]
		public void IsUnitTestTest()
		{
			bool res1 = CalystoTools.IsUnitTest;
			Trace.Write(res1);
			Assert.AreEqual(true, res1, "Unittest process has to be detected as unittest, ALWAYS.");
		}

		[TestMethod()]
		public void LongToByteArrayTest()
		{
			long exp1 = 20042362354623561;
			byte[] data1 = Calysto.Utility.CalystoTools.LongToByteArray(exp1);
			long res1 = Calysto.Utility.CalystoTools.ByteArrayToLong(data1);
			Assert.AreEqual(exp1, res1);

			byte[] data2 = BitConverter.GetBytes(exp1);
			Assert.IsTrue(data1.SequenceEqual(data2));

			long res2 = BitConverter.ToInt64(data2, 0);
			Assert.AreEqual(exp1, res2);
		}

		[TestMethod()]
		public void LongToByteArrayTest1()
		{
			long exp1 = 12345;
			byte[] data1 = Calysto.Utility.CalystoTools.LongToByteArray(exp1);
			long res1 = Calysto.Utility.CalystoTools.ByteArrayToLong(data1);
			Assert.AreEqual(exp1, res1);

			byte[] data2 = BitConverter.GetBytes(exp1);
			Assert.IsTrue(data1.SequenceEqual(data2));

			long res2 = BitConverter.ToInt64(data2, 0);
			Assert.AreEqual(exp1, res2);
		}

		[TestMethod()]
		public void IPAddressToNumberTest1()
		{
			string ip1 = "192.168.1.100";

			long num1 = Calysto.Utility.CalystoTools.IPAddressToNumber(ip1);
			Assert.AreEqual(3232235876, num1);

			string ip2 = Calysto.Utility.CalystoTools.IPAddressFromNumber(num1);
			Assert.AreEqual(ip1, ip2);
		}

		[TestMethod()]
		public void IPAddressToNumberTest2()
		{
			string ip1 = "192.168.1.101";

			long num1 = Calysto.Utility.CalystoTools.IPAddressToNumber(ip1);
			Assert.AreEqual(3232235877, num1);

			string ip2 = Calysto.Utility.CalystoTools.IPAddressFromNumber(num1);
			Assert.AreEqual(ip1, ip2);
		}

		[TestMethod()]
		public void IsValidIPv4AddressTest()
		{
			bool res1 = Calysto.Utility.CalystoTools.IsValidIPv4Address("192.168.3.5");
			Assert.AreEqual(true, res1);

			bool res2 = Calysto.Utility.CalystoTools.IsValidIPv4Address("192.168.3");
			Assert.AreEqual(false, res2);

			bool res3 = Calysto.Utility.CalystoTools.IsValidIPv4Address("192..3.5");
			Assert.AreEqual(false, res3);
		}

		[TestMethod()]
		public void LongToByteArrayTest2()
		{
			// LongToByteArrayTest2
			long num1 = 486923762386;
			byte[] res1 = CalystoTools.LongToByteArray(num1);
			byte[] res2 = BitConverter.GetBytes(num1);
			Assert.IsTrue(res1.SequenceEqual(res1));

			// ByteArrayToLongTest
			long num2 = CalystoTools.ByteArrayToLong(res1);
			long num3 = BitConverter.ToInt64(res1, 0);
			Assert.AreEqual(num1, num2);
			Assert.AreEqual(num1, num3);

		}

		[TestMethod()]
		public void NormalizeDirectorySeparatorCharTest1()
		{
			string res1 = CalystoTools.NormalizeDirectorySeparatorChar("c:\\here\\//due//three\\\\hello//double////");
			Assert.AreEqual(@"c:\here\due\three\hello\double\", res1);
		}

		[TestMethod()]
		public void NormalizeDirectorySeparatorCharTest2()
		{
			string res1 = CalystoTools.NormalizeDirectorySeparatorChar("~/\\here\\//due//three\\\\hello//double////");
			Assert.AreEqual(@"~\here\due\three\hello\double\", res1);
		}

		[TestMethod()]
		public void NormalizeDirectorySeparatorCharTest3()
		{
			string res1 = CalystoTools.NormalizeDirectorySeparatorChar("c:\\here\\//due//three\\\\hello//double////", '/');
			Assert.AreEqual(@"c:/here/due/three/hello/double/", res1);
		}

		[TestMethod()]
		public void NormalizeDirectorySeparatorCharTest4()
		{
			string res1 = CalystoTools.NormalizeDirectorySeparatorChar("~/\\here\\//due//three\\\\hello//double////", '/');
			Assert.AreEqual(@"~/here/due/three/hello/double/", res1);
		}
	}
}
