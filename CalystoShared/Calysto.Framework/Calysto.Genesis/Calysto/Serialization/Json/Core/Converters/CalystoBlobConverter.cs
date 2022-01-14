using System;
using System.Collections.Generic;
using System.Linq;
using Calysto.Linq;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Web;
using System.Text;

namespace Calysto.Serialization.Json.Core.Converters
{
	/// <summary>
	/// <para>the main idea is to show the same date and time as it was on server, but if client browser is in different time zone, time zone will not be correct.</para>
	/// <para>on server use local time and get local ticks, send local ticks to client</para>
	/// <para>on client create Date() JS object and adjust time zone so the time and date will be exatctly the same as on server, only time zone on client may be different</para>
	/// <para>, this is not absolutely correct, but this way we have exactly the same time and date on client and server, but we have to keep in mind that client's time zone may be different</para>
	/// </summary>
	internal class CalystoBlobConverter : IJavaScriptConverter
	{
		const string __calystotype = "Calysto_Blob";

		class JsonBlob
		{
			/** (string) Base64 encoded data url */
			public string DataUrl { get; set; }
			/** (int) Blob index when indexes are used instead of dataURL */
			public int? BlobIndex { get; set; }
			/** (string) FileName string */
			public string FileName { get; set; }
			/** mime type */
			public string MimeType { get; set; }
			/** (int), data length */
			public int? Size { get; set; }
			/** string */
			public string __calystotype { get { return CalystoBlobConverter.__calystotype; } }
		}

		private object Convert(object obj, SerializerOptions options)
		{
			// convert from data:image/png;base64,iVBORw0KGgoAAkJggg==
			CalystoBlob blob = new CalystoBlob(){
				FileName = ((Dictionary<string, object>)obj).GetValueOrDefault("FileName") as string ?? "",
				MimeType = ((Dictionary<string, object>)obj).GetValueOrDefault("MimeType") as string ?? "",
				Size = ((Dictionary<string, object>)obj).GetValueOrDefault("Size") as  int? ?? default(int?)
			};

			// from client we may send:
			// DataUrl (base64 standard dataURL format) ili or binary upload using Form items:
			// or if sending Form items, frist item is JSON, other items are blobs, now we have to write binary values into object by BlobIndex
			string dataUrl = ((Dictionary<string, object>)obj).GetValueOrDefault("DataUrl") as string ?? "";
			int? blobIndex = ((Dictionary<string, object>)obj).GetValueOrDefault("BlobIndex") as int? ?? default(int?);

			if (!string.IsNullOrWhiteSpace(dataUrl))
			{
				CalystoBlob b1 = CalystoBlob.FromDataUrl(dataUrl);
				blob.MimeType = b1.MimeType;
				blob.Data = b1.Data;
			}
			else if(blobIndex.HasValue)
			{
				blob.BlobIndex = blobIndex;
				if (options.UseBinaryFrame)
				{
					blob.Data = options.BFOutput.Blobs.Where(o => o.BlobIndex == blobIndex).Select(o => o.Data).First();
				}
			}

			if(blob.Data != null && !blob.Size.HasValue)
			{
				blob.Size = blob.Data.Length;
			}

			return blob;
		}

		public bool TryConvert(object obj, Type toType, SerializerOptions options, out object result)
		{
			// always search for __calystotype key
			// don't use toType == typeof(CalystoBlob) because toType may be Object

			if (obj is IDictionary<string, object> dic)
			{
				if (dic.TryGetValue(nameof(__calystotype), out var key) && object.Equals(key, __calystotype))
				{
					result = this.Convert(obj, options);
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool TrySerialize(object obj, StringBuilder sb, SerializerOptions options)
		{
			if (obj?.GetType() != typeof(CalystoBlob))
				return false;

			CalystoBlob blob = (CalystoBlob)obj;

			if (options.Format == SerializationFormat.JavaScript)
			{
				sb.Append("fnJsonPostConvertObj2(");
			}

			if (options.UseBinaryFrame)
			{
				blob.BlobIndex = options.BFOutput.Blobs.Count;
			}

			// it is better to use anonymous type, than dictionary, this way it may generate default non-null values for intellisese
			string json1 = JsonSerializer.Serialize(new JsonBlob()
			{
				DataUrl = options.UseBinaryFrame ? null : blob.ToDataUrl(), // we have to create anonymous object, can't use existsing blob
				BlobIndex = blob.BlobIndex,
				FileName = blob.FileName,
				MimeType = blob.MimeType,
				Size = blob.Size.HasValue ? blob.Size : blob.Data != null ? blob.Data.Length : (int?)null
			});

			sb.Append(json1);

			if (options.UseBinaryFrame)
			{
				options.BFOutput.Blobs.Add(blob);
			}

			if (options.Format == SerializationFormat.JavaScript)
			{
				sb.Append(")");
			}

			return true;
		}
	}
}
