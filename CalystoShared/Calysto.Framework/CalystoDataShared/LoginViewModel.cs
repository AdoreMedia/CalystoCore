using Calysto.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calysto.Web.TestSite.Web.VS.Home.Models
{
	public interface IFormFile
	{

	}

	[Display(Name = "Ovo je login model")]
	public class LoginViewModel
	{
		[Display(Name = nameof(CalystoLabelsResources.Username_Label), Prompt = nameof(CalystoLabelsResources.Username_Prompt), ResourceType = typeof(CalystoLabelsResources))]
		[Required]
		[MinLength(5)]
		public string Username { get; set; }

		[Display(Name = nameof(CalystoLabelsResources.Password_Label), Prompt = nameof(CalystoLabelsResources.Password_Prompt), ResourceType = typeof(CalystoLabelsResources))]
		[Required]
		[MinLength(5)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public IFormFile File { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
