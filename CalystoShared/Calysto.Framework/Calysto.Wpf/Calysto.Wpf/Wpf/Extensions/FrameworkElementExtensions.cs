using System.Collections;
using System.Reflection;
using System.Windows;

namespace Calysto.Wpf.Extensions
{
	public static class FrameworkElementExtensions
	{
		static PropertyInfo _piLogicalChildren = typeof(FrameworkElement).GetProperty("LogicalChildren", BindingFlags.NonPublic | BindingFlags.Instance);

		public static IEnumerable Children(this FrameworkElement element, bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return element;

			var en1 = _piLogicalChildren.GetValue(element) as IEnumerator;
			while (en1.MoveNext())
				yield return en1.Current;
		}

		public static IEnumerable Descendants(this FrameworkElement element, bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return element;

			foreach (var ch1 in element.Children())
			{
				yield return ch1;
				
				if(ch1 is FrameworkElement frmel1)
				{
					foreach (var ch2 in frmel1.Children())
						yield return ch2;
				}
			}
		}

		public static IEnumerable Ancestors(this FrameworkElement element, bool includeCurrent = false)
		{
			if (includeCurrent)
				yield return element;

			DependencyObject tmp1 = element.Parent;
			while(tmp1 != null)
			{
				yield return tmp1;

				if (tmp1 is FrameworkElement frmel1)
					tmp1 = frmel1.Parent;
			}
		}
	}
}
