using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using Calysto.Web;
using Calysto.Serialization.Json.Core.Converters;

namespace Calysto.Serialization.Json.Core.Serialization
{
	internal class ObjectSerializer
	{
		public const string TYPE_PROPERTY = "__type$";

		public SerializerOptions Options { get; private set; }

		public ObjectSerializer(SerializerOptions options = null)
		{
			this.Options = options ?? new SerializerOptions();
		}

		#region converters

		private bool TrySerialize(object obj, StringBuilder sb)
		{
			if (JavascriptConverters.Converters != null && obj != null)
			{
				foreach (IJavaScriptConverter cc in JavascriptConverters.Converters)
				{
					if (cc.TrySerialize(obj, sb, this.Options))
					{
						return true;
					}
				}
			}
			return false;
		}

		#endregion

		#region serialize methods

        public string Serialize(object obj)
        {
            StringBuilder output = new StringBuilder();
            this.Serialize(obj, output);
            return output.ToString();
        }

        internal void Serialize(object obj, StringBuilder output)
        {
            this.SerializeValue(obj, output, 0, null);
        }

		#endregion

		#region serializaion by type

		private static void SerializeBoolean(bool o, StringBuilder sb)
        {
            if (o)
            {
                sb.Append("true");
            }
            else
            {
                sb.Append("false");
            }
        }

        private static bool IsObjectInUse(Hashtable objectsInUse, object value)
		{
            if (value == null)
                return false;

            if (objectsInUse.ContainsKey(value))
                return true;

            // if value is collection and any of children items is in objectInUse
            // if value is dictionary and any of children items is in objectInUse
            // value may be string or byte[], so ignore it
            if(value is string str1)
			{
                return false;
			}
            else if(value is byte[] arr1)
			{
                return false;
			}
            else if (value is IDictionary dic1)
            {
                foreach (DictionaryEntry item1 in dic1)
                {
                    if (item1.Value != null && objectsInUse.ContainsKey(item1.Value))
                        return true;
                }
            }
            else if (value is IList en1)
            {
                foreach (var item1 in en1)
                {
                    if (item1 != null && objectsInUse.ContainsKey(item1))
                        return true;
                }
            }
            
            return false;
        }

        private void SerializeCustomObject(object o, StringBuilder sb, int depth, Hashtable objectsInUse)
        {
            bool flag = true;
            Type type = o.GetType();
            sb.Append('{');

			if(this.Options.UseTypeName)
			{
                SerializePropertyName(TYPE_PROPERTY, sb);
				sb.Append(":");
				SerializeString(o.GetType().AssemblyQualifiedName, sb); // must be type.AssemblyQualifiedName, it wont load by type.FullName only
				flag = false;
			}
          
            foreach (FieldInfo info1 in TypeHelper.Current.GetFields(type).Values)
            {
				if (!info1.IsDefined(typeof(NonSerializedAttribute), true) && !info1.IsDefined(typeof(JsonIgnoreAttribute), true))
				{
					object value = info1.GetValue(o);

                    if (value == null && this.Options.IgnoreNullValues)
                        continue;
                    else if (this.Options.SkipCircularReference && IsObjectInUse(objectsInUse, value))
                        continue;

                    if (!flag)
                    {
                        sb.Append(',');
                    }
                    SerializePropertyName(info1.Name, sb);
                    sb.Append(':');

                    this.SerializeValue(value, sb, depth, objectsInUse);
                    flag = false;
                }
            }
            foreach (PropertyInfo info2 in TypeHelper.Current.GetProperties(type).Values)
            {
				if (info2.CanRead && !info2.IsDefined(typeof(NonSerializedAttribute), true) && !info2.IsDefined(typeof(JsonIgnoreAttribute), true))
                {
                    MethodInfo getMethod = info2.GetGetMethod();
                    if (getMethod != null)
                    {
						object value = getMethod.Invoke(o, null);

                        if (value == null && this.Options.IgnoreNullValues)
                            continue;
						else if (this.Options.SkipCircularReference && IsObjectInUse(objectsInUse, value))
                            continue;

						if (!flag)
                        {
                            sb.Append(',');
                        }
                        SerializePropertyName(info2.Name, sb);
                        sb.Append(':');
						
						this.SerializeValue(value, sb, depth, objectsInUse);

                        flag = false;
                    }
                }
            }
            sb.Append('}');
        }

		private void SerializeDictionary(IDictionary o, StringBuilder sb, int depth, Hashtable objectsInUse)
		{
			sb.Append('{');
            List<StringBuilder> list1 = new List<StringBuilder>();
            foreach (DictionaryEntry entry in o)
			{
                string key = entry.Key as string;
				if (key == null)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, AtlasWeb.JSON_DictionaryTypeNotSupported, new object[] { o.GetType().FullName }));
				}

                if (this.Options.SkipCircularReference && IsObjectInUse(objectsInUse, entry.Value))
                    continue;

