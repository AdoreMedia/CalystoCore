using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Calysto.Globalization
{
	public class ResxHelper
	{
		public class NameValue
		{
			public string Name;
			public string Value;

			public IEnumerable<string> GetLines(string newLine = "\r\n")
			{
				return (this.Value ?? "").Split('\r', '\n')
					 .Select(o => o.Trim())
					 .Where(o => !string.IsNullOrWhiteSpace(o))
					 .Reverse()
					 .Select((o, n) => o + (n > 0 ? newLine : ""))
					 .Reverse();
			}
		}

		public static IEnumerable<NameValue> GetProperties(Type resx)
		{
			var props = resx.GetProperties(BindingFlags.Static | BindingFlags.Public)
				.Where(p => p.PropertyType == typeof(string))
				.Select(p => new NameValue()
				{
					Name = p.Name,
					Value = p.GetValue(null) as string
				})
				.OrderBy(o => o.Name)
				.ToArray();

			return props;
		}

		public static IEnumerable<NameValue> GetProperties(string resxFilePath)
		{
			string xml = File.ReadAllText(resxFilePath, Encoding.UTF8);
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.SelectNodes("//data")
				.Cast<XmlElement>()
				.Select(o => new NameValue()
				{
					Name = o.GetAttribute("name"),
					Value = o.SelectSingleNode("value")?.InnerXml
				})
				.OrderBy(o => o.Name)
				.ToArray();

			return nodes;
		}
	}
}
