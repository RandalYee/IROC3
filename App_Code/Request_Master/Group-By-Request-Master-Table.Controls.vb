
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Group_By_Request_Master_Table.aspx page.  The Row or RecordControl classes are the 
' ideal place to add code customizations. For example, you can override the LoadData, 
' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.

#Region "Imports statements"

Option Strict On
Imports Microsoft.VisualBasic
Imports BaseClasses.Web.UI.WebControls
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.Script.Serialization
        
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports ReportTools.ReportCreator
Imports ReportTools.Shared

  
        
Imports IROC2.Business
Imports IROC2.Data
Imports IROC2.UI
        

#End Region

  
Namespace IROC2.UI.Controls.Group_By_Request_Master_Table

#Region "Section 1: Place your customizations here."

    
Public Class ContactsTableControlRow
        Inherits BaseContactsTableControlRow
        ' The BaseContactsTableControlRow implements code for a ROW within the
        ' the ContactsTableControl table.  The BaseContactsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of ContactsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class ContactsTableControl
        Inherits BaseContactsTableControl

    ' The BaseContactsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The ContactsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  
Public Class Request_MasterTableControlRow
        Inherits BaseRequest_MasterTableControlRow
        ' The BaseRequest_MasterTableControlRow implements code for a ROW within the
        ' the Request_MasterTableControl table.  The BaseRequest_MasterTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of Request_MasterTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        


		Public Overrides Sub Request_MasterRowFullEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            '--Ryee
              
                  Dim url As String = "../Request_Master/Full-Edit-Request-Master.aspx?Request_Master={Request_MasterTableControlRow:FV:Request_Id}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try

                ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction()

                url = Me.ModifyRedirectUrl(url, "", True)
                url = Me.Page.ModifyRedirectUrl(url, "", True)

            Catch ex As Exception

                ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True

                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)

            Finally
                DbUtils.EndTransaction()
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If
        End Sub

        Public Overrides Sub SetUserEntity()
            '--Ryee
            Me.UserEntity.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Agency"")")
            '--Ryee  Remove padded spaces
            Me.UserEntity.Text = Me.UserEntity.Text.Trim
        End Sub

        Public Overrides Sub SetLRole()
            '--Ryee
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
            role = Right(role, 2)
            If role = ";1" Then
                Me.LRole.Text = "Admin"
            ElseIf role = ";2" Then
                Me.LRole.Text = "Agency"
            ElseIf role = "32" Or role = "33" Then
                Me.LRole.Text = "Prov"
            Else
                Me.LRole.Text = "Entity"
            End If
        End Sub

        Public Overrides Sub Request_MasterRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)

            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.


            Dim url As String = "../Request_Master/Edit-Request-Master.aspx?Request_Master={Request_MasterTableControlRow:FV:Request_Id}&Agency={Request_MasterTableControlRow:FV:Pending_Agency}"

            Dim shouldRedirect As Boolean = True
            Dim target As String = ""

            Try
                If Me.Pending_Agency.Text = "" Then
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Edit Not Allowed On Non-Active Requests!")
                    Exit Sub
                ElseIf Me.LRole.Text.Trim = "Admin" Then  '--Ryee
                    Me.UserEntity.Text = Me.UserEntity.Text.Trim
                ElseIf Me.Pending_Agency.Text = Me.UserEntity.Text.Trim Then
                    Me.UserEntity.Text = Me.UserEntity.Text
                ElseIf Me.Pending_Agency.Text.Trim = "Requester" Then
                    If Me.Req_Enity2.Text.Trim = Me.UserEntity.Text.Trim Then
                        Me.UserEntity.Text = Me.UserEntity.Text.Trim
                    Else
                        Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Not Authorized!")
                        Exit Sub
                    End If
                Else
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Not Authorized!")
                    Exit Sub
                End If  '--Ryee
                ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction()

                url = Me.ModifyRedirectUrl(url, "", True)
                url = Me.Page.ModifyRedirectUrl(url, "", True)

            Catch ex As Exception

                ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True

                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)

            Finally
                DbUtils.EndTransaction()
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If
        End Sub

        Public Overrides Sub SetReq_Dt()


            ' Set the Req_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Dt is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Dt()
            ' and add your own code before or after the call to the MyBase function.
            '--Ryee


            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then

                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                'Dim formattedValue As String = EvaluateFormula("Format(Req_Dt, ""MM/DD/YYYY"")", Me.DataSource, "d")
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "d")
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Dt.Text = formattedValue

            Else

                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Req_Dt.Text = Request_MasterTable.Req_Dt.Format(Request_MasterTable.Req_Dt.DefaultValue, "d")

            End If

            ' If the Req_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Dt.Text Is Nothing _
                OrElse Me.Req_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Dt.Text = "&nbsp;"
            End If

        End Sub

		Public Overrides Sub SetReq_Enity2()


            ' Set the Req_Enity2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity2 is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity2()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Enity2Specified Then

                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)

                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Enity2.Text = formattedValue
                Me.Req_Enity2.Text = Me.Req_Enity2.Text.Trim  '--Ryee

            Else

                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Req_Enity2.Text = Request_MasterTable.Req_Enity2.Format(Request_MasterTable.Req_Enity2.DefaultValue)

            End If

            ' If the Req_Enity2 is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Enity2.Text Is Nothing _
                OrElse Me.Req_Enity2.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Enity2.Text = "&nbsp;"
            End If

        End Sub

        Public Overrides Sub SetPending_Agency()


            ' Set the Pending_Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_AgencySpecified Then

                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)

                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Agency.Text = formattedValue
                Me.Pending_Agency.Text = Me.Pending_Agency.Text.Trim   '--Ryee

            Else

                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Pending_Agency.Text = Request_MasterTable.Pending_Agency.Format(Request_MasterTable.Pending_Agency.DefaultValue)

            End If

            ' If the Pending_Agency is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Agency.Text Is Nothing _
                OrElse Me.Pending_Agency.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Agency.Text = "&nbsp;"
            End If

        End Sub

		Public Overrides Sub Request_MasterRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)

            Try

                ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction()

                If (Not Me.Page.IsPageRefresh) Then

                    Me.Delete()

                End If
                Me.Page.CommitTransaction(sender)
            Catch ex As Exception

                ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True

                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)

            Finally
                DbUtils.EndTransaction()
            End Try

        End Sub
End Class

  

Public Class Request_MasterTableControl
        Inherits BaseRequest_MasterTableControl

    ' The BaseRequest_MasterTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The Request_MasterTableControlRow class offers another place where you can customize
        ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

        Protected Overrides Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
            '--Ryee


            ' Setup the filter and search.
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Pending_AgencyFilter) Then
                    initialVal = Me.GetFromSession(Me.Pending_AgencyFilter)

                Else
                    Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
                    role = Right(role, 2)
                    If role = ";1" Then  'Admin
                        initialVal = EvaluateFormula("URL(""Pending_Agency"")")
                    ElseIf role = ";2" Then 'Agency
                        initialVal = "Requester"
                    Else    'Prov/Enity
                        initialVal = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")")
                    End If

                End If

                If initialVal <> "" Then

                    Dim Pending_AgencyFilteritemListFromSession() As String = initialVal.Split(","c)
                    Dim index As Integer = 0
                    For Each item As String In Pending_AgencyFilteritemListFromSession
                        If index = 0 AndAlso _
                           item.ToString.Equals("") Then
                        Else
                            Me.Pending_AgencyFilter.Items.Add(item)
                            Me.Pending_AgencyFilter.Items.Item(index).Selected = True
                            index += 1
                        End If
                    Next
                    Dim listItem As ListItem
                    For Each listItem In Me.Pending_AgencyFilter.Items
                        listItem.Selected = True
                    Next

                End If

            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Prov_NameFilter) Then
                    initialVal = Me.GetFromSession(Me.Prov_NameFilter)

                Else

                    initialVal = EvaluateFormula("URL(""Prov_Name"")")

                End If

                If initialVal <> "" Then

                    Dim Prov_NameFilteritemListFromSession() As String = initialVal.Split(","c)
                    Dim index As Integer = 0
                    For Each item As String In Prov_NameFilteritemListFromSession
                        If index = 0 AndAlso _
                           item.ToString.Equals("") Then
                        Else
                            Me.Prov_NameFilter.Items.Add(item)
                            Me.Prov_NameFilter.Items.Item(index).Selected = True
                            index += 1
                        End If
                    Next
                    Dim listItem As ListItem
                    For Each listItem In Me.Prov_NameFilter.Items
                        listItem.Selected = True
                    Next

                End If

            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Reg_TypeFilter) Then
                    initialVal = Me.GetFromSession(Me.Reg_TypeFilter)
                Else
                    initialVal = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")")
                End If
                If initialVal <> Nothing Then  '--Ryee
                    If initialVal.Trim = "Admin" Then
                        initialVal = ""
                    End If
                End If
                If initialVal <> "" Then

                    Dim Reg_TypeFilteritemListFromSession() As String = initialVal.Split(","c)
                    Dim index As Integer = 0
                    For Each item As String In Reg_TypeFilteritemListFromSession
                        If index = 0 AndAlso _
                           item.ToString.Equals("") Then
                        Else
                            Me.Reg_TypeFilter.Items.Add(item)
                            Me.Reg_TypeFilter.Items.Item(index).Selected = True
                            index += 1
                        End If
                    Next
                    Dim listItem As ListItem
                    For Each listItem In Me.Reg_TypeFilter.Items
                        listItem.Selected = True
                    Next

                End If

            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Req_Enity2Filter) Then
                    initialVal = Me.GetFromSession(Me.Req_Enity2Filter)

                Else

                    initialVal = EvaluateFormula("URL(""Req_Enity2"")")

                End If

                If initialVal <> "" Then

                    Dim Req_Enity2FilteritemListFromSession() As String = initialVal.Split(","c)
                    Dim index As Integer = 0
                    For Each item As String In Req_Enity2FilteritemListFromSession
                        If index = 0 AndAlso _
                           item.ToString.Equals("") Then
                        Else
                            Me.Req_Enity2Filter.Items.Add(item)
                            Me.Req_Enity2Filter.Items.Item(index).Selected = True
                            index += 1
                        End If
                    Next
                    Dim listItem As ListItem
                    For Each listItem In Me.Req_Enity2Filter.Items
                        listItem.Selected = True
                    Next

                End If

            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Req_StatusFilter) Then
                    initialVal = Me.GetFromSession(Me.Req_StatusFilter)

                Else

                    initialVal = EvaluateFormula("""Active""")

                End If

                If initialVal <> "" Then

                    Dim Req_StatusFilteritemListFromSession() As String = initialVal.Split(","c)
                    Dim index As Integer = 0
                    For Each item As String In Req_StatusFilteritemListFromSession
                        If index = 0 AndAlso _
                           item.ToString.Equals("") Then
                        Else
                            Me.Req_StatusFilter.Items.Add(item)
                            Me.Req_StatusFilter.Items.Item(index).Selected = True
                            index += 1
                        End If
                    Next
                    Dim listItem As ListItem
                    For Each listItem In Me.Req_StatusFilter.Items
                        listItem.Selected = True
                    Next

                End If

            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If Me.InSession(Me.Request_MasterSearch) Then
                    initialVal = Me.GetFromSession(Me.Request_MasterSearch)

                End If

                If initialVal <> "" Then

                    Me.Request_MasterSearch.Text = initialVal

                End If

            End If


            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))

            Else

                Me.CurrentSortOrder = New OrderBy(True, False)

                Me.CurrentSortOrder.Add(Request_MasterTable.Reg_Type, OrderByItem.OrderDir.Asc)

                Me.CurrentSortOrder.Add(Request_MasterTable.Req_Enity2, OrderByItem.OrderDir.Asc)

                Me.CurrentSortOrder.Add(Request_MasterTable.Priority, OrderByItem.OrderDir.Asc)

                Me.CurrentSortOrder.Add(Request_MasterTable.Req_Site_Name, OrderByItem.OrderDir.Asc)

            End If



            ' Setup default pagination settings.

            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "20"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))



            Me.ClearControlsFromSession()
        End Sub

        Public Overrides Sub SetReq_StatusFilter()


            Dim Req_StatusFilterselectedFilterItemList As New ArrayList()
            Dim Req_StatusFilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_StatusFilter)) Then
                Req_StatusFilteritemsString = Me.GetFromSession(Me.Req_StatusFilter)
            End If

            If (Req_StatusFilteritemsString IsNot Nothing) Then
                Dim Req_StatusFilteritemListFromSession() As String = Req_StatusFilteritemsString.Split(","c)
                For Each item As String In Req_StatusFilteritemListFromSession
                    Req_StatusFilterselectedFilterItemList.Add(item)
                Next
            End If

            Req_StatusFilterselectedFilterItemList.Add("Active")
            Me.PopulateReq_StatusFilter(GetSelectedValueList(Me.Req_StatusFilter, Req_StatusFilterselectedFilterItemList), 500)

        End Sub

        Protected Overrides Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            SaveControlsToSession_Ajax()

            ' Setup the pagination events.

            AddHandler Me.Request_MasterPagination.FirstPage.Click, AddressOf Request_MasterPagination_FirstPage_Click

            AddHandler Me.Request_MasterPagination.LastPage.Click, AddressOf Request_MasterPagination_LastPage_Click

            AddHandler Me.Request_MasterPagination.NextPage.Click, AddressOf Request_MasterPagination_NextPage_Click

            AddHandler Me.Request_MasterPagination.PageSizeButton.Click, AddressOf Request_MasterPagination_PageSizeButton_Click

            AddHandler Me.Request_MasterPagination.PreviousPage.Click, AddressOf Request_MasterPagination_PreviousPage_Click

            Dim url As String = ""
            ' Setup the sorting events.

            AddHandler Me.IROC_IdLabel.Click, AddressOf IROC_IdLabel_Click

            AddHandler Me.Req_Site_NameLabel.Click, AddressOf Req_Site_NameLabel_Click

            AddHandler Me.Req_StatusLabel.Click, AddressOf Req_StatusLabel_Click

            AddHandler Me.Pending_AgencyLabel.Click, AddressOf Pending_AgencyLabel_Click

            AddHandler Me.Pending_Action_NeededLabel.Click, AddressOf Pending_Action_NeededLabel_Click

            AddHandler Me.Reg_TypeLabel.Click, AddressOf Reg_TypeLabel_Click

            AddHandler Me.Req_EnityLabel.Click, AddressOf Req_EnityLabel_Click

            AddHandler Me.Prov_NameLabel1.Click, AddressOf Prov_NameLabel1_Click

            AddHandler Me.Req_AddressLabel.Click, AddressOf Req_AddressLabel_Click

            AddHandler Me.Req_CityLabel.Click, AddressOf Req_CityLabel_Click

            AddHandler Me.Req_ZipLabel.Click, AddressOf Req_ZipLabel_Click

            AddHandler Me.Req_IslandLabel.Click, AddressOf Req_IslandLabel_Click

            AddHandler Me.Req_DtLabel.Click, AddressOf Req_DtLabel_Click

            AddHandler Me.Req_Target_DtLabel.Click, AddressOf Req_Target_DtLabel_Click

            AddHandler Me.Req_Completed_DtLabel.Click, AddressOf Req_Completed_DtLabel_Click

            ' Setup the button events.

            AddHandler Me.Request_MasterExportExcelButton.Click, AddressOf Request_MasterExportExcelButton_Click

            AddHandler Me.Request_MasterNewButton.Click, AddressOf Request_MasterNewButton_Click

            AddHandler Me.Request_MasterPDFButton.Click, AddressOf Request_MasterPDFButton_Click

            AddHandler Me.Request_MasterResetButton.Click, AddressOf Request_MasterResetButton_Click

            AddHandler Me.Request_MasterWordButton.Click, AddressOf Request_MasterWordButton_Click

            AddHandler Me.Request_MasterSearchButton.Button.Click, AddressOf Request_MasterSearchButton_Click

            url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
            url = Me.Page.ModifyRedirectUrl(url, "", True)
            Me.Pending_AgencyFilter.PostBackUrl = url & "?Target=" & Me.Pending_AgencyFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Pending_Agency") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
            Me.Pending_AgencyFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Pending_AgencyFilter.PostBackUrl & "', true, event); return false;"

            AddHandler Me.Pending_AgencyFilter.SelectedIndexChanged, AddressOf Pending_AgencyFilter_SelectedIndexChanged

            url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
            url = Me.Page.ModifyRedirectUrl(url, "", True)
            Me.Prov_NameFilter.PostBackUrl = url & "?Target=" & Me.Prov_NameFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Prov_Name") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
            Me.Prov_NameFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Prov_NameFilter.PostBackUrl & "', true, event); return false;"

            AddHandler Me.Prov_NameFilter.SelectedIndexChanged, AddressOf Prov_NameFilter_SelectedIndexChanged

            url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
            url = Me.Page.ModifyRedirectUrl(url, "", True)
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString  '--Ryee
            role = Right(role, 2)
                Select role
                Case "22", "25", "26" 'State
                    Me.Reg_TypeFilter.PostBackUrl = url & "?Target=" & Me.Reg_TypeFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Reg_Type") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("State") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:State"))
                Case Else
                    Me.Reg_TypeFilter.PostBackUrl = url & "?Target=" & Me.Reg_TypeFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Reg_Type") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
            End Select
            Me.Reg_TypeFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Reg_TypeFilter.PostBackUrl & "', true, event); return false;"

            AddHandler Me.Reg_TypeFilter.SelectedIndexChanged, AddressOf Reg_TypeFilter_SelectedIndexChanged

            url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
            url = Me.Page.ModifyRedirectUrl(url, "", True)
            Me.Req_Enity2Filter.PostBackUrl = url & "?Target=" & Me.Req_Enity2Filter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Enity2") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
            Me.Req_Enity2Filter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Req_Enity2Filter.PostBackUrl & "', true, event); return false;"

            AddHandler Me.Req_Enity2Filter.SelectedIndexChanged, AddressOf Req_Enity2Filter_SelectedIndexChanged

            url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
            url = Me.Page.ModifyRedirectUrl(url, "", True)
            Me.Req_StatusFilter.PostBackUrl = url & "?Target=" & Me.Req_StatusFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Status") & "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
            Me.Req_StatusFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Req_StatusFilter.PostBackUrl & "', true, event); return false;"

            AddHandler Me.Req_StatusFilter.SelectedIndexChanged, AddressOf Req_StatusFilter_SelectedIndexChanged


            ' Setup events for others

        End Sub
        Protected Overrides Function CreateQueryClause() As WhereClause
            ' Create a where clause for the Static clause defined at design time.
            '--Ryee
            Dim filter As CompoundFilter = New CompoundFilter(CompoundFilter.CompoundingOperators.And_Operator, Nothing)
            Dim whereClause As WhereClause = New WhereClause()

            'If EvaluateFormula("""Completed""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Completed""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
            'If (EvaluateFormula("""Completed""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Completed""", False) = "--ANY--") Then whereClause.RunQuery = False

            'whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
            Dim cols As New ColumnList   '--Ryee
            role = Right(role, 2)
            Select role
                Case ";1", "23"  'Admin
                    If EvaluateFormula("""State""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""State""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Active""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Active""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)
                Case ";2"  'Agency
                    If EvaluateFormula("GetColumnValue(""Users"", UserId(),""Agency"")", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Enity2"), EvaluateFormula("GetColumnValue(""Users"", UserId(),""Agency"")", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Contains, False))
                    If (EvaluateFormula("GetColumnValue(""Users"", UserId(),""Agency"")", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("GetColumnValue(""Users"", UserId(),""Agency"")", False) = "--ANY--") Then whereClause.RunQuery = False

                    whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)

                Case "32", "33"  'Provider
                    If EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Prov_Name"), EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Contains, False))
                    If (EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", False) = "--ANY--") Then whereClause.RunQuery = False
                    whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)

                Case "22", "25", "26"   'State
                    cols.Add(Request_MasterTable.Reg_Type, True)
                    For Each col As BaseColumn In cols
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, "ETS", True, False)
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, "CATV", True, False)
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, "UH", True, False)
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, "DOE", True, False)
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, "HSPLS", True, False)
                    Next
                    cols = New ColumnList
                    cols.Add(Request_MasterTable.Pending_Agency, True)
                    For Each col As BaseColumn In cols
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, EvaluateFormula("GetColumnValue(""Users"",UserId(), ""Enity"")", False), True, False)
                    Next

                Case Else 'Entity
                    cols.Add(Request_MasterTable.Reg_Type, True)
                    cols.Add(Request_MasterTable.Pending_Agency, True)
                    For Each col As BaseColumn In cols
                        whereClause.iOR(col, BaseFilter.ComparisonOperator.EqualsTo, EvaluateFormula("GetColumnValue(""Users"",UserId(), ""Enity"")", False), True, False)
                    Next
            End Select
            Dim itemType As ListItem
            For Each itemType In Me.Reg_TypeFilter.Items
                If itemType.Value.Trim = "State" Then
                    If EvaluateFormula("""Admin""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""Admin""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Co_Cnc""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""Co_Cnc""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Co_HI""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""Co_HI""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Co_M""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""Co_M""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Co_K""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Reg_Type"), EvaluateFormula("""Co_K""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If (EvaluateFormula("""Admin""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Admin""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Co_Cnc""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Co_Cnc""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Co_HI""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Co_HI""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Co_M""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Co_M""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Co_K""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Co_K""", False) = "--ANY--") Then whereClause.RunQuery = False
                    whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)
                End If
            Next
            Dim item As ListItem
            For Each item In Me.Req_StatusFilter.Items
                If item.Value.Trim = "Active" Then
                    'filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Pending_Agency"), EvaluateFormula("""""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Completed""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Completed""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Done""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Done""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Status unknown""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Status unknown""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If EvaluateFormula("""Canceled""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Canceled""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
                    If (EvaluateFormula("""Completed""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Completed""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Done""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Done""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Status unknown""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Status unknown""", False) = "--ANY--") Then whereClause.RunQuery = False
                    If (EvaluateFormula("""Canceled""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Canceled""", False) = "--ANY--") Then whereClause.RunQuery = False

                    whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)

                End If
            Next
            '          If EvaluateFormula("""Active""", False) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Active""", False), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
            'If (EvaluateFormula("""Active""", False) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Active""", False) = "--ANY--") Then whereClause.RunQuery = False

            ' whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)

            Return whereClause
        End Function

		Public Overrides Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            Request_MasterTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            '--Ryee
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
            ' Get the static clause defined at design time on the Table Panel Wizard
            Dim qc As WhereClause = Me.CreateQueryClause()
            If Not(IsNothing(qc)) Then
                wc.iAND(qc)
            End If

            If IsValueSelected(Me.Pending_AgencyFilter) Then

                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Pending_AgencyFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1

                    End If
                Next

                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Pending_AgencyFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)

            End If

            If IsValueSelected(Me.Prov_NameFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Prov_NameFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Prov_NameFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Prov_Name, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Reg_TypeFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Reg_TypeFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString  '--Ryee
                role = Right(role, 2)
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Reg_TypeFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        If item.Value.Trim <> "State" Then
                            Select Case role
                                Case ";1"  'Admin
                                    filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                                Case "23"
                                    If item.Text.Trim = "CATV" Then
                                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item.Value.Trim, False, False)
                                        filter.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item.Value.Trim, False, False)
                                    Else
                                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                                    End If
                                Case "22", "25", "26"   'State - Do Not Show Counties
                                    If item.Text.Trim = "ETS" Or item.Text.Trim = "CATV" Or item.Text.Trim = "DOE" Or item.Text.Trim = "HSPLS" Or item.Text.Trim = "UH" Then
                                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item.Value.Trim, False, False)
                                        filter.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item.Value.Trim, False, False)
                                    Else 'Show only there own items
                                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, EvaluateFormula("GetColumnValue(""Users"",UserId(), ""Enity"")"), False, False)
                                    End If
                            End Select
                        End If
                    End If
                Next
                wc.iAND(filter)

            End If
                  
                
                       
            If IsValueSelected(Me.Req_Enity2Filter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Req_Enity2Filter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Req_Enity2Filter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Req_Enity2, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Req_StatusFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Req_StatusFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Req_StatusFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If '--Ryee
                    If item.Text <> "Active" Then  '--Ryee
                        filter.iOR(Request_MasterTable.Req_Status, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Request_MasterSearch) Then
              If Me.Request_MasterSearch.Text = BaseClasses.Resources.AppResources.GetResourceValue("Txt:SearchForEllipsis", Nothing) Then
                 Me.Request_MasterSearch.Text = ""
              Else
              ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
              
                    If Me.Request_MasterSearch.Text.StartsWith("...") Then
                        Me.Request_MasterSearch.Text = Me.Request_MasterSearch.Text.SubString(3,Me.Request_MasterSearch.Text.Length-3)
                    End If
                    If Me.Request_MasterSearch.Text.EndsWith("...") then
                        Me.Request_MasterSearch.Text = Me.Request_MasterSearch.Text.SubString(0,Me.Request_MasterSearch.Text.Length-3)
                        ' Strip the last word as well as it is likely only a partial word
                        Dim endindex As Integer = Request_MasterSearch.Text.Length - 1
                        While (Not Char.IsWhiteSpace(Request_MasterSearch.Text(endindex)) AndAlso endindex > 0)
                            endindex -= 1
                        End While
                        If endindex > 0 Then
                            Request_MasterSearch.Text = Request_MasterSearch.Text.Substring(0, endindex)
                        End If
              End If
            End If
            
              Dim formatedSearchText As String = MiscUtils.GetSelectedValue(Me.Request_MasterSearch, Me.GetFromSession(Me.Request_MasterSearch))
                
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(Me.Request_MasterSearch) Then 
        ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
      Dim cols As New ColumnList    
        
      cols.Add(Request_MasterTable.IROC_Id, True)
      
      cols.Add(Request_MasterTable.Reg_Type, True)
      
      cols.Add(Request_MasterTable.Req_Address, True)
      
      cols.Add(Request_MasterTable.Req_Contact_Email, True)
      
      cols.Add(Request_MasterTable.Req_Enity2, True)
      
      cols.Add(Request_MasterTable.Req_Funding_Src, True)
      
      cols.Add(Request_MasterTable.Req_Island, True)
      
      cols.Add(Request_MasterTable.Req_Site_Name, True)
      
      For Each col As BaseColumn in cols
      
                    search.iOR(col, BaseFilter.ComparisonOperator.Contains, MiscUtils.GetSelectedValue(Me.Request_MasterSearch, Me.GetFromSession(Me.Request_MasterSearch)), True, False)
        
      Next
    
                    wc.iAND(search)
                End If
            End If
                  
    Return wc
    End Function
        ' event handler for ImageButton
        Public Overrides Sub Request_MasterPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)

            If Me.DataChanged = True Then Exit Sub 'Ryee prevent double update.
            Try


                Me.PageIndex += 1
                Me.DataChanged = True

            Catch ex As Exception

                Me.Page.ErrorOnPage = True

                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)

            Finally

            End Try

        End Sub
		Public Overrides Sub SetLentityname()
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
            role = Right(role, 2)
            If role = ";1" Then
                Me.Lentityname.Text = "Administrator        *"
            ElseIf role = ";2" Then
                Me.Lentityname.Text = "Agency: " & EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Agency"")") & "       *"
            ElseIf role = "32" Or role = "33" Then
                Me.Lentityname.Text = "Provider: " & EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")") & "        *"
            Else
                Me.Lentityname.Text = "Entity: " & EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")") & "        *"
            End If
        End Sub
		Public Overrides Sub IROC_IdLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Site_Name when clicked.
              
            ' Get previous sorting state for Req_Site_Name.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
				
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.IROC_Id)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Site_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.IROC_Id, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Site_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_Site_NameLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Site_Name when clicked.
              
            ' Get previous sorting state for Req_Site_Name.
            	
            If Me.DataChanged =  True Then Exit Sub '--Ryee

			Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Site_Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Site_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Site_Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Site_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_StatusLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Status when clicked.
              
            ' Get previous sorting state for Req_Status.
 			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
           
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Status)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Status.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Status, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Status, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Pending_AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Agency when clicked.
              
            ' Get previous sorting state for Pending_Agency.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Pending_Action_NeededLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Action_Needed when clicked.
              
            ' Get previous sorting state for Pending_Action_Needed.
 			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
           
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Action_Needed)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Action_Needed.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Action_Needed, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Action_Needed, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Reg_TypeLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Reg_Type when clicked.
              
            ' Get previous sorting state for Reg_Type.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Reg_Type)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Reg_Type.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Reg_Type, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Reg_Type, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_EnityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Enity when clicked.
              
            ' Get previous sorting state for Req_Enity.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Enity2)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Enity.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Enity2, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Enity, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Prov_NameLabel1_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Prov_Name when clicked.
              
            ' Get previous sorting state for Prov_Name.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Prov_Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Prov_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Prov_Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Prov_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_AddressLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Address when clicked.
              
            ' Get previous sorting state for Req_Address.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Address)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Address.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Address, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Address, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_CityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_City when clicked.
              
            ' Get previous sorting state for Req_City.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_City)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_City.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_City, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_City, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_ZipLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Zip when clicked.
              
            ' Get previous sorting state for Req_Zip.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Zip)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Zip.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Zip, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Zip, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_IslandLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Island when clicked.
              
            ' Get previous sorting state for Req_Island.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Island)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Island.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Island, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Island, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Dt when clicked.
              
            ' Get previous sorting state for Req_Dt.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_Completed_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Completed_Dt when clicked.
              
            ' Get previous sorting state for Req_Completed_Dt.
			
            If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Completed_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Completed_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Completed_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Completed_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub

		Public Overrides Sub Req_Target_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Target_Dt when clicked.
              
            ' Get previous sorting state for Req_Target_Dt.
			If Me.DataChanged =  True Then Exit Sub '--Ryee
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Target_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Target_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Target_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Target_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
End Class


