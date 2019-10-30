<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Edit_Request_Master" %>

<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Register Tagprefix="IROC2" TagName="PaginationMedium" Src="../Shared/PaginationMedium.ascx" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Edit-Request-Master.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Edit_Request_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="&lt;%#String.Concat(GetResourceValue(&quot;Title:Edit&quot;),&quot; Request Master&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:TabContainer runat="server" id="Request_MasterRecordControlTabContainer" font-bold="True"> 
 <asp:TabPanel runat="server" id="TabPanel" font-bold="True" HeaderText="Request Info">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Req_Site_NameLabel1" Text="Site Name:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Site_Name1" enableviewstate="True"></asp:Literal> </td><td class="fls"><asp:Literal runat="server" id="IROC_IdLabel1" Text="IROC Id:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="IROC_Id1"></asp:Literal> 
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_AddressLabel1" Text="Address:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Address1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_Completed_DtLabel" Text="Completed_Date:" visible="True">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Completed_Dt" Columns="20" MaxLength="30" cssclass="field_input" dataformat="d" enabled="False" requiredroles="&lt;PRoles>1;23&lt;/PRoles>" visible="False"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Completed_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Completed_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Completed DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_CityLabel1" Text="City:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_City1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_StateLabel1" Text="State:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_State1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_ZipLabel1" Text="Zip Code:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Zip1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_IslandLabel1" Text="Island:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Island1"></asp:Literal> </td></tr><tr><td class="fls"><asp:Literal runat="server" id="Reg_TypeLabel1" Text="Entity:">	</asp:Literal> 
<asp:Literal runat="server" id="Reg_TypeLabel" Text="Entity:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Reg_Type1" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="True" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Reg_Type1TextBoxMaxLengthValidator" ControlToValidate="Reg_Type1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;REG Type&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LReg_Type"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Req_EnityLabel1" Text="Agency:">	</asp:Literal><asp:Literal runat="server" id="Req_EnityLabel" Text="Agency:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Enity2" Columns="20" MaxLength="20" cssclass="field_input" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Enity2TextBoxMaxLengthValidator" ControlToValidate="Req_Enity2" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Enity 2&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LReq_Enity21"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_DtLabel1" Text="Request Date:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Dt1"></asp:Literal> </td><td class="fls"><asp:Literal runat="server" id="Req_Target_DtLabel1" Text="Target Date:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Target_Dt1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Prov_NameLabel" Text="Provider Name:">	</asp:Literal><asp:Literal runat="server" id="Prov_NameLabel1" Text="Provider Name:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Prov_Name" Columns="10" MaxLength="10" cssclass="field_input" readonly="True" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Prov_NameTextBoxMaxLengthValidator" ControlToValidate="Prov_Name" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Province Name&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LProv_Name1"></asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Funding_SrcLabel1" Text="Funding Source:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Funding_Src2"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Contact_EmailLabel" Text="Requester Email:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Contact_Email"></asp:Literal></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_StatusLabel" Text="Status:">	</asp:Literal><asp:Literal runat="server" id="Req_StatusLabel1" Text="Status:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Status" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_StatusTextBoxMaxLengthValidator" ControlToValidate="Req_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LReq_Status1"></asp:Literal></td><td class="fls"></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Request_Id" Columns="14" MaxLength="14" cssclass="field_input" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Request_IdTextBoxMaxLengthValidator" ControlToValidate="Request_Id" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls" style="color:Red;font-weight:bold"><asp:Literal runat="server" id="Pending_AgencyLabel" Text="Pending Entity:">	</asp:Literal><asp:Literal runat="server" id="Pending_AgencyLabel1" Text="Pending Entity:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency1" Columns="10" MaxLength="10" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency1TextBoxMaxLengthValidator" ControlToValidate="Pending_Agency1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LPending_Agency"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Pending_Action_DtLabel1" Text="Pending Action Date:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="LPending_Action_Dt"></asp:Literal> 
</td></tr><tr><td class="fls" style="font-weight:bold;color:Red"><asp:Literal runat="server" id="Pending_Action_NeededLabel" Text="Pending Action Needed:">	</asp:Literal><asp:Literal runat="server" id="Pending_Action_NeededLabel1" Text="Pending Action Needed:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Action_Needed1" Columns="20" MaxLength="20" backcolor="GreenYellow" bordercolor="Red" cssclass="field_input" enabled="True" htmlencodevalue="Default" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Needed1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Needed1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="Pending_Action_Needed"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="Pending_Action_DtLabel" Text="Pending Action Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Pending_Action_Dt1" Columns="20" MaxLength="30" cssclass="field_input" enabled="False" htmlencodevalue="Default" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Action_Dt1TextBoxMaxLengthValidator" ControlToValidate="Pending_Action_Dt1" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Action DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Pending_Agency_ReturnLabel" Text="Pending Entity Return:" visible="True">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Agency_Return" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Agency_ReturnTextBoxMaxLengthValidator" ControlToValidate="Pending_Agency_Return" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Agency Return&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"><asp:Literal runat="server" id="Pending_Prev_StatusLabel" Text="Pending Previous Status:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Status" Columns="10" MaxLength="10" cssclass="field_input" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_StatusTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Status" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Status&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Pending_Prev_Action_NeededLabel" Text="Pending Previous Action_Needed:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Pending_Prev_Action_Needed" Columns="20" MaxLength="20" cssclass="field_input" htmlencodevalue="Default" readonly="False" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Pending_Prev_Action_NeededTextBoxMaxLengthValidator" ControlToValidate="Pending_Prev_Action_Needed" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Pending Previous Action Needed&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="IROC_Id" Columns="10" MaxLength="10" cssclass="field_input" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1&lt;/PRoles>" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="IROC_IdTextBoxMaxLengthValidator" ControlToValidate="IROC_Id" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;IROC&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Req_CommentsLabel" Text="Req_Comments - Send Email TO:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_Comments" MaxLength="255" columns="0" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="1" textmode="SingleLine"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_CommentsTextBoxMaxLengthValidator" ControlToValidate="Req_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Role_IDMaxControl" visible="False">	</asp:Literal></td><td class="dfv" style="font-weight:bold"></td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="ICS_CATV_CommentsLabel" Text="ICS_CATV_Comments - Send Email CC:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="ICS_CATV_Comments" MaxLength="255" columns="120" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="1" textmode="SingleLine" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="ICS_CATV_CommentsTextBoxMaxLengthValidator" ControlToValidate="ICS_CATV_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;ICS CATV Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Cat_OTWC_CommentsLabel" Text="Cat_OTWC_Comments - Send Email BCC:">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Cat_OTWC_Comments" MaxLength="255" columns="120" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="1" textmode="SingleLine" visible="True"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Cat_OTWC_CommentsTextBoxMaxLengthValidator" ControlToValidate="Cat_OTWC_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Category OTWC Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="OTW_More_Info_CommentsLabel" Text="Comments" visible="False">	</asp:Literal></td><td class="dfv" style="font-weight:bold"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_More_Info_Comments" MaxLength="255" columns="120" cssclass="field_input" requiredroles="&lt;PRoles>1&lt;/PRoles>" rows="1" textmode="SingleLine" visible="False"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_More_Info_CommentsTextBoxMaxLengthValidator" ControlToValidate="OTW_More_Info_Comments" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW More Information Comments&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
</td><td class="fls"></td><td class="dfv"></td></tr><tr><td class="fls" style="color:Black"><asp:Literal runat="server" id="Request_IdLabel" Text="Request">	</asp:Literal></td><td class="dfv" style="font-weight:bold"></td><td class="fls"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel4" font-bold="True" HeaderText="Requester Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Req_Quote_ApprovedLabel1" Text="Quote Approved Date:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="LReq_Quote_Approved1"></asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_Quote_ApprovedLabel" Text="Quote Approved Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Quote_Approved" Columns="20" MaxLength="30" cssclass="field_input" enabled="True" htmlencodevalue="Default" requiredroles="&lt;PRoles>1&lt;/PRoles>"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Quote_ApprovedTextBoxMaxLengthValidator" ControlToValidate="Req_Quote_Approved" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request Quote Approved&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_NoLabel" Text="PO Number:  (max 15 char)">	</asp:Literal><asp:Literal runat="server" id="Req_PO_NoLabel1" Text="PO Number:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="Req_PO_No" Columns="15" MaxLength="15" cssclass="field_input" requiredroles="&lt;PRoles>1;2;22;23;25;26;27;28;29;30;31&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_NoTextBoxMaxLengthValidator" ControlToValidate="Req_PO_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LReq_PO_No2"></asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="Req_PO_DtLabel" Text="PO Date:  ">	</asp:Literal><asp:Literal runat="server" id="Req_PO_DtLabel1" Text="PO Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_PO_Dt" Columns="20" MaxLength="30" cssclass="field_input" requiredroles="&lt;PRoles>1;2;22;23;25;26;27;28;29;30;31&lt;/PRoles>"></asp:TextBox></td>
<td style="padding-right: 5px">
<Selectors:CalendarExtendarClass runat="server" ID="Req_PO_DtCalendarExtender" TargetControlID="Req_PO_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_DtTextBoxMaxLengthValidator" ControlToValidate="Req_PO_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LReq_PO_Dt1"></asp:Literal></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_PO_AmtLabel" Text="PO Amount: ">	</asp:Literal><asp:Literal runat="server" id="Req_PO_AmtLabel1" Text="PO Amount:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_PO_Amt" Columns="20" MaxLength="31" cssclass="field_input" requiredroles="&lt;PRoles>1;2;22;23;25;26;27;28;29;30;31&lt;/PRoles>"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_PO_AmtTextBoxMaxLengthValidator" ControlToValidate="Req_PO_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PO Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_PO_Amt1"></asp:Literal></span>
</td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_On_Net_DtLabel" Text="On-INET Date: ">	</asp:Literal><asp:Literal runat="server" id="OTW_On_Net_DtLabel1" Text="On-INET Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_On_Net_Dt" Columns="20" MaxLength="30" cssclass="field_input" requiredroles="&lt;PRoles>1;2;22;23;25;26;27;28;29;30;31&lt;/PRoles>"></asp:TextBox></td>
<td style="padding-right: 5px">
<Selectors:CalendarExtendarClass runat="server" ID="OTW_On_Net_DtCalendarExtender" TargetControlID="OTW_On_Net_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_On_Net_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_On_Net_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW On Net DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
<asp:Literal runat="server" id="LOTW_On_Net_Dt1"></asp:Literal></td><td class="fls"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
<asp:TabPanel runat="server" id="TabPanel1" font-bold="True" HeaderText="SOW Needed">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_NeededLabel" Text="SOW Needed:">	</asp:Literal><asp:Literal runat="server" id="ICS_SOW_NeededLabel1" Text="SOW Needed:">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Needed" enabled="True"></asp:CheckBox>  
<asp:CheckBox runat="server" id="LICS_SOW_Needed1" enabled="False"></asp:CheckBox></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="ICS_SOW_UploadedLabel1" Text="SOW Uploaded:">	</asp:Literal></td><td class="dfv"><asp:Literal runat="server" id="LICS_SOW_Uploaded1"></asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="ICS_SOW_Uploaded" enabled="True" visible="False"></asp:CheckBox></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel2" font-bold="True" HeaderText="CATV Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="Cat_Cost_FreeLabel" Text="INET Benefit:">	</asp:Literal> 
<asp:Literal runat="server" id="Cat_Cost_FreeLabel1" Text="INET Benefit:">	</asp:Literal></td><td class="dfv"><asp:CheckBox runat="server" id="Cat_Cost_Free1" enabled="False"></asp:CheckBox> 
<asp:CheckBox runat="server" id="Cat_Cost_Free" enabled="True"></asp:CheckBox></td><td class="fls"><asp:Literal runat="server" id="PriorityLabel" Text="Priority: *" visible="False">	</asp:Literal> 
<asp:Literal runat="server" id="PriorityLabel1" Text="Priority:" visible="False">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Priority" cssclass="field_input" enabled="True" onkeypress="dropDownListTypeAhead(this,false)" visible="False"></asp:DropDownList></span>
 
