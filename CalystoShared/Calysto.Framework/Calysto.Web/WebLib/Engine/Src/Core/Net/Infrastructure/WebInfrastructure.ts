/// <reference path="ajaxserviceclientbase.ts" />
/// <reference path="icalystoprogressevent.ts" />
/// <reference path="isocketservicerequestcontainer.ts" />
/// <reference path="isocketwebrequestarguments.ts" />
/// <reference path="iwebserviceresponsecontainer.ts" />
/// <reference path="iwebserviceresponsecontainerwithreturn.ts" />
/// <reference path="iwebservicesettings.ts" />
/// <reference path="webtypes.ts" />
/// <reference path="websocketsession.ts" />
namespace Calysto.Net.WebService
{
	export function Log(msg)
	{
		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
			console.log(Date.now(), msg);
		//#endif
	}

	export function EngineExpired()
	{
		if (Calysto.Page && Calysto.Page.OnVersionExpired && Calysto.Page.OnVersionExpired.Any && Calysto.Page.OnVersionExpired.Any())
		{
			Calysto.Page.OnVersionExpired.Invoke(f => f());
		}
		else if (!Calysto.Page.IsPageReloading)
		{
			document.documentElement.className += ' calystoAjaxLoading';
			Calysto.Page.IsPageReloading = true;

			Calysto.Notification.Create(Resources.CalystoLang.NewVersionFoundPageIsReloading, "warning", NaN, "top", "center").Show();

			setTimeout(() => window.location.reload(true), 1000); // make delay if something brakes down, prevent too many page refreshs
		}
	}

	export function CreateUrl(vpath: string, settings: IWebServiceSettings)
	{
		// path + query, important: exclude # hash
		return (vpath || "")
			.replace("__calysto_method_name__", settings.method || "")
			.replace("__calysto_ss__", settings.sstate ? "1" : "0")
			.replace("__calysto_culture__", Calysto.Globalization.CultureInfo.CurrentCulture.Name)
			.replace("__calysto_current_url__", Calysto.Utility.Encoding.Base64RndEncoder.EncodeToBase64String(window.location.pathname + window.location.search));
	}

	export function CreateArgsObj(methodName: string, argsValues: any[], argNames: string[])
	{
		var obj = {};
		for (var n = 0; n < argNames.length; n++)
		{
			var val = argsValues[n];
			if (typeof (val) == "undefined")
			{
				val = null; // convert "undefined" to null value
			}
			else if (typeof (val) == "function")
			{
				throw new Error("Argument " + argNames[n] + " can not be an function in " + methodName + "(" + argNames.join(", ") + ")");
			}
			obj[argNames[n]] = val;
		}
		return obj;
	}