Public Class UploadsTableControlRow
        Inherits BaseUploadsTableControlRow
        ' The BaseUploadsTableControlRow implements code for a ROW within the
        ' the UploadsTableControl table.  The BaseUploadsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of UploadsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class UploadsTableControl
        Inherits BaseUploadsTableControl

    ' The BaseUploadsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The UploadsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  

Public Class CommentsTableControl
        Inherits BaseCommentsTableControl

    ' The BaseCommentsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The CommentsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class
Public Class CommentsTableControlRow
        Inherits BaseCommentsTableControlRow
        ' The BaseCommentsTableControlRow implements code for a ROW within the
        ' the CommentsTableControl table.  The BaseCommentsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of CommentsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class
#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the CommentsTableControlRow control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in CommentsTableControlRow.
Public Class BaseCommentsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in CommentsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in CommentsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
                    
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Comments record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = CommentsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseCommentsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New CommentsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in CommentsTableControlRow.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetAgency()
                SetComment()
                SetComment_Dt()
                SetComment_To_Agency()
                SetComment_Topic()
                SetCreated_By()
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
        End Sub
        
        
        Public Overridable Sub SetAgency()
            
        
            ' Set the Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Agency is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AgencySpecified Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Agency.Text = formattedValue
                
            Else 
            
                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Agency.Text = CommentsTable.Agency.Format(CommentsTable.Agency.DefaultValue)
                        		
                End If
                 
            ' If the Agency is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Agency.Text Is Nothing _
                OrElse Me.Agency.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Agency.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetComment()
            
        
            ' Set the Comment Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CommentSpecified Then
                				
                ' If the Comment is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comment.Text = formattedValue
                
            Else 
            
                ' Comment is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment.Text = CommentsTable.Comment.Format(CommentsTable.Comment.DefaultValue)
                        		
                End If
                 
            ' If the Comment is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Comment.Text Is Nothing _
                OrElse Me.Comment.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Comment.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetComment_Dt()
            
        
            ' Set the Comment_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Comment_DtSpecified Then
                				
                ' If the Comment_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comment_Dt.Text = formattedValue
                
            Else 
            
                ' Comment_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_Dt.Text = CommentsTable.Comment_Dt.Format(CommentsTable.Comment_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the Comment_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Comment_Dt.Text Is Nothing _
                OrElse Me.Comment_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Comment_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetComment_To_Agency()
            
        
            ' Set the Comment_To_Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_To_Agency is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_To_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Comment_To_AgencySpecified Then
                				
                ' If the Comment_To_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_To_Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comment_To_Agency.Text = formattedValue
                
            Else 
            
                ' Comment_To_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_To_Agency.Text = CommentsTable.Comment_To_Agency.Format(CommentsTable.Comment_To_Agency.DefaultValue)
                        		
                End If
                 
            ' If the Comment_To_Agency is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Comment_To_Agency.Text Is Nothing _
                OrElse Me.Comment_To_Agency.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Comment_To_Agency.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetComment_Topic()
            
        
            ' Set the Comment_Topic Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_Topic is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_Topic()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Comment_TopicSpecified Then
                				
                ' If the Comment_Topic is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_Topic)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comment_Topic.Text = formattedValue
                
            Else 
            
                ' Comment_Topic is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_Topic.Text = CommentsTable.Comment_Topic.Format(CommentsTable.Comment_Topic.DefaultValue)
                        		
                End If
                 
            ' If the Comment_Topic is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Comment_Topic.Text Is Nothing _
                OrElse Me.Comment_Topic.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Comment_Topic.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetCreated_By()
            
        
            ' Set the Created_By Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Created_By is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCreated_By()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Created_BySpecified Then
                				
                ' If the Created_By is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Created_By)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Created_By.Text = formattedValue
                
            Else 
            
                ' Created_By is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Created_By.Text = CommentsTable.Created_By.Format(CommentsTable.Created_By.DefaultValue)
                        		
                End If
                 
            ' If the Created_By is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Created_By.Text Is Nothing _
                OrElse Me.Created_By.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Created_By.Text = "&nbsp;"
            End If
                  
        End Sub
                

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function      
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in CommentsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterTableControlRow
          
          				  
          parentCtrl = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow"), Request_MasterTableControlRow)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
                DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in CommentsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetAgency()
            GetComment()
            GetComment_Dt()
            GetComment_To_Agency()
            GetComment_Topic()
            GetCreated_By()
        End Sub
        
        
        Public Overridable Sub GetAgency()
            
        End Sub
                
        Public Overridable Sub GetComment()
            
        End Sub
                
        Public Overridable Sub GetComment_Dt()
            
        End Sub
                
        Public Overridable Sub GetComment_To_Agency()
            
        End Sub
                
        Public Overridable Sub GetComment_Topic()
            
        End Sub
                
        Public Overridable Sub GetCreated_By()
            
        End Sub
                
      
        ' To customize, override this method in CommentsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in CommentsTableControlRow.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          CommentsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).ResetData = True
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                						
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseCommentsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseCommentsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As CommentsRecord
        Public Property DataSource() As CommentsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As CommentsRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property Agency() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Comment() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Comment_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Comment_To_Agency() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_To_Agency"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Comment_Topic() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Topic"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Created_By() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Created_By"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As CommentsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As CommentsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As CommentsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return CommentsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the CommentsTableControl control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in CommentsTableControl.
Public Class BaseCommentsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(CommentsTable.Comment_ID, OrderByItem.OrderDir.Desc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "20"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
            ' Setup the pagination events.
            
              AddHandler Me.CommentsPagination.FirstPage.Click, AddressOf CommentsPagination_FirstPage_Click
              
              AddHandler Me.CommentsPagination.LastPage.Click, AddressOf CommentsPagination_LastPage_Click
              
              AddHandler Me.CommentsPagination.NextPage.Click, AddressOf CommentsPagination_NextPage_Click
              
              AddHandler Me.CommentsPagination.PageSizeButton.Click, AddressOf CommentsPagination_PageSizeButton_Click
            
              AddHandler Me.CommentsPagination.PreviousPage.Click, AddressOf CommentsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.AgencyLabel.Click, AddressOf AgencyLabel_Click
            
              AddHandler Me.Comment_DtLabel.Click, AddressOf Comment_DtLabel_Click
            
              AddHandler Me.Comment_To_AgencyLabel.Click, AddressOf Comment_To_AgencyLabel_Click
            
              AddHandler Me.Comment_TopicLabel.Click, AddressOf Comment_TopicLabel_Click
            
              AddHandler Me.CommentLabel.Click, AddressOf CommentLabel_Click
            
              AddHandler Me.Created_ByLabel.Click, AddressOf Created_ByLabel_Click
            
            ' Setup the button events.
                  
        
          ' Setup events for others
            
        End Sub
        
        
        Public Overridable Sub LoadData()        
        
            ' Read data from database. Returns an array of records that can be assigned
            ' to the DataSource table control property.
            Try	
                Dim joinFilter As CompoundFilter = CreateCompoundJoinFilter()
                
                ' The WHERE clause will be empty when displaying all records in table.
                Dim wc As WhereClause = CreateWhereClause()
                If wc IsNot Nothing AndAlso Not wc.RunQuery Then
                    ' Initialize an empty array of records
                    Dim alist As New ArrayList(0)
                    Me.DataSource = DirectCast(alist.ToArray(GetType(CommentsRecord)), CommentsRecord())
                    ' Add records to the list if needed.
                    Me.AddNewRecords()
                    Me._TotalRecords = 0
                    Me._TotalPages = 0
                    Return
                End If

                ' Call OrderBy to determine the order - either use the order defined
                ' on the Query Wizard, or specified by user (by clicking on column heading)
                Dim orderBy As OrderBy = CreateOrderBy()
                
                ' Get the pagesize from the pagesize control.
                Me.GetPageSize()
                               
                If Me.DisplayLastPage Then
                    Dim totalRecords As Integer = If(Me._TotalRecords < 0, GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause()), Me._TotalRecords)
                     
                      Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / Me.PageSize))
                    
                    Me.PageIndex = totalPages - 1
                End If                               
                
                ' Make sure PageIndex (current page) and PageSize are within bounds.
                If Me.PageIndex < 0 Then
                    Me.PageIndex = 0
                End If
                If Me.PageSize < 1 Then
                    Me.PageSize = 1
                End If
                
                ' Retrieve the records and set the table DataSource.
                ' Only PageSize records are fetched starting at PageIndex (zero based).
                If Me.AddNewRecord > 0 Then
                ' Make sure to preserve the previously entered data on new rows.
                    Dim postdata As New ArrayList
                    For Each rc As CommentsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(CommentsRecord)), CommentsRecord())
                Else  ' Get the records from the database	
                        Me.DataSource = GetRecords(joinFilter, wc, orderBy, Me.PageIndex, Me.PageSize)
                      
                End If
                
                ' if the datasource contains no records contained in database, then load the last page.
                If (DbUtils.GetCreatedRecords(Me.DataSource).Length = 0 AndAlso Not Me.DisplayLastPage) Then
                      Me.DisplayLastPage = True
                      LoadData()
                Else
                
                    ' Add any new rows desired by the user.
                    Me.AddNewRecords()
                       

                    ' Initialize the page and grand totals. now
                
                End If
    
            Catch ex As Exception
                ' Report the error message to the end user
                Dim msg As String = ex.Message
                If ex.InnerException IsNot Nothing Then
                    msg = msg & " InnerException: " & ex.InnerException.Message
                End If
                Throw New Exception(msg, ex.InnerException)
            End Try
        End Sub
        
        Public Overridable Function GetRecords( _
            ByVal join As BaseFilter, _
            ByVal where As WhereClause, _
            ByVal orderBy As OrderBy, _
            ByVal pageIndex As Integer, _
            ByVal pageSize As Integer) As CommentsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(CommentsTable.Column1, True)         
            ' selCols.Add(CommentsTable.Column2, True)          
            ' selCols.Add(CommentsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return CommentsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New CommentsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(CommentsRecord)), CommentsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(CommentsTable.Column1, True)         
            ' selCols.Add(CommentsTable.Column2, True)          
            ' selCols.Add(CommentsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return CommentsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New CommentsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)           
                
                
                Return CInt(databaseTable.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
            End If

        End Function        
        
      
    
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record for each row in the table.  To do this, it calls the
            ' DataBind for each of the rows.
            ' DataBind also populates any filters above the table, and sets the pagination
            ' control to the correct number of records and the current page number.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If
            
            'LoadData for DataSource for chart and report if they exist
               
            ' Setup the pagination controls.
            BindPaginationControls()

      
        
          ' Bind the repeater with the list of records to expand the UI.
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetAgencyLabel()
                SetComment_DtLabel()
                SetComment_To_AgencyLabel()
                SetComment_TopicLabel()
                SetCommentLabel()
                
                SetCreated_ByLabel()
            ' setting the state of expand or collapse alternative rows
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
      
        Public Overridable Sub RegisterPostback()
        
        
        End Sub

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e as FormulaEvaluator) As String
            If e Is Nothing
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()
            
            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If
            
            If includeDS
                
            End If
            
            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            
            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function			

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function




        Public Overridable Sub ResetControl()
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(CommentsTable.Comment_ID, OrderByItem.OrderDir.Desc)
                  
            End If
                
            Me.PageIndex = 0
        End Sub

        Public Overridable Sub ResetPageControl()
            Me.PageIndex = 0
        End Sub
        
        Protected Overridable Sub BindPaginationControls()
            ' Setup the pagination controls.

            ' Bind the pagination labels.
        
            If DbUtils.GetCreatedRecords(Me.DataSource).Length > 0 Then                      
                    
                Me.CommentsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.CommentsPagination.CurrentPage.Text = "0"
            End If
            Me.CommentsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.CommentsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for CommentsTableControl pagination.
        
            Me.CommentsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.CommentsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As CommentsTableControlRow
            For Each recCtl In Me.GetRecordControls()
        
                If Me.InDeletedRecordIds(recCtl) Then
                    ' Delete any pending deletes. 
                    recCtl.Delete()
                Else
                    If recCtl.Visible Then
                        recCtl.SaveData()
                    End If
                End If
          
            Next
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
          
            ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
            For Each recCtl In Me.GetRecordControls()
                recCtl.IsNewRecord = False
            Next
    
      
            ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
            Me.DeletedRecordIds = Nothing
      
        End Sub

        Public Overridable Function CreateCompoundJoinFilter() As CompoundFilter
            Dim jFilter As CompoundFilter = New CompoundFilter()
         
            Return jFilter
        End Function

        
          Public Overridable Function CreateOrderBy() As OrderBy
          ' The CurrentSortOrder is initialized to the sort order on the
          ' Query Wizard.  It may be modified by the Click handler for any of
          ' the column heading to sort or reverse sort by that column.
          ' You can add your own sort order, or modify it on the Query Wizard.
          Return Me.CurrentSortOrder
          End Function
      
        Public Overridable Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            CommentsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
        Dim request_MasterRecordObj as KeyValue
        request_MasterRecordObj = Nothing
      
              Dim request_MasterTableControlObjRow As Request_MasterTableControlRow = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow") ,Request_MasterTableControlRow)
            
                If (Not IsNothing(request_MasterTableControlObjRow) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord()) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord().Request_Id))
                    wc.iAND(CommentsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterTableControlObjRow.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc                    
                End If
              
      HttpContext.Current.Session("CommentsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            CommentsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("CommentsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterTableControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterTableControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterTableControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(CommentsTable.Request_Id) Then
            wc.iAND(CommentsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(CommentsTable.Request_Id).ToString())
       End If
      
            End If
          
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
      
      
            Return wc
        End Function
          

         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function

        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                   
                    resultList.Add(itemToAdd)
          				
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    
        Protected Overridable Sub GetPageSize()
        
            If Me.CommentsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.CommentsPagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Sub AddNewRecords()
            
            Dim newRecordList As ArrayList = New ArrayList()
          
    Dim newUIDataList As System.Collections.Generic.List(Of Hashtable) = New System.Collections.Generic.List(Of Hashtable)()

    ' Loop though all the record controls and if the record control
    ' does not have a unique record id set, then create a record
    ' and add to the list.
    If Not Me.ResetData Then
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As CommentsRecord = New CommentsRecord()
        
                        If recControl.Agency.Text <> "" Then
                            rec.Parse(recControl.Agency.Text, CommentsTable.Agency)
                        End If
                        If recControl.Comment.Text <> "" Then
                            rec.Parse(recControl.Comment.Text, CommentsTable.Comment)
                        End If
                        If recControl.Comment_Dt.Text <> "" Then
                            rec.Parse(recControl.Comment_Dt.Text, CommentsTable.Comment_Dt)
                        End If
                        If recControl.Comment_To_Agency.Text <> "" Then
                            rec.Parse(recControl.Comment_To_Agency.Text, CommentsTable.Comment_To_Agency)
                        End If
                        If recControl.Comment_Topic.Text <> "" Then
                            rec.Parse(recControl.Comment_Topic.Text, CommentsTable.Comment_Topic)
                        End If
                        If recControl.Created_By.Text <> "" Then
                            rec.Parse(recControl.Created_By.Text, CommentsTable.Created_By)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New CommentsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(CommentsRecord)), CommentsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As CommentsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As CommentsTableControlRow) As Boolean
            If Me.DeletedRecordIds Is Nothing OrElse Me.DeletedRecordIds.Trim = "" Then
                Return False
            End If

            Return Me.DeletedRecordIds.IndexOf("[" & rec.RecordUniqueId & "]") >= 0
        End Function

        Private _DeletedRecordIds As String
        Public Property DeletedRecordIds() As String
            Get
                Return Me._DeletedRecordIds
            End Get
            Set(ByVal value As String)
                Me._DeletedRecordIds = value
            End Set
        End Property
        
      
        ' Create Set, WhereClause, and Populate Methods
        
        Public Overridable Sub SetAgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_To_AgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_To_AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_TopicLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_TopicLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCommentLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.CommentLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCreated_ByLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Created_ByLabel.Text = "Some value"
                    
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    
                    Me.LoadData()
                    Me.DataBind()
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
            ' Save table control properties to the session.
            If Not Me.CurrentSortOrder Is Nothing Then
            Me.SaveToSession(Me, "Order_By", Me.CurrentSortOrder.ToXmlString())
            End If
            
            Me.SaveToSession(Me, "Page_Index", Me.PageIndex.ToString())
            Me.SaveToSession(Me, "Page_Size", Me.PageSize.ToString())
        
            Me.SaveToSession(Me, "DeletedRecordIds", Me.DeletedRecordIds)  
        
        End Sub
        
        Protected  Sub SaveControlsToSession_Ajax()
            ' Save filter controls to values to session.
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("CommentsTableControl_OrderBy"), String)
            
            If orderByStr IsNot Nothing AndAlso orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            
            Else 
                Me.CurrentSortOrder = New OrderBy(True, False)
            
            End If
            
    Dim pageIndex As String = CType(ViewState("Page_Index"), String)
    If pageIndex IsNot Nothing Then
    Me.PageIndex = CInt(pageIndex)
    End If

    Dim pageSize As String = CType(ViewState("Page_Size"), String)
    If Not pageSize Is Nothing Then
    Me.PageSize = CInt(pageSize)
    End If

    
    
            ' Load view state for pagination control.
        
            Me.DeletedRecordIds = CType(Me.ViewState("DeletedRecordIds"), String)
        
        End Sub

        Protected Overrides Function SaveViewState() As Object
            
            If Me.CurrentSortOrder IsNot Nothing Then
                Me.ViewState("CommentsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex = 0
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.DisplayLastPage = True
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex += 1
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub CommentsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.CommentsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.CommentsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            If Me.PageIndex > 0 Then
                Me.PageIndex -= 1
                Me.DataChanged = True
            End If
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        

        ' Generate the event handling functions for sorting events.
        
        Public Overridable Sub AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Agency when clicked.
              
            ' Get previous sorting state for Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_Dt when clicked.
              
            ' Get previous sorting state for Comment_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_To_AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_To_Agency when clicked.
              
            ' Get previous sorting state for Comment_To_Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_To_Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_To_Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_To_Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_To_Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_TopicLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_Topic when clicked.
              
            ' Get previous sorting state for Comment_Topic.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_Topic)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_Topic.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_Topic, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_Topic, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub CommentLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment when clicked.
              
            ' Get previous sorting state for Comment.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Created_ByLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Created_By when clicked.
              
            ' Get previous sorting state for Created_By.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Created_By)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Created_By.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Created_By, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Created_By, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
      

        ' Generate the event handling functions for filter and search events.
        
    
        ' Generate the event handling functions for others
        
      
        Private _UIData As New System.Collections.Generic.List(Of Hashtable)
        Public Property UIData() As System.Collections.Generic.List(Of Hashtable)
            Get
                Return Me._UIData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of Hashtable))
                Me._UIData = value
            End Set
        End Property
        
        ' pagination properties
        Protected _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Protected _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Protected _TotalRecords As Integer = -1
        Public Property TotalRecords() As Integer
            Get
                If _TotalRecords < 0 
                    _TotalRecords = CommentsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
                End If
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                  
                End If
                Me._TotalRecords = value
            End Set
        End Property

        
    
        Protected _TotalPages As Integer = -1
        Public Property TotalPages() As Integer
            Get
                If _TotalPages < 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(TotalRecords / Me.PageSize))
                  
                End If                
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Protected _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property
        
        Private _ResetData As Boolean = False
        Public Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal value As Boolean)
                Me._ResetData = value
            End Set
        End Property

        Private _AddNewRecord As Integer = 0
        Public Property AddNewRecord() As Integer
            Get
                Return Me._AddNewRecord
            End Get
            Set(ByVal value As Integer)
                Me._AddNewRecord = value
            End Set
        End Property

        
        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property
        
        Public Property DataSource() As CommentsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, CommentsRecord())
            End Get
            Set(ByVal value() As CommentsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_To_AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_To_AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_TopicLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_TopicLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property Created_ByLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Created_ByLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"
        
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
      
      
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me,includeSession)
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As CommentsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As CommentsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            End If
            Return url
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As CommentsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As CommentsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                If includeSession then
                    Return EvaluateExpressions(url, arg, rec, bEncrypt)
                Else
                    Return EvaluateExpressions(url, arg, rec, bEncrypt,False)
                End If
            End If
            Return url
        End Function
        
          
        Public Overridable Function GetSelectedRecordControl() As CommentsTableControlRow
            Return Nothing
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As CommentsTableControlRow()
        
            Return DirectCast((new ArrayList()).ToArray(GetType(CommentsTableControlRow)), CommentsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As CommentsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As CommentsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                Else
                
                    recCtl.Delete()
                    
                    ' Setting the DataChanged to True results in the page being refreshed with
                    ' the most recent data from the database.  This happens in PreRender event
                    ' based on the current sort, search and filter criteria.
                    Me.DataChanged = True
                    Me.ResetData = True
                  
                End If
            Next
        End Sub

        Public Function GetRecordControls() As CommentsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(CommentsTableControlRow)), CommentsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the ContactsTableControlRow control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in ContactsTableControlRow.
