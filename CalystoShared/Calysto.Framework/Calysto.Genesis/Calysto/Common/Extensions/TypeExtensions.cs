using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calysto.Common.Extensions
{
	public static class TypeExtensions
	{
		public static bool IsNullableType(this Type type)
		{
			return type.GetGenericArguments().FirstOrDefault() != null && type.GetGenericTypeDefinition() == typeof(Nullable<>);
			// or Nullable.GetUnderlyingType(toType) != null;
		}

		/// <summary>
		/// if type is System.Nullable, return it's generic argument type
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Type GetNullableArgument(this Type type)
		{
			if(type.IsNullableType())
			{
				return type.GetGenericArguments().FirstOrDefault();
			}
			return null;
		}
	}
}
