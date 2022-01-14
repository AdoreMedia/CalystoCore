using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Calysto.IO.Tests
{
	[TestClass()]
	public class StreamExtensionsTests
	{
		[TestMethod()]
		public void SplitToPartsTest()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and track orders.";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			var list1 = ms1.SplitToParts(33).Select(o=>Encoding.UTF8.GetString(o)).ToList();
			string str2 = string.Join("#", list1);
			string exp2 = "Order pizza, pasta, chicken & mor#e online for carryout or delivery# from your local Domino's restaur#ant. View our menu, find location#s and track orders.";
			Assert.AreEqual(exp2, str2);
		}

		[TestMethod()]
		public void SplitToPartsTest4()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and tr";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			var arr1 = ms1.SplitToParts(33).ToArray();
			List<MemoryStream> list1 = arr1.Select(o => new MemoryStream(o)).ToList();
			var list2 = list1.SplitToParts(35).ToList();
			var list3 = list2.Select(o => Encoding.UTF8.GetString(o));
			string str2 = string.Join("#", list3);
			string exp2 = "Order pizza, pasta, chicken & more #online for carryout or delivery fro#m your local Domino's restaurant. V#iew our menu, find locations and tr";
			Assert.AreEqual(exp2, str2);
		}

		[TestMethod()]
		public void SplitToPartsTest5()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and tr";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			var arr1 = ms1.SplitToParts(33).ToArray();
			List<MemoryStream> list1 = arr1.Select(o => new MemoryStream(o)).ToList();
			var list2 = list1.SplitToParts(31).ToList();
			var list3 = list2.Select(o => Encoding.UTF8.GetString(o));
			string str2 = string.Join("#", list3);
			string exp2 = "Order pizza, pasta, chicken & m#ore online for carryout or deli#very from your local Domino's r#estaurant. View our menu, find #locations and tr";
			Assert.AreEqual(exp2, str2);
		}

		[TestMethod()]
		public void ToMemoryStreamTest()
		{
			string str1 = "Order pizza, pasta, chicken & more online for carryout or delivery from your local Domino's restaurant. View our menu, find locations and track orders.";
			byte[] data1 = Encoding.UTF8.GetBytes(str1);
			MemoryStream ms1 = new MemoryStream(data1);
			MemoryStream ms2 = ms1.ToMemoryStream();
			string str2 = Encoding.UTF8.GetString(ms2.ToArray());
			Assert.AreEqual(str1, str2);
		}
	}
}