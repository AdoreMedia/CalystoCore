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
                    var Common;
                    (function (Common) {
                        Calysto.Page.Preloader.Enable(300);
                        Calysto.Page.OnUnhandledException(function (msg) {
                            //Calysto.Dialog.CreateError(msg, "Inside OnUnhandledException").Show();
                        }).OnVersionExpired(function () {
                            Calysto.Dialog.ShowVersionExpired();
                        });
                    })(Common = CalystoUI.Common || (CalystoUI.Common = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Common.js.map