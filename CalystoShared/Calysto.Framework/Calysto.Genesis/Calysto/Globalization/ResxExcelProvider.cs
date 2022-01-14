using Calysto.Linq;
using Calysto.Utility;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Calysto.Globalization
{
	public class ResxExcelProvider
	{
		#region static methods

		static Dictionary<Type, ResxExcelProvider> _diccache = new Dictionary<Type, ResxExcelProvider>();

		/// <summary>
		/// Get provider from <see cref="TResx"/> using reflection.
		/// </summary>
		/// <typeparam name="TResx"></typeparam>
		/// <returns></returns>
		public static ResxExcelProvider GetProviderFromResx<TResx>() where TResx : ICalystoResx
		{
			Type tt = typeof(TResx);
			if(!_diccache.TryGetValue(tt, out var res))
			{
				lock (_diccache)
				{
					if (!_diccache.TryGetValue(tt, out res))
					{
						res = (ResxExcelProvider)typeof(TResx).GetField(nameof(ResxExcelGenerator.ResourceProvider)).GetValue(null);
						_diccache.Add(tt, res);
					}
				}
			}
			return res;
		}

		static void RegisterProvider()
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
		}

		static ResxExcelProvider()
		{
			// By default, ExcelDataReader throws a NotSupportedException "No data is available for encoding 1252." on.NET Core.
			// To fix, add a dependency to the package System.Text.Encoding.CodePages and then add code to register the code page provider during application initialization(f.ex in Startup.cs):
			// System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			// This is required to parse strings in binary BIFF2-5 Excel documents encoded with DOS - era code pages. These encodings are registered by default in the full .NET Framework, but not on .NET Core.
			// must be in new function, this way dll will not be loaded at all if not net-core
			if (CalystoTools.IsDotNetCore)
			{
				RegisterProvider();
			}
		}

		public static ResxExcelProvider FromJson(string jsonTable)
		{
			ResxExcelProvider provider = new ResxExcelProvider();
			provider.Table = Calysto.Serialization.Json.JsonSerializer.Deserialize<DataTable>(jsonTable);
			return provider;
		}

		public static T FromJson<T>(string jsonTable) where T: ResxExcelProvider
		{
			T provider = CalystoActivator.CreateInstance<T>();
			provider.Table = Calysto.Serialization.Json.JsonSerializer.Deserialize<DataTable>(jsonTable);
			return provider;
		}

		#endregion

		#region excel file to dictionary

		// public properties for deserialization
		public class CellItem
		{
			public int RowIndex { get; set; }
			public int ColumnIndex { get; set; }
			public string ColumnName { get; set; }
			public string PropertyName { get; set; }
			public string CellValue { get; set; }
		}

		public DataTable Table { get; set; }

		Dictionary<string, DataRow> _dataRows;
		/// <summary>
		/// {Key: propertyName, Value: DataRow}
		/// </summary>
		public Dictionary<string, DataRow> DataRows => _dataRows ?? (_dataRows = this.Table.Rows.Cast<DataRow>().Distinct(o=>o[0]).ToDictionary(o => o[0] as string));

		/// <summary>
		/// Column 0: property names <br/>
		/// Column 1: default text <br/>
		/// Column 2, 3, 4, ... : additional translations
		/// </summary>
		public HashSet<string> Columns => new HashSet<string>(this.Table.Columns.Cast<DataColumn>().Select(o => o.ColumnName));

		///// <summary>
		///// Default column: if exists, use current culture name, else use column at index 1.
		///// 0: column with property names,
		///// 1: default column
		///// 2...: additional columns
		///// </summary>
		//public string DefaultColumn => this.Columns.Where(name=>name == CultureInfo.CurrentCulture.Name).FirstOrDefault() ?? this.Columns.Skip(1).First();

		/// <summary>
		/// For deserialization only.
		/// </summary>
		public ResxExcelProvider()
		{
		}

		public ResxExcelProvider(byte[] excelData)
		{
			var reader = ExcelReaderFactory.CreateReader(new MemoryStream(excelData));
			var ds = reader.AsDataSet();
			DataTable dt1 = ds.Tables[0];

			// create new table with column names from excel
			DataTable table = new DataTable();
			
			// columns from excel
			foreach (string colName in dt1.Rows[0].ItemArray.TakeWhile(o=>o is string str1 && !string.IsNullOrEmpty(str1)))
				table.Columns.Add(colName, typeof(string));

			int columnsCount = table.Columns.Count;

			// properties, skip first row which contains header with column names
			foreach (object[] rowArr in dt1.Rows.Cast<DataRow>().Skip(1).Select(o => o.ItemArray))
			{
				// skip empty properties (column index 0)
				if (!string.IsNullOrWhiteSpace(rowArr[0]?.ToString()))
					table.Rows.Add(rowArr.Take(columnsCount).ToArray());
			}

			this.Table = table;
		}

		/// <summary>
		/// Read all table cells.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CellItem> ReadTableCells()
		{
			return this.Table.Rows.Cast<DataRow>().SelectMany((row, rowIndex) =>
			{
				return row.ItemArray.Select((cellItem, columnIndex) => new CellItem()
				{
					RowIndex = rowIndex,
					ColumnIndex = columnIndex,
					ColumnName = this.Table.Columns.Cast<DataColumn>().Skip(columnIndex).First().ColumnName,
					PropertyName = row.ItemArray[0] as string,
					CellValue = cellItem as string,
				});
			}).ToList();
		}

		/// <summary>
		/// Try get non empty value.
		/// </summary>
		/// <param name="exceptionOnError"></param>
		/// <param name="propertyName"></param>
		/// <param name="searchColumnsOrder"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		private bool TryGetStringWorker(
			bool exeptionIfColumnNotFound,
			bool exceptionIfValueNotFound,
			string propertyName,
			IEnumerable<string> searchColumnsOrder,
			out string value)
		{
			value = null;

			if (this.DataRows.TryGetValue(propertyName, out DataRow row1))
			{
				foreach (string col1 in searchColumnsOrder)
				{
					if (!this.Table.Columns.Contains(col1))
					{
						if (exeptionIfColumnNotFound)
							throw new Exception($"Resx column {col1} doesn't exist.");
						else
							continue;
					}

					string str1 = row1[col1] as string;
					if (string.IsNullOrEmpty(str1))
						continue;
					else
					{
						value = str1;
						return true;
					}
				}

				if (exceptionIfValueNotFound)
					throw new Exception($"Resx property {propertyName} with cell {(string.Join("|", searchColumnsOrder))} not found.");
			}
			if (exceptionIfValueNotFound)
				throw new Exception($"Resx property {propertyName} not found.");
			else
				return false;
		}

		private IEnumerable<string> GetSearchColumns(IEnumerable<string> searchColumns = null)
		{
			if(searchColumns != null && searchColumns.Any())
			{
				// seach exact columns
				foreach (string col in searchColumns)
					yield return col;
			}
			else
			{
				// take value from column named as current culture name
				// if culture name column not found, than take from first available column which is default
				string cultureName = Thread.CurrentThread.CurrentCulture.Name;
				// da ne skace exception ako nemamo column name jednak cultureName-u
				if (this.Table.Columns.Contains(cultureName))
					yield return cultureName;

				string col1 = this.Table.Columns[1].ColumnName; // default column
				if (col1 != null)
					yield return col1;
			}
		}

		/// <summary>
		/// Get cell value for current culture name or use second excel text column as default.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public virtual string GetString(string propertyName)
		{
			this.TryGetStringWorker(true, false, propertyName, GetSearchColumns(), out string value);
			return value;
		}

		/// <summary>
		/// Get cell value
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		public string GetString(string propertyName, string columnName)
		{
			this.TryGetStringWorker(true, false, propertyName, GetSearchColumns(new string[] { columnName }), out string value);
			return value;
		}

		/// <summary>
		/// Get cell value. Search in columns in the same order as provided.
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="searchColumnsOrder">Search in columns as provided or all columns if argument is null.</param>
		/// <returns></returns>
		public string GetString(string propertyName, IEnumerable<string> searchColumnsOrder)
		{
			this.TryGetStringWorker(true, false, propertyName, GetSearchColumns(searchColumnsOrder), out string value);
			return value;
		}



		#endregion
	}
}
