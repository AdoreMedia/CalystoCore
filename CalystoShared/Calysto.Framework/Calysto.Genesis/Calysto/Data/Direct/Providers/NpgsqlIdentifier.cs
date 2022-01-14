namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class NpgsqlIdentifier : SqlIdentifier
		{
			public NpgsqlIdentifier()
			{
				this.ConnectionName = "NpgsqlConnection";
				this.Provider = ProviderName.Npgsql;
				this.ParameterPrefix = "@";
				this.QuotePrefix = "\"";
				this.QuoteSuffix = "\"";
			}
		}
	}
}
