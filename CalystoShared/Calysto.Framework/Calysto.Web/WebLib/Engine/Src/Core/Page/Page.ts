namespace Calysto.Page
{
	enum ReadyStateEnum
	{
		Loading = 2,
		Interactive = 3,
		Complete = 4
	}

	class PendingItem
	{
		// function to be executed
		public Func: () => void;
		public MinReadyState: ReadyStateEnum;
		public IsExecuted: boolean;
	}

	var _items: PendingItem[] = [];

	//#region page events engine

	function ExecuteByEnumState(currState: number)
	{
		for (let item of _items)
		{
			if (!item.IsExecuted && item.MinReadyState <= currState)
			{
				item.IsExecuted = true;
				item.Func();
			}
		}
	}

	// IE and Safari requires additional delay on interactive to process window variables
	// this way we may test if dom is really ready
	let _timeoutid: number;
	let delay = window.FormData ? 10 : 200; // old browsers need more delay

	function CheckReadyState()
	{
		//////#if DEBUG
		////if (Calysto.Core.IsDebugDefined)
		////{
		////	console.log("DOM not ready #1");
		////}
		//////#endif

		if (window.document && document.body)
		{
			switch (document.readyState)
			{
				case "loading":
					// let's fall to the end and invoke new setTimeout(...)
					break;

				case "interactive":
					{
						// jQuery is testing !!document.body, but it is not ok since DOM is not ready yet
						// we have to test readyState==interactive, interactive is set later when dom is ready
						
						setTimeout(() => ExecuteByEnumState(ReadyStateEnum.Interactive), delay);
						// let's fall to the end and invoke new setTimeout(...)
						break;
					}

				case "complete":
					{
						// execute all
						// IE and Safari requires additional delay on interactive to process window variables
						setTimeout(() => ExecuteByEnumState(ReadyStateEnum.Complete), delay);
						return; // must exits, don't set timeout any more
					}

			}
		}

		// continue waiting for complete
		clearTimeout(_timeoutid); // to make sure there is only 1 alive timeout
		_timeoutid = setTimeout(CheckReadyState, delay);
	}

	function AddEvent(func: () => void, readyStateKind: ReadyStateEnum)
	{
		var item = new PendingItem();
		item.Func = func;
		item.MinReadyState = readyStateKind;
		_items.push(item);
		// must be sorted: to invoke callbacks in correct order if it comes to "complete" without coming to "interactive": "interactive", "complete"
		_items = _items.OrderBy(o => o.MinReadyState);
		CheckReadyState();
	}

	//#endregion

	// *******************************************************************

	export var IsPageReloading = false;

	export var IsVersionExpiredVisible = false;

	// *******************************************************************

	/**
	 * Execute once at window.onload event (or document.readyState=='complete'). Includes clasic page load only.
	 */
	export const OnLoadComplete = new Calysto.MulticastDelegate<() => void>().OnAdd((func) =>
	{
		AddEvent(func, ReadyStateEnum.Complete);

	}).AsFunc(Calysto.Page);

	// *******************************************************************
	/**
		Executes on:
		1. Page unload by navigating to different url
		2. MS classic postback start
		3. MS ajax postback start
		4. Calysto ajax start request
	 */
	export const OnLoading = new Calysto.MulticastDelegate<(isLoading: boolean) => void>().AsFunc(Calysto.Page);

	// *******************************************************************
	// Begin request & End request

	var _aliveRequests = 0;

	/**
		Executes on:
		1. Page unload by navigating to different url
		2. MS classic postback start
		3. MS ajax postback start
		4. Calysto ajax start request
	 */
	export const OnBeginRequest = new Calysto.MulticastDelegate<() => void>().Add(() =>
	{
		if (++_aliveRequests == 1)
		{
			OnLoading.Invoke(f => f(true));
		}
		////console.log("begin _aliveRequests: " + _aliveRequests);
	}).AsFunc(Calysto.Page);

	/**
		Executes on:
		1. Page load or interactive
		2. MS classic postback end response
		3. MS ajax end response
		4. Calysto ajax end response
	 */
	export const OnEndResponse = new Calysto.MulticastDelegate<() => void>().Add(() =>
	{
		if (--_aliveRequests < 1)
		{
			_aliveRequests = 0;
			OnLoading.Invoke(f => f(false));
		}
	}).AsFunc(Calysto.Page);


	// *******************************************************************
	/**
	 * Execute once on document.readyState=='interactive' or page load. It is as soon as html is interactive, but all other resources may not be loaded (eg. images)
	 * @param func
	 */
	export const OnInteractive = new Calysto.MulticastDelegate<() => void>().OnAdd((func) =>
	{
		AddEvent(func, ReadyStateEnum.Interactive);

	}).Add(() =>
	{
		// register with MS Ajax EndRequest
		var _sys = (<any>window).Sys;
		if (typeof (_sys) != "undefined" && _sys.WebForms && _sys.WebForms.PageRequestManager)
		{
			_sys.WebForms.PageRequestManager.getInstance().add_beginRequest(() => OnBeginRequest.Invoke(f => f()));
			_sys.WebForms.PageRequestManager.getInstance().add_endRequest(() => OnEndResponse.Invoke(f => f()));
		}

		OnEndResponse.Invoke(f => f());

	}).AsFunc(Calysto.Page);

	// *******************************************************************

	///**
	// * MS ASP.NET or AJAX.NET Specific. Add func which will be executed before page MS postback submit or MS Ajax submit
	// */
	//export const OnBeforeSubmit = new Calysto.MulticastDelegate<() => void>().AsFunc(Calysto.Page);

	//// export as global function
	//Calysto.Core.ExportGlobal(Calysto.Page.OnBeforeSubmit.Invoke.BindContext(Calysto.Page.OnBeforeSubmit), "fnOnBeforeSubmitInvoke");
	
	/*
	insert to page html:
	must return true, otherwise MS postback will not work
	function WebForm_OnSubmit() {
		if(typeof(Calysto) != 'undefined'){return Calysto.Page.OnBeforeSubmit.Invoke();};
		return true;
	}
	*/

	// ******************************************************************
	/**
	 * Accepts function(errMsg){...} where errMsg is sent from the system.
	 */
	export const OnUnhandledException = new Calysto.MulticastDelegate<(errMsg: string) => void>().AsFunc(Calysto.Page);


	// *******************************************************************

	/**
	 * Executes when JS engine version is outdated. This command is returned from server
	 * errMsg is sent from the system
	 * warning: must be MulticastDelegate because .Any() is used in EngineExpiredJS on server
	 */
	export const OnVersionExpired = new Calysto.MulticastDelegate<() => void>().AsFunc(Calysto.Page);


	//else if (evName == "escKey")
	//{
	//	parts.unshift("keydown");
	//	cb11 = function (sender, ev)
	//	{
	//		if (Calysto.Event.IsEscKey(ev))
	//		{
	//			return callbackFunc.call(sender, sender, ev);
	//		}
	//	};
	//}

	var _isOnEscKeyEventAttached = false;

	/**
	* Accepts function(sender, ev){...} where sender is document
	*/
	export const OnEscKey = new Calysto.MulticastDelegate<() => void>().OnAdd(() =>
	{
		// init event
		if (!_isOnEscKeyEventAttached)
		{
			_isOnEscKeyEventAttached = true;
			Calysto.Event.Attach(<any>document, "keydown", ev =>
			{
				if (Calysto.Event.IsEscKey(<KeyboardEvent>ev))
				{
					OnEscKey.Invoke(f=>f());
				}
			});
		}
	}).AsFunc(Calysto.Page);

}

