/// <reference path="DataBinder.ts" />
/// <reference path="d.ts/IRuntimeConstants.d.ts" />

declare var Calysto_Core_RuntimeConstants: IRuntimeConstants;

namespace Calysto
{
	export class Core
	{
		public static get Constants() { return Calysto_Core_RuntimeConstants || {}; }

		public static get IsDebugDefined() { return Calysto.Core.Constants.IsDebugDefined }

		public static get IsLocallyHosted() { return Calysto.Core.Constants.IsLocallyHosted }

		public static get IsTddSpecific() { return Calysto.Core.Constants.IsTddSpecific }

		/**
		 * Run fn if debug is defined.
		 * @param fn
		 */
		public static DebugRun(fn: () => void)
		{
			if (this.IsDebugDefined)
				fn();
		}

		/**
		 * Register namespace in window object.
		 * @param path
		 */
		public static RegisterGlobalNs(path: string)
		{
			Calysto.DataBinder.SetValue(window, path, {});
		}

		/**
		 * Register obj to window as window[path] = object;
		 * If path not provided, and obj is function, will use obj[name] as path
		 * @param obj
		 * @param path If not set, will use function.name. If can not resolve name, will throw exception.
		 * @param mayOverwrite If namespace already exists:
		 *		if true, will overwrite existing object in namespace
		 *		else, will throw exception
		 */
		public static ExportGlobal(obj: any, path?: string, mayOverwrite?: boolean)
		{
			if (!path && typeof obj == "function")
			{
				path = obj["name"];
				if (!path)
				{
					// older browsers:
					// lambda functions can't be resolved for older browsers
					// standard functions converted to string gives function fnname(args){...}
					let str1 = obj + ""; // gives: function fnname(){}
					let match1 = str1.match("function[\\s]+([^\\(\\)]+)");
					if (match1)
						path = match1[1];
				}
			}

			if (!path)
				throw new Error("ExportGlobal error: path can not be empty.");

			if (!mayOverwrite && Calysto.DataBinder.GetValue(window, path))
				throw new Error("ExportGlobal error: path \"" + path + "\" aready exists in window.");
			else
				Calysto.DataBinder.SetValue(window, path, obj);
		}

		/**
		 * Using IDisposable item which is Disposed() at the end.
		 * exapmple: 		
		let res1 = await Calysto.Core.UseDispose(new Tasks.CancellationTokenSource(3000), async token => await Tasks.TaskUtility.RunAsync(async () =>
		{
			await Tasks.TaskUtility.SleepAsync(1000);
			return 22;
		}, token));
		 * @param item IDisposable object.
		 * @param func Function to execute.
		 */
		public static UseDispose<TItem extends IDisposable, TResult>(item: TItem, func: (item: TItem) => TResult)
		{
			try
			{
				return func(item);
			}
			finally
			{
				item.Dispose();
			}
		}

		public static UseThis<TItem>(item: TItem, func: (item: TItem) => any)
		{
			func(item);
			return item;
		}

		public static UseTryCatch<TItem, TResult>(item: TItem, func: (item: TItem) => TResult, defaultResult?: TResult)
		{
			try
			{
				return func(item);
			}
			catch
			{
				return defaultResult;
			}
		}
	}
}

