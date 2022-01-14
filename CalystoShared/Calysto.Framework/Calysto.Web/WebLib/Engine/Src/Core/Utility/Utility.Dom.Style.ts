namespace Calysto.Utility.Dom.Style
{
	//#region CSS style methods

	/**
	 * Takes border-color and returns borderColor.
	 * @param name
	 */
	export function ConvertCssNameToCamel(name: string)
	{
		var re = new RegExp("(([\\w]*)-([a-z]))|([^\\-]+)", "g");
		var exarr;
		var ss = "";
		while ((exarr = re.exec(name)) != null)
		{
			ss += (exarr[2] || "") + (exarr[3] || "").toUpperCase() + (exarr[4] || "");
		}
		return ss;
	}

	/**
	 * Takes borderColor and returns border-color.
	 * @param name
	 */
	export function ConvertCssNameFromCamel(name: string)
	{
		var re = new RegExp("(([a-z]*)([A-Z]))|([\\w\\-]+)", "g");
		var exarr;
		var ss = "";
		while ((exarr = re.exec(name)) != null) // IE has "" if group not found, FF has undefined as default value in exarr
		{
			ss += (exarr[2] || "") + ((exarr[3] || "") != "" ? "-" + (exarr[3] || "").toLowerCase() : "") + (exarr[4] || "");
		}
		return ss;
	}

	/**
	 * Set opacity.
	 * @param element
	 * @param value 0.0 - 1.0
	 */
	export function SetOpacity(element: HTMLElement, value: string | number)
	{
		if (element && element.style)
		{
			let numValue = typeof (value) == "string" ? parseFloat(value) : value;

			if (numValue < 0)
				numValue = 0;
			else if (numValue > 1)
				numValue = numValue / 100; // ako je poslan postotak do 100%

			if (numValue > 1)
				numValue = 1;

			// chrome requires for opacity to be set, ie7 and ie8 requires filter to be set :(
			// must test filter first, ie7 has opacity, but setting opacity value doesn't work
			// must set both properties for compatibility

			if ("opacity" in element.style)
			{
				// opacity: 0...1
				// default is "" which is equal to 1
				// we have to set value 1 too, eg. if opacity is defined in css as 0.5 and now we want to set value 1, we can not use "" value, it will not override css value
				element.style.opacity = numValue + "";
			}

			if ("filter" in element.style)
			{
				// filter opacity: 0...100
				element.style.filter = "alpha(opacity=" + (numValue * 100.0) + ")";
			}

		}
	};

	/**
	 * Returns opacity percent value 0...100 or 100 if not set.
	 * @param element
	 */
	export function GetOpacity(element: HTMLElement)
	{
		var op: number = NaN;
		if (element && element.style)
		{
			if ("opacity" in element.style) // 0...1
			{
				op = parseFloat(element.style.opacity as string) * 100;
			}
			else if ("filter" in element.style) // 0...100
			{
				var match = (element.style["filter"] as string).match(new RegExp("opacity[\\s\\=]+([\\d]+)"));
				if (match)
				{
					op = parseFloat(match[1]); // may be 0
				}
			}
		}

		return typeof (op) == "number" && op >= 0 && op < 100 ? op : 100;
	};

	export function GetZIndex(element: HTMLElement)
	{
		// zIndex is not computed value, so computed value is always auto
		if (element?.style?.zIndex)
		{
			return parseInt(element.style.zIndex);
		}
		return NaN;
	}

	/**
	 * Get zIndex from element or from the first ancestor where value is defined.
	 * @param element
	 */
	export function GetZIndexNested(element: HTMLElement)
	{
		let tmp1: any = element;
		let zIndex: number = NaN;
		while (tmp1 && tmp1.ownerDocument && !Type.TypeInspector.IsNumber(zIndex = GetZIndex(tmp1)))
		{
			tmp1 = tmp1.parentNode;
		}
		return zIndex;
	}

	var rePxNumericProperties = new RegExp("top|left|bottom|right|width|height|size|radius|padding|margin", "i"); // ignore case, eg. borderTop

	export class StyleDecodedValue
	{
		public PropertyName: string;

		public HasNumericValue() { return Calysto.Type.TypeInspector.IsNumber(this.NumericValue) }

		public NumericValue: number;

		private _styleValue: string;

		public get StyleValue() { return this._styleValue || (this._styleValue = this.CreateStyleValue())}
		
		private CreateStyleValue()
		{
			if (this.HasNumericValue())
			{
				let units = this.Units;
				if (!units && typeof (this.PropertyName) == "string" && rePxNumericProperties.test(this.PropertyName))
				{
					units = "px";
				}

				if (units && units != "%")
				{
					return Math.round(this.NumericValue) + "" + units;
				}
				else
				{
					return this.NumericValue + "";
				}
			}
			else
			{
				return "";
			}
		}

		public Units: string;

		public Increment: string;

		public IsIncrement() { return this.Increment?.Contains("=") }

		public IsPercent() {return this.Units == "%"}

		public constructor() { }

		public static Parse(styleValue: string | number, styleProperty?: string)
		{
			let ss = new StyleDecodedValue();

			if (typeof styleValue == "string")
			{
				ss._styleValue = styleValue;
			}

			if (styleProperty)
				ss.PropertyName = ConvertCssNameToCamel(styleProperty);

			if(typeof(styleValue) == "string")
			{
				// values: +=10, -10, +=10px, +=10%,
				// values: -25px
				// color should not be parsed: rgb(0, 3, 5), 
				var match = styleValue.match(new RegExp("^([\\*\\-\\+][\\=])?([\\-]{0,1}[\\d\\.]+)(px|%|vh|vw)?$")); // extract negative decimal number
				if (match)
				{
					ss.Increment = match[1];
					ss.NumericValue = parseFloat(match[2]);
					ss.Units = match[3];
				}
			}
			else if (Calysto.Type.TypeInspector.IsNumber(styleValue))
			{
				ss.NumericValue = <number><any>styleValue;
			}

			return ss;
		}

		public ApplyNewValue(newValue: StyleDecodedValue)
		{
			let n3 = new StyleDecodedValue();
			n3.PropertyName = newValue.PropertyName || this.PropertyName;

			if (newValue.IsIncrement() && this.HasNumericValue() && newValue.HasNumericValue())
			{
				// +=10%, we have to use this.Units since % from +=10% is not the unit, we're changing value by 10% only
				n3.Units = this.Units;
				n3.NumericValue = this.NumericValue;

				let tmpNum = newValue.NumericValue;

				if (newValue.IsPercent())
				{
					// numVal is percentage, get value from percent
					tmpNum = n3.NumericValue * newValue.NumericValue / 100;
				}

				switch (newValue.Increment)
				{
					case "+=":
						n3.NumericValue += tmpNum;
						break;
					case "-=":
						n3.NumericValue -= tmpNum;
						break;
					case "*=":
						n3.NumericValue *= tmpNum;
						break;
				}
			}
			else if (newValue.HasNumericValue())
			{
				n3.NumericValue = newValue.NumericValue;
				n3.Units = newValue.Units;
			}
			else
			{
				n3._styleValue = newValue.StyleValue;
			}

			return n3;
		}
	}


	/**
	 * Calculate style value from currValue value corrected by newValue. Returns number. 
	 * If there is originalValue and newValue is in %, return percentage value of originalValue.
	 * @param currValue numeric or string, with px, %, or no units
	 * @param newValue new value or eg. +=10, auto, -=20, *=30, 10px, with px, % or no units
	 */
	export function CalculateNumericValue(currValue: number, newValue: string | number): number
	{
		let ss1 = StyleDecodedValue.Parse(currValue);
		let ss2 = StyleDecodedValue.Parse(newValue);
		let ss3 = ss1.ApplyNewValue(ss2);
		return ss3.NumericValue;
	}

	export function GetComputedStyleDeclaration(element: HTMLElement): CSSStyleDeclaration
	{
		// computed style on Chrowe won't work if html is not attached to dom
		if (element.ownerDocument && element.ownerDocument.defaultView && element.ownerDocument.defaultView.getComputedStyle)
		{
			// firefox and other
			return element.ownerDocument.defaultView.getComputedStyle(element);
		}
		else if (window.getComputedStyle)
		{
			// ie 9, chrome
			return window.getComputedStyle(element);
		}
		else if ((<any>element).currentStyle)
		{
			// ie 6, ie7, ie8
			return (<any>element).currentStyle as CSSStyleDeclaration;
		}
		return element.style;
	}

	/**
	 * Get element style value if available, else get computed value.
	 * @param element
	 * @param stylePropName style property name
	 */
	export function GetComputedStyle(element: HTMLElement, styleProperty: string)
	{
		let styleName = ConvertCssNameToCamel(styleProperty);
		let styleValue: string = <any> undefined;
		let numericValue: number = <any> undefined;

		if (styleName == "opacity")
		{
			numericValue = GetOpacity(element);
		}
		else if (styleName == "zIndex")
		{
			// zIndex is not computed value, so computed value is always auto
			numericValue = GetZIndex(element);
		}
		else if (styleName.indexOf("client") == 0 || styleName.indexOf("offset") == 0 || styleName.indexOf("scroll") == 0)
		{
			// names: client|offset|scroll + Width|Height|Left|Top
			numericValue = element[styleName];
		}
		else
		{
			// get value from .style object first, if value is not set, then get from computed style object
			// eg. if name is "border-width", it may be retreived from element.style only, computed style value is always ""

			styleValue = element.style[styleName];

			if (!styleValue || styleValue.indexOf("color") >= 0 || new RegExp("auto|initial|inherit").test(styleValue))
			{
				// if we need start value for animator in percent (%), we have to get value as element.style[styleName] because computed value is always in px
				// always get computed value, eg if style.height == "auto", we must get mesured numeric value for animator to work
				// styleValue is always string, so "" is false
				styleValue = GetComputedStyleDeclaration(element)[styleName];
			}
		}

		let result = StyleDecodedValue.Parse(styleValue || numericValue, styleName);

		if (result.HasNumericValue())
		{
			// ok
		}
		else if (result.StyleValue == "auto")
		{
			// fix for IE7 and older which returns "auto" if value is not set
			switch (result.PropertyName)
			{
				case "height":
					result.NumericValue = element.clientHeight;
					break;
				case "width":
					result.NumericValue = element.clientWidth;
					break;
			}
		}

		return result;
	}

	/**
	 * Set style value.
	 * @param element
	 * @param name
	 * @param value can be string '+=10' which wil increment current value or '-=10" to decrement current value
	 * @param units
	 */
	export function SetStyleValue(element: HTMLElement, name: string, value: any, units?: string)
	{
		if (element && element.style)
		{
			let ss1 = GetComputedStyle(element, name);

			let ss2 = StyleDecodedValue.Parse(value, name);
			if (!ss2.Units && !!units)
				ss2.Units = units;

			let ss3 = ss1.ApplyNewValue(ss2);

			if (name == "opacity")
			{
				SetOpacity(element, ss3.NumericValue);
			}
			else if (name.indexOf("offset") == 0)
			{
				// offset values can not be set
			}
			else if (name.indexOf("client") == 0 || name.indexOf("scroll") == 0)
			{
				// set attribute value, this is required for animator
				element[name] = ss3.NumericValue;
			}
			else
			{
				try
				{
					// ie 7 may throw exception if setting negative width or height
					element.style[ss3.PropertyName] = ss3.StyleValue;
				}
				catch (e)
				{
				}
			}
		}
	}

	//#endregion
}
