using Calysto.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Calysto.AspNetCore.Mvc.Utility
{
	public class ControllerActionExpressionTranslator : CalystoExpressionVisitorBase
	{
		MethodInfo _action;

		public MethodInfo Translate<TController, TArg1, TArg2, TArg3>(Expression<Func<TController, Func<TArg1, TArg2, TArg3, IActionResult>>> expression)
		{
			base.Visit(expression);
			return _action;
		}

		public MethodInfo Translate<TController, TArg1, TArg2>(Expression<Func<TController, Func<TArg1, TArg2, IActionResult>>> expression)
		{
			base.Visit(expression);
			return _action;
		}

		public MethodInfo Translate<TController, TArg>(Expression<Func<TController, Func<TArg, IActionResult>>> expression)
		{
			base.Visit(expression);
			return _action;
		}

		public MethodInfo Translate<TController>(Expression<Func<TController, Func<IActionResult>>> expression)
		{
			base.Visit(expression);
			return _action;
		}

		protected override Expression VisitConstant(ConstantExpression c)
		{
			if (c.Value is MethodInfo mi && typeof(IActionResult).IsAssignableFrom(mi.ReturnType))
			{
				_action = mi;
				return c;
			}
			else
			{
				return base.VisitConstant(c);
			}
		}
	}

}
