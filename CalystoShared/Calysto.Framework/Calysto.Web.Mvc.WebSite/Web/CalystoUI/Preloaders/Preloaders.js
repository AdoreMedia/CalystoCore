var Calysto;
(function (Calysto) {
    var Web;
    (function (Web_1) {
        var TestSite;
        (function (TestSite) {
            var Web;
            (function (Web) {
                var CalystoUI;
                (function (CalystoUI) {
                    var Preloaders;
                    (function (Preloaders) {
                        var PreloadersController;
                        (function (PreloadersController) {
                            // mark js file as EmbeddedResource for ScriptManager to load it in Release build
                            // include js file using ScriptManager for Relese build
                            // include js file on page with script tag for debugging
                            // add your code here
                            function AppendItem(name, svg) {
                                $$calysto(["#divContainer1", "#divContainer2", "#divContainer3"])
                                    .AddChildren("\n<div class=\"spinnerItem\">\n\t<div class=\"spinnerLabel\">".concat(name, "</div>\n\t<div class=\"svgContainer\">").concat(svg, "</div>\n</div>\n"));
                            }
                            Calysto.Page.OnInteractive(function () {
                                for (var prop in Calysto.Preloaders) {
                                    var fn1 = Calysto.Preloaders[prop];
                                    if (typeof fn1 == "function") {
                                        AppendItem(prop, fn1());
                                    }
                                }
                            });
                        })(PreloadersController = Preloaders.PreloadersController || (Preloaders.PreloadersController = {}));
                    })(Preloaders = CalystoUI.Preloaders || (CalystoUI.Preloaders = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Preloaders.js.map