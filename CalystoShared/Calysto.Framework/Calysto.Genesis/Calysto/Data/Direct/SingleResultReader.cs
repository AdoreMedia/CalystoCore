using Calysto.Data.DatabaseSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Calysto.Data.Direct
{
	public class SingleResultReader
	{
		DbDataReader _reader;
		bool _invokeNextResult;

		public SingleResultReader(DbDataReader reader)
		{
			this._reader = reader;
		}

		private bool InvokeNextResult()
		{
			if (_invokeNextResult)
				_reader.NextResult();

			_invokeNextResult = true;

			if (_reader.FieldCount == 0)
			{
				// no more recordsets
				return false;
			}

			return true;
		}

		private static IEnumerable<object[]> GetDataRows(DbDataReader reader)
		{
			while (reader.Read())
			{
				object[] vals = new object[reader.FieldCount];
				reader.GetValues(vals);
				yield return vals;
			}
		}

		public DataTable GetDataTable()
		{
			if (!this.InvokeNextResult())
				return null; // no more recordsets

			DataTable table = new DataTable();
			SchemaReader schemaReader = new SchemaReader(_reader.GetSchemaTable());
			// add columns to table
			schemaReader.ReadColumns().ToList().ForEach(col => table.Columns.Add(col.ColumnName, col.DataType));
			// add data to table
			while (_reader.Read())
			{
				object[] vals = new object[_reader.FieldCount];
				_reader.GetValues(vals);
				table.Rows.Add(vals);
			}
			return table;
		}

		/// <summary>
		/// <para>Get next result from an open reader, create and return enumerable data translator.</para>
		/// </summary>
		/// <typeparam name="TElement"></typeparam>
		/// <returns></returns>
		public IEnumerable<TElement> GetSequence<TElement>()
		{
			if (!this.InvokeNextResult())
				return null; // no more recordsets

			// Translate() returns enumerable. To read actual rows, invoke ToList() or First() etc.
			return new DataTranslator<TElement>(_reader).Translate();
		}
	}
}