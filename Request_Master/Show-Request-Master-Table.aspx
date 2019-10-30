<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" TagName="PaginationMedium" Src="../Shared/PaginationMedium.ascx" %>

<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="../Shared/ThemeButton.ascx" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Show-Request-Master-Table.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Show_Request_Master_Table" %>
<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Show_Request_Master_Table" %>

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

                <table cellpadding="0" cellspacing="0" border="0"><tr><td>
                        <IROC2:Request_MasterTableControl runat="server" id="Request_MasterTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelHeaderL"></td><td class="dh">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="Request_MasterTitle" Text="&lt;%#String.Concat(&quot;Request Master&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="Request_MasterTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td>
                        <table cellpadding="0" cellspacing="0" border="0"><tr><td class="fila"><%# GetResourceValue("Txt:SearchFor", "IROC2") %></td><td><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("Request_MasterSearchButton"))%>
<asp:TextBox runat="server" id="Request_MasterSearch" columns="50" cssclass="Search_Input">	</asp:TextBox>
<asp:AutoCompleteExtender id="Request_MasterSearchAutoCompleteExtender" runat="server" TargetControlID="Request_MasterSearch" ServiceMethod="GetAutoCompletionList_Request_MasterSearch" MinimumPrefixLength="2" CompletionInterval="700" CompletionSetCount="10" CompletionListCssClass="autotypeahead_completionListElement" CompletionListItemCssClass="autotypeahead_listItem " CompletionListHighlightedItemCssClass="autotypeahead_highlightedListItem">
</asp:AutoCompleteExtender>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("Request_MasterSearchButton"))%>
</td><td class="fila"><IROC2:ThemeButton runat="server" id="Request_MasterSearchButton" button-causesvalidation="False" button-commandname="Search" button-text="&lt;%# GetResourceValue(&quot;Btn:SearchGoButtonText&quot;, &quot;IROC2&quot;) %>" button-tooltip="&lt;%# GetResourceValue(&quot;Btn:SearchGoButtonText&quot;, &quot;IROC2&quot;) %>" postback="False"></IROC2:ThemeButton></td></tr><tr><td class="fila"><asp:Literal runat="server" id="Req_EnityLabel1" Text="Request Enity">	</asp:Literal></td><td><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("Request_MasterFilterButton"))%>
<BaseClasses:QuickSelector runat="server" id="Req_EnityFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector><%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("Request_MasterFilterButton"))%>
</td><td class="filbc" rowspan="1"></td></tr></table>

                        </td></tr><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterNewButton" causesvalidation="False" commandname="Redirect" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterPDFButton" causesvalidation="False" commandname="ReportData" imageurl="../Images/ButtonBarPDFExport.gif" onmouseout="this.src='../Images/ButtonBarPDFExport.gif'" onmouseover="this.src='../Images/ButtonBarPDFExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:PDF&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterWordButton" causesvalidation="False" commandname="ExportToWord" imageurl="../Images/ButtonBarWordExport.gif" onmouseout="this.src='../Images/ButtonBarWordExport.gif'" onmouseover="this.src='../Images/ButtonBarWordExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Word&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterExportExcelButton" causesvalidation="False" commandname="ExportDataExcel" imageurl="../Images/ButtonBarExcelExport.gif" onmouseout="this.src='../Images/ButtonBarExcelExport.gif'" onmouseover="this.src='../Images/ButtonBarExcelExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:ExportExcel&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterImportButton" causesvalidation="False" commandname="ImportCSV" imageurl="../Images/ButtonBarImport.gif" onmouseout="this.src='../Images/ButtonBarImport.gif'" onmouseover="this.src='../Images/ButtonBarImportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Import&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="Request_MasterResetButton" causesvalidation="False" commandname="ResetFilters" imageurl="../Images/ButtonBarReset.gif" onmouseout="this.src='../Images/ButtonBarReset.gif'" onmouseover="this.src='../Images/ButtonBarResetOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Reset&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="prbbc" style="text-align:right"></td><td class="prbbc"><img src="../Images/space.gif" alt="" style="width: 10px" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="Request_MasterPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" colspan="2"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Site_NameLabel" tooltip="Sort by Req_Site_Name" Text="Request Site Name" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Contact_EmailLabel" tooltip="Sort by Req_Contact_Email" Text="Request Contact Email" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_AddressLabel" tooltip="Sort by Req_Address" Text="Request Address" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_CityLabel" tooltip="Sort by Req_City" Text="Request City" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_StateLabel" tooltip="Sort by Req_State" Text="Request State" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_ZipLabel" tooltip="Sort by Req_Zip" Text="Request ZIP" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Completed_DtLabel" tooltip="Sort by OTW_Completed_Dt" Text="OTW Completed DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Deployment_Start_DtLabel" tooltip="Sort by OTW_Deployment_Start_Dt" Text="OTW Deployment Start DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Invoice_DtLabel" tooltip="Sort by OTW_Invoice_Dt" Text="OTW Invoice DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Projected_Deploy_DtLabel" tooltip="Sort by OTW_Projected_Deploy_Dt" Text="OTW Projected Deploy DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Scheduled_Deploy_DtLabel" tooltip="Sort by OTW_Scheduled_Deploy_Dt" Text="OTW Scheduled Deploy DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Action_DtLabel" tooltip="Sort by Pending Action_Dt" Text="Pending Action DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Completed_DtLabel" tooltip="Sort by Req_Completed_Dt" Text="Request Completed DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_DtLabel" tooltip="Sort by Req_Dt" Text="Request DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_PO_DtLabel" tooltip="Sort by Req_PO_Dt" Text="Request PO DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Pymt_DtLabel" tooltip="Sort by Req_Pymt_Dt" Text="Request PYMT DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Quote_ApprovedLabel" tooltip="Sort by Req_Quote_Approved" Text="Request Quote Approved" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Target_DtLabel" tooltip="Sort by Req_Target_Dt" Text="Request Target DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Cat_Cost_FreeLabel" tooltip="Sort by Cat_Cost_Free" Text="Category Cost Free" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="County_UploadLabel" tooltip="Sort by County_Upload" Text="County Upload" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="ICS_SOW_NeededLabel" tooltip="Sort by ICS_SOW_Needed" Text="ICS SOW Needed" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="ICS_SOW_UploadedLabel" tooltip="Sort by ICS_SOW_Uploaded" Text="ICS SOW Uploaded" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_More_Info_FlagLabel" tooltip="Sort by OTW_More_Info_Flag" Text="OTW More Information Flag" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_On_NetLabel" tooltip="Sort by OTW_On-Net" Text="OTW On Net" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Premise_Fiber_Work_ReqdLabel" tooltip="Sort by OTW_Premise Fiber Work Reqd" Text="OTW Premise Fiber Work Reqd" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Invoice_PaidLabel" tooltip="Sort by Req_Invoice_Paid" Text="Request Invoice Paid" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Invoice_AmtLabel" tooltip="Sort by OTW_Invoice_Amt" Text="OTW Invoice Amount" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_PO_AmtLabel" tooltip="Sort by Req_PO_Amt" Text="Request PO Amount" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Pymt_AmtLabel" tooltip="Sort by Req_Pymt_Amt" Text="Request PYMT Amount" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_QuoteLabel" tooltip="Sort by OTW_Quote" Text="OTW Quote" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Interval_Days_1stLabel" tooltip="Sort by Pending_Interval_Days_1st" Text="Pending Interval Days 1 ST" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Interval_Days_2ndLabel" tooltip="Sort by Pending_Interval_Days_2nd" Text="Pending Interval Days 2 ND" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Interval_Days_Auto_CancelLabel" tooltip="Sort by Pending_Interval_Days_Auto_Cancel" Text="Pending Interval Days Automat~ancel" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Interval_Days_CancelLabel" tooltip="Sort by Pending_Interval_Days_Cancel" Text="Pending Interval Days Cancel" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Nterval_Days_MaxLabel" tooltip="Sort by Pending_Nterval_Days_Max" Text="Pending Nterval Days Maximum" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="PriorityLabel" tooltip="Sort by Priority" Text="Priority" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Cat_Franchise_Order_NumberLabel" tooltip="Sort by Cat_Franchise_Order_Number" Text="Category Franchise Order Number" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="IROC_IdLabel" tooltip="Sort by IROC_Id" Text="IROC" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Construction_StatusLabel" tooltip="Sort by OTW_Construction_Status" Text="OTW Construction Status" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Invoice_NoLabel" tooltip="Sort by OTW_Invoice_No" Text="OTW Invoice Number" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Island_completedLabel" tooltip="Sort by OTW_Island completed" Text="OTW Island Completed" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_Permit_StatusLabel" tooltip="Sort by OTW_Permit_Status" Text="OTW Permit Status" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Action_NeededLabel" tooltip="Sort by Pending_Action_Needed" Text="Pending Action Needed" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_AgencyLabel" tooltip="Sort by Pending_Agency" Text="Pending Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Agency_ReturnLabel" tooltip="Sort by Pending_Agency_Return" Text="Pending Agency Return" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Prev_Action_NeededLabel" tooltip="Sort by Pending_Prev_Action_Needed" Text="Pending Previous Action Needed" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Pending_Prev_StatusLabel" tooltip="Sort by Pending_Prev_Status" Text="Pending Previous Status" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Reg_TypeLabel" tooltip="Sort by Reg_Type" Text="REG Type" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_EnityLabel" tooltip="Sort by Req_Enity" Text="Request Enity" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Funding_SrcLabel" tooltip="Sort by Req_Funding_Src" Text="Request Funding Source" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Funding_Src2Label" tooltip="Sort by Req_Funding_Src2" Text="Request Funding Source 2" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_IslandLabel" tooltip="Sort by Req_Island" Text="Request Island" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_PO_NoLabel" tooltip="Sort by Req_PO_No" Text="Request PO Number" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Pymt_Check_NoLabel" tooltip="Sort by Req_Pymt_Check_No" Text="Request PYMT Check Number" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_StatusLabel" tooltip="Sort by Req_Status" Text="Request Status" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_CommentsLabel" tooltip="Sort by Req_Comments" Text="Request Comments" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Req_Quote_RespnseLabel" tooltip="Sort by Req_Quote_Respnse" Text="Request Quote Respnse" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="ICS_CATV_CommentsLabel" tooltip="Sort by ICS_CATV_Comments" Text="ICS CATV Comments" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Cat_OTWC_CommentsLabel" tooltip="Sort by Cat_OTWC_Comments" Text="Category OTWC Comments" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="OTW_More_Info_CommentsLabel" tooltip="Sort by OTW_More_Info_Comments" Text="OTW More Information Comments" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:Literal runat="server" id="CommentsRecordControlLabel" Text="Comments">	</asp:Literal>    
                        </th><th class="thc" scope="col">
                           <asp:Literal runat="server" id="ContactsRecordControlLabel" Text="Contacts">	</asp:Literal>    
                        </th><th class="thc" scope="col">
                           <asp:Literal runat="server" id="EnityRecordControlLabel" Text="DBO Enity">	</asp:Literal>    
                        </th></tr><asp:Repeater runat="server" id="Request_MasterTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:Request_MasterTableControlRow runat="server" id="Request_MasterTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="Request_MasterRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="tic" scope="row">
                          <asp:ImageButton runat="server" id="Request_MasterRowDeleteButton" causesvalidation="False" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ttc"><asp:Literal runat="server" id="Req_Site_Name"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Contact_Email"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Address"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_City"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_State"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Zip"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Completed_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Deployment_Start_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Invoice_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Projected_Deploy_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Action_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Completed_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_PO_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Pymt_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Quote_Approved"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Target_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Cat_Cost_Free"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="County_Upload"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="ICS_SOW_Needed"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="ICS_SOW_Uploaded"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_More_Info_Flag"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_On_Net"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Premise_Fiber_Work_Reqd"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Invoice_Paid"></asp:Literal> </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="OTW_Invoice_Amt"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_PO_Amt"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_Pymt_Amt"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="OTW_Quote"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_1st"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_2nd"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_Auto_Cancel"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_Cancel"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Nterval_Days_Max"></asp:Literal></span>
 </td><td class="ttc" style="text-align: right;"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Priority"></asp:Literal></span>
 </td><td class="ttc"><asp:Literal runat="server" id="Cat_Franchise_Order_Number"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="IROC_Id"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Construction_Status"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Invoice_No"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Island_completed"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_Permit_Status"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Action_Needed"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Agency_Return"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Prev_Action_Needed"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Pending_Prev_Status"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Reg_Type"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Enity"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Funding_Src"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Funding_Src2"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Island"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_PO_No"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Pymt_Check_No"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Status"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Comments"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Req_Quote_Respnse"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="ICS_CATV_Comments"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Cat_OTWC_Comments"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="OTW_More_Info_Comments"></asp:Literal> </td><td class="ttc"><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CancelButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveButton"))%>
