using Calysto.AbstractSyntaxTree;
using Calysto.Common;
using Calysto.Data;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Calysto.Serialization.Json.Tests
{
	[TestClass()]
	public class FormSerializerTests
	{
		public class MyAddress
		{
			public string Kind { get; set; }
			public string Street { get; set; }
		}

		public class MyInfo
		{
			public string Name { get; set; }
			public PersonDetail Value { get; set; }
			public MyAddress Address { get; set; }
		}

		public enum ColorEnum
		{
			Red,
			Green,
			Blue
		}

		public class PersonDetail
		{
			public string Name { get; set; }
			public ColorEnum HeatColor { get; set; }
			public ColorEnum? ShoesColor { get; set; }
			public MyInfo MyInfo1 { get; set; }
			public MyInfo MyInfo2 { get; set; }
			public DataTable Table1 { get; set; }
			public DateTime? Birth { get; set; }
			public TimeSpan Duration { get; set; }
			public CalystoBlob MyBlob { get; set; }
			public List<MyAddress> MyAddresses { get; set; }
		}

		class FullPersonInfo
		{
			public PersonDetail Personal { get; set; }
		}

		private FullPersonInfo CreateFullPerson()
		{
			return new FullPersonInfo()
			{
				Personal = new PersonDetail()
				{
					Name = "Thomas",
					HeatColor = ColorEnum.Green,
					ShoesColor = ColorEnum.Red,
					MyInfo1 = new MyInfo()
					{
						Name = "Somersby",
						Value = new PersonDetail() { Name = "Nested name" },
						Address = new MyAddress() { Street = "my street 1" }
					},
					MyInfo2 = new MyInfo()
					{
						Name = "My info no 2",
						Address = new MyAddress()
						{
							Kind = "kind1",
							Street = "some street"
						}
					},
					Table1 = new DataTable("my-table1"),
					Birth = new DateTime(2019, 10, 22, 11, 05, 17),
					Duration = TimeSpan.FromSeconds(15)
				}
			};
		}

		string expected1 = "{\"Personal.Name\":\"Thomas\",\"Personal.HeatColor\":1,\"Personal.ShoesColor\":0,\"Personal.MyInfo1.Name\":\"Somersby\",\"Personal.MyInfo1.Value.Name\":\"Nested name\",\"Personal.MyInfo1.Value.HeatColor\":0,\"Personal.MyInfo1.Value.ShoesColor\":null,\"Personal.MyInfo1.Value.MyInfo1\":null,\"Personal.MyInfo1.Value.MyInfo2\":null,\"Personal.MyInfo1.Value.Table1\":null,\"Personal.MyInfo1.Value.Birth\":null,\"Personal.MyInfo1.Value.Duration\":\"00:00:00\",\"Personal.MyInfo1.Value.MyBlob\":null,\"Personal.MyInfo1.Value.MyAddresses\":null,\"Personal.MyInfo1.Address.Kind\":null,\"Personal.MyInfo1.Address.Street\":\"my street 1\",\"Personal.MyInfo2.Name\":\"My info no 2\",\"Personal.MyInfo2.Value\":null,\"Personal.MyInfo2.Address.Kind\":\"kind1\",\"Personal.MyInfo2.Address.Street\":\"some street\",\"Personal.Table1\":{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"my-table1\",\"Columns\":[],\"Rows\":[]},\"Personal.Birth\":{\"__calystotype\":\"Calysto_Date\",\"Date\":\"2019-10-22T11:05:17.000000\"},\"Personal.Duration\":\"00:00:15\",\"Personal.MyBlob\":{\"DataUrl\":\"data:text/plain;base64,dGhpcyBpcyB0ZXN0MQ==\",\"BlobIndex\":null,\"FileName\":\"filename1.txt\",\"MimeType\":\"text/plain\",\"Size\":13,\"__calystotype\":\"Calysto_Blob\"},\"Personal.MyAddresses.0.Kind\":\"kind1\",\"Personal.MyAddresses.0.Street\":\"stree1\",\"Personal.MyAddresses.1.Kind\":\"kind2\",\"Personal.MyAddresses.1.Street\":\"stree2\",\"Personal.MyAddresses.2.Kind\":\"kind3\",\"Personal.MyAddresses.2.Street\":\"stree3\"}";

		[TestMethod]
		public void SerializeTest3()
		{
			var person1 = CreateFullPerson();

			byte[] data = Encoding.UTF8.GetBytes("this is test1");
			CalystoBlob blob = new CalystoBlob();
			blob.FileName = "filename1.txt";
			blob.MimeType = "text/plain";
			blob.Size = data.Length;
			blob.Data = data;
			person1.Personal.MyBlob = blob;

			person1.Personal.MyAddresses = new List<MyAddress>()
			{
				new MyAddress(){Kind = "kind1", Street = "stree1"},
				new MyAddress(){Kind = "kind2", Street = "stree2"},
				new MyAddress(){Kind = "kind3", Street = "stree3"},
			};

			string form1 = JsonSerializer.FormSerialize(person1);
			Assert.AreEqual(expected1, form1);

			var person2 = JsonSerializer.FormDeserialize<FullPersonInfo>(form1);
			string form2 = JsonSerializer.FormSerialize(person1);
			Assert.AreEqual(form1, form2);

			string json1 = JsonSerializer.Serialize(person1);
			string json2 = JsonSerializer.Serialize(person2);
			Assert.AreEqual(json1, json2);
		}

	

	}
}