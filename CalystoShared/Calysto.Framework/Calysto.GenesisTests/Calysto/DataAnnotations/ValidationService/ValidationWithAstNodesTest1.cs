using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Calysto.Serialization.Json;
using Calysto.Linq;
using System.Globalization;
using CalystoGenesisTests.Calysto.AbstractSyntaxTree.Model;
using Calysto.DataAnnotations.ValidationService;

namespace CalystoGenesisTests.DataAnotations.ValidationService.Tests
{
	[TestClass()]
	public class ValidationWithAstNodesTest1
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

			// run data validation
			// if data are valid, try to convert deserialized object to actual instance type

			ValidatorsViewModel model = new ValidatorsViewModel();
			model.CalystoModel.Age = 1;
			model.CalystoModel.Name = "ab";

			// lets say this is received json via http request or web service
			string json1 = JsonSerializer.Serialize(model);

			object rawObj = JsonSerializer.DeserializeObject(json1);

			var results1 = CalystoValidationService.Validate(typeof(ValidatorsViewModel), rawObj);

			string errors2 = results1.Select(o => o.FormsNamePath + ": " + o.ErrorText).ToStringJoined("\r\n");

			string expected2 = @"CalystoModel.Name: Birth date must be a string or array type with a minimum length of 5.
CalystoModel.Name: Birth date accepts digits only.
CalystoModel.Name: Polje Birth date ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
CalystoModel.Age: Age must be between 5 and 55.
CalystoModel2.Name: Birth date must be a string or array type with a minimum length of 5.
CalystoModel2.Name: Birth date accepts digits only.
CalystoModel2.Name: Polje Birth date ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
List1.0.Name: Birth date accepts digits only.
List1.0.Name: Polje Birth date ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
List1.0.Age: Age must be between 5 and 55.
Dic1.Key1.Name: Birth date accepts digits only.
Dic1.Key1.Name: Polje Birth date ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
Dic1.Key1.Age: Age must be between 5 and 55.
List1.{index}.Name: Birth date value is required.
Dic1.{key}.Name: Birth date value is required.";

			Assert.AreEqual(expected2, errors2);
		}

		[TestMethod()]
		public void ValidationTest2()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");
			// run data validation
			// if data are valid, try to convert deserialized object to actual instance type

			ValidatorsViewModel model = new ValidatorsViewModel();
			model.CalystoModel.Age = 1;
			model.CalystoModel.Name = "ab";

			// lets say this is received json via http request or web service
			string json1 = JsonSerializer.Serialize(model);

			object rawObj = JsonSerializer.DeserializeObject(json1);

			var results1 = CalystoValidationService.Validate(typeof(ValidatorsViewModel), rawObj);

			string errors2 = results1.Select(o => o.FormsNamePath + ": " + o.ErrorText).ToStringJoined("\r\n");

			string expected2 = @"CalystoModel.Name: Datum rođenja mora sadržavati najmanje 5 znakova.
CalystoModel.Name: Datum rođenja polje prihvaća samo brojke.
CalystoModel.Name: Polje Datum rođenja ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
CalystoModel.Age: Age mora biti između 5 i 55.
CalystoModel2.Name: Datum rođenja mora sadržavati najmanje 5 znakova.
CalystoModel2.Name: Datum rođenja polje prihvaća samo brojke.
CalystoModel2.Name: Polje Datum rođenja ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
List1.0.Name: Datum rođenja polje prihvaća samo brojke.
List1.0.Name: Polje Datum rođenja ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
List1.0.Age: Age mora biti između 5 i 55.
Dic1.Key1.Name: Datum rođenja polje prihvaća samo brojke.
Dic1.Key1.Name: Polje Datum rođenja ne zadovoljava uzorak w[\d]+. (Uvijek HR tekst, nije lokalizirno.)
Dic1.Key1.Age: Age mora biti između 5 i 55.
List1.{index}.Name: Datum rođenja podatak je obavezan.
Dic1.{key}.Name: Datum rođenja podatak je obavezan.";

			Assert.AreEqual(expected2, errors2);
		}
	}
}
