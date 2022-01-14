using Calysto.Web.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calysto.AspNetCore.Mvc.Utility
{
	public static partial class CalystoMvcUtility
	{
		#region ControllerAction exists safe checker

		private static string CreateKey(string controller, string action) => (action + " at controller " + controller).ToLower();

		private static HashSet<string> _controllerActions;

		private static HashSet<string> GetControllerActions()
		{
			if (_controllerActions == null)
			{
				_controllerActions = new HashSet<string>(CalystoMvcHostingEnvironment.Current.ControllerActionDescriptors
					.Select(o => CreateKey(o.ControllerName, o.ActionName)));
			}

			return _controllerActions;
		}

		private static bool ContainsAction(string controller, string action) => GetControllerActions().Contains(CreateKey(controller, action));

		/// <summary>
		/// Throw exception if controller and action are not valid - not existing.
		/// </summary>
		/// <param name="controller"></param>
		/// <param name="action"></param>
		public static void ExceptionIfNotFound(string controllerName, string actionName)
		{
			if (!ContainsAction(controllerName, actionName))
				throw new Exception($"Action \"{actionName}\" at controller \"{controllerName}\" not found.");
		}

		#endregion

		#region controller action builder with exists check

		const string _controllerWord = "Controller";
		static readonly int _controllerLength = _controllerWord.Length;

		private static string ExtractControllerName(string controllerTypeName)
		{
			if (controllerTypeName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
				return controllerTypeName.Substring(0, controllerTypeName.Length - _controllerLength);
			else
				return controllerTypeName;
		}

		/// <summary>
		/// Create controler-action with check if they both exist.
		/// Throw exception if not found.
		/// </summary>
		/// <param name="controllerTypeName">controller type name or name without controller</param>
		/// <param name="actionName"></param>
		/// <returns></returns>
		public static ControllerActionItem CreateControllerActionSafe(string controllerTypeName, string actionName = "Index")
		{
			string controllerName = ExtractControllerName(controllerTypeName);

			ExceptionIfNotFound(controllerName, actionName);

			return new ControllerActionItem()
			{
				controller = controllerName,
				action = actionName
			};
		}

		/// <summary>
		/// Create controler-action with check if they both exist.
		/// </summary>
		/// <param name="controllerType"></param>
		/// <param name="actionName"></param>
		/// <returns></returns>
		public static ControllerActionItem CreateControllerActionSafe(Type controllerType, string actionName = "Index")
		{
			return CreateControllerActionSafe(controllerType.Name, actionName);
		}

		/// <summary>
		/// Create controler-action with check if they both exist.
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		public static ControllerActionItem UseTranslatorSafe(Func<ControllerActionExpressionTranslator, MethodInfo> func)
		{
			ControllerActionExpressionTranslator tranlator = new ControllerActionExpressionTranslator();
			MethodInfo mi = func.Invoke(tranlator);
			return CreateControllerActionSafe(mi.DeclaringType.Name, mi.Name);
		}

		#endregion

	}
}
