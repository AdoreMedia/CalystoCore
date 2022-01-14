/// <reference path="Utility.Dom.Style.ts" />

namespace Calysto.Utility.Dom
{
	export class ScrollHandler
	{
		private _currDeltaY = 0;
		private _currDeltaX = 0;

		public HandleScroll(sender: HTMLDivElement, ev: WheelEvent)
		{
			//////#if DEBUG
			////if (Calysto.Core.IsDebugDefined)
			////{
			////	console.log(ev);
			////}
			//////#endif
			if (ev.deltaY || ev.deltaX)
			{
				//WheelEvent.deltaMode Read only
				//Returns an unsigned long representing the unit of the delta values scroll amount. Permitted values are:
				//DOM_DELTA_PIXEL	0x00	The delta values are specified in pixels.
				//DOM_DELTA_LINE	0x01	The delta values are specified in lines.
				//DOM_DELTA_PAGE	0x02	The delta values are specified in pages.

				let dy = ev.deltaY || 0;
				let dx = ev.deltaX || 0;

				if (ev.shiftKey)
				{
					let t1 = dy;
					dy = dx;
					dx = t1;
				}

				switch (ev.deltaMode)
				{
					case 0: // pixels, chrome
						this._currDeltaY += dy;
						this._currDeltaX += dx;
						break;
					case 1: // lines, firefox
						this._currDeltaY += dy * 20; // 1 line = 20px, average
						this._currDeltaX += dx * 20; // 1 line = 20px, average
						break;
					case 2:
						this._currDeltaY += dy * window.screen.height;
						this._currDeltaX += dx * window.screen.height;
						break;
				}

				if (Math.abs(this._currDeltaY) > 10)
				{
					// scroll has no deltaY
					// apply scroll to sender
					sender.scrollTop += this._currDeltaY;
					this._currDeltaY = 0;
				}

				if (Math.abs(this._currDeltaX) > 10)
				{
					// scroll has no deltaY
					// apply scroll to sender
					sender.scrollLeft += this._currDeltaX;
					this._currDeltaX = 0;
				}
			}
		}
	}

	export enum NodeTypeEnum
	{
		ELEMENT_NODE = 1,
		ATTRIBUTE_NODE = 2,
		TEXT_NODE = 3,
		CDATA_SECTION_NODE = 4,
		ENTITY_REFERENCE_NODE = 5,
		ENTITY_NODE = 6,
		PROCESSING_INSTRUCTION_NODE = 7,
		COMMENT_NODE = 8,
		DOCUMENT_NODE = 9,
		DOCUMENT_TYPE_NODE = 10,
		DOCUMENT_FRAGMENT_NODE = 11,
		NOTATION_NODE = 12
	}

	export function TrimSpaces(str: string)
	{
		if (!str) { return str; }

		return (str || "").replace(new RegExp("(^[\\s]+)|([\\s]+$)", "ig"), "");
	}

	//#region DOM utility methods

	/**
	 * Return element id. If doesn't exist, will create new id.
	 * @param el
	 */
	export function EnsureElementId(el: string | HTMLElement)
	{
		if (typeof el == "string")
			return el;
		else if (el.id)
			return el.id;
		else
			return (el.id = Calysto.Utility.Generators.GenerateLabel(20));
	}

	/**
	 * Test if element is visible in DOM, using style.display and offsetHeight and offsetWidht and style.visibility
	 * @param element
	 */
	export function IsElementVisible(element: Node)
	{
		var el = <HTMLElement>element;

		return !!(el && el.parentNode
			&& (el.offsetWidth > 0 && el.offsetHeight > 0)
			&& el.style && el.style.display != "none"
			&& el.style && el.style.visibility != "hidden"
		);
	}

	/**
	 * Test if element and it's ancestors are visible in DOM.
	 * @param element
	 */
	export function IsDomTreeVisible(element: Node)
	{
		let tmp = <HTMLElement>element;
		
		let childIsAbsolute = false;
		do
		{
			if (tmp && tmp.parentNode)
			{
				// if element has absolute or fixed position, it's parent may have offset dimensions are 0, and element is still visible
				// or better to say: if childIsAbsolute, than current tmp element may have offset dimensions 0, and child is still visible
				let vis1 = (childIsAbsolute || (tmp.offsetWidth > 0 && tmp.offsetHeight > 0))
					&& tmp.style && tmp.style.display != "none"
					&& tmp.style && tmp.style.visibility != "hidden";

				if (!vis1)
					return false;

				let style1 = Style.GetComputedStyleDeclaration(tmp);
				childIsAbsolute = style1.position == "absolute" || style1.position == "fixed";
			}
		}
		while (
			tmp
			&& tmp != <any> document
			&& tmp.tagName?.toLowerCase() != "html" // kad se gleda u iframeu, iframe.document != self.document
			&& (tmp = <HTMLElement> tmp.parentNode)
		)
		{ }

		return true;
	}

