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
//DotNet.attachReviver(function (key, value)
//{
//	console.log({ key, value });
//});
var Calysto;
(function (Calysto) {
    globalThis.Calysto = Calysto;
    //export function Test1(a, b, c)
    //{
    //	console.log({ a, b, c });
    //}
})(Calysto || (Calysto = {}));
(function (Calysto) {
    var Blazor;
    (function (Blazor) {
        var Interop;
        (function (Interop) {
            function SleepAsync(sleepMs) {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        return [2 /*return*/, new Promise(function (success, reject) {
                                setTimeout(function () { return success(); }, sleepMs);
                            })];
                    });
                });
            }
            Interop.SleepAsync = SleepAsync;
            function ExecuteScriptAsync(js) {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, (new Function(js))()];
                            case 1: return [2 /*return*/, _a.sent()];
                        }
                    });
                });
            }
            Interop.ExecuteScriptAsync = ExecuteScriptAsync;
            function SystemAlertAsync(txt) {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, alert(txt)];
                            case 1: return [2 /*return*/, _a.sent()];
                        }
                    });
                });
            }
            Interop.SystemAlertAsync = SystemAlertAsync;
            function SystemConfirmAsync(txt) {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, confirm(txt)];
                            case 1: return [2 /*return*/, _a.sent()];
                        }
                    });
                });
            }
            Interop.SystemConfirmAsync = SystemConfirmAsync;
            function SystemPromptAsync(txt) {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, prompt(txt)];
                            case 1: return [2 /*return*/, _a.sent()];
                        }
                    });
                });
            }
            Interop.SystemPromptAsync = SystemPromptAsync;
            function CreateEl(el) {
                return {
                    tagName: el.tagName,
                    id: el.id,
                    style: el.style.cssText,
                    className: el.className,
                    offsetWidth: el.offsetWidth,
                    offsetHeight: el.offsetHeight,
                    name: el.name || el.getAttribute("name"),
                    value: el.value || el.getAttribute("value"),
                    type: el.type || el.getAttribute("type")
                };
            }
            function GetElementByReference(elementReference) {
                return CreateEl(elementReference);
            }
            Interop.GetElementByReference = GetElementByReference;
            function GetElementById(id) {
                var el = document.getElementById(id);
                if (!el)
                    return null;
                else
                    return CreateEl(el);
            }
            Interop.GetElementById = GetElementById;
            function SelectElements(source, skip, take) {
                var e_1, _a;
                skip = skip || 0;
                take = take || Number.MAX_SAFE_INTEGER;
                var arr2 = [];
                var index = -1;
                try {
                    for (var _b = __values(source), _c = _b.next(); !_c.done; _c = _b.next()) {
                        var el2 = _c.value;
                        if (++index >= skip && index < skip + take) {
                            arr2.push(CreateEl(el2));
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                return arr2;
            }
            function GetElementsByTagName(tagName, skip, take) {
                return SelectElements(document.getElementsByTagName(tagName), skip, take);
            }
            Interop.GetElementsByTagName = GetElementsByTagName;
            function GetElementsByClassName(className, skip, take) {
                return SelectElements(document.getElementsByClassName(className), skip, take);
            }
            Interop.GetElementsByClassName = GetElementsByClassName;
            function GetElementsByName(className, skip, take) {
                return SelectElements(document.getElementsByName(className), skip, take);
            }
            Interop.GetElementsByName = GetElementsByName;
            //#endregion
            //#region element manipulation
            function SplitPath(propertyPath) {
                var e_2, _a;
                if (!propertyPath)
                    return [];
                //"one[0].two.three".split(new RegExp("\\.|\\[|\\]"))
                var parts = propertyPath.split(new RegExp("\\.|\\[|\\]"));
                var arr1 = [];
                try {
                    for (var parts_1 = __values(parts), parts_1_1 = parts_1.next(); !parts_1_1.done; parts_1_1 = parts_1.next()) {
                        var p1 = parts_1_1.value;
                        if (p1)
                            arr1.push(p1);
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (parts_1_1 && !parts_1_1.done && (_a = parts_1.return)) _a.call(parts_1);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
                return arr1;
            }
            function IsNumber(value) {
                return new RegExp("^[\\d]+$").test(value);
            }
            function SetPropertyValue2(obj, propertyPath, value) {
                var parts = SplitPath(propertyPath);
                var tmp = obj;
                var p1;
                for (var n1 = 0; n1 < parts.length - 1; n1++) {
                    p1 = parts[n1];
                    if (IsNumber(p1))
                        p1 = parseInt(p1);
                    if (typeof tmp[p1] == undefined) {
                        tmp[p1] = {};
                    }
                    tmp = tmp[p1];
                }
                tmp[parts[parts.length - 1]] = value;
            }
            function GetPropertyValue2(obj, propertyPath) {
                var e_3, _a;
                var parts = SplitPath(propertyPath);
                var tmp = obj;
                try {
                    for (var parts_2 = __values(parts), parts_2_1 = parts_2.next(); !parts_2_1.done; parts_2_1 = parts_2.next()) {
                        var p1 = parts_2_1.value;
                        if (IsNumber(p1))
                            p1 = parseInt(p1);
                        if (typeof tmp[p1] == undefined) {
                            return undefined;
                        }
                        tmp = tmp[p1];
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (parts_2_1 && !parts_2_1.done && (_a = parts_2.return)) _a.call(parts_2);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                return tmp;
            }
            function SetPropertyValue(el, propertyPath, value) {
                SetPropertyValue2(el, propertyPath, value);
            }
            Interop.SetPropertyValue = SetPropertyValue;
            function GetPropertyValue(el, propertyPath) {
                return GetPropertyValue2(el, propertyPath);
            }
            Interop.GetPropertyValue = GetPropertyValue;
            function GetPropertyReference(el, propertyPath) {
                return DotNet.createJSObjectReference(GetPropertyValue(el, propertyPath));
            }
            Interop.GetPropertyReference = GetPropertyReference;
            //#endregion
            //#region invoke element / object function
            function HasObjectProperty(el, propertyPath) {
                var val1 = GetPropertyValue(window, propertyPath);
                return (val1 && !!val1.apply && !!val1.call)
                    || !(val1 === undefined || val1 === null || isNaN(val1));
            }
            Interop.HasObjectProperty = HasObjectProperty;
            function HasObjectFunction(el, propertyPath) {
                var val1 = GetPropertyValue(window, propertyPath);
                // is function
                return (val1 && !!val1.apply && !!val1.call);
            }
            Interop.HasObjectFunction = HasObjectFunction;
            function InvokeObjectFunction(el, propertyPath, args) {
                var partsArr = SplitPath(propertyPath);
                partsArr.pop();
                var obj = GetPropertyValue(el, partsArr.join("."));
                var fn = GetPropertyValue(el, propertyPath);
                return fn.apply(obj, args);
            }
            Interop.InvokeObjectFunction = InvokeObjectFunction;
            function InvokeObjectFunctionVoid(el, propertyPath, args) {
                InvokeObjectFunction(el, propertyPath, args);
            }
            Interop.InvokeObjectFunctionVoid = InvokeObjectFunctionVoid;
            //#endregion
            //# window properties
            function HasWindowProperty(propertyPath) {
                return HasObjectProperty(window, propertyPath);
            }
            Interop.HasWindowProperty = HasWindowProperty;
            function HasWindowFunction(propertyPath) {
                return HasObjectFunction(window, propertyPath);
            }
            Interop.HasWindowFunction = HasWindowFunction;
            function GetWindowPropertyValue(propertyPath) {
                return GetPropertyValue(window, propertyPath);
            }
            Interop.GetWindowPropertyValue = GetWindowPropertyValue;
            function GetWindowPropertyReference(propertyPath) {
                return GetPropertyReference(window, propertyPath);
            }
            Interop.GetWindowPropertyReference = GetWindowPropertyReference;
            //#endregion
            //#region invoke window function
            function InvokeWindowFunction(propertyPath, args) {
                return InvokeObjectFunction(window, propertyPath, args);
            }
            Interop.InvokeWindowFunction = InvokeWindowFunction;
            function InvokeWindowFunctionVoid(propertyPath, args) {
                InvokeObjectFunctionVoid(window, propertyPath, args);
            }
            Interop.InvokeWindowFunctionVoid = InvokeWindowFunctionVoid;
            //#endregion
            //#region element attributes
            function SetAttributeValue(el, attrName, value) {
                el.setAttribute(attrName, value);
            }
            Interop.SetAttributeValue = SetAttributeValue;
            function GetAttributeValue(el, attrName) {
                return el.getAttribute(attrName);
            }
            Interop.GetAttributeValue = GetAttributeValue;
            function CreateEventArgument(argType, ev) {
                switch (argType) {
                    case "MouseEventArgs":
                        return {
                            Detail: ev.detail,
                            ScreenX: ev.screenX,
                            ScreenY: ev.screenY,
                            ClientX: ev.clientX,
                            ClientY: ev.clientY,
                            OffsetX: ev.offsetX,
                            OffsetY: ev.offsetY,
                            Button: ev.button,
                            Buttons: ev.buttons,
                            CtrlKey: ev.ctrlKey,
                            ShiftKey: ev.shiftKey,
                            AltKey: ev.altKey,
                            MetaKey: ev.metaKey,
                            Type: ev.type
                        };
                        break;
                    case "KeyboardEventArgs":
                        return {
                            Key: ev.key,
                            Code: ev.code,
                            Location: ev.location,
                            Repeat: ev.repeat,
                            CtrlKey: ev.ctrlKey,
                            ShiftKey: ev.shiftKey,
                            AltKey: ev.altKey,
                            MetaKey: ev.metaKey,
                            Type: ev.type
                        };
                        break;
                    default:
                        throw "Unsupported event argument type: " + argType;
                }
            }
            /**
             * Wait for one time event.
             * @param eventName
             * @param targetElementId
             * @param argType
             */
            function WaitForDomEventAsync(eventName, targetElementId, argType) {
                return new Promise(function (resolve, reject) {
                    var el = document;
                    if (targetElementId) {
                        el = document.getElementById(targetElementId);
                    }
                    var callback = function (ev) {
                        el.removeEventListener(eventName, callback);
                        resolve(CreateEventArgument(argType, ev));
                    };
                    el.addEventListener(eventName, callback);
                });
            }
            Interop.WaitForDomEventAsync = WaitForDomEventAsync;
            function AddEventListener(el, eventName, callback, argType) {
                var _this = this;
                var fnCallback = function (ev) { return __awaiter(_this, void 0, void 0, function () {
                    var arg1, res1;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0:
                                arg1 = CreateEventArgument(argType, ev);
                                console.log({ type: ev.type, arg: arg1 });
                                return [4 /*yield*/, callback.invokeMethodAsync("Callback", arg1)];
                            case 1:
                                res1 = _a.sent();
                                console.log("JS result: " + res1);
                                return [2 /*return*/, res1];
                        }
                    });
                }); };
                console.log(eventName);
                el.addEventListener(eventName, fnCallback);
                var state2 = {};
                var ref1 = DotNet.createJSObjectReference(state2);
                state2.fnRemove = function () {
                    console.log("fnRemove invoked");
                    el.removeEventListener(eventName, fnCallback);
                    DotNet.disposeJSObjectReference(ref1);
                };
                return ref1;
            }
            Interop.AddEventListener = AddEventListener;
            function RemoveEventListener(obj) {
                obj.fnRemove();
            }
            Interop.RemoveEventListener = RemoveEventListener;
            //#endregion
            //#region client version control
            function RemoveBlazorOfflineCacheAsync() {
                return __awaiter(this, void 0, void 0, function () {
                    var cacheKeys;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, caches.keys()];
                            case 1:
                                cacheKeys = _a.sent();
                                return [4 /*yield*/, Promise.all(cacheKeys
                                        .filter(function (key) { return key.startsWith("offline-cache-") || key.startsWith("blazor-resources-"); })
                                        .map(function (key) { return caches.delete(key); }))];
                            case 2:
                                _a.sent();
                                return [2 /*return*/];
                        }
                    });
                });
            }
            function RemoveBlazorOfflineCacheAndReloadAsync() {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0:
                                console.log("Refresh blazor offline cache");
                                return [4 /*yield*/, RemoveBlazorOfflineCacheAsync()];
                            case 1:
                                _a.sent();
                                location.reload();
                                return [2 /*return*/];
                        }
                    });
                });
            }
            Interop.RemoveBlazorOfflineCacheAndReloadAsync = RemoveBlazorOfflineCacheAndReloadAsync;
            function GetServerVersionFromHtmlAsync() {
                return __awaiter(this, void 0, void 0, function () {
                    var el;
                    return __generator(this, function (_a) {
                        el = document.getElementById("server-version");
                        return [2 /*return*/, (el === null || el === void 0 ? void 0 : el.value) || (el === null || el === void 0 ? void 0 : el.getAttribute("value"))];
                    });
                });
            }
            Interop.GetServerVersionFromHtmlAsync = GetServerVersionFromHtmlAsync;
            function InitialBlazorVersionCheckAsync() {
                return __awaiter(this, void 0, void 0, function () {
                    var expected1, current1;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, GetServerVersionFromHtmlAsync()];
                            case 1:
                                expected1 = _a.sent();
                                if (!expected1)
                                    throw "Missing server-version in html";
                                current1 = localStorage.getItem("blazor-initial");
                                if (!(current1 != expected1)) return [3 /*break*/, 3];
                                localStorage.setItem("blazor-initial", expected1);
                                console.log("Reload blazor-initial");
                                return [4 /*yield*/, RemoveBlazorOfflineCacheAndReloadAsync()];
                            case 2:
                                _a.sent();
                                _a.label = 3;
                            case 3: return [2 /*return*/];
                        }
                    });
                });
            }
            //InitialBlazorVersionCheckAsync();
            //#endregion
            //#region window.location
            function GetLocationAsync() {
                return __awaiter(this, void 0, void 0, function () {
                    return __generator(this, function (_a) {
                        return [2 /*return*/, ({
                                hash: location.hash,
                                host: location.host,
                                hostname: location.hostname,
                                href: location.href,
                                origin: location.origin,
                                pathname: location.pathname,
                                port: location.port,
                                protocol: location.protocol
                            })];
                    });
                });
            }
            Interop.GetLocationAsync = GetLocationAsync;
            //#endregion
        })(Interop = Blazor.Interop || (Blazor.Interop = {}));
    })(Blazor = Calysto.Blazor || (Calysto.Blazor = {}));
})(Calysto || (Calysto = {}));
//# sourceMappingURL=Calysto.Blazor.Interop.js.map