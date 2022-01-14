namespace Calysto
{
	export enum CloseMode
	{
		destroy = "destroy",
		hide = "hide"
	}

	export enum DialogButton
	{
		XClose = "XClose",
		Yes = "Yes",
		No = "No",
		Cancel = "Cancel",
		Close = "Close"
	}

	// transform: translateX(-50%) translateY(-20%)
	// calystoDialogBox width:auto to override css from  web template
	// td: padding:0;border:none override css from web template
	// it has to be modal always because calystoDialogBoxContainer is stretched over the whole page anyway

	let _html = (
`<div class="themeAero calystoDialogControl calystoDialogModal">
	<div class="calystoDialogMask"></div>
	<div class="calystoDialogBoxContainer">
		<div class="calystoDialogBox">
				
			<div class="calystoWindow">

				<label class="calystoWindowXMark fa fa-close" style="display: none;">
					<button class="calystoXCloseButton" calysto_button_name="${DialogButton.XClose}" style="position: absolute; width: 1px; height: 1px; opacity: 0;"></button>
				</label>

				<div class="calystoWindowTitle">
					<table style="border-collapse:collapse;" cellpadding="0" cellspacing="0">
						<tbody>
							<tr>
								<td class="calystoWindowTd1">
									<div class="calystoWindowIcon fa fa-info-circle"></div>
								</td>
								<td>
									<div class="calystoWindowTitleText">Alert</div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>

				<div class="calystoWindowContent">
					<table class="calystoWindowTable1 calystoWindowInnerContent" cellpadding="0" cellspacing="0" style="border-collapse:collapse;min-width: 250px; min-height: 35px;">
						<tbody>
							<tr>
								<td class="calystoWindowTd2"></td>
							</tr>
						</tbody>
					</table>
				</div>

				<div class="calystoWindowButtons" style="display:none"></div>

			</div>
		
		</div>
	</div>
</div>`);

	export enum DialogIcon
	{
		file = "file",
		edit = "edit",
		info = "info",
		error = "error",
		warning = "warning",
		question = "question",
		success = "success",
		none = "none"
	};

	export enum DialogMode
	{
		/** default */
		Alert = 0,
		/** similar to bootstrap modal: hides page scrollbar and create scrollbar for dialog at the window right-most*/
		Panel = 1
	}

	/**
	 * Get window title based on icon.
	 * @param iconName
	 */
	function GetTitle(iconName: keyof typeof DialogIcon)
	{
		switch (iconName)
		{
			case "file": return Resources.CalystoLang.File;
			case "edit": return Resources.CalystoLang.Edit;
			case "error": return Resources.CalystoLang.Error;
			case "warning": return Resources.CalystoLang.Warning;
			case "info": return Resources.CalystoLang.Information;
			case "question": return Resources.CalystoLang.Question;
			case "success": return Resources.CalystoLang.Success;
			default: return "";
		}
	}

	/**
	 * Font Awesome icon.
	 * @param iconName
	 */
	export function GetFAIconClass(iconName: keyof typeof DialogIcon)
	{
		switch (iconName)
		{
			case "file": return "fa-file";
			case "edit": return "fa-edit";
			case "success": return "fa-check-circle";
			case "error": return "fa-times-circle";
			case "warning": return "fa-exclamation-triangle";
			case "info": return "fa-info-circle";
			case "question": return "fa-question-circle";
			default: return "";
		}
	}

	/**
	 * Get window icon in color.
	 * @param iconName
	 */
	function GetIconColorClass(iconName: keyof typeof DialogIcon)
	{
		return "";
		//switch (iconName)
		//{
		//	case "success": return "calystoWindowIconGreen";
		//	case "error": return "calystoWindowIconRed";
		//	case "warning": return "calystoWindowIconOrange";
		//	case "info": return "calystoWindowIconBlue";
		//	case "question": return "calystoWindowIconOrange";
		//	default: return "";
		//}
	}

	/**
	 * global z-index, ever new dialog instace will increase as _zIndex++
	 */
	let _zIndex = 1000000; // global z-index, every new dialog increases _zIndex++

	/**
	 * global dialogls stack
	 */
	let _dialogsStack: Dialog[] = [];

	/**
	 * global test if OnEsc event is assigned
	 */
	let _hasEscEvent = false;

	interface ButtonItem
	{
		name: string;
		isDefault: boolean;
		isRendered: boolean;
	}

	export class Dialog
	{
		private _dialogControlEl: HTMLDivElement;
		private _buttonsEl: HTMLDivElement;
		private _xButtonEl: HTMLDivElement;
		private _focusButtonEl: HTMLButtonElement;
		private _dialogBoxEl: HTMLDivElement;
		private _windowEl: HTMLDivElement;
		private _dialogBoxContainerEl: HTMLDivElement;
		private _contentEl: HTMLDivElement;
		private _maskEl: HTMLDivElement;
		private _innerContentEl: HTMLDivElement;
		private _titleEl: HTMLDivElement;
		private _tdContentEl: HTMLDivElement;
		private _titleText: string;
		private _initDone: boolean;
		private _isModal: boolean;
		private _iconName: keyof typeof DialogIcon;
		private _closeOnEscKey: boolean;
		private _closeMode: keyof typeof CloseMode = "destroy";
		private _viewMode = DialogMode.Alert;

		/**
		 * creates new instance and append it to document body
		 */
		constructor()
		{
			this.Initialize();
		}

		public Initialize()
		{
			var el = document.createElement("div");
			el.innerHTML = _html;

			this._dialogControlEl = <HTMLDivElement> el.childNodes[0];
			// container with Calysto.Dialog instance
			this._dialogControlEl["__calystoDialog"] = this;

			var $$dialogEl = $$calysto(this._dialogControlEl);

			this._dialogControlEl.style.zIndex = (_zIndex++) + "";
			this._maskEl = <HTMLDivElement>$$dialogEl.Query("//.calystoDialogMask").First();
			this._dialogBoxContainerEl = <HTMLDivElement>$$dialogEl.Query("//.calystoDialogBoxContainer").First();
			this._dialogBoxEl = <HTMLDivElement>$$dialogEl.Query("//.calystoDialogBox").First(); // must have display:inline-block for scroll to work

			this._windowEl = <HTMLTableCellElement>$$dialogEl.Query("//.calystoWindow").First();
			let $windowEl = $$calysto(this._windowEl);

			this._xButtonEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowXMark").First();
			this._titleEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowTitle").First();
			this._contentEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowContent").First();
			this._innerContentEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowInnerContent").First();
			this._tdContentEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowTd2").First();
			this._buttonsEl = <HTMLDivElement>$windowEl.Query("//.calystoWindowButtons").First();
		}

		public GetDialogEl()
		{
			return this._dialogControlEl;
		}

		public GetContentEl()
		{
			return this._contentEl;
		}

		/**
		 * Apply dialog width 100% and max-width:prefferedWidth in px
		 * @param prefferedWidth
		 */
		public PrefferedWidth(prefferedWidth: number)
		{
			$$calysto(this._dialogBoxEl).ApplyStyle(`width:100%;max-width:${prefferedWidth}px;`);
			return this;
		}

		public Set(cb: (dialog: Dialog) => void)
		{
			cb(this);
			return this;
		}

		private RenderTitle(title: string)
		{
			// u Modern designu prikazujemo samo custom title text, ne i tekst koji se dobije iz ikone
			// u Windows designu prikazujemo ili custom title tekst, a ako nije setiran, onda tekst dekodiran iz ikone
			let showTitle = false;
			if (this._viewMode == DialogMode.Panel)
				showTitle = false;
			else
				showTitle = !String.IsNullOrWhiteSpace(title);

			// don't allow empty title, use text depending on icon text
			$$calysto(this._dialogControlEl).Query("//.calystoWindowTitleText")
				.SetProperty("innerHTML", title || "")
				.SetVisible(showTitle);

			$$calysto(this._windowEl).AddClass("windowTitleHidden", !showTitle);

			return this;
		}

		public Title(title: string)
		{
			this._titleText = title; // title won't change if icon is changed using this.Icon(name)
			return this.RenderTitle(title);
		}

		public Icon(iconName: keyof typeof DialogIcon)
		{
			this._iconName = iconName;
			if (!this._titleText) this.RenderTitle(GetTitle(iconName)); // use text based on icon
			let showIcon = !!this._iconName && this._iconName != "none";
			$$calysto(this._windowEl).AddClass("calystoShowIcon", showIcon);
			let cls1 = "calystoWindowIcon fa " + GetFAIconClass(this._iconName) + " " + GetIconColorClass(this._iconName);
			$$calysto(this._windowEl).Query("//.calystoWindowTd1/div").SetVisible(showIcon).SetClass(cls1);
			return this;
		}

		/**
		* Assign single callback, overwrite previous callback.
		 * this inside fn is current Calysto.Dialog instance
		 * @param {(buttonEl} fn
		 * @param {string} buttonName
		 * @param {function} ev
		 * @returns
		 */
		public OnButtonClick = new MulticastDelegate<(dialog: Calysto.Dialog, buttonName: DialogButton | string, ev: Event) => void>().AsFunc(this);

		/**
		 * Assign single callback, overwrite previous callback.
		 * Invoked when dialog is shown.
		 * @param fn
		 */
		public OnShown = new MulticastDelegate<(dialog: Calysto.Dialog) => void>().AsFunc(this);

		/**
		 * Assign single callback, overwrite previous callback.
		 * Invoked when dialog close is started.
		*	If action returns false, will abort closing action
		 * @param fn
		 */
		public OnClosing = new MulticastDelegate<(dialog: Calysto.Dialog) => void>().AsFunc(this);

		/**
		 * Assign single callback, overwrite previous callback.
		 * Invoked when dialog is removed from DOM.
		 * @param fn
		 */
		public OnClosed = new MulticastDelegate<(dialog: Calysto.Dialog) => void>().AsFunc(this);

		public CloseMode(mode: keyof typeof CloseMode)
		{
			this._closeMode = mode;
			return this;
		}

		private fnButtonClickHandler(sender: HTMLButtonElement | string, ev: Event)
		{
			let name = <string>(typeof sender == "string" ? sender : (<HTMLButtonElement>sender).getAttribute("calysto_button_name"));

			if (name == DialogButton.XClose)
				this.Close();
			else
				this.OnButtonClick.Invoke(f => f(this, name, ev));
		}

		private _buttons: ButtonItem[] = [];

		/**
		 * Hide all buttons, including X button
		 */
		public HideButtons()
		{
			$$calysto([this._buttonsEl, this._xButtonEl]).SetVisible(false);
			return this;
		}

		public ButtonXClose()
		{
			return this.Button(DialogButton.XClose);
		}

		/**
		 * XClose, OK, CANCEL, ...
		 * @param name XClose, OK, CANCEL, ...
		 * @param isDefault if true, focus button
		 */
		public Button(name: string, isDefault?: boolean)
		{
			let item: ButtonItem = {
				name: name,
				isDefault: !!isDefault,
				isRendered: false
			};

			this._buttons.push(item);

			item.isRendered = true;

			let btnEl;
			if (item.name == DialogButton.XClose)
			{
				btnEl = <HTMLButtonElement>$$calysto(this._dialogControlEl).Query("//.calystoWindowXMark").SetVisible(true).Query("/button").First();
			}
			else
			{
				$$calysto(this._buttonsEl).SetVisible(true).AddChildren(
					btnEl = <HTMLButtonElement>Calysto.DomQuery.CreateElement("button")
						.AddClass("calystoBtn")
						.SetAttribute("calysto_button_name", item.name)
						.SetInnerHtml(item.name)
						.First()
				);
			}

			if (item.isDefault) this._focusButtonEl = btnEl;
			$$calysto<HTMLButtonElement>(btnEl).OnClick((s, e) => this.fnButtonClickHandler(s, e)); // use lambda to keep scope

			return this;
		}

		/**
		 * Append content
		 * @param content
		 */
		public AppendContent(content: string | HTMLElement)
		{
			if ((content && content["nodeType"] > 0) // DOM element
				// html closing tag becuase it may contain generic <IList> which is not html indicator
				// selfclosing tag: <meta.../> 
				// ending tag: </div>
				|| (typeof content == "string" && content.match(new RegExp("(<[^>/\\s]+/>)|(</[^>/\\s]+>)")))
			)
			{
				$$calysto(this._tdContentEl).AddChildren(content);
			}
			else
			{
				// pure text, encapsulate into pre element, respecting new lines in text	
				// text has to be html encoded because <null> is understood as html tag an not shown unless it is encoded as &lt;null&gt;
				$$calysto(this._tdContentEl).AddChildren(
					Calysto.DomQuery.CreateElement("pre")
					.AddClass("calystoWindowPre")
					.SetInnerHtml(
						Calysto.Utility.Html.HtmlEncodeSimple(<string>content)
					)
				);
			}
			return this;
		}

		/**
		 * Set content. Remove previous content.
		 * @param content
		 */
		public Content(content: string | HTMLElement)
		{
			this._tdContentEl.innerHTML = "";
			return this.AppendContent(content);
		};

		/**
		 * Set mask opacity (0.0 - 1.0), 1.0: full visibility
		 * @param value 0.0 - 1.0 (full visibility = 1.0)
		 */
		public MaskOpacity(value: number)
		{
			$$calysto(this._maskEl).SetOpacity(value);
			return this;
		}

		public Background(value: string)
		{
			$$calysto(this._windowEl).ApplyStyle("background", value);
			return this;
		}

		private _intervalId: number | null;

		public Close()
		{
			this.OnClosing.Invoke(f => f(this));

			if (this._intervalId)
			{
				clearInterval(this._intervalId);
				this._intervalId = null;
			}

			_dialogsStack.Remove(this);

			////this._dialogBoxContainerEl.style.top = 0 + "px"; // to animate up while fading out
			$$calysto(this._dialogControlEl).RemoveClass("showDialog").Sleep(400, q =>
			{
				q.SetVisible(false);

				if (this._closeMode == "destroy")
					q.RemoveFromDom();

				this.OnClosed.Invoke(f => f(this));

				if (!_dialogsStack.Any() && this._viewMode == DialogMode.Panel)
				{
					OverflowProvider.RemoveOverflow();
				}
			});
		}

		public AutoClose(delayMs: number)
		{
			if (delayMs > 0)
				setTimeout(() => this.Close(), delayMs);

			return this;
		}

		private fnFixPosition()
		{
			if (this._viewMode == DialogMode.Panel)
			{

			}
			else if (this._viewMode == DialogMode.Alert)
			{
				var margin = 10;

				// max-height has to be set on calystoWindowContent for scroll:overflow to work, while width works fine anyway
				var viewport = Calysto.Utility.Dom.GetViewportDiv();

				var maxContentWidth = viewport.clientWidth - margin * 2;
				var minContentWidth = Math.min(maxContentWidth, 400);
				var maxContentHeight = viewport.clientHeight - margin * 2 - this._titleEl.offsetHeight - this._buttonsEl.offsetHeight;

				// element height with overflow:auto has to be limited for scroll to show
				// use hidden to hide scrollbar x when not required
				this._contentEl.style.overflowX = this._innerContentEl.offsetWidth > maxContentWidth ? "scroll" : "hidden";
				this._contentEl.style.overflowY = this._innerContentEl.offsetHeight > maxContentHeight ? "scroll" : "hidden";
				this._contentEl.style.maxWidth = maxContentWidth + "px";
				this._contentEl.style.maxHeight = maxContentHeight + "px";
				this._contentEl.style.minWidth = minContentWidth + "px";

				this._windowEl.style.maxWidth = maxContentWidth + "px";

				// table can be centered with margin:auto, it works for table only

				// don't use css transform because letters are blured
				// horizontaly is centered with left:50% and margin-left:-50% in child element
				// verticaly can't be centered with css, without transform
				var hspace = Math.round((viewport.clientHeight - 2 * margin - this._dialogBoxEl.offsetHeight) * 0.2);
				if (!(hspace > margin)) hspace = margin;
				this._dialogBoxEl.style.top = hspace + "px";
			}
		}

		private fnFirstTimeInit()
		{
			if (this._initDone) return;
			this._initDone = true;

			(document.body || document.documentElement).appendChild(this._dialogControlEl);

			if (this._viewMode == DialogMode.Panel)
			{
				$$calysto(this._titleEl).SetVisible(false);

				this._dialogBoxEl.style.padding = "20px 5px";

				this._dialogBoxContainerEl.style.overflowY = "scroll"; // always show, prevent from moving popup left-right when scrollbar is shown/hidden
				this._dialogBoxContainerEl.style.overflowX = "auto";

				this._dialogBoxContainerEl.style.bottom = "0";

				setTimeout(() =>
				{
					this._dialogBoxContainerEl.scrollTop = 0;
					this._dialogBoxContainerEl.scrollLeft = 0;
				}, 1);

			}
			else if (this._viewMode == DialogMode.Alert)
			{
				$$calysto(this._windowEl).AddClass("windowBorder");

				var handler = new Calysto.Utility.Dom.ScrollHandler();

				$$calysto([this._dialogBoxContainerEl]).On(["scroll", "mousewheel", "wheel", "DOMMouseScroll"], (sender, ev) =>
				{
					handler.HandleScroll(this._contentEl, <WheelEvent>ev);
					return false; // disable scroll propagation to page because we want to scroll _innerContentEl
				});
			}
		}

		private fnShowWorker()
		{
			this.fnFirstTimeInit();

			if (!this._intervalId && this._viewMode == DialogMode.Alert)
			{
				// periodic position fix
				this._intervalId = setInterval(() => this.fnFixPosition(), 1000);
			}

			// element has to be visible in order to be able to measure dimensions and transform
			$$calysto(this._dialogControlEl).SetVisible(true);
			// za IE treba pokrenuti visibility iz novog threada da bi radila animacija sa transition ispravno
			setTimeout(() => $$calysto(this._dialogControlEl).AddClass("showDialog"), 5);

			// dialog height is changing while translating into view, translation duration is 300 ms, so let's fix position regularly up to 400 ms
			let dtStart1 = Date.now();
			let interval1 = setInterval(() =>
			{
				this.fnFixPosition();
				if (Date.now() - dtStart1 > 400)
					clearInterval(interval1);
			}, 10);

			if (this._focusButtonEl)
				this._focusButtonEl.focus();

			this.OnShown.Invoke(f => f(this));
		}

		private _closeOnMaskAssigned: boolean;

		public CloseOnMaskClick()
		{
			if (this._closeOnMaskAssigned) return this;
			this._closeOnMaskAssigned = true;

			// let's close panel dialog on click on mask
			// we have to use OnMouseDown, not OnClick because OnClick is triggered when mouse button is released on mask, but pressed on panel
			$$calysto([this._maskEl, this._dialogBoxContainerEl, this._windowEl]).OnMouseDown((sender, ev) =>
			{
				if (Calysto.Event.IsLeftMouseButton(<MouseEvent>ev) && Calysto.Event.GetTarget(ev) == sender)
				{
					this.fnButtonClickHandler(DialogButton.XClose, ev);
					return false; // stop propagation
				}
				return undefined;
			});
			return this;
		}

		public CloseOnEscKey()
		{
			this._closeOnEscKey = true;
			return this;
		}

		public ViewMode(mode: DialogMode)
		{
			this._viewMode = mode;
			return this;
		}

		/**
		 * Show dialog in Calysto manner
		 */
		public Show()
		{
			if (!_hasEscEvent)
			{
				_hasEscEvent = true;

				Calysto.Page.OnEscKey(() =>
				{
					// esc key should not close information dialog without buttons:
					let dd = _dialogsStack[_dialogsStack.length - 1];
					if (dd && dd._closeOnEscKey)
					{
						dd.fnButtonClickHandler(DialogButton.XClose, <any>{});
					}
				});
			}

			this.fnShowWorker();

			_dialogsStack.push(this);

			if (this._viewMode == DialogMode.Panel)
			{
				OverflowProvider.CreateOverflow();
			}

			return this;
		}

		/**
		 * Return clicked button name.
		 * @param closeOnClick Default true.
		 */
		public async WaitButtonAsync(closeOnClick = true)
		{
			return new Promise((resolve, reject) =>
			{
				this.OnButtonClick((dialog, buttonName, ev) =>
				{
					if (closeOnClick)
						dialog.Close();

					resolve(buttonName);
				});
			});
		}
	}
}

