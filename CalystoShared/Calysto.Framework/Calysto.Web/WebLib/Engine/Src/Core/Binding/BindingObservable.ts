namespace Calysto.Binding
{
	/**
	 * DOM element custom properties: visible, invisible, enabled, disabled
	 * Data custom properties inside repeater: DataItem, ItemIndex
	 * 
	*/
	export class BindingObservable extends BindingDataSource
	{
		constructor()
		{
			super();
		}

		private WriteLog(element: BindingElement, line: string)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				if (!element.$$observable_Log)
					element.$$observable_Log = [];

				element.$$observable_Log.push(line);
			}
			//#endif
		}

		private SetElementValue(element: BindingElement, elProperty: string, value: any)
		{
			//console.log("SetElementValue", elProperty, value, element);

			this.WriteLog(element, `SetElementValue(${elProperty}, ${value})`);

			if (elProperty == "options" && element.tagName.toLowerCase() == "select")
			{
				element.innerHTML = "";
				var items: { Text: string, Value: any, Selected: boolean }[] = value;
				for(let o of items.ToArray())
				{
					let opt = document.createElement("option");
					opt.innerHTML = o.Text;
					opt.value = Type.TypeConverter.ToStringFormated(o.Value, <any>element.getAttribute(AttrName.CalystoFormat)); // option value is attribute, so value is string
					element.appendChild(opt);
					opt.selected = !!o.Selected;
				}
			}
			else if (elProperty == "enabled" || elProperty == "disabled")
			{
				// to be able to use calysto-bind="enabled:true/false"
				// to be able to use calysto-bind="disabled:true/false"
				if ((!value && elProperty == "enabled") || (value && elProperty == "disabled"))
				{
					// disable element
					element.setAttribute("disabled", "disabled");
					element.disabled = true;
				}
				else
				{
					// enable element
					element.removeAttribute("disabled");
					element.disabled = false;
				}
			}
			else if (elProperty == "visible")
			{
				// to be able to use calysto-bind="visible:true/false"
				// to be able to use calysto-bind="visible:true/false" instead of writing (visible)=> this.style.display = visible ? "" : "none"
				element.style.display = value ? "" : "none";
			}
			else if (elProperty == "invisible")
			{
				// to be able to use calysto-bind="invisible:true/false"
				element.style.display = value ? "none" : "";
			}
			else if (elProperty == "innerHTML" || elProperty == "value")
			{
				// value must be string, eg. innerHTML = 1 won't work unless 1 is string
				// convert to string if property is "innerHTML" or "value"

				// el. property "innerHTML" or "value" may bind only string or value which can be converted to string
				// lets throw exception if GetDotNetTypeName can not convert val to string

				if (Type.TypeInspector.IsNullOrUndefined(value))
				{
					value = "";
				}
				else if (typeof (value) != "string")
				{
					value = Type.TypeConverter.ToStringFormated(value);
				}

				element[elProperty] = value;
			}
			else
			{
				// we may not use ToStringFormated, e.g. if we bind element._movieID = 343, so 343 must be integer, as-is
				// sometimes we're bounding compound object to element's property, so it doesn't have to be converted (and can not be converted)
				// elProperty may be compound path: style.backgroundColor

				Calysto.DataBinder.SetValue(element, elProperty, value);
			}
		}

		/**
		 * Remove element from DOM, remove listeners from ObservableDictionaryTree
		 * @param element
		 */
		private RemoveElementAndListeners(element: BindingElement)
		{
			// remove DOM event listeners
			Calysto.Event.Detach(element);

			// remove from DOM
			Calysto.Utility.Dom.RemoveNodeFromDom(element);

			// remove from Calysto.DataObserver
			if (element.$$observable_DataSourceListeners)
				element.$$observable_DataSourceListeners.ForEach(listener => listener.RemoveListener());
		}

		private CloneNodeSafe(el: BindingElement)
		{
			let el1 = <BindingElement>el.cloneNode(true);
			el1.style.display = "none";
			return el1;
		}

		private BindDataToRepeater(repeaterEl: BindingElement, absoluteDataPath: string, sourceList: any[])
		{
			repeaterEl.$$observable_DataPath = absoluteDataPath;

			this.WriteLog(repeaterEl, `BindDataToRepeater(${absoluteDataPath}, ${sourceList})`);

			let repeater = BindingCache.GetRepeaterSetting(repeaterEl);

			if (sourceList && sourceList.ToArray)
				sourceList = sourceList.ToArray();

			////#if DEBUG
			//if (Calysto.Core.IsDebugDefined)
			//{
			//	console.log({ repeater: absoluteDataPath, source: sourceList });
			//}
			////#endif

			var total = sourceList && sourceList.length ? sourceList.length : 0;

			// moramo zadrzati trenutnu visinu repeatera da se ne mijenja scroll pozicija elementa kad se svi itemi obrisu pa prije nego se kreiraju novi
			repeaterEl.style.minHeight = repeaterEl.offsetHeight + "px";

			// moramo izbaciti sve prethodne repeater elemente i ponovo ih kreirati jer imamo i separator iteme i header i footer...
			// ali moramo uklniti i sve listenere
			$$calysto(repeaterEl).DescendantNodes<BindingElement>().ToArray().ForEach(el => this.RemoveElementAndListeners(el));

			// da budemo ziher da su izbaceni i text nodovi:
			repeaterEl.innerHTML = "";

			let items3: BindingElement[] = [repeaterEl];

			if (!(total > 0))
			{
				if (repeater.nodata)
				{
					let nn: BindingElement;
					repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.nodata));
					nn.$$observable_DataPath = absoluteDataPath;
					items3.push(nn);
				}
			}
			else
			{
				let nn: BindingElement;

				if (repeater.header)
				{
					repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.header));
					nn.$$observable_DataPath = absoluteDataPath;
					items3.push(nn);
				}

				for (let index = 0; index < sourceList.length; index++)
				{
					let item = sourceList[index];

					if (repeater.separator && index > 0)
					{
						repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.separator));
						nn.$$observable_DataPath = absoluteDataPath + "." + index;
						nn.$$observable_ItemIndex = index;
						items3.push(nn);
					}

					if (repeater.alternating && index % 2 == 1)
					{
						repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.alternating));
						nn.$$observable_DataPath = absoluteDataPath + "." + index;
						nn.$$observable_ItemIndex = index;
						items3.push(nn);
					}
					else if (repeater.item)
					{
						repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.item));
						nn.$$observable_DataPath = absoluteDataPath + "." + index;
						nn.$$observable_ItemIndex = index;
						items3.push(nn);
					}
				}

				if (repeater.footer)
				{
					repeaterEl.appendChild(nn = this.CloneNodeSafe(repeater.footer));
					nn.$$observable_DataPath = absoluteDataPath;
					items3.push(nn);
				}
			}

			let items2 = $$calysto(repeaterEl).Query<BindingElement>(`//[${Binding.Attributes.Uid}]`).ToArray();
			for(let item of items2)
			{
				this.WriteLog(item, `Inside repeater, init listeners`);
				this.CreateViewListeners(item);
				this.CreateDataListeners(item);
			}

			// trigger data binding
			for (let item of items2)
			{
				// trigger all, except current repeaterEl
				if (item != repeaterEl && item.$$observable_DataSourceListeners && item.$$observable_DataSourceListeners.Any())
				{
					for (let listener of item.$$observable_DataSourceListeners)
					{
						listener.CallbackFunc(listener.FullPath);
					}
				}
			}

			// make visible
			items3.ForEach(o => o.style.display = "");

			// nakon sto je kreirao i nested repeatere, smijemo ukloniti min-height
			repeaterEl.style.minHeight = "";
		}

		private GetUpperPath(path: string)
		{
			let arr1 = path.split('.').ToArray();
			arr1.RemoveAt(arr1.length - 1);
			return arr1.join(".");
		}

		/**
		 * 1. test if lambda
		 * 2. test if exists in window
		 * 3. search in dataSource
		 * @param absoluteDataPath
		 */
		private ResolveHandlerFunction<TFunc>(jsHandler: string, pathResolver: BindingElementPathResolver):IFuncHandler<TFunc>
		{
			if (typeof (jsHandler) == "function")
				return ({ Func: <any>jsHandler });

			// 1. try lambda
			if (jsHandler.Contains("=>"))
				return ({ Func: <any>Calysto.Utility.Expressions.CompileLambdaExpression(jsHandler) });

			// 2. try from data source, traverse from current path up to the root
			let absoluteDataPath = pathResolver.CreateAbsoluteDataPath(jsHandler);
			let arr1 = absoluteDataPath.split(".");
			let tmpPath;
			let fn1: any;

			while ((tmpPath = arr1.join(".")) && !Type.TypeInspector.IsFunction(fn1 = this.GetValue(tmpPath)))
			{
				fn1 = null;
				// upper path, e.g. @.path1.path2.jsHandler, we have to remove path2 and in the next iteration path1
				if (arr1.length > 1)
					arr1.splice(arr1.length - 2, 1);
				else if (arr1.length > 0)
					arr1.splice(0, 1);
			}

			if (!fn1)
			{
				// 3. try global fuction
				let fn1 = Calysto.DataBinder.GetValue(window, jsHandler);
				if (fn1)
				{
					if (Type.TypeInspector.IsFunction(fn1))
						return ({ Func: <TFunc>fn1 });
					else
						throw new Error("Handler path is not function: " + jsHandler);
				}
			}

			if(!fn1)
				throw new Error("Function is expected at " + absoluteDataPath + ", but found: " + fn1);

			// find context, path up 1 level
			let context1 = this.GetValue(this.GetUpperPath(tmpPath));

			return ({
				Func: <TFunc>fn1,
				HandlerContext: context1
			});
		}

		private CreateHtmlEventContext(context: any, element: BindingElement, eventsNames: (keyof HTMLElementEventMap)[], event: Event, dsDataPath: string): IViewListenerContext
		{
			return ({
				Binder: this,
				Element: element,
				DataSource: this.GetDataSource(),
				DataPath: dsDataPath,
				HandlerContext: context,
				ListeningEventsNames: eventsNames,
				Event: event
			});
		}

		private CreateViewListeners(element: BindingElement)
		{
			if (element.$$observable_hasHtmlListenersAttached) return;
			element.$$observable_hasHtmlListenersAttached = true;

			if (!element.$$observable_Uid)
				element.$$observable_Uid = BindingCache.GetElementUid(element);

			let pathResolver = BindingElementPathResolver.GetInstance(element);

			let settings = element.$$observable_ElementSetting = BindingCache.GetBindingElement(element.$$observable_Uid).Settings;

			this.WriteLog(element, `inside CreateHtmlListeners`);

			if (settings.ViewListeners)
			{
				settings.ViewListeners.ForEach(item1 =>
				{
					this.WriteLog(element, "Create HtmlListeners: " + item1.EventNames + ", jsHandler: " + item1.JsHandler);

					// nek resolva handler prije kreiranja listenera, tako samo sigurni da on postoji
					let fnHandler = this.ResolveHandlerFunction<(context: IViewListenerContext) => void | boolean>(<any>item1.JsHandler, pathResolver);
					let dsDataPath = pathResolver.CreateAbsoluteDataPath("DataItem");

					$$calysto(element).On(item1.EventNames, (sender, ev) =>
					{
						// (sender, event, binder) => ..., this in lamba is context
						// external function paht, this is context
						// @.state.DivClick it is function inside data model, this is object @.state in which @.state.DivClick function is defined
						return fnHandler.Func(this.CreateHtmlEventContext(fnHandler.HandlerContext, element, item1.EventNames, ev, dsDataPath));

					});
				});
			}

			let tagName = element.tagName.toLowerCase();
			let isInput = (tagName == "input" || tagName == "select" || tagName == "textarea");

			if (settings.Bindings && isInput)
			{
				settings.Bindings.ForEach(item1 =>
				{
					let absoluteDsPath = pathResolver.CreateAbsoluteDataPath(item1.DataSourcePath);

					let bindEvents = item1.EventNames;

					if (!bindEvents || bindEvents.length == 0)
					{
						if (element.type == "checkbox" || element.type == "radio")
						{
							bindEvents = ["change"];
						}
						else
						{
							bindEvents = ["change"];
						}
					}

					this.WriteLog(element, "Create Binding DomListeners: " + bindEvents);

					// nek resolva handler prije kreiranja listenera, tako samo sigurni da on postoji
					let fnGetConvert: IFuncHandler<(context:IViewListenerContext, value: any) => any>;

					if (item1.JsGetConvert)
						fnGetConvert = this.ResolveHandlerFunction<(context:IViewListenerContext, value: any) => any>(<string>item1.JsGetConvert, pathResolver);

					$$calysto(element).On(bindEvents, (sender, ev) =>
					{
						let value: any = undefined;
						let hasValue = false;

						// sender == element
						if (tagName == "select" && item1.ElementPath == "options")
						{
							let obj1: any = this.GetValue(absoluteDsPath);
							[].AddRange(sender["options"]).ForEach((o: HTMLOptionElement,n) =>
							{
								// do not call NotifyPropertyChanged untill all options are set
								Calysto.DataBinder.SetValue(obj1, n + ".Selected", !!o.selected);
							});
							// original object obj1 is modified, so we have to invoke manually notify changed
							this.NotifyPropertyChanged(absoluteDsPath);
							return;
						}
						else if (tagName == "input" && item1.ElementPath == "checked")
						{
							if (element.name && (element.type == "radio" || element.type == "checkbox"))
							{
								// if it is radio group, all other must be unchecked
								// if it is checkbox, do not uncheck anything, just change current element state
								// search 2 upper paths: @.data.0.Selected -> collection is @.data
								let upperPath = this.GetUpperPath(absoluteDsPath);
								let ds1 = <any[]>this.GetValue(upperPath);
								if (!Type.TypeInspector.IsArray(ds1))
								{
									upperPath = this.GetUpperPath(upperPath);
									ds1 = <any[]> this.GetValue(upperPath);
								}

								if (Type.TypeInspector.IsArray(ds1))
								{
									if (element.type == "radio")
									{
										// uncheck all items
										ds1.ForEach(o => o[item1.DataSourcePath] = false);
									}
									else if (element.type == "checkbox")
									{
										// do not uncheck anything, it may have multiple checkbox checked
									}

									this.SetValueSilent(absoluteDsPath, element.checked);
									// invoke notify on upper path just to be sure if something else is bound to the same collection
									this.NotifyPropertyChanged(upperPath);
									// stop the execution
									return;
								}
							}

							// if there is no collection bound, set single value
							// checkbox or radio without name attribute
							value = element[item1.ElementPath];
							hasValue = true;
						
						}
						else if (item1.ElementPath == "enabled")
						{
							value = !element["disabled"];
							hasValue = true;
						}
						else if (item1.ElementPath == "disabled")
						{
							value = !!element["disabled"];
							hasValue = true;
						}
						else if (item1.ElementPath == "visible")
						{
							value = $$calysto(element).WhereVisible(true).Any();
							hasValue = true;
						}
						else if (item1.ElementPath == "invisible")
						{
							value = !$$calysto(element).WhereVisible(true).Any();
							hasValue = true;
						}
						else if (item1.ElementPath == "value")
						{
							value = element[item1.ElementPath];
							hasValue = true;
						}
						else
						{
							throw new Error("Not supported: " + item1.ElementPath);
						}

						if (hasValue)
						{
							if (item1.JsGetConvert)
							{
								value = fnGetConvert.Func(
									this.CreateHtmlEventContext(fnGetConvert.HandlerContext, element, bindEvents || [], ev, absoluteDsPath),
									value
								);
							}
							else
							{
								// change type to data source type

								let dsType = this._cachedDataSourceTypes[absoluteDsPath];
								if (!dsType)
								{
									// detect type from current value in datasource
									let dsValue = this.GetValue(absoluteDsPath);
									if (!Type.TypeInspector.IsNullOrUndefined(dsValue))
									{
										dsType = Calysto.Type.TypeDescriptor.FromValue(dsValue);
										this._cachedDataSourceTypes[absoluteDsPath] = dsType;
									}
								}

								if (dsType)
								{
									value = Calysto.Type.TypeConverter.ChangeType(value, dsType);
								}

							}

							// set value to data source
							this.SetValue(absoluteDsPath, value);
						}
					});

				});
			}

		}

		private _cachedDataSourceTypes: { [P: string]: Calysto.Type.TypeDescriptor} = {};

		private CreateDataSourceContext(context: any, element: BindingElement, listeningDataPaths: string[], dataPath: string, values: any[]): IDataListenerContext
		{
			return ({
				Binder: this,
				Element: element,
				DataSource: this.GetDataSource(),
				DataPath: dataPath,
				HandlerContext: context,
				ListeningDataPaths: listeningDataPaths,
				Values: values
			});
		}

		private GetDataSourceValue(element: BindingElement, dataSourcePath: string)
		{
			if (dataSourcePath.EndsWith("ItemIndex"))
			{
				var tmpel = element;
				while (tmpel && <any>tmpel != document)
				{
					if (tmpel.$$observable_ItemIndex == 0 || tmpel.$$observable_ItemIndex > 0)
						return tmpel.$$observable_ItemIndex;

					tmpel = <BindingElement>tmpel.parentNode;
				}

				throw new Error("ItemIndex not found");
			}

			return super.GetValue(dataSourcePath);
		}

		private CreateDataListeners(element: BindingElement)
		{
			if (element.$$observable_hasDataListenersAttached) return;
			element.$$observable_hasDataListenersAttached = true;

			if (!element.$$observable_Uid)
				element.$$observable_Uid = BindingCache.GetElementUid(element);

			if (!element.$$observable_DataSourceListeners)
				element.$$observable_DataSourceListeners = [];

			let listenersItems = element.$$observable_DataSourceListeners;

			let settings = element.$$observable_ElementSetting = BindingCache.GetBindingElement(element.$$observable_Uid).Settings;

			this.WriteLog(element, `inside CreateDataSourceListeners`);

			let pathResolver = BindingElementPathResolver.GetInstance(element);

			if (settings.Sources)
			{
				settings.Sources.ForEach(item =>
				{
					element.$$observable_DataPath = item.DataSourcePath;
				});
			}

			if (settings.DataListeners)
			{
				settings.DataListeners.ForEach(item1 =>
				{
					// create absolute paths
					let absoluteDataPaths = item1.DataSourcePaths.AsEnumerable().Select(o => pathResolver.CreateAbsoluteDataPath(o)).ToArray();
					absoluteDataPaths.ForEach(path1 =>
					{
						this.WriteLog(element, "Create DataListener: " + path1);

						// nek resolva handler prije kreiranja listenera, tako samo sigurni da on postoji
						let fnHandler = this.ResolveHandlerFunction<(context:IDataListenerContext, ...args: any[]) => void | boolean>(<any>item1.JsHandler, pathResolver);

						listenersItems.Add(this.dsListeners.AddListener(path1, element, (dataPath) =>
						{
							if (!Calysto.Utility.Dom.IsElementInDom(element))
							{
								this.RemoveElementAndListeners(element);
								return;
							}

							let valuesArr = absoluteDataPaths.AsEnumerable().Select(o => this.GetDataSourceValue(element, o)).ToArray();

							return fnHandler.Func(
								this.CreateDataSourceContext(fnHandler.HandlerContext, element, absoluteDataPaths, dataPath, valuesArr),
								...valuesArr
							);
							
						}));
					});
				});
			}

			if (settings.Bindings)
			{
				settings.Bindings.ForEach(item1 =>
				{
					// create absolute paths
					let absolutePath = pathResolver.CreateAbsoluteDataPath(item1.DataSourcePath);
					this.WriteLog(element, "Create Binding DataSourceListener: " + absolutePath);

					// nek resolva handler prije kreiranja listenera, tako samo sigurni da on postoji
					let fnSetConvert: IFuncHandler<(context:IDataListenerContext, value: any) => any>;

					if (item1.JsSetConvert)
						fnSetConvert = this.ResolveHandlerFunction<(context:IDataListenerContext, value: any) => any>(<string>item1.JsSetConvert, pathResolver);

					listenersItems.Add(this.dsListeners.AddListener(absolutePath, element, (currentPath) =>
					{
						if (!Calysto.Utility.Dom.IsElementInDom(element))
						{
							this.RemoveElementAndListeners(element);
							return;
						}

						let value = this.GetDataSourceValue(element, absolutePath);
						if (item1.JsSetConvert)
						{
							value = fnSetConvert.Func(
								this.CreateDataSourceContext(fnSetConvert.HandlerContext, element, [absolutePath], currentPath, [value]),
								value
							);
						}

						this.SetElementValue(element, item1.ElementPath, value);
					}));
				});
			}

			if (settings.Repeaters)
			{
				settings.Repeaters.ForEach(item =>
				{
					// create absolute paths
					let absolutePath = pathResolver.CreateAbsoluteDataPath(item.DataSourcePath);
					this.WriteLog(element, "Create Repeater DataSourceListener: " + absolutePath);
					listenersItems.Add(this.dsListeners.AddListener(absolutePath, element, () =>
					{
						if (!Calysto.Utility.Dom.IsElementInDom(element))
						{
							this.RemoveElementAndListeners(element);
							return;
						}

						let value = this.GetDataSourceValue(element, absolutePath) as any[];
						this.BindDataToRepeater(element, absolutePath, value);
					}));
				});
			}
		}

		/** HTMLElement holding ObservableBinder */
		private _rootElement: BindingElement;

		private EnsureRootElement()
		{
			if (this._rootElement)
				return;

			if (!this._rootSelector)
				throw new Error("Root selector not defined.");

			var root = $$calysto(this._rootSelector).Take(2).ToList(); // "body" ili lower, don't search "html" node since we have templates inside
			if (root.Count() > 1)
				throw new Error("DataBind selector selects " + root.Count() + " elements");

			this._rootElement = <BindingElement>root.FirstOrDefault();

			if (!this._rootElement)
				throw new Error("DataBind root element not found: " + this._rootElement);

			this._rootElement.$$observable_Binder = this;
			this._rootElement.$$observable_DataPath = "@";

			// will remove repeater's templates from DOM
			BindingCache.InitializeBindings(this._rootElement, this._factory?.GetSetup());

			// once the templates are removed from DOM, assign datasource listeners

			var arr1 = $$calysto(this._rootElement).Query("*, //*")
				.Query(`[${Calysto.Binding.Attributes.Uid}=*]`)
				.Cast<BindingElement>()
				.ToArray();

			for (var el of arr1)
			{
				this.CreateDataListeners(el);
				this.CreateViewListeners(el);
			}
		}

		private _recursions = 0;

		public NotifyPropertyChanged(propertyPath: string)
		{
			if (!propertyPath || propertyPath.length == 0)
				throw new Error("NotifyPropertyChanged(...) requires an argument");

			this._recursions++;

			if (Math.abs(this._recursions) > 100)
				throw Error("NotifyPropertyChanged recursion overflow");

			this.EnsureRootElement();

			super.NotifyPropertyChanged(propertyPath); // uses cached items

			this._recursions--;

			return this;
		}

		private _rootSelector: string;
		public SetRootElement(calystoSelector)
		{
			this._rootSelector = calystoSelector;
			return this;
		}

		private _factory: Calysto.Binding.Setup.BindingFactory;

		public SetFactory(factory: Setup.BindingFactory)
		{
			this._factory = factory;
			let root = factory.GetRoot();
			if(root)
				this._rootSelector = `[${Attributes.Uid}=${factory.GetRoot()}]`;
			return this;
		}

		public DataBind()
		{
			/// <summary>
			/// bind this ObservableBinder to elements by calystoSelector. if not set it is bound to document.
			/// </summary>

			// WARNING: bind data after listeners are bound, this way we'll not append listeners twice inside of repeater elements
			// NotifyPropertyChanged has to be invoked at the end
			this.NotifyPropertyChanged("@");

			return this;
		}
	}
}

