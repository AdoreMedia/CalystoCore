using Calysto.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

/******************************************************
 * Port from project JSTools_Serbian_MB_PIB_JMBG
 * https://github.com/draganjovanovic1/JSTools.git 
******************************************************/
namespace Calysto.ISO7064
{
	public class SerbianValidator
	{
		#region PIB tools

		/// <summary>
		/// Test last digit signature. <br/>
		/// Works with: <br/>
		/// Serbian PIB (9 chars) <br/>
		/// HR MBS (firma) (9 chars) <br/>
		/// HR MBO (obrt) (8 chars) <br/>
		/// </summary>
		/// <param name="pibComplete"></param>
		/// <param name="pibLength">PIB length</param>
		/// <returns></returns>
		public static bool IsPIBValid(string pibComplete, int pibLength = 9)
		{
			if (pibComplete?.Length != pibLength)
				return false;

			// last digit is signature
			string s1 = pibComplete.Remove(pibComplete.Length - 1);

			// PibChecksum() ne racuna dobro
			//string s2 = PibChecksum(s1, pibLength - 1);
			//return pibComplete[pibComplete.Length - 1] + "" == s2;

			// moze se i ovako generirati:
			return CheckDigits.CalculateNumericCheckDigit(s1, false) == pibComplete; //MOD 11,10
		}

		/// <summary>
		/// Accepts PIB without last digit, of ay length, calculate last digit, and return complete PIB with signature.
		/// </summary>
		/// <param name="oibPart"></param>
		/// <param name="pibLength">PIB length</param>
		/// <returns></returns>
		public static string SignPIB(string pibPrefix, int pibLength = 9)
		{
			if (pibPrefix?.Length != (pibLength - 1))
				throw new ArgumentNullException();

			// PibChecksum() ne racuna dobro
			//string s2 = PibChecksum(pibPrefix, pibLength - 1);
			//return pibPrefix + s2;

			// moze se i ovako generirati:
			return CheckDigits.CalculateNumericCheckDigit(pibPrefix, false); //MOD 11,10
		}

		/// <summary>
		/// Genereate new OIB with signature. If prefix is set, will use it and append the rest of digits.
		/// </summary>
		/// <param name="pibPrefix"></param>
		/// <returns></returns>
		public static string GeneratePIB(string pibPrefix, int pibLength = 9)
		{
			CalystoRandom rnd1 = new CalystoRandom();
			string str1 = pibPrefix + ""; // nek koristi dio oiba koji vec imamo upisan
			while (str1.Length < pibLength)
			{
				str1 += rnd1.Next(1000000, 9000000).ToString();
			}

			string oib1 = str1.Substring(0, pibLength - 1);

			string signedPib = SignPIB(oib1);

			if (!IsPIBValid(signedPib))
				throw new Exception("Generirani PIB nije ispravan: " + signedPib);

			return signedPib;
		}

		#endregion

		#region Company Maticni Broj

		/// <summary>
		/// Serbian Maticni Broj privrednika (firme i preduzetnici)
		/// </summary>
		/// <param name="mb"></param>
		/// <returns></returns>
		public static bool IsCompanyMBValid(string mb)
		{
			if (mb?.Length != 8)
				return false;

			// last digit is signature
			string s1 = mb.Remove(mb.Length - 1);
			string s2 = Mod11Checksum(s1, kb => kb > 9 ? 0 : kb);
			return mb.Substring(mb.Length - 1, 1) == s2;
		}

		/// <summary>
		/// Serbian Maticni Broj privrednika (firme i preduzetnici)
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string SignCompanyMB(string prefix)
		{
			if (prefix?.Length != 7)
				throw new ArgumentNullException();

			string s2 = Mod11Checksum(prefix, kb => kb > 9 ? 0 : kb);
			return prefix + s2;
		}

		/// <summary>
		/// Serbian Maticni Broj privrednika (firme i preduzetnici)
		/// </summary>
		/// <param name="prefix"></param>
		/// <param name="finalLength"></param>
		/// <returns></returns>
		public static string GenerateCompanyMB(string prefix, int finalLength = 8)
		{
			CalystoRandom rnd1 = new CalystoRandom();
			string str1 = prefix + ""; // nek koristi dio oiba koji vec imamo upisan
			while (str1.Length < finalLength)
			{
				str1 += rnd1.Next(1000000, 9000000).ToString();
			}

			string oib1 = str1.Substring(0, finalLength - 1);

			string signedMb = SignCompanyMB(oib1);

			if (!IsCompanyMBValid(signedMb))
				throw new Exception("Generirani MB nije ispravan: " + signedMb);

			return signedMb;
		}

		#endregion

		#region utility functions

		// ovo ne racuna dobro (unittestovi ne prolaze, a imam prave PIB-ove skinute za prave firme)
		//private static string PibChecksum(string pib, int length = 9)
		//{
		//	int suma = 10;
		//	for(int n = 0; n < (length - 1); n++)
		//	{
		//		suma = (suma + int.Parse(pib[n] + "")) % 10;
		//		Trace.WriteLine(suma);
		//		suma = (suma == 0 ? 10 : suma) * 2 % 11;
		//		Trace.WriteLine(suma);
		//	}
		//	suma = (11 - suma) % 10;
		//	Trace.WriteLine(suma);
		//	return suma + "";
		//}

		private static string Mod11Checksum(string br, Func<int, int> fnUvjet = null)
		{
			int kb = 0;
			int mnozilac = 2;
			for(int n = br.Length - 1; n >= 0; n--)
			{
				kb += int.Parse(br[n]+"") * mnozilac; // have to parse string, not char, if converting char to int, will cast char to int which is invalid
				mnozilac = mnozilac == 7 ? 2 : (mnozilac + 1);
			}
			kb = 11 - (kb % 11);
			if (fnUvjet == null)
				return kb + "";
			else
				return fnUvjet.Invoke(kb) + "";
		}

		#endregion

	}
}
