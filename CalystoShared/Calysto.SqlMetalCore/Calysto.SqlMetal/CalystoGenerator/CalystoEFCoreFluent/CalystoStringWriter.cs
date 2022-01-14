using System.IO;
using System.Linq;

namespace Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent
{
	class CalystoStringWriter : StringWriter
	{
		public int Indent;

		private string GetIndent(int cnt)
		{
			string str = "";
			for (int n = 0; n < cnt; n++)
			{
				str += "	";
			}
			return str;
		}

		public void WriteIndent()
		{
			base.Write(GetIndent(this.Indent));
		}
		
		/// <summary>
		/// Split text by lines and write each line with current indent using WriteLine(...) adding line terminator to each line.
		/// </summary>
		/// <param name="str"></param>
		public void WriteBlockLine(string str)
		{
			// ubaciti indent ispred svake linije
			foreach (string s1 in str.Replace("\r\n", "\n").Split('\n').Select(o => GetIndent(this.Indent) + o))
			{
				base.WriteLine(s1);
			}
		}
	}

}