	/**
	 * Returns true if el is in DOM. Traverse complete DOM tree from element to document root.
	 * @param element
	 */
	export function IsElementInDom(element: Node)
	{
		// seems that offsetParent property have elements with real dimensions and real visibility in dom, e.g. div element
		// link, #text nodes etc. don't have offsetParent property, or is null or undefined
		// offsetParent is quicker way to traverse up on the DOM tree, but we always have to use parentNode as backup
		var tmp: any = element;
		while (
			tmp
			&& tmp != document
			&& (tmp = (tmp.offsetParent || tmp.parentNode))
		)
		{
			// use offsetParent to find offset ancestor, it is less iterations thant with parentNode which finds first parent
		}

		return tmp == document; // el is in dom if tmp == document
	};

	/**
	 * Test if element is child or descendant of parent or ancestor.
	 * @param element
	 * @param parent
	 */
	export function IsDescendant(element: Node, parent: Node)
	{
		var el: any = element;

		if (!el || !parent || el == parent)
		{
			return false;
		}
		while (el && el != parent)
		{
			try { el = el.parentNode; } catch (e) { return false; }
		}
		return el == parent;
	};

	/**
	 * Get innerText or innerHtml with removed html tags or nodeValue.
	 * @param element
	 */
	export function GetInnerText(element: Node)
	{
		var el: any = element;

		if (!el) return "";

		var val = "innerText" in el ? el.innerText :
			"innerHTML" in el ? Calysto.Utility.Html.RemoveHtmlTags(el.innerHTML, "") :
				"nodeValue" in el ? el.nodeValue :
					el.value || ""; // force to return "" if all values are empty or null

		return val + ""; // make sure it is string
	}

	export function HasTagName(obj: Element, tagName: string)
	{
		if (obj && obj.tagName && typeof obj.tagName == "string" && typeof tagName == "string" && obj.tagName.toLowerCase() == tagName.toLowerCase())
		{
			return true;
		}
		return false;
	}

	//#endregion

	//#region positions calculation: element, page, viewport position

	var _fixedDiv: HTMLDivElement;

	export function GetViewportDiv()
	{
		if (!_fixedDiv)
		{
			// more secure way is to create fixed div and mesure it's dimmension: <div style='position:fixed;top:0;left:0;bottom:0;right:0;z-index:-100000;'></div>
			var tmp = document.createElement("div");
			tmp.innerHTML = "<div id='calystoViewportSizeDiv' style='position:fixed;top:0;left:0;bottom:0;right:0;z-index:-10000000;'></div>";
			_fixedDiv = <HTMLDivElement>tmp.childNodes[0];
			(document.body || document.documentElement).appendChild(_fixedDiv);
		}
		return _fixedDiv;
	}

	/**
	 * Get element's position relative to visible viewport. {top:n, left:n, width:n, height:d}.
	 * Position is measured from top left corner. 
	 * Bottom and right values are confusing. It is value from top left corner to the bottom or right side of element, not from bottom of the page.
	 * @param element
	 */
	export function GetElementScreenPosition(element: HTMLElement)
	{
		var tmpEl = <HTMLElement>element;
		
		if (tmpEl.getBoundingClientRect)
		{
			return tmpEl.getBoundingClientRect(); // getBoundingClientRect() returns element position on screen
		}
		else
		{
			var el: HTMLElement = element;

			var result = {
				left: 0,
				top: 0,
				bottom: 0,
				right: 0,
				width: tmpEl.offsetWidth,
				height: tmpEl.offsetHeight
			};

			do
			{
				result.left += (tmpEl.offsetLeft || 0) - (tmpEl.scrollLeft || 0); // document nema offsetLeft i scrollLeft, zapravo je undefined i NaN, zato || 0
				result.top += (tmpEl.offsetTop || 0) - (tmpEl.scrollTop || 0);

				if (tmpEl.style && (tmpEl.style.position == "fixed" || Style.GetComputedStyleDeclaration(tmpEl).position == "fixed"))
				{
					// if it is fixed element, take any of: offsetLeft i offsetTop i scrollLeft i scrollTop and stop climbing up in DOM
					break;
				}
				else
				{
					tmpEl = <HTMLElement>(tmpEl.offsetParent || tmpEl.parentNode); // preferiramo offsetParent, body ima samo parentNode
				}
			}
			while (tmpEl);

			return result;
		}
	};

