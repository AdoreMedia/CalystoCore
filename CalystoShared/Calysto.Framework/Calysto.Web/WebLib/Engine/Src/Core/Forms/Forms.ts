namespace Calysto.Forms
{
	type SerializedElementType = {
		Element: HTMLInputElement,
		Name: string,
		/** value may be any type, since it may be value returned from getter fn */
		Value: string | string[] | any,
		/** if it is not null or undefined or NaN, empty string is considred as value */
		HasValue: boolean
	};

	class SerializedElement
	{
		CalystoId: string;
		CalystoUid: string;
		Value: any;
		Enabled = true;
		Visible = true;
		Name: string;
		Id: string;
		Checked: boolean;
		HtmlName: string;
		HtmlValue: string;
		HtmlId: string;
		HtmlTagName: string;
		HtmlType: string;
	}

	//#region SerializeElement

	function SerializeElement(element): SerializedElementType
	{
		/// <summary>
		/// values which browser originally send on form-submit. Returns name-value object: {Element: el, Name:name1, Value: value1}
		/// </summary>
		/// <param name="element"></param>

		//////#if VSINT ELLISENSE
		////if (Calysto.IsVSIntellisense)
		////{
		////	return {
		////		// dom element
		////		Element: HTMLInputElement.prototype,
		////		// string: attribute name="..."
		////		Name: "",
		////		// string or array: attribute value="..." or array of values in multiselect
		////		Value: ""
		////	};
		////}
		//////#endif

		// if there is calysto-id, name may not exsits, serialize element anyway

		if (!(element && element.tagName && element.type))
		{
			return <SerializedElementType>{}; // text nodes, html nodes
		}

		var elementName = element.name;
		var tagName = element.tagName.toUpperCase();
		var type = element.type.toLowerCase();
		var finalValue: any = null;

		var attr = element.getAttribute(Calysto.AttrName.CalystoGetter);
		if (attr)
		{
			var fn = Calysto.Utility.Expressions.CompileLambdaExpression(attr); /// fn must return value
			finalValue = fn.call(element, element);
		}
		else
		{
			switch (tagName)
			{
				case "INPUT":
					switch (type)
					{
						case "checkbox":
						case "radio":
							// if not checked, value should not be sent to server at all,
							// can not create false value because of radios group where all of them have the same name and value is selected if radio is checked
							if (!element.checked)
							{
								return <SerializedElementType>{};
							}
							else if (element.value == "on" && !element.getAttribute("value"))
							{
								// if there is no attribute "value", default value for checkbox and radio is "on"
								// than return only true if checked, if not checked, value should not be sent to server at all
								finalValue = true;
							}
							else
							{
								finalValue = element.value;
							}
							break;

						case "file":
							finalValue = []; // always create name and array of values (or empty array if there is no values)
							if (element.files && element.files[0])
							{
								for (var n = 0; n < element.files.length; n++)
								{
									finalValue.push(element.files[n]);
								}
							}
							break;

						// text, password, hidden, email, tel, ...
						default:
							finalValue = element.value; // allways create name and value, even if value is empty ("")
							break;
					}
					break;

				case "TEXTAREA":
					finalValue = element.value; // allways create name and value, even if value is empty ("")
					break;

				case "SELECT":
					{
						switch (element.type)
						{
							case "select":
							case "select-one":
								finalValue = element.value;  // allways create name and value, even if value is empty ("")
								break;

							case "select-multiple":
								{
									var option;
									finalValue = [];// allways create name and value, even if value is empty ("")
									// browser creates CSV values, but it is better to use Array because we may have value with comma inside
									for (var j = 0; j < element.options.length; j++)
									{
										if ((option = element.options[j]) && option.selected)
										{
											finalValue.push(option.value);
										}
									}
								}
								break;
						}
					}
					break;
			}
		}

		let toType = element.getAttribute(Calysto.AttrName.CalystoType);
		if (toType)
		{
			let destType = Calysto.Type.TypeDescriptor.FromTypeName(toType);
			if (!destType.IsValidKnownType)
			{
				throw new Error("Forms serializer error, invalid toType: " + toType);
			}

			var fnConvert = function (val1)
			{
				// Date or Calysto.DateTime convertion only
				var format = element.getAttribute(Calysto.AttrName.CalystoFormat);
				if (val1 && format && (destType.KnownTypeName == Calysto.Type.JSType.Date || destType.KnownTypeName == Calysto.Type.JSType.DateTime))
				{
					let refOut = new BoxValue<DateTime>();
					if (DateTime.TryParseDateTime(val1, format, refOut))
					{
						val1 = refOut.GetValue();
					}
				}
				// empty string has to be converted to null if toType != String
				val1 = Calysto.Type.TypeConverter.ChangeType(val1, toType, true);
				return val1;
			};

			let currType = Type.TypeDescriptor.FromValue(finalValue);
			if (currType.KnownTypeName != destType.KnownTypeName)
			{
				if (Calysto.Type.TypeInspector.IsArray(finalValue))
				{
					var arr: any[] = [];
					for (var n1 = 0; n1 < finalValue.length; n1++)
					{
						arr.push(fnConvert(finalValue[n1]));
					}
					finalValue = arr;
				}
				else
				{
					finalValue = fnConvert(finalValue);
				}
			}
		}

		// if finalValue is not set, value should not be sent to server at all
		// if null, don't send to server at all
		return {
			// dom element
			Element: element,
			// string: attribute name="..."
			Name: elementName,
			// string or array: attribute value="..." or array of values in multiselect
			Value: finalValue,
			// if has value, empty string is considred as value too
			HasValue: !Calysto.Type.TypeInspector.IsNullOrUndefined(finalValue)
		};
	};

	export function SerializeContainer(containerSelector: string | HTMLElement)
	{
		/// <summary>
		/// Form-serialize containerSelector, returns array of Name-Value objects: [{Element:el1, Name:name1, Value:value1}, {Element:el2, Name:name2, Value:value2}, ...]
		/// </summary>
		/// <param name="containerSelector"></param>
		/// <param name="nameValueDataObject"></param>

		//////#if VSIN TELLISENSE
		////if (Calysto.Core.IsVSIntellisense)
		////{
		////	return [SerializeElement()];
		////}
		//////#endif

		if (!containerSelector)
		{
			return [];
		}

		var all = $$calysto(containerSelector).Query("*, //*").Query("input, textarea, select").ToArray();

		var result: SerializedElementType | null;
		var finalArr: SerializedElementType[] = [];
		for (var n = 0; n < all.length; n++)
		{
			if ((result = SerializeElement(all[n])).HasValue) // result is {Element:el1, Name:name1, Value:value1}
			{
				finalArr.push(result);
			}
		}
		return finalArr;
	};

	//#endregion

	//#region DeserializeElement

	function EnsureDataTypeAttribute(el, data)
	{
		/// <summary>
		/// Set calysto-type attribute, only if doesn't exist already
		/// </summary>
		/// <param name="el" type="HTMLDivElement"></param>
		/// <param name="data" type="type"></param>
		/// <returns type=""></returns>
		if (!el.getAttribute(Calysto.AttrName.CalystoType))
		{
			var tt = Type.TypeDescriptor.FromValue(data);
			if (tt.IsValidKnownType)
			{
				el.setAttribute(Calysto.AttrName.CalystoType, tt.NullableTypeName);
			}
		}
	}

	function DeserializeElement(elem: HTMLElement, pval: any)
	{
		let element = <HTMLInputElement>elem;

		EnsureDataTypeAttribute(element, pval);

		var attr = element.getAttribute(Calysto.AttrName.CalystoSetter);
		if (attr)
		{
			// use original pval, do not convert to "" if null or undefined or NaN
			var fn = Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(attr);
			fn.call(element, pval);
			return true;
		}

		var type = "";
		if (element.type)
		{
			// div element doesn't have .type
			type = element.type.toLowerCase();
		}

		if (Calysto.Type.TypeInspector.IsNullOrUndefined(pval))
		{
			pval = "";
		}

		var tagName = element.tagName.toUpperCase();

		switch (tagName)
		{
			case "TEXTAREA":
				element.value = pval;
				break;

			case "INPUT":
				switch (type)
				{
					case "checkbox":
					case "radio":
						if (element.value == "on" && !element.getAttribute("value")) // means if value is not set, it's default value is "on"
						{
							// if pval is boolean, set checked = value
							element.checked = pval === true || pval === "true" || pval === "True";
						}
						else
						{
							// if pval is equal to value, set checked = true
							element.checked = element.value + "" == pval + "";
						}
						break;

					default:
						// if we have calysto-format specified or if pval is dateTime or number, format it
						element.value = Calysto.Type.TypeConverter.ToStringFormated(pval, <string>element.getAttribute(Calysto.AttrName.CalystoFormat));
						break;
				}
				break;

			case "SELECT":
				switch (type)
				{
					case "select":
					case "select-one":
					case "select-multiple":
						// select-multiple.value is always single value, must select options one by one
						try
						{
							if (pval && "Items" in pval)
							{
								var listItems: { Text: string, Value: string, Selected: boolean }[] = pval["Items"];

								var el: HTMLSelectElement = <any>element; // element with options as children
								el.innerHTML = "";

								listItems.ForEach((o, n) =>
								{
									let opt = document.createElement("option");
									opt.innerHTML = o.Text;
									opt.value = o.Value;
									el.appendChild(opt);
									opt.selected = !!o.Selected;
								});

								break;
							}
						}
						catch (e) { }


						if (type == "select-multiple")
						{
							if (Calysto.Type.TypeInspector.IsNullOrUndefined(pval))
							{
								pval = [];
							}
							else if (!Calysto.Type.TypeInspector.IsArray(pval))
							{
								pval = [pval];
							}

							var arr: any[] = pval;
							var el: HTMLSelectElement = <any>element; // element with options as children

							// pval contains values which have to be selected
							// since IE element.options return select element, we have use it like this:
							for (var n1 = 0; n1 < el.options.length; n1++)
							{
								(<any>el.options[n1]).selected = arr.AsEnumerable().Where(o => (o + "") == (<any>el.options[n1]).value).Any(); // value is always string
							}
						}
						else
						{
							// if value doesn't exist in ddl, it will select index -1, or nothing
							// it is better way because we may not accidentaly assign first value in ddl if there is no valid pval send from 
							// if pval is dateTime or number, format it
							// if value doesn't exist, it will set selectedIndex = -1 (none will be selected)
							element.value = Calysto.Type.TypeConverter.ToStringFormated(pval, <string>element.getAttribute(Calysto.AttrName.CalystoFormat)); 
						}
						break;

					default:
						throw new Error(`Type ${type} not supported.`);
				}
				break;

			default:
				if ("innerHTML" in element)
				{
					// if pval is dateTime or number, format it
					(<HTMLElement>element).innerHTML = Calysto.Type.TypeConverter.ToStringFormated(pval, <string>(<HTMLElement>element).getAttribute(Calysto.AttrName.CalystoFormat));
				}
				else
				{
					return false; // element can't be deserialized
				}
				break;
		}

		return true; // element deserialized successfuly
	}

	//#endregion

	//#region Reset Form Fields

	/**
	 * Reset all values do defaults. Exclude disabled or readOnly elements.
	 * @param {string | HTMLElement} containerSelector
	 */
	export function ResetForm(containerSelector: string | HTMLElement)
	{
		/// <summary>
		/// Reset all values do defaults. Exclude disabled or readOnly elements.
		/// </summary>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>

		$$calysto(containerSelector || document.documentElement).Query("*, //*").Query("input, select, textarea, [" + Calysto.AttrName.CalystoSetter + "=*]").ForEach((o: any) =>
		{
			if (!o.disabled && !o.readOnly)
			{
				var attr = o.getAttribute(Calysto.AttrName.CalystoSetter);
				var tagName = o.tagName.toLowerCase();

				if (attr)
				{
					var fn = Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(attr);
					fn.call(o, "");
				}
				else if (tagName == "textarea")
				{
					o.value = "";
				}
				else if (tagName == "input")
				{
					if (o.type == "radio" || o.type == "checkbox")
					{
						o.checked = false;
					}
					else if (o.type == "button" || o.type == "submit")
					{
						// nothing
					}
					else
					{
						o.value = "";
					}
				}
				else if (tagName.indexOf("select") == 0)
				{
					o.value = ""; // if value doesn't exist select selectedIndex = -1
					o.selectedIndex = 0; // now set first value in ddl
				}
			}
		});
	};

	//#endregion

	//#region FormSerialize & FormDeserialize

	/**
	 * Form-serialize containerSelector into dictionary. Serializes inputs with 'name' attribute. Returns dictionary: {name1: value1, name2: value2, ...}<br/>
		If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} trimStrings?
	 * @param {TResult} refOutDataObj?
	 * @returns
	 */
	export function FormSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult
	{
		/// <summary>
		/// Form-serialize containerSelector into dictionary. Serializes inputs with 'name' attribute. Returns dictionary: {name1: value1, name2: value2, ...}<br/>
		/// If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		/// If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
		/// </summary>
		/// <param name="containerSelector"></param>
		/// <param name="trimStrings" optional="true">if true, trim text values</param>
		/// <param name="refOutDataObj" optional="true">update read values into this object</param>

		var arr = SerializeContainer(containerSelector || document.documentElement);

		let includedNames = {};
		var dic: TResult = refOutDataObj || <TResult>{};
		for (var n = 0; n < arr.length; n++)
		{
			var name = arr[n].Name;
			if (!name)
			{
				continue;
			}
			else if (includedNames[name])
			{
				// Form standard uses first name found in form and ignores next item with the same name
				continue;
			}

			includedNames[name] = true;

			var value = arr[n].Value;

			if (trimStrings && Calysto.Type.TypeInspector.IsString(value))
			{
				value = (value || "").Trim();
			}

			// if value is null, undefined, NaN or empty string, do not set value at all
			// DataAnnotation attributes considers null as no data, while empty string "" is considered as data and triggers MinLen attribute
			if (!Type.TypeInspector.IsNullOrUndefined(value) && !String.IsNullOrEmpty(value))
			{
				dic[name] = value;
			}

		}
		return dic;
	};

	/**
	 * Bind data from dataObj dictionay to any element (not just input) with 'name' or 'id' attribute named as dataObj properties<br/>
		If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
	 * @param {any} dataObj
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} alwaysSet?
	 */
	export function FormDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean)
	{
		/// <summary>
		/// Bind data from dataObj dictionay to any element (not just input) with 'name' or 'id' attribute named as dataObj properties<br/>
		/// If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		/// If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		/// If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
		/// </summary>
		/// <param name="dataObj" type="object">object with values</param>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="alwaysSet" optional="true">if true, always set element value, if value doesn't exist in dataObj, use default value</param>

		dataObj = dataObj || {};
		// populate controls
		// allow multiple elements with the same name or id
		// asp.net style name = pp$aa$propName
		// asp.net style id = pp_aa_propName

		$$calysto(containerSelector || document.documentElement).Query("[name=*], //[name=*]").ForEach((o: any) =>
		{
			// required condition: name && name.length > 0
			var name;
			if (o && (name = o.name))
			{
				if (alwaysSet || name in dataObj)
				{
					if (!DeserializeElement(o, dataObj[name]))
					{
						throw new Error("Element with name=" + name + " is not valid for data binding");
					}
				}
			}
		});
	};


	//#endregion

	//#region MvcSerialize && MvcDeserialize

	/**
	 * Form-serialize values into dictionary. 
	 * Ignores null or empty values.
	 * Serializes inputs with 'name' attribute. Name may have nested path: prop1.prop2.prop3. It builds nested js objects.
		If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} trimStrings?
	 * @param {TResult} refOutDataObj?
	 * @returns
	 */
	export function MvcSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult
	{
		var arr = SerializeContainer(containerSelector || document.documentElement);

		let includedNames = {};
		var dic: TResult = refOutDataObj || <TResult>{};
		for (var n = 0; n < arr.length; n++)
		{
			var name = arr[n].Name;
			if (!name)
			{
				continue;
			}
			else if (includedNames[name])
			{
				// Form standard uses first name found in form and ignores next item with the same name
				continue;
			}

			includedNames[name] = true;

			var value = arr[n].Value;

			if (trimStrings && Calysto.Type.TypeInspector.IsString(value))
			{
				value = (value || "").Trim();
			}

			// if value is null, undefined, NaN or empty string, do not set value at all
			// DataAnnotation attributes considers null as no data, while empty string "" is considered as data and triggers MinLen attribute
			if (!Type.TypeInspector.IsNullOrUndefined(value) && (typeof value != "string" ||  !String.IsNullOrEmpty(value)))
			{
				///dic[name] = value;
				// create hierarchy
				Calysto.DataBinder.SetValue(dic, name, value);
			}

		}
		return dic;
	};

	/**
	 * Bind data from dataObj to any element (not just inputs) with 'name' or 'id' attributes named as dataObj properties or asp.net style names with pp$aa$propName<br/>
		If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
	 * @param {any} dataObj
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} alwaysSet?
	 */
	export function MvcDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean)
	{
		/// <summary>
		/// Bind data from dataObj to any element (not just inputs) with 'name' or 'id' attributes named as dataObj properties or asp.net style names with pp$aa$propName<br/>
		/// If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		/// If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		/// If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
		/// </summary>
		/// <param name="dataObj" type="object">object with values</param>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="alwaysSet" optional="true">if true, always set element value, if value doesn't exist in dataObj, use null value</param>

		dataObj = dataObj || {};
		// populate controls
		// allow multiple elements with the same name or id
		// asp.net style name = pp$aa$propName
		// asp.net style id = pp_aa_propName

		$$calysto(containerSelector || document.documentElement).Query("*, //*").ForEach((el: any) =>
		{
			var name;

			if (el && (name = el.name))
			{
				if (!!name)
				{
					// element name many be full property path prop1.prop2.prop3
					let box1 = new BoxValue();
					let hasProperty = Calysto.DataBinder.TryGetValue(dataObj, name, box1);

					// required condition: name && name.length > 0
					if (alwaysSet || hasProperty)
					{
						if (!DeserializeElement(el, box1.GetValue()))
						{
							throw new Error("Element with name=" + name + " is not valid for data binding");
						}
					}
				}
			}
		});
	};

	//#endregion

	//#region CalystoSerialize & CalystoDeserialize

	/**
	 * Serialize values from input elements with 'calysto-id' attribute into dictionary by creating properties named as calysto-id attribute values.<br/>
		Property names may by compound path, eg. prop1.prop2.prop3, it creates nested object using Calysto.DataBinder.SetValue(...).<br/>
		If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} trimStrings?
	 * @param {TResult} refOutDataObj?
	 * @returns
	 */
	export function CalystoSerialize<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult
	{
		/// <summary>
		/// Serialize values from input elements with 'calysto-id' attribute into dictionary by creating properties named as calysto-id attribute values.<br/>
		/// Property names may by compound path, eg. prop1.prop2.prop3, it creates nested object using Calysto.DataBinder.SetValue(...).<br/>
		/// If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		/// If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
		/// </summary>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="trimStrings" optional="true">if true, trim text values</param>
		/// <param name="refOutDataObj" optional="true">update values into this refOutDataObj</param>

		// important: serialize input, select, textarea only, do not serialize other html elements bezause there may be duplicated ids
		let arr = $$calysto(containerSelector || document.documentElement)
			.Query("[" + Calysto.AttrName.CalystoId + "=*], //[" + Calysto.AttrName.CalystoId + "=*]").Query("input, textarea, select, [" + Calysto.AttrName.CalystoGetter + "=*]")
			.Distinct()
			.ToArray();

		let dic: TResult = refOutDataObj || <TResult>{};
		for (let n = 0; n < arr.length; n++)
		{
			let el = arr[n];
			let result: SerializedElementType;
			let name;
			let value;
			// if we're using existing object to populate with values, allow previous values to exist in dataObj
			let createArrayValues = !!el.getAttribute(Calysto.AttrName.CalystoIsGroup); 
			// we may have multiple input elements with the same calysto-id attribute value, than create array with their values
			let allowDuplicates = createArrayValues || (!!refOutDataObj); 

			result = <SerializedElementType>SerializeElement(el);

			// if we're populating existing refOutDataObj, we have to set it's value even if it is empty or has no value, 
			// this way we update the existing value with new one when the new one is empty or null or ""
			if (!!refOutDataObj || result.HasValue)
			{
				name = el.getAttribute(Calysto.AttrName.CalystoId);
				value = result.Value;
				if (!name) continue;
			}
			else
			{
				continue;
			}

			if (trimStrings && typeof (value) == "string")
			{
				value = (value || "").Trim();
			}

			// name can be property path: prop1.prop2.prop3, only in calysto-id="prop1.prop2.prop3", MVC or Forms doesnt support it
			let refOut = new BoxValue<any>();

			if (!allowDuplicates && Calysto.DataBinder.TryGetValue(dic, name, refOut))
			{
				throw new Error("Error in CalystoSerialize, property " + name + " already exists.");
			}

			if (createArrayValues)
			{
				Calysto.DataBinder.SetValue(dic, name, [refOut.GetValue()]);
			}
			else
			{
				Calysto.DataBinder.SetValue(dic, name, value);
			}
		}
		return dic;
	};

	/**
	 * Bind data from dataObj to any element with 'calysto-id' attribute named as dataObj properties.<br/>
		Property names may by compound path, eg. prop1.prop2.prop2, value is read using Calysto.DataBinder.TryGetValue(...).<br/>
		If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
	 * @param {any} dataObj
	 * @param {string | HTMLElement} containerSelector
	 * @param {boolean} alwaysSet?
	 */
	export function CalystoDeserialize(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean)
	{
		/// <summary>
		/// Bind data from dataObj to any element with 'calysto-id' attribute named as dataObj properties.<br/>
		/// Property names may by compound path, eg. prop1.prop2.prop2, value is read using Calysto.DataBinder.TryGetValue(...).<br/>
		/// If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		/// If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		/// If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
		/// </summary>
		/// <param name="dataObj" type="object">object with values</param>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="alwaysSet" optional="true">if true, always set element value, if value doesn't exist in dataObj, use default value</param>

		// populate controls
		// allow multiple calysto-id=name with the same name

		if (dataObj)
		{
			$$calysto(containerSelector || document.documentElement).Query("[" + Calysto.AttrName.CalystoId + "=*], //[" + Calysto.AttrName.CalystoId + "=*]").Distinct().ForEach((el) =>
			{
				// componud name path may be used, eg. calysto-id="Data.Names.0.Age", that is why we use Calysto.DataBinder.TryGetValue
				let name = el.getAttribute(Calysto.AttrName.CalystoId);

				// required condition: name && name.length > 0
				let refObj = new BoxValue<any>();

				if (name && (Calysto.DataBinder.TryGetValue(dataObj, name, refObj)) || alwaysSet)
				{
					if (el["type"] == "text" && el.getAttribute(Calysto.AttrName.CalystoIsGroup))
					{
						// for check and radio inputs, we have to find p
						// can not deserialize value if element has calysto-isgroup attribute, 
						// means there are multiple elements with the same calysto-id attribute
						throw new Error("NotImplemented: deserialization to element with calysto-isgroup attribute");
					}
					else if (!DeserializeElement(el, refObj.GetValue())) // if value doesn't exists in dataObj[name], it will set default value to element
					{
						throw new Error("Element with calysto-id=" + name + " is not valid for data binding");
					}
				}
			});
		}
	};

	//#endregion

	//#region CalystoSerialize2 & CalystoDeserialize2

	////type TResult =
	////	{
	////		[p: string]: SerializedElement
	////	};

	export function CalystoSerialize2<TResult>(containerSelector: string | HTMLElement, trimStrings?: boolean, refOutDataObj?: TResult): TResult
	{
		/// <summary>
		/// Serialize values from input elements with 'calysto-id' attribute into dictionary by creating properties named as calysto-id attribute values.<br/>
		/// Property names may by compound path, eg. prop1.prop2.prop3, it creates nested object using Calysto.DataBinder.SetValue(...).<br/>
		/// If 'calysto-type' attribute exists, data is converted to calysto-type type. For supported calysto-type values, see: Calysto.Type.DotNetTypeName<br/>
		/// If 'calysto-getter' attribute exists with lambda expression, it will be used to get value from element. this inside lamba is element.
		/// </summary>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="trimStrings" optional="true">if true, trim text values</param>
		/// <param name="refOutDataObj" optional="true">update values into this refOutDataObj</param>

		// important: serialize input, select, textarea only, do not serialize other html elements because there may be duplicated ids
		let arr = $$calysto(containerSelector || document.documentElement)
			.Query("[" + Calysto.AttrName.CalystoId + "=*], //[" + Calysto.AttrName.CalystoId + "=*]")
			.Query("input, textarea, select, [" + Calysto.AttrName.CalystoGetter + "=*]")
			.Distinct()
			.ToArray();

		let allowDuplicates = !!refOutDataObj; // if we're using existing object to populate with values, allow previous values to exist in dataObj
		let dic: TResult = refOutDataObj || <TResult>{};
		for (let n = 0; n < arr.length; n++)
		{
			let element = arr[n];
			let calystoid = <string>element.getAttribute(Calysto.AttrName.CalystoId);
			let calystouid = <string>element.getAttribute(Calysto.AttrName.CalystoUid);
			if (!calystouid)
			{
				element.setAttribute(Calysto.AttrName.CalystoUid, (calystouid = Calysto.Utility.Generators.GeneratePassword(20)));
			}

			let res = SerializeElement(element);

			let dic2 = <SerializedElement>{
				CalystoId: calystoid,
				CalystoUid: calystouid,
				Value: res && res.HasValue ? res.Value : undefined,
				Enabled: $$calysto(element).WhereEnabled(true).Any(),
				Visible: $$calysto(element).WhereVisible(true).Any(),
				Name: Calysto.Utility.Html.ExtractAspNameOrId(element["name"]),
				Id: Calysto.Utility.Html.ExtractAspNameOrId(element.id),
				Checked: element["checked"],
				HtmlName: element["name"],
				HtmlValue: element["value"],
				HtmlId: element.id,
				HtmlTagName: element.tagName,
				HtmlType: element["type"]
			};

			// name can be property path: prop1.prop2.prop3, only in calysto-id="prop1.prop2.prop3", MVC or Forms doesnt support it

			let refOut = new BoxValue<any>();
			if (!allowDuplicates && Calysto.DataBinder.TryGetValue(dic, calystoid, refOut))
			{
				throw new Error("Error in CalystoSerialize2, property " + calystoid + " already exists.");
			}

			if (trimStrings && typeof (dic2.Value) == "string")
			{
				dic2.Value = (dic2.Value || "").Trim();
			}

			Calysto.DataBinder.SetValue(dic, calystoid, dic2);
		}
		return dic;
	}

	export function CalystoDeserialize2(dataObj: any, containerSelector: string | HTMLElement, alwaysSet?: boolean)
	{
		/// <summary>
		/// Bind data from dataObj to any element with 'calysto-id' attribute named as dataObj properties.<br/>
		/// Property names may by compound path, eg. prop1.prop2.prop2, value is read using Calysto.DataBinder.TryGetValue(...).<br/>
		/// If 'calysto-format' attribute exists, data is formated into string using Calysto.Type.ToStringFormated(val, format).<br/>
		/// If 'calysto-type' attribute doesn't exist, it resolved from current data value and is added to element.<br/>
		/// If 'calysto-setter' attribute exits with lambda expression, it is used to set value to element. this inside lambda is element.
		/// </summary>
		/// <param name="dataObj" type="object">object with values</param>
		/// <param name="containerSelector" optional="true">if not provided, default: document</param>
		/// <param name="alwaysSet" optional="true">if true, always set element value, if value doesn't exist in dataObj, use default value</param>

		// populate controls
		// allow multiple calysto-id=name with the same name

		if (dataObj)
		{
			$$calysto(containerSelector || document.documentElement).Query("[" + Calysto.AttrName.CalystoId + "=*], //[" + Calysto.AttrName.CalystoId + "=*]").Distinct().ForEach((el) =>
			{
				// componud name path may be used, eg. calysto-id="Data.Names.0.Age", that is why we use Calysto.DataBinder.TryGetValue
				var name = el.getAttribute(Calysto.AttrName.CalystoId);
				// required condition: name && name.length > 0
				var refOut = new BoxValue<SerializedElement>();
				if (name && (Calysto.DataBinder.TryGetValue(dataObj, name, refOut)) || alwaysSet)
				{
					let item = refOut.GetValue();
					let val1 = item ? item.Value : undefined;
					if (!DeserializeElement(el, val1)) // if value doesn't exists in dataObj[name], it will set default value to element
					{
						throw new Error("Element with calysto-id=" + name + " is not valid for data binding");
					}
					else if (item)
					{
						// deserialize other values
						$$calysto(el)
							.SetVisible(!!item.Visible)
							.SetEnabled(!!item.Enabled)
							.SetProperty("checked", !!item.Checked);
					}
				}
			});
		}
	}
	//#endregion

	//#region ToMvcModelState

	export function ToMvcModelState<TModel>(containerSelector: string | HTMLElement)
	{
		let state = new Calysto.Web.UI.Direct.CalystoMvcModelState<TModel>();
		state.Raw = MvcSerialize(containerSelector, true);
		state.RootSelector = Calysto.Utility.Dom.EnsureElementId(containerSelector);
		return state;
	}

	//#endregion

}

