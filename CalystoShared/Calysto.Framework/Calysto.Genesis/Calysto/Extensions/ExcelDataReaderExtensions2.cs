using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Calysto.Extensions
{
	/// <summary>
	/// Extension for ExcelDataReader & ExcelDataReader.DataSet
	/// </summary>
	internal static class ExcelDataReaderExtensions2
	{
		/// <summary>
		/// First row contains columns names.
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static DataSet AsDataSetWithColumns(this IExcelDataReader reader)
		{
			DataSet ds1 = reader.AsDataSet();

			// first row has column names
			for (int n1 = 0; n1 < ds1.Tables.Count; n1++)
			{
				DataTable dt1 = ds1.Tables[0];
				if (dt1.Rows.Count == 0)
					continue;

				if (!dt1.Rows[0].ItemArray.All(o => o is string))
					throw new Exception("First row doesn't contain string values");

				DataRow row = dt1.Rows[0];

				for (int n2 = 0; n2 < row.ItemArray.Length; n2++)
				{
					string name1 = row.ItemArray[n2] as string;
					if (!string.IsNullOrWhiteSpace(name1))
					{
						dt1.Columns[n2].ColumnName = name1;
					}
				}

				// remove headers row
				dt1.Rows.RemoveAt(0);

			}

			return ds1;
		}
	}
}
