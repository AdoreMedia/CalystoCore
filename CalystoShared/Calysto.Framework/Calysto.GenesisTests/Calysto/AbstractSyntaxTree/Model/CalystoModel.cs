using Calysto.DataAnnotations;
using Calysto.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace CalystoGenesisTests.Calysto.AbstractSyntaxTree.Model
{
	public class CalystoModel
    {
        [StringLength(15)]
        [MinLength(5)]
        [MaxLength(15)]
        [DigitsOnly]
        [Required]
        [RegularExpression("w[\\d]+", ErrorMessage = "Polje {0} ne zadovoljava uzorak {1}. (Uvijek HR tekst, nije lokalizirno.)")]
        [Display(Name = nameof(CalystoLabelsResources.BirthDate_Label), Prompt = nameof(CalystoLabelsResources.BirthDate_Prompt), ResourceType = typeof(CalystoLabelsResources))]
        public string Name { get; set; } = "ab";

        [Range(5, 55)]
        public int Age { get; set; } = 50;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy. HH:mm")]
        public DateTime Birth { get; set; } = DateTime.Now.AddYears(-15);
    }
}
