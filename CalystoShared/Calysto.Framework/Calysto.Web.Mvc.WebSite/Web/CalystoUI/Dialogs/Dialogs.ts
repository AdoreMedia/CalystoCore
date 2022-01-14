namespace Calysto.Web.TestSite.Web.CalystoUI.Dialogs
{
	export function InvokeShortContent(sender)
	{
		Calysto.Dialog.CreateAlert("Delete file, sure?").Show();
	}

	export function InvokeLongContent(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("height:800px");
		Calysto.Dialog.CreateAlert(<any>msg.First()).Show();
	}

	export function InvokeWidthContent(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px");
		Calysto.Dialog.CreateAlert(<any>msg.First()).Show();
	}

	export function InvokeLongWidthContent(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px;height:800px;");
		Calysto.Dialog.CreateAlert(<any>msg.First()).Show();
	}

	function ShowPanel(content)
	{
		return Calysto.Dialog.CreatePanel().Content(content).Show();
	}

	export function InvokeContentPanel(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1");
		ShowPanel(<any>msg.First());
	}

	export function InvokeLongContentPanel(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("height:800px");
		ShowPanel(<any>msg.First());
	}

	export function InvokeWidthContentPanel(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px");
		ShowPanel(<any>msg.First());
	}

	export function InvokeLongWidthContentPanel(sender)
	{
		let msg = $$calysto(document.body).CloneNodes().ToList();
		msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px;height:800px;");
		ShowPanel(<any>msg.First());
	}
}

const Dialogs = Calysto.Web.TestSite.Web.CalystoUI.Dialogs;
