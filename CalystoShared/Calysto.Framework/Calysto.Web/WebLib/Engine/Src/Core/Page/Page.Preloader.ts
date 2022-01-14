namespace Calysto.Page.Preloader
{
	let _isLoading = false;
	let _delayMs = 300;
	let _isEnabled = false;
	let _timer: Calysto.Timer;
	let _hasPageEvent = false;

	export function Enable(delayMs = 300)
	{
		/// <summary>
		/// Create preloader event and start monitoring for ajax start/stop
		/// </summary>
		/// <param name="delayMs" type="Integer" optional="true">default is 300ms, if not provided</param>

		_delayMs = arguments.length == 0 ? 300 : delayMs;
		_isEnabled = true;

		if (!_timer)
		{
			_timer = new Calysto.Timer().OnTimeout(() =>
			{
				// add class to html element
				if (!_isLoading)
				{
					Calysto.Utility.Dom.RemoveClass(document.documentElement, "calystoAjaxLoading");
				}
				else
				{
					Calysto.Utility.Dom.AddClass(document.documentElement, "calystoAjaxLoading");
				}
			});
		}

		if (!_hasPageEvent)
		{
			_hasPageEvent = true;
			Calysto.Page.OnLoading((isLoading: boolean) =>
			{
				_isLoading = isLoading;
				if (_isEnabled)
				{
					_timer.Abort().Start(_isLoading ? _delayMs : 1);
				}
			});
		}
	}

	export function Disable()
	{
		/// <summary>
		/// Stop monitoring ajax start/stop
		/// </summary>

		if (_timer)
		{
			_isEnabled = false;
			_isLoading = false; // remove class from body
			_timer.Abort().Start(1);
		}
	};
}
