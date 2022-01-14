using Calysto.Common;
using Calysto.SqlMetal.CalystoGenerator.CalystoEFCoreFluent;
using Calysto.SqlMetal.SqlMetal;
using LinqToSqlShared.Common;
using LinqToSqlShared.DbmlObjectModel;
using LinqToSqlShared.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlMetal
{
	internal partial class Extractor
	{
		private ConnectionManager connectionManager;
		private Database dbml;
		private DisplayMessage display;
		private string connStr;
		private List<LinqToSqlShared.DbmlObjectModel.Function> functionsWithErrors;
		private static char namepartDelimiter = '.';
		private ExtractorOptions options;
		private static char[] specialCharacters = new char[] { '[', ']', '.', '"', '\'', '\\', '-', '@', ' ' };
		private Dictionary<Table, string> tableSchemas;
		private const uint UMax = uint.MaxValue;
		private Dictionary<Table, List<UniqueConstraint>> uniqueConstraints;
		private Dictionary<Table, List<UniqueIndex>> uniqueIndexes;
		private List<Table> views;
		private List<SchemaObject> schemaObjects;
		private HashSet<string> schemas;

		internal Extractor(ExtractorOptions options, DisplayMessage displayCallback)
		{
			this.options = options;
			this.display = displayCallback;
			this.connStr = options.ConnectionString;
		}

		private static string GetUniqueStringFromType(LinqToSqlShared.DbmlObjectModel.Type type)
		{
			return string.Join(", ", type.Columns.OrderBy(o => o.Name).Select(c => c.Name + " [" + c.DbType + "]"));
		}

		/// <summary>
		/// Return type which is unique, either newly added or previously added.
		/// </summary>
		/// <param name="types"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private static LinqToSqlShared.DbmlObjectModel.Type AddUniqueResultType(List<LinqToSqlShared.DbmlObjectModel.Type> types, LinqToSqlShared.DbmlObjectModel.Type type)
		{
			foreach (LinqToSqlShared.DbmlObjectModel.Type type2 in types)
			{
				string existing1 = GetUniqueStringFromType(type2);
				string new1 = GetUniqueStringFromType(type);
				if (existing1 == new1)
				{
					return type2;
				}
			}
			types.Add(type);
			return type;
		}

		private static bool ColumnsMatch(List<DbmlKeyColumn> a, string[] b)
		{
			if (a.Count != b.Length)
			{
				return false;
			}
			List<string> nameList = GetNameList(b);
			return IsSameSet(a, nameList);
		}

		private static bool ColumnsMatch(List<string> a, string[] b)
		{
			if (a.Count != b.Length)
			{
				return false;
			}
			List<string> nameList = GetNameList(b);
			return IsSameSet(a, nameList);
		}

		private static void CopyStringToStringBuilder(StringBuilder sb, string str)
		{
			sb.Remove(0, sb.Length);
			sb.Append(str);
		}

		private static DbParameter CreateParameter(DbCommand command, string name, SqlDbType dbType)
		{
			DbParameter parameter = command.CreateParameter();
			parameter.ParameterName = name;
			PropertyInfo property = parameter.GetType().GetProperty("SqlDbType");
			if (property != null)
			{
				property.SetValue(parameter, dbType, null);
			}

			var type1 = DbTypeSystem.GetClosestRuntimeType(dbType);
			if (type1 == typeof(string))
				parameter.Value = "";
			else if (type1 == typeof(DateTime))
				parameter.Value = DateTime.Now; // sql doesn't support min value for datetime
			else if (type1 == typeof(Binary))
				parameter.Value = new byte[0];
			else
				parameter.Value = Activator.CreateInstance(type1);

			return parameter;
		}

		internal Database Extract()
		{
			using (this.connectionManager = new ConnectionManager(this.connStr, this.options.CommandTimeout))
			{
				this.connectionManager.Open();

				string database = this.connectionManager.GetDatabase();

				this.dbml = new Database();
				this.dbml.Connection = new Connection(database) { ConnectionString = this.connStr };
				this.dbml.DatabaseName = database;
				this.dbml.ContextNamespace = this.options.Namespace;
				this.dbml.EntityNamespace = this.options.Namespace;
				this.GetDbml(database);
				return this.dbml;
			}
		}

		private static Column FindColumn(IEnumerable<Column> cols, string name)
		{
			if (cols != null)
			{
				foreach (Column column in cols)
				{
					if (string.Compare(column.Name, name, StringComparison.Ordinal) == 0)
					{
						return column;
					}
				}
			}
			return null;
		}

		private Table FindTable(string fullName)
		{
			foreach (Table table in this.dbml.Tables)
			{
				if (string.Compare(table.FullName, fullName, StringComparison.Ordinal) == 0)
				{
					return table;
				}
			}
			return null;
		}

		private static string GetBrackettedName(string schema, string name)
		{
			SqlCommandBuilder builder = new SqlCommandBuilder();
			if (string.IsNullOrEmpty(schema))
			{
				return builder.QuoteIdentifier(name);
			}
			return (builder.QuoteIdentifier(schema) + "." + builder.QuoteIdentifier(name));
		}

		private void GetDbml(string database)
		{
			string legalLanguageName = GetLegalLanguageName(database);
			if (string.Compare(legalLanguageName, database, StringComparison.Ordinal) == 0)
			{
				this.dbml.DatabaseName = legalLanguageName;
			}
			else
			{
				this.dbml.DatabaseName = database;
				this.dbml.ContextClass = legalLanguageName;
			}
			this.tableSchemas = new Dictionary<Table, string>();
			////this.functionSchemas = new Dictionary<LinqToSqlShared.DbmlObjectModel.Function, string>();
			////this.functionTypes = new Dictionary<LinqToSqlShared.DbmlObjectModel.Function, string>();
			this.functionsWithErrors = new List<LinqToSqlShared.DbmlObjectModel.Function>();
			this.views = new List<Table>();
			this.uniqueConstraints = new Dictionary<Table, List<UniqueConstraint>>();
			this.uniqueIndexes = new Dictionary<Table, List<UniqueIndex>>();
			this.schemaObjects = new List<SchemaObject>();
			this.schemas = new HashSet<string>();

			if (this.connectionManager.ConnectionType == ConnectionType.SqlCE)
			{
				this.options.Types &= ExtractTypes.Relationships | ExtractTypes.Tables;
			}

			// get all schemas
			this.GetSchemas();
			// keep checked items only
			// if there are tables with the same name in different schemas, will crete name prefixed with schema
			this.schemaObjects = this.schemaObjects.Where(o => this.options.MayGenerate(o.FullName)).ToList();
			this.schemas = new HashSet<string>(this.schemaObjects.Select(o=>o.Schema).Distinct().ToList());

			if (((this.options.Types & ExtractTypes.Tables) != 0) || ((this.options.Types & ExtractTypes.Views) != 0))
			{
				this.GetTablesAndViews();
				if (!this.options.RetrieveNamesOnly)
				{
					this.GetPrimaryKeys();
					this.GetUniqueKeys();
					this.GetIndexes();
				}
			}
			if ((this.options.Types & ExtractTypes.Relationships) != 0)
			{
				if (!this.options.RetrieveNamesOnly)
				{
					this.GetRelationships();
				}
			}
			if (((this.options.Types & ExtractTypes.Functions) != 0) || ((this.options.Types & ExtractTypes.StoredProcedures) != 0))
			{
				this.GetSprocsAndFunctions();
			}
		}

		internal static string GetFullName(string schema, string name)
		{
			if (string.IsNullOrEmpty(schema))
			{
				return QuoteIfNeeded(name);
			}
			return QuoteIfNeeded(schema, name);
		}

		internal static string GetFullRoutineName(string schema, string routine, string fType)
		{
			if (fType == "SVF")
			{
				if (string.IsNullOrEmpty(schema))
				{
					return QuoteIfNeeded(routine);
				}
				return QuoteIfNeeded(schema, routine);
			}
			if (string.IsNullOrEmpty(schema))
			{
				return QuoteIfNeeded(routine);
			}
			return QuoteIfNeeded(schema, routine);
		}

		private void GetIndexes()
		{
			if (this.connectionManager.ConnectionType != ConnectionType.SqlCE)
			{
				string str;
				if (this.connectionManager.ConnectionType == ConnectionType.Sql2000)
				{
					str = @"
                    select 
                    user_name(t.uid) as [schema],
                    object_name(i.id) as [table], 
                        i.id as [object_id],
                        i.name as [index],
                        case when i.indid = 1 then 'CLUSTERED' else 'NONCLUSTERED' end as [Style],
                        (select count(*) from sysindexkeys where id = i.id and indid = i.indid and
                         ISNULL(OBJECTPROPERTY(id, 'IsMSShipped'), 0) = 0) as [Count],
                        convert(tinyint,ik.keyno) as [Ordinal],
                        c.name as [Column],
                        convert(bit, case when i.status & 0x2 <> 0 then 1 else 0 end) AS is_unique,
                        convert(bit, case when i.status & 0x800 <> 0 then 1 else 0 end) AS is_primary_key,
                        convert(bit, case when i.status & 0x1000 <> 0 then 1 else 0 end) AS is_unique_constraint
                    from 
                        sysindexes as i
                        join sysindexkeys ik on ik.id = i.id and ik.indid = i.indid
                        join syscolumns c on c.id = i.id and c.colid = ik.colid
                        join sysobjects t on t.id = i.id and (t.xtype='U')
                    where 
                        i.indid>=1 and i.indid<255 AND
                        ISNULL(OBJECTPROPERTY(t.id, 'IsMSShipped'), 0) = 0
                    order by
                        t.uid, t.id, i.indid, ik.keyno
                ";
				}
				else
				{
					str = @"
                    select s.name as [schema], t.name as [table], t.object_id, 
                    x.name as [index], x.type_desc as [style], 
                        (select count(*) 
                            from sys.index_columns ic2
                            where ic2.object_id = ic.object_id and
                                  ic2.index_id = ic.index_id and
                                  ISNULL(OBJECTPROPERTY(ic2.object_id, 'IsMSShipped'), 0) = 0)
                            as [count],
                    ic.key_ordinal as [ordinal], c.name as [column], 
                        x.is_unique, x.is_primary_key, x.is_unique_constraint
                    from sys.indexes as x,
                        sys.index_columns as ic,
                        sys.columns as c,
                        sys.tables as t,
                        sys.schemas as s
                    where x.object_id = ic.object_id and
                            x.index_id = ic.index_id and
                            x.object_id = c.object_id and
                            ic.column_id = c.column_id and
                            c.object_id = t.object_id and
                            t.schema_id = s.schema_id and
                            ISNULL(OBJECTPROPERTY(t.object_id, 'IsMSShipped'), 0) = 0
                    order by s.schema_id, t.object_id, x.index_id, ic.key_ordinal
                    ";
				}
				using (DbCommand command = this.connectionManager.CreateCommand(str))
				{
					using (DbDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							if ((bool)reader["is_unique"])
							{
								string schema = (string)reader["schema"];
								string strA = (string)reader["table"];
								int num = (int)reader["count"];
								string item = (string)reader["column"];
								if (string.Compare(strA, "SYSDIAGRAMS", StringComparison.OrdinalIgnoreCase) != 0)
								{
									string fullName = GetFullName(schema, strA);
									Table table1 = this.FindTable(fullName);
									if (table1 != null)
									{
										UniqueIndex index = new UniqueIndex
										{
											KeyColumns = { item }
										};
										while ((num > 1) && reader.Read())
										{
											item = (string)reader["column"];
											index.KeyColumns.Add(item);
											num--;
										}
										if (this.uniqueIndexes.ContainsKey(table1))
										{
											this.uniqueIndexes[table1].Add(index);
										}
										else
										{
											this.uniqueIndexes.Add(table1, new List<UniqueIndex>());
											this.uniqueIndexes[table1].Add(index);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private static string GetLegalLanguageName(string name)
		{
			return Naming.MakeLegalNameLangIndependent(new StringBuilder(name)).ToString();
		}

		/// <summary>
		/// If there are multiple schemas, will create name prefixed with schema name.
		/// </summary>
		/// <param name="schema"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		private string GetLegalLanguageName(string schema, string name)
		{
			if (this.options.NeverAddSchemaPrefixForSchemas.Contains(schema))
			{
				// don't add schema as prefix
			}
			else if (this.schemas.Count > 1)
			{
				name = schema + "." + name;
			}

			return GetLegalLanguageName(name);
		}

		private static List<string> GetNameList(string[] a)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < a.Length; i++)
			{
				list.Add(a[i].Trim(new char[] { ' ' }));
			}
			return list;
		}

		private void GetPrimaryKeys()
		{
			string str;
			if (this.connectionManager.ConnectionType == ConnectionType.SqlCE)
			{
				str = @"
                    select 
                        null as CONSTRAINT_SCHEMA,
                        tc.CONSTRAINT_NAME,
                        pkcol.ORDINAL_POSITION,
                        null as pkSchema,
                        pkcol.TABLE_NAME as pkTable,
                        pkcol.COLUMN_NAME as pkColumn
                    from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
                        inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as pkcol
                            on tc.CONSTRAINT_NAME = pkcol.CONSTRAINT_NAME and
                                tc.CONSTRAINT_TYPE = 'PRIMARY KEY'
                    inner join INFORMATION_SCHEMA.TABLES as tables
                        on tables.TABLE_NAME = pkcol.TABLE_NAME and
                        tables.TABLE_TYPE <> 'SYSTEM TABLE'
                    order by 
                        tc.CONSTRAINT_SCHEMA,
                        tc.CONSTRAINT_NAME,
                        pkcol.ORDINAL_POSITION ";
			}
			else
			{
				str = @"
                    select tc.CONSTRAINT_SCHEMA,
                        tc.CONSTRAINT_NAME,
                        pkcol.ORDINAL_POSITION,
                        pkcol.TABLE_SCHEMA as pkSchema,
                        pkcol.TABLE_NAME as pkTable,
                        pkcol.COLUMN_NAME as pkColumn
                    from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc,
                        INFORMATION_SCHEMA.KEY_COLUMN_USAGE as pkcol
                    where tc.CONSTRAINT_SCHEMA = pkcol.CONSTRAINT_SCHEMA and
                        tc.CONSTRAINT_NAME = pkcol.CONSTRAINT_NAME and
                        tc.CONSTRAINT_TYPE = 'PRIMARY KEY' and
                        ISNULL(OBJECTPROPERTY(OBJECT_ID(tc.TABLE_NAME), 'IsMSShipped'), 0) = 0
                    order by 
                        tc.CONSTRAINT_SCHEMA,
                        tc.CONSTRAINT_NAME,
                        pkcol.ORDINAL_POSITION ";
			}
			using (DbCommand command = this.connectionManager.CreateCommand(str))
			{
				using (DbDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string pkSchema = (string)ValueOrDefault(reader["pkSchema"], "");
						string pkTable = (string)reader["pkTable"];
						string pkColumn = (string)reader["pkColumn"];
						if (string.Compare(pkTable, "SYSDIAGRAMS", StringComparison.OrdinalIgnoreCase) != 0)
						{
							string fullName = GetFullName(pkSchema, pkTable);
							Table table = this.FindTable(fullName);
							// if table is not checked for processing
							if (table == null)
								continue;

							pkColumn = QuoteIfNeeded(pkColumn);
							Column column = FindColumn(table.Type.Columns, pkColumn);
							if (column == null)
							{
								throw SqlMetal.Error.CouldNotIdentifyPrimaryKeyColumn(pkColumn, fullName);
							}
							column.IsPrimaryKey = true;
						}
					}
				}
			}
		}

		private FkDeleteRule DecodeFkDeleteRule(string rule)
		{
			if (rule.Equals("NO ACTION", StringComparison.OrdinalIgnoreCase))
				return FkDeleteRule.NoAction;
			else if (rule.Equals("SET NULL", StringComparison.OrdinalIgnoreCase))
				return FkDeleteRule.SetNull;
			else if (rule.Equals("CASCADE", StringComparison.OrdinalIgnoreCase))
				return FkDeleteRule.Cascade;
			else if (rule.Equals("SET DEFAULT", StringComparison.OrdinalIgnoreCase))
				return FkDeleteRule.SetDefault;
			else
				throw new InvalidOperationException("Fk rule not supported: " + rule);
		}

		private void GetRelationships()
		{
			string str;
			if (this.connectionManager.ConnectionType == ConnectionType.SqlCE)
			{
				str = @"
                select 
                null as CONSTRAINT_SCHEMA,
                rc.CONSTRAINT_NAME,
                pkcol.ORDINAL_POSITION,
                cnt.COUNT,
                null as fkSchema,
                fkcol.TABLE_NAME as fkTable,
                fkcol.COLUMN_NAME as fkColumn,
                null as pkSchema,
                pkcol.TABLE_NAME as pkTable,
                pkcol.COLUMN_NAME as pkColumn,
                rc.UPDATE_RULE,
                rc.DELETE_RULE
                 from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc
              INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE as pkcol 
                      ON rc.UNIQUE_CONSTRAINT_NAME = pkcol.CONSTRAINT_NAME
              INNER join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as fkcol
                      ON pkcol.ORDINAL_POSITION = fkcol.ORDINAL_POSITION AND
                      rc.CONSTRAINT_NAME = fkcol.CONSTRAINT_NAME
              inner join INFORMATION_SCHEMA.TABLES as tables
                on tables.TABLE_NAME = pkcol.TABLE_NAME and
                   tables.TABLE_TYPE <> 'SYSTEM TABLE'
              cross apply (
                 select count(*) as COUNT 
                 from INFORMATION_SCHEMA.KEY_COLUMN_USAGE kc
                 where rc.CONSTRAINT_NAME = kc.CONSTRAINT_NAME
                 ) as cnt 
              order by 
                 rc.CONSTRAINT_SCHEMA,
                 rc.CONSTRAINT_NAME,
                 pkcol.ORDINAL_POSITION ";
			}
			else
			{
				str = @"
              select 
                rc.CONSTRAINT_SCHEMA,
                rc.CONSTRAINT_NAME,
                pkcol.ORDINAL_POSITION,
                (select count(*) from INFORMATION_SCHEMA.KEY_COLUMN_USAGE kc
                    where rc.CONSTRAINT_SCHEMA = kc.CONSTRAINT_SCHEMA and
                          rc.CONSTRAINT_NAME = kc.CONSTRAINT_NAME and
                          ISNULL(OBJECTPROPERTY(OBJECT_ID(kc.CONSTRAINT_NAME), 'IsMSShipped'), 0) = 0)
                          as COUNT,
            fkcol.TABLE_SCHEMA as fkSchema,
                fkcol.TABLE_NAME as fkTable,
                fkcol.COLUMN_NAME as fkColumn,
                pkcol.TABLE_SCHEMA as pkSchema,
                pkcol.TABLE_NAME as pkTable,
                pkcol.COLUMN_NAME as pkColumn,
                rc.UPDATE_RULE,
                rc.DELETE_RULE
          from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc,
                   INFORMATION_SCHEMA.KEY_COLUMN_USAGE as pkcol,
                   INFORMATION_SCHEMA.KEY_COLUMN_USAGE as fkcol
              where rc.CONSTRAINT_SCHEMA = fkcol.CONSTRAINT_SCHEMA and
                 rc.CONSTRAINT_NAME = fkcol.CONSTRAINT_NAME and
                 rc.UNIQUE_CONSTRAINT_SCHEMA = pkcol.CONSTRAINT_SCHEMA and
                 rc.UNIQUE_CONSTRAINT_NAME = pkcol.CONSTRAINT_NAME and
                 pkcol.ORDINAL_POSITION = fkcol.ORDINAL_POSITION and
                 ISNULL(OBJECTPROPERTY(OBJECT_ID(rc.CONSTRAINT_NAME), 'IsMSShipped'), 0) = 0
              order by 
                 rc.CONSTRAINT_SCHEMA,
                 rc.CONSTRAINT_NAME,
                 pkcol.ORDINAL_POSITION ";
			}
			using (DbCommand command = this.connectionManager.CreateCommand(str))
			{
				using (DbDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string constraintName = (string)reader["CONSTRAINT_NAME"];
						int count1 = (int)reader["COUNT"];
						string fkSchema = (string)ValueOrDefault(reader["fkSchema"], "");
						string fkTable = (string)reader["fkTable"];
						string fkColumn = (string)reader["fkColumn"];
						string pkSchema = (string)ValueOrDefault(reader["pkSchema"], "");
						string pkTable = (string)reader["pkTable"];
						string pkColumn = (string)reader["pkColumn"];
						FkDeleteRule deleteRule = this.DecodeFkDeleteRule((string)reader["DELETE_RULE"]);
						Table fkTypeTable = this.FindTable(GetFullName(fkSchema, fkTable));
						// if table is not checked for processing
						if (fkTypeTable == null)
							continue;

						string str10 = QuoteIfNeeded(fkColumn);
						Column column1 = FindColumn(fkTypeTable.Type.Columns, str10);
						Table pkTypeTable = this.FindTable(GetFullName(pkSchema, pkTable));
						// if table is not checked for processing
						if (pkTypeTable == null)
							continue;

						str10 = QuoteIfNeeded(pkColumn);
						Column column2 = FindColumn(pkTypeTable.Type.Columns, str10);
						Association pkAssoc = new Association()
						{
							Name = constraintName,
							Cardinality =	 Cardinality.One,
							IsForeignKey = true,
							Type = GetLegalLanguageName(pkTypeTable.Type.TypeName)
						};
						fkTypeTable.Type.Associations.Add(pkAssoc);
						Association fkAssoc = new Association()
						{
							Name = constraintName,
							IsForeignKey = false,
							Cardinality = Cardinality.Many,
							DeleteRule = deleteRule,
							Type = GetLegalLanguageName(fkTypeTable.Type.TypeName)
						};
						pkTypeTable.Type.Associations.Add(fkAssoc);
						bool canBeNull = true;
						List<string> list1 = new List<string>();
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						List<string> list4 = new List<string>();
						List<string> list5 = new List<string> { column1.Member };

						if (FindColumn(fkTypeTable.Type.Columns, column1.Name).CanBeNull == false)
						{
							canBeNull = false;
						}
						list1.Add(column1.Member);
						list4.Add(column1.Member);
						list2.Add(column2.Member);
						list3.Add(column2.Member);
						while ((count1 > 1) && reader.Read())
						{
							fkColumn = (string)reader["fkColumn"];
							pkColumn = (string)reader["pkColumn"];
							str10 = QuoteIfNeeded(fkColumn);
							column1 = FindColumn(fkTypeTable.Type.Columns, str10);
							if (column1.CanBeNull == false)
							{
								canBeNull = false;
							}
							str10 = QuoteIfNeeded(pkColumn);
							column2 = FindColumn(pkTypeTable.Type.Columns, str10);
							list1.Add(column1.Member);
							list4.Add(column1.Member);
							list2.Add(column2.Member);
							list3.Add(column2.Member);
							list5.Add(column1.Member);
							count1--;
						}
						pkAssoc.SetThisKey(list1.ToArray());
						fkAssoc.SetOtherKey(list4.ToArray());
						fkAssoc.SetThisKey(list2.ToArray());
						pkAssoc.SetOtherKey(list3.ToArray());
						if (this.IsOneToOne(fkTypeTable, list5.ToArray()))
						{
							fkAssoc.Cardinality = Cardinality.One;
						}
						if (fkAssoc.DeleteRule == FkDeleteRule.Cascade && !canBeNull)
						{
							pkAssoc.DeleteOnNull = true;
						}
					}
				}
			}
			foreach (Table table3 in this.dbml.Tables)
			{
				foreach (Association association3 in table3.Type.Associations)
				{
					this.InferAssociationPropertyName(table3, association3);
				}
			}
		}

		/// <summary>
		/// Reads table-valued functions only.
		/// </summary>
		/// <param name="sqlfunc"></param>
		/// <param name="command"></param>
		private void GetRoutineResultTypesFromInformationSchema(LinqToSqlShared.DbmlObjectModel.Function sqlfunc, DbCommand command, DatabaseItemSetting sett1)
		{
			// it will be always Table-valued function
			if (sqlfunc.Kind != DbObjectKind.FunctionTableValued)
			{
				throw new NotSupportedException();
			}

			if (sett1?.ReturnKind == FunctionReturnKindEnum.DataSet)
			{
				sqlfunc.ReturnKind = sett1.ReturnKind;
				return;
			}
			else if (sett1?.ReturnKind == FunctionReturnKindEnum.DataTable)
			{
				sqlfunc.ReturnKind = sett1.ReturnKind;
				return;
			}

			command.Parameters.Clear();

			try
			{
				// sql query returns columns returned by sql functions only (no sql procedures)
				command.CommandText = $@"select * from INFORMATION_SCHEMA.ROUTINE_COLUMNS 
where TABLE_SCHEMA = '{sqlfunc.Schema}' and TABLE_NAME = '{sqlfunc.Name}'
order by ORDINAL_POSITION";

				SqlDataAdapter dataAdapter = new SqlDataAdapter((SqlCommand)command);
				DataTable table1 = new DataTable();
				dataAdapter.Fill(table1);

				List<LinqToSqlShared.DbmlObjectModel.Type> types = new List<LinqToSqlShared.DbmlObjectModel.Type>();

				LinqToSqlShared.DbmlObjectModel.Type type1 = new LinqToSqlShared.DbmlObjectModel.Type();
				type1.TypeName = string.Format(CultureInfo.InvariantCulture, "{0}Result", new object[] { sqlfunc.Method });

				List<ResultSetInfo> resultsInfos = sett1?.GetResultSetInfos();
				int infoIndex = 0;
				ResultSetInfo resInfo = resultsInfos?.Skip(infoIndex)?.FirstOrDefault();
				infoIndex++;
				int typesCount = 0;
				if (resInfo != null)
				{
					type1.ResultSetInfo = resInfo;
					// element type in List<element>, without List<>
					type1.TypeName = resInfo.ElementType ?? type1.TypeName;
				}

				if(resInfo?.HasElementType == true)
				{
					// use provided type
					types.Add(type1);
					typesCount++;
				}
				else
				{
					List<string> list2 = new List<string>();
					
					types.Add(type1);
					typesCount++;

					foreach (DataRow row in table1.Rows)
					{
						Column item = new Column();
						item.Name = Convert.ToString(row["COLUMN_NAME"], CultureInfo.InvariantCulture);
						if (list2.Contains(item.Name))
						{
							this.functionsWithErrors.Add(sqlfunc);
							if (this.display != null)
							{
								if ((this.display != null) && (item.Name.Length == 0))
								{
									this.display(Severity.Error, SqlMetal.Strings.SprocResultMultipleAnonymousColumns(sqlfunc.Name));
								}
								else
								{
									this.display(Severity.Error, SqlMetal.Strings.SprocResultColumnsHaveSameName(sqlfunc.Name, item.Name));
								}
							}
							return;
						}
						list2.Add(item.Name);
						string name = item.Name;
						if (string.IsNullOrEmpty(name))
						{
							name = string.Format(CultureInfo.InvariantCulture, "Column{0}", new object[] { typesCount });
						}
						item.Member = GetLegalLanguageName(name);
						SqlDbType sqlDbType = DbTypeSystem.Parse(Convert.ToString(row["DATA_TYPE"], CultureInfo.InvariantCulture));
						System.Type closestRuntimeType = DbTypeSystem.GetClosestRuntimeType(sqlDbType);
						item.PropertyType = GetScopedTypeName(closestRuntimeType);
						int size = (int)ValueOrDefault(row["CHARACTER_MAXIMUM_LENGTH"], 0);

						short precision = -1;
						string tmp1 = row["NUMERIC_PRECISION"] + "";
						if (!short.TryParse(tmp1, out precision))
							precision = -1;

						short scale = -1;
						string tmp2 = row["NUMERIC_SCALE"] + "";
						if (!short.TryParse(tmp2, out scale))
							scale = -1;

						item.SqlColumnType = item.DbType = GetSqlTypeDeclaration(sqlDbType, size, precision, scale, false, false);
						item.CanBeNull = (bool)ValueOrDefault(row["IS_NULLABLE"] + "" == "YES", true);
						type1.Columns.Add(item);
					}
				}

				// sql function may return single type only, so it will never be > 1
				if (typesCount > 1)
				{
					throw new NotSupportedException();
				}

				sqlfunc.Types.AddRange(types);
			}
			catch (SqlException exception)
			{
				this.LogFunctionSchemaError(sqlfunc, exception.Message);
			}
		}

		private IEnumerable<string> GetAllTypesNames()
		{
			foreach(var item in this.dbml.Tables)
			{
				yield return item.Name;
			}
			foreach (var item in this.dbml.Functions.SelectMany(f => f.Types.SelectMany(t => t.Descendants(true))))
			{
				yield return item.TypeName;
			}
		}

		/// <summary>
		/// Reads stored procedures only.
		/// </summary>
		/// <param name="sqlfunc"></param>
		/// <param name="command"></param>
		private void GetRoutineResultTypesFromReaderSchema(LinqToSqlShared.DbmlObjectModel.Function sqlfunc, DbCommand command, CommandBehavior commandBehavior, DatabaseItemSetting sett1)
		{
			if(sqlfunc.Kind != DbObjectKind.Procedure)
			{
				throw new InvalidOperationException();
			}

			if (!this.options.MayGenerate(sqlfunc.FullName))
				return;

			if (this.options.RetrieveNamesOnly)
				return;

			bool isSqlProcedure = sqlfunc.Kind == DbObjectKind.Procedure;
			bool hasOutParameter = false;

			command.Parameters.Clear();

			string[] csvValues = sett1?.CsvArgs?.Split(',').Select(o => o.Trim()).ToArray();

			int index1 = -1;
			foreach (Parameter parameter in sqlfunc.Parameters)
			{
				index1++;

				if (parameter.Direction == LinqToSqlShared.DbmlObjectModel.ParameterDirection.Out || parameter.Direction == LinqToSqlShared.DbmlObjectModel.ParameterDirection.InOut)
				{
					hasOutParameter = true;
				}

				SqlDbType dbType = DbTypeSystem.Parse(parameter.DbType);
				DbParameter parameter2 = CreateParameter(command, parameter.Name, dbType);

				command.Parameters.Add(parameter2);

				if (csvValues != null && csvValues.Length > index1)
				{
					parameter2.Value = Calysto.Utility.CalystoTypeConverter.ChangeType(csvValues[index1], parameter2.Value?.GetType());
				}
			}

			if(sett1?.ReturnKind == FunctionReturnKindEnum.DataSet)
			{
				sqlfunc.ReturnKind = sett1.ReturnKind;
				return;
			}
			else if(sett1?.ReturnKind == FunctionReturnKindEnum.DataTable)
			{
				sqlfunc.ReturnKind = sett1.ReturnKind;
				return;
			}

			List<ResultSetInfo> resultsInfos = sett1?.GetResultSetInfos();
			
			try
			{
				using (DbDataReader reader = command.ExecuteReader(commandBehavior))
				{
					DataTable schemaTable = reader.GetSchemaTable();
					//if (schemaTable == null)
					//	return;
					
					int infoIndex = 0;

					// if we have multiple results returned from stored procedure, results may have the same type for materialization, so reuse the same type
					List<LinqToSqlShared.DbmlObjectModel.Type> distinctTypes = new List<LinqToSqlShared.DbmlObjectModel.Type>();
					// into allTypes add as many types as there are results set, we use it to create Result[n] properties later
					List<LinqToSqlShared.DbmlObjectModel.Type> allTypes = new List<LinqToSqlShared.DbmlObjectModel.Type>();

					while (schemaTable != null)
					{
						LinqToSqlShared.DbmlObjectModel.Type type1 = new LinqToSqlShared.DbmlObjectModel.Type();
						type1.TypeName = string.Format(CultureInfo.InvariantCulture, "{0}Result", new object[] { sqlfunc.Method });

						ResultSetInfo resInfo = resultsInfos?.Skip(infoIndex)?.FirstOrDefault();
						infoIndex++;

						if (resInfo != null)
						{
							type1.ResultSetInfo = resInfo;
							// element type in List<element>, without List<>
							type1.TypeName = resInfo.ElementType ?? type1.TypeName;
						}

						if(resInfo?.HasElementType == true)
						{ 
							// use provided type
							allTypes.Add(type1);
						}
						else
						{
							int num2 = 0;
							int count = schemaTable.Rows.Count;
							List<string> list2 = new List<string>();
							while (num2 < count)
							{
								Column item = new Column();
								DataRow row = schemaTable.Rows[num2];
								item.Name = Convert.ToString(row["ColumnName"], CultureInfo.InvariantCulture);
								if (list2.Contains(item.Name))
								{
									this.functionsWithErrors.Add(sqlfunc);
									if (this.display != null)
									{
										if ((this.display != null) && (item.Name.Length == 0))
										{
											this.display(Severity.Error, SqlMetal.Strings.SprocResultMultipleAnonymousColumns(sqlfunc.Name));
										}
										else
										{
											this.display(Severity.Error, SqlMetal.Strings.SprocResultColumnsHaveSameName(sqlfunc.Name, item.Name));
										}
									}
									return;
								}
								list2.Add(item.Name);
								string name = item.Name;
								if (string.IsNullOrEmpty(name))
								{
									name = string.Format(CultureInfo.InvariantCulture, "Column{0}", new object[] { num2 + 1 });
								}
								item.Member = GetLegalLanguageName(name);
								SqlDbType sqlDbType = DbTypeSystem.Parse(Convert.ToString(row["DataTypeName"], CultureInfo.InvariantCulture));
								System.Type closestRuntimeType = DbTypeSystem.GetClosestRuntimeType(sqlDbType);
								item.PropertyType = GetScopedTypeName(closestRuntimeType);
								int size = (int)ValueOrDefault(row["ColumnSize"], 0);
								short precision = (short)ValueOrDefault(row["NumericPrecision"], (short)(-1));
								short scale = (short)ValueOrDefault(row["NumericScale"], (short)(-1));
								item.SqlColumnType = item.DbType = GetSqlTypeDeclaration(sqlDbType, size, precision, scale, false, false);
								item.CanBeNull = (bool)ValueOrDefault(row["AllowDBNull"], true);
								type1.Columns.Add(item);
								num2++;
							}

							LinqToSqlShared.DbmlObjectModel.Type uniqueType = AddUniqueResultType(distinctTypes, type1);
							allTypes.Add(uniqueType);
						}

						reader.NextResult();
						schemaTable = reader.GetSchemaTable();
					}

					if (allTypes.Count > 1 || hasOutParameter || isSqlProcedure)
					{
						// let's make sql procedure always return MultipleResults, this way it is possible to read returned value from procedure and to read out parameters

						if (distinctTypes.Count > 1)
						{
							int num7 = 0;
							foreach (LinqToSqlShared.DbmlObjectModel.Type type5 in distinctTypes)
							{
								num7++;
								type5.TypeName += num7;
							}
						}

						List<Column> columns1 = new List<Column>();
						int num8 = -1;
						foreach (var type6 in allTypes)
						{
							num8++;
							ResultSetInfo info1 = resultsInfos?.Skip(num8)?.FirstOrDefault();
							columns1.Add(new Column()
							{
								PropertyType = info1?.PropertyType ?? ResultSetInfo.CreateCollectionType(type6.TypeName),
								Member = info1?.PropertyName ?? ("Result" + (num8 + 1))
							});
						}

						num8++;
						ResultSetInfo info2 = resultsInfos?.Skip(num8)?.FirstOrDefault();
						columns1.Add(new Column()
						{
							PropertyType = "System.Int32",
							Member = info2?.PropertyName ?? ("ReturnValue")
						});

						LinqToSqlShared.DbmlObjectModel.Type multipleResults = new LinqToSqlShared.DbmlObjectModel.Type() { TypeName = sqlfunc.Method + "MultipleResults" };
						multipleResults.Columns.AddRange(columns1);
						multipleResults.SubTypes.AddRange(distinctTypes);

						sqlfunc.Types.Add(multipleResults);
						sqlfunc.HasMultipleResults = true;
					}
					else
					{
						throw new NotSupportedException();
					}
				}
			}
			catch (SqlException exception)
			{
				// if failed, try to execute sp
				if (commandBehavior == CommandBehavior.SchemaOnly && sett1?.Execute == true)
				{
					GetRoutineResultTypesFromReaderSchema(sqlfunc, command, CommandBehavior.Default, sett1);
				}
				else
				{
					this.LogFunctionSchemaError(sqlfunc, exception.Message);
				}
			}
		}

		private static string GetScopedTypeName(System.Type type)
		{
			if ((type.Namespace != null) && (type.Namespace.Length > 0))
			{
				return (type.Namespace + "." + type.Name);
			}
			return type.Name;
		}

		private void GetSprocAndFunctionDefinitions()
		{
			string sql = @"SELECT
r.SPECIFIC_CATALOG,
r.SPECIFIC_SCHEMA, 
r.ROUTINE_TYPE, 
r.SPECIFIC_NAME, 
r.DATA_TYPE AS ROUTINE_DATA_TYPE, 
r.ROUTINE_DEFINITION,
p.ORDINAL_POSITION, 
p.PARAMETER_MODE, 
p.PARAMETER_NAME, 
p.DATA_TYPE, 
p.CHARACTER_MAXIMUM_LENGTH, 
p.NUMERIC_PRECISION, 
p.NUMERIC_SCALE, 
p.DATETIME_PRECISION,
p.IS_RESULT FROM INFORMATION_SCHEMA.ROUTINES AS r 
FULL OUTER JOIN INFORMATION_SCHEMA.PARAMETERS AS p 
    on r.SPECIFIC_NAME = p.SPECIFIC_NAME 
		AND r.SPECIFIC_CATALOG = p.SPECIFIC_CATALOG
        AND r.SPECIFIC_SCHEMA = p.SPECIFIC_SCHEMA 
WHERE (r.ROUTINE_TYPE = 'PROCEDURE' OR r.ROUTINE_TYPE = 'FUNCTION') 
    AND ISNULL(OBJECTPROPERTY(OBJECT_ID(r.SPECIFIC_NAME), 'IsMSShipped'), 0) = 0 
ORDER BY r.SPECIFIC_CATALOG, r.SPECIFIC_SCHEMA, r.SPECIFIC_NAME, p.ORDINAL_POSITION";

			using (DbCommand command = this.connectionManager.CreateCommand(sql))
			{
				using (DbDataReader reader = command.ExecuteReader())
				{
					LinqToSqlShared.DbmlObjectModel.Function item = null;
					
					bool createSqlProcedure = (this.options.Types & ExtractTypes.StoredProcedures) != 0;
					bool createSqlFunction = (this.options.Types & ExtractTypes.Functions) != 0;

					while (reader.Read())
					{
						Parameter parameter = null;
						short num3;
						string routineType = (string)reader["ROUTINE_TYPE"];
						if (((routineType != "FUNCTION") || !createSqlFunction) && (!(routineType == "PROCEDURE") || !createSqlProcedure))
						{
							continue;
						}
						string routineName = (string)reader["SPECIFIC_NAME"];
						string routineSchema = (string)reader["SPECIFIC_SCHEMA"];

						item = new LinqToSqlShared.DbmlObjectModel.Function();
						item.Name = routineName;
						item.Schema = routineSchema;
						item.Database = (string)reader["SPECIFIC_CATALOG"]; // database name
						string fullName = item.FullName;

						if (!this.options.MayGenerate(fullName))
							continue;

						var existsingItem = this.dbml.Functions.Where(o => o.FullName == fullName).FirstOrDefault();
						if(existsingItem != null)
						{
							item = existsingItem;
						}
						else
						{
							string routineDataType = (string)ValueOrDefault(reader["ROUTINE_DATA_TYPE"], "");

							this.dbml.Functions.Add(item);
							////this.functionSchemas.Add(item, routineSchema);
							switch (routineType)
							{
								case "FUNCTION":
									if (routineDataType == "TABLE")
									{
										item.IsComposable = true;
										routineType = "TVF";
										item.Kind = DbObjectKind.FunctionTableValued;
									}
									else
									{
										item.Kind = DbObjectKind.FunctionScalarValued;
										routineType = "SVF";
										if (!string.IsNullOrEmpty(routineDataType))
										{
											item.Return = new LinqToSqlShared.DbmlObjectModel.Return(routineDataType);
											item.IsComposable = true;
										}
										else
										{
											item.IsComposable = false;
										}
									}
									break;

								case "PROCEDURE":
									item.Kind = DbObjectKind.Procedure;
									item.Return = new LinqToSqlShared.DbmlObjectModel.Return(typeof(int).ToString());
									item.Return.DbType = "Int";
									break;
							}
							////this.functionTypes.Add(item, routineType);
						}

						if (reader["ORDINAL_POSITION"] == DBNull.Value)
						{
							continue;
						}
						string str8 = (string)ValueOrDefault(reader["IS_RESULT"], "NO");
						string stype = (string)reader["DATA_TYPE"];
						SqlDbType sqlDbType = DbTypeSystem.Parse(stype);
						System.Type closestRuntimeType = DbTypeSystem.GetClosestRuntimeType(sqlDbType);
						string scopedTypeName = GetScopedTypeName(closestRuntimeType);
						int size = (int)ValueOrDefault(reader["CHARACTER_MAXIMUM_LENGTH"], 0);
						short precision = Convert.ToSByte(ValueOrDefault(reader["NUMERIC_PRECISION"], (short)(-1)), CultureInfo.InvariantCulture);
						if (HasDateTimePrecision(sqlDbType))
						{
							num3 = Convert.ToSByte(ValueOrDefault(reader["DATETIME_PRECISION"], (short)(-1)), CultureInfo.InvariantCulture);
						}
						else
						{
							num3 = Convert.ToSByte(ValueOrDefault(reader["NUMERIC_SCALE"], (short)(-1)), CultureInfo.InvariantCulture);
						}
						string str12 = GetSqlTypeDeclaration(sqlDbType, size, precision, num3, false, false);
						if (str8 == "YES")
						{
							item.Return = new LinqToSqlShared.DbmlObjectModel.Return(scopedTypeName);
							item.Return.DbType = str12;
							continue;
						}
						string name = (string)reader["PARAMETER_NAME"];
						parameter = new Parameter(name, scopedTypeName)
						{
							DbType = str12
						};

						////parameter.Name = parameter.Name.Replace("@", "");

						StringBuilder builder = new StringBuilder(GetLegalLanguageName(parameter.Name));
						builder[0] = char.ToLower(builder[0], CultureInfo.InvariantCulture);
						parameter.ParameterName = builder.ToString();
						if (!Naming.IsUniqueParameterName(parameter.ParameterName, item))
						{
							parameter.ParameterName = Naming.GetUniqueParameterName(item, parameter.ParameterName);
						}
						string str14 = (string)reader["PARAMETER_MODE"];
						if (str14 == null)
						{
							goto Label_03FC;
						}
						if (!(str14 == "IN"))
						{
							if (str14 == "INOUT")
							{
								goto Label_03F2;
							}
							if (str14 == "OUT")
							{
								goto Label_03F7;
							}
							goto Label_03FC;
						}
						LinqToSqlShared.DbmlObjectModel.ParameterDirection @in = LinqToSqlShared.DbmlObjectModel.ParameterDirection.In;
						goto Label_03FF;
						Label_03F2:
						@in = LinqToSqlShared.DbmlObjectModel.ParameterDirection.InOut;
						goto Label_03FF;
						Label_03F7:
						@in = LinqToSqlShared.DbmlObjectModel.ParameterDirection.Out;
						goto Label_03FF;
						Label_03FC:
						@in = LinqToSqlShared.DbmlObjectModel.ParameterDirection.In;
						Label_03FF:
						parameter.Direction = new LinqToSqlShared.DbmlObjectModel.ParameterDirection?(@in);
						item.Parameters.Add(parameter);
						if (sqlDbType == SqlDbType.Structured)
						{
							this.display(Severity.Error, SqlMetal.Strings.SprocParameterTypeNotSupported(item.Name, parameter.Name, parameter.DbType));
							this.functionsWithErrors.Add(item);
						}

						// parameter default value, output parameter may not have default value in C#
						{
							// resolve parameter default value
							// CLR functions dont have ROUTINE_DEFINITION
							string routineDefinition = reader["ROUTINE_DEFINITION"] as string;
							if (routineDefinition != null)
							{
								// find first occurance of parameter name
								// @name nvarchar(100) = 'my name', -- this is comment
								// @totalCount int = null output /* next comment */
								Regex re1 = new Regex(
									name
									+ "[\\s]+"
									+ "(?<type>[\\w\\(\\)]+)"
									+ "[\\s]*"
									+ "[\\=]"
									+ "[\\s]*"
									+ "(?<value>[^,;\r\n]+?)"
									+ "[\\s]*"
									+ "(out|output)*"
									+ "[,]*"
									+ "[\\s]*"
									+ $"((\r)|(\n)|({Regex.Escape("--")})|({Regex.Escape("/*")}))"
								);

								Match m1 = re1.Match(routineDefinition);
								if (m1.Success)
								{
									// sp and func parameters are always nullable
									parameter.ParameterDefaultNetValue = CreateColumnDefaultNetValue(m1.Groups["value"].Value, closestRuntimeType);
								}
							}
						}
					}
				}
			}
		}

		private void GetSprocAndFunctionResultTypes()
		{
			DbCommand command = this.connectionManager.CreateCommand();
			foreach (LinqToSqlShared.DbmlObjectModel.Function function in this.dbml.Functions)
			{
				//string fType = this.functionTypes[function];
				string funcSchema = function.Schema; // this.functionSchemas[function];
				string funcName = function.Name;
				string methodName = GetLegalLanguageName(funcSchema, funcName);
				//string fullMethodName = GetFullMethodName(funcSchema, function.Name);
				//string fullRoutineName = GetFullRoutineName(funcSchema, function.Name, fType);
				
				if (!this.IsUniqueContextMemberName(methodName))
				{
					function.Method = this.GetUniqueMemberName(methodName);
				}
				else
				{
					function.Method = methodName;
				}

				DatabaseItemSetting sett1 = null;
				if (this.options.SelectionDic?.TryGetValue(function.FullName, out sett1) == true && !string.IsNullOrEmpty(sett1.CSharpName))
				{
					function.Method = sett1.CSharpName;
				}

				if (function.Kind == DbObjectKind.Procedure)
				{
					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = GetBrackettedName(funcSchema, funcName);

					DateTime dtStart = DateTime.Now;
					this.GetRoutineResultTypesFromReaderSchema(function, command, CommandBehavior.SchemaOnly, sett1);
					if(sett1 != null)
					{
						sett1.DurationSec = (DateTime.Now - dtStart).TotalSeconds;
					}
				}
				else if(function.Kind == DbObjectKind.FunctionTableValued)
				{
					command.CommandType = CommandType.Text;
					string str4 = "";
					foreach (Parameter parameter in function.Parameters)
					{
						str4 = str4 + string.Format(CultureInfo.InvariantCulture, "{0}, ", new object[] { parameter.Name });
					}
					if (str4.Length > 0)
					{
						str4 = str4.TrimEnd(new char[] { ',', ' ' });
					}
					command.CommandText = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}({1})", new object[] { GetBrackettedName(funcSchema, funcName), str4 });
					DateTime dtStart = DateTime.Now;
					this.GetRoutineResultTypesFromInformationSchema(function, command, sett1);
					if (sett1 != null)
					{
						sett1.DurationSec = (DateTime.Now - dtStart).TotalSeconds;
					}
				}

			}
			foreach (LinqToSqlShared.DbmlObjectModel.Function function2 in this.functionsWithErrors)
			{
				this.dbml.Functions.Remove(function2);
			}
		}

		private void GetSprocsAndFunctions()
		{
			this.GetSprocAndFunctionDefinitions();
			this.GetSprocAndFunctionResultTypes();
		}

		private string GetSqlTypeDeclaration(SqlDbType sqlType, int size, short precision, short scale, bool nonNull, bool isAutoIncrement)
		{
			if(this.options.TargetMode == DbProvider.MySql)
			{
				// mysql nema bit pa ne zna konvertirati int u boolean
				// obavezno mora biti TinyInt(1), ne samo TinyInt
				// koristi se u EF .HasColumnType("TinyInt(1)")
				if (sqlType == SqlDbType.Bit)
				{
					return "TinyInt(1)";
				}
			}

			StringBuilder builder = new StringBuilder();
			if (sqlType == SqlDbType.Timestamp)
			{
				builder.Append("rowversion");
			}
			else if (sqlType == SqlDbType.Variant)
			{
				builder.Append("sql_variant");
			}
			else
			{
				builder.Append(sqlType.ToString());
			}
			if (HasSize(sqlType))
			{
				builder.AppendFormat("({0})", ((size == 0x7fffffff) || (size == -1)) ? "MAX" : size.ToString(CultureInfo.InvariantCulture));
			}
			else if (HasPrecision(sqlType))
			{
				builder.Append("(");
				builder.Append(precision);
				if (HasScale(sqlType))
				{
					builder.Append(",");
					builder.Append(scale);
				}
				builder.Append(")");
			}
			else if (HasDateTimePrecision(sqlType))
			{
				builder.Append("(");
				builder.Append(scale);
				builder.Append(")");
			}
			if (nonNull)
			{
				builder.Append(" NOT NULL");
			}
			if (isAutoIncrement)
			{
				if (sqlType == SqlDbType.UniqueIdentifier)
				{
					builder.Append(" ROWGUIDCOL");
				}
				else
				{
					builder.Append(" IDENTITY");
				}
			}
			return builder.ToString();
		}

		private void GetTableColumns(Table table)
		{
			string schema = this.tableSchemas[table];
			string brackettedName = GetBrackettedName(schema, table.Name);
			string sql = "select * from " + brackettedName + " where 1=0";

			using (DbCommand command = this.connectionManager.CreateCommand(sql))
			{
				DataTable meta = null;
				DataTable extendedColumnInfoTable = null;
				try
				{
					CommandBehavior behavior = (this.connectionManager.ConnectionType == ConnectionType.SqlCE) ? (CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly) : CommandBehavior.Default;
					using (DbDataReader reader = command.ExecuteReader(behavior))
					{
						meta = reader.GetSchemaTable();
					}
					if (this.connectionManager.ConnectionType != ConnectionType.SqlCE)
					{
						command.CommandText = $@"select * 
from INFORMATION_SCHEMA.COLUMNS 
where TABLE_SCHEMA = '{table.Schema}' and TABLE_NAME = '{table.Name}'
order by ORDINAL_POSITION";

						//command.CommandText = "SELECT sc.name AS ColumnName, sc.iscomputed AS IsComputed, text AS Definition FROM syscolumns sc LEFT OUTER JOIN syscomments scm ON sc.id = scm.id AND scm.number = sc.colid WHERE sc.id = OBJECT_ID(@p0)";
						//DbParameter parameter = CreateParameter(command, "@p0", SqlDbType.NVarChar);
						//parameter.Value = brackettedName;
						//command.Parameters.Add(parameter);
						using (DbDataReader reader2 = command.ExecuteReader())
						{
							extendedColumnInfoTable = new DataTable
							{
								Locale = CultureInfo.InvariantCulture
							};
							extendedColumnInfoTable.Load(reader2);
						}
					}
					this.GetTableColumns(meta, table, extendedColumnInfoTable);
				}
				catch (SqlException exception)
				{
					this.LogTableOrViewError(table, exception, false);
				}
				catch (Exception exception2)
				{
					this.LogTableOrViewError(table, exception2, true);
				}
			}
		}

		private void GetTableColumns(DataTable meta, Table table, DataTable extendedColumnInfoTable)
		{
			DataColumn column = meta.Columns["AllowDBNull"];
			DataColumn column2 = meta.Columns["ColumnName"];
			DataColumn column3 = meta.Columns["ColumnSize"];
			DataColumn column4 = meta.Columns["IsAutoIncrement"];
			DataColumn column5 = meta.Columns["IsLong"];
			DataColumn column6 = meta.Columns["IsRowVersion"];
			DataColumn column7 = meta.Columns["NumericPrecision"];
			DataColumn column8 = meta.Columns["NumericScale"];
			DataColumn column9 = meta.Columns["ProviderType"];
			foreach (DataRow row in meta.Rows)
			{
				//Func<DataRow, bool> predicate = null;
				string columnName = (string)ValueOrDefault(row[column2], null);
				if (((this.connectionManager.ConnectionType != ConnectionType.SqlCE) || (columnName == null)) || !columnName.StartsWith("__sys", StringComparison.OrdinalIgnoreCase))
				{
					object sqlColumnType = row[column9];
					string legalLanguageName = GetLegalLanguageName(columnName);
					SqlDbType sqlDbType = DbTypeSystem.Parse(ValueOrDefault(sqlColumnType, SqlDbType.Char).ToString());
					if (sqlDbType == SqlDbType.Udt)
					{
						if (this.display != null)
						{
							this.display(Severity.Error, SqlMetal.Strings.UnableToExtractColumnBecauseOfUDT(columnName, table.Name));
						}
					}
					else
					{
						System.Type closestRuntimeType = DbTypeSystem.GetClosestRuntimeType(sqlDbType);
						Column item = null;
						if ((legalLanguageName == null) || (legalLanguageName.Length == 0))
						{
							legalLanguageName = "Column";
						}
						if (!Naming.IsUniqueTableClassMemberName(legalLanguageName, table))
						{
							legalLanguageName = Naming.GetUniqueTableMemberName(table, legalLanguageName);
						}
						item = new Column()
						{
							PropertyType = GetScopedTypeName(closestRuntimeType),
							Name = QuoteIfNeeded(columnName),
							Member = legalLanguageName
						};
						bool isAutoIncrement = (bool)ValueOrDefault(row[column4], false);
						if (isAutoIncrement)
						{
							item.IsDbGenerated = true;
							item.IsReadOnly = false;
						}

						////DataRow row2 = null;
						////if (extendedColumnInfoTable != null)
						////{
						////    if (predicate == null)
						////    {
						////        predicate = r => string.Compare((string) r["ColumnName"], name, StringComparison.OrdinalIgnoreCase) == 0;
						////    }
						////    row2 = extendedColumnInfoTable.Rows.OfType<DataRow>().First<DataRow>(predicate);
						////}
						////if ((row2 != null) && (((int) row2["IsComputed"]) == 1))
						////{
						////    string str3 = (string) ValueOrDefault(row2["Definition"], "");
						////    if (!string.IsNullOrEmpty(str3))
						////    {
						////        item.Expression = str3;
						////    }
						////}

						if ((bool)ValueOrDefault(row[column5], false))
						{
							item.UpdateCheck = (UpdateCheck)1;
						}
						if (!string.IsNullOrEmpty(item.Expression))
						{
							item.UpdateCheck = (UpdateCheck)1;
						}
						bool? nullable;
						bool canBeNull = !((bool)ValueOrDefault(row[column], false)) ? false : !((nullable = item.IsPrimaryKey).HasValue ? nullable.GetValueOrDefault() : false);
						int size = (int)ValueOrDefault(row[column3], 0);
						if (canBeNull && closestRuntimeType.IsValueType)
						{
							item.CanBeNull = true;
						}
						else if (!canBeNull && !closestRuntimeType.IsValueType)
						{
							item.CanBeNull = false;
						}
						if (((bool)ValueOrDefault(row[column6], false)) || (sqlDbType == SqlDbType.Timestamp))
						{
							item.IsVersion = true;
							item.IsReadOnly = false;
						}
						short precision = (short)ValueOrDefault(row[column7], (short)(-1));
						short scale = (short)ValueOrDefault(row[column8], (short)(-1));
						
						item.SqlColumnType = GetSqlTypeDeclaration(sqlDbType, size, precision, scale, false, false);
						item.DbType = GetSqlTypeDeclaration(sqlDbType, size, precision, scale, !canBeNull, isAutoIncrement);
						item.CanBeNull = new bool?(canBeNull);
						table.Type.Columns.Add(item);

						if (extendedColumnInfoTable != null)
						{
							DataRow row1 = extendedColumnInfoTable.Rows.Cast<DataRow>()
								.Where(p => object.Equals(p["COLUMN_NAME"], columnName))
								.FirstOrDefault();

							item.ColumnDefaultNetValue = CreateColumnDefaultNetValue(row1["COLUMN_DEFAULT"], closestRuntimeType);
							
						}
					}
				}
			}
		}

		private string CreateColumnDefaultNetValue(object colDefaultValue, System.Type closestRuntimeType)
		{
			if(colDefaultValue == null || colDefaultValue == System.DBNull.Value)
			{
				return null;
			}
			else if (colDefaultValue is string str1 && str1.Equals("NULL", StringComparison.OrdinalIgnoreCase))
			{
				return "null";
			}
			else
			{
				string str2 = colDefaultValue.ToString().Trim('\'', ' ', '"', ')', '(');

				if (string.Equals(str2, "getdate", StringComparison.OrdinalIgnoreCase) && closestRuntimeType == typeof(DateTime))
				{
					return "/*getdate()*/ DateTime.Now";
				}
				else if(string.Equals(str2, "newid", StringComparison.OrdinalIgnoreCase) && closestRuntimeType == typeof(System.Guid))
				{
					return "/*newid()*/ Guid.NewGuid()";
				}
				else if (closestRuntimeType == typeof(string))
				{
					return "\"" + str2 + "\"";
				}
				else if (Calysto.Utility.CalystoTypeConverter.TryChangeType(str2, closestRuntimeType, out object res3))
				{
					if (closestRuntimeType == typeof(bool))
						return object.Equals(res3, true) ? "true" : "false";
					else if (closestRuntimeType == typeof(DateTime) && res3 is DateTime dt1)
						return $"/*{str2}*/ new DateTime({dt1.Ticks})";
					else
					{
						// have to cast to appropriate type, eg. decimal, double, long...
						return $"({EFUtility.GetColumnType(closestRuntimeType.FullName, false)})({res3})";
					}
				}
			}
			return null;
		}

		private void GetSchemas()
		{
			string sql = @"SELECT 
	TABLE_CATALOG as [DATABASE], 
	TABLE_SCHEMA AS [SCHEMA], 
	TABLE_NAME AS [NAME], 
	TABLE_TYPE AS [TYPE], 
	TABLE_SCHEMA + '.' + TABLE_NAME AS FULLNAME 
FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT 
	ROUTINE_CATALOG AS [DATABASE], 
	ROUTINE_SCHEMA AS [SCHEMA], 
	ROUTINE_NAME AS [NAME], 
	ROUTINE_TYPE AS [TYPE], 
	ROUTINE_SCHEMA + '.' + ROUTINE_NAME AS FULLNAME 
FROM INFORMATION_SCHEMA.ROUTINES
";
			using (DbCommand command = this.connectionManager.CreateCommand(sql))
			{
				using (DbDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						SchemaObject sch1 = new SchemaObject()
						{
							Database = reader["DATABASE"]+"",
							Schema = reader["SCHEMA"] + "",
							Name = reader["NAME"] + "",
							FullName = reader["FULLNAME"] + "",
						};

						this.schemaObjects.Add(sch1);
						this.schemas.Add(sch1.Schema);
					}
				}
			}
		}

		private void GetTablesAndViews()
		{
			string sql = "SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES ";
			if (this.connectionManager.ConnectionType == ConnectionType.SqlCE)
			{
				sql = sql + "WHERE TABLE_TYPE <> 'SYSTEM TABLE' ";
			}
			else
			{
				sql = sql + "WHERE ISNULL(OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'IsMSShipped'), 0) = 0 ";
			}
			sql = sql + "ORDER BY TABLE_NAME";
			using (DbCommand command = this.connectionManager.CreateCommand(sql))
			{
				using (DbDataReader reader = command.ExecuteReader())
				{
					StringBuilder sb = new StringBuilder();
					while (reader.Read())
					{
						string databaseName = (string)ValueOrDefault(reader["TABLE_CATALOG"], "");
						string tableSchema = (string)ValueOrDefault(reader["TABLE_SCHEMA"], "");
						string tableName = (string)ValueOrDefault(reader["TABLE_NAME"], "");
						string tableType = ((string)ValueOrDefault(reader["TABLE_TYPE"], "")).Trim();

						if ((string.Compare(tableName, "SYSDIAGRAMS", StringComparison.OrdinalIgnoreCase) != 0) && ((((string.Compare("BASE TABLE", tableType, StringComparison.Ordinal) == 0) || (string.Compare("TABLE", tableType, StringComparison.Ordinal) == 0)) && ((this.options.Types & ExtractTypes.Tables) != 0)) || ((string.Compare("VIEW", tableType, StringComparison.Ordinal) == 0) && ((this.options.Types & ExtractTypes.Views) != 0))))
						{
							string legalLanguageName = GetLegalLanguageName(tableSchema, tableName);

							Table table1 = new Table()
							{
								Database = databaseName,
								Schema = tableSchema,
								Name = tableName,
								Member = legalLanguageName,
								Kind = DbObjectKind.Table
							};

							if (!this.options.MayGenerate(table1.FullName))
								continue;

							DatabaseItemSetting sett1 = null;
							if (this.options.SelectionDic?.TryGetValue(table1.FullName, out sett1) == true && !string.IsNullOrEmpty(sett1.CSharpName))
							{
								table1.Member = legalLanguageName = sett1.CSharpName;
							}

							string className = legalLanguageName;
							if (this.options.Pluralize)
							{
								CopyStringToStringBuilder(sb, legalLanguageName);
								legalLanguageName = Naming.MakePluralName(sb.ToString());
								CopyStringToStringBuilder(sb, className);
								className = Naming.MakeSingularName(sb.ToString());
								if ((className == null) || (className.Length == 0))
								{
									className = "Class";
								}
							}
							if (!this.IsUniqueClassName(className) || Shared.ReservedTypeNames.Contains<string>(className))
							{
								className = this.GetUniqueClassName(className);
							}
							if (!this.IsUniqueContextMemberName(legalLanguageName))
							{
								legalLanguageName = this.GetUniqueMemberName(legalLanguageName);
							}

							LinqToSqlShared.DbmlObjectModel.Type type = new LinqToSqlShared.DbmlObjectModel.Type() { TypeName = className };
							table1.Type = type;

							this.tableSchemas.Add(table1, tableSchema);
							this.dbml.Tables.Add(table1);
							if (string.Compare("VIEW", tableType, StringComparison.Ordinal) == 0)
							{
								table1.Kind = DbObjectKind.View;
								this.views.Add(table1);
							}
						}
					}
				}
			}
			foreach (Table table2 in this.dbml.Tables)
			{
				try
				{
					this.GetTableColumns(table2);
				}
				catch (SqlException exception)
				{
					this.LogTableOrViewError(table2, exception, false);
				}
				catch (Exception exception2)
				{
					this.LogTableOrViewError(table2, exception2, true);
				}
			}
			foreach (Table table3 in this.views)
			{
				RemovePrimaryKeyAttributeForViews(table3);
			}
		}

		private string GetUniqueClassName(string candidateLegalLanguageName)
		{
			return Naming.GetUniqueName(candidateLegalLanguageName, new Predicate<string>(this.IsUniqueClassName));
		}

		private void GetUniqueKeys()
		{
			if (this.connectionManager.ConnectionType != ConnectionType.SqlCE)
			{
				string sql = @"
                  select tc.CONSTRAINT_SCHEMA,
                    tc.CONSTRAINT_NAME,
                    pkcol.ORDINAL_POSITION,
                    (select count(*) 
                        from INFORMATION_SCHEMA.KEY_COLUMN_USAGE kc
                        where tc.CONSTRAINT_SCHEMA = kc.CONSTRAINT_SCHEMA and
                              tc.CONSTRAINT_NAME = kc.CONSTRAINT_NAME and
                              ISNULL(OBJECTPROPERTY(OBJECT_ID(tc.TABLE_NAME), 'IsMSShipped'), 0) = 0)
                              as COUNT,
                    pkcol.TABLE_SCHEMA as pkSchema,
                    pkcol.TABLE_NAME as pkTable,
                    pkcol.COLUMN_NAME as pkColumn
                from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc,
               INFORMATION_SCHEMA.KEY_COLUMN_USAGE as pkcol
                  where tc.CONSTRAINT_SCHEMA = pkcol.CONSTRAINT_SCHEMA and
                        tc.CONSTRAINT_NAME = pkcol.CONSTRAINT_NAME and
                        tc.CONSTRAINT_TYPE = 'UNIQUE' and
                        ISNULL(OBJECTPROPERTY(OBJECT_ID(tc.TABLE_NAME), 'IsMSShipped'), 0) = 0
                  order by 
                     tc.CONSTRAINT_SCHEMA,
                     tc.CONSTRAINT_NAME,
                     pkcol.ORDINAL_POSITION ";
				using (DbCommand command = this.connectionManager.CreateCommand(sql))
				{
					using (DbDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int num = (int)reader["COUNT"];
							string schema = (string)reader["pkSchema"];
							string strA = (string)reader["pkTable"];
							string item = (string)reader["pkColumn"];
							if (string.Compare(strA, "SYSDIAGRAMS", StringComparison.OrdinalIgnoreCase) != 0)
							{
								string fullName = GetFullName(schema, strA);
								Table key = this.FindTable(fullName);
								if (key != null)
								{
									UniqueConstraint constraint = new UniqueConstraint
									{
										KeyColumns = { item }
									};
									while ((num > 1) && reader.Read())
									{
										item = (string)reader["pkColumn"];
										constraint.KeyColumns.Add(item);
										num--;
									}
									if (this.uniqueConstraints.ContainsKey(key))
									{
										this.uniqueConstraints[key].Add(constraint);
									}
									else
									{
										this.uniqueConstraints.Add(key, new List<UniqueConstraint>());
										this.uniqueConstraints[key].Add(constraint);
									}
								}
							}
						}
					}
				}
			}
		}

		private string GetUniqueMemberName(string candidateLegalLanguageName)
		{
			return Naming.GetUniqueName(candidateLegalLanguageName, new Predicate<string>(this.IsUniqueContextMemberName));
		}

		private static bool HasDateTimePrecision(SqlDbType type)
		{
			switch (type)
			{
				case SqlDbType.Time:
				case SqlDbType.DateTime2:
				case SqlDbType.DateTimeOffset:
					return true;
			}
			return false;
		}

		private static bool HasPrecision(SqlDbType type)
		{
			SqlDbType type2 = type;
			return (type2 == SqlDbType.Decimal);
		}

		private static bool HasScale(SqlDbType type)
		{
			SqlDbType type2 = type;
			return (type2 == SqlDbType.Decimal);
		}

		private static bool HasSize(SqlDbType type)
		{
			switch (type)
			{
				case SqlDbType.Binary:
				case SqlDbType.Char:
				case SqlDbType.NChar:
				case SqlDbType.NVarChar:
				case SqlDbType.VarBinary:
				case SqlDbType.VarChar:
					return true;
			}
			return false;
		}

		private void InferAssociationPropertyName(Table table, Association assoc)
		{
			bool manyHasSuffix = !string.IsNullOrEmpty(this.options.CollectionNavigationPropSufix);
			string legalLanguageName = null;

			// if FK name starts with any of options.FkPrefixes, we have to take fk name as property name
			string fkPrefix = this.options.FkPrefixesForPropName?.Where(o => assoc.Name?.StartsWith(o) == true).FirstOrDefault();
			if(fkPrefix != null)
			{
				// FKEF_HomeMemberAddress, use "HomeMemberAddress" as navigation property name
				legalLanguageName = assoc.Name.Substring(fkPrefix.Length);
			}
			else
			{
				legalLanguageName = GetLegalLanguageName(assoc.Type);
			}

			StringBuilder sb = new StringBuilder();
			if (((Cardinality)assoc.Cardinality) == Cardinality.Many)
			{
				if (manyHasSuffix)
				{
					legalLanguageName += this.options.CollectionNavigationPropSufix;
				}
				else if (this.options.Pluralize)
				{
					CopyStringToStringBuilder(sb, legalLanguageName);
					legalLanguageName = Naming.MakePluralName(sb.ToString());
				}
			}
			else if (!manyHasSuffix && this.options.Pluralize)
			{
				legalLanguageName = Naming.MakeSingularName(legalLanguageName);
			}
			if (((assoc.Member != legalLanguageName) && Naming.IsUniqueTableClassMemberName(legalLanguageName, table)) && ((assoc.Type != table.Type.TypeName) || (((Cardinality)assoc.Cardinality) == Cardinality.One)))
			{
				assoc.Member = legalLanguageName;
			}
			else
			{
				string[] thisKey = assoc.GetThisKey();
				if (thisKey.Length == 1)
				{
					legalLanguageName = GetLegalLanguageName(thisKey[0]);
					bool endsWithID = legalLanguageName.EndsWith("id", StringComparison.CurrentCultureIgnoreCase);
					if ((legalLanguageName.Length > 4) && endsWithID)
					{
						legalLanguageName = legalLanguageName.Substring(0, legalLanguageName.Length - 2);
						if (manyHasSuffix)
						{
							if (((Cardinality)assoc.Cardinality) == Cardinality.Many)
							{
								legalLanguageName += this.options.CollectionNavigationPropSufix;
							}
						}
						else if (this.options.Pluralize)
						{
							if (((Cardinality)assoc.Cardinality) == Cardinality.One)
							{
								legalLanguageName = Naming.MakeSingularName(legalLanguageName);
							}
							else
							{
								CopyStringToStringBuilder(sb, legalLanguageName);
								legalLanguageName = Naming.MakePluralName(sb.ToString());
							}
						}
						if ((assoc.Member != legalLanguageName) && Naming.IsUniqueTableClassMemberName(legalLanguageName, table))
						{
							assoc.Member = legalLanguageName;
							return;
						}
					}
					else if (!endsWithID)
					{
						string name = GetLegalLanguageName(assoc.Type);
						if (((Cardinality)assoc.Cardinality) == Cardinality.One)
						{
							if (!manyHasSuffix && this.options.Pluralize)
							{
								name = Naming.MakeSingularName(name);
							}
						}
						else if (manyHasSuffix)
						{
							name += this.options.CollectionNavigationPropSufix;
						}
						else if (this.options.Pluralize)
						{
							CopyStringToStringBuilder(sb, name);
							name = Naming.MakePluralName(sb.ToString());
						}
						legalLanguageName = legalLanguageName + name;
						if ((assoc.Member != legalLanguageName) && Naming.IsUniqueTableClassMemberName(legalLanguageName, table))
						{
							assoc.Member = legalLanguageName;
							return;
						}
					}
				}
				if (assoc.Name != null)
				{
					legalLanguageName = assoc.Name;
					if (string.Compare(legalLanguageName, 0, "fk_", 0, 3, StringComparison.OrdinalIgnoreCase) == 0)
					{
						legalLanguageName = legalLanguageName.Substring(3);
					}
					else if (string.Compare(legalLanguageName, 0, "fk", 0, 2, StringComparison.OrdinalIgnoreCase) == 0)
					{
						legalLanguageName = legalLanguageName.Substring(2);
					}
					legalLanguageName = GetLegalLanguageName(legalLanguageName);
					if (manyHasSuffix)
					{
						if (assoc.Cardinality == Cardinality.Many)
						{
							legalLanguageName += this.options.CollectionNavigationPropSufix;
						}
					}
					else if (this.options.Pluralize)
					{
						if (((Cardinality)assoc.Cardinality) == Cardinality.One)
						{
							legalLanguageName = Naming.MakeSingularName(legalLanguageName);
						}
						else
						{
							CopyStringToStringBuilder(sb, legalLanguageName);
							legalLanguageName = Naming.MakePluralName(sb.ToString());
						}
					}
					if ((assoc.Member != legalLanguageName) && Naming.IsUniqueTableClassMemberName(legalLanguageName, table))
					{
						assoc.Member = legalLanguageName;
						return;
					}
				}
				assoc.Member = Naming.GetUniqueTableMemberName(table, legalLanguageName);
			}
		}

		private bool IsOneToOne(Table table, string[] keyColumns)
		{
			List<DbmlKeyColumn> a = new List<DbmlKeyColumn>();
			foreach (Column column in table.Type.Columns)
			{
				if (column.IsPrimaryKey == true)
				{
					DbmlKeyColumn item = new DbmlKeyColumn
					{
						Name = column.Name
					};
					a.Add(item);
				}
			}
			if ((a.Count != 0) && ColumnsMatch(a, keyColumns))
			{
				return true;
			}
			if (this.uniqueConstraints.ContainsKey(table))
			{
				foreach (UniqueConstraint constraint in this.uniqueConstraints[table])
				{
					if (ColumnsMatch(constraint.KeyColumns, keyColumns))
					{
						return true;
					}
				}
			}
			if (this.uniqueIndexes.ContainsKey(table))
			{
				foreach (UniqueIndex index in this.uniqueIndexes[table])
				{
					if (ColumnsMatch(index.KeyColumns, keyColumns))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool IsSameSet(List<DbmlKeyColumn> list1, List<string> list2)
		{
			return ((from key in list1 select key.Name).Except<string>(list2).Count<string>() == 0);
		}

		private static bool IsSameSet(List<string> list1, List<string> list2)
		{
			return (list1.Except<string>(list2).Count<string>() == 0);
		}

		private bool IsUniqueClassName(string legalLanguageName)
		{
			return !this.MatchingTypeExists(legalLanguageName);
		}

		private bool IsUniqueContextMemberName(string legalLanguageName)
		{
			if (Naming.IsSameName(this.dbml.ContextClass, legalLanguageName))
				return false;
			
			if(Naming.IsSameName(this.dbml.DatabaseName, legalLanguageName))
				return false;

			if (this.MatchingFunctionMethodExists(legalLanguageName))
				return false;

			if (this.MatchingTableMemberExists(legalLanguageName))
				return false;

			return true;
		}

		private static bool IsUnquoted(string s)
		{
			if (s.StartsWith("[", StringComparison.Ordinal))
			{
				return !s.EndsWith("]", StringComparison.Ordinal);
			}
			return true;
		}

		private void LogFunctionSchemaError(LinqToSqlShared.DbmlObjectModel.Function routine, string errorMsg)
		{
			string str;
			if (!this.functionsWithErrors.Contains(routine))
			{
				this.functionsWithErrors.Add(routine);
			}
			errorMsg = errorMsg.Replace("\r\n", " ");
			if (routine.Kind == DbObjectKind.Procedure)
			{
				str = SqlMetal.Strings.UnableToExtractSproc(routine.Name, errorMsg);
			}
			else
			{
				str = SqlMetal.Strings.UnableToExtractFunction(routine.Name, errorMsg);
			}
			if (this.display != null)
			{
				this.display(Severity.Error, str);
			}
		}

		private void LogTableOrViewError(Table table, Exception exception, bool showStack)
		{
			string str = exception.Message.Replace("\r\n", " ");
			str = SqlMetal.Strings.UnableToExtractTable(table.Name, str);
			if (this.views.Contains(table))
			{
				str = SqlMetal.Strings.UnableToExtractView(table.Name, str);
			}
			if (showStack)
			{
				str = str + "\n" + exception.StackTrace;
			}
			if (this.display != null)
			{
				this.display(Severity.Error, str);
			}
		}

		private bool MatchingFunctionMethodExists(string legalLanguageName)
		{
			return this.dbml.Functions.Exists(f => Naming.IsSameName(f.Method, legalLanguageName));
		}

		private bool MatchingTableMemberExists(string legalLanguageName)
		{
			return this.dbml.Tables.Exists(t => Naming.IsSameName(t.Member, legalLanguageName));
		}

		private bool MatchingTypeExists(string legalLanguageName)
		{
			if (Naming.IsSameName(this.dbml.ContextClass, legalLanguageName))
				return true;
			else if (Naming.IsSameName(this.dbml.DatabaseName, legalLanguageName))
				return true;
			else if (this.dbml.Tables.Exists(t => Naming.IsSameName(t.Type.TypeName, legalLanguageName)))
				return true;
			else
				return false;
		}

		private static bool NeedsQuoting(string s)
		{
			return (SqlRequiresQuoting(s) && !RuntimeWillQuoteCorrectly(s));
		}

		private static string QuoteIfNeeded(string s)
		{
			if (NeedsQuoting(s))
			{
				SqlCommandBuilder builder = new SqlCommandBuilder();
				return builder.QuoteIdentifier(s);
			}
			return s;
		}

		private static string QuoteIfNeeded(string schema, string id)
		{
			SqlCommandBuilder builder = new SqlCommandBuilder();
			bool flag = NeedsQuoting(schema);
			bool flag2 = NeedsQuoting(id);
			if (flag && id.EndsWith("]", StringComparison.Ordinal))
			{
				flag2 = true;
			}
			if (flag2 && schema.StartsWith("[", StringComparison.Ordinal))
			{
				flag = true;
			}
			if ((schema.StartsWith("[", StringComparison.Ordinal) && id.EndsWith("]", StringComparison.Ordinal)) || (schema.Contains(".") || id.Contains(".")))
			{
				flag2 = true;
				flag = true;
			}
			if (flag)
			{
				schema = builder.QuoteIdentifier(schema);
			}
			if (flag2)
			{
				id = builder.QuoteIdentifier(id);
			}
			return (schema + "." + id);
		}

		private static void RemovePrimaryKeyAttributeForViews(Table view)
		{
			if (view != null)
			{
				foreach (Column column in view.Type.Columns)
				{
					column.IsDbGenerated = false;
					column.IsPrimaryKey = false;
				}
			}
		}

		private static bool RuntimeWillQuoteCorrectly(string s)
		{
			if (s == null)
			{
				throw SqlMetal.Error.ArgumentNull("s");
			}
			if (s.Length < 2)
			{
				return true;
			}
			if (s.StartsWith("@", StringComparison.Ordinal))
			{
				return false;
			}
			if (s.IndexOf(namepartDelimiter) >= 0)
			{
				return false;
			}
			return IsUnquoted(s);
		}

		private static bool SqlRequiresQuoting(string s)
		{
			return (s.IndexOfAny(specialCharacters) >= 0);
		}

		private static object ValueOrDefault(object value, object defvalue)
		{
			if ((value != DBNull.Value) && (value != null))
			{
				return value;
			}
			return defvalue;
		}

		private class DbmlKeyColumn
		{
			internal string Name;
		}

		private class UniqueConstraint
		{
			private List<string> keyColumns = new List<string>();

			internal List<string> KeyColumns
			{
				get
				{
					return this.keyColumns;
				}
			}
		}

		private class UniqueIndex
		{
			private List<string> keyColumns = new List<string>();

			internal List<string> KeyColumns
			{
				get
				{
					return this.keyColumns;
				}
			}
		}
	}
}

