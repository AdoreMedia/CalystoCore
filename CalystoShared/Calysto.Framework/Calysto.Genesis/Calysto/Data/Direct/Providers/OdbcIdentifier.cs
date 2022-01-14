namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class OdbcIdentifier : SqlIdentifier
		{
			public OdbcIdentifier()
			{
				this.ConnectionName = "OdbcConnection";
				this.Provider = ProviderName.Odbc;
				this.UnnamedParms = true;
			}
		}
	}
}
