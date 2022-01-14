interface Function
{
	////SetIntellisense(func: () => {}): () => {};

	////EncapsulateArgs(...args: any[]): Function;

	BindContext(context: any): Function;
}

////if (!Function.prototype.EncapsulateArgs)
////{
////	Function.prototype.EncapsulateArgs = function (...args: any[]): Function
////	{
////		/// <summary>
////		/// Create outter function, bind current function with context and arguments. <br/>Return outter function which must be invoked without argumens.
////		/// </summary>
////		/// <param name="arg0" type="object">arg0</param>
////		/// <param name="arg1" type="object" optional="true"></param>
////		/// <param name="arg2" type="object" optional="true"></param>
////		/// <param name="arg3" type="object" optional="true"></param>
////		/// <param name="etc" type="object" optional="true"></param>

////		if (arguments.length < 1)
////		{
////			throw new Error("EncapsulateArgs(...) requires min 1 argument, current arguments: " + arguments.length);
////		}

////		var method = this;
////		var arr = arguments;

////		return function ()
////		{
////			return method.apply(method, arr)
////		};
////	};
////}

if (!Function.prototype.BindContext)
{
	Function.prototype.BindContext = function (context): Function
	{
		/// <summary>
		/// Bind current function with context and optionally arguments.
		/// </summary>
		/// <param name="context">execution context</param>

		if (arguments.length != 1)
		{
			throw new Error("BindContext(...) requires 1 argument exactly, current arguments: " + arguments.length);
		}

		var method = this;
		var cx = context || this || null;

		return function (/*arguments*/)
		{
			//now invoke this method within cx context and this arguments
			return method.apply(cx, arguments);
		};
	};
}

