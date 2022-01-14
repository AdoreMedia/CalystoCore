using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.TypeLite.TsModels;

namespace Calysto.TypeLite {
	/// <summary>
	/// Defines a method used to format specific TsType to the string representation.
	/// </summary>
	/// <param name="type">The type to format.</param>
	/// <param name="formatter">The formatter that can format other types.</param>
	/// <returns>The string representation of the type.</returns>
	public delegate string TsTypeFormatter(TsType type, ITsTypeFormatter formatter);
}
