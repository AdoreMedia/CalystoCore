namespace Calysto.DataAnnotations.Validators
{
	export function GetValidators(sender: IValidationElement, context: IValidationContext)
	{
		let validators: IValidator[] = [];
		let dic = $$calysto(sender).SelectAttributesAll().First();
		for (let name in dic)
		{
			switch (name)
			{
				case "data-val-required": validators.push(new RequiredValidator(dic[name]));
					break;

				case "data-val-email": validators.push(new EmailAddressValidator(dic[name]));
					break;

				case "data-val-length": validators.push(new StringLengthValidator(dic[name],
					parseInt(<string>sender.getAttribute("data-val-length-min")),
					parseInt(<string>sender.getAttribute("data-val-length-max"))));
					break;

				case "data-val-regex": validators.push(new RegularExpressionValidator(dic[name],
					<string>sender.getAttribute("data-val-regex-pattern")));
					break;

				case "data-val-range": validators.push(new RangeValidator(dic[name],
					parseFloat(<string>sender.getAttribute("data-val-range-min")),
					parseFloat(<string>sender.getAttribute("data-val-range-max"))));
					break;

				case "data-val-minlength": validators.push(new MinLengthValidator(dic[name],
					parseFloat(<string>sender.getAttribute("data-val-minlength-min"))));
					break;

				case "data-val-maxlength": validators.push(new MaxLengthValidator(dic[name],
					parseFloat(<string>sender.getAttribute("data-val-maxlength-max"))));
					break;

				case "data-val-fileextensions": validators.push(new FileExtensionsValidator(dic[name],
					<string>sender.getAttribute("data-val-fileextensions-extensions")));
					break;

				case "data-val-equalto": validators.push(new CompareValidator(dic[name],
					<string>sender.getAttribute("data-val-equalto-other"),
					context));
					break;

			}
		}
		return validators;
	}

	//#region Validators

	class RequiredValidator implements IValidator
	{
		public constructor(public ErrorText: string) { }
		public IsValid(value: any)
		{
			// must be non null or empty or NaN and length > 0
			return !Type.TypeInspector.IsNullOrUndefined(value) && !String.IsNullOrWhiteSpace(value + "");
		}
	}

	class EmailAddressValidator implements IValidator
	{
		public constructor(public ErrorText: string) { }
		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			let str1 = value + "";
			return new RegExp("[^@]+[@][^@]+").test(str1);
		}
	}

	class StringLengthValidator implements IValidator
	{
		public constructor(public ErrorText: string, public MinimumLength: number, public MaximumLength: number) { }

		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			// if not null, lenght must be in range
			let str1 = value + "";
			return str1.length >= (this.MinimumLength || 0) && str1.length <= (this.MaximumLength || Number.MAX_VALUE);
		}
	}

	class RegularExpressionValidator implements IValidator
	{
		public constructor(public ErrorText: string, public RegexPattern: string) { }

		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			let str1 = value + "";
			if (String.IsNullOrEmpty(str1)) return true;
			return new RegExp(this.RegexPattern).test(str1);
		}
	}

	class RangeValidator implements IValidator
	{
		public constructor(public ErrorText: string, public Minimum: number, public Maximum: number) { }

		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			// if not null, lenght must be in range
			let val1 = parseFloat(value + "");
			if (!Type.TypeInspector.IsNumber(val1)) return false;
			return val1 >= (this.Minimum || Number.MIN_VALUE) && val1 <= (this.Maximum || Number.MAX_VALUE);
		}
	}

	class MinLengthValidator implements IValidator
	{
		public constructor(public ErrorText: string, public Length: number) { }

		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			// if not null, lenght must be in range
			let str1 = value + "";
			return str1.length >= (this.Length || 0);
		}
	}

	class MaxLengthValidator implements IValidator
	{
		public constructor(public ErrorText: string, public Length: number) { }

		public IsValid(value: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(value)) return true; // null is valid
			// if not null, lenght must be in range
			let str1 = value + "";
			return str1.length <= (this.Length || Number.MAX_VALUE);
		}
	}

	class FileExtensionsValidator implements IValidator
	{
		/**
		 * 
		 * @param ErrorText
		 * @param Extensions example: "png,jpg,jpeg,gif"
		 */
		public constructor(public ErrorText: string, public Extensions: string) { }

		public IsValid(filename: any)
		{
			if (Type.TypeInspector.IsNullOrUndefined(filename)) return true; // null is valid
			let str1 = filename + "";
			let match1 = str1.match(new RegExp("[\\w]+$")); // extract extension
			if (match1 && match1[0])
			{
				let extension = match1[0];
				return ("," + this.Extensions + ",").Contains("," + extension + ",");
			}
			return false;
		}
	}

	class CompareValidator implements IValidator
	{
		public constructor(public ErrorText: string, public OtherProperty: string, public Context: IValidationContext) { }

		public IsValid(value2: any)
		{
			// OtherProperty: *.NewPassword
			let prop2 = this.OtherProperty.ReplaceAll("*", "");
			for (let prop1 in this.Context.inputs)
			{
				if (prop1 == prop2 || (prop2.charAt(0) == "." && prop1.EndsWith(prop2)))
				{
					let value1 = this.Context.inputs[prop1]?.value;
					// empty string has to be converted to null, it is C# logic
					let tmp1 = value1 === "" ? null : value1;
					
					return Type.TypeInspector.AreValuesEqual(value2, tmp1);
				}
			}
			return false;
		}
	}

	//#endregion
}
