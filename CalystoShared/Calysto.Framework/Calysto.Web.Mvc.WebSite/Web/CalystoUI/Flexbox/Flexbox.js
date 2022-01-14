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
                    var Flexbox;
                    (function (Flexbox) {
                        var FlexboxController;
                        (function (FlexboxController) {
                            // mark js file as EmbeddedResource for ScriptManager to load it in Release build
                            // include js file using ScriptManager for Relese build
                            // include js file on page with script tag for debugging
                            // add your code here
                            function fnGoHome() {
                                console.log("Invoked fnGoHome");
                            }
                            var fnLambda = function () {
                                console.log("fnLambda");
                            };
                            Calysto.Core.ExportGlobal(fnGoHome);
                            //Calysto.Core.ExportGlobal(fnLambda); // ovo ne radi na IE-u 11 i starijima
                            function LoadDynamicContent(id, url) {
                                new Calysto.Net.WebClient(url)
                                    .OnLoad(function (sender, ev) {
                                    var txt = sender.GetResponseText();
                                    var h1 = Calysto.DomQuery.FromHtml(txt);
                                    $$calysto("#" + id).ParentNodes().ReplaceWith(h1);
                                }).Start();
                            }
                            FlexboxController.LoadDynamicContent = LoadDynamicContent;
                        })(FlexboxController = Flexbox.FlexboxController || (Flexbox.FlexboxController = {}));
                    })(Flexbox = CalystoUI.Flexbox || (CalystoUI.Flexbox = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var FlexboxControllerWeb = Calysto.Web.TestSite.Web.CalystoUI.Flexbox.FlexboxController;
//# sourceMappingURL=Flexbox.js.map