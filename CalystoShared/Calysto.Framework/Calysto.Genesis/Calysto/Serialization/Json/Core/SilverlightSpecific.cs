using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

#if SILVERLIGHT
namespace System
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	public sealed class NonSerializedAttribute : Attribute
	{
		// Summary:
		//     Initializes a new instance of the System.NonSerializedAttribute class.
		public NonSerializedAttribute()
		{
		}
	}

}

namespace System.Collections
{
	public class Hashtable : Dictionary<object, object>
	{
		public Hashtable()
		{
		}
		public Hashtable(IEqualityComparer<object> comparer)
			: base(comparer)
		{

		}
	}

	public class ArrayList : List<object>
	{
		public object[] ToArray(Type type)
		{
			return base.ToArray();
		}
	}
}

namespace System.ComponentModel
{
	public class TypeDescriptor
	{
		public static TypeConverter GetConverter(object o)
		{
			return new TypeConverter();
		}
	}

	public static class TypeConverterExtensions
	{
		public static string ConvertToInvariantString(this TypeConverter converter, object o)
		{
			return converter.ConvertToString(o);
		}

		public static object ConvertFromInvariantString(this TypeConverter converter, string text)
		{
			return converter.ConvertFromString(text);
		}
	}
}

#endif