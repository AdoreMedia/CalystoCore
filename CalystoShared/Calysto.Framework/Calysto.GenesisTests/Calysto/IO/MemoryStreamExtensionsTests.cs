using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Calysto.IO.Tests
{
	[TestClass()]
	public class MemoryStreamExtensionsTests
	{
		[TestMethod()]
		public void ReadArrayTest1()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and track orders.";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			ms1.Position = 9;
			BinaryReader reader = new BinaryReader(ms1);
			string str2 = Encoding.UTF8.GetString(reader.ReadBytes(22));
			Assert.AreEqual("za, pasta, chicken & m", str2);
		}

		[TestMethod()]
		public void ReadArrayTest2()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and track orders.";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			BinaryReader reader = new BinaryReader(ms1);
			reader.BaseStream.Position = 9;
			string str2 = Encoding.UTF8.GetString(reader.ReadBytes(22));
			Assert.AreEqual("za, pasta, chicken & m", str2);
		}


		[TestMethod()]
		public void ReadArrayTest3()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and track orders.";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			BinaryReader reader = new BinaryReader(new MemoryStream(data1));
			reader.BaseStream.Position = 9999;
			var arr2 = reader.ReadBytes(22);
			Assert.AreEqual(0, arr2.Length);
		}
	}
}