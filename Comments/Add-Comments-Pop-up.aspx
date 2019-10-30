﻿<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Add_Comments_Pop_up" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Add-Comments-Pop-up.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/Popup.master" Inherits="IROC2.UI.Add_Comments_Pop_up" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %><asp:Content id="PageSection" ContentPlaceHolderID="PageContent" Runat="server">
    <a id="StartOfPageContent"></a>
    <asp:UpdateProgress runat="server" id="UpdatePanel1_UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1">
			<ProgressTemplate>
				<div class="ajaxUpdatePanel">
				</div>
				<div style=" position:absolute; padding:30px;">
					<img src="../Images/updating.gif" alt="Updating" />
				</div>
			</ProgressTemplate>
		</asp:UpdateProgress>
		<asp:UpdatePanel runat="server" id="UpdatePanel1" UpdateMode="Conditional">
			<ContentTemplate>
				<input type="hidden" id="_clientSideIsPostBack" name="clientSideIsPostBack" runat="server" />

                <table cellpadding="0" cellspacing="0" border="0"><tr><td><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CancelButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveButton"))%>

                        <IROC2:CommentsRecordControl runat="server" id="CommentsRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelHeaderL"></td><td class="dh">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="CommentsTitle" Text="&lt;%#String.Concat(GetResourceValue(&quot;Title:Add&quot;),&quot; Comments&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="CommentsRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><div class="scrollRegion"><asp:panel id="CommentsRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="fls"><asp:Literal runat="server" id="AgencyLabel" Text="Agency:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Agency" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="AgencyTextBoxMaxLengthValidator" ControlToValidate="Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Comment_DtLabel" Text="Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Comment_Dt" Columns="20" MaxLength="30" cssclass="field_input" htmlencodevalue="Default" readonly="True"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Comment_DtTextBoxMaxLengthValidator" ControlToValidate="Comment_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Comment_TopicLabel" Text="Topic:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Comment_Topic" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Comment_TopicRequiredFieldValidator" ControlToValidate="Comment_Topic" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment Topic&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator></span>
 
</td><td class="dfv"><asp:Literal runat="server" id="Comment_To_AgencyLabel" Text="To Agency:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Comment_To_Agency" Columns="10" MaxLength="10" cssclass="field_input" readonly="True"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Comment_To_AgencyRequiredFieldValidator" ControlToValidate="Comment_To_Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment To Agency&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Comment_To_AgencyTextBoxMaxLengthValidator" ControlToValidate="Comment_To_Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment To Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Created_ByLabel" Text="Created By:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Created_By" Columns="50" MaxLength="50" cssclass="field_input" readonly="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Created_ByTextBoxMaxLengthValidator" ControlToValidate="Created_By" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Created By&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="CommentLabel" Text="Comment: *  (max 255 char)">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="Comment" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="CommentRequiredFieldValidator" ControlToValidate="Comment" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="CommentTextBoxMaxLengthValidator" ControlToValidate="Comment" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr><tr><td class="fls"></td><td class="dfv"><asp:Literal runat="server" id="Request_Id" visible="False"></asp:Literal></td><td class="dfv"></td><td class="dfv"></td></tr></table></asp:panel>
</div></td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:CommentsRecordControl>

            <%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td></tr><tr><td class="QPPageButtonsContainer"><table cellpadding="0" cellspacing="0" border="0" class="pageButtonsContainer"><tr><td><table cellpadding="0" cellspacing="0" border="0"><tr><td><IROC2:ThemeButton runat="server" id="SaveButton" button-causesvalidation="True" button-commandname="UpdateData" button-text="&lt;%# GetResourceValue(&quot;Btn:Save&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Save&quot;, &quot;IROC2&quot;) %>" postback="True"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="CancelButton" button-causesvalidation="False" button-commandname="Redirect" button-text="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td></tr></table>
</td></tr></table>
</td></tr></table>
    </ContentTemplate>
</asp:UpdatePanel>

    <div id="detailPopup" class="detailRolloverPopup" onmouseout="detailRolloverPopupClose();" onmouseover="clearTimeout(gPopupTimer);"></div>
                   <div class="QDialog" id="dialog" style="display:none;">
                          <iframe id="QuickPopupIframe" style="width:100%;height:100%;border:none"></iframe>
                   </div>                  
    <asp:ValidationSummary id="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server"></asp:ValidationSummary>
</asp:Content>
                