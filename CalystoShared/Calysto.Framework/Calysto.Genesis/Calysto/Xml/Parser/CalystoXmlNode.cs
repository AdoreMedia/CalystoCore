using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Calysto.Linq;
using System.Collections.ObjectModel;

namespace Calysto.Xml.Parser
{
	[DebuggerDisplay("{OutterXml}")]
	public class CalystoXmlNode
	{
		/// <summary>
		/// Get or set the data item that is bound to the xmlNode.
		/// </summary>
		public object DataItem { get; set; }
		internal CalystoSourceKindEnum SourceKind { get; set; }
		private string mNodeValue = "";
		internal string NodeValue { get { return mNodeValue; } set { mNodeValue = value ?? ""; } }
		public CalystoXmlNodeType NodeType { get; internal set; }
		private string mTagName = "";
		public string TagName { get { return mTagName; } set { mTagName = value ?? ""; } }
		internal CalystoParsingStateEnum ParsingState { get; set; }
		List<CalystoXmlNode> mChildren = new List<CalystoXmlNode>();
		public List<CalystoXmlNode> Children { get { return mChildren; } }
		public CalystoXmlNode Parent { get; internal set; }
		List<CalystoXmlAttribute> mAttributes = new List<CalystoXmlAttribute>();
		public List<CalystoXmlAttribute> Attributes { get { return mAttributes; } }
		public List<CalystoXmlNode> Ancestors { get { return this.AncestorNodes().ToList(); } }

		#region helper properties for resolving broken html

		public int Level { get; internal set; }
		//internal XmlNode StartTagNode { get; set; }
		//internal XmlNode EndTagNode { get; set; }

		#endregion

		private void AddSingleChild(CalystoXmlNode child)
		{
			child.Parent = this;
			this.Children.Add(child);
		}

		public CalystoXmlNode AddChildren(IEnumerable<CalystoXmlNode> children)
		{
			foreach (CalystoXmlNode child in children)
			{
				this.AddSingleChild(child);
			}
			return this;
		}

		public CalystoXmlNode AddChildren(params CalystoXmlNode[] children)
		{
			foreach (CalystoXmlNode child in children)
			{
				this.AddSingleChild(child);
			}
			return this;
		}

		public bool HasError()
		{
			return this.ParsingState != CalystoParsingStateEnum.NodeClosed && this.ParsingState != CalystoParsingStateEnum.NodeSelfClosed;
		}

		public string NodeName
		{
			get
			{
				return ((string.IsNullOrEmpty(this.TagName) ? ("#" + this.NodeType) : this.TagName)) ?? "";
			}
		}

		internal string StartTagText
		{
			get
			{
				if (this.ParsingState == CalystoParsingStateEnum.EndTag)
				{
					return "";
				}
				else if (this.NodeType == CalystoXmlNodeType.XmlHeader)
				{
					string attr = this.Attributes.Select(o => o.GetString()).ToStringJoined(" ");
					return "<?xml " + attr + "?>";
				}
				else if (this.NodeType == CalystoXmlNodeType.AspxHeader)
				{
					string attr = this.Attributes.Select(o => o.GetString()).ToStringJoined(" ");
					return "<%@ " + this.TagName + " " + attr + " %>";
				}
				else if (!string.IsNullOrEmpty(this.TagName))
				{
					string attr = this.Attributes.Select(o => o.GetString()).ToStringJoined(" ");
					return "<" + this.TagName + (string.IsNullOrEmpty(attr) ? null : " " + attr) + (this.ParsingState == CalystoParsingStateEnum.NodeSelfClosed ? "/>" : ">");
				}
				else
				{
					return "";
				}
			}
		}

		internal string EndTagText
		{
			get
			{
				if (this.ParsingState == CalystoParsingStateEnum.EndTag)
				{
					return "</" + this.TagName + ">";
				}
				else if (this.ParsingState == CalystoParsingStateEnum.NodeSelfClosed)
				{
					return "";
				}
				else
				{
					// for debugging only in allNodes collection
					return string.IsNullOrEmpty(this.TagName) ? "" : "</" + this.TagName + ">";
				}
			}
		}

		/// <summary>
		///  node itself, includes tag and attributes, but no children xml. Used for search by text.
		/// </summary>
		internal string StartTagTextAndNodeValue
		{
			get
			{
				return this.StartTagText + (string.IsNullOrEmpty(this.NodeValue) ? null : " " + this.NodeValue);
			}
		}


		private CalystoXmlNode RootNode
		{
			get
			{
				CalystoXmlNode s = this;
				while (s.Parent != null)
				{
					s = s.Parent;
				}
				return s;
			}
		}

		/// <summary>
		/// get or set InnerXml
		/// </summary>
		public string InnerXml
		{
			get
			{
				if (this.Children.Count > 0)
				{
					return this.Children.Select(o => o.OutterXml).ToStringJoined();
				}
				else
				{
					return this.NodeValue ?? "";
				}
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.mChildren = new List<CalystoXmlNode>();
					this.NodeValue = null;
				}
				else
				{
					this.NodeValue = null;
					this.NodeType = this.Parent != null ? this.Parent.NodeType : CalystoXmlNodeType.Xml;
					this.mChildren = new List<CalystoXmlNode>();
					if (!string.IsNullOrEmpty(value))
					{
						CalystoXmlDocument doc = CalystoXmlDocument.Parse(value ?? "", this.RootNode.SourceKind);
						this.AddChildren(doc.Children);
					}
				}
			}
		}

		public virtual string OutterXml
		{
			get
			{
				return this.StartTagText + this.InnerXml + this.EndTagText;
			}
		}

