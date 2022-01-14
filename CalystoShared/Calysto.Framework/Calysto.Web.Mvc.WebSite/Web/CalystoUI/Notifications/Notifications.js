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
                    var Notifications;
                    (function (Notifications) {
                        var _autoHide = 5000;
                        function ShowNotification1() {
                            Calysto.Notification.Create("this is my text", "none", _autoHide).Show();
                        }
                        Notifications.ShowNotification1 = ShowNotification1;
                        function ShowNotification2() {
                            Calysto.Notification.Create("this is my text", "error", _autoHide, "bottom", "left").Show();
                        }
                        Notifications.ShowNotification2 = ShowNotification2;
                        function ShowNotification3() {
                            Calysto.Notification.Create("this is my text", "info", _autoHide, "bottom", "center").Show();
                        }
                        Notifications.ShowNotification3 = ShowNotification3;
                        function ShowNotification4() {
                            Calysto.Notification.Create("this is my text", "question", _autoHide, "bottom", "right").Show();
                        }
                        Notifications.ShowNotification4 = ShowNotification4;
                        function ShowNotification5() {
                            Calysto.Notification.Create("this is my text", "success", _autoHide, "top", "left").Show();
                        }
                        Notifications.ShowNotification5 = ShowNotification5;
                        function ShowNotification6() {
                            Calysto.Notification.Create("this is my text", "warning", _autoHide, "top", "center").Show();
                        }
                        Notifications.ShowNotification6 = ShowNotification6;
                        function ShowNotification7() {
                            Calysto.Notification.Create("this is my text", "error", _autoHide, "top", "right").Show();
                        }
                        Notifications.ShowNotification7 = ShowNotification7;
                    })(Notifications = CalystoUI.Notifications || (CalystoUI.Notifications = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Notifications = Calysto.Web.TestSite.Web.CalystoUI.Notifications;
//# sourceMappingURL=Notifications.js.map