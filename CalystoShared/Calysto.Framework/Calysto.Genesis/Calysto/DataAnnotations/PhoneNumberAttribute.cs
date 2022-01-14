using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calysto.DataAnnotations
{
	public class PhoneNumberAttribute : RegularExpressionAttribute
	{
		public PhoneNumberAttribute() : base("^[\\d\\+\\-\\/]*$")
		{

		}
	}
}