<IROC2:CommentsRecordControl runat="server" id="CommentsRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="CommentsRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:panel id="CommentsRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dfv"><asp:Literal runat="server" id="Agency"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Comment_Topic"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Comment_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Comment_To_Agency"></asp:Literal> </td><td class="dfv"></td><td class="dfv"></td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Comment"></asp:Literal> </td></tr></table></asp:panel>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:CommentsRecordControl>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td><td class="ttc"><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CancelButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveButton"))%>
<IROC2:ContactsRecordControl runat="server" id="ContactsRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="ContactsRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:panel id="ContactsRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dfv"><asp:Literal runat="server" id="Email"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Zip"></asp:Literal> </td><td class="dfv"></td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Address"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Agency1"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="City"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Comments"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Mobile"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Name"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Title"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Type0"></asp:Literal> </td></tr><tr><td class="dfv" colspan="3"><asp:Literal runat="server" id="Work_Phone"></asp:Literal> </td></tr></table></asp:panel>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:ContactsRecordControl>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td><td class="ttc"><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CancelButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveButton"))%>
<IROC2:EnityRecordControl runat="server" id="EnityRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="EnityRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:panel id="EnityRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dfv"><asp:Literal runat="server" id="DeptAgencyNames"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Enity_Codes"></asp:Literal> </td><td class="dfv"></td></tr></table></asp:panel>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:EnityRecordControl>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td></tr></IROC2:Request_MasterTableControlRow>
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
                