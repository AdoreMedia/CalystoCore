namespace Calysto
{
	let _css1 = `
.calystoConsole {
	position:fixed;
	top:0;
	left:0;
	width:400px;
	height:100px;
	overflow:auto;
	border:solid 1px black;
	background:#f3f37a;
	color:black;
	font-size:11px;
	z-index:1000000;
}

.calystoConsole * {
	font-size:inherit;
}
`;

	let _cssAdded = false;

	function EnsureCssAdded()
	{
		if (_cssAdded) return;
		_cssAdded = true;

		Calysto.ScriptLoader.LoadCSS(Calysto.Utility.Html.Minify(_css1));
	}


	export class Console
	{
		private _consoleDiv: HTMLElement;

		/** default: 1000 */
		public LineMaxLength = 1000;

		private EnsureCreated()
		{
			// ovo smije raditi samo u debugu, ni slucajno ne smije raditi u releaseu da ne pocnu skakati konzole

			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
    			if (this._consoleDiv)
					return;

				EnsureCssAdded();

				let div1 = document.createElement("div");
				div1.innerHTML = "<div class='calystoConsole'></div>"
				this._consoleDiv = <any>div1.childNodes[0];
				document.body.appendChild(this._consoleDiv);
			}
			//#endif
		}

		public ApplyStyle(style: string)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				this.EnsureCreated();
				$$calysto(this._consoleDiv).ApplyStyle(style);
			}
			//#endif			
		}

		private ConverToString(txt: any)
		{
			if (typeof (txt) == "string")
				return txt;
			else if (txt === undefined)
				return "undefined";
			else if (txt === null)
				return "null";
			else if (txt == NaN)
				return "NaN";
			else if (typeof (txt) == "function")
				return txt + "";
			else
				return JSON.stringify(txt);
		}

		public WriteLine(txt: any)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				this.EnsureCreated();
				let str1 = this.ConverToString(txt);

				if (str1.length > this.LineMaxLength)
					str1 = str1.substr(0, this.LineMaxLength) + "...[truncated]";

				$$calysto(this._consoleDiv).AddChildren(Calysto.DomQuery.CreateElement("div").AddChildren(str1));
				this._consoleDiv.scrollTop = this._consoleDiv.scrollHeight;
			}
			//#endif
		}

		/** Clear console content */
		public Clear()
		{
			if (this._consoleDiv)
				this._consoleDiv.innerHTML = "";
		}

		/** Remove console from DOM */
		public Destroy()
		{
			if (this._consoleDiv)
			{
				$$calysto(this._consoleDiv).RemoveFromDom();
				this._consoleDiv = <any>null;
			}
		}

		public constructor()
		{
		}

		public static readonly Current = new Console();

	}
}

