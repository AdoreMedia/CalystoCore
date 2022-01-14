namespace Binding4
{
	export function SelitemsHandler(context: Calysto.Binding.IDataListenerContext, selitems: Calysto.Binding.ISelectListItem<number>[])
	{
		context.Element.style.backgroundColor = selitems.AsEnumerable().Where(k => k.Selected).Count() > 1 ? "yellow" : "cyan";
	}

	export function MouseHandler(context: Calysto.Binding.IViewListenerContext) 
	{
		context.Element.style.backgroundColor = context.Event.type == 'mouseover' ? 'yellow' : 'silver'
	}

	export function ItemTemplateHandler(context: Calysto.Binding.IDataListenerContext, sel, notSel, anynw)
	{
		context.Element.style.backgroundColor = sel ? "green" : "red"
	}

	export function ActiveStateConverter1(context: Calysto.Binding.IDataListenerContext, active)
	{
		return active ? "aktivno stanje" : "nije aktivno stanje"
	}

	export function ActiveStateConverter2(context: Calysto.Binding.IDataListenerContext, active)
	{
		return active ? "greenyellow" : "red"
	}

	export function ActiveConverter1(context: Calysto.Binding.IDataListenerContext, active)
	{
		var a = 10;
		$$calysto(context.Element).ParentNodes().ApplyStyle('border:solid 0px blue');
		var b = active;
		return b ? '111 to je aktivno' : '111 nije aktivno';
	}

	export function ActiveConverter2(context: Calysto.Binding.IDataListenerContext, active)
	{
		return active ? "orange" : "violet"
	}

	export function Checkbox5(context: Calysto.Binding.IDataListenerContext, active)
	{
		$$calysto(context.Element).ParentNodes().ApplyStyle('border: 1px solid ' + (active ? 'green' : 'red'));
		return active;
	}

	export function Checkbox8(cx, active)
	{
		return !active;
	}

	export function Checkbox2Set(cx, active)
	{
		//console.log(cx);
		return !active
	}

	export function Checkbox2Get(cx, active)
	{
		//console.log(cx);
		return !active;
	}
}

namespace Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable4.Web
{
	export var fnGetOpis = function (cx, isActive) { return "ovo je opis iz metode GetOpis(" + isActive + ")"; };
	export var fnGetColor = function (cx, isActive) { return !isActive ? "red" : "green"; };
	export var fnNot = function (cx, val) { return !val; };
	export var fnActiveOpis = function (cx, isActive) { return isActive ? "aktivno je" : "nije aktivno"; };
	export var fnColor = function (cx, isActive) { return isActive ? "blue" : "red"; };
	export var fnSelected = function (cx, items) { return "ddl selection: " + new Calysto.List(items).AsEnumerable().Where((o: any) => o.Selected).Select((o: any) => o.Text).ToStringJoined(", "); };

	var ds11 = ({
		ready: true,
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

	let allItems = ds11.selitems.ToArray();
	window["ds11"] = ds11;
	let binder = new Calysto.Binding.BindingObservable();
	declare let factory1: Calysto.Binding.Setup.BindingFactory;
	declare let model1: any;

	Calysto.Page.OnInteractive(() =>
	{
		binder.SetFactory(factory1)
			.SetDataSource(ds11)
			.DataBind();

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

	Calysto.Core.ExportGlobal(Rebind1, "Binding4.Rebind1");
	Calysto.Core.ExportGlobal(Rebind2, "Binding4.Rebind2");
	Calysto.Core.ExportGlobal(Rebind3, "Binding4.Rebind3");

}
