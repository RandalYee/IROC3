<%@ Page Language="vb" AutoEventWireup="false" Inherits="BaseClasses.Web.UI.GenericPage" %>
<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %>
<%@ Import NameSpace="BaseClasses.Configuration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Default Page</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<BaseClasses:BasePageSettings id="PageSettings" runat="server" LoginRequired=""></BaseClasses:BasePageSettings>
<%
	If ((Me.Request.ServerVariables("SERVER_PORT") = 80) AndAlso _
		CStr(LCase(ApplicationSettings.Current.GetAppSetting(ApplicationSettings.ConfigurationKey.WebServer))).StartsWith("https:") _
	) Then
		'Dim strSecureURL As String = _
		'	"https://" & _
		'	Request.ServerVariables("SERVER_NAME") & _
		'	ApplicationSettings.Current.DefaultPageUrl(Me.bcSystem.ROLE_USER.Chars(0))
		'Response.Redirect(strSecureURL)
	Else
		'Response.Redirect(ApplicationSettings.Current.DefaultPageUrl(Me.bcSystem.ROLE_USER.Chars(0)))
		BaseClasses.Web.UI.BasePage.RedirectToDefaultPage(Me.Request, Me.Response)
	End If
%>
		</form>
	</body>
</HTML>
