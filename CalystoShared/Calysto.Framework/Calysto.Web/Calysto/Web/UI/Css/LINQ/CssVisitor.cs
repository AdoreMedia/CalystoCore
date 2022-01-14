using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Calysto.Linq.Expressions;
using Calysto.Linq;

namespace Calysto.Web.UI.Css.LINQ
{
	class CssVisitor : CalystoExpressionVisitorBase
	{
		public string Translate(Expression exp)
		{
			base.Visit(exp);

			return this.SqlSegments.ToStringJoined();
		}

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

		protected override Expression VisitUnary(UnaryExpression u)
		{
			string op;

			switch (u.NodeType)
			{
				case ExpressionType.Not:
					op = this.GetOperator(u);
					if (IsBoolean(u.Operand.Type))
					{
						SqlSegments.Add(op);
						SqlSegments.Add(" ");
						return this.VisitPredicate(u.Operand);
					}
					else
					{
						SqlSegments.Add(op);
						return this.VisitValue(u.Operand);
					}

				case ExpressionType.Negate:
				case ExpressionType.NegateChecked:
					op = this.GetOperator(u);
					SqlSegments.Add(op);
					return this.VisitValue(u.Operand);
					
				case ExpressionType.UnaryPlus:
					return this.VisitValue(u.Operand);
					
				case ExpressionType.Convert:
					if(u.Operand.NodeType == ExpressionType.Constant)
					{
						object value = ((ConstantExpression)u.Operand).Value;
						return this.Visit(Expression.Constant(value, u.Type));
					}
					else
					{
						return this.Visit(u.Operand); // we must return converted value
					}
			}

			throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));

		}

		protected override Expression VisitBinary(BinaryExpression b)
		{
			string op = this.GetOperator(b);
			Expression left = b.Left;
			Expression right = b.Right;

			if (b.NodeType != ExpressionType.Coalesce)
			{
				SqlSegments.Add("(");
			}

			switch (b.NodeType)
			{
				case ExpressionType.And:
				case ExpressionType.AndAlso:
				case ExpressionType.Or:
				case ExpressionType.OrElse:
				case ExpressionType.Coalesce :
					if (IsBoolean(left.Type))
					{
						this.VisitPredicate(left);
						SqlSegments.Add(" ");
						SqlSegments.Add(op);
						SqlSegments.Add(" ");
						this.VisitPredicate(right);
					}
					else
					{
						this.VisitValue(left);
						SqlSegments.Add(" ");
						SqlSegments.Add(op);
						SqlSegments.Add(" ");
						this.VisitValue(right);
					}

					////if (b.NodeType == ExpressionType.Coalesce && !SqlSegments.AsEnumerable().Where(o=>o.Text == "COALESCE(").Any())
					////{
					////    SqlSegments.Insert(0, "COALESCE(");
					////    SqlSegments.Add(")");
					////}
					break;

				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
					// check for special x.CompareTo(y) && type.Compare(x,y)
				case ExpressionType.Add:
				case ExpressionType.AddChecked:
				case ExpressionType.Subtract:
				case ExpressionType.SubtractChecked:
				case ExpressionType.Multiply:
				case ExpressionType.MultiplyChecked:
				case ExpressionType.Divide:
				case ExpressionType.Modulo:
				case ExpressionType.ExclusiveOr:

					PushWriter();
					left = this.Visit(left);
					List<string> sbInLeft = PopWriter();
					// depends on left, right and operator
					PushWriter();
					right = this.Visit(right);
					List<string> sbInRight = PopWriter();

					if (left.NodeType == ExpressionType.Constant && right.NodeType == ExpressionType.Constant)
					{
						throw new NotSupportedException();
					}

					if (left.NodeType == ExpressionType.Constant && right.NodeType != ExpressionType.Constant)
					{
						// change left and right if null = o.Age for example to be able to create Age IS NULL
						Expression tmp = right;
						right = left;
						left = tmp;

						List<string> tmpsb = sbInRight;
						sbInRight = sbInLeft;
						sbInLeft = tmpsb;
						op = GetComplementOperator(b);
					}

					string propName = sbInLeft.ToStringJoined();
					string strval = sbInRight.ToStringJoined();
					int value = Convert.ToInt32(strval);
					if (op == ">")
					{
						value += 1;
					}
					else if (op == "<")
					{
						value -= 1;
					}

					switch (op)
					{
						case ">":
						case ">=":
							propName = "min-" + propName;
							break;
						case "<":
						case "<=":
							propName = "max-" + propName;
							break;
					}

					this.SqlSegments.Add(propName + ":" + value + "px");

					////// if column name and value are revesed: 10 < UserID, add column name
					////if (!string.IsNullOrEmpty(this.LastColumnName) && this.LastParameter != null)
					////{
					////    if (string.IsNullOrEmpty(this.LastParameter.Column))
					////    {
					////        this.LastParameter.Column = this.LastColumnName;
					////        this.LastColumnName = null; // once tmpColumnName is used, remove it
					////    }
					////}

					break;

				default:
					throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
			}

			if (b.NodeType != ExpressionType.Coalesce)
			{
				SqlSegments.Add(")");
			}

			return b;
		}

		private string GetOperator(string methodName)
		{
			switch (methodName)
			{
				case "Add": return "+";
				case "Subtract": return "-";
				case "Multiply": return "*";
				case "Divide": return "/";
				case "Negate": return "-";
				case "Remainder": return "%";
				default: return null;
			}
		}

		private string GetOperator(UnaryExpression u)
		{
			switch (u.NodeType)
			{
				case ExpressionType.Negate:
				case ExpressionType.NegateChecked:
					return "-";
				case ExpressionType.UnaryPlus:
					return "+";
				case ExpressionType.Not:
					return IsBoolean(u.Operand.Type) ? "NOT" : "~";
				default:
					return "";
			}
		}
	
		private string GetOperator(BinaryExpression b)
		{
			switch (b.NodeType)
			{
				case ExpressionType.Coalesce:
					return ",";
				case ExpressionType.And:
				case ExpressionType.AndAlso:
					return (IsBoolean(b.Left.Type)) ? "AND" : "&";
				case ExpressionType.Or:
				case ExpressionType.OrElse:
					return (IsBoolean(b.Left.Type) ? "OR" : "|");
				case ExpressionType.Equal:
					return "=";
				case ExpressionType.NotEqual:
					return "<>";
				case ExpressionType.LessThan:
					return "<";
				case ExpressionType.LessThanOrEqual:
					return "<=";
				case ExpressionType.GreaterThan:
					return ">";
				case ExpressionType.GreaterThanOrEqual:
					return ">=";
				case ExpressionType.Add:
				case ExpressionType.AddChecked:
					return "+";
				case ExpressionType.Subtract:
				case ExpressionType.SubtractChecked:
					return "-";
				case ExpressionType.Multiply:
				case ExpressionType.MultiplyChecked:
					return "*";
				case ExpressionType.Divide:
					return "/";
				case ExpressionType.Modulo:
					return "%";
				case ExpressionType.ExclusiveOr:
					return "^";
				default:
					return "";
			}
		}

		private string GetComplementOperator(BinaryExpression b)
		{
			switch (b.NodeType)
			{
				case ExpressionType.Equal:
					return "<>";
				case ExpressionType.NotEqual:
					return "=";
				case ExpressionType.LessThan:
					return ">";
				case ExpressionType.LessThanOrEqual:
					return ">=";
				case ExpressionType.GreaterThan:
					return "<";
				case ExpressionType.GreaterThanOrEqual:
					return "<=";
				default:
					throw new NotSupportedException();
			}
		}

		private bool IsBoolean(Type type)
		{
			return type == typeof(bool) || type == typeof(bool?);
		}

		protected bool IsPredicate(Expression expr)
		{
			switch (expr.NodeType)
			{
				case ExpressionType.And:
				case ExpressionType.AndAlso:
				case ExpressionType.Or:
				case ExpressionType.OrElse:
					return IsBoolean(((BinaryExpression)expr).Type);
				case ExpressionType.Not:
					return IsBoolean(((UnaryExpression)expr).Type);
				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
					return true;
				case ExpressionType.Call:
					MethodCallExpression mc = (MethodCallExpression)expr;
					if (IsBoolean(mc.Type))
					{
						if (IsMethodName(expr, "GetValueOrDefault"))
						{
							return false;
						}
						else if(IsAllNotNullAndConstantExpression(mc)) // .Where(o=> "aaa".Contains("aa")) translates to 1 <> 0
						{
							return false;
						}
						return true;
					}
					else
					{
						return false;
					}
				case ExpressionType.MemberAccess:
					return IsBoolean(((MemberExpression)expr).Type) && IsPropertyName(expr, "HasValue");
				default:
					return false;
			}
		}

		protected bool IsAllNotNullAndConstantExpression(MethodCallExpression mc)
		{
			if (mc == null)
			{
				return false;
			}

			Expression[] items;
			if(mc.Object != null)
			{
				items = new List<Expression>(){mc.Object}.Concat(mc.Arguments).ToArray();
			}
			else
			{
				items = mc.Arguments.ToArray();
			}

			return items.All(o => o != null && (o.NodeType == ExpressionType.Constant || !HaveParameterExpression(o)));
		}

		protected bool IsPropertyName(Expression expr, params string[] names)
		{
			// handles nullable test o.DateStart.HasValue and creates [DateStart] IS NOT NULL
			MemberExpression ma = expr as MemberExpression;
			return ma != null && names.Where(o => o == ma.Member.Name).Take(1).Count() > 0;
		}

		protected bool IsMethodName(Expression expr, params string [] names)
		{
			// handles GetValueOrDefault() call on bool? type to create <> 0 after if there is no other condition
			MethodCallExpression mc = expr as MethodCallExpression;
			return mc != null && names.Where(o => o == mc.Method.Name).Take(1).Count() > 0;
		}

		protected virtual Expression VisitPredicate(Expression expr)
		{
			this.Visit(expr);
			if (!IsPredicate(expr))
			{
				SqlSegments.Add(" <> 0"); // or = 1
			}
			return expr;
		}

		protected virtual Expression VisitExecutable(Expression expr)
		{
			return this.Visit(Expression.Constant(Expression.Lambda(expr).Compile().DynamicInvoke()));
		}

		protected virtual Expression VisitValue(Expression expr)
		{
			if (IsPredicate(expr))
			{
				SqlSegments.Add("CASE WHEN (");
				this.Visit(expr);
				SqlSegments.Add(") THEN 1 ELSE 0 END");
			}
			else
			{
				this.Visit(expr);
			}
			return expr;
		}

		protected bool IsParameter(Expression expr)
		{
			MemberExpression m = expr as MemberExpression;
			return m!= null && m.Expression != null && m.Expression.NodeType == ExpressionType.Parameter;
		}

		protected override Expression VisitMethodCall(MethodCallExpression m)
		{
			// for static methods, m.Object is null, it has arguments to method only
			// for instance methods, m.Object is instance, arguments are arguments to method
			if (!HaveParameterExpression(m.Object) && m.Arguments.All(o => !HaveParameterExpression(o)))
			{
				// nither object or arguments have parameter, it is constant
				return this.VisitExecutable(m);
			}
			else
			{
				// static methods have mc.Object == null
				// chained methods calls are supported:
				//  o.HitKorisnik.AdresaNapomena.Substring(10).Substring(5).Contains("fdsf"))

				// compound methods are supported:
				// .Where(o=>o.Name.Substring(5).Contains("adfs")).Select(o => o.HitKorisnik.AdresaNapomena.Substring(10).Substring(5));

				//// Where(o => new List<int?> { 1, 3, 5 }.Contains(o.ChatAnimatorID)); // parameter is Arguments[1], object is Arguments[0]
				//// Where(o=>o.Name.Contains("fsd')); // Argument[0] is object, Argument[1] is "fds"
				//// general rule: obj is m.Object ?? m.Arguments.First(), argument to method is always m.Arguments.Last()
				//// if it is extension method like .Count(), we have argument[0]
				//// example o=> o.StartDate.GetValueOrDefault()
				//// o=>o.Name.Count()
				//// o=>o.Name.FirstOrDefault()

				throw new NotSupportedException();
				//return MemberMethodCallResolver(m); // if not resolved in VisitMemberMethodCall(), call this.Visit(child);
			}
		}

		private bool HaveParameterExpression(Expression exp)
		{
			while (exp != null)
			{
				if (exp is UnaryExpression && exp.NodeType == ExpressionType.Convert)
				{
					exp = ((UnaryExpression)exp).Operand;
				}
				else if (exp is ParameterExpression)
				{
					return true;
				}
				else if (exp is MemberExpression)
				{
					exp = ((MemberExpression)exp).Expression;
				}
				else if (exp is MethodCallExpression)
				{
					// static methods have mc.Object == null
					// chained methods calls are supported:
					//  o.HitKorisnik.AdresaNapomena.Substring(10).Substring(5).Contains("fdsf"))
					MethodCallExpression mc = (MethodCallExpression)exp;
					exp = mc.Object ?? mc.Arguments.FirstOrDefault();
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		protected override Expression VisitMemberAccess(MemberExpression m)
		{
			if (!HaveParameterExpression(m))
			{
				// required to translate var gds = new Query<HitOglasAuto>().Where(o => o.HitOglasID == this.HitOglasID);
				// this.HitOglasID doesn't have paremeter, so it is evaluated as constant, else it would translate to "HitOglasAuto.HitOglasID"
				// it is constant
				return this.VisitExecutable(m);
			}
			////else if (m.Member.DeclaringType == typeof(Calysto.Web.UI.Css.CalystoMediaRule.MediaScreenSettings))
			////{
			////	SqlSegments.Add(m.Member.Name.ToLower());
			////	return m;
			////}
			else
			{
				throw new NotSupportedException();
				//return MemberAccessResolver(m); // if method not resolved, throw exception or discard method and call this.Visit(m.Expression)
			}
		}

		protected override Expression VisitConstant(ConstantExpression c)
		{
			WriteLiteral(c.Value + "");
			return c;
		}

		protected void WriteLiteral(string str)
		{
			SqlSegments.Add(str);
		}

		protected override Expression VisitConditional(ConditionalExpression c)
		{
			/*
CASE
     WHEN Boolean_expression THEN result_expression [ ...n ] 
     [ ELSE else_result_expression ] 
END
			 */
			// this is used by WHERE, SELECT and by ORDER BY statements
			this.WriteLiteral("(CASE WHEN (");
			Expression test = this.VisitPredicate(c.Test);
			this.WriteLiteral(") THEN (");
			Expression ifTrue = this.Visit(c.IfTrue);
			this.WriteLiteral(") ELSE (");
			Expression ifFalse = this.Visit(c.IfFalse);
			this.WriteLiteral(") END)");
			if (test != c.Test || ifTrue != c.IfTrue || ifFalse != c.IfFalse)
			{
				return Expression.Condition(test, ifTrue, ifFalse);
			}
			return c;
		}

	}
}
