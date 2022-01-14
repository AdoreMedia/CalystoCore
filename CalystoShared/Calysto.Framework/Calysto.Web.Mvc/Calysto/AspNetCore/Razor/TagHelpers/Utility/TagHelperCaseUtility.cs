using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers.Utility
{
	public class TagHelperCaseUtility
	{
		/// <summary>
		/// Takes border-color and returns BorderColor.
		/// </summary>
		/// <param name=""></param>
		/// <param name=""></param>
		/// <returns></returns>
		public static string AttributeToPropertyName(string attributeName)
		{
			var re = new Regex("(^[a-z])|(-([a-z]))");
			string ss = re.Replace(attributeName, m =>
			{
				if (m.Groups[1].Success)
					return m.Groups[1].Value.ToUpper();
				else
					return m.Groups[3].Value.ToUpper();
			});

			return ss;
		}

		/// <summary>
		/// Takes BorderColor and returns border-color.
		/// </summary>
		/// <param name=""></param>
		/// <param name=""></param>
		/// <returns></returns>
		public static string PropertyToAttributeName(string propertyName)
		{
			var re = new Regex("(^[A-Z])|([A-Z])");
			string ss = re.Replace(propertyName, m =>
			{
				if (m.Groups[1].Success)
					return m.Groups[1].Value.ToLower();
				else
					return "-" + m.Groups[2].Value.ToLower();
			});
			return ss;
		}

	}
}
