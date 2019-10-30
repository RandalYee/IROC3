<%@ Page Language="vb" AutoEventWireup="false" Inherits="IROC2.UI.BaseApplicationPage"%>

<script runat="server" language="VB">
    Public Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim selectedTheme As String = Me.GetSelectedTheme()
        If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
        Me.Page.MasterPageFile = "../Master Pages/Popup.master"
    End Sub
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "PopupScript", "openPopupPage('QPageSize');", True)
        End If
    End Sub
</script>



<asp:Content id="PageSection" ContentPlaceHolderID="PageContent" Runat="server">
    <table cellspacing="0" cellpadding="0" border="0" class="pWrapper">
        <tr>
            <td class="panelTL">
                <img src="../Images/space.gif" class="panelTLSpace" alt="" /></td>
            <td class="panelT">
                <img src="../Images/space.gif" class="panelTSpace" alt="" /></td>
            <td class="panelTR">
                <img src="../Images/space.gif" class="panelTRSpace" alt="" /></td>
        </tr>
        <tr>
            <td class="panelL">
                <img src="../Images/space.gif" class="panelLSpace" alt="" /></td>
            <td class="panelC">
                <table cellspacing="0" cellpadding="0" border="0" class="pContent">
                    <tr>
                        <td>
		<table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" width="100%" id="AutoNumber1">
		  <tr>
		  	<td class="dialog_header" colspan="3">
				<table cellpadding="0" cellspacing="0" border="0">
				  <tr>
				    <td class="dhel"><img src="../Images/space.gif" alt="" /></td>
				    <td class="dhb">
				        <table border="0" cellpadding="0" cellspacing="0" width="100%">
				            <tr>
								<td class="dht">Configuring an Add Record Pop-up Page</td>
				            </tr>
				        </table>
				    </td>
				    <td class="dher"><img src="../Images/space.gif" alt="" /></td>
				  </tr>
				</table>
		  	</td>
		  </tr>
		  <tr>
		  	<td style="width: 20px;"></td>
			<td class="configureErrorPagesText"><br />
The button or icon you clicked is not yet linked to an Add Record Pop-up page.
<br /><br /> 
				<ol>
			      <li>If you have not yet created an Add Record page, use the Application Wizard to create one.<br /><br /></li>
			      <li>In the Application Explorer, select the page containing the unlinked button or icon.<br /><br /></li>
			      <li>In the Page Layout Editor, select the unlinked button or icon control.<br /><br /></li>
			      <li>In the Property Sheet, open the Button Actions dialog for the button or icon control.<br /><br /></li>
			      <li>In the Button Actions dialog, modify the Redirect URL to point to your Add Record page.<br />
Example: ../MyPages/Add-Record-Pop-up.aspx. <br /><br /></li>
			    </ol>
		    </td>
		  	<td style="width: 20px;"></td>
		  </tr>
		</table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="panelR">
                <img src="../Images/space.gif" class="panelRSpace" alt="" /></td>
        </tr>
        <tr>
            <td class="panelBL">
                <img src="../Images/space.gif" class="panelBLSpace" alt="" /></td>
            <td class="panelB">
                <img src="../Images/space.gif" class="panelBSpace" alt="" /></td>
            <td class="panelBR">
                <img src="../Images/space.gif" class="panelBRSpace" alt="" /></td>
        </tr>
    </table>
</asp:Content>