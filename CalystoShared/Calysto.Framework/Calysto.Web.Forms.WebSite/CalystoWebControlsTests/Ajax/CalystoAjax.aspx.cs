using Calysto.Globalization;
using Calysto.TypeLite;
using Calysto.Utility;
using Calysto.Web.Extensions;
using Calysto.Web.Script.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax
{
	[TsClass]
	public partial class CalystoAjax : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Page.IgnoreMissingForm();
		}

		[CalystoWebMethod]
		public string AjaxSend(string msg, CalystoBlob[] files)
		{
			return $"server received msg: {msg}, files: {files?.Length.ToString() ?? "none"}";
		}

		[CalystoWebMethod]
		public string InvokeAjaxError()
		{
			throw new Exception("this is inside HelloAjaxError");
		}

		private byte[] GetFileContent(string file)
		{
			return new CalystoPhysicalPathHelper(file).FindFile().FileBytes;
		}

		[CalystoWebMethod()]
		public CalystoBlob DownloadBlob()
		{
			return new CalystoBlob()
			{
				Data = GetFileContent("~/CalystoUI/Images/prod_2.jpg"),
				MimeType = "image/jpeg",
				FileName = "mojimage.jpg"
			};
		}

		[CalystoWebMethod]
		public IEnumerable<CalystoBlob> DownloadBlobArray()
		{
			return new List<CalystoBlob>() {
				new CalystoBlob()
				{
					Data = GetFileContent("~/CalystoUI/Images/prod_1.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage1.jpg"
				},
				new CalystoBlob()
				{
					Data = GetFileContent("~/CalystoUI/Images/prod_2.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage2.jpg"
				},
				new CalystoBlob()
				{
					Data = GetFileContent("~/CalystoUI/Images/prod_3.jpg"),
					MimeType = "image/jpeg",
					FileName = "mojimage3.jpg"
				}
			}.ToArray();
		}

		[CalystoWebMethod]
		public DateTime SendClientDateTime(DateTime dt)
		{
			CalystoContextForms.Current.Response.UseDirectUtility(a => a.Alert(@"received from client: " + dt + "\r\nserver time: " + DateTime.Now));
			return DateTime.Now;
		}

		public class BinaryFrameObj
		{
			public string Name { get; set; }
			public int Count { get; set; }
			public List<CalystoBlob> List { get; set; }
		}

		[CalystoWebMethod]
		public BinaryFrameObj DownloadBinaryFrameObject()
		{
			return new BinaryFrameObj()
			{
				Name = "Test frame 1",
				Count = 423423,
				List = DownloadBlobArray().ToList()
			};
		}

		[CalystoWebMethod]
		public CalystoBlob[] DownloadBlobArrayError()
		{
			throw new Exception("ovo je greska u DownloadBlobArrayError");
		}

		[CalystoWebMethod]
		public CalystoBlob DownloadBlobError()
		{
			throw new Exception("ovo je greska u DownloadBlobError");
		}

		[CalystoWebMethod]
		public string GetPartialResult(DateTime date1)
		{
			if(string.IsNullOrEmpty(this.Text1.Text))
				this.Text1.Text = "Text1 " + DateTime.Now;

			this.Text2.Text = "Text2 " + date1;

			CalystoContextForms.Current.Response
				//.AddJavaScript("alert('ovo je direktni js')")
				.UseDirectUtility(a => a.Alert("ovo je direct utility alert"))
				//.UseDirectQuery("div", a => a.ApplyStyle("border: solid 1px green"))
				;
			
			return this.Panel1.ToHtmlRendered();
		}
	}
}