	/**
	 * Get element's absolute position on page. {top:n, left:n, width:n, height:d}.
	 * @param element
	 */
	export function GetElementPagePosition(element: HTMLElement)
	{
		var pos = GetElementScreenPosition(element);

		// add page scrolls
		var page = GetPageDimensions();

		return {
			left: pos.left + page.scrollLeft,
			top: pos.top + page.scrollTop,
			width: pos.width,
			height: pos.height
		};

	}

	export function GetScrollableAncestors(el: HTMLElement)
	{
		let arr: HTMLElement[] = [];
		let tmp1 = el;
		let stop = 0;
		let sleft = 0;
		while ((tmp1 = <HTMLElement>tmp1.parentNode))
		{
			stop = tmp1.scrollTop;
			sleft = tmp1.scrollTop;

			if (tmp1.scrollTop > 0 || tmp1.scrollTop > 0)
			{
				arr.push(tmp1);
				continue;
			}

			++tmp1.scrollTop;
			if (tmp1.scrollTop == stop + 1)
			{
				--tmp1.scrollTop;
				arr.push(tmp1);
				continue;
			}

			--tmp1.scrollTop;
			if (tmp1.scrollTop == stop - 1)
			{
				++tmp1.scrollTop;
				arr.push(tmp1);
				continue;
			}

			++tmp1.scrollLeft;
			if (tmp1.scrollLeft == sleft + 1)
			{
				--tmp1.scrollLeft;
				arr.push(tmp1);
				continue;
			}

			--tmp1.scrollLeft;
			if (tmp1.scrollLeft == sleft - 1)
			{
				++tmp1.scrollLeft;
				arr.push(tmp1);
				continue;
			}

		}
		return arr;
	}

	export interface PageDimension
	{
		scrollLeft: number;
		scrollTop: number;
		scrollWidth: number;
		scrollHeight: number;
		clientWidth: number;
		clientHeight: number;
	}

	/**
	 * Get current html page scroll dimensions as object: {scrollLeft:.., scrollTop:..., scrollWidth:..., scrollHeight:..., clientWidth:..., clientHeight:...}
	 * scrollHeight: full height including scroll
	 * scrollWidth: full width including scroll
	*/
	export function GetPageDimensions()
	{
		var dim = <PageDimension>
			{
				scrollLeft: Math.max(document.body.scrollLeft, document.documentElement.scrollLeft, window.pageXOffset || 0), // scroll position from left, pageXOffset is NaN on IE, max(1,500,40, NaN) is NaN
				scrollTop: Math.max(document.body.scrollTop, document.documentElement.scrollTop, window.pageYOffset || 0), // scroll position from top

				scrollWidth: Math.max(document.body.scrollWidth, document.documentElement.scrollWidth), // full width including scroll
				scrollHeight: Math.max(document.body.scrollHeight, document.documentElement.scrollHeight), // full height including scroll

				clientWidth: GetViewportDiv().offsetWidth, // visible size, window.innerHeigh includes scrollbar height, so better use ViewportDiv instead which excludes scrollbar width or height
				clientHeight: GetViewportDiv().offsetHeight // visible size
			};

		return dim;
	}

	class ElementViewPortPosition
	{
		private _element: HTMLElement;

		public constructor(el: HTMLElement)
		{
			this._element = el;
		}

		public CalculatePoints()
		{
			let rect = GetElementScreenPosition(this._element);
			let wp = GetElementScreenPosition(GetViewportDiv());

			return {
				topLine:
				{
					name: "TL-TR-horizontal-rect-line",
					vDistance: rect.top > (wp.top + wp.height)
						? rect.top - (wp.top + wp.height) // > 0, TL-TR-horizontal-rect-line je ispod wp-a
						: rect.top < wp.top
							? rect.top - wp.top // < 0, TL-TR-horizontal-rect-line je iznad wp-a
							: 0 // unutar wp-a
				},
				rightLine:
				{
					name: "TR-BR-vertical-rect-line",
					hDistance: (rect.left + rect.width) > (wp.left + wp.width)
						? (rect.left + rect.width) - (wp.left - wp.width) // > 0, TR-BR-vertical-rect-line je desno od wp-a
						: (rect.left + rect.width) < wp.left
							? (rect.left + rect.width) - wp.left // < 0, TR-BR-vertical-rect-line je lijevo od wp-a
							: 0 // unutar wp-a
				},
				bottomLine:
				{
					name: "BL-BR-horizontal-rect-line",
					vDistance: (rect.top + rect.height) > (wp.top + wp.height)
						? (rect.top + rect.height) - (wp.top + wp.height) // < 0, BL-BR-horizontal-rect-line je ispod wp-a
						: (rect.top + rect.height) < wp.top
							? (rect.top + rect.height) - wp.top // < 0, BL-BR-horizontal-rect-line je iznad wp-a
							: 0 // unutar wp-a
				},
				leftLine:
				{
					name: "TL-BL-vertical-rect-line",
					hDistance: rect.left > (wp.left + wp.width)
						? rect.left - (wp.left - wp.width) // > 0, TL-BL-vertical-rect-line je desno od wp-a
						: rect.left < wp.left
							? rect.left - wp.left // < 0, TL-BL-vertical-rect-line je lijevo od wp-a
							: 0 // unutar wp-a
				}
			};
		}

