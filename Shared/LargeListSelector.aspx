<%@ Page Language="vb" AutoEventWireup="true" EnableEventValidation="false" Codefile="LargeListSelector.aspx.vb" Inherits="IROC2.UI.LargeListSelector" %>
<%@ Register Tagprefix="IROC2" TagName="Pagination" Src="PaginationMedium.ascx" %>

<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>


<%@ Register Tagprefix="IROC2" Namespace="IROC2.UI.Controls.LargeListSelector" %>

<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %>
<%@ Register Tagprefix="IROC2" TagName="ThemeButton" Src="ThemeButton.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title></title>
  </head>
  <body id="Body1" runat="server" style="background-color: #ffffff;">
	<form id="Form1" method="post" runat="server">
          <BaseClasses:BasePageSettings id="PageSettings" runat="server" />
          		<asp:ScriptManager ID="scriptManager1" runat="server" EnablePartialRendering="True" EnablePageMethods="True" />

	    <asp:UpdateProgress runat="server" id="ItemsTableControlUpdateProgress" AssociatedUpdatePanelID="ItemsTableControlUpdatePanel">
		<ProgressTemplate>
			<div class="ajaxUpdatePanel">
			</div>
			<div style=" position:absolute; padding:30px;">
				<img src="../Images/updating.gif" alt="Updating" />
			</div>
		</ProgressTemplate>
	     </asp:UpdateProgress>
	     <asp:UpdatePanel runat="server" id="ItemsTableControlUpdatePanel" UpdateMode="Conditional">

		<ContentTemplate>    
<IROC2:ItemsTable runat="server" id="ItemsTable">
			
	<table border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td colspan="2">
<!-- BEGIN Search -->
<table>
 <tr>
  <td>
    <%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControl("ItemsTable$SearchButton")) %>
   <table>
    <tr>
     <td class="filter_area">
      <asp:Literal runat="server" id="StartsWithText" Text='<%# GetResourceValue("Txt:StartsWith")%>'/>
     </td>
     <td class="dfv">
      <asp:TextBox runat="server" id="StartsWith" CssClass="Search_Input_Classic" Columns="50" />
      <asp:AutoCompleteExtender id="StartsWithAutoCompleteExtender" runat="server" TargetControlID="StartsWith" ServiceMethod="GetAutoCompletionList_StartsWith" MinimumPrefixLength="2" CompletionInterval="700" CompletionSetCount="10" CompletionListCssClass="autotypeahead_completionListElement" CompletionListItemCssClass="autotypeahead_listItem" CompletionListHighlightedItemCssClass="autotypeahead_highlightedListItem">
		</asp:AutoCompleteExtender>
     </td>
    </tr>
    <tr>
     <td class="filter_area">
      <asp:Literal runat="server" id="ContainsText" Text='<%# GetResourceValue("Txt:Contains")%>'/>
     </td>
     <td class="dfv">
      <asp:TextBox runat="server" id="Contains" CssClass="Search_Input_Classic" Columns="50" />
      <asp:AutoCompleteExtender id="ContainsAutoCompleteExtender" runat="server" TargetControlID="Contains" ServiceMethod="GetAutoCompletionList_Contains" MinimumPrefixLength="2" CompletionInterval="700" CompletionSetCount="10" CompletionListCssClass="autotypeahead_completionListElement" CompletionListItemCssClass="autotypeahead_listItem" CompletionListHighlightedItemCssClass="autotypeahead_highlightedListItem">
		</asp:AutoCompleteExtender>
     </td>
    </tr>
   </table>
    <%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControl("ItemsTable$SearchButton")) %>
  </td>
  <td style="vertical-align:middle;">
   <IROC2:ThemeButton runat="server" id="SearchButton" Button-CausesValidation="False" Button-CommandName="Search" Button-Text="<%# GetResourceValue(&quot;Btn:SearchGoButtonText&quot;) %>">
			</IROC2:ThemeButton>
  </td>
 </tr>
</table>
<!-- END Search -->
			</td>
		</tr>
		<tr>
			<td colspan="2" align="center">
<!-- BEGIN Pagination -->
<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr>
<td class="pagination_row">
<table cellpadding="0" cellspacing="0" border="0">
 <tr>
  <td><img src="../Images/paginationRowEdgeL.gif" alt="" /></td>
  <td class="pagination_area" style="width:100%;">
	<IROC2:Pagination runat="server" id="Pagination"></IROC2:Pagination>
  </td>
  <td><img src="../Images/paginationRowEdgeR.gif" alt="" /></td>
 </tr>
</table>
</td>
</tr>
</table>
<!-- END Pagination -->
		</td>
		</tr>
		<asp:Repeater runat="server" id="Row1">
					<ITEMTEMPLATE>
							<IROC2:ItemsTableRecordControl runat="server" id="ItemsTableRecordControl">
									
			<tr>
				<td class="header_cell" style="text-align:center;">
					<div class="column_header"><asp:Label runat="server" ID="ValueText" Visible="false"></asp:Label><asp:Label runat="server" ID="Formula" Visible="false"></asp:Label><asp:LinkButton runat="server" id="SelectButton" CausesValidation="False" Text="Select"></asp:LinkButton></div>
				</td>
				<td class="table_cell">
					<asp:Label runat="server" id="ItemText"></asp:Label>
				</td>
			</tr>
		
							</IROC2:ItemsTableRecordControl>
					</ITEMTEMPLATE>
			</asp:Repeater>
	</table>

</IROC2:ItemsTable>
</ContentTemplate>
</asp:UpdatePanel>
 </form>
  </body>
</html>