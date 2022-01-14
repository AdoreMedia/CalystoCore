using Calysto.Genesis.WebSite;
using Calysto.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.TestSite.TagHelpers
{
    public class CalystoEnvironmentTagHelper : TagHelper
    { 
#if DEBUG
        private BuildKind _buildKind = BuildKind.Debug;
#elif TDDSPECIFIC
        private BuildKind _buildKind = BuildKind.TddSpecific;
#else
        private BuildKind _buildKind = BuildKind.Release;
#endif

        public enum BuildKind
        {
            Never,
            Release,
            Debug,
            TddSpecific
        }

        public BuildKind IncludeIf { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var invalid = context.AllAttributes.Where(o => o.Name != "include-if").Select(o => o.Name).ToList();
            if (invalid.Any())
                throw new Exception("calysto-enviroment tag doesn't allow attribute " + invalid.ToStringJoined(", "));

            output.TagName = "";

            if (_buildKind != this.IncludeIf)
                output.SuppressOutput();

            await base.ProcessAsync(context, output);
        }
    }
}