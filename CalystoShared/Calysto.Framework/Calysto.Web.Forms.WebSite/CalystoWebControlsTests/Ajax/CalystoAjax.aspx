<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalystoAjax.aspx.cs" Inherits="Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Ajax.CalystoAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<% = new Calysto.Web.UI.CalystoScriptManager() { }
		.RegisterFontAwesome()
		.RegisterEngineCSS(Calysto.Web.Script.Services.Compiler.CssTheme.MetroLightBlue)
		.RegisterEngineJS()
        .RegisterWebService(this)
        .RegisterWebService(typeof(Calysto.Web.TestSite.Web.CalystoUI.Sockets.SocketSession))
		.RegisterScriptFile(CSSFilesList.CalystoWebControlsTests_Ajax_Ajax_css)
		.RegisterScriptFile(JSFilesList.CalystoWebControlsTests_Ajax_Common_js)
		.RegisterScriptFile(JSFilesList.CalystoWebControlsTests_Ajax_Sockets_js)
		.RegisterScriptFile(JSFilesList.CalystoWebControlsTests_Ajax_Ajax_js)
		.GetAllScriptsTags()
	%>
</head>
<body>
	<h3>Web sockets</h3>
	<div class="div1" style="padding: 10px; border: solid 5px silver; margin-bottom: 10px;">
		<div style="padding: 5px;">CalystoWebSocketTest test, watch results in console</div>
		<input type="button" value="SocketOpen" id="btnConnect" onclick="Sockets.SocketOpen(this)" />
		<input type="button" value="SocketClose" id="btnDisconnect" onclick="Sockets.SocketClose(this)" /><br />
		<input class="iceThemeGreen" type="text" id="socketInput" /><br />
		<input type="button" value="Send" id="btnSend1" onclick="Sockets.SendSocket(this)" />
		<input type="button" value="Send Delayed" id="btnSend2" onclick="Sockets.SendSocketDelayed(this)" />
		<input type="file" id="socketFiles" value="SocketSendFiles" onchange="Sockets.SendSocket(this)" multiple="multiple" /><br />
		<input class="iceThemeGreen" type="button" value="Invoke Server Error" id="btnInvokeServerError" onclick="Sockets.SocketErrorTest(this, 'baci gresku')" />
		<input type="button" value="HelloWorld" onclick="Sockets.SocketHelloWorld(this);" />
		<input type="button" value="Send to all" onclick="Sockets.SocketSendToAll(this);" />
		<br />
		<input type="button" value="Send-ResultAsync" onclick="Sockets.SocketSendResultAsync(this);" />
	</div>

	<h3>Ajax</h3>
	<div class="div1" style="padding: 10px; border: solid 5px silver; margin-bottom: 10px;">
		<div style="padding: 5px;">Ajax test, watch results in console</div>
		<input type="text" id="ajaxInput" />
		<input type="file" id="ajaxFiles" value="AjaxSendFiles" onchange="Ajax.AjaxSend(this)" multiple="multiple" /><br />
		<input type="button" value="Ajax Send" id="btnAjaxSend1" onclick="Ajax.AjaxSend(this)" />
		<input type="button" value="Ajax Send Delayed" id="btnAjaxSend2" onclick="Ajax.AjaxSendDelayed(this)" />
		<input type="button" value="Invoke Server Error" id="btnAjaxSend4" onclick="Ajax.InvokeAjaxError(this)" /><br />

		<input type="button" value="DownloadBlob" id="btnAjaxSend41" onclick="Ajax.DownloadBlob(this)" />
		<input type="button" value="DownloadBlobError" id="btnAjaxSend42" onclick="Ajax.DownloadBlobError(this)" /><br />
		<input type="button" value="DownloadBlobArray" id="btnAjaxSend43" onclick="Ajax.DownloadBlobArray(this)" />
		<input type="button" value="DownloadBlobArrayError" id="btnAjaxSend44" onclick="Ajax.DownloadBlobArrayError(this)" /><br />
		<input type="button" value="DownloadBinaryFrameObject" id="btnAjaxSend45" onclick="Ajax.DownloadBinaryFrameObject(this)" />
		<br />
		<input type="button" value="SendClientDateTime" id="btnAjaxSend46" onclick="Ajax.SendClientDateTime(this)" />
		<input type="button" value="Send-ResultAsync" onclick="Ajax.SendResultAsync(this);" />
	</div>

	<h3>Partial rendering</h3>
	<div class="div1" style="padding: 10px; border: solid 5px silver; margin-bottom: 10px;">
		<asp:Panel ID="Panel1" runat="server">
			<asp:TextBox ID="Text1" runat="server"></asp:TextBox><br />
			<asp:TextBox ID="Text2" runat="server"></asp:TextBox>
		</asp:Panel>
		<button onclick="Ajax.GetPartialResult(this)">Get partial result</button>
		<div>Partial result:</div>
		<pre id="partialResult1">[Partial result goes here]</pre>
	</div>

</body>
</html>