                StringBuilder sb1 = new StringBuilder();
                this.SerializeDictionaryKeyValue(key, entry.Value, sb1, depth, objectsInUse);
                list1.Add(sb1);
			}
            sb.Append(string.Join(",", list1));
            sb.Append('}');
		}

        private void SerializeDictionaryKeyValue(string key, object value, StringBuilder sb, int depth, Hashtable objectsInUse)
        {
            SerializePropertyName(key, sb);
            sb.Append(':');
            this.SerializeValue(value, sb, depth, objectsInUse);
        }

        private void SerializeEnumerable(IEnumerable enumerable, StringBuilder sb, int depth, Hashtable objectsInUse)
        {
            sb.Append('[');
            List<StringBuilder> list1 = new List<StringBuilder>();
            foreach (object obj2 in enumerable)
            {
                if (this.Options.SkipCircularReference && IsObjectInUse(objectsInUse, obj2))
                    continue;

                StringBuilder sb1 = new StringBuilder();
                this.SerializeValue(obj2, sb1, depth, objectsInUse);
                list1.Add(sb1);
            }
            sb.Append(string.Join(",", list1));
            sb.Append(']');
        }

        private static void SerializeGuid(Guid guid, StringBuilder sb)
        {
            sb.Append("\"").Append(guid.ToString()).Append("\"");
        }

        private static void SerializeString(string input, StringBuilder sb)
        {
            sb.Append('"');
            sb.Append(JavaScriptString.QuoteString(input));
            sb.Append('"');
        }

        private void SerializePropertyName(string input, StringBuilder sb)
		{
			if (!this.Options.ToJavaScript)
                sb.Append('"');
          
            sb.Append(JavaScriptString.QuoteString(input));

            if(!this.Options.ToJavaScript)
                sb.Append('"');
		}

        private static void SerializeUri(Uri uri, StringBuilder sb)
        {
            sb.Append("\"").Append(uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped)).Append("\"");
        }

        private void SerializeValue(object obj, StringBuilder sb, int depth, Hashtable objectsInUse)
        {
            if (++depth > this.Options.RecursionLimit)
                return;

			if(!this.TrySerialize(obj, sb))
			{
                this.SerializeValueInternal(obj, sb, depth, objectsInUse);
            }
        }

        private void SerializeValueInternal(object o, StringBuilder sb, int depth, Hashtable objectsInUse)
        {
            if (o is ICalystoSerialization)
                o = ((ICalystoSerialization)o).ToDictionary();

            Type type = o?.GetType();

            if ((o == null) || DBNull.Value.Equals(o))
            {
                sb.Append("null");
            }
            else if (o is string input)
            {
                SerializeString(input, sb);
            }
            else if (o is char ch)
            {
                if (ch == '\0')
                {
                    sb.Append("null");
                }
                else
                {
                    SerializeString(o.ToString(), sb);
                }
            }
            else if (o is bool)
            {
                SerializeBoolean((bool)o, sb);
            }
            else if (o is Guid)
            {
                SerializeGuid((Guid)o, sb);
            }
            else if (o is TimeSpan)
            {
                SerializeString(o.ToString(), sb);
            }
            else if (o is Uri uri)
            {
                SerializeUri(uri, sb);
            }
            else if (o is double dd)
            {
                sb.Append(dd.ToString("r", this.Options.Culture));
            }
            else if (o is float ff)
            {
                sb.Append(ff.ToString("r", this.Options.Culture));
            }
            else if (type.IsPrimitive || (o is decimal))
            {
                if (o is IConvertible convertible)
                {
                    sb.Append(convertible.ToString(this.Options.Culture));
                }
                else
                {
                    sb.Append(o.ToString());
                }
            }
            else if (type.IsEnum)
            {
                Type type2 = Enum.GetUnderlyingType(type);
                if (type2 == typeof(int))
                    sb.Append((int)o);
                else if (type2 == typeof(byte))
                    sb.Append((byte)o);
                else if (type2 == typeof(long))
                    sb.Append((long)o);
                else
                    throw new InvalidOperationException();
            }
            else
            {
                try
                {
                    if (objectsInUse == null)
                    {
                        objectsInUse = new Hashtable(new ReferenceComparer());
                    }
                    else if (objectsInUse.ContainsKey(o))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AtlasWeb.JSON_CircularReference, new object[] { type.FullName }));
                    }

                    objectsInUse.Add(o, null);

                    if (o is IDictionary dictionary)
                    {
                        this.SerializeDictionary(dictionary, sb, depth, objectsInUse);
                    }
                    else if (o is Type)
                    {
                        // don't serialize type
                        //this.SerializeType((Type)o, sb, depth, objectsInUse);
                    }
                    else if (o is IEnumerable enumerable)
                    {
                        this.SerializeEnumerable(enumerable, sb, depth, objectsInUse);
                    }
                    else
                    {
                        this.SerializeCustomObject(o, sb, depth, objectsInUse);
                    }

                }
                finally
                {
                    if (objectsInUse != null)
                    {
                        objectsInUse.Remove(o);
                    }
                }
            }
        } 

		#endregion

		#region helper properties and methods

#if SILVERLIGHT

        private class ReferenceComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                return (x == y);
            }

            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                return RuntimeHelpers.GetHashCode(obj);
            }
        }
#else
		private class ReferenceComparer : IEqualityComparer
		{
			bool IEqualityComparer.Equals(object x, object y)
			{
				return (x == y);
			}

			int IEqualityComparer.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}
		}
#endif

		#endregion
	}
}

