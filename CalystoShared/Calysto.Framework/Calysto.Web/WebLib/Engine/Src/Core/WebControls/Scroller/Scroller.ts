namespace Calysto.WebControls
{
	/* CalystoScroller html example:
		
		create div with long content horizontaly or verticaly like this:
			<div class="calystoScroller" style="overflow:hidden;position:relative;width:200px;height:120px;;border:solid 1px green;">
				<div class="calystoScrollerContent" style="background-color:lavenderblush;height:200px;width:800px;">ovo je veliki sadrzaj</div>
			</div>
	
		and it will add controls into div.calystoScroller
	 
		how to use it:
		Calysto.Page.OnInteractive.Add(function ()
		{
			Calysto.Web.UI.WebControls.CalystoScroller.Create(".calystoScroller");
		});
	*/

	// Scroller.scss is included in Style/_dist/_includes.scss

	//let _cssLoaded = false;
	//function EnsureCss()
	//{
	//	if (!_cssLoaded)
	//	{
	//		_cssLoaded = true;
	//		let url = new Web.CalystoVirtualPathHelper(`~/Engine/Src/Core/WebControls/Scroller/Scroller.css?v=${Calysto.Core.Constants.ModuleVersion}`).ToVirtualUrlPath();
	//		ScriptLoader.LoadCSSFile(url);
	//	}
	//}

	var _html =
		`<div class="calystoScrollerCtrl calystoScrollerY">
			<div class="calystoScrollerMarker"></div>
		</div>
		<div class="calystoScrollerCtrl calystoScrollerX">
			<div class="calystoScrollerMarker"></div>
		</div>`;

	type MoveStatItem = { time: number, ev: MouseEvent };

	type StartCondition = {
		event: any,
		contentLeft: number,
		contentTop: number,
		vMarkerTop: number,
		hMarkerLeft: number
	};

	export class CalystoScroller
	{
		/** scrollbar min opacity, 0 - 100 */
		public MinOpacity = 10;

		/** scrollbar max opacity, 0 - 100 */
		public MaxOpacity = 100;

		private _currentTop: number;
		/** current top position (negative number) */
		public get CurrentTop() { return this._currentTop; }
		public set CurrentTop(value: number) { this.SetScrollPosition(value, <any>null) }

		private _currentLeft: number;
		/** current left position (negative number) */
		public get CurrentLeft() { return this._currentLeft }
		public set CurrentLeft(value: number) {this.SetScrollPosition(<any>null, value)}

		private firstInitDone = false;
		private contentEl: HTMLElement;
		private mainEl: HTMLElement;
		private contentElWidth = -1;
		private contentElHeight = -1;
		private mainElWidth = -1;
		private mainElHeight = -1;
		private hSliderEl: HTMLElement;
		private hMarkerEl: HTMLElement;
		private hAR: number;
		private showHorizontal: boolean;
		private vSliderEl: HTMLElement;
		private vMarkerEl: HTMLElement;
		private vAR: number;
		private showVertical: boolean;
		private maxMarkerLeft: number;
		private maxMarkerTop: number;
		private accelerationAbort: boolean;
		private moveStatistics: MoveStatItem[];
		private markerDragging: HTMLElement;
		private startCondition: StartCondition;
		private minContentTop: number;
		private minContentLeft: number;

		public constructor(mainElement: HTMLElement)
		{
			//EnsureCss();
			this.mainEl = mainElement;
		}

		//#region mouse wheel handling

		private ScrollersAdjustContent(top: number, left: number)
		{
			// contentEl je siri od mainEl
			// slider ima hod jednak sirini mainEl pa se top i left moraju povecati tako da kad dodje do kraja mainEl-a, contentEl se cijeli pomakne
			let top1 = -1 * (top / this.maxMarkerTop) * (this.contentEl.scrollHeight - this.mainEl.clientHeight);
			let left1 = -1 * (left / this.maxMarkerLeft) * (this.contentEl.scrollWidth - this.mainEl.clientWidth);
			return this.SetScrollPosition(top1, left1);
		}

		private SetScrollPosition(top: number, left: number)
		{
			if (typeof (top) == "number")
			{
				this.minContentTop = this.mainEl.clientHeight - this.contentEl.scrollHeight; // let's calculate every time, it is safer
				
				if (top < this.minContentTop) { top = this.minContentTop; }
				if (top > 0) { top = 0; }

				top = Math.round(top);
				this._currentTop = top;
				this.contentEl.style.marginTop = top + "px";

				var markerTop = -1 * (this.contentEl.offsetTop / this.contentEl.scrollHeight * (this.vSliderEl.offsetHeight));
				this.vMarkerEl.style.top = Math.round(markerTop) + "px";
			}

			if (typeof (left) == "number")
			{
				this.minContentLeft = this.mainEl.clientWidth - this.contentEl.scrollWidth;

				if (left < this.minContentLeft) { left = this.minContentLeft; }
				if (left > 0) { left = 0; }

				left = Math.round(left);
				this._currentLeft = left;
				this.contentEl.style.marginLeft = left + "px";

				var markerLeft = -1 * (this.contentEl.offsetLeft / this.contentEl.scrollWidth * (this.hSliderEl.offsetWidth));
				this.hMarkerEl.style.left = Math.round(markerLeft) + "px";
			}

			return { endH: left == 0 || left == this.minContentLeft, endV: top == 0 || top == this.minContentTop }; // means scroll is at the end, so continue scrolling page
		}

		private WheelAdjustSliderX(sender, ev)
		{
			if (this.showHorizontal)
			{
				ev = ev || {};
				var deltaX = 0;
				if ("deltaX" in ev)
				{
					deltaX = ev.deltaX;
				}
				else if ("wheelDeltaX" in ev)
				{
					deltaX = -(ev.wheelDeltaX);
				}

				// ev.deltaMode: 0=pixel, 1=line, 2=page
				// ev.axis: 1=horizontal, 2=vertical
				if (ev.deltaMode == 1)
				{
					deltaX *= 30;
				}

				var left = this.contentEl.offsetLeft - deltaX;
				this.SetScrollPosition(<any>null, left);
			}
		}

		private WheelAdjustSliderY(sender, ev)
		{
			// ako je shift key, mouse wheel koristimo za pomicanje lijevo-desno
			if (this.showVertical || ev?.shiftKey)
			{
				ev = ev || {};
				var deltaY = 0;
				if ("deltaY" in ev)
				{
					deltaY = ev.deltaY;
				}
				else if ("wheelDeltaY" in ev)
				{
					deltaY = -(ev.wheelDeltaY);
				}

				// ev.deltaMode: 0=pixel, 1=line, 2=page
				// ev.axis: 1=horizontal, 2=vertical
				if (ev.deltaMode == 1)
				{
					deltaY *= 30;
				}

				if (ev.shiftKey)
				{
					// use mouse wheel to move left-right
					var left = this.contentEl.offsetLeft - deltaY;
					this.SetScrollPosition(<any>null, left);
				}
				else
				{
					// move up-down
					var top = this.contentEl.offsetTop - deltaY;
					this.SetScrollPosition(top, <any>null);
				}
			}
		}

		private WheelAdjustSliders(sender, ev)
		{
			this.WheelAdjustSliderX(sender, ev);
			this.WheelAdjustSliderY(sender, ev);
		}

		//#endregion

		//#region velocity handling

		/**
		 * 
		 * @param sender
		 * @param velocity pixel/second
		 * @param isAxisY
		 */
		private CreateAnimator(sender, velocity, isAxisY)
		{
			this.accelerationAbort = false;
			var lastVal = 0;
			// izgleda prirodno za ovu kombinaciju: velocity/3, easeOutQuart, duration 1000

			var animator = new Calysto.Animator().AddValue(0, velocity/3, (anim, currVal) =>
			{
				if (this.accelerationAbort)
				{
					anim.Abort();
				}
				else
				{
					var obj = {};
					obj[isAxisY ? "deltaY" : "deltaX"] = lastVal - currVal;
					if (isAxisY)
					{
						this.WheelAdjustSliderY(sender, obj);
					}
					else
					{
						this.WheelAdjustSliderX(sender, obj);
					}
					lastVal = currVal;
				}
			}).Easing("easeOutQuart").Duration(1000).Start();
		}

		private CalculateVelocity(sender, statArr: MoveStatItem[])
		{
			var dt = new Date().getTime();
			var list = new Calysto.List(statArr).Reverse().Take(10).ToList();

			var first = list.FirstOrDefault();
			var last = list.LastOrDefault();

			if (first && last && first.ev && last.ev && first.time && last.time)
			{
				return {
					deltaX: last.ev.pageX - first.ev.pageX,
					deltaY: last.ev.pageY - first.ev.pageX,
					/**pixel/second*/
					velocityX: (last.ev.pageX - first.ev.pageX) / (last.time - first.time) * 1000 || 0,
					/**pixel/second*/
					velocityY: (last.ev.pageY - first.ev.pageY) / (last.time - first.time) * 1000 || 0,
					items: statArr?.length
				};
			}
			return undefined;
		}

		private HandleAcceleration(sender, statArr)
		{
			var velocityObj = this.CalculateVelocity(sender, statArr);
			if (!velocityObj)
			{
				return;
			}

			if (this.showVertical && velocityObj.velocityY && Math.abs(velocityObj.deltaY || 0) > 10)
			{
				this.CreateAnimator(sender, velocityObj.velocityY, true);
			}

			if (this.showHorizontal && velocityObj.velocityX && Math.abs(velocityObj.deltaX || 0) > 10)
			{
				this.CreateAnimator(sender, velocityObj.velocityX, false);
			}
		}

		//#endregion

		//#region initialize

		private InitElements()
		{
			/// <summary>
			/// Has to mesure elements and adjust scrollbars. Has to be invoked again if container dimensions are changed.
			/// </summary>

			// ova funkcija se poziva na kraju iz timera skvakih 1-2 sekunde ako se content resiza da se postave kontrole scrollera ispravno

			if (!this.firstInitDone)
			{
				this.firstInitDone = true;

				// this.mainEl is scroll-container
				// make sure it has overflow:hidden and position relative since sliders are absolute
				this.contentEl = $$calysto(this.mainEl).ApplyStyle("overflow:hidden;position:relative;")
					.ChildNodes().Where(function (o) { return o.nodeType == 1 }).First(); // first level child only

				$$calysto(this.mainEl).AddChildren(_html);
			}

			// iPhone problem i rjesenje:
			// treba gledati contentEl.scrollWidth jer on prikazuje pravu sirinu contenta koji je siri od mainEl contenta
			// da bi radio contentEl.style.marginLeft, treba postaviti contentEl.style.width = contentEl.scrollWidth + "px"

			let contentWidth = this.contentEl.scrollWidth; // radi iPhonea gledati scrollWidth jer pokazuje stvranu sirinu
			this.contentEl.style.width = contentWidth + "px";
			this.hSliderEl = $$calysto(this.mainEl).Query("//.calystoScrollerX").SetOpacity(0).ApplyStyle("display", "block").First();
			this.hMarkerEl = $$calysto(this.hSliderEl).Query("//.calystoScrollerMarker").First();
			this.hAR = this.mainEl.clientWidth / contentWidth;
			this.showHorizontal = this.hAR < 1;

			let contentHeight = this.contentEl.scrollHeight;
			this.contentEl.style.height = contentHeight + "px";
			this.vSliderEl = $$calysto(this.mainEl).Query("//.calystoScrollerY").SetOpacity(0).ApplyStyle("display", "block").First();
			this.vMarkerEl = $$calysto(this.vSliderEl).Query("//.calystoScrollerMarker").First();
			this.vAR = this.mainEl.clientHeight / contentHeight;
			this.showVertical = this.vAR < 1;

			$$calysto(this.vSliderEl).SetOpacity(this.MinOpacity).ApplyStyle("display", this.showVertical ? "block" : "none");
			$$calysto(this.hSliderEl).SetOpacity(this.MinOpacity).ApplyStyle("display", this.showHorizontal ? "block" : "none");

			this.hMarkerEl.style.width = Math.round(this.hSliderEl.offsetWidth * this.hAR) + "px";
			this.maxMarkerLeft = this.hMarkerEl?.parentNode?.["clientWidth"] - this.hMarkerEl.offsetWidth;

			this.vMarkerEl.style.height = Math.round(this.vSliderEl.offsetHeight * this.vAR) + "px";
			this.maxMarkerTop = this.vMarkerEl?.parentNode?.["clientHeight"] - this.vMarkerEl.offsetHeight;
		}

		// on iPhone event object is reused, so create it's copy
		// na iPhoneu se event objekt reusa pa treba skopirati vrijednosti:
		private CopyEvent(ev)
		{
			if (ev)
			{
				return { pageX: ev.pageX, pageY: ev.pageY, clientX: ev.clientX, clientY: ev.clientX };
			}
			return null;
		}

		private InitializeEvents()
		{
			// this.hMarkerEl, this.vMarkerEl
			$$calysto([this.hMarkerEl, this.vMarkerEl]).On(["mousedown", "touchstart"], (sender, ev) =>
			{
				this.markerDragging = sender;
			});

			let faderAnimator: Calysto.Animator;

			type TShowState = "Showing" | "Hiding" | "None";

			let currentShowState: TShowState = "None";

			let fnScrollbarsShow = () =>
			{
				if (currentShowState == "Showing") return;
				currentShowState = "Showing";
				faderAnimator?.Abort();
				faderAnimator = $$calysto([this.hSliderEl, this.vSliderEl]).ToAnimator({ opacity: this.MaxOpacity }).Start();
			};

			let fnScrollbarsHide = () =>
			{
				if (currentShowState == "Hiding") return;
				currentShowState = "Hiding";
				faderAnimator?.Abort();
				faderAnimator = $$calysto([this.hSliderEl, this.vSliderEl]).ToAnimator({ opacity: this.MinOpacity }).Start();
			};

			// this.mainEl
			$$calysto(this.mainEl).ForEach((el, n) =>
			{
				// create initial slider and apply settings
				$$calysto([this.hSliderEl, this.vSliderEl]).SetOpacity(this.MinOpacity);
				this.WheelAdjustSliders(el, null);

			}).On(["hover", "mouseover", "mousemove", "wheel"], (sender, ev) =>
			{
				fnScrollbarsShow();
			}).On(["hout"], (sender, ev) =>
			{
				// on mobile, mouseout triggers when we click something else, different element from element where touchstart was triggered
				// on mobile on touch events are triggered: touchstart, toucheend, mouseover, mousedown, so it would keep 100% opaciti, so use hack:
				fnScrollbarsHide();
			}).On(["scroll", "mousewheel", "wheel", "DOMMouseScroll"], (sender, ev) =>
			{
				let doAdjust = false;
				if (this.showVertical && (ev.type == "wheel" || ev.type == "mousewheel"))
				{
					doAdjust = true;
				}
				else if (this.showHorizontal && ev?.["shiftKey"])
				{
					doAdjust = true;
				}
				else if (this.showHorizontal && (Math.abs(ev?.["deltaX"]) > 0 || Math.abs(ev?.["wheelDeltaX"]) > 0))
				{
					doAdjust = true;
				}

				if (doAdjust)
				{
					this.WheelAdjustSliders(sender, ev);
					return false; // stop propagation
				}
				return true;

				////}).On(["keydown"], function (sender, ev)
				////{
				////	// WRITE THE CODE: up, down, left, right, page up, page down

			}).On(["mousedown", "touchstart"], (sender, ev: any) =>
			{
				if (ev.type == "touchstart")
				{
					ev = ev.touches[0];
				}
				this.moveStatistics = [];
				this.accelerationAbort = true;

				this.startCondition = {
					event: <any>this.CopyEvent(ev),
					contentLeft: this.contentEl.offsetLeft,
					contentTop: this.contentEl.offsetTop,
					vMarkerTop: this.vMarkerEl.offsetTop,
					hMarkerLeft: this.hMarkerEl.offsetLeft
				};
				// return true or nothing to propagate click event if it is touchstart
				// return true; // stop propagation

			});

			// document
			$$calysto(document).On(["mouseup", "touchend"], (sender, ev) =>
			{
				if (this.moveStatistics && !this.markerDragging)
				{
					this.HandleAcceleration(this.mainEl, this.moveStatistics);
				}
				this.moveStatistics = <any>null;
				this.markerDragging = <any>null;
				this.startCondition = <any>null;
			});

			// As stated by Google, they've changed the behavior of passive event listeners only for window, document or body elements.
			// so make touchmove event bind to div element intead, not document
			// trebamo event na document da bi radilo povlacenje scrollbara dobro
			// trebamo event na mainEl da bi na mobitelu radilo povlacenje contenta dobro
			$$calysto([document, this.mainEl]).On(["mousemove", "touchmove"], (sender, ev: any) =>
			{
				if (!this.startCondition) { return true; }

				if (ev.type == "touchmove")
				{
					ev = ev.touches[0];
				}

				fnScrollbarsShow();
				
				this.moveStatistics.push({ time: new Date().getTime(), ev: <any>this.CopyEvent(ev) });

				if (this.markerDragging == this.hMarkerEl)
				{
					var left = Math.round(this.startCondition.hMarkerLeft - (this.startCondition.event.pageX - ev.pageX));
					this.ScrollersAdjustContent(<any>null, left);
					return false; // stop propagation
				}
				else if (this.markerDragging == this.vMarkerEl)
				{
					var top = Math.round(this.startCondition.vMarkerTop - (this.startCondition.event.pageY - ev.pageY));
					this.ScrollersAdjustContent(top, <any>null);
					return false; // stop propagation
				}
				else if (!this.markerDragging)
				{
					// content dragging
					var deltaY = this.startCondition.event.pageY - ev.pageY;
					var deltaX = this.startCondition.event.pageX - ev.pageX;
					var top = Math.round(this.startCondition.contentTop - deltaY);
					var left = Math.round(this.startCondition.contentLeft - deltaX);

					var res = this.SetScrollPosition(top, left);
					// on Android, we may return true always, if it is at the scroll end, it will contine with page scroll
					// this is required on iPhone because it scrolls scroll element and page at the same time
					// if comes to scroll end, continue event propagation to the page
					// if didn't come to scoll end, stop propagation, return false
					// iPhone is reusing event object
					
					if (Math.abs(deltaX) > 10 && res?.endH)
					{
						return true; // continue with page scroll
					}
					else if (Math.abs(deltaY) > 10 && res?.endV)
					{
						return true;
					}
					else
					{
						return false;
					}
				}

				return true;
			});
		}

		public Start()
		{
			this.InitElements();

			this.InitializeEvents();

			var _interval1 = setInterval(() =>
			{
				if (!this.contentEl || !this.mainEl || !(this.contentEl.scrollHeight > 0) || !(this.contentEl.scrollWidth > 0))
				{
					// if removed from DOM, don't clear timeout, it may be reattached to dom later
					return;
				}

				if (this.contentEl.scrollWidth != this.contentElWidth
					|| this.contentEl.scrollHeight != this.contentElHeight
					|| this.mainEl.clientWidth != this.mainElWidth
					|| this.mainEl.clientHeight != this.mainElHeight)
				{
					this.contentElWidth = this.contentEl.scrollWidth;
					this.contentElHeight = this.contentEl.scrollHeight;
					this.mainElWidth = this.mainEl.clientWidth;
					this.mainElHeight = this.mainEl.clientHeight;

					this.InitElements();
				}
			}, 2000);
		}

		//#endregion

		/**
		* Initialize calystoScroller. If content or container are resized, scroller is refreshed every 1 second.
		* @param selector if not provided, will select all elements with class calystoScroller
		*/
		public static Create(selector?)
		{
			$$calysto(selector || ".calystoScroller").Where(function (o) { return !o.__calystoScroller })
				.ForEach(function (o) { o.__calystoScroller = true })
				.ForEach(function (o)
				{
					let scr1 = new CalystoScroller(o);
					scr1.Start();
					o.__calystoScroller = scr1;
				});
		}
	}
}
