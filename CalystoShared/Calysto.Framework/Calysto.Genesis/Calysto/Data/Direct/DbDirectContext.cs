using Calysto.Data.DatabaseSchema;
using Calysto.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Calysto.Data.Direct
{
	public class DbDirectContext
	{
		public DbConnection Connection { get; private set; }

		public DbTransaction CurrentTransaction { get; set; }

		/// <summary>
		/// Command timeout [seconds]
		/// </summary>
		public int? CommandTimeout { get; set; }

		public DbDirectContext(DbConnection connection)
		{
			this.Connection = connection;
		}

		public DbCommand CreateCommand()
		{
			DbCommand cmd = this.Connection.CreateCommand();
			cmd.Transaction = this.CurrentTransaction;
			if (this.CommandTimeout.HasValue)
				cmd.CommandTimeout = this.CommandTimeout.Value;

			return cmd;
		}

		private string FormatException(DbCommand cmd)
		{
			return cmd.CommandText
				+ "\r\n"
				+ string.Join("\r\n", cmd.Parameters.Cast<DbParameter>().Select(o => o.ParameterName + " (" + o.DbType + ") = " + o.Value + "; "));
		}

		/// <summary>
		/// Execute command and return affected records count.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public int ExecuteCommand(string command, params object[] parameters)
		{
			int rows = -1;

			this.UsingConnection((state) =>
			{
				rows = DbQueryBuilder.PrepareCommand(CreateCommand(), command, parameters).ExecuteNonQuery();
			});

			return rows;
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

		/// <summary>
		/// Execute query and return data set.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public DataSet ExecuteDataSet(string command, params object[] parameters)
		{
			DataSet ds = new DataSet();

			this.UsingConnection((state) =>
			{
				var reader = DbQueryBuilder.PrepareCommand(CreateCommand(), command, parameters).ExecuteReader();
				// do-while to read multiple tables from reader
				do
				{
					DataTable table = new DataTable();
					SchemaReader schemaReader = new SchemaReader(reader.GetSchemaTable());
					// add columns to table
					schemaReader.ReadColumns().ToList().ForEach(col => table.Columns.Add(col.ColumnName, col.DataType));
					// add data to table
					GetDataRows(reader).ToList().ForEach(rowArr => table.Rows.Add(rowArr));

					ds.Tables.Add(table);
				}
				while (reader.NextResult());

				reader.Close();
			});

			return ds;
		}

		/// <summary>
		/// Prepare multiple results reader. To read data from database, invoke .ReadResults(m=>...}
		/// </summary>
		/// <param name="command"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public MultipleResultsReader ExecuteMultipleResults(string command, params object[] parameters)
		{
			var fnPrepareCmd = new Func<DbCommand>(() => DbQueryBuilder.PrepareCommand(this.CreateCommand(), command, parameters));
			return new MultipleResultsReader(this, fnPrepareCmd);
		}

		public List<TResult> ExecuteList<TResult>(string command, params object[] parameters)
		{
			return this.ExecuteMultipleResults(command, parameters).ReadResults(mm => mm.GetSequence<TResult>().ToList());
		}

		public void ExecuteBulkInsert<TEntity>(string tableName, IEnumerable<TEntity> items, bool identityInsert = false, int batchSize = 10000, List<string> members = null)
		{
			if (!items.Any()) return;

			SqlIdentifier ident = SqlIdentifier.GetIdentifier(this.Connection);

			string schemaQuery = $"select * from {ident.QuoteCompoundIdentifier(tableName)} where 1=2";

			// don't use select top x, instead use query like this, it works with all db providers:
			DataTable dt = this.ExecuteDataSet(schemaQuery).Tables[0];

			var dicProps = items.First().GetType().GetProperties().ToDictionary(p => p.Name.ToLower());

			this.UsingConnection(state =>
			{
				//if (ident.IsSqlServer)
				//{
				//	foreach (var item in items)
				//	{
				//		// it is important to have values[] in the exact the same order as dt.Columns
				//		object[] values = dt.Columns.Cast<DataColumn>().Select(o => dicProps.GetValueOrDefault(o.ColumnName.ToLower())?.GetValue(item)).ToArray();
				//		dt.Rows.Add(values);
				//		if(dt.Rows.Count >= batchSize)
				//		{
				//			// write to db as soon as batchSize rows is created
				//			ExecSqlBulkCopy(identityInsert, batchSize, tableName, dt);
				//			// clear inserted rows
				//			dt.Rows.Clear();
				//		}
				//	}

				//	if (dt.Rows.Count > 0)
				//	{
				//		ExecSqlBulkCopy(identityInsert, batchSize, tableName, dt);
				//	}

				//}
				//else
				{
					// SQLite, MySQL, Access allows to insert value into idenitity column if value is not null, there is no need IDENTITY_INSERT command
					// SQLite always allows inserting a value into the primary key column; automatically generated values are used only when the inserted value is NULL (explicitly or omitted).

					List<SchemaColumn> schemaColumns = null;

					using (DbCommand cmd1 = this.CreateCommand())
					{
						cmd1.CommandText = schemaQuery;
						using (DbDataReader reader1 = cmd1.ExecuteReader())
						{
							SchemaReader schemaReader = new SchemaReader(reader1.GetSchemaTable());
							schemaColumns = schemaReader.ReadColumns().ToList();
						}
					}

					if (identityInsert && ident.UseIdentityInsertCommand)
					{
						this.ExecuteCommand("SET IDENTITY_INSERT " + ident.QuoteCompoundIdentifier(tableName) + " ON");
					}

					members = members ?? schemaColumns.Where(o => !o.IsAutoIncrement && !o.IsReadOnly).Select(o => o.ColumnName).ToList();

					string colNames = string.Join(", ", members.Select(o => ident.QuoteCompoundIdentifier(o)).ToArray());

					// Obviously the limit number of parameters for MS-SQL is 2100 whereas it is 65535 for MySQL.
					// parameters count has to be less than 2100, because on 2100 throws exception
					int size2 = (2100 - 1) / members.Count;

					batchSize = Math.Min(size2, batchSize);

					items.Select((o, n) => new
					{
						Index = n,
						Item = o
					})
					.GroupBy(o => o.Index / batchSize)
					.ToList()
					.ForEach(group =>
					{
						// group contains batchSize of items
						// create single insert into statement for every group
						int pkgIndex = 0;

						var package = group.Select((item, index) =>
						{
							object[] valuesArr = new object[members.Count];
							for (int n = 0; n < members.Count; n++)
							{
								valuesArr[n] = dicProps.GetValueOrDefault(members[n].ToLower())?.GetValue(item.Item);
							}

							return new
							{
								Values = valuesArr,
								ParNames = members.Select((o, n) => "{" + (pkgIndex++) + "}").ToArray()
							};
						}).ToList();

						// create single insert into statement
						string insertSql = "INSERT INTO " + ident.QuoteCompoundIdentifier(tableName) + " (" + colNames + ") VALUES "
							+ string.Join(",", package.Select(o => "\r\n(" + string.Join(",", o.ParNames) + ")")); // create: (@p1, @p2), (@p3, @p4), (@p5, p6)

						var valuesAll = package.SelectMany(o => o.Values).ToArray();

						this.ExecuteCommand(insertSql, valuesAll);
					});

					if (identityInsert && ident.UseIdentityInsertCommand)
					{
						this.ExecuteCommand("SET IDENTITY_INSERT " + ident.QuoteCompoundIdentifier(tableName) + " OFF");
					}
				}
			});
		}

		//private void ExecSqlBulkCopy(bool identityInsert, int batchSize, string tableName, DataTable dt)
		//{
		//	// db connection may be closed, so we have to open the connection
		//	this.UseConnection((state) =>
		//	{
		//		using (SqlBulkCopy bulkCopy = new SqlBulkCopy((SqlConnection)state.Connection,
		//						identityInsert ? SqlBulkCopyOptions.KeepIdentity : SqlBulkCopyOptions.Default,
		//						(SqlTransaction)this.CurrentTransaction))
		//		{
		//			bulkCopy.BatchSize = batchSize;
		//			bulkCopy.BulkCopyTimeout = this.CommandTimeout ?? this.Connection.ConnectionTimeout;
		//			bulkCopy.DestinationTableName = tableName;
		//			bulkCopy.WriteToServer(dt);
		//		}
		//	});
		//}

	}
}

