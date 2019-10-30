<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Save_Request_Master" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Save-Request-Master.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Save_Request_Master" %><asp:Content id="PageSection" ContentPlaceHolderID="PageContent" Runat="server">
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
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="Send More Info Question To Agency.">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server" visible="False"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:TabContainer runat="server" id="Request_MasterRecordControlTabContainer" font-bold="True" visible="False"> 
 <asp:TabPanel runat="server" id="TabPanel" font-bold="True" requiredroles="&lt;PRoles>NOT_ANONYMOUS&lt;/PRoles>" visible="True" HeaderText="Request Info">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Req_Site_NameLabel1" Text="Site Name">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Site_Name1" enableviewstate="True"></asp:Literal> </td><td class="fls"><asp:Literal runat="server" id="IROC_IdLabel1" Text="IROC Id">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="IROC_Id"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_AddressLabel1" Text="Address">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Address1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_Completed_DtLabel" Text="Completed_Dt" visible="False">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Completed_Dt" visible="False"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_CityLabel1" Text="City">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_City1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_StateLabel1" Text="State">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_State1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_ZipLabel1" Text="Zip">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Zip1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_IslandLabel1" Text="Island">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Island1"></asp:Literal> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_EnityLabel1" Text="Entity ">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Enity2"></asp:Literal> </td><td class="fls"><asp:Literal runat="server" id="Req_Funding_SrcLabel1" Text="Funding Source">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Funding_Src2"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_DtLabel1" Text="Request Date">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Dt1"></asp:Literal> </td><td class="fls"><asp:Literal runat="server" id="Req_Target_DtLabel1" Text="Target Date">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Target_Dt1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="County_UploadLabel1" Text="County Upload">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="County_Upload1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Reg_TypeLabel1" Text="Type">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Reg_Type1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Prov_NameLabel" Text="Province Name">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Prov_Name" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Prov_NameTextBoxMaxLengthValidator" ControlToValidate="Prov_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Province Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Contact_EmailLabel" Text="Requester Email">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Contact_Email"></asp:Literal></td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_StatusLabel" Text="Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Status" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StatusTextBoxMaxLengthValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Red;font-weight:bold"><asp:Literal runat="server" id="Pending_AgencyLabel" Text="Pending Agency">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency1" Columns="10" MaxLength="10" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" htmlencodevalue="Default" readonly="True" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency1TextBoxMaxLengthValidator" ControlToValidate="Pending_Agency1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Pending_Action_DtLabel" Text="Pending Action Date">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Action_Dt1" Columns="20" MaxLength="30" cssclass="field_input" enabled="False" htmlencodevalue="Default" readonly="True" visible="True"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Dt1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Pending_Action_NeededLabel" Text="Pending Action Needed">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Action_Needed1" Columns="20" MaxLength="20" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" htmlencodevalue="Default" readonly="True" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Needed1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Needed1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Pending_Agency_ReturnLabel" Text="Pending Agency Return" visible="True">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency_Return" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency_ReturnTextBoxMaxLengthValidator" ControlToValidate="Pending_Agency_Return" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency Return&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Pending_Prev_StatusLabel" Text="Pending Previous Status">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Status" Columns="10" MaxLength="10" cssclass="field_input" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_StatusTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Pending_Prev_Action_NeededLabel" Text="Pending Previous Action_Needed">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Action_Needed" Columns="20" MaxLength="20" cssclass="field_input" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_Action_NeededTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Action_Needed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Label runat="server" id="Label" Text="ToAgency:">	</asp:Label></td><td class="dfv"><asp:TextBox runat="server" id="ToAgency">	</asp:TextBox></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Req_CommentsLabel" Text="Request Comments Temporary Email">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><asp:TextBox runat="server" id="Req_Comments" MaxLength="255" columns="120" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CommentsTextBoxMaxLengthValidator" ControlToValidate="Req_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Role_IDMaxControl" visible="False">	</asp:Literal></td><td class="dfv" style="font-weight:bold"></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:TextBox runat="server" id="ICS_CATV_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ICS_CATV_CommentsTextBoxMaxLengthValidator" ControlToValidate="ICS_CATV_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ICS CATV Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv" style="font-weight:bold"></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:TextBox runat="server" id="Cat_OTWC_Comments" MaxLength="255" columns="120" cssclass="field_input" rows="5" textmode="MultiLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_OTWC_CommentsTextBoxMaxLengthValidator" ControlToValidate="Cat_OTWC_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category OTWC Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td><td class="dfv" style="font-weight:bold"></td><td class="fls"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel4" font-bold="True" requiredroles="&lt;PRoles>1;2;4&lt;/PRoles>" visible="True" HeaderText="Requester Input">	<ContentTemplate> 
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_On_Net_DtLabel1" Text="OTW On Net DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_On_Net_Dt1" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_On_Net_Dt1CalendarExtender" TargetControlID="OTW_On_Net_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_On_Net_Dt1TextBoxMaxLengthValidator" ControlToValidate="OTW_On_Net_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW On Net DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td><td class="dfv"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
<asp:TabPanel runat="server" id="TabPanel1" font-bold="True" requiredroles="&lt;PRoles>1;2;3;4;6;8&lt;/PRoles>" visible="False" HeaderText="SOW Needed">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_NeededLabel" Text="SOW Needed">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Needed"></asp:CheckBox> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_UploadedLabel" Text="SOW Uploaded">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Uploaded"></asp:CheckBox> </td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel2" font-bold="True" requiredroles="&lt;PRoles>1;4&lt;/PRoles>" visible="False" HeaderText="CATV Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="PriorityLabel" Text="Priority">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Priority" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList></span>
</td><td class="fls"><asp:Literal runat="server" id="Cat_Cost_FreeLabel" Text="Category Cost Free">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="Cat_Cost_Free"></asp:CheckBox> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_Franchise_Order_NumberLabel" Text="Category Franchise Order Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Cat_Franchise_Order_Number2" Columns="25" MaxLength="25" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_Franchise_Order_Number2TextBoxMaxLengthValidator" ControlToValidate="Cat_Franchise_Order_Number2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category Franchise Order Number 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="dfv"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel3" font-bold="True" requiredroles="&lt;PRoles>1;2;4;5&lt;/PRoles>" visible="False" HeaderText="OTWC Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="OTW_Premise_Fiber_Work_ReqdLabel" Text="OTW Premise Fiber Work Reqd">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="OTW_Premise_Fiber_Work_Reqd"></asp:CheckBox></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_QuoteLabel" Text="OTW Quote">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Quote" Columns="14" MaxLength="14" cssclass="field_input" dataformat="$###,###,###.##"></asp:TextBox></td>
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
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_DtLabel1" Text="OTW Scheduled Deploy DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Scheduled_Deploy_Dt1" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Scheduled_Deploy_Dt1CalendarExtender" TargetControlID="OTW_Scheduled_Deploy_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Scheduled_Deploy_Dt1TextBoxMaxLengthValidator" ControlToValidate="OTW_Scheduled_Deploy_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Scheduled Deploy DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
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
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Deployment_Start_DtLabel" Text="OTW Deployment Start DT">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Deployment_Start_Dt1" Columns="20" MaxLength="30" cssclass="field_input"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Deployment_Start_Dt1CalendarExtender" TargetControlID="OTW_Deployment_Start_Dt1" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Deployment_Start_Dt1TextBoxMaxLengthValidator" ControlToValidate="OTW_Deployment_Start_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Deployment Start DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td><td class="fls"></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Pymt_Check_NoLabel" Text="Request PYMT Check Number">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Pymt_Check_No" Columns="10" MaxLength="10" cssclass="field_input"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_Check_NoTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Check_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT Check Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_AmtLabel" Text="Request PO Amount">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
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
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_On_Net_DtLabel" Text="On-INET Date">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_On_Net_Dt" Columns="20" MaxLength="30" cssclass="field_input" htmlencodevalue="Default"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_On_Net_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_On_Net_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW On Net DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
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
</td></tr><tr><td></td></tr><tr><td class="recordPanelButtonsAlignment"><table cellpadding="0" cellspacing="0" border="0" class="pageButtonsContainer"><tr><td><table cellpadding="0" cellspacing="0" border="0"><tr><td><IROC2:ThemeButton runat="server" id="Save_More_Info" button-causesvalidation="True" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="More Info Send" button-tooltip="Send Request f" postback="True" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Request+For+More+Info++About+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td></tr></table>
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
                