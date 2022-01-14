using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calysto.Web.TestSite.Web.CalystoUI.Checkboxes
{
    public class CheckboxesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Unauthroized()
        {
            return this.Unauthorized("you are not authorized");
        }

        public IActionResult Throw()
        {
            throw new Exception("this is exception");
        }
    }
}