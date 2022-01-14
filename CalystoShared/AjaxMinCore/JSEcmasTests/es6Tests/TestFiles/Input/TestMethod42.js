function fnCreateAndSendRequest(frm)
{
    var _a;
    if (!frm)
        throw new Error("Form is null.");
    let receivedHandler1 = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormHandler);
    let targetSel1 = frm.getAttribute(Calysto.Constants.CalystoDomAttributes.CalystoFormTarget);
    if (!targetSel1 && !receivedHandler1)
    {
        if (Calysto.Core.IsDebugDefined)
        {
            console.log("Form has no target and no received handler.");
        }
        return;
    }
    let selectorId = Calysto.Utility.Dom.EnsureElementId(targetSel1 || frm);
    let appendArr = [{ Key: "__RootSelectorKey", Value: selectorId }];
    let items1 = Calysto.Forms.SerializeContainer(frm);
    for (let item1 of items1)
    {
        if ((_a = item1.Element) === null || _a === void 0 ? void 0 : _a.disabled)
        {
            appendArr.push({ Key: item1.Name, Value: item1.Value });
        }
    }
    if (Calysto.Core.IsDebugDefined)
    {
    }
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
        .OnError((wclient, ev) =>
        {
            if (Calysto.Core.IsDebugDefined)
            {
                Calysto.Dialog.CreateError(ev + "").Show();
            }
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
                let title1 = wclient.xhr.status + " " + (wclient.xhr.statusText || Calysto.Net.HttpStatusCode[wclient.xhr.status] || "");
                let body1 = txt || title1;
                Calysto.Dialog.CreateError(body1, title1).Show();
            }
            else if (wclient.xhr.getResponseHeader(Calysto.Constants.WsjsHeaderConstants.XCalystoResponseContainerKey) == Calysto.Constants.WsjsHeaderConstants.XCalystoResponseContainerValue)
            {
                let state = fnCreateResponseState();
                Calysto.Net.WebService.AjaxResponseReceivedHandler(wclient, state);
            }
            else
            {
                if (receivedHandler1)
                {
                    let result = new Calysto.BoxValue();
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
                    for (let sel1 of targetSel1.split(','))
                    {
                        sel1 = sel1.Trim();
                        let items = Calysto.DomQuery.FromHtml(txt).Query(`${sel1}, //${sel1}`).Distinct().ChildNodes().ToArray();
                        $$calysto(targetSel1)[mode1]((items === null || items === void 0 ? void 0 : items.Any()) ? items : txt);
                    }
                }
            }
            Calysto.Page.OnEndResponse.Invoke();
        }).Start();
}