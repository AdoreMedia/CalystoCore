namespace Calysto.Mvc.AjaxForm
{
	let _isEnabled = false;
	let _isDisabled = false;

	export function IsAjaxFormSubmitEnabled()
	{
		return _isEnabled && !_isDisabled;
	}

	export function UseAjaxFormSubmit(enable = true)
	{
		if (enable === false)
		{
			_isDisabled = true;
		}
		else if (!_isEnabled)
		{
			_isEnabled = true;
			Calysto.Page.OnEndResponse(() => fnInitFormsInterceptor());
		}
	}

	/**
	 * Submit form without validation.
	 * Form has to be fully rendered and visible in browser, otherwise it won't work.
	 * @param formSelector
	 */
	export function SubmitForm(formSelector: string | ICalystoHtmlFromElement, delay: number = 0)
	{
		setTimeout(() =>
		{
			let form = $$calysto<ICalystoHtmlFromElement>(formSelector).First();
			fnCreateAndSendRequest(form);
		}, delay);
	}

	type FormMode =
		{
			ReplaceChildren,
			InsertChildren,
			AddChildren
		};

	interface ICalystoHtmlFromElement extends HTMLFormElement
	{
		$$CalystoInterceptor: boolean;
	}

	function fnInitFormsInterceptor()
	{
		// init forms
		$$calysto<ICalystoHtmlFromElement>("form")
			.Where(f => !f.$$CalystoInterceptor)
			.ForEach(frm =>
			{
				frm.$$CalystoInterceptor = true;

				let f1 = <any>frm;

				f1.submitBase = f1.submit;
				// this code handles when form.submit() is invoked
				f1.submit = function (this: ICalystoHtmlFromElement, ev)
				{
					let _safethis14 = this;
					setTimeout(() => fnHandleSubmitRequest(_safethis14));
					return false;
				};

			}).On("submit", (sender, ev) =>
			{
				// this code handles when button type=submit inside form is clicked
				setTimeout(() => fnHandleSubmitRequest(sender));
				return false;
			});
	}

	function fnHandleSubmitRequest(sender: ICalystoHtmlFromElement)
	{
		if (!IsAjaxFormSubmitEnabled())
			return false;

		// if form not valid, return
		if (Calysto.DataAnnotations.FindValidationService(sender)?.Validate().Render().Interactive(true).HasErrors())
			return false;

		fnCreateAndSendRequest(sender);

		return false;
	}

	function fnCreateAndSendRequest(frm: ICalystoHtmlFromElement)
	{
		if (!frm)
			throw new Error("Form is null.");

		// hander: function(content){} or lambda (content)=> {} or just function name in global scope
		let receivedHandler1 = <string>frm.getAttribute(Constants.CalystoDomAttributes.CalystoFormHandler);

		let targetSel1 = <string>frm.getAttribute(Constants.CalystoDomAttributes.CalystoFormTarget);
		if (!targetSel1 && !receivedHandler1)
		{
			//#if DEBUG
			if (Calysto.Core.IsDebugDefined)
			{
				console.log("Form has no target and no received handler.");
			}
			//#endif
			return;
		}

		// if we have receivedHandler1, targetSel1 is null, so use frm element
		let selectorId = Calysto.Utility.Dom.EnsureElementId(targetSel1 || frm);

		// we need to know container root selector to create validation errors for container only
		let appendArr: { Key: string, Value: any }[] = [{ Key: "__RootSelectorKey", Value: selectorId }];

		// must include disabled elements for validation on server to work correctly
		let items1 = Calysto.Forms.SerializeContainer(frm);
		for (let item1 of items1)
		{
			if (item1.Element?.disabled)
			{
				appendArr.push({ Key: item1.Name, Value: item1.Value });
			}
		}

		//#if DEBUG
		if (Calysto.Core.IsDebugDefined)
		{
			//	console.log(appendArr);
		}
		//#endif

		let mode1: keyof FormMode = <any>frm.getAttribute(Constants.CalystoDomAttributes.CalystoFormMode);

		let timeout1 = parseInt(<string>frm.getAttribute("calysto-timeout")) || 90000;

		let spinner1 = Calysto.Mvc.CalystoSpinner.Start(frm, false);

		let actionUrl = <string>frm.getAttribute(Constants.CalystoDomAttributes.CalystoFormDestination);
		if (!!actionUrl)
			actionUrl = Calysto.Utility.Encoding.CalystoBase64.DecodeBase64StringToString(actionUrl);
		else
			throw new Error("Invalid action url.");

		Page.OnBeginRequest.Invoke();

		return new Calysto.Net.WebClient(actionUrl)
			.AddRequestHeader(Constants.WsjsHeaderConstants.XCalystoAjaxFormKey, Constants.WsjsHeaderConstants.XCalystoAjaxFormValue)
			.SetTimeout(timeout1)
			.UploadHtmlForm(frm, appendArr)
			.OnError((wclient, ev) =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					Calysto.Dialog.CreateError(ev + "").Show();
				}
				//#endif
			})
			.OnLoad((wclient, ev) =>
			{
				let txt = wclient.GetResponseText();

				let loc1 = wclient.xhr.getResponseHeader("location");
				if (loc1)
				{
					location.assign(loc1);
					return;
				}

				spinner1.Remove();

				if (wclient.xhr.status < 200 || wclient.xhr.status >= 300)
				{
					// Full description is send only if app.UseDeveloperExceptionPage(); is set at Startup.cs
					// else, will use error page defined in startup.cs with app.UseExceptionHandler($"/controller/action");
					// if error page not found, returns 404
					//#if DEBUG
					if (Calysto.Core.IsDebugDefined)
					{
						let title1 = wclient.xhr.status + " " + (wclient.xhr.statusText || Calysto.Net.HttpStatusCode[wclient.xhr.status] || "");
						let body1 = txt || title1;
						Calysto.Dialog.CreateError(body1, title1).Show();
					}
					//#endif
				}
				else if (wclient.xhr.getResponseHeader(Constants.WsjsHeaderConstants.XCalystoResponseContainerKey) == Constants.WsjsHeaderConstants.XCalystoResponseContainerValue)
				{
					// it is CalystoResponse object
					let state = fnCreateResponseState();
					Calysto.Net.WebService.AjaxResponseReceivedHandlerAsync(wclient, state);
				}
				else
				{
					if (receivedHandler1)
					{
						let result = new BoxValue<Function>();

						if (receivedHandler1.Contains("=>"))
						{
							let fn1 = Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(receivedHandler1);
							fn1(txt);
						}
						else if (Calysto.DataBinder.TryGetValue(window, receivedHandler1, result))
						{
							result.GetValue()(txt);
						}
						else
						{
							throw new Error("Received handler supported: " + receivedHandler1);
						}
					}

					if (targetSel1)
					{
						mode1 = mode1 || "ReplaceChildren";

						// we may have multiple target selectors
						for (let sel1 of targetSel1.split(','))
						{
							sel1 = sel1.Trim();

							// find for the sel1 selector in both source and target than replace target selector children with content
							// important: if there is no selector in received content, use complete received content and insert it into target element
							// this way we have debug feedback
							let items = Calysto.DomQuery.FromHtml(txt).Query(`${sel1}, //${sel1}`).Distinct().ChildNodes().ToArray();
							$$calysto(targetSel1)[mode1](items?.Any() ? items : txt);

							$$calysto(targetSel1).ExecuteScriptNodes();
						}
					}
				}

				Page.OnEndResponse.Invoke();

			}).Start();
	}

	function fnCreateResponseState()
	{
		return ({
			fnErrorCallback: (a) =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					Calysto.Dialog.CreateError(a).Show();
				}
				//#endif
			},
			fnResponseContainerCallback: (a) =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					console.log("fnResponseContainerCallback", a);
				}
				//#endif
			},
			fnReturnValueCallback: (a) =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					console.log("fnReturnValueCallback", a);
				}
				//#endif
			},
			fnResponseEndCallback: () =>
			{
				//#if DEBUG
				if (Calysto.Core.IsDebugDefined)
				{
					console.log("fnResponseEndCallback");
				}
				//#endif
			}
		}) as Net.WebService.StateTypeSmall<any>;
	}
}

/* this has to be invoked in your code:
	Calysto.Mvc.AjaxForm.UseAjaxFormSubmit();
*/