		/** Vertical distance from viewport, above or below, absolute value.
		 * 0 means it is in viewport. */
		public VerticalDistance()
		{
			let points = this.CalculatePoints();
			return Math.min(Math.abs(points.topLine.vDistance), Math.abs(points.bottomLine.vDistance));
		}

		/** Horizontal distance from viewport, left or right, absolute value. 
		 * 0 means it is in viewport. */
		public HorizontalDistance()
		{
			let points = this.CalculatePoints();
			return Math.min(Math.abs(points.leftLine.hDistance), Math.abs(points.rightLine.hDistance));
		}

		public IsInViewportVertical(allowPartial?: boolean)
		{
			let points = this.CalculatePoints();
			let isTop = Math.abs(points.topLine.vDistance) === 0;
			let isBottom = Math.abs(points.bottomLine.vDistance) === 0;
			return (isTop && isBottom) || (!!allowPartial && (isTop || isBottom));
		}

		public IsInViewportHorizontal(allowPartial?: boolean)
		{
			let points = this.CalculatePoints();
			let isLeft = Math.abs(points.leftLine.hDistance) === 0;
			let isRight = Math.abs(points.rightLine.hDistance) === 0;
			return (isLeft && isRight) || (!!allowPartial && (isLeft || isRight));
		}
	}

	/**
	* Calculate element abslute distance from viewport.
	* @param el
	*/
	export function GetElementViewportPosition(el: HTMLElement)
	{
		return new ElementViewPortPosition(el);
	}

	/**
	 * Test if element is in visible viewport.
	 * @param el
	 * @param onlyPart if true, at least 1 dimension must be included in viewport, if false, all dimensions must be included
	 */
	export function IsElementInViewport(el: HTMLElement, onlyPart: boolean)
	{
		var pos = GetElementScreenPosition(el);
		var viewport = GetElementScreenPosition(GetViewportDiv());

		var top = pos.top >= viewport.top && pos.top <= (viewport.top + viewport.height);
		var bottom = (pos.top + pos.height) >= viewport.top && (pos.top + pos.height) <= (viewport.top + viewport.height);
		var left = pos.left >= viewport.left && pos.left <= (viewport.left + viewport.width);
		var right = (pos.left + pos.width) >= viewport.left && (pos.left + pos.width) <= (viewport.left + viewport.width);

		if (onlyPart)
		{
			var w = pos.width <= viewport.width ? (left || right) : ((left && !right) || (!left && right) || (!left && !right && pos.left < viewport.left && (pos.left + pos.width) > viewport.left));
			var h = pos.height <= viewport.height ? (top || bottom) : ((top && !bottom) || (!top && bottom) || (!top && !bottom && pos.top < viewport.top && (pos.top + pos.height) > viewport.top));
			return w && h;
		}
		else
		{
			return top && bottom && left && right;
		}
	}

	//#endregion

	//#region Clip methods

	export type ClipDimension = {
		match?: RegExpMatchArray,
		useMargins?: boolean,
		top: number,
		right: number,
		bottom: number,
		left: number
	};

	/**
	 * Margins is Calysto specific, defines margin from top, right, bottom, left.
	 * Rect is css standard, defined as left, right: from left, top, bottom: from top.
	 * @param el
	 * @param clipStyleString
	 */
	export function ParseClip(el: HTMLElement, clipStyleString: string)
	{
		var m = clipStyleString.match(new RegExp("(rect|margins)[\\(][\\s]*([\\d\\+\\-px\\%]+)[\\s]+([\\d\\+\\-px\\%]+)[\\s]+([\\d\\+\\-px\\%]+)[\\s]+([\\d\\+\\-px\\%]+)[\\s]*[\\)]"));
		m = m || <RegExpMatchArray><any>[];

		return <ClipDimension>({
			match: m,
			useMargins: m && m[1] == "margins",
			top: parseFloat(m[2]) || 0,
			right: m[3] ? parseFloat(m[3]) : el.offsetWidth,
			bottom: m[4] ? parseFloat(m[4]) : el.offsetHeight,
			left: parseFloat(m[5]) || 0
		});
	}

