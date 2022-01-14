var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
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
                    var Ajax;
                    (function (Ajax) {
                        var AjaxService = Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax.CalystoAjax;
                        function GetAjaxInputText() {
                            return $$calysto("#ajaxInput").Select(function (o) { return o.value; }).First();
                        }
                        function GetAjaxInputFiles() {
                            return $$calysto("#ajaxFiles").Select(function (o) { return o.files; }).First();
                        }
                        function AjaxSend(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                var a1;
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0: return [4 /*yield*/, AjaxService.AjaxSend(GetAjaxInputText(), GetAjaxInputFiles())
                                                .OnProgress(function (e) { return console.log((e.IsUpload ? "upload" : "download") + ": " + e.Percent + " % of " + e.Total + " bytes"); })
                                                .OnSuccess(function (resp) { return console.log(resp); })];
                                        case 1:
                                            a1 = _a.sent();
                                            return [2 /*return*/];
                                    }
                                });
                            });
                        }
                        Ajax.AjaxSend = AjaxSend;
                        function AjaxSendDelayed(sender) {
                            var a1 = AjaxService.AjaxSend(GetAjaxInputText(), GetAjaxInputFiles())
                                .OnProgress(function (e) { return console.log((e.IsUpload ? "upload" : "download") + ": " + e.Percent + " % of " + e.Total + " bytes"); })
                                .OnSuccess(function (resp) { return console.log(resp); });
                            setTimeout(function () { a1.OnSuccess(function (resp) { return alert("delayed: " + resp); }); }, 1000);
                        }
                        Ajax.AjaxSendDelayed = AjaxSendDelayed;
                        function InvokeAjaxError(sender) {
                            AjaxService.InvokeAjaxError();
                        }
                        Ajax.InvokeAjaxError = InvokeAjaxError;
                        function DownloadBlob(sender) {
                            AjaxService.DownloadBlob()
                                .OnSuccess(function (blob) { return blob.SaveFileAs(); });
                        }
                        Ajax.DownloadBlob = DownloadBlob;
                        function DownloadBlobError(sender) {
                            AjaxService.DownloadBlobError()
                                .OnSuccess(function (blob) { return blob.SaveFileAs(); });
                        }
                        Ajax.DownloadBlobError = DownloadBlobError;
                        function DownloadBlobArray(sender) {
                            AjaxService.DownloadBlobArray()
                                .OnSuccess(function (array) { return array.ForEach(function (m) { return m.SaveFileAs(); }); });
                        }
                        Ajax.DownloadBlobArray = DownloadBlobArray;
                        function DownloadBlobArrayError(sender) {
                            AjaxService.DownloadBlobArrayError()
                                .OnSuccess(function (array) { return array.ForEach(function (m) { return m.SaveFileAs(); }); });
                        }
                        Ajax.DownloadBlobArrayError = DownloadBlobArrayError;
                        function DownloadBinaryFrameObject(sender) {
                            AjaxService.DownloadBinaryFrameObject()
                                .OnSuccess(function (resp) {
                                resp.List.AsEnumerable().ForEach(function (o) { return o.SaveFileAs(); });
                                console.log(resp);
                            });
                        }
                        Ajax.DownloadBinaryFrameObject = DownloadBinaryFrameObject;
                        function SendClientDateTime(sender) {
                            AjaxService.SendClientDateTime(new Date())
                                .OnSuccess(function (resp) {
                                console.log(resp.ToStringFormated());
                            });
                        }
                        Ajax.SendClientDateTime = SendClientDateTime;
                        function SendResultAsync(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                var res1;
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0: return [4 /*yield*/, AjaxService.SendClientDateTime(new Date()).ResultAsync()];
                                        case 1:
                                            res1 = _a.sent();
                                            Calysto.Dialog.CreateAlert(res1.ToStringFormated(), "success").Show();
                                            return [2 /*return*/];
                                    }
                                });
                            });
                        }
                        Ajax.SendResultAsync = SendResultAsync;
                        function GetPartialResult(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                var html1;
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0: return [4 /*yield*/, AjaxService.GetPartialResult(Calysto.DateTime.Now.ToSystemDate()).ResultAsync()];
                                        case 1:
                                            html1 = _a.sent();
                                            $$calysto("#partialResult1").SetInnerHtml(Calysto.Utility.Html.HtmlEncode(html1));
                                            return [2 /*return*/];
                                    }
                                });
                            });
                        }
                        Ajax.GetPartialResult = GetPartialResult;
                    })(Ajax = CalystoUI.Ajax || (CalystoUI.Ajax = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Ajax = Calysto.Web.TestSite.Web.CalystoUI.Ajax;
//# sourceMappingURL=Ajax.js.map