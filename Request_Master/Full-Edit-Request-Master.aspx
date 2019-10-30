<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Full_Edit_Request_Master" %>

<%@ Register Tagprefix="IROC2" TagName="PaginationMedium" Src="../Shared/PaginationMedium.ascx" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Full-Edit-Request-Master.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Full_Edit_Request_Master" %>
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
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="&lt;%#String.Concat(GetResourceValue(&quot;Full Edit&quot;),&quot; Request Master&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:TabContainer runat="server" id="Request_MasterRecordControlTabContainer"> 
 <asp:TabPanel runat="server" id="TabPanel" requiredroles="&lt;PRoles>NOT_ANONYMOUS&lt;/PRoles>" HeaderText="Request Info">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Request_IdLabel" Text="Request">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Request_Id"></asp:Literal></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Site_NameLabel1" Text="Site Name">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Site_Name1" Columns="50" MaxLength="50" cssclass="field_input" enableviewstate="True" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Site_Name1RequiredFieldValidator" ControlToValidate="Req_Site_Name1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Site Name&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Site_Name1TextBoxMaxLengthValidator" ControlToValidate="Req_Site_Name1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Site Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="fls"><asp:Literal runat="server" id="IROC_IdLabel1" Text="IROC Id">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="IROC_Id" Columns="10" MaxLength="10" cssclass="field_input" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="IROC_IdRequiredFieldValidator" ControlToValidate="IROC_Id" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;IROC&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="IROC_IdTextBoxMaxLengthValidator" ControlToValidate="IROC_Id" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;IROC&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_AddressLabel1" Text="Address">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Address1" Columns="50" MaxLength="50" cssclass="field_input" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Address1RequiredFieldValidator" ControlToValidate="Req_Address1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Address&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Address1TextBoxMaxLengthValidator" ControlToValidate="Req_Address1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Address&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_Completed_DtLabel" Text="Completed_Dt" visible="True">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Completed_Dt" Columns="20" MaxLength="30" cssclass="field_input" visible="True"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Completed_DtCalendarExtender" TargetControlID="Req_Completed_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Completed_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Completed_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Completed DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_CityLabel1" Text="City">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_City1" Columns="20" MaxLength="20" cssclass="field_input" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_City1RequiredFieldValidator" ControlToValidate="Req_City1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request City&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_City1TextBoxMaxLengthValidator" ControlToValidate="Req_City1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request City&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_StateLabel1" Text="State">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_State1" Columns="2" MaxLength="2" cssclass="field_input" enabled="True" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_State1RequiredFieldValidator" ControlToValidate="Req_State1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request State&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_State1TextBoxMaxLengthValidator" ControlToValidate="Req_State1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request State&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_ZipLabel1" Text="Zip">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Zip1" Columns="10" MaxLength="10" cssclass="field_input" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Zip1RequiredFieldValidator" ControlToValidate="Req_Zip1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request ZIP&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Zip1TextBoxMaxLengthValidator" ControlToValidate="Req_Zip1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request ZIP&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_IslandLabel1" Text="Island">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Req_Island1" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)" readonly="True"></asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Island1RequiredFieldValidator" ControlToValidate="Req_Island1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Island&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator></span>
 </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_EnityLabel1" Text="Agency">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Enity2" Columns="20" MaxLength="20" cssclass="field_input" datareadersortby="Enity_Codes Asc" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Enity2RequiredFieldValidator" ControlToValidate="Req_Enity2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Enity 2&quot;) %>" enabled="True"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Enity2TextBoxMaxLengthValidator" ControlToValidate="Req_Enity2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Enity 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Reg_TypeLabel1" Text="Entity">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Reg_Type1" Columns="10" MaxLength="10" cssclass="field_input" readonly="False"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Reg_Type1RequiredFieldValidator" ControlToValidate="Reg_Type1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;REG Type&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Reg_Type1TextBoxMaxLengthValidator" ControlToValidate="Reg_Type1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;REG Type&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_DtLabel1" Text="Request Date">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Dt1" Columns="20" MaxLength="30" cssclass="field_input" enabled="True" readonly="False"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Dt1CalendarExtender" TargetControlID="Req_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Dt1RequiredFieldValidator" ControlToValidate="Req_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request DT&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Dt1TextBoxMaxLengthValidator" ControlToValidate="Req_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td><td class="fls"><asp:Literal runat="server" id="Req_Target_DtLabel1" Text="Target Date">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Target_Dt1" Columns="20" MaxLength="30" cssclass="field_input" readonly="False"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Req_Target_Dt1CalendarExtender" TargetControlID="Req_Target_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Target_Dt1TextBoxMaxLengthValidator" ControlToValidate="Req_Target_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Target DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Prov_NameLabel" Text="Provider_Name">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Prov_Name" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Prov_NameRequiredFieldValidator" ControlToValidate="Prov_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Province Name&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_Funding_SrcLabel1" Text="Funding Source">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Funding_Src2" Columns="30" MaxLength="30" cssclass="field_input" readonly="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Funding_Src2TextBoxMaxLengthValidator" ControlToValidate="Req_Funding_Src2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Funding Source 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Contact_EmailLabel" Text="Requester Email">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Contact_Email" Columns="50" MaxLength="75" cssclass="field_input" requiredroles="&lt;PRoles>1;2;4&lt;/PRoles>"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_Contact_EmailRequiredFieldValidator" ControlToValidate="Req_Contact_Email" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Contact Email 2&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Contact_EmailTextBoxMaxLengthValidator" ControlToValidate="Req_Contact_Email" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Contact Email 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_StatusLabel" Text="Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Status" MaxLength="10" columns="20" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Req_StatusRequiredFieldValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StatusTextBoxMaxLengthValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Red;font-weight:bold"><asp:Literal runat="server" id="Pending_AgencyLabel" Text="Pending Entity">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency1" Columns="10" MaxLength="10" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Pending_Agency1RequiredFieldValidator" ControlToValidate="Pending_Agency1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency1TextBoxMaxLengthValidator" ControlToValidate="Pending_Agency1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Pending_Action_DtLabel" Text="Pending Action Date">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Action_Dt1" Columns="20" MaxLength="30" cssclass="field_input" enabled="True" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Pending_Action_Dt1CalendarExtender" TargetControlID="Pending_Action_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Dt1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Pending_Action_NeededLabel" Text="Pending Action Needed">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Action_Needed1" Columns="20" MaxLength="20" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<asp:RequiredFieldValidator runat="server" id="Pending_Action_Needed1RequiredFieldValidator" ControlToValidate="Pending_Action_Needed1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueIsRequired&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>" enabled="True" text="*"></asp:RequiredFieldValidator>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Needed1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Needed1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Pending_Agency_ReturnLabel" Text="Pending Entity Return" visible="True">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency_Return" Columns="10" MaxLength="10" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency_ReturnTextBoxMaxLengthValidator" ControlToValidate="Pending_Agency_Return" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency Return&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Pending_Prev_StatusLabel" Text="Pending Previous Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Status" Columns="10" MaxLength="10" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_StatusTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Pending_Prev_Action_NeededLabel" Text="Pending Previous Action_Needed">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Action_Needed" Columns="20" MaxLength="20" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_Action_NeededTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Action_Needed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Req_CommentsLabel" Text="Req_Comments - Email TO:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><asp:TextBox runat="server" id="Req_Comments" MaxLength="255" columns="120" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CommentsTextBoxMaxLengthValidator" ControlToValidate="Req_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="ICS_CATV_CommentsLabel" Text="ICS_CATV_Comments - Email  CC:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><asp:TextBox runat="server" id="ICS_CATV_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ICS_CATV_CommentsTextBoxMaxLengthValidator" ControlToValidate="ICS_CATV_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ICS CATV Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Cat_OTWC_CommentsLabel" Text="Cat_OTWC_Comments - Email BCC: ">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><asp:TextBox runat="server" id="Cat_OTWC_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_OTWC_CommentsTextBoxMaxLengthValidator" ControlToValidate="Cat_OTWC_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category OTWC Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="fls"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel4" requiredroles="&lt;PRoles>1;2;4&lt;/PRoles>" HeaderText="Requester Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="OTW_QuoteLabel1" Text="OTW Quote">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Quote1" Columns="14" MaxLength="14" cssclass="field_input"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Quote1TextBoxMaxLengthValidator" ControlToValidate="OTW_Quote1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Quote&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Quote_ApprovedLabel" Text="Request Quote Approved">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Quote_Approved" Columns="20" MaxLength="30" cssclass="field_input" enabled="False"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Quote_ApprovedTextBoxMaxLengthValidator" ControlToValidate="Req_Quote_Approved" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Quote Approved&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_NoLabel" Text="Request PO Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_PO_No" Columns="15" MaxLength="15" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_NoTextBoxMaxLengthValidator" ControlToValidate="Req_PO_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"><asp:Literal runat="server" id="Req_PO_DtLabel" Text="Request PO DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Pymt_AmtLabel" Text="Request PYMT Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="dfv"><asp:Literal runat="server" id="Req_Pymt_DtLabel" Text="Request PYMT DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Pymt_Check_NoLabel" Text="Request PYMT Check Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Pymt_Check_No" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_Check_NoTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Check_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT Check Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_AmtLabel" Text="Request PO Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="dfv"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
