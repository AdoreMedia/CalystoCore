using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Calysto.AspNetCore.Middlewares.Filters
{
	public class CalystoHtmlMinifyStream : Stream
	{
		private HttpContext _context;
		private Stream _baseStream;
		private MemoryStream _ms;

		public CalystoHtmlMinifyStream(HttpContext context, Stream baseStream)
		{
			this._context = context;
			this._baseStream = baseStream;
		}

		public Stream RestoreBaseStream()
		{
			var b1 = _baseStream;
			_baseStream = new MemoryStream();
			return b1;
		}

		protected override void Dispose(bool disposing)
		{
			this.FlushAsync();
			if (_ms != null)
			{
				_ms.Close();
				_ms.Dispose();
			}
			base.Dispose(disposing);
		}

		public override bool CanRead => throw new NotImplementedException();

		public override bool CanSeek => throw new NotImplementedException();

		public override bool CanWrite => true;

		public override long Length => throw new NotImplementedException();

		public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		private bool IsHtml => _context.Response.ContentType?.StartsWith("text/html") == true;

		public override async Task FlushAsync(CancellationToken cancellationToken)
		{
			if(_ms != null)
			{
				byte[] data2 = _ms.ToArray();
				_ms.Close();
				_ms.Dispose();
				_ms = null;
				byte[] data3 = this.Minify(data2, 0, data2.Length);
				await this._baseStream.WriteAsync(data3, 0, data3.Length, cancellationToken);
			}

			await this._baseStream.FlushAsync(cancellationToken);
		}

		// doesn't exist in netstandard2.0
		//public override ValueTask WriteAsync(ReadOnlyMemory<byte> source, CancellationToken cancellationToken = default)
		//{
		//	byte[] data = source.ToArray();

		//	if (this.IsHtml)
		//	{
		//		if(_tmpMs == null)
		//			_tmpMs = new MemoryStream();

		//		return new ValueTask(_tmpMs.WriteAsync(data, 0, data.Length, cancellationToken));
		//	}
		//	else
		//	{
		//		return new ValueTask(base.WriteAsync(data, 0, data.Length, cancellationToken));
		//	}
		//}

		public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			// vise puta se poziva WriteAsinc()
			// na kraju se ne poziva FlushAsync() pa je rijeseno kroz Dispose()
			if (this.IsHtml)
			{
				if (_ms == null)
					_ms = new MemoryStream();

				await _ms.WriteAsync(buffer, 0, count, cancellationToken);
			}
			else
			{
				await _baseStream.WriteAsync(buffer, offset, count, cancellationToken);
			}
		}

		private byte[] Minify(byte[] buffer, int offset, int count)
		{
			string str1 = Encoding.UTF8.GetString(buffer, offset, count);
			string str2 = MinifyContent(str1);
			return Encoding.UTF8.GetBytes(str2);
		}

		public static string MinifyContent(string html, bool encryptHtml = false, string headerText = null, string footerText = null)
		{
			string minifiedHtml = html

			// AjaxControlToolkit: dodaje CDATA komentare
			// remove CDATA in JS, // kad se makne \r\n, JS kod bi ostao zakomentiran
			.Replace("//<![CDATA[", "")
			.Replace("//]]>", "");

			// warning: use [\\w\\W], don't use .*? because dot won't select some unicode chars

			// html comments <!--...-->
			minifiedHtml = new Regex(Regex.Escape("<!--") + "[\\w\\W]*?" + Regex.Escape("-->")).Replace(minifiedHtml, "");

			// c++ comments in JS /*...*/
			minifiedHtml = new Regex(Regex.Escape("/*") + "[\\w\\W]*?" + Regex.Escape("*/")).Replace(minifiedHtml, "");

			// replace multiple white spaces with single white space
			minifiedHtml = new Regex("[\\s]+").Replace(minifiedHtml, " ");
		;

			if (encryptHtml)
			{
				byte[] data1 = Encoding.UTF8.GetBytes(minifiedHtml);
				StringBuilder sb = new StringBuilder();
				sb.Append("<script>document.write(unescape(\""); // unescape or decodeURIComponent
				foreach (var ch in data1)
				{
					sb.Append("%");
					sb.Append(ch.ToString("X2"));
				}
				sb.Append("\"))</script>");

				minifiedHtml = sb.ToString();
			}

			return CreateComment(headerText, false, true) 
				+ minifiedHtml 
				+ CreateComment(footerText, true, false);
		}

		private static string CreateComment(string str1, bool newLineBefore, bool newLineAfter)
		{
			if (str1 != null)
				return (newLineBefore ? "\r\n" : null) + "<!--" + str1 + "-->" + (newLineAfter ? "\r\n" : null);
			else
				return null;
		}
	}
}
