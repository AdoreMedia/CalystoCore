using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.AbstractSyntaxTree;
using Calysto.Serialization.Json.Core.Serialization;
using System.Linq;
using Calysto.Serialization.Json;
using CalystoGenesisTests.Calysto.AbstractSyntaxTree.Model;

namespace CalystoGenesisTests.Calysto.AbstractSyntaxTree
{
	[TestClass()]
	public class ObjectAstNodeTests
	{
		[TestMethod()]
		public void ObjectAstNodeTest1()
		{
			ValidatorsViewModel model = new ValidatorsViewModel();
			model.CalystoModel.Age = 1;
			model.CalystoModel.Name = "ab";

			SerializerOptions opt = new SerializerOptions() { DateFormat = DateTimeFormat.ISOTDateTime };
			string json1 = JsonSerializer.Serialize(model, opt);
			object obj1 = JsonSerializer.DeserializeObject(json1);
			// parse dictionary
			ObjectAstNode node2 = new ObjectAstNode(obj1);
			var items1 = node2.Descendants(true).ToList();
			Assert.AreEqual(19, items1.Count);

			Assert.AreEqual("@.CalystoModel.Name", items1[2].FullPath);

			var items2 = node2.Descendants(true).Where(o => o.Children().Any()).ToList();
			Assert.AreEqual(7, items2.Count);

			Assert.AreEqual("@.List1", items2[3].FullPath);
		}

		[TestMethod()]
		public void ObjectAstNodeTest2()
		{
			ValidatorsViewModel model = new ValidatorsViewModel();
			model.CalystoModel.Age = 1;
			model.CalystoModel.Name = "ab";

			// parse model object
			ObjectAstNode node = new ObjectAstNode(model);

			var items = node.Descendants(true, 10).ToArray();
			Assert.AreEqual(19, items.Length);

			Assert.AreEqual("@.CalystoModel.Name", items[2].FullPath);

			var objects1 = node.Descendants(true).Where(o => o.Children().Any()).ToList();
			Assert.AreEqual(7, objects1.Count);

			Assert.AreEqual("@.CalystoModel", items[1].FullPath);

			var arr1 = items[0].SelectChain("CalystoModel.Age..Name").ToArray();
			Assert.AreEqual(4, arr1.Length);

			Assert.AreEqual("@.CalystoModel.Name", items[2].FullPath);

		}
	}
}
