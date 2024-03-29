<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
  <title>Test 2</title>
  <script src="OnlineHelp.js" language="javascript" type="text/javascript"></script>
  <script language="javascript" type="text/javascript">
   <!--
	function DoTest2() {
	    if (document.getElementById('DatabaseRadioButton').checked) database = ""
		else database = document.forms[0]['File'].value

		url = "Test2Do.aspx?Database=" + database + "&Table=" + document.forms[0]['Table'].value
		newwindow = window.open(url,'name','height=500,width=650,left=100,top=100,scrollbars=yes,resizable=yes');
		if (window.focus) {newwindow.focus()}
		return false;
	}
	function GoToURL(url) {
		newwindow = window.open(url,'name','height=500,width=650,left=100,top=100,scrollbars=yes,resizable=yes');
		if (window.focus) {newwindow.focus()}
		return false;
	}

	-->
  </script>
<link rel="stylesheet" rev="stylesheet" type="text/css" href="TestConfiguration.css" />
 </head>

<body>
<form id="gsr" method="get" action="http://search.ironspeed.com/search" target="_blank">

<table cellpadding="3" cellspacing="0" border="0" width="100%">
 <tr>
  <td class="page_heading">
   Microsoft Access Connection Test
  </td>
 </tr>
 <tr>
  <td>
   Run this test if your application uses Microsoft Access.  Otherwise <a href="Test3.aspx">Go to Next Test</a>.
   <br /><br />
  </td>
 </tr>
 <tr>
  <td style="padding-left:20px">
     <input type="radio" id="DatabaseRadioButton" name="DatabaseRadioButton" value="Default" checked="checked" /> Default database file (TestConfiguration.mdb, Customers table)<br />
     <input type="radio" id="DatabaseRadioButton2" name="DatabaseRadioButton" value="New" />  Your database file: <input type="file" name="File" value="Browse" size="35" class="description_node" /><br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     Database table: <input type="text" name="Table" class="description_node" /> First 5 rows will be displayed from this table.
     <br /><br />
  </td>
 </tr>
 <tr>
  <td>
   <input type="button" value="Run Microsoft Access Connection Test Now" onclick="return DoTest2();" />
  </td>
 </tr>
 <tr>
  <td>
   <ul>
    <li>
     <b>Test Successful?</b>
     <br />
     <input type="button" value="Go to Next Test" onclick="parent.location='Test3.aspx'" />
    </li>
    <li>
     <b>Errors?  Is it one of these?</b>
      <br />
      <a href="#" onclick="ShowHelp('Part_VI/Localhost_is_Not_Properly_Configured.htm');return false;">Localhost is Not Properly Configured</a><br />
      <a href="#" onclick="ShowHelp('Part_VI/Cannot_Connect_to_Your_Database.htm');return false;">Cannot Connect to Your Database</a><br />
      <a href="#" onclick="ShowHelp('Part_VI/ASP_NET_User_Does_Not_Have_Permissions_to_Your_Application_Folder.htm');return false;">ASP.NET User Does Not Have Permissions to Your Application Folder</a><br />
      <a href="#" onclick="ShowHelp('Part_VI/Microsoft_Jet_OLEDB_4_0_provider_is_not_registered.htm');return false;">'Microsoft.Jet.OLEDB.4.0' provider is not registered...</a><br />
    </li>
    <li>
     <b>Can't find your error message?</b>
      <br />

      Search our knowledge base:
		<!-- Search -->
			<input type="text" name="q" size="25" maxlength="255" value="" class="description_node"/>
			<input type="submit" name="btnI" value="Search"/>
			<input type="hidden" name="site" value="AllHelp" />
			<input type="hidden" name="output" value="xml_no_dtd" />
			<input type="hidden" name="client" value="c1" />
			<input type="hidden" name="proxystylesheet" value="kb" />
		<!-- End Search -->
    </li>
    <li>
     <b>Still having problems?</b>
     <br />
     <a href="http://www.ironspeed.com/Support1/Case/AddCaseFromDesigner.aspx" target="_blank">Submit a Support Case</a>.  Please include a screen shot of the error message.
    </li>
   </ul>
  </td>
 </tr>
</table>

</form>

</body>

</html>