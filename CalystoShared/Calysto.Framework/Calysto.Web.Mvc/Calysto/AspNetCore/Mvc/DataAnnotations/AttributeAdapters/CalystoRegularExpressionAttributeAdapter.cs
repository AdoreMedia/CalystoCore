using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calysto.AspNetCore.Mvc.DataAnnotations.AttributeAdapters
{
	internal class CalystoRegularExpressionAttributeAdapter<TAttribute> : AttributeAdapterBase<TAttribute> where TAttribute: RegularExpressionAttribute
	{
		public CalystoRegularExpressionAttributeAdapter(TAttribute attribute, IStringLocalizer stringLocalizer)
			: base(attribute, stringLocalizer)
		{
		}

		public override void AddValidation(ClientModelValidationContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			ValidationAttributeAdapter<TAttribute>.MergeAttribute(context.Attributes, "data-val", "true");
			ValidationAttributeAdapter<TAttribute>.MergeAttribute(context.Attributes, "data-val-regex", GetErrorMessage(context));
			ValidationAttributeAdapter<TAttribute>.MergeAttribute(context.Attributes, "data-val-regex-pattern", base.Attribute.Pattern);
		}

		public override string GetErrorMessage(ModelValidationContextBase validationContext)
		{
			if (validationContext == null)
			{
				throw new ArgumentNullException("validationContext");
			}
			return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName(), base.Attribute.Pattern);
		}
	}
}

