﻿<%@ Page Language="vb" AutoEventWireup="false" Codefile="ExportFieldValue.aspx.vb" Inherits="IROC2.ExportFieldValue" %>
<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %>

<%--
Example URL:
http://localhost/IROC2/ExportFieldValue.aspx?Table=authors&Field=au_lname&Record=<key+au_id="172-32-1176"+/>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Export Field Value</title>
<meta name='GENERATOR' content='Microsoft Visual Studio.NET 7.0' />
<meta name='CODE_LANGUAGE' content='Visual Basic 7.0' />
<meta name='vs_defaultClientScript' content='JavaScript' />
<meta name='vs_targetSchema' content='http://schemas.microsoft.com/intellisense/ie5' />
</head>
<body>
<form id='Form1' method='post' runat='server'>
	<BaseClasses:BasePageSettings id="PageSettings" runat="server"></BaseClasses:BasePageSettings>

</form>
</body>
</html>