<span style="white-space:nowrap;">
<asp:Literal runat="server" id="LPriority1" visible="False"></asp:Literal></span>
</td></tr><tr><td class="fls"><asp:Literal runat="server" id="Cat_Franchise_Order_NumberLabel" Text="Franchise Order Number: *">	</asp:Literal><asp:Literal runat="server" id="Cat_Franchise_Order_NumberLabel1" Text="Franchise Order Number:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="Cat_Franchise_Order_Number2" cssclass="field_input" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList></span>
 
<asp:Literal runat="server" id="LCat_Franchise_Order_Number21"></asp:Literal></td><td class="dfv"></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
 <asp:TabPanel runat="server" id="TabPanel3" font-bold="True" HeaderText="Provider Input">	<ContentTemplate> 
  <table><tr><td class="fls"><asp:Literal runat="server" id="OTW_QuoteLabel" Text="Quote Amount: *">	</asp:Literal><asp:Literal runat="server" id="OTW_QuoteLabel1" Text="Quote Amount:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Quote" Columns="14" MaxLength="14" cssclass="field_input" enabled="True" htmlencodevalue="Default" readonly="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>" tooltip="Quote Amount is Entered VIA  UPLOADS's  Quote Amount."></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_QuoteTextBoxMaxLengthValidator" ControlToValidate="OTW_Quote" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Quote&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<span style="white-space:nowrap;">
