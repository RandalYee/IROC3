<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Group_By_Request_Master_Table" %>

<%@ Register Tagprefix="IROC2" TagName="PaginationMedium" Src="../Shared/PaginationMedium.ascx" %>

<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Group-By-Request-Master-Table.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Group_By_Request_Master_Table" %><asp:Content id="PageSection" ContentPlaceHolderID="PageContent" Runat="server">
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

                <table cellpadding="0" cellspacing="0" border="0"><tr><td>
                        <IROC2:Request_MasterTableControl runat="server" id="Request_MasterTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelHeaderL"></td><td class="dh">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="&lt;%#String.Concat(&quot;INET Request Search&quot;) %>">	</asp:Literal></td><td></td><td></td><td style="font-size:8pt;font-style:italic"></td></tr><tr><td style="color:#004000"><asp:Label runat="server" id="Lentityname" Text="MyLabel">	</asp:Label>
</td><td></td><td></td><td style="color:Black;font-style:italic;font-size:8pt;text-align:center;"><asp:Label runat="server" id="Lentityname1" Text="MyLabel">	</asp:Label>
<span style="color:Black;font-size:8pt">Please email any questions on IROC to IROC@dcca.hawaii.gov, with email subject line, “Inquiry to IROC System Admin"</span></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td>
                        <table cellpadding="0" cellspacing="0" border="0"><tr><td class="fila"><%# GetResourceValue("Txt:SearchFor", "IROC2") %></td><td><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("Request_MasterSearchButton"))%>
<asp:TextBox runat="server" id="Request_MasterSearch" columns="50" cssclass="Search_Input">	</asp:TextBox>
<asp:AutoCompleteExtender id="Request_MasterSearchAutoCompleteExtender" runat="server" TargetControlID="Request_MasterSearch" ServiceMethod="GetAutoCompletionList_Request_MasterSearch" MinimumPrefixLength="2" CompletionInterval="700" CompletionSetCount="10" CompletionListCssClass="autotypeahead_completionListElement" CompletionListItemCssClass="autotypeahead_listItem " CompletionListHighlightedItemCssClass="autotypeahead_highlightedListItem">
</asp:AutoCompleteExtender>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("Request_MasterSearchButton"))%>
</td><td class="fila"><IROC2:ThemeButton runat="server" id="Request_MasterSearchButton" button-causesvalidation="False" button-commandname="Search" button-text="&lt;%# GetResourceValue(&quot;Btn:SearchGoButtonText&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:SearchGoButtonText&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td><td class="fila"></td></tr><tr><td class="fila"><asp:Literal runat="server" id="Reg_TypeLabel1" Text="Request Entity">	</asp:Literal></td><td><BaseClasses:QuickSelector runat="server" id="Reg_TypeFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector> </td><td class="fila"><asp:Literal runat="server" id="Req_Enity2Label" Text="Agency">	</asp:Literal></td><td class="fila"><BaseClasses:QuickSelector runat="server" id="Req_Enity2Filter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector></td></tr><tr><td class="fila"><asp:Literal runat="server" id="Req_StatusLabel1" Text="Status">	</asp:Literal></td><td><BaseClasses:QuickSelector runat="server" id="Req_StatusFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single" tooltip="Select Clear for Full List,  Active For  In Process Requests.">	</BaseClasses:QuickSelector> </td><td class="fila"><asp:Literal runat="server" id="Prov_NameLabel" Text="Network Provider">	</asp:Literal></td><td class="fila"><BaseClasses:QuickSelector runat="server" id="Prov_NameFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector></td></tr><tr><td class="fila"><asp:Literal runat="server" id="Pending_AgencyLabel1" Text="Pending Agency">	</asp:Literal></td><td><BaseClasses:QuickSelector runat="server" id="Pending_AgencyFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector></td><td class="fila"></td><td class="fila"></td></tr></table>

                        </td></tr><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterNewButton" backcolor="White" bordercolor="White" borderstyle="Dotted" causesvalidation="False" commandname="Redirect" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" requiredroles="&lt;PRoles>1;2;22;23;25;26;27;28;29;30;31&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Create New Request&quot;, &quot;IROC2&quot;) %>" visible="True">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterResetButton" causesvalidation="false" commandname="ResetFilters" imageurl="../Images/ButtonBarReset.gif" onmouseout="this.src='../Images/ButtonBarReset.gif'" onmouseover="this.src='../Images/ButtonBarResetOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Reset&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterPDFButton" causesvalidation="False" commandname="ReportData" imageurl="../Images/ButtonBarPDFExport.gif" onmouseout="this.src='../Images/ButtonBarPDFExport.gif'" onmouseover="this.src='../Images/ButtonBarPDFExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:PDF&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterWordButton" causesvalidation="False" commandname="ExportToWord" imageurl="../Images/ButtonBarWordExport.gif" onmouseout="this.src='../Images/ButtonBarWordExport.gif'" onmouseover="this.src='../Images/ButtonBarWordExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Word&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterExportExcelButton" causesvalidation="False" commandname="ExportDataExcel" imageurl="../Images/ButtonBarExcelExport.gif" onmouseout="this.src='../Images/ButtonBarExcelExport.gif'" onmouseover="this.src='../Images/ButtonBarExcelExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:ExportExcel&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"></td><td class="prbbc"></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="prbbc" style="text-align:right"></td><td class="prbbc"><img src="../Images/space.gif" alt="" style="width: 10px" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="Request_MasterPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" colspan="3"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thc" scope="col"></th><th class="thc" scope="col"></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="IROC_IdLabel" tooltip="Sort by IROC_Id" Text="IROC Id" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_Site_NameLabel" tooltip="Sort by Req_Site_Name" Text="Site Name" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_StatusLabel" tooltip="Sort by Req_Status" Text="Status" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Pending_AgencyLabel" tooltip="Sort by Pending_Agency" Text="Pending Agency" CausesValidation="False">	</asp:LinkButton> 
