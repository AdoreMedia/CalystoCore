using System;

namespace Calysto.Common.Extensions
{
	public static class CalystoObjectExtensions
	{
		/// <summary>
		/// Thread safe access to TObject methods. Lock is made on TObject itself.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public static TResult UsingLock<TObject, TResult>(this TObject obj, Func<TObject, TResult> fn)
		{
			lock (obj)
				return fn.Invoke(obj);
		}

		/// <summary>
		/// Thread safe access to TObject methods. Lock is made on TObject itself.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public static void UsingLock<TObject>(this TObject obj, Action<TObject> fn)
		{
			lock (obj)
				fn.Invoke(obj);
		}

		/// <summary>
		/// Invoke fn in this context and return this.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <param name="obj"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public static TObject UsingThis<TObject>(this TObject obj, Action<TObject> fn)
		{
			fn.Invoke(obj);
			return obj;
		}

		/// <summary>
		/// Invoke fn in try-catch, return result of default if exeption occures.
		/// </summary>
		/// <typeparam name="TObject"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public static TResult UsingTryCatch<TObject, TResult>(this TObject obj, Func<TObject, TResult> fn, TResult defaultResult = default)
		{
			try
			{
				return fn.Invoke(obj);
			}
			catch
			{
				return defaultResult;
			}
		}
	}
}
