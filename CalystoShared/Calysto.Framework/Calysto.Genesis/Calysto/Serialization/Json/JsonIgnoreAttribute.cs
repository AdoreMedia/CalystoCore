using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calysto.Serialization.Json
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public sealed class JsonIgnoreAttribute : Attribute
	{
	}
}