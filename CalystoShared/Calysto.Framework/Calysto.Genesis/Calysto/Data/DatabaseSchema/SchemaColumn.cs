using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Calysto.Data.DatabaseSchema
{
	public class SchemaColumn
	{
		public string ColumnName { get { return GetValue<string>(nameof(ColumnName)); } }
		public int ColumnOrdinal { get { return GetValue<int>(nameof(ColumnOrdinal)); } }
		public int ColumnSize { get { return GetValue<int>(nameof(ColumnSize)); } }
		public short NumericPrecision { get { return GetValue<short>(nameof(NumericPrecision)); } }
		public short NumericScale { get { return GetValue<short>(nameof(NumericScale)); } }
		public bool IsUnique { get { return GetValue<bool>(nameof(IsUnique)); } }
		public bool IsKey { get { return GetValue<bool>(nameof(IsKey)); } }
		public string BaseServerName { get { return GetValue<string>(nameof(BaseServerName)); } }
		public string BaseCatalogName { get { return GetValue<string>(nameof(BaseCatalogName)); } }
		public string BaseColumnName { get { return GetValue<string>(nameof(BaseColumnName)); } }
		public string BaseSchemaName { get { return GetValue<string>(nameof(BaseSchemaName)); } }
		public string BaseTableName { get { return GetValue<string>(nameof(BaseTableName)); } }
		public Type DataType { get { return GetValue<Type>(nameof(DataType)); } }
		public bool AllowDBNull { get { return GetValue<bool>(nameof(AllowDBNull)); } }
		public int ProviderType { get { return GetValue<int>(nameof(ProviderType)); } }
		public bool IsIdentity { get { return GetValue<bool>(nameof(IsIdentity)); } }
		public bool IsAliased { get { return GetValue<bool>(nameof(IsAliased)); } }
		public bool IsExpression { get { return GetValue<bool>(nameof(IsExpression)); } }
		public bool IsHidden { get { return GetValue<bool>(nameof(IsHidden)); } }
		public bool IsAutoIncrement { get { return GetValue<bool>(nameof(IsAutoIncrement)); } }
		public bool IsRowVersion { get { return GetValue<bool>(nameof(IsRowVersion)); } }
		public bool IsLong { get { return GetValue<bool>(nameof(IsLong)); } }
		public bool IsReadOnly { get { return GetValue<bool>(nameof(IsReadOnly)); } }
		public Type ProviderSpecificDataType { get { return GetValue<Type>(nameof(ProviderSpecificDataType)); } }
		public string DataTypeName { get { return GetValue<string>(nameof(DataTypeName)); } }
		public int NonVersionedProviderType { get { return GetValue<int>(nameof(NonVersionedProviderType)); } }
		public bool IsColumnSet { get { return GetValue<bool>(nameof(IsColumnSet)); } }
		public string XmlSchemaCollectionDatabase { get { return GetValue<string>(nameof(XmlSchemaCollectionDatabase)); } }
		public string XmlSchemaCollectionOwningSchema { get { return GetValue<string>(nameof(XmlSchemaCollectionOwningSchema)); } }
		public string XmlSchemaCollectionName { get { return GetValue<string>(nameof(XmlSchemaCollectionName)); } }
		public string UdtAssemblyQualifiedName { get { return GetValue<string>(nameof(UdtAssemblyQualifiedName)); } }

		private DataRow _dr;
		private HashSet<string> _columns;

		private TResult GetValue<TResult>(string colName)
		{
			if (!_columns.Contains(colName.ToLower()))
				return default(TResult);

			var val = _dr[colName];
			if (val == null || val == DBNull.Value)
				return default(TResult);
			else
				return (TResult)val;
		}

		public SchemaColumn(HashSet<string> columns, DataRow dr)
		{
			_dr = dr;
			_columns = columns;
		}
	}
}
