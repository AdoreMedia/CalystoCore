var Binding4;
(function (Binding4) {
    function SelitemsHandler(context, selitems) {
        context.Element.style.backgroundColor = selitems.AsEnumerable().Where(function (k) { return k.Selected; }).Count() > 1 ? "yellow" : "cyan";
    }
    Binding4.SelitemsHandler = SelitemsHandler;
    function MouseHandler(context) {
        context.Element.style.backgroundColor = context.Event.type == 'mouseover' ? 'yellow' : 'silver';
    }
    Binding4.MouseHandler = MouseHandler;
    function ItemTemplateHandler(context, sel, notSel, anynw) {
        context.Element.style.backgroundColor = sel ? "green" : "red";
    }
    Binding4.ItemTemplateHandler = ItemTemplateHandler;
    function ActiveStateConverter1(context, active) {
        return active ? "aktivno stanje" : "nije aktivno stanje";
    }
    Binding4.ActiveStateConverter1 = ActiveStateConverter1;
    function ActiveStateConverter2(context, active) {
        return active ? "greenyellow" : "red";
    }
    Binding4.ActiveStateConverter2 = ActiveStateConverter2;
    function ActiveConverter1(context, active) {
        var a = 10;
        $$calysto(context.Element).ParentNodes().ApplyStyle('border:solid 0px blue');
        var b = active;
        return b ? '111 to je aktivno' : '111 nije aktivno';
    }
    Binding4.ActiveConverter1 = ActiveConverter1;
    function ActiveConverter2(context, active) {
        return active ? "orange" : "violet";
    }
    Binding4.ActiveConverter2 = ActiveConverter2;
    function Checkbox5(context, active) {
        $$calysto(context.Element).ParentNodes().ApplyStyle('border: 1px solid ' + (active ? 'green' : 'red'));
        return active;
    }
    Binding4.Checkbox5 = Checkbox5;
    function Checkbox8(cx, active) {
        return !active;
    }
    Binding4.Checkbox8 = Checkbox8;
    function Checkbox2Set(cx, active) {
        //console.log(cx);
        return !active;
    }
    Binding4.Checkbox2Set = Checkbox2Set;
    function Checkbox2Get(cx, active) {
        //console.log(cx);
        return !active;
    }
    Binding4.Checkbox2Get = Checkbox2Get;
})(Binding4 || (Binding4 = {}));
var Calysto;
(function (Calysto) {
    var Genesis;
    (function (Genesis) {
        var WebTest;
        (function (WebTest) {
            var CalystoWebControlsTests;
            (function (CalystoWebControlsTests) {
                var CalystoBindable4;
                (function (CalystoBindable4) {
                    var Web;
                    (function (Web) {
                        Web.fnGetOpis = function (cx, isActive) { return "ovo je opis iz metode GetOpis(" + isActive + ")"; };
                        Web.fnGetColor = function (cx, isActive) { return !isActive ? "red" : "green"; };
                        Web.fnNot = function (cx, val) { return !val; };
                        Web.fnActiveOpis = function (cx, isActive) { return isActive ? "aktivno je" : "nije aktivno"; };
                        Web.fnColor = function (cx, isActive) { return isActive ? "blue" : "red"; };
                        Web.fnSelected = function (cx, items) { return "ddl selection: " + new Calysto.List(items).AsEnumerable().Where(function (o) { return o.Selected; }).Select(function (o) { return o.Text; }).ToStringJoined(", "); };
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
                        var allItems = ds11.selitems.ToArray();
                        window["ds11"] = ds11;
                        var binder = new Calysto.Binding.BindingObservable();
                        Calysto.Page.OnInteractive(function () {
                            binder.SetFactory(factory1)
                                .SetDataSource(ds11)
                                .DataBind();
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
                        Calysto.Core.ExportGlobal(Rebind1, "Binding4.Rebind1");
                        Calysto.Core.ExportGlobal(Rebind2, "Binding4.Rebind2");
                        Calysto.Core.ExportGlobal(Rebind3, "Binding4.Rebind3");
                    })(Web = CalystoBindable4.Web || (CalystoBindable4.Web = {}));
                })(CalystoBindable4 = CalystoWebControlsTests.CalystoBindable4 || (CalystoWebControlsTests.CalystoBindable4 = {}));
            })(CalystoWebControlsTests = WebTest.CalystoWebControlsTests || (WebTest.CalystoWebControlsTests = {}));
        })(WebTest = Genesis.WebTest || (Genesis.WebTest = {}));
    })(Genesis = Calysto.Genesis || (Calysto.Genesis = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Binding4.js.map