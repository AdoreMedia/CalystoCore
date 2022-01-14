using Calysto.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Calysto.DataAnnotations.AttributeAdapterProviders
{
	public class CalystoValidationAttributeLocalization 
	{ 
		public static void ApplyLocalizedMessage(ValidationAttribute attribute)
		{
			ApplyLocalizedMessage(attribute, attribute.GetType());
		}

		static PropertyInfo _propertyInfo;

		private static void ApplyLocalizedMessage(ValidationAttribute attribute, Type type)
		{
			if(_propertyInfo == null)
				_propertyInfo = attribute.GetType().GetProperty("DefaultErrorMessage", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

			if (type == typeof(EmailAddressAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.EmailAddressAttribute_Invalid);
			else if (type == typeof(RegularExpressionAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.RegexAttribute_ValidationError);
			else if (type == typeof(MaxLengthAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.MaxLengthAttribute_ValidationError);
			else if (type == typeof(RequiredAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.RequiredAttribute_ValidationError);
			else if (type == typeof(CompareAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.CompareAttribute_MustMatch);
			else if (type == typeof(MinLengthAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.MinLengthAttribute_ValidationError);
			else if (type == typeof(CreditCardAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.CreditCardAttribute_Invalid);
			else if (type == typeof(StringLengthAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.StringLengthAttribute_ValidationError);
			else if (type == typeof(RangeAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.RangeAttribute_ValidationError);
			else if (type == typeof(PhoneAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.PhoneAttribute_Invalid);
			else if (type == typeof(UrlAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.UrlAttribute_Invalid);
			else if (type == typeof(FileExtensionsAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.FileExtensionsAttribute_Invalid);
			else if (type == typeof(DataTypeAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.ValidationAttribute_ValidationError);
			else if (type == typeof(PhoneNumberAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.PhoneNumberAttribute_ValidationError);
			else if (type == typeof(DigitsOnlyAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.RegexAttribute_EnterDigitsOnly);
			else if (type == typeof(NoSpacesAttribute))
				_propertyInfo.SetValue(attribute, CalystoAnnotationsResources.RegexAttribute_SpacesNotAccepted);
			else
				throw new ArgumentException(type.FullName);
		}
	}
}