		static Regex mRemoveHtmlRegex = new Regex("<[^>]+>");

		/// <summary>
		/// Get or set InnerText
		/// </summary>
		public string InnerText
		{
			get
			{
				string xml = this.InnerXml; 
				return string.IsNullOrEmpty(xml) ? "" : mRemoveHtmlRegex.Replace(xml, "");
			}
			set
			{
				this.mChildren = new List<CalystoXmlNode>();
				this.NodeType = CalystoXmlNodeType.Text;
				this.NodeValue = value ?? "";
			}
		}

		static Regex mRemoveCdataRegex = new Regex("\\<\\!\\[CDATA\\[(?<text>[\\w\\W]*?)\\]\\]\\>", RegexOptions.IgnoreCase);

		/// <summary>
		/// Get or set text inside CDATA section
		/// </summary>
		public string CdataText
		{
			get
			{
				// remove <![CDATA[some text]]>
				string innerXml = this.InnerXml;
				Match m = mRemoveCdataRegex.Match(innerXml);
				if (m.Groups["text"].Success)
				{
					return m.Groups["text"].Value;
				}
				else
				{
					return "";
				}
			}
			set
			{
				this.mChildren = new List<CalystoXmlNode>();
				this.NodeType = CalystoXmlNodeType.Cdata;
				this.NodeValue = "<![CDATA[" + value + "]]>" ?? "";
			}
		}

		#region constructors

		public CalystoXmlNode()
		{
		}

		#endregion

		#region Attribute methodes

		/// <summary>
		/// returns attribute or null if not found
		/// </summary>
		/// <param name="attributeName"></param>
		/// <param name="caseSensitive"></param>
		/// <returns></returns>
		public CalystoXmlAttribute GetAttributeNode(string attributeName, bool caseSensitive = false)
		{
			return this.Attributes.FirstOrDefault(o=>o.Name.Equals(attributeName, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// return "" if attribute is null or it's value is null to enable .Contains(...) methods
		/// </summary>
		/// <param name="attributeName"></param>
		/// <returns></returns>
		public string GetAttributeValue(string attributeName, bool caseSensitive = false)
		{
			CalystoXmlAttribute attr = GetAttributeNode(attributeName, caseSensitive);
			return attr == null ? "" : attr.Value ?? "";
		}

		/// <summary>
		/// set attribute value or add new attribute with value
		/// </summary>
		/// <param name="attributeName"></param>
		/// <param name="attributeValue">may be null for HTML5 compatibility</param>
		public CalystoXmlNode SetAttributeValue(string attributeName, string attributeValue = null)
		{
			CalystoXmlAttribute attr = GetAttributeNode(attributeName);
			if (attr == null)
			{
				this.Attributes.Add(new CalystoXmlAttribute(attributeName, attributeValue));
			}
			// HTML5 comapatibility: value may be null, build attribute name only if value is null: <audio controls>...</audio>
			////else if (string.IsNullOrEmpty(attributeValue))
			////{
			////    this.Attributes.Remove(attr);
			////}
			else
			{
				attr.Value = attributeValue;
			}
			return this;
		}

		#endregion

		#region Custom properties

		/// <summary>
		/// Get or set node id attribute
		/// </summary>
		public string Id
		{
			get { return GetAttributeValue("id"); }
			set { SetAttributeValue("id", value); }
		}

		/// <summary>
		/// Get or set node value attribute
		/// </summary>
		public string Value
		{
			get { return GetAttributeValue("value"); }
			set { SetAttributeValue("value", value); }
		}

		/// <summary>
		/// Get or set style attribute
		/// </summary>
		public string Style
		{
			get { return GetAttributeValue("style"); }
			set { SetAttributeValue("style", value); }
		}

		/// <summary>
		/// Get or set class attribute
		/// </summary>
		public string Class
		{
			get { return GetAttributeValue("class"); }
			set { SetAttributeValue("class", value); }
		}

		public ReadOnlyCollection<string> ClassList => this.Class.Split(' ').Select(o => o.Trim()).Where(o => !string.IsNullOrWhiteSpace(o)).ToList().AsReadOnly();

		public bool HasClass(string name) => this.ClassList.Where(o => o == name).Any();

		/// <summary>
		/// Get or set name attribute
		/// </summary>
		public string Name
		{
			get { return GetAttributeValue("name"); }
			set { SetAttributeValue("name", value); }
		}

		/// <summary>
		/// Get or set type attribute
		/// </summary>
		public string Type
		{
			get { return GetAttributeValue("type"); }
			set { SetAttributeValue("type", value); }
		}

		/// <summary>
		/// Get or set checked attribute
		/// </summary>
		public string Checked
		{
			get { return GetAttributeValue("checked"); }
			set { SetAttributeValue("checked", value); }
		}

		/// <summary>
		/// Get or set href attribute
		/// </summary>
		public string Href
		{
			get { return GetAttributeValue("href"); }
			set { SetAttributeValue("href", value); }
		}

		/// <summary>
		/// Get or set src attribute
		/// </summary>
		public string Src
		{
			get { return GetAttributeValue("src"); }
			set { SetAttributeValue("src", value); }
		}

		/// <summary>
		/// Get or set href attribute
		/// </summary>
		public string Title
		{
			get { return GetAttributeValue("title"); }
			set { SetAttributeValue("title", value); }
		}

		/// <summary>
		/// Get or set rel attribute
		/// </summary>
		public string Rel
		{
			get { return GetAttributeValue("rel"); }
			set { SetAttributeValue("rel", value); }
		}


		#endregion
	}


}