	/**test if event is triggered by user action */
	export function IsTriggeredByUserAction()
	{
		if (window.event && "isTrusted" in window.event)
		{
			// firefox doesn't have "event" in window
			// isTrusted==true says that event is triggered by user action

			if (event && event.isTrusted && (event.target || event.srcElement))
			{
				// ok, event is triggered by user action
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					console.log("web service method invoked by user event: " + event.type);
				}
				//#endif
				return true;
			}
			else
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					throw new Error("Event is null, not invoked in user event.");
				}
				//#endif
				//return servclient; // da ne baca exception na chain metode koje se invokaju kasnije
				//return false;
			}
		}
		return false;
	}

	export function CreateFullStateObj(sender: WebClient, state: StateTypeSmall<any>)
	{
		let xhr = sender.xhr;

		// LET'S THROW EXCEPTION IF NOT SUPPORTED, nothing else will work anyway
		// XDomainRequest doesn't support getResponseHeader
		// getResponseHeader throws excetpion in few browsers: "An attempt was made to use an object that is not, or is no longer, usable"
		let contentType = "";
		try
		{
			contentType = <string> xhr.getResponseHeader("Content-type");
		}
		catch (ex11) { }

		if (!contentType)
			contentType = xhr["contentType"] || (xhr.response || {}).type || "";

		var calystoType = xhr.getResponseHeader(Calysto.Constants.WsjsHeaderConstants.XTypeHeaderKey);

		var state2 = <StateTypeFull>{
			...state,
			isErrorStatus: (xhr.status < 200 || xhr.status >= 300),
			contentType: contentType,
			isHtml: (contentType || "").indexOf("text/html") >= 0,
			isJson: (contentType || "").indexOf("application/json") >= 0,
			calystoType: calystoType,
		};

		switch (xhr.responseType)
		{
			case "arraybuffer":
				state2.arrayBuffer = xhr.response;
				break;
			case "blob":
				state2.blob = xhr.response;
				break;
			case "":
			case "text":
				state2.respTxt = xhr.responseText;
				break;
			default:
				throw new Error("ResponseType not supported: " + xhr.responseType);
		}

		return state2;
	}

	export async function ReadArrayBufferAsync(state: StateTypeFull)
	{
		if (state.calystoType == Calysto.Constants.WsjsHeaderConstants.XTypeHeaderBinaryFrameValue)
		{
			let finalObj = await Calysto.Json.BinaryFrame.DeserializeAsync<IWebServiceResponseContainerWithReturn<any>>(state.arrayBuffer);
			// finalObj contains complete object including CalystoBlobs inside
			state.responseContainer = finalObj;
		}
		else
		{
			// exception handled on server, response http status is 200 and we probably have JSON sent from server
			// if exception occured on server, we probably have JSON (calysto-json object) or text (html generated on server)
			// eg, we're expecing Blob, but server didn't return CalystoBlob, exception was thrown on server and now we're getting error page html
			state.respTxt = Calysto.Utility.Encoding.UTF8.GetString(new Uint8Array(state.arrayBuffer));

			if (state.isHtml)
			{
				state.errorText = "Blob download failed";
				state.errorHtml = state.respTxt;
			}
			else if (state.isJson)
			{
				// we have Calysto exception response, handle it as classic ajax response
				try
				{
					state.responseContainer = Calysto.Json.Deserialize<IWebServiceResponseContainerWithReturn<any>>(state.respTxt);
				}
				catch (e1)
				{
					state.errorText = "Blob download failed";
					state.errorDescription = state.respTxt;
				}
			}
			else
			{
				state.errorText = "Blob download failed";
				state.errorDescription = state.respTxt;
			}
		}
	};

	export function ProcessResponseContainer(responseContainer: IWebServiceResponseContainerWithReturn<any>, state: StateTypeSmall<any>)
	{
		// JS has to be executed before OnComplete is invoked
		// eg.if js contains version invalidation code, it must execute before OnComplete because in OnComplete may throw exception if argument is null

		state.fnResponseContainerCallback(responseContainer);

		if (responseContainer.IsEngineExpired)
		{
			state.fnResponseEndCallback(); // to hide loading spinner
			EngineExpired();
			return;
		}

		if (Calysto.Page.IsPageReloading)
		{
			// do not execute the rest of the code because it would throw exception only
			state.fnResponseEndCallback(); // to hide loading spinner
			return;
		}

		if (responseContainer.ExceptionMessage && !responseContainer.IsExceptionMessageDone)
		{
			responseContainer.IsExceptionMessageDone = true;
			// this is exception thrown on server
			state.fnResponseEndCallback();
			state.fnErrorCallback(responseContainer.ExceptionMessage, responseContainer.ExceptionDetails, true);
			return;
		}

		if (responseContainer.JavaScriptLO && !responseContainer.IsJavaScriptLODone)
		{
			responseContainer.IsJavaScriptLODone = true;
			////eval("(" + state.respJsObj.JavaScript + ")"); // doesn't work if there is html inside
			// when state.respJsObj is deserialized, state.respJsObj.JavaScript contains real javascript, not string any more, so load it as javascript, not using eval
			let nodeLo = Calysto.ScriptLoader.LoadJS(responseContainer.JavaScriptLO);
			setTimeout(() => (<any>nodeLo).parentNode.removeChild(nodeLo), 200); // remove from dom immediately
		}

		if (responseContainer.IsSuccessful)
		{
			// don't use new thread, this way we have stack trace if something breaks
			state.fnReturnValueCallback(responseContainer.ReturnedValue);
		}
		
		// at the end call response end, it will hide loading spinner
		state.fnResponseEndCallback();
	}

	export function ProcessResponse(state: StateTypeFull)
	{
		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
			Log({ AJAX_RESPONSE: state.responseContainer });
		//#endif

		if (state.errorText)
		{
			state.fnResponseEndCallback();
			state.fnErrorCallback(state.errorText, { errorDescription: state.errorDescription, errorHtml: state.errorHtml }, false);
		}
		else if (state.responseContainer && state.responseContainer.Type == "IWebServiceResponseContainer")
		{
			ProcessResponseContainer(state.responseContainer, state);
		}
		else
		{
			// at the end call response end
			state.fnResponseEndCallback();

			// not CalystoWebServiceResponse, but it is json object
			state.fnReturnValueCallback(state.responseContainer || state.errorText);
		}
	}

	export async function AjaxResponseReceivedHandlerAsync(wclient: WebClient, state1: StateTypeSmall<any>)
	{
		if (wclient.xhr.status == 0)
		{
			// browser disconnected or aborted request, do nothing
			state1.fnResponseEndCallback();
			return;
		}

		let loc1 = wclient.xhr.getResponseHeader("location");
		if (loc1)
		{
			location.assign(loc1);
			return;
		}

		var state = CreateFullStateObj(wclient, state1);

		if (state.isErrorStatus)
		{
			state.errorText = "Ajax response error #2 - error status received";
			state.errorDescription = "xhr.status: " + wclient.xhr.status
				+ "\r\nxhr.statusText: " + wclient.xhr.statusText
				+ "\r\nxhr.resposeText:\r\n";

			var fnProcess11 = function ()
			{
				if (state.isHtml)
				{
					state.errorHtml = state.respTxt;
				}
				else
				{
					state.errorDescription += state.respTxt;
				}
				ProcessResponse(state);
			};

			if (state.respTxt)
			{
				fnProcess11();
			}
			else if (state.arrayBuffer)
			{
				state.respTxt = Calysto.Utility.Encoding.UTF8.GetString(new Uint8Array(state.arrayBuffer));
				fnProcess11();
			}
			else if (state.blob)
			{
				var rr = new FileReader();
				rr.onload = function (res)
				{
					state.respTxt = Calysto.Utility.Encoding.UTF8.GetString(new Uint8Array((<any>res.currentTarget).result));
					fnProcess11();
				};
				rr.readAsArrayBuffer(state.blob);
			}
		}
		else if (state.arrayBuffer)
		{
			await ReadArrayBufferAsync(state);
			ProcessResponse(state);
		}
		else if (state.blob)
		{
			var rr = new FileReader();
			rr.onload = async function (res)
			{
				state.arrayBuffer = <ArrayBuffer>(<any>res.currentTarget).result;
				await ReadArrayBufferAsync(state);
				ProcessResponse(state);
			};
			rr.readAsArrayBuffer(state.blob);
		}
		else
		{
			try
			{
				if (state.isJson)
				{
					state.responseContainer = Calysto.Json.Deserialize(state.respTxt);
				}
			}
			catch (ex)
			{
				state.errorText = "Ajax response error #1 - invalid JSON string";
				state.errorDescription = ex + "\r\nRESPONSE:\r\n" + state.respTxt;
			}
			ProcessResponse(state);
		}
	}

}

