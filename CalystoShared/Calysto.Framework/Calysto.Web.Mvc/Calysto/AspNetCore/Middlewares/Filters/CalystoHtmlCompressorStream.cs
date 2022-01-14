using System;
using System.IO;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Brotli;
using Calysto.Extensions;
using Calysto.IO.Compression;
using Calysto.Web;
using Calysto.Web.Hosting;
using Microsoft.AspNetCore.Http;

namespace Calysto.AspNetCore.Middlewares.Filters
{
	public class CalystoHtmlCompressorStream : Stream
	{
		private HttpContext _context;
		private Stream _baseStream;
		private MemoryStream _ms;

		public CalystoHtmlCompressorStream(HttpContext context, Stream baseStream)
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
			if(_ms != null)
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
				byte[] compr1 = _compress.Invoke(_ms);
				_ms.Close();
				_ms.Dispose();
				_ms = null;
				await _baseStream.WriteAsync(compr1, 0, compr1.Length, cancellationToken);
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
			if (this.IsHtml && !CalystoMvcHostingEnvironment.Current.BrowserCompression.IsNone)
			{
				if (_ms == null)
				{
					ApplyCompressionFilter();
					_ms = new MemoryStream();
				}

				await _ms.WriteAsync(buffer, 0, count, cancellationToken);
			}
			else
			{
				await _baseStream.WriteAsync(buffer, offset, count, cancellationToken);
			}
		}

		private Func<MemoryStream, byte[]> _compress;

		private void ApplyCompressionFilter()
		{
			var compr = CalystoMvcHostingEnvironment.Current.BrowserCompression;

			if (compr.IsNone)
			{
				return;
			}
			else if (compr.IsBrotli)
			{
				// brotli
				// https://github.com/XieJJ99/brotli.net
				_context.Response.Headers.Add("Content-Encoding", BrowserCompression.KindName.Brotli.GetStringValue());
				_compress = (ms) => BrotliHelper.Compress(ms.ToArray());
				// writing to brotly doesn't work, stream has to be copied, use BrotliHelper
				//return new BrotliStream(_baseStream, CompressionMode.Compress);
			}
			else if (compr.IsGzip)
			{
				// gzip
				_context.Response.Headers.Add("Content-Encoding", BrowserCompression.KindName.Gzip.GetStringValue());
				_compress = (ms) => GZipHelper.Compress(ms.ToArray());
				//return new GZipStream(_baseStream, CompressionMode.Compress);
			}
			else if (compr.IsDeflate)
			{
				// defalte
				_context.Response.Headers.Add("Content-Encoding", BrowserCompression.KindName.Deflate.GetStringValue());
				_compress = (ms) => DeflateHelper.Compress(ms.ToArray());
				//return new DeflateStream(_baseStream, CompressionMode.Compress);
			}
			else
			{
				// leave as-is (no compression)
				throw new Exception("Unknown browser compression: " + compr.AcceptEncoding);
			}
		}
	}
}
