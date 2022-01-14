using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calysto.Utility
{
	public class CyrilicConverter
	{
		#region cyrilic to latin letters

		static string cyrilicToLatinLetters = @"
џ		dž
Џ		Dž
Џ		DŽ
њ		nj
Њ		Nj
Њ		NJ
љ		lj
Љ		Lj
Љ		LJ
њ		nj
Њ		NJ
Њ		Nj
љ		lj
Љ		Lj
Љ		LJ
џ		dž
Џ		Dž
Џ		DŽ
ђ		đ
Ђ		Đ
a		a
ш		š
ч		č
ћ		ć
ж		ž
ђ		đ
Ђ		Đ
б		b
ц		c
д		d
е		e
ф		f
г		g
х		h
и		i
ј		j
к		k
л		l
м		m
н		n
о		o
п		p
р		r
с		s
т		t
у		u
в		v
з		z
А		A
Ш		Š
Ч		Č
Ћ		Ć
Ж		Ž
Б		B
Ц		C
Д		D
Е		E
Ф		F
Г		G
Х		H
И		I
Ј		J
К		K
Л		L
М		M
Н		N
О		O
П		P
Р		R
С		S
Т		T
У		U
В		V
З		Z

";
		#endregion

		static List<string> latinList = new List<string>();
		static List<string> cyrilicList = new List<string>();

		static CyrilicConverter()
		{ 
			// ne moze se koristiti dictionary jer imam ista slova sa drugim page codeom

			MatchCollection matches = new Regex("(?<cyrilic>[\\w]+)[\\s]+(?<latin>[\\w]+)[\\r\\n]+").Matches(cyrilicToLatinLetters);
			foreach (Match m in matches)
			{
				cyrilicList.Add(m.Groups[1].Value);
				latinList.Add(m.Groups[2].Value);
			}
		}

		public CyrilicConverter()
		{

		}
		
		#region Cyrilic to Latin

		private string GetNextCyrilicToLatin(IEnumerator<char> cyrilicEnumerator)
		{
			if (cyrilicEnumerator.MoveNext())
			{
				int index = cyrilicList.IndexOf(cyrilicEnumerator.Current.ToString());
				if(index >= 0)
					return latinList[index];
				else
					return cyrilicEnumerator.Current.ToString();
			}
			else
				return null;
		}

		public IEnumerable<string> GetLatinLetters(string cirilica)
		{
			if (string.IsNullOrEmpty(cirilica))
			{
				yield break;
			}

			var en1 = cirilica.AsEnumerable().GetEnumerator();
			string current = this.GetNextCyrilicToLatin(en1);
			string next = this.GetNextCyrilicToLatin(en1);

			while (current != null)
			{
				if (current.Length == 2 && char.IsUpper(current.First()))
				{
					if (next != null)
					{
						if (char.IsUpper(next.First()))
						{
							// current mora biti uppercased, oba slova LJ, NJ, DŽ
							yield return current.ToUpper();
						}
						else
						{
							// vrati as-is
							yield return current;
						}
					}
				}
				else
				{
					// vrati as-is
					yield return current;
				}

				// get next
				current = next;
				next = this.GetNextCyrilicToLatin(en1);
			}
		}

		public string ConvertToLatin(string cirilica)
		{
			return this.GetLatinLetters(cirilica).ToStringJoined();
		}

		#endregion

		#region Latin to Cyrilic

		private char? GetNextLatinChar(IEnumerator<char> latinEnumerator)
		{
			if (latinEnumerator.MoveNext())
			{
				return latinEnumerator.Current;
			}
			else
				return null;
		}

		private IEnumerable<char> GetCyrilicLetters(string latinica)
		{
			if (string.IsNullOrEmpty(latinica))
			{
				yield break;
			}

			var en1 = latinica.AsEnumerable().GetEnumerator();
			char? current = this.GetNextLatinChar(en1);
			char? next1 = this.GetNextLatinChar(en1);

			while(current != null)
			{
				if ((current == 'L' || current == 'l') && (next1 == 'j' || next1 == 'J'))
				{
					yield return char.IsUpper(current.Value) ? 'Љ' : 'љ';
					next1 = this.GetNextLatinChar(en1);
				}
				else if((current == 'N' || current == 'n') && (next1 == 'j' || next1 == 'J'))
				{
					yield return char.IsUpper(current.Value) ? 'Њ' : 'њ';
					next1 = this.GetNextLatinChar(en1);
				}
				else if((current == 'D' || current == 'd') && (next1 == 'ž' || next1 == 'Ž'))
				{
					yield return char.IsUpper(current.Value) ? 'Џ' : 'џ';
					next1 = this.GetNextLatinChar(en1);
				}
				else
				{
					int index = latinList.IndexOf(current.ToString());
					if (index >= 0)
						yield return cyrilicList[index].First();
					else
						yield return current.Value;
				}

				// get next
				current = next1;
				next1 = this.GetNextLatinChar(en1);
			}
		}

		public string ConvertToCyrilic(string latinica)
		{
			return this.GetCyrilicLetters(latinica).ToStringJoined();
		}

		#endregion
	}
}