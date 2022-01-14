using System.ComponentModel.DataAnnotations;

namespace Calysto.Genesis.Tests.Calysto.DataAnnotations.ValidationService.Models
{
	public class SaveCompanyIban
	{
		public int BillFirmaTransakcijskiRacunID { get; set; }

		[Required]
		[MinLength(10)]
		public string IBAN { get; set; }

		[MinLength(2)]
		public string Naziv { get; set; }
		
		[Required]
		public string Valuta { get; set; }

		public bool VidljivNaPonudama { get; set; }
	}
}
