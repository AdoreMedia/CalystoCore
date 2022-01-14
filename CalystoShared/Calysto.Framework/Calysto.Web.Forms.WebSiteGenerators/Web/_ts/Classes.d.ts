declare namespace Calysto.Web.Forms.WebSite.CalystoWebControlsTests
{
	interface Default extends System.Web.UI.Page
	{
	}

	namespace Default
	{
		export function HelloWorld(name: string): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
	}

}

declare namespace Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax
{
	interface CalystoAjax extends System.Web.UI.Page
	{
	}

	namespace CalystoAjax
	{
		export function AjaxSend(msg: string, files: Blob[]): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function InvokeAjaxError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function DownloadBlob(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob>;
		export function DownloadBlobArray(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob[]>;
		export function SendClientDateTime(dt: Date): Calysto.Net.WebService.AjaxServiceClientWithReturn<Date>;
		export function DownloadBinaryFrameObject(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax.CalystoAjax.BinaryFrameObj>;
		export function DownloadBlobArrayError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob[]>;
		export function DownloadBlobError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob>;
		export function GetPartialResult(date1: Date): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
	}

}

declare namespace Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax.CalystoAjax
{
	interface BinaryFrameObj
	{
		Count: number;
		List: Blob[];
		Name: string;
	}

}

declare namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	interface AjaxService
	{
	}

}

declare namespace Calysto.Web.TestSite.Web.CalystoUI.Sockets
{
	interface SocketResponse1
	{
		FilesReceived: Blob[];
		Poruka: string;
	}

	class SocketSession extends Calysto.Net.WebService.WebSocketSession<string>
	{
		public constructor();
		public HelloWorld(text: string, blob: Blob[]): Calysto.Net.WebService.AjaxServiceClientWithReturn<Calysto.Web.TestSite.Web.CalystoUI.Sockets.SocketResponse1>;
		public SocketErrorTest(name: string, prezime: string, age: number, blob: Blob[]): Calysto.Net.WebService.AjaxServiceClientVoid;
		public SetHelloString(text: string): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		public SocketSendToAll(text: string): Calysto.Net.WebService.AjaxServiceClientVoid;
	}

}