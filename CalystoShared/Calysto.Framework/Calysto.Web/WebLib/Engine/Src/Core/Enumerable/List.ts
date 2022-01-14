namespace Calysto
{
	function CreateArray<TElement>(source?: CalystoEnumerable<TElement> | TElement[])
	{
		if (!source)
			return [];
		else if (source.ToArray)
			return source.ToArray();
		else
			return CalystoEnumerable.From(source).ToArray();
	}

	export class List<TElement>
		extends CalystoEnumerable<TElement>
		implements IInnerArray<TElement>
	{
		private readonly array: TElement[] = [];

		public get InnerArray() { return this.array; }

		constructor(source?: CalystoEnumerable<TElement> | TElement[])
		{
			super(() => Calysto.CalystoEnumerator.From(this.array));

			if (typeof source == "string")
				throw new Error("List source can not be string"); // let's test if there is string sent from old code

			for (let item of CreateArray(source))
				this.array.push(item);
		}

		public Add(value: TElement)
		{
			this.array.push(value);
			return this;
		}

		public AddRange(arr: TElement[])
		{
			this.array.AddRange(arr);
			return this;
		}

		public Count()
		{
			return this.array.length;
		}

		public Any()
		{
			return this.array.length > 0;
		}

		public Insert(index: number, value: TElement)
		{
			this.array.splice(index, 0, value);
			return this;
		}

		public ElementAt(index: number, defaultValue?: TElement)
		{
			if (this.array.length > index) return this.array[index];
			else return defaultValue;
		}

		public Remove(value: TElement)
		{
			return this.RemoveAt(this.IndexOf(value));
		}

		public RemoveAt(index: number)
		{
			return this.RemoveRange(index, 1);
		}

		/**
		 * in-place splice
		 * @param {number} index
		 * @param {number} count?
		 * @returns
		 */
		public RemoveRange(index: number, count?: number)
		{
			if (index > 0 || index == 0)
			{
				this.array.splice(index, count || 1); // in-place splice
			}
			return this;
		}

		/**
		 * in place reverse
		 * @returns
		 */
		public Reverse()
		{
			this.array.reverse(); // in place reverse
			return this;
		}

		public IndexOf(value: TElement): number
		{
			return this.array.indexOf(value);
		}

		public Contains(value: TElement)
		{
			return this.IndexOf(value) >= 0;
		}

		public Clear()
		{
			this.array.splice(0, this.array.length);
			return this;
		}

		/**
		 * Returns new copy of inner array
		 * @returns
		 */
		public ToArray()
		{
			return this.array.slice(0);
		}

		/** create new instance of List from sliced inner array. */
		public ToList()
		{
			return new Calysto.List(this.array.slice(0));
		}

		public ToStringJoined(separator?: string)
		{
			return this.array.join(separator || "");
		}

		public ForEach(action: (item: TElement, index: number) => void)
		{
			if (typeof action == "string")
				action = <any>Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(action);

			Calysto.Collections.ForEach(this.array, <any>action);
			return this;
		}

		public FirstOrDefault(defaultValue?: TElement)
		{
			return this.array.length > 0 ? this.array[0] : defaultValue as TElement;
		}

		public First()
		{
			if (this.array?.length > 0)
				return this.array[0];
			else
				throw new Error("Error in First(), no items");
		}

		public LastOrDefault(defaultValue?: TElement)
		{
			return this.array.length > 0 ? this.array[this.array.length - 1] : defaultValue as TElement;
		}

		public Last()
		{
			if(this.array?.length > 0)
				return this.array[this.array.length - 1];
			else
				throw new Error("Error in Last(), no items");
		}

	}
}

