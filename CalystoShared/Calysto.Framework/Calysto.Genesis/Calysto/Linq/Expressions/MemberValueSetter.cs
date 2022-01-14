//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;

//namespace Calysto.Linq.Expressions
//{
//	public class MemberValueSetter<TModel> : CalystoExpressionVisitorBase
//	{
//		MemberInfo _mi;
//		TModel _instance;
//		public MemberValueSetter(TModel instance)
//		{
//			_instance = instance;
//		}

//		public void SetValue<TValue>(Expression<Func<TModel, TValue>> pathSelector, TValue value)
//		{
//			var path1 = new MemberPropertyPathExtractor<TModel>();
//			string pathStr = path1.GetPath(pathSelector);
//			Calysto.Data.CalystoDataBinder.Private.SetValue(_instance, pathStr, value);
//		}
//	}
//}
