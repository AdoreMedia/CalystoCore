namespace Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web
{
	export var fnGetOpis = function (cx, isActive) { return "ovo je opis iz metode GetOpis(" + isActive + ")"; };
	export var fnGetColor = function (cx, isActive) { return !isActive ? "red" : "green"; };
	export var fnNot = function (cx, val) { return !val; };
	export var fnActiveOpis = function (cx, isActive) { return isActive ? "aktivno je" : "nije aktivno"; };
	export var fnColor = function (cx, isActive) { return isActive ? "blue" : "red"; };
	export var fnSelected = function (cx, items) { return "ddl selection: " + new Calysto.List(items).AsEnumerable().Where((o: any) => o.Selected).Select((o: any) => o.Text).ToStringJoined(", "); };

	var ds11 = ({
		text: "ovo je sadrzaj neki bez veze",
		html: "ovo je moj html",
		state2: ({
			mm: 33,
			isActive: true,
			isActive2: true
		}),
		state: ({
			mm: 33,
			isActive: true,
			isActive2: true,
			Nsdff: () =>
			{
			},
			ClickedChk: function (context: Calysto.Binding.IViewListenerContext)
			{
				binder.SetValue("state.isActive", !ds11.state.isActive);
				var dd = 10;
			},
			DoSomething: function (context: Calysto.Binding.IViewListenerContext)
			{
				console.log("DoSomething: " + context.Element);
			},
			DivClick: function (context: Calysto.Binding.IViewListenerContext)
			{
				alert("DivClick");
			},
			HandleClick: function (context: Calysto.Binding.IViewListenerContext)
			{
				alert("HandleClick");
			}
		}),
		selitems: <Calysto.Binding.ISelectListItem<number>[]><any>([
			{ Text: "zero", Value: 0, Selected: true, Color: "green", Ages: [1, 2, 5, 8] },
			{ Text: "one", Value: 1, Selected: true, Color: "red", Ages: [3, 5] },
			{ Text: "two", Value: 2, Selected: false, Color: "magenta", Ages: [4] },
			{ Text: "three", Value: 3, Selected: true, Color: "blue", Ages: [5] },
			{ Text: "four", Value: 4, Selected: false, Color: "red", Ages: [6] }
		])
	});

	// build binding instructions
	let factory = new Calysto.Binding.Setup.BindingFactory()
		.Assign("button1", item => item.ListenView("click", "Binding.Rebind1"))
		.Assign("button2", item => item.ListenView("click", "Binding.Rebind2"))
		.Assign("button3", item => item.ListenView("click", "Binding.Rebind3"))
		.Assign("button4", item => item.ListenView("click", "Binding.Rebind1"))
		.Assign("button5", item => item.ListenView("click", "Binding.Rebind2"))
		.Assign("button6", item => item.ListenView("click", "Binding.Rebind3"))

		.Assign("divSomeValue", item => item.Bind("someValue", "state",
			(context, dsValue) => "vrijednost: " + dsValue,
			(context, elValue) => parseInt(elValue),
			["click", "mouseover", "mouseout", "change", "input"]))

		.Assign("divTopClicker", o => o.Source("state").ListenView("click", "HandleClick"))
		.Assign("divTopClicker", o => o.Source("state").ListenView("click", ds11.state.HandleClick))
		.Assign("divTopSubClick", o => o.ListenView("click", ds11.state.DivClick)
			.ListenView(["mouseover", "mouseout"], (context) => { context.Element.style.backgroundColor = context.Event.type == "mouseover" ? "yellow" : "silver" }))

		.Assign("repeaterOuter", o => o.Repeater("selitems").ListenData("selitems", (context, selitems: Calysto.Binding.ISelectListItem<number>[]) =>
		{
			context.Element.style.backgroundColor = selitems.AsEnumerable().Where(k => k.Selected).Count() > 1 ? "yellow" : "cyan";
		}))

		.Assign("templateHeader", o => o.Template(Calysto.Binding.TemplateKind.Header))
		.Assign("templateSeparator", o => o.Template(Calysto.Binding.TemplateKind.Separator))
		.Assign("templateFooter", o => o.Template(Calysto.Binding.TemplateKind.Footer))
		.Assign("templateItem", o => o.Template(Calysto.Binding.TemplateKind.Item)
			.ListenData(["Selected", "NotSelected", "Any.New.Year"], (context, sel, notSel, anynw) =>
			{
				context.Element.style.backgroundColor = sel ? "green" : "red"
			}))

		.Assign("textSelected", o => o.Bind("innerHTML", "DataItem.Selected", value => value ? "selected" : "not selected"))

		.Assign("repeaterAges", o => o.Repeater("Ages"))
		.Assign("templateAgesNoData", o => o.Template(Calysto.Binding.TemplateKind.NoData))
		.Assign("templateAgesItem", o => o.Template(Calysto.Binding.TemplateKind.Item))
		.Assign("templateAgesSeparator", o => o.Template(Calysto.Binding.TemplateKind.Separator))

		.Assign("agesDataItem", o => o.Bind("innerHTML", "DataItem"))
		.Assign("agesIndexItem", o => o.Bind("innerHTML", "ItemIndex"))

		.Assign("labelAges", o => o.Source("@.state"))
		.Assign("checkbox1", o => o.Bind("checked", "@.state.isActive"))
		.Assign("checkbox2", o => o.Bind("checked", "isActive", (cx, active) => { console.log(cx); return !active }, (cx, active) => { console.log(cx); return !active }))
		.Assign("checkbox3", o => o.Bind("checked", "isActive", (cx, active) => active))
		.Assign("checkbox4", o => o.Bind("checked", "@.state.isActive", (cx, active) => active))
		.Assign("spantext1", o => o.Bind("innerHTML", "Text"))
		.Assign("spanvalue1", o => o.Bind("innerHTML", "Value"))
		.Assign("spanselected1", o => o.Bind("innerHTML", "Selected"))

		.Assign("spanactive1", o => o.Bind("innerHTML", "state.isActive", (cx, active) => active ? "aktivno stanje" : "nije aktivno stanje")
			.Bind("style.color", "state.isActive", (cx, active) => active ? "greenyellow" : "red"))

		.Assign("spantext2", o => o.Bind("innerHTML", "text"))

		.Assign("divextensive1", o => o.Bind("innerHTML", "state.isActive", (cx, active) =>
		{
			var a = 10;
			$$calysto(cx.Element).ParentNodes().ApplyStyle('border:solid 0px blue');
			var b = active;
			return b ? '111 to je aktivno' : '111 nije aktivno';
		}).Bind("style.color", "state.isActive", (cx, active) => active ? "orange" : "violet"))

		.Assign("checkbox5", o => o.Bind("checked", "state.isActive", (cx, active) => { $$calysto(cx.Element).ParentNodes().ApplyStyle('border: 1px solid ' + (active ? 'green' : 'red')); return active; }))

		.Assign("divActiveDesc", o => o.Bind("innerHTML", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnActiveOpis"))

		.Assign("labelActive1", o => o.Source("state"))
		.Assign("checkbox6", o => o.Bind("checked", "@.state.isActive", (cx, active) => !!active)
			.ListenView(["mouseover", "mouseout"], (cx) => console.log(cx))
			.ListenView(["mouseover", "mouseout"], "@.state.DoSomething"))
		.Assign("checkbox7", o => o.Bind("checked", "@.state.isActive"))
		.Assign("checkbox8", o => o.Bind("checked", "state.isActive", (cx, active) => !active, (cx, active) => !active))

		.Assign("divDescription1", o => o
			.Bind("innerHTML", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnGetOpis")
			.Bind("style.color", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnGetColor"))

		.Assign("inputtext1", o => o.Source("state").Bind("value", "isActive"))
		.Assign("divSelected1", o => o.Bind("innerHTML", "selitems", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnSelected"))

		.Assign("select1", o => o.Bind("options", "selitems"))
		.Assign("select2", o => o.Bind("options", "selitems"))

		.Assign("repeater3", o => o.Repeater("selitems"))
		.Assign("template3Item", o => o.Template(Calysto.Binding.TemplateKind.Item))

		.Assign("radio1", o => o.Bind("checked", "Selected").Bind("value", "Value"))
		.Assign("spanitem1", o => o.Bind("innerHTML", "Text"))

		.Assign("repeater4", o => o.Repeater("selitems"))
		.Assign("template4Item", o => o.Template(Calysto.Binding.TemplateKind.Item))

		.Assign("checkbox9", o => o.Bind("value", "Value").Bind("checked", "Selected"))
		.Assign("spantext3", o => o.Bind("innerHTML", "Text"))
		;


	let allItems = ds11.selitems.ToArray();

	window["ds11"] = ds11;
	//let binder = new Calysto.Observable.ObservableBinder().SetDataSource(ds11);
	let binder = new Calysto.Binding.BindingObservable();

	Calysto.Page.OnInteractive(() =>
	{
		binder.SetRootElement("#divBindingRoot").SetFactory(factory).SetDataSource(ds11).DataBind();

		$$calysto("#divBindingRoot").SetVisible(true);

		//GetBindingHtml().OnSuccess(resp =>
		//{
		//	$$calysto("body").AddChildren(resp);
		//	binder.SetDataSource(ds11).DataBind();
		//});

	});

	export function Rebind1()
	{
		binder.DataBind();
	}

	export function Rebind2()
	{
		ds11.selitems.RemoveAt(0);
		binder.DataBind();
	}

	export function Rebind3()
	{
		ds11.selitems.InsertRange(0, allItems.slice(0, 1));
		binder.DataBind();
	}

	Calysto.Core.ExportGlobal(Rebind1, "Binding.Rebind1");
	Calysto.Core.ExportGlobal(Rebind2, "Binding.Rebind2");
	Calysto.Core.ExportGlobal(Rebind3, "Binding.Rebind3");

}
