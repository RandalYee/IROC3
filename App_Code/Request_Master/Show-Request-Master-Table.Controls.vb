
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Show_Request_Master_Table.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Show_Request_Master_Table

#Region "Section 1: Place your customizations here."

    
Public Class Request_MasterTableControlRow
        Inherits BaseRequest_MasterTableControlRow
        ' The BaseRequest_MasterTableControlRow implements code for a ROW within the
        ' the Request_MasterTableControl table.  The BaseRequest_MasterTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of Request_MasterTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class Request_MasterTableControl
        Inherits BaseRequest_MasterTableControl

    ' The BaseRequest_MasterTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The Request_MasterTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  

Public Class EnityRecordControl
        Inherits BaseEnityRecordControl
        ' The BaseEnityRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class
Public Class ContactsRecordControl
        Inherits BaseContactsRecordControl
        ' The BaseContactsRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class
Public Class CommentsRecordControl
        Inherits BaseCommentsRecordControl
        ' The BaseCommentsRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class
#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the Request_MasterTableControlRow control on the Show_Request_Master_Table page.
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
        
                SetCat_Cost_Free()
                SetCat_Franchise_Order_Number()
                SetCat_OTWC_Comments()
                
                
                SetCounty_Upload()
                
                SetICS_CATV_Comments()
                SetICS_SOW_Needed()
                SetICS_SOW_Uploaded()
                SetIROC_Id()
                SetOTW_Completed_Dt()
                SetOTW_Construction_Status()
                SetOTW_Deployment_Start_Dt()
                SetOTW_Invoice_Amt()
                SetOTW_Invoice_Dt()
                SetOTW_Invoice_No()
                SetOTW_Island_completed()
                SetOTW_More_Info_Comments()
                SetOTW_More_Info_Flag()
                SetOTW_On_Net()
                SetOTW_Permit_Status()
                SetOTW_Premise_Fiber_Work_Reqd()
                SetOTW_Projected_Deploy_Dt()
                SetOTW_Quote()
                SetOTW_Scheduled_Deploy_Dt()
                SetPending_Action_Dt()
                SetPending_Action_Needed()
                SetPending_Agency()
                SetPending_Agency_Return()
                SetPending_Interval_Days_1st()
                SetPending_Interval_Days_2nd()
                SetPending_Interval_Days_Auto_Cancel()
                SetPending_Interval_Days_Cancel()
                SetPending_Nterval_Days_Max()
                SetPending_Prev_Action_Needed()
                SetPending_Prev_Status()
                SetPriority()
                SetReg_Type()
                SetReq_Address()
                SetReq_City()
                SetReq_Comments()
                SetReq_Completed_Dt()
                SetReq_Contact_Email()
                SetReq_Dt()
                SetReq_Enity()
                SetReq_Funding_Src()
                SetReq_Funding_Src2()
                SetReq_Invoice_Paid()
                SetReq_Island()
                SetReq_PO_Amt()
                SetReq_PO_Dt()
                SetReq_PO_No()
                SetReq_Pymt_Amt()
                SetReq_Pymt_Check_No()
                SetReq_Pymt_Dt()
                SetReq_Quote_Approved()
                SetReq_Quote_Respnse()
                SetReq_Site_Name()
                SetReq_State()
                SetReq_Status()
                SetReq_Target_Dt()
                SetReq_Zip()
                
                
      
      
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
            
        Dim recCommentsRecordControl as CommentsRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "CommentsRecordControl"), CommentsRecordControl)
                    
        recCommentsRecordControl.LoadData()
        recCommentsRecordControl.DataBind()
        
        Dim recContactsRecordControl as ContactsRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "ContactsRecordControl"), ContactsRecordControl)
                    
        recContactsRecordControl.LoadData()
        recContactsRecordControl.DataBind()
        
        Dim recEnityRecordControl as EnityRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "EnityRecordControl"), EnityRecordControl)
                    
        recEnityRecordControl.LoadData()
        recEnityRecordControl.DataBind()
        
        End Sub
        
        
        Public Overridable Sub SetCat_Cost_Free()
            
        
            ' Set the Cat_Cost_Free Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Cost_Free is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Cost_Free()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Cost_FreeSpecified Then
                				
                ' If the Cat_Cost_Free is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Cost_Free)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Cat_Cost_Free.Text = formattedValue
                
            Else 
            
                ' Cat_Cost_Free is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_Cost_Free.Text = Request_MasterTable.Cat_Cost_Free.Format(Request_MasterTable.Cat_Cost_Free.DefaultValue)
                        		
                End If
                 
            ' If the Cat_Cost_Free is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Cat_Cost_Free.Text Is Nothing _
                OrElse Me.Cat_Cost_Free.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Cat_Cost_Free.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_Number()
            
        
            ' Set the Cat_Franchise_Order_Number Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Franchise_Order_Number is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Franchise_Order_Number()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_NumberSpecified Then
                				
                ' If the Cat_Franchise_Order_Number is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Franchise_Order_Number)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Cat_Franchise_Order_Number.Text = formattedValue
                
            Else 
            
                ' Cat_Franchise_Order_Number is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_Franchise_Order_Number.Text = Request_MasterTable.Cat_Franchise_Order_Number.Format(Request_MasterTable.Cat_Franchise_Order_Number.DefaultValue)
                        		
                End If
                 
            ' If the Cat_Franchise_Order_Number is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Cat_Franchise_Order_Number.Text Is Nothing _
                OrElse Me.Cat_Franchise_Order_Number.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Cat_Franchise_Order_Number.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetCat_OTWC_Comments()
            
        
            ' Set the Cat_OTWC_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_OTWC_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_OTWC_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_OTWC_CommentsSpecified Then
                				
                ' If the Cat_OTWC_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_OTWC_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Cat_OTWC_Comments.Text = formattedValue
                
            Else 
            
                ' Cat_OTWC_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_OTWC_Comments.Text = Request_MasterTable.Cat_OTWC_Comments.Format(Request_MasterTable.Cat_OTWC_Comments.DefaultValue)
                        		
                End If
                 
            ' If the Cat_OTWC_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Cat_OTWC_Comments.Text Is Nothing _
                OrElse Me.Cat_OTWC_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Cat_OTWC_Comments.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetCounty_Upload()
            
        
            ' Set the County_Upload Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.County_Upload is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCounty_Upload()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.County_UploadSpecified Then
                				
                ' If the County_Upload is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.County_Upload)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.County_Upload.Text = formattedValue
                
            Else 
            
                ' County_Upload is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.County_Upload.Text = Request_MasterTable.County_Upload.Format(Request_MasterTable.County_Upload.DefaultValue)
                        		
                End If
                 
            ' If the County_Upload is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.County_Upload.Text Is Nothing _
                OrElse Me.County_Upload.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.County_Upload.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetICS_CATV_Comments()
            
        
            ' Set the ICS_CATV_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_CATV_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetICS_CATV_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_CATV_CommentsSpecified Then
                				
                ' If the ICS_CATV_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_CATV_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.ICS_CATV_Comments.Text = formattedValue
                
            Else 
            
                ' ICS_CATV_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.ICS_CATV_Comments.Text = Request_MasterTable.ICS_CATV_Comments.Format(Request_MasterTable.ICS_CATV_Comments.DefaultValue)
                        		
                End If
                 
            ' If the ICS_CATV_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.ICS_CATV_Comments.Text Is Nothing _
                OrElse Me.ICS_CATV_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.ICS_CATV_Comments.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetICS_SOW_Needed()
            
        
            ' Set the ICS_SOW_Needed Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Needed is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetICS_SOW_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_NeededSpecified Then
                				
                ' If the ICS_SOW_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_SOW_Needed)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.ICS_SOW_Needed.Text = formattedValue
                
            Else 
            
                ' ICS_SOW_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.ICS_SOW_Needed.Text = Request_MasterTable.ICS_SOW_Needed.Format(Request_MasterTable.ICS_SOW_Needed.DefaultValue)
                        		
                End If
                 
            ' If the ICS_SOW_Needed is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.ICS_SOW_Needed.Text Is Nothing _
                OrElse Me.ICS_SOW_Needed.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.ICS_SOW_Needed.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetICS_SOW_Uploaded()
            
        
            ' Set the ICS_SOW_Uploaded Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Uploaded is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetICS_SOW_Uploaded()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                				
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_SOW_Uploaded)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.ICS_SOW_Uploaded.Text = formattedValue
                
            Else 
            
                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.ICS_SOW_Uploaded.Text = Request_MasterTable.ICS_SOW_Uploaded.Format(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue)
                        		
                End If
                 
            ' If the ICS_SOW_Uploaded is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.ICS_SOW_Uploaded.Text Is Nothing _
                OrElse Me.ICS_SOW_Uploaded.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.ICS_SOW_Uploaded.Text = "&nbsp;"
            End If
                  
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
                
        Public Overridable Sub SetOTW_Completed_Dt()
            
        
            ' Set the OTW_Completed_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Completed_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Completed_DtSpecified Then
                				
                ' If the OTW_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Completed_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Completed_Dt.Text = Request_MasterTable.OTW_Completed_Dt.Format(Request_MasterTable.OTW_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the OTW_Completed_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Completed_Dt.Text Is Nothing _
                OrElse Me.OTW_Completed_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Completed_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Construction_Status()
            
        
            ' Set the OTW_Construction_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Construction_Status is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Construction_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Construction_StatusSpecified Then
                				
                ' If the OTW_Construction_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Construction_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Construction_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Construction_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Construction_Status.Text = Request_MasterTable.OTW_Construction_Status.Format(Request_MasterTable.OTW_Construction_Status.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Construction_Status is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Construction_Status.Text Is Nothing _
                OrElse Me.OTW_Construction_Status.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Construction_Status.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_Dt()
            
        
            ' Set the OTW_Deployment_Start_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Deployment_Start_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Deployment_Start_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Deployment_Start_DtSpecified Then
                				
                ' If the OTW_Deployment_Start_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Deployment_Start_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Deployment_Start_Dt.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the OTW_Deployment_Start_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Deployment_Start_Dt.Text Is Nothing _
                OrElse Me.OTW_Deployment_Start_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Deployment_Start_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Amt()
            
        
            ' Set the OTW_Invoice_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Amt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_AmtSpecified Then
                				
                ' If the OTW_Invoice_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Invoice_Amt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Amt.Text = Request_MasterTable.OTW_Invoice_Amt.Format(Request_MasterTable.OTW_Invoice_Amt.DefaultValue, "C")
                        		
                End If
                 
            ' If the OTW_Invoice_Amt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Invoice_Amt.Text Is Nothing _
                OrElse Me.OTW_Invoice_Amt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Invoice_Amt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Dt()
            
        
            ' Set the OTW_Invoice_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_DtSpecified Then
                				
                ' If the OTW_Invoice_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Invoice_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Dt.Text = Request_MasterTable.OTW_Invoice_Dt.Format(Request_MasterTable.OTW_Invoice_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the OTW_Invoice_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Invoice_Dt.Text Is Nothing _
                OrElse Me.OTW_Invoice_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Invoice_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_No()
            
        
            ' Set the OTW_Invoice_No Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_No is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_NoSpecified Then
                				
                ' If the OTW_Invoice_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_No)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Invoice_No.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_No.Text = Request_MasterTable.OTW_Invoice_No.Format(Request_MasterTable.OTW_Invoice_No.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Invoice_No is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Invoice_No.Text Is Nothing _
                OrElse Me.OTW_Invoice_No.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Invoice_No.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Island_completed()
            
        
            ' Set the OTW_Island completed Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Island_completed is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Island_completed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Island_completedSpecified Then
                				
                ' If the OTW_Island completed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Island_completed)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Island_completed.Text = formattedValue
                
            Else 
            
                ' OTW_Island completed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Island_completed.Text = Request_MasterTable.OTW_Island_completed.Format(Request_MasterTable.OTW_Island_completed.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Island completed is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Island_completed.Text Is Nothing _
                OrElse Me.OTW_Island_completed.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Island_completed.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_More_Info_Comments()
            
        
            ' Set the OTW_More_Info_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_More_Info_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_More_Info_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_More_Info_CommentsSpecified Then
                				
                ' If the OTW_More_Info_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_More_Info_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_More_Info_Comments.Text = formattedValue
                
            Else 
            
                ' OTW_More_Info_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_More_Info_Comments.Text = Request_MasterTable.OTW_More_Info_Comments.Format(Request_MasterTable.OTW_More_Info_Comments.DefaultValue)
                        		
                End If
                 
            ' If the OTW_More_Info_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_More_Info_Comments.Text Is Nothing _
                OrElse Me.OTW_More_Info_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_More_Info_Comments.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_More_Info_Flag()
            
        
            ' Set the OTW_More_Info_Flag Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_More_Info_Flag is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_More_Info_Flag()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_More_Info_FlagSpecified Then
                				
                ' If the OTW_More_Info_Flag is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_More_Info_Flag)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_More_Info_Flag.Text = formattedValue
                
            Else 
            
                ' OTW_More_Info_Flag is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_More_Info_Flag.Text = Request_MasterTable.OTW_More_Info_Flag.Format(Request_MasterTable.OTW_More_Info_Flag.DefaultValue)
                        		
                End If
                 
            ' If the OTW_More_Info_Flag is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_More_Info_Flag.Text Is Nothing _
                OrElse Me.OTW_More_Info_Flag.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_More_Info_Flag.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_On_Net()
            
        
            ' Set the OTW_On-Net Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_On_Net()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_NetSpecified Then
                				
                ' If the OTW_On-Net is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_On_Net)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_On_Net.Text = formattedValue
                
            Else 
            
                ' OTW_On-Net is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_On_Net.Text = Request_MasterTable.OTW_On_Net.Format(Request_MasterTable.OTW_On_Net.DefaultValue)
                        		
                End If
                 
            ' If the OTW_On-Net is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_On_Net.Text Is Nothing _
                OrElse Me.OTW_On_Net.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_On_Net.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Permit_Status()
            
        
            ' Set the OTW_Permit_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Permit_Status is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Permit_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Permit_StatusSpecified Then
                				
                ' If the OTW_Permit_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Permit_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Permit_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Permit_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Permit_Status.Text = Request_MasterTable.OTW_Permit_Status.Format(Request_MasterTable.OTW_Permit_Status.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Permit_Status is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Permit_Status.Text Is Nothing _
                OrElse Me.OTW_Permit_Status.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Permit_Status.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_Reqd()
            
        
            ' Set the OTW_Premise Fiber Work Reqd Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Premise_Fiber_Work_Reqd is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Premise_Fiber_Work_Reqd()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Premise_Fiber_Work_ReqdSpecified Then
                				
                ' If the OTW_Premise Fiber Work Reqd is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Premise_Fiber_Work_Reqd.Text = formattedValue
                
            Else 
            
                ' OTW_Premise Fiber Work Reqd is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Premise_Fiber_Work_Reqd.Text = Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.Format(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Premise Fiber Work Reqd is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Premise_Fiber_Work_Reqd.Text Is Nothing _
                OrElse Me.OTW_Premise_Fiber_Work_Reqd.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Premise_Fiber_Work_Reqd.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_Dt()
            
        
            ' Set the OTW_Projected_Deploy_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Projected_Deploy_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Projected_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Projected_Deploy_DtSpecified Then
                				
                ' If the OTW_Projected_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Projected_Deploy_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Projected_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Projected_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Projected_Deploy_Dt.Text = Request_MasterTable.OTW_Projected_Deploy_Dt.Format(Request_MasterTable.OTW_Projected_Deploy_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the OTW_Projected_Deploy_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Projected_Deploy_Dt.Text Is Nothing _
                OrElse Me.OTW_Projected_Deploy_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Projected_Deploy_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Quote()
            
        
            ' Set the OTW_Quote Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Quote.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
                End If
                 
            ' If the OTW_Quote is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Quote.Text Is Nothing _
                OrElse Me.OTW_Quote.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Quote.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_Dt()
            
        
            ' Set the OTW_Scheduled_Deploy_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Scheduled_Deploy_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Scheduled_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Scheduled_Deploy_DtSpecified Then
                				
                ' If the OTW_Scheduled_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.OTW_Scheduled_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Scheduled_Deploy_Dt.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the OTW_Scheduled_Deploy_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.OTW_Scheduled_Deploy_Dt.Text Is Nothing _
                OrElse Me.OTW_Scheduled_Deploy_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.OTW_Scheduled_Deploy_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Action_Dt()
            
        
            ' Set the Pending Action_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Action_DtSpecified Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Action_Dt.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Dt.Text = Request_MasterTable.Pending_Action_Dt.Format(Request_MasterTable.Pending_Action_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the Pending Action_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Action_Dt.Text Is Nothing _
                OrElse Me.Pending_Action_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Action_Dt.Text = "&nbsp;"
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
                
        Public Overridable Sub SetPending_Agency_Return()
            
        
            ' Set the Pending_Agency_Return Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency_Return is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency_Return()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Agency_ReturnSpecified Then
                				
                ' If the Pending_Agency_Return is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency_Return)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Agency_Return.Text = formattedValue
                
            Else 
            
                ' Pending_Agency_Return is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency_Return.Text = Request_MasterTable.Pending_Agency_Return.Format(Request_MasterTable.Pending_Agency_Return.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Agency_Return is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Agency_Return.Text Is Nothing _
                OrElse Me.Pending_Agency_Return.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Agency_Return.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_1st()
            
        
            ' Set the Pending_Interval_Days_1st Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_1st is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_1st()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_1stSpecified Then
                				
                ' If the Pending_Interval_Days_1st is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_1st)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Interval_Days_1st.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_1st is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_1st.Text = Request_MasterTable.Pending_Interval_Days_1st.Format(Request_MasterTable.Pending_Interval_Days_1st.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Interval_Days_1st is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Interval_Days_1st.Text Is Nothing _
                OrElse Me.Pending_Interval_Days_1st.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Interval_Days_1st.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_2nd()
            
        
            ' Set the Pending_Interval_Days_2nd Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_2nd is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_2nd()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_2ndSpecified Then
                				
                ' If the Pending_Interval_Days_2nd is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_2nd)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Interval_Days_2nd.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_2nd is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_2nd.Text = Request_MasterTable.Pending_Interval_Days_2nd.Format(Request_MasterTable.Pending_Interval_Days_2nd.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Interval_Days_2nd is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Interval_Days_2nd.Text Is Nothing _
                OrElse Me.Pending_Interval_Days_2nd.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Interval_Days_2nd.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_Auto_Cancel()
            
        
            ' Set the Pending_Interval_Days_Auto_Cancel Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_Auto_Cancel is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_Auto_Cancel()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_Auto_CancelSpecified Then
                				
                ' If the Pending_Interval_Days_Auto_Cancel is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Interval_Days_Auto_Cancel.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_Auto_Cancel is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_Auto_Cancel.Text = Request_MasterTable.Pending_Interval_Days_Auto_Cancel.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Interval_Days_Auto_Cancel is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Interval_Days_Auto_Cancel.Text Is Nothing _
                OrElse Me.Pending_Interval_Days_Auto_Cancel.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Interval_Days_Auto_Cancel.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_Cancel()
            
        
            ' Set the Pending_Interval_Days_Cancel Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_Cancel is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_Cancel()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_CancelSpecified Then
                				
                ' If the Pending_Interval_Days_Cancel is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_Cancel)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Interval_Days_Cancel.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_Cancel is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_Cancel.Text = Request_MasterTable.Pending_Interval_Days_Cancel.Format(Request_MasterTable.Pending_Interval_Days_Cancel.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Interval_Days_Cancel is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Interval_Days_Cancel.Text Is Nothing _
                OrElse Me.Pending_Interval_Days_Cancel.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Interval_Days_Cancel.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Nterval_Days_Max()
            
        
            ' Set the Pending_Nterval_Days_Max Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Nterval_Days_Max is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Nterval_Days_Max()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Nterval_Days_MaxSpecified Then
                				
                ' If the Pending_Nterval_Days_Max is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Nterval_Days_Max)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Nterval_Days_Max.Text = formattedValue
                
            Else 
            
                ' Pending_Nterval_Days_Max is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Nterval_Days_Max.Text = Request_MasterTable.Pending_Nterval_Days_Max.Format(Request_MasterTable.Pending_Nterval_Days_Max.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Nterval_Days_Max is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Nterval_Days_Max.Text Is Nothing _
                OrElse Me.Pending_Nterval_Days_Max.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Nterval_Days_Max.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Prev_Action_Needed()
            
        
            ' Set the Pending_Prev_Action_Needed Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Action_Needed is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Action_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_Action_NeededSpecified Then
                				
                ' If the Pending_Prev_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Action_Needed)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Prev_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Action_Needed.Text = Request_MasterTable.Pending_Prev_Action_Needed.Format(Request_MasterTable.Pending_Prev_Action_Needed.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Prev_Action_Needed is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Prev_Action_Needed.Text Is Nothing _
                OrElse Me.Pending_Prev_Action_Needed.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Prev_Action_Needed.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPending_Prev_Status()
            
        
            ' Set the Pending_Prev_Status Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Status is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_StatusSpecified Then
                				
                ' If the Pending_Prev_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Status)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Pending_Prev_Status.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Status.Text = Request_MasterTable.Pending_Prev_Status.Format(Request_MasterTable.Pending_Prev_Status.DefaultValue)
                        		
                End If
                 
            ' If the Pending_Prev_Status is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Pending_Prev_Status.Text Is Nothing _
                OrElse Me.Pending_Prev_Status.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Pending_Prev_Status.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetPriority()
            
        
            ' Set the Priority Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Priority is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPriority()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.PrioritySpecified Then
                				
                ' If the Priority is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Priority)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Priority.Text = formattedValue
                
            Else 
            
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Priority.Text = Request_MasterTable.Priority.Format(Request_MasterTable.Priority.DefaultValue)
                        		
                End If
                 
            ' If the Priority is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Priority.Text Is Nothing _
                OrElse Me.Priority.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Priority.Text = "&nbsp;"
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
                
        Public Overridable Sub SetReq_Comments()
            
        
            ' Set the Req_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CommentsSpecified Then
                				
                ' If the Req_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Comments.Text = formattedValue
                
            Else 
            
                ' Req_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Comments.Text = Request_MasterTable.Req_Comments.Format(Request_MasterTable.Req_Comments.DefaultValue)
                        		
                End If
                 
            ' If the Req_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Comments.Text Is Nothing _
                OrElse Me.Req_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Comments.Text = "&nbsp;"
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Completed_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Completed_Dt.Text = Request_MasterTable.Req_Completed_Dt.Format(Request_MasterTable.Req_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the Req_Completed_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Completed_Dt.Text Is Nothing _
                OrElse Me.Req_Completed_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Completed_Dt.Text = "&nbsp;"
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
                 
            ' If the Req_Contact_Email2 is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Contact_Email.Text Is Nothing _
                OrElse Me.Req_Contact_Email.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Contact_Email.Text = "&nbsp;"
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_DtSpecified Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt.Text = Request_MasterTable.Req_Dt.Format(Request_MasterTable.Req_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the Req_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Dt.Text Is Nothing _
                OrElse Me.Req_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Enity()
            
        
            ' Set the Req_Enity Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_EnitySpecified Then
                				
                ' If the Req_Enity is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Enity.Text = formattedValue
                
            Else 
            
                ' Req_Enity is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity.Text = Request_MasterTable.Req_Enity.Format(Request_MasterTable.Req_Enity.DefaultValue)
                        		
                End If
                 
            ' If the Req_Enity is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Enity.Text Is Nothing _
                OrElse Me.Req_Enity.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Enity.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Funding_Src()
            
        
            ' Set the Req_Funding_Src Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Funding_Src is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Funding_Src()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Funding_SrcSpecified Then
                				
                ' If the Req_Funding_Src is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Funding_Src)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Funding_Src.Text = formattedValue
                
            Else 
            
                ' Req_Funding_Src is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Funding_Src.Text = Request_MasterTable.Req_Funding_Src.Format(Request_MasterTable.Req_Funding_Src.DefaultValue)
                        		
                End If
                 
            ' If the Req_Funding_Src is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Funding_Src.Text Is Nothing _
                OrElse Me.Req_Funding_Src.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Funding_Src.Text = "&nbsp;"
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
                 
            ' If the Req_Funding_Src2 is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Funding_Src2.Text Is Nothing _
                OrElse Me.Req_Funding_Src2.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Funding_Src2.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Invoice_Paid()
            
        
            ' Set the Req_Invoice_Paid Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Invoice_Paid is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Invoice_Paid()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Invoice_PaidSpecified Then
                				
                ' If the Req_Invoice_Paid is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Invoice_Paid)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Invoice_Paid.Text = formattedValue
                
            Else 
            
                ' Req_Invoice_Paid is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Invoice_Paid.Text = Request_MasterTable.Req_Invoice_Paid.Format(Request_MasterTable.Req_Invoice_Paid.DefaultValue)
                        		
                End If
                 
            ' If the Req_Invoice_Paid is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Invoice_Paid.Text Is Nothing _
                OrElse Me.Req_Invoice_Paid.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Invoice_Paid.Text = "&nbsp;"
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
                
        Public Overridable Sub SetReq_PO_Amt()
            
        
            ' Set the Req_PO_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Amt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_AmtSpecified Then
                				
                ' If the Req_PO_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_PO_Amt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Amt.Text = Request_MasterTable.Req_PO_Amt.Format(Request_MasterTable.Req_PO_Amt.DefaultValue, "C")
                        		
                End If
                 
            ' If the Req_PO_Amt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_PO_Amt.Text Is Nothing _
                OrElse Me.Req_PO_Amt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_PO_Amt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_PO_Dt()
            
        
            ' Set the Req_PO_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_DtSpecified Then
                				
                ' If the Req_PO_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_PO_Dt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Dt.Text = Request_MasterTable.Req_PO_Dt.Format(Request_MasterTable.Req_PO_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the Req_PO_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_PO_Dt.Text Is Nothing _
                OrElse Me.Req_PO_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_PO_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_PO_No()
            
        
            ' Set the Req_PO_No Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_No is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_NoSpecified Then
                				
                ' If the Req_PO_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_No)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_PO_No.Text = formattedValue
                
            Else 
            
                ' Req_PO_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_No.Text = Request_MasterTable.Req_PO_No.Format(Request_MasterTable.Req_PO_No.DefaultValue)
                        		
                End If
                 
            ' If the Req_PO_No is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_PO_No.Text Is Nothing _
                OrElse Me.Req_PO_No.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_PO_No.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Amt()
            
        
            ' Set the Req_Pymt_Amt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Amt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_AmtSpecified Then
                				
                ' If the Req_Pymt_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Amt, "C")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Pymt_Amt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Amt.Text = Request_MasterTable.Req_Pymt_Amt.Format(Request_MasterTable.Req_Pymt_Amt.DefaultValue, "C")
                        		
                End If
                 
            ' If the Req_Pymt_Amt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Pymt_Amt.Text Is Nothing _
                OrElse Me.Req_Pymt_Amt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Pymt_Amt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Check_No()
            
        
            ' Set the Req_Pymt_Check_No Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Check_No is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Check_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_Check_NoSpecified Then
                				
                ' If the Req_Pymt_Check_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Check_No)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Pymt_Check_No.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Check_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Check_No.Text = Request_MasterTable.Req_Pymt_Check_No.Format(Request_MasterTable.Req_Pymt_Check_No.DefaultValue)
                        		
                End If
                 
            ' If the Req_Pymt_Check_No is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Pymt_Check_No.Text Is Nothing _
                OrElse Me.Req_Pymt_Check_No.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Pymt_Check_No.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Dt()
            
        
            ' Set the Req_Pymt_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_DtSpecified Then
                				
                ' If the Req_Pymt_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Dt, "d")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Pymt_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Dt.Text = Request_MasterTable.Req_Pymt_Dt.Format(Request_MasterTable.Req_Pymt_Dt.DefaultValue, "d")
                        		
                End If
                 
            ' If the Req_Pymt_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Pymt_Dt.Text Is Nothing _
                OrElse Me.Req_Pymt_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Pymt_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Quote_Approved()
            
        
            ' Set the Req_Quote_Approved Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Quote_Approved is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Quote_Approved()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_ApprovedSpecified Then
                				
                ' If the Req_Quote_Approved is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Approved, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Quote_Approved.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Approved is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Quote_Approved.Text = Request_MasterTable.Req_Quote_Approved.Format(Request_MasterTable.Req_Quote_Approved.DefaultValue, "g")
                        		
                End If
                 
            ' If the Req_Quote_Approved is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Quote_Approved.Text Is Nothing _
                OrElse Me.Req_Quote_Approved.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Quote_Approved.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetReq_Quote_Respnse()
            
        
            ' Set the Req_Quote_Respnse Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Quote_Respnse is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Quote_Respnse()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_RespnseSpecified Then
                				
                ' If the Req_Quote_Respnse is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Respnse)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Quote_Respnse.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Respnse is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Quote_Respnse.Text = Request_MasterTable.Req_Quote_Respnse.Format(Request_MasterTable.Req_Quote_Respnse.DefaultValue)
                        		
                End If
                 
            ' If the Req_Quote_Respnse is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_Quote_Respnse.Text Is Nothing _
                OrElse Me.Req_Quote_Respnse.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_Quote_Respnse.Text = "&nbsp;"
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
                
        Public Overridable Sub SetReq_State()
            
        
            ' Set the Req_State Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_State is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_State()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StateSpecified Then
                				
                ' If the Req_State is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_State)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_State.Text = formattedValue
                
            Else 
            
                ' Req_State is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_State.Text = Request_MasterTable.Req_State.Format(Request_MasterTable.Req_State.DefaultValue)
                        		
                End If
                 
            ' If the Req_State is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Req_State.Text Is Nothing _
                OrElse Me.Req_State.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Req_State.Text = "&nbsp;"
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Target_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Target_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Target_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Target_Dt.Text = Request_MasterTable.Req_Target_Dt.Format(Request_MasterTable.Req_Target_Dt.DefaultValue, "g")
                        		
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
          
        Dim recCommentsRecordControl as CommentsRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "CommentsRecordControl"), CommentsRecordControl)
        recCommentsRecordControl.SaveData()
        
        Dim recContactsRecordControl as ContactsRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "ContactsRecordControl"), ContactsRecordControl)
        recContactsRecordControl.SaveData()
        
        Dim recEnityRecordControl as EnityRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me, "EnityRecordControl"), EnityRecordControl)
        recEnityRecordControl.SaveData()
        
        End Sub

        ' To customize, override this method in Request_MasterTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetCat_Cost_Free()
            GetCat_Franchise_Order_Number()
            GetCat_OTWC_Comments()
            GetCounty_Upload()
            GetICS_CATV_Comments()
            GetICS_SOW_Needed()
            GetICS_SOW_Uploaded()
            GetIROC_Id()
            GetOTW_Completed_Dt()
            GetOTW_Construction_Status()
            GetOTW_Deployment_Start_Dt()
            GetOTW_Invoice_Amt()
            GetOTW_Invoice_Dt()
            GetOTW_Invoice_No()
            GetOTW_Island_completed()
            GetOTW_More_Info_Comments()
            GetOTW_More_Info_Flag()
            GetOTW_On_Net()
            GetOTW_Permit_Status()
            GetOTW_Premise_Fiber_Work_Reqd()
            GetOTW_Projected_Deploy_Dt()
            GetOTW_Quote()
            GetOTW_Scheduled_Deploy_Dt()
            GetPending_Action_Dt()
            GetPending_Action_Needed()
            GetPending_Agency()
            GetPending_Agency_Return()
            GetPending_Interval_Days_1st()
            GetPending_Interval_Days_2nd()
            GetPending_Interval_Days_Auto_Cancel()
            GetPending_Interval_Days_Cancel()
            GetPending_Nterval_Days_Max()
            GetPending_Prev_Action_Needed()
            GetPending_Prev_Status()
            GetPriority()
            GetReg_Type()
            GetReq_Address()
            GetReq_City()
            GetReq_Comments()
            GetReq_Completed_Dt()
            GetReq_Contact_Email()
            GetReq_Dt()
            GetReq_Enity()
            GetReq_Funding_Src()
            GetReq_Funding_Src2()
            GetReq_Invoice_Paid()
            GetReq_Island()
            GetReq_PO_Amt()
            GetReq_PO_Dt()
            GetReq_PO_No()
            GetReq_Pymt_Amt()
            GetReq_Pymt_Check_No()
            GetReq_Pymt_Dt()
            GetReq_Quote_Approved()
            GetReq_Quote_Respnse()
            GetReq_Site_Name()
            GetReq_State()
            GetReq_Status()
            GetReq_Target_Dt()
            GetReq_Zip()
        End Sub
        
        
        Public Overridable Sub GetCat_Cost_Free()
            
        End Sub
                
        Public Overridable Sub GetCat_Franchise_Order_Number()
            
        End Sub
                
        Public Overridable Sub GetCat_OTWC_Comments()
            
        End Sub
                
        Public Overridable Sub GetCounty_Upload()
            
        End Sub
                
        Public Overridable Sub GetICS_CATV_Comments()
            
        End Sub
                
        Public Overridable Sub GetICS_SOW_Needed()
            
        End Sub
                
        Public Overridable Sub GetICS_SOW_Uploaded()
            
        End Sub
                
        Public Overridable Sub GetIROC_Id()
            
        End Sub
                
        Public Overridable Sub GetOTW_Completed_Dt()
            
        End Sub
                
        Public Overridable Sub GetOTW_Construction_Status()
            
        End Sub
                
        Public Overridable Sub GetOTW_Deployment_Start_Dt()
            
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Amt()
            
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Dt()
            
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_No()
            
        End Sub
                
        Public Overridable Sub GetOTW_Island_completed()
            
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Comments()
            
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Flag()
            
        End Sub
                
        Public Overridable Sub GetOTW_On_Net()
            
        End Sub
                
        Public Overridable Sub GetOTW_Permit_Status()
            
        End Sub
                
        Public Overridable Sub GetOTW_Premise_Fiber_Work_Reqd()
            
        End Sub
                
        Public Overridable Sub GetOTW_Projected_Deploy_Dt()
            
        End Sub
                
        Public Overridable Sub GetOTW_Quote()
            
        End Sub
                
        Public Overridable Sub GetOTW_Scheduled_Deploy_Dt()
            
        End Sub
                
        Public Overridable Sub GetPending_Action_Dt()
            
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed()
            
        End Sub
                
        Public Overridable Sub GetPending_Agency()
            
        End Sub
                
        Public Overridable Sub GetPending_Agency_Return()
            
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_1st()
            
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_2nd()
            
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_Auto_Cancel()
            
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_Cancel()
            
        End Sub
                
        Public Overridable Sub GetPending_Nterval_Days_Max()
            
        End Sub
                
        Public Overridable Sub GetPending_Prev_Action_Needed()
            
        End Sub
                
        Public Overridable Sub GetPending_Prev_Status()
            
        End Sub
                
        Public Overridable Sub GetPriority()
            
        End Sub
                
        Public Overridable Sub GetReg_Type()
            
        End Sub
                
        Public Overridable Sub GetReq_Address()
            
        End Sub
                
        Public Overridable Sub GetReq_City()
            
        End Sub
                
        Public Overridable Sub GetReq_Comments()
            
        End Sub
                
        Public Overridable Sub GetReq_Completed_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Contact_Email()
            
        End Sub
                
        Public Overridable Sub GetReq_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Enity()
            
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src()
            
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src2()
            
        End Sub
                
        Public Overridable Sub GetReq_Invoice_Paid()
            
        End Sub
                
        Public Overridable Sub GetReq_Island()
            
        End Sub
                
        Public Overridable Sub GetReq_PO_Amt()
            
        End Sub
                
        Public Overridable Sub GetReq_PO_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_PO_No()
            
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Amt()
            
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Check_No()
            
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Dt()
            
        End Sub
                
        Public Overridable Sub GetReq_Quote_Approved()
            
        End Sub
                
        Public Overridable Sub GetReq_Quote_Respnse()
            
        End Sub
                
        Public Overridable Sub GetReq_Site_Name()
            
        End Sub
                
        Public Overridable Sub GetReq_State()
            
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
            
              
                  Dim url As String = "../Request_Master/Edit-Request-Master.aspx?Request_Master={PK}"
                
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
        
        Public ReadOnly Property Cat_Cost_Free() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_Free"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Franchise_Order_Number() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_Number"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Cat_OTWC_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property CommentsRecordControl() As CommentsRecordControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsRecordControl"), CommentsRecordControl)
            End Get
        End Property
        
        Public ReadOnly Property ContactsRecordControl() As ContactsRecordControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRecordControl"), ContactsRecordControl)
            End Get
        End Property
        
        Public ReadOnly Property County_Upload() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_Upload"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property EnityRecordControl() As EnityRecordControl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "EnityRecordControl"), EnityRecordControl)
            End Get
        End Property
        
        Public ReadOnly Property ICS_CATV_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_Needed() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Needed"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_Uploaded() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Uploaded"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Completed_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Construction_Status() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_Status"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Deployment_Start_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_Amt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Amt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_No() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_No"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Island_completed() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completed"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_Flag() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Flag"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_On_Net() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Permit_Status() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_Status"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Premise_Fiber_Work_Reqd() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_Reqd"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Projected_Deploy_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Quote() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Scheduled_Deploy_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Dt"), System.Web.UI.WebControls.Literal)
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
            
        Public ReadOnly Property Pending_Agency_Return() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_Return"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_1st() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_1st"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_2nd() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_2nd"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_Auto_Cancel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Auto_Cancel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_Cancel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Cancel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Nterval_Days_Max() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Nterval_Days_Max"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_Action_Needed() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_Needed"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_Status() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Status"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Priority() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Priority"), System.Web.UI.WebControls.Literal)
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
            
        Public ReadOnly Property Req_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Completed_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Contact_Email() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Enity() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_Src() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_Src2() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src2"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Invoice_Paid() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Invoice_Paid"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Island() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_Amt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Amt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_No() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_No"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Amt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Amt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Check_No() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_No"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Quote_Approved() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_Approved"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Quote_Respnse() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_Respnse"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Site_Name() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_Name"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_State() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_State"), System.Web.UI.WebControls.Literal)
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

  

