#if !SILVERLIGHT

using System.Collections.Generic;
using System.Xml;

namespace Calysto.Xml
{
	public static class XmlExtensions
	{
		public static IEnumerable<XmlNode> DescendantNodes(this XmlNode node, bool includeSelf = false)
		{
			if(includeSelf) yield return node;

			if (node.ChildNodes != null)
			{
				foreach (XmlNode n in node.ChildNodes)
				{
					yield return n;

					foreach (XmlNode n1 in n.DescendantNodes())
					{
						yield return n1;
					}
				}
			}
		}

		public static IEnumerable<XmlNode> AncestorNodes(this XmlNode node, bool includeSelf = false)
		{
			if (includeSelf) yield return node;

			while ((node = node.ParentNode) != null)
			{
				yield return node;
			}
		}
	}


}

#endif

