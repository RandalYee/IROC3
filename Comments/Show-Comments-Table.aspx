<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Page Language="vb" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Show-Comments-Table.aspx.vb" Culture="en-US" MasterPageFile="../Master Pages/HorizontalMenu.master" Inherits="IROC2.UI.Show_Comments_Table" %>
<%@ Register Tagprefix="IROC2" TagName="PaginationMedium" Src="../Shared/PaginationMedium.ascx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.Show_Comments_Table" %>

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
                        <IROC2:CommentsTableControl runat="server" id="CommentsTableControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td class="panelTL"><img src="../Images/space.gif" class="panelTLSpace" alt="" /></td><td class="panelT"></td><td class="panelTR"><img src="../Images/space.gif" class="panelTRSpace" alt="" /></td></tr><tr><td class="panelHeaderL"></td><td class="dh">
                  <table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dhel"><img src="../Images/space.gif" alt="" /></td><td class="dhb"><table cellpadding="0" cellspacing="0" border="0"><tr><td class="dht" valign="middle"><table cellpadding="0" cellspacing="0" border="0"><tr><td><asp:Literal runat="server" id="CommentsTitle" Text="&lt;%#String.Concat(&quot;Comments&quot;) %>">	</asp:Literal></td></tr></table>
</td></tr></table>
</td><td class="dher"><img src="../Images/space.gif" alt="" /></td></tr></table>

                </td><td class="panelHeaderR"></td></tr><tr><td class="panelL"></td><td>
                  <asp:panel id="CommentsTableControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td>
                        <table cellpadding="0" cellspacing="0" border="0"><tr><td class="fila"><asp:Literal runat="server" id="AgencyLabel1" Text="Agency">	</asp:Literal></td><td><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CommentsFilterButton"))%>
<BaseClasses:QuickSelector runat="server" id="AgencyFilter" autopostback="True" onkeypress="dropDownListTypeAhead(this,false)" redirecturl="" selectionmode="Single">	</BaseClasses:QuickSelector><%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CommentsFilterButton"))%>
</td><td class="filbc" rowspan="1"></td></tr></table>

                        </td></tr><tr><td class="pr" style="vertical-align: top">
                      <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;"><tr><td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td class="prbbc"><img src="../Images/ButtonBarDividerL.gif" alt="" /></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsNewButton" causesvalidation="False" commandname="Redirect" imageurl="../Images/ButtonBarNew.gif" onmouseout="this.src='../Images/ButtonBarNew.gif'" onmouseover="this.src='../Images/ButtonBarNewOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Add&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsPDFButton" causesvalidation="False" commandname="ReportData" imageurl="../Images/ButtonBarPDFExport.gif" onmouseout="this.src='../Images/ButtonBarPDFExport.gif'" onmouseover="this.src='../Images/ButtonBarPDFExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:PDF&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsWordButton" causesvalidation="False" commandname="ExportToWord" imageurl="../Images/ButtonBarWordExport.gif" onmouseout="this.src='../Images/ButtonBarWordExport.gif'" onmouseover="this.src='../Images/ButtonBarWordExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Word&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsExportExcelButton" causesvalidation="False" commandname="ExportDataExcel" imageurl="../Images/ButtonBarExcelExport.gif" onmouseout="this.src='../Images/ButtonBarExcelExport.gif'" onmouseover="this.src='../Images/ButtonBarExcelExportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:ExportExcel&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsImportButton" causesvalidation="False" commandname="ImportCSV" imageurl="../Images/ButtonBarImport.gif" onmouseout="this.src='../Images/ButtonBarImport.gif'" onmouseover="this.src='../Images/ButtonBarImportOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Import&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><asp:ImageButton runat="server" id="CommentsResetButton" causesvalidation="False" commandname="ResetFilters" imageurl="../Images/ButtonBarReset.gif" onmouseout="this.src='../Images/ButtonBarReset.gif'" onmouseover="this.src='../Images/ButtonBarResetOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:Reset&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td class="prbbc"><img src="../Images/ButtonBarDividerR.gif" alt="" /></td><td class="prspace"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td><td class="pra"><IROC2:PaginationMedium runat="server" id="CommentsPagination"></IROC2:PaginationMedium>
            <!--To change the position of the pagination control, please search for "prspace" on the Online Help for instruction. --></td><td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td><td></td></tr></table>
</td></tr><tr><td class="tre"><table cellpadding="0" cellspacing="0" border="0" width="100%" onkeydown="captureUpDownKey(this, event)"><tr class="tch"><th class="thc" colspan="2"><img src="../Images/space.gif" height="1" width="1" alt="" /></th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="AgencyLabel" tooltip="Sort by Agency" Text="Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_DtLabel" tooltip="Sort by Comment_Dt" Text="Comment DT" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_TopicLabel" tooltip="Sort by Comment_Topic" Text="Comment Topic" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="Comment_To_AgencyLabel" tooltip="Sort by Comment_To_Agency" Text="Comment To Agency" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:LinkButton runat="server" id="CommentLabel" tooltip="Sort by Comment" Text="Comment" CausesValidation="False">	</asp:LinkButton>    
                        </th><th class="thc" scope="col">
                           <asp:Literal runat="server" id="Request_MasterRecordControlLabel" Text="Request Master">	</asp:Literal>    
                        </th></tr><asp:Repeater runat="server" id="CommentsTableControlRepeater">		<ITEMTEMPLATE>		<IROC2:CommentsTableControlRow runat="server" id="CommentsTableControlRow">
