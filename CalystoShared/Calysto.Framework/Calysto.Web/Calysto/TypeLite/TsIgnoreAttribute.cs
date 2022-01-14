using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.TypeLite {
	/// <summary>
	/// Configures property to be ignored by the script generator.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class TsIgnoreAttribute : Attribute {
	}
}