	/**
	 * Get element's current clip value.
	 * clip: rect(0px 10px 100px 20px );
	 * clip is always in px, all 4 values has to be set: top right bottom left
	 * @param el
	 */
	export function GetClip(el: HTMLElement)
	{
		return ParseClip(el, Style.GetComputedStyle(el, "clip").StyleValue);
	}

	/** define delta dimensions, ex: +=50 */
	type ClipDeltaDimensions = {
		top: string,
		right: string,
		bottom: string,
		left: string,
		useMargins?: boolean
	};

	/**
	 * Calculate clip. Used with animator.
	 * @param el
	 * @param newDim
	 */
	export function CalculateClip(el: HTMLElement, newDim: string | ClipDeltaDimensions)
	{
		// Calysto clip value is different from css clip: has to be provided as string with 4 values "from top, from right, from bottom, from left", default unit is px, but % may be used
		// var arr = item.finalValue.split(new RegExp("[, ]")).AsEnumerable().Where(function (o) { return !!o; }).ToArray();
		// var final = { top: fromTop, right: fromRight, bottom: fromBottom, left: fromLeft };

		// css clip: rect(0px 10px 100px 20px );
		// clip is always in px, all 4 values has to be set: top right bottom left
		var curr = GetClip(el);
		var deltaDim: ClipDeltaDimensions;

		if (typeof (newDim) == "string")
		{
			var mm = newDim.match(new RegExp("[\\d\\+\\-px\\%]+", "g"));
			mm = mm || <RegExpMatchArray><any>[];
			// must use string values to include % if exists
			deltaDim = {
				top: mm[0],
				right: mm[1],
				bottom: mm[2],
				left: mm[3],
				useMargins: newDim.indexOf("margins") >= 0
			};
		}
		else
		{
			deltaDim = newDim
		}

		if (deltaDim.useMargins)
		{
			return <ClipDimension>({
				top: Style.CalculateNumericValue(curr.top, deltaDim.top),
				right: el.offsetWidth - Style.CalculateNumericValue(curr.right, deltaDim.right),
				bottom: el.offsetHeight - Style.CalculateNumericValue(curr.bottom, deltaDim.bottom),
				left: Style.CalculateNumericValue(curr.left, deltaDim.left)
			});
		}
		else
		{
			return <ClipDimension>({
				top: Style.CalculateNumericValue(curr.top, deltaDim.top),
				right: Style.CalculateNumericValue(curr.left, deltaDim.right),
				bottom: Style.CalculateNumericValue(curr.top, deltaDim.bottom),
				left: Style.CalculateNumericValue(curr.left, deltaDim.left)
			});
		}
	}

	/**
	 * Set clip. Not implemented.
	 * @param el
	 * @param clipValue e.g. already parsed into object or "margins(100% 0 0 0)" or "rect:(10px 100px 50px 53px)"
	 */
	export function SetClip(el: HTMLElement, clipValue: string | { top: number, right: number; bottom: number; left: number; useMargins?: boolean })
	{
		// this will add position:absolute to an element because clip requires absolute position
		// Calysto clip: "margins(fromTop  fromRight  fromBottom  fromLeft)"; // units none, px, %, +=...%, eg. .ToAnimator({ clip: "margins(100% 0 0 0)", marginTop: "-100%" })
		// css clip: "rect(fromTop fromLeftToRight fromTopToBottom fromLeft)// eg. ss clip: rect(0px 10px 100px 20px ); // always in px
		// Calysto clip value is different from css clip: has to be provided as string with 4 values "from top, from right, from bottom, from left", default unit is px, but % may be used

		throw new Error("Not implemeted: SetClip()");
		//if (typeof (clipValue) == "string")
		//{
		//	clipValue = this.CalculateClip(el, clipValue);
		//}
		//////console.log(clipValue);

		//// css clip: rect(0px 10px 100px 20px );
		//var cc = clipValue;
		//el.style.clip = "rect(" + cc.top + "px " + cc.right + "px " + cc.bottom + "px " + cc.left + "px" + ")";
		//el.style.position = "absolute";
		////console.log(el.style.clip);
	}

	//#endregion

	//#region CSS class methods

	export function HasClass(obj: Element, cls: string)
	{
		return !!(obj && obj.className && cls && (' ' + obj.className + ' ').indexOf(' ' + (cls) + ' ') >= 0);
	}

