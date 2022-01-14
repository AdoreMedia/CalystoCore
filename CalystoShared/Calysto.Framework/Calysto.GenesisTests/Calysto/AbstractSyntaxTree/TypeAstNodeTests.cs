using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.AbstractSyntaxTree;
using System.Linq;
using CalystoGenesisTests.Calysto.AbstractSyntaxTree.Model;

namespace CalystoGenesisTests.Calysto.AbstractSyntaxTree
{
	[TestClass()]
	public class TypeAstNodeTests
	{
		[TestMethod()]
		public void TypeAstNodeTest1()
		{
			// create types tree structure
			// we have to traverse JsonNode descendants and select full path for each node
			// than we use full path to get value type from TypeNode tree
			// than validate value againist value type and validation attributes from TypeNode
			TypeAstNode node = new TypeAstNode(typeof(ValidatorsViewModel));

			// find objects with properties
			var objects1 = node.Descendants(true).ToList();
			var dictypes = objects1.ToDictionary(o => o.TypePath);

			Assert.AreEqual("@.CalystoModel2", objects1[5].TypePath);

			Assert.AreEqual("@.CalystoModel2.Age", objects1[7].TypePath);
			
			Assert.AreEqual("@.List1.{index}.Name", objects1[11].TypePath);
			
			Assert.AreEqual("@.Dic1.{key}.Age", objects1[17].TypePath);
		}

	}
}