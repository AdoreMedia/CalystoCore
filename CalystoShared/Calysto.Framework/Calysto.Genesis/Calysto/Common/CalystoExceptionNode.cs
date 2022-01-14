using Calysto.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Calysto.Common
{
	/// <summary>
	/// JSON serializable
	/// </summary>
	public class CalystoExceptionNode
	{
		public string Source { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public string HelpLink { get; set; }
		public IDictionary Data { get; set; }
		public CalystoExceptionNode InnerException { get; set; }

		// public ctor for deserialization
		public CalystoExceptionNode() { }

		// private ctor
		public CalystoExceptionNode(Exception ex)
		{
			this.Source = ex.Source;
			this.Type = ex.GetType().FullName;
			this.Message = ex.Message;
			this.StackTrace = ex.StackTrace;
			this.HelpLink = ex.HelpLink;
			this.Data = ex.Data;

			if (ex.InnerException != null)
			{
				this.InnerException = new CalystoExceptionNode(ex.InnerException);
			}
		}

		private IEnumerable<CalystoExceptionNode> GetInnerExceptions(bool includeCurrent)
		{
			if (includeCurrent)
				yield return this;

			if (this.InnerException != null)
			{
				foreach (var item in this.InnerException.GetInnerExceptions(true))
					yield return item;
			}
		}

		public CalystoException ToSystemException()
		{
			CalystoException current = null;
			foreach(var node in this.GetInnerExceptions(true).Reverse())
			{
				current = new CalystoException(node, current);
			}
			return current;
		}

#if DOTNETFRAMEWORK
		public static void WriteExceptionToResponse(HttpContext context, Exception ex)
		{
			context.Response.ClearContent();
			context.Response.ClearHeaders();
			context.Response.ContentType = "application/json;charset=utf-8;";
			context.Response.Write(Calysto.Serialization.Json.JsonSerializer.Serialize(new CalystoExceptionNode(ex)));
			context.Response.StatusCode = 503;
		}
#endif

		/// <summary>
		/// Resolve exception from response and update original ex with data
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static Exception TryResolveExceptionFromResponse<T>(T ex) where T : Exception
		{
			// WebException is InnerException if tash was aborted, so traverse to find WebException
			Exception tempEx = ex;
			do
			{
				if (tempEx is WebException)
				{
					WebException resp1 = (WebException)tempEx;
					HttpWebResponse resp = resp1.Response as HttpWebResponse;
					if(resp == null)
					{
						// there is no response, probably the web server is not available
					}
					else if ((int)resp.StatusCode == 503 && resp.ContentType.Contains("application/json"))
					{
						byte[] data = resp.GetResponseStream().ToMemoryStream().ToArray();
						string json = Encoding.UTF8.GetString(data);
						var iceex = Calysto.Serialization.Json.JsonSerializer.Deserialize<CalystoExceptionNode>(json);
						Exception ex1 = iceex.ToSystemException();
						// assign webEx.InnerException = ex1 like this:
						typeof(Exception).GetField("_innerException", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tempEx, ex1);
						throw ex;
					}
				}
			} while ((tempEx = tempEx.InnerException) != null);

			throw ex;
		}

	}
}
