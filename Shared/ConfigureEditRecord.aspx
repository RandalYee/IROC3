<%@ Page Language="vb" AutoEventWireup="false" Inherits="IROC2.UI.BaseApplicationPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<script runat="server" language="VB">
    Public Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim selectedTheme As String = Me.GetSelectedTheme()
        If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
    End Sub
</script>
    <title>Configure Edit Record Page</title>
</head>
<body class="pBack">
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
                            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse"
                                width="100%" id="AutoNumber1">
                                <tr>
                                    <td class="dialog_header" colspan="3">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td class="dialogHeaderEdgeL">
                                                    <img src="../Images/space.gif" alt="" /></td>
                                                <td class="dhb">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="dialog_header_text">
                                                                Configuring an Edit Record Page</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="dialogHeaderEdgeR">
                                                    <img src="../Images/space.gif" alt="" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20px;">
                                    </td>
                                    <td class="configureErrorPagesText">
                                        <br />
                                        The Edit button or icon you clicked on is not yet bound to an Edit Record page.<br />
                                        <br />
                                        To bind the Edit button or icon to an Edit Record page:<br />
                                        <br />
                                        <ol>
                                            <li>If you have not yet created an Edit Record page, use the Application Wizard to create
                                                one.<br />
                                                <br />
                                            </li>
                                            <li>Go to the Application Explorer tab, navigate in the tree to the page that contains
                                                the Edit button or icon, then click the Properties button on the tool bar.<br />
                                                <br />
                                                <ul style="list-style-type: disc">
                                                    <li>Select the name of the Edit button or icon in the tree.</li>
                                                    <li>On the Bindings tab, modify the Redirect URL to point to your Edit Record page.<br />
                                                        Example: ../MyPages/MyEditRecordPage.aspx?QueryStringParam={0}</li>
                                                    <li>Make sure the Redirect parameter is "ID".<br />
                                                        <br />
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>Save changes and rebuild the application.</li>
                                        </ol>
                                    </td>
                                    <td style="width: 20px;">
                                    </td>
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
</body>
</html>
