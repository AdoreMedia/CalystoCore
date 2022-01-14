using Calysto.Globalization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.Script.Services.Compiler
{
	public class CulturesGenerator
	{
		static string[] _defaultCultures = new string[] { "en-US", "hr-HR" }; // "sr-Latn-CS"

		public Dictionary<string, CalystoCultureInfo> GetDefaultCultures()
		{
			return GetCultures(_defaultCultures);
		}

		/// <summary>
		/// Get cultures from parameter cultures but except default cultures.
		/// </summary>
		/// <param name="cultures"></param>
		/// <returns></returns>
		public Dictionary<string, CalystoCultureInfo> GetNonDefaultCultures(string[] cultures)
		{
			return GetCultures(cultures.Except(_defaultCultures).ToArray());
		}

		public CalystoCultureInfo GetSingleCulture(string name)
		{
			return new CalystoCultureInfo(System.Globalization.CultureInfo.GetCultureInfo(name));
		}

		private Dictionary<string, CalystoCultureInfo> GetCultures(string[] cultures)
		{
			// current culture is at first position
			// en-US i hr-HR is required for parsing numbers in unittests (dot or comma)
			return cultures.Where(o => !string.IsNullOrWhiteSpace(o)) // coz Invariant culture has Name == ""
					.Distinct()
					.Select(o => GetSingleCulture(o))
					//.ToDictionary(o => o.Name.Replace("-", "_"), o => o);
					.ToDictionary(o => o.Name);
		}
	}
}
