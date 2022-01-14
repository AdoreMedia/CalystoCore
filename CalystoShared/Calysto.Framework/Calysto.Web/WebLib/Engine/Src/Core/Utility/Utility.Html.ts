namespace Calysto.Utility.Html
{
	export function RemoveHtmlTags(html: string, replacement: string = "")
	{
		var re = new RegExp("\\<[^\\>]+\\>");
		while (html.match(re) != null)
		{
			html = html.replace(re, replacement || "");
		}
		return html;
	}

	export function ExtractAspNameOrId(aspNetIdOrName: string)
	{
		// include asp.net id: page$sub$txtName or page_sub_txtName
		if (aspNetIdOrName && typeof aspNetIdOrName == "string")
		{
			let n2 = aspNetIdOrName.lastIndexOf("_");
			if (n2 > 0)
			{
				return aspNetIdOrName.substr(n2 + 1);
			}

			let n1 = aspNetIdOrName.lastIndexOf("$");
			if (n1 > 0)
			{
				return aspNetIdOrName.substr(n1 + 1);
			}

			return aspNetIdOrName;
		}

		return undefined;
	}

	export function UrlEncode(str: string)
	{
		//return escape(Calysto.Utility.Encoding.StringEncoder.EncodeUTF8(string)); // will not encode right slash in http://something
		return encodeURIComponent(Calysto.Utility.Encoding.Utf8CharsEncoder.EncodeUTF8(str)); // will encode right slash in http://something
	};

	export function UrlDecode(str: string)
	{
		//return Calysto.Utility.Encoding.StringEncoder.DecodeUTF8(unescape(string));
		return Calysto.Utility.Encoding.Utf8CharsEncoder.DecodeUTF8(decodeURIComponent(str));
	};

	export function HtmlEncodeSimple(html: string)
	{
		return html.replace(new RegExp("<", "g"), "&lt;").replace(new RegExp(">", "g"), "&gt;");
	};

	export function HtmlDecodeSimple(html: string)
	{
		return html.replace(new RegExp("&lt;", "g"), "<").replace(new RegExp("&gt;", "g"), ">");
	};

	//#region html encode & decode

	let map = {
		"&": "&amp;",
		"'": "&#39;",
		'"': "&quot;",
		"<": "&lt;",
		">": "&gt;",
		"\r": "&#13",
		"\n": "&#10",
	};

	let mapReStr;

	let reversedMap;
	let reversedReStr;

	export function HtmlEncode(html: string)
	{
		if (!html) return "";

		if (!mapReStr)
		{
			let arr1: any[] = [];
			for (let prop in map)
			{
				arr1.push("(" + RegExp.Escape(prop) + ")");
			}
			mapReStr = arr1.join("|");
		}

		return html.replace(new RegExp(mapReStr, 'g'), (a, b) =>
		{
			return map[a];
		});
	}

	export function HtmlDecode(html: string)
	{
		if (!html) return "";

		if (!reversedMap)
		{
			reversedMap = {};
			let arr1: any[] = [];
			for (let prop in map)
			{
				reversedMap[map[prop]] = prop;
				arr1.push("(" + RegExp.Escape(map[prop]) + ")");
			}
			reversedReStr = arr1.join("|");
		}

		return html.replace(new RegExp(reversedReStr, "g"), (a, b) =>
		{
			return reversedMap[a];
		});
	}

	export function StringToHtml(str: string, htmlEncode?: boolean)
	{
		if (String.IsNullOrEmpty(str))
		{
			return str;
		}
		else
		{
			str = str.ReplaceAll("\r\n", "\n").ReplaceAll("\r", "");
			if (htmlEncode)
			{
				return str.Split('\n').AsEnumerable().Select(row => HtmlEncode(row)).ToStringJoined("<br/>");
			}
			else
			{
				return str.ReplaceAll("\n", "<br/>");
			}
		}
	}

	//#endregion

	//#region JavaScript encode

	const escapeeChars = {
		"\b": '\\b',
		"\t": '\\t',
		"\n": '\\n',
		"\f": '\\f',
		"\r": '\\r',
		'"': '\\"',
		"\\": '\\\\'
	};

	export function JavaScriptStringEncode(str: string)
	{
		return str.replace(new RegExp('([\\\\\x00-\x1f\\"])', 'g'), (a, b) =>
		{
			var c = escapeeChars[b];
			if (c)
			{
				return c;
			}
			c = b.charCodeAt();
			return "\\u00" +
				Math.floor(c / 16).toString(16) +
				(c % 16).toString(16);
		});
	}

	//#endregion

	//#region JS & CSS minify

	/**
	 * Minify JS or CSS content.
	 * @param jscode content string
	 * @param kind default Full
	 */
	export function Minify(jscode: string, kind: "Comments" | "Full" = "Full")
	{
		//remove /* */ comments
		// obavezno [\\w\\W], ne .*? jer tocka nece selektirati neke unicode charove
		jscode = new Regex(Regex.Escape("/*") + "[\\w\\W]*?" + Regex.Escape("*/")).Replace(jscode, " ");

		if (kind == "Full")
		{
			// remove any space including tab, new line, space...
			jscode = new Regex("[\\s]+").Replace(jscode, " ");

			// remove space near to symbols // don't use it, it breaks css, must have space between css class names, e.g.: solid 1px red, :nth-child(1) :first-child, itd.
			//jscode = Regex.Replace(jscode, @"[ ]*([\;\{\}\[\]\(\)\:\,\=\-\+\*\/\<\>]+)[ ]*", "$1");

			jscode = new Regex(`[ ]*([\\;\\{\\}\\,]+)[ ]*`).Replace(jscode, "$1"); // tested, ok, don't use : because of: :nth-child(1) :first-child

			let re2 = new RegExp(`\\{[^\\}]+\\}`, "ig");

			let re3 = new RegExp(`[ ]*([\\:])[ ]*`, "ig");

			jscode = jscode.replace(re2, substr =>
			{
				return substr.replace(re3, ":");
			});

			return jscode.TrimStart();
		}

		return jscode;
	}

	//#endregion

}
