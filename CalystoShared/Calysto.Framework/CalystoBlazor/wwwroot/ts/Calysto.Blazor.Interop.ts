interface IBlazorInteropObject
{
	invokeMethodAsync<T>(methodName: string, ...args: any[]): Promise<T>;
	invokeMethod<T>(methodName: string, ...args: any[]): T;
}

interface IJSObjectReference
{
	__jsObjectId: number;
}

declare namespace DotNet
{
	export const JSCallResultType: { 0: 'Default', 1: 'JSObjectReference', Default: 0, JSObjectReference: 1 }

	export function invokeMethod(e, t);
	
	export function invokeMethodAsync(e, t);
	
	export function attachDispatcher(e);
	
	export function attachReviver(e);
	
	export function createJSObjectReference(e): IJSObjectReference;
	
	export function disposeJSObjectReference(e): void;

	export function parseJsonWithRevivers(e);

	namespace jsCallDispatcher
	{
		export function findJSFunction(e, t);
		
		export function disposeJSObjectReferenceById();
		
		export function invokeJSFromDotNet(e, t, n, r);
		
		export function beginInvokeJSFromDotNet(e, t, n, r, o);
		
		export function endInvokeDotNetFromJS(e, t, n);
	}
}

//DotNet.attachReviver(function (key, value)
//{
//	console.log({ key, value });
//});

namespace Calysto
{
	globalThis.Calysto = Calysto;

	//export function Test1(a, b, c)
	//{
	//	console.log({ a, b, c });
	//}
}

namespace Calysto.Blazor.Interop
{
	export async function SleepAsync(sleepMs: number)
	{
		return new Promise<void>((success, reject) =>
		{
			setTimeout(() => success(), sleepMs);
		});
	}

	export async function ExecuteScriptAsync(js: string)
	{
		return await (new Function(js))();
	}

	export async function SystemAlertAsync(txt:string)
	{
		return await alert(txt);
	}	

	export async function SystemConfirmAsync(txt:string)
	{
		return await confirm(txt);
	}

	export async function SystemPromptAsync(txt:string)
	{
		return await prompt(txt);
	}

	//#region getElementBy methods

	interface IDomElement
	{
		tagName: string;
		id: string;
		name: string;
		style: string;
		className: string;
		offsetWidth: number;
		offsetHeight: number;
		value: string;
		type: string;
	}

	function CreateEl(el: HTMLElement)
	{
		return <IDomElement>{
			tagName: el.tagName,
			id: el.id,
			style: el.style.cssText,
			className: el.className,
			offsetWidth: el.offsetWidth,
			offsetHeight: el.offsetHeight,
			name: (<any>el).name || el.getAttribute("name"),
			value: (<any>el).value || el.getAttribute("value"),
			type: (<any>el).type || el.getAttribute("type")
		};
	}

	export function GetElementByReference(elementReference)
	{
		return CreateEl(elementReference);
	}

	export function GetElementById(id: string)
	{
		let el = document.getElementById(id);
		if (!el)
			return null;
		else
			return CreateEl(el);
	}

	function SelectElements(source: HTMLCollectionOf<Element>, skip?: number, take?: number)
	{
		skip = skip || 0;
		take = take || Number.MAX_SAFE_INTEGER;
		let arr2: IDomElement[] = [];
		let index = -1;
		for (let el2 of <any>source)
		{
			if (++index >= skip && index < skip + take)
			{
				arr2.push(CreateEl(<HTMLElement>el2));
			}
		}
		return arr2;
	}

	export function GetElementsByTagName(tagName: string, skip?: number, take?: number)
	{
		return SelectElements(document.getElementsByTagName(tagName), skip, take);
	}

	export function GetElementsByClassName(className: string, skip?: number, take?: number)
	{
		return SelectElements(document.getElementsByClassName(className), skip, take);
	}

	export function GetElementsByName(className: string, skip?: number, take?: number)
	{
		return SelectElements(<any>document.getElementsByName(className), skip, take);
	}

	//#endregion

	//#region element manipulation

	function SplitPath(propertyPath?: string)
	{
		if (!propertyPath)
			return [];

		//"one[0].two.three".split(new RegExp("\\.|\\[|\\]"))
		let parts = propertyPath.split(new RegExp("\\.|\\[|\\]"));
		let arr1: string[] = [];
		for (let p1 of parts)
		{
			if (p1)
				arr1.push(p1);
		}
		return arr1;
	}

	function IsNumber(value)
	{
		return new RegExp("^[\\d]+$").test(value);
	}

