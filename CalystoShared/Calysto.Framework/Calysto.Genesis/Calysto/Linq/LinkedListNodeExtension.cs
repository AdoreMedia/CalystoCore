using System.Collections.Generic;

namespace Calysto.Linq
{
	public static class LinkedListNodeExtension
	{
		public static IEnumerable<LinkedListNode<TItem>> PreviousNodes<TItem>(this LinkedListNode<TItem> node, bool includeCurrent = false)
		{
			if (node != null)
			{
				if (includeCurrent)
					yield return node;

				var tmp1 = node;
				while ((tmp1 = tmp1.Previous) != null)
				{
					yield return tmp1;
				}
			}
		}

		public static IEnumerable<LinkedListNode<TItem>> NextNodes<TItem>(this LinkedListNode<TItem> node, bool includeCurrent = false)
		{
			if (node != null)
			{
				if (includeCurrent)
					yield return node;

				var tmp1 = node;
				while ((tmp1 = tmp1.Next) != null)
				{
					yield return tmp1;
				}
			}
		}
	}
}