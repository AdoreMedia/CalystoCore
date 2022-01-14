/*
Modifier	Description
i		Perform case-insensitive matching
g		Perform a global match (find all matches rather than stopping after the first match)
m		Perform multiline matching

Expression	Description
[abc]	Find any character between the brackets
[^abc]	Find any character NOT between the brackets
[0-9]	Find any digit between the brackets
[^0-9]	Find any digit NOT between the brackets
(x|y)	Find any of the alternatives specified

Metacharacter	Description
.		Find a single character, except newline or line terminator
\w	Find a word character
\W	Find a non-word character
\d		Find a digit
\D		Find a non-digit character
\s		Find a whitespace character
\S		Find a non-whitespace character
\b		Find a match at the beginning/end of a word
\B		Find a match not at the beginning/end of a word
\0		Find a NUL character
\n		Find a new line character
\f		Find a form feed character
\r		Find a carriage return character
\t		Find a tab character
\v		Find a vertical tab character
\xxx		Find the character specified by an octal number xxx
\xdd		Find the character specified by a hexadecimal number dd
\uxxxx		Find the Unicode character specified by a hexadecimal number xxxx

Quantifier	Description
n+	Matches any string that contains at least one n
n*	Matches any string that contains zero or more occurrences of n
n?		Matches any string that contains zero or one occurrences of n
n{X}		Matches any string that contains a sequence of X n's
n{X,Y}	Matches any string that contains a sequence of X to Y n's
n{X,}	Matches any string that contains a sequence of at least X n's
n$	Matches any string with n at the end of it
^n	Matches any string with n at the beginning of it
?=n	Matches any string that is followed by a specific string n
?!n	Matches any string that is not followed by a specific string n
*/

namespace Calysto
{
	type Match = {
		/** true if match is successful, else false */
		Success: boolean,
		/** start position in original string */
		Index: number,
		/** length of match text */
		Length: number,
		/** complete match text value*/
		Value: string,
		/**Groups, 0 is complete match, 1,2,3... groups */
		Groups: RegExpMatchArray
	};

	export class Regex
	{
		/**
		 * Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) and return string with escaped chars.
		 * @param str
		 */
		public static Escape(str: string)
		{
			return RegExp.Escape(str);
		}

		private regexPattern: string;
		private ignoreCase = false;

		constructor(regexPattern: string, ignoreCase = false) 
		{
			this.regexPattern = regexPattern || "";
			this.ignoreCase = ignoreCase;
		}

		private CreateRegex(isGlobal = false)
		{
			return new RegExp(this.regexPattern, (this.ignoreCase ? "i" : "") + (isGlobal ? "g" : ""));
		}

		private CreateMatchSegment(currMatch: RegExpMatchArray | string, index?: number, success?: boolean)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="match" type="Match|String"></param>
			/// <param name="index" type="Int" optional="true"></param>
			/// <param name="success" type="bool" optional="true"></param>
			/// <returns type=""></returns>

			var matchArr: any[];

			if (typeof (currMatch) == "string")
			{
				matchArr = [currMatch];
				(<any>matchArr).index = index || 0;
				(<any>matchArr).success = !!success;
			}
			else
			{
				matchArr = currMatch;
			}

			var str = matchArr[0] || "";

			return <Match>({
				/**[boolean] true if match is successful, else false*/
				Success: !!(arguments.length > 2 ? success : str),
				/**[int] start position in original string*/
				Index: arguments.length > 1 ? index : matchArr ? (<any>matchArr).index : -1,
				/**[int] length of match text*/
				Length: str.length,
				/**[string] complete match text value*/
				Value: str,
				/**[string[]] Gropus*/
				Groups: matchArr
			});
		}

		/**
		 * Returns true if regex match is found
		 * @param {string} inputStr
		 * @returns
		 */
		public IsMatch(inputStr: string)
		{
			/// <summary>
			/// Returns true if regex match is found.
			/// </summary>
			/// <param name="inputStr"></param>
			/// <returns type="Boolean"></returns>
			return this.CreateRegex(false).test(inputStr);
		}

		/**
		 * Returns IEnumerable of matched items
		 * @param {string} inputStr
		 * @param {number} startIndex?
		 * @param {number} length?
		 * @returns
		 */
		public SelectMatches(inputStr: string, startIndex?:number, length?: number)
		{
			/// <summary>
			/// Returns IEnumerable of matched items.
			/// </summary>
			/// <param name="input" type="String"></param>
			/// <param name="startIndex" type="Int" optional="true"></param>

			return new Calysto.CalystoEnumerable(() =>
			{
				if (!!startIndex && startIndex > 0) inputStr = inputStr.substr(startIndex || 0);
				if (!!length && length > 0) inputStr = inputStr.substr(0, length || 0);

				// g flag returns all matches, without g flag, exec returns first match only
				// in while, always use g flag, without g flag, endless loop will occure
				var re = this.CreateRegex(true);
				var m;

				return Calysto.CalystoEnumerator.FromYieldFunc((refYield: BoxValue<Match>) =>
				{
					if ((m = re.exec(inputStr)) && m[0])
					{
						refYield.SetValue(this.CreateMatchSegment(m));
						return true;
					}
					return false;
				});
			});
		}

