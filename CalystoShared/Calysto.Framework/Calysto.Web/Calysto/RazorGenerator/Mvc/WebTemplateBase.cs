namespace Calysto.RazorGenerator.Mvc
{
    public class WebTemplateBase : RazorTemplateBase
    {
        public IGeneratorHtmlString Html(string html)
        {
            return new GeneratorHtmlString(html);
        }

        public string AttributeEncode(string text)
        {
            return string.IsNullOrEmpty(text)
                 ? string.Empty
                 : System.Net.WebUtility.HtmlEncode(text);
        }

        public string Encode(string text)
        {
            return string.IsNullOrEmpty(text) 
                 ? string.Empty 
                 : RazorGenerator.Mvc.Html.Encode(text).ToHtmlString();
        }

        public override void Write(object value)
        {
            if (value == null)
                return;
            else if (value is IGeneratorHtmlString str1)
                base.Write(str1.ToHtmlString());
            else
                base.Write(System.Net.WebUtility.HtmlEncode(value + ""));
        }

        public override object RenderBody()
        {
            return new GeneratorHtmlString(base.RenderBody().ToString());
        }

        public override string TransformText()
        {
            return base.TransformText();
        }
    }
}