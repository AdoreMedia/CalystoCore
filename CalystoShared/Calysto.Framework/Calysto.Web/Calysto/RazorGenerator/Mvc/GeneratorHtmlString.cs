namespace Calysto.RazorGenerator.Mvc
{
	public class GeneratorHtmlString : IGeneratorHtmlString
	{
		readonly string _html;

		public GeneratorHtmlString(string html)
		{
			_html = html ?? string.Empty; 
		}

		public string ToHtmlString() => _html;

		public override string ToString() => this.ToHtmlString();
	}
}