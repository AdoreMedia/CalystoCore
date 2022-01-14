/// <reference path="Json.Infrastructure.ts" />
namespace Calysto.Json.Infrastructure
{
	export class CalystoJsonReader
	{
		// JsonReader used if window.JSON is not supported in browser
		constructor(private json: string, private blobsArray?: Blob[])
		{
		}

		private index: number = -1;   // The index of the current character
		private currchar: string; // / The current character
		private escapee = escapeeChars;

		private Error(m)
		{
			// must use throw to stop execution, otherwise, it would throw at least 2 exceptions
			throw new Error("JSON Error: " + m + ", position: " + this.index + ", json: " + this.json);
		}

		private Next(c1?: string)
		{
			// If a c parameter is provided, verify that it matches the current character.
			if (c1 && c1 !== this.currchar)
			{
				this.Error("Expected '" + c1 + "' instead of '" + this.currchar + "'");
			}
			// Get the next character. When there are no more characters,
			// return the empty string.
			this.currchar = this.json.charAt(this.index);
			this.index++;
			return this.currchar;
		}

		private Number()
		{
			// Parse a number value.
			let str1 = "";

			if (this.currchar == "-")
			{
				str1 = "-";
				this.Next("-");
			}
			while (this.currchar >= "0" && this.currchar <= "9")
			{
				str1 += this.currchar;
				this.Next();
			}
			if (this.currchar == ".")
			{
				str1 += ".";
				while (this.Next() && this.currchar >= "0" && this.currchar <= "9")
				{
					str1 += this.currchar;
				}
			}

			if ((this.currchar == "e") || (this.currchar == "E"))
			{
				str1 += this.currchar;
				this.Next();
				if (<string>this.currchar == <string>"-" || <string>this.currchar == <string>"+")
				{
					str1 += this.currchar;
					this.Next();
				}
				while (this.currchar >= "0" && this.currchar <= "9")
				{
					str1 += this.currchar;
					this.Next();
				}
			}

			let value = (+(str1)); /// parse string into number
			if (!isFinite(value))
			{
				this.Error("Bad number");
				return null;
			}
			else
			{
				return value;
			}
		}

		private String()
		{
			// Parse a string value.
			var hex;
			var i;
			var value = "";
			var uffff;
			// When parsing for string values, we must look for " and \ characters.
			if (this.currchar == "\"")
			{
				while (this.Next())
				{
					if (this.currchar == "\"")
					{
						this.Next();
						return value;
					}

					if (this.currchar == "\\")
					{
						this.Next();
						if (<string>this.currchar == <string>"u")
						{
							uffff = 0;
							for (i = 0; i < 4; i += 1)
							{
								hex = parseInt(this.Next(), 16);
								if (!isFinite(hex))
								{
									break;
								}
								uffff = uffff * 16 + hex;
							}
							value += String.fromCharCode(uffff);
						}
						else if (this.currchar && typeof this.escapee[this.currchar] == "string")
						{
							value += this.escapee[this.currchar];
						} else
						{
							break;
						}
					} else
					{
						value += this.currchar;
					}
				}
			}
			this.Error("Bad string");
			return;
		}

		private White()
		{
			// Skip whitespace.
			while (this.currchar && this.currchar <= " ")
			{
				this.Next();
			}
		}

		private Word()
		{
			// true, false, or null.
			switch (this.currchar)
			{
				case "t":
					this.Next("t");
					this.Next("r");
					this.Next("u");
					this.Next("e");
					return true;
				case "f":
					this.Next("f");
					this.Next("a");
					this.Next("l");
					this.Next("s");
					this.Next("e");
					return false;
				case "n":
					this.Next("n");
					this.Next("u");
					this.Next("l");
					this.Next("l");
					return null;
			}
			this.Error("Unexpected '" + this.currchar + "'");
			return;
		}

		private Array()
		{
			// Parse an array value.
			let arr: any[] = [];

			if (this.currchar == <string>'[')
			{
				this.Next("[");
				this.White();
				if (this.currchar == <string>"]")
				{
					this.Next("]");
					return arr;   // empty array
				}
				while (this.currchar)
				{
					arr.push(this.Value());
					this.White();
					if (this.currchar == <string>"]")
					{
						this.Next("]");
						return arr;
					}
					this.Next(",");
					this.White();
				}
			}
			this.Error("Bad array");
			return;
		}

		private Object()
		{
			// Parse an object value.
			var key;
			var obj = {};

			if (this.currchar == "{")
			{
				this.Next("{");
				this.White();
				if (this.currchar == <string>"}")
				{
					this.Next("}");
					return obj;   // empty object
				}
				while (this.currchar)
				{
					key = this.String();
					this.White();
					this.Next(":");
					if (Object.hasOwnProperty.call(obj, key))
					{
						this.Error("Duplicate key '" + key + "'");
					}
					obj[key] = this.Value();
					this.White();
					if (this.currchar == <string>"}")
					{
						this.Next("}");
						return obj;
					}
					this.Next(",");
					this.White();
				}
			}
			this.Error("Bad object");
			return;
		}

		private Value()
		{
			// Parse a JSON value. It could be an object, an array, a string, a number,
			// or a word.
			this.White();
			switch (this.currchar)
			{
				case "{":
					{
						var obj1 = this.Object();
						// run object conveter for Calysto objects
						obj1 = fnJsonPostConvertObj2(<IJsonItem>obj1, this.blobsArray);
						return obj1;
					}
				case "[":
					return this.Array();
				case "\"":
					return this.String();
				case "-":
					return this.Number();
				default:
					return (this.currchar >= "0" && this.currchar <= "9")
						? this.Number()
						: this.Word();
			}
		}

		public Parse()
		{
			var result;
			this.index = 0;
			this.currchar = " ";
			result = this.Value();
			this.White();
			if (this.currchar)
			{
				this.Error("Syntax error");
			}
			return result;
		}
	}
}
