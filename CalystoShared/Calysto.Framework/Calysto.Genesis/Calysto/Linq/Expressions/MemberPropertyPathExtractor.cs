using Calysto.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Calysto.Linq.Expressions
{
	public class MemberPropertyPathExtractor<TModel>
	{
		private class PathVisitor : CalystoExpressionVisitorBase
		{
			Stack<List<string>> _stack = new Stack<List<string>>();
			List<string> SqlSegments = new List<string>();

			protected void PushWriter()
			{
				_stack.Push(this.SqlSegments);
				SqlSegments = new List<string>();
			}

			internal List<string> PopWriter()
			{
				List<string> curr = this.SqlSegments;
				this.SqlSegments = _stack.Pop();
				return curr;
			}

			private int ExtractValue(Expression expression)
			{
				if (expression is ConstantExpression const1)
					return (int)(const1.Value);
				else
					return (int) Expression.Lambda(expression).Compile().DynamicInvoke();
			}

			/// <summary>
			/// When collection is Array[]
			/// </summary>
			/// <param name="b"></param>
			/// <returns></returns>
			protected override Expression VisitBinary(BinaryExpression b)
			{
				int index1 = this.ExtractValue(b.Right);

				this.PushWriter();
				Expression left = this.Visit(b.Left);

				var list1 = this.PopWriter();
				string str1 = string.Join(".", list1) + "[" + index1 + "]";
				this.SqlSegments.Insert(0, str1);

				return b;
			}

			/// <summary>
			/// When collection is List<>
			/// </summary>
			/// <param name="m"></param>
			/// <returns></returns>
			protected override Expression VisitMethodCall(MethodCallExpression m)
			{
				// get method, index position, e.g. Colors[2]
				if (m.Arguments.Count == 1 && m.Method.Name.StartsWith("get_"))
				{
					// get index value
					int index1 = ExtractValue(m.Arguments[0]);

					this.PushWriter();

					base.Visit(m.Object);

					var list1 = this.PopWriter();
					string str1 = string.Join(".", list1) + "[" + index1 + "]";
					this.SqlSegments.Insert(0, str1);

					return m;
				}

				throw new NotSupportedException();
			}

			protected override Expression VisitMemberAccess(MemberExpression m)
			{
				this.SqlSegments.Insert(0, m.Member.Name);

				return base.VisitMemberAccess(m);
			}

			public string GetPath(Expression expression)
			{
				this.SqlSegments.Clear();
				base.Visit(expression);
				return string.Join(".", this.SqlSegments);
			}
		}

		/// <summary>
		/// Return new path extractor for nested object.
		/// </summary>
		/// <typeparam name="TReturn"></typeparam>
		/// <param name="fn"></param>
		/// <returns></returns>
		public MemberPropertyPathExtractor<TReturn> GetExtractor<TReturn>(Expression<Func<TModel, TReturn>> fn)
		{
			return new MemberPropertyPathExtractor<TReturn>();
		}

		/// <summary>
		/// Get nested property path relative to base path. Path1.Path2.Path3...
		/// </summary>
		/// <param name="fn"></param>
		/// <returns></returns>
		public string GetPath(Expression<Func<TModel, object>> fn)
		{
			return new PathVisitor().GetPath(fn);
		}

		/// <summary>
		/// Get nested property path relative to base path. Path1.Path2.Path3...
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public string GetPath<TValue>(Expression<Func<TModel, TValue>> expression)
		{
			return new PathVisitor().GetPath(expression);
		}


	}
}

