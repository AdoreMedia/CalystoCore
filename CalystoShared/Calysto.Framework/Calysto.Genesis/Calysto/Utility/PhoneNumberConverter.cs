using Calysto.Linq;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	public class PhoneNumberConverter
	{
		/// <summary>
		/// <para>PhoneNumber format: 385911444555, 091 1444 555, 0911444555, 091/1222-333, 385912233343, +385913432324, 00385914326234</para> 
		/// <para>Returns MSISDN 3859..., or null if number is not valid</para>
		/// </summary>
		/// <param name="phoneNumber"></param>
		/// <returns></returns>
		public static string ConvertToMSISDN(string phoneNumber, string countryPrefix = "385", bool addPlusPrefix = false)
		{
			if (string.IsNullOrEmpty(phoneNumber))
			{
				return null;
			}

			if (phoneNumber.StartsWith("+"))
			{
				// international
				// +44323456432234
				phoneNumber = "00" + phoneNumber.Substring(1);
			}

			string msisdn = new Regex("([^\\d]+)").Replace(phoneNumber, ""); 	// remove non-digits

			if (msisdn.StartsWith("00"))
			{
				// interanational 00385911234532
				msisdn = msisdn.Substring(2);
			}
			else if (msisdn.StartsWith("0"))
			{
				// national 09113423563
				msisdn = countryPrefix + msisdn.Substring(1);
			}
			else if (msisdn.Length >=  10 && msisdn.Length <= 14)
			{
				// intenacional number
				// 385911234234
				// 44323456432234
			}
			else
			{
				// invalid phone number
				return null;
			}

			if (string.IsNullOrEmpty(msisdn) || msisdn.Length < 8 || msisdn.Length > 14 || msisdn.StartsWith("000"))
			{
				return null;
			}

			if (msisdn.StartsWith(countryPrefix))
			{
				// if not international number with different prefix
				// remove zeros after countryPrefix, eg. 3850994356423
				msisdn = msisdn.Substring(countryPrefix.Length);
				while (msisdn.Length > 0 && msisdn.StartsWith("0"))
				{
					msisdn = msisdn.Substring(1);
				}
				// restore countryPrefix
				msisdn = countryPrefix + msisdn;
			}

			if (string.IsNullOrEmpty(msisdn) || msisdn.Length < 8 || msisdn.Length > 14 || msisdn.StartsWith("000"))
			{
				return null;
			}

			return (addPlusPrefix ? "+" :"") + msisdn;
		}

		static char[] separatorArr = new char[] { ',', ';' };

		/// <summary>
		/// Returns true if phone is in successfuly parsed. outputs eg. +38591333444, +38599666333
		/// </summary>
		/// <param name="inputStr"></param>
		/// <param name="parsedPhones"></param>
		/// <returns></returns>
		public static bool TryParsePhones(string inputStr, out string parsedPhones, string countryPrefix = "385", bool addPlusPrefix = false)
		{
			parsedPhones = null;

			inputStr = (inputStr ?? "").Trim();

			if (string.IsNullOrEmpty(inputStr))
			{
				return false;
			}

			var items = (inputStr ?? "")
				.Split(separatorArr)
				.Select(o => ConvertToMSISDN(o, countryPrefix, addPlusPrefix))
				.Where(o => !string.IsNullOrEmpty(o))
				.ToList();

			if (items.Any())
			{
				// ok
				parsedPhones = items.ToStringJoined(", ");
				return true;
			}

			return false;
		}

		/// <summary>
		/// Convert MSISDN to 091/333-5555. Multiple phones are separated by ','
		/// </summary>
		/// <param name="msisdn"></param>
		/// <param name="countryPrefix"></param>
		/// <param name="separator1"></param>
		/// <param name="separator2"></param>
		/// <returns></returns>
		public static string ConvertToPrettyFormat(string msisdn, string countryPrefix = "385", string separator1="/", string separator2="-")
		{
			if (msisdn == null || msisdn.Length < 10)
			{
				return msisdn;
			}

			string[] nums = msisdn.Split(separatorArr).Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o)).ToArray();
			if(nums.Length > 1)
			{
				return nums.Select(o => ConvertToPrettyFormat(o, countryPrefix, separator1, separator2)).ToStringJoined(", ");
			}

			if (msisdn.StartsWith("+"))
			{
				msisdn = msisdn.Substring(1);
			}

			string phone = "0" + msisdn.Substring(countryPrefix.Length);

			Regex re = null;

			if (countryPrefix == "385" && phone.StartsWith("01"))
			{
				re = new Regex("([\\d]{2})([\\d]{3})([\\d]+)");
			}
			else
			{
				re = new Regex("([\\d]{3})([\\d]{3})([\\d]+)");
			}
			return re.Replace(phone, "$1" + separator1 + "$2" + separator2 + "$3");
		}

		/// <summary>
		/// Add + in front of MSISDN, if doesn't exist.
		/// </summary>
		/// <param name="phoneNum">09xxx, or 385xxx or +385xx</param>
		/// <returns></returns>
		public static string CreatePlusMsisdn(string phoneNum, string countryPrefix = "385")
		{
			if (string.IsNullOrWhiteSpace(phoneNum)) return null;

			// remove non digits
			phoneNum = Regex.Replace(phoneNum, "[^\\d]+", "");

			if (phoneNum.StartsWith("00"))
			{
				phoneNum = phoneNum.Substring(2);
			}
			else if (phoneNum.StartsWith("0"))
			{
				phoneNum = countryPrefix + phoneNum.Substring(1);
			}

			if (phoneNum.StartsWith(countryPrefix) && (phoneNum.Length >= 8 && phoneNum.Length <= 14)) return "+" + phoneNum;

			// e.g. alphanumeric, "Missed-call-from"
			return phoneNum;
		}
	}
}
