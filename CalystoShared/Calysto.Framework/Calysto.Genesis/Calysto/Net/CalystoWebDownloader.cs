#if !SILVERLIGHT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Threading;
using System.IO.Compression;
using Calysto.Threading;
using Calysto.Linq;
using Calysto.Common;
using System.Threading.Tasks;
using Calysto.Utility;
using Calysto.Common.Extensions;
using Calysto.Threading.Tasks;
using Calysto.Extensions;

namespace Calysto.Net
{
	public class CalystoWebDownloader : IDisposable
	{
		public enum HttpMethodEnum
		{
			/// <summary>
			/// 0: GET, Default
			/// </summary>
			GET = 0,
			/// <summary>
			/// 1: POST
			/// </summary>
			POST = 1
		}

		[System.Diagnostics.DebuggerDisplay("{_nameValuePair}")]
		public class NameValuePair
		{
			private string _nameValuePair { get { return $"{this.Name}={this.Value}"; } }
			public string Name;
			public string Value;
			public NameValuePair(string name, string value)
			{
				this.Name = name;
				this.Value = value;
			}
		}

		/// <summary>
		/// Facebook and Google doesn't send content length header, so we have to wait just to make sure all bytes are received
		/// </summary>
		public int WaitIfNoContentLength = 2000;
		/// <summary>
		/// Timeout ms
		/// </summary>
		public int Timeout = 45000;
		public string Url;
		public List<NameValuePair> Parameters;
		public byte[] UploadData;
		////public Func<Action<WebProxy>, bool> InvokeUsingProxy;
		public IWebProxy Proxy;
		public CookieContainer CookieContainer;
		/////// <summary>
		/////// Default 0. How many times will retry. -1 will retry forever.
		/////// </summary>
		////public int RetryCount = 0;
		public HttpMethodEnum HttpMethod = HttpMethodEnum.GET;
		public string AcceptEncoding = "gzip, deflate";
		public string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36";
		public string Accept = "*/*";
		//public string Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-shockwave-flash, */*";
		public string AcceptLanguage = "en-US,en;q=0.8";
		//public string AcceptCharset = "ISO-8859-1,utf-8;q=0.7,*;q=0.3";
		public string AcceptCharset = "utf-8;q=0.7,*;q=0.3";
		public string Referer;
		public bool AllowAutoRedirect = true; // system default
		public string ContentType;
		public Dictionary<string, string> Headers = new Dictionary<string, string>();
		private CancellationToken _cancellationToken;

		public void SetUserAgent(string userAgent) => this.UserAgent = userAgent;

		public enum UserAgentEnum
		{
			[StringValue(null)]
			None,

			[StringValue("Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)")]
			GoogleBot,

			[StringValue("Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z‡ Mobile Safari/537.36 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)")]
			GoogleBotMobile,

			[StringValue("Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)")]
			BingBot,

			[StringValue("Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/W.X.Y.Z Mobile Safari/537.36 Edg/W.X.Y.Z (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)")]
			BingBotMobile,

			[StringValue("Version 87.0.4280.141 (Official Build) (64-bit)")]
			Chrome87,

			[StringValue("Version 88.0.705.50 (Official build) (64-bit)")]
			Edge88,
			
