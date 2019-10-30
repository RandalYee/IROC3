
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Edit_Request_Master.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Edit_Request_Master

#Region "Section 1: Place your customizations here."

    
Public Class CommentsTableControlRow
        Inherits BaseCommentsTableControlRow
        ' The BaseCommentsTableControlRow implements code for a ROW within the
        ' the CommentsTableControl table.  The BaseCommentsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of CommentsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        


		Public Overrides Sub SetAgency()
            
            ' If data was retrieved from UI previously, restore it  --Ryee
            If Me.PreviousUIData.ContainsKey(Me.Agency.ID) Then
            
                Me.Agency.Text = Me.PreviousUIData(Me.Agency.ID).ToString()

                Return
           
            End If
            
        
            ' Set the Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.


            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AgencySpecified Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Agency)
                              
                Me.Agency.Text = formattedValue
                
            Else 
            
                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                'Me.Agency.Text = CommentsTable.Agency.Format(CommentsTable.Agency.DefaultValue)
                Me.Agency.Text = EvaluateFormula("URL(""Agency"")", Me.DataSource)
                End If

        End Sub
        Public Overrides Sub SetComment()

            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Comment.ID) Then

                Me.Comment.Text = Me.PreviousUIData(Me.Comment.ID).ToString()

                Return
            End If


            ' Set the Comment TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment is the ASP:TextBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CommentSpecified Then

                ' If the Comment is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment)

                Me.Comment.Text = formattedValue

            Else

                ' Comment is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Comment.Text = CommentsTable.Comment.Format(CommentsTable.Comment.DefaultValue)
                'Me.PopulateComment_To_AgencyDropDownList(selectedValue, 100)
            End If
        End Sub
    End Class



    Public Class CommentsTableControl
        Inherits BaseCommentsTableControl

        ' The BaseCommentsTableControl class implements the LoadData, DataBind, CreateWhereClause
        ' and other methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
        ' The CommentsTableControlRow class offers another place where you can customize
        ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.


     
    End Class


    Public Class ContactsTableControlRow
        Inherits BaseContactsTableControlRow
        ' The BaseContactsTableControlRow implements code for a ROW within the
        ' the ContactsTableControl table.  The BaseContactsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of ContactsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.



        Public Overrides Sub SetName()

            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Name.ID) Then

                Me.Name.Text = Me.PreviousUIData(Me.Name.ID).ToString()

                Return
            End If


            ' Set the Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Name is the ASP:TextBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetName()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.NameSpecified Then

                ' If the Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Name)

                Me.Name.Text = formattedValue

            Else

                ' Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Name.Text = ContactsTable.Name.Format(ContactsTable.Name.DefaultValue)
            End If

        End Sub

        Public Overrides Sub SetAgency1()


            ' Set the Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Agency1 is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency1()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then

                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Agency)

                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Agency1.Text = formattedValue

            Else

                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.Agency1.Text = EvaluateFormula("URL(""Agency"")", Me.DataSource)
            End If

        End Sub
    
		Public Overrides Sub ContactsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            '--Ryee
              
                  Dim url As String = "../Contacts/Edit-Contacts.aspx?Contacts={PK}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
            Try
                Dim x As String = EvaluateFormula("URL(""Agency"")", Me.DataSource)
                If Me.Agency1.Text <> EvaluateFormula("URL(""Agency"")", Me.DataSource) Then
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

		Public Overrides Sub ContactsRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        '--Ryee
    Try
                If Me.Agency1.Text <> EvaluateFormula("URL(""Agency"")", Me.DataSource) Then
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Not Authorized!")
                    Exit Sub
                End If  '--Ryee
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Dim tc As ContactsTableControl = DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl)
                If Not (IsNothing(tc)) Then
                    If Not Me.IsNewRecord Then
                        tc.AddToDeletedRecordIds(DirectCast(Me, ContactsTableControlRow))
                    End If
                    Me.Visible = False
                    tc.SetFormulaControls()
                End If
              
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
End Class



    Public Class ContactsTableControl
        Inherits BaseContactsTableControl

        ' The BaseContactsTableControl class implements the LoadData, DataBind, CreateWhereClause
        ' and other methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
        ' The ContactsTableControlRow class offers another place where you can customize
        ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

    End Class


    Public Class UploadsTableControlRow
        Inherits BaseUploadsTableControlRow
        ' The BaseUploadsTableControlRow implements code for a ROW within the
        ' the UploadsTableControl table.  The BaseUploadsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of UploadsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.



        Public Overrides Sub SetUPLOAD_File()

            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_File.ID) Then

                Me.UPLOAD_File.Text = Me.PreviousUIData(Me.UPLOAD_File.ID).ToString()

                Return
            End If


            ' Set the UPLOAD_File TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_File is the ASP:TextBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_File()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_FileSpecified Then

                ' If the UPLOAD_File is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_File)

                Me.UPLOAD_File.Text = formattedValue
            Else

                ' UPLOAD_File is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.UPLOAD_File.Text = UploadsTable.UPLOAD_File.Format(UploadsTable.UPLOAD_File.DefaultValue)
            End If

        End Sub

		Public Overrides Sub SetUPLOAD_Dt()


            ' Set the UPLOAD_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Dt is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Dt()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then

                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")

                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Dt.Text = formattedValue

            Else

                ' UPLOAD_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.UPLOAD_Dt.Text = EvaluateFormula("Format(Today(), ""g"")", Me.DataSource, "g")
            End If

        End Sub
    

		Public Overrides Sub Validate()
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            '--Ryee
            Dim i As Integer
            If Me.UPLOAD_Desc.Text = "Quote" And Me.UPLOAD_Quote.Text = "" Then
                Throw New Exception("Quote_Amount is Required!")
            ElseIf Me.UPLOAD_Desc.Text = "Quote" Then
                i = CInt(Me.UPLOAD_Quote.Text)
                If i <= 0 Then
                    Throw New Exception("Quote_Amount Can't be Zero!")
                End If
            End If
        End Sub
    
		Public Overrides Sub UploadsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
            '--Ryee

            Dim url As String = "../Uploads/Edit-Uploads.aspx?Uploads={PK}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
            Try
                Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
                role = Right(role, 2)
                If role <> ";1" Then
                    If Me.UPLOAD_Created_By.Text <> EvaluateFormula("UserName()", Me.DataSource) Then
                        Throw New Exception("Not Authorized To Edit This Upload Item.")
                    End If
                End If
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
End Class



    Public Class UploadsTableControl
        Inherits BaseUploadsTableControl

        ' The BaseUploadsTableControl class implements the LoadData, DataBind, CreateWhereClause
        ' and other methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
        ' The UploadsTableControlRow class offers another place where you can customize
        ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

    End Class


    Public Class Request_MasterRecordControl
        Inherits BaseRequest_MasterRecordControl
        ' The BaseRequest_MasterRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.


    
		Public Overrides Sub SetLOTW_Quote1()
            
        
            ' Set the OTW_Quote Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Quote1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Quote1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then

                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote, "C")

                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Quote1.Text = formattedValue

            Else

                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.LOTW_Quote1.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue, "C")

            End If

        End Sub

        Public Overrides Sub SetLabel_Quote_Instr()
            '--Ryee   
            If EvaluateFormula("Pending_Action_Needed") = "Quote Needed" Then
                Me.Label_Quote_Instr.Visible = True
            Else
                Me.Label_Quote_Instr.Visible = False
            End If

        End Sub

		Public Overrides Sub SetOTW_On_Net_Dt()
            
        
            ' Set the OTW_On_Net_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_On_Net_Dt()
            ' and add your own code before or after the call to the MyBase function.

            '--Ryee      
            If EvaluateFormula("Pending_Action_Needed") = "Connect To INET" Then
                Me.OTW_On_Net_Dt.Visible = True
            Else
                Me.OTW_On_Net_Dt.Visible = False
            End If

            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_Net_DtSpecified Then

                ' If the OTW_On_Net_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_On_Net_Dt, "d")

                Me.OTW_On_Net_Dt.Text = formattedValue

            Else

                ' OTW_On_Net_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Me.OTW_On_Net_Dt.Text = Request_MasterTable.OTW_On_Net_Dt.Format(Request_MasterTable.OTW_On_Net_Dt.DefaultValue, "d")

            End If

        End Sub

		Public Overrides Sub SetIROC_Id()
            
        
            ' Set the IROC_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id()
            ' and add your own code before or after the call to the MyBase function.
            '--Ryee


            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then

                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                If Me.Pending_Action_Needed.Text = "Enter Contact" Then
                    Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                    Me.IROC_Id.Text = formattedValue
                Else
                    Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.IROC_Id)
                    formattedValue = HttpUtility.HtmlEncode(formattedValue)
                    Me.IROC_Id.Text = formattedValue
                End If
            Else

                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.

                Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                Me.IROC_Id.Text = formattedValue
            End If
        End Sub

		Public Overrides Sub SetIROC_Id1()


            ' Set the IROC_Id Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id1 is the ASP:Literal on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id1()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then

                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                If Me.Pending_Action_Needed.Text = "Enter Contact" Then
                    Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                    Me.IROC_Id1.Text = formattedValue
                Else
                    Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.IROC_Id)
                    formattedValue = HttpUtility.HtmlEncode(formattedValue)
                    Me.IROC_Id1.Text = formattedValue
                End If
            Else

                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                Me.IROC_Id1.Text = formattedValue
            End If

        End Sub

		Public Overrides Sub SetICS_SOW_Uploaded()
            
        
            ' Set the ICS_SOW_Uploaded CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Uploaded is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetICS_SOW_Uploaded()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                									
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.
                ' The Format method will use the Display Format
                '--Ryee
                If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "SOW" And EvaluateFormula("Session(""MyUPLOAD_Request_Id"")") = EvaluateFormula("Request_Id", Me.DataSource) Then
                    Me.ICS_SOW_Uploaded.Checked = True
                Else
                    Me.ICS_SOW_Uploaded.Checked = Me.DataSource.ICS_SOW_Uploaded
                End If
            Else

                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "SOW" And EvaluateFormula("Session(""MyUPLOAD_Request_Id"")") = EvaluateFormula("Request_Id", Me.DataSource) Then
                    Me.ICS_SOW_Uploaded.Checked = True
                Else
                    If Not Me.DataSource.IsCreated Then
                        Me.ICS_SOW_Uploaded.Checked = Request_MasterTable.ICS_SOW_Uploaded.ParseValue(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue).ToBoolean()
                    End If
                End If

            End If

        End Sub

		Public Overrides Sub SetOTW_Quote()


            ' Set the OTW_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote is the ASP:TextBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote()
            ' and add your own code before or after the call to the MyBase function.



            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then

                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format

                If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "Quote" _
                   And EvaluateFormula("Session(""MyUPLOAD_Request_Id"")") = EvaluateFormula("Request_Id", Me.DataSource) _
                   And Me.Pending_Action_Needed.Text = "Quote Needed" Then   '--Ryee
                    Dim formattedValue As String = EvaluateFormula("Session(""MyUPLOAD_Quote"")")
                    formattedValue = HttpUtility.HtmlEncode(formattedValue)
                    Me.OTW_Quote.Text = formattedValue
                Else
                    Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote, "C")
                    Me.OTW_Quote.Text = formattedValue
                End If
            Else

                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "Quote" _
                   And EvaluateFormula("Session(""MyUPLOAD_Request_Id"")") = EvaluateFormula("Request_Id", Me.DataSource) _
                   And Me.Pending_Action_Needed.Text = "Quote Needed" Then   '--Ryee
                    Dim formattedValue As String = EvaluateFormula("Session(""MyUPLOAD_Quote"")")
                    formattedValue = HttpUtility.HtmlEncode(formattedValue)
                    Me.OTW_Quote.Text = formattedValue
                Else
                    Me.OTW_Quote.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue, "C")

                End If
            End If
        End Sub
    
		Public Overrides Sub SetLICS_SOW_Uploaded1()
            
        
            ' Set the ICS_SOW_Uploaded CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LICS_SOW_Uploaded1 is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetLICS_SOW_Uploaded1()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                									
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.
                ' The Format method will use the Display Format
				If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "SOW" Then
                    Me.LICS_SOW_Uploaded1.Text = "Yes"
                Else
                    Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_SOW_Uploaded)

                    formattedValue = HttpUtility.HtmlEncode(formattedValue)
                    Me.LICS_SOW_Uploaded1.Text = formattedValue
				End If
            Else
            
                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
				                '--Ryee
				If EvaluateFormula("Session(""MyUPLOAD_Desc"")") = "SOW" Then
                    Me.LICS_SOW_Uploaded1.Text = "Yes"
				Else
                    'If Not Me.DataSource.IsCreated Then
                    ' Me.LICS_SOW_Uploaded1.Checked = Request_MasterTable.ICS_SOW_Uploaded.ParseValue(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue).ToBoolean()
                    'End If

                    ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                    ' Default Value could also be NULL.

                    Me.LICS_SOW_Uploaded1.Text = Request_MasterTable.ICS_SOW_Uploaded.Format(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue)

                End If

                ' If the ICS_SOW_Uploaded is NULL or blank, then use the value specified  
                ' on Properties.
                If Me.LICS_SOW_Uploaded1.Text Is Nothing _
                    OrElse Me.LICS_SOW_Uploaded1.Text.Trim() = "" Then
                    ' Set the value specified on the Properties.
                    Me.LICS_SOW_Uploaded1.Text = "&nbsp;"
                End If
            End If
        End Sub

    End Class



#End Region



#Region "Section 2: Do not modify this section."
    
    
' Base class for the CommentsTableControlRow control on the Edit_Request_Master page.
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
        
                SetComment()
                SetComment_To_Agency()
                SetComment_Topic()
                SetCreated_By()
                SetAgency()
                SetComment_Dt()
      
      
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
            		
                End If
                 
        End Sub
                
        Public Overridable Sub SetAgency()
            
        
            ' Set the Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Agency is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Agency.Text = formattedValue
                
            Else 
            		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Comment_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comment_Dt.Text = formattedValue
                
            Else 
            		
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
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
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
        
            GetComment()
            GetComment_To_Agency()
            GetComment_Topic()
            GetCreated_By()
            GetAgency()
            GetComment_Dt()
        End Sub
        
        
        Public Overridable Sub GetComment()
            
        End Sub
                
        Public Overridable Sub GetComment_To_Agency()
            
        End Sub
                
        Public Overridable Sub GetComment_Topic()
            
        End Sub
                
        Public Overridable Sub GetCreated_By()
            
        End Sub
                
        Public Overridable Sub GetAgency()
            
        End Sub
                
        Public Overridable Sub GetComment_Dt()
            
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
        
        Public ReadOnly Property Comment() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment"), System.Web.UI.WebControls.Literal)
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
            
        Public ReadOnly Property Agency() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Comment_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Dt"), System.Web.UI.WebControls.Literal)
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

  

