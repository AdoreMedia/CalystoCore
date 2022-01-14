declare namespace Calysto.Binding
{
	interface IBindingBase
	{
		Uid: string;
	}

	interface IBindingItem extends IBindingBase
	{
		DataSourcePath: string;
		ElementPath: string;
		EventNames?: (keyof HTMLElementEventMap)[];
		JsGetConvert?: string | ((context: IViewListenerContext, value: any) => any);
		JsSetConvert?: string | ((context: IDataListenerContext, value: any) => any);
	}

	interface IBindingSetup
	{
		RootUid: string;
		Bindings: IBindingItem[];
		DataListeners: IDataListeningItem[];
		ViewListeners: IHtmlListeningItem[];
		Repeaters: IRepeaterItem[];
		Sources: ISourceItem[];
		Templates: ITemplateItem[];
	}

	interface IDataListeningItem extends IBindingBase
	{
		DataSourcePaths: string[];
		JsHandler: string | ((context:IDataListenerContext, ...items:any[])=>void | boolean);
	}

	interface IHtmlListeningItem extends IBindingBase
	{
		EventNames: (keyof HTMLElementEventMap)[];
		JsHandler: string | ((context:IViewListenerContext)=>void | boolean);
	}

	interface IRepeaterItem extends IBindingBase
	{
		DataSourcePath: string;
	}

	interface ISourceItem extends IBindingBase
	{
		DataSourcePath: string;
	}

	interface ITemplateItem extends IBindingBase
	{
		TemplateKind: TemplateKind;
	}

	interface ISelectListGroup
	{
		Disabled: boolean;
		Name: string;
	}

	interface ISelectListItem<TValue>
	{
		Text: string;
		Value: TValue;
		Selected: boolean;
		Disabled: boolean;
		Group: ISelectListGroup;
	}

	interface IFuncHandler<TFunc>
	{
		Func: TFunc;
		/** object containing Func */
		HandlerContext?: any;
	}

	interface ElementSettings
	{
		Element: BindingElement;
		Settings: IBindingSetup;
	}

	interface BindableRepeater
	{
		header: BindingElement;
		item: BindingElement;
		alternating: BindingElement;
		separator: BindingElement;
		footer: BindingElement;
		nodata: BindingElement;
	}

	export interface BindingElement extends HTMLInputElement
	{
		$$observable_Uid: string;

		/** complete binding definition */
		$$observable_RootSetting: IBindingSetup;
		/** element binding definition */
		$$observable_ElementSetting: IBindingSetup;
		$$observable_Binder: BindingObservable;
		/** data path for repeater, source, template */
		$$observable_DataPath: string;
		$$observable_hasHtmlListenersAttached: boolean;
		$$observable_hasDataListenersAttached: boolean;

		$$observable_Log: string[];

		$$observable_PathResolver: BindingElementPathResolver;
		/** item index inside repeater, assigned on repeater templates creating */
		$$observable_ItemIndex: number;
		/** Data source listeners */
		$$observable_DataSourceListeners: DataSourceListenerItem[];


	}

	interface IListenerContext
	{
		Binder: Calysto.Binding.BindingObservable,
		/** current element */
		Element: HTMLElement,
		/** Data source root */
		DataSource: any,
		/** Data path bound to current Element */
		DataPath: string,
		/** context in which handler function is defined */
		HandlerContext: any,
	}

	interface IViewListenerContext extends IListenerContext
	{
		/** listening event names */
		ListeningEventsNames: string[],
		/** current event */
		Event: Event
	}

	interface IDataListenerContext extends IListenerContext
	{
		/** listening data paths */
		ListeningDataPaths: string[],
		/** current data values for listening paths */
		Values: any[]
	}
}