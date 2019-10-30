<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Add-Request-Master.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Add_Request_Master" %>
<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Add_Request_Master" %>

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

                        <IROC2:Request_MasterRecordControl runat="server" id="Request_MasterRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelHeaderL"></td><td class="dh">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="&lt;%#String.Concat(GetResourceValue(&quot;Title:Add&quot;),&quot; Request Master&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:panel id="Request_MasterRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="fls"><asp:Literal runat="server" id="Req_Site_NameLabel" Text="Site Name: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Site_Name" Columns="50" MaxLength="50" cssclass="field_input"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Site_NameRequiredFieldValidator" ControlToValidate="Req_Site_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Site Name&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Site_NameTextBoxMaxLengthValidator" ControlToValidate="Req_Site_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Site Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:TextBox runat="server" id="TxtUser_Id" visible="False">	</asp:TextBox></td><td class="dfv"><BaseClasses:QuickSelector runat="server" id="Request_Id" visible="False"></BaseClasses:QuickSelector></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_AddressLabel" Text="Address: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Address" Columns="50" MaxLength="50" cssclass="field_input"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_AddressRequiredFieldValidator" ControlToValidate="Req_Address" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Address&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_AddressTextBoxMaxLengthValidator" ControlToValidate="Req_Address" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Address&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_CityLabel" Text="City: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_City" Columns="20" MaxLength="20" cssclass="field_input"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_CityRequiredFieldValidator" ControlToValidate="Req_City" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request City&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CityTextBoxMaxLengthValidator" ControlToValidate="Req_City" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request City&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_StateLabel" Text="State:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_State" Columns="2" MaxLength="2" cssclass="field_input" enabled="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StateTextBoxMaxLengthValidator" ControlToValidate="Req_State" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request State&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_ZipLabel" Text="Zip: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Zip" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_ZipRequiredFieldValidator" ControlToValidate="Req_Zip" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request ZIP&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_ZipTextBoxMaxLengthValidator" ControlToValidate="Req_Zip" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request ZIP&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_IslandLabel" Text="Island: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Req_Island" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_IslandRequiredFieldValidator" ControlToValidate="Req_Island" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Island&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Reg_TypeLabel" Text="Entity">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Reg_Type" Columns="10" MaxLength="10" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Reg_TypeTextBoxMaxLengthValidator" ControlToValidate="Reg_Type" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;REG Type&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LReg_Type1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_Enity2Label" Text="Agency">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Enity2" Columns="20" MaxLength="20" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Enity2TextBoxMaxLengthValidator" ControlToValidate="Req_Enity2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Enity 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="Req_Enity21"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Prov_NameLabel" Text="Provider Name: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Prov_Name" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Prov_NameRequiredFieldValidator" ControlToValidate="Prov_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Province Name&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_Funding_SrcLabel" Text="Funding Source: (max 10 char)">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Funding_Src2" Columns="30" MaxLength="30" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Funding_Src2TextBoxMaxLengthValidator" ControlToValidate="Req_Funding_Src2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Funding Source 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_DtLabel" Text="Request Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Dt" Columns="20" MaxLength="30" cssclass="field_input" enabled="False" readonly="True" visible="False"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
  
<asp:Literal runat="server" id="LReq_Dt"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_Target_DtLabel" Text="Target Date: *">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Target_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Target_DtCalendarExtender" TargetControlID="Req_Target_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Target_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Target_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Target DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Contact_EmailLabel" Text="Contact Email:  *">	</asp:Literal> 
<asp:Literal runat="server" id="Req_Contact_Email2Label" Text="Contact Email: ">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Contact_Email" Columns="50" MaxLength="75" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1;34&lt;/PRoles>" tooltip="Requester's Email. Multiple Email Addresses Allowed with Comma Seperator."></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Contact_EmailRequiredFieldValidator" ControlToValidate="Req_Contact_Email" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Contact Email 2&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Contact_EmailTextBoxMaxLengthValidator" ControlToValidate="Req_Contact_Email" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Contact Email 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="Req_Contact_Email1"></asp:Literal></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Status" Columns="10" MaxLength="10" cssclass="field_input" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StatusTextBoxMaxLengthValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency" Columns="10" MaxLength="10" cssclass="field_input" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_AgencyTextBoxMaxLengthValidator" ControlToValidate="Pending_Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Action_Needed" Columns="20" MaxLength="20" cssclass="field_input" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_NeededTextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Needed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Action_Dt" Columns="20" MaxLength="30" cssclass="field_input" visible="False"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Pending_Action_DtCalendarExtender" TargetControlID="Pending_Action_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_DtTextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls" style="font-weight:bold"><asp:TextBox runat="server" id="Req_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CommentsTextBoxMaxLengthValidator" ControlToValidate="Req_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv"></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="dfv" colspan="3"><asp:Label runat="server" id="label1" Text="All Fields with an &quot;*&quot; are Required fields." font-bold="True" font-italic="True">	</asp:Label> 
</td><td class="dfv"></td></tr><tr><td class="dfv"><asp:TextBox runat="server" id="Cat_OTWC_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_OTWC_CommentsTextBoxMaxLengthValidator" ControlToValidate="Cat_OTWC_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category OTWC Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv"><asp:TextBox runat="server" id="ICS_CATV_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ICS_CATV_CommentsTextBoxMaxLengthValidator" ControlToValidate="ICS_CATV_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ICS CATV Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv"><asp:TextBox runat="server" id="OTW_More_Info_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_More_Info_CommentsTextBoxMaxLengthValidator" ControlToValidate="OTW_More_Info_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW More Information Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv"></td></tr><tr><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Needed" checked="True" visible="False"></asp:CheckBox></td><td class="dfv"></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Priority" Columns="7" MaxLength="7" cssclass="field_input" visible="False"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="PriorityTextBoxMaxLengthValidator" ControlToValidate="Priority" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Priority&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td><td class="dfv"></td></tr></table></asp:panel>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:Request_MasterRecordControl>

            <%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td></tr><tr><td><asp:TabContainer runat="server" id="Request_MasterTabContainer">
 
 
 
</asp:TabContainer></td></tr><tr><td class="recordPanelButtonsAlignment"><table cellpadding="0" cellspacing="0" border="0" class="pageButtonsContainer"><tr><td><table cellpadding="0" cellspacing="0" border="0"><tr><td><IROC2:ThemeButton runat="server" id="SaveButton" button-causesvalidation="True" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Continue" button-tooltip="Done with Info, Continue to Contact." postback="True"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="CancelButton" button-causesvalidation="False" button-commandname="Redirect" button-text="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td></tr></table>
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
                