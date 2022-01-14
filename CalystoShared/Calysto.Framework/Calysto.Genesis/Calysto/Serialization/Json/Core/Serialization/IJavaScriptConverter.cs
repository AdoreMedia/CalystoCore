namespace Calysto.Serialization.Json.Core.Serialization
{
	using System;
    using System.Collections.Generic;
	using System.Text;

	internal interface IJavaScriptConverter
    {
		bool TryConvert(object obj, Type toType, SerializerOptions options, out object result);

		bool TrySerialize(object obj, StringBuilder sb, SerializerOptions options);
    }
}

