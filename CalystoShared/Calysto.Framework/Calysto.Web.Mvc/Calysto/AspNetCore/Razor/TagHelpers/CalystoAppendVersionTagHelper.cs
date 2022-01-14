using Calysto.Linq;
using Calysto.RazorGenerator.Mvc;
using Calysto.Web;
using Calysto.Web.Script.Services;
using Calysto.Web.UI;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Calysto.AspNetCore.Razor.TagHelpers
{
	[HtmlTargetElement("script")]
	[HtmlTargetElement("link")]
	[HtmlTargetElement("img")]
	public class CalystoAppendVersionTagHelper : TagHelper
	{
		public override int Order => 1000; // da procesira nakon ImageSrcTagHelpera

		/// <summary>
		/// Append file last write time to file query string.
		/// This works with all files anywhere.
		/// MS attribute asp-append-version works for files in wwwroot only.
		/// </summary>
		[HtmlAttributeName(CalystoDomAttributes.CalystoAppendVersion)]
		public bool CalystoAppendVersion { get; set; }

		static FieldInfo _fi;

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (this.CalystoAppendVersion)
				ProcessTag(output);

			await base.ProcessAsync(context, output);
		}

		private void ProcessTag(TagHelperOutput output)
		{
			if (!output.Attributes.TryGetAttribute("href", out TagHelperAttribute attr))
				if(!output.Attributes.TryGetAttribute("src", out attr))
					throw new Exception("href or src attribute is required");

			output.Attributes.Remove(attr);

			if (attr.Value is string url1)
			{
				// vec je obradjen u drugom tagHelperu, npr CalystoImageTagHelper
			}
			else if(attr.Value is HtmlString html1)
			{
				url1 = html1.Value;
			}
			else
			{
				// _firstSegment has full virtual path with /basePath at start
				// _secondSegment has app relative path without ~/ at start
				if (_fi == null)
					_fi = attr.Value.GetType().GetField("_firstSegment", BindingFlags.NonPublic | BindingFlags.Instance);

				url1 = _fi.GetValue(attr.Value) as string;
			}

			CalystoPhysicalPathHelper pathHelper = new CalystoPhysicalPathHelper(url1);
			
			string virtualPath = pathHelper.ToVirtualUrlPath();
			var fileInfo = StaticFileCache.Cache.GetOrCreate(virtualPath, (key) =>
			{
				return pathHelper.FindFile();
			});

			string finalUrl = virtualPath + "?b=" + fileInfo.GetFileLastWriteTimeHash();
			output.Attributes.Add(attr.Name, finalUrl);

		}

	}
}