<asp:TabPanel runat="server" id="TabPanel1" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" HeaderText="SOW Needed">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_NeededLabel" Text="ICS SOW Needed">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Needed"></asp:CheckBox> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_UploadedLabel" Text="ICS SOW Uploaded">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Uploaded"></asp:CheckBox> </td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel2" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" HeaderText="CATV Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Cat_Cost_FreeLabel" Text="INET Benefit">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="Cat_Cost_Free"></asp:CheckBox></td><td class="fls"><asp:Literal runat="server" id="PriorityLabel" Text="Priority" visible="False">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Priority" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)" visible="False"></asp:DropDownList></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_Franchise_Order_NumberLabel" Text="Category Franchise Order Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Cat_Franchise_Order_Number2" Columns="25" MaxLength="25" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_Franchise_Order_Number2TextBoxMaxLengthValidator" ControlToValidate="Cat_Franchise_Order_Number2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category Franchise Order Number 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel3" requiredroles="&lt;PRoles>1;2;4;5&lt;/PRoles>" HeaderText="OTWC Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="OTW_More_Info_FlagLabel" Text="OTW More Information Flag">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_More_Info_Flag"></asp:CheckBox></td><td class="fls"><asp:Literal runat="server" id="OTW_Premise_Fiber_Work_ReqdLabel" Text="OTW Premise Fiber Work Reqd" visible="False">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_Premise_Fiber_Work_Reqd" visible="False"></asp:CheckBox></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_QuoteLabel" Text="OTW Quote">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="fls"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_DtLabel" Text="OTW Scheduled Deploy DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Permit_StatusLabel" Text="OTW Permit Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Permit_Status" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Permit_StatusTextBoxMaxLengthValidator" ControlToValidate="OTW_Permit_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Permit Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Deployment_Start_DtLabel" Text="OTW Deployment Start DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="fls"><asp:Literal runat="server" id="OTW_Projected_Deploy_DtLabel" Text="OTW Projected Deploy DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_On_NetLabel" Text="OTW On Net">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_On_Net"></asp:CheckBox></td><td class="fls"><asp:Literal runat="server" id="OTW_Island_completedLabel" Text="OTW Island Completed">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Island_completed" Columns="30" MaxLength="30" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Island_completedTextBoxMaxLengthValidator" ControlToValidate="OTW_Island_completed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Island Completed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Construction_StatusLabel" Text="OTW Construction Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Construction_Status" Columns="20" MaxLength="20" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Construction_StatusTextBoxMaxLengthValidator" ControlToValidate="OTW_Construction_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Construction Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="OTW_Completed_DtLabel" Text="OTW Completed DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_NoLabel" Text="OTW Invoice Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Invoice_No" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_NoTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_DtLabel" Text="OTW Invoice DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_AmtLabel" Text="OTW Invoice Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="fls"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
  
