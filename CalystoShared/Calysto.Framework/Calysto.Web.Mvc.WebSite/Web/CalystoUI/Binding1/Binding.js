var Calysto;
(function (Calysto) {
    var Genesis;
    (function (Genesis) {
        var WebTest;
        (function (WebTest) {
            var CalystoWebControlsTests;
            (function (CalystoWebControlsTests) {
                var CalystoBindable1;
                (function (CalystoBindable1) {
                    var Web;
                    (function (Web) {
                        Web.fnGetOpis = function (cx, isActive) { return "ovo je opis iz metode GetOpis(" + isActive + ")"; };
                        Web.fnGetColor = function (cx, isActive) { return !isActive ? "red" : "green"; };
                        Web.fnNot = function (cx, val) { return !val; };
                        Web.fnActiveOpis = function (cx, isActive) { return isActive ? "aktivno je" : "nije aktivno"; };
                        Web.fnColor = function (cx, isActive) { return isActive ? "blue" : "red"; };
                        Web.fnSelected = function (cx, items) { return "ddl selection: " + new Calysto.List(items).AsEnumerable().Where(function (o) { return o.Selected; }).Select(function (o) { return o.Text; }).ToStringJoined(", "); };
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
                                Nsdff: function () {
                                },
                                ClickedChk: function (context) {
                                    binder.SetValue("state.isActive", !ds11.state.isActive);
                                    var dd = 10;
                                },
                                DoSomething: function (context) {
                                    console.log("DoSomething: " + context.Element);
                                },
                                DivClick: function (context) {
                                    alert("DivClick");
                                },
                                HandleClick: function (context) {
                                    alert("HandleClick");
                                }
                            }),
                            selitems: ([
                                { Text: "zero", Value: 0, Selected: true, Color: "green", Ages: [1, 2, 5, 8] },
                                { Text: "one", Value: 1, Selected: true, Color: "red", Ages: [3, 5] },
                                { Text: "two", Value: 2, Selected: false, Color: "magenta", Ages: [4] },
                                { Text: "three", Value: 3, Selected: true, Color: "blue", Ages: [5] },
                                { Text: "four", Value: 4, Selected: false, Color: "red", Ages: [6] }
                            ])
                        });
                        // build binding instructions
                        var factory = new Calysto.Binding.Setup.BindingFactory()
                            .Assign("button1", function (item) { return item.ListenView("click", "Binding.Rebind1"); })
                            .Assign("button2", function (item) { return item.ListenView("click", "Binding.Rebind2"); })
                            .Assign("button3", function (item) { return item.ListenView("click", "Binding.Rebind3"); })
                            .Assign("button4", function (item) { return item.ListenView("click", "Binding.Rebind1"); })
                            .Assign("button5", function (item) { return item.ListenView("click", "Binding.Rebind2"); })
                            .Assign("button6", function (item) { return item.ListenView("click", "Binding.Rebind3"); })
                            .Assign("divSomeValue", function (item) { return item.Bind("someValue", "state", function (context, dsValue) { return "vrijednost: " + dsValue; }, function (context, elValue) { return parseInt(elValue); }, ["click", "mouseover", "mouseout", "change", "input"]); })
                            .Assign("divTopClicker", function (o) { return o.Source("state").ListenView("click", "HandleClick"); })
                            .Assign("divTopClicker", function (o) { return o.Source("state").ListenView("click", ds11.state.HandleClick); })
                            .Assign("divTopSubClick", function (o) { return o.ListenView("click", ds11.state.DivClick)
                            .ListenView(["mouseover", "mouseout"], function (context) { context.Element.style.backgroundColor = context.Event.type == "mouseover" ? "yellow" : "silver"; }); })
                            .Assign("repeaterOuter", function (o) { return o.Repeater("selitems").ListenData("selitems", function (context, selitems) {
                            context.Element.style.backgroundColor = selitems.AsEnumerable().Where(function (k) { return k.Selected; }).Count() > 1 ? "yellow" : "cyan";
                        }); })
                            .Assign("templateHeader", function (o) { return o.Template(Calysto.Binding.TemplateKind.Header); })
                            .Assign("templateSeparator", function (o) { return o.Template(Calysto.Binding.TemplateKind.Separator); })
                            .Assign("templateFooter", function (o) { return o.Template(Calysto.Binding.TemplateKind.Footer); })
                            .Assign("templateItem", function (o) { return o.Template(Calysto.Binding.TemplateKind.Item)
                            .ListenData(["Selected", "NotSelected", "Any.New.Year"], function (context, sel, notSel, anynw) {
                            context.Element.style.backgroundColor = sel ? "green" : "red";
                        }); })
                            .Assign("textSelected", function (o) { return o.Bind("innerHTML", "DataItem.Selected", function (value) { return value ? "selected" : "not selected"; }); })
                            .Assign("repeaterAges", function (o) { return o.Repeater("Ages"); })
                            .Assign("templateAgesNoData", function (o) { return o.Template(Calysto.Binding.TemplateKind.NoData); })
                            .Assign("templateAgesItem", function (o) { return o.Template(Calysto.Binding.TemplateKind.Item); })
                            .Assign("templateAgesSeparator", function (o) { return o.Template(Calysto.Binding.TemplateKind.Separator); })
                            .Assign("agesDataItem", function (o) { return o.Bind("innerHTML", "DataItem"); })
                            .Assign("agesIndexItem", function (o) { return o.Bind("innerHTML", "ItemIndex"); })
                            .Assign("labelAges", function (o) { return o.Source("@.state"); })
                            .Assign("checkbox1", function (o) { return o.Bind("checked", "@.state.isActive"); })
                            .Assign("checkbox2", function (o) { return o.Bind("checked", "isActive", function (cx, active) { console.log(cx); return !active; }, function (cx, active) { console.log(cx); return !active; }); })
                            .Assign("checkbox3", function (o) { return o.Bind("checked", "isActive", function (cx, active) { return active; }); })
                            .Assign("checkbox4", function (o) { return o.Bind("checked", "@.state.isActive", function (cx, active) { return active; }); })
                            .Assign("spantext1", function (o) { return o.Bind("innerHTML", "Text"); })
                            .Assign("spanvalue1", function (o) { return o.Bind("innerHTML", "Value"); })
                            .Assign("spanselected1", function (o) { return o.Bind("innerHTML", "Selected"); })
                            .Assign("spanactive1", function (o) { return o.Bind("innerHTML", "state.isActive", function (cx, active) { return active ? "aktivno stanje" : "nije aktivno stanje"; })
                            .Bind("style.color", "state.isActive", function (cx, active) { return active ? "greenyellow" : "red"; }); })
                            .Assign("spantext2", function (o) { return o.Bind("innerHTML", "text"); })
                            .Assign("divextensive1", function (o) { return o.Bind("innerHTML", "state.isActive", function (cx, active) {
                            var a = 10;
                            $$calysto(cx.Element).ParentNodes().ApplyStyle('border:solid 0px blue');
                            var b = active;
                            return b ? '111 to je aktivno' : '111 nije aktivno';
                        }).Bind("style.color", "state.isActive", function (cx, active) { return active ? "orange" : "violet"; }); })
                            .Assign("checkbox5", function (o) { return o.Bind("checked", "state.isActive", function (cx, active) { $$calysto(cx.Element).ParentNodes().ApplyStyle('border: 1px solid ' + (active ? 'green' : 'red')); return active; }); })
                            .Assign("divActiveDesc", function (o) { return o.Bind("innerHTML", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnActiveOpis"); })
                            .Assign("labelActive1", function (o) { return o.Source("state"); })
                            .Assign("checkbox6", function (o) { return o.Bind("checked", "@.state.isActive", function (cx, active) { return !!active; })
                            .ListenView(["mouseover", "mouseout"], function (cx) { return console.log(cx); })
                            .ListenView(["mouseover", "mouseout"], "@.state.DoSomething"); })
                            .Assign("checkbox7", function (o) { return o.Bind("checked", "@.state.isActive"); })
                            .Assign("checkbox8", function (o) { return o.Bind("checked", "state.isActive", function (cx, active) { return !active; }, function (cx, active) { return !active; }); })
                            .Assign("divDescription1", function (o) { return o
                            .Bind("innerHTML", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnGetOpis")
                            .Bind("style.color", "state.isActive", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnGetColor"); })
                            .Assign("inputtext1", function (o) { return o.Source("state").Bind("value", "isActive"); })
                            .Assign("divSelected1", function (o) { return o.Bind("innerHTML", "selitems", "Calysto.Genesis.WebTest.CalystoWebControlsTests.CalystoBindable1.Web.fnSelected"); })
                            .Assign("select1", function (o) { return o.Bind("options", "selitems"); })
                            .Assign("select2", function (o) { return o.Bind("options", "selitems"); })
                            .Assign("repeater3", function (o) { return o.Repeater("selitems"); })
                            .Assign("template3Item", function (o) { return o.Template(Calysto.Binding.TemplateKind.Item); })
                            .Assign("radio1", function (o) { return o.Bind("checked", "Selected").Bind("value", "Value"); })
                            .Assign("spanitem1", function (o) { return o.Bind("innerHTML", "Text"); })
                            .Assign("repeater4", function (o) { return o.Repeater("selitems"); })
                            .Assign("template4Item", function (o) { return o.Template(Calysto.Binding.TemplateKind.Item); })
                            .Assign("checkbox9", function (o) { return o.Bind("value", "Value").Bind("checked", "Selected"); })
                            .Assign("spantext3", function (o) { return o.Bind("innerHTML", "Text"); });
                        var allItems = ds11.selitems.ToArray();
                        window["ds11"] = ds11;
                        //let binder = new Calysto.Observable.ObservableBinder().SetDataSource(ds11);
                        var binder = new Calysto.Binding.BindingObservable();
                        Calysto.Page.OnInteractive(function () {
                            binder.SetRootElement("#divBindingRoot").SetFactory(factory).SetDataSource(ds11).DataBind();
                            $$calysto("#divBindingRoot").SetVisible(true);
                            //GetBindingHtml().OnSuccess(resp =>
                            //{
                            //	$$calysto("body").AddChildren(resp);
                            //	binder.SetDataSource(ds11).DataBind();
                            //});
                        });
                        function Rebind1() {
                            binder.DataBind();
                        }
                        Web.Rebind1 = Rebind1;
                        function Rebind2() {
                            ds11.selitems.RemoveAt(0);
                            binder.DataBind();
                        }
                        Web.Rebind2 = Rebind2;
                        function Rebind3() {
                            ds11.selitems.InsertRange(0, allItems.slice(0, 1));
                            binder.DataBind();
                        }
                        Web.Rebind3 = Rebind3;
                        Calysto.Core.ExportGlobal(Rebind1, "Binding.Rebind1");
                        Calysto.Core.ExportGlobal(Rebind2, "Binding.Rebind2");
                        Calysto.Core.ExportGlobal(Rebind3, "Binding.Rebind3");
                    })(Web = CalystoBindable1.Web || (CalystoBindable1.Web = {}));
                })(CalystoBindable1 = CalystoWebControlsTests.CalystoBindable1 || (CalystoWebControlsTests.CalystoBindable1 = {}));
            })(CalystoWebControlsTests = WebTest.CalystoWebControlsTests || (WebTest.CalystoWebControlsTests = {}));
        })(WebTest = Genesis.WebTest || (Genesis.WebTest = {}));
    })(Genesis = Calysto.Genesis || (Calysto.Genesis = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Binding.js.map