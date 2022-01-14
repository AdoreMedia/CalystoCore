using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Calysto.Utility
{
	public class SignedStringHelper
	{
		string _secret;
		const char _separator = '|';

		/// <summary>
		/// If secret is null, will use ManifestModule.ModuleVersionId
		/// </summary>
		/// <param name="secret"></param>
		public SignedStringHelper(string secret = null)
		{
			if (string.IsNullOrEmpty(secret))
			{
				_secret = Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.ToString();
			}
			else
			{
				_secret = secret;
			}
		}

		/// <summary>
		/// Returns base64 encoded "signature|rawString"
		/// </summary>
		/// <param name="rawString"></param>
		/// <returns></returns>
		public string CreateSignedString(string rawString)
		{
			string s1 = _secret + _separator + rawString;
			string signature = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(s1)));
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(signature + _separator + rawString));
		}

		public bool TryDecodePageState(string signedString, out string rawString)
		{
			try
			{
				string str1 = Encoding.UTF8.GetString(Convert.FromBase64String(signedString));
				int index1 = str1.IndexOf(_separator);
				string signature = str1.Remove(index1);
				string data1 = str1.Substring(index1 + 1);
				if (signedString == CreateSignedString(data1))
				{
					rawString = data1;
					return true;
				}
			}
			catch { }

			rawString = null;
			return false;
		}
	}
}