	/**
	 * Add css class, prevent duplicates.
	 * @param obj
	 * @param cls
	 */
	export function AddClass(obj: Element, cls: string)
	{
		if (cls && obj)
		{
			RemoveClass(obj, cls); // to prevent duplicates

			obj.className = TrimSpaces(obj.className + " " + cls);
		}
	}

	/**
	 * Remove class name or multiple class names.
	 * @param obj
	 * @param cls may contain multiple names separated by space
	 */
	export function RemoveClass(obj: Element, cls: string)
	{
		if (cls && obj)
		{
			// make sure className is not substring of some other className
			// replace with space " " if class is inside other classes: cls1 cls2 cls3, replace " " + cls2 + " " with " "
			var arr = cls.split(' ');
			for (var n = 0; n < arr.length; n++)
			{
				if (cls = arr[n])
				{
					obj.className = TrimSpaces((" " + obj.className + " ").replace(new RegExp(" " + cls + " ", "g"), " ")); // replace all matches of cls
				}
			}
		}
	}

	/**
	 * Set exact cls value, removing all previous values.
	 * @param obj
	 * @param cls
	 */
	export function SetClass(obj: Element, cls: string)
	{
		if (obj)
		{
			obj.className = TrimSpaces(cls) || "";
		}
	}

	export function ToggleClass(obj: Element, cls: string)
	{
		if (obj && "className" in obj && cls)
		{
			if (HasClass(obj, cls))
			{
				RemoveClass(obj, cls);
			}
			else
			{
				AddClass(obj, cls);
			}
		}
	}

	//#endregion



	//#region element attribute methods

	export function GetAttributeNode(element: HTMLElement, attrName: string): Attr | null
	{
		if (element && element.getAttributeNode)
		{
			return element.getAttributeNode(attrName);
		}
		return null;
	}

	/**
	 * Returns attribute value as string or null if there is no attribute defined.
	 * @param element
	 * @param attrName
	 */
	export function GetAttribute(element: Element, attrName: string): string | null
	{
		if (element && element.getAttribute)
		{
			return element.getAttribute(attrName);
		}
		return null;
	}

	export function SetAttribute(element: Element, attrName: string, value: string)
	{
		if (element && element.setAttribute)
		{
			element.setAttribute(attrName, value);
		}
	}

	export function RemoveAttribute(element: Element, attrName: string)
	{
		if (element && element.removeAttribute)
		{
			element.removeAttribute(attrName);
		}
	}

	export function HasAttribute(element: Element, attrName: string)
	{
		if (element)
		{
			// IE8< doesn't have .hasAttribute, so use .getAttribute
			if (element.hasAttribute)
			{
				return element.hasAttribute(attrName);
			}
			else if (element.getAttribute)
			{
				// if element has attribute, but has no value, getAttribute() returns ""
				// if element doesn't have attribute, return null
				return !(element.getAttribute(attrName) == null);
			}
		}
		return false;
	}

	//#endregion

	//#region element DOM manipulation
	
	export function SetEnabled(element: HTMLElement, enabled: boolean)
	{
		if (element)
		{
			if (enabled)
			{
				RemoveAttribute(element, "disabled");
				(<any>element).disabled = false;
			}
			else
			{
				// disable

				// if "a" tag is disabled, firefox and chrome ignores disabled attribute and acts like it is not disabled. We have to disable click event on element.
				// warning: don't manipulate click event, it will mess up with MS ajax events, just add disabled attribute

				SetAttribute(element, "disabled", "disabled");
				(<any>element).disabled = true;
			}
		}
	}

	export function CloneNodeIfHasParent(node: Node)
	{
		if (node && node.parentNode && node.cloneNode)
		{
			// if node has parent, clone it, full depth
			return node.cloneNode(true);
		}
		else
		{
			return node;
		}
	}

	export function RemoveNodeFromDom(node: Node)
	{
		if (node && node.parentNode)
		{
			node.parentNode.removeChild(node);
		}
	}

	/**
	 * Insert elements before refNode without cloning - remove elements from previous position.
	 * @param refNode
	 * @param elArray array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
	 */
	export function InsertBefore(refNode: Node, elArray: Node[])
	{
		if (refNode && refNode.parentNode)
		{
			if (elArray && elArray.length > 0)
			{
				// insert backwards because we have system .insertBefore() only, there is no .insertAfter()
				for (var n = elArray.length - 1; n >= 0; n--)
				{
					var n1 = elArray[n];
					if (n1 && refNode.parentNode)
					{
						////n1 = __dom.CloneNodeIfHasParent(n1); // NO!!! node has to be already cloned in the code before
						refNode.parentNode.insertBefore(n1, refNode);
						refNode = n1;
					}
				}
			}
		}
		else
		{
			throw new Error("InsertBefore failed, no parentNode");
		}
	}

