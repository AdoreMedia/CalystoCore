using Calysto.Common;
using Calysto.Common.Extensions;
using System;
using System.ComponentModel;
using System.Linq;

namespace Calysto.Utility
{
	public class CalystoTypeConverter
	{
		private static bool TryChangeTypeWorker(object obj, Type toType, out object result, bool exceptionIfFailed)
		{
			if (obj == System.DBNull.Value)
			{
				obj = null;
			}

			Type objType = obj?.GetType();

			if (toType == typeof(object) || objType == toType || toType.IsAssignableFrom(objType))
			{
				result = obj;
				return true;
			}

			object defaultValue = GetDefaultNetValue(toType); // test if result may be null
			bool mayBeNull = defaultValue == null;

			if (mayBeNull && (object.Equals(obj, "null") || object.Equals(obj, "")))
			{
				result = null;
				return true;
			}
			else if (obj == null)
			{
				result = defaultValue;
				bool success = result == null; // if nullable type, and obj is null, conversion is successful, return true
				if (!success && exceptionIfFailed)
				{
					throw new Exception("conversion failed, " + obj + " can not be converted to type " + toType.FullName);
				}
				return success;
			}
			else if (obj.GetType() == toType)
			{
				result = obj;
				return true;
			}
			else if (toType == typeof(bool) || toType == (typeof(bool?)))
			{
				bool val;
				string str = obj + "";
				if (str == "1")
				{
					result = true;
					return true;
				}
				else if (str == "0")
				{
					result = false;
					return true;
				}
				else if (bool.TryParse(str, out val))
				{
					result = val;
					return true;
				}
			}

			try
			{
				TypeConverter converter2 = TypeDescriptor.GetConverter(toType);
				if (converter2.CanConvertFrom(obj?.GetType()) && converter2.CanConvertTo(toType))
				{
					// converting long to int doesn't work here
					// if conversion fails, will throw exception
					result = converter2.ConvertFrom(obj);
					return true;
				}
				else if (toType.IsValueType)
				{
					toType = Nullable.GetUnderlyingType(toType) ?? toType;
					// if converting long to int, use Convert.ChangeType(...)
					// can't just cast values (e.g. double to decimal, string to int, etc., must use Convert)
					// if conversion fails, will throw exception
					result = Convert.ChangeType(obj, toType, null);
					return true;
				}
				else if (toType == typeof(string))
				{
					result = obj + "";
					return true;
				}
				else if (exceptionIfFailed)
				{
					throw new Exception("conversion failed, " + obj + " can not be converted to type " + toType.FullName);
				}
				else
				{
					result = default;
					return false;
				}
			}
			catch (Exception ex)
			{
				if (exceptionIfFailed)
				{
					throw new Exception(ex.Message + " toType: " + toType.FullName + ", value: " + obj, ex);
				}

				result = default;
				return false;
			}
		}


		/// <summary>
		/// Returns true if conversion is successful
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="toType"></param>
		/// <param name="res"></param>
		/// <returns></returns>
		public static bool TryChangeType(object obj, Type toType, out object res)
		{
			return TryChangeTypeWorker(obj, toType, out res, false);
		}

		/// <summary>
		/// Returns true if conversion is successful
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <param name="o"></param>
		/// <returns></returns>
		public static bool TryChangeType<TResult>(object obj, out TResult res)
		{
			object tmp = null;
			if (TryChangeTypeWorker(obj, typeof(TResult), out tmp, false))
			{
				res = (TResult)tmp;
				return true;
			}
			else
			{
				res = default(TResult);
				return false;
			}
		}

		/// <summary>
		/// returns converted object, else throws exception if conversion failed
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="toType"></param>
		/// <returns></returns>
		public static object ChangeType(object obj, Type toType)
		{
			object res = null;
			TryChangeTypeWorker(obj, toType, out res, true);
			return res;
		}

		/// <summary>
		/// returns converted object, else throws exception if conversion failed
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static TResult ChangeType<TResult>(object obj)
		{
			object res = null;
			TryChangeTypeWorker(obj, typeof(TResult), out res, true);
			return (TResult)res;
		}

		////private static TResult DynamicCastWorker<TResult>(object obj)
		////{
		////	if (obj == null)
		////	{
		////		return default(TResult);
		////	}
		////	return (TResult)obj;
		////}

		/////// <summary>
		/////// cast into toType, or get default value of toType if obj is null.
		/////// </summary>
		/////// <param name="obj"></param>
		/////// <param name="toType"></param>
		/////// <returns></returns>
		////public static object DynamicCast(object obj, Type toType)
		////{
		////	MethodInfo mi = typeof(CalystoTypeConverter).GetMethod("DynamicCastWorker", BindingFlags.Static | BindingFlags.NonPublic);
		////	MethodInfo castMethod = mi.MakeGenericMethod(toType);
		////	object castedObject = castMethod.Invoke(null, new object[] { obj });
		////	return castedObject;
		////}

		public static object GetDefaultNetValue(Type toType)
		{
			if (toType == typeof(string)) // string has no parameterless constructor
			{
				return null;
			}
			else if (toType == typeof(byte[])) // byte[] has no parameterless constructor
			{
				return null;
			}
			else
			{
				return Activator.CreateInstance(toType);
			}
		}

		private static object GetNotNullValueImpl(Type type)
		{
			Type nullableArgument = type.GetNullableArgument();
			if (nullableArgument != null)
			{
				return Activator.CreateInstance(nullableArgument);
			}

			if (type == typeof(string))
			{
				return "";
			}
			else if (type == typeof(byte[]))
			{
				return new byte[0];
			}

			try
			{
				return Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				throw new Exception(type.FullName + " error: " + ex.Message);
			}
		}

		public object GetNotNullValue(Type type)
		{
			Type nullableArgument = type.GetNullableArgument();
			if (nullableArgument != null)
			{
				return Activator.CreateInstance(nullableArgument);
			}

			Type arrayElementType = type.GetElementType(); // array []
			if (arrayElementType != null)
			{
				return new[] { GetNotNullValueImpl(arrayElementType) }.ToArray();
			}

			Type genericArgumentType = type.GetGenericArguments().FirstOrDefault(); // List<>
			if (genericArgumentType != null)
			{
				return new[] { GetNotNullValueImpl(genericArgumentType) }.ToList();
			}

			return GetNotNullValueImpl(type);
		}
	}
}
