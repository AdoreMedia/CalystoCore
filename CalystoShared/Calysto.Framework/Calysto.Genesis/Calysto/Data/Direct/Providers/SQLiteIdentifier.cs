namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class SQLiteIdentifier : SqlIdentifier
		{
			public SQLiteIdentifier()
			{
				this.ConnectionName = "SQLiteConnection";
				this.Provider = ProviderName.SQLite;
			}
		}
	}
}
