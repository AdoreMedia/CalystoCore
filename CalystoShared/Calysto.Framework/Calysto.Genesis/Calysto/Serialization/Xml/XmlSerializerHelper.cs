#if !SILVERLIGHT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Calysto.Serialization.Xml
{
	/// <summary>
	/// AnonymousType serializer
	/// </summary>
	public class XmlSerializerHelper
	{
		public bool AddType { get; set; }

		XmlDocument _doc;

		private string GetValidName(string name)
		{
			if (name.Contains("AnonymousType"))
			{
				return "object";
			}
			else
			{
				return name;
			}
		}

		private string GetValidName(object obj)
		{
			if (obj == null)
			{
				return "";
			}
			else if (!(obj is string) && obj is IEnumerable)
			{
				return "array";
			}
			else
			{
				return GetValidName(obj.GetType().Name);
			}
		}

		private string GetTypeName(Type tt)
		{
			string name = (System.Nullable.GetUnderlyingType(tt) ?? tt).FullName;
			if (name.Contains("AnonymousType"))
			{
				return "object";
			}
			else
			{
				return name;
			}
		}

		private void SetValue(XmlElement el, object obj)
		{
			el.InnerXml = (obj + "").Replace("<", "&lt;").Replace(">", "&gt;");
		}

		private void SerializeInternal(XmlElement parent, object obj)
		{
			if (obj == null || obj is string)
			{
				SetValue(parent, obj);
			}
			else if(obj.GetType().FullName.Contains("KeyValuePair"))
			{
				string key = obj.GetType().GetProperty("Key").GetValue(obj, null) + "";
				object value = obj.GetType().GetProperty("Value").GetValue(obj, null);
				XmlElement el = _doc.CreateElement(key);
				parent.AppendChild(el);
				SerializeInternal(el, value);
			}
			else if(obj.GetType().IsValueType)
			{
				SetValue(parent, obj);
			}
			else if (obj is IDictionary)
			{
				var en = ((IDictionary)obj).GetEnumerator();
				while (en.MoveNext())
				{
					XmlElement el = _doc.CreateElement(en.Key + "");
					parent.AppendChild(el);
					SerializeInternal(el, en.Value);
				}
			}
			else if (obj is IEnumerable)
			{
				foreach (object a1 in (IEnumerable)obj)
				{
					XmlElement item = _doc.CreateElement("item");
					parent.AppendChild(item);
					if (a1 != null && this.AddType)
					{
						item.SetAttribute("type", GetTypeName(a1.GetType()));
					}
					SerializeInternal(item, a1);
				}
			}
			else
			{
				foreach (MemberInfo mi in obj.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance))
				{
					object value;
					Type type;

					if (mi.MemberType == MemberTypes.Property)
					{
						PropertyInfo pi = (PropertyInfo)mi;
						type = ((PropertyInfo)mi).PropertyType;
						value = pi.GetValue(obj, null);
					}
					else if (mi.MemberType == MemberTypes.Field)
					{
						FieldInfo fi = (FieldInfo)mi;
						type = fi.FieldType;
						value = fi.GetValue(obj);
					}
					else
					{
						continue;
					}

					XmlElement el = _doc.CreateElement(GetValidName(mi.Name));
					parent.AppendChild(el);
					if (this.AddType)
					{
						el.SetAttribute("type", GetTypeName(type));
					}

					SerializeInternal(el, value);
				}
			}
		}

		private string Serialize2(object obj)
		{
			_doc = new XmlDocument();
			XmlElement el = _doc.CreateElement(GetValidName(obj));
			_doc.AppendChild(el);
			if (this.AddType)
			{
				el.SetAttribute("type", GetTypeName(obj.GetType()));
			}
			SerializeInternal(el, obj);
			MemoryStream ms = new MemoryStream();
			_doc.Save(ms);
			return Encoding.UTF8.GetString(ms.ToArray());
		}

		public static string Serialize(object obj, bool addTypeAttribute = false)
		{
			XmlSerializerHelper ser = new XmlSerializerHelper() { AddType = addTypeAttribute };
			return ser.Serialize2(obj);
		}

	}
}
#endif
