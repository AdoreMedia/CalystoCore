namespace Calysto
{
	export class SelectorReader
	{
		constructor(private selector: string)
		{
			this.currPosition = 0;
		}

		private currPosition: number;

		public Peek(forwardBy = 0)
		{
			/// <summary>
			/// Peek next char.
			/// </summary>
			/// <param name="forwardBy" optional="true">default:0 (first available on stack)</param>

			return this.selector.charAt(this.currPosition + (forwardBy || 0));
		}

		public Pop()
		{
			/// <summary>
			/// Pop first available value, than advance index + 1.
			/// </summary>
			return this.selector.charAt(this.currPosition++);
		}

		public PopMatch(regex: RegExp, origin = 0)
		{
			/// <summary>
			/// Match from (first + origin) position, if match found, advance index by (match length + origin) and return match.
			/// If match is not found, return undefined and don't advance current position index.
			/// </summary>
			/// <param name="regex"></param>
			/// <param name="origin" optional="true">default: 0</param>
			origin = origin || 0;
			var mm = (this.selector.substr(this.currPosition + origin) || "").match(regex);
			if (mm && mm[0])
			{
				this.currPosition += mm[0].length + origin;
				return mm;
			}
			// return undefined
			return null;
		}
	}
}