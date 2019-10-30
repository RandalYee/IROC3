﻿<%@ Register Tagprefix="Selectors" Namespace="IROC2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Control Language="vb" AutoEventWireup="false" CodeFile="PaginationShort.ascx.vb" Inherits="IROC2.UI.PaginationShort" %>
<%@ Register Tagprefix="BaseClasses" Namespace="BaseClasses.Web.UI.WebControls" Assembly="BaseClasses" %><table style="width: 100%" border="0" cellpadding="0" cellspacing="0"><tr><td style="width: 50%"><img src="../Images/space.gif" width="10" height="1" alt="" /></td><td><img src="../Images/ButtonBarEdgeL.gif" alt="" /></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td><asp:ImageButton runat="server" id="_FirstPage" causesvalidation="False" commandname="FirstPage" imageurl="../Images/ButtonBarFirst.gif" onclientclick="return SubmitHRefOnce(this, &quot;&quot;);" onmouseout="this.src='../Images/ButtonBarFirst.gif'" onmouseover="this.src='../Images/ButtonBarFirstOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:FirstPage&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td><asp:ImageButton runat="server" id="_PreviousPage" causesvalidation="False" commandname="PreviousPage" imageurl="../Images/ButtonBarPrevious.gif" onclientclick="return SubmitHRefOnce(this, &quot;&quot;);" onmouseout="this.src='../Images/ButtonBarPrevious.gif'" onmouseover="this.src='../Images/ButtonBarPreviousOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:PreviousPage&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td class="prbg"><%= SystemUtils.GenerateEnterKeyCaptureBeginTag(FindControl("_PageSizeButton")) %><asp:TextBox runat="server" id="_CurrentPage" cssclass="Pagination_Input" maxlength="10" size="5">	</asp:TextBox><%= SystemUtils.GenerateEnterKeyCaptureEndTag(FindControl("_PageSizeButton")) %></td><td class="prbg"><%# GetResourceValue("Txt:Of", "IROC2") %> <b><asp:Label runat="server" id="_TotalPages">	</asp:Label></b></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td><asp:ImageButton runat="server" id="_NextPage" causesvalidation="False" commandname="NextPage" imageurl="../Images/ButtonBarNext.gif" onclientclick="return SubmitHRefOnce(this, &quot;&quot;);" onmouseout="this.src='../Images/ButtonBarNext.gif'" onmouseover="this.src='../Images/ButtonBarNextOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:NextPage&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td><asp:ImageButton runat="server" id="_LastPage" causesvalidation="False" commandname="LastPage" imageurl="../Images/ButtonBarLast.gif" onclientclick="return SubmitHRefOnce(this, &quot;&quot;);" onmouseout="this.src='../Images/ButtonBarLast.gif'" onmouseover="this.src='../Images/ButtonBarLastOver.gif'" tooltip="&lt;%# GetResourceValue(&quot;Btn:LastPage&quot;, &quot;IROC2&quot;) %>">		
	</asp:ImageButton></td><td><img src="../Images/ButtonBarDivider.gif" alt="" /></td><td class="prbg"><asp:LinkButton runat="server" id="_PageSizeButton" causesvalidation="False" commandname="PageSize" cssclass="button_link" text="&lt;%# GetResourceValue(&quot;Btn:Go&quot;, &quot;IROC2&quot;) %>" tooltip="&lt;%# GetResourceValue(&quot;Btn:Go&quot;, &quot;IROC2&quot;) %>">		
	</asp:LinkButton></td><td style="width: 50%"><img src="../Images/ButtonBarEdgeR.gif" alt="" /></td></tr></table>