</asp:TabContainer></td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:Request_MasterRecordControl>

            <%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td></tr><tr><td><asp:TabContainer runat="server" id="Request_MasterTabContainer">
 <asp:TabPanel runat="server" id="CommentsTabPanel" HeaderText="Comments">	<ContentTemplate>
  <IROC2:CommentsTableControl runat="server" id="CommentsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="CommentsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsAddButton" causesvalidation="False" commandname="AddRecord" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" imageurl="../Images/ButtonBarDelete.gif" onmouseout="this.src='../Images/ButtonBarDelete.gif'" onmouseover="this.src='../Images/ButtonBarDeleteOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Delete&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="CommentsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thcnb" colspan="2"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thcwb" style="padding:0px;vertical-align:middle;"><asp:CheckBox runat="server" id="CommentsToggleAll" onclick="toggleAllCheckboxes(this);">	</asp:CheckBox></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_DtLabel" tooltip="Sort by Comment_Dt" Text="Comment Date" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_TopicLabel" tooltip="Sort by Comment_Topic" Text="Topic" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Comment_To_AgencyLabel" tooltip="Sort by Comment_To_Agency" Text="To Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CommentLabel" tooltip="Sort by Comment" Text="Comment" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="CommentsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:CommentsTableControlRow runat="server" id="CommentsTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="CommentsRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="CommentsRowDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticwb">
                      <asp:CheckBox runat="server" id="CommentsRecordRowSelection" onclick="moveToThisTableRow(this);">	</asp:CheckBox>
                    </td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Agency" Columns="10" MaxLength="10" cssclass="field_input" readonly="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="AgencyTextBoxMaxLengthValidator" ControlToValidate="Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="ttc"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Comment_Dt" Columns="20" MaxLength="30" cssclass="field_input" readonly="True"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="Comment_DtCalendarExtender" TargetControlID="Comment_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Comment_DtTextBoxMaxLengthValidator" ControlToValidate="Comment_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td><td class="ttc"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Comment_Topic" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList></span>
 </td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Comment_To_Agency" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Comment_To_AgencyTextBoxMaxLengthValidator" ControlToValidate="Comment_To_Agency" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment To Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><asp:TextBox runat="server" id="Comment" MaxLength="255" columns="60" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="CommentTextBoxMaxLengthValidator" ControlToValidate="Comment" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Comment&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="ttc"></td></tr></IROC2:CommentsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:CommentsTableControl>

 </ContentTemplate></asp:TabPanel>
 <asp:TabPanel runat="server" id="ContactsTabPanel" HeaderText="Contacts">	<ContentTemplate>
  <IROC2:ContactsTableControl runat="server" id="ContactsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="ContactsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="ContactsAddButton" causesvalidation="False" commandname="AddRecord" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="ContactsDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" imageurl="../Images/ButtonBarDelete.gif" onmouseout="this.src='../Images/ButtonBarDelete.gif'" onmouseover="this.src='../Images/ButtonBarDeleteOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Delete&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="ContactsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thcnb" colspan="2"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thcwb" style="padding:0px;vertical-align:middle;"><asp:CheckBox runat="server" id="ContactsToggleAll" onclick="toggleAllCheckboxes(this);">	</asp:CheckBox></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel2" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="TypeLabel" tooltip="Sort by Type" Text="Type" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="TitleLabel" tooltip="Sort by Title" Text="Title" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="NameLabel" tooltip="Sort by Name" Text="Name" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="EmailLabel" tooltip="Sort by Email" Text="Email" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Work_PhoneLabel" tooltip="Sort by Work Phone" Text="Work Phone" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="MobileLabel" tooltip="Sort by Mobile" Text="Mobile" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AddressLabel" tooltip="Sort by Address" Text="Address" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CityLabel" tooltip="Sort by City" Text="City" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="ZipLabel" tooltip="Sort by Zip" Text="ZIP" CausesValidation="False">	</asp:LinkButton></th></tr><asp:Repeater runat="server" id="ContactsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:ContactsTableControlRow runat="server" id="ContactsTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="ContactsRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="ContactsRowDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticwb">
                      <asp:CheckBox runat="server" id="ContactsRecordRowSelection" onclick="moveToThisTableRow(this);">	</asp:CheckBox>
                    </td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Agency1" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Agency1TextBoxMaxLengthValidator" ControlToValidate="Agency1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Type0" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Type0TextBoxMaxLengthValidator" ControlToValidate="Type0" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Type&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Title" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="TitleTextBoxMaxLengthValidator" ControlToValidate="Title" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Title&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Name" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="NameTextBoxMaxLengthValidator" ControlToValidate="Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Email" Columns="50" MaxLength="255" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="EmailTextBoxMaxLengthValidator" ControlToValidate="Email" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Email&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Work_Phone" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Work_PhoneTextBoxMaxLengthValidator" ControlToValidate="Work_Phone" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Work Phone&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Mobile" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="MobileTextBoxMaxLengthValidator" ControlToValidate="Mobile" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Mobile&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Address" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="AddressTextBoxMaxLengthValidator" ControlToValidate="Address" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Address&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="City" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="CityTextBoxMaxLengthValidator" ControlToValidate="City" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;City&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Zip" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ZipTextBoxMaxLengthValidator" ControlToValidate="Zip" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ZIP&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr></IROC2:ContactsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:ContactsTableControl>

 </ContentTemplate></asp:TabPanel>
 <asp:TabPanel runat="server" id="UploadsTabPanel" HeaderText="Uploads">	<ContentTemplate>
  <IROC2:UploadsTableControl runat="server" id="UploadsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="UploadsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="UploadsAddButton" causesvalidation="False" commandname="AddRecord" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="UploadsDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" imageurl="../Images/ButtonBarDelete.gif" onmouseout="this.src='../Images/ButtonBarDelete.gif'" onmouseover="this.src='../Images/ButtonBarDeleteOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Delete&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="UploadsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thcnb"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thc" scope="col"><asp:Literal runat="server" id="UPLOAD_DOCLabel" Text="Upload Document">	</asp:Literal></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DtLabel" tooltip="Sort by UPLOAD_Dt" Text="UPLOAD DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DescLabel" tooltip="Sort by UPLOAD_Desc" Text="UPLOAD Description" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_QuoteLabel" tooltip="Sort by UPLOAD_Quote" Text="Quote Amount" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_Created_ByLabel" tooltip="Sort by UPLOAD_Created_By" Text="Created_By:" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_CommentsLabel" tooltip="Sort by UPLOAD_Comments" Text="UPLOAD Comments" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"></th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="UploadsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:UploadsTableControlRow runat="server" id="UploadsTableControlRow">
