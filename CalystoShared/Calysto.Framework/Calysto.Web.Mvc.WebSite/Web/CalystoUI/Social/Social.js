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
                    var Social;
                    (function (Social) {
                        var Unittests;
                        (function (Unittests) {
                            function RunTests() {
                                Calysto.TestTools.TestRunner.RunTests();
                            }
                            Unittests.RunTests = RunTests;
                        })(Unittests = Social.Unittests || (Social.Unittests = {}));
                    })(Social = CalystoUI.Social || (CalystoUI.Social = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Unittests = Calysto.Web.TestSite.Web.CalystoUI.Social.Unittests;
(function (Calysto) {
    var Web;
    (function (Web_2) {
        var TestSite;
        (function (TestSite) {
            var Web;
            (function (Web) {
                var CalystoUI;
                (function (CalystoUI) {
                    var Social;
                    (function (Social) {
                        var Facebook;
                        (function (Facebook) {
                            var _facebookAppId = "763422044109553"; // BlueStack
                            function InitApp() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var tokenSource, fb, _a, _b;
                                    return __generator(this, function (_c) {
                                        switch (_c.label) {
                                            case 0:
                                                tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
                                                fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
                                                //console.log(await fb.InitEngine());
                                                _b = (_a = console).log;
                                                return [4 /*yield*/, fb.InitApp(tokenSource.Token)];
                                            case 1:
                                                //console.log(await fb.InitEngine());
                                                _b.apply(_a, [_c.sent()]);
                                                console.log(fb);
                                                return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Facebook.InitApp = InitApp;
                            function Logout() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        alert("not implemented");
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Facebook.Logout = Logout;
                            function Login() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var tokenSource, fb, _a, _b, _c, _d, _e, _f, _g, _h;
                                    return __generator(this, function (_j) {
                                        switch (_j.label) {
                                            case 0:
                                                tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
                                                fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
                                                _b = (_a = console).log;
                                                return [4 /*yield*/, fb.Login()];
                                            case 1:
                                                _b.apply(_a, [_j.sent()]);
                                                _d = (_c = console).log;
                                                return [4 /*yield*/, fb.LoadPermissions(tokenSource.Token)];
                                            case 2:
                                                _d.apply(_c, [_j.sent()]);
                                                _f = (_e = console).log;
                                                return [4 /*yield*/, fb.LoadPicture(tokenSource.Token)];
                                            case 3:
                                                _f.apply(_e, [_j.sent()]);
                                                _h = (_g = console).log;
                                                return [4 /*yield*/, fb.LoadProfile(tokenSource.Token)];
                                            case 4:
                                                _h.apply(_g, [_j.sent()]);
                                                console.log(fb);
                                                return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Facebook.Login = Login;
                            function Status() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var tokenSource, fb, _a, _b, _c, _d, _e, _f;
                                    return __generator(this, function (_g) {
                                        switch (_g.label) {
                                            case 0:
                                                tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
                                                fb = Calysto.Page.Social.Facebook.FacebookProvider.GetProvider(_facebookAppId);
                                                //console.log(await fb.InitEngine());
                                                //console.log(await fb.InitApp());
                                                _b = (_a = console).log;
                                                return [4 /*yield*/, fb.GetLoginStatus(tokenSource.Token)];
                                            case 1:
                                                //console.log(await fb.InitEngine());
                                                //console.log(await fb.InitApp());
                                                _b.apply(_a, [_g.sent()]);
                                                console.log(fb);
                                                _d = (_c = console).log;
                                                return [4 /*yield*/, fb.IsFbAuthenticated()];
                                            case 2:
                                                _d.apply(_c, [_g.sent()]);
                                                _f = (_e = console).log;
                                                return [4 /*yield*/, fb.IsAuthenticated()];
                                            case 3:
                                                _f.apply(_e, [_g.sent()]);
                                                return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Facebook.Status = Status;
                        })(Facebook = Social.Facebook || (Social.Facebook = {}));
                    })(Social = CalystoUI.Social || (CalystoUI.Social = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_2.TestSite || (Web_2.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Facebook = Calysto.Web.TestSite.Web.CalystoUI.Social.Facebook;
(function (Calysto) {
    var Web;
    (function (Web_3) {
        var TestSite;
        (function (TestSite) {
            var Web;
            (function (Web) {
                var CalystoUI;
                (function (CalystoUI) {
                    var Social;
                    (function (Social) {
                        var Google;
                        (function (Google) {
                            var _googleApiKey = "AIzaSyCRzDlVMG8_EHhIjwyqDApaLWKMBjRGrRM";
                            var _googleClientId = "658661145263-qah8cdjjb5idbo2ovt90msr3nsr4kvh1.apps.googleusercontent.com";
                            function InitApp() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var tokenSource, gg, _a, _b;
                                    return __generator(this, function (_c) {
                                        switch (_c.label) {
                                            case 0:
                                                tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
                                                gg = Calysto.Page.Social.Google.GoogleProvider.GetProvider(_googleApiKey, _googleClientId);
                                                //console.log(await gg.InitEngine());
                                                _b = (_a = console).log;
                                                return [4 /*yield*/, gg.InitApp(tokenSource.Token)];
                                            case 1:
                                                //console.log(await gg.InitEngine());
                                                _b.apply(_a, [_c.sent()]);
                                                console.log(gg);
                                                return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Google.InitApp = InitApp;
                            function Login() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var tokenSource, gg, _a, _b, e_1;
                                    return __generator(this, function (_c) {
                                        switch (_c.label) {
                                            case 0:
                                                _c.trys.push([0, 2, , 3]);
                                                tokenSource = new Calysto.Tasks.CancellationTokenSource(10000);
                                                gg = Calysto.Page.Social.Google.GoogleProvider.GetProvider(_googleApiKey, _googleClientId);
                                                //console.log(await gg.Login());
                                                _b = (_a = console).log;
                                                return [4 /*yield*/, gg.LoadProfile(tokenSource.Token)];
                                            case 1:
                                                //console.log(await gg.Login());
                                                _b.apply(_a, [_c.sent()]);
                                                console.log(gg);
                                                //tokenSource.Register(() => alert("token timeout"));
                                                tokenSource.CancelAfter();
                                                return [3 /*break*/, 3];
                                            case 2:
                                                e_1 = _c.sent();
                                                alert(e_1);
                                                return [3 /*break*/, 3];
                                            case 3: return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Google.Login = Login;
                        })(Google = Social.Google || (Social.Google = {}));
                    })(Social = CalystoUI.Social || (CalystoUI.Social = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_3.TestSite || (Web_3.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Google = Calysto.Web.TestSite.Web.CalystoUI.Social.Google;
(function (Calysto) {
    var Web;
    (function (Web_4) {
        var TestSite;
        (function (TestSite) {
            var Web;
            (function (Web) {
                var CalystoUI;
                (function (CalystoUI) {
                    var Social;
                    (function (Social) {
                        var Other;
                        (function (Other) {
                            //window.onunhandledrejection = function (ev)
                            //{
                            //	console.log(ev);
                            //	console.log(ev.reason);
                            //};
                            //Calysto.Event.Attach(<any>window, "unhandledrejection", function (ev)
                            //{
                            //	console.log(ev.type);
                            //	console.log(ev);
                            //});
                            Calysto.Page.OnUnhandledException(function (err) {
                                alert("unhandled: " + err);
                            });
                            function Test1() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var m1;
                                    return __generator(this, function (_a) {
                                        switch (_a.label) {
                                            case 0:
                                                m1 = 0;
                                                _a.label = 1;
                                            case 1:
                                                if (!(m1++ < 10)) return [3 /*break*/, 3];
                                                console.log(m1);
                                                return [4 /*yield*/, Calysto.Tasks.TaskUtility.SleepAsync(500)];
                                            case 2:
                                                _a.sent();
                                                return [3 /*break*/, 1];
                                            case 3: return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Other.Test1 = Test1;
                            function Test2() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var t1, t2;
                                    return __generator(this, function (_a) {
                                        t1 = new Calysto.DateTime().Ticks;
                                        t2 = Calysto.TimeSpan.FromTicks(t1);
                                        try {
                                            console.log("#1");
                                            throw "err1";
                                        }
                                        catch (ex1) {
                                            console.log(ex1);
                                            throw "err2";
                                        }
                                        finally {
                                            console.log("#2");
                                        }
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test2 = Test2;
                            function Test3() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var res4, res1, token1, res2;
                                    var _this = this;
                                    return __generator(this, function (_a) {
                                        switch (_a.label) {
                                            case 0:
                                                console.log("#1");
                                                return [4 /*yield*/, Calysto.Core.UseDispose(new Calysto.Tasks.CancellationTokenSource(3000), function (token) {
                                                        Calysto.Tasks.TaskUtility.SleepAsync(1000).TimeoutAsync(100);
                                                    })];
                                            case 1:
                                                res4 = _a.sent();
                                                return [4 /*yield*/, Calysto.Core.UseDispose(new Calysto.Tasks.CancellationTokenSource(3000), function (token) { return __awaiter(_this, void 0, void 0, function () {
                                                        var _this = this;
                                                        return __generator(this, function (_a) {
                                                            switch (_a.label) {
                                                                case 0: return [4 /*yield*/, Calysto.Tasks.TaskUtility.RunAsync(function () { return __awaiter(_this, void 0, void 0, function () {
                                                                        return __generator(this, function (_a) {
                                                                            switch (_a.label) {
                                                                                case 0: return [4 /*yield*/, Calysto.Tasks.TaskUtility.SleepAsync(1000)];
                                                                                case 1:
                                                                                    _a.sent();
                                                                                    return [2 /*return*/, 22];
                                                                            }
                                                                        });
                                                                    }); }, token)];
                                                                case 1: return [2 /*return*/, _a.sent()];
                                                            }
                                                        });
                                                    }); })];
                                            case 2:
                                                res1 = _a.sent();
                                                console.log(res1);
                                                token1 = new Calysto.Tasks.CancellationTokenSource(3000);
                                                _a.label = 3;
                                            case 3:
                                                _a.trys.push([3, , 5, 6]);
                                                return [4 /*yield*/, Calysto.Tasks.TaskUtility.RunAsync(function () { return __awaiter(_this, void 0, void 0, function () {
                                                        return __generator(this, function (_a) {
                                                            switch (_a.label) {
                                                                case 0: return [4 /*yield*/, Calysto.Tasks.TaskUtility.SleepAsync(1000)];
                                                                case 1:
                                                                    _a.sent();
                                                                    return [2 /*return*/, 33];
                                                            }
                                                        });
                                                    }); }, token1)];
                                            case 4:
                                                res2 = _a.sent();
                                                console.log(res2);
                                                return [3 /*break*/, 6];
                                            case 5:
                                                token1.Dispose();
                                                return [7 /*endfinally*/];
                                            case 6:
                                                console.log("#2");
                                                return [2 /*return*/];
                                        }
                                    });
                                });
                            }
                            Other.Test3 = Test3;
                            var monitor1 = new Calysto.Tasks.CalystoMonitor();
                            function Test4() {
                                return __awaiter(this, void 0, void 0, function () {
                                    var cnt;
                                    var _this = this;
                                    return __generator(this, function (_a) {
                                        console.log("#start");
                                        cnt = 0;
                                        setTimeout(function () { return __awaiter(_this, void 0, void 0, function () {
                                            var _a, _b;
                                            return __generator(this, function (_c) {
                                                switch (_c.label) {
                                                    case 0:
                                                        if (!(cnt++ < 10)) return [3 /*break*/, 2];
                                                        console.log("#before: " + cnt);
                                                        _b = (_a = console).log;
                                                        return [4 /*yield*/, monitor1.WaitAsync(3000)];
                                                    case 1:
                                                        _b.apply(_a, [_c.sent()]);
                                                        console.log("#after: " + cnt);
                                                        return [3 /*break*/, 0];
                                                    case 2: return [2 /*return*/];
                                                }
                                            });
                                        }); });
                                        console.log("#end");
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test4 = Test4;
                            function Test5() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        monitor1.Pulse("single");
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test5 = Test5;
                            function Test6() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        monitor1.PulseAll("all");
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test6 = Test6;
                            function Test7() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        // ne reloadirati cesce od 30 sekundi
                                        // setiramo _cRelExpires, potom provjerimo da li je setiran i onda moze reload, u protivnom ne
                                        if (!(parseInt(sessionStorage["_cRelExpires"]) > Date.now())) {
                                            sessionStorage["_cRelExpires"] = Date.now() + 30000;
                                            if (parseInt(sessionStorage["_cRelExpires"]) > Date.now()) {
                                                location.reload(true);
                                            }
                                        }
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test7 = Test7;
                            function Test8() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test8 = Test8;
                            function Test9() {
                                return __awaiter(this, void 0, void 0, function () {
                                    return __generator(this, function (_a) {
                                        return [2 /*return*/];
                                    });
                                });
                            }
                            Other.Test9 = Test9;
                        })(Other = Social.Other || (Social.Other = {}));
                    })(Social = CalystoUI.Social || (CalystoUI.Social = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_4.TestSite || (Web_4.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Other = Calysto.Web.TestSite.Web.CalystoUI.Social.Other;
//# sourceMappingURL=Social.js.map