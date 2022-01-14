namespace Calysto
{
	type TQueryItem = { lowerName: string, name: string, value: string };

	export class QueryString
	{
		/**
		 * Create new instance from url if provided
		 * @param url if provided, parse url
		 */
		constructor(private urlStr?: string)
		{
			this.items = [];
			if (urlStr) this.ParseImpl(urlStr);
		}

		private items: TQueryItem[];

		private uri: Calysto.Uri;

		public GetInnerUri ()
		{
			return this.uri || (this.uri = new Calysto.Uri());
		};

		/**
		 * Query string prefixed with question
		 */
		public GetQuery()
		{
			/// <summary>
			/// Query string prefixed with question
			/// </summary>

			var arr = new Array();

			for (var n = 0; n < this.items.length; n++)
			{
				var item = this.items[n];
				arr.push(encodeURIComponent(item.name) + "=" + encodeURIComponent(item.value));
			}
			return arr.length > 0 ? ("?" + arr.join("&")) : "";
		};

		public GetUrl ()
		{
			this.uri = this.uri || new Calysto.Uri();
			this.uri.Query = this.GetQuery();
			return this.uri.GetAbsoluteUri();
		}


		public Clear()
		{
			///<summary>remove query string items</summary>
			this.items = [];
		}

		private FindItem(name: string, caseSensitive: boolean = false)
		{
			/// <summary>
			/// Case non-sensitive search.
			/// </summary>
			/// <param name="name"></param>

			if (caseSensitive)
			{
				return this.items.AsEnumerable().Where(o => o.name == name).FirstOrDefault();
			}
			else
			{
				var lower = name.toLowerCase();
				return this.items.AsEnumerable().Where(o => o.lowerName == lower).FirstOrDefault();
			}
		}

		/**
		 * case non-sensitive name search and add or update if exists
		 * @param name
		 * @param value
		 */
		public SetValue(name: string, value: string | any)
		{
			///<summary>case non-sensitive name search and add or update if exists</summary>

			if (name)
			{
				var item: TQueryItem = this.FindItem(name) as TQueryItem;
				var lower = name.toLowerCase();

				if (!item)
				{
					item = {
						lowerName: lower,
						name: name,
						value: Calysto.Type.TypeInspector.IsNullOrUndefined(value) ? "" : (value + "")
					};
					this.items.push(item);
				}
				else
				{
					// update values
					item.lowerName = lower,
					item.name = name;
					item.value = Calysto.Type.TypeInspector.IsNullOrUndefined(value) ? "" : (value + "")
				}
			}
			return this;
		}

		/**
		 * case non-sensitive name search and remove
		 * @param name
		 */
		public RemoveValue(name: string)
		{
			///<summary>case non-sensitive name search and remove</summary>

			if (name)
			{
				var lower = name.toLowerCase();
				this.items = this.items.AsEnumerable().Where(o => o.lowerName != lower).ToArray()
			}
			return this;
		}

		/**
		 * case non-sensitve name search
		 * @param name
		 */
		public GetValue(name: string)
		{
			///<summary>case non-sensitve name search</summary>
			var item: TQueryItem = this.FindItem(name) as TQueryItem;
			if (item) return item.value;
			return null;
		}

		/**
		 * Extract query part from url and parse it
		 * @param url
		 */
		private ParseImpl(url: string)
		{
			/// <summary>
			/// Extract query part from url and parse it.
			/// </summary>
			/// <param name="url" type="String"></param>

			// accept:
			// 1. /path.aspx?d=43&gg=22#fg
			// 2. d=34&bb=534
			// 3. ?d=gg&dt=443

			this.uri = new Calysto.Uri(url);
			var qstr = (this.uri.Query || "").Trim(['?']);

			if (qstr)
			{
				// extract query string only

				var pairsArr = qstr.split("&");
				for (var n = 0; n < pairsArr.length; n++)
				{
					var pair = pairsArr[n].split('=');
					var name = decodeURIComponent(pair[0]);
					var value = decodeURIComponent(pair[1]);
					this.SetValue(name, value);
				}

			}
			return this;
		}
	}
}

