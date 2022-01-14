using Calysto.Serialization.Json.Core.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.Serialization.Json.Core.Converters
{
	/// <summary>
	/// Includes Calysto converters
	/// </summary>
	internal static class JavascriptConverters
	{
		public static List<IJavaScriptConverter> Converters = new List<IJavaScriptConverter>()
		{
				new Converters.DateTimeConverter(),

#if !SILVERLIGHT
				new Converters.DataTableConverter(),
#endif
				new Converters.CalystoBlobConverter(),
				new Converters.ByteArrayConverter()
		};
	}
}
