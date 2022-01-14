var Converters;
(function (Converters) {
    function ItemIndexConverter(cx, dsValue) {
        return "This is index value ".concat(dsValue, " in context data path ").concat(cx.DataPath);
    }
    Converters.ItemIndexConverter = ItemIndexConverter;
})(Converters || (Converters = {}));
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
                        var mm = new Calysto.Binding.BindingObservable()
                            .SetFactory(factory1)
                            .SetDataSource(model1)
                            .DataBind();
                        //setTimeout(() => mm.SetValue("Ready", true), 1000);
                    })(Web = CalystoBindable3.Web || (CalystoBindable3.Web = {}));
                })(CalystoBindable3 = CalystoWebControlsTests.CalystoBindable3 || (CalystoWebControlsTests.CalystoBindable3 = {}));
            })(CalystoWebControlsTests = WebTest.CalystoWebControlsTests || (WebTest.CalystoWebControlsTests = {}));
        })(WebTest = Genesis.WebTest || (Genesis.WebTest = {}));
    })(Genesis = Calysto.Genesis || (Calysto.Genesis = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Binding3.js.map