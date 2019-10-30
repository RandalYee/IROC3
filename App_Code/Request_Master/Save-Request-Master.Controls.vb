
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Save_Request_Master.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Save_Request_Master

#Region "Section 1: Place your customizations here."

    

  
Public Class Request_MasterRecordControl
        Inherits BaseRequest_MasterRecordControl
        ' The BaseRequest_MasterRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        


		Public Overrides Sub SetToAgency()
                  '--Ryee
            Me.ToAgency.Text = EvaluateFormula("URL(""To_Agency"")")
            If Me.ToAgency.Text = "Agency" Then
                Me.ToAgency.Text = Me.Req_Enity2.Text
            End If
                    
                  End Sub
End Class

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the Request_MasterRecordControl control on the Save_Request_Master page.
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
          
              AddHandler Me.Priority.SelectedIndexChanged, AddressOf Priority_SelectedIndexChanged
            
              AddHandler Me.Cat_Cost_Free.CheckedChanged, AddressOf Cat_Cost_Free_CheckedChanged
            
              AddHandler Me.ICS_SOW_Needed.CheckedChanged, AddressOf ICS_SOW_Needed_CheckedChanged
            
              AddHandler Me.ICS_SOW_Uploaded.CheckedChanged, AddressOf ICS_SOW_Uploaded_CheckedChanged
            
              AddHandler Me.OTW_Premise_Fiber_Work_Reqd.CheckedChanged, AddressOf OTW_Premise_Fiber_Work_Reqd_CheckedChanged
            
              AddHandler Me.Cat_Franchise_Order_Number2.TextChanged, AddressOf Cat_Franchise_Order_Number2_TextChanged
            
              AddHandler Me.Cat_OTWC_Comments.TextChanged, AddressOf Cat_OTWC_Comments_TextChanged
            
              AddHandler Me.ICS_CATV_Comments.TextChanged, AddressOf ICS_CATV_Comments_TextChanged
            
              AddHandler Me.OTW_Completed_Dt.TextChanged, AddressOf OTW_Completed_Dt_TextChanged
            
              AddHandler Me.OTW_Construction_Status.TextChanged, AddressOf OTW_Construction_Status_TextChanged
            
              AddHandler Me.OTW_Deployment_Start_Dt1.TextChanged, AddressOf OTW_Deployment_Start_Dt1_TextChanged
            
              AddHandler Me.OTW_Invoice_Amt.TextChanged, AddressOf OTW_Invoice_Amt_TextChanged
            
              AddHandler Me.OTW_Invoice_Dt.TextChanged, AddressOf OTW_Invoice_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_No.TextChanged, AddressOf OTW_Invoice_No_TextChanged
            
              AddHandler Me.OTW_Island_completed.TextChanged, AddressOf OTW_Island_completed_TextChanged
            
              AddHandler Me.OTW_On_Net_Dt.TextChanged, AddressOf OTW_On_Net_Dt_TextChanged
            
              AddHandler Me.OTW_On_Net_Dt1.TextChanged, AddressOf OTW_On_Net_Dt1_TextChanged
            
              AddHandler Me.OTW_Permit_Status.TextChanged, AddressOf OTW_Permit_Status_TextChanged
            
              AddHandler Me.OTW_Projected_Deploy_Dt.TextChanged, AddressOf OTW_Projected_Deploy_Dt_TextChanged
            
              AddHandler Me.OTW_Quote1.TextChanged, AddressOf OTW_Quote1_TextChanged
            
              AddHandler Me.OTW_Scheduled_Deploy_Dt.TextChanged, AddressOf OTW_Scheduled_Deploy_Dt_TextChanged
            
              AddHandler Me.OTW_Scheduled_Deploy_Dt1.TextChanged, AddressOf OTW_Scheduled_Deploy_Dt1_TextChanged
            
              AddHandler Me.Pending_Action_Dt1.TextChanged, AddressOf Pending_Action_Dt1_TextChanged
            
              AddHandler Me.Pending_Action_Needed1.TextChanged, AddressOf Pending_Action_Needed1_TextChanged
            
              AddHandler Me.Pending_Agency_Return.TextChanged, AddressOf Pending_Agency_Return_TextChanged
            
              AddHandler Me.Pending_Prev_Action_Needed.TextChanged, AddressOf Pending_Prev_Action_Needed_TextChanged
            
              AddHandler Me.Pending_Prev_Status.TextChanged, AddressOf Pending_Prev_Status_TextChanged
            
              AddHandler Me.Prov_Name.TextChanged, AddressOf Prov_Name_TextChanged
            
              AddHandler Me.Req_Comments.TextChanged, AddressOf Req_Comments_TextChanged
            
              AddHandler Me.Req_PO_Amt.TextChanged, AddressOf Req_PO_Amt_TextChanged
            
              AddHandler Me.Req_PO_Dt.TextChanged, AddressOf Req_PO_Dt_TextChanged
            
              AddHandler Me.Req_PO_No.TextChanged, AddressOf Req_PO_No_TextChanged
            
              AddHandler Me.Req_Pymt_Amt.TextChanged, AddressOf Req_Pymt_Amt_TextChanged
            
              AddHandler Me.Req_Pymt_Check_No.TextChanged, AddressOf Req_Pymt_Check_No_TextChanged
            
              AddHandler Me.Req_Pymt_Dt.TextChanged, AddressOf Req_Pymt_Dt_TextChanged
            
              AddHandler Me.Req_Quote_Approved.TextChanged, AddressOf Req_Quote_Approved_TextChanged
            
              AddHandler Me.Req_Status.TextChanged, AddressOf Req_Status_TextChanged
            
              AddHandler Me.OTW_Quote.TextChanged, AddressOf OTW_Quote_TextChanged
            
              AddHandler Me.Pending_Agency1.TextChanged, AddressOf Pending_Agency1_TextChanged
            					
              AddHandler Me.ToAgency.TextChanged, AddressOf ToAgency_TextChanged
                    
    
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
       
      
      
            ' Call the Set methods for each controls on the panel
        
                SetCat_Cost_Free()
                SetCat_Cost_FreeLabel()
                SetCat_Franchise_Order_Number2()
                SetCat_Franchise_Order_NumberLabel()
                SetCat_OTWC_Comments()
                SetCounty_Upload1()
                SetCounty_UploadLabel1()
                SetICS_CATV_Comments()
                SetICS_SOW_Needed()
                SetICS_SOW_NeededLabel()
                SetICS_SOW_Uploaded()
                SetICS_SOW_UploadedLabel()
                SetIROC_Id()
                SetIROC_IdLabel1()
                SetLabel()
                SetOTW_Completed_Dt()
                SetOTW_Completed_DtLabel()
                SetOTW_Construction_Status()
                SetOTW_Construction_StatusLabel()
                SetOTW_Deployment_Start_Dt1()
                SetOTW_Deployment_Start_DtLabel()
                SetOTW_Invoice_Amt()
                SetOTW_Invoice_AmtLabel()
                SetOTW_Invoice_Dt()
                SetOTW_Invoice_DtLabel()
                SetOTW_Invoice_No()
                SetOTW_Invoice_NoLabel()
                SetOTW_Island_completed()
                SetOTW_On_Net_Dt()
                SetOTW_On_Net_Dt1()
                SetOTW_On_Net_DtLabel()
                SetOTW_On_Net_DtLabel1()
                SetOTW_Permit_Status()
                SetOTW_Permit_StatusLabel()
                SetOTW_Premise_Fiber_Work_Reqd()
                SetOTW_Premise_Fiber_Work_ReqdLabel()
                SetOTW_Projected_Deploy_Dt()
                SetOTW_Projected_Deploy_DtLabel()
                SetOTW_Quote1()
                SetOTW_QuoteLabel()
                SetOTW_QuoteLabel1()
                SetOTW_Scheduled_Deploy_Dt()
                SetOTW_Scheduled_Deploy_Dt1()
                SetOTW_Scheduled_Deploy_DtLabel()
                SetOTW_Scheduled_Deploy_DtLabel1()
                SetPending_Action_Dt1()
                SetPending_Action_DtLabel()
                SetPending_Action_Needed1()
                SetPending_Action_NeededLabel()
                SetPending_Agency_Return()
                SetPending_Agency_ReturnLabel()
                SetPending_AgencyLabel()
                SetPending_Prev_Action_Needed()
                SetPending_Prev_Action_NeededLabel()
                SetPending_Prev_Status()
                SetPending_Prev_StatusLabel()
                SetPriority()
                SetPriorityLabel()
                SetProv_Name()
                SetProv_NameLabel()
                SetReg_Type1()
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
                SetReq_EnityLabel1()
                SetReq_Funding_Src2()
                SetReq_Funding_SrcLabel1()
                SetReq_Island1()
                SetReq_IslandLabel1()
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
                SetReq_Site_Name1()
                SetReq_Site_NameLabel1()
                SetReq_State1()
                SetReq_StateLabel1()
                SetReq_Status()
                SetReq_StatusLabel()
                SetReq_Target_Dt1()
                SetReq_Target_DtLabel1()
                SetReq_Zip1()
                SetReq_ZipLabel1()
                
                
                SetRole_IDMaxControl()
                
                
                
                
                
                
                SetToAgency()
                SetOTW_Quote()
                SetPending_Agency1()
      
      
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
                
        Public Overridable Sub SetCat_Franchise_Order_Number2()
            
        
            ' Set the Cat_Franchise_Order_Number2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Franchise_Order_Number2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Franchise_Order_Number2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_Number2Specified Then
                				
                ' If the Cat_Franchise_Order_Number2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Franchise_Order_Number2)
                              
                Me.Cat_Franchise_Order_Number2.Text = formattedValue
                
            Else 
            
                ' Cat_Franchise_Order_Number2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_Franchise_Order_Number2.Text = Request_MasterTable.Cat_Franchise_Order_Number2.Format(Request_MasterTable.Cat_Franchise_Order_Number2.DefaultValue)
                        		
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
                
        Public Overridable Sub SetCounty_Upload1()
            
        
            ' Set the County_Upload Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.County_Upload1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCounty_Upload1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.County_UploadSpecified Then
                				
                ' If the County_Upload is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.County_Upload)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.County_Upload1.Text = formattedValue
                
            Else 
            
                ' County_Upload is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.County_Upload1.Text = Request_MasterTable.County_Upload.Format(Request_MasterTable.County_Upload.DefaultValue)
                        		
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
                
        Public Overridable Sub SetOTW_Deployment_Start_Dt1()
            
        
            ' Set the OTW_Deployment_Start_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Deployment_Start_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Deployment_Start_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Deployment_Start_DtSpecified Then
                				
                ' If the OTW_Deployment_Start_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "g")
                              
                Me.OTW_Deployment_Start_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Deployment_Start_Dt1.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "g")
                        		
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
                
        Public Overridable Sub SetOTW_On_Net_Dt1()
            
        
            ' Set the OTW_On_Net_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_On_Net_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_Net_DtSpecified Then
                				
                ' If the OTW_On_Net_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_On_Net_Dt, "d")
                              
                Me.OTW_On_Net_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_On_Net_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_On_Net_Dt1.Text = Request_MasterTable.OTW_On_Net_Dt.Format(Request_MasterTable.OTW_On_Net_Dt.DefaultValue, "d")
                        		
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
                
        Public Overridable Sub SetOTW_Quote1()
            
        
            ' Set the OTW_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                Me.OTW_Quote1.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote1.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
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
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_Dt1()
            
        
            ' Set the OTW_Scheduled_Deploy_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Scheduled_Deploy_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Scheduled_Deploy_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Scheduled_Deploy_DtSpecified Then
                				
                ' If the OTW_Scheduled_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "g")
                              
                Me.OTW_Scheduled_Deploy_Dt1.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Scheduled_Deploy_Dt1.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "g")
                        		
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
            
        
            ' Set the Reg_Type Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
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
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote, "$###,###,###.##")
                              
                Me.OTW_Quote.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue, "$###,###,###.##")
                        		
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
                
        Public Overridable Sub SetCat_Cost_FreeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCounty_UploadLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.County_UploadLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_SOW_NeededLabel()
                  
                  End Sub
                
        Public Overridable Sub SetICS_SOW_UploadedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetIROC_IdLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.IROC_IdLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Label.Text = "Some value"
                    
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
                
        Public Overridable Sub SetOTW_On_Net_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.OTW_On_Net_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_On_Net_DtLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Permit_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_ReqdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Action_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_NeededLabel.Text = "Some value"
                    
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
                  
                  End Sub
                
        Public Overridable Sub SetProv_NameLabel()
                  
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
                
        Public Overridable Sub SetRole_IDMaxControl()
                  
                      Me.Role_IDMaxControl.Text = EvaluateFormula("LOOKUP(Role_IDMaxQuery, """")")
                    
                  End Sub
                
        Public Overridable Sub SetToAgency()
                  
                      Me.ToAgency.Text = EvaluateFormula("URL(""To_Agency"")")
                    
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
            GetCat_Franchise_Order_Number2()
            GetCat_OTWC_Comments()
            GetCounty_Upload1()
            GetICS_CATV_Comments()
            GetICS_SOW_Needed()
            GetICS_SOW_Uploaded()
            GetIROC_Id()
            GetOTW_Completed_Dt()
            GetOTW_Construction_Status()
            GetOTW_Deployment_Start_Dt1()
            GetOTW_Invoice_Amt()
            GetOTW_Invoice_Dt()
            GetOTW_Invoice_No()
            GetOTW_Island_completed()
            GetOTW_On_Net_Dt()
            GetOTW_On_Net_Dt1()
            GetOTW_Permit_Status()
            GetOTW_Premise_Fiber_Work_Reqd()
            GetOTW_Projected_Deploy_Dt()
            GetOTW_Quote1()
            GetOTW_Scheduled_Deploy_Dt()
            GetOTW_Scheduled_Deploy_Dt1()
            GetPending_Action_Dt1()
            GetPending_Action_Needed1()
            GetPending_Agency_Return()
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
            GetReq_PO_Dt()
            GetReq_PO_No()
            GetReq_Pymt_Amt()
            GetReq_Pymt_Check_No()
            GetReq_Pymt_Dt()
            GetReq_Quote_Approved()
            GetReq_Site_Name1()
            GetReq_State1()
            GetReq_Status()
            GetReq_Target_Dt1()
            GetReq_Zip1()
            GetOTW_Quote()
            GetPending_Agency1()
        End Sub
        
        
        Public Overridable Sub GetCat_Cost_Free()
        
        
            ' Retrieve the value entered by the user on the Cat_Cost_Free ASP:CheckBox, and
            ' save it into the Cat_Cost_Free field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.Cat_Cost_Free = Me.Cat_Cost_Free.Checked
                    
        End Sub
                
        Public Overridable Sub GetCat_Franchise_Order_Number2()
            
            ' Retrieve the value entered by the user on the Cat_Franchise_Order_Number2 ASP:TextBox, and
            ' save it into the Cat_Franchise_Order_Number2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_Franchise_Order_Number2.Text, Request_MasterTable.Cat_Franchise_Order_Number2)			

                      
        End Sub
                
        Public Overridable Sub GetCat_OTWC_Comments()
            
            ' Retrieve the value entered by the user on the Cat_OTWC_Comments ASP:TextBox, and
            ' save it into the Cat_OTWC_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_OTWC_Comments.Text, Request_MasterTable.Cat_OTWC_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetCounty_Upload1()
            
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
                
        Public Overridable Sub GetOTW_Deployment_Start_Dt1()
            
            ' Retrieve the value entered by the user on the OTW_Deployment_Start_Dt ASP:TextBox, and
            ' save it into the OTW_Deployment_Start_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Deployment_Start_Dt1.Text, Request_MasterTable.OTW_Deployment_Start_Dt)			

                      
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
                
        Public Overridable Sub GetOTW_On_Net_Dt1()
            
            ' Retrieve the value entered by the user on the OTW_On_Net_Dt ASP:TextBox, and
            ' save it into the OTW_On_Net_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_On_Net_Dt1.Text, Request_MasterTable.OTW_On_Net_Dt)			

                      
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
                
        Public Overridable Sub GetOTW_Quote1()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote1.Text, Request_MasterTable.OTW_Quote)			

                      
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
                
        Public Overridable Sub GetOTW_Scheduled_Deploy_Dt1()
            
            ' Retrieve the value entered by the user on the OTW_Scheduled_Deploy_Dt ASP:TextBox, and
            ' save it into the OTW_Scheduled_Deploy_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Scheduled_Deploy_Dt1.Text, Request_MasterTable.OTW_Scheduled_Deploy_Dt)			

                      
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
            
        End Sub
                
        Public Overridable Sub GetReq_Contact_Email()
            
        End Sub
                
        Public Overridable Sub GetReq_Dt1()
            
        End Sub
                
        Public Overridable Sub GetReq_Enity2()
            
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
                
        Public Overridable Sub GetOTW_Quote()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote.Text, Request_MasterTable.OTW_Quote)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Agency1()
            
            ' Retrieve the value entered by the user on the Pending_Agency ASP:TextBox, and
            ' save it into the Pending_Agency field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency1.Text, Request_MasterTable.Pending_Agency)			

                      
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
            HttpContext.Current.Session("QueryString in Save-Request-Master") = recId
              
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
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery() As WhereClause
        
        
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
                                
                
			Me.Page.Authorize(Ctype(Label, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency_Return, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency_ReturnLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_Needed, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_NeededLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Status, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_StatusLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_CommentsLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Contact_Email, Control), "1;2;4")
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel"), Control), "NOT_ANONYMOUS")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel1"), Control), "1;2;3;4;6;8")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel2"), Control), "1;4")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel3"), Control), "1;2;4;5")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel4"), Control), "1;2;4")
			End If
					
			Me.Page.Authorize(Ctype(ToAgency, Control), "1")
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
				Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				parentTC.Visible = MiscUtils.IsTabContainerVisible(parentTC)
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
            
                        
        Public Overridable Function CreateWhereClause_PriorityDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
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
            
        Protected Overridable Sub ICS_SOW_Needed_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Uploaded_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_Premise_Fiber_Work_Reqd_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_Franchise_Order_Number2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Cat_OTWC_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub ICS_CATV_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Construction_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Deployment_Start_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Island_completed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_On_Net_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_On_Net_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Permit_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Projected_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Scheduled_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Scheduled_Deploy_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Needed1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency_Return_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Action_Needed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Prov_Name_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
            
        Protected Overridable Sub Req_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            		
        Protected Overridable Sub ToAgency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
             
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
        
        Public ReadOnly Property Cat_Franchise_Order_Number2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_Number2"), System.Web.UI.WebControls.TextBox)
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
            
        Public ReadOnly Property County_Upload1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_Upload1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property County_UploadLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "County_UploadLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_CATV_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_Comments"), System.Web.UI.WebControls.TextBox)
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
        
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property IROC_IdLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Label() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Label"), System.Web.UI.WebControls.Label)
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
        
        Public ReadOnly Property OTW_Deployment_Start_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_Dt1"), System.Web.UI.WebControls.TextBox)
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
            
        Public ReadOnly Property OTW_On_Net_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_On_Net_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net_Dt1"), System.Web.UI.WebControls.TextBox)
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
        
        Public ReadOnly Property OTW_Quote1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote1"), System.Web.UI.WebControls.TextBox)
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
            
        Public ReadOnly Property OTW_Scheduled_Deploy_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_Dt1"), System.Web.UI.WebControls.TextBox)
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
        
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Reg_Type1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_Type1"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Completed_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_Dt"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Enity2() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property ToAgency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ToAgency"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Agency1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency1"), System.Web.UI.WebControls.TextBox)
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

  