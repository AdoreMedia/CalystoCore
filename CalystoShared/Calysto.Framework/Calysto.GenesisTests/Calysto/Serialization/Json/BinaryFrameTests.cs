using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calysto.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calysto.Serialization.Json.Core.Serialization;

namespace Calysto.Serialization.Json.Tests
{
	[TestClass()]
	public class BinaryFrameTests
	{
		enum ColorEnum
		{
			Red,
			Green,
			Blue
		}

		class PersonDetail
		{
			public string Name { get; set; }
			public ColorEnum HeatColor { get; set; }
			public ColorEnum? ShoesColor { get; set; }
			public byte[] EncodedName { get; set; }
			public List<byte[]> PersonAttributes { get; set; }
		}

		[TestMethod()]
		public void SerializeTest1()
		{
			List<byte[]> attributes = new[]
			{
				"line one",
				"line two"
			}.Select(o => Encoding.UTF8.GetBytes(o)).ToList();

			PersonDetail person1 = new PersonDetail()
			{
				Name = "Thomas",
				HeatColor = ColorEnum.Red,
				ShoesColor = ColorEnum.Blue,
				EncodedName = Encoding.UTF8.GetBytes("how nice day it is"),
				PersonAttributes = attributes
			};

			BinaryFrame bf = BinaryFrame.Serialize(person1);

			byte[] bfdata = bf.ToBinaryData();

			// deserialize
			PersonDetail deserialized1 = BinaryFrame.Deserialize<PersonDetail>(bfdata);

			Assert.AreEqual(person1.Name, deserialized1.Name);
			Assert.AreEqual(person1.HeatColor, deserialized1.HeatColor);
			Assert.IsTrue(person1.EncodedName.SequenceEqual(deserialized1.EncodedName));
			Assert.AreEqual(person1.PersonAttributes.Count, deserialized1.PersonAttributes.Count);
			Assert.IsTrue(person1.PersonAttributes[0].SequenceEqual(deserialized1.PersonAttributes[0]));
			Assert.IsTrue(person1.PersonAttributes[1].SequenceEqual(deserialized1.PersonAttributes[1]));
		}

		[TestMethod()]
		public void SerializeTest2()
		{
			List<byte[]> attributes = new[]
			{
				"line one",
				"line two"
			}.Select(o => Encoding.UTF8.GetBytes(o)).ToList();

			PersonDetail person1 = new PersonDetail()
			{
				Name = "Thomas",
				HeatColor = ColorEnum.Red,
				ShoesColor = ColorEnum.Blue,
				EncodedName = Encoding.UTF8.GetBytes("how nice day it is"),
				PersonAttributes = attributes
			};

			SerializerOptions options = new SerializerOptions();
			options.UseTypeName = true;
			BinaryFrame bf = BinaryFrame.Serialize(person1, options);

			byte[] bfdata = bf.ToBinaryData();

			// deserialize
			PersonDetail deserialized1 = BinaryFrame.Deserialize<PersonDetail>(bfdata);

			Assert.AreEqual(person1.Name, deserialized1.Name);
			Assert.AreEqual(person1.HeatColor, deserialized1.HeatColor);
			Assert.IsTrue(person1.EncodedName.SequenceEqual(deserialized1.EncodedName));
			Assert.AreEqual(person1.PersonAttributes.Count, deserialized1.PersonAttributes.Count);
			Assert.IsTrue(person1.PersonAttributes[0].SequenceEqual(deserialized1.PersonAttributes[0]));
			Assert.IsTrue(person1.PersonAttributes[1].SequenceEqual(deserialized1.PersonAttributes[1]));
		}

		[TestMethod]
		public void SerializeTest3()
		{
			BinaryFrame bf = BinaryFrame.Serialize<object>(null);
			var data = bf.ToBinaryData();
			SerializerOptions options = new SerializerOptions();
			var res1 = BinaryFrame.Deserialize<object>(data, options);

			Assert.AreEqual(null, res1);
			Assert.AreEqual("null", options.BFOutput.Json);
			Assert.AreEqual(0, options.BFOutput.Blobs.Count);
		}
	}
}