using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Calysto.Data.DatabaseSchema
{
	public class SchemaReader
	{
		private DataTable _schemaTable;
		private HashSet<string> _columns;

		public SchemaReader(DataTable schemaTable)
		{
			_schemaTable = schemaTable;
		}

		public IEnumerable<SchemaColumn> ReadColumns()
		{ 
			if (_columns == null)
				_columns = new HashSet<string>(_schemaTable.Columns.Cast<DataColumn>().Select(o => o.ColumnName.ToLower()));

			foreach (var col in _schemaTable.Rows.Cast<DataRow>().Select(row => new SchemaColumn(_columns, row)))
			{
				yield return col;
			}
		}
	}
}