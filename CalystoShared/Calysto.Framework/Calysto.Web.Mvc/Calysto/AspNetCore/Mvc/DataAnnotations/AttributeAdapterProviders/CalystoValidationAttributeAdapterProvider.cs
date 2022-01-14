using Calysto.AspNetCore.Mvc.DataAnnotations.AttributeAdapters;
using Calysto.DataAnnotations;
using Calysto.DataAnnotations.AttributeAdapterProviders;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calysto.AspNetCore.Mvc.DataAnnotations.AttributeAdapterProviders
{
	/*************************************************************************
	 * Make sure to inject it to services:
	 public void ConfigureServices(IServiceCollection services)
	{
		services.AddSingleton<Microsoft.AspNetCore.Mvc.DataAnnotations.IValidationAttributeAdapterProvider, CalystoValidationAttributeAdapterProvider>();
	}
	*************************************************************************/

	/// <summary>
	/// Apply localized error messages to validation attributes (client side validation)
	/// </summary>
	public class CalystoValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
	{
		private readonly ValidationAttributeAdapterProvider _originalProvider = new ValidationAttributeAdapterProvider();

		public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
		{
			Type type = attribute.GetType();

			CalystoValidationAttributeLocalization.ApplyLocalizedMessage(attribute);

			if (type == typeof(DigitsOnlyAttribute))
				return new CalystoRegularExpressionAttributeAdapter<DigitsOnlyAttribute>((DigitsOnlyAttribute)attribute, stringLocalizer);
			else if (type == typeof(NoSpacesAttribute))
				return new CalystoRegularExpressionAttributeAdapter<NoSpacesAttribute>((NoSpacesAttribute)attribute, stringLocalizer);
			else
				return _originalProvider.GetAttributeAdapter(attribute, stringLocalizer);
		}

	}
}
