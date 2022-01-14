namespace Calysto.Data.Direct
{
	namespace Providers
	{
		/// <summary>
		/// Microsoft provider
		/// </summary>
		public class SqliteIdentifier : SqlIdentifier
		{
			public SqliteIdentifier()
			{
				this.ConnectionName = "SqliteConnection";
				this.Provider = ProviderName.Sqlite;
				this.QuotePrefix = "\"";
				this.QuoteSuffix = "\"";
			}
		}
	}
}
