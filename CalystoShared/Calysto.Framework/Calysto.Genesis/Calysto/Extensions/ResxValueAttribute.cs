using System;
using System.Collections.Generic;
using System.Text;

namespace Calysto.Extensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ResxValueAttribute : Attribute
	{
		public Type ResxType;
		public string ResxPropertyName;
	}
}
