using System.Collections.Generic;
using Calysto.Threading;
using System.Data;
using System.Reflection;
using System;
using System.Linq;
using Calysto.Common;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Calysto.Linq
{
	public static class EnumerableExtensions3
	{
		public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this NameValueCollection collection)
		{
			return collection.AllKeys.Select(key => new KeyValuePair<string, string>(key, collection.Get(key)));
		}

		/// <summary>
		/// Copy elements from source to destination. 
		/// Modify destination by adding or removing items.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="destination"></param>
		/// <returns></returns>
		public static void SynchronizeTo<T>(this IList<T> source, IList<T> destination)
		{
			while (destination.Count > source.Count)
			{
				destination.RemoveAt(destination.Count - 1);
			}

			for (int index = 0; index < source.Count; index++)
			{
				if (destination.Count < index + 1)
				{
					destination.Insert(index, source[index]);
				}
				else if (!object.Equals(destination[index], source[index]))
				{
					destination[index] = source[index];
				}
			}
			
		}
	}

}