' Base class for the CommentsTableControl control on the Edit_Request_Master page.
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
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
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
          
              AddHandler Me.CommentsAddButton1.Click, AddressOf CommentsAddButton1_Click
              
              Me.CommentsAddButton1.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.Page.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
                    
        
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
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(CommentsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(CommentsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
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
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("CommentsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
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
        
                        If recControl.Comment.Text <> "" Then
                            rec.Parse(recControl.Comment.Text, CommentsTable.Comment)
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
                        If recControl.Agency.Text <> "" Then
                            rec.Parse(recControl.Agency.Text, CommentsTable.Agency)
                        End If
                        If recControl.Comment_Dt.Text <> "" Then
                            rec.Parse(recControl.Comment_Dt.Text, CommentsTable.Comment_Dt)
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
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
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
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsAddButton1_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Add-Comments-Pop-up.aspx?Request_id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Pending_Agency}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.Page.IsPageRefresh) Then         
                  Me.Page.SaveData()
              End If        
        
            
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          Me.Page.CommitTransaction(sender)
          ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
          Dim recCtl As CommentsTableControlRow
          For Each recCtl in Me.GetRecordControls()
            
            recCtl.IsNewRecord = False
          Next
    
      
          ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
          
                Me.DeletedRecordIds = Nothing
            
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
        
        Public ReadOnly Property CommentsAddButton1() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsAddButton1"), System.Web.UI.WebControls.ImageButton)
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

  
' Base class for the ContactsTableControlRow control on the Edit_Request_Master page.
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
        
              ' Show confirmation message on Click
              Me.ContactsRowDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteRecordConfirm", "IROC2") & """));")
                  
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.ContactsRowDeleteButton.Click, AddressOf ContactsRowDeleteButton_Click
              
              AddHandler Me.ContactsRowEditButton.Click, AddressOf ContactsRowEditButton_Click
              
    
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Agency1.Text = formattedValue
                
            Else 
            		
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
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
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
                                
                
			Me.Page.Authorize(Ctype(ContactsRowDeleteButton, Control), "NOT_ANONYMOUS")
					
			Me.Page.Authorize(Ctype(ContactsRowEditButton, Control), "NOT_ANONYMOUS")
											
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
        Public Overridable Sub ContactsRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Dim tc As ContactsTableControl = DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl)
                If Not (IsNothing(tc)) Then
                    If Not Me.IsNewRecord Then
                        tc.AddToDeletedRecordIds(DirectCast(Me, ContactsTableControlRow))
                    End If
                    Me.Visible = False
                    tc.SetFormulaControls()
                End If
              
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
        Public Overridable Sub ContactsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Contacts/Edit-Contacts.aspx?Contacts={PK}"
                
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
            
        Public ReadOnly Property ContactsRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRowEditButton"), System.Web.UI.WebControls.ImageButton)
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

  

