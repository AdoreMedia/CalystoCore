using Calysto.Common;
using Calysto.Common.Extensions;
using System;
using System.Text;

namespace Calysto.Utility
{
	public class CalystoGenerators
	{
		const string _smallLetters = "abcdefghijklmnopqrstuvwxyz";

		const string _capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		const string _nums = "0123456789";

		const string _special = @"!@#$%^&*()_+=-~/\][><.,?>:;'\}{";

		static CalystoRandom _random1 = new CalystoRandom();

		private static string GetRndCharsFromTable(string table, int finalLength)
		{
			if (!(finalLength > 0))
				throw new Exception("Invalid finalLength");

			int tlen = table.Length;

			if (!(tlen > 0))
				throw new Exception("Invalid table length");

			StringBuilder sb1 = new StringBuilder();

			while (tlen > 0 && sb1.Length < finalLength)
			{
				sb1.Append(table[(int)Math.Floor(_random1.UsingLock(a=>a.NextDouble()) * tlen)]);
			}
			return sb1.ToString();
		}

		private static string GetRndChars(int finalLength, bool letterFirst, bool smallLetters, bool capitalLetters, bool numbers, bool specialChars)
		{
			StringBuilder sb1 = new StringBuilder();

			string table = "";

			if (letterFirst)
				sb1.Append(GetRndCharsFromTable(_smallLetters + _capitalLetters, 1));

			if (smallLetters)
				table += _smallLetters;

			if (capitalLetters)
				table += _capitalLetters;

			if (numbers)
				table += _nums;

			if (specialChars)
				table += _special;

			sb1.Append(GetRndCharsFromTable(table, finalLength));

			return sb1.ToString();
		}

		/// <summary>
		/// Generate alpha-numeric password. 
		/// Always starts with letter, contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GeneratePassword(int length)
		{
			return GetRndChars(length, true, true, true, true, false);
		}

		/// <summary>
		/// Generate alpha-numeric label. 
		/// Always starts with letter, contains lowercased letters, uppercased letters, and digits, may be used as label of element name.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateLabel(int length)
		{
			return GetRndChars(length, true, true, true, true, false);
		}

		/// <summary>
		/// Generate new strong random password. 
		/// Contains lowercased letters, uppercased letters, digits and special chars.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateStrongPassword(int length)
		{
			return GetRndChars(length, false, true, true, true, true);
		}

		/// <summary>
		/// Generate new numeric password.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateNumericPassword(int length)
		{
			return GetRndCharsFromTable(_nums, length);
		}

	}
}
