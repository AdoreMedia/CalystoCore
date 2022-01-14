using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Calysto.Net
{
	public static class CookieContainerExtensions
	{
		public static List<System.Net.Cookie> GetAllCookies(this CookieContainer c)
		{
			if(c == null)
			{
				return new List<Cookie>();
			}

			FieldInfo fi1 = c.GetType().GetField("m_domainTable", BindingFlags.NonPublic | BindingFlags.Instance);
			Hashtable m_domainTable = fi1.GetValue(c) as Hashtable;
			var final = m_domainTable.Cast<DictionaryEntry>().SelectMany(o =>
			{
				List<System.Net.Cookie> list = new List<Cookie>();

				FieldInfo fi2 = o.Value.GetType().GetField("m_list", BindingFlags.NonPublic | BindingFlags.Instance);
				System.Collections.SortedList list1 = fi2.GetValue(o.Value) as System.Collections.SortedList;
				foreach (System.Net.CookieCollection coll in list1.Values)
				{
					foreach (System.Net.Cookie cc in coll)
					{
						list.Add(cc);
					}
				}
				return list;
			}).ToList();

			return final;
		}
	}
}
