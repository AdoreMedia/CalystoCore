using Calysto.Resources;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calysto.Web.TestSite.Web.CalystoUI.Validation.Models
{
	[Display(Name = "Ovo je validation model")]
	public class ValidationViewModel
	{
		//[Display(Name = nameof(CalystoLabelsResources.Username_Label), Prompt = nameof(CalystoLabelsResources.Username_Prompt), ResourceType = typeof(CalystoLabelsResources))]
		//[Required]
		//[MinLength(5)]
		//public string Username { get; set; }

		//[Display(Name = nameof(CalystoLabelsResources.Password_Label), Prompt = nameof(CalystoLabelsResources.Password_Prompt), ResourceType = typeof(CalystoLabelsResources))]
		//[Required]
		//[MinLength(5)]
		//[DataType(DataType.Password)]
		//public string Password { get; set; }

		[Display(Name = nameof(CalystoLabelsResources.BirthDate_Label), Prompt = nameof(CalystoLabelsResources.BirthDate_Prompt), ResourceType = typeof(CalystoLabelsResources))]
		//[Required]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Visina cm")]
		[Required]
		public decimal Height { get; set; }

		public IFormFile File { get; set; }

	}
}
