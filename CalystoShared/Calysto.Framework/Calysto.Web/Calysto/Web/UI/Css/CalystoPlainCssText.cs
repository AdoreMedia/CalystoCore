namespace Calysto.Web.UI.Css
{
	public class CalystoPlainCssText : ICalystoCssItem
	{
		private string _cssText;

		public CalystoPlainCssText(string cssText)
		{
			_cssText = cssText;
		}

		public string ToCssString()
		{
			return _cssText;
		}

		public CalystoPlainCssText AddToStyleSheet(CalystoStyleSheet sheet)
		{
			sheet.Add(this);
			return this;
		}


		public CalystoPlainCssText Clone()
		{
			return new CalystoPlainCssText(this._cssText);
		}

		ICalystoCssItem ICalystoCssItem.Clone()
		{
			return this.Clone();
		}
	}
}
