using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Utility
{
	public class HoroscopeHelper
	{
		public class ZodiacSign
		{
			public string Name;
			public string HrName;
			public DateTime StartDate;

			public ZodiacSign(string name, string hrName, DateTime start)
			{
				this.Name = name;
				this.HrName = hrName;
				this.StartDate = start;
			}
		}

		private static List<ZodiacSign> _signs = new List<ZodiacSign>(){
			new ZodiacSign("Capricorn", "Jarac", new DateTime(1999, 12, 22)),
			new ZodiacSign("Aquarius", "Vodenjak", new DateTime(2000, 1, 20)),
			new ZodiacSign("Pisces", "Ribe", new DateTime(2000, 2, 19)),
			new ZodiacSign("Aries", "Ovan", new DateTime(2000, 3, 21)),
			new ZodiacSign("Taurus", "Bik", new DateTime(2000, 4, 20)),
			new ZodiacSign("Gemini", "Blizanci", new DateTime(2000, 5, 21)),
			new ZodiacSign("Cancer", "Rak", new DateTime(2000, 6, 21)),
			new ZodiacSign("Leo", "Lav", new DateTime(2000, 7, 23)),
			new ZodiacSign("Virgo", "Djevica", new DateTime(2000, 8, 23)),
			new ZodiacSign("Libra", "Vaga", new DateTime(2000, 9, 23)),
			new ZodiacSign("Scorpio", "Škorpion", new DateTime(2000, 10, 23)),
			new ZodiacSign("Sagittarius", "Strijelac", new DateTime(2000, 11, 22)),
			new ZodiacSign("Capricorn", "Jarac", new DateTime(2000, 12, 22)),
			new ZodiacSign("Aquarius", "Vodenjak", new DateTime(2001, 1, 20)),
			new ZodiacSign("Pisces", "Ribe", new DateTime(2001, 2, 19)),
			new ZodiacSign("Aries", "Ovan", new DateTime(2001, 3, 21)),
		}.OrderByDescending(o => o.StartDate).ToList();

		public static ZodiacSign GetSignName(DateTime? birth)
		{
			if(birth == null)
			{
				return null;
			}
			DateTime dt = new DateTime(2000, birth.Value.Month, birth.Value.Day);
			// find first item
			return _signs.Where(o => dt >= o.StartDate).FirstOrDefault();
		}
	}
}
