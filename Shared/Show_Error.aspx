<%@ Page Language="vb" AutoEventWireup="true" EnableEventValidation="false" Codefile="Show_Error.aspx.vb" Inherits="IROC2.UI.Show_Error" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<script runat="server" language="VB">
    Public Overloads Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim selectedTheme As String = Me.GetSelectedTheme()
        If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
    End Sub
</script>
    <title>Show Error Page</title>
</head>
<body class="pBack">
    <table border="0" cellpadding="0" cellspacing="0" class="pWrapper">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" border="0" class="dv">
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
                                                                            Error</td>
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
                                                    <asp:Literal ID="ShowErrorLine1" runat="server" Text='<%# GetResourceValue("Txt:ShowErrorLine1") %>' /><br />
                                                    <br />
                                                    <%-- Unable to access data.  Please contact your system administrator or customer support.--%>
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
            </td>
        </tr>
    </table>
</body>
</html>