	/**
	 * Replace refNode with new one. refNode has to be in DOM, otherwise it won't work with replaceWith method.
	 * @param refNode node which should be replaced
	 * @param elArray array of replacement elements
	 */
	export function ReplaceWith(refNode: Node, elArray: Node[])
	{
		InsertBefore(refNode, elArray);

		if (refNode && refNode.parentNode)
			refNode.parentNode.removeChild(refNode);
	}

	/**
	 * Insert elements after refNode without cloning - remove elements from previous position.
	 * @param refNode
	 * @param elArray array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
	 */
	export function InsertAfter(refNode: Node, elArray: Node[])
	{
		if (refNode && refNode.parentNode)
		{
			if (elArray && elArray.length > 0)
			{
				// insert element before, than swap nodes
				// insert backwards because we have system .insertBefore() only, there is no .insertAfter()
				for (var n = 0; n < elArray.length; n++)
				{
					var n1 = elArray[n];
					if (n1 && refNode.parentNode)
					{
						////n1 = __dom.CloneNodeIfHasParent(n1); // NO!!! node has to be already cloned before if required
						refNode.parentNode.insertBefore(n1, refNode);
						// swap nodes
						refNode.parentNode.insertBefore(refNode, n1);
						// change anchor node
						refNode = n1;
					}
				}
			}
		}
		else
		{
			throw new Error("InsertAfter failed, no parentNode");
		}
	}

	/**
	 * Replace parent's children with childrenArray.
	 * @param parent
	 * @param childrenArray If null, remove children only. Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
	 */
	export function ReplaceChildrenWith(parent: Node, childrenArray: Node[])
	{
		if (parent && parent.childNodes && parent.nodeType == 1)
		{
			// remove children first
			// parent.innerHTML = ""; // remove children first this way, or use removeChild()
			for (var n = parent.childNodes.length - 1; n >= 0; n--)
			{
				var nn = parent.childNodes[n];
				if (nn && nn.parentNode)
				{
					nn.parentNode.removeChild(nn);
				}
			}
			if (childrenArray && childrenArray.length > 0)
			{
				// add children
				for (var n = 0; n < childrenArray.length; n++)
				{
					////parent.appendChild(__dom.CloneNodeIfHasParent(childrenArray[n])); // NO!!! node has to be already cloned before if required
					parent.appendChild((childrenArray[n]));
				}
			}
		}
	}

	/**
	 * Add childrenArray to parent's children without cloning.
	 * @param parent
	 * @param childrenArray Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position
	 */
	export function AddChildren(parent: Node, childrenArray: Node[])
	{
		if (parent && parent.childNodes && parent.nodeType == 1)
		{
			if (childrenArray && childrenArray.length > 0)
			{
				for (var n = 0; n < childrenArray.length; n++)
				{
					var n1 = childrenArray[n];
					if (n1)
					{
						////n1 = __dom.CloneNodeIfHasParent(n1); // NO!!! node has to be already cloned before if required
						parent.appendChild(n1);
					}
				}
			}
		}
	};

	/**
	 * Insert childrenArray as first child to parent node without cloning.
	 * @param parent
	 * @param childrenArray Array of elements to insert, element are not cloned, so they will be removed from previous position and will be inserted into new position.
	 */
	export function InsertChildren(parent: Node, childrenArray: Node[])
	{
		if (parent && parent.childNodes)
		{
			if (parent.childNodes.length > 0)
			{
				InsertBefore(parent.childNodes[0], childrenArray);
			}
			else
			{
				AddChildren(parent, childrenArray);
			}
		}
	};

	export function ConvertToElementsArray(...args:any[]): HTMLElement[]
	{
		if (arguments.length == 0)
		{
			// args is null or empty
			// this is possible, e.g. .ReplaceChildren() without arguments, means should remove children without adding any new child
			return <any>[];
		}

		var res: any[] = [];
		var args = Calysto.Collections.SelectFlatten(arguments);
		for (var n1 = 0; n1 < args.length; n1++)
		{
			res.AddRange(ConvertSingleToElementsArray(args[n1]));
		}
		return res;
	}

