using System;
using System.Collections;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Calysto.Utility;
using System.IO;
using Calysto.Linq.Expressions;

namespace Calysto.Data
{
	public class CalystoDataBinder
    {
		/// <summary>
		/// Search Public, Instance properties and fields.
		/// </summary>
		public static readonly CalystoDataBinder Default = new CalystoDataBinder();

		/// <summary>
		/// Search Public, NonPublic, Instance properties and fields.
		/// </summary>
		public static readonly CalystoDataBinder Private = new CalystoDataBinder() { Binding = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic };

		private BindingFlags Binding = BindingFlags.Instance | BindingFlags.Public;

		private static readonly char[] expressionPartSeparator = new char[] { '.', '[', ']' };

		private static string[] GetPropertyParts(string propertyPath)
		{
			return propertyPath?.Split(expressionPartSeparator).Select(o => o.Trim().Trim('(', '[', ']', ')')).Where(o => !string.IsNullOrEmpty(o)).ToArray();
		}

		private static bool HasPaths(string[] paths)
		{
			return paths?.Any() == true;
		}

		/// <summary>
		/// Returns true if property exists.
		/// </summary>
		/// <param name="dataObj">object with values, IEnumerable, or IDictionary</param>
		/// <param name="propertyPath">case sensitive, public props and fields, dictionary keys, array indexes, eg. Customer.Addresses.3.Street or Customer.Addresses.[3].Street</param>
		/// <param name="result"></param>
		/// <returns></returns>
		public bool TryGetValue<TResult>(object dataObj, string[] propParts, out TResult result)
		{
			try
			{
				if (dataObj == null || !HasPaths(propParts))
				{
					result = default(TResult);
					return false;
				}

				int index;
				object tmpObj = dataObj;
				for (int i = 0; (i < propParts.Length) && (tmpObj != null); i++)
				{
					string propName = propParts[i];

					if (tmpObj is IList && int.TryParse(propName, out index))
					{
						var item = (IList)tmpObj;
						if (item.Count > index)
							tmpObj = ((IList)tmpObj)[index];
						else
						{
							result = default;
							return false;
						}
					}
					else if (tmpObj is IDictionary)
					{
						tmpObj = ((IDictionary)tmpObj)[propName];
					}
					else
					{
						PropertyInfo pi;
						FieldInfo fi;

						if ((pi = tmpObj.GetType().GetProperty(propName, this.Binding)) != null)
						{
							tmpObj = pi.GetValue(tmpObj);
						}
						else if ((fi = tmpObj.GetType().GetField(propName, this.Binding)) != null)
						{
							tmpObj = fi.GetValue(tmpObj);
						}
						else
						{
							// property not found
							result = default(TResult);
							return false;
						}
					}
				}

				if(global::Calysto.Utility.CalystoTypeConverter.TryChangeType<TResult>(tmpObj, out result))
				{
					return true;
				}
			}
			catch
			{
			}

			result = default(TResult);
			return false;
		}

		public bool TryGetValue<TResult>(object dataObj, string propertyPath, out TResult result)
		{
			return TryGetValue<TResult>(dataObj, GetPropertyParts(propertyPath), out result);
		}

		/// <summary>
		/// Throws exception if property doesn't exists.
		/// </summary>
		/// <param name="dataObj">object with values, IEnumerable, or IDictionary</param>
		/// <param name="propertyPath">case sensitive, public props and fields, dictionary keys, array indexes, eg. Customer.Addresses.3.Street or Customer.Addresses.[3].Street</param>
		/// <returns></returns>
		public TResult GetValue<TResult>(object dataObj, string[] propertyPaths)
		{
			if(!HasPaths(propertyPaths))
				throw new ArgumentNullException("propertyPath");
			
			if(TryGetValue<TResult>(dataObj, propertyPaths, out TResult result))
				return result;

			throw new ArgumentNullException("DataBinder_Property_Not_Found: " + string.Join(".", propertyPaths));
        }

		public TResult GetValue<TResult>(object dataObj, string propertyPath)
		{
			return GetValue<TResult>(dataObj, GetPropertyParts(propertyPath));
		}

		private void SetValueInternal(object dataObj, string propertyName, object newValue)
		{
			int index;

			if (dataObj is IList && int.TryParse(propertyName, out index))
			{
				var item = (IList)dataObj;
				if (item.Count > index)
					item[index] = newValue;
				else
					item.Add(newValue);
			}
			else if (dataObj is IDictionary)
			{
				((IDictionary)dataObj)[propertyName] = newValue;
			}
			else
			{
				PropertyInfo pi;
				FieldInfo fi;

				if ((pi = dataObj.GetType().GetProperty(propertyName, this.Binding)) != null)
				{
					pi.SetValue(dataObj, newValue);
				}
				else if ((fi = dataObj.GetType().GetField(propertyName, this.Binding)) != null)
				{
					fi.SetValue(dataObj, newValue);
				}
				else
				{
					throw new ArgumentNullException("DataBinder_Property_Not_Found: " + dataObj.GetType().FullName, propertyName);
				}
			}
		}

		/// <summary>
		/// Set value only if property owner is not null.
		/// </summary>
		/// <param name="dataObj"></param>
		/// <param name="propertyPath"></param>
		/// <param name="newValue"></param>
		/// <param name="typesChain"></param>
		/// <returns></returns>
		public bool TrySetValue(object dataObj, string[] propParts, object newValue, Func<int, Type> getTypeAtIndex = null)
		{
			if (!HasPaths(propParts))
				return false;

			string lastPart = propParts.LastOrDefault();
			string[] partsWithoutLast = propParts.Take(propParts.Length - 1).ToArray();
			object tmpObj = dataObj;

			for (int n1 = 0; n1 < propParts.Length - 1; n1++)
			{
				string property1 = propParts[n1];
				if (TryGetValue(tmpObj, property1, out object value1) && value1 != null)
				{
					tmpObj = value1;
				}
				else if(getTypeAtIndex != null)
				{
					value1 = CalystoActivator.CreateInstance(getTypeAtIndex.Invoke(n1));
					SetValueInternal(tmpObj, property1, value1);
					tmpObj = value1;
				}
				else
				{
					return false;
				}
			}

			SetValueInternal(tmpObj, lastPart, newValue);

			return true;
		}

		public bool TrySetValue(object dataObj, string propertyPath, object newValue, Func<int, Type> getTypeAtIndex = null)
		{
			return TrySetValue(dataObj, GetPropertyParts(propertyPath), newValue, getTypeAtIndex);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataObj">object with values, IEnumerable, or IDictionary</param>
		/// <param name="propertyPath">case sensitive, eg. Customer.Addresses.3.Street or Customer.Addresses.[3].Street</param>
		/// <param name="newValue"></param>
		public void SetValue(object dataObj, string[] propertyPaths, object newValue, Func<int, Type> getTypeAtIndex = null)
		{
			if(!TrySetValue(dataObj, propertyPaths, newValue, getTypeAtIndex))
				throw new InvalidOperationException($"Can not assign {string.Join(".", propertyPaths)} since parent object is null.");
		}

		public void SetValue(object dataObj, string propertyPath, object newValue, Func<int, Type> getTypeAtIndex = null)
		{
			SetValue(dataObj, GetPropertyParts(propertyPath), newValue, getTypeAtIndex);
		}
	}
}

