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
                    var Sockets;
                    (function (Sockets) {
                        function GetSocketInputText() {
                            return $$calysto("#socketInput").Select(function (o) { return o.value; }).First();
                        }
                        function GetSocketInputFiles() {
                            return $$calysto("#socketFiles").Select(function (o) { return o.files; }).First();
                        }
                        var hh = new Sockets.SocketSession();
                        hh.Socket.OnClose(function () { return console.log("socket OnClose"); });
                        hh.Socket.OnMessage(function (rawObj) { return console.log({ OnMessage: rawObj }); });
                        hh.Socket.OnError(function (msg) { return console.log("OnError: " + msg); });
                        hh.OnBroadcastMessage(function (obj) {
                            console.log({ OnBroadcastMessage: obj });
                        });
                        function SocketOpen(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0: return [4 /*yield*/, hh.Socket.OpenAsync()];
                                        case 1:
                                            _a.sent();
                                            console.log("opened: " + hh.Socket.IsOpened());
                                            return [2 /*return*/];
                                    }
                                });
                            });
                        }
                        Sockets.SocketOpen = SocketOpen;
                        function SocketClose(sender) {
                            hh.Socket.Close();
                        }
                        Sockets.SocketClose = SocketClose;
                        function SendSocket(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                return __generator(this, function (_a) {
                                    hh.HelloWorld(GetSocketInputText(), GetSocketInputFiles())
                                        .OnSuccess(function (resp) { return console.log({ HelloWorldResponse: resp }); });
                                    return [2 /*return*/];
                                });
                            });
                        }
                        Sockets.SendSocket = SendSocket;
                        function SendSocketDelayed(sender) {
                            var a1 = hh.HelloWorld(GetSocketInputText(), GetSocketInputFiles())
                                .OnSuccess(function (resp) { return console.log({ HelloWorldResponse: resp }); });
                            setTimeout(function () { a1.OnSuccess(function (resp) { return alert("delayed: " + resp); }); }, 1000);
                        }
                        Sockets.SendSocketDelayed = SendSocketDelayed;
                        function SocketErrorTest(sender, error) {
                            hh.SocketErrorTest(GetSocketInputText(), "last name", 22, GetSocketInputFiles())
                                .OnSuccess(function () { return console.log("SocketErrorTest success"); })
                                .OnError(function (err) { return console.log("SocketErrorTest error: " + err); })
                                .OnResponse(function (cc) { return console.log(cc); });
                        }
                        Sockets.SocketErrorTest = SocketErrorTest;
                        function SocketHelloWorld(sender) {
                            hh.SetHelloString(GetSocketInputText())
                                .OnSuccess(function (resp) { return console.log("SocketHelloWorld response: " + resp); });
                        }
                        Sockets.SocketHelloWorld = SocketHelloWorld;
                        function SocketSendToAll(sender) {
                            hh.SocketSendToAll(GetSocketInputText())
                                .OnSuccess(function () { return console.log("SocketSendToAll response"); });
                        }
                        Sockets.SocketSendToAll = SocketSendToAll;
                        function SocketSendResultAsync(sender) {
                            return __awaiter(this, void 0, void 0, function () {
                                var res1;
                                return __generator(this, function (_a) {
                                    switch (_a.label) {
                                        case 0: return [4 /*yield*/, hh.SetHelloString(GetSocketInputText()).ResultAsync()];
                                        case 1:
                                            res1 = _a.sent();
                                            console.log("async response: " + res1);
                                            return [2 /*return*/];
                                    }
                                });
                            });
                        }
                        Sockets.SocketSendResultAsync = SocketSendResultAsync;
                    })(Sockets = CalystoUI.Sockets || (CalystoUI.Sockets = {}));
                })(CalystoUI = Web.CalystoUI || (Web.CalystoUI = {}));
            })(Web = TestSite.Web || (TestSite.Web = {}));
        })(TestSite = Web_1.TestSite || (Web_1.TestSite = {}));
    })(Web = Calysto.Web || (Calysto.Web = {}));
})(Calysto || (Calysto = {}));
var Sockets = Calysto.Web.TestSite.Web.CalystoUI.Sockets;
//# sourceMappingURL=Sockets.js.map