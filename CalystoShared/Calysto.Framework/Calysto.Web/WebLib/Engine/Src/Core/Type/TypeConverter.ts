namespace Calysto.Type.TypeConverter
{
	/**
	 * 	if obj is null or undefined or NaN, return empty string ""
		if exists obj.ToStringFormated, invoke obj.ToStringFormated(format), else, invoke ChangeType(obj, String).
	 * @param obj
	* @param format eg.N1, N2, N0, dd.MM.yy HH: ss
	 */
	export function ToStringFormated(obj: any, format?: string)
	{
		if (TypeInspector.IsNullOrUndefined(obj)) return "";
		if (obj && obj.ToStringFormated) return obj.ToStringFormated(format); // if format not provided, use default formating
		else return ChangeType(obj, "String");
	};

	/**
	 * 
	 * @param obj
	 * @param toType
	 * @param mayBeNull
	 */
	export function ChangeType(obj: any, toType: keyof typeof JSType, mayBeNull?: boolean);

	/**
	 * 
	 * @param obj
	 * @param toType
	 */
	export function ChangeType(obj: any, toType: TypeDescriptor);

	/**
	 * Convert obj to different type.
		If obj type already is of requested type, return obj itself.
		If obj is "", but toTypeName is not String, return null. This is required for element serialization, used in Calysto.Forms and Calysto.ObservableBinder
		If obj is null, but requested type is String, will return "" (empty string)
	 * @param obj
	 * @param toType type name, may end with question (?) which means nullable type
	 * @param mayBeNull
	 */
	export function ChangeType(obj: any, toType: keyof typeof JSType | TypeDescriptor, mayBeNull?: boolean)
	{
		if (toType == <any>"Int")
		{
			throw new Error("Int is not supported, use Integer instead");
		}

		let destType = typeof (toType) == "string"
			? TypeDescriptor.FromTypeName(toType, mayBeNull) :
			toType;

		if (!destType.IsValidKnownType)
		{
			throw new Error("Invalid destType: " + toType);
		}

		if (TypeInspector.IsNullOrUndefined(obj) || (destType.KnownTypeName != JSType.String && obj === ""))
		{
			// destType.NetType != DotNetType.String && obj === "": used in reading values from element and converting to type which is not string

			if (destType.IsNullable)
			{
				return null;
			}
			else
			{
				throw new Error("Error in ChangeType(). Can not convert null to " + toType);
			}
		}

		let currType = TypeDescriptor.FromValue(obj);

		if (currType.UnderlayingTypeName == destType.UnderlayingTypeName)
		{
			// obj already is of the required type
			return obj;
		}

		switch (destType.KnownTypeName)
		{
			case JSType.String:
				if (currType.KnownTypeName == JSType.String) return obj;
				if (TypeInspector.IsNullOrUndefined(obj)) return ""; // used in data binding to elments to convert undefined or null into empty string ""
				if (obj.ToStringFormated) return obj.ToStringFormated(); //this is way to convert date to string in Calysto.Forms.Deserialize
				if (obj && obj.join) return "[" + obj.join(",") + "]"; // convert array to string, there is already native converter in browser
				// we could convert {...} to string too, but if object is large, lets better not do it, NO, DO NOT DO IT, LET'S THROW EXCEPTION
				return obj + "";
			case JSType.Boolean:
				{
					if (currType.KnownTypeName == JSType.Boolean) return obj;
					if (obj === true || obj == "true" || obj == "True" || obj == "1") return true;
					if (obj === false || obj == "false" || obj == "False" || obj == "0") return false;
					if (typeof (obj) == "number") return obj === 0 ? false : true;
					throw new Error("Can not create boolean from: " + obj);
				}
			//break;
			case JSType.Decimal:
			case JSType.Number:
			case JSType.Integer:
				{
					if (!TypeInspector.IsNumber(obj))
					{
						let re1 = new RegExp("^[\\+\\-]*[\\s]*[\\d\\,\\.]+$");
						if (!re1.test(obj + ""))
							throw new Error("Can not create number from: " + obj);
					}
					var num = NumberConverter.ToDecimal(obj); // convert using current culture
					if (TypeInspector.IsNumber(num))
					{
						if (destType.KnownTypeName == JSType.Integer) { return parseInt(num); }
						else { return num; }
					}
					throw new Error("Can not create number from: " + obj);
				}
			//break;
			case JSType.DateTime:
			case JSType.Date:
				{
					if (typeof (obj) == "string")
					{
						try
						{
							var dt = Calysto.DateTime.ParseDateTime(obj, undefined, true);
							if (!dt) throw new Error("Can not create DateTime from " + obj);
							if (dt && destType.KnownTypeName == JSType.Date) return dt.ToSystemDate();
							else return dt; // Calysto.DateTime
						}
						catch (e)
						{
							// na kraju ce baciti exception
						}
					}
					throw new Error("Can not create DateTime from " + obj);
				}
			//break;
			case JSType.Function:
				return Calysto.Utility.Expressions.CompileLambdaExpression(obj);
			case JSType.Array:
				// csv values, [1,2,3,4]
				return (<string>obj).Trim(['[', ']']).Split([',']).AsEnumerable().Select((o) => o.Trim()).ToArray();
		}

		throw new Error("Can not create " + toType + " from " + obj);
	};

	/**
	 * Try to change obj to toTypeName, output result into refOutArray. Returns true if successful.
	 * @param obj
	 * @param toType
	 * @param refOut
	 */
	export function TryChangeType<TResult>(obj: any, toType: keyof typeof JSType, refOut: BoxValue<TResult>)
	{
		try
		{
			refOut.SetValue(ChangeType(obj, toType));
			return true;
		}
		catch (e1)
		{ }
		return false;
	};
}
