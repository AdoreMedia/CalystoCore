using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Xml.Parser
{
	[DebuggerDisplay("{Text}")]
	public class CalystoSegment
	{
		static List<CalystoSegmentKind> _enumValues = Enum.GetValues(typeof(CalystoSegmentKind)).Cast<CalystoSegmentKind>().ToList();
		static List<string> _enumNames = _enumValues.Select(o => o.ToString()).ToList();
		static Dictionary<CalystoSegmentKind, string> _dicNames = _enumValues.ToDictionary(o => o, o => o.ToString());

		Match _match;

		public CalystoSegment(Match match)
		{
			_match = match;
		}

		public CalystoSegment(CalystoSegmentKind kind)
		{
			_kind = kind;
		}

		public int Level { get; set; }

		public int StartPosition { get { return _match != null ? _match.Index : -1; } }

		public Match Match { get { return _match; } }

		private CalystoSegmentKind GetSuccessfulKind()
		{
			return _enumValues
				.Select(o => new
				{
					Kind = o,
					Group = _match.Groups[_dicNames[o]]
				}).Where(o => o.Group != null && o.Group.Success)
				.Select(o=>o.Kind).FirstOrDefault();
		}

		public string GetGroupValue(CalystoSegmentKind groupName)
		{
			Group g = _match.Groups[_dicNames[groupName]];
			return g == null ? null : g.Value;
		}

		public bool IsSuccessful(CalystoSegmentKind groupName)
		{
			return _match.Groups[_dicNames[groupName]].Success;
		}

		private CalystoSegmentKind? _kind;
		/// <summary>
		/// first successful group
		/// </summary>
		public virtual CalystoSegmentKind Kind { get { return (_kind ?? (_kind = GetSuccessfulKind())).GetValueOrDefault(); } }

		public virtual string Text { get { return _match.Value; } }

	}

}
