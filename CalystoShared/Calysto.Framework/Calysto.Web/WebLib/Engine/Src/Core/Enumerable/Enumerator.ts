namespace Calysto
{
	export interface ICalystoEnumerable<TElement>
	{
		GetEnumerator(): CalystoEnumerator<TElement>;
	}

	export class CalystoEnumerator<TElement>
	{
		constructor(private fnYieldNext: (refYield: BoxValue<TElement>) => boolean)
		{
		}

		private current: TElement;

		public YieldNext(refYield: BoxValue<TElement>): boolean
		{
			if (this.fnYieldNext(refYield))
			{
				this.current = refYield.GetValue();
				return true;
			}
			return false;
		};

		public GetNext()
		{
			let box = new BoxValue<TElement>();
			this.YieldNext(box);
			return box;
		}

		public MoveNext(): boolean
		{
			return this.YieldNext(new BoxValue<TElement>());
		};

		public get Current(): TElement
		{
			return this.current;
		};

		public static FromYieldFunc<TElement>(fnYieldNext: (refYield: BoxValue<TElement>) => boolean) //: CalystoEnumerator<TElement>
		{
			if (fnYieldNext /*as (refYield: BoxValue<TElement>) => boolean*/ && Calysto.Type.TypeInspector.IsFunction(fnYieldNext))
			{
				return new CalystoEnumerator(fnYieldNext as (refYield: BoxValue<TElement>) => boolean);
			}
			throw new Error("CalystoEnumerator can not be created from fnYieldNext: " + fnYieldNext);
		}

		/**
		* From generator, function* (){ yield value; } with yield inside.
		* @param generatorFunc
	    */
		public static From<TElement>(generatorFunc: () => IterableIterator<TElement>): CalystoEnumerator<TElement>;

		public static From<TElement>(getEnumerator: () => CalystoEnumerator<TElement>): CalystoEnumerator<TElement>

		public static From<TElement>(iterator: Iterator<TElement>): CalystoEnumerator<TElement>;

		public static From<TElement>(iterableIterator: IterableIterator<TElement>): CalystoEnumerator<TElement>;

		public static From<TElement>(array: TElement[]): CalystoEnumerator<TElement>;

		public static From<TElement>(enumerable: ICalystoEnumerable<TElement>): CalystoEnumerator<TElement>

		public static From<TElement>(enumerable: CalystoEnumerable<TElement>): CalystoEnumerator<TElement>

		public static From<TElement>(enumerator: CalystoEnumerator<TElement>): CalystoEnumerator<TElement>

		public static From(source: string): CalystoEnumerator<string>;

		public static From<TElement>(
			source:
				ICalystoEnumerable<TElement>
				| CalystoEnumerable<TElement>
				| TElement[]
				| (() => CalystoEnumerator<TElement>)
				| Iterator<TElement>
				| IterableIterator<TElement>
				| CalystoEnumerator<TElement>
				| (() => IterableIterator<TElement>)
				| string
		): CalystoEnumerator<TElement> | CalystoEnumerator<string>
		{
			if (source)
			{
				if (typeof source == "string")
				{
					return FromString(source as string);
				}
				else if (((<any>source)?.GetEnumerator?.apply) && "GetEnumerator" in source)
				{
					// source is ICalystoEnumerable<TElement>
					return source.GetEnumerator();
				}
				else if ((<any>source)?.YieldNext?.apply && (<any>source)?.MoveNext?.apply && "Current" in source)
				{
					// source is CalystoEnumerator
					return source;
				}
				else if (Calysto.Type.TypeInspector.IsArrayOrDomArray(source))
				{
					// source is TElement[]
					return FromArray(source as TElement[]);
				}
				else if ((<any>source)?.next?.apply?.apply)
				{
					// source is Iterator<TElement>
					// if "return" in source && "throw" in source then source is IterableIterator<TElement>
					// Chrome Iterator has next, without return or throw, e.g. new FormData().next(), but no return and no throw props
					return FromIterableIterator(source as (Iterator<TElement>));
				}
				else if (typeof source == "function")
				{
					if ((<any>source)?.prototype?.next?.apply?.apply)
					{
						// generator function: function*(){yield value;}
						return FromGeneratorFunc(source as (() => IterableIterator<TElement>));
					}

					// if it is TypeScript generated generator for ES5, we have to invoke the function
					// because function*(){} when translated to ES5, doesn't have prototype with next(), return() or throw()
					// invoking the function returns object which has next(), return() and throw() which mimics IterableIterator<TElement>
					let gen1 = <any> source();
					if (gen1?.next?.apply?.apply)
					{
						return FromIterableIterator(<Iterator<TElement>>gen1);
					}
					else if (gen1?.YieldNext?.apply && gen1?.MoveNext?.apply && "Current" in gen1)
					{
						// source is CalystoEnumerator
						return <CalystoEnumerator<TElement>> gen1;
					}
				}

			}
			throw new Error("CalystoEnumerator can not be created from source: " + source);
		}
	};

	function FromArray<TElement>(source: TElement[])
	{
		var index = -1;
		return new CalystoEnumerator((refYield: BoxValue<TElement>): boolean =>
		{
			if ((<TElement[]>source).length > 0 && ++index < (<TElement[]>source).length)
			{
				refYield.SetValue(source[index]);
				return true;
			}
			return false;
		});
	}

	function FromIterableIterator<TElement>(source: (Iterator<TElement>) | (IterableIterator<TElement>))
	{
		let res1: IteratorResult<TElement>;
		return new CalystoEnumerator((refYield: BoxValue<TElement>): boolean =>
		{
			res1 = source.next();
			if (res1 && !res1.done)
			{
				refYield.SetValue(res1.value);
				return true;
			}
			return false;
		});
	}

	/**
		* From generator, function* (){ yield value; } with yield inside.
		* @param fn
		*/
	function FromGeneratorFunc<TElement>(fn: () => IterableIterator<TElement>)
	{
		let res1: IteratorResult<TElement>;
		let source: IterableIterator<TElement>;

		return new CalystoEnumerator((refYield: BoxValue<TElement>): boolean =>
		{
			if (!source)
				source = fn();

			res1 = source.next();

			if (res1 && !res1.done)
			{
				refYield.SetValue(res1.value);
				return true;
			}
			return false;
		});
}

	/**
		* From string, distinction from lambda as string.
		* Returns chars enumerable
		* @param source
		*/
	function FromString(source: string): CalystoEnumerator<string>
	{
		if (source as string && Calysto.Type.TypeInspector.IsString(source))
		{
			var index = -1;
			return new CalystoEnumerator((refYield: BoxValue<string>): boolean =>
			{
				if (source.length > 0 && ++index < source.length)
				{
					refYield.SetValue(source.charAt(index));
					return true;
				}
				return false;
			});
		}

		throw new Error("CalystoEnumerator can not be created from source: " + source);
	}
}

