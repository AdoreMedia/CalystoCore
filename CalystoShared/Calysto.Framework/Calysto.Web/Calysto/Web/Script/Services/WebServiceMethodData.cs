using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Linq;
using Calysto.Linq;
using Calysto.Serialization.Json;
using Calysto.Serialization.Json.Core.Serialization;

namespace Calysto.Web.Script.Services
{
	class WebServiceMethodData
    {
		#region MethodData cache

		static object _methodsLock = new object();
		static Dictionary<string, Dictionary<string, WebServiceMethodData>> _webServicesCachedDic = new Dictionary<string, Dictionary<string, WebServiceMethodData>>();

		/// <summary>
		/// Get method data from cache or create method data using reflection and cache it
		/// </summary>
		/// <param name="context"></param>
		/// <param name="serviceType"></param>
		/// <param name="methodName"></param>
		/// <returns></returns>
		public static WebServiceMethodData GetMethodData(Type serviceType, string methodName)
		{
			// web service hashtable contains methods per for web service ( WebServiceMethodData  objects)
			Dictionary<string, WebServiceMethodData> methodsInService = _webServicesCachedDic.GetValueOrDefault(serviceType.FullName);
			if (methodsInService == null)
			{
				lock (_methodsLock)
				{
					methodsInService = _webServicesCachedDic.GetValueOrDefault(serviceType.FullName);

					if (methodsInService == null)
					{
						WebServiceData ws = new WebServiceData(serviceType);

						methodsInService = GetWebMethods(serviceType)
						.Select(o => new WebServiceMethodData(ws, o))
						.ToDictionary(o => o.MethodInfo.Name, o => o);

						_webServicesCachedDic[serviceType.FullName] = methodsInService;
					}
				}
			}

			return methodsInService.GetValueOrDefault(methodName);
		}

		#endregion

		public static List<MethodInfo> GetWebMethods(Type type)
		{
			// since we can not retrieve static methods from inherited aspx, or ascx type, use it's base type, and to make sure, use BaseType.BaseType too:

			List<Type> list = new List<Type>() { type };

			if (type.BaseType != null)
			{
				list.Add(type.BaseType);

				if (type.BaseType.BaseType != null)
				{
					list.Add(type.BaseType.BaseType);
				}
			}

			var items = list.SelectMany(o => o.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
				.Where(mi => mi.GetCustomAttributes(typeof(CalystoWebMethodAttribute), true).Length > 0))
				.Distinct(o => o.Name) // same function name with different set of arguments is not supported in Javascript - it is not checked here
				.ToList();

			items.Where(o => !o.IsPublic).ForEach(o => { throw new Exception("Method with [CalystoWebMethod] attribute has to be public: " + o.DeclaringType.FullName + "." + o.Name); });

			return items.Where(o => o.IsPublic).ToList();
		}


        private Dictionary<string, WebServiceParameterData> _parameterData;

		public CalystoWebMethodAttribute MethodAttribute { get; set; }

		internal WebServiceMethodData(WebServiceData owner, System.Reflection.MethodInfo methodInfo)
		{
			this.Owner = owner;
			this.MethodInfo = methodInfo;
			this.MethodAttribute = methodInfo.GetCustomAttributes(typeof(CalystoWebMethodAttribute), true).OfType<CalystoWebMethodAttribute>().FirstOrDefault() ?? new CalystoWebMethodAttribute();
		}

        private object CallMethod(object target, IDictionary<string, object> parameters)
        {
            this.EnsureParameters();
            object[] objArray = new object[this._parameterData.Count];
            foreach (WebServiceParameterData data in this._parameterData.Values)
            {
                object obj2;
                if (!parameters.TryGetValue(data.ParameterInfo.Name, out obj2))
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "WebService_MissingArg", new object[] { data.ParameterInfo.Name }));
                }
                objArray[data.Index] = obj2;
            }
            return this.MethodInfo.Invoke(target, objArray);
        }

        internal object CallMethodFromRawParams(object target, IDictionary<string, object> rawParams, Action<object> argConverted)
        {
			rawParams = this.ConvertTypeAndVerifyStrongParameters(rawParams, argConverted);
            return this.CallMethod(target, rawParams);
        }

		/// <summary>
		/// Convert raw arguments types to types which are expected by the method. Test if all required parameters exists.
		/// </summary>
		/// <param name="rawParams"></param>
		/// <returns></returns>
		private IDictionary<string, object> ConvertTypeAndVerifyStrongParameters(IDictionary<string, object> rawParams, Action<object> argConverted)
		{
			IDictionary<string, object> dictionary2 = new Dictionary<string, object>(this.ParameterDataDictionary.Count);

			// method arguments as Dictionary<string, object> - string is method parameter name, object is an argument to method
			foreach(var kv in this.ParameterDataDictionary)
			{
				object val;
				if(rawParams.TryGetValue(kv.Key, out val))
				{
					try
					{
						Type parameterType = kv.Value.ParameterInfo.ParameterType;
						// convert from culture string for decimal numbers and dates
						SerializerOptions opt1 = new SerializerOptions(){ Culture = CultureInfo.CurrentCulture};
						ObjectConverter converter = new ObjectConverter(opt1);
						object obj1 = converter.ConvertObjectToType(val, parameterType);
						argConverted?.Invoke(obj1);
						dictionary2.Add(kv.Key, obj1);
					}
					catch (Exception ex)
					{
						throw new Exception("Can't convert (" + (val == null ? "null" : val) + ") to parameter \"" + kv.Key + "\" of type " + kv.Value.ParameterInfo.ParameterType.FullName, ex);
					}
				}
				else
				{
					// argument is required but missing
					throw new Exception("Parameter \"" + kv.Key + "\" is required but missing in method " + this.MethodInfo.Name);
				}
			}
			
			return dictionary2;
		}

		internal System.Reflection.MethodInfo MethodInfo { get; set; }

        internal WebServiceData Owner{get;set;}

		private void EnsureParameters()
		{
			if (this._parameterData == null)
			{
				lock (this)
				{
					WebServiceParameterData pardata;
					Dictionary<string, WebServiceParameterData> dictionary = new Dictionary<string, WebServiceParameterData>();
					int index = 0;
					foreach (ParameterInfo info in this.MethodInfo.GetParameters())
					{
						dictionary[info.Name] = pardata = new WebServiceParameterData(info, index);
						index++;
					}
					this._parameterData = dictionary;
				}
			}
		}

        internal IDictionary<string, WebServiceParameterData> ParameterDataDictionary
        {
            get
            {
                this.EnsureParameters();
                return this._parameterData;
            }
        }

		string _fullMethodString = null;

		internal string FullMethodString
		{
			get
			{
				this.EnsureParameters();
				if (_fullMethodString == null)
				{
					string argsStr = this.ParameterDataDictionary.Select(o => o.Value.ParameterType.Name + " " + o.Value.ParameterName).ToStringJoined(", ");
					_fullMethodString = this.MethodInfo.DeclaringType.FullName + "." + this.MethodInfo.Name + "(" + argsStr + ")";
				}
				return _fullMethodString;
			}
		}

    }
}

