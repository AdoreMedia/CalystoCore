using Calysto.AspNetCore.Mvc.Razor;
using Calysto.AspNetCore.Mvc.Utility;
using Calysto.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
    [HtmlTargetElement("a")]
	public class CalystoAnchorTagHelper : TagHelper
    {
        public override int Order => 900;

        public ControllerActionItem CalystoControllerAction { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (this.CalystoControllerAction != null)
            {
                if (output.Attributes.TryGetAttribute("href", out var hrefAttr))
                    output.Attributes.Remove(hrefAttr);

                var actionStr = this.CalystoControllerAction.ToVirtualPath();
                output.Attributes.Add("href", actionStr);
            }

            await base.ProcessAsync(context, output);
        }
    }
}