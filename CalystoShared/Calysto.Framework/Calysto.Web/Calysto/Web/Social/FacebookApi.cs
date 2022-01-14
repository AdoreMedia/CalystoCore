using Calysto.Serialization.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using Web.Calysto.Web.Social.Facebook.Infrastructure;

namespace Web.Calysto.Web.Social
{
	public class FacebookApi
	{
		const string _fields = "id,name,first_name,last_name,age_range,gender,email";

		public static FBUser GetUser(string accessToken)
		{
			string url = $"	https://graph.facebook.com/me?fields={_fields}&access_token={accessToken}";
			try
			{
				return JsonSerializer.Deserialize<FBUser>(DownloadJson(url));
			}
			catch (Exception ex)
			{
				return new FBUser() { error = new FBError() { message = ex.Message } };
			}
		}

		public static FBApp GetApp(string accessToken)
		{
			string url = $"	https://graph.facebook.com/app?access_token={accessToken}";
			try
			{
				return JsonSerializer.Deserialize<FBApp>(DownloadJson(url));
			}
			catch (Exception ex)
			{
				return new FBApp() { error = new FBError() { message = ex.Message } };
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