//#region static methods

//*******************************************************************
// static methods
//*******************************************************************
namespace Calysto.Dialog
{
	/**
	 * Find Calysto.Dialog instance containing childElement
	 * @param childEl
	 */
	export function FindDialog(childEl: HTMLElement): Calysto.Dialog
	{
		return <Calysto.Dialog>$$calysto(childEl).AncestorNodes().Select(o => o["__calystoDialog"]).Where(o=>!!o).FirstOrDefault();
	}

	export function ShowVersionExpired()
	{
		if (Calysto.Page.IsPageReloading || Calysto.Page.IsVersionExpiredVisible) return;

		Calysto.Page.IsVersionExpiredVisible = true;

		return new Calysto.Dialog()
			.Content(Resources.CalystoLang.JavascriptEngineIsOutdatedInformation)
			.Icon("warning")
			.Button(Resources.CalystoLang.Reload)
			.Button(Resources.CalystoLang.Cancel)
			.ButtonXClose()
			.OnButtonClick((dialog, name)=>
			{
				Calysto.Page.IsVersionExpiredVisible = false;
				dialog.Close();
				if (name == Resources.CalystoLang.Reload)
				{
					document.documentElement.className += ' calystoAjaxLoading'; // show wait cursor
					new Calysto.Dialog().Content(Resources.CalystoLang.PageIsReloadingPleaseWait).Icon("info").Show();
					Calysto.Page.IsPageReloading = true;
					setTimeout(() => window.location.reload(true), 1);
				}
			}).Show();
	}

