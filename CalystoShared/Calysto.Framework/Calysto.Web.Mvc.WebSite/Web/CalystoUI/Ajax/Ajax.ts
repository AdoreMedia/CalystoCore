namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	function GetAjaxInputText()
	{
		return $$calysto<HTMLInputElement>("#ajaxInput").Select(o => o.value).First();
	}

	function GetAjaxInputFiles()
	{
		return <Blob[]><any>$$calysto<HTMLInputElement>("#ajaxFiles").Select(o => o.files).First();
	}

	export async function AjaxSend(sender)
	{
		let a1 = await AjaxService.AjaxSend(GetAjaxInputText(), GetAjaxInputFiles())
			.OnProgress(e => console.log((e.IsUpload ? "upload" : "download") + ": " + e.Percent + " % of " + e.Total + " bytes"))
			.OnSuccess(resp => console.log(resp));
	}

	Calysto.Page.OnUnhandledException(e => alert(e));
	
	export async function AjaxSendThrow(sender)
	{
		await AjaxService.AjaxSendThrow().ResultAsync();
	}

	export function AjaxSendDelayed(sender)
	{
		let a1 = AjaxService.AjaxSend(GetAjaxInputText(), GetAjaxInputFiles())
			.OnProgress(e => console.log((e.IsUpload ? "upload" : "download") + ": " + e.Percent + " % of " + e.Total + " bytes"))
			.OnSuccess(resp => console.log(resp));

		setTimeout(() => { a1.OnSuccess(resp => alert("delayed: " + resp)) }, 1000);
	}

	export function InvokeAjaxError(sender)
	{
		AjaxService.InvokeAjaxError();
	}

	export function DownloadBlob(sender)
	{
		AjaxService.DownloadBlob()
			.OnSuccess(blob => blob.SaveFileAs());
	}

	export function DownloadBlobError(sender)
	{
		AjaxService.DownloadBlobError()
			.OnSuccess(blob => blob.SaveFileAs());
	}

	export function DownloadBlobArray(sender)
	{
		AjaxService.DownloadBlobArray()
			.OnSuccess(array => array.ForEach(m => m.SaveFileAs()));
	}

	export function DownloadBlobArrayError(sender)
	{
		AjaxService.DownloadBlobArrayError()
			.OnSuccess(array => array.ForEach(m => m.SaveFileAs()));
	}

	export function DownloadBinaryFrameObject(sender)
	{
		AjaxService.DownloadBinaryFrameObject()
			.OnSuccess(resp =>
			{
				resp.List.AsEnumerable().ForEach(o=>o.SaveFileAs());
				console.log(resp);
			});
	}

	export function SendClientDateTime(sender)
	{
		AjaxService.SendClientDateTime(new Date())
			.OnSuccess(resp =>
			{
				console.log(resp.ToStringFormated());
			});
	}

	export async function SendResultAsync(sender)
	{
		let res1 = await AjaxService.SendClientDateTime(new Date()).ResultAsync();
		Calysto.Dialog.CreateAlert(res1.ToStringFormated(), "success").Show();
	}

	export async function AjaxVoidAsync(sender)
	{
		await AjaxService.Javascript1();
	}

}

const Ajax = Calysto.Web.TestSite.Web.CalystoUI.Ajax;
