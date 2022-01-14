namespace Calysto.Binding.BindingCache
{
	let globalRepeatersDic: { [RepeaterUid: string]: BindableRepeater } = {};

	export function GetRepeaterSetting(element: BindingElement)
	{
		let uid = GetElementUid(element);
		return globalRepeatersDic[uid];
	}

	let globalElementsDic: { [ElementUid: string]: ElementSettings } = {};

	Calysto.Core.DebugRun(() =>
	{
		//#if DEBUG
		window["$$globalRepeatersDic"] = globalRepeatersDic;
		window["$$globalElementsDic"] = globalElementsDic;
		//#endif
	});

	export function GetBindingElement(uid: string)
	{
		return globalElementsDic[uid];
	}

	export function GetElementUid(element: HTMLElement)
	{
		return <string>element.getAttribute(Binding.Attributes.Uid);
	}

	function FindSettings(rootElement: BindingElement)
	{
		let json1 = <string>$$calysto(rootElement)
			.Query(`//div[${Calysto.Binding.Attributes.ComponentSetting}=*]`)
			.SelectInnerHtml()
			.FirstOrDefault();

		return Calysto.Json.Deserialize<IBindingSetup>(json1);
	}

	export function InitializeBindings(rootElement: BindingElement, settings?: IBindingSetup)
	{
		let fullSettings = settings || FindSettings(rootElement);
		rootElement.$$observable_RootSetting = fullSettings;

		// svi elementi sa uid atributom
		let elementsArr = $$calysto(rootElement).Query(`[${Calysto.Binding.Attributes.Uid}], //[${Calysto.Binding.Attributes.Uid}]`)
			.Select(o => ({
				Uid: o.getAttribute(Calysto.Binding.Attributes.Uid),
				Element: <BindingElement>o
			})).ToArray();

		// add to globalElementsDic
		elementsArr.ForEach(o =>
		{
			//console.log(o.Uid);
			if (!o.Uid)
				throw new Error(`Uid is undefined for ${o.Element.tagName} element`);

			if (globalElementsDic[o.Uid])
				throw new Error(`Multiple elements with the same uid: ${o.Uid}`);

			let sett1 = {
				RootUid: fullSettings.RootUid,
				Bindings: fullSettings.Bindings.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray(),
				ViewListeners: fullSettings.ViewListeners.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray(),
				DataListeners: fullSettings.DataListeners.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray(),
				Sources: fullSettings.Sources.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray(),
				Repeaters: fullSettings.Repeaters.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray(),
				Templates: fullSettings.Templates.AsEnumerable().Where(k => k.Uid == o.Uid).ToArray()
			};

			// if there is no setting for an element, let's throw exception
			if (!sett1.RootUid
				&& !sett1.Bindings.Any()
				&& !sett1.ViewListeners.Any()
				&& !sett1.DataListeners.Any()
				&& !sett1.Sources.Any()
				&& !sett1.Repeaters.Any()
				&& !sett1.Templates.Any())
				throw new Error(`No settings found for element with uid: ${o.Uid}`);

			globalElementsDic[o.Uid] = {
				Element: o.Element,
				Settings: sett1
			};
		});

		let elementsDic = elementsArr.AsEnumerable().ToRawObject(o => o.Uid, o => o.Element);

		let templates = fullSettings.Templates.AsEnumerable()
			.Select(o =>
			{
				let repeater1: BindingElement;
				try
				{
					repeater1 = <BindingElement>elementsDic[o.Uid].parentElement;
				}
				catch (err)
				{
					throw new Error(err + ", Uid: " + o.Uid);
				}

				return ({
					Template: o,
					Element: elementsDic[o.Uid],
					RepeaterElement: repeater1,
					RepeaterUid: <string>repeater1.getAttribute(Calysto.Binding.Attributes.Uid)
				})
			}).ToArray();

		let invalidTemplates = templates.AsEnumerable().Where(o => !o.RepeaterUid).ToArray();
		if (invalidTemplates.Any())
			throw new Error("Template has no parent element.");

		let invalidRepeaters = templates.AsEnumerable().Where(o => $$calysto(o.RepeaterElement).WhereVisible().Any()).ToArray();
		if (invalidRepeaters.Any())
			throw new Error("Repeater must have style='display:none'");

		let fnGetTemplate = (repeaterUid: string, templateKind: TemplateKind) =>
		{
			return <BindingElement>templates.AsEnumerable()
				.Where(o => o.RepeaterUid == repeaterUid && o.Template.TemplateKind == templateKind)
				.Select(o => o.Element)
				.FirstOrDefault();
		};

		// add to globalRepeatersDic
		fullSettings.Repeaters.ForEach(rep =>
		{
			if (!globalRepeatersDic[rep.Uid])
			{
				globalRepeatersDic[rep.Uid] = {
					header: fnGetTemplate(rep.Uid, TemplateKind.Header),
					item: fnGetTemplate(rep.Uid, TemplateKind.Item),
					alternating: fnGetTemplate(rep.Uid, TemplateKind.AlternatingItem),
					separator: fnGetTemplate(rep.Uid, TemplateKind.Separator),
					footer: fnGetTemplate(rep.Uid, TemplateKind.Footer),
					nodata: fnGetTemplate(rep.Uid, TemplateKind.NoData),
				};
			}
		});

		// now remove templates from DOM
		// it will remove repeaters nested inside templates
		$$calysto(templates.AsEnumerable().Select(o => o.Element).ToArray()).RemoveFromDom();

	}
}
