using Calysto.Net.Sockets;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
    [HtmlTargetElement(CALYSTO_SPINNER, ParentTag = "form", TagStructure = TagStructure.NormalOrSelfClosing)]
    [HtmlTargetElement(CALYSTO_SPINNER, ParentTag = "div", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalystoSpinnerTagHelper : TagHelper
    {
        public const string CALYSTO_SPINNER= "calysto-spinner";
        public const string CALYSTO_SPINNER_DELAY = "calysto-spinner-delay";

        public override int Order => 900;

        public TimeSpan? CalystoSpinnerDelay { get; set; }

        public string Class { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // css style won't work on tag name e.g. calysto-spinner, so we must change it to div
            output.TagName = "div";

            if (output.Attributes.TryGetAttribute("class", out TagHelperAttribute clsAttr))
                output.Attributes.Remove(clsAttr);

            List<string> list1 = new List<string>() { "calysto-spinner" };
            if (!string.IsNullOrEmpty(this.Class))
                list1.Add(this.Class);

            output.Attributes.Add(new TagHelperAttribute("class", string.Join(" ", list1)));

            if (this.CalystoSpinnerDelay.HasValue)
                output.Attributes.Add(CALYSTO_SPINNER_DELAY, this.CalystoSpinnerDelay?.TotalMilliseconds);

            await base.ProcessAsync(context, output);
        }
    }
}