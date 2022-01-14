namespace Calysto.Xml.Parser
{
	internal enum CalystoParsingStateEnum
	{
		Unknown,

		/// <summary>
		/// start tag opened, attributes are expected &lt;div ... attributes...
		/// </summary>
		StartTag, // <....attributes....>

		/// <summary>
		/// end tag eg. &lt;/div&gt;
		/// </summary>
		EndTag, // .... </div>

		/////// <summary>
		/////// end tag mached with StartTag
		/////// </summary>
		////EndTagMatched,
		
		/// <summary>
		/// self closed node, eg. &lt;img..../&gt;
		/// </summary>
		NodeSelfClosed, // ... />
		
		/////// <summary>
		/////// attributes nodes
		/////// </summary>
		////Attributes,
		
		/// <summary>
		/// node is complete, closed with EndTag &lt;div&gt;....content....&lt;/div&gt;
		/// </summary>
		NodeClosed,


		InvalidEndTag

	}
}
