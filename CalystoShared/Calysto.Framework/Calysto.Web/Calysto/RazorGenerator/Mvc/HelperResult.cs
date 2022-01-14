using System;
using System.Globalization;
using System.IO;

namespace Calysto.RazorGenerator.Mvc
{
    /// <summary>
    /// Represents the result of a helper action as an HTML-encoded string.
    /// </summary>

    // See http://msdn.microsoft.com/en-us/library/system.web.webpages.helperresult.aspx

    public class HelperResult : IGeneratorHtmlString
    {
        private readonly Action<TextWriter> _action;

        public HelperResult(Action<TextWriter> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            _action = action;
        }

        public string ToHtmlString()
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                WriteTo(writer);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
        
        public void WriteTo(TextWriter writer)
        {
            _action(writer);
        }
    }
}