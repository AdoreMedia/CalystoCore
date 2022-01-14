namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class MySqlIdentifier : SqlIdentifier
		{
			public MySqlIdentifier()
			{
				this.ConnectionName = "MySqlConnection";
				this.Provider = ProviderName.MySql;
				this.ParameterPrefix = "?";
				this.QuotePrefix = "`";
				this.QuoteSuffix = "`";
			}
		}
	}
}
