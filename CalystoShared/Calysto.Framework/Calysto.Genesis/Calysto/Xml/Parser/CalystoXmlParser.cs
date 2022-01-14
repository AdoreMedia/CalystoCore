using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using Calysto.Linq;
using Calysto.Text.RegularExpressions;

namespace Calysto.Xml.Parser
{
	public enum CalystoSourceKindEnum
	{
		Html,
		Xml,
		Json
	}

	public enum CalystoSegmentKind
	{
		Unknown,
		FreeText,
		scriptNode,
		styleNode,
		cdataNode,
		phpCodeBlock,
		xmlHeader,
		htmlComment,
		htmlDoctype,
		aspxComment,
		aspxHeader,
		aspxCodeBlock,
		NodeSelfClosed,
		StartTag,
		EndTag,
		
		// inner matches
		attr,
		tag,
		content
	}

	internal class CalystoXmlParser
	{
		#region common methods & variables

		CalystoXmlNode currentElement = null;
		List<CalystoXmlNode> allNodes = new List<CalystoXmlNode>();
		StringBuilder freeTextBuffer = new StringBuilder();

		private CalystoXmlParser()
		{
		}

		private void FlushFreeTextBuffer()
		{
			if(freeTextBuffer != null)
			{
				AddTextNode(freeTextBuffer.ToString(), CalystoXmlNodeType.Text);
				freeTextBuffer = null;
			}
		}

		private void AddFreeTextToBuffer(string txt)
		{
			if (freeTextBuffer == null)
			{
				freeTextBuffer = new StringBuilder();
			}
			freeTextBuffer.Append(txt);
		}

		private void AddChildNode(CalystoXmlNode parent, CalystoXmlNode child)
		{
			child.Parent = parent;
			child.Level = parent.Level + 1;
			parent.Children.Add(child);
			allNodes.Add(child);
		}

		private void AddTextNode(string nodeValue, CalystoXmlNodeType nodeType, object dataItem = null)
		{
			AddChildNode(currentElement, new CalystoXmlNode()
			{
				NodeType = nodeType,
				ParsingState = CalystoParsingStateEnum.NodeClosed,
				NodeValue = nodeValue,
				DataItem = dataItem
			});
		}

		#endregion

		#region parse HTML & XML

		#region regex for HTML & XML parsing

		private static string GetRegexPattern(bool isHtml)
		{
			// xml specific part is always included
			// html specific part is included only if isHtml == true
			// warning: do not change patterns order

			return new[]
			{
				new {include = true, regex = "(?<FreeText>((< )|( >)))"}, // space before > or after <, it is not tag, eg. <div>temp >10 and < temp11 10 < ma < ne < Moze </div>
				new {include = isHtml, regex = "(?<scriptNode><script(?<attr>[^>]*)>(?<content>[\\w\\W]*?)</script>)"}, // <script type="text/javascript"> ...content... </script>
				new {include= isHtml, regex = "(?<styleNode><style(?<attr>[^>]*)>(?<content>[\\w\\W]*?)</style>)"}, // <style type="text/css"> ...content... </style>
				new {include = true, regex = "(?<cdataNode><\\!\\[CDATA\\[(?<cdata>[\\w\\W]*?)\\]\\]>)"}, // <![CDATA[   ...some text or script...  ] ]>
				new {include = isHtml, regex = "(?<phpCodeBlock>[<][\\?]php[\\w\\W]*?[\\?][>])"}, // <?php .... ?>
				new {include = true, regex = "(?<xmlHeader>[<][\\?]xml(?<attr>[^>]*?)[\\?][>])"}, // <?xml version="1.0" encoding="utf-8" ?>
				new {include = true, regex = "(?<htmlComment><\\!\\-\\-[\\w\\W]*?\\->)"}, // <!--html comment-->
				new {include = isHtml, regex = "(?<htmlDoctype><\\!DOCTYPE[^>]*>)"}, // <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
				new {include = isHtml, regex = "(?<aspxComment><%\\-\\-[\\w\\W]*?\\-\\-%>)"}, // <%--aspx comment--%>
				new {include = isHtml, regex = "(?<aspxHeader><%@[ ]*(?<tag>[\\w]+)(?<attr>[\\w\\W]*?)%>)"}, // <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FileUploadWeb.WebForm2" %>
				new {include = isHtml, regex = "(?<aspxCodeBlock><%[\\w\\W]*?%>)"}, // <% aspx code block %>
				new {include = true, regex = "(?<NodeSelfClosed>[<][ ]*(?<tagName>[\\w\\:\\-\\._]+)[ ]*(?<attr>[^<>]*?)/>)"}, // NodeSelfClosed has to be tested before StartTag bacause of /> at the end: < br />, <img .../>
				new {include = true, regex = "(?<StartTag>[<][ ]*(?<tagName>[\\w\\:\\-\\._]+)[ ]*(?<attr>[^<>]*?)>)"}, // <div>, ima nekih htmlova gdje je space iza <, znaci < div ...., ali to je invalid html
				new {include = true, regex = "(?<EndTag>[<]\\/[ ]*(?<tagName>[\\w\\:\\-\\._]+)[ ]*>)"}, // </div>
				new {include = true, regex = "(?<FreeText>(([^><]+)|([><]+?)))"} // free text, take all non <>, or if it is < or >, then take 1 by 1 and buffer it into freeTextBuffer
			}.Where(o => o.include == true).Select(o => o.regex).ToStringJoined("|");
		}

