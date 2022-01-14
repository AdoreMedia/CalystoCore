/// <reference path="../../../../calysto.web/weblib/WebLib.d.ts" />
declare namespace HostProxy.XmlHttpInterceptor {
    interface IXhrResponse {
        locationHref: string;
        responseURL: string;
        responseText: string;
    }
    class XhrInteceptorManager {
        NotifyResponseReceived(xhr: XMLHttpRequest): void;
        OnResponseReceived: Calysto.MulticastDelegate<(resp: IXhrResponse) => void>;
    }
    function CreateInteceptor(win?: Window): XhrInteceptorManager;
}
