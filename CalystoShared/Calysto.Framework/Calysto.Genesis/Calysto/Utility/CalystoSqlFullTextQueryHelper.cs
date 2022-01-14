using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	public class CalystoSqlFullTextQueryHelper
	{
		private string _searchText;

		public CalystoSqlFullTextQueryHelper(string searchText)
		{
			this._searchText = searchText;
		}

		public IEnumerable<string> GetWords()
		{
			return new Regex("[\\w\\*]+")
				.Matches(this._searchText ?? "")
				.Cast<Match>()
				.Select(o => o.Value)
				.Where(o => !string.IsNullOrWhiteSpace(o));
		}

		/// <summary>
		/// Exact words, keep star (*) if exists.
		/// </summary>
		/// <param name="joinWith"></param>
		/// <returns></returns>
		public string GetWordsQuery(string joinWith = "AND")
		{
			return this.GetWords()
				.Select(o => "\"" + o + "\"")
				.ToStringJoined(" " + joinWith + " ")
				.ToNullIfEmpty();
		}

		/// <summary>
		/// Remove ending vocals from words and add star (*) at the end of every word.
		/// </summary>
		/// <param name="joinWith"></param>
		/// <returns></returns>
		public string GetWordsQueryWithEndingStar(string joinWith = "AND")
		{
			return this.GetWords()
				.Select(o =>
				{
					string s1 = o.TrimEnd("aeiouAEIOU*".ToCharArray());
					if (s1 == o)
						return o + "*";
					else if (string.IsNullOrWhiteSpace(s1))
						return null;
					else
						return s1 + "*";
				})
				.Where(o => !string.IsNullOrWhiteSpace(o))
				.Select(o => "\"" + o + "\"")
				.ToStringJoined(" " + joinWith + " ")
				.ToNullIfEmpty();
		}
	}
}

