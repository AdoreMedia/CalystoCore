using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	public interface IAjaxService
	{
		Task<string> AjaxSend(string msg, CalystoBlob[] files);
		Task<string> AjaxSendThrow();
		Task<BinaryFrameObj> DownloadBinaryFrameObject();
		Task<CalystoBlob> DownloadBlob();
		Task<IEnumerable<CalystoBlob>> DownloadBlobArray();
		Task<CalystoBlob[]> DownloadBlobArrayError();
		Task<CalystoBlob> DownloadBlobError();
		Task<string> InvokeAjaxError();
		Task Javascript1();
		Task<DateTime> SendClientDateTime(DateTime dt);
	}
}