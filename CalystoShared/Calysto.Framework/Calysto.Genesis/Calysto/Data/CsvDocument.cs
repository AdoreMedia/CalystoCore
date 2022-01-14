using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Calysto.Data
{
	public class CsvDocument
	{
		private static string CleanCellString(string s1)
		{
			// if we have """", or "some "" thing", we have to remove only the most outter quotes, so we can not use .Trim('\"') because it removes all chars
			if (s1.StartsWith("\"")) s1 = s1.Substring(1);
			if (s1.EndsWith("\"")) s1 = s1.Substring(0, s1.Length - 1);
			return s1;
		}

		private static List<string> ParseCsvLine(string csvLine, char delimiter = ',')
		{
			List<string> cels = new List<string>();
			StringBuilder sb = new StringBuilder();
			// whatever is inside quotes, it is protected from splitting by delimiter
			bool isInsideQuotes = false;
			foreach (char ch in csvLine)
			{
				if (ch == delimiter)
				{
					if (!isInsideQuotes)
					{
						// znaci, delimiter gledamo samo ako nije u navodicima, ako je u navodnicima, smatramo da je to normani char (text), a ne delimiter
						cels.Add(CleanCellString(sb.ToString()));
						sb = new StringBuilder();
						continue; // delimiter should not be added
					}
					else
					{
						// delimiter char, ignore it
					}
				}
				else if (ch == '\"')
				{
					// complete value has to be inside "...", and quote " inside text has to be converted into double quote: ""
					isInsideQuotes = !isInsideQuotes;
				}

				sb.Append(ch);
			}

			if(sb.Length > 0)
			{
				cels.Add(CleanCellString(sb.ToString()));
			}

			return cels;
		}

		private IEnumerable<List<string>> _rowsEnumerable;

		public IEnumerable<List<string>> SelectRows()
		{
			return _rowsEnumerable;
		}

		private IEnumerable<List<string>> ReadFileLines(string filePath, char delimiter=',')
		{
			StreamReader sr = new StreamReader(filePath);
			string txt;
			while (!sr.EndOfStream && (txt = sr.ReadLine()) != null)
			{
				yield return ParseCsvLine(txt, delimiter);
			}
		}

		/// <summary>
		/// Lazy file reader, read line by line on demand.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static CsvDocument FromCsvFile(string filePath, char delimiter = ',')
		{
			CsvDocument doc = new CsvDocument();
			doc._rowsEnumerable = doc.ReadFileLines(filePath, delimiter);
			return doc;
		}

		private IEnumerable<List<string>> ReadTextLines(string csvText, char delimiter = ',')
		{
			StringReader sr = new StringReader(csvText);
			string txt;
			while ((txt = sr.ReadLine()) != null)
			{
				yield return ParseCsvLine(txt, delimiter);
			}
		}

		/// <summary>
		/// Lazy string reader, read line by line on demand.
		/// </summary>
		/// <param name="csvText"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static CsvDocument FromCsvString(string csvText, char delimiter = ',')
		{
			CsvDocument doc = new CsvDocument();
			doc._rowsEnumerable = doc.ReadTextLines(csvText, delimiter);
			return doc;
		}

		private IEnumerable<List<string>> ReadDataTableImpl(DataTable dataTable, bool includeColumnsNames)
		{
			if (includeColumnsNames)
			{
				yield return (dataTable.Columns.Cast<DataColumn>().Select(o => o.ColumnName).ToList());
			}

			foreach(DataRow dr in dataTable.Rows.Cast<DataRow>())
			{
				yield return dr.ItemArray.Select(v1 => v1 + "").ToList();
			}
		}

		/// <summary>
		/// Lazy rows reader, read row by row on demand.
		/// </summary>
		/// <param name="dataTable"></param>
		/// <param name="includeColumnsNames"></param>
		/// <returns></returns>
		public static CsvDocument FromDataTable(DataTable dataTable, bool includeColumnsNames)
		{
			CsvDocument doc = new CsvDocument();
			doc._rowsEnumerable = doc.ReadDataTableImpl(dataTable, includeColumnsNames);
			return doc;
		}

		/// <summary>
		/// Return new CSVDocument instance with skip
		/// </summary>
		/// <param name="skip"></param>
		/// <returns></returns>
		public CsvDocument Skip(int skip)
		{
			if (skip < 0) throw new ArgumentOutOfRangeException(nameof(skip));
			CsvDocument doc2 = new CsvDocument();
			doc2._rowsEnumerable = this.SelectRows().Skip(skip);
			return doc2;
		}

		/// <summary>
		/// Return new CSVDocument instance with take
		/// </summary>
		/// <param name="take"></param>
		/// <returns></returns>
		public CsvDocument Take(int take)
		{
			if (take < 0) throw new ArgumentOutOfRangeException(nameof(take));
			CsvDocument doc2 = new CsvDocument();
			doc2._rowsEnumerable = this.SelectRows().Take(take);
			return doc2;
		}

		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable();
			bool hasColumns = false;
			int columnsCount = -1;
			foreach (var item in this.SelectRows())
			{
				if (!hasColumns)
				{
					hasColumns = true;
					columnsCount = item.Count;
					for (int n1 = 0; n1 < item.Count; n1++)
					{
						dt.Columns.Add();
					}
				}
				dt.Rows.Add(item.ToArray());
			}
			return dt;
		}

		public string ToCsvString(string delimiter = ",")
		{
			return string.Join("\r\n", this.SelectRows().Select(row => EncodeCsvLine(row, delimiter)));
		}

		public static string EncodeCsvLine(IEnumerable<object> cells, string delimiter = ",")
		{
			return string.Join(delimiter, cells.Select(val =>
			{
				string str = val + "";
				if (str.Contains(delimiter) || str.Contains("\""))
				{
					// complete value has to be inside "...", and quote " inside text has to be converted into double quote: ""
					return "\"" + str.Replace("\"", "\"\"") + "\"";
				}
				else
				{
					return str;
				}
			}));
		}
	}
}
