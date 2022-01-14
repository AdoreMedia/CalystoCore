//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;

//namespace Calysto.Linq.Expressions
//{
//	public class MemberInfoExtractor : CalystoExpressionVisitorBase
//	{
//		MemberInfo _mi;

//		protected override Expression VisitMemberAccess(MemberExpression m)
//		{
//			if (_mi == null)
//				_mi = m.Member;
//			return m;
//		}

//		public MemberInfo GetMemberInfo<TModel, TValue>(Expression<Func<TModel, TValue>> selector)
//		{
//			_mi = null;
//			base.Visit(selector);
//			return _mi;
//		}
//	}
//}