' Base class for the ContactsTableControl control on the Edit_Request_Master page.
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
          
              AddHandler Me.ContactsAddButton.Click, AddressOf ContactsAddButton_Click
              
              Me.ContactsAddButton.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.Page.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
                    
        
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
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(ContactsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(ContactsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
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
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("ContactsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
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
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.AddressLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetAgencyLabel2()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.AgencyLabel2.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCityLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.CityLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetEmailLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.EmailLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetMobileLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.MobileLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetNameLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.NameLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetTitleLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.TitleLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetTypeLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.TypeLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetWork_PhoneLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Work_PhoneLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetZipLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ZipLabel.Text = "Some value"
                    
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
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
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
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsAddButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Contacts/Add-Contacts-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Pending_Agency}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.Page.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          Me.Page.CommitTransaction(sender)
          ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
          Dim recCtl As ContactsTableControlRow
          For Each recCtl in Me.GetRecordControls()
            
            recCtl.IsNewRecord = False
          Next
    
      
          ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
          
                Me.DeletedRecordIds = Nothing
            
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
        
        Public ReadOnly Property ContactsAddButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsAddButton"), System.Web.UI.WebControls.ImageButton)
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

  
' Base class for the UploadsTableControlRow control on the Edit_Request_Master page.
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
          
              AddHandler Me.UploadsRowEditButton.Click, AddressOf UploadsRowEditButton_Click
              
    
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
                SetUPLOAD_DOCImage()
                SetUPLOAD_Dt()
                SetUPLOAD_File()
                
                SetUPLOAD_Desc()
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
            		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_DOCImage()
                
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DOCSpecified Then
                
                Me.UPLOAD_DOCImage.Text = Me.DataSource.UPLOAD_File
                Me.UPLOAD_DOCImage.ToolTip = "Open " & Me.UPLOAD_DOCImage.Text
				   If String.IsNullOrEmpty(Me.UPLOAD_DOCImage.Text) Then
					      Me.UPLOAD_DOCImage.Text = Page.GetResourceValue("Txt:OpenFile", "IROC2")
                Me.UPLOAD_DOCImage.ToolTip = Me.UPLOAD_DOCImage.Text
				   End If
						
                Me.UPLOAD_DOCImage.OnClientClick = "window.open('../Shared/ExportFieldValue.aspx?Table=" & _
                            Me.Page.Encrypt("Uploads") & _
                            "&Field=" & Me.Page.Encrypt("UPLOAD_DOC") & _
                            "&Record=" & Me.Page.Encrypt(HttpUtility.UrlEncode(Me.DataSource.GetID().ToString())) & _
                            "&Filename=" & Me.DataSource.UPLOAD_File & _
                            "','','left=100,top=50,width=400,height=300,resizable, scrollbars=1');return false;"
                   
                Me.UPLOAD_DOCImage.Visible = True
            Else
                Me.UPLOAD_DOCImage.Visible = False
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Dt.Text = formattedValue
                
            Else 
            		
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
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
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
            GetUPLOAD_Dt()
            GetUPLOAD_File()
            GetUPLOAD_Desc()
            GetUPLOAD_Quote()
        End Sub
        
        
        Public Overridable Sub GetUPLOAD_Comments()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Created_By()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Dt()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_File()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Desc()
            
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
        
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Uploads/Edit-Uploads.aspx?Uploads={PK}"
                
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
            
        Public ReadOnly Property UPLOAD_DOCImage() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOCImage"), System.Web.UI.WebControls.LinkButton)
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
            
        Public ReadOnly Property UploadsRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsRowEditButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Desc() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Desc"), System.Web.UI.WebControls.Literal)
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

  

' Base class for the UploadsTableControl control on the Edit_Request_Master page.
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
            
                Me.CurrentSortOrder.Add(UploadsTable.Upload_Id, OrderByItem.OrderDir.Desc)
              
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
          
              AddHandler Me.UploadsAddButton.Click, AddressOf UploadsAddButton_Click
                      
        
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
            
                Me.CurrentSortOrder.Add(UploadsTable.Upload_Id, OrderByItem.OrderDir.Desc)
                  
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
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(UploadsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
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
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("UploadsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
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
                        If recControl.UPLOAD_DOCImage.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_DOCImage.Text, UploadsTable.UPLOAD_DOC)
                        End If
                        If recControl.UPLOAD_Dt.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Dt.Text, UploadsTable.UPLOAD_Dt)
                        End If
                        If recControl.UPLOAD_File.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_File.Text, UploadsTable.UPLOAD_File)
                        End If
                        If recControl.UPLOAD_Desc.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Desc.Text, UploadsTable.UPLOAD_Desc)
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
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
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
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsAddButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Uploads/Add-Uploads-Pop-up.aspx?Request_Master={Request_MasterRecordControl:FV:Request_Id}"
                
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
        
        Public ReadOnly Property UploadsAddButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsAddButton"), System.Web.UI.WebControls.ImageButton)
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

  
' Base class for the Request_MasterRecordControl control on the Edit_Request_Master page.
' Do not modify this class. Instead override any method in Request_MasterRecordControl.
Public Class BaseRequest_MasterRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in Request_MasterRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in Request_MasterRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.Cat_Franchise_Order_Number2.SelectedIndexChanged, AddressOf Cat_Franchise_Order_Number2_SelectedIndexChanged
            
              AddHandler Me.OTW_Construction_Status.SelectedIndexChanged, AddressOf OTW_Construction_Status_SelectedIndexChanged
            
              AddHandler Me.OTW_Permit_Status.SelectedIndexChanged, AddressOf OTW_Permit_Status_SelectedIndexChanged
            
              AddHandler Me.Priority.SelectedIndexChanged, AddressOf Priority_SelectedIndexChanged
            
              AddHandler Me.Cat_Cost_Free.CheckedChanged, AddressOf Cat_Cost_Free_CheckedChanged
            
              AddHandler Me.Cat_Cost_Free1.CheckedChanged, AddressOf Cat_Cost_Free1_CheckedChanged
            
              AddHandler Me.ICS_SOW_Needed.CheckedChanged, AddressOf ICS_SOW_Needed_CheckedChanged
            
              AddHandler Me.ICS_SOW_Uploaded.CheckedChanged, AddressOf ICS_SOW_Uploaded_CheckedChanged
            
              AddHandler Me.LICS_SOW_Needed1.CheckedChanged, AddressOf LICS_SOW_Needed1_CheckedChanged
            
              AddHandler Me.Cat_OTWC_Comments.TextChanged, AddressOf Cat_OTWC_Comments_TextChanged
            
              AddHandler Me.ICS_CATV_Comments.TextChanged, AddressOf ICS_CATV_Comments_TextChanged
            
              AddHandler Me.OTW_Completed_Dt.TextChanged, AddressOf OTW_Completed_Dt_TextChanged
            
              AddHandler Me.OTW_Deployment_Start_Dt.TextChanged, AddressOf OTW_Deployment_Start_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_Amt.TextChanged, AddressOf OTW_Invoice_Amt_TextChanged
            
              AddHandler Me.OTW_Invoice_Dt.TextChanged, AddressOf OTW_Invoice_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_No.TextChanged, AddressOf OTW_Invoice_No_TextChanged
            
              AddHandler Me.OTW_More_Info_Comments.TextChanged, AddressOf OTW_More_Info_Comments_TextChanged
            
              AddHandler Me.OTW_On_Net_Dt.TextChanged, AddressOf OTW_On_Net_Dt_TextChanged
            
              AddHandler Me.OTW_Projected_Deploy_Dt.TextChanged, AddressOf OTW_Projected_Deploy_Dt_TextChanged
            
              AddHandler Me.OTW_Scheduled_Deploy_Dt.TextChanged, AddressOf OTW_Scheduled_Deploy_Dt_TextChanged
            
              AddHandler Me.Pending_Action_Dt1.TextChanged, AddressOf Pending_Action_Dt1_TextChanged
            
              AddHandler Me.Pending_Action_Needed1.TextChanged, AddressOf Pending_Action_Needed1_TextChanged
            
              AddHandler Me.Pending_Agency_Return.TextChanged, AddressOf Pending_Agency_Return_TextChanged
            
              AddHandler Me.Pending_Agency1.TextChanged, AddressOf Pending_Agency1_TextChanged
            
              AddHandler Me.Pending_Prev_Action_Needed.TextChanged, AddressOf Pending_Prev_Action_Needed_TextChanged
            
              AddHandler Me.Pending_Prev_Status.TextChanged, AddressOf Pending_Prev_Status_TextChanged
            
              AddHandler Me.Prov_Name.TextChanged, AddressOf Prov_Name_TextChanged
            
              AddHandler Me.Reg_Type1.TextChanged, AddressOf Reg_Type1_TextChanged
            
              AddHandler Me.Req_Comments.TextChanged, AddressOf Req_Comments_TextChanged
            
              AddHandler Me.Req_Completed_Dt.TextChanged, AddressOf Req_Completed_Dt_TextChanged
            
              AddHandler Me.Req_Enity2.TextChanged, AddressOf Req_Enity2_TextChanged
            
              AddHandler Me.Req_PO_Amt.TextChanged, AddressOf Req_PO_Amt_TextChanged
            
              AddHandler Me.Req_PO_Dt.TextChanged, AddressOf Req_PO_Dt_TextChanged
            
              AddHandler Me.Req_PO_No.TextChanged, AddressOf Req_PO_No_TextChanged
            
              AddHandler Me.Req_Pymt_Amt.TextChanged, AddressOf Req_Pymt_Amt_TextChanged
            
              AddHandler Me.Req_Pymt_Dt.TextChanged, AddressOf Req_Pymt_Dt_TextChanged
            
              AddHandler Me.Req_Quote_Approved.TextChanged, AddressOf Req_Quote_Approved_TextChanged
            
              AddHandler Me.Req_Status.TextChanged, AddressOf Req_Status_TextChanged
            
              AddHandler Me.Request_Id.TextChanged, AddressOf Request_Id_TextChanged
            
              AddHandler Me.IROC_Id.TextChanged, AddressOf IROC_Id_TextChanged
            
              AddHandler Me.OTW_Quote.TextChanged, AddressOf OTW_Quote_TextChanged
            
    
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
        
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "Request_MasterRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New Request_MasterRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As Request_MasterRecord = Request_MasterTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = Request_MasterTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in Request_MasterRecordControl.
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
          
                  LoadData_Role_IDMaxQuery()
       
                  LoadData_Role_IDMaxQuery1()
       
                  LoadData_Role_IDMaxQuery10()
       
                  LoadData_Role_IDMaxQuery11()
       
                  LoadData_Role_IDMaxQuery12()
       
                  LoadData_Role_IDMaxQuery13()
       
                  LoadData_Role_IDMaxQuery14()
       
                  LoadData_Role_IDMaxQuery15()
       
                  LoadData_Role_IDMaxQuery16()
       
                  LoadData_Role_IDMaxQuery17()
       
                  LoadData_Role_IDMaxQuery18()
       
                  LoadData_Role_IDMaxQuery19()
       
                  LoadData_Role_IDMaxQuery2()
       
                  LoadData_Role_IDMaxQuery20()
       
                  LoadData_Role_IDMaxQuery21()
       
                  LoadData_Role_IDMaxQuery22()
       
                  LoadData_Role_IDMaxQuery23()
       
                  LoadData_Role_IDMaxQuery24()
       
                  LoadData_Role_IDMaxQuery25()
       
                  LoadData_Role_IDMaxQuery26()
       
                  LoadData_Role_IDMaxQuery27()
       
                  LoadData_Role_IDMaxQuery28()
       
                  LoadData_Role_IDMaxQuery29()
       
                  LoadData_Role_IDMaxQuery3()
       
                  LoadData_Role_IDMaxQuery30()
       
                  LoadData_Role_IDMaxQuery31()
       
                  LoadData_Role_IDMaxQuery4()
       
                  LoadData_Role_IDMaxQuery5()
       
                  LoadData_Role_IDMaxQuery6()
       
                  LoadData_Role_IDMaxQuery7()
       
                  LoadData_Role_IDMaxQuery8()
       
                  LoadData_Role_IDMaxQuery9()
       
      
      
            ' Call the Set methods for each controls on the panel
        
                SetCat_Cost_Free()
                SetCat_Cost_Free1()
                SetCat_Cost_FreeLabel()
                SetCat_Cost_FreeLabel1()
                SetCat_Franchise_Order_Number2()
                SetCat_Franchise_Order_NumberLabel()
                SetCat_Franchise_Order_NumberLabel1()
                SetCat_OTWC_Comments()
                SetCat_OTWC_CommentsLabel()
                SetICS_CATV_Comments()
                SetICS_CATV_CommentsLabel()
                SetICS_SOW_Needed()
                SetICS_SOW_NeededLabel()
                SetICS_SOW_NeededLabel1()
                SetICS_SOW_Uploaded()
                SetICS_SOW_UploadedLabel1()
                SetIROC_IdLabel1()
                SetLabel_Quote_Instr()
                SetLCat_Franchise_Order_Number21()
                SetLICS_SOW_Needed1()
                SetLICS_SOW_Uploaded1()
                SetLOTW_Completed_Dt1()
                SetLOTW_Construction_Status1()
                SetLOTW_Deployment_Start_Dt1()
                SetLOTW_Invoice_Amt1()
                SetLOTW_Invoice_No1()
                SetLOTW_On_Net_Dt1()
                SetLOTW_Permit_Status1()
                SetLOTW_Projected_Deploy_Dt1()
                SetLOTW_Quote1()
                SetLOTW_Scheduled_Deploy_Dt1()
                SetLPending_Action_Dt()
                SetLPending_Agency()
                SetLPriority1()
                SetLProv_Name1()
                SetLReg_Type()
                SetLReq_Enity21()
                SetLReq_PO_Dt1()
                SetLReq_PO_No2()
                SetLReq_Pymt_Dt1()
                SetLReq_Quote_Approved1()
                SetLReq_Status1()
                SetOTW_Completed_Dt()
                SetOTW_Completed_DtLabel()
                SetOTW_Completed_DtLabel1()
                SetOTW_Construction_Status()
                SetOTW_Construction_StatusLabel()
                SetOTW_Construction_StatusLabel1()
                SetOTW_Deployment_Start_Dt()
                SetOTW_Deployment_Start_DtLabel()
                SetOTW_Deployment_Start_DtLabel1()
                SetOTW_Invoice_Amt()
                SetOTW_Invoice_AmtLabel()
                SetOTW_Invoice_AmtLabel1()
                SetOTW_Invoice_Dt()
                SetOTW_Invoice_Dt1()
                SetOTW_Invoice_DtLabel()
                SetOTW_Invoice_DtLabel1()
                SetOTW_Invoice_No()
                SetOTW_Invoice_NoLabel()
                SetOTW_Invoice_NoLabel1()
                SetOTW_More_Info_Comments()
                SetOTW_More_Info_CommentsLabel()
                SetOTW_On_Net_Dt()
                SetOTW_On_Net_DtLabel()
                SetOTW_On_Net_DtLabel1()
                SetOTW_Permit_Status()
                SetOTW_Permit_StatusLabel()
                SetOTW_Permit_StatusLabel1()
                SetOTW_Projected_Deploy_Dt()
                SetOTW_Projected_Deploy_DtLabel()
                SetOTW_Projected_Deploy_DtLabel1()
                SetOTW_QuoteLabel()
                SetOTW_QuoteLabel1()
                SetOTW_Scheduled_Deploy_Dt()
                SetOTW_Scheduled_Deploy_DtLabel()
                SetOTW_Scheduled_Deploy_DtLabel1()
                SetPending_Action_Dt1()
                SetPending_Action_DtLabel()
                SetPending_Action_DtLabel1()
                SetPending_Action_Needed()
                SetPending_Action_Needed1()
                SetPending_Action_NeededLabel()
                SetPending_Action_NeededLabel1()
                SetPending_Agency_Return()
                SetPending_Agency_ReturnLabel()
                SetPending_Agency1()
                SetPending_AgencyLabel()
                SetPending_AgencyLabel1()
                SetPending_Prev_Action_Needed()
                SetPending_Prev_Action_NeededLabel()
                SetPending_Prev_Status()
                SetPending_Prev_StatusLabel()
                SetPriority()
                SetPriorityLabel()
                SetPriorityLabel1()
                SetProv_Name()
                SetProv_NameLabel()
                SetProv_NameLabel1()
                SetReg_Type1()
                SetReg_TypeLabel()
                SetReg_TypeLabel1()
                SetReq_Address1()
                SetReq_AddressLabel1()
                SetReq_City1()
                SetReq_CityLabel1()
                SetReq_Comments()
                SetReq_CommentsLabel()
                SetReq_Completed_Dt()
                SetReq_Completed_DtLabel()
                SetReq_Contact_Email()
                SetReq_Contact_EmailLabel()
                SetReq_Dt1()
                SetReq_DtLabel1()
                SetReq_Enity2()
                SetReq_EnityLabel()
                SetReq_EnityLabel1()
                SetReq_Funding_Src2()
                SetReq_Funding_SrcLabel1()
                SetReq_Island1()
                SetReq_IslandLabel1()
                SetReq_PO_Amt()
                SetReq_PO_Amt1()
                SetReq_PO_AmtLabel()
                SetReq_PO_AmtLabel1()
                SetReq_PO_Dt()
                SetReq_PO_DtLabel()
                SetReq_PO_DtLabel1()
                SetReq_PO_No()
                SetReq_PO_NoLabel()
                SetReq_PO_NoLabel1()
                SetReq_Pymt_Amt()
                SetReq_Pymt_Amt1()
                SetReq_Pymt_AmtLabel()
                SetReq_Pymt_AmtLabel1()
                SetReq_Pymt_Dt()
                SetReq_Pymt_DtLabel()
                SetReq_Pymt_DtLabel1()
                SetReq_Quote_Approved()
                SetReq_Quote_ApprovedLabel()
                SetReq_Quote_ApprovedLabel1()
                SetReq_Site_Name1()
                SetReq_Site_NameLabel1()
                SetReq_State1()
                SetReq_StateLabel1()
                SetReq_Status()
                SetReq_StatusLabel()
                SetReq_StatusLabel1()
                SetReq_Target_Dt1()
                SetReq_Target_DtLabel1()
                SetReq_Zip1()
                SetReq_ZipLabel1()
                SetRequest_Id()
                SetRequest_IdLabel()
                
                
                SetRole_IDMaxControl()
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                SetIROC_Id()
                SetIROC_Id1()
                SetOTW_Quote()
      
      
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
            
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "CommentsTableControl"), CommentsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recCommentsTableControl.ResetControl()
            End IF
        
        recCommentsTableControl.LoadData()
        recCommentsTableControl.DataBind()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "ContactsTableControl"), ContactsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recContactsTableControl.ResetControl()
            End IF
        
        recContactsTableControl.LoadData()
        recContactsTableControl.DataBind()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "UploadsTableControl"), UploadsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recUploadsTableControl.ResetControl()
            End IF
        
        recUploadsTableControl.LoadData()
        recUploadsTableControl.DataBind()
        
        End Sub
        
        
        Public Overridable Sub SetCat_Cost_Free()
            
        
            ' Set the Cat_Cost_Free CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Cost_Free is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetCat_Cost_Free()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Cost_FreeSpecified Then
                									
                ' If the Cat_Cost_Free is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.Cat_Cost_Free.Checked = Me.DataSource.Cat_Cost_Free
            Else
            
                ' Cat_Cost_Free is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.Cat_Cost_Free.Checked = Request_MasterTable.Cat_Cost_Free.ParseValue(Request_MasterTable.Cat_Cost_Free.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetCat_Cost_Free1()
            
        
            ' Set the Cat_Cost_Free CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Cost_Free1 is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetCat_Cost_Free1()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Cost_FreeSpecified Then
                									
                ' If the Cat_Cost_Free is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.Cat_Cost_Free1.Checked = Me.DataSource.Cat_Cost_Free
            Else
            
                ' Cat_Cost_Free is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.Cat_Cost_Free1.Checked = Request_MasterTable.Cat_Cost_Free.ParseValue(Request_MasterTable.Cat_Cost_Free.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_Number2()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Cat_Franchise_Order_Number2 DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Franchise_Order_Number2 is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Franchise_Order_Number2()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_Number2Specified Then
                            
                ' If the Cat_Franchise_Order_Number2 is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Cat_Franchise_Order_Number2
            Else
                
                ' Cat_Franchise_Order_Number2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Cat_Franchise_Order_Number2.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateCat_Franchise_Order_Number2DropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetCat_OTWC_Comments()
            
        
            ' Set the Cat_OTWC_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_OTWC_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_OTWC_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_OTWC_CommentsSpecified Then
                				
                ' If the Cat_OTWC_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_OTWC_Comments)
                              
                Me.Cat_OTWC_Comments.Text = formattedValue
                
            Else 
            
                ' Cat_OTWC_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_OTWC_Comments.Text = Request_MasterTable.Cat_OTWC_Comments.Format(Request_MasterTable.Cat_OTWC_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetICS_CATV_Comments()
            
        
            ' Set the ICS_CATV_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_CATV_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetICS_CATV_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_CATV_CommentsSpecified Then
                				
                ' If the ICS_CATV_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_CATV_Comments)
                              
                Me.ICS_CATV_Comments.Text = formattedValue
                
            Else 
            
                ' ICS_CATV_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.ICS_CATV_Comments.Text = Request_MasterTable.ICS_CATV_Comments.Format(Request_MasterTable.ICS_CATV_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetICS_SOW_Needed()
            
        
            ' Set the ICS_SOW_Needed CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Needed is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetICS_SOW_Needed()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_NeededSpecified Then
                									
                ' If the ICS_SOW_Needed is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.ICS_SOW_Needed.Checked = Me.DataSource.ICS_SOW_Needed
            Else
            
                ' ICS_SOW_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.ICS_SOW_Needed.Checked = Request_MasterTable.ICS_SOW_Needed.ParseValue(Request_MasterTable.ICS_SOW_Needed.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetICS_SOW_Uploaded()
            
        
            ' Set the ICS_SOW_Uploaded CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Uploaded is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetICS_SOW_Uploaded()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                									
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.ICS_SOW_Uploaded.Checked = Me.DataSource.ICS_SOW_Uploaded
            Else
            
                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.ICS_SOW_Uploaded.Checked = Request_MasterTable.ICS_SOW_Uploaded.ParseValue(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetLCat_Franchise_Order_Number21()
            
        
            ' Set the Cat_Franchise_Order_Number2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LCat_Franchise_Order_Number21 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLCat_Franchise_Order_Number21()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_Number2Specified Then
                				
                ' If the Cat_Franchise_Order_Number2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Franchise_Order_Number2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LCat_Franchise_Order_Number21.Text = formattedValue
                
            Else 
            
                ' Cat_Franchise_Order_Number2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LCat_Franchise_Order_Number21.Text = Request_MasterTable.Cat_Franchise_Order_Number2.Format(Request_MasterTable.Cat_Franchise_Order_Number2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLICS_SOW_Needed1()
            
        
            ' Set the ICS_SOW_Needed CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LICS_SOW_Needed1 is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetLICS_SOW_Needed1()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_NeededSpecified Then
                									
                ' If the ICS_SOW_Needed is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.LICS_SOW_Needed1.Checked = Me.DataSource.ICS_SOW_Needed
            Else
            
                ' ICS_SOW_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.LICS_SOW_Needed1.Checked = Request_MasterTable.ICS_SOW_Needed.ParseValue(Request_MasterTable.ICS_SOW_Needed.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetLICS_SOW_Uploaded1()
            
        
            ' Set the ICS_SOW_Uploaded Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LICS_SOW_Uploaded1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLICS_SOW_Uploaded1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                				
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_SOW_Uploaded)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LICS_SOW_Uploaded1.Text = formattedValue
                
            Else 
            
                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LICS_SOW_Uploaded1.Text = Request_MasterTable.ICS_SOW_Uploaded.Format(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue)
                        		
                End If
                 
            ' If the ICS_SOW_Uploaded is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.LICS_SOW_Uploaded1.Text Is Nothing _
                OrElse Me.LICS_SOW_Uploaded1.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.LICS_SOW_Uploaded1.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetLOTW_Completed_Dt1()
            
        
            ' Set the OTW_Completed_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Completed_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Completed_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Completed_DtSpecified Then
                				
                ' If the OTW_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Completed_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Completed_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Completed_Dt1.Text = Request_MasterTable.OTW_Completed_Dt.Format(Request_MasterTable.OTW_Completed_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Construction_Status1()
            
        
            ' Set the OTW_Construction_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Construction_Status1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Construction_Status1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Construction_StatusSpecified Then
                				
                ' If the OTW_Construction_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Construction_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Construction_Status1.Text = formattedValue
                
            Else 
            
                ' OTW_Construction_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Construction_Status1.Text = Request_MasterTable.OTW_Construction_Status.Format(Request_MasterTable.OTW_Construction_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Deployment_Start_Dt1()
            
        
            ' Set the OTW_Deployment_Start_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Deployment_Start_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Deployment_Start_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Deployment_Start_DtSpecified Then
                				
                ' If the OTW_Deployment_Start_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Deployment_Start_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Deployment_Start_Dt1.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Invoice_Amt1()
            
        
            ' Set the OTW_Invoice_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Invoice_Amt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Invoice_Amt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_AmtSpecified Then
                				
                ' If the OTW_Invoice_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Invoice_Amt1.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Invoice_Amt1.Text = Request_MasterTable.OTW_Invoice_Amt.Format(Request_MasterTable.OTW_Invoice_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Invoice_No1()
            
        
            ' Set the OTW_Invoice_No Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Invoice_No1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Invoice_No1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_NoSpecified Then
                				
                ' If the OTW_Invoice_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_No)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Invoice_No1.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Invoice_No1.Text = Request_MasterTable.OTW_Invoice_No.Format(Request_MasterTable.OTW_Invoice_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_On_Net_Dt1()
            
        
            ' Set the OTW_On_Net_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_On_Net_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_On_Net_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_Net_DtSpecified Then
                				
                ' If the OTW_On_Net_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_On_Net_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_On_Net_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_On_Net_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_On_Net_Dt1.Text = Request_MasterTable.OTW_On_Net_Dt.Format(Request_MasterTable.OTW_On_Net_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Permit_Status1()
            
        
            ' Set the OTW_Permit_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Permit_Status1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Permit_Status1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Permit_StatusSpecified Then
                				
                ' If the OTW_Permit_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Permit_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Permit_Status1.Text = formattedValue
                
            Else 
            
                ' OTW_Permit_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Permit_Status1.Text = Request_MasterTable.OTW_Permit_Status.Format(Request_MasterTable.OTW_Permit_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Projected_Deploy_Dt1()
            
        
            ' Set the OTW_Projected_Deploy_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Projected_Deploy_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Projected_Deploy_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Projected_Deploy_DtSpecified Then
                				
                ' If the OTW_Projected_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Projected_Deploy_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Projected_Deploy_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Projected_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Projected_Deploy_Dt1.Text = Request_MasterTable.OTW_Projected_Deploy_Dt.Format(Request_MasterTable.OTW_Projected_Deploy_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Quote1()
            
        
            ' Set the OTW_Quote Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Quote1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Quote1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Quote1.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Quote1.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLOTW_Scheduled_Deploy_Dt1()
            
        
            ' Set the OTW_Scheduled_Deploy_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LOTW_Scheduled_Deploy_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLOTW_Scheduled_Deploy_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Scheduled_Deploy_DtSpecified Then
                				
                ' If the OTW_Scheduled_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LOTW_Scheduled_Deploy_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LOTW_Scheduled_Deploy_Dt1.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLPending_Action_Dt()
            
        
            ' Set the Pending Action_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LPending_Action_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLPending_Action_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Action_DtSpecified Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LPending_Action_Dt.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LPending_Action_Dt.Text = Request_MasterTable.Pending_Action_Dt.Format(Request_MasterTable.Pending_Action_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLPending_Agency()
            
        
            ' Set the Pending_Agency Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LPending_Agency is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLPending_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_AgencySpecified Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LPending_Agency.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LPending_Agency.Text = Request_MasterTable.Pending_Agency.Format(Request_MasterTable.Pending_Agency.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLPriority1()
            
        
            ' Set the Priority Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LPriority1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLPriority1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.PrioritySpecified Then
                				
                ' If the Priority is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Priority)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LPriority1.Text = formattedValue
                
            Else 
            
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LPriority1.Text = Request_MasterTable.Priority.Format(Request_MasterTable.Priority.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLProv_Name1()
            
        
            ' Set the Prov_Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LProv_Name1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLProv_Name1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Prov_NameSpecified Then
                				
                ' If the Prov_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Prov_Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LProv_Name1.Text = formattedValue
                
            Else 
            
                ' Prov_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LProv_Name1.Text = Request_MasterTable.Prov_Name.Format(Request_MasterTable.Prov_Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReg_Type()
            
        
            ' Set the Reg_Type Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReg_Type is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReg_Type()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReg_Type.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReg_Type.Text = Request_MasterTable.Reg_Type.Format(Request_MasterTable.Reg_Type.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_Enity21()
            
        
            ' Set the Req_Enity2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_Enity21 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_Enity21()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Enity2Specified Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_Enity21.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_Enity21.Text = Request_MasterTable.Req_Enity2.Format(Request_MasterTable.Req_Enity2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_PO_Dt1()
            
        
            ' Set the Req_PO_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_PO_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_PO_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_DtSpecified Then
                				
                ' If the Req_PO_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_PO_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_PO_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_PO_Dt1.Text = Request_MasterTable.Req_PO_Dt.Format(Request_MasterTable.Req_PO_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_PO_No2()
            
        
            ' Set the Req_PO_No Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_PO_No2 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_PO_No2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_NoSpecified Then
                				
                ' If the Req_PO_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_No)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_PO_No2.Text = formattedValue
                
            Else 
            
                ' Req_PO_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_PO_No2.Text = Request_MasterTable.Req_PO_No.Format(Request_MasterTable.Req_PO_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_Pymt_Dt1()
            
        
            ' Set the Req_Pymt_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_Pymt_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_Pymt_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_DtSpecified Then
                				
                ' If the Req_Pymt_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_Pymt_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_Pymt_Dt1.Text = Request_MasterTable.Req_Pymt_Dt.Format(Request_MasterTable.Req_Pymt_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_Quote_Approved1()
            
        
            ' Set the Req_Quote_Approved Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_Quote_Approved1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_Quote_Approved1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_ApprovedSpecified Then
                				
                ' If the Req_Quote_Approved is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Approved, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_Quote_Approved1.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Approved is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_Quote_Approved1.Text = Request_MasterTable.Req_Quote_Approved.Format(Request_MasterTable.Req_Quote_Approved.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_Status1()
            
        
            ' Set the Req_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_Status1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_Status1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StatusSpecified Then
                				
                ' If the Req_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_Status1.Text = formattedValue
                
            Else 
            
                ' Req_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_Status1.Text = Request_MasterTable.Req_Status.Format(Request_MasterTable.Req_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Completed_Dt()
            
        
            ' Set the OTW_Completed_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Completed_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Completed_DtSpecified Then
                				
                ' If the OTW_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Completed_Dt, "d")
                              
                Me.OTW_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Completed_Dt.Text = Request_MasterTable.OTW_Completed_Dt.Format(Request_MasterTable.OTW_Completed_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Construction_Status()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the OTW_Construction_Status DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Construction_Status is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Construction_Status()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Construction_StatusSpecified Then
                            
                ' If the OTW_Construction_Status is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.OTW_Construction_Status
            Else
                
                ' OTW_Construction_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.OTW_Construction_Status.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateOTW_Construction_StatusDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_Dt()
            
        
            ' Set the OTW_Deployment_Start_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Deployment_Start_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Deployment_Start_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Deployment_Start_DtSpecified Then
                				
                ' If the OTW_Deployment_Start_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "d")
                              
                Me.OTW_Deployment_Start_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Deployment_Start_Dt.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Amt()
            
        
            ' Set the OTW_Invoice_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_AmtSpecified Then
                				
                ' If the OTW_Invoice_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Amt, "C")
                              
                Me.OTW_Invoice_Amt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Amt.Text = Request_MasterTable.OTW_Invoice_Amt.Format(Request_MasterTable.OTW_Invoice_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Dt()
            
        
            ' Set the OTW_Invoice_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_DtSpecified Then
                				
                ' If the OTW_Invoice_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Dt, "d")
                              
                Me.OTW_Invoice_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Dt.Text = Request_MasterTable.OTW_Invoice_Dt.Format(Request_MasterTable.OTW_Invoice_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Dt1()
            
        
            ' Set the OTW_Invoice_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_DtSpecified Then
                				
                ' If the OTW_Invoice_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Invoice_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Dt1.Text = Request_MasterTable.OTW_Invoice_Dt.Format(Request_MasterTable.OTW_Invoice_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_No()
            
        
            ' Set the OTW_Invoice_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_NoSpecified Then
                				
                ' If the OTW_Invoice_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_No)
                              
                Me.OTW_Invoice_No.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_No.Text = Request_MasterTable.OTW_Invoice_No.Format(Request_MasterTable.OTW_Invoice_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_More_Info_Comments()
            
        
            ' Set the OTW_More_Info_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_More_Info_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_More_Info_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the OTW_More_Info_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = EvaluateFormula("""""", Me.DataSource)
                Me.OTW_More_Info_Comments.Text = formattedValue
                
            Else 
            
                ' OTW_More_Info_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_More_Info_Comments.Text = Request_MasterTable.OTW_More_Info_Comments.Format(Request_MasterTable.OTW_More_Info_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_On_Net_Dt()
            
        
            ' Set the OTW_On_Net_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_On_Net_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_Net_DtSpecified Then
                				
                ' If the OTW_On_Net_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_On_Net_Dt, "d")
                              
                Me.OTW_On_Net_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_On_Net_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_On_Net_Dt.Text = Request_MasterTable.OTW_On_Net_Dt.Format(Request_MasterTable.OTW_On_Net_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Permit_Status()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the OTW_Permit_Status DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Permit_Status is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Permit_Status()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Permit_StatusSpecified Then
                            
                ' If the OTW_Permit_Status is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.OTW_Permit_Status
            Else
                
                ' OTW_Permit_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.OTW_Permit_Status.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateOTW_Permit_StatusDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_Dt()
            
        
            ' Set the OTW_Projected_Deploy_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Projected_Deploy_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Projected_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Projected_Deploy_DtSpecified Then
                				
                ' If the OTW_Projected_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Projected_Deploy_Dt, "d")
                              
                Me.OTW_Projected_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Projected_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Projected_Deploy_Dt.Text = Request_MasterTable.OTW_Projected_Deploy_Dt.Format(Request_MasterTable.OTW_Projected_Deploy_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_Dt()
            
        
            ' Set the OTW_Scheduled_Deploy_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Scheduled_Deploy_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Scheduled_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Scheduled_Deploy_DtSpecified Then
                				
                ' If the OTW_Scheduled_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "d")
                              
                Me.OTW_Scheduled_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Scheduled_Deploy_Dt.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Dt1()
            
        
            ' Set the Pending Action_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                Me.Pending_Action_Dt1.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Dt1.Text = EvaluateFormula("Format(Now(), ""D"")", Me.DataSource, "g")		
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
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Needed1()
            
        
            ' Set the Pending_Action_Needed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Needed1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Needed1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Needed)
                              
                Me.Pending_Action_Needed1.Text = formattedValue
                
            Else 
            
                ' Pending_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Needed1.Text = EvaluateFormula("""Incomplete Request""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Agency_Return()
            
        
            ' Set the Pending_Agency_Return TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency_Return is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency_Return()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Agency_ReturnSpecified Then
                				
                ' If the Pending_Agency_Return is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency_Return)
                              
                Me.Pending_Agency_Return.Text = formattedValue
                
            Else 
            
                ' Pending_Agency_Return is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency_Return.Text = Request_MasterTable.Pending_Agency_Return.Format(Request_MasterTable.Pending_Agency_Return.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Agency1()
            
        
            ' Set the Pending_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                Me.Pending_Agency1.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency1.Text = EvaluateFormula("""REQUESTOR""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Prev_Action_Needed()
            
        
            ' Set the Pending_Prev_Action_Needed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Action_Needed is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Action_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_Action_NeededSpecified Then
                				
                ' If the Pending_Prev_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Action_Needed)
                              
                Me.Pending_Prev_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Action_Needed.Text = Request_MasterTable.Pending_Prev_Action_Needed.Format(Request_MasterTable.Pending_Prev_Action_Needed.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Prev_Status()
            
        
            ' Set the Pending_Prev_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_StatusSpecified Then
                				
                ' If the Pending_Prev_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Status)
                              
                Me.Pending_Prev_Status.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Status.Text = Request_MasterTable.Pending_Prev_Status.Format(Request_MasterTable.Pending_Prev_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPriority()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Priority DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Priority is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPriority()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.PrioritySpecified Then
                            
                ' If the Priority is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Priority.ToString()
            Else
                
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Priority.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulatePriorityDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetProv_Name()
            
        
            ' Set the Prov_Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Prov_Name is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetProv_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Prov_NameSpecified Then
                				
                ' If the Prov_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Prov_Name)
                              
                Me.Prov_Name.Text = formattedValue
                
            Else 
            
                ' Prov_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Prov_Name.Text = Request_MasterTable.Prov_Name.Format(Request_MasterTable.Prov_Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReg_Type1()
            
        
            ' Set the Reg_Type TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                Me.Reg_Type1.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Reg_Type1.Text = Request_MasterTable.Reg_Type.Format(Request_MasterTable.Reg_Type.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Address1()
            
        
            ' Set the Req_Address Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Address1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Address1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_AddressSpecified Then
                				
                ' If the Req_Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Address)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Address1.Text = formattedValue
                
            Else 
            
                ' Req_Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Address1.Text = Request_MasterTable.Req_Address.Format(Request_MasterTable.Req_Address.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_City1()
            
        
            ' Set the Req_City Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_City1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_City1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CitySpecified Then
                				
                ' If the Req_City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_City)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_City1.Text = formattedValue
                
            Else 
            
                ' Req_City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_City1.Text = Request_MasterTable.Req_City.Format(Request_MasterTable.Req_City.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Comments()
            
        
            ' Set the Req_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CommentsSpecified Then
                				
                ' If the Req_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Comments)
                              
                Me.Req_Comments.Text = formattedValue
                
            Else 
            
                ' Req_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Comments.Text = Request_MasterTable.Req_Comments.Format(Request_MasterTable.Req_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Completed_Dt()
            
        
            ' Set the Req_Completed_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Completed_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Completed_DtSpecified Then
                				
                ' If the Req_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Completed_Dt, "d")
                              
                Me.Req_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Completed_Dt.Text = Request_MasterTable.Req_Completed_Dt.Format(Request_MasterTable.Req_Completed_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Contact_Email()
            
        
            ' Set the Req_Contact_Email2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Contact_Email is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Contact_Email()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Contact_Email2Specified Then
                				
                ' If the Req_Contact_Email2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Contact_Email2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Contact_Email.Text = formattedValue
                
            Else 
            
                ' Req_Contact_Email2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Contact_Email.Text = Request_MasterTable.Req_Contact_Email2.Format(Request_MasterTable.Req_Contact_Email2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Dt1()
            
        
            ' Set the Req_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt1.Text = EvaluateFormula("Format(Today(), ""d"")", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Enity2()
            
        
            ' Set the Req_Enity2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Enity2Specified Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                Me.Req_Enity2.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity2.Text = Request_MasterTable.Req_Enity2.Format(Request_MasterTable.Req_Enity2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Funding_Src2()
            
        
            ' Set the Req_Funding_Src2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Funding_Src2 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Funding_Src2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Funding_Src2Specified Then
                				
                ' If the Req_Funding_Src2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Funding_Src2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Funding_Src2.Text = formattedValue
                
            Else 
            
                ' Req_Funding_Src2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Funding_Src2.Text = Request_MasterTable.Req_Funding_Src2.Format(Request_MasterTable.Req_Funding_Src2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Island1()
            
        
            ' Set the Req_Island Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Island1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Island1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_IslandSpecified Then
                				
                ' If the Req_Island is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Island)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Island1.Text = formattedValue
                
            Else 
            
                ' Req_Island is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Island1.Text = Request_MasterTable.Req_Island.Format(Request_MasterTable.Req_Island.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_Amt()
            
        
            ' Set the Req_PO_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_AmtSpecified Then
                				
                ' If the Req_PO_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Amt, "C")
                              
                Me.Req_PO_Amt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Amt.Text = Request_MasterTable.Req_PO_Amt.Format(Request_MasterTable.Req_PO_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_Amt1()
            
        
            ' Set the Req_PO_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Amt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Amt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_AmtSpecified Then
                				
                ' If the Req_PO_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_PO_Amt1.Text = formattedValue
                
            Else 
            
                ' Req_PO_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Amt1.Text = Request_MasterTable.Req_PO_Amt.Format(Request_MasterTable.Req_PO_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_Dt()
            
        
            ' Set the Req_PO_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_DtSpecified Then
                				
                ' If the Req_PO_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Dt, "d")
                              
                Me.Req_PO_Dt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Dt.Text = Request_MasterTable.Req_PO_Dt.Format(Request_MasterTable.Req_PO_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_No()
            
        
            ' Set the Req_PO_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_NoSpecified Then
                				
                ' If the Req_PO_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_No)
                              
                Me.Req_PO_No.Text = formattedValue
                
            Else 
            
                ' Req_PO_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_No.Text = Request_MasterTable.Req_PO_No.Format(Request_MasterTable.Req_PO_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Amt()
            
        
            ' Set the Req_Pymt_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_AmtSpecified Then
                				
                ' If the Req_Pymt_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Amt, "C")
                              
                Me.Req_Pymt_Amt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Amt.Text = Request_MasterTable.Req_Pymt_Amt.Format(Request_MasterTable.Req_Pymt_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Amt1()
            
        
            ' Set the Req_Pymt_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Amt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Amt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_AmtSpecified Then
                				
                ' If the Req_Pymt_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Pymt_Amt1.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Amt1.Text = Request_MasterTable.Req_Pymt_Amt.Format(Request_MasterTable.Req_Pymt_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Dt()
            
        
            ' Set the Req_Pymt_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_DtSpecified Then
                				
                ' If the Req_Pymt_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Dt, "d")
                              
                Me.Req_Pymt_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Dt.Text = Request_MasterTable.Req_Pymt_Dt.Format(Request_MasterTable.Req_Pymt_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Quote_Approved()
            
        
            ' Set the Req_Quote_Approved TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Quote_Approved is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Quote_Approved()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_ApprovedSpecified Then
                				
                ' If the Req_Quote_Approved is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Approved, "g")
                              
                Me.Req_Quote_Approved.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Approved is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Quote_Approved.Text = Request_MasterTable.Req_Quote_Approved.Format(Request_MasterTable.Req_Quote_Approved.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Site_Name1()
            
        
            ' Set the Req_Site_Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Site_Name1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Site_Name1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Site_NameSpecified Then
                				
                ' If the Req_Site_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Site_Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Site_Name1.Text = formattedValue
                
            Else 
            
                ' Req_Site_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Site_Name1.Text = Request_MasterTable.Req_Site_Name.Format(Request_MasterTable.Req_Site_Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_State1()
            
        
            ' Set the Req_State Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_State1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_State1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_State is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_State)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_State1.Text = formattedValue
                
            Else 
            
                ' Req_State is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_State1.Text = EvaluateFormula("""HI""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Status()
            
        
            ' Set the Req_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StatusSpecified Then
                				
                ' If the Req_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Status)
                              
                Me.Req_Status.Text = formattedValue
                
            Else 
            
                ' Req_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Status.Text = Request_MasterTable.Req_Status.Format(Request_MasterTable.Req_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Target_Dt1()
            
        
            ' Set the Req_Target_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Target_Dt1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Target_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Target_DtSpecified Then
                				
                ' If the Req_Target_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Target_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Target_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_Target_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Target_Dt1.Text = Request_MasterTable.Req_Target_Dt.Format(Request_MasterTable.Req_Target_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Zip1()
            
        
            ' Set the Req_Zip Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Zip1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Zip1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_ZipSpecified Then
                				
                ' If the Req_Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Zip)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Zip1.Text = formattedValue
                
            Else 
            
                ' Req_Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Zip1.Text = Request_MasterTable.Req_Zip.Format(Request_MasterTable.Req_Zip.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRequest_Id()
            
        
            ' Set the Request_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Request_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Request_IdSpecified Then
                				
                ' If the Request_Id is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = ""
                Dim _isExpandableNonCompositeForeignKey As Boolean = Request_MasterTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(Request_MasterTable.Request_Id)
                If _isExpandableNonCompositeForeignKey AndAlso Request_MasterTable.Request_Id.IsApplyDisplayAs Then
                                  
                       formattedValue = Request_MasterTable.GetDFKA(Me.DataSource.Request_Id.ToString(),Request_MasterTable.Request_Id, Nothing)
                                    
                       If (formattedValue Is Nothing) Then
                              formattedValue = Me.DataSource.Format(Request_MasterTable.Request_Id)
                       End If
                Else
                       formattedValue = Me.DataSource.Request_Id.ToString()
                End If
                                
                Me.Request_Id.Text = formattedValue
                
            Else 
            
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Request_Id.Text = Request_MasterTable.Request_Id.Format(Request_MasterTable.Request_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetIROC_Id()
            
        
            ' Set the IROC_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                Me.IROC_Id.Text = formattedValue
                
            Else 
            
                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IROC_Id.Text = Request_MasterTable.IROC_Id.Format(Request_MasterTable.IROC_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetIROC_Id1()
            
        
            ' Set the IROC_Id Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = EvaluateFormula("Year(Today()) + ""-"" + Request_Id", Me.DataSource)
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.IROC_Id1.Text = formattedValue
                
            Else 
            
                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IROC_Id1.Text = Request_MasterTable.IROC_Id.Format(Request_MasterTable.IROC_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Quote()
            
        
            ' Set the OTW_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                Me.OTW_Quote.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCat_Cost_FreeLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_Cost_FreeLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCat_Cost_FreeLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_Cost_FreeLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_Franchise_Order_NumberLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_Franchise_Order_NumberLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCat_OTWC_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_OTWC_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_CATV_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ICS_CATV_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_SOW_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ICS_SOW_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_SOW_NeededLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ICS_SOW_NeededLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_SOW_UploadedLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ICS_SOW_UploadedLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetIROC_IdLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.IROC_IdLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetLabel_Quote_Instr()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Label_Quote_Instr.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Completed_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Completed_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Completed_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Completed_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Construction_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Construction_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Construction_StatusLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Construction_StatusLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Deployment_Start_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Deployment_Start_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_AmtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_AmtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_AmtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_AmtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_NoLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_NoLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_NoLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Invoice_NoLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_More_Info_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_More_Info_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_On_Net_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_On_Net_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_On_Net_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_On_Net_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Permit_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Permit_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Permit_StatusLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Permit_StatusLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Projected_Deploy_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Projected_Deploy_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_QuoteLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_QuoteLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Scheduled_Deploy_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_Scheduled_Deploy_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_NeededLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Agency_ReturnLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Agency_ReturnLabel.Text = "Some value"
                    
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
                
        Public Overridable Sub SetPending_Prev_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Prev_Action_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Prev_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Prev_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPriorityLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.PriorityLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPriorityLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.PriorityLabel1.Text = "Some value"
                    
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
                
        Public Overridable Sub SetReq_AddressLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_AddressLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_CityLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_CityLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Completed_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Completed_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Contact_EmailLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Contact_EmailLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_EnityLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_EnityLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Funding_SrcLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Funding_SrcLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_IslandLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_IslandLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_AmtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_AmtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_AmtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_AmtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_NoLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_NoLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_NoLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_PO_NoLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_AmtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Pymt_AmtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_AmtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Pymt_AmtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Pymt_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Pymt_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Quote_ApprovedLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Quote_ApprovedLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Quote_ApprovedLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Quote_ApprovedLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Site_NameLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Site_NameLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_StateLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StateLabel1.Text = "Some value"
                    
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
                
        Public Overridable Sub SetReq_Target_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Target_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_ZipLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_ZipLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetRequest_IdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetRole_IDMaxControl()
                  
                      Me.Role_IDMaxControl.Text = EvaluateFormula("LOOKUP(Role_IDMaxQuery, """")")
                    
                  End Sub
                
        Public Overridable Sub ResetControl()
          
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
                
                ' add datasource as variables for formula evaluation
                  
                If Role_IDMaxQuery IsNot Nothing AndAlso Role_IDMaxQuery.Initialized Then e.Variables.Add("Role_IDMaxQuery", Role_IDMaxQuery)                                                       
                        
                If Role_IDMaxQuery1 IsNot Nothing AndAlso Role_IDMaxQuery1.Initialized Then e.Variables.Add("Role_IDMaxQuery1", Role_IDMaxQuery1)                                                       
                        
                If Role_IDMaxQuery10 IsNot Nothing AndAlso Role_IDMaxQuery10.Initialized Then e.Variables.Add("Role_IDMaxQuery10", Role_IDMaxQuery10)                                                       
                        
                If Role_IDMaxQuery11 IsNot Nothing AndAlso Role_IDMaxQuery11.Initialized Then e.Variables.Add("Role_IDMaxQuery11", Role_IDMaxQuery11)                                                       
                        
                If Role_IDMaxQuery12 IsNot Nothing AndAlso Role_IDMaxQuery12.Initialized Then e.Variables.Add("Role_IDMaxQuery12", Role_IDMaxQuery12)                                                       
                        
                If Role_IDMaxQuery13 IsNot Nothing AndAlso Role_IDMaxQuery13.Initialized Then e.Variables.Add("Role_IDMaxQuery13", Role_IDMaxQuery13)                                                       
                        
                If Role_IDMaxQuery14 IsNot Nothing AndAlso Role_IDMaxQuery14.Initialized Then e.Variables.Add("Role_IDMaxQuery14", Role_IDMaxQuery14)                                                       
                        
                If Role_IDMaxQuery15 IsNot Nothing AndAlso Role_IDMaxQuery15.Initialized Then e.Variables.Add("Role_IDMaxQuery15", Role_IDMaxQuery15)                                                       
                        
                If Role_IDMaxQuery16 IsNot Nothing AndAlso Role_IDMaxQuery16.Initialized Then e.Variables.Add("Role_IDMaxQuery16", Role_IDMaxQuery16)                                                       
                        
                If Role_IDMaxQuery17 IsNot Nothing AndAlso Role_IDMaxQuery17.Initialized Then e.Variables.Add("Role_IDMaxQuery17", Role_IDMaxQuery17)                                                       
                        
                If Role_IDMaxQuery18 IsNot Nothing AndAlso Role_IDMaxQuery18.Initialized Then e.Variables.Add("Role_IDMaxQuery18", Role_IDMaxQuery18)                                                       
                        
                If Role_IDMaxQuery19 IsNot Nothing AndAlso Role_IDMaxQuery19.Initialized Then e.Variables.Add("Role_IDMaxQuery19", Role_IDMaxQuery19)                                                       
                        
                If Role_IDMaxQuery2 IsNot Nothing AndAlso Role_IDMaxQuery2.Initialized Then e.Variables.Add("Role_IDMaxQuery2", Role_IDMaxQuery2)                                                       
                        
                If Role_IDMaxQuery20 IsNot Nothing AndAlso Role_IDMaxQuery20.Initialized Then e.Variables.Add("Role_IDMaxQuery20", Role_IDMaxQuery20)                                                       
                        
                If Role_IDMaxQuery21 IsNot Nothing AndAlso Role_IDMaxQuery21.Initialized Then e.Variables.Add("Role_IDMaxQuery21", Role_IDMaxQuery21)                                                       
                        
                If Role_IDMaxQuery22 IsNot Nothing AndAlso Role_IDMaxQuery22.Initialized Then e.Variables.Add("Role_IDMaxQuery22", Role_IDMaxQuery22)                                                       
                        
                If Role_IDMaxQuery23 IsNot Nothing AndAlso Role_IDMaxQuery23.Initialized Then e.Variables.Add("Role_IDMaxQuery23", Role_IDMaxQuery23)                                                       
                        
                If Role_IDMaxQuery24 IsNot Nothing AndAlso Role_IDMaxQuery24.Initialized Then e.Variables.Add("Role_IDMaxQuery24", Role_IDMaxQuery24)                                                       
                        
                If Role_IDMaxQuery25 IsNot Nothing AndAlso Role_IDMaxQuery25.Initialized Then e.Variables.Add("Role_IDMaxQuery25", Role_IDMaxQuery25)                                                       
                        
                If Role_IDMaxQuery26 IsNot Nothing AndAlso Role_IDMaxQuery26.Initialized Then e.Variables.Add("Role_IDMaxQuery26", Role_IDMaxQuery26)                                                       
                        
                If Role_IDMaxQuery27 IsNot Nothing AndAlso Role_IDMaxQuery27.Initialized Then e.Variables.Add("Role_IDMaxQuery27", Role_IDMaxQuery27)                                                       
                        
                If Role_IDMaxQuery28 IsNot Nothing AndAlso Role_IDMaxQuery28.Initialized Then e.Variables.Add("Role_IDMaxQuery28", Role_IDMaxQuery28)                                                       
                        
                If Role_IDMaxQuery29 IsNot Nothing AndAlso Role_IDMaxQuery29.Initialized Then e.Variables.Add("Role_IDMaxQuery29", Role_IDMaxQuery29)                                                       
                        
                If Role_IDMaxQuery3 IsNot Nothing AndAlso Role_IDMaxQuery3.Initialized Then e.Variables.Add("Role_IDMaxQuery3", Role_IDMaxQuery3)                                                       
                        
                If Role_IDMaxQuery30 IsNot Nothing AndAlso Role_IDMaxQuery30.Initialized Then e.Variables.Add("Role_IDMaxQuery30", Role_IDMaxQuery30)                                                       
                        
                If Role_IDMaxQuery31 IsNot Nothing AndAlso Role_IDMaxQuery31.Initialized Then e.Variables.Add("Role_IDMaxQuery31", Role_IDMaxQuery31)                                                       
                        
                If Role_IDMaxQuery4 IsNot Nothing AndAlso Role_IDMaxQuery4.Initialized Then e.Variables.Add("Role_IDMaxQuery4", Role_IDMaxQuery4)                                                       
                        
                If Role_IDMaxQuery5 IsNot Nothing AndAlso Role_IDMaxQuery5.Initialized Then e.Variables.Add("Role_IDMaxQuery5", Role_IDMaxQuery5)                                                       
                        
                If Role_IDMaxQuery6 IsNot Nothing AndAlso Role_IDMaxQuery6.Initialized Then e.Variables.Add("Role_IDMaxQuery6", Role_IDMaxQuery6)                                                       
                        
                If Role_IDMaxQuery7 IsNot Nothing AndAlso Role_IDMaxQuery7.Initialized Then e.Variables.Add("Role_IDMaxQuery7", Role_IDMaxQuery7)                                                       
                        
                If Role_IDMaxQuery8 IsNot Nothing AndAlso Role_IDMaxQuery8.Initialized Then e.Variables.Add("Role_IDMaxQuery8", Role_IDMaxQuery8)                                                       
                        
                If Role_IDMaxQuery9 IsNot Nothing AndAlso Role_IDMaxQuery9.Initialized Then e.Variables.Add("Role_IDMaxQuery9", Role_IDMaxQuery9)                                                       
                        
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

      
        
        ' To customize, override this method in Request_MasterRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "Request_MasterRecordControlPanel"), System.Web.UI.WebControls.Panel)

          If ((Not IsNothing(Panel)) AndAlso (Not Panel.Visible)) OrElse IsNothing(Me.DataSource) Then
              Return
          End If
          
              
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
              
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "CommentsTableControl"), CommentsTableControl)
        recCommentsTableControl.SaveData()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "ContactsTableControl"), ContactsTableControl)
        recContactsTableControl.SaveData()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "UploadsTableControl"), UploadsTableControl)
        recUploadsTableControl.SaveData()
        
        End Sub

        ' To customize, override this method in Request_MasterRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetCat_Cost_Free()
            GetCat_Cost_Free1()
            GetCat_Franchise_Order_Number2()
            GetCat_OTWC_Comments()
            GetICS_CATV_Comments()
            GetICS_SOW_Needed()
            GetICS_SOW_Uploaded()
            GetLCat_Franchise_Order_Number21()
            GetLICS_SOW_Needed1()
            GetLICS_SOW_Uploaded1()
            GetLOTW_Completed_Dt1()
            GetLOTW_Construction_Status1()
            GetLOTW_Deployment_Start_Dt1()
            GetLOTW_Invoice_Amt1()
            GetLOTW_Invoice_No1()
            GetLOTW_On_Net_Dt1()
            GetLOTW_Permit_Status1()
            GetLOTW_Projected_Deploy_Dt1()
            GetLOTW_Quote1()
            GetLOTW_Scheduled_Deploy_Dt1()
            GetLPending_Action_Dt()
            GetLPending_Agency()
            GetLPriority1()
            GetLProv_Name1()
            GetLReg_Type()
            GetLReq_Enity21()
            GetLReq_PO_Dt1()
            GetLReq_PO_No2()
            GetLReq_Pymt_Dt1()
            GetLReq_Quote_Approved1()
            GetLReq_Status1()
            GetOTW_Completed_Dt()
            GetOTW_Construction_Status()
            GetOTW_Deployment_Start_Dt()
            GetOTW_Invoice_Amt()
            GetOTW_Invoice_Dt()
            GetOTW_Invoice_Dt1()
            GetOTW_Invoice_No()
            GetOTW_More_Info_Comments()
            GetOTW_On_Net_Dt()
            GetOTW_Permit_Status()
            GetOTW_Projected_Deploy_Dt()
            GetOTW_Scheduled_Deploy_Dt()
            GetPending_Action_Dt1()
            GetPending_Action_Needed()
            GetPending_Action_Needed1()
            GetPending_Agency_Return()
            GetPending_Agency1()
            GetPending_Prev_Action_Needed()
            GetPending_Prev_Status()
            GetPriority()
            GetProv_Name()
            GetReg_Type1()
            GetReq_Address1()
            GetReq_City1()
            GetReq_Comments()
            GetReq_Completed_Dt()
            GetReq_Contact_Email()
            GetReq_Dt1()
            GetReq_Enity2()
            GetReq_Funding_Src2()
            GetReq_Island1()
            GetReq_PO_Amt()
            GetReq_PO_Amt1()
            GetReq_PO_Dt()
            GetReq_PO_No()
            GetReq_Pymt_Amt()
            GetReq_Pymt_Amt1()
            GetReq_Pymt_Dt()
            GetReq_Quote_Approved()
            GetReq_Site_Name1()
            GetReq_State1()
            GetReq_Status()
            GetReq_Target_Dt1()
            GetReq_Zip1()
            GetRequest_Id()
            GetIROC_Id()
            GetIROC_Id1()
            GetOTW_Quote()
        End Sub
        
        
        Public Overridable Sub GetCat_Cost_Free()
        
        
            ' Retrieve the value entered by the user on the Cat_Cost_Free ASP:CheckBox, and
            ' save it into the Cat_Cost_Free field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.Cat_Cost_Free = Me.Cat_Cost_Free.Checked
                    
        End Sub
                
        Public Overridable Sub GetCat_Cost_Free1()
        
        End Sub
                
        Public Overridable Sub GetCat_Franchise_Order_Number2()
         
            ' Retrieve the value entered by the user on the Cat_Franchise_Order_Number2 ASP:DropDownList, and
            ' save it into the Cat_Franchise_Order_Number2 field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Cat_Franchise_Order_Number2), Request_MasterTable.Cat_Franchise_Order_Number2)				
            
        End Sub
                
        Public Overridable Sub GetCat_OTWC_Comments()
            
            ' Retrieve the value entered by the user on the Cat_OTWC_Comments ASP:TextBox, and
            ' save it into the Cat_OTWC_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_OTWC_Comments.Text, Request_MasterTable.Cat_OTWC_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetICS_CATV_Comments()
            
            ' Retrieve the value entered by the user on the ICS_CATV_Comments ASP:TextBox, and
            ' save it into the ICS_CATV_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.ICS_CATV_Comments.Text, Request_MasterTable.ICS_CATV_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetICS_SOW_Needed()
        
        
            ' Retrieve the value entered by the user on the ICS_SOW_Needed ASP:CheckBox, and
            ' save it into the ICS_SOW_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.ICS_SOW_Needed = Me.ICS_SOW_Needed.Checked
                    
        End Sub
                
        Public Overridable Sub GetICS_SOW_Uploaded()
        
        
            ' Retrieve the value entered by the user on the ICS_SOW_Uploaded ASP:CheckBox, and
            ' save it into the ICS_SOW_Uploaded field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.ICS_SOW_Uploaded = Me.ICS_SOW_Uploaded.Checked
                    
        End Sub
                
        Public Overridable Sub GetLCat_Franchise_Order_Number21()
            
        End Sub
                
        Public Overridable Sub GetLICS_SOW_Needed1()
        
        End Sub
                
        Public Overridable Sub GetLICS_SOW_Uploaded1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Completed_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Construction_Status1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Deployment_Start_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Invoice_Amt1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Invoice_No1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_On_Net_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Permit_Status1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Projected_Deploy_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Quote1()
            
        End Sub
                
        Public Overridable Sub GetLOTW_Scheduled_Deploy_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLPending_Action_Dt()
            
        End Sub
                
        Public Overridable Sub GetLPending_Agency()
            
        End Sub
                
        Public Overridable Sub GetLPriority1()
            
        End Sub
                
        Public Overridable Sub GetLProv_Name1()
            
        End Sub
                
        Public Overridable Sub GetLReg_Type()
            
        End Sub
                
        Public Overridable Sub GetLReq_Enity21()
            
        End Sub
                
        Public Overridable Sub GetLReq_PO_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLReq_PO_No2()
            
        End Sub
                
        Public Overridable Sub GetLReq_Pymt_Dt1()
            
        End Sub
                
        Public Overridable Sub GetLReq_Quote_Approved1()
            
        End Sub
                
        Public Overridable Sub GetLReq_Status1()
            
        End Sub
                
        Public Overridable Sub GetOTW_Completed_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Completed_Dt ASP:TextBox, and
            ' save it into the OTW_Completed_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Completed_Dt.Text, Request_MasterTable.OTW_Completed_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Construction_Status()
         
            ' Retrieve the value entered by the user on the OTW_Construction_Status ASP:DropDownList, and
            ' save it into the OTW_Construction_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.OTW_Construction_Status), Request_MasterTable.OTW_Construction_Status)				
            
        End Sub
                
        Public Overridable Sub GetOTW_Deployment_Start_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Deployment_Start_Dt ASP:TextBox, and
            ' save it into the OTW_Deployment_Start_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Deployment_Start_Dt.Text, Request_MasterTable.OTW_Deployment_Start_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Amt()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_Amt ASP:TextBox, and
            ' save it into the OTW_Invoice_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_Amt.Text, Request_MasterTable.OTW_Invoice_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_Dt ASP:TextBox, and
            ' save it into the OTW_Invoice_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_Dt.Text, Request_MasterTable.OTW_Invoice_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Dt1()
            
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_No()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_No ASP:TextBox, and
            ' save it into the OTW_Invoice_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_No.Text, Request_MasterTable.OTW_Invoice_No)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Comments()
            
            ' Retrieve the value entered by the user on the OTW_More_Info_Comments ASP:TextBox, and
            ' save it into the OTW_More_Info_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_More_Info_Comments.Text, Request_MasterTable.OTW_More_Info_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_On_Net_Dt()
            
            ' Retrieve the value entered by the user on the OTW_On_Net_Dt ASP:TextBox, and
            ' save it into the OTW_On_Net_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_On_Net_Dt.Text, Request_MasterTable.OTW_On_Net_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Permit_Status()
         
            ' Retrieve the value entered by the user on the OTW_Permit_Status ASP:DropDownList, and
            ' save it into the OTW_Permit_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.OTW_Permit_Status), Request_MasterTable.OTW_Permit_Status)				
            
        End Sub
                
        Public Overridable Sub GetOTW_Projected_Deploy_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Projected_Deploy_Dt ASP:TextBox, and
            ' save it into the OTW_Projected_Deploy_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Projected_Deploy_Dt.Text, Request_MasterTable.OTW_Projected_Deploy_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Scheduled_Deploy_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Scheduled_Deploy_Dt ASP:TextBox, and
            ' save it into the OTW_Scheduled_Deploy_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Scheduled_Deploy_Dt.Text, Request_MasterTable.OTW_Scheduled_Deploy_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Action_Dt1()
            
            ' Retrieve the value entered by the user on the Pending Action_Dt ASP:TextBox, and
            ' save it into the Pending Action_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Dt1.Text, Request_MasterTable.Pending_Action_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed()
            
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed1()
            
            ' Retrieve the value entered by the user on the Pending_Action_Needed ASP:TextBox, and
            ' save it into the Pending_Action_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Needed1.Text, Request_MasterTable.Pending_Action_Needed)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Agency_Return()
            
            ' Retrieve the value entered by the user on the Pending_Agency_Return ASP:TextBox, and
            ' save it into the Pending_Agency_Return field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency_Return.Text, Request_MasterTable.Pending_Agency_Return)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Agency1()
            
            ' Retrieve the value entered by the user on the Pending_Agency ASP:TextBox, and
            ' save it into the Pending_Agency field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency1.Text, Request_MasterTable.Pending_Agency)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Prev_Action_Needed()
            
            ' Retrieve the value entered by the user on the Pending_Prev_Action_Needed ASP:TextBox, and
            ' save it into the Pending_Prev_Action_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Prev_Action_Needed.Text, Request_MasterTable.Pending_Prev_Action_Needed)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Prev_Status()
            
            ' Retrieve the value entered by the user on the Pending_Prev_Status ASP:TextBox, and
            ' save it into the Pending_Prev_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Prev_Status.Text, Request_MasterTable.Pending_Prev_Status)			

                      
        End Sub
                
        Public Overridable Sub GetPriority()
         
            ' Retrieve the value entered by the user on the Priority ASP:DropDownList, and
            ' save it into the Priority field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Priority), Request_MasterTable.Priority)				
            
        End Sub
                
        Public Overridable Sub GetProv_Name()
            
            ' Retrieve the value entered by the user on the Prov_Name ASP:TextBox, and
            ' save it into the Prov_Name field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Prov_Name.Text, Request_MasterTable.Prov_Name)			

                      
        End Sub
                
        Public Overridable Sub GetReg_Type1()
            
            ' Retrieve the value entered by the user on the Reg_Type ASP:TextBox, and
            ' save it into the Reg_Type field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Reg_Type1.Text, Request_MasterTable.Reg_Type)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Address1()
            
        End Sub
                
        Public Overridable Sub GetReq_City1()
            
        End Sub
                
        Public Overridable Sub GetReq_Comments()
            
            ' Retrieve the value entered by the user on the Req_Comments ASP:TextBox, and
            ' save it into the Req_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Comments.Text, Request_MasterTable.Req_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Completed_Dt()
            
            ' Retrieve the value entered by the user on the Req_Completed_Dt ASP:TextBox, and
            ' save it into the Req_Completed_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Completed_Dt.Text, Request_MasterTable.Req_Completed_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Contact_Email()
            
        End Sub
                
        Public Overridable Sub GetReq_Dt1()
            
        End Sub
                
        Public Overridable Sub GetReq_Enity2()
            
            ' Retrieve the value entered by the user on the Req_Enity2 ASP:TextBox, and
            ' save it into the Req_Enity2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Enity2.Text, Request_MasterTable.Req_Enity2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src2()
            
        End Sub
                
        Public Overridable Sub GetReq_Island1()
            
        End Sub
                
        Public Overridable Sub GetReq_PO_Amt()
            
            ' Retrieve the value entered by the user on the Req_PO_Amt ASP:TextBox, and
            ' save it into the Req_PO_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_Amt.Text, Request_MasterTable.Req_PO_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_PO_Amt1()
            
        End Sub
                
        Public Overridable Sub GetReq_PO_Dt()
            
            ' Retrieve the value entered by the user on the Req_PO_Dt ASP:TextBox, and
            ' save it into the Req_PO_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_Dt.Text, Request_MasterTable.Req_PO_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_PO_No()
            
            ' Retrieve the value entered by the user on the Req_PO_No ASP:TextBox, and
            ' save it into the Req_PO_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_No.Text, Request_MasterTable.Req_PO_No)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Amt()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Amt ASP:TextBox, and
            ' save it into the Req_Pymt_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Amt.Text, Request_MasterTable.Req_Pymt_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Amt1()
            
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Dt()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Dt ASP:TextBox, and
            ' save it into the Req_Pymt_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Dt.Text, Request_MasterTable.Req_Pymt_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Quote_Approved()
            
            ' Retrieve the value entered by the user on the Req_Quote_Approved ASP:TextBox, and
            ' save it into the Req_Quote_Approved field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Quote_Approved.Text, Request_MasterTable.Req_Quote_Approved)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Site_Name1()
            
        End Sub
                
        Public Overridable Sub GetReq_State1()
            
        End Sub
                
        Public Overridable Sub GetReq_Status()
            
            ' Retrieve the value entered by the user on the Req_Status ASP:TextBox, and
            ' save it into the Req_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Status.Text, Request_MasterTable.Req_Status)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Target_Dt1()
            
        End Sub
                
        Public Overridable Sub GetReq_Zip1()
            
        End Sub
                
        Public Overridable Sub GetRequest_Id()
            
        End Sub
                
        Public Overridable Sub GetIROC_Id()
            
            ' Retrieve the value entered by the user on the IROC_Id ASP:TextBox, and
            ' save it into the IROC_Id field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(EvaluateFormula("Request_MasterRecordControl.IROC_Id.Text"), Request_MasterTable.IROC_Id)			

                      
        End Sub
                
        Public Overridable Sub GetIROC_Id1()
            
        End Sub
                
        Public Overridable Sub GetOTW_Quote()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote.Text, Request_MasterTable.OTW_Quote)			

                      
        End Sub
                
      
        ' To customize, override this method in Request_MasterRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            Request_MasterTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
            ' Retrieve the record id from the URL parameter.
              
                  Dim recId As String = DirectCast(Me.Page, BaseApplicationPage).Decrypt(Me.Page.Request.QueryString.Item("Request_Master"))
                
            If recId Is Nothing OrElse recId.Trim = "" Then
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:UrlParamMissing", "IROC2").Replace("{URL}", "Request_Master"))
            End If
            HttpContext.Current.Session("QueryString in Edit-Request-Master") = recId
              
            If KeyValue.IsXmlKey(recId) Then
                ' Keys are typically passed as XML structures to handle composite keys.
                ' If XML, then add a Where clause based on the Primary Key in the XML.
                Dim pkValue As KeyValue = KeyValue.XmlToKey(recId)
                
                wc.iAND(Request_MasterTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, pkValue.GetColumnValueString(Request_MasterTable.Request_Id))
        
            Else
                ' The URL parameter contains the actual value, not an XML structure.
                
                wc.iAND(Request_MasterTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, recId)
        
            End If
              
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            Request_MasterTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            
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
         
        'Formats the resultItem and adds it to the list of suggestions.
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
        
        Protected _Role_IDMaxQuery As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery As DataSource          
            Get               
                Return _Role_IDMaxQuery
            End Get
        End Property
       
        Protected _Role_IDMaxQuery1 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery1 As DataSource          
            Get               
                Return _Role_IDMaxQuery1
            End Get
        End Property
       
        Protected _Role_IDMaxQuery10 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery10 As DataSource          
            Get               
                Return _Role_IDMaxQuery10
            End Get
        End Property
       
        Protected _Role_IDMaxQuery11 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery11 As DataSource          
            Get               
                Return _Role_IDMaxQuery11
            End Get
        End Property
       
        Protected _Role_IDMaxQuery12 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery12 As DataSource          
            Get               
                Return _Role_IDMaxQuery12
            End Get
        End Property
       
        Protected _Role_IDMaxQuery13 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery13 As DataSource          
            Get               
                Return _Role_IDMaxQuery13
            End Get
        End Property
       
        Protected _Role_IDMaxQuery14 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery14 As DataSource          
            Get               
                Return _Role_IDMaxQuery14
            End Get
        End Property
       
        Protected _Role_IDMaxQuery15 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery15 As DataSource          
            Get               
                Return _Role_IDMaxQuery15
            End Get
        End Property
       
        Protected _Role_IDMaxQuery16 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery16 As DataSource          
            Get               
                Return _Role_IDMaxQuery16
            End Get
        End Property
       
        Protected _Role_IDMaxQuery17 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery17 As DataSource          
            Get               
                Return _Role_IDMaxQuery17
            End Get
        End Property
       
        Protected _Role_IDMaxQuery18 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery18 As DataSource          
            Get               
                Return _Role_IDMaxQuery18
            End Get
        End Property
       
        Protected _Role_IDMaxQuery19 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery19 As DataSource          
            Get               
                Return _Role_IDMaxQuery19
            End Get
        End Property
       
        Protected _Role_IDMaxQuery2 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery2 As DataSource          
            Get               
                Return _Role_IDMaxQuery2
            End Get
        End Property
       
        Protected _Role_IDMaxQuery20 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery20 As DataSource          
            Get               
                Return _Role_IDMaxQuery20
            End Get
        End Property
       
        Protected _Role_IDMaxQuery21 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery21 As DataSource          
            Get               
                Return _Role_IDMaxQuery21
            End Get
        End Property
       
        Protected _Role_IDMaxQuery22 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery22 As DataSource          
            Get               
                Return _Role_IDMaxQuery22
            End Get
        End Property
       
        Protected _Role_IDMaxQuery23 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery23 As DataSource          
            Get               
                Return _Role_IDMaxQuery23
            End Get
        End Property
       
        Protected _Role_IDMaxQuery24 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery24 As DataSource          
            Get               
                Return _Role_IDMaxQuery24
            End Get
        End Property
       
        Protected _Role_IDMaxQuery25 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery25 As DataSource          
            Get               
                Return _Role_IDMaxQuery25
            End Get
        End Property
       
        Protected _Role_IDMaxQuery26 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery26 As DataSource          
            Get               
                Return _Role_IDMaxQuery26
            End Get
        End Property
       
        Protected _Role_IDMaxQuery27 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery27 As DataSource          
            Get               
                Return _Role_IDMaxQuery27
            End Get
        End Property
       
        Protected _Role_IDMaxQuery28 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery28 As DataSource          
            Get               
                Return _Role_IDMaxQuery28
            End Get
        End Property
       
        Protected _Role_IDMaxQuery29 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery29 As DataSource          
            Get               
                Return _Role_IDMaxQuery29
            End Get
        End Property
       
        Protected _Role_IDMaxQuery3 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery3 As DataSource          
            Get               
                Return _Role_IDMaxQuery3
            End Get
        End Property
       
        Protected _Role_IDMaxQuery30 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery30 As DataSource          
            Get               
                Return _Role_IDMaxQuery30
            End Get
        End Property
       
        Protected _Role_IDMaxQuery31 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery31 As DataSource          
            Get               
                Return _Role_IDMaxQuery31
            End Get
        End Property
       
        Protected _Role_IDMaxQuery4 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery4 As DataSource          
            Get               
                Return _Role_IDMaxQuery4
            End Get
        End Property
       
        Protected _Role_IDMaxQuery5 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery5 As DataSource          
            Get               
                Return _Role_IDMaxQuery5
            End Get
        End Property
       
        Protected _Role_IDMaxQuery6 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery6 As DataSource          
            Get               
                Return _Role_IDMaxQuery6
            End Get
        End Property
       
        Protected _Role_IDMaxQuery7 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery7 As DataSource          
            Get               
                Return _Role_IDMaxQuery7
            End Get
        End Property
       
        Protected _Role_IDMaxQuery8 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery8 As DataSource          
            Get               
                Return _Role_IDMaxQuery8
            End Get
        End Property
       
        Protected _Role_IDMaxQuery9 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery9 As DataSource          
            Get               
                Return _Role_IDMaxQuery9
            End Get
        End Property
       
        Public Overridable Sub LoadData_Role_IDMaxQuery()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery.DataChanged = True
          
              Me._Role_IDMaxQuery.Initialize("Role_IDMaxQuery", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery()
              Me._Role_IDMaxQuery.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery.LoadData(False, Me._Role_IDMaxQuery.PageSize, Me._Role_IDMaxQuery.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery1()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery1.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery1.DataChanged = True
          
              Me._Role_IDMaxQuery1.Initialize("Role_IDMaxQuery1", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery1()
              Me._Role_IDMaxQuery1.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery1.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery1.LoadData(False, Me._Role_IDMaxQuery1.PageSize, Me._Role_IDMaxQuery1.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery10()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery10.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery10.DataChanged = True
          
              Me._Role_IDMaxQuery10.Initialize("Role_IDMaxQuery10", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery10()
              Me._Role_IDMaxQuery10.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery10.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery10.LoadData(False, Me._Role_IDMaxQuery10.PageSize, Me._Role_IDMaxQuery10.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery11()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery11.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery11.DataChanged = True
          
              Me._Role_IDMaxQuery11.Initialize("Role_IDMaxQuery11", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery11()
              Me._Role_IDMaxQuery11.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery11.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery11.LoadData(False, Me._Role_IDMaxQuery11.PageSize, Me._Role_IDMaxQuery11.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery12()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery12.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery12.DataChanged = True
          
              Me._Role_IDMaxQuery12.Initialize("Role_IDMaxQuery12", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery12()
              Me._Role_IDMaxQuery12.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery12.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery12.LoadData(False, Me._Role_IDMaxQuery12.PageSize, Me._Role_IDMaxQuery12.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery13()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery13.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery13.DataChanged = True
          
              Me._Role_IDMaxQuery13.Initialize("Role_IDMaxQuery13", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery13()
              Me._Role_IDMaxQuery13.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery13.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery13.LoadData(False, Me._Role_IDMaxQuery13.PageSize, Me._Role_IDMaxQuery13.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery14()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery14.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery14.DataChanged = True
          
              Me._Role_IDMaxQuery14.Initialize("Role_IDMaxQuery14", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery14()
              Me._Role_IDMaxQuery14.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery14.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery14.LoadData(False, Me._Role_IDMaxQuery14.PageSize, Me._Role_IDMaxQuery14.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery15()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery15.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery15.DataChanged = True
          
              Me._Role_IDMaxQuery15.Initialize("Role_IDMaxQuery15", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery15()
              Me._Role_IDMaxQuery15.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery15.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery15.LoadData(False, Me._Role_IDMaxQuery15.PageSize, Me._Role_IDMaxQuery15.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery16()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery16.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery16.DataChanged = True
          
              Me._Role_IDMaxQuery16.Initialize("Role_IDMaxQuery16", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery16()
              Me._Role_IDMaxQuery16.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery16.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery16.LoadData(False, Me._Role_IDMaxQuery16.PageSize, Me._Role_IDMaxQuery16.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery17()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery17.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery17.DataChanged = True
          
              Me._Role_IDMaxQuery17.Initialize("Role_IDMaxQuery17", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery17()
              Me._Role_IDMaxQuery17.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery17.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery17.LoadData(False, Me._Role_IDMaxQuery17.PageSize, Me._Role_IDMaxQuery17.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery18()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery18.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery18.DataChanged = True
          
              Me._Role_IDMaxQuery18.Initialize("Role_IDMaxQuery18", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery18()
              Me._Role_IDMaxQuery18.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery18.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery18.LoadData(False, Me._Role_IDMaxQuery18.PageSize, Me._Role_IDMaxQuery18.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery19()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery19.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery19.DataChanged = True
          
              Me._Role_IDMaxQuery19.Initialize("Role_IDMaxQuery19", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery19()
              Me._Role_IDMaxQuery19.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery19.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery19.LoadData(False, Me._Role_IDMaxQuery19.PageSize, Me._Role_IDMaxQuery19.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery2()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery2.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery2.DataChanged = True
          
              Me._Role_IDMaxQuery2.Initialize("Role_IDMaxQuery2", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery2()
              Me._Role_IDMaxQuery2.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery2.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery2.LoadData(False, Me._Role_IDMaxQuery2.PageSize, Me._Role_IDMaxQuery2.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery20()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery20.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery20.DataChanged = True
          
              Me._Role_IDMaxQuery20.Initialize("Role_IDMaxQuery20", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery20()
              Me._Role_IDMaxQuery20.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery20.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery20.LoadData(False, Me._Role_IDMaxQuery20.PageSize, Me._Role_IDMaxQuery20.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery21()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery21.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery21.DataChanged = True
          
              Me._Role_IDMaxQuery21.Initialize("Role_IDMaxQuery21", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery21()
              Me._Role_IDMaxQuery21.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery21.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery21.LoadData(False, Me._Role_IDMaxQuery21.PageSize, Me._Role_IDMaxQuery21.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery22()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery22.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery22.DataChanged = True
          
              Me._Role_IDMaxQuery22.Initialize("Role_IDMaxQuery22", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery22()
              Me._Role_IDMaxQuery22.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery22.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery22.LoadData(False, Me._Role_IDMaxQuery22.PageSize, Me._Role_IDMaxQuery22.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery23()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery23.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery23.DataChanged = True
          
              Me._Role_IDMaxQuery23.Initialize("Role_IDMaxQuery23", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery23()
              Me._Role_IDMaxQuery23.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery23.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery23.LoadData(False, Me._Role_IDMaxQuery23.PageSize, Me._Role_IDMaxQuery23.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery24()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery24.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery24.DataChanged = True
          
              Me._Role_IDMaxQuery24.Initialize("Role_IDMaxQuery24", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery24()
              Me._Role_IDMaxQuery24.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery24.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery24.LoadData(False, Me._Role_IDMaxQuery24.PageSize, Me._Role_IDMaxQuery24.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery25()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery25.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery25.DataChanged = True
          
              Me._Role_IDMaxQuery25.Initialize("Role_IDMaxQuery25", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery25()
              Me._Role_IDMaxQuery25.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery25.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery25.LoadData(False, Me._Role_IDMaxQuery25.PageSize, Me._Role_IDMaxQuery25.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery26()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery26.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery26.DataChanged = True
          
              Me._Role_IDMaxQuery26.Initialize("Role_IDMaxQuery26", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery26()
              Me._Role_IDMaxQuery26.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery26.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery26.LoadData(False, Me._Role_IDMaxQuery26.PageSize, Me._Role_IDMaxQuery26.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery27()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery27.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery27.DataChanged = True
          
              Me._Role_IDMaxQuery27.Initialize("Role_IDMaxQuery27", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery27()
              Me._Role_IDMaxQuery27.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery27.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery27.LoadData(False, Me._Role_IDMaxQuery27.PageSize, Me._Role_IDMaxQuery27.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery28()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery28.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery28.DataChanged = True
          
              Me._Role_IDMaxQuery28.Initialize("Role_IDMaxQuery28", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery28()
              Me._Role_IDMaxQuery28.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery28.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery28.LoadData(False, Me._Role_IDMaxQuery28.PageSize, Me._Role_IDMaxQuery28.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery29()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery29.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery29.DataChanged = True
          
              Me._Role_IDMaxQuery29.Initialize("Role_IDMaxQuery29", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery29()
              Me._Role_IDMaxQuery29.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery29.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery29.LoadData(False, Me._Role_IDMaxQuery29.PageSize, Me._Role_IDMaxQuery29.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery3()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery3.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery3.DataChanged = True
          
              Me._Role_IDMaxQuery3.Initialize("Role_IDMaxQuery3", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery3()
              Me._Role_IDMaxQuery3.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery3.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery3.LoadData(False, Me._Role_IDMaxQuery3.PageSize, Me._Role_IDMaxQuery3.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery30()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery30.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery30.DataChanged = True
          
              Me._Role_IDMaxQuery30.Initialize("Role_IDMaxQuery30", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery30()
              Me._Role_IDMaxQuery30.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery30.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery30.LoadData(False, Me._Role_IDMaxQuery30.PageSize, Me._Role_IDMaxQuery30.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery31()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery31.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery31.DataChanged = True
          
              Me._Role_IDMaxQuery31.Initialize("Role_IDMaxQuery31", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery31()
              Me._Role_IDMaxQuery31.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery31.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery31.LoadData(False, Me._Role_IDMaxQuery31.PageSize, Me._Role_IDMaxQuery31.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery4()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery4.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery4.DataChanged = True
          
              Me._Role_IDMaxQuery4.Initialize("Role_IDMaxQuery4", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery4()
              Me._Role_IDMaxQuery4.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery4.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery4.LoadData(False, Me._Role_IDMaxQuery4.PageSize, Me._Role_IDMaxQuery4.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery5()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery5.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery5.DataChanged = True
          
              Me._Role_IDMaxQuery5.Initialize("Role_IDMaxQuery5", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery5()
              Me._Role_IDMaxQuery5.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery5.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery5.LoadData(False, Me._Role_IDMaxQuery5.PageSize, Me._Role_IDMaxQuery5.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery6()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery6.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery6.DataChanged = True
          
              Me._Role_IDMaxQuery6.Initialize("Role_IDMaxQuery6", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery6()
              Me._Role_IDMaxQuery6.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery6.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery6.LoadData(False, Me._Role_IDMaxQuery6.PageSize, Me._Role_IDMaxQuery6.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery7()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery7.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery7.DataChanged = True
          
              Me._Role_IDMaxQuery7.Initialize("Role_IDMaxQuery7", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery7()
              Me._Role_IDMaxQuery7.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery7.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery7.LoadData(False, Me._Role_IDMaxQuery7.PageSize, Me._Role_IDMaxQuery7.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery8()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery8.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery8.DataChanged = True
          
              Me._Role_IDMaxQuery8.Initialize("Role_IDMaxQuery8", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery8()
              Me._Role_IDMaxQuery8.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery8.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery8.LoadData(False, Me._Role_IDMaxQuery8.PageSize, Me._Role_IDMaxQuery8.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery9()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery9.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery9.DataChanged = True
          
              Me._Role_IDMaxQuery9.Initialize("Role_IDMaxQuery9", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery9()
              Me._Role_IDMaxQuery9.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery9.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery9.LoadData(False, Me._Role_IDMaxQuery9.PageSize, Me._Role_IDMaxQuery9.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery1() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery10() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery11() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery12() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery13() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery14() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery15() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery16() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery17() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery18() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery19() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery2() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery20() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery21() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery22() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery23() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery24() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery25() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery26() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery27() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery28() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery29() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery3() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery30() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery31() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery4() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery5() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery6() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery7() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery8() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery9() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
    

        ' To customize, override this method in Request_MasterRecordControl.
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
                                
                
			Me.Page.Authorize(Ctype(Cat_Cost_Free, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Cat_Cost_Free1, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Cat_Cost_FreeLabel, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Cat_Cost_FreeLabel1, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Cat_Franchise_Order_Number2, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Cat_Franchise_Order_NumberLabel, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Cat_Franchise_Order_NumberLabel1, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Cat_OTWC_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(Cat_OTWC_CommentsLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(ICS_CATV_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(ICS_CATV_CommentsLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(ICS_SOW_Needed, Control), "1;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(ICS_SOW_NeededLabel, Control), "1;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(ICS_SOW_NeededLabel1, Control), "2;32;33")
					
			Me.Page.Authorize(Ctype(Label_Quote_Instr, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(LCat_Franchise_Order_Number21, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LICS_SOW_Needed1, Control), "2;32;33")
					
			Me.Page.Authorize(Ctype(LOTW_Completed_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Construction_Status1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Deployment_Start_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Invoice_Amt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Invoice_No1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_On_Net_Dt1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(LOTW_Permit_Status1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Projected_Deploy_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LOTW_Quote1, Control), "2;22;23;25;26;27;28;29;30;31;34")
					
			Me.Page.Authorize(Ctype(LOTW_Scheduled_Deploy_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LPending_Action_Dt, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LPending_Agency, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LPriority1, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LReq_Enity21, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LReq_PO_Dt1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(LReq_PO_No2, Control), "32;33")
					
			Me.Page.Authorize(Ctype(LReq_Pymt_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(LReq_Quote_Approved1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(LReq_Status1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Completed_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Completed_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Completed_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Construction_Status, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Construction_StatusLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Construction_StatusLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Deployment_Start_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Deployment_Start_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Deployment_Start_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_Amt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_AmtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_AmtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_Dt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_No, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_NoLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Invoice_NoLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_More_Info_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(OTW_More_Info_CommentsLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_On_Net_Dt, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_On_Net_DtLabel, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_On_Net_DtLabel1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(OTW_Permit_Status, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Permit_StatusLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Permit_StatusLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_Projected_Deploy_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Projected_Deploy_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Projected_Deploy_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(OTW_QuoteLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_QuoteLabel1, Control), "2;22;23;25;26;27;28;29;30;31;34")
					
			Me.Page.Authorize(Ctype(OTW_Scheduled_Deploy_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Scheduled_Deploy_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(OTW_Scheduled_Deploy_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Pending_Action_Dt1, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_DtLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Pending_Action_Needed, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Pending_Action_Needed1, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_NeededLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_NeededLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Pending_Agency_Return, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency_ReturnLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency1, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_AgencyLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_AgencyLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_Needed, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_NeededLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Status, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_StatusLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Priority, Control), "1;23")
					
			Me.Page.Authorize(Ctype(PriorityLabel, Control), "1;23")
					
			Me.Page.Authorize(Ctype(PriorityLabel1, Control), "2;22;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Prov_NameLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Prov_NameLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Reg_TypeLabel, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Reg_TypeLabel1, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_CommentsLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Completed_Dt, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Req_Completed_DtLabel, Control), "1;23")
					
			Me.Page.Authorize(Ctype(Req_Enity2, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_EnityLabel, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Req_EnityLabel1, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_PO_Amt, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_Amt1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(Req_PO_AmtLabel, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_AmtLabel1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(Req_PO_Dt, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_DtLabel, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_DtLabel1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(Req_PO_No, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_NoLabel, Control), "1;2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_PO_NoLabel1, Control), "32;33")
					
			Me.Page.Authorize(Ctype(Req_Pymt_Amt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(Req_Pymt_Amt1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_Pymt_AmtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(Req_Pymt_AmtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_Pymt_Dt, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(Req_Pymt_DtLabel, Control), "1;32;33")
					
			Me.Page.Authorize(Ctype(Req_Pymt_DtLabel1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_Quote_Approved, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Quote_ApprovedLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Quote_ApprovedLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Req_Status, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_StatusLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_StatusLabel1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Request_Id, Control), "1")
					
			Me.Page.Authorize(Ctype(Request_IdLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Role_IDMaxControl, Control), "1")
					
			Me.Page.Authorize(Ctype(IROC_Id, Control), "1")
					
			Me.Page.Authorize(Ctype(OTW_Quote, Control), "1;32;33")
											
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
        
        
        ' Generate the event handling functions for pagination events.
            
      
        ' Generate the event handling functions for filter and search events.
            
                        
        Public Overridable Function CreateWhereClause_Cat_Franchise_Order_Number2DropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_OTW_Construction_StatusDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_OTW_Permit_StatusDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_PriorityDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
        ' Fill the Cat_Franchise_Order_Number2 list.
        Protected Overridable Sub PopulateCat_Franchise_Order_Number2DropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Cat_Franchise_Order_Number2.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            
            ' Add the Please Select item.
            Me.Cat_Franchise_Order_Number2.Items.Insert(0, new ListItem(Me.Page.GetResourceValue("Txt:PleaseSelect", "IROC2"), "--PLEASE_SELECT--"))
                            		  			
            ' 2. Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Cat_Franchise_Order_Number2DropDownList function.
            ' It is better to customize the where clause there.
            
            Dim wc As WhereClause = CreateWhereClause_Cat_Franchise_Order_Number2DropDownList()
            ' Create the ORDER BY clause to sort based on the displayed value.			
                

            Dim orderBy As OrderBy = New OrderBy(false, false)			
            
                      Dim variables As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)
                      
            ' 3. Read a total of maxItems from the database and insert them		
            Dim itemValues() As Franchise_NumberRecord = Nothing
            Dim evaluator As New FormulaEvaluator                
            If wc.RunQuery
                Dim counter As Integer = 0
                Dim pageNum As Integer = 0
                Dim listDuplicates As New ArrayList()

                Do
                    itemValues = Franchise_NumberTable.GetRecords(wc, orderBy, pageNum, maxItems)
                    For each itemValue As Franchise_NumberRecord In itemValues
                        ' Create the item and add to the list.
                        Dim cvalue As String = Nothing
                        Dim fvalue As String = Nothing
                        If itemValue.Franchise_Order_NumberSpecified Then
                            cvalue = itemValue.Franchise_Order_Number.ToString() 
                            
                            If counter < maxItems AndAlso Me.Cat_Franchise_Order_Number2.Items.FindByValue(cvalue) Is Nothing Then
                            
                                Dim variables2 As New System.Collections.Generic.Dictionary(Of String, Object)
                                


                                variables2.Add(itemValue.TableAccess.TableDefinition.TableCodeName, itemValue)
                                
                                fvalue = EvaluateFormula("Franchise_Order_Number", itemValue, variables2, evaluator)
                              
                                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = cvalue

                                If (IsNothing(fvalue)) Then
                                   fvalue = ""
                                End If

                                fvalue = fvalue.Trim()

                                If ( fvalue.Length > 50 ) Then
                                    fvalue = fvalue.Substring(0, 50) & "..."
                                End If

                                Dim dupItem As ListItem = Me.Cat_Franchise_Order_Number2.Items.FindByText(fvalue)
                          
                                If Not IsNothing(dupItem) Then
                                    listDuplicates.Add(fvalue)
                                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                                    End If
                                End If

                                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                                Me.Cat_Franchise_Order_Number2.Items.Add(newItem)

                                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                                End If

                                counter += 1			  
                            End If
                        End If
                    Next
                    pageNum += 1
                Loop While (itemValues.Length = maxItems AndAlso counter < maxItems)
            End If
                            
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Cat_Franchise_Order_Number2, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Cat_Franchise_Order_Number2, selectedValue)Then

                ' construct a whereclause to query a record with DatabaseIROC%dbo.Franchise_Number.Franchise_Order_Number = selectedValue
                Dim filter2 As CompoundFilter = New CompoundFilter(CompoundFilter.CompoundingOperators.And_Operator, Nothing)
                Dim whereClause2 As WhereClause = New WhereClause()
                filter2.AddFilter(New BaseClasses.Data.ColumnValueFilter(Franchise_NumberTable.Franchise_Order_Number, selectedValue, BaseClasses.Data.BaseFilter.ComparisonOperator.EqualsTo, False))
                whereClause2.AddFilter(filter2, CompoundFilter.CompoundingOperators.And_Operator)

                Try
                    ' Execute the query
                    Dim rc() As Franchise_NumberRecord = Franchise_NumberTable.GetRecords(whereClause2, New OrderBy(False, False), 0, 1)
                      Dim vars As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)
                      ' if find a record, add it to the dropdown and set it as selected item
                      If rc IsNot Nothing AndAlso rc.Length = 1 Then
                      Dim itemValue As Franchise_NumberRecord = DirectCast(rc(0), Franchise_NumberRecord)
                        ' Create the item and add to the list.
                        Dim cvalue As String = Nothing
                        Dim fvalue As String = Nothing
                        If itemValue.Franchise_Order_NumberSpecified Then
                            cvalue = itemValue.Franchise_Order_Number.ToString() 
                          Dim evaluator2 As New FormulaEvaluator
                          Dim variables2 As New System.Collections.Generic.Dictionary(Of String, Object)
                          


                          variables2.Add(itemValue.TableAccess.TableDefinition.TableCodeName, itemValue)
                          
                          fvalue = EvaluateFormula("Franchise_Order_Number", itemValue, variables2, evaluator2)
                        
                              If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = cvalue
                              ResetSelectedItem(Me.Cat_Franchise_Order_Number2, New ListItem(fvalue, cvalue))
                            End If
                        End If
                Catch
                End Try

            End If					
                        
                
        End Sub
        
              
        ' Fill the OTW_Construction_Status list.
        Protected Overridable Sub PopulateOTW_Construction_StatusDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.OTW_Construction_Status.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Pending Permits"), "Pending Permits"))
                            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Pending MR"), "Pending MR"))
                            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("In Construction"), "In Construction"))
                            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("On Hold"), "On Hold"))
                            							
            Me.OTW_Construction_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Completed"), "Completed"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.OTW_Construction_Status, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.OTW_Construction_Status, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.OTW_Construction_Status, Request_MasterTable.OTW_Construction_Status.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.OTW_Construction_Status.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.OTW_Construction_Status, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        ' Fill the OTW_Permit_Status list.
        Protected Overridable Sub PopulateOTW_Permit_StatusDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.OTW_Permit_Status.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Walkout"), "Walkout"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Submitted"), "Submitted"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Rejected"), "Rejected"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Approved"), "Approved"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("MR Req"), "MR Req"))
                            							
            Me.OTW_Permit_Status.Items.Add(New ListItem(Me.Page.ExpandResourceValue("App w/MR"), "App w/MR"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.OTW_Permit_Status, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.OTW_Permit_Status, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.OTW_Permit_Status, Request_MasterTable.OTW_Permit_Status.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.OTW_Permit_Status.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.OTW_Permit_Status, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        ' Fill the Priority list.
        Protected Overridable Sub PopulatePriorityDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Priority.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{PleaseSelect Priority}"), ""))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("High"), "1"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Medium"), "2"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Low"), "3"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Priority, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Priority, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Priority, Request_MasterTable.Priority.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Priority.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Priority, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        Protected Overridable Sub Cat_Franchise_Order_Number2_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Cat_Franchise_Order_Number2.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Cat_Franchise_Order_Number2.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Cat_Franchise_Order_Number2.Items.Add(New ListItem(displayText, val))
                Me.Cat_Franchise_Order_Number2.SelectedIndex = Me.Cat_Franchise_Order_Number2.Items.Count - 1
                Me.Page.Session.Remove(Cat_Franchise_Order_Number2.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Cat_Franchise_Order_Number2.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub OTW_Construction_Status_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(OTW_Construction_Status.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(OTW_Construction_Status.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.OTW_Construction_Status.Items.Add(New ListItem(displayText, val))
                Me.OTW_Construction_Status.SelectedIndex = Me.OTW_Construction_Status.Items.Count - 1
                Me.Page.Session.Remove(OTW_Construction_Status.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(OTW_Construction_Status.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub OTW_Permit_Status_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(OTW_Permit_Status.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(OTW_Permit_Status.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.OTW_Permit_Status.Items.Add(New ListItem(displayText, val))
                Me.OTW_Permit_Status.SelectedIndex = Me.OTW_Permit_Status.Items.Count - 1
                Me.Page.Session.Remove(OTW_Permit_Status.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(OTW_Permit_Status.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Priority_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Priority.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Priority.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Priority.Items.Add(New ListItem(displayText, val))
                Me.Priority.SelectedIndex = Me.Priority.Items.Count - 1
                Me.Page.Session.Remove(Priority.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Priority.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Cat_Cost_Free_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_Cost_Free1_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Needed_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Uploaded_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub LICS_SOW_Needed1_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_OTWC_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub ICS_CATV_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Deployment_Start_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_More_Info_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_On_Net_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Projected_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Scheduled_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Needed1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency_Return_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Action_Needed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Prov_Name_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Reg_Type1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Enity2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Quote_Approved_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Request_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub IROC_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseRequest_MasterRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseRequest_MasterRecordControl_Rec") = value
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
    
        Private _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property
    
        Private _TotalRecords As Integer
        Public Property TotalRecords() As Integer
            Get
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                End If

                Me._TotalRecords = value
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
        
        Public ReadOnly Property Cat_Cost_Free() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_Free"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Cost_Free1() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_Free1"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Cost_FreeLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_FreeLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Cost_FreeLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_FreeLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Franchise_Order_Number2() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_Number2"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Franchise_Order_NumberLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_NumberLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Franchise_Order_NumberLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_NumberLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_OTWC_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_OTWC_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_CATV_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_CATV_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_Needed() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Needed"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_NeededLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_NeededLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_Uploaded() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Uploaded"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_UploadedLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_UploadedLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property IROC_IdLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Label_Quote_Instr() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Label_Quote_Instr"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
        Public ReadOnly Property LCat_Franchise_Order_Number21() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LCat_Franchise_Order_Number21"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LICS_SOW_Needed1() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LICS_SOW_Needed1"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property LICS_SOW_Uploaded1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LICS_SOW_Uploaded1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Completed_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Completed_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Construction_Status1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Construction_Status1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Deployment_Start_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Deployment_Start_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Invoice_Amt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Invoice_Amt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Invoice_No1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Invoice_No1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_On_Net_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_On_Net_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Permit_Status1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Permit_Status1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Projected_Deploy_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Projected_Deploy_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Quote1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Quote1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LOTW_Scheduled_Deploy_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LOTW_Scheduled_Deploy_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LPending_Action_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LPending_Action_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LPending_Agency() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LPending_Agency"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LPriority1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LPriority1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LProv_Name1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LProv_Name1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReg_Type() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReg_Type"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_Enity21() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_Enity21"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_PO_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_PO_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_PO_No2() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_PO_No2"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_Pymt_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_Pymt_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_Quote_Approved1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_Quote_Approved1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_Status1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_Status1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Completed_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Completed_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Completed_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Construction_Status() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_Status"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Construction_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Construction_StatusLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_StatusLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Deployment_Start_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Deployment_Start_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Deployment_Start_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_AmtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_AmtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_NoLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_NoLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_NoLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_More_Info_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_On_Net_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_On_Net_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_On_Net_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Permit_Status() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_Status"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Permit_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Permit_StatusLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_StatusLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Projected_Deploy_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Projected_Deploy_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Projected_Deploy_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_QuoteLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_QuoteLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Scheduled_Deploy_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Scheduled_Deploy_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Scheduled_Deploy_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Dt1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Needed() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_Needed1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_NeededLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency_Return() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_Return"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Agency_ReturnLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_ReturnLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_Action_Needed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_Needed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_Action_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Priority() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Priority"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property PriorityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "PriorityLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property PriorityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "PriorityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Prov_Name() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_Name"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Prov_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Prov_NameLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Reg_Type1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_Type1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Reg_TypeLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Reg_TypeLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Address1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Address1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_AddressLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_AddressLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_City1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_City1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_CityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Completed_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Completed_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Contact_Email() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Contact_EmailLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_EmailLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Enity2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_EnityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_EnityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_Src2() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src2"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_SrcLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_SrcLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Island1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_IslandLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_Amt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Amt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_AmtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_AmtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_NoLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_NoLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_NoLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Amt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Amt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_AmtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_AmtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Quote_Approved() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_Approved"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Quote_ApprovedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_ApprovedLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Quote_ApprovedLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_ApprovedLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Site_Name1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_Name1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Site_NameLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_NameLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_State1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_State1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_StateLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StateLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_StatusLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Target_Dt1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_Dt1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Target_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Zip1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Zip1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_ZipLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_ZipLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Request_IdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Role_IDMaxControl() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Role_IDMaxControl"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property IROC_Id1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote"), System.Web.UI.WebControls.TextBox)
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

  

#End Region
    
  
End Namespace

  