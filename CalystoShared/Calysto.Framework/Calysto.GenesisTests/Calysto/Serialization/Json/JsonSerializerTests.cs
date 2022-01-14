using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Calysto.Serialization.Json.Tests
{
	[TestClass()]
	public class JsonSerializerTests
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
		}

		[TestMethod()]
		public void SerializeTest1()
		{
			PersonDetail person1 = new PersonDetail() { Name = "Thomas", HeatColor = ColorEnum.Red, ShoesColor = ColorEnum.Blue };
			string json1 = JsonSerializer.Serialize(person1);

			PersonDetail person2 = JsonSerializer.Deserialize<PersonDetail>(json1);
			string json2 = JsonSerializer.Serialize(person2);

			Assert.AreEqual("{\"Name\":\"Thomas\",\"HeatColor\":0,\"ShoesColor\":2}", json1);
			Assert.AreEqual(json1, json2);

		}

		public class MyInfo
		{
			public string Name { get; set; }
			public object Value { get; set; }
		}

		public class MyAddress
		{
			public string Kind { get; set; }
			public string Street { get; set; }
		}

		[TestMethod()]
		public void SerializeTest2()
		{
			var person1 = new MyInfo()
			{
				Name = "Jonas",
				Value = new[]
				{
					new MyAddress(){Kind = "Living", Street = "Some street"},
					new MyAddress(){Kind = "Billing", Street = "Some street"}
				}
			};

			string json1 = JsonSerializer.Serialize(person1, new SerializerOptions() { UseTypeName = true });

			// buduci da imamo __type$ name, moze deserijalizirati svaki Value item u pravi MyAddress
			// ako Value items ostanu u Dictionary<string, object> tipu, nece se mozi castati u MyInfo pa ce baciti gresku
			var person2 = JsonSerializer.Deserialize<object>(json1, new SerializerOptions() { UseTypeName = true });

			Assert.IsTrue(typeof(MyInfo).IsAssignableFrom(person2.GetType()));

			var person3 = (MyInfo)person2;

			string json2 = JsonSerializer.Serialize(person2, new SerializerOptions() { UseTypeName = true });

			Assert.AreEqual(json1, json2);
		}

		[TestMethod]
		public void SerializeDateTime1()
		{
			SerializerOptions opt = new SerializerOptions() { DateFormat = DateTimeFormat.ExtendedObject };
			string dtstr1 = "2020-05-08T23:47:19.226175";
			DateTime dt1 = DateTimeExtensions.ParseISOTDateTimeString(dtstr1);
			string json1 = JsonSerializer.Serialize(dt1, opt);
			Assert.AreEqual("{\"__calystotype\":\"Calysto_Date\",\"Date\":\"2020-05-08T23:47:19.226175\"}", json1);

			DateTime dt2 = JsonSerializer.Deserialize<DateTime>(json1, opt);
			Assert.AreEqual(dtstr1, dt2.ToISOTDateTimeString());
		}

		[TestMethod]
		public void SerializeDateTime2()
		{
			SerializerOptions opt = new SerializerOptions() { DateFormat = DateTimeFormat.ISOTDateTime };
			string dtstr1 = "2020-05-08T23:47:19.226175";
			DateTime dt1 = DateTimeExtensions.ParseISOTDateTimeString(dtstr1);
			string json1 = JsonSerializer.Serialize(dt1, opt);
			Assert.AreEqual("\"2020-05-08T23:47:19.226175\"", json1);

			DateTime dt2 = JsonSerializer.Deserialize<DateTime>(json1, opt);
			Assert.AreEqual(dtstr1, dt2.ToISOTDateTimeString());

		}

		[TestMethod]
		public void SerializeDateTime3()
		{
			SerializerOptions opt = new SerializerOptions()
			{
				DateFormat = DateTimeFormat.ExtendedObject,
				Format = Core.Serialization.SerializationFormat.JavaScript
			};

			string dtstr1 = "2020-05-08T23:47:19.226175";
			DateTime dt1 = DateTimeExtensions.ParseISOTDateTimeString(dtstr1);
			string json1 = JsonSerializer.Serialize(dt1, opt);
			Assert.AreEqual("fnJsonPostConvertObj2({\"__calystotype\":\"Calysto_Date\",\"Date\":\"2020-05-08T23:47:19.226175\"})", json1);

		}

		[TestMethod]
		public void SerializeDateTime4()
		{
			SerializerOptions opt = new SerializerOptions()
			{
				DateFormat = DateTimeFormat.ISOTDateTime,
				Format = Core.Serialization.SerializationFormat.JavaScript
			};

			string dtstr1 = "2020-05-08T23:47:19.226175";
			DateTime dt1 = DateTimeExtensions.ParseISOTDateTimeString(dtstr1);
			string json1 = JsonSerializer.Serialize(dt1, opt);
			Assert.AreEqual("new Date(\"2020-05-08T23:47:19.226175\")", json1);
		}

		[TestMethod]
		public void SerializeDataTable1()
		{
			DataTable dt1 = new DataTable("MyTable1");
			dt1.Columns.Add("Column1", typeof(string));
			dt1.Columns.Add("Column2", typeof(int));
			dt1.Rows.Add("Jan", 10);
			dt1.Rows.Add("Mark", 15);

			string json1 = JsonSerializer.Serialize(dt1);

			string res1 = "{\"__calystotype\":\"Calysto_DataTable\",\"TotalCount\":null,\"TableName\":\"MyTable1\",\"Columns\":[\"Column1\",\"Column2\"],\"Rows\":[[\"Jan\",10],[\"Mark\",15]]}";

			Assert.AreEqual(res1, json1);

			DataTable dt2 = JsonSerializer.Deserialize<DataTable>(json1);

			string json2 = JsonSerializer.Serialize(dt2);
			Assert.AreEqual(res1, json2);
		}

		[TestMethod]
		public void CalystoBlobTest1()
		{
			byte[] data = Encoding.UTF8.GetBytes("this is test1");
			CalystoBlob blob = new CalystoBlob();
			blob.FileName = "filename1.txt";
			blob.MimeType = "text/plain";
			blob.Size = data.Length;
			blob.Data = data;

			string json1 = JsonSerializer.Serialize(blob);

			string res1 = "{\"DataUrl\":\"data:text/plain;base64,dGhpcyBpcyB0ZXN0MQ==\",\"BlobIndex\":null,\"FileName\":\"filename1.txt\",\"MimeType\":\"text/plain\",\"Size\":13,\"__calystotype\":\"Calysto_Blob\"}";

			Assert.AreEqual(res1, json1);

			CalystoBlob blob1 = JsonSerializer.Deserialize<CalystoBlob>(json1);
			Assert.AreEqual(blob.FileName, blob1.FileName);
			Assert.AreEqual(blob.MimeType, blob1.MimeType);
			Assert.AreEqual(blob.Size, blob1.Size);
			Assert.IsTrue(blob.Data.SequenceEqual(blob1.Data));
		}

		[TestMethod]
		public void CalystoBlobTest2()
		{
			// using BinaryFrame
			byte[] data = Encoding.UTF8.GetBytes("this is test1");
			CalystoBlob blob = new CalystoBlob();
			blob.FileName = "filename1.txt";
			blob.MimeType = "text/plain";
			blob.Size = data.Length;
			blob.Data = data;

			BinaryFrame frame = BinaryFrame.Serialize(blob);

			string res1 = "{\"DataUrl\":null,\"BlobIndex\":0,\"FileName\":\"filename1.txt\",\"MimeType\":\"text/plain\",\"Size\":13,\"__calystotype\":\"Calysto_Blob\"}";
			Assert.AreEqual(res1, frame.Json);
			Assert.AreEqual(1, frame.Blobs.Count);

			byte[] data1 = frame.ToBinaryData();

			CalystoBlob blob1 = BinaryFrame.Deserialize<CalystoBlob>(data1);
			Assert.AreEqual(blob.FileName, blob1.FileName);
			Assert.AreEqual(blob.MimeType, blob1.MimeType);
			Assert.AreEqual(blob.Size, blob1.Size);
			Assert.IsTrue(blob.Data.SequenceEqual(blob1.Data));
		}

		[TestMethod]
		public void CalystoDecimalTest1()
		{
			CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hr-HR");
			// string is hr-HR culture
			string str1 = "23.123.831,234";
			ObjectConverter converter = new ObjectConverter(new SerializerOptions() { Culture = CultureInfo.CurrentCulture});
			object res1 = converter.ConvertObjectToType(str1, typeof(decimal?));

			Assert.AreEqual(23123831.234m, res1);
		}

		[TestMethod]
		public void CalystoDecimalTest12()
		{
			CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hr-HR");
			// string is hr-HR culture
			string str1 = "23.123.83";
			ObjectConverter converter = new ObjectConverter(new SerializerOptions() { Culture = CultureInfo.CurrentCulture });
			object res1 = converter.ConvertObjectToType(str1, typeof(decimal?));

			Assert.AreEqual(2312383m, res1);
		}

		[TestMethod]
		public void CalystoDecimalTest2()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
			// string is en-US culture
			string str1 = "23,831.234";
			ObjectConverter converter = new ObjectConverter(new SerializerOptions() { Culture = CultureInfo.CurrentCulture });
			object res1 = converter.ConvertObjectToType(str1, typeof(decimal?));

			Assert.AreEqual(23831.234m, res1);
		}

		[TestMethod]
		public void CalystoDecimalTest3()
		{
			// default converter culture is Invariant culture
			// decimal separator is dot, group separator is comma
			string str1 = "23,831.234";
			ObjectConverter converter = new ObjectConverter();
			object res1 = converter.ConvertObjectToType(str1, typeof(decimal?));

			Assert.AreEqual(23831.234m, res1);
		}

	}
}