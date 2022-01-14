namespace Calysto.AjaxHistory
{
	export type StateArrItemType = {
		functionName?: string, // function name to be invoked on popstate
		selector?: string,
		html?: string,
	};

	type StateObjType =
		{
			isCalystoState: boolean,
			url: string, // window.location.href,
			pathname: string, // window.location.pathname,
			search: string, // window.location.search,
			hash: string, //window.location.hash,
			title: string, //document.title,
			// array with selector & html pairs, select element by selector and replace it's innerHTML
			stateArray: StateArrItemType[]
		};
		 
	let _eventsDone = false;

	function EnsureEvents()
	{
		if (!_eventsDone)
		{
			_eventsDone = true;
			Calysto.Event.Attach((<any>window), "popstate", (ev: any) => RestoreState(ev.state));
		}
	}

	/**
	 * Create state restoration command for current url.
	 * @param stateArray
	 */
	function ReplaceHistoryState(stateArray: StateArrItemType[])
	{
		var stateObj: StateObjType = {
			isCalystoState: true,
			url: window.location.href,
			pathname: window.location.pathname,
			search: window.location.search,
			hash: window.location.hash,
			title: document.title,
			stateArray: stateArray
		};

		if (stateObj && stateObj.isCalystoState && window.history.replaceState)
		{
			EnsureEvents();
			
			window.history.replaceState(stateObj, stateObj.title, stateObj.url);
		}
	}

	function RestoreState(stateObj: StateObjType)
	{
		if (stateObj && stateObj.isCalystoState && stateObj.stateArray && window.history.replaceState)
		{
			document.title = stateObj.title;

			for (let n = 0; n < stateObj.stateArray.length; n++)
			{
				let obj = stateObj.stateArray[n];

				if (obj.selector)
				{
					$$calysto(obj.selector).SetInnerHtml(obj.html);
				}
			}
		}
	}

	/**
	 * Create new history state by changing url hash.
	 */
	function CreateNewRandomHash()
	{
		// firefox will register new url only if property hash is explicitly set
		window.location.hash = "!x" + Date.now() + "-" + Math.floor(Math.random() * 1000000);
	};

	/**
	 * Will save current state, then modify with new values and save new state, so the back-forward will work.
	 * @param stateArray [{selector:.., html:..}, {selector:.., html:..}...]
	 */
	export function PushState(stateArray: StateArrItemType[])
	{
		// save current state connected with current url
		let currentArr: StateArrItemType[] = [];
		for (let n = 0; n < stateArray.length; n++)
		{
			let sel1: string = <string>stateArray[n].selector;
			if (!sel1) throw new Error("Error in AjaxHistory, selector is null");

			currentArr.push({
				selector: sel1,
				html: <string>$$calysto(sel1).SelectInnerHtml().FirstOrDefault(),
			});
		}
		ReplaceHistoryState(currentArr);

		// update content
		for (let n = 0; n < stateArray.length; n++)
		{
			// update page content
			$$calysto(<string>stateArray[n].selector).SetInnerHtml(<string>stateArray[n].html);
		}

		// change hash, new url will be connected with new state
		CreateNewRandomHash();

		// save new current state for new url (this is required only go forward is pushed after go back is pushed)
		let newArr: StateArrItemType[] = [];
		for (let n = 0; n < stateArray.length; n++)
		{
			let sel1 = <string>stateArray[n].selector;
			newArr.push({
				selector: sel1,
				html: <string>$$calysto(sel1).SelectInnerHtml().FirstOrDefault(),
			});
		}
		ReplaceHistoryState(newArr);
		
	}
}

