using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calysto.Web.TestSite.Web.CalystoUI.Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calysto.Web.TestSite.Web.CalystoUI.Validation
{
	public class ValidationController : Controller
	{
		public IActionResult Index()
		{
			ValidationViewModel viewModel = new ValidationViewModel();
			return View(viewModel);
		}

		public IActionResult Validatate(ValidationViewModel viewModel)
		{
			return this.View(nameof(Index), viewModel);
		}
	}
}