' Base class for the Request_MasterTableControl control on the Show_Request_Master_Table page.
' Do not modify this class. Instead override any method in Request_MasterTableControl.
Public Class BaseRequest_MasterTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Req_EnityFilter) 				
                    initialVal = Me.GetFromSession(Me.Req_EnityFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""Req_Enity"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Req_EnityFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Req_EnityFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Req_EnityFilter.Items.Add(item)
                                Me.Req_EnityFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Req_EnityFilter.Items
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
            
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
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
          
              AddHandler Me.Cat_Cost_FreeLabel.Click, AddressOf Cat_Cost_FreeLabel_Click
            
              AddHandler Me.Cat_Franchise_Order_NumberLabel.Click, AddressOf Cat_Franchise_Order_NumberLabel_Click
            
              AddHandler Me.Cat_OTWC_CommentsLabel.Click, AddressOf Cat_OTWC_CommentsLabel_Click
            
              AddHandler Me.County_UploadLabel.Click, AddressOf County_UploadLabel_Click
            
              AddHandler Me.ICS_CATV_CommentsLabel.Click, AddressOf ICS_CATV_CommentsLabel_Click
            
              AddHandler Me.ICS_SOW_NeededLabel.Click, AddressOf ICS_SOW_NeededLabel_Click
            
              AddHandler Me.ICS_SOW_UploadedLabel.Click, AddressOf ICS_SOW_UploadedLabel_Click
            
              AddHandler Me.IROC_IdLabel.Click, AddressOf IROC_IdLabel_Click
            
              AddHandler Me.OTW_Completed_DtLabel.Click, AddressOf OTW_Completed_DtLabel_Click
            
              AddHandler Me.OTW_Construction_StatusLabel.Click, AddressOf OTW_Construction_StatusLabel_Click
            
              AddHandler Me.OTW_Deployment_Start_DtLabel.Click, AddressOf OTW_Deployment_Start_DtLabel_Click
            
              AddHandler Me.OTW_Invoice_AmtLabel.Click, AddressOf OTW_Invoice_AmtLabel_Click
            
              AddHandler Me.OTW_Invoice_DtLabel.Click, AddressOf OTW_Invoice_DtLabel_Click
            
              AddHandler Me.OTW_Invoice_NoLabel.Click, AddressOf OTW_Invoice_NoLabel_Click
            
              AddHandler Me.OTW_Island_completedLabel.Click, AddressOf OTW_Island_completedLabel_Click
            
              AddHandler Me.OTW_More_Info_CommentsLabel.Click, AddressOf OTW_More_Info_CommentsLabel_Click
            
              AddHandler Me.OTW_More_Info_FlagLabel.Click, AddressOf OTW_More_Info_FlagLabel_Click
            
              AddHandler Me.OTW_On_NetLabel.Click, AddressOf OTW_On_NetLabel_Click
            
              AddHandler Me.OTW_Permit_StatusLabel.Click, AddressOf OTW_Permit_StatusLabel_Click
            
              AddHandler Me.OTW_Premise_Fiber_Work_ReqdLabel.Click, AddressOf OTW_Premise_Fiber_Work_ReqdLabel_Click
            
              AddHandler Me.OTW_Projected_Deploy_DtLabel.Click, AddressOf OTW_Projected_Deploy_DtLabel_Click
            
              AddHandler Me.OTW_QuoteLabel.Click, AddressOf OTW_QuoteLabel_Click
            
              AddHandler Me.OTW_Scheduled_Deploy_DtLabel.Click, AddressOf OTW_Scheduled_Deploy_DtLabel_Click
            
              AddHandler Me.Pending_Action_DtLabel.Click, AddressOf Pending_Action_DtLabel_Click
            
              AddHandler Me.Pending_Action_NeededLabel.Click, AddressOf Pending_Action_NeededLabel_Click
            
              AddHandler Me.Pending_Agency_ReturnLabel.Click, AddressOf Pending_Agency_ReturnLabel_Click
            
              AddHandler Me.Pending_AgencyLabel.Click, AddressOf Pending_AgencyLabel_Click
            
              AddHandler Me.Pending_Interval_Days_1stLabel.Click, AddressOf Pending_Interval_Days_1stLabel_Click
            
              AddHandler Me.Pending_Interval_Days_2ndLabel.Click, AddressOf Pending_Interval_Days_2ndLabel_Click
            
              AddHandler Me.Pending_Interval_Days_Auto_CancelLabel.Click, AddressOf Pending_Interval_Days_Auto_CancelLabel_Click
            
              AddHandler Me.Pending_Interval_Days_CancelLabel.Click, AddressOf Pending_Interval_Days_CancelLabel_Click
            
              AddHandler Me.Pending_Nterval_Days_MaxLabel.Click, AddressOf Pending_Nterval_Days_MaxLabel_Click
            
              AddHandler Me.Pending_Prev_Action_NeededLabel.Click, AddressOf Pending_Prev_Action_NeededLabel_Click
            
              AddHandler Me.Pending_Prev_StatusLabel.Click, AddressOf Pending_Prev_StatusLabel_Click
            
              AddHandler Me.PriorityLabel.Click, AddressOf PriorityLabel_Click
            
              AddHandler Me.Reg_TypeLabel.Click, AddressOf Reg_TypeLabel_Click
            
              AddHandler Me.Req_AddressLabel.Click, AddressOf Req_AddressLabel_Click
            
              AddHandler Me.Req_CityLabel.Click, AddressOf Req_CityLabel_Click
            
              AddHandler Me.Req_CommentsLabel.Click, AddressOf Req_CommentsLabel_Click
            
              AddHandler Me.Req_Completed_DtLabel.Click, AddressOf Req_Completed_DtLabel_Click
            
              AddHandler Me.Req_Contact_EmailLabel.Click, AddressOf Req_Contact_EmailLabel_Click
            
              AddHandler Me.Req_DtLabel.Click, AddressOf Req_DtLabel_Click
            
              AddHandler Me.Req_EnityLabel.Click, AddressOf Req_EnityLabel_Click
            
              AddHandler Me.Req_Funding_Src2Label.Click, AddressOf Req_Funding_Src2Label_Click
            
              AddHandler Me.Req_Funding_SrcLabel.Click, AddressOf Req_Funding_SrcLabel_Click
            
              AddHandler Me.Req_Invoice_PaidLabel.Click, AddressOf Req_Invoice_PaidLabel_Click
            
              AddHandler Me.Req_IslandLabel.Click, AddressOf Req_IslandLabel_Click
            
              AddHandler Me.Req_PO_AmtLabel.Click, AddressOf Req_PO_AmtLabel_Click
            
              AddHandler Me.Req_PO_DtLabel.Click, AddressOf Req_PO_DtLabel_Click
            
              AddHandler Me.Req_PO_NoLabel.Click, AddressOf Req_PO_NoLabel_Click
            
              AddHandler Me.Req_Pymt_AmtLabel.Click, AddressOf Req_Pymt_AmtLabel_Click
            
              AddHandler Me.Req_Pymt_Check_NoLabel.Click, AddressOf Req_Pymt_Check_NoLabel_Click
            
              AddHandler Me.Req_Pymt_DtLabel.Click, AddressOf Req_Pymt_DtLabel_Click
            
              AddHandler Me.Req_Quote_ApprovedLabel.Click, AddressOf Req_Quote_ApprovedLabel_Click
            
              AddHandler Me.Req_Quote_RespnseLabel.Click, AddressOf Req_Quote_RespnseLabel_Click
            
              AddHandler Me.Req_Site_NameLabel.Click, AddressOf Req_Site_NameLabel_Click
            
              AddHandler Me.Req_StateLabel.Click, AddressOf Req_StateLabel_Click
            
              AddHandler Me.Req_StatusLabel.Click, AddressOf Req_StatusLabel_Click
            
              AddHandler Me.Req_Target_DtLabel.Click, AddressOf Req_Target_DtLabel_Click
            
              AddHandler Me.Req_ZipLabel.Click, AddressOf Req_ZipLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.Request_MasterExportExcelButton.Click, AddressOf Request_MasterExportExcelButton_Click
              							
              Me.Request_MasterImportButton.PostBackUrl = "../Shared/SelectFileToImport.aspx?TableName=Request_Master" 
              Me.Request_MasterImportButton.Attributes.Item("onClick") = "window.open('" & Me.Page.EncryptUrlParameter(Me.Request_MasterImportButton.PostBackUrl) & "','importWindow', 'width=700, height=500,top=' +(screen.availHeight-500)/2 + ',left=' + (screen.availWidth-700)/2+ ', resizable=yes, scrollbars=yes,modal=yes'); return false;"
                        
              AddHandler Me.Request_MasterImportButton.Click, AddressOf Request_MasterImportButton_Click
              
              AddHandler Me.Request_MasterNewButton.Click, AddressOf Request_MasterNewButton_Click
              
              AddHandler Me.Request_MasterPDFButton.Click, AddressOf Request_MasterPDFButton_Click
              
              AddHandler Me.Request_MasterResetButton.Click, AddressOf Request_MasterResetButton_Click
              
              AddHandler Me.Request_MasterWordButton.Click, AddressOf Request_MasterWordButton_Click
              
            AddHandler Me.Request_MasterSearchButton.Button.Click, AddressOf Request_MasterSearchButton_Click
        
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Req_EnityFilter.PostBackUrl = url & "?Target=" & Me.Req_EnityFilter.ClientID & "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Enity")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Req_EnityFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Req_EnityFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Req_EnityFilter.SelectedIndexChanged, AddressOf Req_EnityFilter_SelectedIndexChanged                  
                        
        
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
        
                SetCat_Cost_FreeLabel()
                SetCat_Franchise_Order_NumberLabel()
                SetCat_OTWC_CommentsLabel()
                SetCommentsRecordControlLabel()
                SetContactsRecordControlLabel()
                SetCounty_UploadLabel()
                SetEnityRecordControlLabel()
                SetICS_CATV_CommentsLabel()
                SetICS_SOW_NeededLabel()
                SetICS_SOW_UploadedLabel()
                SetIROC_IdLabel()
                SetOTW_Completed_DtLabel()
                SetOTW_Construction_StatusLabel()
                SetOTW_Deployment_Start_DtLabel()
                SetOTW_Invoice_AmtLabel()
                SetOTW_Invoice_DtLabel()
                SetOTW_Invoice_NoLabel()
                SetOTW_Island_completedLabel()
                SetOTW_More_Info_CommentsLabel()
                SetOTW_More_Info_FlagLabel()
                SetOTW_On_NetLabel()
                SetOTW_Permit_StatusLabel()
                SetOTW_Premise_Fiber_Work_ReqdLabel()
                SetOTW_Projected_Deploy_DtLabel()
                SetOTW_QuoteLabel()
                SetOTW_Scheduled_Deploy_DtLabel()
                SetPending_Action_DtLabel()
                SetPending_Action_NeededLabel()
                SetPending_Agency_ReturnLabel()
                SetPending_AgencyLabel()
                SetPending_Interval_Days_1stLabel()
                SetPending_Interval_Days_2ndLabel()
                SetPending_Interval_Days_Auto_CancelLabel()
                SetPending_Interval_Days_CancelLabel()
                SetPending_Nterval_Days_MaxLabel()
                SetPending_Prev_Action_NeededLabel()
                SetPending_Prev_StatusLabel()
                SetPriorityLabel()
                SetReg_TypeLabel()
                SetReq_AddressLabel()
                SetReq_CityLabel()
                SetReq_CommentsLabel()
                SetReq_Completed_DtLabel()
                SetReq_Contact_EmailLabel()
                SetReq_DtLabel()
                SetReq_EnityFilter()
                SetReq_EnityLabel()
                SetReq_EnityLabel1()
                SetReq_Funding_Src2Label()
                SetReq_Funding_SrcLabel()
                SetReq_Invoice_PaidLabel()
                SetReq_IslandLabel()
                SetReq_PO_AmtLabel()
                SetReq_PO_DtLabel()
                SetReq_PO_NoLabel()
                SetReq_Pymt_AmtLabel()
                SetReq_Pymt_Check_NoLabel()
                SetReq_Pymt_DtLabel()
                SetReq_Quote_ApprovedLabel()
                SetReq_Quote_RespnseLabel()
                SetReq_Site_NameLabel()
                SetReq_StateLabel()
                SetReq_StatusLabel()
                SetReq_Target_DtLabel()
                SetReq_ZipLabel()
                
                
                
                
                
                
                SetRequest_MasterSearch()
                
                
                
                
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
                    
            Me.Req_EnityFilter.ClearSelection()
            
            Me.Request_MasterSearch.Text = ""
            
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
                
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

              
            If IsValueSelected(Me.Req_EnityFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Req_EnityFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Req_EnityFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(Request_MasterTable.Req_Enity, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
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
        
      cols.Add(Request_MasterTable.Req_Enity, True)
      
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
      
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
            Dim Req_EnityFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Req_EnityFilter_Ajax"), String)
            If IsValueSelected(Req_EnityFilterSelectedValue) Then
    
            If Not isNothing(Req_EnityFilterSelectedValue) Then
                Dim Req_EnityFilteritemListFromSession() As String = Req_EnityFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Req_EnityFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(Request_MasterTable.Req_Enity, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
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
        
      cols.Add(Request_MasterTable.Req_Enity, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators & formatedSearchText, True, False)
                
      Next
    
                    Else
                        
      Dim cols As New ColumnList    
        
      cols.Add(Request_MasterTable.Req_Enity, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, formatedSearchText, True, False)
      Next
    
                    End If
                    wc.iAND(search)
                End If
            End If
                  
      
      
            Return wc
        End Function
          
        Public Overridable Function GetAutoCompletionList_Request_MasterSearch(ByVal prefixText As String, ByVal count As Integer) As String()
            Dim resultList As ArrayList = New ArrayList
            Dim wordList As ArrayList = New ArrayList
            
            Dim filterJoin As CompoundFilter = CreateCompoundJoinFilter()
            If count = 0 Then count = 10
            Dim wc As WhereClause = CreateWhereClause(prefixText,"Request_MasterSearch", "WordsStartingWithSearchString", "[^a-zA-Z0-9]")
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
        
                resultItem = rec.Format(Request_MasterTable.Req_Enity)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If Request_MasterTable.Req_Enity.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "WordsStartingWithSearchString", "[^a-zA-Z0-9]", resultList, Request_MasterTable.Req_Enity.IsFullTextSearchable)
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
        
                        If recControl.Cat_Cost_Free.Text <> "" Then
                            rec.Parse(recControl.Cat_Cost_Free.Text, Request_MasterTable.Cat_Cost_Free)
                        End If
                        If recControl.Cat_Franchise_Order_Number.Text <> "" Then
                            rec.Parse(recControl.Cat_Franchise_Order_Number.Text, Request_MasterTable.Cat_Franchise_Order_Number)
                        End If
                        If recControl.Cat_OTWC_Comments.Text <> "" Then
                            rec.Parse(recControl.Cat_OTWC_Comments.Text, Request_MasterTable.Cat_OTWC_Comments)
                        End If
                        If recControl.County_Upload.Text <> "" Then
                            rec.Parse(recControl.County_Upload.Text, Request_MasterTable.County_Upload)
                        End If
                        If recControl.ICS_CATV_Comments.Text <> "" Then
                            rec.Parse(recControl.ICS_CATV_Comments.Text, Request_MasterTable.ICS_CATV_Comments)
                        End If
                        If recControl.ICS_SOW_Needed.Text <> "" Then
                            rec.Parse(recControl.ICS_SOW_Needed.Text, Request_MasterTable.ICS_SOW_Needed)
                        End If
                        If recControl.ICS_SOW_Uploaded.Text <> "" Then
                            rec.Parse(recControl.ICS_SOW_Uploaded.Text, Request_MasterTable.ICS_SOW_Uploaded)
                        End If
                        If recControl.IROC_Id.Text <> "" Then
                            rec.Parse(recControl.IROC_Id.Text, Request_MasterTable.IROC_Id)
                        End If
                        If recControl.OTW_Completed_Dt.Text <> "" Then
                            rec.Parse(recControl.OTW_Completed_Dt.Text, Request_MasterTable.OTW_Completed_Dt)
                        End If
                        If recControl.OTW_Construction_Status.Text <> "" Then
                            rec.Parse(recControl.OTW_Construction_Status.Text, Request_MasterTable.OTW_Construction_Status)
                        End If
                        If recControl.OTW_Deployment_Start_Dt.Text <> "" Then
                            rec.Parse(recControl.OTW_Deployment_Start_Dt.Text, Request_MasterTable.OTW_Deployment_Start_Dt)
                        End If
                        If recControl.OTW_Invoice_Amt.Text <> "" Then
                            rec.Parse(recControl.OTW_Invoice_Amt.Text, Request_MasterTable.OTW_Invoice_Amt)
                        End If
                        If recControl.OTW_Invoice_Dt.Text <> "" Then
                            rec.Parse(recControl.OTW_Invoice_Dt.Text, Request_MasterTable.OTW_Invoice_Dt)
                        End If
                        If recControl.OTW_Invoice_No.Text <> "" Then
                            rec.Parse(recControl.OTW_Invoice_No.Text, Request_MasterTable.OTW_Invoice_No)
                        End If
                        If recControl.OTW_Island_completed.Text <> "" Then
                            rec.Parse(recControl.OTW_Island_completed.Text, Request_MasterTable.OTW_Island_completed)
                        End If
                        If recControl.OTW_More_Info_Comments.Text <> "" Then
                            rec.Parse(recControl.OTW_More_Info_Comments.Text, Request_MasterTable.OTW_More_Info_Comments)
                        End If
                        If recControl.OTW_More_Info_Flag.Text <> "" Then
                            rec.Parse(recControl.OTW_More_Info_Flag.Text, Request_MasterTable.OTW_More_Info_Flag)
                        End If
                        If recControl.OTW_On_Net.Text <> "" Then
                            rec.Parse(recControl.OTW_On_Net.Text, Request_MasterTable.OTW_On_Net)
                        End If
                        If recControl.OTW_Permit_Status.Text <> "" Then
                            rec.Parse(recControl.OTW_Permit_Status.Text, Request_MasterTable.OTW_Permit_Status)
                        End If
                        If recControl.OTW_Premise_Fiber_Work_Reqd.Text <> "" Then
                            rec.Parse(recControl.OTW_Premise_Fiber_Work_Reqd.Text, Request_MasterTable.OTW_Premise_Fiber_Work_Reqd)
                        End If
                        If recControl.OTW_Projected_Deploy_Dt.Text <> "" Then
                            rec.Parse(recControl.OTW_Projected_Deploy_Dt.Text, Request_MasterTable.OTW_Projected_Deploy_Dt)
                        End If
                        If recControl.OTW_Quote.Text <> "" Then
                            rec.Parse(recControl.OTW_Quote.Text, Request_MasterTable.OTW_Quote)
                        End If
                        If recControl.OTW_Scheduled_Deploy_Dt.Text <> "" Then
                            rec.Parse(recControl.OTW_Scheduled_Deploy_Dt.Text, Request_MasterTable.OTW_Scheduled_Deploy_Dt)
                        End If
                        If recControl.Pending_Action_Dt.Text <> "" Then
                            rec.Parse(recControl.Pending_Action_Dt.Text, Request_MasterTable.Pending_Action_Dt)
                        End If
                        If recControl.Pending_Action_Needed.Text <> "" Then
                            rec.Parse(recControl.Pending_Action_Needed.Text, Request_MasterTable.Pending_Action_Needed)
                        End If
                        If recControl.Pending_Agency.Text <> "" Then
                            rec.Parse(recControl.Pending_Agency.Text, Request_MasterTable.Pending_Agency)
                        End If
                        If recControl.Pending_Agency_Return.Text <> "" Then
                            rec.Parse(recControl.Pending_Agency_Return.Text, Request_MasterTable.Pending_Agency_Return)
                        End If
                        If recControl.Pending_Interval_Days_1st.Text <> "" Then
                            rec.Parse(recControl.Pending_Interval_Days_1st.Text, Request_MasterTable.Pending_Interval_Days_1st)
                        End If
                        If recControl.Pending_Interval_Days_2nd.Text <> "" Then
                            rec.Parse(recControl.Pending_Interval_Days_2nd.Text, Request_MasterTable.Pending_Interval_Days_2nd)
                        End If
                        If recControl.Pending_Interval_Days_Auto_Cancel.Text <> "" Then
                            rec.Parse(recControl.Pending_Interval_Days_Auto_Cancel.Text, Request_MasterTable.Pending_Interval_Days_Auto_Cancel)
                        End If
                        If recControl.Pending_Interval_Days_Cancel.Text <> "" Then
                            rec.Parse(recControl.Pending_Interval_Days_Cancel.Text, Request_MasterTable.Pending_Interval_Days_Cancel)
                        End If
                        If recControl.Pending_Nterval_Days_Max.Text <> "" Then
                            rec.Parse(recControl.Pending_Nterval_Days_Max.Text, Request_MasterTable.Pending_Nterval_Days_Max)
                        End If
                        If recControl.Pending_Prev_Action_Needed.Text <> "" Then
                            rec.Parse(recControl.Pending_Prev_Action_Needed.Text, Request_MasterTable.Pending_Prev_Action_Needed)
                        End If
                        If recControl.Pending_Prev_Status.Text <> "" Then
                            rec.Parse(recControl.Pending_Prev_Status.Text, Request_MasterTable.Pending_Prev_Status)
                        End If
                        If recControl.Priority.Text <> "" Then
                            rec.Parse(recControl.Priority.Text, Request_MasterTable.Priority)
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
                        If recControl.Req_Comments.Text <> "" Then
                            rec.Parse(recControl.Req_Comments.Text, Request_MasterTable.Req_Comments)
                        End If
                        If recControl.Req_Completed_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Completed_Dt.Text, Request_MasterTable.Req_Completed_Dt)
                        End If
                        If recControl.Req_Contact_Email.Text <> "" Then
                            rec.Parse(recControl.Req_Contact_Email.Text, Request_MasterTable.Req_Contact_Email2)
                        End If
                        If recControl.Req_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Dt.Text, Request_MasterTable.Req_Dt)
                        End If
                        If recControl.Req_Enity.Text <> "" Then
                            rec.Parse(recControl.Req_Enity.Text, Request_MasterTable.Req_Enity)
                        End If
                        If recControl.Req_Funding_Src.Text <> "" Then
                            rec.Parse(recControl.Req_Funding_Src.Text, Request_MasterTable.Req_Funding_Src)
                        End If
                        If recControl.Req_Funding_Src2.Text <> "" Then
                            rec.Parse(recControl.Req_Funding_Src2.Text, Request_MasterTable.Req_Funding_Src2)
                        End If
                        If recControl.Req_Invoice_Paid.Text <> "" Then
                            rec.Parse(recControl.Req_Invoice_Paid.Text, Request_MasterTable.Req_Invoice_Paid)
                        End If
                        If recControl.Req_Island.Text <> "" Then
                            rec.Parse(recControl.Req_Island.Text, Request_MasterTable.Req_Island)
                        End If
                        If recControl.Req_PO_Amt.Text <> "" Then
                            rec.Parse(recControl.Req_PO_Amt.Text, Request_MasterTable.Req_PO_Amt)
                        End If
                        If recControl.Req_PO_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_PO_Dt.Text, Request_MasterTable.Req_PO_Dt)
                        End If
                        If recControl.Req_PO_No.Text <> "" Then
                            rec.Parse(recControl.Req_PO_No.Text, Request_MasterTable.Req_PO_No)
                        End If
                        If recControl.Req_Pymt_Amt.Text <> "" Then
                            rec.Parse(recControl.Req_Pymt_Amt.Text, Request_MasterTable.Req_Pymt_Amt)
                        End If
                        If recControl.Req_Pymt_Check_No.Text <> "" Then
                            rec.Parse(recControl.Req_Pymt_Check_No.Text, Request_MasterTable.Req_Pymt_Check_No)
                        End If
                        If recControl.Req_Pymt_Dt.Text <> "" Then
                            rec.Parse(recControl.Req_Pymt_Dt.Text, Request_MasterTable.Req_Pymt_Dt)
                        End If
                        If recControl.Req_Quote_Approved.Text <> "" Then
                            rec.Parse(recControl.Req_Quote_Approved.Text, Request_MasterTable.Req_Quote_Approved)
                        End If
                        If recControl.Req_Quote_Respnse.Text <> "" Then
                            rec.Parse(recControl.Req_Quote_Respnse.Text, Request_MasterTable.Req_Quote_Respnse)
                        End If
                        If recControl.Req_Site_Name.Text <> "" Then
                            rec.Parse(recControl.Req_Site_Name.Text, Request_MasterTable.Req_Site_Name)
                        End If
                        If recControl.Req_State.Text <> "" Then
                            rec.Parse(recControl.Req_State.Text, Request_MasterTable.Req_State)
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
        
        Public Overridable Sub SetCat_Cost_FreeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_OTWC_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCommentsRecordControlLabel()
                  
                  End Sub
                
        Public Overridable Sub SetContactsRecordControlLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCounty_UploadLabel()
                  
                  End Sub
                
        Public Overridable Sub SetEnityRecordControlLabel()
                  
                  End Sub
                
        Public Overridable Sub SetICS_CATV_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetICS_SOW_NeededLabel()
                  
                  End Sub
                
        Public Overridable Sub SetICS_SOW_UploadedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetIROC_IdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Completed_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Construction_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Island_completedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_More_Info_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_More_Info_FlagLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_On_NetLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Permit_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_ReqdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Action_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Agency_ReturnLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_AgencyLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Interval_Days_1stLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Interval_Days_2ndLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Interval_Days_Auto_CancelLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Interval_Days_CancelLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Nterval_Days_MaxLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Prev_Action_NeededLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Prev_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPriorityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReg_TypeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_AddressLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_CityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Completed_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Contact_EmailLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Funding_Src2Label()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Funding_SrcLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Invoice_PaidLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_IslandLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_PO_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_PO_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_PO_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_Check_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Quote_ApprovedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Quote_RespnseLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Site_NameLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_StateLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Target_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_ZipLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_EnityFilter()

            
            Dim Req_EnityFilterselectedFilterItemList As New ArrayList()
            Dim Req_EnityFilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_EnityFilter)) Then
                Req_EnityFilteritemsString = Me.GetFromSession(Me.Req_EnityFilter)
            End If
            
            If (Req_EnityFilteritemsString IsNot Nothing) Then
                Dim Req_EnityFilteritemListFromSession() As String = Req_EnityFilteritemsString.Split(","c)
                For Each item as String In Req_EnityFilteritemListFromSession
                    Req_EnityFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateReq_EnityFilter(GetSelectedValueList(Me.Req_EnityFilter, Req_EnityFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetRequest_MasterSearch()

            
              End Sub	
            
        ' Get the filters' data for Req_EnityFilter
        Protected Overridable Sub PopulateReq_EnityFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Req_EnityFilter()
            Me.Req_EnityFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Req_EnityFilter function.
            ' It is better to customize the where clause there.
                
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(Request_MasterTable.Req_Enity, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = Request_MasterTable.GetValues(Request_MasterTable.Req_Enity, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( Request_MasterTable.Req_Enity.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = Request_MasterTable.Req_Enity.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.Req_EnityFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.Req_EnityFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            Me.Req_EnityFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Req_EnityFilter.Items.Count = 0 Then
                Me.Req_EnityFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Req_EnityFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
              

        Public Overridable Function CreateWhereClause_Req_EnityFilter() As WhereClause
          
            ' Create a where clause for the filter Req_EnityFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Req_EnityFilterQuickSelector
            
            Dim Req_EnityFilterselectedFilterItemList As New ArrayList()
            Dim Req_EnityFilteritemsString As String = Nothing
            If (Me.InSession(Me.Req_EnityFilter)) Then
                Req_EnityFilteritemsString = Me.GetFromSession(Me.Req_EnityFilter)
            End If
            
            If (Req_EnityFilteritemsString IsNot Nothing) Then
                Dim Req_EnityFilteritemListFromSession() As String = Req_EnityFilteritemsString.Split(","c)
                For Each item as String In Req_EnityFilteritemListFromSession
                    Req_EnityFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Req_EnityFilterselectedFilterItemList = GetSelectedValueList(Me.Req_EnityFilter, Req_EnityFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Req_EnityFilterselectedFilterItemList Is Nothing OrElse Req_EnityFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Req_EnityFilterselectedFilterItemList
              
            
      
   
                    wc.iOR(Request_MasterTable.Req_Enity, BaseFilter.ComparisonOperator.EqualsTo, item)

                                
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
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
            Dim Req_EnityFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_EnityFilter, Nothing)
            Dim Req_EnityFilterSessionString As String = ""
            If Not Req_EnityFilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_EnityFilterselectedFilterItemList
                Req_EnityFilterSessionstring = Req_EnityFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Req_EnityFilter, Req_EnityFilterSessionstring)
                  
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
          
            Dim Req_EnityFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Req_EnityFilter, Nothing)
            Dim Req_EnityFilterSessionString As String = ""
            If Not Req_EnityFilterselectedFilterItemList is Nothing Then
            For Each item As String In Req_EnityFilterselectedFilterItemList
                Req_EnityFilterSessionstring = Req_EnityFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Req_EnityFilter_Ajax", Req_EnityFilterSessionString)
          
      Me.SaveToSession("Request_MasterSearch_Ajax", Me.Request_MasterSearch.Text)
              
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
            Me.RemoveFromSession(Me.Req_EnityFilter)
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
        
        Public Overridable Sub Cat_Cost_FreeLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Cat_Cost_Free when clicked.
              
            ' Get previous sorting state for Cat_Cost_Free.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Cat_Cost_Free)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Cat_Cost_Free.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Cat_Cost_Free, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Cat_Cost_Free, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Cat_Franchise_Order_NumberLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Cat_Franchise_Order_Number when clicked.
              
            ' Get previous sorting state for Cat_Franchise_Order_Number.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Cat_Franchise_Order_Number)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Cat_Franchise_Order_Number.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Cat_Franchise_Order_Number, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Cat_Franchise_Order_Number, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Cat_OTWC_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Cat_OTWC_Comments when clicked.
              
            ' Get previous sorting state for Cat_OTWC_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Cat_OTWC_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Cat_OTWC_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Cat_OTWC_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Cat_OTWC_Comments, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub County_UploadLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by County_Upload when clicked.
              
            ' Get previous sorting state for County_Upload.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.County_Upload)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for County_Upload.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.County_Upload, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by County_Upload, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub ICS_CATV_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by ICS_CATV_Comments when clicked.
              
            ' Get previous sorting state for ICS_CATV_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.ICS_CATV_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for ICS_CATV_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.ICS_CATV_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by ICS_CATV_Comments, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub ICS_SOW_NeededLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by ICS_SOW_Needed when clicked.
              
            ' Get previous sorting state for ICS_SOW_Needed.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.ICS_SOW_Needed)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for ICS_SOW_Needed.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.ICS_SOW_Needed, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by ICS_SOW_Needed, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub ICS_SOW_UploadedLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by ICS_SOW_Uploaded when clicked.
              
            ' Get previous sorting state for ICS_SOW_Uploaded.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.ICS_SOW_Uploaded)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for ICS_SOW_Uploaded.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.ICS_SOW_Uploaded, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by ICS_SOW_Uploaded, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
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
            
        Public Overridable Sub OTW_Completed_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Completed_Dt when clicked.
              
            ' Get previous sorting state for OTW_Completed_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Completed_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Completed_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Completed_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Completed_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Construction_StatusLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Construction_Status when clicked.
              
            ' Get previous sorting state for OTW_Construction_Status.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Construction_Status)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Construction_Status.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Construction_Status, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Construction_Status, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Deployment_Start_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Deployment_Start_Dt when clicked.
              
            ' Get previous sorting state for OTW_Deployment_Start_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Deployment_Start_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Deployment_Start_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Deployment_Start_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Deployment_Start_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Invoice_AmtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Invoice_Amt when clicked.
              
            ' Get previous sorting state for OTW_Invoice_Amt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Invoice_Amt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Invoice_Amt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Invoice_Amt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Invoice_Amt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Invoice_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Invoice_Dt when clicked.
              
            ' Get previous sorting state for OTW_Invoice_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Invoice_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Invoice_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Invoice_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Invoice_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Invoice_NoLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Invoice_No when clicked.
              
            ' Get previous sorting state for OTW_Invoice_No.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Invoice_No)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Invoice_No.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Invoice_No, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Invoice_No, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Island_completedLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Island completed when clicked.
              
            ' Get previous sorting state for OTW_Island completed.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Island_completed)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Island completed.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Island_completed, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Island completed, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_More_Info_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_More_Info_Comments when clicked.
              
            ' Get previous sorting state for OTW_More_Info_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_More_Info_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_More_Info_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_More_Info_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_More_Info_Comments, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_More_Info_FlagLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_More_Info_Flag when clicked.
              
            ' Get previous sorting state for OTW_More_Info_Flag.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_More_Info_Flag)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_More_Info_Flag.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_More_Info_Flag, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_More_Info_Flag, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_On_NetLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_On-Net when clicked.
              
            ' Get previous sorting state for OTW_On-Net.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_On_Net)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_On-Net.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_On_Net, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_On-Net, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Permit_StatusLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Permit_Status when clicked.
              
            ' Get previous sorting state for OTW_Permit_Status.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Permit_Status)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Permit_Status.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Permit_Status, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Permit_Status, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Premise_Fiber_Work_ReqdLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Premise Fiber Work Reqd when clicked.
              
            ' Get previous sorting state for OTW_Premise Fiber Work Reqd.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Premise Fiber Work Reqd.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Premise Fiber Work Reqd, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Projected_Deploy_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Projected_Deploy_Dt when clicked.
              
            ' Get previous sorting state for OTW_Projected_Deploy_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Projected_Deploy_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Projected_Deploy_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Projected_Deploy_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Projected_Deploy_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_QuoteLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Quote when clicked.
              
            ' Get previous sorting state for OTW_Quote.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Quote)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Quote.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Quote, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Quote, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub OTW_Scheduled_Deploy_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by OTW_Scheduled_Deploy_Dt when clicked.
              
            ' Get previous sorting state for OTW_Scheduled_Deploy_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.OTW_Scheduled_Deploy_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for OTW_Scheduled_Deploy_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.OTW_Scheduled_Deploy_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by OTW_Scheduled_Deploy_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Action_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending Action_Dt when clicked.
              
            ' Get previous sorting state for Pending Action_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Action_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending Action_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Action_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending Action_Dt, so just reverse.
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
            
        Public Overridable Sub Pending_Agency_ReturnLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Agency_Return when clicked.
              
            ' Get previous sorting state for Pending_Agency_Return.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Agency_Return)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Agency_Return.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Agency_Return, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Agency_Return, so just reverse.
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
            
        Public Overridable Sub Pending_Interval_Days_1stLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Interval_Days_1st when clicked.
              
            ' Get previous sorting state for Pending_Interval_Days_1st.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Interval_Days_1st)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Interval_Days_1st.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Interval_Days_1st, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Interval_Days_1st, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Interval_Days_2ndLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Interval_Days_2nd when clicked.
              
            ' Get previous sorting state for Pending_Interval_Days_2nd.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Interval_Days_2nd)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Interval_Days_2nd.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Interval_Days_2nd, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Interval_Days_2nd, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Interval_Days_Auto_CancelLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Interval_Days_Auto_Cancel when clicked.
              
            ' Get previous sorting state for Pending_Interval_Days_Auto_Cancel.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Interval_Days_Auto_Cancel)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Interval_Days_Auto_Cancel.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Interval_Days_Auto_Cancel, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Interval_Days_Auto_Cancel, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Interval_Days_CancelLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Interval_Days_Cancel when clicked.
              
            ' Get previous sorting state for Pending_Interval_Days_Cancel.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Interval_Days_Cancel)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Interval_Days_Cancel.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Interval_Days_Cancel, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Interval_Days_Cancel, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Nterval_Days_MaxLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Nterval_Days_Max when clicked.
              
            ' Get previous sorting state for Pending_Nterval_Days_Max.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Nterval_Days_Max)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Nterval_Days_Max.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Nterval_Days_Max, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Nterval_Days_Max, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Prev_Action_NeededLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Prev_Action_Needed when clicked.
              
            ' Get previous sorting state for Pending_Prev_Action_Needed.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Prev_Action_Needed)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Prev_Action_Needed.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Prev_Action_Needed, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Prev_Action_Needed, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Pending_Prev_StatusLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Pending_Prev_Status when clicked.
              
            ' Get previous sorting state for Pending_Prev_Status.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Pending_Prev_Status)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Pending_Prev_Status.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Pending_Prev_Status, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Pending_Prev_Status, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub PriorityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Priority when clicked.
              
            ' Get previous sorting state for Priority.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Priority)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Priority.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Priority, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Priority, so just reverse.
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
            
        Public Overridable Sub Req_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Comments when clicked.
              
            ' Get previous sorting state for Req_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Comments, so just reverse.
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
            
        Public Overridable Sub Req_Contact_EmailLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Contact_Email when clicked.
              
            ' Get previous sorting state for Req_Contact_Email.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Contact_Email)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Contact_Email.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Contact_Email, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Contact_Email, so just reverse.
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
            ' Sorts by Req_Enity when clicked.
              
            ' Get previous sorting state for Req_Enity.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Enity)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Enity.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Enity, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Enity, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Funding_Src2Label_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Funding_Src2 when clicked.
              
            ' Get previous sorting state for Req_Funding_Src2.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Funding_Src2)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Funding_Src2.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Funding_Src2, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Funding_Src2, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Funding_SrcLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Funding_Src when clicked.
              
            ' Get previous sorting state for Req_Funding_Src.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Funding_Src)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Funding_Src.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Funding_Src, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Funding_Src, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Invoice_PaidLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Invoice_Paid when clicked.
              
            ' Get previous sorting state for Req_Invoice_Paid.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Invoice_Paid)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Invoice_Paid.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Invoice_Paid, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Invoice_Paid, so just reverse.
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
            
        Public Overridable Sub Req_PO_AmtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_PO_Amt when clicked.
              
            ' Get previous sorting state for Req_PO_Amt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_PO_Amt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_PO_Amt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_PO_Amt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_PO_Amt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_PO_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_PO_Dt when clicked.
              
            ' Get previous sorting state for Req_PO_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_PO_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_PO_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_PO_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_PO_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_PO_NoLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_PO_No when clicked.
              
            ' Get previous sorting state for Req_PO_No.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_PO_No)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_PO_No.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_PO_No, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_PO_No, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Pymt_AmtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Pymt_Amt when clicked.
              
            ' Get previous sorting state for Req_Pymt_Amt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Pymt_Amt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Pymt_Amt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Pymt_Amt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Pymt_Amt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Pymt_Check_NoLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Pymt_Check_No when clicked.
              
            ' Get previous sorting state for Req_Pymt_Check_No.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Pymt_Check_No)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Pymt_Check_No.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Pymt_Check_No, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Pymt_Check_No, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Pymt_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Pymt_Dt when clicked.
              
            ' Get previous sorting state for Req_Pymt_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Pymt_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Pymt_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Pymt_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Pymt_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Quote_ApprovedLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Quote_Approved when clicked.
              
            ' Get previous sorting state for Req_Quote_Approved.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Quote_Approved)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Quote_Approved.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Quote_Approved, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Quote_Approved, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Req_Quote_RespnseLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_Quote_Respnse when clicked.
              
            ' Get previous sorting state for Req_Quote_Respnse.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_Quote_Respnse)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_Quote_Respnse.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_Quote_Respnse, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_Quote_Respnse, so just reverse.
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
            
        Public Overridable Sub Req_StateLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Req_State when clicked.
              
            ' Get previous sorting state for Req_State.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(Request_MasterTable.Req_State)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Req_State.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(Request_MasterTable.Req_State, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Req_State, so just reverse.
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
             Request_MasterTable.Priority, _ 
             Request_MasterTable.Req_Site_Name, _ 
             Request_MasterTable.Req_Address, _ 
             Request_MasterTable.Req_City, _ 
             Request_MasterTable.Req_Island, _ 
             Request_MasterTable.Req_State, _ 
             Request_MasterTable.Req_Zip, _ 
             Request_MasterTable.Req_Dt, _ 
             Request_MasterTable.Req_Target_Dt, _ 
             Request_MasterTable.Req_Completed_Dt, _ 
             Request_MasterTable.Req_Status, _ 
             Request_MasterTable.Req_Funding_Src, _ 
             Request_MasterTable.Req_Enity, _ 
             Request_MasterTable.Req_Comments, _ 
             Request_MasterTable.Req_Quote_Respnse, _ 
             Request_MasterTable.Req_Quote_Approved, _ 
             Request_MasterTable.ICS_SOW_Needed, _ 
             Request_MasterTable.ICS_SOW_Uploaded, _ 
             Request_MasterTable.ICS_CATV_Comments, _ 
             Request_MasterTable.Cat_Cost_Free, _ 
             Request_MasterTable.Cat_Franchise_Order_Number, _ 
             Request_MasterTable.County_Upload, _ 
             Request_MasterTable.Cat_OTWC_Comments, _ 
             Request_MasterTable.OTW_Quote, _ 
             Request_MasterTable.OTW_More_Info_Flag, _ 
             Request_MasterTable.OTW_More_Info_Comments, _ 
             Request_MasterTable.OTW_Permit_Status, _ 
             Request_MasterTable.OTW_Premise_Fiber_Work_Reqd, _ 
             Request_MasterTable.OTW_On_Net, _ 
             Request_MasterTable.OTW_Scheduled_Deploy_Dt, _ 
             Request_MasterTable.OTW_Projected_Deploy_Dt, _ 
             Request_MasterTable.OTW_Deployment_Start_Dt, _ 
             Request_MasterTable.OTW_Construction_Status, _ 
             Request_MasterTable.OTW_Island_completed, _ 
             Request_MasterTable.OTW_Completed_Dt, _ 
             Request_MasterTable.Pending_Agency, _ 
             Request_MasterTable.Pending_Action_Dt, _ 
             Request_MasterTable.Pending_Action_Needed, _ 
             Request_MasterTable.Pending_Interval_Days_1st, _ 
             Request_MasterTable.Pending_Interval_Days_2nd, _ 
             Request_MasterTable.Pending_Nterval_Days_Max, _ 
             Request_MasterTable.Pending_Interval_Days_Cancel, _ 
             Request_MasterTable.Pending_Interval_Days_Auto_Cancel, _ 
             Request_MasterTable.Req_PO_No, _ 
             Request_MasterTable.Req_PO_Dt, _ 
             Request_MasterTable.Req_PO_Amt, _ 
             Request_MasterTable.Req_Invoice_Paid, _ 
             Request_MasterTable.Req_Pymt_Check_No, _ 
             Request_MasterTable.Req_Pymt_Dt, _ 
             Request_MasterTable.Req_Pymt_Amt, _ 
             Request_MasterTable.OTW_Invoice_No, _ 
             Request_MasterTable.OTW_Invoice_Dt, _ 
             Request_MasterTable.OTW_Invoice_Amt, _ 
             Request_MasterTable.Reg_Type, _ 
             Request_MasterTable.Req_Funding_Src2, _ 
             Request_MasterTable.Pending_Agency_Return, _ 
             Request_MasterTable.Pending_Prev_Action_Needed, _ 
             Request_MasterTable.Pending_Prev_Status, _ 
             Request_MasterTable.Req_Contact_Email2, _ 
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
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Priority, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Site_Name, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Address, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_City, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Island, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_State, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Zip, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Target_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Completed_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Status, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Funding_Src, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Enity, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Comments, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Quote_Respnse, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Quote_Approved, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.ICS_SOW_Needed, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.ICS_SOW_Uploaded, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.ICS_CATV_Comments, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Cat_Cost_Free, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Cat_Franchise_Order_Number, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.County_Upload, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Cat_OTWC_Comments, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Quote, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_More_Info_Flag, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_More_Info_Comments, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Permit_Status, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_On_Net, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Projected_Deploy_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Deployment_Start_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Construction_Status, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Island_completed, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Completed_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Agency, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Action_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Action_Needed, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Interval_Days_1st, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Interval_Days_2nd, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Nterval_Days_Max, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Interval_Days_Cancel, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Interval_Days_Auto_Cancel, "0"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_PO_No, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_PO_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_PO_Amt, "Currency"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Invoice_Paid, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Pymt_Check_No, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Pymt_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Pymt_Amt, "Currency"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Invoice_No, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Invoice_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.OTW_Invoice_Amt, "Currency"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Reg_Type, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Funding_Src2, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Agency_Return, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Prev_Action_Needed, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Pending_Prev_Status, "Default"))
             data.ColumnList.Add(New ExcelColumn(Request_MasterTable.Req_Contact_Email2, "Default"))


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
        Public Overridable Sub Request_MasterImportButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
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
                report.SpecificReportFileName = Page.Server.MapPath("Show-Request-Master-Table.Request_MasterPDFButton.report")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Request_Master"
                ' If Show-Request-Master-Table.Request_MasterPDFButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.   
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column   			
                 report.AddColumn(Request_MasterTable.IROC_Id.Name, ReportEnum.Align.Left, "${IROC_Id}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Priority.Name, ReportEnum.Align.Right, "${Priority}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Req_Site_Name.Name, ReportEnum.Align.Left, "${Req_Site_Name}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Address.Name, ReportEnum.Align.Left, "${Req_Address}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_City.Name, ReportEnum.Align.Left, "${Req_City}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Island.Name, ReportEnum.Align.Left, "${Req_Island}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_State.Name, ReportEnum.Align.Left, "${Req_State}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Zip.Name, ReportEnum.Align.Left, "${Req_Zip}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Dt.Name, ReportEnum.Align.Left, "${Req_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Target_Dt.Name, ReportEnum.Align.Left, "${Req_Target_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Completed_Dt.Name, ReportEnum.Align.Left, "${Req_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Status.Name, ReportEnum.Align.Left, "${Req_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Funding_Src.Name, ReportEnum.Align.Left, "${Req_Funding_Src}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Enity.Name, ReportEnum.Align.Left, "${Req_Enity}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Comments.Name, ReportEnum.Align.Left, "${Req_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Quote_Respnse.Name, ReportEnum.Align.Left, "${Req_Quote_Respnse}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Quote_Approved.Name, ReportEnum.Align.Left, "${Req_Quote_Approved}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.ICS_SOW_Needed.Name, ReportEnum.Align.Left, "${ICS_SOW_Needed}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.ICS_SOW_Uploaded.Name, ReportEnum.Align.Left, "${ICS_SOW_Uploaded}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.ICS_CATV_Comments.Name, ReportEnum.Align.Left, "${ICS_CATV_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Cat_Cost_Free.Name, ReportEnum.Align.Left, "${Cat_Cost_Free}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Cat_Franchise_Order_Number.Name, ReportEnum.Align.Left, "${Cat_Franchise_Order_Number}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.County_Upload.Name, ReportEnum.Align.Left, "${County_Upload}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Cat_OTWC_Comments.Name, ReportEnum.Align.Left, "${Cat_OTWC_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.OTW_Quote.Name, ReportEnum.Align.Right, "${OTW_Quote}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.OTW_More_Info_Flag.Name, ReportEnum.Align.Left, "${OTW_More_Info_Flag}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_More_Info_Comments.Name, ReportEnum.Align.Left, "${OTW_More_Info_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.OTW_Permit_Status.Name, ReportEnum.Align.Left, "${OTW_Permit_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.Name, ReportEnum.Align.Left, "${OTW_Premise_Fiber_Work_Reqd}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_On_Net.Name, ReportEnum.Align.Left, "${OTW_On_Net}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Scheduled_Deploy_Dt.Name, ReportEnum.Align.Left, "${OTW_Scheduled_Deploy_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Projected_Deploy_Dt.Name, ReportEnum.Align.Left, "${OTW_Projected_Deploy_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Deployment_Start_Dt.Name, ReportEnum.Align.Left, "${OTW_Deployment_Start_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Construction_Status.Name, ReportEnum.Align.Left, "${OTW_Construction_Status}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Island_completed.Name, ReportEnum.Align.Left, "${OTW_Island_completed}", ReportEnum.Align.Left, 24)
                 report.AddColumn(Request_MasterTable.OTW_Completed_Dt.Name, ReportEnum.Align.Left, "${OTW_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Agency.Name, ReportEnum.Align.Left, "${Pending_Agency}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Action_Dt.Name, ReportEnum.Align.Left, "${Pending_Action_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_1st.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_1st}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_2nd.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_2nd}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Nterval_Days_Max.Name, ReportEnum.Align.Right, "${Pending_Nterval_Days_Max}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_Cancel.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_Cancel}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_Auto_Cancel.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_Auto_Cancel}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Req_PO_No.Name, ReportEnum.Align.Left, "${Req_PO_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_PO_Dt.Name, ReportEnum.Align.Left, "${Req_PO_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_PO_Amt.Name, ReportEnum.Align.Right, "${Req_PO_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.Req_Invoice_Paid.Name, ReportEnum.Align.Left, "${Req_Invoice_Paid}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Check_No.Name, ReportEnum.Align.Left, "${Req_Pymt_Check_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Dt.Name, ReportEnum.Align.Left, "${Req_Pymt_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Amt.Name, ReportEnum.Align.Right, "${Req_Pymt_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_No.Name, ReportEnum.Align.Left, "${OTW_Invoice_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_Dt.Name, ReportEnum.Align.Left, "${OTW_Invoice_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_Amt.Name, ReportEnum.Align.Right, "${OTW_Invoice_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.Reg_Type.Name, ReportEnum.Align.Left, "${Reg_Type}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Funding_Src2.Name, ReportEnum.Align.Left, "${Req_Funding_Src2}", ReportEnum.Align.Left, 24)
                 report.AddColumn(Request_MasterTable.Pending_Agency_Return.Name, ReportEnum.Align.Left, "${Pending_Agency_Return}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Prev_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Prev_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Prev_Status.Name, ReportEnum.Align.Left, "${Pending_Prev_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Contact_Email2.Name, ReportEnum.Align.Left, "${Req_Contact_Email2}", ReportEnum.Align.Left, 30)

          
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
                                                         report.AddData("${IROC_Id}", record.Format(Request_MasterTable.IROC_Id), ReportEnum.Align.Left, 300)
                             report.AddData("${Priority}", record.Format(Request_MasterTable.Priority), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_Site_Name}", record.Format(Request_MasterTable.Req_Site_Name), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Address}", record.Format(Request_MasterTable.Req_Address), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_City}", record.Format(Request_MasterTable.Req_City), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Island}", record.Format(Request_MasterTable.Req_Island), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_State}", record.Format(Request_MasterTable.Req_State), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Zip}", record.Format(Request_MasterTable.Req_Zip), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Dt}", record.Format(Request_MasterTable.Req_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Target_Dt}", record.Format(Request_MasterTable.Req_Target_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Completed_Dt}", record.Format(Request_MasterTable.Req_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Status}", record.Format(Request_MasterTable.Req_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Funding_Src}", record.Format(Request_MasterTable.Req_Funding_Src), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Enity}", record.Format(Request_MasterTable.Req_Enity), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Comments}", record.Format(Request_MasterTable.Req_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Quote_Respnse}", record.Format(Request_MasterTable.Req_Quote_Respnse), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Quote_Approved}", record.Format(Request_MasterTable.Req_Quote_Approved), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_SOW_Needed}", record.Format(Request_MasterTable.ICS_SOW_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_SOW_Uploaded}", record.Format(Request_MasterTable.ICS_SOW_Uploaded), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_CATV_Comments}", record.Format(Request_MasterTable.ICS_CATV_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_Cost_Free}", record.Format(Request_MasterTable.Cat_Cost_Free), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_Franchise_Order_Number}", record.Format(Request_MasterTable.Cat_Franchise_Order_Number), ReportEnum.Align.Left, 300)
                             report.AddData("${County_Upload}", record.Format(Request_MasterTable.County_Upload), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_OTWC_Comments}", record.Format(Request_MasterTable.Cat_OTWC_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Quote}", record.Format(Request_MasterTable.OTW_Quote), ReportEnum.Align.Right, 300)
                             report.AddData("${OTW_More_Info_Flag}", record.Format(Request_MasterTable.OTW_More_Info_Flag), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_More_Info_Comments}", record.Format(Request_MasterTable.OTW_More_Info_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Permit_Status}", record.Format(Request_MasterTable.OTW_Permit_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Premise_Fiber_Work_Reqd}", record.Format(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_On_Net}", record.Format(Request_MasterTable.OTW_On_Net), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Scheduled_Deploy_Dt}", record.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Projected_Deploy_Dt}", record.Format(Request_MasterTable.OTW_Projected_Deploy_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Deployment_Start_Dt}", record.Format(Request_MasterTable.OTW_Deployment_Start_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Construction_Status}", record.Format(Request_MasterTable.OTW_Construction_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Island_completed}", record.Format(Request_MasterTable.OTW_Island_completed), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Completed_Dt}", record.Format(Request_MasterTable.OTW_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Agency}", record.Format(Request_MasterTable.Pending_Agency), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Action_Dt}", record.Format(Request_MasterTable.Pending_Action_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Action_Needed}", record.Format(Request_MasterTable.Pending_Action_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Interval_Days_1st}", record.Format(Request_MasterTable.Pending_Interval_Days_1st), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_2nd}", record.Format(Request_MasterTable.Pending_Interval_Days_2nd), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Nterval_Days_Max}", record.Format(Request_MasterTable.Pending_Nterval_Days_Max), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_Cancel}", record.Format(Request_MasterTable.Pending_Interval_Days_Cancel), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_Auto_Cancel}", record.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_PO_No}", record.Format(Request_MasterTable.Req_PO_No), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_PO_Dt}", record.Format(Request_MasterTable.Req_PO_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_PO_Amt}", record.Format(Request_MasterTable.Req_PO_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_Invoice_Paid}", record.Format(Request_MasterTable.Req_Invoice_Paid), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Check_No}", record.Format(Request_MasterTable.Req_Pymt_Check_No), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Dt}", record.Format(Request_MasterTable.Req_Pymt_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Amt}", record.Format(Request_MasterTable.Req_Pymt_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${OTW_Invoice_No}", record.Format(Request_MasterTable.OTW_Invoice_No), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Invoice_Dt}", record.Format(Request_MasterTable.OTW_Invoice_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Invoice_Amt}", record.Format(Request_MasterTable.OTW_Invoice_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${Reg_Type}", record.Format(Request_MasterTable.Reg_Type), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Funding_Src2}", record.Format(Request_MasterTable.Req_Funding_Src2), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Agency_Return}", record.Format(Request_MasterTable.Pending_Agency_Return), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Prev_Action_Needed}", record.Format(Request_MasterTable.Pending_Prev_Action_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Prev_Status}", record.Format(Request_MasterTable.Pending_Prev_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Contact_Email2}", record.Format(Request_MasterTable.Req_Contact_Email2), ReportEnum.Align.Left, 300)

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
    
              Me.Req_EnityFilter.ClearSelection()
              Me.Request_MasterSearch.Text = ""
              Me.CurrentSortOrder.Reset()
              If Me.InSession(Me, "Order_By") Then
                  Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
              Else
                  Me.CurrentSortOrder = New OrderBy(True, False)
                  

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
                report.SpecificReportFileName = Page.Server.MapPath("Show-Request-Master-Table.Request_MasterWordButton.word")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Request_Master"
                ' If Show-Request-Master-Table.Request_MasterWordButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column
                 report.AddColumn(Request_MasterTable.IROC_Id.Name, ReportEnum.Align.Left, "${IROC_Id}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Priority.Name, ReportEnum.Align.Right, "${Priority}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Req_Site_Name.Name, ReportEnum.Align.Left, "${Req_Site_Name}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Address.Name, ReportEnum.Align.Left, "${Req_Address}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_City.Name, ReportEnum.Align.Left, "${Req_City}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Island.Name, ReportEnum.Align.Left, "${Req_Island}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_State.Name, ReportEnum.Align.Left, "${Req_State}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Zip.Name, ReportEnum.Align.Left, "${Req_Zip}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Dt.Name, ReportEnum.Align.Left, "${Req_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Target_Dt.Name, ReportEnum.Align.Left, "${Req_Target_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Completed_Dt.Name, ReportEnum.Align.Left, "${Req_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Status.Name, ReportEnum.Align.Left, "${Req_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Funding_Src.Name, ReportEnum.Align.Left, "${Req_Funding_Src}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Enity.Name, ReportEnum.Align.Left, "${Req_Enity}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Comments.Name, ReportEnum.Align.Left, "${Req_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Quote_Respnse.Name, ReportEnum.Align.Left, "${Req_Quote_Respnse}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Req_Quote_Approved.Name, ReportEnum.Align.Left, "${Req_Quote_Approved}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.ICS_SOW_Needed.Name, ReportEnum.Align.Left, "${ICS_SOW_Needed}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.ICS_SOW_Uploaded.Name, ReportEnum.Align.Left, "${ICS_SOW_Uploaded}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.ICS_CATV_Comments.Name, ReportEnum.Align.Left, "${ICS_CATV_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.Cat_Cost_Free.Name, ReportEnum.Align.Left, "${Cat_Cost_Free}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Cat_Franchise_Order_Number.Name, ReportEnum.Align.Left, "${Cat_Franchise_Order_Number}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.County_Upload.Name, ReportEnum.Align.Left, "${County_Upload}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Cat_OTWC_Comments.Name, ReportEnum.Align.Left, "${Cat_OTWC_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.OTW_Quote.Name, ReportEnum.Align.Right, "${OTW_Quote}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.OTW_More_Info_Flag.Name, ReportEnum.Align.Left, "${OTW_More_Info_Flag}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_More_Info_Comments.Name, ReportEnum.Align.Left, "${OTW_More_Info_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(Request_MasterTable.OTW_Permit_Status.Name, ReportEnum.Align.Left, "${OTW_Permit_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.Name, ReportEnum.Align.Left, "${OTW_Premise_Fiber_Work_Reqd}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_On_Net.Name, ReportEnum.Align.Left, "${OTW_On_Net}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Scheduled_Deploy_Dt.Name, ReportEnum.Align.Left, "${OTW_Scheduled_Deploy_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Projected_Deploy_Dt.Name, ReportEnum.Align.Left, "${OTW_Projected_Deploy_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Deployment_Start_Dt.Name, ReportEnum.Align.Left, "${OTW_Deployment_Start_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Construction_Status.Name, ReportEnum.Align.Left, "${OTW_Construction_Status}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Island_completed.Name, ReportEnum.Align.Left, "${OTW_Island_completed}", ReportEnum.Align.Left, 24)
                 report.AddColumn(Request_MasterTable.OTW_Completed_Dt.Name, ReportEnum.Align.Left, "${OTW_Completed_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Agency.Name, ReportEnum.Align.Left, "${Pending_Agency}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Action_Dt.Name, ReportEnum.Align.Left, "${Pending_Action_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_1st.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_1st}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_2nd.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_2nd}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Nterval_Days_Max.Name, ReportEnum.Align.Right, "${Pending_Nterval_Days_Max}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_Cancel.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_Cancel}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Pending_Interval_Days_Auto_Cancel.Name, ReportEnum.Align.Right, "${Pending_Interval_Days_Auto_Cancel}", ReportEnum.Align.Right, 15)
                 report.AddColumn(Request_MasterTable.Req_PO_No.Name, ReportEnum.Align.Left, "${Req_PO_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_PO_Dt.Name, ReportEnum.Align.Left, "${Req_PO_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_PO_Amt.Name, ReportEnum.Align.Right, "${Req_PO_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.Req_Invoice_Paid.Name, ReportEnum.Align.Left, "${Req_Invoice_Paid}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Check_No.Name, ReportEnum.Align.Left, "${Req_Pymt_Check_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Dt.Name, ReportEnum.Align.Left, "${Req_Pymt_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Req_Pymt_Amt.Name, ReportEnum.Align.Right, "${Req_Pymt_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_No.Name, ReportEnum.Align.Left, "${OTW_Invoice_No}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_Dt.Name, ReportEnum.Align.Left, "${OTW_Invoice_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.OTW_Invoice_Amt.Name, ReportEnum.Align.Right, "${OTW_Invoice_Amt}", ReportEnum.Align.Right, 20)
                 report.AddColumn(Request_MasterTable.Reg_Type.Name, ReportEnum.Align.Left, "${Reg_Type}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Funding_Src2.Name, ReportEnum.Align.Left, "${Req_Funding_Src2}", ReportEnum.Align.Left, 24)
                 report.AddColumn(Request_MasterTable.Pending_Agency_Return.Name, ReportEnum.Align.Left, "${Pending_Agency_Return}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Pending_Prev_Action_Needed.Name, ReportEnum.Align.Left, "${Pending_Prev_Action_Needed}", ReportEnum.Align.Left, 20)
                 report.AddColumn(Request_MasterTable.Pending_Prev_Status.Name, ReportEnum.Align.Left, "${Pending_Prev_Status}", ReportEnum.Align.Left, 15)
                 report.AddColumn(Request_MasterTable.Req_Contact_Email2.Name, ReportEnum.Align.Left, "${Req_Contact_Email2}", ReportEnum.Align.Left, 30)

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
                             report.AddData("${IROC_Id}", record.Format(Request_MasterTable.IROC_Id), ReportEnum.Align.Left, 300)
                             report.AddData("${Priority}", record.Format(Request_MasterTable.Priority), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_Site_Name}", record.Format(Request_MasterTable.Req_Site_Name), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Address}", record.Format(Request_MasterTable.Req_Address), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_City}", record.Format(Request_MasterTable.Req_City), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Island}", record.Format(Request_MasterTable.Req_Island), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_State}", record.Format(Request_MasterTable.Req_State), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Zip}", record.Format(Request_MasterTable.Req_Zip), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Dt}", record.Format(Request_MasterTable.Req_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Target_Dt}", record.Format(Request_MasterTable.Req_Target_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Completed_Dt}", record.Format(Request_MasterTable.Req_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Status}", record.Format(Request_MasterTable.Req_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Funding_Src}", record.Format(Request_MasterTable.Req_Funding_Src), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Enity}", record.Format(Request_MasterTable.Req_Enity), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Comments}", record.Format(Request_MasterTable.Req_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Quote_Respnse}", record.Format(Request_MasterTable.Req_Quote_Respnse), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Quote_Approved}", record.Format(Request_MasterTable.Req_Quote_Approved), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_SOW_Needed}", record.Format(Request_MasterTable.ICS_SOW_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_SOW_Uploaded}", record.Format(Request_MasterTable.ICS_SOW_Uploaded), ReportEnum.Align.Left, 300)
                             report.AddData("${ICS_CATV_Comments}", record.Format(Request_MasterTable.ICS_CATV_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_Cost_Free}", record.Format(Request_MasterTable.Cat_Cost_Free), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_Franchise_Order_Number}", record.Format(Request_MasterTable.Cat_Franchise_Order_Number), ReportEnum.Align.Left, 300)
                             report.AddData("${County_Upload}", record.Format(Request_MasterTable.County_Upload), ReportEnum.Align.Left, 300)
                             report.AddData("${Cat_OTWC_Comments}", record.Format(Request_MasterTable.Cat_OTWC_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Quote}", record.Format(Request_MasterTable.OTW_Quote), ReportEnum.Align.Right, 300)
                             report.AddData("${OTW_More_Info_Flag}", record.Format(Request_MasterTable.OTW_More_Info_Flag), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_More_Info_Comments}", record.Format(Request_MasterTable.OTW_More_Info_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Permit_Status}", record.Format(Request_MasterTable.OTW_Permit_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Premise_Fiber_Work_Reqd}", record.Format(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_On_Net}", record.Format(Request_MasterTable.OTW_On_Net), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Scheduled_Deploy_Dt}", record.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Projected_Deploy_Dt}", record.Format(Request_MasterTable.OTW_Projected_Deploy_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Deployment_Start_Dt}", record.Format(Request_MasterTable.OTW_Deployment_Start_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Construction_Status}", record.Format(Request_MasterTable.OTW_Construction_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Island_completed}", record.Format(Request_MasterTable.OTW_Island_completed), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Completed_Dt}", record.Format(Request_MasterTable.OTW_Completed_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Agency}", record.Format(Request_MasterTable.Pending_Agency), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Action_Dt}", record.Format(Request_MasterTable.Pending_Action_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Action_Needed}", record.Format(Request_MasterTable.Pending_Action_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Interval_Days_1st}", record.Format(Request_MasterTable.Pending_Interval_Days_1st), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_2nd}", record.Format(Request_MasterTable.Pending_Interval_Days_2nd), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Nterval_Days_Max}", record.Format(Request_MasterTable.Pending_Nterval_Days_Max), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_Cancel}", record.Format(Request_MasterTable.Pending_Interval_Days_Cancel), ReportEnum.Align.Right, 300)
                             report.AddData("${Pending_Interval_Days_Auto_Cancel}", record.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_PO_No}", record.Format(Request_MasterTable.Req_PO_No), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_PO_Dt}", record.Format(Request_MasterTable.Req_PO_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_PO_Amt}", record.Format(Request_MasterTable.Req_PO_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${Req_Invoice_Paid}", record.Format(Request_MasterTable.Req_Invoice_Paid), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Check_No}", record.Format(Request_MasterTable.Req_Pymt_Check_No), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Dt}", record.Format(Request_MasterTable.Req_Pymt_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Pymt_Amt}", record.Format(Request_MasterTable.Req_Pymt_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${OTW_Invoice_No}", record.Format(Request_MasterTable.OTW_Invoice_No), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Invoice_Dt}", record.Format(Request_MasterTable.OTW_Invoice_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${OTW_Invoice_Amt}", record.Format(Request_MasterTable.OTW_Invoice_Amt), ReportEnum.Align.Right, 300)
                             report.AddData("${Reg_Type}", record.Format(Request_MasterTable.Reg_Type), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Funding_Src2}", record.Format(Request_MasterTable.Req_Funding_Src2), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Agency_Return}", record.Format(Request_MasterTable.Pending_Agency_Return), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Prev_Action_Needed}", record.Format(Request_MasterTable.Pending_Prev_Action_Needed), ReportEnum.Align.Left, 300)
                             report.AddData("${Pending_Prev_Status}", record.Format(Request_MasterTable.Pending_Prev_Status), ReportEnum.Align.Left, 300)
                             report.AddData("${Req_Contact_Email2}", record.Format(Request_MasterTable.Req_Contact_Email2), ReportEnum.Align.Left, 300)

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
        Protected Overridable Sub Req_EnityFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
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
        
        Public ReadOnly Property Cat_Cost_FreeLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_FreeLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Franchise_Order_NumberLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_NumberLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Cat_OTWC_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsRecordControlLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsRecordControlLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ContactsRecordControlLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRecordControlLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property County_UploadLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_UploadLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property EnityRecordControlLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "EnityRecordControlLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_CATV_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_NeededLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_NeededLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_UploadedLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_UploadedLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property IROC_IdLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Completed_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Construction_StatusLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_StatusLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Deployment_Start_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_AmtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_AmtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_NoLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_NoLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Island_completedLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completedLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_More_Info_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_More_Info_FlagLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_FlagLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_On_NetLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_NetLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Permit_StatusLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_StatusLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_ReqdLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Projected_Deploy_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_QuoteLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Scheduled_Deploy_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_NeededLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency_ReturnLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_ReturnLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_1stLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_1stLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_2ndLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_2ndLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_Auto_CancelLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Auto_CancelLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_CancelLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_CancelLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Nterval_Days_MaxLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Nterval_Days_MaxLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_Action_NeededLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_NeededLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_StatusLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_StatusLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property PriorityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "PriorityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Reg_TypeLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel"), System.Web.UI.WebControls.LinkButton)
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
        
        Public ReadOnly Property Req_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Completed_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Contact_EmailLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_EmailLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_EnityFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Req_EnityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_EnityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_Src2Label() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src2Label"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_SrcLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_SrcLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Invoice_PaidLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Invoice_PaidLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_IslandLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_AmtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_AmtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_NoLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_NoLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_AmtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_AmtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Check_NoLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_NoLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Quote_ApprovedLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_ApprovedLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Quote_RespnseLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_RespnseLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_Site_NameLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_NameLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_StateLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StateLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Req_StatusLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel"), System.Web.UI.WebControls.LinkButton)
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
        
        Public ReadOnly Property Request_MasterImportButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterImportButton"), System.Web.UI.WebControls.ImageButton)
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

  
' Base class for the CommentsRecordControl control on the Show_Request_Master_Table page.
' Do not modify this class. Instead override any method in CommentsRecordControl.
Public Class BaseCommentsRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in CommentsRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in CommentsRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Comments record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "CommentsRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New CommentsRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As CommentsRecord = CommentsTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = CommentsTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in CommentsRecordControl.
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

      
        
        ' To customize, override this method in CommentsRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "CommentsRecordControlPanel"), System.Web.UI.WebControls.Panel)

          If ((Not IsNothing(Panel)) AndAlso (Not Panel.Visible)) OrElse IsNothing(Me.DataSource) Then
              Return
          End If
          
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
              
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in CommentsRecordControl.
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
                
      
        ' To customize, override this method in CommentsRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            CommentsTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
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
              
      HttpContext.Current.Session("CommentsRecordControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            CommentsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("CommentsRecordControlWhereClause"), String)
            
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
        
    

        ' To customize, override this method in CommentsRecordControl.
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
        
        
        ' Generate the event handling functions for pagination events.
            
      
        ' Generate the event handling functions for filter and search events.
            
   
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
                Return CType(Me.ViewState("BaseCommentsRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseCommentsRecordControl_Rec") = value
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

  
' Base class for the ContactsRecordControl control on the Show_Request_Master_Table page.
' Do not modify this class. Instead override any method in ContactsRecordControl.
Public Class BaseContactsRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in ContactsRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in ContactsRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Contacts record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "ContactsRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New ContactsRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As ContactsRecord = ContactsTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = ContactsTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in ContactsRecordControl.
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
                SetComments()
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
                
        Public Overridable Sub SetComments()
            
        
            ' Set the Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CommentsSpecified Then
                				
                ' If the Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Comments.Text = formattedValue
                
            Else 
            
                ' Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comments.Text = ContactsTable.Comments.Format(ContactsTable.Comments.DefaultValue)
                        		
                End If
                 
            ' If the Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Comments.Text Is Nothing _
                OrElse Me.Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Comments.Text = "&nbsp;"
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

      
        
        ' To customize, override this method in ContactsRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "ContactsRecordControlPanel"), System.Web.UI.WebControls.Panel)

          If ((Not IsNothing(Panel)) AndAlso (Not Panel.Visible)) OrElse IsNothing(Me.DataSource) Then
              Return
          End If
          
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
              
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in ContactsRecordControl.
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
            GetComments()
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
                
        Public Overridable Sub GetComments()
            
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
                
      
        ' To customize, override this method in ContactsRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            ContactsTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
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
              
      HttpContext.Current.Session("ContactsRecordControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            ContactsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("ContactsRecordControlWhereClause"), String)
            
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
        
    

        ' To customize, override this method in ContactsRecordControl.
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
        
        
        ' Generate the event handling functions for pagination events.
            
      
        ' Generate the event handling functions for filter and search events.
            
   
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
                Return CType(Me.ViewState("BaseContactsRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseContactsRecordControl_Rec") = value
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
            
        Public ReadOnly Property Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comments"), System.Web.UI.WebControls.Literal)
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

  
' Base class for the EnityRecordControl control on the Show_Request_Master_Table page.
' Do not modify this class. Instead override any method in EnityRecordControl.
Public Class BaseEnityRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in EnityRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in EnityRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Enity record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "EnityRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New EnityRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As EnityRecord = EnityTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = EnityTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in EnityRecordControl.
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
        
                SetDeptAgencyNames()
                SetEnity_Codes()
      
      
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
        
        
        Public Overridable Sub SetDeptAgencyNames()
            
        
            ' Set the DeptAgencyNames Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Enity database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Enity record retrieved from the database.
            ' Me.DeptAgencyNames is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetDeptAgencyNames()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.DeptAgencyNamesSpecified Then
                				
                ' If the DeptAgencyNames is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(EnityTable.DeptAgencyNames)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.DeptAgencyNames.Text = formattedValue
                
            Else 
            
                ' DeptAgencyNames is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.DeptAgencyNames.Text = EnityTable.DeptAgencyNames.Format(EnityTable.DeptAgencyNames.DefaultValue)
                        		
                End If
                 
            ' If the DeptAgencyNames is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.DeptAgencyNames.Text Is Nothing _
                OrElse Me.DeptAgencyNames.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.DeptAgencyNames.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetEnity_Codes()
            
        
            ' Set the Enity_Codes Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Enity database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Enity record retrieved from the database.
            ' Me.Enity_Codes is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetEnity_Codes()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Enity_CodesSpecified Then
                				
                ' If the Enity_Codes is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(EnityTable.Enity_Codes)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Enity_Codes.Text = formattedValue
                
            Else 
            
                ' Enity_Codes is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Enity_Codes.Text = EnityTable.Enity_Codes.Format(EnityTable.Enity_Codes.DefaultValue)
                        		
                End If
                 
            ' If the Enity_Codes is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Enity_Codes.Text Is Nothing _
                OrElse Me.Enity_Codes.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Enity_Codes.Text = "&nbsp;"
            End If
                  
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

      
        
        ' To customize, override this method in EnityRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "EnityRecordControlPanel"), System.Web.UI.WebControls.Panel)

          If ((Not IsNothing(Panel)) AndAlso (Not Panel.Visible)) OrElse IsNothing(Me.DataSource) Then
              Return
          End If
          
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
            
            Me.DataSource.Enity_Codes = parentCtrl.DataSource.Req_Enity2
              
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
          
        End Sub

        ' To customize, override this method in EnityRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetDeptAgencyNames()
            GetEnity_Codes()
        End Sub
        
        
        Public Overridable Sub GetDeptAgencyNames()
            
        End Sub
                
        Public Overridable Sub GetEnity_Codes()
            
        End Sub
                
      
        ' To customize, override this method in EnityRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            EnityTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
        Dim request_MasterRecordObj as KeyValue
        request_MasterRecordObj = Nothing
      
              Dim request_MasterTableControlObjRow As Request_MasterTableControlRow = DirectCast(MiscUtils.GetParentControlObject(Me, "Request_MasterTableControlRow") ,Request_MasterTableControlRow)
            
                If (Not IsNothing(request_MasterTableControlObjRow) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord()) AndAlso Not IsNothing(request_MasterTableControlObjRow.GetRecord().Req_Enity2))
                    wc.iAND(EnityTable.Enity_Codes, BaseFilter.ComparisonOperator.EqualsTo, request_MasterTableControlObjRow.GetRecord().Req_Enity2.ToString())
                Else
                    wc.RunQuery = False
                    Return wc                    
                End If
              
      HttpContext.Current.Session("EnityRecordControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            EnityTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            
            Dim selectedRecordInRequest_MasterTableControl as String = DirectCast(HttpContext.Current.Session("EnityRecordControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterTableControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterTableControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterTableControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(EnityTable.Enity_Codes) Then
            wc.iAND(EnityTable.Enity_Codes, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(EnityTable.Enity_Codes).ToString())
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
        
    

        ' To customize, override this method in EnityRecordControl.
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
          EnityTable.DeleteRecord(pkValue)
          
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
        
        
        ' Generate the event handling functions for pagination events.
            
      
        ' Generate the event handling functions for filter and search events.
            
   
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
                Return CType(Me.ViewState("BaseEnityRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseEnityRecordControl_Rec") = value
            End Set
        End Property
        
        Private _DataSource As EnityRecord
        Public Property DataSource() As EnityRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As EnityRecord)
            
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
        
        Public ReadOnly Property DeptAgencyNames() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "DeptAgencyNames"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Enity_Codes() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Enity_Codes"), System.Web.UI.WebControls.Literal)
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
            
            Dim rec As EnityRecord = Nothing
             
        
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
            
            Dim rec As EnityRecord = Nothing
             
        
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

         
        Public Overridable Function GetRecord() As EnityRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return EnityTable.GetRecord(Me.RecordUniqueId, True)
                
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

  

#End Region
    
  
End Namespace

  