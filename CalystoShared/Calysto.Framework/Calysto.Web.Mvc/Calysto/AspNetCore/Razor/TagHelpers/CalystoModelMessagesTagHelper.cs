//using Microsoft.AspNetCore.Razor.TagHelpers;
//using System;
//using System.Runtime.InteropServices;
//using System.Threading.Tasks;

//namespace Calysto.AspNetCore.Razor.TagHelpers
//{
//    [HtmlTargetElement("div")]
//	public class CalystoModelMessagesTagHelper : TagHelper
//    {
//        const string CALYSTO_MODEL_MESSAGES = "calysto-model-messages";

//        public override int Order => 900;

//        /// <summary>
//        /// if true, will create div element.
//        /// </summary>
//        [HtmlAttributeName(CALYSTO_MODEL_MESSAGES)]
//        public bool CalystoModelMessages { get; set; }

//        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
//        {
//            if (this.CalystoModelMessages)
//			{
//                // add class
//                if (output.Attributes.TryGetAttribute("class", out TagHelperAttribute classAttr))
//                    output.Attributes.Remove(classAttr);

//                string class1 = classAttr?.Value.ToString();
//                if (!string.IsNullOrWhiteSpace(class1))
//                    class1 += " ";
//                class1 += CALYSTO_MODEL_MESSAGES;
//                output.Attributes.Add("class", class1);
//            }
//            else if(context.AllAttributes.ContainsName(CALYSTO_MODEL_MESSAGES))
//			{
//                // don't render element at all
//                output.SuppressOutput();
//			}
            
//            await base.ProcessAsync(context, output);
//        }
//    }
//}