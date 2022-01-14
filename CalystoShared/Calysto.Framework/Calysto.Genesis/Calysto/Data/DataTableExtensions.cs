using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Calysto.Data
{
	public class DataTableCell : MatrixCell
	{
		public DataTable Table { get; set; }
		public DataColumn Column { get; set; }
	}

	public static class DataTableExtensions
	{
		public static IEnumerable<KeyValuePair<string, object>> ReadDataRow(this DataRow row)
		{
			return row.ItemArray.Select((item, index) => new KeyValuePair<string, object>(row.Table.Columns[index].ColumnName, item));
		}

		/// <summary>
		/// Return first row and columns one by one, then next row and columns one by one... 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static IEnumerable<DataTableCell> SelectCellsByRows(this DataTable table)
		{
			Dictionary<int, DataColumn> dic = table.Columns.Cast<DataColumn>().ToDictionary(column => column.Ordinal);

			return table.Rows.Cast<DataRow>().SelectMany((dataRow, rowIndex) =>
			{
				return dataRow.ItemArray.Select((value, colIndex)=>
				{
					return new DataTableCell()
					{
						Table = table,
						Column = dic[colIndex],
						ColumnName = dic[colIndex].ColumnName,
						ColumnIndex = colIndex,
						DataType = dic[colIndex].DataType,
						RowIndex = rowIndex,
						CellValue = value
					};
				});
			});
		}

		/// <summary>
		/// Return first column and rows one by one, then next column and rows one by one... 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static IEnumerable<DataTableCell> SelectCellsByColumns(this DataTable table)
		{
			var cols = table.Columns.Cast<DataColumn>().Select((col, index) => new {
				Index = index,
				Column = col
			}).ToList();

			return cols.SelectMany(col =>
			{
				return table.Rows.Cast<DataRow>().Select((dataRow, rowIndex) =>
				{
					return new DataTableCell()
					{
						Table = table,
						Column = col.Column,
						ColumnName = col.Column.ColumnName,
						ColumnIndex = col.Index,
						DataType = col.Column.DataType,
						RowIndex = rowIndex,
						CellValue = dataRow[col.Index]
					};
				});
			});
		}

		/// <summary>
		/// Translate DataTable to enumerable collection of objects.
		/// TResult is class representing single data row.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="dataTable"></param>
		/// <returns></returns>
		public static IEnumerable<TResult> Translate<TResult>(this DataTable dataTable)
		{
			return new DataTranslator<TResult>(dataTable).Translate();
		}

		public static IEnumerable<string> GetCSVLines(this DataTable dataTable, bool includeColumnsNames, string delimiter = ",")
		{
			if (includeColumnsNames)
			{
				yield return CsvDocument.EncodeCsvLine(dataTable.Columns.Cast<DataColumn>().Select(o => o.ColumnName), delimiter);
			}

			foreach(var row in dataTable.Rows.Cast<DataRow>())
			{
				yield return CsvDocument.EncodeCsvLine(row.ItemArray, delimiter);
			}
		}

		public static string ToCSV(this DataTable dataTable, bool includeColumnsNames, string delimiter = ",")
		{
			StringBuilder sb = new StringBuilder();
			
			foreach (var item in dataTable.GetCSVLines(includeColumnsNames, delimiter))
				sb.AppendLine(item);

			return sb.ToString();
		}

		/// <summary>
		/// Return each DataRow as Dictionary
		/// </summary>
		/// <param name="dataTable"></param>
		/// <returns></returns>
		public static IEnumerable<Dictionary<string, object>> ToDictionaries(this DataTable dataTable)
		{
			var columns = dataTable.Columns.Cast<DataColumn>().Select(o => o.ColumnName).ToList();
			return dataTable.Rows.Cast<DataRow>().Select(row =>
			{
				var dic = new Dictionary<string, object>();
				int index = -1;

				foreach (string col1 in columns)
					dic.Add(col1, Calysto.Utility.CalystoTypeConverter.ChangeType<object>(row.ItemArray[++index])); // conver DBNull to null

				return dic;
			});
		}

	}
}