<tr><td class="ticnb" scope="row">
                          <asp:ImageButton runat="server" id="CommentsRowEditButton" causesvalidation="False" commandname="Redirect" cssclass="button_link" imageurl="../Images/icon_edit.gif" onmouseout="this.src='../Images/icon_edit.gif'" onmouseover="this.src='../Images/icon_edit_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:EditRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="tic" scope="row">
                          <asp:ImageButton runat="server" id="CommentsRowDeleteButton" causesvalidation="False" commandname="DeleteRecord" cssclass="button_link" imageurl="../Images/icon_delete.gif" onmouseout="this.src='../Images/icon_delete.gif'" onmouseover="this.src='../Images/icon_delete_over.gif'" tooltip="&lt;%# GetResourceValue(&quot;Txt:DeleteRecord&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton>
                        </td><td class="ttc"><asp:Literal runat="server" id="Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Dt"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_Topic"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment_To_Agency"></asp:Literal> </td><td class="ttc"><asp:Literal runat="server" id="Comment"></asp:Literal> </td><td class="ttc"><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("CancelButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControlRecursively("SaveButton"))%>
<IROC2:Request_MasterRecordControl runat="server" id="Request_MasterRecordControl">	<table class="dv" cellpadding="0" cellspacing="0" border="0"><tr><td></td><td></td><td></td></tr><tr><td></td><td>
                  <asp:panel id="Request_MasterRecordControlCollapsibleRegion" runat="server"><table class="dBody" cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td><asp:panel id="Request_MasterRecordControlPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0" width="100%"><tr><td class="dfv"><asp:Literal runat="server" id="Req_Site_Name"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Address"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Completed_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Req_Contact_Email"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_City"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Deployment_Start_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Cat_Cost_Free"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_State"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Invoice_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="County_Upload"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Zip"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Projected_Deploy_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="ICS_SOW_Needed"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Cat_Franchise_Order_Number"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Scheduled_Deploy_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="ICS_SOW_Uploaded"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="IROC_Id"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Pending_Action_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="OTW_More_Info_Flag"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Construction_Status"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Completed_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="OTW_On_Net"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Invoice_No"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="OTW_Premise_Fiber_Work_Reqd"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Island_completed"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_PO_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Req_Invoice_Paid"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="OTW_Permit_Status"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Pymt_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Pending_Action_Needed"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Pending_Agency"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Quote_Approved"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Reg_Type"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Enity"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Target_Dt"></asp:Literal> </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Req_Funding_Src"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Island"></asp:Literal> </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="OTW_Quote"></asp:Literal></span>
 </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Req_PO_No"></asp:Literal> </td><td class="dfv"><asp:Literal runat="server" id="Req_Pymt_Check_No"></asp:Literal> </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_1st"></asp:Literal></span>
 </td></tr><tr><td class="dfv"><asp:Literal runat="server" id="Req_Status"></asp:Literal> </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="OTW_Invoice_Amt"></asp:Literal></span>
 </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_2nd"></asp:Literal></span>
 </td></tr><tr><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_PO_Amt"></asp:Literal></span>
 </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Req_Pymt_Amt"></asp:Literal></span>
 </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_Auto_Cancel"></asp:Literal></span>
 </td></tr><tr><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Interval_Days_Cancel"></asp:Literal></span>
 </td><td class="dfv"><span style="white-space:nowrap;">
<asp:Literal runat="server" id="Pending_Nterval_Days_Max"></asp:Literal></span>
 </td><td class="dfv"></td></tr></table></asp:panel>
</td></tr></table>
</asp:panel>
                </td><td></td></tr></table>
</IROC2:Request_MasterRecordControl>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("SaveAndNewButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("OKButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("EditButton"))%>
<%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControlRecursively("CancelButton"))%>
</td></tr></IROC2:CommentsTableControlRow>
</ITEMTEMPLATE>

</asp:Repeater>
</table>
</td></tr></table>
</asp:panel>
                </td><td class="panelR"></td></tr></table>
</IROC2:CommentsTableControl>

            </td></tr></table>
    </ContentTemplate>
</asp:UpdatePanel>

    <div id="detailPopup" class="detailRolloverPopup" onmouseout="detailRolloverPopupClose();" onmouseover="clearTimeout(gPopupTimer);"></div>
                   <div class="QDialog" id="dialog" style="display:none;">
                          <iframe id="QuickPopupIframe" style="width:100%;height:100%;border:none"></iframe>
                   </div>                  
    <asp:ValidationSummary id="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server"></asp:ValidationSummary>
</asp:Content>
                