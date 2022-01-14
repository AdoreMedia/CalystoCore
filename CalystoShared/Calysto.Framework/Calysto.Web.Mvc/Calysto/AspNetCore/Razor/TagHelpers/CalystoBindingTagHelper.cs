using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
	[HtmlTargetElement("div")]
	[HtmlTargetElement("span")]
	[HtmlTargetElement("img")]
	[HtmlTargetElement("label")]
	[HtmlTargetElement("input")]
	[HtmlTargetElement("button")]
	[HtmlTargetElement("a")]
	[HtmlTargetElement("textarea")]
	[HtmlTargetElement("select")]
	public class CalystoBindingTagHelper : TagHelper
	{
		const string CALYSTO_BINDING_UID = "calysto-binding-uid";

		public override int Order => 1000;

		public HtmlString CalystoBinding { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if(this.CalystoBinding?.Value != null)
				output.Attributes.Add(CALYSTO_BINDING_UID, this.CalystoBinding);

			await base.ProcessAsync(context, output);
		}
	}
}