	function SetPropertyValue2(obj: any, propertyPath: string, value: any)
	{
		let parts = SplitPath(propertyPath);
		let tmp = obj;
		let p1: string;
		for (let n1 = 0; n1 < parts.length - 1; n1++)
		{
			p1 = parts[n1];

			if (IsNumber(p1))
				p1 = <any>parseInt(p1);

			if (typeof tmp[p1] == undefined)
			{
				tmp[p1] = {};
			}
			tmp = tmp[p1];
		}
		tmp[parts[parts.length - 1]] = value;
	}

	function GetPropertyValue2(obj: any, propertyPath: string)
	{
		let parts = SplitPath(propertyPath);
		let tmp = obj;
		for (let p1 of parts)
		{
			if (IsNumber(p1))
				p1 = <any> parseInt(p1);

			if (typeof tmp[p1] == undefined)
			{
				return undefined;
			}
			tmp = tmp[p1];
		}
		return tmp;
	}

	export function SetPropertyValue(el: HTMLElement, propertyPath: string, value: any)
	{
		SetPropertyValue2(el, propertyPath, value);
	}

	export function GetPropertyValue(el: HTMLElement, propertyPath: string)
	{
		return GetPropertyValue2(el, propertyPath);
	}

	export function GetPropertyReference(el: HTMLElement, propertyPath: string)
	{
		return DotNet.createJSObjectReference(GetPropertyValue(el, propertyPath));
	}

	//#endregion

	//#region invoke element / object function

	export function HasObjectProperty(el: HTMLElement, propertyPath: string)
	{
		let val1 = GetPropertyValue(<any>window, <string>propertyPath);
		return (val1 && !!val1.apply && !!val1.call)
			|| !(val1 === undefined || val1 === null || isNaN(val1));
	}

	export function HasObjectFunction(el: HTMLElement, propertyPath: string)
	{
		let val1 = GetPropertyValue(<any>window, <string>propertyPath);
		// is function
		return (val1 && !!val1.apply && !!val1.call);
	}

	export function InvokeObjectFunction(el: HTMLElement, propertyPath: string, args: any[])
	{
		let partsArr = SplitPath(propertyPath);
		partsArr.pop();
		let obj = GetPropertyValue(el, partsArr.join("."));

		let fn: Function = GetPropertyValue(el, propertyPath);
		return fn.apply(obj, args);
	}

	export function InvokeObjectFunctionVoid(el: HTMLElement, propertyPath: string, args: any[])
	{
		InvokeObjectFunction(el, propertyPath, args);
	}

	//#endregion

	//# window properties

	export function HasWindowProperty(propertyPath: string)
	{
		return HasObjectProperty(<any>window, propertyPath);
	}

	export function HasWindowFunction(propertyPath: string)
	{
		return HasObjectFunction(<any>window, propertyPath);
	}

	export function GetWindowPropertyValue(propertyPath?: string)
	{
		return GetPropertyValue(<any>window, <string>propertyPath);
	}

	export function GetWindowPropertyReference(propertyPath?: string)
	{
		return GetPropertyReference(<any>window, <string>propertyPath);
	}

	//#endregion

	//#region invoke window function

	export function InvokeWindowFunction(propertyPath: string, args: any[])
	{
		return InvokeObjectFunction(<any>window, propertyPath, args);
	}

	export function InvokeWindowFunctionVoid(propertyPath: string, args: any[])
	{
		InvokeObjectFunctionVoid(<any>window, propertyPath, args);
	}

	//#endregion

	//#region element attributes

	export function SetAttributeValue(el: HTMLElement, attrName: string, value: string)
	{
		el.setAttribute(attrName, value);
	}

	export function GetAttributeValue(el: HTMLElement, attrName: string)
	{
		return el.getAttribute(attrName);
	}

	//#endregion

	//#region DOM events

	/** Microsoft.AspNetCore.Components.Web.MouseEventArgs */
	interface IMouseEventArgs
	{
		Detail: number;
		ScreenX: number;
		ScreenY: number;
		ClientX: number;
		ClientY: number;
		OffsetX: number;
		OffsetY: number;
		Button: number;
		Buttons: number;
		CtrlKey: boolean;
		ShiftKey: boolean;
		AltKey: boolean;
		MetaKey: boolean;
		Type: string;
	}

	/** Microsoft.AspNetCore.Components.Web.IKeyboardEventArgs */
	interface IKeyboardEventArgs
	{
		Key: string;
		Code: string;
		Location: number;
		Repeat: boolean;
		CtrlKey: boolean;
		ShiftKey: boolean;
		AltKey: boolean;
		MetaKey: boolean;
		Type: string;
	}