<asp:Literal runat="server" id="LOTW_Quote1"></asp:Literal></span>
</td><td class="fls"><asp:Label runat="server" id="Label_Quote_Instr" Text="Note: Quote Amount is Updated via Upload Amount.  " font-bold="True" font-italic="True" font-size="Small" forecolor="MediumBlue">	</asp:Label></td><td class="dfv" style="color:Red;font-weight:bold"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Permit_StatusLabel" Text="Permit_Status:  (max 10 char)">	</asp:Literal> 
<asp:Literal runat="server" id="OTW_Permit_StatusLabel1" Text="Permit_Status:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="OTW_Permit_Status" cssclass="field_input" enabled="True" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList></span>
 
<asp:Literal runat="server" id="LOTW_Permit_Status1"></asp:Literal></td><td class="dfv" colspan="3"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_DtLabel" Text="Target Start Date: ">	</asp:Literal><asp:Literal runat="server" id="OTW_Scheduled_Deploy_DtLabel1" Text="Target Start Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Scheduled_Deploy_Dt" Columns="20" MaxLength="30" cssclass="field_input" dataformat="d" enabled="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Scheduled_Deploy_DtCalendarExtender" TargetControlID="OTW_Scheduled_Deploy_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Scheduled_Deploy_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Scheduled_Deploy_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Scheduled Deploy DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LOTW_Scheduled_Deploy_Dt1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="OTW_Projected_Deploy_DtLabel" Text="Target Completion Date: ">	</asp:Literal><asp:Literal runat="server" id="OTW_Projected_Deploy_DtLabel1" Text="Target Completion Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Projected_Deploy_Dt" Columns="20" MaxLength="30" cssclass="field_input" dataformat="d" enabled="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Projected_Deploy_DtCalendarExtender" TargetControlID="OTW_Projected_Deploy_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Projected_Deploy_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Projected_Deploy_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Projected Deploy DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LOTW_Projected_Deploy_Dt1"></asp:Literal></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Deployment_Start_DtLabel" Text="Actual Start Date: ">	</asp:Literal><asp:Literal runat="server" id="OTW_Deployment_Start_DtLabel1" Text="Actual Start Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Deployment_Start_Dt" Columns="20" MaxLength="30" cssclass="field_input" dataformat="d" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Deployment_Start_DtCalendarExtender" TargetControlID="OTW_Deployment_Start_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Deployment_Start_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Deployment_Start_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Deployment Start DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LOTW_Deployment_Start_Dt1"></asp:Literal></td><td class="fls"></td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Construction_StatusLabel" Text="Construction_Status: (max 20 char)">	</asp:Literal><asp:Literal runat="server" id="OTW_Construction_StatusLabel1" Text="Construction_Status:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:DropDownList runat="server" id="OTW_Construction_Status" cssclass="field_input" enabled="True" onkeypress="dropDownListTypeAhead(this,false)"></asp:DropDownList></span>
 