			[StringValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.69 Safari/537.36 Edg/95.0.1020.53")]
			Edge95,

			[StringValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.69 Safari/537.36")]
			Chrome95,
		}

		public void SetUserAgent(UserAgentEnum userAgent) => this.UserAgent = userAgent.GetStringValue();

		public void AddParameter(string name, string value)
		{
			if (this.Parameters == null) this.Parameters = new List<NameValuePair>();
			this.Parameters.Add(new NameValuePair(HttpUtility.UrlDecode(name ?? ""), HttpUtility.UrlDecode(value ?? "")));
		}

		public void AddParameters(Dictionary<string, string> dic)
		{
			dic.ForEach(o => this.AddParameter(o.Key, o.Value));
		}

		public void AddParameters(string queryString)
		{
			queryString.Split('?', '&').Where(o => !string.IsNullOrWhiteSpace(o)).ForEach(pair =>
			{
				var pp = pair.Split('=');
				this.AddParameter(pp.FirstOrDefault(), pp.Skip(1).FirstOrDefault());
			});
		}

		public class CalystoWebResponse
		{

			public HttpStatusCode StatusCode;

			public string StatusDescription;

			public string ContentType;

			public WebHeaderCollection Headers;

			public byte[] CompressedData;

			public string Compression;

			public Encoding Encoding;

			private byte[] _bytes;
			
			public byte[] Bytes
			{
				get
				{
					if (_bytes == null && this.CompressedData != null)
					{
						if (string.IsNullOrEmpty(this.Compression))
						{
							_bytes = this.CompressedData;
						}
						else
						{
							_bytes = DecompressData(this.Compression, new MemoryStream(this.CompressedData));
						}
					}
					return _bytes;
				}
			}

			private string _text;

			public string Text
			{
				get { return _text ?? (_text = this.Bytes != null ? this.Encoding.GetString(this.Bytes) : null); }
			}
		}

		private CalystoWebResponse _rxResponse;

		public CalystoWebResponse GetResponse()
		{
			if (this.IsDisposed)
				throw new InvalidOperationException("Object disposed");

			if(this._rxResponse == null)
			{
				this.GetResponseWorker();
			}
			return this._rxResponse;
		}

		public CalystoWebDownloader Set(Action<CalystoWebDownloader> action)
		{
			action.Invoke(this);
			return this;
		}

		private void ResetResponse()
		{
			this._rxResponse = null;
		}

		public CalystoWebDownloader(string url, CancellationToken? cancellationToken = null)
		{
			this.Url = url;
			this.Client = new CalystoWebClient(url);
			_cancellationToken = cancellationToken ?? new CancellationToken();
		}
		
		private static byte[] ReadDataFromStream(Stream stream)
		{
			MemoryStream ms = new MemoryStream();
			stream.CopyTo(ms);
			return ms.ToArray();
		}

		private static byte[] DecompressData(string compression, Stream stream)
		{
			switch (compression)
			{
				case "gzip":
					return ReadDataFromStream(new GZipStream(stream, CompressionMode.Decompress));

				case "deflate":
					return ReadDataFromStream(new DeflateStream(stream, CompressionMode.Decompress));

				default: // uncompressed
					return ReadDataFromStream(stream);
			}
		}

		~CalystoWebDownloader() => this.Dispose();

		public void Dispose()
		{
			this.IsDisposed = true;
			this.ReleaseStreams();
		}

		public CalystoWebClient Client;

		private void ReleaseStreams()
		{
			this.Client?.Dispose();
		}

		private void GetResponseWorker()
		{
			this.ResetResponse();

			// we need new token which will be used to terminate subtasks in GetResponseWorkerAsync() if timeot is occured
			// token1.Cancel() is invoked at the end from finally block
			CancellationTokenSource token1 = CancellationTokenSource.CreateLinkedTokenSource(_cancellationToken);

			try
			{
				if(!this.GetResponseWorkerAsync(token1.Token).Wait(this.Timeout, token1.Token))
				{
					throw new TimeoutException();
				}
			}
			catch(AggregateException ex)
			{
				throw ex.GetBaseException();
			}
			finally
			{
				token1.Cancel();
				token1.Dispose();

				// it is very important to close and dispose streams, otherwise it throws exceptions in multithread environment
				// if exception was thrown, streams are still opened, close and dispose them
				this.ReleaseStreams();
			}
		}

		public bool IsDisposed { get; private set; }

		private async Task<bool> GetResponseWorkerAsync(CancellationToken cancellationToken)
		{
			string queryString = this.Parameters == null ? null : this.Parameters.Select(o => HttpUtility.UrlEncode(o.Name) + "=" + HttpUtility.UrlEncode(o.Value)).ToStringJoined("&");
			string reqUrl = this.Url.Trim('?');
			if (this.HttpMethod == HttpMethodEnum.GET && !string.IsNullOrEmpty(queryString))
			{
				reqUrl += "?" + queryString;
			}

			if (cancellationToken.IsCancellationRequested) return false;

			// this.Client already has events set, so we may not instantinate the new Client
			// set new url before this.Client.Request is instantinated (on first invocation)
			this.Client.Url = reqUrl;

			HttpWebRequest httpWebRequest = this.Client.Request;
			httpWebRequest.AllowAutoRedirect = this.AllowAutoRedirect;

			if (this.CookieContainer == null)
			{
				this.CookieContainer = new CookieContainer();
			}
			httpWebRequest.CookieContainer = this.CookieContainer;

			httpWebRequest.ReadWriteTimeout = this.Timeout;
			httpWebRequest.Timeout = this.Timeout;
			httpWebRequest.Accept = this.Accept;
			httpWebRequest.UserAgent = this.UserAgent;
			httpWebRequest.Headers["Accept-Language"] = this.AcceptLanguage;
			httpWebRequest.Headers["Accept-Encoding"] = this.AcceptEncoding;
			httpWebRequest.Headers["Accept-Charset"] = this.AcceptCharset;

			if (!string.IsNullOrEmpty(this.Referer))
			{
				httpWebRequest.Referer = this.Referer;
			}

			if (this.Proxy != null)
			{
				httpWebRequest.Proxy = this.Proxy;
			}

			if (cancellationToken.IsCancellationRequested) return false;
			
			if (!string.IsNullOrWhiteSpace(this.ContentType))
				httpWebRequest.ContentType = this.ContentType;

			this.Headers.ForEach(kv => httpWebRequest.Headers[kv.Key] = kv.Value);

			if(this.UploadData != null)
			{
				httpWebRequest.Method = "POST";
				if (string.IsNullOrEmpty(httpWebRequest.ContentType))
				{
					httpWebRequest.ContentType = "application/octet-stream";
					////httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				}

				httpWebRequest.ContentLength = this.UploadData.Length;
				await this.Client.WriteAsync(this.UploadData, cancellationToken);
			}
			else if (this.HttpMethod == HttpMethodEnum.POST)
			{
				httpWebRequest.Method = "POST";
				if (string.IsNullOrEmpty(httpWebRequest.ContentType))
				{
					httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				}

				byte[] data = Encoding.UTF8.GetBytes(queryString);
				httpWebRequest.ContentLength = data.Length;

				await this.Client.WriteAsync(data, cancellationToken);
			}
			else
			{
				httpWebRequest.Method = "GET";
			}

			if (cancellationToken.IsCancellationRequested) return false;

			this._rxResponse = new CalystoWebResponse();

			try
			{
				this._rxResponse.CompressedData = await this.Client.ReadAsync(cancellationToken);

				this._rxResponse.StatusCode = this.Client.Response.StatusCode;
				this._rxResponse.ContentType = this.Client.Response.ContentType;
				this._rxResponse.Headers = this.Client.Response.Headers;
			}
			//catch(HttpException ex)
			//{
			//	throw ex;
			//}
			catch(WebException ex)
			{
				this._rxResponse.StatusDescription = ex.Message;

				try
				{
					HttpWebResponse resp1 = (HttpWebResponse)ex.Response;

					if (resp1 != null)
					{
						this._rxResponse.StatusCode = resp1.StatusCode;
					}
				}
				catch 
				{
				}

				throw ex;
			}
			catch(Exception ex)
			{
				this._rxResponse.StatusDescription = ex.Message;
				throw ex;
			}

			if (cancellationToken.IsCancellationRequested) return false;

			this.CookieContainer = httpWebRequest.CookieContainer;

			this._rxResponse.Compression = (this.Client.Response.GetResponseHeader("content-encoding") ?? "").ToLower().ToNullIfEmpty();

			// must close & dispose to close stream for sure
			this.Client.Dispose();

			Encoding encoding = null;
			try
			{
				string characterset = this.Client.Response.CharacterSet;
				if (!string.IsNullOrEmpty(characterset))
				{
					encoding = Encoding.GetEncoding(characterset);
				}
			}
			catch
			{
			}

			this._rxResponse.Encoding = encoding ?? new UTF8Encoding();

			if (cancellationToken.IsCancellationRequested) return false;

			return await Task.FromResult(true);
		}

		public byte[] DownloadData()
		{
			return this.GetResponse().Bytes;
		}

		public string DownloadString()
		{
			return this.GetResponse().Text;
		}

	}
}
#endif
