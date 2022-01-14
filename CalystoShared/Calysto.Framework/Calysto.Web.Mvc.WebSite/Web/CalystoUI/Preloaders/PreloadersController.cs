using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calysto.TypeLite;
using Microsoft.AspNetCore.Mvc;

namespace Calysto.Web.TestSite.Web.CalystoUI.Preloaders
{
    public class PreloadersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}