using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calysto.DataAnnotations
{
	public class DigitsOnlyAttribute : RegularExpressionAttribute
	{
		public DigitsOnlyAttribute() : base("^[\\d]*$")
		{

		}
	}
}
