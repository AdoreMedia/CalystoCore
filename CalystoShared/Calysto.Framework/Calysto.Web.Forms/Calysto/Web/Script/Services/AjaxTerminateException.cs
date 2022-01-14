using Calysto.Web.UI.Direct;
using System;

namespace Calysto.Web.Script.Services
{
	public class AjaxAbortAlertException : AjaxAbortException
	{
		/// <summary>
		/// Write the error message to CalystoContext.Current.Response
		/// </summary>
		/// <param name="errorMessage"></param>
		public AjaxAbortAlertException(string errorMessage) : base(errorMessage)
		{
			CalystoContextForms.Current.Response
				.ClearResponse()
				.SetInvocationSuccessful(false)
				.UseDirectUtility(a => a.Alert(errorMessage, CalystoDirectUtility.DialogIconEnum.error));
		}
	}

	public class AjaxAbortNotificationException : AjaxAbortException
	{
		/// <summary>
		/// Write the error message to CalystoContext.Current.Response
		/// </summary>
		/// <param name="errorMessage"></param>
		public AjaxAbortNotificationException(string errorMessage) : base(errorMessage)
		{
			CalystoContextForms.Current.Response
				.ClearResponse()
				.SetInvocationSuccessful(false)
				.UseDirectUtility(a => a.Notification(errorMessage, CalystoDirectUtility.DialogIconEnum.error));
		}
	}
}