		private static readonly Regex mMainRegexXml = new Regex(GetRegexPattern(false), RegexOptions.IgnoreCase);

		private static readonly Regex mMainRegexHtml = new Regex(GetRegexPattern(true), RegexOptions.IgnoreCase);

		// atribute style: name = "value", name = 'value' name=value, x:Size="234" (xaml)
		// html5 compatible: <audio controls autoplay preload="none" myfiles=mojifileovi drugidio=1234 volume=0.5 raq=1.5>
		private static readonly Regex mAttributesRegex = new Regex("((?<name>[\\w\\:\\-\\._]+)[ ]*=[ ]*((\"(?<val>[^\"]*?)\")|('(?<val>[^']*?)')|((?<val>[^ ='\">]*))))|(?<name>[\\w\\:\\-\\._]+)", RegexOptions.IgnoreCase);

		private static readonly Regex mReStartTagNameOnly = new Regex("([<][\\/]*(?<tagName>[\\w\\:\\-\\._]+))", RegexOptions.IgnoreCase);  // tagname ili attribute name moze [^ >='\"\\/], ali je sigurnije [\\w\\:\\-\\.]

		// tags that can not contain other tags
		private static readonly Dictionary<string, bool> mHtmlSelfClosingTags = new string[]{
										"link",
										 "base",
										 "meta",
										 "isindex",
										 "hr",
										 "col",
										 "img",
										 "param",
										 "embed",
										 "frame",
										 "wbr",
										 "bgsound",
										 "spacer",
										 "keygen",
										 "area",
										 "input",
										 "basefont",
										 "br"
		}.ToDictionary(o => o.ToLower(), o=>true);

		#endregion

		private static bool IsSelfClosingHTMLTag(string tag)
		{
			return mHtmlSelfClosingTags.ContainsKey(tag.ToLower());
		}

		private string ExtractTagName(string html, CalystoSourceKindEnum kind)
		{
			Match m = mReStartTagNameOnly.Match(html);
			if (m.Groups["tagName"].Success)
			{
				return m.Groups["tagName"].Value;
			}
			else
			{
				return null;
			}
		}

		private void ExtractAttributes(string str, CalystoXmlNode node)
		{
			MatchCollection mc = CalystoXmlParser.mAttributesRegex.Matches(str);
			foreach (Match matt in mc)
			{
				// HTML5: attribute value may not be defined: <audio controls autoplay preload="none">....</audio>, set null for value and when building attributes, if value is null, use attribute name only
				node.Attributes.Add(new CalystoXmlAttribute(matt.Groups["name"].Value, matt.Groups["val"].Success ? matt.Groups["val"].Value : null));
			}
		}

