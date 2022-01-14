//using Calysto.Linq;
//using Calysto.Utility;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Calysto.AspNetCore.Mvc.ViewVeatures
//{
//	public static class ViewDataDictionaryExtensions
//	{
//		/// <summary>
//		/// Get instance or create new and insert to dictionary. Return instance.
//		/// </summary>
//		/// <typeparam name="TInstance"></typeparam>
//		/// <param name="viewData"></param>
//		/// <returns></returns>
//		public static TInstance GetInstanceOrNew<TInstance>(this ViewDataDictionary viewData)
//		{
//			return (TInstance) viewData.GetValueOrNew(typeof(TInstance).FullName, () => CalystoActivator.CreateInstance<TInstance>());
//		}
//	}
//}