<asp:Literal runat="server" id="LOTW_Construction_Status1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="OTW_Completed_DtLabel" Text="Completed Date:">	</asp:Literal><asp:Literal runat="server" id="OTW_Completed_DtLabel1" Text="Completed Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Completed_Dt" Columns="20" MaxLength="30" cssclass="field_input" dataformat="d" enabled="True" enabletheming="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Completed_DtCalendarExtender" TargetControlID="OTW_Completed_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Completed_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Completed_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Completed DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LOTW_Completed_Dt1"></asp:Literal></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_NoLabel" Text="Invoice_No:  (max 10 char)">	</asp:Literal><asp:Literal runat="server" id="OTW_Invoice_NoLabel1" Text="Invoice_No:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<asp:TextBox runat="server" id="OTW_Invoice_No" Columns="10" MaxLength="10" cssclass="field_input" enabled="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_NoTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_No" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice Number&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></span>
 
<asp:Literal runat="server" id="LOTW_Invoice_No1"></asp:Literal></td><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_DtLabel" Text="Invoice Date: ">	</asp:Literal><asp:Literal runat="server" id="OTW_Invoice_DtLabel1" Text="Invoice Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Invoice_Dt" Columns="20" MaxLength="30" cssclass="field_input" enabled="True" enableviewstate="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td style="padding-right: 5px">
<Selectors:CalendarExtendarClass runat="server" ID="OTW_Invoice_DtCalendarExtender" TargetControlID="OTW_Invoice_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_DtTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="OTW_Invoice_Dt1"></asp:Literal></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="OTW_Invoice_AmtLabel" Text="Invoice_Amount:">	</asp:Literal><asp:Literal runat="server" id="OTW_Invoice_AmtLabel1" Text="Invoice_Amount:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="OTW_Invoice_Amt" Columns="20" MaxLength="31" cssclass="field_input" enabled="True" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="OTW_Invoice_AmtTextBoxMaxLengthValidator" ControlToValidate="OTW_Invoice_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;OTW Invoice Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<span style="white-space:nowrap;">
<asp:Literal runat="server" id="LOTW_Invoice_Amt1"></asp:Literal></span>
</td><td class="fls"></td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="fls"><asp:Literal runat="server" id="Req_Pymt_AmtLabel" Text="Payment Amount:">	</asp:Literal> 
<asp:Literal runat="server" id="Req_Pymt_AmtLabel1" Text="Payment Amount:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Pymt_Amt" Columns="20" MaxLength="31" cssclass="field_input" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td>
&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_AmtTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Amt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT Amount&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_Pymt_Amt1"></asp:Literal></span>
</td><td class="fls"><asp:Literal runat="server" id="Req_Pymt_DtLabel" Text="Payment Date: ">	</asp:Literal><asp:Literal runat="server" id="Req_Pymt_DtLabel1" Text="Payment Date:">	</asp:Literal></td><td class="dfv"><span style="white-space:nowrap;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td style="padding-right: 5px; vertical-align:top">
<asp:TextBox runat="server" id="Req_Pymt_Dt" Columns="20" MaxLength="30" cssclass="field_input" requiredroles="&lt;PRoles>1;32;33&lt;/PRoles>"></asp:TextBox></td>
<td style="padding-right: 5px">
<Selectors:CalendarExtendarClass runat="server" ID="Req_Pymt_DtCalendarExtender" TargetControlID="Req_Pymt_Dt" CssClass="MyCalendar" Format="d">
</Selectors:CalendarExtendarClass>&nbsp;
<BaseClasses:TextBoxMaxLengthValidator runat="server" id="Req_Pymt_DtTextBoxMaxLengthValidator" ControlToValidate="Req_Pymt_Dt" ErrorMessage="&lt;%# GetResourceValue(&quot;Val:ValueTooLong&quot;, &quot;IROC2&quot;).Replace(&quot;{FieldName}&quot;, &quot;Request PYMT DT&quot;) %>"></BaseClasses:TextBoxMaxLengthValidator></td>
</tr>
</table>
</span>
 
