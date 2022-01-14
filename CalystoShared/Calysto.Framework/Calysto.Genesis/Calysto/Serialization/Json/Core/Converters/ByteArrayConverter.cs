using System;
using System.Collections.Generic;
using System.Linq;
using Calysto.Web;
using System.Text;
using Calysto.Linq;
using Calysto.Serialization.Json.Core.Serialization;

namespace Calysto.Serialization.Json.Core.Converters
{
	/// <summary>
	/// <para>the main idea is to show the same date and time as it was on server, but if client browser is in different time zone, time zone will not be correct.</para>
	/// <para>on server use local time and get local ticks, send local ticks to client</para>
	/// <para>on client create Date() JS object and adjust time zone so the time and date will be exatctly the same as on server, only time zone on client may be different</para>
	/// <para>, this is not absolutely correct, but this way we have exactly the same time and date on client and server, but we have to keep in mind that client's time zone may be different</para>
	/// </summary>
	internal class ByteArrayConverter : IJavaScriptConverter
	{
		const string __calystotype = "Calysto_ByteArray";

		private object Convert(object obj, SerializerOptions options)
		{
			// it supports both: BlobIndex and base64 data string

			int? blobIndex = ((Dictionary<string, object>)obj).GetValueOrDefault("BlobIndex") as int? ?? default(int?);

			if (blobIndex.HasValue)
			{
				// let's throw exception if there is not blob data
				return options.BFOutput.Blobs.Where(o => o.BlobIndex == blobIndex).Select(o => o.Data).First();
			}

			string base64str = ((Dictionary<string, object>)obj).GetValueOrDefault("Data") as string ?? "";
			return System.Convert.FromBase64String(base64str);
		}

		public bool TryConvert(object obj, Type toType, SerializerOptions options, out object result)
		{
			// always search for __calystotype key
			// don't use toType == typeof(byte[]) because toType may be Object
			
			if (obj is IDictionary<string, object> dic)
			{
				if (dic.TryGetValue("__calystotype", out var key) && object.Equals(key, __calystotype))
				{
					result = Convert(obj, options);
					return true;
				}
			}

			result = null;
			return false;
		}

		public bool TrySerialize(object obj, StringBuilder sb, SerializerOptions options)
		{
			if (obj?.GetType() != typeof(byte[]))
				return false;

			// it supports both:
			// if we want BinaryFrame so we create BlobIndex
			// or if we have byte[] which is serialized to base64 data string

			byte[] data = (byte[])obj;

			if (options.Format == SerializationFormat.JavaScript)
			{
				throw new Exception("byte[] can not be serialized in JavaScript serialization mode");
			}

			int? index1 = null;
			string base64str = null;
			if (options.UseBinaryFrame)
			{
				index1 = options.BFOutput.Blobs.Count;
			}
			else
			{
				base64str = System.Convert.ToBase64String(data);
			}

			string json1 = JsonSerializer.Serialize(new
			{
				__calystotype = __calystotype,
				Size = data.Length,
				BlobIndex = index1,
				Data = base64str
			});
			sb.Append(json1);

			if (options.UseBinaryFrame)
			{
				options.BFOutput.Blobs.Add(new CalystoBlob()
				{
					BlobIndex = index1,
					Data = data, // byte[] will be saved as binary, without conversion
					Size = data.Length
				});
			}

			return true;
		}
	}

}