	/**
	 * All arrays or enumerables are flattened and items are converted to HtlmElements array.
	 * @param htmlOrElement html, array of htmls, element or array or elements
	 */
	function ConvertSingleToElementsArray(htmlOrElement: any): HTMLElement[]
	{
		// possible values: value, null, undefined, e.g. inside .Select(...), if we don't want to create dom element, we're sending null instead of html or element
		if (Calysto.Type.TypeInspector.IsNullOrUndefined(htmlOrElement))
		{
			return <any>[];
		}

		if (typeof (htmlOrElement) == "number")
		{
			htmlOrElement = htmlOrElement + "";
		}

		if (typeof (htmlOrElement) == "string") // string
		{
			if (String.IsNullOrWhiteSpace(htmlOrElement))
			{
				return [];
			}
			var div = document.createElement("div"); // container div
			div.innerHTML = htmlOrElement;
			var items: HTMLElement[] = [];
			for (var n = 0; n < div.childNodes.length; n++)
			{
				var node1: HTMLElement = <any>div.childNodes[n];
				items.push(node1);
			}

			// must remove parentNode to remove container div from parentNode
			for (var n = 0; n < items.length; n++)
			{
				var node2 = items[n];
				if (node2 && node2.parentNode)
				{
					node2.parentNode.removeChild(node2);// to remove node.parentNode value
				}
			}
			return items;
		}
		else if (htmlOrElement.childNodes) // dom node
		{
			return [htmlOrElement];
		}

		throw new Error("Invalid type in ConvertSingleToElementsArray");
	}

	/**
	 * Center element into parent. Larger element is shrinked to fit into container.
	 * @param element
	 * @param crop false: fit larger dimension; true: overscan to fit smaller dimension
	 * @param enlarge true: smaller element is enlarged to fit into parent, false: smaller element is not enlarged
	 */
	export function CenterElementIntoParent(element: HTMLElement, crop?: boolean, enlarge?: boolean)
	{
		var el: any = element;

		if (!el || !el.parentNode || !(el.parentNode.clientHeight > 0 && el.parentElement.clientWidth > 0))
		{
			// on IE 11 in full screen ajax loader image has offsetHeight == 0 && offsetWidth == 0
			// if el is not visible or not in dom
			return;
		}

		/// <param name="shrink" type="Boolean" optional="true" default="true">true: larger element is shrinked to fit into parent, smaller element is not resized, false: larger element is not shrinked</param>
		var shrink = true; // always shrink larger element

		el.parentNode.style.overflow = "hidden";

		if (enlarge || shrink)
		{
			if ((el.tagName || "").toLowerCase() == "img")
			{
				el.removeAttribute("width");
				el.removeAttribute("height");
				el.style.width = "";
				el.style.height = "";
			}
			el.style.margin = "";
		}

		// width and height are needed to calcucate AR only
		var elWidth = el.__initialWidth || el.offsetWidth || el.clientWidth;
		var elHeight = el.__initialHeight || el.offsetHeight || el.clientHeight;

		var ar = elWidth / elHeight || 1; // if elHeight is 0

		var w = elWidth;
		var h = elHeight;

		// if fit always shring or enlarge to fit into parent
		// if not fit: shrink if larger; if smaller, don't change size

		if ((enlarge && (w < el.parentElement.clientWidth || h < el.parentElement.clientHeight)) || (shrink && (w > el.parentElement.clientWidth || h > el.parentElement.clientHeight)))
		{
			w = el.parentElement.clientWidth;
			h = w / ar;

			if ((crop && h < el.parentElement.clientHeight) || (!crop && h > el.parentElement.clientHeight))
			{
				h = el.parentElement.clientHeight;
				w = h * ar;
			}
		}

		// WARNING: el must be positioned as relative or nothing, set position:relative or nothing
		// position has to be set using margin-top and margin-left
		// don't use position:absolute, it won't work in Firefox and Android mobile

		el.style.position = "relative"; // user relative or none, works better on Firefox and Mobile
		el.style.top = "0";
		el.style.left = "0";
		el.style.bottom = "0";
		el.style.right = "0";
		el.style.padding = "0";
		el.style.margin = "0";

		w = Math.ceil(w); // ceil: round to upper level to avoid empty space around the picture
		h = Math.ceil(h);

		// parent must not have align='center', everything has to be default on parent
		var mleft = Math.floor((el.parentNode.clientWidth - w) / 2);
		var mtop = Math.floor((el.parentNode.clientHeight - h) / 2);
		// positioning with margin-top and margin-right doesn't require parent to have position:absolute, while positioning with top and left requires position:absolute on parent
		el.style.marginTop = mtop + "px";
		el.style.marginLeft = mleft + "px";
		el.style.width = w + "px";
		el.style.height = h + "px";
	}

	/**
	 * Select transform value of current elements and return new Calysto.List with string values.
	 * @param node
	 */
	export function SelectTransform(node: HTMLElement) : string
	{
		if (node && node.style)
		{
			return node.style.transform || (<any>node.style).msTransform || node.style.webkitTransform;
		}
		return "";
	}

	//#endregion

}

