namespace Calysto.Web.UI.Css
{
	public interface ICalystoCssItem
	{
		string ToCssString();

		ICalystoCssItem Clone();
	}
}
