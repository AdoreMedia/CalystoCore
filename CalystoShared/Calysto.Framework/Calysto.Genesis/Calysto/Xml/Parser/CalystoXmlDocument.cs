using System;
using System.Diagnostics;

namespace Calysto.Xml.Parser
{
	[DebuggerDisplay("#root")]
	public class CalystoXmlDocument : CalystoXmlNode
	{
		/// <summary>
		/// parse html, returns #root node
		/// </summary>
		/// <param name="html"></param>
		/// <returns></returns>
		public static CalystoXmlDocument Parse(string str, CalystoSourceKindEnum kind = CalystoSourceKindEnum.Html)
		{
			return CalystoXmlParser.Parse(str, kind);
		}

		public static CalystoXmlDocument Parse(object p)
		{
			throw new NotImplementedException();
		}

		public static CalystoXmlDocument ParseHtml(string html)
		{
			return CalystoXmlParser.Parse(html, CalystoSourceKindEnum.Html);
		}

		public static CalystoXmlDocument ParseXml(string xml)
		{
			return CalystoXmlParser.Parse(xml, CalystoSourceKindEnum.Xml);
		}

		public static CalystoXmlDocument ParseJson(string json)
		{
			return CalystoXmlParser.Parse(json, CalystoSourceKindEnum.Json);
		}

		public override string OutterXml
		{
			get
			{
				return base.InnerXml;
			}
		}
	}


}