Public Class BaseContactsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in ContactsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in ContactsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
                    
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Contacts record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = ContactsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseContactsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New ContactsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in ContactsTableControlRow.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetAddress()
                SetAgency1()
                SetCity()
                SetEmail()
                SetMobile()
                SetName()
                SetTitle()
                SetType0()
                SetWork_Phone()
                SetZip()
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
        End Sub
        
        
        Public Overridable Sub SetAddress()
            
        
            ' Set the Address Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Address is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAddress()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AddressSpecified Then
                				
                ' If the Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Address)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Address.Text = formattedValue
                
            Else 
            
                ' Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Address.Text = ContactsTable.Address.Format(ContactsTable.Address.DefaultValue)
                        		
                End If
                 
            ' If the Address is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Address.Text Is Nothing _
                OrElse Me.Address.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Address.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetAgency1()
            
        
            ' Set the Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Agency1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AgencySpecified Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Agency1.Text = formattedValue
                
            Else 
            
                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Agency1.Text = ContactsTable.Agency.Format(ContactsTable.Agency.DefaultValue)
                        		
                End If
                 
            ' If the Agency is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Agency1.Text Is Nothing _
                OrElse Me.Agency1.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Agency1.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetCity()
            
        
            ' Set the City Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.City is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCity()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CitySpecified Then
                				
                ' If the City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.City)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.City.Text = formattedValue
                
            Else 
            
                ' City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.City.Text = ContactsTable.City.Format(ContactsTable.City.DefaultValue)
                        		
                End If
                 
            ' If the City is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.City.Text Is Nothing _
                OrElse Me.City.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.City.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetEmail()
            
        
            ' Set the Email Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Email is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetEmail()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.EmailSpecified Then
                				
                ' If the Email is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Email)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Email.Text = formattedValue
                
            Else 
            
                ' Email is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Email.Text = ContactsTable.Email.Format(ContactsTable.Email.DefaultValue)
                        		
                End If
                 
            ' If the Email is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Email.Text Is Nothing _
                OrElse Me.Email.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Email.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetMobile()
            
        
            ' Set the Mobile Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Mobile is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetMobile()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.MobileSpecified Then
                				
                ' If the Mobile is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Mobile)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Mobile.Text = formattedValue
                
            Else 
            
                ' Mobile is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Mobile.Text = ContactsTable.Mobile.Format(ContactsTable.Mobile.DefaultValue)
                        		
                End If
                 
            ' If the Mobile is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Mobile.Text Is Nothing _
                OrElse Me.Mobile.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Mobile.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetName()
            
        
            ' Set the Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Name is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetName()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.NameSpecified Then
                				
                ' If the Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Name.Text = formattedValue
                
            Else 
            
                ' Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Name.Text = ContactsTable.Name.Format(ContactsTable.Name.DefaultValue)
                        		
                End If
                 
            ' If the Name is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Name.Text Is Nothing _
                OrElse Me.Name.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Name.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetTitle()
            
        
            ' Set the Title Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Title is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetTitle()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.TitleSpecified Then
                				
                ' If the Title is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Title)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Title.Text = formattedValue
                
            Else 
            
                ' Title is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Title.Text = ContactsTable.Title.Format(ContactsTable.Title.DefaultValue)
                        		
                End If
                 
            ' If the Title is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Title.Text Is Nothing _
                OrElse Me.Title.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Title.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetType0()
            
        
            ' Set the Type Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Type0 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetType0()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Type0Specified Then
                				
                ' If the Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Type0)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Type0.Text = formattedValue
                
            Else 
            
                ' Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Type0.Text = ContactsTable.Type0.Format(ContactsTable.Type0.DefaultValue)
                        		
                End If
                 
            ' If the Type is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Type0.Text Is Nothing _
                OrElse Me.Type0.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Type0.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetWork_Phone()
            
        
            ' Set the Work Phone Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Work_Phone is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetWork_Phone()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Work_PhoneSpecified Then
                				
                ' If the Work Phone is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Work_Phone)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Work_Phone.Text = formattedValue
                
            Else 
            
                ' Work Phone is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Work_Phone.Text = ContactsTable.Work_Phone.Format(ContactsTable.Work_Phone.DefaultValue)
                        		
                End If
                 
            ' If the Work Phone is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Work_Phone.Text Is Nothing _
                OrElse Me.Work_Phone.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Work_Phone.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetZip()
            
        
            ' Set the Zip Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Zip is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetZip()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ZipSpecified Then
                				
                ' If the Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Zip)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Zip.Text = formattedValue
                
            Else 
            
                ' Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Zip.Text = ContactsTable.Zip.Format(ContactsTable.Zip.DefaultValue)
                        		
                End If
                 
            ' If the Zip is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Zip.Text Is Nothing _
                OrElse Me.Zip.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Zip.Text = "&nbsp;"
            End If
                  
        End Sub
                

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function      
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in ContactsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterTableControlRow
          
          				  
          parentCtrl = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow"), Request_MasterTableControlRow)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
                DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in ContactsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetAddress()
            GetAgency1()
            GetCity()
            GetEmail()
            GetMobile()
            GetName()
            GetTitle()
            GetType0()
            GetWork_Phone()
            GetZip()
        End Sub
        
        
        Public Overridable Sub GetAddress()
            
        End Sub
                
        Public Overridable Sub GetAgency1()
            
        End Sub
                
        Public Overridable Sub GetCity()
            
        End Sub
                
        Public Overridable Sub GetEmail()
            
        End Sub
                
        Public Overridable Sub GetMobile()
            
        End Sub
                
        Public Overridable Sub GetName()
            
        End Sub
                
        Public Overridable Sub GetTitle()
            
        End Sub
                
        Public Overridable Sub GetType0()
            
        End Sub
                
        Public Overridable Sub GetWork_Phone()
            
        End Sub
                
        Public Overridable Sub GetZip()
            
        End Sub
                
      
        ' To customize, override this method in ContactsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in ContactsTableControlRow.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          ContactsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).ResetData = True
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                						
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseContactsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseContactsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As ContactsRecord
        Public Property DataSource() As ContactsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As ContactsRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property Address() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Address"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Agency1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property City() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "City"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Email() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Email"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Mobile() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Mobile"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Name() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Name"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Title() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Title"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Type0() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Type0"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Work_Phone() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Work_Phone"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Zip() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Zip"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As ContactsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As ContactsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As ContactsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return ContactsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the ContactsTableControl control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in ContactsTableControl.
Public Class BaseContactsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(ContactsTable.Contact_Id, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
            ' Setup the pagination events.
            
              AddHandler Me.ContactsPagination.FirstPage.Click, AddressOf ContactsPagination_FirstPage_Click
              
              AddHandler Me.ContactsPagination.LastPage.Click, AddressOf ContactsPagination_LastPage_Click
              
              AddHandler Me.ContactsPagination.NextPage.Click, AddressOf ContactsPagination_NextPage_Click
              
              AddHandler Me.ContactsPagination.PageSizeButton.Click, AddressOf ContactsPagination_PageSizeButton_Click
            
              AddHandler Me.ContactsPagination.PreviousPage.Click, AddressOf ContactsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.AddressLabel.Click, AddressOf AddressLabel_Click
            
              AddHandler Me.AgencyLabel2.Click, AddressOf AgencyLabel2_Click
            
              AddHandler Me.CityLabel.Click, AddressOf CityLabel_Click
            
              AddHandler Me.EmailLabel.Click, AddressOf EmailLabel_Click
            
              AddHandler Me.MobileLabel.Click, AddressOf MobileLabel_Click
            
              AddHandler Me.NameLabel.Click, AddressOf NameLabel_Click
            
              AddHandler Me.TitleLabel.Click, AddressOf TitleLabel_Click
            
              AddHandler Me.TypeLabel.Click, AddressOf TypeLabel_Click
            
              AddHandler Me.Work_PhoneLabel.Click, AddressOf Work_PhoneLabel_Click
            
              AddHandler Me.ZipLabel.Click, AddressOf ZipLabel_Click
            
            ' Setup the button events.
                  
        
          ' Setup events for others
            
        End Sub
        
        
        Public Overridable Sub LoadData()        
        
            ' Read data from database. Returns an array of records that can be assigned
            ' to the DataSource table control property.
            Try	
                Dim joinFilter As CompoundFilter = CreateCompoundJoinFilter()
                
                ' The WHERE clause will be empty when displaying all records in table.
                Dim wc As WhereClause = CreateWhereClause()
                If wc IsNot Nothing AndAlso Not wc.RunQuery Then
                    ' Initialize an empty array of records
                    Dim alist As New ArrayList(0)
                    Me.DataSource = DirectCast(alist.ToArray(GetType(ContactsRecord)), ContactsRecord())
                    ' Add records to the list if needed.
                    Me.AddNewRecords()
                    Me._TotalRecords = 0
                    Me._TotalPages = 0
                    Return
                End If

                ' Call OrderBy to determine the order - either use the order defined
                ' on the Query Wizard, or specified by user (by clicking on column heading)
                Dim orderBy As OrderBy = CreateOrderBy()
                
                ' Get the pagesize from the pagesize control.
                Me.GetPageSize()
                               
                If Me.DisplayLastPage Then
                    Dim totalRecords As Integer = If(Me._TotalRecords < 0, GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause()), Me._TotalRecords)
                     
                      Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / Me.PageSize))
                    
                    Me.PageIndex = totalPages - 1
                End If                               
                
                ' Make sure PageIndex (current page) and PageSize are within bounds.
                If Me.PageIndex < 0 Then
                    Me.PageIndex = 0
                End If
                If Me.PageSize < 1 Then
                    Me.PageSize = 1
                End If
                
                ' Retrieve the records and set the table DataSource.
                ' Only PageSize records are fetched starting at PageIndex (zero based).
                If Me.AddNewRecord > 0 Then
                ' Make sure to preserve the previously entered data on new rows.
                    Dim postdata As New ArrayList
                    For Each rc As ContactsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(ContactsRecord)), ContactsRecord())
                Else  ' Get the records from the database	
                        Me.DataSource = GetRecords(joinFilter, wc, orderBy, Me.PageIndex, Me.PageSize)
                      
                End If
                
                ' if the datasource contains no records contained in database, then load the last page.
                If (DbUtils.GetCreatedRecords(Me.DataSource).Length = 0 AndAlso Not Me.DisplayLastPage) Then
                      Me.DisplayLastPage = True
                      LoadData()
                Else
                
                    ' Add any new rows desired by the user.
                    Me.AddNewRecords()
                       

                    ' Initialize the page and grand totals. now
                
                End If
    
            Catch ex As Exception
                ' Report the error message to the end user
                Dim msg As String = ex.Message
                If ex.InnerException IsNot Nothing Then
                    msg = msg & " InnerException: " & ex.InnerException.Message
                End If
                Throw New Exception(msg, ex.InnerException)
            End Try
        End Sub
        
        Public Overridable Function GetRecords( _
            ByVal join As BaseFilter, _
            ByVal where As WhereClause, _
            ByVal orderBy As OrderBy, _
            ByVal pageIndex As Integer, _
            ByVal pageSize As Integer) As ContactsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(ContactsTable.Column1, True)         
            ' selCols.Add(ContactsTable.Column2, True)          
            ' selCols.Add(ContactsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return ContactsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New ContactsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(ContactsRecord)), ContactsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(ContactsTable.Column1, True)         
            ' selCols.Add(ContactsTable.Column2, True)          
            ' selCols.Add(ContactsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return ContactsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New ContactsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)           
                
                
                Return CInt(databaseTable.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
            End If

        End Function        
        
      
    
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record for each row in the table.  To do this, it calls the
            ' DataBind for each of the rows.
            ' DataBind also populates any filters above the table, and sets the pagination
            ' control to the correct number of records and the current page number.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If
            
            'LoadData for DataSource for chart and report if they exist
               
            ' Setup the pagination controls.
            BindPaginationControls()

      
        
          ' Bind the repeater with the list of records to expand the UI.
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetAddressLabel()
                SetAgencyLabel2()
                SetCityLabel()
                
                SetEmailLabel()
                SetMobileLabel()
                SetNameLabel()
                SetTitleLabel()
                SetTypeLabel()
                SetWork_PhoneLabel()
                SetZipLabel()
            ' setting the state of expand or collapse alternative rows
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
      
        Public Overridable Sub RegisterPostback()
        
        
        End Sub

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e as FormulaEvaluator) As String
            If e Is Nothing
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()
            
            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If
            
            If includeDS
                
            End If
            
            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            
            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function			

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function




        Public Overridable Sub ResetControl()
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(ContactsTable.Contact_Id, OrderByItem.OrderDir.Asc)
                  
            End If
                
            Me.PageIndex = 0
        End Sub

        Public Overridable Sub ResetPageControl()
            Me.PageIndex = 0
        End Sub
        
        Protected Overridable Sub BindPaginationControls()
            ' Setup the pagination controls.

            ' Bind the pagination labels.
        
            If DbUtils.GetCreatedRecords(Me.DataSource).Length > 0 Then                      
                    
                Me.ContactsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.ContactsPagination.CurrentPage.Text = "0"
            End If
            Me.ContactsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.ContactsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for ContactsTableControl pagination.
        
            Me.ContactsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.ContactsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As ContactsTableControlRow
            For Each recCtl In Me.GetRecordControls()
        
                If Me.InDeletedRecordIds(recCtl) Then
                    ' Delete any pending deletes. 
                    recCtl.Delete()
                Else
                    If recCtl.Visible Then
                        recCtl.SaveData()
                    End If
                End If
          
            Next
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
          
            ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
            For Each recCtl In Me.GetRecordControls()
                recCtl.IsNewRecord = False
            Next
    
      
            ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
            Me.DeletedRecordIds = Nothing
      
        End Sub

        Public Overridable Function CreateCompoundJoinFilter() As CompoundFilter
            Dim jFilter As CompoundFilter = New CompoundFilter()
         
            Return jFilter
        End Function

        
          Public Overridable Function CreateOrderBy() As OrderBy
          ' The CurrentSortOrder is initialized to the sort order on the
          ' Query Wizard.  It may be modified by the Click handler for any of
          ' the column heading to sort or reverse sort by that column.
          ' You can add your own sort order, or modify it on the Query Wizard.
          Return Me.CurrentSortOrder
          End Function
      
        Public Overridable Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            ContactsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
        Dim request_MasterRecordObj as KeyValue
        request_MasterRecordObj = Nothing
      
              Dim request_MasterTableControlObjRow As Request_MasterTableControlRow = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow") ,Request_MasterTableControlRow)
            
                If (Not IsNothing(request_MasterTableControlObjRow) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord()) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord().Request_Id))
                    wc.iAND(ContactsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterTableControlObjRow.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc                    
                End If
              
      HttpContext.Current.Session("ContactsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            ContactsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("ContactsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterTableControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterTableControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterTableControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(ContactsTable.Request_Id) Then
            wc.iAND(ContactsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(ContactsTable.Request_Id).ToString())
       End If
      
            End If
          
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
      
      
            Return wc
        End Function
          

         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function

        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                   
                    resultList.Add(itemToAdd)
          				
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    
        Protected Overridable Sub GetPageSize()
        
            If Me.ContactsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.ContactsPagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Sub AddNewRecords()
            
            Dim newRecordList As ArrayList = New ArrayList()
          
    Dim newUIDataList As System.Collections.Generic.List(Of Hashtable) = New System.Collections.Generic.List(Of Hashtable)()

    ' Loop though all the record controls and if the record control
    ' does not have a unique record id set, then create a record
    ' and add to the list.
    If Not Me.ResetData Then
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As ContactsRecord = New ContactsRecord()
        
                        If recControl.Address.Text <> "" Then
                            rec.Parse(recControl.Address.Text, ContactsTable.Address)
                        End If
                        If recControl.Agency1.Text <> "" Then
                            rec.Parse(recControl.Agency1.Text, ContactsTable.Agency)
                        End If
                        If recControl.City.Text <> "" Then
                            rec.Parse(recControl.City.Text, ContactsTable.City)
                        End If
                        If recControl.Email.Text <> "" Then
                            rec.Parse(recControl.Email.Text, ContactsTable.Email)
                        End If
                        If recControl.Mobile.Text <> "" Then
                            rec.Parse(recControl.Mobile.Text, ContactsTable.Mobile)
                        End If
                        If recControl.Name.Text <> "" Then
                            rec.Parse(recControl.Name.Text, ContactsTable.Name)
                        End If
                        If recControl.Title.Text <> "" Then
                            rec.Parse(recControl.Title.Text, ContactsTable.Title)
                        End If
                        If recControl.Type0.Text <> "" Then
                            rec.Parse(recControl.Type0.Text, ContactsTable.Type0)
                        End If
                        If recControl.Work_Phone.Text <> "" Then
                            rec.Parse(recControl.Work_Phone.Text, ContactsTable.Work_Phone)
                        End If
                        If recControl.Zip.Text <> "" Then
                            rec.Parse(recControl.Zip.Text, ContactsTable.Zip)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New ContactsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(ContactsRecord)), ContactsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As ContactsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As ContactsTableControlRow) As Boolean
            If Me.DeletedRecordIds Is Nothing OrElse Me.DeletedRecordIds.Trim = "" Then
                Return False
            End If

            Return Me.DeletedRecordIds.IndexOf("[" & rec.RecordUniqueId & "]") >= 0
        End Function

        Private _DeletedRecordIds As String
        Public Property DeletedRecordIds() As String
            Get
                Return Me._DeletedRecordIds
            End Get
            Set(ByVal value As String)
                Me._DeletedRecordIds = value
            End Set
        End Property
        
      
        ' Create Set, WhereClause, and Populate Methods
        
        Public Overridable Sub SetAddressLabel()
                  
                  End Sub
                
        Public Overridable Sub SetAgencyLabel2()
                  
                  End Sub
                
        Public Overridable Sub SetCityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetEmailLabel()
                  
                  End Sub
                
        Public Overridable Sub SetMobileLabel()
                  
                  End Sub
                
        Public Overridable Sub SetNameLabel()
                  
                  End Sub
                
        Public Overridable Sub SetTitleLabel()
                  
                  End Sub
                
        Public Overridable Sub SetTypeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetWork_PhoneLabel()
                  
                  End Sub
                
        Public Overridable Sub SetZipLabel()
                  
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    
                    Me.LoadData()
                    Me.DataBind()
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
            ' Save table control properties to the session.
            If Not Me.CurrentSortOrder Is Nothing Then
            Me.SaveToSession(Me, "Order_By", Me.CurrentSortOrder.ToXmlString())
            End If
            
            Me.SaveToSession(Me, "Page_Index", Me.PageIndex.ToString())
            Me.SaveToSession(Me, "Page_Size", Me.PageSize.ToString())
        
            Me.SaveToSession(Me, "DeletedRecordIds", Me.DeletedRecordIds)  
        
        End Sub
        
        Protected  Sub SaveControlsToSession_Ajax()
            ' Save filter controls to values to session.
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("ContactsTableControl_OrderBy"), String)
            
            If orderByStr IsNot Nothing AndAlso orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            
            Else 
                Me.CurrentSortOrder = New OrderBy(True, False)
            
            End If
            
    Dim pageIndex As String = CType(ViewState("Page_Index"), String)
    If pageIndex IsNot Nothing Then
    Me.PageIndex = CInt(pageIndex)
    End If

    Dim pageSize As String = CType(ViewState("Page_Size"), String)
    If Not pageSize Is Nothing Then
    Me.PageSize = CInt(pageSize)
    End If

    
    
            ' Load view state for pagination control.
        
            Me.DeletedRecordIds = CType(Me.ViewState("DeletedRecordIds"), String)
        
        End Sub

        Protected Overrides Function SaveViewState() As Object
            
            If Me.CurrentSortOrder IsNot Nothing Then
                Me.ViewState("ContactsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex = 0
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.DisplayLastPage = True
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex += 1
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub ContactsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.ContactsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.ContactsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            If Me.PageIndex > 0 Then
                Me.PageIndex -= 1
                Me.DataChanged = True
            End If
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        

        ' Generate the event handling functions for sorting events.
        
        Public Overridable Sub AddressLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Address when clicked.
              
            ' Get previous sorting state for Address.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Address)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Address.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Address, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Address, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub AgencyLabel2_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Agency when clicked.
              
            ' Get previous sorting state for Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub CityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by City when clicked.
              
            ' Get previous sorting state for City.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.City)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for City.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.City, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by City, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub EmailLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Email when clicked.
              
            ' Get previous sorting state for Email.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Email)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Email.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Email, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Email, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub MobileLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Mobile when clicked.
              
            ' Get previous sorting state for Mobile.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Mobile)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Mobile.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Mobile, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Mobile, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub NameLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Name when clicked.
              
            ' Get previous sorting state for Name.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub TitleLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Title when clicked.
              
            ' Get previous sorting state for Title.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Title)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Title.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Title, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Title, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub TypeLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Type when clicked.
              
            ' Get previous sorting state for Type.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Type0)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Type.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Type0, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Type, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Work_PhoneLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Work Phone when clicked.
              
            ' Get previous sorting state for Work Phone.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Work_Phone)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Work Phone.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Work_Phone, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Work Phone, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub ZipLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Zip when clicked.
              
            ' Get previous sorting state for Zip.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Zip)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Zip.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Zip, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Zip, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
      

        ' Generate the event handling functions for filter and search events.
        
    
        ' Generate the event handling functions for others
        
      
        Private _UIData As New System.Collections.Generic.List(Of Hashtable)
        Public Property UIData() As System.Collections.Generic.List(Of Hashtable)
            Get
                Return Me._UIData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of Hashtable))
                Me._UIData = value
            End Set
        End Property
        
        ' pagination properties
        Protected _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Protected _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Protected _TotalRecords As Integer = -1
        Public Property TotalRecords() As Integer
            Get
                If _TotalRecords < 0 
                    _TotalRecords = ContactsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
                End If
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                  
                End If
                Me._TotalRecords = value
            End Set
        End Property

        
    
        Protected _TotalPages As Integer = -1
        Public Property TotalPages() As Integer
            Get
                If _TotalPages < 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(TotalRecords / Me.PageSize))
                  
                End If                
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Protected _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property
        
        Private _ResetData As Boolean = False
        Public Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal value As Boolean)
                Me._ResetData = value
            End Set
        End Property

        Private _AddNewRecord As Integer = 0
        Public Property AddNewRecord() As Integer
            Get
                Return Me._AddNewRecord
            End Get
            Set(ByVal value As Integer)
                Me._AddNewRecord = value
            End Set
        End Property

        
        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property
        
        Public Property DataSource() As ContactsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, ContactsRecord())
            End Get
            Set(ByVal value() As ContactsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property AddressLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AddressLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property AgencyLabel2() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AgencyLabel2"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property EmailLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "EmailLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property MobileLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "MobileLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property NameLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "NameLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property TitleLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TitleLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property TypeLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TypeLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Work_PhoneLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Work_PhoneLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ZipLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ZipLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"
        
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
      
      
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me,includeSession)
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As ContactsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As ContactsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            End If
            Return url
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As ContactsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As ContactsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                If includeSession then
                    Return EvaluateExpressions(url, arg, rec, bEncrypt)
                Else
                    Return EvaluateExpressions(url, arg, rec, bEncrypt,False)
                End If
            End If
            Return url
        End Function
        
          
        Public Overridable Function GetSelectedRecordControl() As ContactsTableControlRow
            Return Nothing
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As ContactsTableControlRow()
        
            Return DirectCast((new ArrayList()).ToArray(GetType(ContactsTableControlRow)), ContactsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As ContactsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As ContactsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                Else
                
                    recCtl.Delete()
                    
                    ' Setting the DataChanged to True results in the page being refreshed with
                    ' the most recent data from the database.  This happens in PreRender event
                    ' based on the current sort, search and filter criteria.
                    Me.DataChanged = True
                    Me.ResetData = True
                  
                End If
            Next
        End Sub

        Public Function GetRecordControls() As ContactsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(ContactsTableControlRow)), ContactsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the Request_MasterTableControlRow control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in Request_MasterTableControlRow.
