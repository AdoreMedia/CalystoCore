using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Ajax.Utilities.Css2
{
	public class CssMinifier
	{
		public static string Minify(string cssCode, MinifyModeEnum mode)
		{
			if (mode >= MinifyModeEnum.RemoveComments)
			{
				//remove /* */ comments
				// use [\\w\\W], since .*? doesn't work with unicode chars
				cssCode = new Regex(Regex.Escape("/*") + "[\\w\\W]*?" + Regex.Escape("*/")).Replace(cssCode, " ");
			}

			if (mode >= MinifyModeEnum.Minify)
			{
				// replace multiple white space with single space
				cssCode = new Regex("[\\s]+").Replace(cssCode, " ");

				// remove @charset ... ;
				// file has to be saved with utf-8 bom instead
				cssCode = new Regex("@charset[\\s]+[^;]+;").Replace(cssCode, " ");

				// remove white space arround ; { } ,
				cssCode = new Regex(@"[ ]*([\;\{\}\,]+)[ ]*").Replace(cssCode, "$1"); // tested, ok, don't use : because of: :nth-child(1) :first-child

				// inside {...} block replace spaces arround :
				Regex re2 = new Regex(@"[\{][^\{\}]+[\}]");

				Regex re3 = new Regex(@"[ ]*([\:])[ ]*");

				cssCode = re2.Replace(cssCode, match =>
				{
					return re3.Replace(match.Value, ":");
				});

				return cssCode.TrimStart();
			}

			return cssCode;
		}
	}
}
