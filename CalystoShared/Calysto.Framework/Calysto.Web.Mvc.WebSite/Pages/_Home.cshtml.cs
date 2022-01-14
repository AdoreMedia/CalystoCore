using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calysto.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calysto.Genesis.WebSite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class _HomeModel : PageModel
    {
        public string ServerVersion => CalystoPhysicalPaths.Current?.AssembliesSignature;

        public void OnGet()
        {
            Response.Cookies.Append("zeko", "zec");
        }
    }
}