		/**
		 * Returns IEnumerable with matches and unmatches.
		 * @param {string} inputStr
		 * @param {number} startIndex?
		 * @param {number} length?
		 * @returns
		 */
		public SelectSegments(inputStr: string, startIndex?: number, length?: number)
		{
			/// <summary>
			/// Returns IEnumerable with matches and unmatches.
			/// </summary>
			/// <param name="input" type="String"></param>
			/// <param name="startIndex" type="Int" optional="true"></param>
			/// <param name="length" type="String" optional="true"></param>

			return new Calysto.CalystoEnumerable(() =>
			{
				if (!!startIndex && startIndex > 0) inputStr = inputStr.substr(startIndex || 0);
				if (!!length && length > 0) inputStr = inputStr.substr(0, length || 0);

				// g flag returns all matches, without g flag, exec returns first match only
				// in while, always use g flag, without g flag, endless loop will occure
				var re = this.CreateRegex(true);
				var m: RegExpExecArray | null;
				var startPosition = 0;
				var segment: string;
				var len = 0;
				var stack: Match[] = [];
				var match: Match;

				return Calysto.CalystoEnumerator.FromYieldFunc((refYield: BoxValue<Match>) =>
				{
					while (stack.length > 0)
					{
						refYield.SetValue(<Match>stack.shift());
						return true;
					}

					if (startPosition >= inputStr.length) return false;

					if ((m = re.exec(inputStr)) && m[0])
					{
						match = this.CreateMatchSegment(m);

						if (match.Index > startPosition)
						{
							segment = inputStr.substr(startPosition, match.Index - startPosition);
							len = segment.length;
							stack.push(this.CreateMatchSegment(segment, startPosition, false)); // this is un-match
							// new position:
							startPosition += len;
						}
						stack.push(match);
						// new position:
						startPosition = match.Index + match.Length;
					}

					while (stack.length > 0)
					{
						refYield.SetValue(<Match>stack.shift());
						return true;
					}

					// if there is something left
					segment = inputStr.substr(startPosition);
					len = segment.length;
					if (len > 0)
					{
						// something has left at the end
						stack.push(this.CreateMatchSegment(segment, startPosition, false));
						// new position:
						startPosition += len;
					}

					if (stack.length > 0)
					{
						refYield.SetValue(<Match>stack.shift());
						return true;
					}

					return false; // no more data
				});
			});
		}

		/**
		 * Returns all matches as array.
		 * @param {string} inputStr
		 * @param {number} startIndex?
		 * @param {number} length?
		 * @returns
		 */
		public Matches (inputStr: string, startIndex?: number, length?: number) : Match[]
		{
			/// <summary>
			/// Returns all matches as array.
			/// </summary>
			/// <param name="inputStr" type="string"></param>
			/// <param name="startIndex" type="int" optional="true"></param>
			/// <param name="length" type="int" optional="true"></param>

			return this.SelectMatches(inputStr, startIndex, length).ToArray();
		}

		/**
		 * Find and returns first match
		 * @param {string} inputStr
		 * @param {number} startIndex?
		 * @param {number} length?
		 * @returns
		 */
		public Match(inputStr: string, startIndex?: number, length?: number): Match | null
		{
			/// <summary>
			/// Find and returns first match.
			/// </summary>
			/// <param name="inputStr" type="string"></param>
			/// <param name="startIndex" type="int" optional="true"></param>
			/// <param name="length" type="int" optional="true"></param>

			/*
				new RegExp(...).exec(inputStr) with "g" flag returns all matches, without "g" flag, returns first match only
				match item is array with properties:
					0: "ante" // full match
					1: "te"		// first group
					2: "mb"		// second group
					index: 0	// position in inputStr
					input: "anteantefadsantefdsante" // inputStr
					length: 2	// items in this array
			*/

			var m1 = this.CreateRegex(false).exec(inputStr);
			return m1 ? this.CreateMatchSegment(m1) : null;
		}

		public Replace(input: string, replacement: string)
		{
			if (!input) return input;

			let re1 = this.CreateRegex(true);

			return input.replace(re1, replacement);
		}
	}
}

