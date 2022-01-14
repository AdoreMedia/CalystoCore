<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalystoPreloaders.aspx.cs" Inherits="Calysto.Web.Forms.WebSite.CalystoWebControlsTests.CalystoPreloaders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<%--<calysto:CalystoScriptManager runat="server" Engine="True" WriteElmah="true" Theme="MetroBlue"></calysto:CalystoScriptManager>--%>
	<%--<script src="CalystoPreloaders.js?t=<%=DateTime.Now.Ticks %>"></script>--%>
		<% = new Calysto.Web.UI.CalystoScriptManager() { }
		.RegisterEngineJS()
		.RegisterScriptFile(JSFilesList.CalystoWebControlsTests_Preloaders_CalystoPreloaders_js)
		.GetAllScriptsTags()
	%>
	<style type="text/css">
		.spinnerItem {margin: 0 5px 5px 0; float:left;border:solid 1px green;text-align:center;}
		.spinnerLabel{padding:2px; background-color:black;color:white;font-family: Arial;}
		.svgContainer{height:70px;width:70px;padding:10px;font-size:14px;overflow:hidden;}
		#divContainer1 .spinnerItem{background:#e9efb7;}
		#divContainer2 .spinnerItem{background:#7373d6;}
		#divContainer3 .spinnerItem{background:#504f4f;}

	</style>
</head>
<body>

	<div id="divContainer1">
	</div>
	<div style="clear:both"></div>
	<div id="divContainer2">
	</div>
	<div style="clear:both"></div>
	<div id="divContainer3">
	</div>
	<div style="clear:both"></div>
</body>
</html>
