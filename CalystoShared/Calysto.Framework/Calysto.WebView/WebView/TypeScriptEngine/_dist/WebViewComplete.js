var __read = (this && this.__read) || function (o, n) {
    var m = typeof Symbol === "function" && o[Symbol.iterator];
    if (!m) return o;
    var i = m.call(o), r, ar = [], e;
    try {
        while ((n === void 0 || n-- > 0) && !(r = i.next()).done) ar.push(r.value);
    }
    catch (error) { e = { error: error }; }
    finally {
        try {
            if (r && !r.done && (m = i["return"])) m.call(i);
        }
        finally { if (e) throw e.error; }
    }
    return ar;
};
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
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
var HostProxy;
(function (HostProxy) {
    var XmlHttpInterceptor;
    (function (XmlHttpInterceptor) {
        var XMLHttpRequestProxy = /** @class */ (function () {
            function XMLHttpRequestProxy(originalXhr) {
                var _this = this;
                this.OnResponseIntercept = new Calysto.MulticastDelegate();
                this._onReadyStateListeners = [];
                this.DONE = XMLHttpRequest.DONE;
                this.HEADERS_RECEIVED = XMLHttpRequest.HEADERS_RECEIVED;
                this.LOADING = XMLHttpRequest.LOADING;
                this.OPENED = XMLHttpRequest.OPENED;
                this.UNSENT = XMLHttpRequest.UNSENT;
                this._xhr = originalXhr;
                this._xhr.onreadystatechange = function (ev) { return _this._onReadyStateChangeHandler(ev); };
            }
            XMLHttpRequestProxy.prototype.send = function (body) {
                var _a;
                (_a = this._xhr).send.apply(_a, __spreadArray([], __read(arguments), false));
            };
            XMLHttpRequestProxy.prototype.open = function (method, url, async, username, password) {
                //console.log(`XMLHttpRequest open ${method} ${url}`);
                this._xhr.open(method, url, !!async, username, password);
            };
            XMLHttpRequestProxy.prototype._onReadyStateChangeHandler = function (ev) {
                var e_1, _a;
                var _this = this;
                if (this.readyState == 4) {
                    //console.log(`_onReadyStateChangeHandler ${this.responseURL} ${this.responseText}`);
                    this.OnResponseIntercept.Invoke(function (f) { return f(_this._xhr); });
                }
                try {
                    for (var _b = __values(this._onReadyStateListeners), _c = _b.next(); !_c.done; _c = _b.next()) {
                        var fn1 = _c.value;
                        fn1.call(this._xhr, ev);
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
            };
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onreadystatechange", {
                get: function () { return this._onReadyStateChangeHandler; },
                set: function (fn) {
                    if (fn) {
                        this._onReadyStateListeners.push(fn);
                    }
                },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "readyState", {
                get: function () { return this._xhr.readyState; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "response", {
                get: function () { return this._xhr.response; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "responseText", {
                get: function () { return this._xhr.responseText; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "responseType", {
                get: function () { return this._xhr.responseType; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "responseURL", {
                get: function () { return this._xhr.responseURL; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "responseXML", {
                get: function () { return this._xhr.responseXML; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "status", {
                get: function () { return this._xhr.status; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "statusText", {
                get: function () { return this._xhr.statusText; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "timeout", {
                get: function () { return this._xhr.timeout; },
                set: function (valueMs) { this._xhr.timeout = valueMs; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "upload", {
                get: function () { return this._xhr.upload; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "withCredentials", {
                get: function () { return this._xhr.withCredentials; },
                set: function (value) { this._xhr.withCredentials = value; },
                enumerable: false,
                configurable: true
            });
            XMLHttpRequestProxy.prototype.abort = function () { this._xhr.abort(); };
            XMLHttpRequestProxy.prototype.getAllResponseHeaders = function () { return this._xhr.getAllResponseHeaders(); };
            XMLHttpRequestProxy.prototype.getResponseHeader = function (name) { return this._xhr.getResponseHeader(name); };
            XMLHttpRequestProxy.prototype.overrideMimeType = function (mime) { this._xhr.overrideMimeType(mime); };
            XMLHttpRequestProxy.prototype.setRequestHeader = function (name, value) { this._xhr.setRequestHeader(name, value); };
            XMLHttpRequestProxy.prototype.addEventListener = function (type, listener, options) {
                this._xhr.addEventListener(type, listener, options);
            };
            XMLHttpRequestProxy.prototype.removeEventListener = function (type, listener, options) {
                this._xhr.removeEventListener(type, listener, options);
            };
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onabort", {
                get: function () { return this._xhr.onabort; },
                set: function (fn) { this._xhr.onabort = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onerror", {
                get: function () { return this._xhr.onerror; },
                set: function (fn) { this._xhr.onerror = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onload", {
                get: function () { return this._xhr.onload; },
                set: function (fn) { this._xhr.onload = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onloadend", {
                get: function () { return this._xhr.onloadend; },
                set: function (fn) { this._xhr.onloadend = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onloadstart", {
                get: function () { return this._xhr.onloadstart; },
                set: function (fn) { this._xhr.onloadstart = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "onprogress", {
                get: function () { return this._xhr.onprogress; },
                set: function (fn) { this._xhr.onprogress = fn; },
                enumerable: false,
                configurable: true
            });
            Object.defineProperty(XMLHttpRequestProxy.prototype, "ontimeout", {
                get: function () { return this._xhr.ontimeout; },
                set: function (fn) { this._xhr.ontimeout = fn; },
                enumerable: false,
                configurable: true
            });
            return XMLHttpRequestProxy;
        }());
        var XhrInteceptorManager = /** @class */ (function () {
            function XhrInteceptorManager() {
                this.OnResponseReceived = new Calysto.MulticastDelegate();
            }
            XhrInteceptorManager.prototype.NotifyResponseReceived = function (xhr) {
                var item = {
                    locationHref: location.href,
                    responseURL: xhr.responseURL,
                    responseText: xhr.responseText,
                    xhr: xhr
                };
                this.OnResponseReceived.Invoke(function (f) { return f(item); });
            };
            return XhrInteceptorManager;
        }());
        XmlHttpInterceptor.XhrInteceptorManager = XhrInteceptorManager;
        function CreateInteceptor(win) {
            win = win || window;
            var xhrOriginal = win["XMLHttpRequest"];
            var manager = new XhrInteceptorManager();
            win["XMLHttpRequest"] = (function () {
                var pp = new XMLHttpRequestProxy(new xhrOriginal());
                pp.OnResponseIntercept.Add(function (xhr) {
                    manager.NotifyResponseReceived(xhr);
                });
                return pp;
            });
            return manager;
        }
        XmlHttpInterceptor.CreateInteceptor = CreateInteceptor;
    })(XmlHttpInterceptor = HostProxy.XmlHttpInterceptor || (HostProxy.XmlHttpInterceptor = {}));
})(HostProxy || (HostProxy = {}));
/// <reference path="../../../calysto.web/weblib/WebLib.d.ts" />
/// <reference path="interceptor.xmlhttprequestproxy.ts" />
//# sourceMappingURL=WebViewComplete.js.map