
var Calysto;
(function (Calysto) {
    var Mvc;
    (function (Mvc) {
        var AjaxForm;
        (function (AjaxForm) {
            let _isEnabled = false;
            let _isDisabled = false;
            function IsAjaxFormSubmitEnabled() {
                return _isEnabled && !_isDisabled;
            }
            AjaxForm.IsAjaxFormSubmitEnabled = IsAjaxFormSubmitEnabled;
            function UseAjaxFormSubmit(enable = true) {
                if (enable === false) {
                    _isDisabled = true;
                }
                else if (!_isEnabled) {
                    _isEnabled = true;
                    Calysto.Page.OnEndResponse(() => fnInitFormsInterceptor());
                }
            }
            AjaxForm.UseAjaxFormSubmit = UseAjaxFormSubmit;
            /**
             * Submit form without validation.
             * @param formSelector
             */
            function SubmitForm(formSelector, delay = 0) {
                setTimeout(() => {
                    let form = $$calysto(formSelector).First();
                    fnCreateAndSendRequest(form);
                }, delay);
            }
            AjaxForm.SubmitForm = SubmitForm;
            function fnInitFormsInterceptor() {
                // init forms
                $$calysto("form")
                    .Where(f => !f.$$CalystoInterceptor)
                    .ForEach(frm => {
                    frm.$$CalystoInterceptor = true;
                    let f1 = frm;
                    f1.submitBase = f1.submit;
                    // this code handles when form.submit() is invoked
                    f1.submit = function (ev) {
                        let _safethis14 = this;
                        setTimeout(() => fnHandleSubmitRequest(_safethis14), 1);
                        return false;
                    };
                }).On("submit", (sender, ev) => {
                    // this code handles when button type=submit inside form is clicked
                    setTimeout(() => fnHandleSubmitRequest(sender), 1);
                    return false;
                });
            }
            function fnHandleSubmitRequest(sender) {
                var _a;
                if (!IsAjaxFormSubmitEnabled())
                    return false;
                // if form not valid, return
                if ((_a = Calysto.DataAnnotations.FindValidationService(sender)) === null || _a === void 0 ? void 0 : _a.Validate().Render().Interactive(true).HasErrors())
                    return false;
                fnCreateAndSendRequest(sender);
                return false;
            }
            function fnCreateAndSendRequest(frm) {
                var _a;
                if (!frm)
                    throw new Error("Form is null.");
                // hander: function(content){} or lambda (content)=> {} or just function name in global scope
                let receivedHandler1 = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormHandler);
                let targetSel1 = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormTarget);
                if (!targetSel1 && !receivedHandler1) {
                    //#if DEBUG
                    if (Calysto.Core.IsDebugDefined) {
                        console.log("Form has no target and no received handler.");
                    }
                    //#endif
                    return;
                }
                // if we have receivedHandler1, targetSel1 is null, so use frm element
                let selectorId = Calysto.Utility.Dom.EnsureElementId(targetSel1 || frm);
                // we need to know container root selector to create validation errors for container only
                let appendArr = [{ Key: "__RootSelectorKey", Value: selectorId }];
                // must include disabled elements for validation on server to work correctly
                let items1 = Calysto.Forms.SerializeContainer(frm);
                for (let item1 of items1) {
                    if ((_a = item1.Element) === null || _a === void 0 ? void 0 : _a.disabled) {
                        appendArr.push({ Key: item1.Name, Value: item1.Value });
                    }
                }
                //#if DEBUG
                if (Calysto.Core.IsDebugDefined) {
                    //	console.log(appendArr);
                }
                //#endif
                let mode1 = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormMode);
                let timeout1 = parseInt(frm.getAttribute("calysto-timeout")) || 90000;
                let spinner1 = Calysto.Mvc.UseCalystoSpinner(frm, false);
                let actionUrl = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormDestination);
                if (!!actionUrl)
                    actionUrl = Calysto.Utility.Encoding.CalystoBase64.DecodeBase64StringToString(actionUrl);
                else
                    throw new Error("Invalid action url.");
                Calysto.Page.OnBeginRequest.Invoke();
                return new Calysto.Net.WebClient(actionUrl)
                    .AddRequestHeader(Calysto.Constants.WsjsHeaderConstants.XCalystoAjaxFormKey, Calysto.Constants.WsjsHeaderConstants.XCalystoAjaxFormValue)
                    .SetTimeout(timeout1)
                    .UploadHtmlForm(frm, appendArr)
                    .OnError((wclient, ev) => {
                    //#if DEBUG
                    if (Calysto.Core.IsDebugDefined) {
                        Calysto.Dialog.CreateError(ev + "").Show();
                    }
                    //#endif
                })
                    .OnLoad((wclient, ev) => {
                    let txt = wclient.GetResponseText();
                    let loc1 = wclient.xhr.getResponseHeader("location");
                    if (loc1) {
                        location.assign(loc1);
                        return;
                    }
                    spinner1.Remove();
                    if (wclient.xhr.status < 200 || wclient.xhr.status >= 300) {
                        // Full description is send only if app.UseDeveloperExceptionPage(); is set at Startup.cs
                        // else, will use error page defined in startup.cs with app.UseExceptionHandler($"/controller/action");
                        // if error page not found, returns 404
                        let title1 = wclient.xhr.status + " " + (wclient.xhr.statusText || Calysto.Net.HttpStatusCode[wclient.xhr.status] || "");
                        let body1 = txt || title1;
                        Calysto.Dialog.CreateError(body1, title1).Show();
                    }
                    else if (wclient.xhr.getResponseHeader(Calysto.Constants.WsjsHeaderConstants.XCalystoResponseContainerKey) == Calysto.Constants.WsjsHeaderConstants.XCalystoResponseContainerValue) {
                        // it is CalystoResponse object
                        let state = fnCreateResponseState();
                        Calysto.Net.WebService.AjaxResponseReceivedHandler(wclient, state);
                    }
                    else {
                        if (receivedHandler1) {
                            let result = new Calysto.BoxValue();
                            if (receivedHandler1.Contains("=>")) {
                                let fn1 = Calysto.Utility.Expressions.CompileLambdaNoReturnCheck(receivedHandler1);
                                fn1(txt);
                            }
                            else if (Calysto.DataBinder.TryGetValue(window, receivedHandler1, result)) {
                                result.GetValue()(txt);
                            }
                            else {
                                throw new Error("Received handler supported: " + receivedHandler1);
                            }
                        }
                        if (targetSel1) {
                            mode1 = mode1 || "ReplaceChildren";
                            // we may have multiple target selectors
                            for (let sel1 of targetSel1.split(',')) {
                                sel1 = sel1.Trim();
                                // find for the sel1 selector in both source and target than replace target selector children with content
                                // important: if there is no selector in received content, use complete received content and insert it into target element
                                // this way we have debug feedback
                                let items = Calysto.DomQuery.FromHtml(txt).Query(`${sel1}, //${sel1}`).Distinct().ChildNodes().ToArray();
                                $$calysto(targetSel1)[mode1]((items === null || items === void 0 ? void 0 : items.Any()) ? items : txt);
                            }
                        }
                    }
                    Calysto.Page.OnEndResponse.Invoke();
                }).Start();
            }
            function fnCreateResponseState() {
                return ({
                    fnErrorCallback: (a) => {
                        //#if DEBUG
                        if (Calysto.Core.IsDebugDefined) {
                            Calysto.Dialog.CreateError(a).Show();
                        }
                        //#endif
                    },
                    fnResponseContainerCallback: (a) => {
                        //#if DEBUG
                        if (Calysto.Core.IsDebugDefined) {
                            console.log("fnResponseContainerCallback", a);
                        }
                        //#endif
                    },
                    fnReturnValueCallback: (a) => {
                        //#if DEBUG
                        if (Calysto.Core.IsDebugDefined) {
                            console.log("fnReturnValueCallback", a);
                        }
                        //#endif
                    },
                    fnResponseEndCallback: () => {
                        //#if DEBUG
                        if (Calysto.Core.IsDebugDefined) {
                            console.log("fnResponseEndCallback");
                        }
                        //#endif
                    }
                });
            }
        })(AjaxForm = Mvc.AjaxForm || (Mvc.AjaxForm = {}));
    })(Mvc = Calysto.Mvc || (Calysto.Mvc = {}));
})(Calysto || (Calysto = {}));
/* this has to be invoked in your code:
    Calysto.Mvc.AjaxForm.UseAjaxFormSubmit();
*/