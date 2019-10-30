<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Add-Request-Master-Pop-up.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/Popup.master" Inherits="IROC2.UI.Add_Request_Master_Pop_up" %>
<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Add_Request_Master_Pop_up" %>

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
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><div class="scrollRegion"><asp:panel id="Request_MasterRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="fls"><asp:Literal runat="server" id="Req_Site_NameLabel" Text="Request Site Name">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Site_Name" Columns="50" MaxLength="50" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Site_NameTextBoxMaxLengthValidator" ControlToValidate="Req_Site_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Site Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_AddressLabel" Text="Request Address">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Address" Columns="50" MaxLength="50" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_AddressTextBoxMaxLengthValidator" ControlToValidate="Req_Address" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Address&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_Cost_FreeLabel" Text="Category Cost Free">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="Cat_Cost_Free"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="Req_CityLabel" Text="Request City">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_City" Columns="20" MaxLength="20" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CityTextBoxMaxLengthValidator" ControlToValidate="Req_City" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request City&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="County_UploadLabel" Text="County Upload">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="County_Upload"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="Req_StateLabel" Text="Request State">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_State" Columns="2" MaxLength="2" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StateTextBoxMaxLengthValidator" ControlToValidate="Req_State" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request State&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_NeededLabel" Text="ICS SOW Needed">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Needed"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="Req_ZipLabel" Text="Request ZIP">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Zip" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_ZipTextBoxMaxLengthValidator" ControlToValidate="Req_Zip" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request ZIP&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_UploadedLabel" Text="ICS SOW Uploaded">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Uploaded"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="OTW_Completed_DtLabel" Text="OTW Completed DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Completed_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Completed_DtCalendarExtender" TargetControlID="OTW_Completed_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Completed_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Completed_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Completed DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_More_Info_FlagLabel" Text="OTW More Information Flag">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_More_Info_Flag"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="OTW_Deployment_Start_DtLabel" Text="OTW Deployment Start DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Deployment_Start_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Deployment_Start_DtCalendarExtender" TargetControlID="OTW_Deployment_Start_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Deployment_Start_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Deployment_Start_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Deployment Start DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_On_NetLabel" Text="OTW On Net">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_On_Net"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_DtLabel" Text="OTW Invoice DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Invoice_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Invoice_DtCalendarExtender" TargetControlID="OTW_Invoice_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Premise_Fiber_Work_ReqdLabel" Text="OTW Premise Fiber Work Reqd">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_Premise_Fiber_Work_Reqd"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="OTW_Projected_Deploy_DtLabel" Text="OTW Projected Deploy DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Projected_Deploy_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Projected_Deploy_DtCalendarExtender" TargetControlID="OTW_Projected_Deploy_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Projected_Deploy_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Projected_Deploy_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Projected Deploy DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Invoice_PaidLabel" Text="Request Invoice Paid">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="Req_Invoice_Paid"></asp:CheckBox> </td><td class="fls"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_DtLabel" Text="OTW Scheduled Deploy DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Scheduled_Deploy_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Scheduled_Deploy_DtCalendarExtender" TargetControlID="OTW_Scheduled_Deploy_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Scheduled_Deploy_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Scheduled_Deploy_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Scheduled Deploy DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_Franchise_Order_NumberLabel" Text="Category Franchise Order Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Cat_Franchise_Order_Number" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_Franchise_Order_NumberTextBoxMaxLengthValidator" ControlToValidate="Cat_Franchise_Order_Number" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category Franchise Order Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Pending_Action_DtLabel" Text="Pending Action DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Action_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Pending_Action_DtCalendarExtender" TargetControlID="Pending_Action_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_DtTextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="IROC_IdLabel" Text="IROC">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="IROC_Id" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="IROC_IdTextBoxMaxLengthValidator" ControlToValidate="IROC_Id" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;IROC&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Completed_DtLabel" Text="Request Completed DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Completed_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Completed_DtCalendarExtender" TargetControlID="Req_Completed_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Completed_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Completed_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Completed DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Construction_StatusLabel" Text="OTW Construction Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Construction_Status" Columns="20" MaxLength="20" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Construction_StatusTextBoxMaxLengthValidator" ControlToValidate="OTW_Construction_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Construction Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_DtLabel" Text="Request DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_DtCalendarExtender" TargetControlID="Req_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_NoLabel" Text="OTW Invoice Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Invoice_No" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_NoTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_PO_DtLabel" Text="Request PO DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_PO_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_PO_DtCalendarExtender" TargetControlID="Req_PO_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_DtTextBoxMaxLengthValidator" ControlToValidate="Req_PO_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Island_completedLabel" Text="OTW Island Completed">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Island_completed" Columns="30" MaxLength="30" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Island_completedTextBoxMaxLengthValidator" ControlToValidate="OTW_Island_completed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Island Completed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Pymt_DtLabel" Text="Request PYMT DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Pymt_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Pymt_DtCalendarExtender" TargetControlID="Req_Pymt_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Permit_StatusLabel" Text="OTW Permit Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Permit_Status" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Permit_StatusTextBoxMaxLengthValidator" ControlToValidate="OTW_Permit_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Permit Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Quote_ApprovedLabel" Text="Request Quote Approved">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Quote_Approved" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Quote_ApprovedCalendarExtender" TargetControlID="Req_Quote_Approved" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Quote_ApprovedTextBoxMaxLengthValidator" ControlToValidate="Req_Quote_Approved" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Quote Approved&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Pending_Action_NeededLabel" Text="Pending Action Needed">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Action_Needed" Columns="20" MaxLength="20" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_NeededTextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Needed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Target_DtLabel" Text="Request Target DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Pending_AgencyLabel" Text="Pending Agency">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_AgencyTextBoxMaxLengthValidator" ControlToValidate="Pending_Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_AmtLabel" Text="OTW Invoice Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Invoice_Amt" Columns="20" MaxLength="31" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_AmtTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Reg_TypeLabel" Text="REG Type">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Reg_Type" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Reg_TypeTextBoxMaxLengthValidator" ControlToValidate="Reg_Type" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;REG Type&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_PO_AmtLabel" Text="Request PO Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_PO_Amt" Columns="20" MaxLength="31" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_AmtTextBoxMaxLengthValidator" ControlToValidate="Req_PO_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_EnityLabel" Text="Request Enity">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Enity" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_EnityTextBoxMaxLengthValidator" ControlToValidate="Req_Enity" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Enity&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Pymt_AmtLabel" Text="Request PYMT Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Pymt_Amt" Columns="20" MaxLength="31" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_AmtTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Funding_SrcLabel" Text="Request Funding Source">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Funding_Src" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Funding_SrcTextBoxMaxLengthValidator" ControlToValidate="Req_Funding_Src" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Funding Source&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="OTW_QuoteLabel" Text="OTW Quote">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Quote" Columns="14" MaxLength="14" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_QuoteTextBoxMaxLengthValidator" ControlToValidate="OTW_Quote" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Quote&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_IslandLabel" Text="Request Island">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Island" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_IslandTextBoxMaxLengthValidator" ControlToValidate="Req_Island" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Island&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Pending_Interval_Days_1stLabel" Text="Pending Interval Days 1 ST">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Interval_Days_1st" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Interval_Days_1stTextBoxMaxLengthValidator" ControlToValidate="Pending_Interval_Days_1st" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Interval Days 1 ST&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_NoLabel" Text="Request PO Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_PO_No" Columns="15" MaxLength="15" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_NoTextBoxMaxLengthValidator" ControlToValidate="Req_PO_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Pending_Interval_Days_2ndLabel" Text="Pending Interval Days 2 ND">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Interval_Days_2nd" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Interval_Days_2ndTextBoxMaxLengthValidator" ControlToValidate="Pending_Interval_Days_2nd" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Interval Days 2 ND&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Pymt_Check_NoLabel" Text="Request PYMT Check Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Pymt_Check_No" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_Check_NoTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Check_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT Check Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Pending_Interval_Days_Auto_CancelLabel" Text="Pending Interval Days Automat~ancel">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Interval_Days_Auto_Cancel" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Interval_Days_Auto_CancelTextBoxMaxLengthValidator" ControlToValidate="Pending_Interval_Days_Auto_Cancel" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Interval Days Automat~ancel&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_StatusLabel" Text="Request Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Status" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StatusTextBoxMaxLengthValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="Pending_Interval_Days_CancelLabel" Text="Pending Interval Days Cancel">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Interval_Days_Cancel" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Interval_Days_CancelTextBoxMaxLengthValidator" ControlToValidate="Pending_Interval_Days_Cancel" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Interval Days Cancel&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Pending_Nterval_Days_MaxLabel" Text="Pending Nterval Days Maximum">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Nterval_Days_Max" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Nterval_Days_MaxTextBoxMaxLengthValidator" ControlToValidate="Pending_Nterval_Days_Max" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Nterval Days Maximum&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td><td class="fls"><asp:Literal runat="server" id="PriorityLabel" Text="Priority">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Priority" Columns="7" MaxLength="7" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="PriorityTextBoxMaxLengthValidator" ControlToValidate="Priority" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Priority&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_OTWC_CommentsLabel" Text="Category OTWC Comments">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="Cat_OTWC_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_OTWC_CommentsTextBoxMaxLengthValidator" ControlToValidate="Cat_OTWC_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category OTWC Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_CATV_CommentsLabel" Text="ICS CATV Comments">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="ICS_CATV_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ICS_CATV_CommentsTextBoxMaxLengthValidator" ControlToValidate="ICS_CATV_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ICS CATV Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_More_Info_CommentsLabel" Text="OTW More Information Comments">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="OTW_More_Info_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_More_Info_CommentsTextBoxMaxLengthValidator" ControlToValidate="OTW_More_Info_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW More Information Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_CommentsLabel" Text="Request Comments">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="Req_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CommentsTextBoxMaxLengthValidator" ControlToValidate="Req_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Quote_RespnseLabel" Text="Request Quote Respnse">	</asp:Literal></td><td class="dfv" colspan="3"><asp:TextBox runat="server" id="Req_Quote_Respnse" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Quote_RespnseTextBoxMaxLengthValidator" ControlToValidate="Req_Quote_Respnse" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Quote Respnse&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td></tr></table></asp:panel>
</div></td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:Request_MasterRecordControl>

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
                