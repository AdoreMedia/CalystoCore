using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Calysto.Linq.Expressions
{
	/// <summary>
	/// Translate expression to nested property path. eg. Prop1.Prop2.Prop3 and get property name from DisplayAttribute or property name.
	/// </summary>
	public class MemberDisplayExtractor<TModel> : CalystoExpressionVisitorBase
	{
		MemberInfo _mi;
		CalystoRunOnce<MemberInfo> _memberInfoGetter;
		CalystoRunOnce<DisplayAttribute> _displayAttributeGetter;

		public MemberDisplayExtractor(Expression<Func<TModel, object>> expression)
		{
			_memberInfoGetter = new CalystoRunOnce<MemberInfo>(() =>
			{
				base.Visit(expression);
				return _mi;
			});

			_displayAttributeGetter = new CalystoRunOnce<DisplayAttribute>(() =>
			{
				return _memberInfoGetter.Value.GetCustomAttributes<DisplayAttribute>().FirstOrDefault();
			});

		}

		protected override Expression VisitMemberAccess(MemberExpression m)
		{
			// will create full path if property path is nested Prop1.Prop2.Prop3
			// first invocation is for the latest part, Prop3
			if (_mi == null)
				_mi = m.Member;
			// we want first member, don't visit other
			return m;
		}

		public MemberInfo GetMemberInfo()
		{
			return _memberInfoGetter.Value;
		}

		/// <summary>
		/// Get DisplayAttribute or null.
		/// </summary>
		/// <returns></returns>
		public DisplayAttribute GetDisplayAttribute() => _displayAttributeGetter.Value;

		/// <summary>
		/// Get name from DisplayAttribute or property or field name.
		/// </summary>
		/// <returns></returns>
		public string GetName() => this.GetDisplayAttribute()?.GetName() ?? _mi.Name;
	}
}