</th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Pending_Action_NeededLabel" tooltip="Sort by Pending_Action_Needed" Text="Pending Action Needed" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Reg_TypeLabel" tooltip="Sort by Request Type." Text="Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_EnityLabel" tooltip="Sort by Req_Enity" Text="Entity" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Prov_NameLabel1" tooltip="Sort by Prov_Name" Text="Network Provider" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_AddressLabel" tooltip="Sort by Req_Address" Text="Address" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_CityLabel" tooltip="Sort by Req_City" Text="City" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_ZipLabel" tooltip="Sort by Req_Zip" Text="Zip Code" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_IslandLabel" tooltip="Sort by Req_Island" Text="Island" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                            
<asp:LinkButton runat="server" id="Req_DtLabel" tooltip="Sort by Req_Dt" Text="Request Date" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_Target_DtLabel" tooltip="Sort by Req_Target_Dt" Text="Target Date" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Req_Completed_DtLabel" tooltip="Sort by Req_Completed_Dt" Text="Completion Date" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="Request_MasterTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:Request_MasterTableControlRow runat="server" id="Request_MasterTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="Request_MasterRowExpandCollapseRowButton" causesvalidation="False" commandname="ExpandCollapseRow" cssclass="button_link" imageurl="../Images/icon_expandcollapserow.gif" onmouseout="this.src='../Images/icon_expandcollapserow.gif'" onmouseover="this.src='../Images/icon_expandcollapserow_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:ExpandCollapseRow&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ticnb" scope="row"><asp:ImageButton runat="server" id="Request_MasterRowViewButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_view.gif" onmouseout="this.src='../Images/icon_view.gif'" onmouseover="this.src='../Images/icon_view_over.gif'" tooltip="View Request.">		
	</asp:ImageButton></td><td class="ticnb" scope="row">
                          
                        <asp:ImageButton runat="server" id="Request_MasterRowEditButton" backcolor="Lime" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" tooltip="Process Request.">		
	</asp:ImageButton></td><td class="ttc"> 
<asp:ImageButton runat="server" id="Request_MasterRowFullEditButton" backcolor="Red" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" requiredroles="&lt;PRoles>1&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Full EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="ttc"><asp:ImageButton runat="server" id="Request_MasterRowDeleteButton" causesvalidation="False" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" requiredroles="&lt;PRoles>1&lt;/PRoles>" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="ttc"><asp:Literal runat="server" id="IROC_Id"></asp:Literal></td><td class="ttc" style="width:600px"><asp:Literal runat="server" id="Req_Site_Name"></asp:Literal> 
</td><td class="ttc" style="width:50px"><asp:Literal runat="server" id="Req_Status"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Pending_Agency"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Pending_Action_Needed"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Reg_Type"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Enity2"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Prov_Name"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Address"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_City"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Zip"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Island"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Dt"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Target_Dt"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Req_Completed_Dt"></asp:Literal></td><td class="ttc"><asp:Label runat="server" id="UserEntity" Text="MyLabel" visible="False">	</asp:Label><asp:Label runat="server" id="LRole" Text="MyLabel" visible="False">	</asp:Label></td></tr><tr id="Request_MasterTableControlAltRow" runat="server"><td class="ticnb" scope="row">&nbsp;</td><td class="ticnb" scope="row"></td><td class="ticnb" scope="row">&nbsp;</td><td class="ttc"></td><td class="ttc"></td><td class="ttc" colspan="15"><asp:TabContainer runat="server" id="Request_MasterTabContainer" requiredroles="&lt;PRoles>1;4&lt;/PRoles>">
 <asp:TabPanel runat="server" id="CommentsTabPanel" HeaderText="Comments">	<ContentTemplate>
  <IROC2:CommentsTableControl runat="server" id="CommentsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="CommentsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"></td><td class="prbbc"></td><td class="prbbc"></td><td class="prspace">&nbsp;</td><td class="pra"><IROC2:PaginationMedium runat="server" id="CommentsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_DtLabel" tooltip="Sort by Comment_Dt" Text="Date" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_TopicLabel" tooltip="Sort by Comment_Topic" Text="Topic" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_To_AgencyLabel" tooltip="Sort by Comment_To_Agency" Text="To Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="Created_ByLabel" tooltip="Sort by Created_By" Text="Created By" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CommentLabel" tooltip="Sort by Comment" Text="Comment" CausesValidation="False">	</asp:LinkButton>    
                        </th></tr><asp:Repeater runat="server" id="CommentsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:CommentsTableControlRow runat="server" id="CommentsTableControlRow">
