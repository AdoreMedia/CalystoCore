namespace Calysto.OverflowProvider
{
	let _calystoOverflowHidden = "calystoOverflowHidden";
	let _hasOverflow = false;

	let _paddings: {
		paddingRight: string
		paddingBottom: string,
	};

	function GetScrollElement()
	{
		for (let el of [document.documentElement, document.body])
		{
			if (el.scrollHeight > el.clientHeight) return el;
			if (el.scrollWidth > el.clientWidth) return el;
		}
		return undefined;
	}

	export function CreateOverflow()
	{
		if (_hasOverflow)
			return;
		else
			_hasOverflow = true;

		$$calysto(document.body).RemoveClass(_calystoOverflowHidden);

		_paddings = <any>null;

		let el = GetScrollElement();
		if (!el) return;

		_paddings = <any>{};

		let w1 = el.clientWidth;
		let h1 = el.clientHeight;

		// overflow class must be added to body, not to html element, for all browsers
		$$calysto(document.body).AddClass(_calystoOverflowHidden);

		let w2 = el.clientWidth;
		let h2 = el.clientHeight;
		if (w2 > w1)
		{
			// save original padding
			_paddings.paddingRight = document.body.style.paddingRight || "";
			document.body.style.paddingRight = (w2 - w1) + "px";
		}
		if (h2 > h1)
		{
			// save original padding
			_paddings.paddingBottom = document.body.style.paddingBottom || "";
			document.body.style.paddingBottom = (h2 - h1) + "px";
		}
	}

	export function RemoveOverflow()
	{
		_hasOverflow = false;

		if (!_paddings)
			return;
		$$calysto(document.body).RemoveClass(_calystoOverflowHidden);
		document.body.style.paddingRight = _paddings.paddingRight || "";
		document.body.style.paddingBottom = _paddings.paddingBottom || "";
	}
}