		private CalystoXmlDocument ParseHtmlWorker(string html, CalystoSourceKindEnum kind)
		{
			CalystoXmlDocument document = new CalystoXmlDocument() { ParsingState = CalystoParsingStateEnum.NodeClosed, SourceKind = kind};
			currentElement = document;

			// parse html into segments
			var segments = (kind == CalystoSourceKindEnum.Html ? mMainRegexHtml : mMainRegexXml).SelectMatches(html ?? "").Select(o => new CalystoSegment(o));

			foreach(CalystoSegment seg in segments)
			{
				if(seg.IsSuccessful(CalystoSegmentKind.FreeText))
				{
					AddFreeTextToBuffer(seg.Text);
					continue;
				}

				FlushFreeTextBuffer();

				if(seg.IsSuccessful(CalystoSegmentKind.cdataNode))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.Cdata);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.phpCodeBlock))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.PhpCodeBlock);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.xmlHeader))
				{
					////AddTextNode(m.Value, XmlNodeType.XmlHeader);
					CalystoXmlNode node = new CalystoXmlNode();
					node.NodeType = CalystoXmlNodeType.XmlHeader;
					node.ParsingState = CalystoParsingStateEnum.NodeSelfClosed;
					ExtractAttributes(seg.GetGroupValue(CalystoSegmentKind.attr), node);
					AddChildNode(currentElement, node);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.htmlComment))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.Comment);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.aspxComment))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.AspxComment);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.htmlDoctype))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.Doctype);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.aspxHeader))
				{
					////AddTextNode(m.Value, XmlNodeType.AspxHeader);
					CalystoXmlNode node = new CalystoXmlNode();
					node.TagName = seg.GetGroupValue(CalystoSegmentKind.tag).Trim();
					node.NodeType = CalystoXmlNodeType.AspxHeader;
					node.ParsingState = CalystoParsingStateEnum.NodeSelfClosed;
					ExtractAttributes(seg.GetGroupValue(CalystoSegmentKind.attr), node);
					AddChildNode(currentElement, node);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.aspxCodeBlock))
				{
					AddTextNode(seg.Text, CalystoXmlNodeType.AspxCodeBlock);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.scriptNode) || seg.IsSuccessful(CalystoSegmentKind.styleNode))
				{
					CalystoXmlNode node = new CalystoXmlNode();
					node.TagName = ExtractTagName(seg.Text, kind);
					node.ParsingState = CalystoParsingStateEnum.NodeClosed;
					ExtractAttributes(seg.GetGroupValue(CalystoSegmentKind.attr), node);
					AddChildNode(currentElement, node);

					// script node can have text node as child only
					// script may contain html code as string, we don't want to parse it
					string content = seg.GetGroupValue(CalystoSegmentKind.content);
					if (!string.IsNullOrEmpty(content))
					{
						CalystoXmlNode scriptNode = new CalystoXmlNode();
						scriptNode.NodeType = seg.IsSuccessful(CalystoSegmentKind.scriptNode) ? CalystoXmlNodeType.Script : CalystoXmlNodeType.Style;
						scriptNode.NodeValue = content;
						scriptNode.ParsingState = CalystoParsingStateEnum.NodeClosed;
						AddChildNode(node, scriptNode); // add script content as child to node
					}
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.NodeSelfClosed))
				{
					CalystoXmlNode node = new CalystoXmlNode();
					node.NodeType = CalystoXmlNodeType.Xml;
					node.ParsingState = CalystoParsingStateEnum.NodeSelfClosed;
					node.TagName = ExtractTagName(seg.Text, kind);
					ExtractAttributes(seg.GetGroupValue(CalystoSegmentKind.attr), node);
					AddChildNode(currentElement, node);
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.StartTag))
				{
					CalystoXmlNode node = new CalystoXmlNode();
					node.NodeType = CalystoXmlNodeType.Xml;
					node.ParsingState = CalystoParsingStateEnum.StartTag;
					node.TagName = ExtractTagName(seg.Text, kind);
					ExtractAttributes(seg.GetGroupValue(CalystoSegmentKind.attr), node);
					AddChildNode(currentElement, node);
					if (kind == CalystoSourceKindEnum.Html && IsSelfClosingHTMLTag(node.TagName))
					{
						// this closes nodes like <br> or <img...> which should be self closed
						node.ParsingState = CalystoParsingStateEnum.NodeSelfClosed;
					}
					else
					{
						currentElement = node; // expect children, but only if node is not self closed
					}
				}
				else if (seg.IsSuccessful(CalystoSegmentKind.EndTag))
				{
					string tagName = ExtractTagName(seg.Text, kind);

					// for fixing broken html, but not implemented
					CalystoXmlNode endNode = new CalystoXmlNode() { TagName = tagName, ParsingState = CalystoParsingStateEnum.EndTag, Level = currentElement.Level };
					allNodes.Add(endNode);

					if (kind == CalystoSourceKindEnum.Html && IsSelfClosingHTMLTag(tagName))
					{
						// ignore closing tag if node is self-closed already, </img> or </meta>
					}
					else
					{
						if (kind != CalystoSourceKindEnum.Html && tagName != currentElement.TagName)
						{
							currentElement.ParsingState = CalystoParsingStateEnum.InvalidEndTag;
						}
						else if (kind == CalystoSourceKindEnum.Html && !tagName.Equals(currentElement.TagName, StringComparison.OrdinalIgnoreCase))
						{
							// html tag has to be case nonsensitive
							
							// this is simple and quick fix for broken html, if current node doesn't match, try to match with parent node (required for Freemeteo.com, 7-days forecast)
							// npr. ako se zatvori parent td, automatski se zatvara i div i span: <td><div><span>fdsgsd</td>, closing div and span is missing, but consider div and span closed since parent td is closed, this is standard
							// test all ancestors up to the root
							CalystoXmlNode ancestor = currentElement.AncestorNodes().Where(o => tagName.Equals(o.TagName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
							if (ancestor != null)
							{
								currentElement = ancestor;
								currentElement.ParsingState = CalystoParsingStateEnum.NodeClosed;
							}
							else
							{
								// mark node as invalid, but don't throw exeption
								currentElement.ParsingState = CalystoParsingStateEnum.InvalidEndTag;
							}
						}
						else
						{
							currentElement.ParsingState = CalystoParsingStateEnum.NodeClosed;
						}

						if (currentElement.Parent != null)
						{
							// if parent is null, document is broken, add other nodes to current node
							currentElement = currentElement.Parent; // no children are expected any more to currentElement, move up level
						}
					}
				}
			}

			FlushFreeTextBuffer();

			return document;
		}

		#endregion

		#region parse JSON

		private void ProcessJsonNode(object obj)
		{
			if (obj is string)
			{
				// string is IEnumerable, that is why we have to test firs if it is string
				AddTextNode(obj + "", CalystoXmlNodeType.Text, obj);
			}
			else if (obj is IEnumerable)
			{
				foreach (object cobj in obj as IEnumerable)
				{
					CalystoXmlNode node = new CalystoXmlNode();
					node.DataItem = cobj;
					AddChildNode(currentElement, node);
					node.NodeType = CalystoXmlNodeType.JSObject;
					if (string.IsNullOrEmpty(node.TagName))
					{
						node.TagName = "js:object";
					}
					node.ParsingState = CalystoParsingStateEnum.NodeClosed;
					currentElement = node;
					ProcessJsonNode(cobj);
					currentElement = node.Parent;
				}
			}
			else if (obj is KeyValuePair<string, object>)
			{
				KeyValuePair<string, object> kv = ((KeyValuePair<string, object>)obj);
				currentElement.DataItem = obj;
				currentElement.NodeType = CalystoXmlNodeType.JSObject;
				currentElement.TagName = kv.Key;
				ProcessJsonNode(kv.Value);
			}
			else
			{
				// just a value
				AddTextNode(obj + "", CalystoXmlNodeType.Text, obj);
			}
		}

		private CalystoXmlDocument ParseJsonWorker(string json)
		{
			object obj = Calysto.Serialization.Json.JsonSerializer.DeserializeObject(json);
			// tree is dictionary tree output from JavaScriptSerializer.DeserializeObject()
			CalystoXmlDocument document = new CalystoXmlDocument() { ParsingState = CalystoParsingStateEnum.NodeClosed, SourceKind = CalystoSourceKindEnum.Json};
			currentElement = document;
			ProcessJsonNode(obj);
			return document;
		}

		#endregion

		#region parse entry point

		public static CalystoXmlDocument Parse(string str, CalystoSourceKindEnum kind = CalystoSourceKindEnum.Html)
		{
			CalystoXmlParser parser = new CalystoXmlParser();

			switch (kind)
			{
				case CalystoSourceKindEnum.Html:
				case CalystoSourceKindEnum.Xml:
					return parser.ParseHtmlWorker(str, kind);
				case CalystoSourceKindEnum.Json:
					return parser.ParseJsonWorker(str);
				default:
					throw new NotImplementedException();
			}
		}

		#endregion

	}
}
