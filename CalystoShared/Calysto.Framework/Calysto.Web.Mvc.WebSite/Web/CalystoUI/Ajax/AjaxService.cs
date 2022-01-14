using Calysto.TypeLite;
using Calysto.Web.Script.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.TestSite.Web.CalystoUI.Ajax
{
	[TsClass]
	public class AjaxService : IAjaxService
	{
		[CalystoWebMethod(Timeout = 5000)]
		public Task<string> AjaxSend(string msg, CalystoBlob[] files)
		{
			return Task.FromResult($"server received msg: {msg}, files: {files?.Length.ToString() ?? "none"}");
		}

		[CalystoWebMethod(SessionState = true)]
		public Task<string> AjaxSendThrow()
		{
			throw new Exception("this is my exception: " + DateTime.Now);
		}

		[CalystoWebMethod]
		public Task<string> InvokeAjaxError()
		{
			throw new Exception("this is inside HelloAjaxError");
		}

		private Task<byte[]> GetFileContent(string file)
		{
			return Task.FromResult(new CalystoPhysicalPathHelper(file).FindFile().FileBytes);
		}

		[CalystoWebMethod()]
		public async Task<CalystoBlob> DownloadBlob()
		{
			return new CalystoBlob()
			{
				Data = await GetFileContent("~/CalystoUI/Images/prod_2.jpg"),
				MimeType = "image/jpeg",
				FileName = "mojimage.jpg"
			};
		}

		[CalystoWebMethod]
		public async Task<IEnumerable<CalystoBlob>> DownloadBlobArray()
		{
			return new List<CalystoBlob>() {
				new CalystoBlob()
				{
					Data = await GetFileContent("~/CalystoUI/Images/prod_1.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage1.jpg"
				},
				new CalystoBlob()
				{
					Data = await GetFileContent("~/CalystoUI/Images/prod_2.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage2.jpg"
				},
				new CalystoBlob()
				{
					Data = await GetFileContent("~/CalystoUI/Images/prod_3.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage3.jpg"
				}
			}.ToArray();
		}

		[CalystoWebMethod]
		public Task<DateTime> SendClientDateTime(DateTime dt)
		{
			CalystoContextMvc.Current.Response.UseDirectUtility(a => a.Alert(@"received from client: " + dt + "\r\nserver time: " + DateTime.Now));
			return Task.FromResult(DateTime.Now);
		}

		[CalystoWebMethod]
		public async Task<BinaryFrameObj> DownloadBinaryFrameObject()
		{
			return new BinaryFrameObj()
			{
				Name = "Test frame 1",
				Count = 423423,
				List = (await DownloadBlobArray()).ToList()
			};
		}

		[CalystoWebMethod]
		public Task<CalystoBlob[]> DownloadBlobArrayError()
		{
			throw new Exception("ovo je greska u DownloadBlobArrayError");
		}

		[CalystoWebMethod]
		public Task<CalystoBlob> DownloadBlobError()
		{
			throw new Exception("ovo je greska u DownloadBlobError");
		}

		[CalystoWebMethod]
		public async Task Javascript1()
		{
			await Task.CompletedTask;
			CalystoContextMvc.Current.Response.UseDirectUtility(a => a.SystemAlert("inside javascript"));
		}
	}
}
