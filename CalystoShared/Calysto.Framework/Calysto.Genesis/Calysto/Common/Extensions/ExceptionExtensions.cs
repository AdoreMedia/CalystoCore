using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Common.Extensions
{
	public static class ExceptionExtensions
	{
		/// <summary>
		/// Unwind exceptions. BaseException (the most InnerException) is first.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static LinkedList<Exception> Unwind(this Exception ex)
		{
			LinkedList<Exception> list = new LinkedList<Exception>();
			while (ex != null)
			{
				list.AddFirst(ex);
				ex = ex.InnerException;
			}
			return list;
		}

		const string _separator1 = "\r\n^^^^^^^^^^^ InnerException ^^^^^^^^^^^\r\n";

		public static string UnwindToString(this Exception ex)
		{
			var en1 = ex.Unwind()
				.Select(o => $"{o.GetType().FullName}: {o.Message}\r\n{o.StackTrace}");

			return string.Join(_separator1, en1);
		}

	}
}
