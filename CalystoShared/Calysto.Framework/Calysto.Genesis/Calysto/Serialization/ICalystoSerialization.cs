using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Serialization
{
	public interface ICalystoSerialization
	{
		Dictionary<string, object> ToDictionary();
	}
}
