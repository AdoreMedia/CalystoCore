using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Calysto.Text.RegularExpressions
{
	[DebuggerDisplay("{debuggerString}")]
	public class CalystoMatchSegment
	{
		private string debuggerString { get { return "Success: " + this.Success + ", Index: " + this.Index + ", Length: " + this.Length + ", Value: " + this.Value; } }

		// original Match
		public Match Match { get; set; }

		/// <summary>
		/// True if match, false if segment doesn't match
		/// </summary>
		public bool Success { get { return this.Match != null && this.Match.Success; } }

		// Summary:
		//     The position in the original string where the first character of the captured
		//     substring is found.
		//
		// Returns:
		//     The zero-based starting position in the original string where the captured
		//     substring is found.
		public int Index { get; set; }
		//
		// Summary:
		//     Gets the length of the captured substring.
		//
		// Returns:
		//     The length of the captured substring.
		public int Length { get; set; }
		//
		// Summary:
		//     Gets the captured substring from the input string.
		//
		// Returns:
		//     The substring that is captured by the match.
		public string Value { get; set; }
	}
}
