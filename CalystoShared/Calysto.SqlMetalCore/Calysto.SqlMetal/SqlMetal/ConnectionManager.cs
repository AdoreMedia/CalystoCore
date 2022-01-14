namespace SqlMetal
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    internal class ConnectionManager : IDisposable
    {
        private DbConnection connection;
        private const string SqlCeProviderInvariantName = "System.Data.SqlServerCe.3.5";
        private int timeout;
        private SqlMetal.ConnectionType type;
        private DbTransaction transaction;

        public void Dispose()
		{
            this.Close();
		}

        internal ConnectionManager(string connectionString, int timeout)
        {
            this.timeout = timeout;
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder {
                ConnectionString = connectionString
            };
            if (builder.ContainsKey("Data Source") && ((string) builder["Data Source"]).EndsWith(".sdf", StringComparison.OrdinalIgnoreCase))
            {
                DbProviderFactory provider = GetProvider("System.Data.SqlServerCe.3.5");
                if (provider == null)
                {
                    throw SqlMetal.Error.ProviderNotInstalled(builder["Data Source"], "System.Data.SqlServerCe.3.5");
                }
                this.connection = provider.CreateConnection();
                this.connection.ConnectionString = connectionString;
                this.type = SqlMetal.ConnectionType.SqlCE;
            }
            else
            {
                this.connection = new SqlConnection(connectionString);
            }
        }

        private void Close()
        {
            if(this.transaction != null)
			{
				try
				{
                    this.transaction.Rollback();
				}
				catch 
                {
                }

                this.transaction = null;
			}

            if (this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }

        internal DbCommand CreateCommand(string sql = null)
        {
            DbCommand command = this.connection.CreateCommand();
            command.Transaction = this.transaction;

            if (sql != null)
                command.CommandText = sql;

            if (this.ConnectionType != SqlMetal.ConnectionType.SqlCE)
                command.CommandTimeout = this.timeout;

            return command;
        }

        internal string GetDatabase()
        {
            this.Open();
            return this.connection.Database;
        }

        private static DbProviderFactory GetProvider(string providerName)
        {
            return System.Data.SqlClient.SqlClientFactory.Instance;

			//if ((from r in DbProviderFactories.GetFactoryClasses().Rows.OfType<DataRow>() select (string)r["InvariantName"]).Contains<string>(providerName, StringComparer.OrdinalIgnoreCase))
			//{
			//	return DbProviderFactories.GetFactory(providerName);
			//}
			//return null;
		}

        internal void Open()
        {
            if (this.connection.State == ConnectionState.Closed)
            {
                this.connection.Open();
            }

            if(this.transaction == null)
			{
                this.transaction = this.connection.BeginTransaction();
			}
        }

        internal SqlMetal.ConnectionType ConnectionType
        {
            get
            {
                if (this.type == SqlMetal.ConnectionType.Unknown)
                {
                    if (this.connection.GetType().Name == "System.Data.SqlServerCe.SqlCeConnection")
                    {
                        this.type = SqlMetal.ConnectionType.SqlCE;
                    }
                    else if (this.IsServer2KOrEarlier)
                    {
                        this.type = SqlMetal.ConnectionType.Sql2000;
                    }
                    else if (this.IsServer2005)
                    {
                        this.type = SqlMetal.ConnectionType.Sql2005;
                    }
                    else
                    {
                        this.type = SqlMetal.ConnectionType.Sql2008;
                    }
                }
                return this.type;
            }
        }

        private bool IsServer2005
        {
            get
            {
                this.Open();
                return this.connection.ServerVersion.StartsWith("09.00", StringComparison.Ordinal);
            }
        }

        private bool IsServer2KOrEarlier
        {
            get
            {
                this.Open();
                string serverVersion = this.connection.ServerVersion;
                if ((!serverVersion.StartsWith("08.00.", StringComparison.Ordinal) && !serverVersion.StartsWith("07.00.", StringComparison.Ordinal)) && (!serverVersion.StartsWith("06.50.", StringComparison.Ordinal) && !serverVersion.StartsWith("06.00.", StringComparison.Ordinal)))
                {
                    return false;
                }
                return true;
            }
        }
    }
}

