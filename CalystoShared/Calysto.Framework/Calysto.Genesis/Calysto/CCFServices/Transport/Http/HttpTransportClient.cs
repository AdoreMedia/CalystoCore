using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Calysto.CCFServices.Transport.Http
{
	public class HttpTransportClient : HttpTransport, ICCFTransportClient
	{
		public HttpTransportClient(string url) : base(url)
		{
		}

		public event Action<ProgressEventArgs> OnProgress;
		public event Action<byte[]> OnDataReceived;

		public virtual async Task BeforeRequestSentAsync(HttpRequestMessage request)
		{
			await Task.CompletedTask;
		}

		public virtual async Task HeadersReceivedAsync(HttpResponseMessage response)
		{
			await Task.CompletedTask;
		}

		public virtual async Task<(HttpResponseMessage Response, byte[] Data)> UploadDataAsync(byte[] sendData, string url = null, Action<HttpClient, HttpRequestMessage> beforeRequest = null)
		{
			CancellationTokenSource tokenSource1 = new CancellationTokenSource();

			try
			{
				HttpResponseMessage response1;
				HttpClientHandler handler = new HttpClientHandler();
				HttpClient client = new HttpClient(handler);
				
				HttpRequestMessage request1 = new HttpRequestMessage();
				request1.Method = HttpMethod.Get;
				request1.RequestUri = new Uri(url ?? this.Url);
				request1.Headers.Add(this.HEADER_KEY, this.HEADER_VALUE);
				if (sendData?.Length > 0)
				{
					ProgressArrayContent content1 = new ProgressArrayContent(sendData, this.ChunkSize, tokenSource1.Token);
					content1.OnProgress += (current, total) => this.OnProgress?.Invoke(new ProgressEventArgs(current, total, "Upload"));
					request1.Method = HttpMethod.Post;
					request1.Content = content1;
				}

				beforeRequest?.Invoke(client, request1);

				await this.BeforeRequestSentAsync(request1);

				response1 = await client.SendAsync(request1, HttpCompletionOption.ResponseHeadersRead, tokenSource1.Token);

				await this.HeadersReceivedAsync(response1);

				Stream stream1 = await response1.Content.ReadAsStreamAsync();
				MemoryStream ms = new MemoryStream();

				if (this.OnProgress == null)
				{
					await stream1.CopyToAsync(ms, this.ChunkSize, tokenSource1.Token);
				}
				else
				{
					long contentLength = response1.Content.Headers.ContentLength ?? -1;
					bool hasLength = contentLength >= 0;

					int chunkSize = ProgressArrayContent.CalculateChunkSize(contentLength, this.ChunkSize);
					byte[] buffer = new byte[chunkSize];
					int read = 0;
					int zeroReads = 0;
					while ((hasLength && ms.Length < contentLength) || (!hasLength && stream1.CanRead))
					{
						// kad ima contentLength, citati ce stream dok je ms.Length < contentLength
						// kad nema contentLength, brojat ce zeroReads
						zeroReads++;

						if ((read = stream1.Read(buffer, 0, chunkSize)) > 0)
						{
							zeroReads = 0;
							ms.Write(buffer, 0, read);
							this.OnProgress?.Invoke(new ProgressEventArgs(ms.Position, contentLength >= 0 ? contentLength : ms.Position, "Download"));
						}

						if (zeroReads > 20)
						{
							break;
						}
						else if (zeroReads > 10)
						{
							await Task.Delay(20);
						}
					}
				}

				return (response1, ms.ToArray());
			}
			finally
			{
				tokenSource1.Cancel();
				tokenSource1.Dispose();
			}
		}

		public virtual async Task SendRequestAsync(byte[] sendData)
		{
			byte[] resp = (await this.UploadDataAsync(sendData)).Data;
			this.OnDataReceived?.Invoke(resp);
		}

		#region disposing

		public override void Dispose()
		{
			if (this.IsDisposed) return;
			base.Dispose();
		}

		#endregion
	}
}