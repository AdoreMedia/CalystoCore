/// <reference path="../enumerable/enumerable.ts" />
/// <reference path="../enumerable/collections.ts" />

interface Array<T>
{
	/** Remove T item at index from this array and return this array */
	RemoveAt(index: number): Array<T>;

	/** Remove T item from this array and return this array */
	Remove(item: T): Array<T>;

	/**
	 * Remove items from this array and return this array
	 * @param predicate condition
	 */
	RemoveBy(predicate: (item: T, index: number) => boolean) : Array<T>;

	/** tests if item exists in this array */
	Contains(item: T): boolean;

	/**
	 * creates and returns copy of current array
	 */
	ToArray(): Array<T>;

	/**
	 * returns true if array contains any element
	 */
	Any(): boolean;

	/**
	 * add elements to this array, returns this array
	 * @param {Array<T>} arr
	 */
	AddRange(arr: Array<T> | IArguments): Array<T>;

	/**
	 * add new item to this array and return this array
	 * @param {T} item
	 */
	Add(item: T): Array<T>;

	/**
	 * insert new items to this array and return this array
	 * @param {number} atIndex
	 * @param {Array<T>} arr
	 */
	InsertRange(atIndex: number, arr: Array<T>): Array<T>;

	/**
	 * Remove all items from this, return this array
	 */
    Clear(): Array<T>;

    AsEnumerable(): Calysto.CalystoEnumerable<T>;

    /**
    * returns new array with sorted items by key
    */
	OrderBy<TKey>(keySelector: (item: T) => TKey, descending?: boolean): Array<T>;

	///** return new sliced array */
	//SkipTake(skip: number, take: number): Array<T>;

	/** Run foreach on this array and returns this array. */
	ForEach(func: (item: T, index: number) => void): Array<T>;

	/**
	* In place reverse. Return this array.
	*/
	Reverse(): Array<T>;

	///** return new sliced array */
	//Where(predicate: (item: T, index: number) => boolean, take?: number): Array<T>;

	///** return new array from selected items */
	//Select<TNew>(selector: (item: T, index: number) => TNew): Array<TNew>;

	/** join array elements to string, default separator is empty string "" */
	ToStringJoined(separator?: string): string;

}

