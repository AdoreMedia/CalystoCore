using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Calysto.Common;

namespace Calysto.Net
{
	/// <summary>
	/// HttpWebRequest implementation for Silverlight (async only)
	/// Silverlight has no GZip or Deflate streams support
	/// </summary>
	public class CalystoWebClient : IDisposable
	{
		public string Url { get;  set; }

		HttpWebRequest _request;
		/// <summary>
		/// Instantinate request on first invocation.
		/// </summary>
		public HttpWebRequest Request => _request ?? (_request = (HttpWebRequest)HttpWebRequest.Create(this.Url));

		public HttpWebResponse Response { get; private set; }
		
		Stream _responseStream;
		Stream _requestStream;

		~CalystoWebClient() => this.Dispose();

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			if (this.IsDisposed) return;
			this.IsDisposed = true;
			this.StreamsCleanup();

			this.OnResponseComplete = null;
			this.OnResponseProgress = null;
			this.OnUploadComplete = null;
			this.OnUploadProgress = null;
		}

		private void StreamsCleanup()
		{
			if (_requestStream != null)
			{
				try
				{
					_requestStream.Close();
					_requestStream.Dispose();
					_requestStream = null;
				}
				catch { }
			}

			if (_responseStream != null)
			{
				try
				{
					_responseStream.Close();
					_responseStream.Dispose();
					_responseStream = null;
				}
				catch { }
			}
		}

		public event Action<CalystoWebClient> OnResponseComplete;

		public event Action<CalystoWebClient, CalystoWebClientProgressArg> OnResponseProgress;

		public event Action<CalystoWebClient> OnUploadComplete;

		public event Action<CalystoWebClient, CalystoWebClientProgressArg> OnUploadProgress;

		private async Task<byte[]> ReadDataAsync(CancellationToken cancellationToken)
		{
			long responsePosition = 0;
			MemoryStream respMs = new MemoryStream();
			int readBufferSize = 2 ^ 15;
			byte[] readBuffer = new byte[readBufferSize];

			while (!this.IsDisposed && !cancellationToken.IsCancellationRequested)
			{
				int read = await this._responseStream.ReadAsync(readBuffer, 0, readBufferSize, cancellationToken);
				responsePosition += read;

				if (read > 0)
				{
					respMs.Write(readBuffer, 0, read);
					this.OnResponseProgress?.Invoke(this, new CalystoWebClientProgressArg(responsePosition, this.Response.ContentLength));
					continue;
				}
				else
				{
					byte[] responseData = respMs.ToArray();
					this._responseStream.Close();
					this._responseStream.Dispose();
					this._responseStream = null;

					this.OnResponseComplete?.Invoke(this);

					// read complete
					return responseData;
				}
			}
			return new byte[0];
		}

		private int CalculateWriteBufferSize(int dataLength)
		{
			int len1 = dataLength / 500;
			if (len1 > 65536)
				return 65536;
			else if (len1 < 4096)
				return 4096;
			else
				return len1;
		}

		private async Task WriteDataAsync(byte[] uploadData, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
			int uploadPosition = 0;
			int writeBufferSize = this.CalculateWriteBufferSize(uploadData.Length);

			while (!this.IsDisposed && !cancellationToken.IsCancellationRequested)
			{
				int writeLength = 0;
				if (uploadData != null && uploadData.Length > 0 && (writeLength = uploadData.Length - uploadPosition) > 0)
				{
					if (writeLength > writeBufferSize)
					{
						writeLength = writeBufferSize;
					}
					int offset = uploadPosition;
					uploadPosition += writeLength;
					await this._requestStream.WriteAsync(uploadData, offset, writeLength, cancellationToken);
					await this._requestStream.FlushAsync(cancellationToken);
					this.OnUploadProgress?.Invoke(this, new CalystoWebClientProgressArg(uploadPosition, uploadData.Length));
					
					if(this.Response == null)
						this.Response = (HttpWebResponse)await this.Request.GetResponseAsync(); 

					continue;
				}
				else
				{
					// write complete or no data to be sent
					this._requestStream.Flush();
					this._requestStream.Close();
					this._requestStream.Dispose();
					this._requestStream = null;

					this.OnUploadComplete?.Invoke(this);

					// now we're ready to receive data
					return;
				}
			}
		}

		public CalystoWebClient(string url)
		{
			this.Url = url;
		}

		public async Task WriteAsync(byte[] uploadData, CancellationToken cancellationToken)
		{
			try
			{
				this.Request.AllowWriteStreamBuffering = false;
				this.Request.AllowReadStreamBuffering = false;
				this.Request.ContentLength = uploadData?.Length ?? 0;
				if(string.IsNullOrEmpty(this.Request.ContentType))
				{
					this.Request.ContentType = "application/octet-stream";
					//this.Request.ContentType = "application/x-www-form-urlencoded";
					//this.Request.ContentType = "multipart/form-data";
				}
				this._requestStream = await this.Request.GetRequestStreamAsync();
				await this.WriteDataAsync(uploadData, cancellationToken);
			}
			finally
			{
				this.StreamsCleanup();
			}
		}

		public async Task<byte[]> ReadAsync(CancellationToken cancellationToken)
		{
			try
			{
				// if posting data, stream has to be read on the server, else EndGetResponse throws NotFound exception
				if(this.Response == null)
					this.Response = (HttpWebResponse)await this.Request.GetResponseAsync();

				this._responseStream = this.Response.GetResponseStream();
				return await this.ReadDataAsync(cancellationToken);
			}
			finally
			{
				this.StreamsCleanup();
			}
		}
	}
}