<asp:Literal runat="server" id="LReq_Pymt_Dt1"></asp:Literal></td><td class="dfv"></td></tr></table>
 
 </ContentTemplate></asp:TabPanel> 
  
</asp:TabContainer> 
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
 <asp:TabPanel runat="server" id="CommentsTabPanel" HeaderText="Comments">	<ContentTemplate>
  <IROC2:CommentsTableControl runat="server" id="CommentsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="CommentsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /> 
</td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsAddButton1" causesvalidation="False" commandname="UpdateData" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" redirectargument="UpdateData" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="CommentsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_DtLabel" tooltip="Sort by Comment_Dt" Text="Date" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_TopicLabel" tooltip="Sort by Comment_Topic" Text="Topic" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_To_AgencyLabel" tooltip="Sort by Comment_To_Agency" Text="To Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Created_ByLabel" tooltip="Sort by Created_By" Text="Created By" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CommentLabel" tooltip="Sort by Comment" Text="Comment" CausesValidation="False">	</asp:LinkButton></th></tr><asp:Repeater runat="server" id="CommentsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:CommentsTableControlRow runat="server" id="CommentsTableControlRow">
<tr><td class="ttc"><asp:Literal runat="server" id="Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Topic"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Comment_To_Agency"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Created_By"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Comment"></asp:Literal></td></tr></IROC2:CommentsTableControlRow>
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
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="ContactsAddButton" causesvalidation="False" commandname="UpdateData" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="ContactsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col"></th><th class="thc" scope="col"></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel2" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="TypeLabel" tooltip="Sort by Type" Text="Entity" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="TitleLabel" tooltip="Sort by Title" Text="Title" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="NameLabel" tooltip="Sort by Name" Text="Name" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="EmailLabel" tooltip="Sort by Email" Text="Email" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Work_PhoneLabel" tooltip="Sort by Work Phone" Text="Work Phone" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="MobileLabel" tooltip="Sort by Mobile" Text="Mobile" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AddressLabel" tooltip="Sort by Address" Text="Address" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CityLabel" tooltip="Sort by City" Text="City" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="ZipLabel" tooltip="Sort by Zip" Text="Zip Code" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="ContactsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:ContactsTableControlRow runat="server" id="ContactsTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="ContactsRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" requiredroles="&lt;PRoles>NOT_ANONYMOUS&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="ContactsRowDeleteButton" causesvalidation="False" commandargument="DeleteOnUpdate" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" requiredroles="&lt;PRoles>NOT_ANONYMOUS&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ttc"><asp:Literal runat="server" id="Agency1"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Type0"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Title"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Name"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Email"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Work_Phone"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Mobile"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Address"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="City"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Zip"></asp:Literal></td><td class="ttc"></td></tr></IROC2:ContactsTableControlRow>
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
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="UploadsAddButton" causesvalidation="False" commandname="Redirect" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="UploadsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col"></th><th class="thc" scope="col"><asp:Literal runat="server" id="UPLOAD_DOCLabel" Text="UPLOAD Name">	</asp:Literal></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DtLabel" tooltip="Sort by UPLOAD_Dt" Text="Date" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DescLabel" tooltip="Sort by UPLOAD_Desc" Text="Description" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_QuoteLabel" tooltip="Sort by UPLOAD_Quote" Text="Quote Amount" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_CommentsLabel" tooltip="Sort by UPLOAD_Comments" Text="Comments:" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_Created_ByLabel" tooltip="Sort by UPLOAD_Created_By" Text="Created By:" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="UploadsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:UploadsTableControlRow runat="server" id="UploadsTableControlRow">
<tr><td class="ttc"><asp:ImageButton runat="server" id="UploadsRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="ttc"><asp:LinkButton runat="server" id="UPLOAD_DOCImage" CommandName="Redirect" class="imageDropshadow" filenamefield="UPLOAD_File"></asp:LinkButton></td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Desc"></asp:Literal> </td><td class="ttc"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="UPLOAD_Quote"></asp:Literal></span>
</td><td class="ttc"><br /> 
<asp:Literal runat="server" id="UPLOAD_Comments"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Created_By"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_File" visible="False"></asp:Literal></td></tr></IROC2:UploadsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:UploadsTableControl>

 </ContentTemplate></asp:TabPanel>
