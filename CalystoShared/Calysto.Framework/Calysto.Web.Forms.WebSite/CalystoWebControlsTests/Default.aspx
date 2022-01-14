<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calysto.Web.Forms.WebSite.CalystoWebControlsTests.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style type="text/css">
		a {
			display: block;
		}
	</style>
	<% = new Calysto.Web.UI.CalystoScriptManager() { }
		.RegisterEngineJS()
		.GetAllScriptsTags()
	%>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<div style="background: whitesmoke; padding: 10px">Calysto Web Controls Tests TOC</div>
			<% this.MenuItems.ForEach(item =>
				{ %>
			<a href="<%=item.Href %>"><%=item.Name %></a>
			<%}); %>
		</div>
	</form>
</body>
</html>
