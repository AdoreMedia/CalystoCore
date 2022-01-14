namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class OracleIdentifier : SqlIdentifier
		{
			public OracleIdentifier()
			{
				this.ConnectionName = "OracleConnection";
				this.Provider = ProviderName.Oracle;
				this.ParameterPrefix = ":";
				this.QuotePrefix = "\"";
				this.QuoteSuffix = "\"";
			}
		}
	}
}
