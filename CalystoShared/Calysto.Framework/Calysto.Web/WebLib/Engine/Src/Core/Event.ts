interface ICalystoEventDefinition {
    element: Node;
    /** full name with namespaces after dot, eg: click.state-one.all-states, used for removal by name */
    eventFullName: string;
    /** event type string, without namespace, eg. click or focus */
    type: string;
    /** namespaces, array split by . */
    namespaces: string[];
	/** event handler function  function (ev) { } */
	callbackFunc : (this: HTMLElement, ev: Event) => void;
    /** function to remove event listener, function(){ } */
	removeEvent(): void;
    /** use capture, true/false */
    useCapture: boolean;
    /** passive, true/false */
    passive: boolean;
}

interface Node
{
	/** Events assigned using Calysto.Event.Attach()
	 * Event may be removed 
	*/
    $$calysto_EventsArr: ICalystoEventDefinition[];
}

namespace Calysto.Event
{
	var TAGNAMES = {
		'select': 'input',
		'change': 'input',
		'submit': 'form',
		'reset': 'form',
		'error': 'img',
		'load': 'img',
		'abort': 'img'
	};

	export function IsSupported(eventType: string)
	{
		/// <summary>
		/// Test if event name is supported by the browser.
		/// </summary>
		/// <param name="eventType" type="String">event name without 'on'</param>
		/// <returns type="Boolean"></returns>
		if (eventType.indexOf("on") == 0) eventType = eventType.substr(2);
		switch (eventType)
		{
			case "hover":
				eventType = "mouseover";
				break;
			case "hout":
				eventType = "mouseout";
				break;
			case "enterKey":
			case "escKey":
				return true;
		}

		var el = document.createElement(TAGNAMES[eventType] || 'div');
		eventType = 'on' + eventType;
		var isSupported = (eventType in el);
		if (!isSupported)
		{
			el.setAttribute(eventType, 'return;');
			isSupported = typeof el[eventType] == 'function';
		}
		el = null;
		return isSupported;
	};

	/**
	 * 
	 * @param element
	 * @param eventFullName includes event name and namespace: click.stage1.allStages
	 * @param callbackMethod event handler function  function (ev) { }
	 * @param useCapture
	 */
	function fnEventDefinition(element: Node, eventFullName?: string, callbackMethod?: (this: HTMLElement, ev: Event) => void, useCapture?: boolean)
	{
		eventFullName = eventFullName || "";
		if (eventFullName.indexOf("on") == 0) eventFullName = eventFullName.substr(2);
		var arr = eventFullName.split('.');
		
		return <ICalystoEventDefinition>{
			/** DOM element */
			element: element,
			/** full name with namespaces after dot, eg: click.state-one.all-states, used for removal by name */
			eventFullName: eventFullName,
			/** event type string, without namespace, eg. click or focus */
			type: <string>arr.shift(),
			/** namespaces, array split by */
			namespaces: arr,
			/** event handler function  function (ev) { } */
			callbackFunc: callbackMethod,
			/** function to remove event, function(){ } */
			removeEvent: () => { },
			/** use capture, true/false */
			useCapture: !!useCapture,
			/** passive, true/false */
			passive: false
		};
	};

	export function Attach(element: Node, eventFullName: string, callbackMethod: (this: HTMLElement, ev: Event) => void, useCapture?: boolean)
	{
		///<summary>Attach event</summary>
		///<param name="element" type="Object">Object to attach event to</param>
		///<param name="eventFullName" type="String">Event type or namespace or type and namespace (click.ns1.ns2)</param>
		///<param name="callbackMethod" type="Function">Callback delegate function(event){...}</param>
		///<param name="useCapture" type="Boolean" optional="true">if false, inner element event has precedence</param>

		// parse argument for namespaces
		var obj1 = fnEventDefinition(element, eventFullName, callbackMethod, useCapture);
		if (!obj1.element) throw new Error("element is required");
		if (!obj1.type) throw new Error("eventFullName is required");
		if (!obj1.callbackFunc) throw new Error("callbackMethod is required");


		// ***************************************************
		// create object for tracking
		if (!obj1.element.$$calysto_EventsArr) obj1.element.$$calysto_EventsArr = [];
		obj1.element.$$calysto_EventsArr.push(obj1);
		// create removal function for removig the event listener from element
		obj1.removeEvent = ()=>
		{
			obj1.element.$$calysto_EventsArr.Remove(obj1);
			if (!obj1.element.$$calysto_EventsArr.Any()) delete (<any>obj1).element.$$calysto_EventsArr;
			fnDetachNativeEvent(obj1);
		};
		// ***************************************************


		// attach native event
		if (obj1.element.addEventListener)
		{
			obj1.element.addEventListener(obj1.type, obj1.callbackFunc, obj1.useCapture);
		}
		else if ((<any>obj1.element).attachEvent)
		{
			(<any>obj1.element).attachEvent("on" + obj1.type, obj1.callbackFunc, obj1.useCapture);
		}
		else
		{
			throw new Error("Attaching event is not supported");
		}

		return obj1;
	};

