/// <reference path="infrastructure/webajaxservicehelper.ts" />
/// <reference path="infrastructure/websocketsessionhelper.ts" />


namespace Calysto.Net.WebService
{
	export function CreateAjax(namespace: string, url: string)
	{
		return new WebAjaxServiceHelper(namespace, url);
	}

	export function CreateSocket(namespace: string, url: string)
	{
		return new WebSocketSessionHelper(namespace, url);
	}
}

