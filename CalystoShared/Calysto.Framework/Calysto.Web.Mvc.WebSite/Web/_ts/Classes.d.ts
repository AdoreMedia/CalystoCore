declare namespace Calysto.Genesis.WebSite.Controllers
{
	interface SomeMethods
	{
	}

	namespace SomeMethods
	{
		export function GetAgeString(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetAgeString2(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetHtmlString(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
	}

}

declare namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	interface AjaxService
	{
	}

	namespace AjaxService
	{
		export function AjaxSend(msg: string, files: Blob[]): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function AjaxSendThrow(): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function InvokeAjaxError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function DownloadBlob(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob>;
		export function DownloadBlobArray(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob[]>;
		export function SendClientDateTime(dt: Date): Calysto.Net.WebService.AjaxServiceClientWithReturn<Date>;
		export function DownloadBinaryFrameObject(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Calysto.Web.TestSite.Web.CalystoUI.Ajax.BinaryFrameObj>;
		export function DownloadBlobArrayError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob[]>;
		export function DownloadBlobError(): Calysto.Net.WebService.AjaxServiceClientWithReturn<Blob>;
		export function Javascript1(): Calysto.Net.WebService.AjaxServiceClientVoid;
	}

	interface BinaryFrameObj
	{
		Count: number;
		List: Blob[];
		Name: string;
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

declare namespace Calysto.Web.TestSite.Web.VS.Home
{
	interface HomeController extends Microsoft.AspNetCore.Mvc.Controller
	{
	}

	namespace HomeController
	{
		export function CheckLoginModel(model: Calysto.Web.TestSite.Web.VS.Home.Models.LoginViewModel): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetAgeString1(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetAgeString2(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetHtmlString1(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetHtmlString2(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
		export function GetHtmlString3(age: number): Calysto.Net.WebService.AjaxServiceClientWithReturn<string>;
	}

}

declare namespace Calysto.Web.TestSite.Web.VS.Home.Models
{
	interface IFormFile
	{
	}

	interface LoginViewModel
	{
		BirthDate: Date;
		File: Calysto.Web.TestSite.Web.VS.Home.Models.IFormFile;
		Password: string;
		Username: string;
	}

}