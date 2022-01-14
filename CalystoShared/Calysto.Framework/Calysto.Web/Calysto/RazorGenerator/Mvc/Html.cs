namespace Calysto.RazorGenerator.Mvc
{
	static class Html
    {
        public static readonly IGeneratorHtmlString Empty = new GeneratorHtmlString(string.Empty);

        public static IGeneratorHtmlString Raw(string input)
        {
            return string.IsNullOrEmpty(input) ? Empty : new GeneratorHtmlString(input);
        }

        public static IGeneratorHtmlString Encode(object input)
        {
            IGeneratorHtmlString html;
            return null != (html = input as IGeneratorHtmlString)
                 ? html
                 : input == null
                 ? Empty
                 : Raw(System.Net.WebUtility.HtmlDecode(input.ToString()));
        }
    }
}