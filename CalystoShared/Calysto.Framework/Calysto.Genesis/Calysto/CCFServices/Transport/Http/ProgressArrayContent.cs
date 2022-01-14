using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.Http
{
	class ProgressArrayContent : HttpContent
	{
		public static int CalculateChunkSize(long contentLength, int chunkSize)
		{
			int calculated1 = (int)(contentLength / 100);
			if (calculated1 > (2 ^ 20))
				return (2 ^ 20); // 1MB
			else if (calculated1 < chunkSize)
				return chunkSize;
			else
				return calculated1;
		}

		public event Action<long, long> OnProgress;

		byte[] _data;
		CancellationToken _cancellationToken;
		int _chunkSize;

		public ProgressArrayContent(byte[] data, int chunkSize, CancellationToken cancellationToken) : base()
		{
			this._data = data;
			this._chunkSize = chunkSize;
			this._cancellationToken = cancellationToken;
		}

		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			if (this.OnProgress == null)
			{
				MemoryStream ms = new MemoryStream(this._data);
				await ms.CopyToAsync(stream, this._chunkSize, this._cancellationToken);
			}
			else
			{
				int chunkSize = CalculateChunkSize(_data.Length, _chunkSize);
				int offset = 0;
				int totalLen = _data.Length;
				int left = totalLen - offset;
				while (!this.IsDisposed && left > 0)
				{
					int take = Math.Min(chunkSize, left);
					await stream.WriteAsync(_data, offset, take);
					await stream.FlushAsync();
					offset += take;
					left = _data.Length - offset;
					this.OnProgress?.Invoke(offset, totalLen);
				}
			}
		}

		protected override bool TryComputeLength(out long length)
		{
			length = _data.Length;
			return true;
		}

		protected override Task<Stream> CreateContentReadStreamAsync()
		{
			return base.CreateContentReadStreamAsync();
		}

		public bool IsDisposed { get; private set; }

		protected override void Dispose(bool disposing)
		{
			this.IsDisposed = true;
			base.Dispose(disposing);
			this.OnProgress = null;
		}
	}
}