<tr><td class="ttc"><asp:Literal runat="server" id="Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Topic"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_To_Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Created_By"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Comment"></asp:Literal> </td></tr></IROC2:CommentsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:CommentsTableControl>

 </ContentTemplate></asp:TabPanel>
 <asp:TabPanel runat="server" id="ContactsTabPanel" HeaderText="Contacts">	<ContentTemplate>
  <IROC2:ContactsTableControl runat="server" id="ContactsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="ContactsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td></td><td class="prbbc"></td><td class="prbbc"></td><td class="prbbc"></td><td class="prspace">&nbsp;</td><td class="pra"><IROC2:PaginationMedium runat="server" id="ContactsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel2" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="TypeLabel" tooltip="Sort by Type" Text="Type" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="ZipLabel" tooltip="Sort by Zip" Text="ZIP" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="EmailLabel" tooltip="Sort by Email" Text="Email" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="TitleLabel" tooltip="Sort by Title" Text="Title" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="NameLabel" tooltip="Sort by Name" Text="Name" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AddressLabel" tooltip="Sort by Address" Text="Address" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CityLabel" tooltip="Sort by City" Text="City" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Work_PhoneLabel" tooltip="Sort by Work Phone" Text="Work Phone" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="MobileLabel" tooltip="Sort by Mobile" Text="Mobile" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="ContactsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:ContactsTableControlRow runat="server" id="ContactsTableControlRow">
<tr><td class="ttc"><asp:Literal runat="server" id="Agency1"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Type0"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Zip"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Email"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="Title"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Name"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Address"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="City"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Work_Phone"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Mobile"></asp:Literal> </td><td class="ttc"></td></tr></IROC2:ContactsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:ContactsTableControl>

 </ContentTemplate></asp:TabPanel>
 <asp:TabPanel runat="server" id="UploadsTabPanel" HeaderText="Uploads">	<ContentTemplate>
  <IROC2:UploadsTableControl runat="server" id="UploadsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="UploadsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"></td><td class="prbbc"></td><td class="prbbc"></td><td class="prspace">&nbsp;</td><td class="pra"><IROC2:PaginationMedium runat="server" id="UploadsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" scope="col">
                           <asp:Literal runat="server" id="UPLOAD_DOCLabel" Text="Download Document:">	</asp:Literal>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DtLabel" tooltip="Sort by UPLOAD_Dt" Text="Date" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_DescLabel" tooltip="Sort by UPLOAD_Desc" Text="Description:" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_QuoteLabel" tooltip="Sort by UPLOAD_Quote" Text="Amount:" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col"><asp:LinkButton runat="server" id="UPLOAD_Created_ByLabel" tooltip="Sort by UPLOAD_Created_By" Text="Created By:" CausesValidation="False">	</asp:LinkButton></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="UPLOAD_CommentsLabel" tooltip="Sort by UPLOAD_Comments" Text="Comments:" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col"></th></tr><asp:Repeater runat="server" id="UploadsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:UploadsTableControlRow runat="server" id="UploadsTableControlRow">
<tr><td class="ttc"><asp:LinkButton runat="server" id="UPLOAD_DOC" CommandName="Redirect" class="imageDropshadow" filenamefield="UPLOAD_File" style="max-width:120px;margin:5px;"></asp:LinkButton></td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Desc"></asp:Literal> </td><td class="ttc"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="UPLOAD_Quote"></asp:Literal></span>
</td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Created_By"></asp:Literal></td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_Comments"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="UPLOAD_File" visible="False"></asp:Literal> </td></tr></IROC2:UploadsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:UploadsTableControl>

 </ContentTemplate></asp:TabPanel>
</asp:TabContainer> 
</td><td class="ttc"></td></tr></IROC2:Request_MasterTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:Request_MasterTableControl>

            </td></tr></table>
    </ContentTemplate>
</asp:UpdatePanel>

    <div id="detailPopup" class="detailRolloverPopup" onmouseout="detailRolloverPopupClose();" onmouseover="clearTimeout(gPopupTimer);"></div>
                   <div class="QDialog" id="dialog" style="display:none;">
                          <iframe id="QuickPopupIframe" style="width:100%;height:100%;border:none"></iframe>
                   </div>                  
    <asp:ValidationSummary id="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server"></asp:ValidationSummary>
</asp:Content>
                