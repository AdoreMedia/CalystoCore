namespace Calysto
{
	export class CalystoEnumerable<TItem>
	{
		public constructor(getEnumerator: () => CalystoEnumerator<TItem>)
		{
			if (typeof getEnumerator != "function")
				throw new Error("GetEnumerator is not function");

			this._getEnumerator = getEnumerator;
		}

		protected _getEnumerator: () => CalystoEnumerator<TItem>;

		public GetEnumerator()
		{
			if (this._getEnumerator)
				return this._getEnumerator();
			else
				throw new Error("GetEnumerator is not defined");
		}

		public AsEnumerable()
		{
			return this;
		}

		public AsIterableIterator()
		{
			let context1 = this;
			let box1 = new BoxValue<TItem>();
			let aa = function* ()
			{
				let en1 = context1.GetEnumerator();
				while (en1.YieldNext(box1))
				{
					yield en1.Current;
				}
			};
			return aa();
		}

		public ToArray()//: TItem[]
		{
			var arr: TItem[] = [];
			var en1 = this.GetEnumerator();
			var refOut = new BoxValue<TItem>();
			while (en1.YieldNext(refOut) && refOut.HasValue())
			{
				arr.push(refOut.GetValue());
				refOut.RemoveValue();
			}
			return arr;
		}

		/**
		 * Create new DOM enumerable query without converting to array first.
		 * @returns
		 */
		public AsDomQuery()
		{
			return new DomQuery(() => this.GetEnumerator());
		}

		public ToList()
		{
			return new List(this.ToArray());
		}

		//public ToArrayList(): ArrayList<TItem>
		//{
		//	return new ArrayList(this.ToArray());
		//}

		public Count()
		{
			return this.ToArray().length;
		}

		public ToDictionary<TKey>(keySelector: (item: TItem) => TKey): Dictionary<TKey, TItem>;

		public ToDictionary<TKey, TValue>(keySelector: (item: TItem) => TKey, valueSelector: (item: TItem) => TValue): Dictionary<TKey, TValue>;

		public ToDictionary<TKey, TValue>(keySelector, valueSelector?): Dictionary<TKey, TValue>
		{
			if (typeof keySelector != "function") keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);
			if (typeof valueSelector != "function") valueSelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(valueSelector);

			var dic2 = new Calysto.Dictionary<TKey, TValue>();
			this.ForEach((item, index) => dic2.Add(keySelector(item), (<Function>valueSelector)(item)));
			return dic2;
		}


		/**
		 * Create {key: value, key1: value1}... If keys are not unique, will be overwriten.
		 * @param keySelector
		 */
		public ToRawObject<TKey>(keySelector: (item: TItem) => TKey): { [P: string]: TItem };

		/**
		 * Create {key: value, key1: value1}... If keys are not unique, will be overwriten.
		 * @param keySelector
		 * @param valueSelector
		 */
		public ToRawObject<TKey, TValue>(keySelector: (item: TItem) => TKey, valueSelector: (item: TItem) => TValue): { [P: string]: TValue };

		public ToRawObject<TKey, TValue>(keySelector, valueSelector?): { [P: string]: TValue }
		{
			/// <summary>
			/// Create {key: value, key1: value1}... If keys are not unique, will be overwriten.
			/// </summary>
			/// <param name="keySelector" type="Function|Lambda">function(item, index){....}</param>
			/// <param name="valueSelector" optional="true" type="Function|Lambda">function(item, index){...}</param>

			if (typeof keySelector != "function") keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);
			if (typeof valueSelector != "function") valueSelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(valueSelector);

			var dic = {};
			// key has to be string, e.g. for(var prop in {}), prop is string
			// dic[1] = "test"; dic[1] returns "test", but dic["1"] returns test too, which means than key is converted into string by the JS itselft
			this.ForEach((item, index) => dic[keySelector(item) + ""] = (<Function>valueSelector)(item));
			return dic;
		}

		public ToStringJoined(separator?: string)
		{
			var arr = this.ToArray();
			return arr.join(separator || "");
		}

		/**
		 * Run foreach and return new enumerable
		 * @param action
		 */
		public ForEach(action: (item: TItem, index: number) => void)
		{
			if (typeof (action) == "string")
				action = <any>Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(action);

			var arr = this.ToArray();
			for (var n = 0; n < arr.length; n++)
			{
				(<Function>action)(arr[n], n);
			}

			return CalystoEnumerable.From(arr);
		}

		public Skip(count: number)
		{
			return CalystoEnumerable.From(() => function* (__this)
			{
				let currindex = -1;
				for (let item of __this.AsIterableIterator())
				{
					if (++currindex < count)
						continue;
					else
						yield item;
				}
			}(this));
		}

		public Take(count: number)
		{
			return CalystoEnumerable.From(() => function* (__this)
			{
				let currindex = -1;
				for (let item of __this.AsIterableIterator())
				{
					if (++currindex < count)
						yield item;
					else
						break;
				}
			}(this));
		}

		public Single()
		{
			var el = this.Take(2).ToArray();

			if (el.length == 1)
			{
				return el[0];
			}
			else if (el.length == 0)
			{
				throw new Error("Error in .Single(), sequence contains no elements");
			}
			else
			{
				throw new Error("Error in .Single(), sequence contains more than single element");
			}
		};

		/**
		 * Take exact count. If there is more or less items in source, throw exception.
		 * @param count
		 */
		public Exact(count: number)
		{
			if (!(count >= 0))
			{
				throw new Error("Exact(count) requires count parameter >= 0");
			}

			var arr = this.ToArray();

			if (arr.length != count)
			{
				throw new Error("Error in .Exact(), sequence contains " + arr.length + " elements. Required is " + count + " elements.");
			}

			return CalystoEnumerable.From(arr);
		}

		/**
		 * Computes the sum of numeric values the sequence.
		 * @param selector
		 */
		public Sum<TNew>(selector?: (item: TItem) => TNew)
		{
			var val: TNew = <any>null;
			this.Select(selector || (<TItem>(o) => o)).ForEach((o, n) =>
				{
					if (Calysto.Type.TypeInspector.IsNumber(o))
					{
						val = (<any>val || 0) + o;
					}
				});
			return val;
		};

		/**
		 * Computes average of non-null numeric values of the sequence: sum / count, count of numeric non-null values only.
		 * @param selector
		 */
		public Average<TNew>(selector?: (item: TItem) => TNew)
		{
			var val: TNew = <any>null;
			var count = 0;
			this.Select(selector || (<TItem>(o) => o)).ForEach((o, n) =>
				{
					if (Calysto.Type.TypeInspector.IsNumber(o))
					{
						val = (<any>val || 0) + o;
						count++;
					}
				});
			return count > 0 ? (<any>val / count) : 0;
		}

		/**
		 * Returns min value or null.
		 * @param selector
		 */
		public Min<TNew>(selector?: (item: TItem) => TNew)
		{
			var val: TNew = <any>null;
			this.Select(selector || (<TItem>(o) => o)).ForEach((o, n) =>
			{
				if (Calysto.Type.TypeInspector.IsNumber(o) || Calysto.Type.TypeInspector.IsDate(o))
				{
					if (val == null || o < val)
					{
						val = o;
					}
				}
			});
			return val;
		}

		/**
		 * Returns max value or null.
		 * @param selector
		 */
		public Max<TNew>(selector?: (item: TItem) => TNew)
		{
			var val: TNew = <any>null;
			this.Select(selector || (<TItem>(o) => o)).ForEach((o, n) =>
			{
				if (Calysto.Type.TypeInspector.IsNumber(o) || Calysto.Type.TypeInspector.IsDate(o))
				{
					if (val == null || o > val)
					{
						val = o;
					}
				}
			});
			return val;
		}

		/**
		 * Concatenates two sequences. (Is actually Idendical to the Array.concat method.)
		 * @param secondSource
		 */
		public Concat(secondSource: CalystoEnumerable<TItem>): CalystoEnumerable<TItem>;

		/**
		 * Concatenates two sequences. (Is actually Idendical to the Array.concat method.)
		 * @param secondSource
		 */
		public Concat(secondSource: TItem[]): CalystoEnumerable<TItem>;

		public Concat(secondSource: TItem[] | CalystoEnumerable<TItem>)
		{
			/// <summary>Concatenates two sequences. (Is actually Idendical to the Array.concat method.)</summary>
			/// <param name="soruce2">A Calysto.Linq or Array object that contains the elements to concatenate.</param>

			return CalystoEnumerable.From(() => function* (__this)
			{
				for (let item of __this.AsIterableIterator())
					yield item;

				for (let item of secondSource.AsEnumerable().AsIterableIterator())
					yield item;

			}(this));
		}

		/**
		 * Include items from first where predicate(item1, item2){....} returns true
		 * @param secondSource
		 * @param predicate
		 * @param excludeIntersection default: false
		 */
		public Intersect<TSecond>(
			secondSource: TSecond[] | CalystoEnumerable<TSecond>,
			predicate: (item1: TItem, item2: TSecond) => boolean,
			excludeIntersection = false)
		{
			/// <summary>Include items from first where predicate(item1, item2){....} returns true. Returns items from first source if predicate returns true.</summary>
			/// <param name="secondSource">The second Calysto.Linq element or array sequence to perform the Intersect on.</param>
			/// <param name="predicate">comparison function, lambda expression or function (item1, item2)=>....</param>
			/// <param name="excludeIntersection" optional="true">default: false</param>

			if (!secondSource || !predicate)
			{
				throw new Error("Intersect(secondSource, predicate) requires secondSource and predicate parameters");
			}

			var secondArr: TSecond[] = secondSource.ToArray();
			if (typeof predicate == "string") predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(predicate);
			// include item1 where exist item1.key == item2.key
			return this.Where(item1 => (!excludeIntersection) == secondArr.AsEnumerable().Where(item2 => (<Function>predicate)(item1, item2)).Any());
		}

		/**
		 * Exclude items from first where predicate(item1, item2){....} returns true
		 * @param secondSource
		 * @param predicate
		 */
		public Except<TSecond>(
			secondSource: TSecond[] | CalystoEnumerable<TSecond>,
			predicate: (item1: TItem, item2: TSecond) => boolean)
		{
			/// <summary>Exclude items from first sequence where predicate(item1, item2){....} returns true. Returns non excluded items from first source.</summary>
			/// <param name="secondSource">The second Calysto.Linq element or array sequence to perform the Intersect on.</param>
			/// <param name="predicate">comparison function, lambda expression or function (item1, item2)=>....</param>

			return this.Intersect(secondSource, predicate, true);
		};

		/**
		 * Join two sequences.
		 * @param innerSource
		 * @param outerKeySelector
		 * @param innerKeySelector
		 * @param resultSelector
		 */
		public Join<TInner, TKey, TResult>(
			innerSource: TInner[] | CalystoEnumerable<TInner>,
			outerKeySelector: (outer: TItem) => TKey,
			innerKeySelector: (inner: TInner) => TKey,
			resultSelector: (outer: TItem, inner: TInner) => TResult
		)
		{
			let innerDic = innerSource.AsEnumerable().ToDictionary(o => innerKeySelector(o));

			return this.Select(outer =>
			{
				let res1 = new BoxValue<TResult>();
				let innerRef = new BoxValue<TInner>();
				if (innerDic.TryGetValue(outerKeySelector(outer), innerRef))
				{
					res1.SetValue(resultSelector(outer, innerRef.GetValue()));
				}
				return res1;
			}).Where(o => o.HasValue()).Select(o => o.GetValue());
		}

		/**
		 * Returns elements from a sequence as long as predicate returns true
		 * @param predicate
		 */
		public TakeWhile(predicate: (item: TItem, index: number) => boolean)
		{
			///<summary>Returns elements from a sequence as long as predicate returns true</summary>
			/// <param name="predicate" type="String|Function">(item)=>... lambda expression or function predicate used to determine query matches.</param>

			if (!predicate)
				throw new Error("TakeWhile(predicate) requires predicate");

			if (typeof predicate != "function")
				predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(predicate);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let currindex = -1;
				for (let item of __this.AsIterableIterator())
				{
					if (!predicate(item, ++currindex))
						break;
					else
						yield item;
				}
			}(this));
		}

		/**
		 * Skip elements from a sequence as long as predicate returns true, elements after that are selected.
		 * @param predicate
		 */
		public SkipWhile(predicate: (item: TItem, index: number) => boolean)
		{
			///<summary>skip elements from a sequence as long as predicate returns true, elements after that are selected</summary>
			/// <param name="predicate" type="String|Function">(item)=>... lambda expression or function predicate used to determine query matches.</param>

			if (!predicate)
				throw new Error("SkipWhile(predicate) requires predicate");

			if (typeof predicate != "function")
				predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(predicate);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let takeRest = false;
				let currindex = -1;
				for (let item of __this.AsIterableIterator())
				{
					if (takeRest)
						yield item;
					else if (predicate(item, ++currindex))
						continue;
					else
					{
						takeRest = true;
						yield item;
					}
				}
			}(this));
		}

		public Reverse()
		{
			return new CalystoEnumerable(() =>
			{
				var items = this.ToArray();
				items.reverse(); // in place reverse
				return Calysto.CalystoEnumerator.From(items);
			});
		}

		public FirstOrDefault(defaultValue?: TItem | null)
		{
			var arr = this.Take(1).ToArray();
			return arr.length == 1 ? arr.pop() : defaultValue;
		}

		public First()
		{
			var el = this.Take(1).ToArray();
			if (el.length == 1)
			{
				return el[0];
			}
			else
			{
				throw new Error("Error in .First(), sequence contains no elements");
			}
		}

		public LastOrDefault(defaultValue?: TItem | null)
		{
			var el = this.ToArray();
			return el.length > 0 ? el[el.length - 1] : defaultValue;
		}

		public Last()
		{
			var el = this.ToArray();
			if (el.length > 0)
			{
				return el[el.length - 1];
			}
			else
			{
				throw new Error("Error in .Last(), sequence contains no elements");
			}
		}

		public Any(predicate?: (item: TItem, index: number) => boolean)
		{
			if (typeof predicate != "function")
				predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(<any>predicate);

			predicate = predicate || ((o, n) => true);
			var arr = this.Where(predicate).Take(1).ToArray();
			return arr.length == 1;
		}

		/**
		 * Test if predicate returns true for all items in collection.
		 * @param predicate
		 */
		public All(predicate: (item: TItem, index: number) => boolean)
		{
			return !this.Where((o, index) => !predicate(o, index)).Any();
		}

		public Where(predicate: (item: TItem, index: number) => boolean)
		{
			if (typeof predicate != "function")
				predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(predicate);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let index = -1;
				for (let item of __this.AsIterableIterator())
				{
					if (!predicate(item, ++index))
						continue;
					else
						yield item;
				}
			}(this));
		}

		public Select<TNew>(selector: (item: TItem, index: number) => TNew)
		{
			if (typeof selector != "function")
				selector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(selector);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let index = -1;
				for (let item of __this.AsIterableIterator())
					yield selector(item, ++index);
			}(this));
		}

		public Cast<TNew>()
		{
			return <CalystoEnumerable<TNew>>(<any>this);
		}

		public SelectMany<TNew>(selector?: (item: TItem) => TNew[] | CalystoEnumerable<TNew>)
		{
			if (typeof selector != "function")
				selector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(<any>selector);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let sel1 = selector || (x => x);

				for (let item of __this.AsIterableIterator())
				{
					if (!item)
						continue; // null, e.g. [[1,2,3], null, [3,4,5]]

					let collection1 = sel1(item);
					if (!collection1)
						continue;

					let enumerable2 = CalystoEnumerable.From(<any>collection1); // item is inner source, e.g. [1,2,3]
					for (let item2 of enumerable2.AsIterableIterator())
						yield <TNew>item2;
				}
			}(this));
		}

		public Distinct<TKey>(keySelector?: (item: TItem) => TKey)
		{
			if (typeof keySelector != "function")
				keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(<any>keySelector);

			return CalystoEnumerable.From(() => function* (__this)
			{
				let sel1 = keySelector || (x => x);
				let set = new Set<TKey>();

				for (let item of __this.AsIterableIterator())
				{
					let key = <any>sel1(item);
					if (!set.has(key))
					{
						set.add(key);
						yield item;
					}
				}
			}(this));
		}

		/**
		 * Cycle all elements in current collection to infinity.
		 */
		public Cycle(take: number)
		{
			/// <summary>
			///  Cycle all elements in current collection to infinity. Must be used Take(x) to limit cycling.
			/// </summary>
			/// <param name="take" type="int" optional="true">OPTIONAL, if specified, takes max 'take' items</param>

			if (!take)
				throw new Error("Cycle requires take parameter");

			return CalystoEnumerable.From(() => function* (__this)
			{
				let servedItems = 0;
				let abort = false;

				do
				{
					// if there is no items in collection, servedItems is 0 as exit condition for while
					for (let item of __this.AsIterableIterator())
					{
						if (servedItems < take)
						{
							yield item;
							servedItems++;
						}
						else
						{
							abort = true;
							break;
						}
					}
				}
				while (!abort && servedItems > 0 && servedItems < take);

			}(this));
		}

		public GroupBy<TKey>(keySelector: (item: TItem) => TKey)
		{
			if (typeof keySelector != "function")
				keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);

			let dic = new Calysto.Dictionary<TKey, TItem[]>();
			let srcen = this.ToArray();
			for (let item of srcen)
			{
				let key = (<Function>keySelector)(item);
				let arr: TItem[];
				if (!dic.ContainsKey(key))
					dic.Add(key, arr = []);
				else
					arr = dic.GetValue(key);
				arr.push(item);
			}

			return dic.GetItems().AsEnumerable().Select(o => new CalystoGroupingGroup(o.Key, () => o.Value.AsEnumerable().GetEnumerator()));
		}

		public OrderBy<TKey>(keySelector: (item: TItem) => TKey, descending: boolean = false)
		{
			if (typeof keySelector != "function")
				keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);

			let groups = this.GroupBy(keySelector).ToArray();
			var sorted = <CalystoGroupingGroup<TKey, TItem>[]>groups.OrderBy((group) => group.Key, descending);
			return new CalystoOrderedEnumerable<TKey, TItem>(() => sorted.AsEnumerable().GetEnumerator());
		}

		public OrderByDescending<TKey>(keySelector: (item: TItem) => TKey)
		{
			if (typeof keySelector != "function")
				keySelector = <any>Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);

			return this.OrderBy(keySelector, true);
		}

		public static From<TItem>(
			source:
				ICalystoEnumerable<TItem>
				| CalystoEnumerable<TItem>
				| TItem[]
				| Iterator<TItem>
				| IterableIterator<TItem>
				| CalystoEnumerator<TItem>
				| (() => IterableIterator<TItem>)
		): CalystoEnumerable<TItem>
		{
			return new CalystoEnumerable(() => CalystoEnumerator.From<TItem>(<any>source));
		}

		public static Range(start: number, count: number)
		{
			return CalystoEnumerable.From(function* ()
			{
				let taken = 0;
				while (taken < count)
				{
					yield start;
					start++;
					taken++;
				}
			});
		}

		public static Repeat<TItem>(item: TItem, count:number)
		{
			return CalystoEnumerable.From(function* ()
			{
				let taken = 0;
				while (taken < count)
				{
					yield item;
					taken++;
				}
			});
		}
	}

	//#endregion

	//#region Grouping classes

	class CalystoGroupingGroup<TKey, TItem> extends CalystoEnumerable<TItem>
	{
		constructor(public Key: TKey, getEnumerator: () => CalystoEnumerator<TItem>) 
		{
			super(getEnumerator);
		}
	}

	class CalystoOrderedEnumerable<TKey, TItem> extends CalystoEnumerable<TItem>
	{
		constructor(private getGroupsEnumerator: () => CalystoEnumerator<CalystoGroupingGroup<TKey, TItem>>)
		{
			super(() => this.GetFlatEnumerable().GetEnumerator());
		}

		private GetFlatEnumerable()
		{
			return this.GetGroupsEnumerable().SelectMany(group => group);
		}

		private GetGroupsEnumerable()
		{
			return new CalystoEnumerable(this.getGroupsEnumerator);
		}

		public ThenBy<TKey>(keySelector: (item: TItem) => TKey, descending: boolean = false) 
		{
			let miniGroups = new CalystoEnumerable(this.getGroupsEnumerator).SelectMany(group =>
			{
				return group.OrderBy(keySelector, descending).GetGroupsEnumerable();
			});

			return new CalystoOrderedEnumerable(() => miniGroups.GetEnumerator());
		}

		public ThenByDescending<TKey>(keySelector: (item: TItem) => TKey) 
		{
			return this.ThenBy(keySelector, true);
		}
	}

	//#endregion

}
