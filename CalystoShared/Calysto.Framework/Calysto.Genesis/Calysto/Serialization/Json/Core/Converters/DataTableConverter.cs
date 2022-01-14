#if !SILVERLIGHT

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Calysto.Linq;
using Calysto.Serialization.Json.Core.Serialization;
using System.Text;

namespace Calysto.Serialization.Json.Core.Converters
{
	internal class DataTableConverter : IJavaScriptConverter
	{
		const string __calystotype = "Calysto_DataTable";

		ObjectConverter _converter = new ObjectConverter();

		private object Convert(object obj, SerializerOptions options)
		{
			IDictionary<string, object> dictionary = (IDictionary<string, object>)obj;

			List<string> columns = JsonSerializer.ConvertToType<List<string>>(dictionary["Columns"]);
			List<object[]> rows = JsonSerializer.ConvertToType<List<object[]>>(dictionary["Rows"]);

			DataTable dataTable = new DataTable();

			var dataItems = rows.FirstOrDefault();
			int index = -1;
			foreach(string colName in columns)
			{
				Type celltype = dataItems?[++index]?.GetType();
				if (dataItems == null || celltype == null)
					dataTable.Columns.Add(colName);
				else
					dataTable.Columns.Add(colName, celltype);
			}

			rows.ForEach((rowItemsArray) => dataTable.Rows.Add(rowItemsArray));

			dataTable.TableName = dictionary.GetValueOrDefault("TableName") as string;

			int totalCount;
			if (int.TryParse(dictionary.GetValueOrDefault("TotalCount") + "", out totalCount))
			{
				dataTable.ExtendedProperties["TotalCount"] = totalCount;
			}

			return dataTable;
		}

		public bool TryConvert(object obj, Type toType, SerializerOptions options, out object result)
		{
			// always search for __calystotype key
			// don't use toType == typeof(DataTable) because toType may be Object

			if (obj is IDictionary<string, object> dic)
			{
				if (dic.TryGetValue("__calystotype", out var key) && object.Equals(key, __calystotype))
				{

					result = Convert(obj, options);
					return true;
				}
			}
			
			result = null;
			return false;
		}

		public bool TrySerialize(object obj, StringBuilder sb, SerializerOptions options)
		{
			if (obj?.GetType() != typeof(DataTable))
				return false;

			DataTable dt = (DataTable)obj;

			int? totalCount = null;
			if (dt.ExtendedProperties.Contains("TotalCount"))
			{
				// if using data paging, TotalCount is total count of items, while dt.Rows.Count() is currently loaded number of items
				totalCount = System.Convert.ToInt32(dt.ExtendedProperties["TotalCount"]);
			}

			string json1 = JsonSerializer.Serialize(new
			{
				__calystotype = __calystotype,
				TotalCount = totalCount,
				TableName = dt.TableName,
				Columns = dt.Columns.Cast<DataColumn>().Select(o => o.ColumnName).ToArray(),
				Rows = dt.Rows.Cast<DataRow>().Select(o => o.ItemArray).ToArray()
			});
			sb.Append(json1);

			return true;
		}
	}

}
#endif
