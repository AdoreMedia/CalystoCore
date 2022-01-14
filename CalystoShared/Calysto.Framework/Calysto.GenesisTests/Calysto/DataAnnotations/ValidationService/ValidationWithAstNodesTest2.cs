using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Calysto.Serialization.Json;
using Calysto.Linq;
using System.Globalization;
using Calysto.DataAnnotations.ValidationService;
using Calysto.Genesis.Tests.Calysto.DataAnnotations.ValidationService.Models;
using System.Collections.Generic;

namespace CalystoGenesisTests.DataAnotations.ValidationService.Tests
{
	[TestClass()]
	public class ValidationWithAstNodesTest2
	{
		[TestCleanup]
		public void Cleanup()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
		}

		const string _json = "{\"Raw\":{\"BillFirmaID\":\"1\",\"Naziv\":\"Digitalna platforma d.o.o.\",\"Adresa\":\"Savska cesta 32\",\"PostanskiBroj\":\"10000\",\"Mjesto\":\"Zagreb\",\"Email\":\"info@eregistar.hr\",\"Telefon\":\"01/5499-454\",\"OIB\":\"6980\",\"TransakcijskiRacuni[0]\":{\"BillFirmaTransakcijskiRacunID\":\"1\",\"Naziv\":\"Erste\",\"Valuta\":\"HRK\",\"IBAN\":\"HR9424020061100846098\"},\"TransakcijskiRacuni[1]\":{\"BillFirmaTransakcijskiRacunID\":\"7\",\"Naziv\":\"Podravska\",\"Valuta\":\"HRK\",\"IBAN\":\"HR1523860021119027890\"},\"TransakcijskiRacuni[2]\":{\"BillFirmaTransakcijskiRacunID\":\"8\",\"Naziv22\":\"Podravska\",\"Valuta\":\"EUR\",\"IBAN\":\"invalid\"},\"TransakcijskiRacuni[3]\":{\"BillFirmaTransakcijskiRacunID\":\"9\",\"Naziv\":\"a\",\"Valuta\":\"er\",\"IBAN\":\"HR1523860021119027890\"},\"TransakcijskiRacuni[4]\":{\"BillFirmaTransakcijskiRacunID\":\"0\"},\"PdvSustavStartDate\":\"1.1.2019.\",\"RacunIzradjenNaRacunaluNapomena\":\"Račun je izrađen na računalu i pravovaljan je bez žiga i potpisa.\",\"BillFirmaCertificateModeID\":\"2\"},\"RootSelector\":\".modal-body\"}";

		[TestMethod()]
		public void ValidationTest1()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

			Dictionary<string, object> dic = JsonSerializer.Deserialize<Dictionary<string, object>>(_json);
			Dictionary<string, object> rawObj = (Dictionary<string, object>) dic["Raw"];

			var popup1 = JsonSerializer.FormConvertToType<PopupCompany>(rawObj);
			
			var results1 = CalystoValidationService.Validate(typeof(PopupCompany), rawObj);

			string errors2 = results1.Select(o => o.FormsNamePath + ": " + o.ErrorText).ToStringJoined("\r\n");

			string expected2 = @"OIB: Company unique number must be a string or array type with a minimum length of 10.
TransakcijskiRacuni[2].IBAN: IBAN must be a string or array type with a minimum length of 10.
TransakcijskiRacuni[3].Naziv: Naziv must be a string or array type with a minimum length of 2.
OslobodjenoPdvaNapomena: Exempt VAT note value is required.";
			Assert.AreEqual(expected2, errors2);
		}

		[TestMethod()]
		public void ValidationTest2()
		{
			CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("hr-HR");

			Dictionary<string, object> dic = JsonSerializer.Deserialize<Dictionary<string, object>>(_json);
			object rawObj = dic["Raw"];

			var results1 = CalystoValidationService.Validate(typeof(PopupCompany), rawObj);

			string errors2 = results1.Select(o => o.FormsNamePath + ": " + o.ErrorText).ToStringJoined("\r\n");

			string expected2 = @"OIB: OIB tvrtke ili obrta mora sadržavati najmanje 10 znakova.
TransakcijskiRacuni[2].IBAN: IBAN mora sadržavati najmanje 10 znakova.
TransakcijskiRacuni[3].Naziv: Naziv mora sadržavati najmanje 2 znakova.
OslobodjenoPdvaNapomena: Oslobođeno PDV-a napomena podatak je obavezan.";
			Assert.AreEqual(expected2, errors2);

		}
	}
}
