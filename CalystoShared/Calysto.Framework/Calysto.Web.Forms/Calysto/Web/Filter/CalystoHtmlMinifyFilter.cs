using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Calysto.Web.UI;
using System.Text;
using Calysto.Web.Filter;
using Calysto.Common;
using Calysto.Common.Extensions;

namespace Calysto.Web
{
	/// <summary>
	/// Write(...) writes data to base MemoryStream
	/// Flush() is overriden to process buffered data before writing it to this.BaseStream
	/// </summary>
	public class CalystoHtmlMinifyFilter : MemoryStream
	{
		public Stream BaseStream { get; private set; } 

		private bool _encryptHtml { get; set; }

		public CalystoHtmlMinifyFilter(Stream baseStream, bool encryptHtml = false)
		{
			this.BaseStream = baseStream;
			this._encryptHtml = encryptHtml;
		}

		public override void Flush()
		{
			this.Position = 0; // to read from start

			string minifiedHtml = new StreamReader(this, System.Text.Encoding.UTF8).ReadToEnd()

				// AjaxControlToolkit: dodaje CDATA komentare
				// remove CDATA in JS, // kad se makne \r\n, JS kod bi ostao zakomentiran
				.Replace("//<![CDATA[", "")
				.Replace("//]]>", "")

				// warning: use [\\w\\W], don't use .*? because dot won't select some unicode chars

				// html comments <!--...-->
				.Replace(new Regex(Regex.Escape("<!--") + "[\\w\\W]*?" + Regex.Escape("-->")), "")

				// c++ comments in JS /*...*/
				.Replace(new Regex(Regex.Escape("/*") + "[\\w\\W]*?" + Regex.Escape("*/")), "")

				// remove single line comments in JS //..., pazi da ne makne urlove u html tagovima: http://nesto.com
				// this can make mess, don't use it
				// .Replace(new Regex(Regex.Escape("//") + "[^'\"\\:<>\\=\\&]*?" + "[\r\n]+"), "") 

				// replace multiple white spaces with single white space
				.Replace(new Regex("[\\s]+"), " ")

				// AjaxControlToolkit: RequiredFieldValidator control creates js without ; , so fix it
				.Replace("} Sys.Application", "}; Sys.Application")
				.Replace("} document.getElementById", "}; document.getElementById")
				
				// must have space between tags ...</span> <div>..., this way minified html renders the same as nonminified
				//.Replace("> <", "><") 
			;

			byte[] header1 = null;

			if (!string.IsNullOrWhiteSpace(ResponseFilterHelper.HeaderSignature) && HttpContext.Current?.Response?.ContentType?.Contains("text/html") == true)
			{
				header1 = Encoding.UTF8.GetBytes("<!--" + ResponseFilterHelper.HeaderSignature + "-->" + "\r\n");
			}

			byte[] data1 = Encoding.UTF8.GetBytes(minifiedHtml);

			if(this._encryptHtml)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("<script>document.write(unescape(\""); // unescape or decodeURIComponent
				foreach (var ch in data1)
				{
					sb.Append("%");
					sb.Append(ch.ToString("X2"));
				}
				sb.Append("\"))</script>");

				data1 = Encoding.UTF8.GetBytes(sb.ToString());
			}

			if (header1 != null)
				this.BaseStream.Write(header1, 0, header1.Length);

			this.BaseStream.Write(data1, 0, data1.Length);
			this.BaseStream.Flush();
		}

		public override void Close()
		{
			base.Close();
			this.BaseStream.Close();
		}

	
	}
}