	function fnGetListeners(element: HTMLElement, eventFullName?: string, callbackMethod?: (this: HTMLElement, ev) => void, useCapture?: boolean)
	{
		///<summary>Get listeners by condition</summary>
		///<param name="element" type="Element">Element</param>
		///<param name="eventFullName" type="String" optional="true">Event type or namespace or type and namespace (click.ns1.ns2)</param>
		///<param name="callbackMethod" type="Function" optional="true">Callback delegate</param>
		///<param name="useCapture" type="Boolean" optional="true">if false, inner element event has precedence</param>

		////#if INTE LLISENSE
		//if (Calysto.IsVSIntellisense)
		//{
		//	return [fnEventDefinition(), fnEventDefinition()];
		//}
		////#endif

		if (!eventFullName)
		{
			return element.$$calysto_EventsArr; // include all listeners
		}

		var conditionObj1 = fnEventDefinition(element, eventFullName, callbackMethod, useCapture);

		if (!conditionObj1.element.$$calysto_EventsArr) return [];

		return conditionObj1.element.$$calysto_EventsArr.AsEnumerable().Where((o) =>
		{
			return (!conditionObj1.type || conditionObj1.type == o.type)
				&& (!conditionObj1.callbackFunc || conditionObj1.callbackFunc == o.callbackFunc)
				&& (conditionObj1.namespaces.length == 0 || (conditionObj1.namespaces.AsEnumerable().All(function (ns1) { return o.namespaces.Contains(ns1) })));
		});
	}

	export function Detach(element: HTMLElement, eventFullName?: string, callbackMethod?: (this: HTMLElement, ev: Event) => void, useCapture?: boolean)
	{
		///<summary>Detach event, select by any condition provided</summary>
		///<param name="element" type="Object">Object to detach event from</param>
		///<param name="eventFullName" type="String" optional="true">Event type or namespace or type and namespace (click.ns1.ns2)</param>
		///<param name="callbackMethod" type="Function" optional="true">Callback delegate</param>
		///<param name="useCapture" type="Boolean" optional="true">if false, inner element event has precedence</param>
		// detach monitored events
		var listeners = fnGetListeners(element, eventFullName, callbackMethod, useCapture);
		if (listeners) listeners.ForEach(o => o.removeEvent());

		// detach any other event not monitored by $$calysto_EventsArr
		var obj1 = fnEventDefinition(element, eventFullName, callbackMethod, useCapture);
		fnDetachNativeEvent(obj1);
	}

	function fnDetachNativeEvent(obj1: ICalystoEventDefinition)
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj1" type="fnEventDefinition"></param>

