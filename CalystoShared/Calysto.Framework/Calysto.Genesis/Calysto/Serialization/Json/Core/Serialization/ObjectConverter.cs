using Calysto.Serialization.Json.Core.Converters;
using Calysto.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Calysto.Serialization.Json.Core.Serialization
{
	public class ObjectConverter
    {
        private static Type _dictionaryGenericType = typeof(Dictionary<,>);
        private static Type _enumerableGenericType = typeof(IEnumerable<>);
        private static Type _idictionaryGenericType = typeof(IDictionary<,>);
        private static Type _listGenericType = typeof(List<>);
        private static Type _hashSetGenericType = typeof(HashSet<>);
        private static readonly Type[] s_emptyTypeArray = new Type[0];

        public SerializerOptions Options { get; private set; }

        public ObjectConverter(SerializerOptions options = null)
        {
            this.Options = options ?? new SerializerOptions();
        }

        /// <summary>
        /// Convert object to type. Throw exception if conversion failed.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object ConvertObjectToType(object o, Type type)
        {
            object obj2;
            ConvertObjectToTypeMain(o, type, true, out obj2);
            return obj2;
        }
        
        public bool TryConvertObjectToType(object o, Type type, out object convertedObject)
		{
            return ConvertObjectToTypeMain(o, type, false, out convertedObject);
		}

        private bool ConvertObjectToTypeMain(object o, Type toType, bool throwOnError, out object convertedObject)
        {
            if (o == null)
            {
                if (toType == typeof(char))
                {
                    convertedObject = '\0';
                    return true;
                }
                if (IsNonNullableValueType(toType))
                {
                    if (throwOnError)
                    {
                        throw new InvalidOperationException(AtlasWeb.JSON_ValueTypeCannotBeNull);
                    }
                    convertedObject = null;
                    return false;
                }
                convertedObject = null;
                return true;
            }

            if (toType != null && o.GetType() == toType)
            {
                convertedObject = o;
                return true;
            }
			else if (TryConvert(o, toType, out convertedObject))
			{
				return true;
			}
            return ConvertObjectToTypeInternal(o, toType, throwOnError, out convertedObject);
        }

        private bool IsNonNullableValueType(Type type)
        {
            if ((type == null) || !type.IsValueType)
            {
                return false;
            }
            if (type.IsGenericType)
            {
                return (type.GetGenericTypeDefinition() != typeof(Nullable<>));
            }
            return true;
        }

        private bool TryConvert(object obj, Type toType, out object result)
        {
            if (JavascriptConverters.Converters != null && obj != null)
            {
                foreach (IJavaScriptConverter cc in JavascriptConverters.Converters)
                {
                    if (cc.TryConvert(obj, toType, this.Options, out result))
                    {
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }

        private bool ConvertObjectToTypeInternal(object o, Type type, bool throwOnError, out object convertedObject)
        {
            IDictionary<string, object> dictionary = o as IDictionary<string, object>;
            if (dictionary != null)
            {
                return ConvertDictionaryToObject(dictionary, type, throwOnError, out convertedObject);
            }

            IList list = o as IList;
            if (list != null)
            {
                object list2; // we're using this method to convert to HashSet<>
                if (ConvertListToObject(list, type, throwOnError, out list2))
                {
                    convertedObject = list2;
                    return true;
                }
                convertedObject = null;
                return false;
            }

            if ((type == null) || (o.GetType() == type))
            {
                convertedObject = o;
                return true;
            }

            if(o is string str1)
			{
                Type type1 = System.Nullable.GetUnderlyingType(type) ?? type;
                if(type1 == typeof(decimal)
                    || type1 == typeof(int)
                    || type1 == typeof(double)
                    || type1 == typeof(float)
                    || type1 == typeof(long)
                    || type1 == typeof(short))
				{
                    // converting string to number requires group serparator to be removed
                    string decimalSeparator = this.Options.Culture.NumberFormat.NumberDecimalSeparator;
                    string groupSeparator = this.Options.Culture.NumberFormat.NumberGroupSeparator;
                    int decimalIndex = str1.LastIndexOf(decimalSeparator);
                    int groupIndex = str1.LastIndexOf(groupSeparator);
                    if (groupIndex > 0 && (decimalIndex == -1 || decimalIndex > groupIndex))
                    {
                        o = str1.Replace(groupSeparator, "");
                    }
				}
            }

            TypeConverter converter = TypeDescriptor.GetConverter(type);
            if (converter.CanConvertFrom(o.GetType()))
            {
                try
                {
                    convertedObject = converter.ConvertFrom(null, this.Options.Culture, o);
                    return true;
                }
                catch (Exception ex)
                {
                    if (throwOnError)
                    {
                        throw new Exception(o + " " + ex.Message, ex);
                    }
                    convertedObject = null;
                    return false;
                }
            }
            if (converter.CanConvertFrom(typeof(string)))
            {
                TypeConverter converter2 = TypeDescriptor.GetConverter(o);
                try
                {
                    string text = converter2.ConvertToInvariantString(o);
                    convertedObject = converter.ConvertFromInvariantString(text);
                    return true;
                }
                catch
                {
                    if (throwOnError)
                    {
                        throw;
                    }
                    convertedObject = null;
                    return false;
                }
            }
            if (type.IsAssignableFrom(o.GetType()))
            {
                convertedObject = o;
                return true;
            }

            object res;
            if (Calysto.Utility.CalystoTypeConverter.TryChangeType(o, type, out res))
            {
                convertedObject = res;
                return true;
            }

            if (throwOnError)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AtlasWeb.JSON_CannotConvertObjectToType, new object[] { o.GetType(), type }));
            }
            convertedObject = null;
            return false;
        }

        private bool ConvertDictionaryToObject(IDictionary<string, object> dictionary, Type type, bool throwOnError, out object convertedObject)
        {
            Type type1 = type;
            object dic1 = dictionary;

            if (this.Options.UseTypeName && (type1 == null || type1 == typeof(object)))
            {
                // try resolve type form __type$
                if (dictionary.TryGetValue(ObjectSerializer.TYPE_PROPERTY, out object typeName) && typeName is string)
                {
                    type1 = Type.GetType((string)typeName);
                    if (type1 == null)
                        throw new InvalidOperationException($"Type {typeName} not found, object can not be converted.");
                }
            }

            if (type1 != null && type1.FullName.StartsWith("System.Tuple"))
            {
                var ctor1 = type1.GetConstructors().FirstOrDefault();
                convertedObject = ctor1.Invoke(dictionary.Values.ToArray());
                return true;
            }
            else if (type1 == typeof(System.Security.Claims.Claim))
            {
                var args = dictionary.Select(kv => kv.Value).ToArray();
                convertedObject = dic1 = CalystoActivator.CreateInstance(type1, args);
                return true;
            }
            else if (IsClientInstantiatableType(type1))
            {
                try
                {
                    dic1 = CalystoActivator.CreateInstance(type1);
                }
                catch (NotSupportedException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create instance of " + type1.FullName, ex);
                }
            }

            List<string> list = new List<string>(dictionary.Keys);
            if (IsGenericDictionary(type))
            {
                Type type3 = type.GetGenericArguments()[0];
                if ((type3 != typeof(string)) && (type3 != typeof(object)))
                {
                    if (throwOnError)
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_DictionaryTypeNotSupported, new object[] { type.FullName }));
                    }
                    convertedObject = null;
                    return false;
                }
                Type type4 = type.GetGenericArguments()[1];
                IDictionary dictionary2 = null;
                if (IsClientInstantiatableType(type))
                {
                    dictionary2 = (IDictionary)Activator.CreateInstance(type);
                }
                else
                {
                    dictionary2 = (IDictionary)Activator.CreateInstance(_dictionaryGenericType.MakeGenericType(new Type[] { type3, type4 }));
                }
                if (dictionary2 != null)
                {
                    foreach (string str2 in list)
                    {
                        object obj4;
                        if (!ConvertObjectToTypeMain(dictionary[str2], type4, throwOnError, out obj4))
                        {
                            convertedObject = null;
                            return false;
                        }
                        dictionary2[str2] = obj4;
                    }
                    convertedObject = dictionary2;
                    return true;
                }
            }

            if ((type != null) && !type.IsAssignableFrom(dic1.GetType()))
            {
                if (!throwOnError)
                {
                    convertedObject = null;
                    return false;
                }
                if (type.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, s_emptyTypeArray, null) == null)
                {
                    throw new MissingMethodException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_NoConstructor, new object[] { type.FullName }));
                }
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_DeserializerTypeMismatch, new object[] { type.FullName }));
            }

            foreach (string str3 in list)
            {
                object propertyValue = dictionary[str3];
                if (!AssignToPropertyOrField(propertyValue, dic1, str3, throwOnError))
                {
                    convertedObject = null;
                    return false;
                }
            }
            convertedObject = dic1;
            return true;
        }

        private bool IsGenericDictionary(Type type)
        {
            if (((type == null) || !type.IsGenericType) || (!typeof(IDictionary).IsAssignableFrom(type) && (type.GetGenericTypeDefinition() != _idictionaryGenericType)))
            {
                return false;
            }
            return (type.GetGenericArguments().Length == 2);
        }

        Regex _reDigits = new Regex("^[\\d]+$");

        private bool AssignToPropertyOrField(object value, object instance, string memberName, bool throwOnError)
        {
            if (instance is IDictionary dictionary)
            {
                if (!ConvertObjectToTypeMain(value, null, throwOnError, out value))
                {
                    return false;
                }
                dictionary[memberName] = value;
                return true;
            }
            else if(instance is IList list && _reDigits.IsMatch(memberName))
			{
                Type listType = list.GetType();
                Type toType = listType.GetElementType() ?? listType.GenericTypeArguments.Single();
                // converting dictionary to list
                // running FormConvertToType creates dictionary with keys as indexes instead of List
                // because while reconstructing hierarchy we need multiple assignments by index which is not always ordered,
                // and some indexes may be missing (e.g. if form field is disabled, it is not sent to server)
                if (!ConvertObjectToTypeMain(value, toType, throwOnError, out value))
                {
                    return false;
                }
                list.Add(value);
                return true;
            }

            Type type = instance.GetType();

            // in MS code they use: BindingFlags.IgnoreCase
            PropertyInfo property = TypeHelper.Current.GetPropertyInfo(type, memberName);
            if (property != null && property.CanWrite)
            {
                MethodInfo setMethod = property.GetSetMethod();
                if (setMethod != null)
                {
                    try
                    {
                        if (!ConvertObjectToTypeMain(value, property.PropertyType, throwOnError, out value))
                        {
                            return false;
                        }

                        setMethod.Invoke(instance, new object[] { value });
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (throwOnError)
                        {
                            throw new Exception("Can not assign property: " + property.Name + ", type:" + property.PropertyType.FullName, ex);
                        }
                        return false;
                    }
                }
            }

            // in MS code they use: BindingFlags.IgnoreCase
            FieldInfo field = TypeHelper.Current.GetFieldInfo(type, memberName);
            if (field != null)
            {
                try
                {
                    if (!ConvertObjectToTypeMain(value, field.FieldType, throwOnError, out value))
                    {
                        return false;
                    }

                    field.SetValue(instance, value);
                    return true;
                }
                catch (Exception ex)
                {
                    if (throwOnError)
                    {
                        throw new Exception("Can not assign field: " + field.Name + ", type:" + field.FieldType.FullName, ex);
                    }
                    return false;
                }
            }
            return true;
        }

        private bool ConvertListToObject(IList list, Type type, bool throwOnError, out object convertedList)
        {
            if (((type == null) || (type == typeof(object))) || IsArrayListCompatible(type))
            {
                Type elementType = typeof(object);
                if ((type != null) && (type != typeof(object)))
                {
                    elementType = type.GetElementType();
                }
                ArrayList newList = new ArrayList();
                if (!AddItemToList(list, newList, elementType, throwOnError))
                {
                    convertedList = null;
                    return false;
                }
                if (((type == typeof(ArrayList)) || (type == typeof(IEnumerable))) || ((type == typeof(IList)) || (type == typeof(ICollection))))
                {
                    convertedList = newList;
                    return true;
                }
                convertedList = newList.ToArray(elementType);
                return true;
            }

            bool convertToHashSet = false;

            if (type.IsGenericType && (type.GetGenericArguments().Length == 1))
            {
                Type type3 = type.GetGenericArguments()[0];
                if (_enumerableGenericType.MakeGenericType(new Type[] { type3 }).IsAssignableFrom(type))
                {
                    Type type5 = _listGenericType.MakeGenericType(new Type[] { type3 });
                    Type hashSetType = _hashSetGenericType.MakeGenericType(new Type[] { type3 });
                    IList list3 = null;

                    if (IsClientInstantiatableType(type) && typeof(IList).IsAssignableFrom(type))
                    {
                        // IList
                        list3 = (IList)Activator.CreateInstance(type);
                    }
                    else if (IsClientInstantiatableType(type) && hashSetType.IsAssignableFrom(type))
                    {
                        // first create IList and convert to HashSet<> at the end
                        list3 = (IList)Activator.CreateInstance(type5); // type5 is IList type
                        convertToHashSet = true;
                    }
                    else
                    {
                        if (type5.IsAssignableFrom(type))
                        {
                            if (throwOnError)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_CannotCreateListType, new object[] { type.FullName }));
                            }
                            convertedList = null;
                            return false;
                        }
                        list3 = (IList)Activator.CreateInstance(type5);
                    }

                    if (!AddItemToList(list, list3, type3, throwOnError))
                    {
                        convertedList = null;
                        return false;
                    }
                    convertedList = list3;

                    if (convertToHashSet)
                    {
                        convertedList = Activator.CreateInstance(hashSetType, new object[] { list3 });
                    }
                    return true;
                }
            }
            else if (IsClientInstantiatableType(type) && typeof(IList).IsAssignableFrom(type))
            {
                IList list4 = (IList)Activator.CreateInstance(type);
                if (!AddItemToList(list, list4, null, throwOnError))
                {
                    convertedList = null;
                    return false;
                }
                convertedList = list4;
                return true;
            }
            if (throwOnError)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AtlasWeb.JSON_ArrayTypeNotSupported, new object[] { type.FullName }));
            }
            convertedList = null;
            return false;
        }

        private bool AddItemToList(IList oldList, IList newList, Type elementType, bool throwOnError)
        {
            foreach (object obj3 in oldList)
            {
                object obj2;
                if (!ConvertObjectToTypeMain(obj3, elementType, throwOnError, out obj2))
                {
                    return false;
                }
                newList.Add(obj2);
            }
            return true;
        }

        private bool IsArrayListCompatible(Type type)
        {
            if ((!type.IsArray && (type != typeof(ArrayList))) && ((type != typeof(IEnumerable)) && (type != typeof(IList))))
            {
                return (type == typeof(ICollection));
            }
            return true;
        }

        private bool IsClientInstantiatableType(Type t)
        {
            if (((t == null) || t.IsAbstract) || (t.IsInterface || t.IsArray))
            {
                return false;
            }
            if (t == typeof(object))
            {
                return false;
            }
            return true;
        }

    }
}

