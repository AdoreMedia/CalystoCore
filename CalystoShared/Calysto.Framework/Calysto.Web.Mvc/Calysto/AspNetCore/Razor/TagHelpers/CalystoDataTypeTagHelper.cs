using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
	public enum JSType
	{
		String = 1,
		Boolean = 2,
		Decimal = 3,
		Number = 4,
		Integer = 5,
		Array = 6,
		Function = 7,
		DateTime = 8,
		Date = 9,
		Any = 10
	};

	[HtmlTargetElement("input")]
	[HtmlTargetElement("select")]
	public class CalystoDataTypeTagHelper : TagHelper
	{
		const string CALYSTO_TYPE = "calysto-type";

		public override int Order => 1000;	

		/// <summary>
		/// Used for form serialization to convert the input value to specified type.
		/// </summary>
		public JSType CalystoType { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (context.AllAttributes.TryGetAttribute(CALYSTO_TYPE, out var attr))
			{
				// value is case sensitive when converting: Calysto.Type.TypeDescriptor.FromTypeName(toType);
				
				output.Attributes.Add(CALYSTO_TYPE, attr.Value);

				await base.ProcessAsync(context, output);
			}
		}
	}
}