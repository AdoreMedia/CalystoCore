using Calysto.Common;
using Calysto.Common.Extensions;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	/// <summary>
	/// Parse errors throw using sql function fnThrowErrorMessage
	/// </summary>
	public class CalystoSqlErrorMessage
	{
		public enum KindEnum
		{
			Unknown,
			ErrorCode,
			SystemMessage,
			CustomerMessage
		}

		public KindEnum Kind;
		public string Value;

		private static KindEnum DetectKind(string kind)
		{
			if (Enum.TryParse<KindEnum>(kind, true, out KindEnum val1))
				return val1;
			else
				return KindEnum.Unknown;
		}

		public static List<CalystoSqlErrorMessage> FromException(Exception ex, bool unwindAll = false)
		{
			// vidi fnThrowErrorMessage za strukturu poruke
			string msg1;

			if (unwindAll)
				msg1 = ex.Unwind().Select(o => o.Message).ToStringJoined(";;; ");
			else
				msg1 = ex?.GetBaseException()?.Message;

			return Regex.Matches(msg1 ?? "", "(\\[\\[\\[(?<type>[\\w\\W]*?)\\]\\]\\])*" + "\\{\\{\\{(?<text>[\\w\\W]*?)\\}\\}\\}").Cast<Match>()
				.Select(m => new CalystoSqlErrorMessage()
				{
					Kind = DetectKind(m.Groups["type"].Value.ToNullIfEmpty(true)),
					Value = m.Groups["text"].Value.ToNullIfEmpty(true)
				}).ToList();
		}

		public static bool TryExtractCustomerError(Exception ex, out string errMsg)
		{
			errMsg = FromException(ex, true).Where(o => o.Kind == KindEnum.CustomerMessage).Select(o => o.Value).ToStringJoined("\r\n").ToNullIfEmpty(true);
			return !string.IsNullOrWhiteSpace(errMsg);
		}
	}
}