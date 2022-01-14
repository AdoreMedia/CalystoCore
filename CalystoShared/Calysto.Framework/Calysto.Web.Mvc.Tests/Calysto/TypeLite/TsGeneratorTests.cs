using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.TypeLite;
using System;
using System.Collections.Generic;
using System.Text;
using Calysto.TypeLite.TsModels;
using CalystoWebTests.Calysto.TypeLite.Validators;
using System.Web;
using System.Threading.Tasks;

namespace Calysto.TypeLite.Tests
{
	public class MessageItem3
	{
		public string Name { get; set; }
	}

	[TestClass()]
	public class TsGeneratorTests
	{
		[TestMethod()]
		public void GetFullTypeNameTest001()
		{
			TsType type = TsType.Create(typeof(Dictionary<string, int>));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("{ [key: string]: number }", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest002()
		{
			TsType type = TsType.Create(typeof(Validators), TsTypeFamily.ResX);
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("CalystoWebTests.Calysto.TypeLite.Validators.Validators", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest003()
		{
			TsType type = TsType.Create(typeof(Task));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("void", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest004()
		{
			TsType type = TsType.Create(typeof(Task<bool>));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("boolean", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest005()
		{
			TsType type = TsType.Create(typeof(Task<IEnumerable<string>>));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("string[]", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest006()
		{
			TsType type = TsType.Create(typeof(IEnumerable<string>));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("string[]", name1);
		}

		[TestMethod()]
		public void GetFullTypeNameTest007()
		{
			TsType type = TsType.Create(typeof(IEnumerable<MessageItem3>));
			TsGenerator generator = new TsGenerator();
			string name1 = generator.GetFullTypeName(type);
			Assert.AreEqual("Calysto.TypeLite.Tests.MessageItem3[]", name1);
		}

	}
}