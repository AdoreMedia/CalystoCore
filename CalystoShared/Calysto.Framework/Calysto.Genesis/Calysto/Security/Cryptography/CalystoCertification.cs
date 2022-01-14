using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calysto.Security.Cryptography
{
	/// <summary>
	/// Add signature to string, using secret and hashing.
	/// </summary>
	public class CalystoCertification
	{
		string _secret;
		public CalystoCertification(string secret)
		{
			_secret = secret;
		}

		private string ComputeHash(string txt)
		{
			byte[] data = Encoding.UTF8.GetBytes(_secret + "$#$" + txt + "#$#" + _secret);
			byte[] hash1 = System.Security.Cryptography.MD5.Create().ComputeHash(data);
			return Convert.ToBase64String(hash1);
		}

		public string Sign(string txt)
		{
			return $"[[[{ComputeHash(txt)}]]]" + txt; 
		}

		Regex _re = new Regex("^\\[\\[\\[(?<sig>[\\w\\W]+?)\\]\\]\\](?<txt>[\\w\\W]*)$");
		
		public bool TryDecode(string signedTxt, out string pureTxt)
		{
			pureTxt = null;
			
			if (string.IsNullOrEmpty(signedTxt))
				return false;

			Match m1 = _re.Match(signedTxt);
			if (!m1.Success)
				return false;

			string hash1 = m1.Groups["sig"].Value;
			string str1 = m1.Groups["txt"].Value;
			if (hash1.Length > 10 && this.ComputeHash(str1) == hash1)
			{
				pureTxt = str1;
				return true;
			}
			else
				return false;
		}
	}
}
