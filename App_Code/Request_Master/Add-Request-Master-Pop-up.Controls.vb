
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Add_Request_Master_Pop_up.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Add_Request_Master_Pop_up

#Region "Section 1: Place your customizations here."

    
Public Class Request_MasterRecordControl
        Inherits BaseRequest_MasterRecordControl
        ' The BaseRequest_MasterRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the Request_MasterRecordControl control on the Add_Request_Master_Pop_up page.
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
          
              AddHandler Me.Cat_Cost_Free.CheckedChanged, AddressOf Cat_Cost_Free_CheckedChanged
            
              AddHandler Me.County_Upload.CheckedChanged, AddressOf County_Upload_CheckedChanged
            
              AddHandler Me.ICS_SOW_Needed.CheckedChanged, AddressOf ICS_SOW_Needed_CheckedChanged
            
              AddHandler Me.ICS_SOW_Uploaded.CheckedChanged, AddressOf ICS_SOW_Uploaded_CheckedChanged
            
              AddHandler Me.OTW_More_Info_Flag.CheckedChanged, AddressOf OTW_More_Info_Flag_CheckedChanged
            
              AddHandler Me.OTW_On_Net.CheckedChanged, AddressOf OTW_On_Net_CheckedChanged
            
              AddHandler Me.OTW_Premise_Fiber_Work_Reqd.CheckedChanged, AddressOf OTW_Premise_Fiber_Work_Reqd_CheckedChanged
            
              AddHandler Me.Req_Invoice_Paid.CheckedChanged, AddressOf Req_Invoice_Paid_CheckedChanged
            
              AddHandler Me.Cat_Franchise_Order_Number.TextChanged, AddressOf Cat_Franchise_Order_Number_TextChanged
            
              AddHandler Me.Cat_OTWC_Comments.TextChanged, AddressOf Cat_OTWC_Comments_TextChanged
            
              AddHandler Me.ICS_CATV_Comments.TextChanged, AddressOf ICS_CATV_Comments_TextChanged
            
              AddHandler Me.IROC_Id.TextChanged, AddressOf IROC_Id_TextChanged
            
              AddHandler Me.OTW_Completed_Dt.TextChanged, AddressOf OTW_Completed_Dt_TextChanged
            
              AddHandler Me.OTW_Construction_Status.TextChanged, AddressOf OTW_Construction_Status_TextChanged
            
              AddHandler Me.OTW_Deployment_Start_Dt.TextChanged, AddressOf OTW_Deployment_Start_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_Amt.TextChanged, AddressOf OTW_Invoice_Amt_TextChanged
            
              AddHandler Me.OTW_Invoice_Dt.TextChanged, AddressOf OTW_Invoice_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_No.TextChanged, AddressOf OTW_Invoice_No_TextChanged
            
              AddHandler Me.OTW_Island_completed.TextChanged, AddressOf OTW_Island_completed_TextChanged
            
              AddHandler Me.OTW_More_Info_Comments.TextChanged, AddressOf OTW_More_Info_Comments_TextChanged
            
              AddHandler Me.OTW_Permit_Status.TextChanged, AddressOf OTW_Permit_Status_TextChanged
            
              AddHandler Me.OTW_Projected_Deploy_Dt.TextChanged, AddressOf OTW_Projected_Deploy_Dt_TextChanged
            
              AddHandler Me.OTW_Quote.TextChanged, AddressOf OTW_Quote_TextChanged
            
              AddHandler Me.OTW_Scheduled_Deploy_Dt.TextChanged, AddressOf OTW_Scheduled_Deploy_Dt_TextChanged
            
              AddHandler Me.Pending_Action_Dt.TextChanged, AddressOf Pending_Action_Dt_TextChanged
            
              AddHandler Me.Pending_Action_Needed.TextChanged, AddressOf Pending_Action_Needed_TextChanged
            
              AddHandler Me.Pending_Agency.TextChanged, AddressOf Pending_Agency_TextChanged
            
              AddHandler Me.Pending_Interval_Days_1st.TextChanged, AddressOf Pending_Interval_Days_1st_TextChanged
            
              AddHandler Me.Pending_Interval_Days_2nd.TextChanged, AddressOf Pending_Interval_Days_2nd_TextChanged
            
              AddHandler Me.Pending_Interval_Days_Auto_Cancel.TextChanged, AddressOf Pending_Interval_Days_Auto_Cancel_TextChanged
            
              AddHandler Me.Pending_Interval_Days_Cancel.TextChanged, AddressOf Pending_Interval_Days_Cancel_TextChanged
            
              AddHandler Me.Pending_Nterval_Days_Max.TextChanged, AddressOf Pending_Nterval_Days_Max_TextChanged
            
              AddHandler Me.Priority.TextChanged, AddressOf Priority_TextChanged
            
              AddHandler Me.Reg_Type.TextChanged, AddressOf Reg_Type_TextChanged
            
              AddHandler Me.Req_Address.TextChanged, AddressOf Req_Address_TextChanged
            
              AddHandler Me.Req_City.TextChanged, AddressOf Req_City_TextChanged
            
              AddHandler Me.Req_Comments.TextChanged, AddressOf Req_Comments_TextChanged
            
              AddHandler Me.Req_Completed_Dt.TextChanged, AddressOf Req_Completed_Dt_TextChanged
            
              AddHandler Me.Req_Dt.TextChanged, AddressOf Req_Dt_TextChanged
            
              AddHandler Me.Req_Enity.TextChanged, AddressOf Req_Enity_TextChanged
            
              AddHandler Me.Req_Funding_Src.TextChanged, AddressOf Req_Funding_Src_TextChanged
            
              AddHandler Me.Req_Island.TextChanged, AddressOf Req_Island_TextChanged
            
              AddHandler Me.Req_PO_Amt.TextChanged, AddressOf Req_PO_Amt_TextChanged
            
              AddHandler Me.Req_PO_Dt.TextChanged, AddressOf Req_PO_Dt_TextChanged
            
              AddHandler Me.Req_PO_No.TextChanged, AddressOf Req_PO_No_TextChanged
            
              AddHandler Me.Req_Pymt_Amt.TextChanged, AddressOf Req_Pymt_Amt_TextChanged
            
              AddHandler Me.Req_Pymt_Check_No.TextChanged, AddressOf Req_Pymt_Check_No_TextChanged
            
              AddHandler Me.Req_Pymt_Dt.TextChanged, AddressOf Req_Pymt_Dt_TextChanged
            
              AddHandler Me.Req_Quote_Approved.TextChanged, AddressOf Req_Quote_Approved_TextChanged
            
              AddHandler Me.Req_Quote_Respnse.TextChanged, AddressOf Req_Quote_Respnse_TextChanged
            
              AddHandler Me.Req_Site_Name.TextChanged, AddressOf Req_Site_Name_TextChanged
            
              AddHandler Me.Req_State.TextChanged, AddressOf Req_State_TextChanged
            
              AddHandler Me.Req_Status.TextChanged, AddressOf Req_Status_TextChanged
            
              AddHandler Me.Req_Target_Dt.TextChanged, AddressOf Req_Target_Dt_TextChanged
            
              AddHandler Me.Req_Zip.TextChanged, AddressOf Req_Zip_TextChanged
            
    
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
          
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New Request_MasterRecord()
            
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As Request_MasterRecord = Request_MasterTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = CType(Request_MasterRecord.Copy(recList(0), False), Request_MasterRecord)
                  
    
    
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
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetCat_Cost_Free()
                SetCat_Cost_FreeLabel()
                SetCat_Franchise_Order_Number()
                SetCat_Franchise_Order_NumberLabel()
                SetCat_OTWC_Comments()
                SetCat_OTWC_CommentsLabel()
                SetCounty_Upload()
                SetCounty_UploadLabel()
                SetICS_CATV_Comments()
                SetICS_CATV_CommentsLabel()
                SetICS_SOW_Needed()
                SetICS_SOW_NeededLabel()
                SetICS_SOW_Uploaded()
                SetICS_SOW_UploadedLabel()
                SetIROC_Id()
                SetIROC_IdLabel()
                SetOTW_Completed_Dt()
                SetOTW_Completed_DtLabel()
                SetOTW_Construction_Status()
                SetOTW_Construction_StatusLabel()
                SetOTW_Deployment_Start_Dt()
                SetOTW_Deployment_Start_DtLabel()
                SetOTW_Invoice_Amt()
                SetOTW_Invoice_AmtLabel()
                SetOTW_Invoice_Dt()
                SetOTW_Invoice_DtLabel()
                SetOTW_Invoice_No()
                SetOTW_Invoice_NoLabel()
                SetOTW_Island_completed()
                SetOTW_Island_completedLabel()
                SetOTW_More_Info_Comments()
                SetOTW_More_Info_CommentsLabel()
                SetOTW_More_Info_Flag()
                SetOTW_More_Info_FlagLabel()
                SetOTW_On_Net()
                SetOTW_On_NetLabel()
                SetOTW_Permit_Status()
                SetOTW_Permit_StatusLabel()
                SetOTW_Premise_Fiber_Work_Reqd()
                SetOTW_Premise_Fiber_Work_ReqdLabel()
                SetOTW_Projected_Deploy_Dt()
                SetOTW_Projected_Deploy_DtLabel()
                SetOTW_Quote()
                SetOTW_QuoteLabel()
                SetOTW_Scheduled_Deploy_Dt()
                SetOTW_Scheduled_Deploy_DtLabel()
                SetPending_Action_Dt()
                SetPending_Action_DtLabel()
                SetPending_Action_Needed()
                SetPending_Action_NeededLabel()
                SetPending_Agency()
                SetPending_AgencyLabel()
                SetPending_Interval_Days_1st()
                SetPending_Interval_Days_1stLabel()
                SetPending_Interval_Days_2nd()
                SetPending_Interval_Days_2ndLabel()
                SetPending_Interval_Days_Auto_Cancel()
                SetPending_Interval_Days_Auto_CancelLabel()
                SetPending_Interval_Days_Cancel()
                SetPending_Interval_Days_CancelLabel()
                SetPending_Nterval_Days_Max()
                SetPending_Nterval_Days_MaxLabel()
                SetPriority()
                SetPriorityLabel()
                SetReg_Type()
                SetReg_TypeLabel()
                SetReq_Address()
                SetReq_AddressLabel()
                SetReq_City()
                SetReq_CityLabel()
                SetReq_Comments()
                SetReq_CommentsLabel()
                SetReq_Completed_Dt()
                SetReq_Completed_DtLabel()
                SetReq_Dt()
                SetReq_DtLabel()
                SetReq_Enity()
                SetReq_EnityLabel()
                SetReq_Funding_Src()
                SetReq_Funding_SrcLabel()
                SetReq_Invoice_Paid()
                SetReq_Invoice_PaidLabel()
                SetReq_Island()
                SetReq_IslandLabel()
                SetReq_PO_Amt()
                SetReq_PO_AmtLabel()
                SetReq_PO_Dt()
                SetReq_PO_DtLabel()
                SetReq_PO_No()
                SetReq_PO_NoLabel()
                SetReq_Pymt_Amt()
                SetReq_Pymt_AmtLabel()
                SetReq_Pymt_Check_No()
                SetReq_Pymt_Check_NoLabel()
                SetReq_Pymt_Dt()
                SetReq_Pymt_DtLabel()
                SetReq_Quote_Approved()
                SetReq_Quote_ApprovedLabel()
                SetReq_Quote_Respnse()
                SetReq_Quote_RespnseLabel()
                SetReq_Site_Name()
                SetReq_Site_NameLabel()
                SetReq_State()
                SetReq_StateLabel()
                SetReq_Status()
                SetReq_StatusLabel()
                SetReq_Target_Dt()
                SetReq_Target_DtLabel()
                SetReq_Zip()
                SetReq_ZipLabel()
                
      
      
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
                
        Public Overridable Sub SetCat_Franchise_Order_Number()
            
        
            ' Set the Cat_Franchise_Order_Number TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Franchise_Order_Number is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Franchise_Order_Number()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_NumberSpecified Then
                				
                ' If the Cat_Franchise_Order_Number is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Franchise_Order_Number)
                              
                Me.Cat_Franchise_Order_Number.Text = formattedValue
                
            Else 
            
                ' Cat_Franchise_Order_Number is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_Franchise_Order_Number.Text = Request_MasterTable.Cat_Franchise_Order_Number.Format(Request_MasterTable.Cat_Franchise_Order_Number.DefaultValue)
                        		
                End If
                 
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
                
        Public Overridable Sub SetCounty_Upload()
            
        
            ' Set the County_Upload CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.County_Upload is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetCounty_Upload()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.County_UploadSpecified Then
                									
                ' If the County_Upload is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.County_Upload.Checked = Me.DataSource.County_Upload
            Else
            
                ' County_Upload is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.County_Upload.Checked = Request_MasterTable.County_Upload.ParseValue(Request_MasterTable.County_Upload.DefaultValue).ToBoolean()
                End If
                    				
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
                
        Public Overridable Sub SetIROC_Id()
            
        
            ' Set the IROC_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IROC_IdSpecified Then
                				
                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.IROC_Id)
                              
                Me.IROC_Id.Text = formattedValue
                
            Else 
            
                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IROC_Id.Text = Request_MasterTable.IROC_Id.Format(Request_MasterTable.IROC_Id.DefaultValue)
                        		
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Completed_Dt, "g")
                              
                Me.OTW_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Completed_Dt.Text = Request_MasterTable.OTW_Completed_Dt.Format(Request_MasterTable.OTW_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Construction_Status()
            
        
            ' Set the OTW_Construction_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Construction_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Construction_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Construction_StatusSpecified Then
                				
                ' If the OTW_Construction_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Construction_Status)
                              
                Me.OTW_Construction_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Construction_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Construction_Status.Text = Request_MasterTable.OTW_Construction_Status.Format(Request_MasterTable.OTW_Construction_Status.DefaultValue)
                        		
                End If
                 
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "g")
                              
                Me.OTW_Deployment_Start_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Deployment_Start_Dt.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "g")
                        		
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
                
        Public Overridable Sub SetOTW_Island_completed()
            
        
            ' Set the OTW_Island completed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Island_completed is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Island_completed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Island_completedSpecified Then
                				
                ' If the OTW_Island completed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Island_completed)
                              
                Me.OTW_Island_completed.Text = formattedValue
                
            Else 
            
                ' OTW_Island completed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Island_completed.Text = Request_MasterTable.OTW_Island_completed.Format(Request_MasterTable.OTW_Island_completed.DefaultValue)
                        		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_More_Info_CommentsSpecified Then
                				
                ' If the OTW_More_Info_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_More_Info_Comments)
                              
                Me.OTW_More_Info_Comments.Text = formattedValue
                
            Else 
            
                ' OTW_More_Info_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_More_Info_Comments.Text = Request_MasterTable.OTW_More_Info_Comments.Format(Request_MasterTable.OTW_More_Info_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_More_Info_Flag()
            
        
            ' Set the OTW_More_Info_Flag CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_More_Info_Flag is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_More_Info_Flag()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_More_Info_FlagSpecified Then
                									
                ' If the OTW_More_Info_Flag is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_More_Info_Flag.Checked = Me.DataSource.OTW_More_Info_Flag
            Else
            
                ' OTW_More_Info_Flag is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_More_Info_Flag.Checked = Request_MasterTable.OTW_More_Info_Flag.ParseValue(Request_MasterTable.OTW_More_Info_Flag.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetOTW_On_Net()
            
        
            ' Set the OTW_On-Net CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_On_Net()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_NetSpecified Then
                									
                ' If the OTW_On-Net is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_On_Net.Checked = Me.DataSource.OTW_On_Net
            Else
            
                ' OTW_On-Net is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_On_Net.Checked = Request_MasterTable.OTW_On_Net.ParseValue(Request_MasterTable.OTW_On_Net.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetOTW_Permit_Status()
            
        
            ' Set the OTW_Permit_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Permit_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Permit_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Permit_StatusSpecified Then
                				
                ' If the OTW_Permit_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Permit_Status)
                              
                Me.OTW_Permit_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Permit_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Permit_Status.Text = Request_MasterTable.OTW_Permit_Status.Format(Request_MasterTable.OTW_Permit_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_Reqd()
            
        
            ' Set the OTW_Premise Fiber Work Reqd CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Premise_Fiber_Work_Reqd is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_Premise_Fiber_Work_Reqd()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Premise_Fiber_Work_ReqdSpecified Then
                									
                ' If the OTW_Premise Fiber Work Reqd is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_Premise_Fiber_Work_Reqd.Checked = Me.DataSource.OTW_Premise_Fiber_Work_Reqd
            Else
            
                ' OTW_Premise Fiber Work Reqd is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_Premise_Fiber_Work_Reqd.Checked = Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.ParseValue(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Projected_Deploy_Dt, "g")
                              
                Me.OTW_Projected_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Projected_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Projected_Deploy_Dt.Text = Request_MasterTable.OTW_Projected_Deploy_Dt.Format(Request_MasterTable.OTW_Projected_Deploy_Dt.DefaultValue, "g")
                        		
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "g")
                              
                Me.OTW_Scheduled_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Scheduled_Deploy_Dt.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Dt()
            
        
            ' Set the Pending Action_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Action_DtSpecified Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                Me.Pending_Action_Dt.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Dt.Text = Request_MasterTable.Pending_Action_Dt.Format(Request_MasterTable.Pending_Action_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Needed()
            
        
            ' Set the Pending_Action_Needed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Needed is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Action_NeededSpecified Then
                				
                ' If the Pending_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Needed)
                              
                Me.Pending_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Needed.Text = Request_MasterTable.Pending_Action_Needed.Format(Request_MasterTable.Pending_Action_Needed.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Agency()
            
        
            ' Set the Pending_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_AgencySpecified Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                Me.Pending_Agency.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency.Text = Request_MasterTable.Pending_Agency.Format(Request_MasterTable.Pending_Agency.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_1st()
            
        
            ' Set the Pending_Interval_Days_1st TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_1st is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_1st()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_1stSpecified Then
                				
                ' If the Pending_Interval_Days_1st is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_1st)
                              
                Me.Pending_Interval_Days_1st.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_1st is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_1st.Text = Request_MasterTable.Pending_Interval_Days_1st.Format(Request_MasterTable.Pending_Interval_Days_1st.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_2nd()
            
        
            ' Set the Pending_Interval_Days_2nd TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_2nd is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_2nd()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_2ndSpecified Then
                				
                ' If the Pending_Interval_Days_2nd is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_2nd)
                              
                Me.Pending_Interval_Days_2nd.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_2nd is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_2nd.Text = Request_MasterTable.Pending_Interval_Days_2nd.Format(Request_MasterTable.Pending_Interval_Days_2nd.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_Auto_Cancel()
            
        
            ' Set the Pending_Interval_Days_Auto_Cancel TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_Auto_Cancel is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_Auto_Cancel()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_Auto_CancelSpecified Then
                				
                ' If the Pending_Interval_Days_Auto_Cancel is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel)
                              
                Me.Pending_Interval_Days_Auto_Cancel.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_Auto_Cancel is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_Auto_Cancel.Text = Request_MasterTable.Pending_Interval_Days_Auto_Cancel.Format(Request_MasterTable.Pending_Interval_Days_Auto_Cancel.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Interval_Days_Cancel()
            
        
            ' Set the Pending_Interval_Days_Cancel TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Interval_Days_Cancel is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Interval_Days_Cancel()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Interval_Days_CancelSpecified Then
                				
                ' If the Pending_Interval_Days_Cancel is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Interval_Days_Cancel)
                              
                Me.Pending_Interval_Days_Cancel.Text = formattedValue
                
            Else 
            
                ' Pending_Interval_Days_Cancel is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Interval_Days_Cancel.Text = Request_MasterTable.Pending_Interval_Days_Cancel.Format(Request_MasterTable.Pending_Interval_Days_Cancel.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Nterval_Days_Max()
            
        
            ' Set the Pending_Nterval_Days_Max TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Nterval_Days_Max is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Nterval_Days_Max()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Nterval_Days_MaxSpecified Then
                				
                ' If the Pending_Nterval_Days_Max is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Nterval_Days_Max)
                              
                Me.Pending_Nterval_Days_Max.Text = formattedValue
                
            Else 
            
                ' Pending_Nterval_Days_Max is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Nterval_Days_Max.Text = Request_MasterTable.Pending_Nterval_Days_Max.Format(Request_MasterTable.Pending_Nterval_Days_Max.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPriority()
            
        
            ' Set the Priority TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Priority is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPriority()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.PrioritySpecified Then
                				
                ' If the Priority is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Priority)
                              
                Me.Priority.Text = formattedValue
                
            Else 
            
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Priority.Text = Request_MasterTable.Priority.Format(Request_MasterTable.Priority.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReg_Type()
            
        
            ' Set the Reg_Type TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                Me.Reg_Type.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Reg_Type.Text = Request_MasterTable.Reg_Type.Format(Request_MasterTable.Reg_Type.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Address()
            
        
            ' Set the Req_Address TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Address is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Address()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_AddressSpecified Then
                				
                ' If the Req_Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Address)
                              
                Me.Req_Address.Text = formattedValue
                
            Else 
            
                ' Req_Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Address.Text = Request_MasterTable.Req_Address.Format(Request_MasterTable.Req_Address.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_City()
            
        
            ' Set the Req_City TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_City is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_City()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CitySpecified Then
                				
                ' If the Req_City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_City)
                              
                Me.Req_City.Text = formattedValue
                
            Else 
            
                ' Req_City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_City.Text = Request_MasterTable.Req_City.Format(Request_MasterTable.Req_City.DefaultValue)
                        		
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Completed_Dt, "g")
                              
                Me.Req_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Completed_Dt.Text = Request_MasterTable.Req_Completed_Dt.Format(Request_MasterTable.Req_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Dt()
            
        
            ' Set the Req_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_DtSpecified Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                Me.Req_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt.Text = Request_MasterTable.Req_Dt.Format(Request_MasterTable.Req_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Enity()
            
        
            ' Set the Req_Enity TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_EnitySpecified Then
                				
                ' If the Req_Enity is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity)
                              
                Me.Req_Enity.Text = formattedValue
                
            Else 
            
                ' Req_Enity is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity.Text = Request_MasterTable.Req_Enity.Format(Request_MasterTable.Req_Enity.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Funding_Src()
            
        
            ' Set the Req_Funding_Src TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Funding_Src is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Funding_Src()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Funding_SrcSpecified Then
                				
                ' If the Req_Funding_Src is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Funding_Src)
                              
                Me.Req_Funding_Src.Text = formattedValue
                
            Else 
            
                ' Req_Funding_Src is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Funding_Src.Text = Request_MasterTable.Req_Funding_Src.Format(Request_MasterTable.Req_Funding_Src.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Invoice_Paid()
            
        
            ' Set the Req_Invoice_Paid CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Invoice_Paid is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetReq_Invoice_Paid()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Invoice_PaidSpecified Then
                									
                ' If the Req_Invoice_Paid is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.Req_Invoice_Paid.Checked = Me.DataSource.Req_Invoice_Paid
            Else
            
                ' Req_Invoice_Paid is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.Req_Invoice_Paid.Checked = Request_MasterTable.Req_Invoice_Paid.ParseValue(Request_MasterTable.Req_Invoice_Paid.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetReq_Island()
            
        
            ' Set the Req_Island TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Island is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Island()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_IslandSpecified Then
                				
                ' If the Req_Island is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Island)
                              
                Me.Req_Island.Text = formattedValue
                
            Else 
            
                ' Req_Island is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Island.Text = Request_MasterTable.Req_Island.Format(Request_MasterTable.Req_Island.DefaultValue)
                        		
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
                
        Public Overridable Sub SetReq_Pymt_Check_No()
            
        
            ' Set the Req_Pymt_Check_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Check_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Check_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_Check_NoSpecified Then
                				
                ' If the Req_Pymt_Check_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Check_No)
                              
                Me.Req_Pymt_Check_No.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Check_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Check_No.Text = Request_MasterTable.Req_Pymt_Check_No.Format(Request_MasterTable.Req_Pymt_Check_No.DefaultValue)
                        		
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
                
        Public Overridable Sub SetReq_Quote_Respnse()
            
        
            ' Set the Req_Quote_Respnse TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Quote_Respnse is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Quote_Respnse()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_RespnseSpecified Then
                				
                ' If the Req_Quote_Respnse is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Respnse)
                              
                Me.Req_Quote_Respnse.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Respnse is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Quote_Respnse.Text = Request_MasterTable.Req_Quote_Respnse.Format(Request_MasterTable.Req_Quote_Respnse.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Site_Name()
            
        
            ' Set the Req_Site_Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Site_Name is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Site_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Site_NameSpecified Then
                				
                ' If the Req_Site_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Site_Name)
                              
                Me.Req_Site_Name.Text = formattedValue
                
            Else 
            
                ' Req_Site_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Site_Name.Text = Request_MasterTable.Req_Site_Name.Format(Request_MasterTable.Req_Site_Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_State()
            
        
            ' Set the Req_State TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_State is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_State()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StateSpecified Then
                				
                ' If the Req_State is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_State)
                              
                Me.Req_State.Text = formattedValue
                
            Else 
            
                ' Req_State is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_State.Text = Request_MasterTable.Req_State.Format(Request_MasterTable.Req_State.DefaultValue)
                        		
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
                
        Public Overridable Sub SetReq_Target_Dt()
            
        
            ' Set the Req_Target_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Target_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Target_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Target_DtSpecified Then
                				
                ' If the Req_Target_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Target_Dt, "g")
                              
                Me.Req_Target_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Target_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Target_Dt.Text = Request_MasterTable.Req_Target_Dt.Format(Request_MasterTable.Req_Target_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Zip()
            
        
            ' Set the Req_Zip TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Zip is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Zip()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_ZipSpecified Then
                				
                ' If the Req_Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Zip)
                              
                Me.Req_Zip.Text = formattedValue
                
            Else 
            
                ' Req_Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Zip.Text = Request_MasterTable.Req_Zip.Format(Request_MasterTable.Req_Zip.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCat_Cost_FreeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_OTWC_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCounty_UploadLabel()
                  
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
                
        Public Overridable Sub SetReq_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel()
                  
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

      
        
        ' To customize, override this method in Request_MasterRecordControl.
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
              
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
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
            GetPending_Interval_Days_1st()
            GetPending_Interval_Days_2nd()
            GetPending_Interval_Days_Auto_Cancel()
            GetPending_Interval_Days_Cancel()
            GetPending_Nterval_Days_Max()
            GetPriority()
            GetReg_Type()
            GetReq_Address()
            GetReq_City()
            GetReq_Comments()
            GetReq_Completed_Dt()
            GetReq_Dt()
            GetReq_Enity()
            GetReq_Funding_Src()
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
        
        
            ' Retrieve the value entered by the user on the Cat_Cost_Free ASP:CheckBox, and
            ' save it into the Cat_Cost_Free field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.Cat_Cost_Free = Me.Cat_Cost_Free.Checked
                    
        End Sub
                
        Public Overridable Sub GetCat_Franchise_Order_Number()
            
            ' Retrieve the value entered by the user on the Cat_Franchise_Order_Number ASP:TextBox, and
            ' save it into the Cat_Franchise_Order_Number field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_Franchise_Order_Number.Text, Request_MasterTable.Cat_Franchise_Order_Number)			

                      
        End Sub
                
        Public Overridable Sub GetCat_OTWC_Comments()
            
            ' Retrieve the value entered by the user on the Cat_OTWC_Comments ASP:TextBox, and
            ' save it into the Cat_OTWC_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_OTWC_Comments.Text, Request_MasterTable.Cat_OTWC_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetCounty_Upload()
        
        
            ' Retrieve the value entered by the user on the County_Upload ASP:CheckBox, and
            ' save it into the County_Upload field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.County_Upload = Me.County_Upload.Checked
                    
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
                
        Public Overridable Sub GetIROC_Id()
            
            ' Retrieve the value entered by the user on the IROC_Id ASP:TextBox, and
            ' save it into the IROC_Id field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.IROC_Id.Text, Request_MasterTable.IROC_Id)			

                      
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
            
            ' Retrieve the value entered by the user on the OTW_Construction_Status ASP:TextBox, and
            ' save it into the OTW_Construction_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Construction_Status.Text, Request_MasterTable.OTW_Construction_Status)			

                      
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
                
        Public Overridable Sub GetOTW_Invoice_No()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_No ASP:TextBox, and
            ' save it into the OTW_Invoice_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_No.Text, Request_MasterTable.OTW_Invoice_No)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Island_completed()
            
            ' Retrieve the value entered by the user on the OTW_Island completed ASP:TextBox, and
            ' save it into the OTW_Island completed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Island_completed.Text, Request_MasterTable.OTW_Island_completed)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Comments()
            
            ' Retrieve the value entered by the user on the OTW_More_Info_Comments ASP:TextBox, and
            ' save it into the OTW_More_Info_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_More_Info_Comments.Text, Request_MasterTable.OTW_More_Info_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Flag()
        
        
            ' Retrieve the value entered by the user on the OTW_More_Info_Flag ASP:CheckBox, and
            ' save it into the OTW_More_Info_Flag field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_More_Info_Flag = Me.OTW_More_Info_Flag.Checked
                    
        End Sub
                
        Public Overridable Sub GetOTW_On_Net()
        
        
            ' Retrieve the value entered by the user on the OTW_On-Net ASP:CheckBox, and
            ' save it into the OTW_On-Net field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_On_Net = Me.OTW_On_Net.Checked
                    
        End Sub
                
        Public Overridable Sub GetOTW_Permit_Status()
            
            ' Retrieve the value entered by the user on the OTW_Permit_Status ASP:TextBox, and
            ' save it into the OTW_Permit_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Permit_Status.Text, Request_MasterTable.OTW_Permit_Status)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Premise_Fiber_Work_Reqd()
        
        
            ' Retrieve the value entered by the user on the OTW_Premise Fiber Work Reqd ASP:CheckBox, and
            ' save it into the OTW_Premise Fiber Work Reqd field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_Premise_Fiber_Work_Reqd = Me.OTW_Premise_Fiber_Work_Reqd.Checked
                    
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
                
        Public Overridable Sub GetOTW_Quote()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote.Text, Request_MasterTable.OTW_Quote)			

                      
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
                
        Public Overridable Sub GetPending_Action_Dt()
            
            ' Retrieve the value entered by the user on the Pending Action_Dt ASP:TextBox, and
            ' save it into the Pending Action_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Dt.Text, Request_MasterTable.Pending_Action_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed()
            
            ' Retrieve the value entered by the user on the Pending_Action_Needed ASP:TextBox, and
            ' save it into the Pending_Action_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Needed.Text, Request_MasterTable.Pending_Action_Needed)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Agency()
            
            ' Retrieve the value entered by the user on the Pending_Agency ASP:TextBox, and
            ' save it into the Pending_Agency field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency.Text, Request_MasterTable.Pending_Agency)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_1st()
            
            ' Retrieve the value entered by the user on the Pending_Interval_Days_1st ASP:TextBox, and
            ' save it into the Pending_Interval_Days_1st field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Interval_Days_1st.Text, Request_MasterTable.Pending_Interval_Days_1st)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_2nd()
            
            ' Retrieve the value entered by the user on the Pending_Interval_Days_2nd ASP:TextBox, and
            ' save it into the Pending_Interval_Days_2nd field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Interval_Days_2nd.Text, Request_MasterTable.Pending_Interval_Days_2nd)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_Auto_Cancel()
            
            ' Retrieve the value entered by the user on the Pending_Interval_Days_Auto_Cancel ASP:TextBox, and
            ' save it into the Pending_Interval_Days_Auto_Cancel field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Interval_Days_Auto_Cancel.Text, Request_MasterTable.Pending_Interval_Days_Auto_Cancel)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Interval_Days_Cancel()
            
            ' Retrieve the value entered by the user on the Pending_Interval_Days_Cancel ASP:TextBox, and
            ' save it into the Pending_Interval_Days_Cancel field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Interval_Days_Cancel.Text, Request_MasterTable.Pending_Interval_Days_Cancel)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Nterval_Days_Max()
            
            ' Retrieve the value entered by the user on the Pending_Nterval_Days_Max ASP:TextBox, and
            ' save it into the Pending_Nterval_Days_Max field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Nterval_Days_Max.Text, Request_MasterTable.Pending_Nterval_Days_Max)			

                      
        End Sub
                
        Public Overridable Sub GetPriority()
            
            ' Retrieve the value entered by the user on the Priority ASP:TextBox, and
            ' save it into the Priority field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Priority.Text, Request_MasterTable.Priority)			

                      
        End Sub
                
        Public Overridable Sub GetReg_Type()
            
            ' Retrieve the value entered by the user on the Reg_Type ASP:TextBox, and
            ' save it into the Reg_Type field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Reg_Type.Text, Request_MasterTable.Reg_Type)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Address()
            
            ' Retrieve the value entered by the user on the Req_Address ASP:TextBox, and
            ' save it into the Req_Address field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Address.Text, Request_MasterTable.Req_Address)			

                      
        End Sub
                
        Public Overridable Sub GetReq_City()
            
            ' Retrieve the value entered by the user on the Req_City ASP:TextBox, and
            ' save it into the Req_City field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_City.Text, Request_MasterTable.Req_City)			

                      
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
                
        Public Overridable Sub GetReq_Dt()
            
            ' Retrieve the value entered by the user on the Req_Dt ASP:TextBox, and
            ' save it into the Req_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Dt.Text, Request_MasterTable.Req_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Enity()
            
            ' Retrieve the value entered by the user on the Req_Enity ASP:TextBox, and
            ' save it into the Req_Enity field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Enity.Text, Request_MasterTable.Req_Enity)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src()
            
            ' Retrieve the value entered by the user on the Req_Funding_Src ASP:TextBox, and
            ' save it into the Req_Funding_Src field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Funding_Src.Text, Request_MasterTable.Req_Funding_Src)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Invoice_Paid()
        
        
            ' Retrieve the value entered by the user on the Req_Invoice_Paid ASP:CheckBox, and
            ' save it into the Req_Invoice_Paid field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.Req_Invoice_Paid = Me.Req_Invoice_Paid.Checked
                    
        End Sub
                
        Public Overridable Sub GetReq_Island()
            
            ' Retrieve the value entered by the user on the Req_Island ASP:TextBox, and
            ' save it into the Req_Island field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Island.Text, Request_MasterTable.Req_Island)			

                      
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
                
        Public Overridable Sub GetReq_Pymt_Check_No()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Check_No ASP:TextBox, and
            ' save it into the Req_Pymt_Check_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Check_No.Text, Request_MasterTable.Req_Pymt_Check_No)			

                      
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
                
        Public Overridable Sub GetReq_Quote_Respnse()
            
            ' Retrieve the value entered by the user on the Req_Quote_Respnse ASP:TextBox, and
            ' save it into the Req_Quote_Respnse field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Quote_Respnse.Text, Request_MasterTable.Req_Quote_Respnse)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Site_Name()
            
            ' Retrieve the value entered by the user on the Req_Site_Name ASP:TextBox, and
            ' save it into the Req_Site_Name field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Site_Name.Text, Request_MasterTable.Req_Site_Name)			

                      
        End Sub
                
        Public Overridable Sub GetReq_State()
            
            ' Retrieve the value entered by the user on the Req_State ASP:TextBox, and
            ' save it into the Req_State field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_State.Text, Request_MasterTable.Req_State)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Status()
            
            ' Retrieve the value entered by the user on the Req_Status ASP:TextBox, and
            ' save it into the Req_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Status.Text, Request_MasterTable.Req_Status)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Target_Dt()
            
            ' Retrieve the value entered by the user on the Req_Target_Dt ASP:TextBox, and
            ' save it into the Req_Target_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Target_Dt.Text, Request_MasterTable.Req_Target_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Zip()
            
            ' Retrieve the value entered by the user on the Req_Zip ASP:TextBox, and
            ' save it into the Req_Zip field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Zip.Text, Request_MasterTable.Req_Zip)			

                      
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
            Dim recId As String = Me.Page.Request.QueryString.Item("Request_Master")
            If recId Is Nothing OrElse recId.Trim = "" Then
                
                Return Nothing
                
            End If
              
                  recId = DirectCast(Me.Page, BaseApplicationPage).Decrypt(recId)
                  If recId Is Nothing OrElse recId.Trim = "" Then
                  
                      Return Nothing
                  
                  End If
                
            HttpContext.Current.Session("QueryString in Add-Request-Master-Pop-up") = recId
                
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
            
        Protected Overridable Sub Cat_Cost_Free_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub County_Upload_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Needed_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Uploaded_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_More_Info_Flag_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_On_Net_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_Premise_Fiber_Work_Reqd_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Req_Invoice_Paid_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_Franchise_Order_Number_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Cat_OTWC_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub ICS_CATV_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub IROC_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Construction_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Deployment_Start_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Island_completed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_More_Info_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Permit_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Projected_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Scheduled_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Needed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Interval_Days_1st_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Interval_Days_2nd_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Interval_Days_Auto_Cancel_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Interval_Days_Cancel_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Nterval_Days_Max_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Priority_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Reg_Type_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Address_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_City_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Enity_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Funding_Src_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Island_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Check_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Quote_Approved_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Quote_Respnse_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Site_Name_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_State_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Target_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Zip_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
            
        Public ReadOnly Property Cat_Cost_FreeLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_FreeLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Franchise_Order_Number() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_Number"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Franchise_Order_NumberLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_NumberLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property County_Upload() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_Upload"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property County_UploadLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_UploadLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property ICS_SOW_Uploaded() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Uploaded"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_UploadedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_UploadedLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property IROC_IdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property OTW_Construction_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Construction_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_StatusLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property OTW_Invoice_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_DtLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property OTW_Island_completed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Island_completedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completedLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property OTW_More_Info_Flag() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Flag"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_FlagLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_FlagLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_On_Net() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_On_NetLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_NetLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Permit_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Permit_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Premise_Fiber_Work_Reqd() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_Reqd"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_ReqdLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property OTW_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_QuoteLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Pending_Action_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Needed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_1st() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_1st"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_1stLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_1stLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_2nd() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_2nd"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_2ndLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_2ndLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_Auto_Cancel() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Auto_Cancel"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_Auto_CancelLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Auto_CancelLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Interval_Days_Cancel() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_Cancel"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Interval_Days_CancelLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Interval_Days_CancelLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Nterval_Days_Max() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Nterval_Days_Max"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Nterval_Days_MaxLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Nterval_Days_MaxLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Priority() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Priority"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property PriorityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "PriorityLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Reg_Type() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_Type"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Reg_TypeLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Address() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Address"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_AddressLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_AddressLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_City() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_City"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_CityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CityLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Enity() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_EnityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_Src() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_SrcLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_SrcLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Invoice_Paid() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Invoice_Paid"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Invoice_PaidLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Invoice_PaidLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Island() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_IslandLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_AmtLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Pymt_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Check_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Check_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_NoLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Quote_Respnse() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_Respnse"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Quote_RespnseLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_RespnseLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Site_Name() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_Name"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Site_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_NameLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_State() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_State"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_StateLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StateLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Target_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Target_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Zip() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Zip"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_ZipLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_ZipLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTitle"), System.Web.UI.WebControls.Literal)
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
            
            
            Return New Request_MasterRecord()
            
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

  