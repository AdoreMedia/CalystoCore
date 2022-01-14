using Calysto.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Calysto.Serialization.Json.Core.Serialization
{
	class TypeHelper
	{
		private TypeHelper() { }

		public static readonly TypeHelper Current = new TypeHelper();

		ConcurrentDictionary<Type, Dictionary<string, FieldInfo>> _dicFields = new ConcurrentDictionary<Type, Dictionary<string, FieldInfo>>();

		public Dictionary<string, FieldInfo> GetFields(Type type)
		{
			return _dicFields.GetOrAdd(type, (key2) =>
			{
				return type.GetFields(BindingFlags.Public | BindingFlags.Instance).ToDictionary(o => o.Name);
			});
		}

		/// <summary>
		/// Return FieldInfo or null if not found
		/// </summary>
		/// <param name="type"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public FieldInfo GetFieldInfo(Type type, string fieldName)
		{
			this.GetFields(type).TryGetValue(fieldName, out FieldInfo fi);
			return fi;
		}

		ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>> _dicProps = new ConcurrentDictionary<Type, Dictionary<string, PropertyInfo>>();

		public Dictionary<string, PropertyInfo> GetProperties(Type type)
		{
			return _dicProps.GetOrAdd(type, (key2) =>
			{
				return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(o => o.Name);
			});
		}

		/// <summary>
		/// returns PropertyInfo or null if not found
		/// </summary>
		/// <param name="type"></param>
		/// <param name="useSetter"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public PropertyInfo GetPropertyInfo(Type type, string propertyName)
		{
			this.GetProperties(type).TryGetValue(propertyName, out PropertyInfo propertyInfo);
			return propertyInfo;
		}
	}
}
