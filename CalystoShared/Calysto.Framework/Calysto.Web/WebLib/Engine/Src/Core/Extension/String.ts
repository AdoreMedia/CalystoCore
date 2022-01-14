interface StringConstructor
{
	/**
	 * Returns true if any of strings is null or empty or undefined
	 * @param {string[]} ...args
	 */
	IsNullOrEmpty(...args: string[]): boolean;

	/**
	 * Returns true if any of strings is null or empty or white space only or undefined
	 * @param {string[]} ...args
	 */
	IsNullOrWhiteSpace(...args: string[]): boolean;
}

interface String
{
	ToCharArray(): string[];
    Equals(str2: string, ignoreCase?: boolean): boolean;
	Trim(charsArray?: string[]): string;
	TrimStart(charsArray?: string[]): string;
	TrimEnd(charsArray?: string[]): string;
	ToNullIfEmpty(trim?: boolean): string;
	EndsWith(secondStr: string, ignoreCase?: boolean): boolean;
	StartsWith(secondStr: string, ignoreCase?: boolean): boolean;
	Contains(secondStr: string, ignoreCase?: boolean): boolean;
	Substring(startIndex: number, length?: number): string;
	Remove(startIndex: number): string;
	Repeat(count: number): string;
	TakeFirst(count: number, elipsis?: string, wordSplit?: boolean): string;
	TakeLast(count: number, elipsis?: string, wordSplit?: boolean): string;
	Split(splitCharsArr: string | string[], ignoreCase?: boolean): string[];
	ReplaceAll(search: string, replacement: string, ignoreCase?: boolean): string;
	ToNumber(): number;
	ToFunc(noReturnCheck: boolean): Function;
	GetHashCode(): number;
	/** single brackets: replace {Name} with value from object with property {Name: "john"} or {User.Name} with value from {User:{Name:"john"}} */
	FormatWith(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
	/** double brackets: replace {{Name}} with value from object with property {Name: "john"} or {{User.Name}} with value from {User:{Name:"john"}} */
	FormatWith2(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
	/** triple brackets: replace {{{Name}}} with value from object with property {Name: "john"} or {{{User.Name}}} with value from {User:{Name:"john"}} */
	FormatWith3(obj: any, placeHolderStart?: string, placeHolderEnd?: string): string;
	AsEnumerable(): Calysto.CalystoEnumerable<string>;
	ToHtml(htmlEncode?:boolean): string;
}

//WARNING: overloaded string methods create this as object (IE < 9), must convert it to string because comparison with string won't work

(function ()
{
	var fnCreateRegexStr = function (strCharArray)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strCharArray" type="String|Array">string or string[] or char[]</param>
		
		if (typeof (strCharArray) == "string")
		{
			return RegExp.Escape(strCharArray);
		}
		else
		{
			var arr = new Array<String>();
			for (var n = 0; n < strCharArray.length; n++)
			{
				arr.push(RegExp.Escape(strCharArray[n]));
			}
			return arr.join("|");
		}
	};

	String.IsNullOrEmpty = function (str1, str2, str3, etc)
	{
		///<summary>
		/// Static.
		/// Returns true if any of strings is null or empty or undefined
		/// </summary>
		///<param name="str1" type="String"></param>
		if (arguments.length == 0) return true;
		for (var n = 0; n < arguments.length; n++)
		{
			var tt = arguments[n];
			var type = typeof (tt);
			// on IE when invoked from String.prototype.AnyFunction using this, this is object, not string
			if (tt && (type == "string" || type == "object") && tt.length > 0)
			{
				// valid string
			}
			else
			{
				// null or empty string
				return true;
			}
		}
		return false;
	};

	String.IsNullOrWhiteSpace = function (str1, str2, str3, etc)
	{
		///<summary>
		/// Static.
		/// Returns true if any of strings is null or empty or white space only or undefined
		/// </summary>
		///<param name="str1" type="String"></param>
		if (arguments.length == 0) return true;
		for (var n = 0; n < arguments.length; n++)
		{
			var tt = arguments[n];
			var type = typeof (tt);
			// on IE when invoked from String.prototype.AnyFunction using this, this is object, not string
			if (tt && (type == "string" || type == "object") && tt.length > 0 && !new RegExp("^[\\s]+$").test(tt))
			{
				// valid string
			}
			else
			{
				// null or empty or white space string
				return true;
			}
		}
		return false;
	};
		

	String.prototype.ToCharArray = function ()
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		var str = this + "";
		var arr: string[] = [];
		for (var n = 0; n < str.length; n++)
		{
			arr.push(str.charAt(n));
		}
		return arr;
	};

	String.prototype.Equals = function (string2, ignoreCase)
	{
		/// <summary>
		/// Compare two string.
		/// </summary>
		/// <param name="string1">this</param>
		/// <param name="string2"></param>
		/// <param name="ignoreCase">If not set, default is false.</param>
		/// <returns type=""></returns>

		var string1 = this + "";

		if (string1 === string2)
		{
			return true;
		}
		else if (ignoreCase)
		{
			if (string1) string1 = string1.toLowerCase();
			if (string2) string2 = string2.toLowerCase();
			return string1 === string2;
		}
		return false;
	};


	var trimDefault = "(" + fnCreateRegexStr([' ', '\r', '\n', '\t']) + ")+"; // default chars to trim

	function Trim(str, charsArray, trimStart, trimEnd)
	{
		/// <summary>
		/// Trim string.
		/// </summary>
		/// <param name="str">String to be trimmed.</param>
		/// <param name="charsArray">Chars array to trim. If not set, will use default chars.</param>
		/// <param name="trimStart">If true, trim start.</param>
		/// <param name="trimEnd">If true, trim end.</param>
		/// <returns type="">Trimmed string.</returns>

		if (!str)
		{
			return str;
		}

		var restr = trimDefault;

		if (charsArray)
		{
			restr = "(" + fnCreateRegexStr(charsArray) + ")+";
		}

		if (arguments.length < 4)
		{
			trimEnd = true;
		}

		if (arguments.length < 3)
		{
			trimStart = true;
		}

		if (trimEnd && trimStart)
		{
			restr = "(^" + restr + ")|(" + restr + "$)";
		}
		else if (trimEnd)
		{
			restr += "$";
		}
		else if (trimStart)
		{
			restr = "^" + restr;
		}

		return str.replace(new RegExp(restr, "g"), "");
	};

	String.prototype.Trim = function (charsArray)
	{
		/// <summary>
		/// Trim string.
		/// </summary>
		/// <param name="str" type="String">this. String to be trimmed.</param>
		/// <param name="charsArray" type="Array" optional="true">Chars array to trim. If not set, will trim all white space with regex \s</param>
		var str = this + "";
		if (charsArray)
		{
			return Trim(str, charsArray, true, true);
		}
		else
		{
			return str.replace(new RegExp("(^[\\s]+)|([\\s]+$)", "g"), "");
		}
	};

	String.prototype.TrimStart = function (charsArray)
	{
		/// <summary>
		/// Trim string.
		/// </summary>
		/// <param name="str" type="String">this. String to be trimmed.</param>
		/// <param name="charsArray" type="Array" optional="true">Chars array to trim. If not set, will trim all white space with regex \s</param>
		var str = this + "";
		if (charsArray)
		{
			return Trim(str, charsArray, true, false);
		}
		else
		{
			return str.replace(new RegExp("(^[\\s]+)", "g"), "");
		}
	};

	String.prototype.TrimEnd = function (charsArray)
	{
		/// <summary>
		/// Trim string.
		/// </summary>
		/// <param name="str" type="String">this. String to be trimmed.</param>
		/// <param name="charsArray" type="Array" optional="true">Chars array to trim. If not set, will trim all white space with regex \s</param>
		var str = this + "";
		if (charsArray)
		{
			return Trim(str, charsArray, false, true);
		}
		else
		{
			return str.replace(new RegExp("([\\s]+$)", "g"), "");
		}
	};

	String.prototype.EndsWith = function (secondStr, ignoreCase)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="type">this</param>
		/// <param name="secondStr" type="String"></param>
		/// <param name="ignoreCase" type="boolean" optional="true"></param>
			
		// must test lenght>0 because !!new String("") == true, so length has to be tested too
		var str = this + "";
		if (!str || !secondStr) return false;
		var re = new RegExp(fnCreateRegexStr(secondStr) + "$", ignoreCase ? "ig" : "g");
		return re.test(str);
	};

