using Calysto.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalystoWebTests.Calysto.Web.UI.Direct.Models
{
	public class BusinessDataModel
	{
		public int ArizonaClientID { get; set; }

		[Required]
		[MaxLength(100)]
		[Display(Name = nameof(Registar.LabelAddress), Prompt = nameof(Registar.PlaceholderAddress), ResourceType = typeof(Registar))]
		public string Adresa { get; set; }

		[Required]
		[MaxLength(100)]
		[Display(Name = nameof(Registar.LabelSettlement), Prompt = nameof(Registar.PlaceholderSettlement), ResourceType = typeof(Registar))]
		public string Naselje { get; set; }

		[Required]
		[DigitsOnly]
		[MaxLength(150)]
		[Display(Name = nameof(Registar.LabelPostOfficeZIP), Prompt = nameof(Registar.PlacehodlerPostOfficeZip), ResourceType = typeof(Registar))]
		public string PostanskiBroj { get; set; }

		[MinLength(5)]
		[MaxLength(50)]
		[Display(Name = nameof(Registar.LabelPostOffice), Prompt = nameof(Registar.PostOffice), ResourceType = typeof(Registar))]
		public string PostanskiUred { get; set; }

		[EmailAddress]
		[MaxLength(150)]
		[Display(Name = nameof(Registar.LabelEmailAddress), Prompt = nameof(Registar.PlaceholderEmailAddress), ResourceType = typeof(Registar))]
		public string Email { get; set; }

		[MaxLength(150)]
		[Display(Name = nameof(Registar.LabelWebSite), Prompt = nameof(Registar.PlaceholderWebSite), ResourceType = typeof(Registar))]
		public string Web { get; set; }

		[DigitsOnly]
		[MinLength(8)]
		[MaxLength(14)]
		[Display(Name = nameof(Registar.LabelTelephone1), Prompt = nameof(Registar.PlaceholderTelephone1), ResourceType = typeof(Registar))]
		public string Telefon1 { get; set; }

		[DigitsOnly]
		[MinLength(8)]
		[MaxLength(14)]
		[Display(Name = nameof(Registar.LabelTelephone2), Prompt = nameof(Registar.PlaceholderTelephone2), ResourceType = typeof(Registar))]
		public string Telefon2 { get; set; }

		[MaxLength(500)]
		[Display(Name = nameof(Registar.LabelWorkingTime), Prompt = nameof(Registar.PlaceholderWorkingTime), ResourceType = typeof(Registar))]
		public string RadnoVrijeme { get; set; }

		[MaxLength(500)]
		[Display(Name = nameof(Registar.LabelKeywords), Prompt = nameof(Registar.PlaceholderKeywords), ResourceType = typeof(Registar))]
		public string KljucneRijeci { get; set; }

		[MaxLength(4000)]
		[Display(Name = nameof(Registar.LabelDescription), Prompt = nameof(Registar.PlaceholderDescriptionExplanation), ResourceType = typeof(Registar))]
		public string Opis { get; set; }

		[Display(Name = nameof(Registar.LabelPhotos), ResourceType = typeof(Registar))]
		public List<PictureDataForUpload> Pictures { get; set; }

		[Required]
		[Display(Name = nameof(Registar.LabelBusinessArea), ResourceType = typeof(Registar))]
		public int? PodrucjeDjelovanja { get; set; }

		[Required]
		[Display(Name = nameof(Registar.LabelMainBusinessCategory), ResourceType = typeof(Registar))]
		public int? PretezitaDjelatnost { get; set; }
	}
}
