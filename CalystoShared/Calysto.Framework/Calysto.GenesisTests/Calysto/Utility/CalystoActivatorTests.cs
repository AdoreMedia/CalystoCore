using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Utility.Tests
{
	[TestClass()]
	public class CalystoActivatorTests
	{
		public class My1
		{
			public string Name { get; set; }
			public int Age { get; set; }
			public My1(string name, int age)
			{
				this.Name = name;
				this.Age = age;
			}

			public My1(string name)
			{
				this.Name = name;
			}
		}

		public class My2
		{
			public My2()
			{
			}
		}

		[TestMethod()]
		public void CreateInstanceTest1()
		{
			string str1 = typeof(My1).AssemblyQualifiedName;
			Type t1 = Type.GetType(str1);
			var m1 = CalystoActivator.CreateInstance(typeof(My1));
			Assert.IsInstanceOfType(m1, typeof(My1));
		}

		[TestMethod()]
		public void CreateInstanceTest1a()
		{
			string str1 = typeof(My2).AssemblyQualifiedName;
			Type t1 = Type.GetType(str1);
			var m1 = CalystoActivator.CreateInstance(t1);
			Assert.IsInstanceOfType(m1, typeof(My2));
		}

		[TestMethod()]
		public void CreateInstanceTest2()
		{
			var k1 = new
			{
				Name = "Bill",
				Age = 150
			};

			var k2 = CalystoActivator.CreateInstance(k1.GetType(), new object[] { "Franco", 23 });
			Assert.IsInstanceOfType(k2, k1.GetType());
		}

		[TestMethod()]
		public void CreateInstanceTest3()
		{
			Tuple<string, int> tuple1 = new Tuple<string, int>("Momo", 55);

			var tuple2 = (Tuple<string,int>) CalystoActivator.CreateInstance(tuple1.GetType(), new object[] { "Ivanho", 10 });
			Assert.IsInstanceOfType(tuple2, tuple1.GetType());
			Assert.AreEqual("Ivanho", tuple2.Item1);
			Assert.AreEqual(10, tuple2.Item2);
		}

		[TestMethod()]
		public void CreateInstanceTest4()
		{
			var list1 = new List<string>() { "first", "second" };

			var list2 = CalystoActivator.CreateInstance(list1.GetType(), new object[] { new string[] { "Ivanho", "Thomas" } });

			Assert.IsInstanceOfType(list2, list1.GetType());
		}
	}
}