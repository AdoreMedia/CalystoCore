namespace Calysto.Collections
{

	/**
	 * Flattens any kind or argumens and any depth as long as they have length or GetEnumerator. Returns flattened array.
	 * @param array
	 */
	export function SelectFlatten(array1: any, array2?: any, array3?:any, etc?:any )
	{
		var arrRes: any[] = [];
		for (var n1 = 0; n1 < arguments.length; n1++)
		{
			var tmpObj = arguments[n1];

			if (tmpObj == undefined)
			{
				continue;
			}
			else if (tmpObj["GetEnumerator"] && tmpObj["ToArray"])
			{
				var arr2 = tmpObj.ToArray();
				for (var n2 = 0; n2 < arr2.length; n2++)
				{
					var res2 = SelectFlatten(arr2[n2]);
					arrRes.AddRange(res2);
				}
			}
			else if ((tmpObj.tagName && tmpObj.nodeType) || tmpObj.nodeType == Calysto.Utility.Dom.NodeTypeEnum.TEXT_NODE)
			{
				// it is form or select element, it is not array
				arrRes.push(tmpObj);
			}
			else if (tmpObj["length"] >= 0)
			{
				if (typeof tmpObj == "string")
				{
					arrRes.push(tmpObj);
				}
				else // it must be array or dom array, iterate
				{
					for (var n2 = 0; n2 < tmpObj.length; n2++)
					{
						var res2 = SelectFlatten(tmpObj[n2]);
						arrRes.AddRange(res2);
					}
				}
			}
			else
			{
				// not array and not string
				arrRes.push(tmpObj);
			}
		}
		return arrRes;
	}

	export function ForEach<TElement>(array: TElement[], delegate: (item: TElement, index: number) => void, context?: Object): void
	{
		if (typeof (array) == "string") throw new Error("ForEach does not accept string");

		// must have support for DOM array and FileList which don't have push or pop
		if (array && array.length > 0)
		{
			// enumerate array, dom array or string
			for (var nn = 0; nn < array.length; nn++)
			{
				delegate.call(context, array[nn], nn); // don't use if return === false because it will break execution in chrome (return is false by default)
			}
		}
	}

	export function ForEachNodeList(array: NodeList, delegate: (item: Node, index: number) => void, context?: Object): void
	{
		// must have support for DOM array and FileList which don't have push or pop
		if (array && array.length > 0)
		{
			// enumerate array, dom array or string
			for (var nn = 0; nn < array.length; nn++)
			{
				delegate.call(context, array[nn], nn);
			}
		}
	}

	export function ForEachChars(str: string, delegate: (item: string, index: number) => void, context?: Object): void
	{
		if (typeof (str) != "string") throw new Error("ForEachChars requires string argument");

		// must have support for DOM array and FileList which don't have push or pop
		if (str && str.length > 0)
		{
			// enumerate array, dom array or string
			for (var nn = 0; nn < str.length; nn++)
			{
				delegate.call(context, str.charAt(nn), nn);
			}
		}
	}

	export function GetProperties(obj: Object, ownPropertiesOnly?: boolean): string[]
	{
		/// <summary>
		/// returns Array
		/// </summary>
		/// <param name="obj" type="Object">object source</param>
		/// <param name="ownPropertiesOnly" type="Boolean" optional="true">default: false</param>

		var arr: string[] = [];

		if (obj)
		{
			// enumerate object's properties
			for (var prop in obj)
			{
				if (!ownPropertiesOnly || obj.hasOwnProperty(prop))
				{
					arr.push(prop);
				}
			}
		}
		return arr;
	}

	export function GetOwnProperties(obj: Object)
	{
		return GetProperties(obj, true);
	}

	/**
	 * Foreach all properties, not just ownProperties.
	 * @param {Object} obj
	 * @param {Function} delegate function(propName, propValue, index){...}
	 * @param {Object} context?
	 * @returns
	 */
	export function ForEachProperties<TValue>(obj: Object, delegate: (name: string, value: TValue, index: number) => void, context?: Object): void
	{
		if (obj)
		{
			// enumerate object's properties
			var index = 0;
			for (var prop in obj)
			{
				delegate.call(context, prop, obj[prop], index++); // don't use if return === false because it will break execution in chrome (return is false by default)
			}
		}
	}

	/**
	 * Foreach ownProperties only.
	 * @param {Object} obj
	 * @param {Function} delegate function(propName, propValue, index){...}
	 * @param {Object} context
	 * @returns
	 */
	export function ForEachOwnProperties<TValue>(obj: Object, delegate: (name: string, value: TValue, index: number) => void, context?: Object): void
	{
		if (obj)
		{
			// enumerate object's properties
			var index = 0;
			for (var prop in obj)
			{
				if (obj.hasOwnProperty(prop))
				{
					delegate.call(context, prop, obj[prop], index++); // don't use if return === false because it will break execution in chrome (return is false by default)
				}
			}
		}
	}

	let _innerArray = "InnerArray";

	export function HasInnerArray(obj: any)
	{
		return obj && _innerArray in obj;
	}

	export function GetInnerArray<TItem>(obj: any) : TItem[] | undefined
	{
		if (HasInnerArray(obj))
		{
			return obj[_innerArray];
		}
		return undefined;
	}
}

