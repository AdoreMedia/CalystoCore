using Calysto.Caching;
using Calysto.Globalization;
using Calysto.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Calysto.Extensions
{
	public static class EnumExtensions
	{
		static ConcurrentDictionary<string, string> _stringValueCache = new ConcurrentDictionary<string, string>();

		/// <summary>
		/// Will get the string value for a given enums value, this will
		/// only work if you assign the StringValue attribute to
		/// the items in your enum. If StringValue attribute is not defined, return value.ToString() if useEnumName==true, else throw Exception
		/// </summary>
		/// <param name="enumValue"></param>
		/// <param name="useEnumName">true: if StringValue attribute is not found, return enumvalue.ToString(), false: always return StringValue or null if StringValue is not defined</param>
		/// <returns></returns>
		public static string GetStringValue(this Enum enumValue, bool useEnumName = false)
		{
			Type type = enumValue.GetType();
			string enumName = enumValue + "";

			return _stringValueCache.GetOrAdd(type.FullName + "#" + enumName + "#" + useEnumName, (key2) =>
			{

				// Get fieldinfo for this type
				FieldInfo fieldInfo = type.GetField(enumName);

				if (fieldInfo != null)
				{
					// Get the stringvalue attributes
					StringValueAttribute attrib = fieldInfo.GetCustomAttribute<StringValueAttribute>(false);
					if (attrib?.StringValue != null)
						return attrib.StringValue;
				}

				if (!useEnumName)
					throw new ArgumentException(nameof(StringValueAttribute) + " not found in enum type " + type.FullName);

				return enumName;
			});
		}

		static ConcurrentDictionary<string, Func<string>> _resxValueCache = new ConcurrentDictionary<string, Func<string>>();

		public static string GetResxValue(this Enum enumValue, bool useEnumName = false)
		{
			Type type = enumValue.GetType();
			string enumName = enumValue + "";

			return _resxValueCache.GetOrAdd(type.FullName + "#" + enumName + "#" + useEnumName, (key2) =>
			{

				// Get fieldinfo for this type
				FieldInfo fieldInfo = type.GetField(enumName);

				if (fieldInfo != null)
				{
					ResxValueAttribute attrib = fieldInfo.GetCustomAttribute<ResxValueAttribute>(false);
					if (attrib?.ResxPropertyName != null && attrib?.ResxType != null)
					{
						ResxExcelProvider provider = attrib.ResxType.GetProperty("ResourceProvider", BindingFlags.Static)?.GetValue(null) as ResxExcelProvider;
						if (provider != null)
						{
							// return value accessor, must return function since we'll get resx value depending on current culture info
							return new Func<string>(() => provider.GetString(attrib.ResxPropertyName));
						}
					}
				}

				if (!useEnumName)
					throw new ArgumentException(nameof(ResxValueAttribute) + " not found in enum type " + type.FullName);

				return new Func<string>(() => enumName);

			}).Invoke();
		}
	}
}

