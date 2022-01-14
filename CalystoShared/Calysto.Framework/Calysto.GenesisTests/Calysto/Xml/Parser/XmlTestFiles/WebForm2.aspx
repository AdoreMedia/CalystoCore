<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FileUploadWeb.WebForm2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

	<meta id="m1" name="description" content="this is description" />
		
</head>
<body>

<?xml version="1.0" encoding="utf-8"?> 

    <form id="form1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

	<img src="myimg.gif" alt="alt text for image" height="134px" />

	<img id='openedTag1' alt='image alt' > <%--opened tag on purpose--%>

	<!--html comment 1-->
	<!--
		this is html comment
	-->

	<%--server comment--%>

<%--
	server comment too
--%>

	<script runat="server">
	
		string a = "fdsf";
		
	</script>


	<%
		
		//this is c sharp code block in html
		int ba = 10;
		int c = ++ba;
	 
	  %>



<div>
	   <?php
 if ( isset( $_FILES['fupload'] ) ) {

     print "name: ".     $_FILES['fupload']['name']       ."<br />";
     print "size: ".     $_FILES['fupload']['size'] ." bytes<br />";
     print "temp name: ".$_FILES['fupload']['tmp_name']   ."<br />";
     print "type: ".     $_FILES['fupload']['type']       ."<br />";
     print "error: ".    $_FILES['fupload']['error']      ."<br />";

     if ( $_FILES['fupload']['type'] == "image/gif" ) {

         $source = $_FILES['fupload']['tmp_name'];
         $target = "upload/".$_FILES['fupload']['name'];
         move_uploaded_file( $source, $target );// or die ("Couldn't copy");
         $size = getImageSize( $target );

         $imgstr = "<p><img width=\"$size[0]\" height=\"$size[1]\" ";
         $imgstr .= "src=\"$target\" alt=\"uploaded image\" /></p>";

         print $imgstr;
     }
 }
 ?>

</div>

 <span> this is new nod <div> one more child</div></span>

    </form>
</body>
</html>
