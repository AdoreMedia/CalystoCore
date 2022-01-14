using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;

namespace Calysto.Serialization.Xml
{
	/// <summary>
	/// does not works with AnonymousTypes
	/// </summary>
	public class XmlTools
	{
#if !SILVERLIGHT
		/// <summary>
		/// Tested, works fine, creates string without utf-x
		/// </summary>
		/// <param name="objToSerialize"></param>
		/// <returns></returns>
		public static string SerializeToXmlString(Object objToSerialize)
		{
			XmlSerializer ser = new XmlSerializer(objToSerialize.GetType());
			
			MemoryStream ms = new MemoryStream();
			ser.Serialize(ms, objToSerialize);
			ms.Close();
			ms.Dispose();
			UTF8Encoding utf = new UTF8Encoding();
			return utf.GetString(ms.GetBuffer());
		}

		/// <summary>
		/// Tested, works fine
		/// </summary>
		/// <param name="xmlString"></param>
		/// <param name="typeToDeserializeTo"></param>
		/// <returns></returns>
		public static Object DeserializeFromXmlString(string xmlString, Type typeToDeserializeTo)
		{
			UTF8Encoding utf = new UTF8Encoding();
			byte[] xmlBytes = utf.GetBytes(xmlString);
			MemoryStream ms = new MemoryStream();
			ms.Write(xmlBytes, 0, xmlBytes.Length);
			ms.Position = 0;
			Object temp = null;
			try
			{
				XmlSerializer saa = new XmlSerializer(typeToDeserializeTo);
				temp = saa.Deserialize(ms);
			}
			catch
			{ }
			ms.Close();
			ms.Dispose();
			return temp;
		}

		/// <summary>
		/// Tested, works fine
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlString"></param>
		/// <returns></returns>
		public static T DeserializeFromXmlString<T>(string xmlString)
		{
			Object obj = DeserializeFromXmlString(xmlString, typeof(T));
			if(obj == null)
			{
				return default(T);
			}
			else
			{
				return (T) obj;
			}
		}
#endif

#if SILVERLIGHT	

		public string SerializeToXmlString(Object objToSerialize)
		{
			MemoryStream mem = new MemoryStream();
			XmlSerializer xs = new XmlSerializer(objToSerialize.GetType());
			mem.Seek(0, SeekOrigin.Begin);
			xs.Serialize(mem, objToSerialize);
			byte[] data = mem.ToArray();
			string xmlString = Encoding.UTF8.GetString(data, 0, data.Length);
			return xmlString;
		}

		public T DeserializeFromXmlString<T>(string xmlString)
		{
			try
			{
				StringReader sr = new StringReader(xmlString);
				XmlSerializer xs = new XmlSerializer(typeof(T));
				object res = xs.Deserialize(sr);
				return (T)res;
			}
			catch
			{
				return default(T);
			}
		}
#endif

	}
}
