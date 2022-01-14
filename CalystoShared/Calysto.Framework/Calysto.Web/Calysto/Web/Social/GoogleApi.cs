using Calysto.Serialization.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using Web.Calysto.Web.Social.Google.Infrastructure;

namespace Web.Calysto.Web.Social
{
	public class GoogleApi
	{
		public static GoogleUser GetUser(string id_token)
		{
			string url = $"	https://oauth2.googleapis.com/tokeninfo?id_token={id_token}";
			try
			{
				return JsonSerializer.Deserialize<GoogleUser>(DownloadJson(url));
			}
			catch (Exception ex)
			{
				return new GoogleUser() { error = ex.Message };
			}
		}

		public static GoogleUser GetUser2(string access_token)
		{
			string url = $"	https://oauth2.googleapis.com/tokeninfo?access_token={access_token}";
			try
			{
				return JsonSerializer.Deserialize<GoogleUser>(DownloadJson(url));
			}
			catch (Exception ex)
			{
				return new GoogleUser() { error = ex.Message };
			}
		}

		private static string DownloadJson(string url)
		{
			try
			{ 
				WebClient client = new WebClient();
				client.Encoding = Encoding.UTF8;
				byte[] data = client.DownloadData(url);
				Encoding enc = client.Encoding ?? Encoding.UTF8;
				return enc.GetString(data);
			}
			catch (WebException ex)
			{
				MemoryStream ms = new MemoryStream();
				ex.Response.GetResponseStream().CopyTo(ms);
				return Encoding.UTF8.GetString(ms.ToArray());
			}
			catch
			{
				throw;
			}
		}
	}
}