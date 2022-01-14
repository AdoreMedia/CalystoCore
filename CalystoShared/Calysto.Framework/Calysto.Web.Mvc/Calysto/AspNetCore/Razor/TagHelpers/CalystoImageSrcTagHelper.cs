using Calysto.Extensions;
using Calysto.Resources;
using Calysto.Web;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
	[HtmlTargetElement("img")]
    public class CalystoImageSrcTagHelper : TagHelper
    {
        const string CALYSTO_SRC = "calysto-src";

        public override int Order => 900;

		[HtmlAttributeName(CALYSTO_SRC)]
		public ImagesEnum CalystoSrc { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (context.AllAttributes.TryGetAttribute(CALYSTO_SRC, out var attr))
			{
				if (context.AllAttributes.ContainsName("src"))
					throw new Exception($"Can not use {CALYSTO_SRC} and src attribute at the same time.");

				output.Attributes.Add("src", new CalystoVirtualPathHelper(this.CalystoSrc.GetStringValue()).ToVirtualUrlPath());
			}

			await base.ProcessAsync(context, output);
		}
	}
}