	export function CreateInformation(msg:string, title?:string)
	{
		return new Calysto.Dialog()
			.Title(<string>title) // title has to be set before icon
			.Icon("info") // if title is empty, will set title based on icon
			.Content(msg)
			.ButtonXClose()
			.CloseOnEscKey()
	}

	function CreateDialogImpl(msg: string, iconName?: keyof typeof DialogIcon, title?: string, addXClose?: boolean)
	{
		/// <summary>
		/// Show alert() message.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="iconName" type="string"> info, warning, error, question, success </param>

		return new Calysto.Dialog()
			.Title(<string>title)
			.Icon(<any>iconName)
			.Content(msg)
			.ButtonXClose()
			.Button(Resources.CalystoLang.Close)
			.CloseOnEscKey()
			.OnButtonClick((dialog, buttonName, ev)=>
			{
				dialog.Close();
			})
	};

	/**
	 * Buttons have to be added. OnButtonClick has to be added. Show is already invoked.
	 * @param msg
	 * @param title
	 */
	export function CreateConfirm(msg:string, title?:string)
	{
		return new Calysto.Dialog()
			.Title(<string>title)
			.Icon("question")
			.Content(msg)
			.ButtonXClose()
			.CloseOnEscKey()
			.CloseOnMaskClick()
			////.Button("Close") // no buttons, they should be added from user code, e.g.: YES, NO
			////.OnClick((dialog, buttonName, ev)=>
			////{
			////	dialog.Close();
			////})
			////.Show();
	};

