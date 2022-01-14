var Calysto;
(function (Calysto) {
    var Web;
    (function (Web_1) {
        var TestSite;
        (function (TestSite) {
            var Web;
            (function (Web) {
                var VS;
                (function (VS) {
                    var Home;
                    (function (Home) {
                        var HomeController;
                        (function (HomeController) {
                            // mark js file as EmbeddedResource for ScriptManager to load it in Release build
                            // include js file using ScriptManager for Relese build
                            // include js file on page with script tag for debugging
                            // add your code here
                            Calysto.Page.OnInteractive(function () {
                                $$calysto("button[test-func]").ForEach(function (o) {
                                    var fname = o.getAttribute("test-func");
                                    o.innerHTML = fname;
                                    o.onclick = function () {
                                        var fn1 = HomeController[fname](1);
                                        fn1.OnSuccess(function (resp) { return alert(resp); });
                                    };
                                });
                                $$calysto("#btnCheckLoginModel").OnClick(function (sender, ev) {
                                    var dic = Calysto.Forms.FormSerialize("#form1");
                                    HomeController.CheckLoginModel(dic);
                                });
                            });
                        })(HomeController = Home.HomeController || (Home.HomeController = {}));
                    })(Home = VS.Home || (VS.Home = {}));
                })(VS = Web.VS || (Web.VS = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Home.js.map