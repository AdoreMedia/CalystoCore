using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calysto.Web.TestSite.Web.CalystoUI.CalystoHome
{
    public class CalystoHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}