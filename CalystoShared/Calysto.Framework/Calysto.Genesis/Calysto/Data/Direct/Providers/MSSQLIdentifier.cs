namespace Calysto.Data.Direct
{
	namespace Providers
	{
		public class MSSQLIdentifier : SqlIdentifier
		{
			public MSSQLIdentifier()
			{
				this.ConnectionName = "SqlConnection";
				this.Provider = ProviderName.MSSQL;
				this.UseIdentityInsertCommand = true;
			}
		}
	}
}