	export function CreateAlert(msg: string, iconName?: keyof typeof DialogIcon, title?:string)
	{
		/// <summary>
		/// Show alert() message.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="iconName" type="string"> info, warning, error, question, success </param>
		return CreateDialogImpl(msg, iconName, title);
	}

	export function CreateError (msg:string, title?:string)
	{
		return CreateDialogImpl(msg, "error", title);
	};

	export function CreateWarning(msg: string, title?: string)
	{
		return CreateDialogImpl(msg, "warning", title);
	};

	export function CreateSuccess(msg: string, title?: string)
	{
		return CreateDialogImpl(msg, "success", title);
	};

	export function CreatePanel()
	{
		return new Calysto.Dialog()
			.CloseOnEscKey()
			.CloseOnMaskClick()
			.ViewMode(DialogMode.Panel);
	};
}

//#endregion

//#region usage example

/*******************************************************************
function ShowDialog()
{
	new Calysto.Dialog()
	.Title("Warning")
	.Content("Carefull what are you doing!")
	.Button("Yes")
	.Button("No")
	.ButtonXClose()
	.Modal(true)
	.Icon("warning")
	.OnClick(function (dialog, buttonName)
	{
		if (buttonName == "XClose") dialog.Close();
		console.log("clicked: " + buttonName);
	})
	.Show();
}
*******************************************************************/
//#endregion
