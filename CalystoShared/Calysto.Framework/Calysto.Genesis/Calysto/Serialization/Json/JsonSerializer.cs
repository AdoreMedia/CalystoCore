using Calysto.AbstractSyntaxTree;
using Calysto.Data;
using Calysto.Serialization.Json.Core.Serialization;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Calysto.Serialization.Json
{
	public class JsonSerializer
	{
		public static string Serialize<T>(T obj, SerializerOptions options = null)
		{
			ObjectSerializer ser = new ObjectSerializer(options);
			return ser.Serialize(obj);
		}

		public static string FormSerialize<T>(T obj)
		{
			ObjectAstNode node = new ObjectAstNode(obj);
			var list = node.Descendants(true).Where(o => !o.Children().Any()).ToList();
			var dic = list.ToDictionary(o => o.FormsNamePath, o => o.Value);
			ObjectSerializer ser = new ObjectSerializer();
			return ser.Serialize(dic);
		}

		public static object ConvertToType(object obj, Type toType)
		{
			ObjectConverter converter = new ObjectConverter();
			return converter.ConvertObjectToType(obj, toType);
		}

		public static T ConvertToType<T>(object obj)
		{
			return (T)ConvertToType(obj, typeof(T));
		}


		public static object DeserializeObject(string json)
		{
			return new ObjectDeserializer().BasicDeserialize(json);
		}

		public static T Deserialize<T>(string json, SerializerOptions options = null)
		{
			object obj1 = DeserializeObject(json);
			return (T) new ObjectConverter(options).ConvertObjectToType(obj1, typeof(T));
		}

		/// <summary>
		/// Conversion to T instance when dic keys are half nested or full flat properties.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dic1"></param>
		/// <returns></returns>
		public static T FormConvertToType<T>(Dictionary<string, object> dic1)
		{
			// reconstruct full hierachy which is required for ObjectConverter to be able to convert to real object
			// propertes in dic1 mey half nested, e.g. prop1[1]
			// or full flat e.g. prop1[1].prop2.prop3, prop1[1].prop2.prop4
			Dictionary<string, object> dic2 = new Dictionary<string, object>();
			ObjectAstNode node1 = new ObjectAstNode(dic1);
			var list1 = node1.Descendants(false).ToArray();
			foreach(var item1 in list1)
			{
				// list will be converted to dictionary with keys as indexes
				// ObjectConverter may handle conversion from dictionary to list
				// running FormConvertToType creates dictionary with keys as indexes instead of List
				// because while reconstructing hierarchy we need multiple assignments by index which is not always ordered,
				// and some indexes may be missing (e.g. if form field is disabled, it is not sent to server)
				// that is why we create dictionary with keys as indexes which wil be converted to list in ObjectConverter
				CalystoDataBinder.Default.SetValue(dic2, item1.FormsNamePath, item1.Value, n => typeof(Dictionary<string, object>));
			}

			SerializerOptions options = new SerializerOptions() { Culture = CultureInfo.CurrentCulture };
			ObjectConverter converter = new ObjectConverter(options);
			var obj1 = converter.ConvertObjectToType(dic2, typeof(T));
			return (T)obj1;
		}

		public static T FormDeserialize<T>(string json)
		{
			var obj1 = JsonSerializer.DeserializeObject(json);
			if (obj1 is Dictionary<string, object> dic1)
			{
				return FormConvertToType<T>(dic1);
			}
			throw new NotSupportedException();
		}

	}
}
