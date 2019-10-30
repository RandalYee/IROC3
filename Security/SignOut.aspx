<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SignOut.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.SignOut" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %><asp:Content id="Content" ContentPlaceHolderID="PageContent" runat="server">
    <a id="StartOfPageContent"></a>
          <table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="dh"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dheci" valign="middle"><asp:CollapsiblePanelExtender id="SignOutCPExtender" runat="server" TargetControlid="SignOutCollapsibleRegion" ExpandControlID="SignOutToggleIcon" CollapseControlID="SignOutToggleIcon" ImageControlID="SignOutToggleIcon" ExpandedImage="../images/icon_panelcollapse.gif" CollapsedImage="../images/icon_panelexpand.gif" SuppressPostBack="true" />
                        <asp:ImageButton id="SignOutToggleIcon" runat="server" ToolTip="<%# GetResourceValue(&quot;Btn:ExpandCollapse&quot;, &quot;IROC2&quot;) %>" causesvalidation="False" imageurl="../images/icon_panelcollapse.gif" />
            </td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><asp:Literal runat="server" id="DialogTitle" Text="&lt;%# GetResourceValue(&quot;Txt:SignOut&quot;, &quot;IROC2&quot;) %>">	</asp:Literal></td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="dBody"><asp:panel id="SignOutCollapsibleRegion" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="325"><tr><td><asp:Label runat="server" id="SignOutMessage" Text="&lt;%# GetResourceValue(&quot;Txt:SuccessfullySignOut&quot;, &quot;IROC2&quot;) %>">	</asp:Label><br /><br /></td></tr><tr><td align="center"><IROC2:ThemeButton runat="server" id="ForgetSignInButton" button-causesvalidation="False" button-commandname="ForgetSignInInformation" button-text="&lt;%# GetResourceValue(&quot;Btn:ForgetSignInButton&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Txt:ForgetSignInButton&quot;, &quot;IROC2&quot;) %>"></IROC2:ThemeButton></td></tr><tr><td><table cellpadding="0" cellspacing="0" border="0" style="padding-top:10px; padding-bottom:5px;" align="center"><tr><td><IROC2:ThemeButton runat="server" id="OKButton" button-causesvalidation="False" button-text="&lt;%# GetResourceValue(&quot;Btn:OK&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:OK&quot;, &quot;IROC2&quot;) %>"></IROC2:ThemeButton></td><td></td></tr></table>
</td></tr><tr><td><asp:Label id="CloseWindowMessage" runat="server" Text="<%# GetResourceValue(&quot;Txt:CloseWindowMessage&quot;, &quot;IROC2&quot;) %>" />&nbsp;</td></tr></table></asp:panel>
</td></tr></table><div id="detailPopup" class="detailRolloverPopup" onmouseout="detailRolloverPopupClose();" onmouseover="clearTimeout(gPopupTimer);"></div>
          <div class="QDialog" id="dialog" style="display:none;">
            <iframe id="QuickPopupIframe" style="width:100%;height:100%;border:none"></iframe>
          </div>  
          <asp:ValidationSummary id="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server"></asp:ValidationSummary>
</asp:Content>
          