	function CreateEventArgument(argType: string, ev: any)
	{
		switch (argType)
		{
			case "MouseEventArgs":
				return <IMouseEventArgs>{
					Detail: ev.detail,
					ScreenX: ev.screenX,
					ScreenY: ev.screenY,
					ClientX: ev.clientX,
					ClientY: ev.clientY,
					OffsetX: ev.offsetX,
					OffsetY: ev.offsetY,
					Button: ev.button,
					Buttons: ev.buttons,
					CtrlKey: ev.ctrlKey,
					ShiftKey: ev.shiftKey,
					AltKey: ev.altKey,
					MetaKey: ev.metaKey,
					Type: ev.type
				};
				break;

			case "KeyboardEventArgs":
				return <IKeyboardEventArgs>{
					Key: ev.key,
					Code: ev.code,
					Location: ev.location,
					Repeat: ev.repeat,
					CtrlKey: ev.ctrlKey,
					ShiftKey: ev.shiftKey,
					AltKey: ev.altKey,
					MetaKey: ev.metaKey,
					Type: ev.type
				};
				break;

			default:
				throw "Unsupported event argument type: " + argType;
		}
	}

	/**
	 * Wait for one time event.
	 * @param eventName
	 * @param targetElementId
	 * @param argType
	 */
	export function WaitForDomEventAsync(eventName: string, targetElementId: string, argType:string)
	{
		return new Promise((resolve, reject) =>
		{
			let el = <HTMLElement><any>document;
			if (targetElementId)
			{
				el = <HTMLElement> document.getElementById(targetElementId);
			}

			let callback = (ev: Event) =>
			{
				el.removeEventListener(eventName, callback);
				resolve(CreateEventArgument(argType, <any>ev));
			};

			el.addEventListener(eventName, callback);
		});
	}

	export function AddEventListener(el: HTMLElement, eventName: string, callback: IBlazorInteropObject, argType: string)
	{
		var fnCallback = async ev =>
		{
			let arg1 = CreateEventArgument(argType, ev);
			console.log({ type: ev.type, arg: arg1 });
			let res1 = await callback.invokeMethodAsync("Callback", arg1);
			console.log("JS result: " + res1);
			return res1;
		};

		console.log(eventName);
		el.addEventListener(eventName, fnCallback);

		let state2 = {};

		let ref1 = DotNet.createJSObjectReference(state2);

		(<any>state2).fnRemove = () =>
		{
			console.log("fnRemove invoked");
			el.removeEventListener(eventName, fnCallback);
			DotNet.disposeJSObjectReference(ref1);
		};

		return ref1;
	}

	export function RemoveEventListener(obj: IJSObjectReference)
	{
		(<any>obj).fnRemove();
	}

	//#endregion

	//#region client version control

	async function RemoveBlazorOfflineCacheAsync()
	{
		// Delete caches
		let cacheKeys = await caches.keys();
		await Promise.all(cacheKeys
			.filter(key => key.startsWith("offline-cache-") || key.startsWith("blazor-resources-"))
			.map(key => caches.delete(key)));
	}

	export async function RemoveBlazorOfflineCacheAndReloadAsync()
	{
		console.log("Refresh blazor offline cache");
		await RemoveBlazorOfflineCacheAsync();
		location.reload();
	}

	export async function GetServerVersionFromHtmlAsync()
	{
		// version should be writtent on server side:
		// <meta id="server-version" value="ca67ebf7-c140-4a3e-bf75-dd919399af0a"/>
		let el = <any> document.getElementById("server-version");
		return el?.value || el?.getAttribute("value");
	}

	async function InitialBlazorVersionCheckAsync()
	{
		// only if server-version exists in html
		let expected1 = await GetServerVersionFromHtmlAsync();
		if (!expected1)
			throw "Missing server-version in html";

		let current1 = localStorage.getItem("blazor-initial");

		if (current1 != expected1)
		{
			localStorage.setItem("blazor-initial", expected1);
			console.log("Reload blazor-initial");

			await RemoveBlazorOfflineCacheAndReloadAsync();
		}
	}

	//InitialBlazorVersionCheckAsync();

	//#endregion

	//#region window.location

	export async function GetLocationAsync()
	{
		return ({
			hash: location.hash,
			host: location.host,
			hostname: location.hostname,
			href: location.href,
			origin: location.origin,
			pathname: location.pathname,
			port: location.port,
			protocol: location.protocol
		});
	}

	//#endregion

}

