using Calysto.IO;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calysto.Serialization.Json
{
	public class BinaryFrame
	{
		public string Json { get; set; }
		public List<CalystoBlob> Blobs { get; set; }

		public static BinaryFrame Serialize<T>(T obj, SerializerOptions options = null)
		{
			ObjectSerializer ser = new ObjectSerializer(options);
			ser.Options.UseBinaryFrame = true;
			string json1 = ser.Serialize(obj);

			return new BinaryFrame()
			{
				Json = json1,
				Blobs = ser.Options.BFOutput.Blobs
			};
		}

		const int _headerSizeBytes = 4;

		public class BinaryToc
		{
			public class TocItem
			{
				public int? Size { get; set; }
				public string FileName { get; set; }
				public int? BlobIndex { get; set; }
				public string MimeType { get; set; }
				public bool IsJson { get; set; }
			}

			public List<TocItem> Items { get; set; }
		}

		private static byte[] CreateBinaryFrame(string json, List<CalystoBlob> blobsArray)
		{
			if (blobsArray == null) blobsArray = new List<CalystoBlob>();

			// first 4 bytes contains TOC length
			// then goes TOC content, it is JSON encoded into binary stream
			// then goes data block, as described in TOC
			BinaryToc toc = new BinaryToc()
			{
				Items = blobsArray.Select(o => new BinaryToc.TocItem
				{
					Size = o.Data != null ? o.Data.Length : (int?)null,
					FileName = o.FileName,
					MimeType = o.MimeType,
					BlobIndex = o.BlobIndex
				}).ToList()
			};

			// main JSON will be written at the end, as las Blob
			byte[] jsonData = Encoding.UTF8.GetBytes(json);

			toc.Items.Add(new BinaryToc.TocItem()
			{
				Size = jsonData.Length,
				MimeType = "application/json",
				IsJson = true
			});

			string tocJson = Calysto.Serialization.Json.JsonSerializer.Serialize(toc);

			byte[] tocBytes = Encoding.UTF8.GetBytes(tocJson);
			// toc length, 4 bytes
			byte[] tocLength = Calysto.Utility.CalystoTools.LongToByteArray(tocBytes.Length).Take(_headerSizeBytes).ToArray();

			MemoryStream ms = new MemoryStream();
			ms.Write(tocLength, 0, tocLength.Length); // toc length, 4 bytes
			ms.Write(tocBytes, 0, tocBytes.Length); // TOC
			// write blobs
			foreach (CalystoBlob blob in blobsArray)
			{
				if (blob.Data != null && blob.Data.Length > 0)
				{
					ms.Write(blob.Data, 0, blob.Data.Length);
				}
			}
			// write main JSON
			ms.Write(jsonData, 0, jsonData.Length);

			return ms.ToArray();
		}

		public byte[] ToBinaryData()
		{
			return CreateBinaryFrame(this.Json, this.Blobs);
		}

		public static T Deserialize<T>(byte[] binaryData, SerializerOptions options = null)
		{
			if (binaryData == null)
				throw new InvalidDataException("binaryData is null");

			if (!(binaryData?.Length > 0))
				throw new InvalidDataException("binaryData length is 0");

			BinaryReader reader = new BinaryReader(new MemoryStream(binaryData));

			int tocLength = (int)Calysto.Utility.CalystoTools.ByteArrayToLong(reader.ReadBytes(_headerSizeBytes)); // header size is 4 bytes alway (_headerSizeBytes)
			
			if (tocLength < 0 || tocLength > binaryData.Length)
				throw new InvalidDataException("Invalid TOC length. Data may be encrypted.");

			string tocJson = Encoding.UTF8.GetString(reader.ReadBytes(tocLength));
			BinaryToc toc = Calysto.Serialization.Json.JsonSerializer.Deserialize<BinaryToc>(tocJson);

			if (toc == null)
				throw new InvalidDataException($"TOC is null, binaryData length: {(binaryData?.Length ?? -1)}, tocJson: {tocJson}");

			if (toc.Items == null)
				throw new InvalidDataException("toc.Items is null.");

			string mainJson = null;
			List<CalystoBlob> blobsList = new List<CalystoBlob>();
			foreach (BinaryToc.TocItem item in toc.Items)
			{
				byte[] data = reader.ReadBytes(item.Size.Value);
				if (item.IsJson)
				{
					mainJson = Encoding.UTF8.GetString(data);
				}
				else
				{
					blobsList.Add(new CalystoBlob()
					{
						BlobIndex = item.BlobIndex,
						Size = item.Size,
						MimeType = item.MimeType,
						FileName = item.FileName,
						Data = data
					});
				}
			}

			ObjectConverter converter = new ObjectConverter(options);
			converter.Options.UseBinaryFrame = true;
			converter.Options.BFOutput.Blobs.AddRange(blobsList);
			converter.Options.BFOutput.Json = mainJson;

			object obj1 = new ObjectDeserializer().BasicDeserialize(mainJson);
			return (T)converter.ConvertObjectToType(obj1, typeof(T));
		}

	}
}
