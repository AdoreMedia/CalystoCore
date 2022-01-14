namespace Calysto
{
	namespace EasingHelper
	{
		const easings =
		{
			// http://easings.net/

			// arg0: time fraction or time progress: 0...1, elapsed time / duration
			// arg1: elapsed time, 0...100
			// arg2: startValue
			// arg3: total value delta: finalValue - startValue
			// arg4: total duration, 100

			linear: function (p, n, firstNum, diff)
			{
				return firstNum + diff * p;
			},
			swing: function (p, n, firstNum, diff)
			{
				return ((-Math.cos(p * Math.PI) / 2) + 0.5) * diff + firstNum;
			},

			easeInQuad: function (x, t, b, c, d)
			{
				return c * (t /= d) * t + b;
			},
			easeOutQuad: function (x, t, b, c, d)
			{
				return -c * (t /= d) * (t - 2) + b;
			},
			easeInOutQuad: function (x, t, b, c, d)
			{
				if ((t /= d / 2) < 1) return c / 2 * t * t + b;
				return -c / 2 * ((--t) * (t - 2) - 1) + b;
			},
			easeInCubic: function (x, t, b, c, d)
			{
				return c * (t /= d) * t * t + b;
			},
			easeOutCubic: function (x, t, b, c, d)
			{
				return c * ((t = t / d - 1) * t * t + 1) + b;
			},
			easeInOutCubic: function (x, t, b, c, d)
			{
				if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
				return c / 2 * ((t -= 2) * t * t + 2) + b;
			},
			easeInQuart: function (x, t, b, c, d)
			{
				return c * (t /= d) * t * t * t + b;
			},
			easeOutQuart: function (x, t, b, c, d)
			{
				return -c * ((t = t / d - 1) * t * t * t - 1) + b;
			},
			easeInOutQuart: function (x, t, b, c, d)
			{
				if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
				return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
			},
			easeInQuint: function (x, t, b, c, d)
			{
				return c * (t /= d) * t * t * t * t + b;
			},
			easeOutQuint: function (x, t, b, c, d)
			{
				return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
			},
			easeInOutQuint: function (x, t, b, c, d)
			{
				if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
				return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
			},
			easeInSine: function (x, t, b, c, d)
			{
				return -c * Math.cos(t / d * (Math.PI / 2)) + c + b;
			},
			easeOutSine: function (x, t, b, c, d)
			{
				return c * Math.sin(t / d * (Math.PI / 2)) + b;
			},
			easeInOutSine: function (x, t, b, c, d)
			{
				return -c / 2 * (Math.cos(Math.PI * t / d) - 1) + b;
			},
			easeInExpo: function (x, t, b, c, d)
			{
				return (t == 0) ? b : c * Math.pow(2, 10 * (t / d - 1)) + b;
			},
			easeOutExpo: function (x, t, b, c, d)
			{
				return (t == d) ? b + c : c * (-Math.pow(2, -10 * t / d) + 1) + b;
			},
			easeInOutExpo: function (x, t, b, c, d)
			{
				if (t == 0) return b;
				if (t == d) return b + c;
				if ((t /= d / 2) < 1) return c / 2 * Math.pow(2, 10 * (t - 1)) + b;
				return c / 2 * (-Math.pow(2, -10 * --t) + 2) + b;
			},
			easeInCirc: function (x, t, b, c, d)
			{
				return -c * (Math.sqrt(1 - (t /= d) * t) - 1) + b;
			},
			easeOutCirc: function (x, t, b, c, d)
			{
				return c * Math.sqrt(1 - (t = t / d - 1) * t) + b;
			},
			easeInOutCirc: function (x, t, b, c, d)
			{
				if ((t /= d / 2) < 1) return -c / 2 * (Math.sqrt(1 - t * t) - 1) + b;
				return c / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + b;
			},
			easeInElastic: function (x, t, b, c, d)
			{
				var s = 1.70158; var p = 0; var a = c;
				if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
				if (a < Math.abs(c)) { a = c; var s = p / 4; }
				else var s = p / (2 * Math.PI) * Math.asin(c / a);
				return -(a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
			},
			easeOutElastic: function (x, t, b, c, d)
			{
				var s = 1.70158; var p = 0; var a = c;
				if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
				if (a < Math.abs(c)) { a = c; var s = p / 4; }
				else var s = p / (2 * Math.PI) * Math.asin(c / a);
				return a * Math.pow(2, -10 * t) * Math.sin((t * d - s) * (2 * Math.PI) / p) + c + b;
			},
			easeInOutElastic: function (x, t, b, c, d)
			{
				var s = 1.70158; var p = 0; var a = c;
				if (t == 0) return b; if ((t /= d / 2) == 2) return b + c; if (!p) p = d * (.3 * 1.5);
				if (a < Math.abs(c)) { a = c; var s = p / 4; }
				else var s = p / (2 * Math.PI) * Math.asin(c / a);
				if (t < 1) return -.5 * (a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
				return a * Math.pow(2, -10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p) * .5 + c + b;
			},
			easeInBack: function (x, t, b, c, d, s)
			{
				if (s == undefined) s = 1.70158;
				return c * (t /= d) * t * ((s + 1) * t - s) + b;
			},
			easeOutBack: function (x, t, b, c, d, s)
			{
				if (s == undefined) s = 1.70158;
				return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
			},
			easeInOutBack: function (x, t, b, c, d, s)
			{
				if (s == undefined) s = 1.70158;
				if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525)) + 1) * t - s)) + b;
				return c / 2 * ((t -= 2) * t * (((s *= (1.525)) + 1) * t + s) + 2) + b;
			},
			easeInBounce: function (x, t, b, c, d)
			{
				return c - easings.easeOutBounce(x, d - t, 0, c, d) + b;
			},
			easeOutBounce: function (x, t, b, c, d)
			{
				if ((t /= d) < (1 / 2.75))
				{
					return c * (7.5625 * t * t) + b;
				} else if (t < (2 / 2.75))
				{
					return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b;
				} else if (t < (2.5 / 2.75))
				{
					return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b;
				} else
				{
					return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b;
				}
			},
			easeInOutBounce: function (x, t, b, c, d)
			{
				if (t < d / 2) return easings.easeInBounce(x, t * 2, 0, c, d) * .5 + b;
				return easings.easeOutBounce(x, t * 2 - d, 0, c, d) * .5 + c * .5 + b;
			}
		};

		export type TEasing = keyof typeof easings;

		/**
		 * 
		 * @param {keyof typeof easings} easingName
		 * @param {number} startValue
		 * @param {number} finalValue
		 * @param {number} currentTimeFraction 0-1
		 * @returns
		 */
		export function InvokeEasing(easingName: TEasing, startValue: number, finalValue: number, currentTimeFraction: number)
		{
			/// <summary>
			/// Calculate current value based on current time fraction
			/// </summary>
			/// <param name="startValue" type="Number"></param>
			/// <param name="finalValue" type="Number"></param>
			/// <param name="currentTimeFraction" type="Number">0...1</param>
			if (currentTimeFraction < 0) currentTimeFraction = 0;
			if (currentTimeFraction > 1) currentTimeFraction = 1;
			var easingFunc: Function | null = null;
			if (typeof (easingName) == "string")		
			{
				easingFunc = easings[easingName];
			}
			else if (typeof (easingName) == "function")
			{
				throw new Error("Easing function not supported: " + easingName);
			}

			if (!easingFunc)
			{
				throw new Error("Unknown easing function: " + easingName);
			}

			return easingFunc(
				currentTimeFraction, // 0...1
				currentTimeFraction * 100, // percent duration 0...100
				startValue,
				finalValue - startValue,
				100 // total duration
			);
		}
	}

	namespace AnimationFrameHelper
	{
		var _ff: Function = window.requestAnimationFrame ||
			(<any>window).mozRequestAnimationFrame ||
			(<any>window).webkitRequestAnimationFrame ||
			(<any>window).msRequestAnimationFrame;

		if (!_ff) // if native is not supported
		{
			Calysto.Core.DebugRun(() =>
			{
				//#if DEBUG
				console.log("requestAnimationFrame not supported");
				//#endif
			});

			var _timeoutId;
			var _buffer: Function[] = [];

			var fnInvoke = () =>
			{
				var arr = _buffer;
				_buffer = [];
				for (var n1 = 0; n1 < arr.length; n1++)
				{
					arr[n1]();
				}
			};

			var fnStart = () =>
			{
				if (!_timeoutId) _timeoutId = setTimeout(() => { _timeoutId = null; fnInvoke(); }, 20);
			};

			// if not of above is supported, use next:
			_ff = (fnCallback =>
			{
				_buffer.push(fnCallback);
				fnStart();
			});
		}

		/**
		 *  fnCallback is executed just before the DOM has to become visible
		 * @param fnCallback
		 */
		export function RequestAnimationFrame(fnCallback: () => void)
		{
			return _ff(() => fnCallback()); // use lambda expressoin to have correct context
		}
	}

	class AnimItem
	{
		public onTick?: (sender: Animator, currentValue: number) => void;

		// element input values:
		public element: HTMLElement;
		public elStyleName: string;
		public elFinalValue: number | string; // should be parsed, it may be clip, color, transform or simple stylevalue

		public clipStart: Utility.Dom.ClipDimension;
		public clipCurrent: Utility.Dom.ClipDimension;
		public clipFinal: Utility.Dom.ClipDimension;

		public rgbStart: Colorspace.RGB;
		public rgbCurrent: Colorspace.RGB;
		public rgbFinal: Colorspace.RGB;

		public transformStart: number[];
		public transformCurrent: number[];
		public transformFinal: number[];
		public transformFormat: string;

		public numStart: number;
		public numFinal: number;
		public numCurrent: number;
		public isNumValue: boolean;

		public elUnits: string;

	}

	enum AnimState
	{
		Unstarted = 0,
		Running = 1,
		Completed = 2,
		Aborted = 3
	}

	export class Animator
	{
		public static InvokeEasing = EasingHelper.InvokeEasing;

		public static RequestAnimationFrame(onAcquired: () => void)
		{
			return AnimationFrameHelper.RequestAnimationFrame(onAcquired);
		}

		private items: AnimItem[];

		// total duration, default 400 ms
		private durationMs = 400;

		// function(sender){...}
		private onComplete: ((sender: Animator) => void)[] = [];

		// function (sender){...}
		private onStart: ((sender: Animator) => void)[] = [];

		// function(sender, percent){...}
		private onProgress: ((sender: Animator, percent: number) => void)[] = [];

		//function(sender){...}
		private onAbort: ((sender: Animator) => void)[] = [];

		// default easing method (linear)
		private easing: EasingHelper.TEasing = "linear";

		private state = AnimState.Unstarted;

		constructor()
		{
			this.items = [];
		}

		/**
		 * Returns all items, both DOM and non-dom.
		 */
		public Items()
		{
			return this.items.ToArray();
		}

		/**
		 * Returns distinct DOM elements list.
		 */
		public ToList()
		{
			return new Calysto.List(this.items.AsEnumerable().Select(o => o.element).Where(o => !!o).ToArray()).ToList();
		}

		/**
		 * Returns distinct DOM elements DomQuery.
		 */
		public AsDomQuery()
		{
			return this.ToList().AsDomQuery();
		}

		/**
		 * Push DOM element with final value setting. Animation will run from current state to final setting.
		 * @param element
		 * @param styleName
		 * @param finalValue
		 * can be exact value or eg. "+=10", "-=50", "*=34"
		 * @param onTick
		 * optional, Function, eg. function(animator, currentValue){...}, this is animator instance
		 */
		public AddElement(element: HTMLElement, styleName: string, finalValue: number | string, onTick?: (sender: Animator, currentValue: number) => void)
		{
			var aa = new AnimItem();
			aa.element = element;
			aa.elStyleName = styleName;
			aa.elFinalValue = finalValue;
			aa.onTick = onTick;
			this.items.push(aa);
			return this;
		}

		public AddValue(startValue: number, finalValue: number, onTick?: (sender: Animator, currentValue: number) => void)
		{
			/// <summary>
			/// Animate general value from startValue to finalValue.
			/// </summary>
			/// <param name="startValue"></param>
			/// <param name="finalValue"></param>
			/// <param name="onTick" optional="true" type="Function">function(animator, currentValue){...}, this is animator instance</param>
			var aa = new AnimItem();
			aa.numStart = startValue;
			aa.numFinal = finalValue;
			aa.onTick = onTick;
			aa.isNumValue = true;
			this.items.push(aa);
			return this;
		}

		public Clear()
		{
			/// <summary>
			/// remove all this._items
			/// </summary>
			this.items.Clear();
			return this;
		}

		public Duration(durationMs = 400)
		{
			/// <summary>
			/// total duration of animation. Default is 400ms.
			/// </summary>
			/// <param name="durationMs">default is 400ms</param>
			if (!((durationMs || 0) > 0))
			{
				durationMs = 1; // duration must be > 0, or easing functions won't work
			}
			this.durationMs = durationMs;
			return this;
		}


		public OnProgress(callback: (sender: Animator, percent: number) => void)
		{
			/// <summary>
			/// send progres in percentage
			/// </summary>
			/// <param name="callback">function(animator, percent){  }, this is animator instance</param>

			this.onProgress.push(callback);
			return this;
		}

		public OnStart(callback: (sender: Animator) => void)
		{
			/// <summary>
			/// Send callbak on start.
			/// </summary>
			/// <param name="callback">function(animator){...}, this is animator instance</param>

			this.onStart.push(callback);
			return this;
		}

		public OnComplete(callback: (sender: Animator) => void)
		{
			/// <summary>
			/// Send callback on complete.
			/// </summary>
			/// <param name="callback">function(animator){...}, this is animator instance</param>

			this.onComplete.push(callback);
			return this;
		}

		public OnAbort(callback: (sender: Animator) => void)
		{
			/// <summary>
			/// Send callback on complete.
			/// </summary>
			/// <param name="callback">function(animator){...}, this is animator instance</param>
			this.onAbort.push(callback);
			return this;
		}

		public Easing(easingType: EasingHelper.TEasing)
		{
			/// <summary>
			/// set easing method
			/// </summary>
			/// <param name="easingType">easing method. If not defined, default linear will be used.</param>
			if (typeof easingType == "string")
			{
				this.easing = easingType;
			}
			////else if (typeof easingType == "function")
			////{
			////	// compatibility with old code where function is sent
			////	this.easing = easingType;
			////}
			else
			{
				this.easing = "linear";
			}
			return this;
		}

		private initializeFirstRun(item: AnimItem)
		{
			if (item.element && Type.TypeInspector.IsNullOrUndefined(item.elFinalValue))
			{
				throw new Error("Error in Animator, no elFinalValue");
			}
			else if (item.element && item.elStyleName && item.elStyleName.Contains("color", true))
			{
				// eg. backgroundColor
				// IE <= v8 returns named colors
				var vvv = Calysto.Utility.Dom.Style.GetComputedStyle(item.element, item.elStyleName).StyleValue;
				item.rgbStart = Calysto.Colorspace.ColorConverter.ParseToRGB(vvv);
				var dd = document.createElement("div");
				dd.style.position = "absolute";
				dd.style.width = "1px";
				dd.style.height = "1px";
				dd.style.zIndex = "-1000";
				document.body.appendChild(dd); // must be in dom to be able to get computed style
				dd.style.backgroundColor = <string>item.elFinalValue;
				var ccc = Calysto.Utility.Dom.Style.GetComputedStyle(dd, "backgroundColor").StyleValue;
				if (dd.parentNode) dd.parentNode.removeChild(dd);
				item.rgbFinal = Calysto.Colorspace.ColorConverter.ParseToRGB(ccc);
				////console.log("start: " + item.startValue.ToHEX() + ", finalValue: " + item.finalValue.ToHEX());
				//item.isRGB = true; // animate RGB, HSV is not ok
				//item.isHSL = false;
				item.rgbCurrent = item.rgbStart.Clone();
			}
			else if (item.element && item.elStyleName == "clip")
			{
				var curr1 = Calysto.Utility.Dom.GetClip(item.element);
				item.clipStart = curr1; // {top, right, bottom, left}
				item.clipCurrent = { ...curr1 }; // clone to avoid messing with startValue object
				item.clipFinal = Calysto.Utility.Dom.CalculateClip(item.element, <string>item.elFinalValue);
				////console.log(item.startValue);
				////console.log(item.finalValue);
				//item.isClip = true;
			}
			else if (item.element && item.elStyleName == "transform")
			{
				// if current transform style is coumpound;
				// translate(100px, -100px) rotate(170deg) scale(0.2)"

				var currList = (Utility.Dom.SelectTransform(item.element) || "")
					.split(")")
					.AsEnumerable()
					.Where(o => !!o)
					.Select(o => o.Trim() + ")")
					.Select(o => ({
						statement: o, // eg. translate(100px, -100px)
						kind: ((o || "").match(new RegExp("[\\w]+")) || [])[0], // eg. translate
						args: ((o || "").match(new RegExp("([\\-]?[\\.\\d]+)", "ig")) || <RegExpMatchArray><any>[]).AsEnumerable().Select(kk => parseFloat(kk)).ToArray() // arguments: 100, -100
					})).ToArray();

				var finalList = (<string>item.elFinalValue).split(")")
					.AsEnumerable()
					.Where(o => !!o)
					.Select(o => o.Trim() + ")")
					.Select(o => ({
						statement: o, // eg. translate(100px, -100px)
						kind: ((o || "").match(new RegExp("[\\w]+")) || [])[0], // eg. translate
						args: ((o || "").match(new RegExp("([\\-]?[\\.\\d]+)", "ig")) || <RegExpMatchArray><any>[]).AsEnumerable().Select(kk => parseFloat(kk)).ToArray()
					})).ToArray();

				// select transforms which are to be animated
				// start and finalVal args count has to be the same, if arguments are missing, add them
				var mainList = finalList.AsEnumerable().Select(finalVal =>
				{
					var curr = currList.AsEnumerable().Where(cc => cc.kind == finalVal.kind).FirstOrDefault()
					if (!curr)
					{
						curr = {
							statement: finalVal.statement,
							kind: finalVal.kind,
							args: finalVal.args.AsEnumerable().Select(ff => finalVal.kind.indexOf("scale") == 0 ? 1 : 0).ToArray()
						};
					}

					// ako finalVal ima vise argumenata, uzeti statement as stringFormat iz finalValue, u protivnom, uzeti iz currValue
					var finalHasMoreArgs = false;

					while (curr.args.length < finalVal.args.length)
					{
						finalHasMoreArgs = true;
						curr.args.push(curr.args.length > 0 ? curr.args[curr.args.length - 1] : finalVal.kind.indexOf("scale") == 0 ? 1 : 0);
					}

					while (curr.args.length > finalVal.args.length)
					{
						finalVal.args.push(finalVal.args.length > 0 ? finalVal.args[finalVal.args.length - 1] : finalVal.kind.indexOf("scale") == 0 ? 1 : 0);
					}

					return ({
						startValuesArr: curr.args,
						finalValuesArr: finalVal.args,
						stringFormat: (finalHasMoreArgs ? finalVal.statement : curr.statement)
					});

				}).ToArray();

				var index = 0;
				// create single item:
				item.transformStart = mainList.AsEnumerable().SelectMany(o => o.startValuesArr).ToArray();
				item.transformCurrent = item.transformStart.ToArray();// array has to be cloned to avoid messing with startValue array
				item.transformFinal = mainList.AsEnumerable().SelectMany(o => o.finalValuesArr).ToArray();
				item.transformFormat = mainList.AsEnumerable().Select(o => o.stringFormat).ToStringJoined(" ").replace(new RegExp("([\\-]?[\\.\\d]+)", "ig"), function () { return "{" + (index++) + "}"; });
			}
			else if (item.element) // any other style value
			{
				let styleItem = Utility.Dom.Style.GetComputedStyle(item.element, item.elStyleName);

				item.numStart = styleItem.NumericValue;

				if (!item.elUnits)
				{
					let finalItem = Utility.Dom.Style.StyleDecodedValue.Parse(item.elFinalValue);

					//item.units = styleItem.Units;
					// take units from finalValue, eg. : 100%
					if (finalItem.Units)
					{
						item.elUnits = finalItem.Units;
					}
					else
					{
						item.elUnits = styleItem.Units;
					}
				}

				//let originalValue: number;

				//if (item.elUnits == "%" && item.elStyleName.indexOf("margin") == 0)
				//{
				//	// we want to set margin in percent of element dimensions, eg. margin-top: 25%, we'll set top margin: 25% of element.offsetHeight
				//	// margin is to be animated and finalValue is in percent, use element offset dimensions to calculate final value
				//	item.elUnits = <any>null;

				//	switch (Utility.Dom.Style.ConvertCssNameToCamel(item.elStyleName))
				//	{
				//		case "marginTop":
				//		case "marginBottom":
				//			originalValue = item.element.offsetHeight;
				//			break;
				//		case "marginLeft":
				//		case "marginRight":
				//			originalValue = item.element.offsetWidth;
				//			break;
				//	}
				//}

				// finalValue may be number, "+=10", "100px"
				if (Type.TypeInspector.IsNullOrUndefined(item.elFinalValue))
				{
					throw new Error("Error in Animator, finalValue is not defined");
				}
				item.numFinal = Utility.Dom.Style.CalculateNumericValue(styleItem.NumericValue, item.elFinalValue);

				item.numCurrent = item.numStart;

				if (!Type.TypeInspector.IsNumber(item.numStart) || !Type.TypeInspector.IsNumber(item.numFinal))
				{
					throw new Error("Calysto.Animator error, invalid start/stop value. Name: " + item.elStyleName + ", styleFinal: " + item.elFinalValue + ", numStart: " + item.numStart + ", numFinal: " + item.numFinal);
				}
			}
			else if (item.isNumValue)
			{
				item.numCurrent = item.numStart;
			}
		}

		private GetCurrent(elapsedTimeMs, startValue, finalValue)
		{
			return Animator.InvokeEasing(this.easing, startValue, finalValue, elapsedTimeMs / this.durationMs);
		}

		private animateStartTicks: number;

		private TimerTick(firstRun)
		{
			if (this.state != AnimState.Running)
			{
				return; // finish it
			}

			var isCompleted = false;
			var elapsedTime = 0;

			if (firstRun)
			{
				// first remove items with element property and with no styleName property (created from domquery with .ToAnimator() with no final values set in .ToAnimator(...final values...)
				this.items = this.items.AsEnumerable().Where(o => o.isNumValue || (!!o.element && !!o.elStyleName && !Type.TypeInspector.IsNullOrUndefined(o.elFinalValue))).ToArray();
				for (var nn = 0; nn < this.items.length; nn++)
				{
					this.initializeFirstRun(this.items[nn]);
				}
				// after the init is done, save current time, it is used for calculations
				this.animateStartTicks = Date.now();
			}
			else
			{
				elapsedTime = Date.now() - (this.animateStartTicks || 0);
				isCompleted = (this.durationMs || 0) <= (elapsedTime || 0);
			}


			for (var nn = 0; nn < this.items.length; nn++)
			{
				var item = this.items[nn];

				if (item.onTick)
				{
					item.onTick(this, item.numCurrent);
				}

				// hsl doesn't work well
				////else if (item.rgbStart)
				////{
				////	Calysto.ForEach(["h", "s", "l", "a"], function (o)
				////	{
				////		var val = isOver ? item.finalValue[o] : (this.GetCurrent(elapsedTime, item.startValue[o], item.finalValue[o]));
				////		item.currentValue[o] = o == "a" ? val : Math.floor(val); // hsl must be integers, "a" is decimal
				////	}, this);
				////	// apply to element
				////	Calysto.Utility.Dom.SetStyleValue(item.element, item.elStyleName, item.currentValue.ToHslString(), null);
				////}

				if (item.rgbStart)
				{
					Calysto.Collections.ForEach(["r", "g", "b", "a"], o =>
					{
						var val = isCompleted ? item.rgbFinal[o] : (this.GetCurrent(elapsedTime, item.rgbStart[o], item.rgbFinal[o]));
						item.rgbCurrent[o] = o == "a" ? val : Math.floor(val); // rgb must be integers, "a" is decimal
					});
					// apply to element
					Calysto.Utility.Dom.Style.SetStyleValue(item.element, item.elStyleName, item.rgbCurrent.ToRgbString());
				}
				else if (item.clipStart)
				{
					Calysto.Collections.ForEach(["top", "right", "bottom", "left"], o =>
					{
						item.clipCurrent[o] = isCompleted ? item.clipFinal[o] : Math.floor(this.GetCurrent(elapsedTime, item.clipStart[o], item.clipFinal[o]))
					});
					// css clip: rect(0px 10px 100px 20px );
					// applyt to element
					Calysto.Utility.Dom.SetClip(item.element, item.clipCurrent);
				}
				else if (item.transformStart)
				{
					var val = item.transformFormat;
					for (var nn = 0; nn < item.transformCurrent.length; nn++)
					{
						item.transformCurrent[nn] = isCompleted ? item.transformFinal[nn] : this.GetCurrent(elapsedTime, item.transformStart[nn], item.transformFinal[nn]);
						val = val.replace("{" + nn + "}", item.transformCurrent[nn] + "");
					}
					// apply to element
					$$calysto(item.element).ApplyTransform(val);
				}
				else // value item or element item
				{
					item.numCurrent = isCompleted ? item.numFinal : this.GetCurrent(elapsedTime, item.numStart, item.numFinal);

					if (item.element)
					{
						// apply to element
						Calysto.Utility.Dom.Style.SetStyleValue(item.element, item.elStyleName, item.numCurrent, item.elUnits);
					}
				}

				if (item.onTick)
				{
					item.onTick(this, item.numCurrent);
				}
			}

			if (this.onProgress)
			{
				var percent = elapsedTime / this.durationMs * 100;
				if (percent > 100)
				{
					percent = 100;
				}
				for (let fn of this.onProgress)
					fn(this, percent); // send progress in percent
			}

			if (!isCompleted)
			{
				Calysto.Animator.RequestAnimationFrame(() => this.TimerTick(false));
			}
			else
			{
				// completed
				this.state = AnimState.Completed;

				// onComplete has to be invoked last because we may have this.Start() in onComplete to restart it all
				// invoke in new thread to allow animate to finish and screen refresh
				setTimeout(() =>
				{
					for (let fn of this.onComplete)
						fn(this);
				});
			}
		}

		public IsRunning()
		{
			/// <summary>
			/// Is animator running. If it is waiting for start with Start(delay), it is not running yet.
			/// </summary>
			return this.state == AnimState.Running;
		}

		////public IsWaiting()
		////{
		////	/// <summary>
		////	/// Is waiting for start, with Start(delay). Once the animation is started, IsWaiting returns false.
		////	/// </summary>

		////	return this._delayTimeoutId && this._delayTimeoutId > 0;
		////};

		private _delayTimeoutId: number | null;

		public Start(delayMs = 0)
		{
			/// <summary>
			/// Call onStart() and start animating.
			/// </summary>
			/// <param name="delayMs" optional="true">delay animator start for delayMs miliseconds</param>

			if (this.IsRunning())
			{
				throw new Error("animation is already running");
			}

			if (this._delayTimeoutId)
			{
				clearTimeout(this._delayTimeoutId);
				this._delayTimeoutId = null;
			}

			if (delayMs > 0)
			{
				this._delayTimeoutId = setTimeout(() => this.Start(), delayMs);
				return this;
			}

			this.state = AnimState.Running;

			for (let fn of this.onStart)
				fn(this);

			this.TimerTick(true);

			return this;
		}

		public Abort()
		{
			/// <summary>
			/// Stop animating at current position. Do not call onComplete(). Call onAbort()
			/// </summary>

			if (this._delayTimeoutId)
			{
				clearTimeout(this._delayTimeoutId);
				this._delayTimeoutId = null;
			}

			this.state = AnimState.Aborted;

			for (let fn of this.onAbort)
				fn(this);

			return this;
		}

		/** Start and wait async until animation is complete */
		public async StartAsync(delayMs = 0)
		{
			return new Promise<Animator>((resolve, reject) =>
			{
				this.OnComplete(s =>
				{
					resolve(s);
				}).Start(delayMs);
			});
		}
	}
}
