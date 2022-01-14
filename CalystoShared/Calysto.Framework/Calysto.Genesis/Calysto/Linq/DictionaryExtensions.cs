using Calysto.Common;
using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Linq
{
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Get value from dictionary if key exits, else default value. Doesn't throw exception if key doesn't exist.
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="source"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue = default(TValue))
		{
			TValue val;
			if (source.TryGetValue(key, out val))
			{
				return val;
			}
			else
			{
				return defaultValue;
			}
		}

		///// <summary>
		///// Thread safe get value if exists, else create new one using fnCreateNew, add value to dictionary and return value.
		///// </summary>
		///// <param name="key"></param>
		///// <param name="fnCreateNew"></param>
		///// <param name="expiration"></param>
		///// <param name="isSlidingExpiration"></param>
		///// <returns></returns>
		//public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> fnCreateNew)
		//{
		//	if (!source.TryGetValue(key, out TValue value))
		//	{
		//		lock (source)
		//		{
		//			if (!source.TryGetValue(key, out value))
		//			{
		//				value = fnCreateNew.Invoke();
		//				source.Add(key, value);
		//			}
		//		}
		//	}

		//	return value;
		//}

		public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> fnCreateNewValue)
		{
			if (!source.TryGetValue(key, out TValue value))
			{
				lock (source)
				{
					if (!source.TryGetValue(key, out value))
					{
						value = fnCreateNewValue.Invoke(key);
						source.Add(key, value);
					}
				}
			}

			return value;
		}

		/// <summary>
		/// Thread safe get value if exists, else create new TInstance and insert with key typeof(TInstance).FullName
		/// </summary>
		/// <typeparam name="TInstance"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static TInstance GetInstanceOrNew<TInstance>(this IDictionary<string, object> source)
		{
			string key = typeof(TInstance).FullName;
			if (!source.TryGetValue(key, out object value))
			{
				lock (source)
				{
					if (!source.TryGetValue(key, out value))
					{
						value = CalystoActivator.CreateInstance<TInstance>();
						source.Add(key, value);
					}
				}
			}

			return (TInstance)value;
		}
	}
}

