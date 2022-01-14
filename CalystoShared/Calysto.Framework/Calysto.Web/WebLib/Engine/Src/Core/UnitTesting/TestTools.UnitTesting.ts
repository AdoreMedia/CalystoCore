namespace Calysto.TestTools.UnitTesting
{
	export namespace Assert
	{
		function ShowError(msg: string)
		{
			console.error(msg);
			return false;
		}

		function ConvertToString(value: any)
		{
			if (typeof value == "string")
				return value;
			if (value === undefined)
				return "undefined";
			else if (value === null)
				return "null";
			else if (isNaN(value))
				return "NaN";
			else // any other object
				return JSON.stringify(value);
		}

		class MessageBuilder
		{
			private _lines: string[] = [];
			public constructor(mainMsg: string)
			{
				this._lines.push(mainMsg);
			}

			public AddNameValue(name: string, value: any)
			{
				this._lines.Add(name + ":<" + ConvertToString(value) + ">.");
				return this;
			}

			public AddCustom(message?: string, parameters?: any[] | object)
			{
				if (message)
					this._lines.Add(message.FormatWith(parameters));
				return this;
			}

			public ToStringFormated(separator = "\r\n")
			{
				return this._lines.join(separator);
			}
		}

		/**
		 * Test references and types with ===, than
		 * Compare values for reference types by serializing to json and compare json strings.
		 * @param expected
		 * @param actual
		 * @param message 
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function AreEqual<T>(expected: T, actual: T, message?: string, parameters?: any[] | object)
		{
			if (Calysto.Type.TypeInspector.AreValuesEqual(expected, actual))
				return true;
			else
				return ShowError(new MessageBuilder("Assert.AreEqual failed.")
					.AddNameValue("Expected", expected)
					.AddNameValue("Actual", actual)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		export function AreNotEqual<T>(notExpected: T, actual: T, message?: string, parameters?: any[] | object)
		{
			if (!Calysto.Type.TypeInspector.AreValuesEqual(notExpected, actual))
				return true;
			else
				return ShowError(new MessageBuilder("Assert.AreNotEqual failed.")
					.AddNameValue("NotExpected", notExpected)
					.AddNameValue("Actual", actual)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Test with if references and types are equal using ===. 
		 * Doesn't compare values for reference types.
		 * @param expected
		 * @param actual
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function AreSame<T>(expected: T, actual: T, message?: string, parameters?: any[] | object)
		{
			if (expected === actual)
				return true;
			else
				return ShowError(new MessageBuilder("Assert.AreSame failed.")
					.AddNameValue("Expected", expected)
					.AddNameValue("Actual", actual)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Test with if references and types are equal using ===. 
		 * Doesn't compare values for reference types.
		 * @param expected
		 * @param actual
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function AreNotSame<T>(expected: T, actual: T, message?: string, parameters?: any[] | object)
		{
			if (expected !== actual)
				return true;
			else
				return ShowError(new MessageBuilder("Assert.AreNotSame failed.")
					.AddNameValue("Expected", expected)
					.AddNameValue("Actual", actual)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		export function Fail(message?: string, parameters?: any[] | object)
		{
			return ShowError(new MessageBuilder(`Assert.Fail.`)
				.AddCustom(message, parameters)
				.ToStringFormated());
		}

		export function Inconclusive(message?: string, parameters?: any[] | object)
		{
			return ShowError(new MessageBuilder(`Assert.Inconclusive.`)
				.AddCustom(message, parameters)
				.ToStringFormated());
		}

		/**
		 * Expects condition to be false.
		 * @param condition
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function IsFalse(condition: boolean, message?: string, parameters?: any[] | object)
		{
			if (!(condition === false))
				return true;
			else
				return ShowError(new MessageBuilder(`Assert.IsFalse failed.`)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Expects condition to be true.
		 * @param condition
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function IsTrue(condition: boolean, message?: string, parameters?: any[] | object)
		{
			if ((condition === true))
				return true;
			else
				return ShowError(new MessageBuilder(`Assert.IsTrue failed.`)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Is null, undefined or NaN
		 * @param value
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function IsNull<T>(value: T, message?: string, parameters?: any[] | object)
		{
			if (Calysto.Type.TypeInspector.IsNullOrUndefined(value))
				return true;
			else
				return ShowError(new MessageBuilder(`Assert.IsNull failed.`)
					.AddNameValue("Actual", value)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Is not null, undefined or NaN
		 * @param value
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function IsNotNull<T>(value: T, message?: string, parameters?: any[] | object)
		{
			if (!Calysto.Type.TypeInspector.IsNullOrUndefined(value))
				return true;
			else
				return ShowError(new MessageBuilder(`Assert.IsNotNull failed.`)
					.AddNameValue("Actual", value)
					.AddCustom(message, parameters)
					.ToStringFormated());
		}

		/**
		 * Test if action throws exception.
		 * @param action function
		 * @param message
		 * message {prop1} if parameters is object {prop1: "value"}
		 * or message {0}, {1} if parameters is array with values ["one", "two"]
		 * @param parameters array ["one", "two"] or object with properties {prop1: "value"}
		 */
		export function ThrowsException<T extends Function>(action: T, message?: string, parameters?: any[] | object)
		{
			try
			{
				action();
			}
			catch (err)
			{
				return true;
			}
			return ShowError(new MessageBuilder(`Assert.ThrowsException failed. Exception was not thrown.`)
				.AddCustom(message, parameters)
				.ToStringFormated());
		}
	}
}