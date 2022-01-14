using Calysto.Common.Extensions;
using Calysto.Web.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Calysto.Linq;

namespace Calysto.Web.Script.Services
{
	public abstract class CalystoAjaxHandlerBase
	{
		static Dictionary<Type, PropertyInfo> _dicProp = new Dictionary<Type, PropertyInfo>();

		protected async Task<CalystoResponse> FinalizeResultAsync(CalystoResponse response, object resp, Type returnType, Func<string> fnGetRedirectLocation)
		{
			bool isVoidResult = false;

			if (resp != null && resp is Task task1)
			{
				// Task uvijek ima 1 generic type argument, u slucaju da ne vraca rezultat, onda je tip argumenta System.Threading.Tasks.VoidTaskResult
				// typeof(Task<T>) is different for every T argument

				Type type1 = task1.GetType();

				Type[] args1 = type1.GenericTypeArguments;

				// wait for task to complete
				await task1;

				if (args1.Length == 0 || args1[0].FullName == "System.Threading.Tasks.VoidTaskResult")
				{
					// void result
					resp = null;
					isVoidResult = true;
				}
				else
				{
					PropertyInfo pi = _dicProp.GetValueOrAdd(type1, key => key.GetProperty("Result"));
					resp = pi.GetValue(task1);
				}
			}

			string redirectLoc = fnGetRedirectLocation?.Invoke();

			if (redirectLoc != null)
			{
				// redirect
				return response.ClearResponse().UseDirectUtility(a => a.SetWindowLocation(redirectLoc));
			}
			else if (resp != null && typeof(CalystoResponse).IsAssignableFrom(resp.GetType()))
			{
				// if resp is current response, it is ok, else throw exception
				if (resp != response)
					throw new InvalidOperationException("Can not return new response instance. Use CalystoContext.Current.Response instead.");
			}
			else if (resp != null && typeof(ICalystoJavaScriptDirect).IsAssignableFrom(resp.GetType()))
			{
				response.AddJavaScript(((ICalystoJavaScriptDirect)resp).GetJavaScript());
			}
			else if (!isVoidResult && returnType != typeof(void))
			{
				response.SetReturnValue(resp);
			}

			return response.SetInvocationSuccessful(true);
		}

		protected virtual CalystoResponse CreateExceptionResponse(Exception ex, CalystoResponse response)
		{
			var list = ex.Unwind();

			var wsResp = list.OfType<AjaxAbortException>().FirstOrDefault();

			if (wsResp != null)
			{
				// used to report that user is not logged in or doesn't have access rights
				return response;
			}

			// write exception to log
			CalystoHostingEnvironment.Current.NotifyException(this.GetType().FullName, () => ex);

			//this._httpContext.Response.TrySkipIisCustomErrors = true;

			// send message only to the client
			return response.ClearResponse().SetExceptionMessage(ex).SetInvocationSuccessful(false);
		}

	}
}
