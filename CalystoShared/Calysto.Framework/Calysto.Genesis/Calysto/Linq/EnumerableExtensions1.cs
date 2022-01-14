using Calysto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Linq
{
	public static class EnumerableExtensions1
	{
		/// <summary>
		/// Join string elements of List collection
		/// </summary>
		/// <typeparam name="?"></typeparam>
		/// <param name="s"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string ToStringJoined<TSource>(this IEnumerable<TSource> s, string separator = null)
		{
			return String.Join(separator, s);
		}

		/// <summary>
		/// If source is null, will return empty enumerable.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> ToEmptyIfNull<TSource>(this IEnumerable<TSource> source)
		{
			if (source != null)
			{
				foreach (var item in source)
					yield return item;
			}
		}

		/// <summary>
		/// Concatenate single item
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ienum"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, TSource item)
		{
			foreach (TSource m in source)
			{
				yield return m;
			}

			yield return item;
		}

		/// <summary>
		/// Returns items from first collection where predicate result is true
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Intersect<TSource, TSource2>(this IEnumerable<TSource> first, IEnumerable<TSource2> second, Func<TSource, TSource2, bool> predicate)
		{
			return first.Where(f => second.Any(s => predicate(f, s)));
		}

		/// <summary>
		/// Returns items from first collection where firstKey == secondKey. Very fast, uses dictionary. Enables comparison of two different collections.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <param name="firstKey"></param>
		/// <param name="secondKey"></param>
		/// <param name="excludeIntersection"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Intersect<TSource, TSource2, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource2> second, Func<TSource, TResult> firstKey, Func<TSource2, TResult> secondKey, bool excludeIntersection = false)
		{
			Dictionary<TResult, bool> secondKeys = null;

			foreach (TSource item in first)
			{
				if (secondKeys == null)
				{
					secondKeys = second.Select(secondKey).Distinct(k => k).ToDictionary(k => k, k => true);
				}

				if (secondKeys.ContainsKey(firstKey(item)) != excludeIntersection)
				{
					yield return item;
				}
			}
		}

		/// <summary>
		/// Returns items from first collection where firstKey != secondKey. Very fast, uses dictionary. Enables comparison of two different collections.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <param name="firstKey"></param>
		/// <param name="secondKey"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Except<TSource, TSource2, TResult>(this IEnumerable<TSource> first, IEnumerable<TSource2> second, Func<TSource, TResult> firstKey, Func<TSource2, TResult> secondKey)
		{
			return first.Intersect(second, firstKey, secondKey, true);
		}

		/// <summary>
		/// Returns the first element of a sequence, or a defaultValue if the sequence contains no elements.
		/// </summary>
		public static TSource FirstOrValue<TSource>(this IEnumerable<TSource> source, TSource defaultValue = default(TSource))
		{
			var items = source.Take(1).ToList();
			if (items.Count == 1)
			{
				return items.First();
			}
			else
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Returns the last element of a sequence, or a defaultValue if the sequence contains no elements.
		/// </summary>
		public static TSource LastOrValue<TSource>(this IEnumerable<TSource> source, TSource defaultValue = default(TSource))
		{
			var items = source.Reverse().Take(1).ToList();

			if (items.Count == 1)
			{
				return items.First();
			}
			else
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// ice dictionary based distinct which is much faster
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="keySelector"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Distinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> keySelector)
		{
			bool hasNullKey = false;

			Dictionary<TResult, bool> keys = new Dictionary<TResult, bool>();

			foreach (TSource item in source)
			{
				TResult key = keySelector(item);

				// warning: key may be null and it throws exception because dictionary key may not be null
				if (key == null)
				{
					if (!hasNullKey)
					{
						// take 1 result for null key
						hasNullKey = true;
						yield return item;
					}
				}
				else if (!keys.ContainsKey(key))
				{
					keys[key] = true;
					yield return item;
				}
			}
		}

		public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending)
		{
			if (descending)
			{
				return source.OrderByDescending(keySelector);
			}
			else
			{
				return source.OrderBy(keySelector);
			}
		}

		public static IOrderedEnumerable<TSource> OrderByRandom<TSource>(this IEnumerable<TSource> source)
		{
			CalystoRandom rnd = new CalystoRandom();
			return source.OrderBy(o => rnd.NextDouble());
		}

		public static IEnumerable<TSource> OrderByKey<TSource>(this IEnumerable<TSource> source, string key)
		{
			byte[] bytes1 = Encoding.UTF8.GetBytes(key);
			int len1 = bytes1.Length;

			return source.Select((item, index) => new {
				item,
				index,
				orderValue = bytes1[index % len1]
			})
			.OrderBy(s => s.orderValue)
			.Select(s => s.item);
		}

		/// <summary>
		/// Cycle current items endlessly. Use Take() to limit number of items.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Cycle<TSource>(this IEnumerable<TSource> source, int? take = null)
		{
			bool hasItems = false;
			int takenCount = 0;
			do
			{
				hasItems = false;

				foreach (var item in source)
				{
					if (take == null || takenCount < take)
					{
						hasItems = true;
						takenCount++;
						yield return item;
					}
					else
					{
						break;
					}
				}
			}
			while (hasItems);
		}

		/// <summary>
		/// Returns random items endlessly. Items are ordered randomly on every new cycle.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="take"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> CycleRandom<TSource>(this IEnumerable<TSource> source, int? take = null)
		{
			CalystoRandom rnd = new CalystoRandom();
			bool hasItems = false;
			int takenCount = 0;
			do
			{
				hasItems = false;

				foreach (var item in source.OrderBy(o => rnd.NextDouble()))
				{
					if (take == null || takenCount < take)
					{
						hasItems = true;
						takenCount++;
						yield return item;
					}
					else
					{
						break;
					}
				}
			}
			while (hasItems);
		}


		/// <summary>
		/// Take exact count of element from source. If actual count in source is different, throw exception. Exact(1) is the same as Single()
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static IEnumerable<TSource> Exact<TSource>(this IEnumerable<TSource> source, int exactCount)
		{
			var items = source.Take(exactCount + 1).ToList();
			if (items.Count != exactCount)
			{
				throw new Exception("Error in Exact(), expected " + exactCount + " elements, but found " + items.Count + " elements");
			}
			return items;
		}

		public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
		{
			var items = source.ToList();
			items.ForEach(action);
			return items;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <param name="source"></param>
		/// <param name="action">(obj, index)...</param>
		/// <returns></returns>
		public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
		{
			int index = 0;
			var items = source.ToList();
			items.ForEach(o => action(o, index++));
			return items;
		}

		public static Dictionary<TKey, TElement> ToDictionary<T, TKey, TElement>(this IEnumerable<T> source, Func<T, int, TKey> keySelector, Func<T, int, TElement> itemSelector)
		{
			int index = 0;
			Dictionary<TKey, TElement> dic = new Dictionary<TKey, TElement>();
			foreach (var item in source)
			{
				dic.Add(keySelector.Invoke(item, index), itemSelector.Invoke(item, index));
				index++;
			}
			return dic;
		}

		public static Dictionary<TKey, T> ToDictionary<T, TKey>(this IEnumerable<T> source, Func<T, int, TKey> keySelector)
		{
			int index = 0;
			Dictionary<TKey, T> dic = new Dictionary<TKey, T>();
			foreach (var item in source)
			{
				dic.Add(keySelector.Invoke(item, index), item);
				index++;
			}
			return dic;
		}

		public static CalystoDictionary<TKey, TSource> ToCalystoDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			CalystoDictionary<TKey, TSource> dic = new CalystoDictionary<TKey, TSource>();
			foreach(var item in source)
			{
				dic.Add(keySelector(item), item);
			}
			return dic;
		}

		public static CalystoDictionary<TKey, TElement> ToCalystoDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			CalystoDictionary<TKey, TElement> dic = new CalystoDictionary<TKey, TElement>();
			foreach (var item in source)
			{
				dic.Add(keySelector(item), elementSelector(item));
			}
			return dic;
		}

	}

}

