namespace Calysto.Page.Diagnostic
{
	/***********************************************************/
	// has to be set on server, ony if ElmahLog="true"
	var ServerUrl: string = (Calysto.Core.Constants.ServerDiagnosticUrl || "").replace("=", "://");
	/***********************************************************/

	function sendElmahLog(errMsg: string, errDetails)
	{
		if (!errMsg) return;

		// Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) GSA/22.0.141836113 Mobile/14C92 Safari/600.1.4
		// Mozilla/5.0 (iPhone; CPU iPhone OS 10_2_1 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) GSA/22.0.141836113 Mobile/14D27 Safari/600.1.4
		// Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_2 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/58.0.3029.113 Mobile/14F89 Safari/602.1
		// neki agenti imaju interne greske pa da nam ne pune elmah, blacklistamo ih
		// SecurityError (DOM Exception 18): Blocked a frame with origin "https://www.somepage.com" from accessing a frame with origin "https://acdn.adnxs.com". Protocols, domains, and ports must match.
		// block next errors on iPhone to prevent from writing to Elmah:
		if (errMsg.indexOf("Blocked a frame with origin") >= 0)
		{
			return;
		}
		else if (errMsg.indexOf("null is not an object (evaluating 'elt.parentNode')") >= 0)
		{
			return;
		}

		var xmlhttp = Calysto.Net.WebClient.GetXMLHttpRequest(ServerUrl);
		// open request
		// since setRequestHeader is not supported on IE8 & IE9 XDomainRequest, it will throw exception here, that is why we have try-catch
		xmlhttp.open("POST", ServerUrl, true);
		xmlhttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
		// custom header can't be set on crossdomain request
		xmlhttp.setRequestHeader(Calysto.Constants.WsjsHeaderConstants.XAjaxHeaderKey, Calysto.Constants.WsjsHeaderConstants.XExceptionHeaderValue);

		var pageHtml = (document.documentElement.innerHTML || "").substr(0, 100);

		var detailsFormated = errDetails;//// + "\r\n\r\n<--- page html start --->\r\n" + pageHtml + "\r\n...\r\n<--- page html end --->";

		var inputValues = "";

		try
		{
			// we can't use Calysto.Forms.Serialize since not all elements have attributes calysto-id or name or id
			var items22 = $$calysto(document.documentElement).Query("//input, //select, //textarea").Select((el: any) =>
			({
				tagName: el.tagName,
				type: el.type,
				calystoId: el.getAttribute(Calysto.AttrName.CalystoId),
				id: el.id,
				name: el.name,
				value: el.value
			})).ToArray();

			inputValues = Calysto.Json.Serialize(items22, 50);
		}
		catch (ex1)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				console.error(ex1);
			}
			//#endif
			inputValues = "*error, values can no be serialized*";
		}

		// since all system objects return hasOwnProperty(name) == false, it can not be serialized, properties have to be cloned to new object first
		var jsitems = { location: {}, screen: {}, navigator: {} };
		Calysto.Collections.ForEachProperties(location, function (name, value, index) { try { jsitems.location[name] = value } catch (e) { } });
		Calysto.Collections.ForEachProperties(screen, function (name, value, index) { try { jsitems.screen[name] = value } catch (e) { } });
		Calysto.Collections.ForEachProperties(navigator, function (name, value, index) { try { jsitems.navigator[name] = value } catch (e) { } });

		var obj = {
			calystoExObj: true,
			errMsg: errMsg,
			errDetails: detailsFormated,
			url: window.location.href,
			cookie: document.cookie,
			userAgent: navigator.userAgent,
			location: Calysto.Json.Serialize(jsitems.location),
			screen: Calysto.Json.Serialize(jsitems.screen),
			navigator: Calysto.Json.Serialize(jsitems.navigator),
			inputValues: inputValues
		};

		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
		{
			//	console.log(JSON.stringify(obj));
		}
		//#endif

		var json = Calysto.Json.Serialize(obj);
		var bb = Calysto.Utility.Encoding.Base64RndEncoder.EncodeToBase64String(json);

		//send request
		// request is handled on server in CalystoElmahErrorHandler.cs
		xmlhttp.send(bb);

	}

	export function ElmahLog(errMsg: string, errDetails: string)
	{
		/// <summary>
		/// Send exeption to server.
		/// </summary>
		/// <param name="elmahTitle" type="string"></param>
		/// <param name="elmahDescription" type="string"></param>

		try
		{
			if (ServerUrl)
			{
				sendElmahLog(errMsg, errDetails)
			}
		}
		catch (e1)
		{
			// slanje nije uspjelo
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				try
				{
					console.error(e1);
				}
				catch (e2) { }
			}
			//#endif
		}
	};

	interface IFormatedError
	{
		/** short message */
		Message: string;
		/** complete details with call stack, used in debug mode*/
		Details: string;
		/** */
		HtmlDetails: string;
		/** true if exception was thrown on server*/
		IsServerError: boolean;

		FileName: string;

		LineNo: number;

		ColNo: number;

		Stack: string;
	};

	interface IErrorVariants
	{
		message: string,
		stack: string,
		description: string,
		error: ErrorEvent & {
			CalystoException: ICalystoException,
			stack: string,
			description: string
		},
		reason: {
			message: string,
			stack: string,
			description: string,
			CalystoException: ICalystoException
		}
	}

	function fnFormatErrorEvent(ev0: ErrorEvent | PromiseRejectionEvent)
	{
		// ev.error.CalystoException kreira se sa new Error().AppendErrorDetails({p:10}) u Error.js extenziji
		// ev.reason.CalystoException kreira se iz promisa

		let res = <IFormatedError>{};
		let ev1 = <ErrorEvent><any>ev0;
		let errVar = <IErrorVariants><any>ev0;

		// execute code in try-catch to prevent throwing exception from here, it would create endless loop
		try
		{
			let calystoEx = errVar?.error?.CalystoException || errVar?.reason?.CalystoException;

			var details: string[] = [];

			if (calystoEx && calystoEx.IsServerError)
			{
				res.Message = calystoEx.Message;
				details.push(calystoEx.Details);
				res.HtmlDetails = calystoEx.HtmlDetails || "";
			}

			res.Message = (res.Message || errVar?.reason?.message || errVar?.error?.message || errVar?.message || errVar?.reason || errVar?.error) + "";

			res.Stack = errVar?.error?.stack || errVar?.reason?.stack || errVar?.stack;

			res.FileName = ev1.filename;
			res.LineNo = ev1.lineno;
			res.ColNo = ev1.colno;

			let description = errVar?.reason?.description || errVar?.error?.description || errVar?.description;
			if (description)
				details.push(description);


			if (res.FileName)
				details.push("filename: " + res.FileName);

			if (res.LineNo)
				details.push("lineno: " + res.LineNo);

			if (res.ColNo)
				details.push("colno: " + res.ColNo);

			if (res.Stack)
				details.push("stack:\r\n" + res.Stack);

			if (calystoEx)
			{
				details.push("-----------------------------");
				details.push("CalystoException.Message:");
				details.push(calystoEx.Message);
				details.push("CalystoException.Details:");
				details.push(calystoEx.Details);
			}

			res.Details = details.join("\r\n");
		}
		catch (e1) { }

		return res;
	}

	export function ErrorHandler(ev: ErrorEvent | PromiseRejectionEvent)
	{
		try
		{
			var err = fnFormatErrorEvent(ev);

			if (!err || !err.Message)
			{
				// this err has no description, usually it is thrown if some google script is not loaded or is blocked by adblocker
				// don't show anything
				return;
			}

			// if there is no FileName or no Stack, exception is useless, so don't write it to Elmah
			if (err && !err.IsServerError && err.FileName && err.Message && err.Stack)
			{
				try
				{
					// server error is thrown on server and written to Elmah
					// write to elmah
					Calysto.Page.Diagnostic.ElmahLog(err.Message, err.Details);
				} catch (e6) { }
			}

			try
			{
				// show error message to the user
				Calysto.Page.OnUnhandledException.Invoke(f => f(err.Message));
			}
			catch (e5) { }

			////#if DEBUG
			//if (Calysto.Core.IsDebugDefined)
			//{
			//	try
			//	{
			//		// if <pre> element is not supported, we need <br/> instead of \r\n, like IE <= 8
			//		// <pre> element knows that <br/> has to be show as \r\n
			//		var dialog = Calysto.Dialog.CreateError(
			//			err.Message + "\r\n\r\n" + err.Details,
			//			"DEBUG MODE - " + (err.IsServerError ? "Server Exception" : "Unhandled JS Exception")
			//		).Show();

			//		if (err.HtmlDetails)
			//		{
			//			dialog.AppendContent(err.HtmlDetails);
			//		}
			//	}
			//	catch (e5) { }
			//}
			////#endif
		}
		catch (e1)
		{
		}
	};

	if (typeof (ErrorEvent) != "undefined")
	{
		if (window.addEventListener)
		{
			window.addEventListener("error", ErrorHandler, true);
			window.addEventListener("unhandledrejection", ErrorHandler, true);
		}
		else if ((<any>window).attachEvent)
		{
			(<any>window).attachEvent("on" + "error", ErrorHandler, true);
			(<any>window).attachEvent("on" + "unhandledrejection", ErrorHandler, true);
		}
	}
	else
	{
		// ovo je IE <= 9
		// Safari win 5.x
		window.onerror = function (msg, file, line, column)
		{
			ErrorHandler(<ErrorEvent>{
				// column number
				colno: column || null,
				// line number
				lineno: line,
				// source filename
				filename: file,
				// error message
				message: msg,
				// error type
				type: "error"
			});
		};

		window.onunhandledrejection = function (ev: PromiseRejectionEvent)
		{
			ErrorHandler(<ErrorEvent>{
				// error message
				message: ev.reason,
				// error type
				type: "unhandledrejection"
			});
		};
	}
}

