namespace Calysto.Web.UI.Direct
{
	export enum Kind
	{
		/// <summary>
		/// black text
		/// </summary>
		//[StringValue("black")]
		Message,
		/// <summary>
		/// red text
		/// </summary>
		//[StringValue("red")]
		Error,
		/// <summary>
		/// orange text
		/// </summary>
		//[StringValue("orange")]
		Warning,
		/// <summary>
		/// green text
		/// </summary>
		//[StringValue("green")]
		Success,
		/// <summary>
		/// blue tekst
		/// </summary>
		//[StringValue("blue")]
		Info
	}

	function GetKindColor(kind: keyof typeof Kind)
	{
		switch (kind)
		{
			case "Message": return "black";
			case "Error": return "red";
			case "Warning": return "orange";
			case "Success": return "green";
			case "Info": return "blue";
			default: return "black";
		}
	}

	export class CalystoHtmlBuilder
	{
		private _messages: Calysto.KeyValue<keyof typeof Kind, string>[] = [];

		public AddMessage(kind: keyof typeof Kind, text: string)
		{
			this._messages.Add(new Calysto.KeyValue(kind, text));
			return this;
		}

		private GetMessagesTags()
		{
			let _this11 = this;
			let fn1 = function* ()
			{
				for (var item of _this11._messages)
				{
					let color = GetKindColor(item.Key);
					yield `<div class="calysto-html-builder-message-${color}" style="color:${color}">${Calysto.Utility.Html.HtmlEncode(item.Value)}</div>`;
				}
			}
			return new Calysto.CalystoEnumerable(() => Calysto.CalystoEnumerator.From(fn1));
		}

		private GetHtmlElements()
		{
			return this.GetMessagesTags();
		}

		public HasElements() { return this.GetHtmlElements().Any(); }

		/**
		 * Create parentTag element and add items as children.
		 * @param parentTag
		 * @param parentClass
		 */
		public ToHtml()
		{
			return this.GetHtmlElements().ToStringJoined();
		}
	}
}
