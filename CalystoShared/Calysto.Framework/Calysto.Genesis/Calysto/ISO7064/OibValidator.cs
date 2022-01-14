using Calysto.Common;
using System;

namespace Calysto.ISO7064
{
	public class OibValidator
	{
		/// <summary>
		/// Test last digit signature. Lenth is not tested.
		/// </summary>
		/// <param name="OIB"></param>
		/// <returns></returns>
		public static bool IsOIBValid(string OIB)
		{
			if (OIB?.Length != 11)
				return false;

			// last digit is signature
			string s1 = OIB.Remove(OIB.Length - 1);
			return CheckDigits.CalculateNumericCheckDigit(s1, false) == OIB; //MOD 11,10
		}

		/// <summary>
		/// Accepts OIB without last digit, of ay length, calculate last digit, and return complete OIB with signature.
		/// </summary>
		/// <param name="oibPart"></param>
		/// <returns></returns>
		public static string SignOIB(string oibPart)
		{
			if (oibPart?.Length != 10)
				throw new ArgumentNullException();

			return CheckDigits.CalculateNumericCheckDigit(oibPart, false); //MOD 11,10
		}

		/// <summary>
		/// Genereate new OIB with signature. If prefix is set, will use it and append the rest of digits.
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GenerateOIB(string prefix, int finalLength = 11)
		{
			CalystoRandom rnd1 = new CalystoRandom();
			string str1 = prefix + ""; // nek koristi dio oiba koji vec imamo upisan
			while (str1.Length < finalLength)
			{
				str1 += rnd1.Next(1000000, 9000000).ToString();
			}

			string oib1 = str1.Substring(0, finalLength - 1);

			string signedOib = SignOIB(oib1);

			if (!IsOIBValid(signedOib))
				throw new Exception("Generirani OIB nije ispravan: " + signedOib);
			
			return signedOib;
		}

	}
}
