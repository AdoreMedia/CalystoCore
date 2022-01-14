namespace Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable3.Web
{
	var dd = {
		hh: [
			{
				Name: "jedan",
				Items: [1, 2, 3, 4]
			},
			{
				Name: "dva",
				Items: [3, 4, 5]
			}
		]
	};

	// build binding instructions
	let factory = new Calysto.Binding.Setup.BindingFactory()
		.Assign("mainRepeater", a => a.Repeater("DataItem"))
		.Assign("templateHeader", a => a.Template(Binding.TemplateKind.Header))
		.Assign("templateFooter", a => a.Template(Binding.TemplateKind.Footer))
		.Assign("templateNoData", a => a.Template(Binding.TemplateKind.NoData))
		.Assign("templateSeparator", a => a.Template(Binding.TemplateKind.Separator))
		.Assign("templateItem", a => a.Template(Binding.TemplateKind.Item))
		.Assign("divName", a => a.Bind("innerHTML", "Name"))
		.Assign("divIndex", a => a.Bind("innerHTML", "ItemIndex", (cx, index) => "index: " + index))
		.Assign("repeater2", a => a.Repeater("Items"))
		.Assign("templ2Item", a => a.Template(Binding.TemplateKind.Item))
		.Assign("div2Item", a => a.Bind("innerHTML", "DataItem"))
		.Assign("input1", a => a.Bind("value", "DataItem", undefined, undefined, ["change", "input", "click", "mouseover", "mouseout"]))
		.Assign("input2", a => a.Bind("value", "DataItem"))
		.Assign("input3", a => a.Bind("value", "DataItem"))
		.Assign("input4", a => a.Bind("value", "DataItem"))
		.Assign("input5", a => a.Bind("value", "DataItem"))
		.Assign("templ2Separator", a => a.Template(Binding.TemplateKind.Separator))
		.Assign("temp2Header", a => a.Template(Binding.TemplateKind.Header))
		.Assign("temp2Footer", a => a.Template(Binding.TemplateKind.Footer))
		.Assign("temp2NoData", a => a.Template(Binding.TemplateKind.NoData))
		;

	var mm = new Calysto.Binding.BindingObservable()
		.SetFactory(factory)
		.SetRootElement("#root111")
		.SetDataSource(dd.hh)
		.DataBind();
}
