var Calysto;
(function (Calysto) {
    var Genesis;
    (function (Genesis) {
        var WebTest;
        (function (WebTest) {
            var CalystoWebControlsTests;
            (function (CalystoWebControlsTests) {
                var CalystoBindable3;
                (function (CalystoBindable3) {
                    var Web;
                    (function (Web) {
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
                        var factory = new Calysto.Binding.Setup.BindingFactory()
                            .Assign("mainRepeater", function (a) { return a.Repeater("DataItem"); })
                            .Assign("templateHeader", function (a) { return a.Template(Calysto.Binding.TemplateKind.Header); })
                            .Assign("templateFooter", function (a) { return a.Template(Calysto.Binding.TemplateKind.Footer); })
                            .Assign("templateNoData", function (a) { return a.Template(Calysto.Binding.TemplateKind.NoData); })
                            .Assign("templateSeparator", function (a) { return a.Template(Calysto.Binding.TemplateKind.Separator); })
                            .Assign("templateItem", function (a) { return a.Template(Calysto.Binding.TemplateKind.Item); })
                            .Assign("divName", function (a) { return a.Bind("innerHTML", "Name"); })
                            .Assign("divIndex", function (a) { return a.Bind("innerHTML", "ItemIndex", function (cx, index) { return "index: " + index; }); })
                            .Assign("repeater2", function (a) { return a.Repeater("Items"); })
                            .Assign("templ2Item", function (a) { return a.Template(Calysto.Binding.TemplateKind.Item); })
                            .Assign("div2Item", function (a) { return a.Bind("innerHTML", "DataItem"); })
                            .Assign("input1", function (a) { return a.Bind("value", "DataItem", undefined, undefined, ["change", "input", "click", "mouseover", "mouseout"]); })
                            .Assign("input2", function (a) { return a.Bind("value", "DataItem"); })
                            .Assign("input3", function (a) { return a.Bind("value", "DataItem"); })
                            .Assign("input4", function (a) { return a.Bind("value", "DataItem"); })
                            .Assign("input5", function (a) { return a.Bind("value", "DataItem"); })
                            .Assign("templ2Separator", function (a) { return a.Template(Calysto.Binding.TemplateKind.Separator); })
                            .Assign("temp2Header", function (a) { return a.Template(Calysto.Binding.TemplateKind.Header); })
                            .Assign("temp2Footer", function (a) { return a.Template(Calysto.Binding.TemplateKind.Footer); })
                            .Assign("temp2NoData", function (a) { return a.Template(Calysto.Binding.TemplateKind.NoData); });
                        var mm = new Calysto.Binding.BindingObservable()
                            .SetFactory(factory)
                            .SetRootElement("#root111")
                            .SetDataSource(dd.hh)
                            .DataBind();
                    })(Web = CalystoBindable3.Web || (CalystoBindable3.Web = {}));
                })(CalystoBindable3 = CalystoWebControlsTests.CalystoBindable3 || (CalystoWebControlsTests.CalystoBindable3 = {}));
            })(CalystoWebControlsTests = WebTest.CalystoWebControlsTests || (WebTest.CalystoWebControlsTests = {}));
        })(WebTest = Genesis.WebTest || (Genesis.WebTest = {}));
    })(Genesis = Calysto.Genesis || (Calysto.Genesis = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Binding2.js.map