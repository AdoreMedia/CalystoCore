using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calysto.Genesis.Tests.Calysto.DataAnnotations.ValidationService.Models
{
	public class PopupCompany
	{
		public string OutputHtml;

		public int BillFirmaID { get; set; }

		[Display(Name = nameof(Arizona.PdvSustavStart), ResourceType = typeof(Arizona))]
		public DateTime? PdvSustavStartDate { get; set; }

		[Display(Name = nameof(Arizona.PdvSustavEnd), ResourceType = typeof(Arizona))]
		public DateTime? PdvSustavEndDate { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(255)]
		[Display(Name = nameof(Arizona.OslobodjenoPdvaLabel), ResourceType = typeof(Arizona))]
		public string OslobodjenoPdvaNapomena { get; set; }

		[MinLength(5)]
		[MaxLength(255)]
		[Display(Name = nameof(Arizona.RacunIzradjenNaRacunaluLabel), ResourceType = typeof(Arizona))]
		public string RacunIzradjenNaRacunaluNapomena { get; set; }

		[Required]
		[MinLength(10)]
		[MaxLength(11)]
		[Display(Name = nameof(Arizona.CompanyUniqueNumber), ResourceType = typeof(Arizona))]
		public string OIB { get; set; }

		public int? BillFirmaCertificateModeID { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(255)]
		[Display(Name = nameof(Arizona.CompanyName), ResourceType = typeof(Arizona))]
		public string Naziv { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(255)]
		[Display(Name = nameof(Arizona.Address), ResourceType = typeof(Arizona))]
		public string Adresa { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(10)]
		[Display(Name = nameof(Arizona.PostalNumber), ResourceType = typeof(Arizona))]
		public string PostanskiBroj { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(100)]
		[Display(Name = nameof(Arizona.City), ResourceType = typeof(Arizona))]
		public string Mjesto { get; set; }

		[Required]
		[MaxLength(150)]
		[Display(Name = nameof(Arizona.Email), ResourceType = typeof(Arizona))]
		public string Email { get; set; }

		[MaxLength(250)]
		[Display(Name = nameof(Arizona.WebSite), ResourceType = typeof(Arizona))]
		public string WebSite { get; set; }

		[MinLength(5)]
		[MaxLength(20)]
		[Display(Name = nameof(Arizona.TelephoneNumber), ResourceType = typeof(Arizona))]
		public string Telefon { get; set; }

		[MinLength(6)]
		[MaxLength(15)]
		[Display(Name = nameof(Arizona.MobilePhone), ResourceType = typeof(Arizona))]
		public string Mobitel { get; set; }

		[MaxLength(500)]
		[Display(Name = nameof(Arizona.TextUFooteruRacunaLabel), ResourceType = typeof(Arizona))]
		public string FooterText { get; set; }

		public List<SaveCompanyIban> TransakcijskiRacuni { get; set; }

	}
}
