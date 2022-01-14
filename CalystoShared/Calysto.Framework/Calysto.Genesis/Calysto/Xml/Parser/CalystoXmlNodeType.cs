namespace Calysto.Xml.Parser
{
	public enum CalystoXmlNodeType
	{
		/// <summary>
		/// Default
		/// </summary>
		Xml = 0,
		Text,
		Cdata,
		Doctype,
		AspxHeader,
		AspxCodeBlock,
		AspxComment,
		PhpCodeBlock,
		XmlHeader,
		Comment,
		NonParsedText,
		Script,
		Style,
		JSObject
	}
}