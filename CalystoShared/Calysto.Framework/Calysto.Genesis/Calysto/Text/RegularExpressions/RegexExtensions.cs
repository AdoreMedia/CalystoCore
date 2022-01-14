using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calysto.Text.RegularExpressions
{
	public static class RegexExtensions
	{
		/// <summary>
		/// Select matches.
		/// </summary>
		/// <param name="re"></param>
		/// <param name="input"></param>
		/// <param name="startIndex"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static IEnumerable<Match> SelectMatches(this Regex re, string input, int? startIndex = null, int? length = null)
		{
			Match m = null;
			if (startIndex != null && length != null)
			{
				m = re.Match(input, startIndex.Value, length.Value);
			}
			else if (startIndex != null)
			{
				m = re.Match(input, startIndex.Value);
			}
			else
			{
				m = re.Match(input);
			}

			while (m.Success)
			{
				yield return m;
				m = m.NextMatch();
			}
		}

		/// <summary>
		/// Select matches and unmatches.
		/// </summary>
		/// <param name="re"></param>
		/// <param name="input"></param>
		/// <param name="startIndex"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static IEnumerable<CalystoMatchSegment> SelectSegments(this Regex re, string input, int? startIndex = null, int? length = null)
		{
			int lastStartPosition = 0;
			string segment = null;
			int len = 0;

			foreach(var m in SelectMatches(re, input, startIndex, length))
			{
				if(m.Index > lastStartPosition)
				{
					// it is unmached segment
					segment = input.Substring(lastStartPosition, m.Index - lastStartPosition);
					len = segment.Length;
					yield return new CalystoMatchSegment() { Index = lastStartPosition, Value = segment, Length = len};
					// new position:
					lastStartPosition += len;
				}
				// return matched segment
				yield return new CalystoMatchSegment() { Index = m.Index, Value = m.Value, Length = m.Length, Match = m };
				// new position:
				lastStartPosition = m.Index + m.Length;
			}

			// any segment left which is unmached
			segment = input.Substring(lastStartPosition);
			len = segment.Length;
			if (len > 0)
			{
				// something has left at the end
				yield return new CalystoMatchSegment() { Index = lastStartPosition, Value = segment, Length = len };
			}
		}
	}
}
