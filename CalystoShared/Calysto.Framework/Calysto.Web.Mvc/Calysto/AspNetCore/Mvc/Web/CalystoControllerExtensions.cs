using Calysto.AspNetCore.Mvc.ModelBinding;
using Calysto.DataAnnotations.ValidationService;
using Calysto.Linq;
using Calysto.Web;
using Calysto.Web.UI.Direct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calysto.AspNetCore.Mvc.Web
{
	public static class CalystoControllerExtensions
	{
		/// <summary>
		/// Send response.
		/// </summary>
		/// <param name="controller"></param>
		/// <param name="response"></param>
		/// <returns></returns>
		public static CalystoActionResult CalystoResult(this Controller controller, CalystoResponse response)
		{
			return new CalystoActionResult(response);
		}

		/// <summary>
		/// Send current calysto response.
		/// </summary>
		/// <param name="controller"></param>
		/// <returns></returns>
		public static CalystoActionResult CalystoResult(this Controller controller)
		{ 
			return controller.CalystoResult(CalystoContextMvc.Current.Response);
		}

		public static CalystoActionResult CalystoResult(this Controller controller, Action<CalystoResponse> action)
		{
			CalystoResponse response = new CalystoResponse();
			action.Invoke(response);
			return controller.CalystoResult(response);
		}

		public static CalystoModelStateHelper<TModel> GetCalystoModelStateHelper<TModel>(this Controller controller, TModel model)
		{
			string rootSelector = null;
			if (controller.HttpContext.Request.Form.TryGetValue("__RootSelectorKey", out var value))
				rootSelector = value;

			var state = new CalystoModelStateHelper<TModel>(controller.ModelState, model, rootSelector);

			// add state to response here, we have to generate response js which will remove previous errors from DOM, always
			CalystoContextMvc.Current.Response.AddJavaScript(() =>
			{
				return new CalystoMvcModelState<TModel>(state.GetErrors(), null, state.RootSelector, state.GetValues()).ToJavaScript();
			});

			return state;
		}
	}
}
