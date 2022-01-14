using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Calysto.Data.Direct
{
	using Providers;

	public enum ProviderName
	{
		MSSQL,
		Odbc,
		OleDb,
		SQLite,
		Sqlite,
		SqlCe,
		MySql,
		Oracle,
		Npgsql
	}

	public abstract class SqlIdentifier
	{
		protected virtual ProviderName Provider { get; set; }
		public virtual string ConnType { get; protected set; }
		public virtual string ParameterPrefix { get; protected set; } = "@";
		public virtual string QuotePrefix { get; protected set; } = "[";
		public virtual string QuoteSuffix { get; protected set; } = "]";
		public virtual bool UnnamedParms { get; protected set; } = false;
		public virtual bool UseIdentityInsertCommand { get; protected set; } = false;
		public virtual string ConnectionName { get; protected set; }
		
		public bool IsSqlite => this.Provider == ProviderName.SQLite || this.Provider == ProviderName.Sqlite;
		public bool IsSqlServer => this.Provider == ProviderName.MSSQL;
		public bool IsMySql => this.Provider == ProviderName.MySql;

		public string CreateParamName(int indexInString, int uniqueIndex)
		{
			return this.ParameterPrefix + "p" + indexInString + "_" + uniqueIndex;
		}

		public string QuoteCompoundIdentifier(string str)
		{
			var items = str.Split('.').Select(o => o.Trim('`', '[', ']', '\"', ' ', '\r', '\n', '\t', '.'))
				.Where(o => !string.IsNullOrWhiteSpace(o))
				.Select(o => this.QuotePrefix + o + this.QuoteSuffix);
			return string.Join(".", items);
		}

		private static Dictionary<string, SqlIdentifier> _dic = new SqlIdentifier[]
		{
			new MSSQLIdentifier(),
			new OdbcIdentifier(),
			new OleDbIdentifier(),
			new SQLiteIdentifier(),
			new SqliteIdentifier(),
			new MySqlIdentifier(),
			new OracleIdentifier(),
			new NpgsqlIdentifier()
		}.ToDictionary(o => o.ConnectionName);

		public static SqlIdentifier GetIdentifier(DbConnection conn)
		{
			if (_dic.TryGetValue(conn.GetType().Name, out var m))
			{
				return m;
			}

			throw new NotSupportedException(conn.GetType().FullName);
		}
	}
}
