using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Calysto.Data.DatabaseSchema;
using Calysto.Utility;

namespace Calysto.Data
{
	public class DataTranslator : IDisposable
	{
		Dictionary<string, CalystoColumnInfo> _dicColumnsByName;
		Dictionary<string, CalystoColumnInfo> _dicColumnsByLowercaseName;
		Dictionary<int, CalystoColumnInfo> _dicColumnsByIndex;
		Type _resultType;
		List<SchemaColumn> _columns;
		protected Func<IEnumerable<SchemaColumn>> _getColumnsEnumerable;
		protected Func<IEnumerable<object[]>> _getDataRowsEnumerable;

		////public DataTranslator(Type resultType, IEnumerable<SchemaColumn> columns, IEnumerable<object[]> rows)
		////{
		////	this._resultType = resultType;
		////	this._columns = columns;
		////	this._dataRows = rows;
		////}

		private IEnumerable<object[]> ReadDataRows(DbDataReader reader)
		{
			while (reader.Read())
			{
				object[] vals = new object[reader.FieldCount];
				reader.GetValues(vals);
				yield return vals;
			}
		}

		public DataTranslator(Type resultType, DbDataReader reader)
		{
			this._resultType = resultType;
			this._getColumnsEnumerable = () => new SchemaReader(reader.GetSchemaTable()).ReadColumns();
			this._getDataRowsEnumerable = () => ReadDataRows(reader);
		}

		public DataTranslator(Type resultType, DataTable table) : this(resultType, table.CreateDataReader())
		{
		}

		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			this.IsDisposed = true;
		}

		~DataTranslator()
		{
			Dispose();
		}

		////private bool ContainsColumn(string name)
		////{
		////	return _dicColumnsByName.ContainsKey(name) || _dicColumnsByLowercaseName.ContainsKey(name.ToLower());
		////}

		private CalystoColumnInfo GetColumnInfo(string name, bool throwExceptionIfNotFound)
		{
			CalystoColumnInfo colinfo;
			if (_dicColumnsByName.TryGetValue(name, out colinfo))
			{
				return colinfo;
			}
			else if (_dicColumnsByLowercaseName.TryGetValue(name.ToLower(), out colinfo))
			{
				return colinfo;
			}
			if (throwExceptionIfNotFound)
			{
				throw new Exception("Column " + name + " not found");
			}
			return new CalystoColumnInfo() { ColumnOrdinal = -1 };
		}

		private CalystoColumnInfo GetColumnInfo(int index)
		{
			CalystoColumnInfo colinfo;
			_dicColumnsByIndex.TryGetValue(index, out colinfo);
			return colinfo;
		}

		private class CalystoColumnInfo
		{
			public int ColumnOrdinal;
			public string ColumnName;
			public Type DataType;
		}

		private class CalystoMemberInfo
		{
			public string Name;
			public MemberInfo Member;
			public Type MemberType;
			public int ColumnIndex;
		}

		private void EnsureColumnsInfo()
		{
			if (_dicColumnsByName != null)
			{
				return;
			}

			_dicColumnsByName = new Dictionary<string, CalystoColumnInfo>();
			_dicColumnsByLowercaseName = new Dictionary<string, CalystoColumnInfo>();
			_dicColumnsByIndex = new Dictionary<int, CalystoColumnInfo>();

			_columns = _getColumnsEnumerable().ToList();

			int index = -1;
			foreach(var tmpcolumn in this._columns)
			{
				index++;

				string columnName;
				string lowercaseName;

				// OleDb uses Product.ProductID naming!!! We want ProductID only!
				// if we're using select count(1) from Table1, there is not column name
				if (string.IsNullOrWhiteSpace(tmpcolumn.ColumnName))
				{
					if (this._columns.Count() == 1)
					{
						columnName = "";
						lowercaseName = "";
					}
					else
					{
						throw new Exception("Column name is empty");
					}
				}
				else
				{
					columnName = tmpcolumn.ColumnName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Last();
					lowercaseName = columnName.ToLower();
				}


				if (_dicColumnsByLowercaseName.ContainsKey(lowercaseName))
				{
					throw new NotSupportedException("duplicated columns in sql select: " + columnName);
				}

				CalystoColumnInfo column = new CalystoColumnInfo()
				{
					ColumnName = columnName,
					ColumnOrdinal = index,
					DataType = tmpcolumn.DataType
				};

				_dicColumnsByLowercaseName.Add(lowercaseName, column);
				_dicColumnsByName.Add(columnName, column);
				_dicColumnsByIndex.Add(index, column);
			}
		}