</asp:TabContainer></td></tr><tr><td class="recordPanelButtonsAlignment"><table cellpadding="0" cellspacing="0" border="0" class="pageButtonsContainer"><tr><td><table cellpadding="0" cellspacing="0" border="0"><tr><td><IROC2:ThemeButton runat="server" id="SaveButton" button-causesvalidation="True" button-commandname="UpdateData" button-text="Save" button-tooltip="Save Data, &amp; Stay on Page." postback="True"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="CancelButton" button-causesvalidation="False" button-commandname="Redirect" button-text="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:Cancel&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_More_Info" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="More Info Needed" button-tooltip="Need More Info From  Party via  Comments."></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Submit" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Submit" button-tooltip="Request Info Completed." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="New+INET+Request+Created.+Upload+SOW+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Provided_Info" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text=" Provide More Info" button-tooltip=" Answer Question and Provide Info." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="More+Info+Provided+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_SOW_Done" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="SOW Completed" button-tooltip="Done with Review &amp; Input." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="SOW+Completed++For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_CATV_Reviewd" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="CATV Review Completed" button-tooltip="Done with Review &amp; Input." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="CATV+has+Completed+Review+For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_PROV_Send_Quote" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Send Quote" button-tooltip="Send Quote for Approval" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Uploaded+Quote+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Req_Quote_Accepted" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Accept Quote" button-tooltip="Requester Agree's to Quote" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Quote+Accepted+By+Requester+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="Button_Req_New_Quote" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Get New Quote" button-tooltip="Request For New Quote. From OTWC." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Requester+Rejected+Quote.+New+Quote+Needed+From+Provider+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td><IROC2:ThemeButton runat="server" id="Button_Req_Cancel" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Cancel Request" button-tooltip="Cancel and close this Request." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Requester+Canceled+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Req_PO_Entered" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Entered PO Information" button-tooltip="PO Info was Entered" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Requester+Entered+PO+Information+and+Issues+Notice+to+Proceed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_No_Cost" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="No PO Required" button-tooltip="INET Benefit Project." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Requester+INET+Benefit%2c+No+P.O.+Needed+For+INET.+-+Notice+to+Proceed+For+INET++%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_PROV_Entered_Target_Dt" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Entered Target Dates" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Entered+Target+Start+and+Completion+Dates+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_PROV_Send_Deploy_Status" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Send Project Status" button-tooltip="Send Project Status Message." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Sent+Project+Status+For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_PROV_Work_Completed" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Work Completed" button-tooltip="Send Deployment Completed Notification." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Work+Completed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_PROV_Entered_Invoice_Info" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Entered Invoice Info" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Entered+Invoice+Information+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Prov_Payment_Received" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Entered Payment Info" button-tooltip="Notify OTWC That  Payment Info Was Uploaded." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Provider+Has+Received+All+Payments+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Prov_Connect_INET" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="On-INET" button-tooltip="Connected To INET" sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Connected+To+INET+For+Inet+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr><tr><td><IROC2:ThemeButton runat="server" id="Button_Req_Complete" button-causesvalidation="False" button-commandname="UpdateData" button-redirectargument="UpdateData" button-text="Request Completed" button-tooltip="Completed. Close Request." sendemail1bcc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d" sendemail1cc="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d" sendemail1content="Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a" sendemail1forrecord="Current" sendemail1from="catv%40dcca.hawaii.gov" sendemail1subject="Request+Completed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d" sendemail1to="%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"></IROC2:ThemeButton></td><td></td><td></td></tr></table>
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
                