		if (obj1.element.removeEventListener)
		{
			obj1.element.removeEventListener(obj1.type, obj1.callbackFunc, obj1.useCapture);
		}
		else if ((<any>obj1.element).detachEvent)
		{
			(<any>obj1.element).detachEvent("on" + obj1.type, obj1.callbackFunc, obj1.useCapture);
		}
		else
		{
			throw new Error("Dettaching event is not supported");
		}

	};

	export function GetTarget(event: Event)
	{
		///<summary>Returns source element</summary>
		///<param name="obj" type="Object">Event object</param>

		return event.target || event.srcElement;
	};

	export function StopPropagation(event: Event, doStop: boolean)
	{
		/// <summary>
		/// Set event state to prevent event propagation. iPhone reuses event so, we have to be able to stop and to continue propagation.
		/// </summary>
		/// <param name="event" type="Event"></param>
		/// <param name="doStop" type="Boolean">true to stop, false to propagate</param>

		// prevent execution if handler method returns false
		if (!!doStop)
		{
			if (event.preventDefault)
			{
				event.preventDefault();
			}
			if (event.stopPropagation)
			{
				event.stopPropagation();
			}
		}
		event.returnValue = !doStop;
		event.cancelBubble = !!doStop;
	}

	export function GetOffsetToTarget(event: MouseEvent)
	{
		/// <summary>
		/// Mouse event relative positions to target element. Returns {offsetX:..., offsetY:...}. Firefox doesn't have offsetX,Y, so, take layerX, layerY.
		/// </summary>
		/// <param name="event"></param>

		return {
			offsetX: "offsetX" in event ? event.offsetX : "layerX" in event ? event["layerX"] : NaN,
			offsetY: "offsetY" in event ? event.offsetY : "layerY" in event ? event["layerY"] : NaN
		};
	}

	export function IsLeftMouseButton(event: MouseEvent)
	{
		///<summary>Returns event source element</summary>
		///<param name="obj" type="Object">Event object</param>
		// mouse button:
		// IE : 1=left down, 2=right down, 4=middle down
		// Chrome, FF, Safari: 0=left down or up, 2=right down, 1=middle down or up

		// right button is alway 2 on all browsers

		if (!!(<any>window).attachEvent)
		{
			return event.button === 0 || event.button === 1; // left down = 1, left up = 0
		}
		else if (!!window.addEventListener)
		{
			return event.button === 0; // non ie browsers: 0 up or down
		}
		return false;
	};

	export function IsRightMouseButton(event: MouseEvent)
	{
		///<summary>Returns event source element</summary>
		///<param name="obj" type="Object">Event object</param>
		// mouse button:
		// IE: 1=left, 2=right, 4=middle
		// Chrome, FF, Safari: 0=left, 2=right, 1=middle
		return event.button === 2;
	};

	export function IsMiddleMouseButton(event: MouseEvent)
	{
		///<summary>Returns event source element</summary>
		///<param name="obj" type="Object">Event object</param>
		// mouse button:
		// IE: 1=left, 2=right, 4=middle
		// Chrome, FF, Safari: 0=left, 2=right, 1=middle
		if (!!(<any>window).attachEvent)
		{
			return event.button === 4;
		}
		else if (!!window.addEventListener)
		{
			return event.button === 1;
		}
		return false;
	};

	export function IsAnyMouseButton(event: MouseEvent)
	{
		return event && (event.button === 0 || event.button > 0);
	};

	export function IsEnterKey(event: KeyboardEvent)
	{
		/// <summary>
		/// Test if key or char is ENTER.
		/// </summary>
		/// <param name="event" type="Char|Event"></param>

		return event && (event.keyCode == 10 || event.keyCode == 13); // CTRL + enter (ie = 10, ff = 13)
	};

	export function IsCtrlKey(event: KeyboardEvent)
	{
		return event && event.ctrlKey ? true : false;
	};

	export function IsShiftKey(event: KeyboardEvent)
	{
		return event && event.shiftKey ? true : false;
	};

	export function IsEscKey (event: KeyboardEvent)
	{
		return event && event.keyCode == 27;
	};

	export function IsHoverChanged(element: Element, ev: MouseEvent, isHover: boolean)
	{
		/// <summary>
		/// Test first mouseover or mouseout to element.<br/>
		/// If mouse moves from element to its child or back, there is no hover state change, return false.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="event"></param>
		/// <param name="isHover">hover state to be tested. true: test if mouseover occured, false: test if mouseout ocured</param>
		ev = ev || <MouseEvent>window.event; // old IE doesn't send event
		// if comes from toolbar or goes to toolbar, relTarget is null
		var relTarget = (isHover ? ev["fromElement"] : ev["toElement"]) || ev.relatedTarget;
		if (element != relTarget && !Calysto.Utility.Dom.IsDescendant(<Node>relTarget, element))
		{
			// mouse enter or exit to element
			return true;
		}
		return false;
	};

	/*
	event dispatch
	http://stackoverflow.com/questions/1225798/javascript-programmatically-invoking-events

	For IE:
	document.getElementById("thing_with_mouseover_handler").fireEvent("onmouseover");
	See the MSDN library for more info.

	For the real browsers:
	var event = document.createEvent("MouseEvent");
	event.initMouseEvent("mouseover", true, true, window);
	document.getElementById("thing_with_mouseover_handler").dispatchEvent(event);
	*/

	// inheritance:
	// Object -> Event -> UIEvent -> MouseEvent | KeyboardEvent
	export function DispatchEvent (el: Element, ev: Event | string, doc?: Document)
	{
		/// <summary>
		/// Dispatch event or event type on element el.
		/// </summary>
		/// <param name="el" type="HTMLDivElement"></param>
		/// <param name="event" type="MouseEvent|KeyboardEvent|String">Event object or string event type name</param>

		if (typeof (ev) == "string")
		{
			var evType = ev;
			if (evType.indexOf("on") == 0) evType = evType.substr(2); // remove on
			if (el.dispatchEvent)
			{
				doc = doc || document;
				if (evType.Contains("mouse") || evType.Contains("click"))
				{
					var ev1 = doc.createEvent("MouseEvent");
					ev1.initEvent(evType, false, true);
					el.dispatchEvent(ev1);
					return;
				}
				else if (evType.Contains("key"))
				{
					var ev2 = doc.createEvent("KeyboardEvent");
					ev2.initEvent(evType, false, true);
					el.dispatchEvent(ev2);
					return;
				}
				else
				{
					var ev3 = doc.createEvent("Event");
					ev3.initEvent(evType, false, true);
					el.dispatchEvent(ev3);
					return;
				}
			}
			else if ((<any>el).fireEvent)
			{
				(<any>el).fireEvent("on" + evType); return;
			}
		}
		else if (el.dispatchEvent)
		{
			el.dispatchEvent(ev); return;
		}
		else if ((<any>el).fireEvent)
		{
			(<any>el).fireEvent("on" + ev.type); return;
		}

		throw new Error("Not supported dispatchEvent: " + ev);
	}
}