		private static bool IsAssignable(MemberInfo member)
		{
			FieldInfo fi = member as FieldInfo;
			if (fi != null)
			{
				return true;
			}
			PropertyInfo pi = member as PropertyInfo;
			if (pi != null)
			{
				return pi.CanWrite;
			}
			return false;
		}

		////public string[] ColumnsNames
		////{
		////	get
		////	{
		////		EnsureColumnsInfo();
		////		return _dicColumnsByName.Select(o => o.Value.ColumnName).ToArray();
		////	}
		////}

		protected IEnumerable Translate()
		{
			CalystoMemberInfo[] members = null;
			ParameterInfo[] anonymousParams = null;

			if (_resultType.Name.Contains("AnonymousType"))
			{
				anonymousParams = _resultType.GetConstructors().First().GetParameters();
			}

			EnsureColumnsInfo();

			int columnsCount = this._columns.Count();
			int rowIndex = -1;
			object single = null;

			foreach(var row in this._getDataRowsEnumerable())
			{
				rowIndex++;

				if (anonymousParams != null)
				{
					object[] parameters = new object[anonymousParams.Length];
					int paramIndex = 0;
					// compound select is supported: .Select((o, k, t) => new {oglas = o, kor = k, o.Name, Tip = t.Name, k.Username })
					// .SelectDirect(o=>new{o.Name, o.Age})
					// there is no parameterless constructor
					foreach (ParameterInfo pi in anonymousParams)
					{
						object obj;
						int columnIndex = this.GetColumnInfo(pi.Name, false).ColumnOrdinal;
						CalystoTypeConverter.TryChangeType(row.Skip(columnIndex).FirstOrDefault(), pi.ParameterType, out obj);
						parameters[paramIndex] = obj;
						paramIndex++;
					}
					yield return Activator.CreateInstance(_resultType, parameters);
				}
				else if (_resultType == typeof(object[]))
				{
					yield return row;
				}
				else if (_resultType == typeof(MatrixCell))
				{
					for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
					{
						object val = row.GetValue(columnIndex);
						yield return new MatrixCell()
						{
							RowIndex = rowIndex,
							ColumnIndex = columnIndex,
							ColumnName = this.GetColumnInfo(columnIndex).ColumnName,
							CellValue = val == DBNull.Value ? null : val,
							DataType = this.GetColumnInfo(columnIndex).DataType
						};
					}
				}
				else if (_dicColumnsByName.Count == 1 && CalystoTypeConverter.TryChangeType(row.GetValue(0), _resultType, out single))
				{
					yield return single;
				}
				else
				{
					// parameterless constructor found, it can be any custom object, but not Anonymous type
					object res = Activator.CreateInstance(_resultType);

					if (members == null)
					{
						members = _resultType.GetMembers(BindingFlags.Public | BindingFlags.Instance)
						.Where(o => IsAssignable(o))
						.Select(o => new CalystoMemberInfo()
						{
							Name = o.Name,
							Member = o,
							MemberType = o is PropertyInfo ? ((PropertyInfo)o).PropertyType : o is FieldInfo ? ((FieldInfo)o).FieldType : null,
							ColumnIndex = this.GetColumnInfo(o.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>(true)?.Name ?? o.Name, false).ColumnOrdinal // case non-sensitive search, don't throw exception if column not found, same as MS Translator<>
						})
						.Where(o => o.MemberType != null && o.ColumnIndex >= 0) // fill properties for which there are columns found, other are ignored
						.ToArray();
					}

					foreach(var o in members)
					{
						// throw exception if type can't be converted
						var val = CalystoTypeConverter.ChangeType(row[o.ColumnIndex], o.MemberType);

						if (o.Member is PropertyInfo pi1)
						{
							if (pi1.CanWrite)
								pi1.SetValue(res, val, null);
						}
						else if (o.Member is FieldInfo fi1)
						{
							fi1.SetValue(res, val);
						}
						else
							throw new InvalidOperationException(); // ne smije doci ovdje jer gore selektiramo PropertyInfo i FieldInfo membere
					}

					yield return res;
				}

			}
		}
	}


	public class DataTranslator<TResult> : DataTranslator
	{
		public DataTranslator(DbDataReader reader) : base(typeof(TResult), reader)
		{
		}

		public DataTranslator(DataTable table) : base(typeof(TResult), table)
		{
		}

		/////// <summary>
		/////// translate datatable with enumerable rows
		/////// </summary>
		/////// <param name="columns"></param>
		/////// <param name="rows"></param>
		////public DataTranslator(IEnumerable<string> columns, IEnumerable<object[]> rows) : base(typeof(TResult), columns, rows)
		////{

		////}

		public new IEnumerable<TResult> Translate()
		{
			return base.Translate().Cast<TResult>();
		}
	}

}
