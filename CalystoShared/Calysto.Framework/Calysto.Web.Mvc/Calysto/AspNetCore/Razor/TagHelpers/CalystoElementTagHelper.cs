using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
	/// <summary>
	/// Creates element with specified tag name.
	/// </summary>
	public class CalystoElementTagHelper : TagHelper
    {
        const string CALYSTO_TAG_NAME = "calysto-tag-name";

        public override int Order => 900;

        [HtmlAttributeName(CALYSTO_TAG_NAME)]
        public string CalystoTagName { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if(string.IsNullOrEmpty(this.CalystoTagName))
                throw new Exception($"{CALYSTO_TAG_NAME} attribute has to be defined.");

            output.TagName = this.CalystoTagName;
            
            await base.ProcessAsync(context, output);
        }
    }
}