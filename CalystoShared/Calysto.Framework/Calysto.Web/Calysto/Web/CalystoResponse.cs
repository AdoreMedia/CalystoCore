using Calysto.Web.UI.Direct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calysto.Web.Script.Services;
using Calysto.Linq;
using Calysto.Serialization.Json;
using Calysto.Common.Extensions;
using Calysto.TypeLite;
using Calysto.Web.EnvDTE;
using Calysto.Utility;

namespace Calysto.Web
{
	public class AjaxUpdateManager
	{
		internal class Item
		{
			public string selector { get; set; }
			public string html { get; set; }
		}

		internal List<Item> Items = new List<Item>();

		public AjaxUpdateManager Append(string selector, string html)
		{
			this.Items.Add(new Item() { selector = selector, html = html});
			return this;
		}
	}

	[TsIgnore]
	public class CalystoResponse
	{
		class ResponseState
		{
			public List<Func<string>> JsItems = new List<Func<string>>();
			public List<object> ReturnValue = new List<object>();
			public Exception LastException;
			public string MethodName;
			public bool IsEngineExpired;
			public string ReferenceGuid;
			public string EchoMsg;
			public List<bool?> Successful = new List<bool?>();
		}

		ResponseState _state = new ResponseState();

		/// <summary>
		/// Clear both locked and current response data.
		/// </summary>
		/// <returns></returns>
		public CalystoResponse ClearResponse()
		{
			_state = new ResponseState();
			return this;
		}

		/// <summary>
		/// Set response object, remove previous object if exists.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public CalystoResponse SetReturnValue(object obj)
		{
			_state.ReturnValue.Clear();
			_state.ReturnValue.Add(obj);
			return this;
		}

		/// <summary>
		/// May set many times. State is successful is has items and all are true.
		/// If state is false, will not invoke js ajax event OnSuccess()
		/// </summary>
		/// <param name="isSuccessful"></param>
		/// <returns></returns>
		internal CalystoResponse SetInvocationSuccessful(bool? isSuccessful)
		{
			// state may be set many times
			// it is considered to be successful if count values >= 1 and all values are true
			_state.Successful.Add(isSuccessful);
			return this;
		}

		/// <summary>
		/// Clear all existing data and set exception message.
		/// </summary>
		internal CalystoResponse SetExceptionMessage(Exception ex)
		{
			ClearResponse();
			_state.LastException = ex;
			return this;
		}

		/// <summary>
		/// Late-get function. GetJsFunc will be invoked on building response.
		/// </summary>
		/// <param name="funcGetJs"></param>
		/// <returns></returns>
		public CalystoResponse AddJavaScript(Func<string> getJsFunc)
		{
			_state.JsItems.Add(getJsFunc);
			return this;
		}

		public CalystoResponse AddJavaScript(string js)
		{
			_state.JsItems.Add(()=>js);
			return this;
		}

		public CalystoResponse UseDirectQuery(string calystoSelector, Action<CalystoDirectQuery> action)
		{
			CalystoDirectQuery query = CalystoDirectQuery.FromSelector(calystoSelector);
			action.Invoke(query);
			return this.AddJavaScript(query.ToJavaScript());
		}

		public CalystoResponse UseDirectUtility(Action<CalystoDirectUtility> action)
		{
			CalystoDirectUtility direct = new CalystoDirectUtility();
			action.Invoke(direct);
			return this.AddJavaScript(direct.ToJavaScript());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="saveAjaxHistory">false: just update html, without saving history obj;;; true: update html and save to history obj</param>
		/// <param name="action"></param>
		/// <param name="priority"></param>
		/// <returns></returns>
		public CalystoResponse UseAjaxHistory(Action<AjaxUpdateManager> action)
		{
			AjaxUpdateManager manager = new AjaxUpdateManager();
			action(manager);

			if (manager.Items.Any())
			{
				var arr1 = manager.Items.Select(o => new
				{
					selector = o.selector,
					html = o.html
				}).ToArray();

				StringBuilder sb = new StringBuilder();
				sb.Append("Calysto.AjaxHistory.PushState(");
				sb.Append(global::Calysto.Serialization.Json.JsonSerializer.Serialize(arr1));
				sb.Append(")");

				// be carefull, this js has to be inserted before any other js (eg. CalystoToolTip, when rendered, 
				// creates js Setup func which has to be executed AFTER the html is inserted into dom)
				// Calysto.WebControls Setup js is now inserted on Render(...), so it should be after AjaxUpdate JS
				this.AddJavaScript(sb.ToString());
			}

			return this;
		}

		internal CalystoResponse SetEchoMsg(string msg)
		{
			_state.EchoMsg = msg;
			return this;
		}

		internal CalystoResponse SetEngineExpired()
		{
			_state.IsEngineExpired = true;
			return this;
		}

		internal CalystoResponse SetReferenceGuid(string referenceGuid)
		{
			_state.ReferenceGuid = referenceGuid;
			return this;
		}

		internal CalystoResponse SetMethodName(string methodName)
		{
			_state.MethodName = methodName;
			return this;
		}

		internal Dictionary<string, object> ToDictionaryCompiled()
		{
			//**********************************************************
			// build response
			//**********************************************************
			Dictionary<string, object> dic = new Dictionary<string, object>();

			if (!string.IsNullOrWhiteSpace(_state.EchoMsg))
			{
				dic.Add(nameof(IWebServiceResponseContainer.EchoMsg), _state.EchoMsg);
			}

			if(!string.IsNullOrWhiteSpace(_state.ReferenceGuid))
			{
				dic.Add(nameof(IWebServiceResponseContainer.ReferenceGuid), _state.ReferenceGuid);
			}

			if (_state.IsEngineExpired)
			{
				dic.Add(nameof(IWebServiceResponseContainer.IsEngineExpired), "true");
			}
			else
			{
				if (_state.JsItems.Any())
				{
					string js1 = _state.JsItems.Select(o=>o?.Invoke()).Where(o=>!string.IsNullOrEmpty(o)).ToStringJoined(";") + ";";
					dic.Add(nameof(IWebServiceResponseContainer.JavaScriptLO), js1);
				}

				if (_state.MethodName != null) { dic.Add(nameof(IWebServiceResponseContainer.Method), _state.MethodName); }

				if (_state.LastException != null)
				{
					dic.Add(nameof(IWebServiceResponseContainer.ExceptionMessage), _state.LastException.GetBaseException().Message);
					if (CalystoTools.IsDebugDefined)
					{
						dic.Add(nameof(IWebServiceResponseContainer.ExceptionDetails), _state.LastException.UnwindToString());
					}
				}

				if (_state.ReturnValue.Any())
				{
					dic.Add(nameof(IWebServiceResponseContainer.ReturnedValue), _state.ReturnValue.First());
				}
			}

			dic.Add(nameof(IWebServiceResponseContainer.Type), nameof(IWebServiceResponseContainer));

			dic.Add(nameof(IWebServiceResponseContainer.IsSuccessful), _state.Successful.Any() && _state.Successful.All(o => o == true));

			return dic;
		}

		internal ArraySegment<byte> ToArraySegmentCompiled()
		{
			var dic = this.ToDictionaryCompiled();

			BinaryFrame bf = BinaryFrame.Serialize(dic);
			byte[] binaryFrame = bf.ToBinaryData();

			return new ArraySegment<byte>(binaryFrame);
		}

		internal void SetEchoMsg(object echoServerResponse)
		{
			throw new NotImplementedException();
		}
	}


}
