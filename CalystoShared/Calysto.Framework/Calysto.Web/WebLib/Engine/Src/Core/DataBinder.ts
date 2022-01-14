namespace Calysto
{
	export namespace DataBinder
	{
		var reNum = new RegExp("^[\\d]+$");
		var reRoot = new RegExp("^[\\@]+[\\.]*"); // @.prop1.prop2 or @prop1.prop2

		var RecursionLimit = 100;

		function RemoveRoot(prop: string)
		{
			return (prop || "").replace(reRoot, "");
		}

		function SplitToParts(prop: string | number)
		{
			return RemoveRoot(prop + "").Split(['.', '[', ']']);
		}

		export function TryGetValue<T>(dataObj: Object, dataProperty: string | number, refOut: BoxValue<T>)
		{
			/// <summary>
			/// Try to get value from dataObj. Returns true if property exist and it's value is pushed into refOutArray. Any other case, returns false and empty refOutArray.
			/// </summary>
			/// <param name="dataObj">object with properties or array</param>
			/// <param name="dataProperty" type="String|Integer">case sensitive full path property name, eg. style.color, or index if object is array, eg. style.color.3.name, where number 3 is index in array</param>
			/// <param name="refOutArray" type="Array"></param>

			if (!dataObj || !refOut || arguments.length != 3)
			{
				// dataProperty may be "", it is used in Calysto.Observable, eg. calysto-bind="repeater:DataItem", TryGetValue has to return dataObj itself
				throw new Error("Calysto.DataBinder.TryGetValue() requires 3 arguments");
				//return false;
			}

			var cnt = 0;
			var arr = SplitToParts(dataProperty);
			var val = dataObj;
			var prop;

			while (arr.length > 0 && (prop = arr.shift())) // will ignore empty prop, eg. Player.Playing. when splited, last value is "", and has to be ignored
			{
				if (cnt++ > RecursionLimit)
				{
					throw new Error("Calysto.DataBinder.TryGetValue() recursion limit");
					//return false;
				}

				let isIndex = false;

				if (reNum.test(prop))
				{
					prop = parseInt(prop, 10);// if it is number, use index as property
					isIndex = true;
				}

				// just to speed up
				if (val == null || val == undefined)
				{
					return false;
				}

				try
				{
					if (isIndex && Calysto.Collections.HasInnerArray	(val))
					{
						val = (<any[]>Calysto.Collections.GetInnerArray(val))[prop];
					}
					else if (!(prop in val))
					{
						return false;
					}
					else
					{
						val = val[prop];
					}
				}
				catch (e)
				{
					return false;
				}
			}
			refOut.SetValue(<T>val);
			return true;
		};

		export function GetValue<T>(dataObj: Object, dataProperty: string | number)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="dataObj">object with properties or array</param>
			/// <param name="dataProperty" type="String|Integer">case sensitive full path property name, eg. style.color, or index if object is array, eg. style.color.3.name, where number 3 is index in array</param>

			if (arguments.length < 2)
			{
				throw new Error("Calysto.DataBinder.GetValue() requires 2 arguments");
			}

			var refOut = new BoxValue<T>();
			TryGetValue(dataObj, dataProperty, refOut);
			return refOut.GetValue();
		};

		export function SetValue(dataObj: Object, dataProperty: string | number, value: any)
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="dataObj"></param>
			/// <param name="dataProperty" type="String|Integer">case sensitive full path property name, eg. style.color.3.name, where number 3 is index in array style.color</param>
			/// <param name="value">new value</param>

			if (!dataObj || !dataProperty || arguments.length < 3)
			{
				throw new Error("Calysto.DataBinder.SetValue() requires 3 arguments");
			}

			var cnt = 0;
			var arr = SplitToParts(dataProperty);
			var prop;
			var obj = dataObj;
			var tmp = obj;
			while (arr.length > 0 && (prop = arr.shift())) // will ignore empty prop
			{
				if (cnt++ > RecursionLimit)
				{
					throw new Error("Calysto.DataBinder.SetValue() recursion limit");
				}

				let isIndex = false;
				if (reNum.test(prop))
				{
					prop = parseInt(prop, 10);// if it is number, use index as property
					isIndex = true;
				}

				if (arr.length > 0)
				{
					if (isIndex && Calysto.Collections.HasInnerArray(obj))
					{
						tmp = (<any[]>Calysto.Collections.GetInnerArray(obj))[prop];
					}
					else
					{
						tmp = obj[prop];
					}

					if (!tmp)
					{
						// not last property, but datacontext has no object, create new object {}
						// this feature is used at imagine player
						obj = obj[prop] = {};
					}
					else
					{
						obj = tmp;
					}
				}
				else if (isIndex && Calysto.Collections.HasInnerArray(obj))
				{
					(<any[]>Calysto.Collections.GetInnerArray(obj))[prop] = value;
				}
				else
				{
					// last property, assing value
					obj[prop] = value;
				}


			}
		};
	}
}

