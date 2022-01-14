var __values = (this && this.__values) || function(o) {
    var s = typeof Symbol === "function" && Symbol.iterator, m = s && o[s], i = 0;
    if (m) return m.call(o);
    if (o && typeof o.length === "number") return {
        next: function () {
            if (o && i >= o.length) o = void 0;
            return { value: o && o[i++], done: !o };
        }
    };
    throw new TypeError(s ? "Object is not iterable." : "Symbol.iterator is not defined.");
};
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
                    var Checkboxes;
                    (function (Checkboxes) {
                        var CheckboxesController;
                        (function (CheckboxesController) {
                            // mark js file as EmbeddedResource for ScriptManager to load it in Release build
                            // include js file using ScriptManager for Relese build
                            // include js file on page with script tag for debugging
                            // add your code here
                            Calysto.Page.OnInteractive(function () {
                                var e_1, _a, e_2, _b;
                                var txt1 = Calysto.CalystoEnumerable.From(document.styleSheets)
                                    .SelectMany(function (o) { return Calysto.CalystoEnumerable.From(o.cssRules); })
                                    .Where(function (o) { return o.selectorText == ".calystoColorsList"; })
                                    .First().cssText;
                                var kvColors = new Calysto.Regex("([^ ]+)[\\s]*:[\\s]*([^ ]+); ")
                                    .Matches(txt1)
                                    .AsEnumerable()
                                    .Select(function (m) { return ({
                                    Name: m.Groups[1].replace("--calystoColor-", ""),
                                    Color: m.Groups[2]
                                }); }).ToArray();
                                // create all elements in all colors and themes
                                kvColors.unshift({
                                    Name: "Default",
                                    Color: ""
                                });
                                console.log(txt1);
                                console.log(kvColors);
                                var themes1 = ["defaultTheme"];
                                var $container = $$calysto("#divControlsContainer").ToList().AsDomQuery();
                                try {
                                    for (var themes1_1 = __values(themes1), themes1_1_1 = themes1_1.next(); !themes1_1_1.done; themes1_1_1 = themes1_1.next()) {
                                        var theme = themes1_1_1.value;
                                        var div1 = Calysto.DomQuery.CreateElement("div").AddClass(theme).First();
                                        $container.AddChildren(div1);
                                        var $div1 = $$calysto(div1);
                                        $div1.AddChildren("<h2>" + theme + " with calystoBtn</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateButton(kv.Name + " calystoBtn"); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " no calystoBtn</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateButton(kv.Name); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " with calystoBtn</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateSelects(kv.Name + " calystoBtn"); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " no calystoBtn</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateSelects(kv.Name); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " with calystoInp</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateInput(kv.Name + " calystoInp"); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " no calystoInp</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateInput(kv.Name); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " with calystoInp</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateTextArea(kv.Name + " calystoInp"); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                        $div1.AddChildren("<h2>" + theme + " no calystoInp</h2>");
                                        $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateTextArea(kv.Name); }).ToArray());
                                        $div1.AddChildren("<hr/>");
                                    }
                                }
                                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                                finally {
                                    try {
                                        if (themes1_1_1 && !themes1_1_1.done && (_a = themes1_1.return)) _a.call(themes1_1);
                                    }
                                    finally { if (e_1) throw e_1.error; }
                                }
                                var _loop_1 = function (theme) {
                                    var div1 = Calysto.DomQuery.CreateElement("div").AddClass(theme).First();
                                    $container.AddChildren(div1);
                                    var $div1 = $$calysto(div1);
                                    $div1.AddChildren("<h2>" + theme + "</h2>");
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name, "checkbox"); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name, "checkbox", true); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name + " right", "checkbox"); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name + " right", "checkbox", true); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    var name1 = Calysto.Utility.Generators.GenerateLabel(10);
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name, "radio", false, name1); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    name1 = Calysto.Utility.Generators.GenerateLabel(10);
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name, "radio", true, name1); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    name1 = Calysto.Utility.Generators.GenerateLabel(10);
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name + " right", "radio", false, name1); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                    name1 = Calysto.Utility.Generators.GenerateLabel(10);
                                    $div1.AddChildren(kvColors.AsEnumerable().Select(function (kv) { return fnCreateCheckbox(kv.Name + " right", "radio", true, name1); }).ToArray());
                                    $div1.AddChildren("<hr/>");
                                };
                                try {
                                    for (var themes1_2 = __values(themes1), themes1_2_1 = themes1_2.next(); !themes1_2_1.done; themes1_2_1 = themes1_2.next()) {
                                        var theme = themes1_2_1.value;
                                        _loop_1(theme);
                                    }
                                }
                                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                                finally {
                                    try {
                                        if (themes1_2_1 && !themes1_2_1.done && (_b = themes1_2.return)) _b.call(themes1_2);
                                    }
                                    finally { if (e_2) throw e_2.error; }
                                }
                                // set disabled buttons
                                // calystoChk is on label, we have to set disabled on child input element to disable changing it's checked state on click
                                $$calysto(".calystoOrange").Query("*, //input").SetEnabled(false);
                            });
                            function fnCreateCheckbox(cls, type, isChecked, groupName) {
                                if (isChecked === void 0) { isChecked = false; }
                                return "<label class=\"".concat(cls, " calystoChk\" style=\"display:inline-block;margin:0 5px 5px 0;background:gainsboro;min-width:270px;\">\n\t\t\t<input type=\"").concat(type, "\" name=\"").concat(groupName, "\" ").concat((isChecked ? "checked" : ""), " ").concat((cls.Contains("ccolorGreen") ? "disabled" : ""), " />\n\t\t\t<span>").concat(cls, "</span>\n\t\t</label>");
                            }
                            function fnCreateButton(cls) {
                                return "<button type=\"submit\" value=\"".concat(cls, "\" class=\"").concat(cls, "\" style=\"margin:0 5px 5px 0\" >\n\t\t\t<div align=\"center\" style=\"white-space:nowrap;\">\n\t\t\t\t<table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%\">\n\t\t\t\t\t<tr>\n\t\t\t\t\t\t<td style=\"width:26px;position:relative;\">\n\t\t\t\t\t\t\t<img src=\"~/WebLib/Images/Icons/s16/silk/icons/accept.png\" />\n\t\t\t\t\t\t</td>\n\t\t\t\t\t\t<td class=\"calystoLabelText\">").concat(cls, "</td>\n\t\t\t\t\t</tr>\n\t\t\t\t</table>\n\t\t\t</div>\n\t\t</button>");
                            }
                            function fnCreateSelects(cls) {
                                return "<select name=\"ctl15\" class=\"".concat(cls, "\" style=\"margin:0 5px 5px 0\">\n\t\t\t<option value=\"prvi\">prvi</option>\n\t\t\t<option value=\"drugi\">drugi</option>\n\t\t\t<option value=\"treci\">treci</option>\n\t\t</select>");
                            }
                            function fnCreateInput(cls) {
                                return "<input class=\"".concat(cls, "\" type=\"text\" value=\"").concat(cls, "\" style=\"margin:0 5px 5px 0\" />");
                            }
                            function fnCreateTextArea(cls) {
                                return "<textarea class=\"".concat(cls, "\" style=\"margin:0 5px 5px 0\" >").concat(cls, "</textarea>");
                            }
                        })(CheckboxesController = Checkboxes.CheckboxesController || (Checkboxes.CheckboxesController = {}));
                    })(Checkboxes = CalystoUI.Checkboxes || (CalystoUI.Checkboxes = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Checkboxes.js.map