if (!Array.prototype.RemoveAt)
{
	(function ()
	{
		if (!Array.prototype.indexOf)
		{
			// for < IE9, used in Calysto.Enumerable.Distinct()

			Array.prototype.indexOf = function (item)
			{
				/// <summary>
				/// Calysto defined function. Returns index of item in this array.
				/// </summary>
				/// <param name="item" type="type"></param>
				/// <returns type=""></returns>
				for (var n = 0; n < this.length; n++)
				{
					if (this[n] === item)
					{
						return n;
					}
				}
				return -1;
			};
		}

		//Array.prototype.SkipTake = function (skip, take)
		//{
		//	return this.slice(skip, skip + take);
		//};

		Array.prototype.ForEach = function (action)
		{
			if (typeof action == "string") action = <any>Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(action);
			Calysto.Collections.ForEach(this, <any>action);
			return this;
		}

		//Array.prototype.Where = function (predicate, take)
		//{
		//	if (typeof predicate == "string") predicate = <any> Calysto.Utility.Expressions.CompileLambdaExpression(predicate);

		//	var a1: any[] = [];
		//	for (let n = 0; n < this.length; n++)
		//	{
		//		if ((<Function>predicate)(this[n], n))
		//		{
		//			a1.push(this[n]);
		//			if (take && a1.length >= take)
		//			{
		//				return a1;
		//			}
		//		}
		//	}
		//	return a1;
		//};

		//Array.prototype.Select = function (selector)
		//{
		//	if (typeof selector == "string") selector = <any> Calysto.Utility.Expressions.CompileLambdaExpression(selector);
		//	var a1: any[] = [];
		//	Calysto.Collections.ForEach(this, (item, index) =>
		//	{
		//		a1.push((<Function>selector)(item, index));
		//	});
		//	return a1;
		//};

		Array.prototype.Reverse = function ()
		{
			this.reverse(); // in place reverse
			return this;
		}

        Array.prototype.OrderBy = function (keySelector, descending)
        {
			/// <summary>
			/// sort and return new array with sorted values.
			/// </summary>
			/// <param name="keySelector" type="Function">function(item){return item.key;}</param>
            /// <param name="descending" type="Boolean"></param>
			if (typeof keySelector == "string") keySelector = <any> Calysto.Utility.Expressions.CompileLambdaExpression(keySelector);
			return Calysto.ArraySorter.SortArray(this, keySelector, descending);
		};

		Array.prototype.RemoveAt = function (index)
		{
			/// <summary>
			/// Remove item at index position.
			/// </summary>
			/// <param name="index" type="Integer"></param>
			this.splice(index, 1);
			return this;
		};

		Array.prototype.Remove = function (item)
		{
			/// <summary>
			/// Remove item from array.
			/// </summary>
			/// <param name="item" type="type"></param>
			var index = this.indexOf(item);
			if (index == 0 || index > 0)
			{
				return this.RemoveAt(index);
			}
			return this;
		};

		Array.prototype.RemoveBy = function (predicate)
		{
			if (typeof predicate == "string") predicate = <any>Calysto.Utility.Expressions.CompileLambdaExpression(predicate);

			for (let n1 = this.length - 1; n1 >= 0; n1--)
			{
				if (predicate(this[n1], n1))
				{
					this.splice(n1, 1);
				}
			}
			return this;
		};

		Array.prototype.Contains = function (value)
		{
			/// <summary>
			/// Calysto defined function. Search for value in this array, return true if value exists.
			/// </summary>
			/// <param name="value" type="type"></param>
			/// <returns type=""></returns>
			let index = this.indexOf(value);
			return index > 0 || index === 0;
		};

        Array.prototype.AsEnumerable = function ()
        {
			return Calysto.CalystoEnumerable.From(this.slice(0));
        };

		Array.prototype.ToArray = function ()
		{
			/// <summary>
			/// Creates new copied array (sliced copy).
			/// </summary>
			// Since GroupBy used to return enumerable, but now returns Array with Key property.
			// This way it is not exception if we invoke ToArray on such grouping group.
			return this.slice(0);
		};

		Array.prototype.Any = function ()
		{
			/// <summary>
			/// Return true if there is any item in array.
			/// </summary>
			return this.length > 0;
		};

		Array.prototype.Add = function (item)
		{
			this.push(item);
			return this;
		};

		Array.prototype.AddRange = function (arr)
		{
			/// <summary>
			/// Calysto defined function. Uses foreach to iterate elements from arr and dd items from arr to this array. Return this array.
			/// </summary>
			/// <param name="value" type="Array|NodeList"></param>
			for (var n1 = 0; arr && n1 < arr.length; n1++)
			{
				this.push(arr[n1]);
			}
			return this;
		};

		Array.prototype.InsertRange = function (atIndex, arr)
		{
			/// <summary>
			/// Calysto defined function. Uses foreach to iterate elements from arr and insert at specified index. Return this array.
			/// </summary>
			/// <param name="value" type="Array|NodeList"></param>
			for (var n1 = arr.length; n1 > 0; n1--)
			{
				this.splice(atIndex, 0, arr[n1 - 1]);
			}
			return this;
		};

		Array.prototype.Clear = function ()
		{
			/// <summary>
			/// Remove all items from array. Return this array.
			/// </summary>
			/// <returns type="Array"></returns>
			this.splice(0, this.length);
			return this;
		};

		Array.prototype.ToStringJoined = function (separator)
		{
			// join must have separator defined, if not defined, default is ", "
			return this.join(arguments.length > 0 ? separator : "");
		};

	})();
}