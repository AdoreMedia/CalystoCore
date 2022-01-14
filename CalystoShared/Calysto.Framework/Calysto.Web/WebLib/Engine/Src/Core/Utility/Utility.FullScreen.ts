namespace Calysto.Utility.FullScreen
{
	// NOTE: Fullscreen requests to be invoked from event handler's thread, otherwise permision is denied.

	export function RequestFullScreen(el: HTMLElement)
	{
		var divObj: any = el;

		var requestFunc = divObj.requestFullscreen
			|| divObj.msRequestFullscreen
			|| divObj.mozRequestFullScreen
			|| divObj.webkitRequestFullscreen
			|| divObj.webkitRequestFullScreen /*safari*/
			|| divObj.webkitEnterFullScreen
			|| divObj.webkitEnterFullscreen;

		//Use the specification method before using prefixed versions
		if (requestFunc)
		{
			requestFunc.apply(divObj);
		}
	}

	var cancelFunc: Function = (() =>
	{
		var doc: any = document;
		return (doc.cancelFullscreen
			|| doc.msExitFullscreen
			|| doc.msCancelFullscreen
			|| doc.mozCancelFullScreen
			|| doc.webkitExitFullscreen
			|| doc.webkitExitFullScreen /*iPhone*/
			|| doc.webkitCancelFullscreen
			|| doc.webkitCancelFullScreen /*safari*/);
	})();

	export function CancelFullScreen()
	{
		// Use the specification method before using prefixed versions
		// IE has msExitFullscreen
		if (cancelFunc)
		{
			cancelFunc.apply(document);
		}
	}

	export function GetFullScreenElement(): HTMLElement
	{
		var doc: any = document;
		//  get full screen element across several browsers
		return doc.fullscreenElement
			|| doc.msFullscreenElement
			|| doc.mozFullScreenElement
			|| doc.webkitFullscreenElement
			|| doc.webkitCurrentFullScreenElement /*safari*/
			|| doc.webkitDisplayingFullscreen; // warning: this should be true/false only, not the element which is in fullscreen
	}

	export function IsInFullscreen()
	{
		return !!GetFullScreenElement();
	};

	export function IsIframeFullscreenEnabled()
	{
		/// <summary>
		/// Test if iframe has allowFullscreen attribute
		/// </summary>
		var doc: any = document;
		return !!(doc.fullscreenEnabled
			|| doc.msFullscreenEnabled
			|| doc.mozFullScreenEnabled
			|| doc.webkitFullscreenEnabled
			|| "webkitIsFullScreen" in doc /*for safari*/);
	}

	export function IsSupported()
	{
		if (window.parent)
		{
			return !!(cancelFunc && IsIframeFullscreenEnabled());
		}
		else
		{
			return !!(cancelFunc);
		}
	}

	var chg = ["MSFullscreenChange", "webkitfullscreenchange", "mozfullscreenchange", "fullscreenchange"];
	var err = ["MSFullscreenError", "webkitfullscreenerror", "mozfullscreenerror", "fullscreenerror"];

	var _evChgAssigned = false;
	var _onFsChanged: ((sender: Document) => void)[] = [];

	export function OnFullscreenChanged(handler: (sender: Document) => void)
	{
		if (!_evChgAssigned)	
		{
			_evChgAssigned = true;
			var sender = <any>document;
			chg.ForEach((evName) => Calysto.Event.Attach(sender, evName, (ev) =>
			{
				// this je originalni element
				// fullscreen detection _this.IsInFullscreen() doesn't work ok
				_onFsChanged.ForEach(fn => fn(sender));
			}));
		}

		_onFsChanged.push(handler);
	}

	var _evErrAssigned = false;
	var _onFsError: ((sender: Document) => void)[] = [];

	export function OnFullscreenError(handler: (sender: Document) => void)
	{
		if (!_evErrAssigned)
		{
			_evErrAssigned = true;
			var sender = <any>document;
			err.ForEach((evName) => Calysto.Event.Attach(sender, evName, (ev) =>
			{
				// this is original element
				// fullscreen detection _this.IsInFullscreen() doesn't work ok
				_onFsError.ForEach(fn => fn(sender));
			}));
		}

		_onFsError.push(handler);
	}
}