<tr><td class="ticnb" scope="row">
                          
                        <asp:ImageButton runat="server" id="UploadsRowDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="ttc"><asp:LinkButton runat="server" id="UPLOAD_DOCImage" CommandName="Redirect" class="imageDropshadow" filenamefield="UPLOAD_File"></asp:LinkButton> 
<asp:FileUpload runat="server" id="UPLOAD_DOC" cssclass="field_input" size="60"></asp:FileUpload></td><td class="ttc"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="UPLOAD_Dt" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="UPLOAD_DtCalendarExtender" TargetControlID="UPLOAD_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_DtTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 </td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="UPLOAD_Desc" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_DescTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_Desc" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD Description&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="ttc"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="UPLOAD_Quote" Columns="14" MaxLength="14" cssclass="field_input" dataformat="$###,###,###.##"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_QuoteTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_Quote" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD Quote&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="UPLOAD_Created_By" Columns="50" MaxLength="50" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_Created_ByTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_Created_By" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD Created By&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="ttc"><asp:TextBox runat="server" id="UPLOAD_Comments" MaxLength="255" columns="60" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_CommentsTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator> </td><td class="ttc"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="UPLOAD_File" MaxLength="255" columns="0" cssclass="field_input" rows="0" textmode="SingleLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="UPLOAD_FileTextBoxMaxLengthValidator" ControlToValidate="UPLOAD_File" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;UPLOAD File&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 </td><td class="ttc"><br /> 
</td></tr></IROC2:UploadsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:UploadsTableControl>

 </ContentTemplate></asp:TabPanel>
</asp:TabContainer></td></tr><tr><td class="recordPanelButtonsAlignment"><table cellpadding="0" cellspacing="0" border="0" class="pageButtonsContainer"><tr><td><table cellpadding="0" cellspacing="0" border="0"><tr><td><IROC2:ThemeButton runat="server" id="SaveButton" button-causesvalidation="True" button-commandname="UpdateData" button-text="&lt;%# GetResourceValue(&quot;Btn:Save&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Save&quot;, &quot;IROC2&quot;) %>" postback="True"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="CancelButton" button-causesvalidation="False" button-commandname="Redirect" button-text="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td></tr></table>
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
                