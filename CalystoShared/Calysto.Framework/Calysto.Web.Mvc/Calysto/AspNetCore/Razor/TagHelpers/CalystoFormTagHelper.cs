using Calysto.AspNetCore.Mvc.Razor;
using Calysto.AspNetCore.Mvc.Utility;
using Calysto.Web.Script.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
    [HtmlTargetElement("form")]
    public class CalystoFormTagHelper : TagHelper
    {
        public const string CALYSTO_AUTOSUBMIT_DELAY = "calysto-autosubmit-delay";

        IHttpContextAccessor _cx;
        public CalystoFormTagHelper(IHttpContextAccessor cx)
		{
            _cx = cx;
		}

        public override int Order => 900;

        public enum UpdateMode
        {
            ReplaceChildren,
            
            InsertChildren,
            
            AddChildren,
        }

        /// <summary>
        /// Update mode for received content. Default: ReplaceChildren.
        /// </summary>
        [HtmlAttributeName(CalystoDomAttributes.CalystoFormMode)]
        public UpdateMode CalystoFormMode { get; set; } = UpdateMode.ReplaceChildren;

        /// <summary>
        /// Selector for panel to be updated with response. CSV values.
        /// </summary>
        [HtmlAttributeName(CalystoDomAttributes.CalystoFormTarget)]
        public string CalystoFormTarget { get; set; }

        /// <summary>
        /// Handler function name or lambda will be invoked on content received.
        /// (content)=>{}
        /// </summary>
        [HtmlAttributeName(CalystoDomAttributes.CalystoFormHandler)]
        public string CalystoFormHandler { get; set; }

        public ControllerActionItem CalystoControllerAction { get; set; }

        /// <summary>
        /// Timeout. Default: 90 s.
        /// </summary>
        public TimeSpan? CalystoTimeout { get; set; }

        /// <summary>
        /// Delay in milliseconds. Zero for no delay.
        /// </summary>
        public int? CalystoAutosubmitDelay { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if(this.CalystoControllerAction != null)
            { 
                if (this.CalystoFormTarget == "")
                    throw new Exception($"{CalystoDomAttributes.CalystoFormTarget} attribute may not have empty string value.");
                else if (!string.IsNullOrEmpty(this.CalystoFormTarget))
                    output.Attributes.Add(CalystoDomAttributes.CalystoFormTarget, this.CalystoFormTarget);

                if (this.CalystoFormHandler== "")
                    throw new Exception($"{CalystoDomAttributes.CalystoFormHandler} attribute may not have empty string value.");
                else if (!string.IsNullOrEmpty(this.CalystoFormHandler))
                    output.Attributes.Add(CalystoDomAttributes.CalystoFormHandler, this.CalystoFormHandler);

                if (this.CalystoFormMode > 0)
                    output.Attributes.Add(CalystoDomAttributes.CalystoFormMode, this.CalystoFormMode);

                // method has to be defined in razor to create validation token
                if (!output.Attributes.TryGetAttribute("method", out var methodAttr))
                    throw new ArgumentException("Missing form 'method' attribute.");

                // just remove action attribute and don't use it since we're using controler type name which it doesn't handle well
                if (output.Attributes.TryGetAttribute("action", out var actionAttr))
                    output.Attributes.Remove(actionAttr);

                string actionStr = this.CalystoControllerAction.ToVirtualPath();

                string encr = Calysto.Converter.CalystoBase64Encoder.JavaScriptRFCTable64Encoder.EncodeToBase64String(actionStr);
                output.Attributes.Add(CalystoDomAttributes.CalystoFormDestination, encr);

                // let's give false data to hackers
                output.Attributes.Add("action", "/form-post-public-api");

                if(this.CalystoTimeout.HasValue)
                    output.Attributes.Add("calysto-timeout", this.CalystoTimeout?.TotalMilliseconds);

                if(this.CalystoAutosubmitDelay.HasValue)
				{
                    if(!output.Attributes.TryGetAttribute("id", out TagHelperAttribute idAttr))
					{
                        string id = Guid.NewGuid().ToString();
                        idAttr = new TagHelperAttribute("id", id);
                        output.Attributes.Insert(0, idAttr);
                    }
                    // create js to invoke autosubmit
                    output.PostContent.AppendHtmlLine($@"
<script>Calysto.Mvc.AjaxForm.SubmitForm(""form#{idAttr.Value}"", {this.CalystoAutosubmitDelay})</script>");
                }
            }

            await base.ProcessAsync(context, output);
        }
    }
}