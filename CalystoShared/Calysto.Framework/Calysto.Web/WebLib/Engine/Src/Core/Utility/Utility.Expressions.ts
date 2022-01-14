namespace Calysto.Utility.Expressions
{
	export function ParsePath<TModel>(pathExpression: (m: TModel) => any)
	{
		let str1 = (pathExpression + "").Trim() || "";
		// depending on browser, str1 is: "function (p) { return p.Form.SenderIP; }" or "p => p.Form.SenderIP"

		if (str1.Contains("=>"))
		{
			return str1.substring(str1.indexOf("=>") + 2).Trim().split(".").slice(1).join("."); // remove p. and take Form.SenderIP
		}

		let m1 = str1.match(new RegExp("return[\\s]*[\\w]+\\.([\\w\\.\\[\\]_@]+)")); // may be parth1.path2[index].path3
		if (m1 && m1[1])
			return m1[1];
		else
			throw new Error("Invalid path expression: " + pathExpression);
	}

	function ParseExpression(expression, checkReturn: boolean): Function
	{
		var type = typeof (expression);

		if (!expression)
		{
			return (function (x) { return x; });
		}
		else if (type == "function")
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				if (checkReturn)
				{
					var fnstr = (expression + "").substr(0, 1000);
					if ((fnstr.indexOf("return") > 0) || (fnstr.indexOf("=>") > 0))
					{
						// it has return or it is lambda expression
					}
					else
					{
						throw Error("Invalid lambda, missing return in: " + fnstr);
					}
				}
			}
			//#endif

			return expression;
		}
		else if (type == "string")
		{
			try
			{
				var index1;

				if (expression == "")
				{
					return function (x) { return x; };
				}
				else if ((index1 = expression.indexOf("=>")) > 0)
				{
					// split at first => only
					// "(DataItem)=>{return DataItem.AsEnumerable().Where('o=>o.Selected').Count() > 1 ? 'yellow' : 'whitesmoke' ;}"

					var left = expression.substr(0, index1);
					var right = expression.substr(index1 + 2); // +2 because => lenth is 2

					var parNames = left.match(new RegExp("[\\w$@_]+", "ig")) || []; // if there is no parameters

					var mm;

					if (mm = right.match(new RegExp("^[\\s]*new[\\s]+(\\{[\\w\\W]*)$")))
					{
						// "o, n => new {Name: o.Name, Age: o.Age}"
						return new Function(parNames.join(","), "return " + mm[1] + ";");
					}
					else if (new RegExp("^[\\s]*\\{").test(right))
					{
						// "o, n => {var a = 10; var b = 20; return a + b;}"
						return new Function(parNames.join(","), right + ";");
					}
					else
					{
						// "o, n => o.Age > 10 && o.Legs > 1"
						return new Function(parNames.join(","), "return " + right + ";");
					}
				}
			}
			catch (err1)
			{
				throw new Error(err1 + "\r\n" + "in " + expression);
			}
		}

		throw new Error("Unsupported expression in Calysto.Utility.Expressions.CompileLambdaExpression(" + expression + ")");
	}


	export function CompileLambdaExpression(expression: Function | string | null | undefined)
	{
		return <Function><any>ParseExpression(expression, true);
	}

	export function CompileLambdaNoReturnCheck(expression: Function | string | null | undefined)
	{
		return <Function><any>ParseExpression(expression, false);
	}
}


