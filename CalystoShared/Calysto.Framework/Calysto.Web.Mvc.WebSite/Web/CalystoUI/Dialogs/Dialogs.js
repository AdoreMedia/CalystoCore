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
                    var Dialogs;
                    (function (Dialogs) {
                        function InvokeShortContent(sender) {
                            Calysto.Dialog.CreateAlert("Delete file, sure?").Show();
                        }
                        Dialogs.InvokeShortContent = InvokeShortContent;
                        function InvokeLongContent(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("height:800px");
                            Calysto.Dialog.CreateAlert(msg.First()).Show();
                        }
                        Dialogs.InvokeLongContent = InvokeLongContent;
                        function InvokeWidthContent(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px");
                            Calysto.Dialog.CreateAlert(msg.First()).Show();
                        }
                        Dialogs.InvokeWidthContent = InvokeWidthContent;
                        function InvokeLongWidthContent(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px;height:800px;");
                            Calysto.Dialog.CreateAlert(msg.First()).Show();
                        }
                        Dialogs.InvokeLongWidthContent = InvokeLongWidthContent;
                        function ShowPanel(content) {
                            return Calysto.Dialog.CreatePanel().Content(content).Show();
                        }
                        function InvokeContentPanel(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1");
                            ShowPanel(msg.First());
                        }
                        Dialogs.InvokeContentPanel = InvokeContentPanel;
                        function InvokeLongContentPanel(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("height:800px");
                            ShowPanel(msg.First());
                        }
                        Dialogs.InvokeLongContentPanel = InvokeLongContentPanel;
                        function InvokeWidthContentPanel(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px");
                            ShowPanel(msg.First());
                        }
                        Dialogs.InvokeWidthContentPanel = InvokeWidthContentPanel;
                        function InvokeLongWidthContentPanel(sender) {
                            var msg = $$calysto(document.body).CloneNodes().ToList();
                            msg.AsDomQuery().Query("//.div1").ApplyStyle("width:800px;height:800px;");
                            ShowPanel(msg.First());
                        }
                        Dialogs.InvokeLongWidthContentPanel = InvokeLongWidthContentPanel;
                    })(Dialogs = CalystoUI.Dialogs || (CalystoUI.Dialogs = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Dialogs = Calysto.Web.TestSite.Web.CalystoUI.Dialogs;
//# sourceMappingURL=Dialogs.js.map