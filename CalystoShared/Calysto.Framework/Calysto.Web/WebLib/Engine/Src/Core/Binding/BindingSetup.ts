namespace Calysto.Binding.Setup
{
	class BindingSetup implements IBindingSetup
	{
		RootUid: string;
		Bindings: IBindingItem[] = [];
		ViewListeners: IHtmlListeningItem[] = [];
		Repeaters: IRepeaterItem[] = [];
		Templates: ITemplateItem[] = [];
		DataListeners: IDataListeningItem[] = [];
		Sources: ISourceItem[] = [];
	}

	class BindingService
	{
		private _uid: string;
		private _setup: BindingSetup;

		public constructor(uid: string, factory: BindingSetup)
		{
			this._uid = uid;
			this._setup = factory;
		}

		private GetCsvValues(csv?: string | string[]): string[]
		{
			if (!csv)
				return [];
			else if (typeof (csv) == "string")
			{
				var arr = csv?.Split(',').AsEnumerable().Select(o => o.Trim()).Where(o => !String.IsNullOrEmpty(o)).ToArray();
				if (arr && arr.length > 1)
					throw new Error("Single string value is expected or string[]. Provided CSV: " + csv);

				return arr.Any() ? arr : <any>null;
			}
			else if (Calysto.Type.TypeInspector.IsArray(csv))
			{
				return csv;
			}
			else
			{
				throw new Error("Invalid argument, requires string or string[]. Provided: " + csv);
			}
		}

		public Root()
		{
			if (this._setup.RootUid)
				throw new Error("Root is already defined.");
			this._setup.RootUid = this._uid;
			return this;
		}
		
		/**
		 * 2-way binding, 1 to 1
		 * @param elementPath single element path, e.g. value, style.backgroundColor, etc.
		 * @param dataSourcePath single data source path, e.g. path1.sub1, @.path.sub, path2, path3,...
		 * @param jsSetConvert 
		 *		1. Lambda: (dataSourceValue) => returns value which will be assigned to element property.
		 *		2. Data source handler path. Function should accept passed arguments and return value which will be assigned to element property.
		 *		3. External func name only. Function should accept passed arguments and return value which will be assigned to element property.
		 * @param jsGetConvert
		 *		1. Lambda: (elementValue) => returns value which will be assigned to data source property.
		 *		2. Data source handler path. Function should accept passed arguments and return value which will be assigned to element property.
		 *		3. External func name only. Function should accept passed arguments and return value which will be assigned to element property.
		 * @param eventNames
		 *		default is 'change', use CSV DOM events names, e.g. mouseover, mouseout, click, input, change
		 */
		public Bind(
			elementPath: string | string[],
			dataSourcePath: string | string[],
			jsSetConvert?: string | ((context: IDataListenerContext, dsValue: any) => any),
			jsGetConvert?: string | ((context: IViewListenerContext, elValue: any) => any),
			eventNames?: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[])
		{
			let elPaths1 = this.GetCsvValues(elementPath);
			if (elPaths1?.length != 1)
				throw new Error("Single element property path is required, but provided: " + elementPath);

			let dsPaths1 = this.GetCsvValues(dataSourcePath);
			if (dsPaths1?.length != 1)
				throw new Error("Single data source property path is required, but provided: " + dataSourcePath);

			this._setup.Bindings.push({
					Uid: this._uid,
					ElementPath: elPaths1[0],
					DataSourcePath: dsPaths1[0],
					JsSetConvert: jsSetConvert,
					JsGetConvert: jsGetConvert,
					EventNames: <(keyof HTMLElementEventMap)[]> this.GetCsvValues(eventNames)
				});
			return this;
		}

		/**
		 * Create listener for data source values.
		 * @param dataSourcePaths CSV: path1, @.path2.sub, path3...
		 * @param jsHandler
		 *		1. Lambda: (context, path1Value, @.path2.subValue, path3Value) => { }
		 *		2. Data source handler path. Function should accept passed arguments, e.g. (context, path1Value, @.path2.subValue, path3Value).
		 *			This inside is object in which handler function is defined.
		 *		3. External func name only. Function should accept passed arguments, e.g. (context, path1Value, @.path2.subValue, path3Value).
		 */
		public ListenData(
			dataSourcePaths: string | string[],
			jsHandler: string | ((context: IDataListenerContext, ...items: any[]) => void | boolean))
		{
			this._setup.DataListeners.push({
				Uid: this._uid,
				DataSourcePaths: this.GetCsvValues(dataSourcePaths),
				JsHandler: jsHandler
			});

			return this;
		}

		/**
		 * Create DOM listener.
		 * @param eventNames CSV: name1, name2, name3, ...
		 * @param jsHandler
		 *		1. Lambda: (context) => { }
		 *		2. Data source handler path. Function should accept (context) arguments.
		 * 			This inside is object in which handler func is defined.
		 *		3. External func name only. Function should accept (context) arguments.
		 */
		public ListenView(
			eventNames: keyof HTMLElementEventMap | (keyof HTMLElementEventMap)[],
			jsHandler: string | ((context: IViewListenerContext) => void | boolean))
		{
			this._setup.ViewListeners.push({
					Uid: this._uid,
					EventNames: <(keyof HTMLElementEventMap)[]>this.GetCsvValues(eventNames),
					JsHandler: jsHandler
				});
			return this;
		}

		/**
		 * Create data source path at current element.
		 * @param dataSourcePath
		 */
		public Source(dataSourcePath: string)
		{
			this._setup.Sources.push({
				Uid: this._uid,
				DataSourcePath: dataSourcePath,
			});
			return this;
		}

		public Repeater(dataSourcePath: string)
		{
			this._setup.Repeaters.push({
				Uid: this._uid,
				DataSourcePath: dataSourcePath,
			});
			return this;
		}

		public Template(kind: TemplateKind)
		{
			this._setup.Templates.push({
				Uid: this._uid,
				TemplateKind: kind,
			});
			return this;
		}
	}

	export class BindingFactory
	{
		private _setup = new BindingSetup();

		public GetSetup() { return this._setup }

		public GetRoot() {return this._setup.RootUid}

		public Assign(uid: string, action: (item: BindingService) => BindingService)
		{
			let service = new BindingService(uid, this._setup);
			action(service);
			return this;
		}
	}
}
