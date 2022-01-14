using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Calysto.Web.UI
{
	/// <summary>
	/// Build html table from collection or DataTable.
	/// </summary>
	public class HtmlTableBuilder
	{
		public virtual string GetCellStyle(string columnName, object value)
		{
			return null;
		}

		public virtual string GetColumnName(string columnName)
		{
			return columnName;
		}

		public virtual string GetCellValue(string columnName, object value)
		{
			if (value is Decimal)
				return ((Decimal)value).ToString("n2");

			if (value is Double)
				return ((Double)value).ToString("n2");

			if (value is Int16)
				return ((Int16)value).ToString("n0");

			if (value is Int32)
				return ((Int32)value).ToString("n0");

			if (value is Int64)
				return ((Int64)value).ToString("n0");

			return value + "";
		}

		private string GetTableStart() => "<table class=\"calystoTable1\">\r\n";
		private string GetTableEnd() => "</table>";

		private IEnumerable<string> GetHeader(string[] names)
		{
			yield return "<tr class=\"thead\">";
			foreach (string p in names)
			{
				yield return "<td class=\"theadItem\" style=\"" + this.GetCellStyle(p, null) + "\">" + HttpUtility.HtmlEncode(this.GetColumnName(p)) + "</td>";
			}
			yield return "</tr>\r\n";
		}

		private string GetRowStart() => "<tr class=\"trow\">";
		private string GetRowEnd() => "</tr>\r\n";
		private string GetRowCellValue(string columnName, object cellValue) => "<td class=\"trowItem\" style=\"" + this.GetCellStyle(columnName, cellValue) + "\">" + HttpUtility.HtmlEncode(this.GetCellValue(columnName, cellValue)) + "</td>";

		private IEnumerable<string> GenerateHtmlTableWorker<Titem>(IEnumerable<Titem> items)
		{
			var props = typeof(Titem).GetProperties();

			// table start
			yield return this.GetTableStart();

			// header items
			foreach (var hitem in this.GetHeader(props.Select(p => p.Name).ToArray()))
			{
				yield return hitem;
			}

			// rows
			foreach (var item in items)
			{
				yield return this.GetRowStart();
				foreach (var p in props)
				{
					yield return this.GetRowCellValue(p.Name, p.GetValue(item));
				}
				yield return this.GetRowEnd();
			}

			// table end
			yield return this.GetTableEnd();
		}

		public string GenerateHtmlTable<Titem>(IEnumerable<Titem> items)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var row in this.GenerateHtmlTableWorker(items))
			{
				sb.Append(row);
			}
			return sb.ToString();
		}

		private IEnumerable<string> GenerateHtmlTableWorker(DataTable table)
		{
			var cols = table.Columns.Cast<DataColumn>().Select(o => o.ColumnName).ToArray();

			// table start
			yield return this.GetTableStart();

			// header items
			foreach (var hitem in this.GetHeader(cols))
			{
				yield return hitem;
			}

			// rows
			foreach (var row in table.Rows.Cast<DataRow>())
			{
				yield return this.GetRowStart();
				object[] itemArr = row.ItemArray;
				for(int n1 = 0; n1 < itemArr.Length; n1++)
				{
					yield return this.GetRowCellValue(table.Columns[n1].ColumnName, itemArr[n1]);
				}
				yield return this.GetRowEnd();
			}

			// table end
			yield return this.GetTableEnd();
		}

		public string GenerateHtmlTable(DataTable table)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var row in this.GenerateHtmlTableWorker(table))
			{
				sb.Append(row);
			}
			return sb.ToString();
		}
	}
}