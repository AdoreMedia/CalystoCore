using System;
using System.Globalization;
using System.Threading;

namespace Calysto.Globalization
{
	public class CalystoCultureInfoHelper
	{
		public static readonly CultureInfo HRCulture = CultureInfo.GetCultureInfo("hr-HR");
		public static readonly CultureInfo USCulture = CultureInfo.GetCultureInfo("en-US");
		public static readonly CultureInfo SRCulture = CultureInfo.GetCultureInfo("sr-RS");
		public static readonly CultureInfo SRCyrilicCulture = CultureInfo.GetCultureInfo("sr-CS");

		/// <summary>
		/// Set culture, invoke action, restore original culture.
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="action"></param>
		public static TResult UsingCulture<TResult>(CultureInfo culture, Func<TResult> action)
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			CultureInfo currentUICulture = CultureInfo.CurrentUICulture;

			CultureInfo.CurrentCulture = culture;
			CultureInfo.CurrentUICulture = culture;

			try
			{
				return action.Invoke();
			}
			finally
			{
				Thread.CurrentThread.CurrentCulture = currentCulture;
				Thread.CurrentThread.CurrentUICulture = currentUICulture;
			}
		}

		/// <summary>
		/// Set culture, invoke action, restore original culture.
		/// </summary>
		/// <param name="culture"></param>
		/// <param name="action"></param>
		public static void UsingCulture(CultureInfo culture, Action action)
		{
			UsingCulture(culture, () => { action.Invoke(); return true; });
		}

		public static TResult UsingHRCulture<TResult>(Func<TResult> action)
		{
			return UsingCulture(HRCulture, action);
		}

		public static TResult UsingUSCulture<TResult>(Func<TResult> action)
		{
			return UsingCulture(USCulture, action);
		}

		public static TResult UsingInvariantCulture<TResult>(Func<TResult> action)
		{
			return UsingCulture(System.Globalization.CultureInfo.InvariantCulture, action);
		}
	}
}
