namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class OleDbIdentifier : SqlIdentifier
		{
			public OleDbIdentifier()
			{
				this.ConnectionName = "OleDbConnection";
				this.Provider = ProviderName.OleDb;
				this.UnnamedParms = true;
			}
		}
	}
}
