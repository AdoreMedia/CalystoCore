namespace Calysto.Genesis.UnitTest.Calysto.TypeLite.Model
{
	public class UrlItem
	{
		public string Name { get; set; }
		public string DataIcon { get; set; }
		public UrlItem(string name, string dataicon)
		{
			this.Name = name;
			this.DataIcon = dataicon;
		}
	}

	public class AdminUrlExample
	{
		//public const string Const1 = "fasdfds";

		//public UrlItem ItemOne;
		//public UrlItem ItemTwo { get; set; }
		//public UrlItem ItemThree = new UrlItem("fasd", "gsadf");
		//public UrlItem ItemFour { get; set; } = new UrlItem("hsadf", "6234");

		public static UrlItem AdministrativeMenu { get; private set; } = new UrlItem("admin", "N");
		public static UrlItem FinancesMenu { get; private set; } = new UrlItem("admin", "N");
		public static UrlItem BookkeepingMenu { get; private set; } = new UrlItem("admin", "N");
		public static UrlItem PosSettingsMenu { get; private set; } = new UrlItem("admin", "N");
		public static UrlItem JobMenu { get; private set; } = new UrlItem("admin", "N");
	}
}