	String.prototype.StartsWith = function (secondStr, ignoreCase)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="type">this</param>
		/// <param name="secondStr" type="String"></param>
		/// <param name="ignoreCase" type="boolean" optional="true"></param>
			
		// must test lenght>0 because !!new String("") == true, so length has to be tested too
		var str = this + "";
		if (!str || !secondStr) return false;
		if (ignoreCase)
		{
			var re = new RegExp("^" + fnCreateRegexStr(secondStr), ignoreCase ? "ig" : "g");
			return re.test(str);
		}
		else
		{
			return str.indexOf(secondStr) == 0;
		}
	};

	String.prototype.Contains = function (secondStr, ignoreCase)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="type">this</param>
		/// <param name="secondStr" type="String"></param>
		/// <param name="ignoreCase" type="boolean" optional="true"></param>
			
		// must test length>0 because !!new String("") == true, so length has to be tested too
		var str = this + "";
		if (!str || !secondStr) return false;
		if (ignoreCase)
		{
			var re = new RegExp(fnCreateRegexStr(secondStr), ignoreCase ? "ig" : "g");
			return re.test(str);
		}
		else
		{
			var index = str.indexOf(secondStr);
			return index >= 0;
		}
	};

	String.prototype.Substring = function (startIndex, length)
	{
		var str = this + "";
		if (!str) { return str; } // null or ""
		var maxlen = str.length - startIndex;
		if ((length || 0) > maxlen)
		{
			return str.substr(startIndex); // take all, length is larger than rest of the string
		}
		else
		{
			return str.substr(startIndex, length);
		}
	};

	String.prototype.Remove = function (startIndex)
	{
		var str = this + "";
		if (str && str.length > 0 && startIndex >= 0)
		{
			return str.substr(0, startIndex);
		}
		else
		{
			return "";
		}
	};

	String.prototype.Repeat = function (count)
	{
		/// <summary>repeated str count times</summary>
		/// <param name="str" type="Number|String|Object">The str to be repeated.</param>
		/// <param name="count" type="Number">The number of times to repeat the str in the generated sequence.</param>
		var str = this + "";
		var arr:string[] = [];
		for (var n = 0; n < count; n++)
		{
			arr.push(str);
		}
		return (arr.join(""));
	};
		
	function TakeSplitByWords(str, maxLength, takeLast, elipsis)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="string"></param>
		/// <param name="maxLength" type="int"></param>
		/// <param name="takeLast" type="bool"></param>
		/// <param name="elipsis" type="string"></param>
			
		var maxTextLength = maxLength - (elipsis || "").length;
		var currentLength = 0;
		var list:string[] = [];
		var split;
		var re = new RegExp("([\\w]+)|([^\\w]+)", "ig"); // m[1] je word, m[2] je non-word
		var matches:string[] = [];
		var m;
		while((m = re.exec(str)))
		{
			matches.push(m);
		}
			
		if (takeLast)
		{
			matches.reverse(); // in-place reverse
		}

		for(var nn = 0; nn < matches.length; nn++)
		{
			m = matches[nn];
			currentLength += m[0].length;

			if (m[2]) // m[2] je split (non word)
			{
				// splitters are kept together, so we don't add tha splitter after the last word
				// there shouldn't be 2 splitters in a row, it is defined in regex
				split = (split || "") + m[0];
				continue;
			}
			else if (currentLength > maxTextLength)
			{
				break;
			}
			else
			{
				if (split)
				{
					list.push(split);
					split = null;
				}
				list.push(m[0]);
			}
		}

		if (elipsis)
		{
			list.push(elipsis);
		}

		if (takeLast)
		{
			list.reverse();
		}

		return list.join("");
	}

	String.prototype.TakeFirst = function (count, elipsis, wordSplit)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="string"></param>
		/// <param name="count" type="int"></param>
		/// <param name="wordSplit" type="bool">if true, split at word boundry</param>
		/// <param name="elipsis" type="string">eg. ...</param>
		var str = this + "";
		if (!str || count > str.length)
		{
			return str;
		}
		else if (wordSplit)
		{
			return TakeSplitByWords(str, count, false, elipsis);
		}
		else
		{
			return str.substr(0, count - (elipsis ? elipsis.length : 0)) + (elipsis || "");
		}
	};

	String.prototype.TakeLast = function (count, elipsis, wordSplit)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str" type="string"></param>
		/// <param name="count" type="int"></param>
		/// <param name="wordSplit" type="bool">if true, split at word boundry</param>
		/// <param name="elipsis" type="string">eg. ...</param>
		var str = this + "";
		if (!str || count > str.length)
		{
			return str;
		}
		else if (wordSplit)
		{
			return TakeSplitByWords(str, count, true, elipsis);
		}
		else
		{
			return (elipsis || "") + str.substr(str.length - count + (elipsis ? elipsis.length : 0), count);
		}
	};

	String.prototype.Split = function (splitCharsArr, ignoreCase)
	{
		/// <summary>
		/// Split by any char
		/// </summary>
		/// <param name="str" type="String"></param>
		/// <param name="splitCharsArr" type="String|StringArray|CharArray">String or Array of chars or strings used as splitter</param>
		/// <param name="ignoreCase" type="Boolean"></param>
		var str = this + "";
		if (!str) { return []; }
		return str.split(new RegExp(fnCreateRegexStr(splitCharsArr), ignoreCase ? "ig" : "g")); // switch "g" nema utjecaja
	};

	String.prototype.ReplaceAll = function (search, replacement, ignoreCase)
	{
		/// <summary>
		/// Replace all occurances of search text inside of str, using RegExp.
		/// </summary>
		/// <param name="str" type="String"></param>
		/// <param name="search" type="String|StringArray|CharArray">String or Array of chars or strings to be replaced</param>
		/// <param name="replacement" type="String"></param>
		/// <param name="ignoreCase" type="Boolean"></param>
		var str = this + "";
		if (!str) { return str; }
		var re = new RegExp(fnCreateRegexStr(search), ignoreCase ? "ig" : "g");
		return str.replace(re, replacement);
	};

	String.prototype.ToNumber = function ()
	{
		/// <summary>
		/// Convert to decimal number using current culture.
		/// </summary>
		/// <returns type=""></returns>
		return Calysto.Type.NumberConverter.ToDecimal(this + "");
	};

	String.prototype.ToFunc = function (noReturnCheck: boolean)
	{
		/// <summary>
		/// Convert lamba to function
		/// </summary>
		/// <returns type=""></returns>

		if (noReturnCheck)
		{
			return Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(this + "");
		}
		else
		{
			return Calysto.Utility.Expressions.CompileLambdaExpression(this + "");
		}
	};

	String.prototype.GetHashCode = function ()
	{
		var str = this + "";
		var hash = 0;
		for (var n = 0; n < (str||"").length; n++)
		{
			var ch = str.charCodeAt(n);
			hash = ((hash << 5) - hash) + ch;
		}
		return hash & hash; // Convert to 32bit integer
	};

	String.prototype.FormatWith = function (obj, placeHolderStart = "{", placeHolderEnd = "}")
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="str">input string with property names or array indexes: My name is {Name}, or My name is {0}</param>
		/// <param name="obj" type="Object|Array">object with properties {Name:Tom, Age:22, ...} or array["Tom", 22"...]</param>
		/// <param name="placeHolderStart" optional="true" type="String" default="{"></param>
		/// <param name="placeHolderEnd" optional="true" type="String">default }</param>

		var str = this + "";
		if (!obj)
		{
			return str;
		}

		return str.replace(new RegExp("(" + RegExp.Escape(placeHolderStart || "{") + "([\\w_\\-\\.]+)" + RegExp.Escape(placeHolderEnd || "}") + ")", "g"), function (all, g1, g2, index, allStr)
		{
			var val = Calysto.DataBinder.GetValue<string>(obj, g2);
			if (val == undefined)
			{
				throw new Error("Exception in String.FormatWith(), " + g1 + " property not found.");
			}
			return val;
		});
	};

	String.prototype.FormatWith2 = function (obj, placeHolderStart = "{{", placeHolderEnd = "}}")
	{
		return (this + "").FormatWith(obj, placeHolderStart, placeHolderEnd);
	};

	String.prototype.FormatWith3 = function (obj, placeHolderStart = "{{{", placeHolderEnd = "}}}")
	{
		return (this + "").FormatWith(obj, placeHolderStart, placeHolderEnd);
	};

	String.prototype.AsEnumerable = function ()
	{
        return new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.From(this + ""));
	};

	String.prototype.ToHtml = function (htmlEncode)
	{
		return Calysto.Utility.Html.StringToHtml(this + "", htmlEncode);
	};

	String.prototype.ToNullIfEmpty = function (trim?: boolean)
	{
		let s1 = this + "";
		if (trim) s1 = s1.Trim();

		if (String.IsNullOrWhiteSpace(s1))
			return <string><any> null;
		else
			return s1;
	};

})();