Public Class BaseRequest_MasterTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in Request_MasterTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in Request_MasterTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
        
              ' Show confirmation message on Click
              Me.Request_MasterRowDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteRecordConfirm", "IROC2") & """));")
                  
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.Request_MasterRowDeleteButton.Click, AddressOf Request_MasterRowDeleteButton_Click
              
              AddHandler Me.Request_MasterRowEditButton.Click, AddressOf Request_MasterRowEditButton_Click
              
              AddHandler Me.Request_MasterRowExpandCollapseRowButton.Click, AddressOf Request_MasterRowExpandCollapseRowButton_Click
              
              AddHandler Me.Request_MasterRowFullEditButton.Click, AddressOf Request_MasterRowFullEditButton_Click
              
              AddHandler Me.Request_MasterRowViewButton.Click, AddressOf Request_MasterRowViewButton_Click
              
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Request_Master record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = Request_MasterTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseRequest_MasterTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New Request_MasterRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in Request_MasterTableControlRow.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                
                
                
                
                SetIROC_Id()
                SetLRole()
                SetPending_Action_Needed()
                SetPending_Agency()
                SetProv_Name()
                SetReg_Type()
                SetReq_Address()
                SetReq_City()
                SetReq_Completed_Dt()
                SetReq_Dt()
                SetReq_Enity2()
                SetReq_Island()
                SetReq_Site_Name()
                SetReq_Status()
                SetReq_Target_Dt()
                SetReq_Zip()
                
                
                
                
                
                
                
                
                SetUserEntity()
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "CommentsTableControl"), CommentsTableControl)
                    
        recCommentsTableControl.LoadData()
        recCommentsTableControl.DataBind()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "ContactsTableControl"), ContactsTableControl)
                    
        recContactsTableControl.LoadData()
        recContactsTableControl.DataBind()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "UploadsTableControl"), UploadsTableControl)
                    
        recUploadsTableControl.LoadData()
        recUploadsTableControl.DataBind()
        
        End Sub
        
        
        Public Overridable Sub SetIROC_Id()
            
        
            ' Set the IROC_Id Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IROC_IdSpecified Then
                				
                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.IROC_Id)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.IROC_Id.Text = formattedValue
                
            Else 
            
                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IROC_Id.Text = Request_MasterTable.IROC_Id.Format(Request_MasterTable.IROC_Id.DefaultValue)
                        		
                End If
                 
            ' If the IROC_Id is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.IROC_Id.Text Is Nothing _
                OrElse Me.IROC_Id.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.IROC_Id.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Action_Needed()
            
        
            ' Set the Pending_Action_Needed Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Needed is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Action_NeededSpecified Then
                				
                ' If the Pending_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Needed)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Needed.Text = Request_MasterTable.Pending_Action_Needed.Format(Request_MasterTable.Pending_Action_Needed.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Action_Needed is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Action_Needed.Text Is Nothing _
                OrElse Me.Pending_Action_Needed.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Action_Needed.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Agency()
            
        
            ' Set the Pending_Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_AgencySpecified Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Agency.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency.Text = Request_MasterTable.Pending_Agency.Format(Request_MasterTable.Pending_Agency.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Agency is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Agency.Text Is Nothing _
                OrElse Me.Pending_Agency.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Agency.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetProv_Name()
            
        
            ' Set the Prov_Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Prov_Name is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetProv_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Prov_NameSpecified Then
                				
                ' If the Prov_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Prov_Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Prov_Name.Text = formattedValue
                
            Else 
            
                ' Prov_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Prov_Name.Text = Request_MasterTable.Prov_Name.Format(Request_MasterTable.Prov_Name.DefaultValue)
                        		
                End If
                 
            ' If the Prov_Name is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Prov_Name.Text Is Nothing _
                OrElse Me.Prov_Name.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Prov_Name.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReg_Type()
            
        
            ' Set the Reg_Type Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Reg_Type.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Reg_Type.Text = Request_MasterTable.Reg_Type.Format(Request_MasterTable.Reg_Type.DefaultValue)
                        		
                End If
                 
            ' If the Reg_Type is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Reg_Type.Text Is Nothing _
                OrElse Me.Reg_Type.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Reg_Type.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Address()
            
        
            ' Set the Req_Address Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Address is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Address()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_AddressSpecified Then
                				
                ' If the Req_Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Address)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Address.Text = formattedValue
                
            Else 
            
                ' Req_Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Address.Text = Request_MasterTable.Req_Address.Format(Request_MasterTable.Req_Address.DefaultValue)
                        		
                End If
                 
            ' If the Req_Address is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Address.Text Is Nothing _
                OrElse Me.Req_Address.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Address.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_City()
            
        
            ' Set the Req_City Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_City is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_City()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CitySpecified Then
                				
                ' If the Req_City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_City)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_City.Text = formattedValue
                
            Else 
            
                ' Req_City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_City.Text = Request_MasterTable.Req_City.Format(Request_MasterTable.Req_City.DefaultValue)
                        		
                End If
                 
            ' If the Req_City is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_City.Text Is Nothing _
                OrElse Me.Req_City.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_City.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Completed_Dt()
            
        
            ' Set the Req_Completed_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Completed_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Completed_DtSpecified Then
                				
                ' If the Req_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Completed_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Completed_Dt.Text = Request_MasterTable.Req_Completed_Dt.Format(Request_MasterTable.Req_Completed_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the Req_Completed_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Completed_Dt.Text Is Nothing _
                OrElse Me.Req_Completed_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Completed_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Dt()
            
        
            ' Set the Req_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = EvaluateFormula("Format(Req_Dt, ""MM/DD/YYYY"")", Me.DataSource, "d")
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt.Text = Request_MasterTable.Req_Dt.Format(Request_MasterTable.Req_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the Req_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Dt.Text Is Nothing _
                OrElse Me.Req_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Enity2()
            
        
            ' Set the Req_Enity2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity2 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Enity2Specified Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Enity2.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity2.Text = Request_MasterTable.Req_Enity2.Format(Request_MasterTable.Req_Enity2.DefaultValue)
                        		
                End If
                 
            ' If the Req_Enity2 is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Enity2.Text Is Nothing _
                OrElse Me.Req_Enity2.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Enity2.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Island()
            
        
            ' Set the Req_Island Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Island is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Island()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_IslandSpecified Then
                				
                ' If the Req_Island is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Island)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Island.Text = formattedValue
                
            Else 
            
                ' Req_Island is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Island.Text = Request_MasterTable.Req_Island.Format(Request_MasterTable.Req_Island.DefaultValue)
                        		
                End If
                 
            ' If the Req_Island is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Island.Text Is Nothing _
                OrElse Me.Req_Island.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Island.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Site_Name()
            
        
            ' Set the Req_Site_Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Site_Name is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Site_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Site_NameSpecified Then
                				
                ' If the Req_Site_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Site_Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Site_Name.Text = formattedValue
                
            Else 
            
                ' Req_Site_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Site_Name.Text = Request_MasterTable.Req_Site_Name.Format(Request_MasterTable.Req_Site_Name.DefaultValue)
                        		
                End If
                 
            ' If the Req_Site_Name is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Site_Name.Text Is Nothing _
                OrElse Me.Req_Site_Name.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Site_Name.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Status()
            
        
            ' Set the Req_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Status is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StatusSpecified Then
                				
                ' If the Req_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Status.Text = formattedValue
                
            Else 
            
                ' Req_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Status.Text = Request_MasterTable.Req_Status.Format(Request_MasterTable.Req_Status.DefaultValue)
                        		
                End If
                 
            ' If the Req_Status is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Status.Text Is Nothing _
                OrElse Me.Req_Status.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Status.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Target_Dt()
            
        
            ' Set the Req_Target_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Target_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Target_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Target_DtSpecified Then
                				
                ' If the Req_Target_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Target_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Target_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Target_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Target_Dt.Text = Request_MasterTable.Req_Target_Dt.Format(Request_MasterTable.Req_Target_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the Req_Target_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Target_Dt.Text Is Nothing _
                OrElse Me.Req_Target_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Target_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Zip()
            
        
            ' Set the Req_Zip Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Zip is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Zip()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_ZipSpecified Then
                				
                ' If the Req_Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Zip)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Zip.Text = formattedValue
                
            Else 
            
                ' Req_Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Zip.Text = Request_MasterTable.Req_Zip.Format(Request_MasterTable.Req_Zip.DefaultValue)
                        		
                End If
                 
            ' If the Req_Zip is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Zip.Text Is Nothing _
                OrElse Me.Req_Zip.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Zip.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetLRole()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.LRole.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUserEntity()
                  
                      Me.UserEntity.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")")
                    
                  End Sub
                

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function      
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in Request_MasterTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
                DirectCast(GetParentControlObject(Me, "Request_MasterTableControl"), Request_MasterTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "Request_MasterTableControl"), Request_MasterTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "CommentsTableControl"), CommentsTableControl)
        recCommentsTableControl.SaveData()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "ContactsTableControl"), ContactsTableControl)
        recContactsTableControl.SaveData()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me, "UploadsTableControl"), UploadsTableControl)
        recUploadsTableControl.SaveData()
        
        End Sub

        ' To customize, override this method in Request_MasterTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetIROC_Id()
            GetPending_Action_Needed()
            GetPending_Agency()
            GetProv_Name()
            GetReg_Type()
            GetReq_Address()
            GetReq_City()
            GetReq_Completed_Dt()
            GetReq_Dt()
            GetReq_Enity2()
            GetReq_Island()
            GetReq_Site_Name()
            GetReq_Status()
            GetReq_Target_Dt()
            GetReq_Zip()
        End Sub
        
        
        Public Overridable Sub GetIROC_Id()
            
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed()
            
        End Sub
                
        Public Overridable Sub GetPending_Agency()
            
        End Sub
                
        Public Overridable Sub GetProv_Name()
            
        End Sub
                
        Public Overridable Sub GetReg_Type()
            
        End Sub
                
        Public Overridable Sub GetReq_Address()
            
        End Sub
                
        Public Overridable Sub GetReq_City()
            
        End Sub
                
        Public Overridable Sub GetReq_Completed_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Enity2()
            
        End Sub
                
        Public Overridable Sub GetReq_Island()
            
        End Sub
                
        Public Overridable Sub GetReq_Site_Name()
            
        End Sub
                
        Public Overridable Sub GetReq_Status()
            
        End Sub
                
        Public Overridable Sub GetReq_Target_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Zip()
            
        End Sub
                
      
        ' To customize, override this method in Request_MasterTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in Request_MasterTableControlRow.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          Request_MasterTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "Request_MasterTableControl"), Request_MasterTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "Request_MasterTableControl"), Request_MasterTableControl).ResetData = True
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                
			Me.Page.Authorize(Ctype(Request_MasterRowDeleteButton, Control), "1")
					
			Me.Page.Authorize(Ctype(Request_MasterRowFullEditButton, Control), "1")
					
			Me.Page.Authorize(Ctype(Me.FindControl("Request_MasterTabContainer"), Control), "1;4")
											
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                  Me.Delete()
              
            End If
      Me.Page.CommitTransaction(sender)
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Edit-Request-Master.aspx?Request_Master={Request_MasterTableControlRow:FV:Request_Id}&Agency={Request_MasterTableControlRow:FV:Pending_Agency}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If              
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterRowExpandCollapseRowButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
          Dim panelControl as Request_MasterTableControl = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControl"), Request_MasterTableControl)

          Dim repeatedRows() as Request_MasterTableControlRow = panelControl.GetRecordControls()
          For Each repeatedRow as Request_MasterTableControlRow in repeatedRows
              Dim altRow as System.Web.UI.Control= DirectCast(MiscUtils.FindControlRecursively(repeatedRow, "Request_MasterTableControlAltRow"), System.Web.UI.Control)
              If (altRow IsNot Nothing) Then
                  If (sender Is repeatedRow.Request_MasterRowExpandCollapseRowButton) Then
                      altRow.Visible = Not altRow.Visible
                  
                  End If                      
                  If (altRow.Visible) Then        
                   
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow.gif"
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over.gif'")
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow.gif'")
                                     
                  Else
                   
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow2.gif"
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over2.gif'")
                     repeatedRow.Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow2.gif'")
                   
                  End If
              Else
                  Me.Page.Response.Redirect("../Shared/ConfigureCollapseExpandRowBtn.aspx")
              End If
          Next
          
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterRowFullEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Full-Edit-Request-Master.aspx?Request_Master={Request_MasterTableControlRow:FV:Request_Id}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If              
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterRowViewButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Show-Request-Master.aspx?Request_Master={Request_MasterTableControlRow:FV:Request_Id}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If              
        End Sub
        
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseRequest_MasterTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseRequest_MasterTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As Request_MasterRecord
        Public Property DataSource() As Request_MasterRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As Request_MasterRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property CommentsTableControl() As CommentsTableControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTableControl"), CommentsTableControl)
            End Get
        End Property
        
        Public ReadOnly Property ContactsTableControl() As ContactsTableControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsTableControl"), ContactsTableControl)
            End Get
        End Property
        
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LRole() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LRole"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Needed() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Agency() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Prov_Name() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_Name"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Reg_Type() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_Type"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Address() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Address"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_City() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_City"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Completed_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Enity2() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Island() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Site_Name() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_Name"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Status() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Status"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Target_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Zip() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Zip"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Request_MasterRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterRowEditButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterRowExpandCollapseRowButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterRowExpandCollapseRowButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterRowFullEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterRowFullEditButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterRowViewButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterRowViewButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsTableControl() As UploadsTableControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTableControl"), UploadsTableControl)
            End Get
        End Property
        
        Public ReadOnly Property UserEntity() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UserEntity"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As Request_MasterRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As Request_MasterRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As Request_MasterRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return Request_MasterTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Throw New Exception(Page.GetResourceValue("Err:RetrieveRec", "IROC2"))
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the Request_MasterTableControl control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in Request_MasterTableControl.
Public Class BaseRequest_MasterTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Pending_AgencyFilter) 				
                    initialVal = Me.GetFromSession(Me.Pending_AgencyFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""Pending_Agency"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Pending_AgencyFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Pending_AgencyFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Pending_AgencyFilter.Items.Add(item)
                                Me.Pending_AgencyFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Pending_AgencyFilter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Prov_NameFilter) 				
                    initialVal = Me.GetFromSession(Me.Prov_NameFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""Prov_Name"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Prov_NameFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Prov_NameFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Prov_NameFilter.Items.Add(item)
                                Me.Prov_NameFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Prov_NameFilter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Reg_TypeFilter) 				
                    initialVal = Me.GetFromSession(Me.Reg_TypeFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Entity"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Reg_TypeFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Reg_TypeFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Reg_TypeFilter.Items.Add(item)
                                Me.Reg_TypeFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Reg_TypeFilter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Req_Enity2Filter) 				
                    initialVal = Me.GetFromSession(Me.Req_Enity2Filter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""Req_Enity2"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Req_Enity2FilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Req_Enity2FilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Req_Enity2Filter.Items.Add(item)
                                Me.Req_Enity2Filter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Req_Enity2Filter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Req_StatusFilter) 				
                    initialVal = Me.GetFromSession(Me.Req_StatusFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("""Active""")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Req_StatusFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Req_StatusFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Req_StatusFilter.Items.Add(item)
                                Me.Req_StatusFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Req_StatusFilter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Request_MasterSearch) 				
                    initialVal = Me.GetFromSession(Me.Request_MasterSearch)
                
              End If
              
                If initialVal <> ""				
                        
                        Me.Request_MasterSearch.Text = initialVal
                            
                    End If
                
            End If
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(Request_MasterTable.Request_Id, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "20"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
            ' Setup the pagination events.
            
              AddHandler Me.Request_MasterPagination.FirstPage.Click, AddressOf Request_MasterPagination_FirstPage_Click
              
              AddHandler Me.Request_MasterPagination.LastPage.Click, AddressOf Request_MasterPagination_LastPage_Click
              
              AddHandler Me.Request_MasterPagination.NextPage.Click, AddressOf Request_MasterPagination_NextPage_Click
              
              AddHandler Me.Request_MasterPagination.PageSizeButton.Click, AddressOf Request_MasterPagination_PageSizeButton_Click
            
              AddHandler Me.Request_MasterPagination.PreviousPage.Click, AddressOf Request_MasterPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.IROC_IdLabel.Click, AddressOf IROC_IdLabel_Click
            
              AddHandler Me.Pending_Action_NeededLabel.Click, AddressOf Pending_Action_NeededLabel_Click
            
              AddHandler Me.Pending_AgencyLabel.Click, AddressOf Pending_AgencyLabel_Click
            
              AddHandler Me.Prov_NameLabel1.Click, AddressOf Prov_NameLabel1_Click
            
              AddHandler Me.Reg_TypeLabel.Click, AddressOf Reg_TypeLabel_Click
            
              AddHandler Me.Req_AddressLabel.Click, AddressOf Req_AddressLabel_Click
            
              AddHandler Me.Req_CityLabel.Click, AddressOf Req_CityLabel_Click
            
              AddHandler Me.Req_Completed_DtLabel.Click, AddressOf Req_Completed_DtLabel_Click
            
              AddHandler Me.Req_DtLabel.Click, AddressOf Req_DtLabel_Click
            
              AddHandler Me.Req_EnityLabel.Click, AddressOf Req_EnityLabel_Click
            
              AddHandler Me.Req_IslandLabel.Click, AddressOf Req_IslandLabel_Click
            
              AddHandler Me.Req_Site_NameLabel.Click, AddressOf Req_Site_NameLabel_Click
            
              AddHandler Me.Req_StatusLabel.Click, AddressOf Req_StatusLabel_Click
            
              AddHandler Me.Req_Target_DtLabel.Click, AddressOf Req_Target_DtLabel_Click
            
              AddHandler Me.Req_ZipLabel.Click, AddressOf Req_ZipLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.Request_MasterExportExcelButton.Click, AddressOf Request_MasterExportExcelButton_Click
              
              AddHandler Me.Request_MasterNewButton.Click, AddressOf Request_MasterNewButton_Click
              
              AddHandler Me.Request_MasterPDFButton.Click, AddressOf Request_MasterPDFButton_Click
              
              AddHandler Me.Request_MasterResetButton.Click, AddressOf Request_MasterResetButton_Click
              
              AddHandler Me.Request_MasterWordButton.Click, AddressOf Request_MasterWordButton_Click
              
            AddHandler Me.Request_MasterSearchButton.Button.Click, AddressOf Request_MasterSearchButton_Click
        
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Pending_AgencyFilter.PostBackUrl = url & "?Target=" & Me.Pending_AgencyFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Pending_Agency")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Pending_AgencyFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Pending_AgencyFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Pending_AgencyFilter.SelectedIndexChanged, AddressOf Pending_AgencyFilter_SelectedIndexChanged                  
                
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Prov_NameFilter.PostBackUrl = url & "?Target=" & Me.Prov_NameFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Prov_Name")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Prov_NameFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Prov_NameFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Prov_NameFilter.SelectedIndexChanged, AddressOf Prov_NameFilter_SelectedIndexChanged                  
                
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Reg_TypeFilter.PostBackUrl = url & "?Target=" & Me.Reg_TypeFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Reg_Type")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Reg_TypeFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Reg_TypeFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Reg_TypeFilter.SelectedIndexChanged, AddressOf Reg_TypeFilter_SelectedIndexChanged                  
                
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Req_Enity2Filter.PostBackUrl = url & "?Target=" & Me.Req_Enity2Filter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Enity2")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Req_Enity2Filter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Req_Enity2Filter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Req_Enity2Filter.SelectedIndexChanged, AddressOf Req_Enity2Filter_SelectedIndexChanged                  
                
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Req_StatusFilter.PostBackUrl = url & "?Target=" & Me.Req_StatusFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Status")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Req_StatusFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Req_StatusFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Req_StatusFilter.SelectedIndexChanged, AddressOf Req_StatusFilter_SelectedIndexChanged                  
                        
        
          ' Setup events for others
            
        End Sub
        
        
        Public Overridable Sub LoadData()        
        
            ' Read data from database. Returns an array of records that can be assigned
            ' to the DataSource table control property.
            Try	
                Dim joinFilter As CompoundFilter = CreateCompoundJoinFilter()
                
                ' The WHERE clause will be empty when displaying all records in table.
                Dim wc As WhereClause = CreateWhereClause()
                If wc IsNot Nothing AndAlso Not wc.RunQuery Then
                    ' Initialize an empty array of records
                    Dim alist As New ArrayList(0)
                    Me.DataSource = DirectCast(alist.ToArray(GetType(Request_MasterRecord)), Request_MasterRecord())
                    ' Add records to the list if needed.
                    Me.AddNewRecords()
                    Me._TotalRecords = 0
                    Me._TotalPages = 0
                    Return
                End If

                ' Call OrderBy to determine the order - either use the order defined
                ' on the Query Wizard, or specified by user (by clicking on column heading)
                Dim orderBy As OrderBy = CreateOrderBy()
                
                ' Get the pagesize from the pagesize control.
                Me.GetPageSize()
                               
                If Me.DisplayLastPage Then
                    Dim totalRecords As Integer = If(Me._TotalRecords < 0, GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause()), Me._TotalRecords)
                     
                      Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / Me.PageSize))
                    
                    Me.PageIndex = totalPages - 1
                End If                               
                
                ' Make sure PageIndex (current page) and PageSize are within bounds.
                If Me.PageIndex < 0 Then
                    Me.PageIndex = 0
                End If
                If Me.PageSize < 1 Then
                    Me.PageSize = 1
                End If
                
                ' Retrieve the records and set the table DataSource.
                ' Only PageSize records are fetched starting at PageIndex (zero based).
                If Me.AddNewRecord > 0 Then
                ' Make sure to preserve the previously entered data on new rows.
                    Dim postdata As New ArrayList
                    For Each rc As Request_MasterTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(Request_MasterRecord)), Request_MasterRecord())
                Else  ' Get the records from the database	
                        Me.DataSource = GetRecords(joinFilter, wc, orderBy, Me.PageIndex, Me.PageSize)
                      
                End If
                
                ' if the datasource contains no records contained in database, then load the last page.
                If (DbUtils.GetCreatedRecords(Me.DataSource).Length = 0 AndAlso Not Me.DisplayLastPage) Then
                      Me.DisplayLastPage = True
                      LoadData()
                Else
                
                    ' Add any new rows desired by the user.
                    Me.AddNewRecords()
                       

                    ' Initialize the page and grand totals. now
                
                End If
    
            Catch ex As Exception
                ' Report the error message to the end user
                Dim msg As String = ex.Message
                If ex.InnerException IsNot Nothing Then
                    msg = msg & " InnerException: " & ex.InnerException.Message
                End If
                Throw New Exception(msg, ex.InnerException)
            End Try
        End Sub
        
        Public Overridable Function GetRecords( _
            ByVal join As BaseFilter, _
            ByVal where As WhereClause, _
            ByVal orderBy As OrderBy, _
            ByVal pageIndex As Integer, _
            ByVal pageSize As Integer) As Request_MasterRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(Request_MasterTable.Column1, True)         
            ' selCols.Add(Request_MasterTable.Column2, True)          
            ' selCols.Add(Request_MasterTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return Request_MasterTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New Request_MasterTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(Request_MasterRecord)), Request_MasterRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(Request_MasterTable.Column1, True)         
            ' selCols.Add(Request_MasterTable.Column2, True)          
            ' selCols.Add(Request_MasterTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return Request_MasterTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New Request_MasterTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)           
                
                
                Return CInt(databaseTable.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
            End If

        End Function        
        
      
    
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record for each row in the table.  To do this, it calls the
            ' DataBind for each of the rows.
            ' DataBind also populates any filters above the table, and sets the pagination
            ' control to the correct number of records and the current page number.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If
            
            'LoadData for DataSource for chart and report if they exist
               
            ' Setup the pagination controls.
            BindPaginationControls()

      
        
          ' Bind the repeater with the list of records to expand the UI.
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As Request_MasterTableControlRow = DirectCast(repItem.FindControl("Request_MasterTableControlRow"), Request_MasterTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetIROC_IdLabel()
                SetLentityname()
                SetLentityname1()
                SetPending_Action_NeededLabel()
                SetPending_AgencyFilter()
                SetPending_AgencyLabel()
                SetPending_AgencyLabel1()
                SetProv_NameFilter()
                SetProv_NameLabel()
                SetProv_NameLabel1()
                SetReg_TypeFilter()
                SetReg_TypeLabel()
                SetReg_TypeLabel1()
                SetReq_AddressLabel()
                SetReq_CityLabel()
                SetReq_Completed_DtLabel()
                SetReq_DtLabel()
                SetReq_Enity2Filter()
                SetReq_Enity2Label()
                SetReq_EnityLabel()
                SetReq_IslandLabel()
                SetReq_Site_NameLabel()
                SetReq_StatusFilter()
                SetReq_StatusLabel()
                SetReq_StatusLabel1()
                SetReq_Target_DtLabel()
                SetReq_ZipLabel()
                
                
                
                
                
                SetRequest_MasterSearch()
                
                
                
                
            ' setting the state of expand or collapse alternative rows
      
            Dim expandFirstRow As Boolean= False   
        
            Dim recControls() As Request_MasterTableControlRow = Me.GetRecordControls()
            For i As Integer = 0 to recControls.Length - 1
                Dim altRow As System.Web.UI.Control = DirectCast(MiscUtils.FindControlRecursively(recControls(i), "Request_MasterTableControlAltRow"), System.Web.UI.Control)
                If (altRow IsNot Nothing) Then
                    If (expandFirstRow AndAlso i = 0) Then                
                        altRow.Visible = True
                   
                         recControls(i).Request_MasterRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow.gif"
                         recControls(i).Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over.gif'")
                         recControls(i).Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow.gif'")
                   
                    Else                
                        altRow.Visible = False
                   
                         recControls(i).Request_MasterRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow2.gif"
                         recControls(i).Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over2.gif'")
                         recControls(i).Request_MasterRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow2.gif'")
                   
                    End If
                End If
            Next
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
      
        Public Overridable Sub RegisterPostback()
        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Request_MasterExportExcelButton"))
                        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Request_MasterPDFButton"))
                        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Request_MasterWordButton"))
                        
        
        End Sub

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e as FormulaEvaluator) As String
            If e Is Nothing
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()
            
            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If
            
            If includeDS
                
            End If
            
            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            
            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function			

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function




        Public Overridable Sub ResetControl()
                    
            Me.Pending_AgencyFilter.ClearSelection()
            
            Me.Prov_NameFilter.ClearSelection()
            
            Me.Reg_TypeFilter.ClearSelection()
            
            Me.Req_Enity2Filter.ClearSelection()
            
            Me.Req_StatusFilter.ClearSelection()
            
            Me.Request_MasterSearch.Text = ""
            
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(Request_MasterTable.Request_Id, OrderByItem.OrderDir.Asc)
                  
            End If
                
            Me.PageIndex = 0
        End Sub

        Public Overridable Sub ResetPageControl()
            Me.PageIndex = 0
        End Sub
        
        Protected Overridable Sub BindPaginationControls()
            ' Setup the pagination controls.

            ' Bind the pagination labels.
        
            If DbUtils.GetCreatedRecords(Me.DataSource).Length > 0 Then                      
                    
                Me.Request_MasterPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.Request_MasterPagination.CurrentPage.Text = "0"
            End If
            Me.Request_MasterPagination.PageSize.Text = Me.PageSize.ToString()
            Me.Request_MasterPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for Request_MasterTableControl pagination.
        
            Me.Request_MasterPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.Request_MasterPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.Request_MasterPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.Request_MasterPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.Request_MasterPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.Request_MasterPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.Request_MasterPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.Request_MasterPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As Request_MasterTableControlRow
            For Each recCtl In Me.GetRecordControls()
        
                If Me.InDeletedRecordIds(recCtl) Then
                    ' Delete any pending deletes. 
                    recCtl.Delete()
                Else
                    If recCtl.Visible Then
                        recCtl.SaveData()
                    End If
                End If
          
            Next
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
          
            ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
            For Each recCtl In Me.GetRecordControls()
                recCtl.IsNewRecord = False
            Next
    
      
            ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
            Me.DeletedRecordIds = Nothing
      
        End Sub

        Public Overridable Function CreateCompoundJoinFilter() As CompoundFilter
            Dim jFilter As CompoundFilter = New CompoundFilter()
         
            Return jFilter
        End Function

        
          Public Overridable Function CreateOrderBy() As OrderBy
          ' The CurrentSortOrder is initialized to the sort order on the
          ' Query Wizard.  It may be modified by the Click handler for any of
          ' the column heading to sort or reverse sort by that column.
          ' You can add your own sort order, or modify it on the Query Wizard.
          Return Me.CurrentSortOrder
          End Function
      
        Public Overridable Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            Request_MasterTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
            ' Get the static clause defined at design time on the Table Panel Wizard
            Dim qc As WhereClause = Me.CreateQueryClause()
            If Not(IsNothing(qc)) Then
                wc.iAND(qc)
            End If
            
            If IsValueSelected(Me.Pending_AgencyFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Pending_AgencyFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Pending_AgencyFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Prov_NameFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Prov_NameFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Prov_NameFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Prov_Name, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Reg_TypeFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Reg_TypeFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Reg_TypeFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Req_Enity2Filter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Req_Enity2Filter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Req_Enity2Filter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Req_Enity2, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Req_StatusFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Req_StatusFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Req_StatusFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Req_Status, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.Request_MasterSearch) Then
              If Me.Request_MasterSearch.Text = BaseClasses.Resources.AppResources.GetResourceValue("Txt:SearchForEllipsis", Nothing) Then
                 Me.Request_MasterSearch.Text = ""
              Else
              ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
              
                    If Me.Request_MasterSearch.Text.StartsWith("...") Then
                        Me.Request_MasterSearch.Text = Me.Request_MasterSearch.Text.SubString(3,Me.Request_MasterSearch.Text.Length-3)
                    End If
                    If Me.Request_MasterSearch.Text.EndsWith("...") then
                        Me.Request_MasterSearch.Text = Me.Request_MasterSearch.Text.SubString(0,Me.Request_MasterSearch.Text.Length-3)
                        ' Strip the last word as well as it is likely only a partial word
                        Dim endindex As Integer = Request_MasterSearch.Text.Length - 1
                        While (Not Char.IsWhiteSpace(Request_MasterSearch.Text(endindex)) AndAlso endindex > 0)
                            endindex -= 1
                        End While
                        If endindex > 0 Then
                            Request_MasterSearch.Text = Request_MasterSearch.Text.Substring(0, endindex)
                        End If
              End If
            End If
            
              Dim formatedSearchText As String = MiscUtils.GetSelectedValue(Me.Request_MasterSearch, Me.GetFromSession(Me.Request_MasterSearch))
                
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(Me.Request_MasterSearch) Then 
        ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
      Dim cols As New ColumnList    
        
      cols.Add(Request_MasterTable.IROC_Id, True)
      
      cols.Add(Request_MasterTable.Reg_Type, True)
      
      cols.Add(Request_MasterTable.Req_Address, True)
      
      cols.Add(Request_MasterTable.Req_Contact_Email, True)
      
      cols.Add(Request_MasterTable.Req_Enity2, True)
      
      cols.Add(Request_MasterTable.Req_Funding_Src, True)
      
      cols.Add(Request_MasterTable.Req_Island, True)
      
      cols.Add(Request_MasterTable.Req_Site_Name, True)
      
      For Each col As BaseColumn in cols
      
                    search.iOR(col, BaseFilter.ComparisonOperator.Contains, MiscUtils.GetSelectedValue(Me.Request_MasterSearch, Me.GetFromSession(Me.Request_MasterSearch)), True, False)
        
      Next
    
                    wc.iAND(search)
                End If
            End If
                  
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            Request_MasterTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            ' Get the static clause defined at design time on the Table Panel Wizard
            Dim qc As WhereClause = Me.CreateQueryClause()
            If Not(IsNothing(qc)) Then
                wc.iAND(qc)
            End If
          
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
            Dim Pending_AgencyFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Pending_AgencyFilter_Ajax"), String)
            If IsValueSelected(Pending_AgencyFilterSelectedValue) Then
    
            If Not isNothing(Pending_AgencyFilterSelectedValue) Then
                Dim Pending_AgencyFilteritemListFromSession() As String = Pending_AgencyFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Pending_AgencyFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            Dim Prov_NameFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Prov_NameFilter_Ajax"), String)
            If IsValueSelected(Prov_NameFilterSelectedValue) Then
    
            If Not isNothing(Prov_NameFilterSelectedValue) Then
                Dim Prov_NameFilteritemListFromSession() As String = Prov_NameFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Prov_NameFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Prov_Name, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            Dim Reg_TypeFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Reg_TypeFilter_Ajax"), String)
            If IsValueSelected(Reg_TypeFilterSelectedValue) Then
    
            If Not isNothing(Reg_TypeFilterSelectedValue) Then
                Dim Reg_TypeFilteritemListFromSession() As String = Reg_TypeFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Reg_TypeFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            Dim Req_Enity2FilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Req_Enity2Filter_Ajax"), String)
            If IsValueSelected(Req_Enity2FilterSelectedValue) Then
    
            If Not isNothing(Req_Enity2FilterSelectedValue) Then
                Dim Req_Enity2FilteritemListFromSession() As String = Req_Enity2FilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Req_Enity2FilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Req_Enity2, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            Dim Req_StatusFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Req_StatusFilter_Ajax"), String)
            If IsValueSelected(Req_StatusFilterSelectedValue) Then
    
            If Not isNothing(Req_StatusFilterSelectedValue) Then
                Dim Req_StatusFilteritemListFromSession() As String = Req_StatusFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Req_StatusFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Req_Status, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            If IsValueSelected(searchText) and fromSearchControl = "Request_MasterSearch" Then
                Dim formatedSearchText as String = searchText
                ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
                If searchText.StartsWith("...") Then
                    formatedSearchText = searchText.SubString(3,searchText.Length-3)
                End If
                If searchText.EndsWith("...") Then
                    formatedSearchText = searchText.SubString(0,searchText.Length-3)
                    ' Strip the last word as well as it is likely only a partial word
                    Dim endindex As Integer = searchText.Length - 1
                    While (Not Char.IsWhiteSpace(searchText(endindex)) AndAlso endindex > 0)
                        endindex -= 1
                    End While
                    If endindex > 0 Then
                        searchText = searchText.Substring(0, endindex)
                    End If
                End If
                'After stripping "...", trim any leading and trailing whitespaces 
                formatedSearchText = formatedSearchText.Trim()
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(formatedSearchText) Then
                      ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
                    If InvariantLCase(AutoTypeAheadSearch).equals("wordsstartingwithsearchstring") Then
                
      Dim cols As New ColumnList    
        
      cols.Add(Request_MasterTable.IROC_Id, True)
      
      cols.Add(Request_MasterTable.Reg_Type, True)
      
      cols.Add(Request_MasterTable.Req_Address, True)
      
      cols.Add(Request_MasterTable.Req_Contact_Email, True)
      
      cols.Add(Request_MasterTable.Req_Enity2, True)
      
      cols.Add(Request_MasterTable.Req_Funding_Src, True)
      
      cols.Add(Request_MasterTable.Req_Island, True)
      
      cols.Add(Request_MasterTable.Req_Site_Name, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators & formatedSearchText, True, False)
                
      Next
    
                    Else
                        
      Dim cols As New ColumnList    
        
      cols.Add(Request_MasterTable.IROC_Id, True)
      
      cols.Add(Request_MasterTable.Reg_Type, True)
      
      cols.Add(Request_MasterTable.Req_Address, True)
      
      cols.Add(Request_MasterTable.Req_Contact_Email, True)
      
      cols.Add(Request_MasterTable.Req_Enity2, True)
      
      cols.Add(Request_MasterTable.Req_Funding_Src, True)
      
      cols.Add(Request_MasterTable.Req_Island, True)
      
      cols.Add(Request_MasterTable.Req_Site_Name, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, formatedSearchText, True, False)
      Next
    
                    End If
                    wc.iAND(search)
                End If
            End If
                  
      
      
            Return wc
        End Function
          
        Protected Overridable Function CreateQueryClause() As WhereClause
            ' Create a where clause for the Static clause defined at design time.
            Dim filter As CompoundFilter = New CompoundFilter(CompoundFilter.CompoundingOperators.And_Operator, Nothing)
        Dim whereClause As WhereClause = New WhereClause()

            If EvaluateFormula("""Completed""", false) <> "" Then filter.AddFilter(New BaseClasses.Data.ColumnValueFilter(BaseClasses.Data.BaseTable.CreateInstance("IROC2.Business.Request_MasterTable, App_Code").TableDefinition.ColumnList.GetByUniqueName("Request_Master_.Req_Status"), EvaluateFormula("""Completed""", false), BaseClasses.Data.BaseFilter.ComparisonOperator.Not_Equals, False))
         If (EvaluateFormula("""Completed""", false) = "--PLEASE_SELECT--" OrElse EvaluateFormula("""Completed""", false) = "--ANY--") Then whereClause.RunQuery = False

            whereClause.AddFilter(filter, CompoundFilter.CompoundingOperators.And_Operator)

            Return whereClause

        End Function
        
        Public Overridable Function GetAutoCompletionList_Request_MasterSearch(ByVal prefixText As String, ByVal count As Integer) As String()
            Dim resultList As ArrayList = New ArrayList
            Dim wordList As ArrayList = New ArrayList
            
            Dim filterJoin As CompoundFilter = CreateCompoundJoinFilter()
            If count = 0 Then count = 10
            Dim wc As WhereClause = CreateWhereClause(prefixText,"Request_MasterSearch", "AnyWhereInString", "[^a-zA-Z0-9]")
            Dim recordList () As IROC2.Business.Request_MasterRecord = Request_MasterTable.GetRecords(filterJoin, wc, Nothing, 0, count,count)
            Dim rec As Request_MasterRecord = Nothing
            Dim resultItem As String = ""
            For Each rec In recordList 
                ' Exit the loop if recordList count has reached AutoTypeAheadListSize.
                If resultList.Count >= count then
                    Exit For
                End If
                ' If the field is configured to Display as Foreign key, Format() method returns the 
                ' Display as Forien Key value instead of original field value.
                ' Since search had to be done in multiple fields (selected in Control's page property, binding tab) in a record,
                ' We need to find relevent field to display which matches the prefixText and is not already present in the result list.
        
                resultItem = rec.Format(Request_MasterTable.IROC_Id)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.IROC_Id.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.IROC_Id.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Reg_Type)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Reg_Type.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Reg_Type.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Address)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Address.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Address.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Contact_Email)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Contact_Email.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Contact_Email.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Enity2)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Enity2.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Enity2.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Funding_Src)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Funding_Src.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Funding_Src.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Island)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Island.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Island.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(Request_MasterTable.Req_Site_Name)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Site_Name.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "AnyWhereInString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Site_Name.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
            Next                
             
            resultList.Sort()
            Dim result() As String = New String(resultList.Count - 1) {}
            Array.Copy(resultList.ToArray, result, resultList.Count)
            Return result
        End Function
          

         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function

        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                   
                    resultList.Add(itemToAdd)
          				
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    
        Protected Overridable Sub GetPageSize()
        
            If Me.Request_MasterPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.Request_MasterPagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Sub AddNewRecords()
            
            Dim newRecordList As ArrayList = New ArrayList()
          
    Dim newUIDataList As System.Collections.Generic.List(Of Hashtable) = New System.Collections.Generic.List(Of Hashtable)()

    ' Loop though all the record controls and if the record control
    ' does not have a unique record id set, then create a record
    ' and add to the list.
    If Not Me.ResetData Then
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As Request_MasterTableControlRow = DirectCast(repItem.FindControl("Request_MasterTableControlRow"), Request_MasterTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As Request_MasterRecord = New Request_MasterRecord()
        
                        If recControl.IROC_Id.Text <> "" Then
                            rec.Parse(recControl.IROC_Id.Text, Request_MasterTable.IROC_Id)
                        End If
                        If recControl.Pending_Action_Needed.Text <> "" Then
                            rec.Parse(recControl.Pending_Action_Needed.Text, Request_MasterTable.Pending_Action_Needed)
                        End If
                        If recControl.Pending_Agency.Text <> "" Then
                            rec.Parse(recControl.Pending_Agency.Text, Request_MasterTable.Pending_Agency)
                        End If
                        If recControl.Prov_Name.Text <> "" Then
                            rec.Parse(recControl.Prov_Name.Text, Request_MasterTable.Prov_Name)
                        End If
                        If recControl.Reg_Type.Text <> "" Then
                            rec.Parse(recControl.Reg_Type.Text, Request_MasterTable.Reg_Type)
                        End If
                        If recControl.Req_Address.Text <> "" Then
                            rec.Parse(recControl.Req_Address.Text, Request_MasterTable.Req_Address)
                        End If
                        If recControl.Req_City.Text <> "" Then
                            rec.Parse(recControl.Req_City.Text, Request_MasterTable.Req_City)
                        End If
                        If recControl.Req_Completed_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Completed_Dt.Text, Request_MasterTable.Req_Completed_Dt)
                        End If
                        If recControl.Req_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Dt.Text, Request_MasterTable.Req_Dt)
                        End If
                        If recControl.Req_Enity2.Text <> "" Then
                            rec.Parse(recControl.Req_Enity2.Text, Request_MasterTable.Req_Enity2)
                        End If
                        If recControl.Req_Island.Text <> "" Then
                            rec.Parse(recControl.Req_Island.Text, Request_MasterTable.Req_Island)
                        End If
                        If recControl.Req_Site_Name.Text <> "" Then
                            rec.Parse(recControl.Req_Site_Name.Text, Request_MasterTable.Req_Site_Name)
                        End If
                        If recControl.Req_Status.Text <> "" Then
                            rec.Parse(recControl.Req_Status.Text, Request_MasterTable.Req_Status)
                        End If
                        If recControl.Req_Target_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Target_Dt.Text, Request_MasterTable.Req_Target_Dt)
                        End If
                        If recControl.Req_Zip.Text <> "" Then
                            rec.Parse(recControl.Req_Zip.Text, Request_MasterTable.Req_Zip)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New Request_MasterRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(Request_MasterRecord)), Request_MasterRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As Request_MasterTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As Request_MasterTableControlRow) As Boolean
            If Me.DeletedRecordIds Is Nothing OrElse Me.DeletedRecordIds.Trim = "" Then
                Return False
            End If

            Return Me.DeletedRecordIds.IndexOf("[" & rec.RecordUniqueId & "]") >= 0
        End Function

        Private _DeletedRecordIds As String
        Public Property DeletedRecordIds() As String
            Get
                Return Me._DeletedRecordIds
            End Get
            Set(ByVal value As String)
                Me._DeletedRecordIds = value
            End Set
        End Property
        
      
        ' Create Set, WhereClause, and Populate Methods
        
        Public Overridable Sub SetIROC_IdLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.IROC_IdLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetLentityname()
                  
                      Me.Lentityname.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")")
                    
                  End Sub
                
        Public Overridable Sub SetLentityname1()
                  
                      Me.Lentityname1.Text = EvaluateFormula("""""")
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_AgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_AgencyLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_AgencyLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetProv_NameLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Prov_NameLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetProv_NameLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Prov_NameLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReg_TypeLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Reg_TypeLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReg_TypeLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Reg_TypeLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_AddressLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_AddressLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_CityLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_CityLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Completed_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Completed_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Enity2Label()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Enity2Label.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_EnityLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_IslandLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_IslandLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Site_NameLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Site_NameLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_StatusLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StatusLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Target_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Target_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_ZipLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_ZipLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_AgencyFilter()

            
            Dim Pending_AgencyFilterselectedFilterItemList As New ArrayList()
            Dim Pending_AgencyFilteritemsString As String = Nothing
            If (Me.InSession(Me.Pending_AgencyFilter)) Then
                Pending_AgencyFilteritemsString = Me.GetFromSession(Me.Pending_AgencyFilter)
            End If
            
            If (Pending_AgencyFilteritemsString IsNot Nothing) Then
                Dim Pending_AgencyFilteritemListFromSession() As String = Pending_AgencyFilteritemsString.Split(","c)
                For Each item as String In Pending_AgencyFilteritemListFromSession
                    Pending_AgencyFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulatePending_AgencyFilter(GetSelectedValueList(Me.Pending_AgencyFilter, Pending_AgencyFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetProv_NameFilter()

            
            Dim Prov_NameFilterselectedFilterItemList As New ArrayList()
            Dim Prov_NameFilteritemsString As String = Nothing
            If (Me.InSession(Me.Prov_NameFilter)) Then
                Prov_NameFilteritemsString = Me.GetFromSession(Me.Prov_NameFilter)
            End If
            
            If (Prov_NameFilteritemsString IsNot Nothing) Then
                Dim Prov_NameFilteritemListFromSession() As String = Prov_NameFilteritemsString.Split(","c)
                For Each item as String In Prov_NameFilteritemListFromSession
                    Prov_NameFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateProv_NameFilter(GetSelectedValueList(Me.Prov_NameFilter, Prov_NameFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetReg_TypeFilter()

            
            Dim Reg_TypeFilterselectedFilterItemList As New ArrayList()
            Dim Reg_TypeFilteritemsString As String = Nothing
            If (Me.InSession(Me.Reg_TypeFilter)) Then
                Reg_TypeFilteritemsString = Me.GetFromSession(Me.Reg_TypeFilter)
            End If
            
            If (Reg_TypeFilteritemsString IsNot Nothing) Then
                Dim Reg_TypeFilteritemListFromSession() As String = Reg_TypeFilteritemsString.Split(","c)
                For Each item as String In Reg_TypeFilteritemListFromSession
                    Reg_TypeFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateReg_TypeFilter(GetSelectedValueList(Me.Reg_TypeFilter, Reg_TypeFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetReq_Enity2Filter()

            
            Dim Req_Enity2FilterselectedFilterItemList As New ArrayList()
            Dim Req_Enity2FilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_Enity2Filter)) Then
                Req_Enity2FilteritemsString = Me.GetFromSession(Me.Req_Enity2Filter)
            End If
            
            If (Req_Enity2FilteritemsString IsNot Nothing) Then
                Dim Req_Enity2FilteritemListFromSession() As String = Req_Enity2FilteritemsString.Split(","c)
                For Each item as String In Req_Enity2FilteritemListFromSession
                    Req_Enity2FilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateReq_Enity2Filter(GetSelectedValueList(Me.Req_Enity2Filter, Req_Enity2FilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetReq_StatusFilter()

            
            Dim Req_StatusFilterselectedFilterItemList As New ArrayList()
            Dim Req_StatusFilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_StatusFilter)) Then
                Req_StatusFilteritemsString = Me.GetFromSession(Me.Req_StatusFilter)
            End If
            
            If (Req_StatusFilteritemsString IsNot Nothing) Then
                Dim Req_StatusFilteritemListFromSession() As String = Req_StatusFilteritemsString.Split(","c)
                For Each item as String In Req_StatusFilteritemListFromSession
                    Req_StatusFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateReq_StatusFilter(GetSelectedValueList(Me.Req_StatusFilter, Req_StatusFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetRequest_MasterSearch()

            
              End Sub	
            
        ' Get the filters' data for Pending_AgencyFilter
        Protected Overridable Sub PopulatePending_AgencyFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Pending_AgencyFilter()
            Me.Pending_AgencyFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Pending_AgencyFilter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Pending_Agency, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Pending_Agency, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Pending_Agency.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Pending_Agency.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Pending_AgencyFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Pending_AgencyFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Pending_AgencyFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Pending_AgencyFilter.Items.Count = 0 Then
                Me.Pending_AgencyFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Pending_AgencyFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
        ' Get the filters' data for Prov_NameFilter
        Protected Overridable Sub PopulateProv_NameFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Prov_NameFilter()
            Me.Prov_NameFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Prov_NameFilter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Prov_Name, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Prov_Name, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Prov_Name.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Prov_Name.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Prov_NameFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Prov_NameFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Prov_NameFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Prov_NameFilter.Items.Count = 0 Then
                Me.Prov_NameFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Prov_NameFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
        ' Get the filters' data for Reg_TypeFilter
        Protected Overridable Sub PopulateReg_TypeFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Reg_TypeFilter()
            Me.Reg_TypeFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Reg_TypeFilter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Reg_Type, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Reg_Type, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Reg_Type.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Reg_Type.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Reg_TypeFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Reg_TypeFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Reg_TypeFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Reg_TypeFilter.Items.Count = 0 Then
                Me.Reg_TypeFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Reg_TypeFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
        ' Get the filters' data for Req_Enity2Filter
        Protected Overridable Sub PopulateReq_Enity2Filter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Req_Enity2Filter()
            Me.Req_Enity2Filter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Req_Enity2Filter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Req_Enity2, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Req_Enity2, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Req_Enity2.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Req_Enity2.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Req_Enity2Filter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Req_Enity2Filter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Req_Enity2Filter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Req_Enity2Filter.Items.Count = 0 Then
                Me.Req_Enity2Filter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Req_Enity2Filter.Items
                item.Selected = True
            Next
                              
        End Sub
            
        ' Get the filters' data for Req_StatusFilter
        Protected Overridable Sub PopulateReq_StatusFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Req_StatusFilter()
            Me.Req_StatusFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Req_StatusFilter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Req_Status, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Req_Status, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Req_Status.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Req_Status.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Req_StatusFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Req_StatusFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Req_StatusFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Req_StatusFilter.Items.Count = 0 Then
                Me.Req_StatusFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Req_StatusFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
              

        Public Overridable Function CreateWhereClause_Pending_AgencyFilter() As WhereClause
          
            ' Create a where clause for the filter Pending_AgencyFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Pending_AgencyFilterQuickSelector
            
            Dim Pending_AgencyFilterselectedFilterItemList As New ArrayList()
            Dim Pending_AgencyFilteritemsString As String = Nothing
            If (Me.InSession(Me.Pending_AgencyFilter)) Then
                Pending_AgencyFilteritemsString = Me.GetFromSession(Me.Pending_AgencyFilter)
            End If
            
            If (Pending_AgencyFilteritemsString IsNot Nothing) Then
                Dim Pending_AgencyFilteritemListFromSession() As String = Pending_AgencyFilteritemsString.Split(","c)
                For Each item as String In Pending_AgencyFilteritemListFromSession
                    Pending_AgencyFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Pending_AgencyFilterselectedFilterItemList = GetSelectedValueList(Me.Pending_AgencyFilter, Pending_AgencyFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Pending_AgencyFilterselectedFilterItemList Is Nothing OrElse Pending_AgencyFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Pending_AgencyFilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Pending_Agency, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
                Next
            End If
            Return wc
        
        End Function			
            
              

        Public Overridable Function CreateWhereClause_Prov_NameFilter() As WhereClause
          
            ' Create a where clause for the filter Prov_NameFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Prov_NameFilterQuickSelector
            
            Dim Prov_NameFilterselectedFilterItemList As New ArrayList()
            Dim Prov_NameFilteritemsString As String = Nothing
            If (Me.InSession(Me.Prov_NameFilter)) Then
                Prov_NameFilteritemsString = Me.GetFromSession(Me.Prov_NameFilter)
            End If
            
            If (Prov_NameFilteritemsString IsNot Nothing) Then
                Dim Prov_NameFilteritemListFromSession() As String = Prov_NameFilteritemsString.Split(","c)
                For Each item as String In Prov_NameFilteritemListFromSession
                    Prov_NameFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Prov_NameFilterselectedFilterItemList = GetSelectedValueList(Me.Prov_NameFilter, Prov_NameFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Prov_NameFilterselectedFilterItemList Is Nothing OrElse Prov_NameFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Prov_NameFilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Prov_Name, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
                Next
            End If
            Return wc
        
        End Function			
            
              

        Public Overridable Function CreateWhereClause_Reg_TypeFilter() As WhereClause
          
            ' Create a where clause for the filter Reg_TypeFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Reg_TypeFilterQuickSelector
            
            Dim Reg_TypeFilterselectedFilterItemList As New ArrayList()
            Dim Reg_TypeFilteritemsString As String = Nothing
            If (Me.InSession(Me.Reg_TypeFilter)) Then
                Reg_TypeFilteritemsString = Me.GetFromSession(Me.Reg_TypeFilter)
            End If
            
            If (Reg_TypeFilteritemsString IsNot Nothing) Then
                Dim Reg_TypeFilteritemListFromSession() As String = Reg_TypeFilteritemsString.Split(","c)
                For Each item as String In Reg_TypeFilteritemListFromSession
                    Reg_TypeFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Reg_TypeFilterselectedFilterItemList = GetSelectedValueList(Me.Reg_TypeFilter, Reg_TypeFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Reg_TypeFilterselectedFilterItemList Is Nothing OrElse Reg_TypeFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Reg_TypeFilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Reg_Type, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
                Next
            End If
            Return wc
        
        End Function			
            
              

        Public Overridable Function CreateWhereClause_Req_Enity2Filter() As WhereClause
          
            ' Create a where clause for the filter Req_Enity2Filter.
            ' This function is called by the Populate method to load the items 
            ' in the Req_Enity2FilterQuickSelector
            
            Dim Req_Enity2FilterselectedFilterItemList As New ArrayList()
            Dim Req_Enity2FilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_Enity2Filter)) Then
                Req_Enity2FilteritemsString = Me.GetFromSession(Me.Req_Enity2Filter)
            End If
            
            If (Req_Enity2FilteritemsString IsNot Nothing) Then
                Dim Req_Enity2FilteritemListFromSession() As String = Req_Enity2FilteritemsString.Split(","c)
                For Each item as String In Req_Enity2FilteritemListFromSession
                    Req_Enity2FilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Req_Enity2FilterselectedFilterItemList = GetSelectedValueList(Me.Req_Enity2Filter, Req_Enity2FilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Req_Enity2FilterselectedFilterItemList Is Nothing OrElse Req_Enity2FilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Req_Enity2FilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Req_Enity2, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
                Next
            End If
            Return wc
        
        End Function			
            
              

        Public Overridable Function CreateWhereClause_Req_StatusFilter() As WhereClause
          
            ' Create a where clause for the filter Req_StatusFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Req_StatusFilterQuickSelector
            
            Dim Req_StatusFilterselectedFilterItemList As New ArrayList()
            Dim Req_StatusFilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_StatusFilter)) Then
                Req_StatusFilteritemsString = Me.GetFromSession(Me.Req_StatusFilter)
            End If
            
            If (Req_StatusFilteritemsString IsNot Nothing) Then
                Dim Req_StatusFilteritemListFromSession() As String = Req_StatusFilteritemsString.Split(","c)
                For Each item as String In Req_StatusFilteritemListFromSession
                    Req_StatusFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Req_StatusFilterselectedFilterItemList = GetSelectedValueList(Me.Req_StatusFilter, Req_StatusFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Req_StatusFilterselectedFilterItemList Is Nothing OrElse Req_StatusFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Req_StatusFilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Req_Status, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
                Next
            End If
            Return wc
        
        End Function			
            

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    
                    Me.LoadData()
                    Me.DataBind()
                    
                End If
                
               
                
			Me.Page.Authorize(Ctype(Lentityname, Control), "NOT_ANONYMOUS")
					
			Me.Page.Authorize(Ctype(Lentityname1, Control), "NOT_ANONYMOUS")
					
			Me.Page.Authorize(Ctype(Prov_NameFilter, Control), "1")
					
			Me.Page.Authorize(Ctype(Prov_NameLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Reg_TypeFilter, Control), "1;22;23;25;26;34")
					
			Me.Page.Authorize(Ctype(Reg_TypeLabel1, Control), "1;22;23;25;26;34")
					
			Me.Page.Authorize(Ctype(Req_Enity2Filter, Control), "1;32;33;34")
					
			Me.Page.Authorize(Ctype(Req_Enity2Label, Control), "1;32;33;34")
					
			Me.Page.Authorize(Ctype(Request_MasterNewButton, Control), "1;2;22;23;25;26;27;28;29;30;31")
									
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
            Dim Pending_AgencyFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Pending_AgencyFilter, Nothing)
            Dim Pending_AgencyFilterSessionString As String = ""
            If Not Pending_AgencyFilterselectedFilterItemList is Nothing Then
            For Each item As String In Pending_AgencyFilterselectedFilterItemList
                Pending_AgencyFilterSessionstring = Pending_AgencyFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Pending_AgencyFilter, Pending_AgencyFilterSessionstring)
                  
            Dim Prov_NameFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Prov_NameFilter, Nothing)
            Dim Prov_NameFilterSessionString As String = ""
            If Not Prov_NameFilterselectedFilterItemList is Nothing Then
            For Each item As String In Prov_NameFilterselectedFilterItemList
                Prov_NameFilterSessionstring = Prov_NameFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Prov_NameFilter, Prov_NameFilterSessionstring)
                  
            Dim Reg_TypeFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Reg_TypeFilter, Nothing)
            Dim Reg_TypeFilterSessionString As String = ""
            If Not Reg_TypeFilterselectedFilterItemList is Nothing Then
            For Each item As String In Reg_TypeFilterselectedFilterItemList
                Reg_TypeFilterSessionstring = Reg_TypeFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Reg_TypeFilter, Reg_TypeFilterSessionstring)
                  
            Dim Req_Enity2FilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_Enity2Filter, Nothing)
            Dim Req_Enity2FilterSessionString As String = ""
            If Not Req_Enity2FilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_Enity2FilterselectedFilterItemList
                Req_Enity2FilterSessionstring = Req_Enity2FilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Req_Enity2Filter, Req_Enity2FilterSessionstring)
                  
            Dim Req_StatusFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_StatusFilter, Nothing)
            Dim Req_StatusFilterSessionString As String = ""
            If Not Req_StatusFilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_StatusFilterselectedFilterItemList
                Req_StatusFilterSessionstring = Req_StatusFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Req_StatusFilter, Req_StatusFilterSessionstring)
                  
            Me.SaveToSession(Me.Request_MasterSearch, Me.Request_MasterSearch.Text)
                  
        
            'Save pagination state to session.
         
            
            ' Save table control properties to the session.
            If Not Me.CurrentSortOrder Is Nothing Then
            Me.SaveToSession(Me, "Order_By", Me.CurrentSortOrder.ToXmlString())
            End If
            
            Me.SaveToSession(Me, "Page_Index", Me.PageIndex.ToString())
            Me.SaveToSession(Me, "Page_Size", Me.PageSize.ToString())
        
            Me.SaveToSession(Me, "DeletedRecordIds", Me.DeletedRecordIds)  
        
        End Sub
        
        Protected  Sub SaveControlsToSession_Ajax()
            ' Save filter controls to values to session.
          
            Dim Pending_AgencyFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Pending_AgencyFilter, Nothing)
            Dim Pending_AgencyFilterSessionString As String = ""
            If Not Pending_AgencyFilterselectedFilterItemList is Nothing Then
            For Each item As String In Pending_AgencyFilterselectedFilterItemList
                Pending_AgencyFilterSessionstring = Pending_AgencyFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Pending_AgencyFilter_Ajax", Pending_AgencyFilterSessionString)
          
            Dim Prov_NameFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Prov_NameFilter, Nothing)
            Dim Prov_NameFilterSessionString As String = ""
            If Not Prov_NameFilterselectedFilterItemList is Nothing Then
            For Each item As String In Prov_NameFilterselectedFilterItemList
                Prov_NameFilterSessionstring = Prov_NameFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Prov_NameFilter_Ajax", Prov_NameFilterSessionString)
          
            Dim Reg_TypeFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Reg_TypeFilter, Nothing)
            Dim Reg_TypeFilterSessionString As String = ""
            If Not Reg_TypeFilterselectedFilterItemList is Nothing Then
            For Each item As String In Reg_TypeFilterselectedFilterItemList
                Reg_TypeFilterSessionstring = Reg_TypeFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Reg_TypeFilter_Ajax", Reg_TypeFilterSessionString)
          
            Dim Req_Enity2FilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_Enity2Filter, Nothing)
            Dim Req_Enity2FilterSessionString As String = ""
            If Not Req_Enity2FilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_Enity2FilterselectedFilterItemList
                Req_Enity2FilterSessionstring = Req_Enity2FilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Req_Enity2Filter_Ajax", Req_Enity2FilterSessionString)
          
            Dim Req_StatusFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_StatusFilter, Nothing)
            Dim Req_StatusFilterSessionString As String = ""
            If Not Req_StatusFilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_StatusFilterselectedFilterItemList
                Req_StatusFilterSessionstring = Req_StatusFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Req_StatusFilter_Ajax", Req_StatusFilterSessionString)
          
      Me.SaveToSession("Request_MasterSearch_Ajax", Me.Request_MasterSearch.Text)
              
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
            Me.RemoveFromSession(Me.Pending_AgencyFilter)
            Me.RemoveFromSession(Me.Prov_NameFilter)
            Me.RemoveFromSession(Me.Reg_TypeFilter)
            Me.RemoveFromSession(Me.Req_Enity2Filter)
            Me.RemoveFromSession(Me.Req_StatusFilter)
            Me.RemoveFromSession(Me.Request_MasterSearch)
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("Request_MasterTableControl_OrderBy"), String)
            
            If orderByStr IsNot Nothing AndAlso orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            
            Else 
                Me.CurrentSortOrder = New OrderBy(True, False)
            
            End If
            
    Dim pageIndex As String = CType(ViewState("Page_Index"), String)
    If pageIndex IsNot Nothing Then
    Me.PageIndex = CInt(pageIndex)
    End If

    Dim pageSize As String = CType(ViewState("Page_Size"), String)
    If Not pageSize Is Nothing Then
    Me.PageSize = CInt(pageSize)
    End If

    
    
            ' Load view state for pagination control.
        
            Me.DeletedRecordIds = CType(Me.ViewState("DeletedRecordIds"), String)
        
        End Sub

        Protected Overrides Function SaveViewState() As Object
            
            If Me.CurrentSortOrder IsNot Nothing Then
                Me.ViewState("Request_MasterTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex = 0
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.DisplayLastPage = True
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex += 1
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub Request_MasterPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.Request_MasterPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.Request_MasterPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            If Me.PageIndex > 0 Then
                Me.PageIndex -= 1
                Me.DataChanged = True
            End If
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        

        ' Generate the event handling functions for sorting events.
        
        Public Overridable Sub IROC_IdLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by IROC_Id when clicked.
              
            ' Get previous sorting state for IROC_Id.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.IROC_Id)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for IROC_Id.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.IROC_Id, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by IROC_Id, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Action_NeededLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Action_Needed when clicked.
              
            ' Get previous sorting state for Pending_Action_Needed.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Action_Needed)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Action_Needed.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Action_Needed, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Action_Needed, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Agency when clicked.
              
            ' Get previous sorting state for Pending_Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Prov_NameLabel1_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Prov_Name when clicked.
              
            ' Get previous sorting state for Prov_Name.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Prov_Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Prov_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Prov_Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Prov_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Reg_TypeLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Reg_Type when clicked.
              
            ' Get previous sorting state for Reg_Type.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Reg_Type)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Reg_Type.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Reg_Type, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Reg_Type, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_AddressLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Address when clicked.
              
            ' Get previous sorting state for Req_Address.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Address)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Address.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Address, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Address, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_CityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_City when clicked.
              
            ' Get previous sorting state for Req_City.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_City)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_City.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_City, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_City, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Completed_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Completed_Dt when clicked.
              
            ' Get previous sorting state for Req_Completed_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Completed_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Completed_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Completed_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Completed_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Dt when clicked.
              
            ' Get previous sorting state for Req_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_EnityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Enity2 when clicked.
              
            ' Get previous sorting state for Req_Enity2.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Enity2)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Enity2.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Enity2, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Enity2, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_IslandLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Island when clicked.
              
            ' Get previous sorting state for Req_Island.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Island)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Island.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Island, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Island, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Site_NameLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Site_Name when clicked.
              
            ' Get previous sorting state for Req_Site_Name.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Site_Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Site_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Site_Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Site_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_StatusLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Status when clicked.
              
            ' Get previous sorting state for Req_Status.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Status)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Status.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Status, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Status, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Target_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Target_Dt when clicked.
              
            ' Get previous sorting state for Req_Target_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Target_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Target_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Target_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Target_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_ZipLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Zip when clicked.
              
            ' Get previous sorting state for Req_Zip.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Zip)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Zip.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Zip, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Zip, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterExportExcelButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            ' To customize the columns or the format, override this function in Section 1 of the page 
            ' and modify it to your liking.
            ' Build the where clause based on the current filter and search criteria
            ' Create the Order By clause based on the user's current sorting preference.
          
              Dim wc As WhereClause = CreateWhereClause
              Dim orderBy As OrderBy = Nothing
              
              orderBy = CreateOrderBy
              
              Dim done As Boolean = False
              Dim val As Object = ""
              ' Read pageSize records at a time and write out the Excel file.
              Dim totalRowsReturned As Integer = 0
          
              Dim join As CompoundFilter = CreateCompoundJoinFilter()
              Me.TotalRecords = Request_MasterTable.GetRecordCount(join, wc)
              If Me.TotalRecords > 10000 Then
          
              ' Add each of the columns in order of export.
              Dim columns() as BaseColumn = New BaseColumn() { _
                         Request_MasterTable.IROC_Id, _ 
             Request_MasterTable.Req_Site_Name, _ 
             Request_MasterTable.Req_Address, _ 
             Request_MasterTable.Req_City, _ 
             Request_MasterTable.Req_Island, _ 
             Request_MasterTable.Req_Zip, _ 
             Request_MasterTable.Req_Dt, _ 
             Request_MasterTable.Req_Target_Dt, _ 
             Request_MasterTable.Req_Completed_Dt, _ 
             Request_MasterTable.Req_Status, _ 
             Request_MasterTable.Pending_Agency, _ 
             Request_MasterTable.Pending_Action_Needed, _ 
             Request_MasterTable.Reg_Type, _ 
             Request_MasterTable.Req_Enity2, _ 
             Request_MasterTable.Prov_Name, _ 
             Nothing}
              Dim  exportData as ExportDataToCSV = New ExportDataToCSV(Request_MasterTable.Instance, wc, orderBy, columns)
              exportData.StartExport(Me.Page.Response, True)

              Dim dataForCSV As DataForExport = New DataForExport(Request_MasterTable.Instance, wc, orderBy, columns, join)

              '  Read pageSize records at a time and write out the CSV file.
              While (Not done)
                  Dim recList As ArrayList = dataForCSV.GetRows(exportData.pageSize)
                  If recList Is Nothing Then
                      Exit While 'no more records we are done
                  End If

                  totalRowsReturned = recList.Count
                  For Each rec As BaseRecord In recList
                      For Each col As BaseColumn In dataForCSV.ColumnList
                          If col Is Nothing Then
                              Continue For
                          End If

                          If Not dataForCSV.IncludeInExport(col) Then
                              Continue For
                          End If

                          val = rec.GetValue(col).ToString()
                          exportData.WriteColumnData(val, dataForCSV.IsString(col))

                      Next col
                      exportData.WriteNewRow()
                  Next rec

                  '  If we already are below the pageSize, then we are done.
                  If totalRowsReturned < exportData.pageSize Then
                      done = True
                  End If
              End While
              exportData.FinishExport(Me.Page.Response)
          Else
          
              ' Create an instance of the Excel report class with the table class, where clause and order by.
              Dim excelReport As ExportDataToExcel = New ExportDataToExcel(Request_MasterTable.Instance, wc, orderBy)
              ' Add each of the columns in order of export.
              ' To customize the data type, change the second parameter of the new ExcelColumn to be
              ' a format string from Excel's Format Cell menu. For example "dddd, mmmm dd, yyyy h:mm AM/PM;@", "#,##0.00"

              If Me.Page.Response Is Nothing Then
                Return
              End If

              excelReport.CreateExcelBook()

              Dim width As Integer = 0
              Dim columnCounter As Integer = 0
              Dim data As DataForExport = New DataForExport(Request_MasterTable.Instance, wc, orderBy, Nothing, join)
                       data.ColumnList.Add(New ExcelColumn(Request_MasterTable.IROC_Id, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Site_Name, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Address, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_City, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Island, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Zip, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Target_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Completed_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Status, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Agency, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Action_Needed, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Reg_Type, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Enity2, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Prov_Name, "Default"))


              For Each col As ExcelColumn In data.ColumnList
                  width = excelReport.GetExcelCellWidth(col)
                  If data.IncludeInExport(col) Then
                      excelReport.AddColumnToExcelBook(columnCounter, col.ToString(), excelReport.GetExcelDataType(col), width, excelReport.GetDisplayFormat(col))
                      columnCounter = columnCounter + 1
                  End If
              Next col
              
              While (Not done)
                  Dim recList As ArrayList = data.GetRows(excelReport.pageSize)

                  If recList Is Nothing Then
                      Exit While 'no more records we are done
                  End If

                  totalRowsReturned = recList.Count

                  For Each rec As BaseRecord In recList
                      excelReport.AddRowToExcelBook()
                      columnCounter = 0

                      For Each col As ExcelColumn In data.ColumnList
                          If Not data.IncludeInExport(col) Then
                              Continue For
                          End If

                          Dim _isExpandableNonCompositeForeignKey As Boolean = col.DisplayColumn.TableDefinition.IsExpandableNonCompositeForeignKey(col.DisplayColumn)
                          If _isExpandableNonCompositeForeignKey AndAlso col.DisplayColumn.IsApplyDisplayAs Then
                              val = Request_MasterTable.GetDFKA(rec.GetValue(col.DisplayColumn).ToString(), col.DisplayColumn, Nothing)
                              If val Is Nothing Then
                                  val = rec.Format(col.DisplayColumn)
                              End If
                          Else
                              val = excelReport.GetValueForExcelExport(col, rec)
                          End If
                          excelReport.AddCellToExcelRow(columnCounter, excelReport.GetExcelDataType(col), val, col.DisplayFormat)

                          columnCounter = columnCounter + 1
                      Next col
                  Next rec

                  ' If we already are below the pageSize, then we are done.
                  If totalRowsReturned < excelReport.pageSize Then
                      done = True
                  End If
              End While

              excelReport.SaveExcelBook(Me.Page.Response)
          End If
        
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterNewButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Add-Request-Master.aspx"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If              
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterPDFButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
                Dim report As PDFReport = New PDFReport() 
                report.SpecificReportFileName = Page.Server.MapPath("Group-By-Request-Master-Table.Request_MasterPDFButton.report")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Request_Master"
                ' If Group-By-Request-Master-Table.Request_MasterPDFButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.   
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column   			
                 report.AddColumn(Request_MasterTable.IROC_Id.Name, ReportEnum.Align.Left, "${IROC_Id}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Site_Name.Name, ReportEnum.Align.Left, "${Req_Site_Name}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Address.Name, ReportEnum.Align.Left, "${Req_Address}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_City.Name, ReportEnum.Align.Left, "${Req_City}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Island.Name, ReportEnum.Align.Left, "${Req_Island}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Zip.Name, ReportEnum.Align.Left, "${Req_Zip}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Dt.Name, ReportEnum.Align.Left, "${Req_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Target_Dt.Name, ReportEnum.Align.Left, "${Req_Target_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Completed_Dt.Name, ReportEnum.Align.Left, "${Req_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Status.Name, ReportEnum.Align.Left, "${Req_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Agency.Name, ReportEnum.Align.Left, "${Pending_Agency}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Reg_Type.Name, ReportEnum.Align.Left, "${Reg_Type}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Enity2.Name, ReportEnum.Align.Left, "${Req_Enity2}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Prov_Name.Name, ReportEnum.Align.Left, "${Prov_Name}", ReportEnum.Align.Left, 15)

          
                Dim rowsPerQuery As Integer = 5000 
                Dim recordCount As Integer = 0 
                                
                report.Page = Page.GetResourceValue("Txt:Page", "IROC2")
                report.ApplicationPath = Me.Page.MapPath(Page.Request.ApplicationPath)
            
                Dim whereClause As WhereClause = CreateWhereClause
                Dim orderBy As OrderBy = CreateOrderBy
              Dim joinFilter As BaseFilter = CreateCompoundJoinFilter()
            
                Dim pageNum As Integer = 0 
                Dim totalRows As Integer = Request_MasterTable.GetRecordCount(joinFilter,whereClause)
                Dim columns As ColumnList = Request_MasterTable.GetColumnList()
                Dim records As Request_MasterRecord() = Nothing
            
                Do 
                    
                    records = Request_MasterTable.GetRecords(joinFilter,whereClause, orderBy, pageNum, rowsPerQuery)
                    If Not (records Is Nothing) AndAlso records.Length > 0 AndAlso whereClause.RunQuery Then
                      For Each record As Request_MasterRecord In records 
                    
                            ' AddData method takes four parameters   
                            ' The 1st parameters represent the data format
                            ' The 2nd parameters represent the data value
                            ' The 3rd parameters represent the default alignment of column using the data
                            ' The 4th parameters represent the maximum length of the data value being shown
                                                         report.AddData("${IROC_Id}", record.Format(Request_MasterTable.IROC_Id), ReportEnum.Align.Left, 12)
                             report.AddData("${Req_Site_Name}", record.Format(Request_MasterTable.Req_Site_Name), ReportEnum.Align.Left, 1200)
                             report.AddData("${Req_Address}", record.Format(Request_MasterTable.Req_Address), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_City}", record.Format(Request_MasterTable.Req_City), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Island}", record.Format(Request_MasterTable.Req_Island), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Zip}", record.Format(Request_MasterTable.Req_Zip), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Dt}", record.Format(Request_MasterTable.Req_Dt), ReportEnum.Align.Left, 15)
                             report.AddData("${Req_Target_Dt}", record.Format(Request_MasterTable.Req_Target_Dt), ReportEnum.Align.Left, 15)
                             report.AddData("${Req_Completed_Dt}", record.Format(Request_MasterTable.Req_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Status}", record.Format(Request_MasterTable.Req_Status), ReportEnum.Align.Left, 12)
                             report.AddData("${Pending_Agency}", record.Format(Request_MasterTable.Pending_Agency), ReportEnum.Align.Left, 15)
                             report.AddData("${Pending_Action_Needed}", record.Format(Request_MasterTable.Pending_Action_Needed), ReportEnum.Align.Left, 20)
                             report.AddData("${Reg_Type}", record.Format(Request_MasterTable.Reg_Type), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Enity2}", record.Format(Request_MasterTable.Req_Enity2), ReportEnum.Align.Left, 300)
                             report.AddData("${Prov_Name}", record.Format(Request_MasterTable.Prov_Name), ReportEnum.Align.Left, 300)

                            report.WriteRow 
                        Next 
                        pageNum = pageNum + 1
                        recordCount += records.Length 
                    End If 
                Loop While Not (records Is Nothing) AndAlso recordCount < totalRows  AndAlso whereClause.RunQuery 
                
                report.Close 
                BaseClasses.Utils.NetUtils.WriteResponseBinaryAttachment(Me.Page.Response, report.Title + ".pdf", report.ReportInByteArray, 0, true)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterResetButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
              Me.Pending_AgencyFilter.ClearSelection()
              Me.Prov_NameFilter.ClearSelection()
              Me.Reg_TypeFilter.ClearSelection()
              Me.Req_Enity2Filter.ClearSelection()
              Me.Req_StatusFilter.ClearSelection()
              Me.Request_MasterSearch.Text = ""
              Me.CurrentSortOrder.Reset()
              If Me.InSession(Me, "Order_By") Then
                  Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
              Else
                  Me.CurrentSortOrder = New OrderBy(True, False)
              
                    Me.CurrentSortOrder.Add(Request_MasterTable.Request_Id, OrderByItem.OrderDir.Asc)
                      

              End If
              

        ' Setting the DataChanged to True results in the page being refreshed with
        ' the most recent data from the database.  This happens in PreRender event
        ' based on the current sort, search and filter criteria.
        Me.DataChanged = True
            
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub Request_MasterWordButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
                Dim report As WordReport = New WordReport
                report.SpecificReportFileName = Page.Server.MapPath("Group-By-Request-Master-Table.Request_MasterWordButton.word")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Request_Master"
                ' If Group-By-Request-Master-Table.Request_MasterWordButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column
                 report.AddColumn(Request_MasterTable.IROC_Id.Name, ReportEnum.Align.Left, "${IROC_Id}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Site_Name.Name, ReportEnum.Align.Left, "${Req_Site_Name}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Address.Name, ReportEnum.Align.Left, "${Req_Address}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_City.Name, ReportEnum.Align.Left, "${Req_City}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Island.Name, ReportEnum.Align.Left, "${Req_Island}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Zip.Name, ReportEnum.Align.Left, "${Req_Zip}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Dt.Name, ReportEnum.Align.Left, "${Req_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Target_Dt.Name, ReportEnum.Align.Left, "${Req_Target_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Completed_Dt.Name, ReportEnum.Align.Left, "${Req_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Status.Name, ReportEnum.Align.Left, "${Req_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Agency.Name, ReportEnum.Align.Left, "${Pending_Agency}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Reg_Type.Name, ReportEnum.Align.Left, "${Reg_Type}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Enity2.Name, ReportEnum.Align.Left, "${Req_Enity2}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Prov_Name.Name, ReportEnum.Align.Left, "${Prov_Name}", ReportEnum.Align.Left, 15)

              Dim whereClause As WhereClause = CreateWhereClause
              
              Dim orderBy As OrderBy = CreateOrderBy
              Dim joinFilter As BaseFilter = CreateCompoundJoinFilter()
                
                Dim rowsPerQuery As Integer = 5000
                Dim pageNum As Integer = 0
                Dim recordCount As Integer = 0
                Dim totalRows As Integer = Request_MasterTable.GetRecordCount(joinFilter,whereClause)

                report.Page = Page.GetResourceValue("Txt:Page", "IROC2")
                report.ApplicationPath = Me.Page.MapPath(Page.Request.ApplicationPath)

                Dim columns As ColumnList = Request_MasterTable.GetColumnList()
                Dim records As Request_MasterRecord() = Nothing
                Do
                    records = Request_MasterTable.GetRecords(joinFilter,whereClause, orderBy, pageNum, rowsPerQuery)
                    
                    If Not (records Is Nothing) AndAlso records.Length > 0 AndAlso whereClause.RunQuery Then
                      For Each record As Request_MasterRecord In records
                            ' AddData method takes four parameters
                            ' The 1st parameters represent the data format
                            ' The 2nd parameters represent the data value
                            ' The 3rd parameters represent the default alignment of column using the data
                            ' The 4th parameters represent the maximum length of the data value being shown
                             report.AddData("${IROC_Id}", record.Format(Request_MasterTable.IROC_Id), ReportEnum.Align.Left, 12)
                             report.AddData("${Req_Site_Name}", record.Format(Request_MasterTable.Req_Site_Name), ReportEnum.Align.Left, 1200)
                             report.AddData("${Req_Address}", record.Format(Request_MasterTable.Req_Address), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_City}", record.Format(Request_MasterTable.Req_City), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Island}", record.Format(Request_MasterTable.Req_Island), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Zip}", record.Format(Request_MasterTable.Req_Zip), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Dt}", record.Format(Request_MasterTable.Req_Dt), ReportEnum.Align.Left, 15)
                             report.AddData("${Req_Target_Dt}", record.Format(Request_MasterTable.Req_Target_Dt), ReportEnum.Align.Left, 15)
                             report.AddData("${Req_Completed_Dt}", record.Format(Request_MasterTable.Req_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Status}", record.Format(Request_MasterTable.Req_Status), ReportEnum.Align.Left, 12)
                             report.AddData("${Pending_Agency}", record.Format(Request_MasterTable.Pending_Agency), ReportEnum.Align.Left, 15)
                             report.AddData("${Pending_Action_Needed}", record.Format(Request_MasterTable.Pending_Action_Needed), ReportEnum.Align.Left, 20)
                             report.AddData("${Reg_Type}", record.Format(Request_MasterTable.Reg_Type), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Enity2}", record.Format(Request_MasterTable.Req_Enity2), ReportEnum.Align.Left, 300)
                             report.AddData("${Prov_Name}", record.Format(Request_MasterTable.Prov_Name), ReportEnum.Align.Left, 300)

                            report.WriteRow
                        Next
                        pageNum = pageNum + 1
                        recordCount += records.Length
                    End If
                Loop While Not (records Is Nothing) AndAlso recordCount < totalRows AndAlso whereClause.RunQuery 
                report.save
                BaseClasses.Utils.NetUtils.WriteResponseBinaryAttachment(Me.Page.Response, report.Title + ".doc", report.ReportInByteArray, 0, true)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for Button with Layout
        Public Overridable Sub Request_MasterSearchButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
          Me.DataChanged = True
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
      

        ' Generate the event handling functions for filter and search events.
        
        ' event handler for FieldFilter
        Protected Overridable Sub Pending_AgencyFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
        ' event handler for FieldFilter
        Protected Overridable Sub Prov_NameFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
        ' event handler for FieldFilter
        Protected Overridable Sub Reg_TypeFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
        ' event handler for FieldFilter
        Protected Overridable Sub Req_Enity2Filter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
        ' event handler for FieldFilter
        Protected Overridable Sub Req_StatusFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
    
        ' Generate the event handling functions for others
        
      
        Private _UIData As New System.Collections.Generic.List(Of Hashtable)
        Public Property UIData() As System.Collections.Generic.List(Of Hashtable)
            Get
                Return Me._UIData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of Hashtable))
                Me._UIData = value
            End Set
        End Property
        
        ' pagination properties
        Protected _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Protected _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Protected _TotalRecords As Integer = -1
        Public Property TotalRecords() As Integer
            Get
                If _TotalRecords < 0 
                    _TotalRecords = Request_MasterTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
                End If
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                  
                End If
                Me._TotalRecords = value
            End Set
        End Property

        
    
        Protected _TotalPages As Integer = -1
        Public Property TotalPages() As Integer
            Get
                If _TotalPages < 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(TotalRecords / Me.PageSize))
                  
                End If                
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Protected _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property
        
        Private _ResetData As Boolean = False
        Public Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal value As Boolean)
                Me._ResetData = value
            End Set
        End Property

        Private _AddNewRecord As Integer = 0
        Public Property AddNewRecord() As Integer
            Get
                Return Me._AddNewRecord
            End Get
            Set(ByVal value As Integer)
                Me._AddNewRecord = value
            End Set
        End Property

        
        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property
        
        Public Property DataSource() As Request_MasterRecord ()
            Get
                Return DirectCast(MyBase._DataSource, Request_MasterRecord())
            End Get
            Set(ByVal value() As Request_MasterRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property IROC_IdLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Lentityname() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Lentityname"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
        Public ReadOnly Property Lentityname1() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Lentityname1"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_NeededLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Prov_NameFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Prov_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Prov_NameLabel1() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel1"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Reg_TypeFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Reg_TypeLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Reg_TypeLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_AddressLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_AddressLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_CityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Completed_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Enity2Filter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2Filter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Req_Enity2Label() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2Label"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_EnityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_IslandLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Site_NameLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_NameLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_StatusFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Req_StatusLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_StatusLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Target_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_ZipLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_ZipLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterExportExcelButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterExportExcelButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterNewButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterNewButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property Request_MasterPDFButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterPDFButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterResetButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterResetButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterSearch() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterSearch"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterSearchButton() As IROC2.UI.IThemeButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterSearchButton"), IROC2.UI.IThemeButton)
          End Get
          End Property
        
        Public ReadOnly Property Request_MasterTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterWordButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterWordButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"
        
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
      
      
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me,includeSession)
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As Request_MasterTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As Request_MasterRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            End If
            Return url
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As Request_MasterTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As Request_MasterRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                If includeSession then
                    Return EvaluateExpressions(url, arg, rec, bEncrypt)
                Else
                    Return EvaluateExpressions(url, arg, rec, bEncrypt,False)
                End If
            End If
            Return url
        End Function
        
          
        Public Overridable Function GetSelectedRecordControl() As Request_MasterTableControlRow
            Return Nothing
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As Request_MasterTableControlRow()
        
            Return DirectCast((new ArrayList()).ToArray(GetType(Request_MasterTableControlRow)), Request_MasterTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As Request_MasterTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As Request_MasterTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                Else
                
                    recCtl.Delete()
                    
                    ' Setting the DataChanged to True results in the page being refreshed with
                    ' the most recent data from the database.  This happens in PreRender event
                    ' based on the current sort, search and filter criteria.
                    Me.DataChanged = True
                    Me.ResetData = True
                  
                End If
            Next
        End Sub

        Public Function GetRecordControls() As Request_MasterTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("Request_MasterTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As Request_MasterTableControlRow = DirectCast(repItem.FindControl("Request_MasterTableControlRow"), Request_MasterTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(Request_MasterTableControlRow)), Request_MasterTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the UploadsTableControlRow control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in UploadsTableControlRow.
Public Class BaseUploadsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in UploadsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in UploadsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
                    
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Uploads record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = UploadsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseUploadsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New UploadsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in UploadsTableControlRow.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetUPLOAD_Comments()
                SetUPLOAD_Created_By()
                SetUPLOAD_Desc()
                SetUPLOAD_DOC()
                SetUPLOAD_Dt()
                SetUPLOAD_File()
                SetUPLOAD_Quote()
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
        End Sub
        
        
        Public Overridable Sub SetUPLOAD_Comments()
            
        
            ' Set the UPLOAD_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_CommentsSpecified Then
                				
                ' If the UPLOAD_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Comments.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Comments.Text = UploadsTable.UPLOAD_Comments.Format(UploadsTable.UPLOAD_Comments.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Comments.Text Is Nothing _
                OrElse Me.UPLOAD_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Comments.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_Created_By()
            
        
            ' Set the UPLOAD_Created_By Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Created_By is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Created_By()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_Created_BySpecified Then
                				
                ' If the UPLOAD_Created_By is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Created_By)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Created_By.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Created_By is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Created_By.Text = UploadsTable.UPLOAD_Created_By.Format(UploadsTable.UPLOAD_Created_By.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Created_By is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Created_By.Text Is Nothing _
                OrElse Me.UPLOAD_Created_By.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Created_By.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_Desc()
            
        
            ' Set the UPLOAD_Desc Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Desc is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Desc()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DescSpecified Then
                				
                ' If the UPLOAD_Desc is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Desc)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Desc.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Desc is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Desc.Text = UploadsTable.UPLOAD_Desc.Format(UploadsTable.UPLOAD_Desc.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Desc is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Desc.Text Is Nothing _
                OrElse Me.UPLOAD_Desc.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Desc.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_DOC()
                
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DOCSpecified Then
                
                Me.UPLOAD_DOC.Text = Me.DataSource.UPLOAD_File
                Me.UPLOAD_DOC.ToolTip = "Open " & Me.UPLOAD_DOC.Text
				   If String.IsNullOrEmpty(Me.UPLOAD_DOC.Text) Then
					      Me.UPLOAD_DOC.Text = Page.GetResourceValue("Txt:OpenFile", "IROC2")
                Me.UPLOAD_DOC.ToolTip = Me.UPLOAD_DOC.Text
				   End If
						
                Me.UPLOAD_DOC.OnClientClick = "window.open('../Shared/ExportFieldValue.aspx?Table=" & _
                            Me.Page.Encrypt("Uploads") & _
                            "&Field=" & Me.Page.Encrypt("UPLOAD_DOC") & _
                            "&Record=" & Me.Page.Encrypt(HttpUtility.UrlEncode(Me.DataSource.GetID().ToString())) & _
                            "&Filename=" & Me.DataSource.UPLOAD_File & _
                            "','','left=100,top=50,width=400,height=300,resizable, scrollbars=1');return false;"
                   
                Me.UPLOAD_DOC.Visible = True
            Else
                Me.UPLOAD_DOC.Visible = False
            End If
        End Sub
                
        Public Overridable Sub SetUPLOAD_Dt()
            
        
            ' Set the UPLOAD_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DtSpecified Then
                				
                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Dt.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Dt.Text = UploadsTable.UPLOAD_Dt.Format(UploadsTable.UPLOAD_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the UPLOAD_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Dt.Text Is Nothing _
                OrElse Me.UPLOAD_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_File()
            
        
            ' Set the UPLOAD_File Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_File is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_File()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_FileSpecified Then
                				
                ' If the UPLOAD_File is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_File)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_File.Text = formattedValue
                
            Else 
            
                ' UPLOAD_File is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_File.Text = UploadsTable.UPLOAD_File.Format(UploadsTable.UPLOAD_File.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_File is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_File.Text Is Nothing _
                OrElse Me.UPLOAD_File.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_File.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_Quote()
            
        
            ' Set the UPLOAD_Quote Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Quote is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Quote()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_QuoteSpecified Then
                				
                ' If the UPLOAD_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Quote)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Quote.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Quote.Text = UploadsTable.UPLOAD_Quote.Format(UploadsTable.UPLOAD_Quote.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Quote is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Quote.Text Is Nothing _
                OrElse Me.UPLOAD_Quote.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Quote.Text = "&nbsp;"
            End If
                  
        End Sub
                

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function      
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in UploadsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterTableControlRow
          
          				  
          parentCtrl = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow"), Request_MasterTableControlRow)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
                DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in UploadsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetUPLOAD_Comments()
            GetUPLOAD_Created_By()
            GetUPLOAD_Desc()
            GetUPLOAD_Dt()
            GetUPLOAD_File()
            GetUPLOAD_Quote()
        End Sub
        
        
        Public Overridable Sub GetUPLOAD_Comments()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Created_By()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Desc()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Dt()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_File()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Quote()
            
        End Sub
                
      
        ' To customize, override this method in UploadsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in UploadsTableControlRow.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          UploadsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).ResetData = True
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                						
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseUploadsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseUploadsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As UploadsRecord
        Public Property DataSource() As UploadsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As UploadsRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property UPLOAD_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Created_By() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_By"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Desc() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Desc"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_DOC() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOC"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_File() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_File"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Quote() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Quote"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As UploadsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As UploadsRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As UploadsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return UploadsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the UploadsTableControl control on the Group_By_Request_Master_Table page.
' Do not modify this class. Instead override any method in UploadsTableControl.
Public Class BaseUploadsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(UploadsTable.Request_Id, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
            ' Setup the pagination events.
            
              AddHandler Me.UploadsPagination.FirstPage.Click, AddressOf UploadsPagination_FirstPage_Click
              
              AddHandler Me.UploadsPagination.LastPage.Click, AddressOf UploadsPagination_LastPage_Click
              
              AddHandler Me.UploadsPagination.NextPage.Click, AddressOf UploadsPagination_NextPage_Click
              
              AddHandler Me.UploadsPagination.PageSizeButton.Click, AddressOf UploadsPagination_PageSizeButton_Click
            
              AddHandler Me.UploadsPagination.PreviousPage.Click, AddressOf UploadsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.UPLOAD_CommentsLabel.Click, AddressOf UPLOAD_CommentsLabel_Click
            
              AddHandler Me.UPLOAD_Created_ByLabel.Click, AddressOf UPLOAD_Created_ByLabel_Click
            
              AddHandler Me.UPLOAD_DescLabel.Click, AddressOf UPLOAD_DescLabel_Click
            
              AddHandler Me.UPLOAD_DtLabel.Click, AddressOf UPLOAD_DtLabel_Click
            
              AddHandler Me.UPLOAD_QuoteLabel.Click, AddressOf UPLOAD_QuoteLabel_Click
            
            ' Setup the button events.
                  
        
          ' Setup events for others
            
        End Sub
        
        
        Public Overridable Sub LoadData()        
        
            ' Read data from database. Returns an array of records that can be assigned
            ' to the DataSource table control property.
            Try	
                Dim joinFilter As CompoundFilter = CreateCompoundJoinFilter()
                
                ' The WHERE clause will be empty when displaying all records in table.
                Dim wc As WhereClause = CreateWhereClause()
                If wc IsNot Nothing AndAlso Not wc.RunQuery Then
                    ' Initialize an empty array of records
                    Dim alist As New ArrayList(0)
                    Me.DataSource = DirectCast(alist.ToArray(GetType(UploadsRecord)), UploadsRecord())
                    ' Add records to the list if needed.
                    Me.AddNewRecords()
                    Me._TotalRecords = 0
                    Me._TotalPages = 0
                    Return
                End If

                ' Call OrderBy to determine the order - either use the order defined
                ' on the Query Wizard, or specified by user (by clicking on column heading)
                Dim orderBy As OrderBy = CreateOrderBy()
                
                ' Get the pagesize from the pagesize control.
                Me.GetPageSize()
                               
                If Me.DisplayLastPage Then
                    Dim totalRecords As Integer = If(Me._TotalRecords < 0, GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause()), Me._TotalRecords)
                     
                      Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / Me.PageSize))
                    
                    Me.PageIndex = totalPages - 1
                End If                               
                
                ' Make sure PageIndex (current page) and PageSize are within bounds.
                If Me.PageIndex < 0 Then
                    Me.PageIndex = 0
                End If
                If Me.PageSize < 1 Then
                    Me.PageSize = 1
                End If
                
                ' Retrieve the records and set the table DataSource.
                ' Only PageSize records are fetched starting at PageIndex (zero based).
                If Me.AddNewRecord > 0 Then
                ' Make sure to preserve the previously entered data on new rows.
                    Dim postdata As New ArrayList
                    For Each rc As UploadsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(UploadsRecord)), UploadsRecord())
                Else  ' Get the records from the database	
                        Me.DataSource = GetRecords(joinFilter, wc, orderBy, Me.PageIndex, Me.PageSize)
                      
                End If
                
                ' if the datasource contains no records contained in database, then load the last page.
                If (DbUtils.GetCreatedRecords(Me.DataSource).Length = 0 AndAlso Not Me.DisplayLastPage) Then
                      Me.DisplayLastPage = True
                      LoadData()
                Else
                
                    ' Add any new rows desired by the user.
                    Me.AddNewRecords()
                       

                    ' Initialize the page and grand totals. now
                
                End If
    
            Catch ex As Exception
                ' Report the error message to the end user
                Dim msg As String = ex.Message
                If ex.InnerException IsNot Nothing Then
                    msg = msg & " InnerException: " & ex.InnerException.Message
                End If
                Throw New Exception(msg, ex.InnerException)
            End Try
        End Sub
        
        Public Overridable Function GetRecords( _
            ByVal join As BaseFilter, _
            ByVal where As WhereClause, _
            ByVal orderBy As OrderBy, _
            ByVal pageIndex As Integer, _
            ByVal pageSize As Integer) As UploadsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UploadsTable.Column1, True)         
            ' selCols.Add(UploadsTable.Column2, True)          
            ' selCols.Add(UploadsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return UploadsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New UploadsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(UploadsRecord)), UploadsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UploadsTable.Column1, True)         
            ' selCols.Add(UploadsTable.Column2, True)          
            ' selCols.Add(UploadsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return UploadsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New UploadsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)           
                
                
                Return CInt(databaseTable.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
            End If

        End Function        
        
      
    
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record for each row in the table.  To do this, it calls the
            ' DataBind for each of the rows.
            ' DataBind also populates any filters above the table, and sets the pagination
            ' control to the correct number of records and the current page number.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If
            
            'LoadData for DataSource for chart and report if they exist
               
            ' Setup the pagination controls.
            BindPaginationControls()

      
        
          ' Bind the repeater with the list of records to expand the UI.
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetUPLOAD_CommentsLabel()
                SetUPLOAD_Created_ByLabel()
                SetUPLOAD_DescLabel()
                SetUPLOAD_DOCLabel()
                SetUPLOAD_DtLabel()
                SetUPLOAD_QuoteLabel()
                
            ' setting the state of expand or collapse alternative rows
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
      
        Public Overridable Sub RegisterPostback()
        
        
        End Sub

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e as FormulaEvaluator) As String
            If e Is Nothing
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()
            
            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If
            
            If includeDS
                
            End If
            
            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            
            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function			

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function




        Public Overridable Sub ResetControl()
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(UploadsTable.Request_Id, OrderByItem.OrderDir.Asc)
                  
            End If
                
            Me.PageIndex = 0
        End Sub

        Public Overridable Sub ResetPageControl()
            Me.PageIndex = 0
        End Sub
        
        Protected Overridable Sub BindPaginationControls()
            ' Setup the pagination controls.

            ' Bind the pagination labels.
        
            If DbUtils.GetCreatedRecords(Me.DataSource).Length > 0 Then                      
                    
                Me.UploadsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.UploadsPagination.CurrentPage.Text = "0"
            End If
            Me.UploadsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.UploadsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for UploadsTableControl pagination.
        
            Me.UploadsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.UploadsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As UploadsTableControlRow
            For Each recCtl In Me.GetRecordControls()
        
                If Me.InDeletedRecordIds(recCtl) Then
                    ' Delete any pending deletes. 
                    recCtl.Delete()
                Else
                    If recCtl.Visible Then
                        recCtl.SaveData()
                    End If
                End If
          
            Next
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
          
            ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
            For Each recCtl In Me.GetRecordControls()
                recCtl.IsNewRecord = False
            Next
    
      
            ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
            Me.DeletedRecordIds = Nothing
      
        End Sub

        Public Overridable Function CreateCompoundJoinFilter() As CompoundFilter
            Dim jFilter As CompoundFilter = New CompoundFilter()
         
            Return jFilter
        End Function

        
          Public Overridable Function CreateOrderBy() As OrderBy
          ' The CurrentSortOrder is initialized to the sort order on the
          ' Query Wizard.  It may be modified by the Click handler for any of
          ' the column heading to sort or reverse sort by that column.
          ' You can add your own sort order, or modify it on the Query Wizard.
          Return Me.CurrentSortOrder
          End Function
      
        Public Overridable Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            UploadsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
        Dim request_MasterRecordObj as KeyValue
        request_MasterRecordObj = Nothing
      
              Dim request_MasterTableControlObjRow As Request_MasterTableControlRow = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow") ,Request_MasterTableControlRow)
            
                If (Not IsNothing(request_MasterTableControlObjRow) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord()) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord().Request_Id))
                    wc.iAND(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterTableControlObjRow.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc                    
                End If
              
      HttpContext.Current.Session("UploadsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            UploadsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("UploadsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterTableControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterTableControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterTableControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(UploadsTable.Request_Id) Then
            wc.iAND(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(UploadsTable.Request_Id).ToString())
       End If
      
            End If
          
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
      
      
            Return wc
        End Function
          

         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function

        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                   
                    resultList.Add(itemToAdd)
          				
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    
        Protected Overridable Sub GetPageSize()
        
            If Me.UploadsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.UploadsPagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Sub AddNewRecords()
            
            Dim newRecordList As ArrayList = New ArrayList()
          
    Dim newUIDataList As System.Collections.Generic.List(Of Hashtable) = New System.Collections.Generic.List(Of Hashtable)()

    ' Loop though all the record controls and if the record control
    ' does not have a unique record id set, then create a record
    ' and add to the list.
    If Not Me.ResetData Then
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As UploadsRecord = New UploadsRecord()
        
                        If recControl.UPLOAD_Comments.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Comments.Text, UploadsTable.UPLOAD_Comments)
                        End If
                        If recControl.UPLOAD_Created_By.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Created_By.Text, UploadsTable.UPLOAD_Created_By)
                        End If
                        If recControl.UPLOAD_Desc.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Desc.Text, UploadsTable.UPLOAD_Desc)
                        End If
                        If recControl.UPLOAD_DOC.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_DOC.Text, UploadsTable.UPLOAD_DOC)
                        End If
                        If recControl.UPLOAD_Dt.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Dt.Text, UploadsTable.UPLOAD_Dt)
                        End If
                        If recControl.UPLOAD_File.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_File.Text, UploadsTable.UPLOAD_File)
                        End If
                        If recControl.UPLOAD_Quote.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Quote.Text, UploadsTable.UPLOAD_Quote)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New UploadsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(UploadsRecord)), UploadsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As UploadsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As UploadsTableControlRow) As Boolean
            If Me.DeletedRecordIds Is Nothing OrElse Me.DeletedRecordIds.Trim = "" Then
                Return False
            End If

            Return Me.DeletedRecordIds.IndexOf("[" & rec.RecordUniqueId & "]") >= 0
        End Function

        Private _DeletedRecordIds As String
        Public Property DeletedRecordIds() As String
            Get
                Return Me._DeletedRecordIds
            End Get
            Set(ByVal value As String)
                Me._DeletedRecordIds = value
            End Set
        End Property
        
      
        ' Create Set, WhereClause, and Populate Methods
        
        Public Overridable Sub SetUPLOAD_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_Created_ByLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_Created_ByLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DescLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DescLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DOCLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DOCLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_QuoteLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_QuoteLabel.Text = "Some value"
                    
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    
                    Me.LoadData()
                    Me.DataBind()
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
            ' Save table control properties to the session.
            If Not Me.CurrentSortOrder Is Nothing Then
            Me.SaveToSession(Me, "Order_By", Me.CurrentSortOrder.ToXmlString())
            End If
            
            Me.SaveToSession(Me, "Page_Index", Me.PageIndex.ToString())
            Me.SaveToSession(Me, "Page_Size", Me.PageSize.ToString())
        
            Me.SaveToSession(Me, "DeletedRecordIds", Me.DeletedRecordIds)  
        
        End Sub
        
        Protected  Sub SaveControlsToSession_Ajax()
            ' Save filter controls to values to session.
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("UploadsTableControl_OrderBy"), String)
            
            If orderByStr IsNot Nothing AndAlso orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            
            Else 
                Me.CurrentSortOrder = New OrderBy(True, False)
            
            End If
            
    Dim pageIndex As String = CType(ViewState("Page_Index"), String)
    If pageIndex IsNot Nothing Then
    Me.PageIndex = CInt(pageIndex)
    End If

    Dim pageSize As String = CType(ViewState("Page_Size"), String)
    If Not pageSize Is Nothing Then
    Me.PageSize = CInt(pageSize)
    End If

    
    
            ' Load view state for pagination control.
        
            Me.DeletedRecordIds = CType(Me.ViewState("DeletedRecordIds"), String)
        
        End Sub

        Protected Overrides Function SaveViewState() As Object
            
            If Me.CurrentSortOrder IsNot Nothing Then
                Me.ViewState("UploadsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex = 0
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.DisplayLastPage = True
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex += 1
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub UploadsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.UploadsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.UploadsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            If Me.PageIndex > 0 Then
                Me.PageIndex -= 1
                Me.DataChanged = True
            End If
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        

        ' Generate the event handling functions for sorting events.
        
        Public Overridable Sub UPLOAD_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Comments when clicked.
              
            ' Get previous sorting state for UPLOAD_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Comments, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_Created_ByLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Created_By when clicked.
              
            ' Get previous sorting state for UPLOAD_Created_By.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Created_By)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Created_By.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Created_By, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Created_By, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_DescLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Desc when clicked.
              
            ' Get previous sorting state for UPLOAD_Desc.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Desc)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Desc.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Desc, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Desc, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Dt when clicked.
              
            ' Get previous sorting state for UPLOAD_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_QuoteLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Quote when clicked.
              
            ' Get previous sorting state for UPLOAD_Quote.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Quote)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Quote.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Quote, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Quote, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
      

        ' Generate the event handling functions for filter and search events.
        
    
        ' Generate the event handling functions for others
        
      
        Private _UIData As New System.Collections.Generic.List(Of Hashtable)
        Public Property UIData() As System.Collections.Generic.List(Of Hashtable)
            Get
                Return Me._UIData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of Hashtable))
                Me._UIData = value
            End Set
        End Property
        
        ' pagination properties
        Protected _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Protected _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Protected _TotalRecords As Integer = -1
        Public Property TotalRecords() As Integer
            Get
                If _TotalRecords < 0 
                    _TotalRecords = UploadsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
                End If
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                  
                End If
                Me._TotalRecords = value
            End Set
        End Property

        
    
        Protected _TotalPages As Integer = -1
        Public Property TotalPages() As Integer
            Get
                If _TotalPages < 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(TotalRecords / Me.PageSize))
                  
                End If                
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Protected _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property
        
        Private _ResetData As Boolean = False
        Public Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal value As Boolean)
                Me._ResetData = value
            End Set
        End Property

        Private _AddNewRecord As Integer = 0
        Public Property AddNewRecord() As Integer
            Get
                Return Me._AddNewRecord
            End Get
            Set(ByVal value As Integer)
                Me._AddNewRecord = value
            End Set
        End Property

        
        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property
        
        Public Property DataSource() As UploadsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, UploadsRecord())
            End Get
            Set(ByVal value() As UploadsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property UPLOAD_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Created_ByLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_ByLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DescLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DescLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DOCLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOCLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_QuoteLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_QuoteLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
#End Region

#Region "Helper Functions"
        
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
      
      
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me,includeSession)
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As UploadsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UploadsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            End If
            Return url
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As UploadsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UploadsRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                If includeSession then
                    Return EvaluateExpressions(url, arg, rec, bEncrypt)
                Else
                    Return EvaluateExpressions(url, arg, rec, bEncrypt,False)
                End If
            End If
            Return url
        End Function
        
          
        Public Overridable Function GetSelectedRecordControl() As UploadsTableControlRow
            Return Nothing
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As UploadsTableControlRow()
        
            Return DirectCast((new ArrayList()).ToArray(GetType(UploadsTableControlRow)), UploadsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As UploadsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As UploadsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                Else
                
                    recCtl.Delete()
                    
                    ' Setting the DataChanged to True results in the page being refreshed with
                    ' the most recent data from the database.  This happens in PreRender event
                    ' based on the current sort, search and filter criteria.
                    Me.DataChanged = True
                    Me.ResetData = True
                  
                End If
            Next
        End Sub

        Public Function GetRecordControls() As UploadsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(UploadsTableControlRow)), UploadsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  

#End Region
    
  
End Namespace

  