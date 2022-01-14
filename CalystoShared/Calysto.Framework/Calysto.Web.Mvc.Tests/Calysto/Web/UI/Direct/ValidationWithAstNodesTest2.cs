using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Calysto.Linq;
using System.Globalization;
using System.Collections.Generic;
using Calysto.Web.UI.Direct;
using CalystoWebTests.Calysto.Web.UI.Direct.Models;

namespace CalystoWebTests.Calysto.Web.UI.Direct
{
	[TestClass()]
	public class ValidationWithAstNodesTest2
	{
		[TestCleanup]
		public void Cleanup()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
		}

		[TestMethod()]
		public void ValidationTest1()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

			var dic1 = new Dictionary<string, object>();
			dic1.Add("Adresa", "adresa1");
			dic1.Add("Naselje", "adresa1");
			dic1.Add("PostanskiBroj", "adresa1");
			dic1.Add("PostanskiUred", "adresa1");
			dic1.Add("Email", "adresa1");
			dic1.Add("PodrucjeDjelovanja", "abc");
			dic1.Add("PretezitaDjelatnost", "41");

			CalystoMvcModelState<MyTestViewModel> modelState = new CalystoMvcModelState<MyTestViewModel>();
			modelState.Raw = new Dictionary<string, object>() { { "Form", dic1 } };
			modelState.Validate();

			string errors2 = modelState.Errors.Select(o => o.Key + ": " + o.Value).ToStringJoined("\r\n");

			string expected2 = @"Form.PostanskiBroj: Post office ZIP accepts digits only.
Form.Email: E-mail address is not a valid e-mail address.
Form.PodrucjeDjelovanja: Business area has invalid value."; // dummy text

			Assert.AreEqual(expected2, errors2);
		}

		[TestMethod()]
		public void ValidationTest2()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");

			var dic1 = new Dictionary<string, object>();
			dic1.Add("Adresa", "adresa1");
			dic1.Add("Naselje", "adresa1");
			dic1.Add("PostanskiBroj", "adresa1");
			dic1.Add("PostanskiUred", "adresa1");
			dic1.Add("Email", "adresa1");
			dic1.Add("PodrucjeDjelovanja", "abc");
			dic1.Add("PretezitaDjelatnost", "41");

			CalystoMvcModelState<MyTestViewModel> modelState = new CalystoMvcModelState<MyTestViewModel>();
			modelState.Raw = new Dictionary<string, object>() { { "Form", dic1 } };
			modelState.Validate();

			string errors2 = modelState.Errors.Select(o => o.Key + ": " + o.Value).ToStringJoined("\r\n");

			string expected2 = @"Form.PostanskiBroj: Poštanski broj polje prihvaća samo brojke.
Form.Email: E-mail adresa nije valjana e-mail adresa.
Form.PodrucjeDjelovanja: Područje djelovanja podatak nije ispravan.";

			Assert.AreEqual(expected2, errors2);

		}
	}
}
