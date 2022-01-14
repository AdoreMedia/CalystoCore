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

interface RegExpConstructor
{
	/**
	 * Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) and return string with escaped chars.
	 * @param {string} str
	 */
	Escape(str:string): string;
}

if (!RegExp.Escape)
{
	(function ()
	{
		var reEscape = new RegExp("[" + [" ", "\\\\", "\\*", "\\+", "\\?", "\\|", "\\,", "\\^", "\\$", "\\.", "\\#", "\\(", "\\)", "\\{", "\\}", "\\[", "\\]"].join("") + "]", "g");

		RegExp.Escape = function (str)
		{
			/// <summary>
			/// Escapes a minimal set of characters (\, *, +, ?, |, {, [, (,), ^, $,., #, and white space) and return string with escaped chars.
			/// </summary>
			/// <param name="str" type="String"></param>
			return str.replace(reEscape, "\\$&");
		};
	})();
}


