using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Extensions.Tests
{
	[TestClass()]
	public class EnumExtensionsTests
	{
		enum MyEnum1
		{
			Red,
			[StringValue("Green color is this")]
			Green,
			[StringValue("Blue color is this")]
			Blue
		}

		enum MyEnum2
		{
			Hot,
			[StringValue("Soft is this")]
			Soft,
			[StringValue("Taste is this")]
			Taste
		}

		[TestMethod()]
		public void GetStringValueTest1()
		{
			for(int nn = 0; nn < 10; nn++)
			{
				string str1 = MyEnum1.Green.GetStringValue();
				Assert.AreEqual("Green color is this", str1);

				string str21 = MyEnum2.Soft.GetStringValue();
				Assert.AreEqual("Soft is this", str21);

				string str2 = MyEnum1.Blue.GetStringValue();
				Assert.AreEqual("Blue color is this", str2);

				string str22 = MyEnum2.Taste.GetStringValue();
				Assert.AreEqual("Taste is this", str22);

				string str3 = MyEnum1.Red.GetStringValue(true);
				Assert.AreEqual("Red", str3);

				string str23 = MyEnum2.Hot.GetStringValue(true);
				Assert.AreEqual("Hot", str23);
			}
		}

		[TestMethod()]
		public void GetStringValueTest4()
		{
			try
			{
				string str3 = MyEnum1.Red.GetStringValue(true);
				Assert.AreEqual("Red", str3);

				string str1 = MyEnum1.Red.GetStringValue();
			}
			catch(Exception ex)
			{
				if (ex.GetType() == typeof(ArgumentException))
					return;
			}

			Assert.Fail("Method should throw exception since there is no StringValue attribute on Red enum value.");
		}

		[TestMethod()]
		public void GetStringValueTest5()
		{
			try
			{
				string str23 = MyEnum2.Hot.GetStringValue(true);
				Assert.AreEqual("Hot", str23);

				string str1 = MyEnum2.Hot.GetStringValue();
			}
			catch (Exception ex)
			{
				if (ex.GetType() == typeof(ArgumentException))
					return;
			}

			Assert.Fail("Method should throw exception since there is no StringValue attribute on Hot enum value.");
		}
	}
}