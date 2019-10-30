
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Add_Request_Master.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Add_Request_Master

#Region "Section 1: Place your customizations here."


    Public Class Request_MasterRecordControl
        Inherits BaseRequest_MasterRecordControl
        ' The BaseRequest_MasterRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.



    
		Public Overrides Sub SetICS_SOW_Needed()
            
        
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
            Me.ICS_SOW_Needed.Checked = True    '--Ryee   
        End Sub

		Public Overrides Sub SetPending_Agency()
            
        
            ' Set the Pending_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                Me.Pending_Agency.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency.Text = EvaluateFormula("""ETS""", Me.DataSource)		
                End If
                 
        End Sub
End Class
#End Region



#Region "Section 2: Do not modify this section."
    
    
' Base class for the Request_MasterRecordControl control on the Add_Request_Master page.
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
          
              url = Me.ModifyRedirectUrl("../Contacts/Contacts-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Request_Id.PostBackUrl = url & "?Target=" & Me.Request_Id.ClientID & "&DFKA=" & CType(Me.Page, BaseApplicationPage).Encrypt("Request_Id")& "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Request_Id")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--PLEASE_SELECT--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:PleaseSelect"))& "&Mode=FieldValueSingleSelection"
              Me.Request_Id.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Request_Id.PostBackUrl & "', false, event); return false;"                  
                
              AddHandler Me.Request_Id.SelectedIndexChanged, AddressOf Request_Id_SelectedIndexChanged                  
                
              AddHandler Me.Prov_Name.SelectedIndexChanged, AddressOf Prov_Name_SelectedIndexChanged
            
              AddHandler Me.Req_Island.SelectedIndexChanged, AddressOf Req_Island_SelectedIndexChanged
            
              AddHandler Me.ICS_SOW_Needed.CheckedChanged, AddressOf ICS_SOW_Needed_CheckedChanged
            
              AddHandler Me.Cat_OTWC_Comments.TextChanged, AddressOf Cat_OTWC_Comments_TextChanged
            
              AddHandler Me.ICS_CATV_Comments.TextChanged, AddressOf ICS_CATV_Comments_TextChanged
            
              AddHandler Me.OTW_More_Info_Comments.TextChanged, AddressOf OTW_More_Info_Comments_TextChanged
            
              AddHandler Me.Pending_Action_Dt.TextChanged, AddressOf Pending_Action_Dt_TextChanged
            
              AddHandler Me.Pending_Action_Needed.TextChanged, AddressOf Pending_Action_Needed_TextChanged
            
              AddHandler Me.Pending_Agency.TextChanged, AddressOf Pending_Agency_TextChanged
            
              AddHandler Me.Priority.TextChanged, AddressOf Priority_TextChanged
            
              AddHandler Me.Reg_Type.TextChanged, AddressOf Reg_Type_TextChanged
            
              AddHandler Me.Req_Address.TextChanged, AddressOf Req_Address_TextChanged
            
              AddHandler Me.Req_City.TextChanged, AddressOf Req_City_TextChanged
            
              AddHandler Me.Req_Comments.TextChanged, AddressOf Req_Comments_TextChanged
            
              AddHandler Me.Req_Contact_Email.TextChanged, AddressOf Req_Contact_Email_TextChanged
            
              AddHandler Me.Req_Dt.TextChanged, AddressOf Req_Dt_TextChanged
            
              AddHandler Me.Req_Enity2.TextChanged, AddressOf Req_Enity2_TextChanged
            
              AddHandler Me.Req_Funding_Src2.TextChanged, AddressOf Req_Funding_Src2_TextChanged
            
              AddHandler Me.Req_Site_Name.TextChanged, AddressOf Req_Site_Name_TextChanged
            
              AddHandler Me.Req_State.TextChanged, AddressOf Req_State_TextChanged
            
              AddHandler Me.Req_Status.TextChanged, AddressOf Req_Status_TextChanged
            
              AddHandler Me.Req_Target_Dt.TextChanged, AddressOf Req_Target_Dt_TextChanged
            
              AddHandler Me.Req_Zip.TextChanged, AddressOf Req_Zip_TextChanged
            					
              AddHandler Me.TxtUser_Id.TextChanged, AddressOf TxtUser_Id_TextChanged
                    
    
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
          
                  LoadData_Request_IdMaxQuery()
       
                  LoadData_Request_IdMaxQuery1()
       
                  LoadData_Request_IdMaxQuery10()
       
                  LoadData_Request_IdMaxQuery11()
       
                  LoadData_Request_IdMaxQuery12()
       
                  LoadData_Request_IdMaxQuery13()
       
                  LoadData_Request_IdMaxQuery14()
       
                  LoadData_Request_IdMaxQuery15()
       
                  LoadData_Request_IdMaxQuery2()
       
                  LoadData_Request_IdMaxQuery3()
       
                  LoadData_Request_IdMaxQuery4()
       
                  LoadData_Request_IdMaxQuery5()
       
                  LoadData_Request_IdMaxQuery6()
       
                  LoadData_Request_IdMaxQuery7()
       
                  LoadData_Request_IdMaxQuery8()
       
                  LoadData_Request_IdMaxQuery9()
       
                  LoadData_Request_IdSumQuery()
       
                  LoadData_Request_IdSumQuery1()
       
                  LoadData_Request_IdSumQuery2()
       
                  LoadData_Request_IdSumQuery3()
       
                  LoadData_Request_IdSumQuery4()
       
                  LoadData_Request_IdSumQuery5()
       
                  LoadData_Request_IdSumQuery6()
       
                  LoadData_Request_IdSumQuery7()
       
                  LoadData_Role_IDMaxQuery()
       
                  LoadData_Role_IDMaxQuery1()
       
      
      
            ' Call the Set methods for each controls on the panel
        
                SetCat_OTWC_Comments()
                SetICS_CATV_Comments()
                SetICS_SOW_Needed()
                Setlabel1()
                SetLReg_Type1()
                SetLReq_Dt()
                SetOTW_More_Info_Comments()
                SetPending_Action_Dt()
                SetPending_Action_Needed()
                SetPending_Agency()
                SetPriority()
                SetProv_Name()
                SetProv_NameLabel()
                SetReg_Type()
                SetReg_TypeLabel()
                SetReq_Address()
                SetReq_AddressLabel()
                SetReq_City()
                SetReq_CityLabel()
                SetReq_Comments()
                SetReq_Contact_Email()
                SetReq_Contact_Email1()
                SetReq_Contact_Email2Label()
                SetReq_Contact_EmailLabel()
                SetReq_Dt()
                SetReq_DtLabel()
                SetReq_Enity2()
                SetReq_Enity21()
                SetReq_Enity2Label()
                SetReq_Funding_Src2()
                SetReq_Funding_SrcLabel()
                SetReq_Island()
                SetReq_IslandLabel()
                SetReq_Site_Name()
                SetReq_Site_NameLabel()
                SetReq_State()
                SetReq_StateLabel()
                SetReq_Status()
                SetReq_Target_Dt()
                SetReq_Target_DtLabel()
                SetReq_Zip()
                SetReq_ZipLabel()
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                SetTxtUser_Id()
                SetRequest_Id()
      
      
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
                
        Public Overridable Sub SetLReg_Type1()
            
        
            ' Set the Reg_Type Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReg_Type1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReg_Type1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReg_Type1.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReg_Type1.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetLReq_Dt()
            
        
            ' Set the Req_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.LReq_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetLReq_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.LReq_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.LReq_Dt.Text = EvaluateFormula("Format(Today(), ""d"")", Me.DataSource, "g")		
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
                
        Public Overridable Sub SetPending_Action_Dt()
            
        
            ' Set the Pending Action_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                Me.Pending_Action_Dt.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Dt.Text = EvaluateFormula("Format(Now(), ""D"")", Me.DataSource, "g")		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Needed)
                              
                Me.Pending_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Needed.Text = EvaluateFormula("""Review Request""", Me.DataSource)		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                Me.Pending_Agency.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency.Text = EvaluateFormula("""ETS""", Me.DataSource)		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Priority is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Priority)
                              
                Me.Priority.Text = formattedValue
                
            Else 
            
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Priority.Text = EvaluateFormula("""1""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetProv_Name()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Prov_Name DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Prov_Name is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetProv_Name()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Prov_NameSpecified Then
                            
                ' If the Prov_Name is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Prov_Name
            Else
                
                ' Prov_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Prov_Name.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateProv_NameDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetReg_Type()
            
        
            ' Set the Reg_Type TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                Me.Reg_Type.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Reg_Type.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Enity"")", Me.DataSource)		
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
                
        Public Overridable Sub SetReq_Contact_Email()
            
        
            ' Set the Req_Contact_Email2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Contact_Email is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Contact_Email()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Contact_Email2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Contact_Email2)
                              
                Me.Req_Contact_Email.Text = formattedValue
                
            Else 
            
                ' Req_Contact_Email2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Contact_Email.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Email"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Contact_Email1()
            
        
            ' Set the Req_Contact_Email2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Contact_Email1 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Contact_Email1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Contact_Email2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Contact_Email2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Contact_Email1.Text = formattedValue
                
            Else 
            
                ' Req_Contact_Email2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Contact_Email1.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Email"")", Me.DataSource)		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                Me.Req_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt.Text = EvaluateFormula("Format(Today(), ""d"")", Me.DataSource, "g")		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                Me.Req_Enity2.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity2.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Agency"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Enity21()
            
        
            ' Set the Req_Enity2 Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity21 is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity21()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Req_Enity21.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity21.Text = EvaluateFormula("GetColumnValue(""Users"", UserId(), ""Agency"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Funding_Src2()
            
        
            ' Set the Req_Funding_Src2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Funding_Src2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Funding_Src2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Funding_Src2Specified Then
                				
                ' If the Req_Funding_Src2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Funding_Src2)
                              
                Me.Req_Funding_Src2.Text = formattedValue
                
            Else 
            
                ' Req_Funding_Src2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Funding_Src2.Text = Request_MasterTable.Req_Funding_Src2.Format(Request_MasterTable.Req_Funding_Src2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Island()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Req_Island DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Island is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Island()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_IslandSpecified Then
                            
                ' If the Req_Island is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Req_Island
            Else
                
                ' Req_Island is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Req_Island.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateReq_IslandDropDownList(selectedValue, 100)              
                        
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_State is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_State)
                              
                Me.Req_State.Text = formattedValue
                
            Else 
            
                ' Req_State is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_State.Text = EvaluateFormula("""HI""", Me.DataSource)		
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

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Status)
                              
                Me.Req_Status.Text = formattedValue
                
            Else 
            
                ' Req_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Status.Text = EvaluateFormula("""New""", Me.DataSource)		
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
                
        Public Overridable Sub SetRequest_Id()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Request_Id QuickSelector on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Request_Id is the ASP:QuickSelector on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Request_IdSpecified Then
                            
                ' If the Request_Id is non-NULL, then format the value.
                ' The Format method will return the Display Foreign Key As (DFKA) value
                selectedValue = Me.DataSource.Request_Id.ToString()
            Else
                
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Request_Id.DefaultValue
                End If
                				
            End If			
                
            ' Add the Please Select item.
            If selectedValue Is Nothing OrElse selectedValue = ""  Then
                  MiscUtils.ResetSelectedItem(Me.Request_Id, New ListItem(Me.Page.GetResourceValue("Txt:PleaseSelect", "IROC2"), "--PLEASE_SELECT--"))
            End If              
            
            
                  
            ' Populate the item(s) to the control
            
            Me.Request_Id.SetFieldMaxLength(50)
            
            Dim variables As System.Collections.Generic.IDictionary(Of String, Object) 
            variables = New System.Collections.Generic.Dictionary(Of String, Object)              
            Dim evaluator As FormulaEvaluator
            evaluator = New FormulaEvaluator
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Request_Id, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Request_Id, selectedValue)Then

                ' construct a whereclause to query a record with DatabaseIROC%dbo.Contacts.Request_Id = selectedValue
                Dim filter2 As CompoundFilter = New CompoundFilter(CompoundFilter.CompoundingOperators.And_Operator, Nothing)
                Dim whereClause2 As WhereClause = New WhereClause()
                filter2.AddFilter(New BaseClasses.Data.ColumnValueFilter(ContactsTable.Request_Id, selectedValue, BaseClasses.Data.BaseFilter.ComparisonOperator.EqualsTo, False))
                whereClause2.AddFilter(filter2, CompoundFilter.CompoundingOperators.And_Operator)

                Try
                    ' Execute the query
                    Dim rc() As ContactsRecord = ContactsTable.GetRecords(whereClause2, New OrderBy(False, False), 0, 1)
                      Dim vars As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)
                      ' if find a record, add it to the dropdown and set it as selected item
                      If rc IsNot Nothing AndAlso rc.Length = 1 Then
                      Dim itemValue As ContactsRecord = DirectCast(rc(0), ContactsRecord)
                        ' Create the item and add to the list.
                        Dim cvalue As String = Nothing
                        Dim fvalue As String = Nothing
                        If itemValue.Request_IdSpecified Then
                            cvalue = itemValue.Request_Id.ToString() 
                          Dim _isExpandableNonCompositeForeignKey As Boolean = Request_MasterTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(Request_MasterTable.Request_Id)
                          If _isExpandableNonCompositeForeignKey AndAlso Request_MasterTable.Request_Id.IsApplyDisplayAs Then
                          fvalue = Request_MasterTable.GetDFKA(itemValue, Request_MasterTable.Request_Id)
                          End If
                          If (Not _isExpandableNonCompositeForeignKey) Or (String.IsNullOrEmpty(fvalue)) Then
                          fvalue = itemValue.Format(ContactsTable.Request_Id)
                          End If
                        
                              If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = cvalue
                              ResetSelectedItem(Me.Request_Id, New ListItem(fvalue, cvalue))
                            End If
                        End If
                Catch
                End Try

            End If					
                                    
        End Sub
                
        Public Overridable Sub Setlabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.label1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetProv_NameLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Prov_NameLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReg_TypeLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Reg_TypeLabel.Text = "Some value"
                    
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
                
        Public Overridable Sub SetReq_Contact_Email2Label()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Contact_Email2Label.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Contact_EmailLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Contact_EmailLabel.Text = "Some value"
                    
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
                
        Public Overridable Sub SetReq_Funding_SrcLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Funding_SrcLabel.Text = "Some value"
                    
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
                
        Public Overridable Sub SetReq_StateLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StateLabel.Text = "Some value"
                    
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
                
        Public Overridable Sub SetTxtUser_Id()
                  
                      Me.TxtUser_Id.Text = EvaluateFormula("UserId()")
                    
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
                  
                If Request_IdMaxQuery IsNot Nothing AndAlso Request_IdMaxQuery.Initialized Then e.Variables.Add("Request_IdMaxQuery", Request_IdMaxQuery)                                                       
                        
                If Request_IdMaxQuery1 IsNot Nothing AndAlso Request_IdMaxQuery1.Initialized Then e.Variables.Add("Request_IdMaxQuery1", Request_IdMaxQuery1)                                                       
                        
                If Request_IdMaxQuery10 IsNot Nothing AndAlso Request_IdMaxQuery10.Initialized Then e.Variables.Add("Request_IdMaxQuery10", Request_IdMaxQuery10)                                                       
                        
                If Request_IdMaxQuery11 IsNot Nothing AndAlso Request_IdMaxQuery11.Initialized Then e.Variables.Add("Request_IdMaxQuery11", Request_IdMaxQuery11)                                                       
                        
                If Request_IdMaxQuery12 IsNot Nothing AndAlso Request_IdMaxQuery12.Initialized Then e.Variables.Add("Request_IdMaxQuery12", Request_IdMaxQuery12)                                                       
                        
                If Request_IdMaxQuery13 IsNot Nothing AndAlso Request_IdMaxQuery13.Initialized Then e.Variables.Add("Request_IdMaxQuery13", Request_IdMaxQuery13)                                                       
                        
                If Request_IdMaxQuery14 IsNot Nothing AndAlso Request_IdMaxQuery14.Initialized Then e.Variables.Add("Request_IdMaxQuery14", Request_IdMaxQuery14)                                                       
                        
                If Request_IdMaxQuery15 IsNot Nothing AndAlso Request_IdMaxQuery15.Initialized Then e.Variables.Add("Request_IdMaxQuery15", Request_IdMaxQuery15)                                                       
                        
                If Request_IdMaxQuery2 IsNot Nothing AndAlso Request_IdMaxQuery2.Initialized Then e.Variables.Add("Request_IdMaxQuery2", Request_IdMaxQuery2)                                                       
                        
                If Request_IdMaxQuery3 IsNot Nothing AndAlso Request_IdMaxQuery3.Initialized Then e.Variables.Add("Request_IdMaxQuery3", Request_IdMaxQuery3)                                                       
                        
                If Request_IdMaxQuery4 IsNot Nothing AndAlso Request_IdMaxQuery4.Initialized Then e.Variables.Add("Request_IdMaxQuery4", Request_IdMaxQuery4)                                                       
                        
                If Request_IdMaxQuery5 IsNot Nothing AndAlso Request_IdMaxQuery5.Initialized Then e.Variables.Add("Request_IdMaxQuery5", Request_IdMaxQuery5)                                                       
                        
                If Request_IdMaxQuery6 IsNot Nothing AndAlso Request_IdMaxQuery6.Initialized Then e.Variables.Add("Request_IdMaxQuery6", Request_IdMaxQuery6)                                                       
                        
                If Request_IdMaxQuery7 IsNot Nothing AndAlso Request_IdMaxQuery7.Initialized Then e.Variables.Add("Request_IdMaxQuery7", Request_IdMaxQuery7)                                                       
                        
                If Request_IdMaxQuery8 IsNot Nothing AndAlso Request_IdMaxQuery8.Initialized Then e.Variables.Add("Request_IdMaxQuery8", Request_IdMaxQuery8)                                                       
                        
                If Request_IdMaxQuery9 IsNot Nothing AndAlso Request_IdMaxQuery9.Initialized Then e.Variables.Add("Request_IdMaxQuery9", Request_IdMaxQuery9)                                                       
                        
                If Request_IdSumQuery IsNot Nothing AndAlso Request_IdSumQuery.Initialized Then e.Variables.Add("Request_IdSumQuery", Request_IdSumQuery)                                                       
                        
                If Request_IdSumQuery1 IsNot Nothing AndAlso Request_IdSumQuery1.Initialized Then e.Variables.Add("Request_IdSumQuery1", Request_IdSumQuery1)                                                       
                        
                If Request_IdSumQuery2 IsNot Nothing AndAlso Request_IdSumQuery2.Initialized Then e.Variables.Add("Request_IdSumQuery2", Request_IdSumQuery2)                                                       
                        
                If Request_IdSumQuery3 IsNot Nothing AndAlso Request_IdSumQuery3.Initialized Then e.Variables.Add("Request_IdSumQuery3", Request_IdSumQuery3)                                                       
                        
                If Request_IdSumQuery4 IsNot Nothing AndAlso Request_IdSumQuery4.Initialized Then e.Variables.Add("Request_IdSumQuery4", Request_IdSumQuery4)                                                       
                        
                If Request_IdSumQuery5 IsNot Nothing AndAlso Request_IdSumQuery5.Initialized Then e.Variables.Add("Request_IdSumQuery5", Request_IdSumQuery5)                                                       
                        
                If Request_IdSumQuery6 IsNot Nothing AndAlso Request_IdSumQuery6.Initialized Then e.Variables.Add("Request_IdSumQuery6", Request_IdSumQuery6)                                                       
                        
                If Request_IdSumQuery7 IsNot Nothing AndAlso Request_IdSumQuery7.Initialized Then e.Variables.Add("Request_IdSumQuery7", Request_IdSumQuery7)                                                       
                        
                If Role_IDMaxQuery IsNot Nothing AndAlso Role_IDMaxQuery.Initialized Then e.Variables.Add("Role_IDMaxQuery", Role_IDMaxQuery)                                                       
                        
                If Role_IDMaxQuery1 IsNot Nothing AndAlso Role_IDMaxQuery1.Initialized Then e.Variables.Add("Role_IDMaxQuery1", Role_IDMaxQuery1)                                                       
                        
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
        
            GetCat_OTWC_Comments()
            GetICS_CATV_Comments()
            GetICS_SOW_Needed()
            GetLReg_Type1()
            GetLReq_Dt()
            GetOTW_More_Info_Comments()
            GetPending_Action_Dt()
            GetPending_Action_Needed()
            GetPending_Agency()
            GetPriority()
            GetProv_Name()
            GetReg_Type()
            GetReq_Address()
            GetReq_City()
            GetReq_Comments()
            GetReq_Contact_Email()
            GetReq_Contact_Email1()
            GetReq_Dt()
            GetReq_Enity2()
            GetReq_Enity21()
            GetReq_Funding_Src2()
            GetReq_Island()
            GetReq_Site_Name()
            GetReq_State()
            GetReq_Status()
            GetReq_Target_Dt()
            GetReq_Zip()
            GetRequest_Id()
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
                
        Public Overridable Sub GetLReg_Type1()
            
        End Sub
                
        Public Overridable Sub GetLReq_Dt()
            
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Comments()
            
            ' Retrieve the value entered by the user on the OTW_More_Info_Comments ASP:TextBox, and
            ' save it into the OTW_More_Info_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_More_Info_Comments.Text, Request_MasterTable.OTW_More_Info_Comments)			

                      
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
                
        Public Overridable Sub GetPriority()
            
            ' Retrieve the value entered by the user on the Priority ASP:TextBox, and
            ' save it into the Priority field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Priority.Text, Request_MasterTable.Priority)			

                      
        End Sub
                
        Public Overridable Sub GetProv_Name()
         
            ' Retrieve the value entered by the user on the Prov_Name ASP:DropDownList, and
            ' save it into the Prov_Name field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Prov_Name), Request_MasterTable.Prov_Name)				
            
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
                
        Public Overridable Sub GetReq_Contact_Email()
            
            ' Retrieve the value entered by the user on the Req_Contact_Email2 ASP:TextBox, and
            ' save it into the Req_Contact_Email2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Contact_Email.Text, Request_MasterTable.Req_Contact_Email2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Contact_Email1()
            
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
                
        Public Overridable Sub GetReq_Enity2()
            
            ' Retrieve the value entered by the user on the Req_Enity2 ASP:TextBox, and
            ' save it into the Req_Enity2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Enity2.Text, Request_MasterTable.Req_Enity2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Enity21()
            
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src2()
            
            ' Retrieve the value entered by the user on the Req_Funding_Src2 ASP:TextBox, and
            ' save it into the Req_Funding_Src2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Funding_Src2.Text, Request_MasterTable.Req_Funding_Src2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Island()
         
            ' Retrieve the value entered by the user on the Req_Island ASP:DropDownList, and
            ' save it into the Req_Island field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Req_Island), Request_MasterTable.Req_Island)				
            
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
                
        Public Overridable Sub GetRequest_Id()
         
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
                
            HttpContext.Current.Session("QueryString in Add-Request-Master") = recId
                
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
        
        Protected _Request_IdMaxQuery As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery As DataSource          
            Get               
                Return _Request_IdMaxQuery
            End Get
        End Property
       
        Protected _Request_IdMaxQuery1 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery1 As DataSource          
            Get               
                Return _Request_IdMaxQuery1
            End Get
        End Property
       
        Protected _Request_IdMaxQuery10 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery10 As DataSource          
            Get               
                Return _Request_IdMaxQuery10
            End Get
        End Property
       
        Protected _Request_IdMaxQuery11 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery11 As DataSource          
            Get               
                Return _Request_IdMaxQuery11
            End Get
        End Property
       
        Protected _Request_IdMaxQuery12 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery12 As DataSource          
            Get               
                Return _Request_IdMaxQuery12
            End Get
        End Property
       
        Protected _Request_IdMaxQuery13 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery13 As DataSource          
            Get               
                Return _Request_IdMaxQuery13
            End Get
        End Property
       
        Protected _Request_IdMaxQuery14 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery14 As DataSource          
            Get               
                Return _Request_IdMaxQuery14
            End Get
        End Property
       
        Protected _Request_IdMaxQuery15 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery15 As DataSource          
            Get               
                Return _Request_IdMaxQuery15
            End Get
        End Property
       
        Protected _Request_IdMaxQuery2 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery2 As DataSource          
            Get               
                Return _Request_IdMaxQuery2
            End Get
        End Property
       
        Protected _Request_IdMaxQuery3 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery3 As DataSource          
            Get               
                Return _Request_IdMaxQuery3
            End Get
        End Property
       
        Protected _Request_IdMaxQuery4 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery4 As DataSource          
            Get               
                Return _Request_IdMaxQuery4
            End Get
        End Property
       
        Protected _Request_IdMaxQuery5 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery5 As DataSource          
            Get               
                Return _Request_IdMaxQuery5
            End Get
        End Property
       
        Protected _Request_IdMaxQuery6 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery6 As DataSource          
            Get               
                Return _Request_IdMaxQuery6
            End Get
        End Property
       
        Protected _Request_IdMaxQuery7 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery7 As DataSource          
            Get               
                Return _Request_IdMaxQuery7
            End Get
        End Property
       
        Protected _Request_IdMaxQuery8 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery8 As DataSource          
            Get               
                Return _Request_IdMaxQuery8
            End Get
        End Property
       
        Protected _Request_IdMaxQuery9 As New DataSource
        Public Overridable ReadOnly Property Request_IdMaxQuery9 As DataSource          
            Get               
                Return _Request_IdMaxQuery9
            End Get
        End Property
       
        Protected _Request_IdSumQuery As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery As DataSource          
            Get               
                Return _Request_IdSumQuery
            End Get
        End Property
       
        Protected _Request_IdSumQuery1 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery1 As DataSource          
            Get               
                Return _Request_IdSumQuery1
            End Get
        End Property
       
        Protected _Request_IdSumQuery2 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery2 As DataSource          
            Get               
                Return _Request_IdSumQuery2
            End Get
        End Property
       
        Protected _Request_IdSumQuery3 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery3 As DataSource          
            Get               
                Return _Request_IdSumQuery3
            End Get
        End Property
       
        Protected _Request_IdSumQuery4 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery4 As DataSource          
            Get               
                Return _Request_IdSumQuery4
            End Get
        End Property
       
        Protected _Request_IdSumQuery5 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery5 As DataSource          
            Get               
                Return _Request_IdSumQuery5
            End Get
        End Property
       
        Protected _Request_IdSumQuery6 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery6 As DataSource          
            Get               
                Return _Request_IdSumQuery6
            End Get
        End Property
       
        Protected _Request_IdSumQuery7 As New DataSource
        Public Overridable ReadOnly Property Request_IdSumQuery7 As DataSource          
            Get               
                Return _Request_IdSumQuery7
            End Get
        End Property
       
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
       
        Public Overridable Sub LoadData_Request_IdMaxQuery()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery.DataChanged = True
          
              Me._Request_IdMaxQuery.Initialize("Request_IdMaxQuery", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery()
              Me._Request_IdMaxQuery.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery.LoadData(False, Me._Request_IdMaxQuery.PageSize, Me._Request_IdMaxQuery.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery1()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery1.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery1.DataChanged = True
          
              Me._Request_IdMaxQuery1.Initialize("Request_IdMaxQuery1", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery1()
              Me._Request_IdMaxQuery1.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery1.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery1.LoadData(False, Me._Request_IdMaxQuery1.PageSize, Me._Request_IdMaxQuery1.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery10()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery10.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery10.DataChanged = True
          
              Me._Request_IdMaxQuery10.Initialize("Request_IdMaxQuery10", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery10()
              Me._Request_IdMaxQuery10.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery10.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery10.LoadData(False, Me._Request_IdMaxQuery10.PageSize, Me._Request_IdMaxQuery10.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery11()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery11.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery11.DataChanged = True
          
              Me._Request_IdMaxQuery11.Initialize("Request_IdMaxQuery11", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery11()
              Me._Request_IdMaxQuery11.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery11.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery11.LoadData(False, Me._Request_IdMaxQuery11.PageSize, Me._Request_IdMaxQuery11.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery12()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery12.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery12.DataChanged = True
          
              Me._Request_IdMaxQuery12.Initialize("Request_IdMaxQuery12", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery12()
              Me._Request_IdMaxQuery12.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery12.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdMaxQuery12.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery12.LoadData(False, Me._Request_IdMaxQuery12.PageSize, Me._Request_IdMaxQuery12.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery13()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery13.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery13.DataChanged = True
          
              Me._Request_IdMaxQuery13.Initialize("Request_IdMaxQuery13", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery13()
              Me._Request_IdMaxQuery13.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery13.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery13.LoadData(False, Me._Request_IdMaxQuery13.PageSize, Me._Request_IdMaxQuery13.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery14()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery14.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery14.DataChanged = True
          
              Me._Request_IdMaxQuery14.Initialize("Request_IdMaxQuery14", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery14()
              Me._Request_IdMaxQuery14.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery14.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdMaxQuery14.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery14.LoadData(False, Me._Request_IdMaxQuery14.PageSize, Me._Request_IdMaxQuery14.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery15()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery15.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery15.DataChanged = True
          
              Me._Request_IdMaxQuery15.Initialize("Request_IdMaxQuery15", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery15()
              Me._Request_IdMaxQuery15.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery15.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery15.LoadData(False, Me._Request_IdMaxQuery15.PageSize, Me._Request_IdMaxQuery15.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery2()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery2.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery2.DataChanged = True
          
              Me._Request_IdMaxQuery2.Initialize("Request_IdMaxQuery2", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery2()
              Me._Request_IdMaxQuery2.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery2.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery2.LoadData(False, Me._Request_IdMaxQuery2.PageSize, Me._Request_IdMaxQuery2.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery3()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery3.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery3.DataChanged = True
          
              Me._Request_IdMaxQuery3.Initialize("Request_IdMaxQuery3", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery3()
              Me._Request_IdMaxQuery3.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery3.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery3.LoadData(False, Me._Request_IdMaxQuery3.PageSize, Me._Request_IdMaxQuery3.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery4()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery4.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery4.DataChanged = True
          
              Me._Request_IdMaxQuery4.Initialize("Request_IdMaxQuery4", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery4()
              Me._Request_IdMaxQuery4.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery4.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdMaxQuery4.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery4.LoadData(False, Me._Request_IdMaxQuery4.PageSize, Me._Request_IdMaxQuery4.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery5()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery5.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery5.DataChanged = True
          
              Me._Request_IdMaxQuery5.Initialize("Request_IdMaxQuery5", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery5()
              Me._Request_IdMaxQuery5.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery5.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery5.LoadData(False, Me._Request_IdMaxQuery5.PageSize, Me._Request_IdMaxQuery5.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery6()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery6.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery6.DataChanged = True
          
              Me._Request_IdMaxQuery6.Initialize("Request_IdMaxQuery6", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery6()
              Me._Request_IdMaxQuery6.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery6.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdMaxQuery6.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery6.LoadData(False, Me._Request_IdMaxQuery6.PageSize, Me._Request_IdMaxQuery6.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery7()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery7.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery7.DataChanged = True
          
              Me._Request_IdMaxQuery7.Initialize("Request_IdMaxQuery7", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery7()
              Me._Request_IdMaxQuery7.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery7.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery7.LoadData(False, Me._Request_IdMaxQuery7.PageSize, Me._Request_IdMaxQuery7.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery8()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery8.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery8.DataChanged = True
          
              Me._Request_IdMaxQuery8.Initialize("Request_IdMaxQuery8", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery8()
              Me._Request_IdMaxQuery8.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery8.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery8.LoadData(False, Me._Request_IdMaxQuery8.PageSize, Me._Request_IdMaxQuery8.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdMaxQuery9()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdMaxQuery9.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdMaxQuery9.DataChanged = True
          
              Me._Request_IdMaxQuery9.Initialize("Request_IdMaxQuery9", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdMaxQuery9()
              Me._Request_IdMaxQuery9.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdMaxQuery9.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdMax"))
              
              ' Define joins if there are any
          
              Me._Request_IdMaxQuery9.LoadData(False, Me._Request_IdMaxQuery9.PageSize, Me._Request_IdMaxQuery9.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery.DataChanged = True
          
              Me._Request_IdSumQuery.Initialize("Request_IdSumQuery", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery()
              Me._Request_IdSumQuery.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery.LoadData(False, Me._Request_IdSumQuery.PageSize, Me._Request_IdSumQuery.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery1()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery1.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery1.DataChanged = True
          
              Me._Request_IdSumQuery1.Initialize("Request_IdSumQuery1", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery1()
              Me._Request_IdSumQuery1.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery1.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery1.LoadData(False, Me._Request_IdSumQuery1.PageSize, Me._Request_IdSumQuery1.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery2()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery2.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery2.DataChanged = True
          
              Me._Request_IdSumQuery2.Initialize("Request_IdSumQuery2", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery2()
              Me._Request_IdSumQuery2.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery2.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery2.LoadData(False, Me._Request_IdSumQuery2.PageSize, Me._Request_IdSumQuery2.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery3()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery3.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery3.DataChanged = True
          
              Me._Request_IdSumQuery3.Initialize("Request_IdSumQuery3", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery3()
              Me._Request_IdSumQuery3.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery3.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdSumQuery3.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery3.LoadData(False, Me._Request_IdSumQuery3.PageSize, Me._Request_IdSumQuery3.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery4()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery4.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery4.DataChanged = True
          
              Me._Request_IdSumQuery4.Initialize("Request_IdSumQuery4", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery4()
              Me._Request_IdSumQuery4.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery4.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery4.LoadData(False, Me._Request_IdSumQuery4.PageSize, Me._Request_IdSumQuery4.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery5()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery5.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery5.DataChanged = True
          
              Me._Request_IdSumQuery5.Initialize("Request_IdSumQuery5", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery5()
              Me._Request_IdSumQuery5.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery5.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery5.LoadData(False, Me._Request_IdSumQuery5.PageSize, Me._Request_IdSumQuery5.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery6()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery6.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery6.DataChanged = True
          
              Me._Request_IdSumQuery6.Initialize("Request_IdSumQuery6", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery6()
              Me._Request_IdSumQuery6.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery6.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery6.LoadData(False, Me._Request_IdSumQuery6.PageSize, Me._Request_IdSumQuery6.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Request_IdSumQuery7()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Request_IdSumQuery7.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Request_IdSumQuery7.DataChanged = True
          
              Me._Request_IdSumQuery7.Initialize("Request_IdSumQuery7", Request_MasterTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Request_IdSumQuery7()
              Me._Request_IdSumQuery7.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Request_IdSumQuery7.AddSelectItem(New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, False, "", ""))
              
              Me._Request_IdSumQuery7.AddSelectItem(New SelectItem(SelectItem.Operation.SUM, New SelectItem(Request_MasterTable.Request_Id, Request_MasterTable.Instance, false, "", ""), "Request_IdSum"))
              
              ' Define joins if there are any
          
              Me._Request_IdSumQuery7.LoadData(False, Me._Request_IdSumQuery7.PageSize, Me._Request_IdSumQuery7.PageIndex)                       
          
              
        End Sub
      
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
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery1() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery10() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery11() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery12() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery13() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery14() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery15() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery2() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery3() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery4() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery5() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery6() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery7() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery8() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdMaxQuery9() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery1() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery2() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery3() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery4() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery5() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery6() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Request_IdSumQuery7() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
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
                                
                
			Me.Page.Authorize(Ctype(LReg_Type1, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Reg_Type, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Contact_Email, Control), "1;34")
					
			Me.Page.Authorize(Ctype(Req_Contact_Email1, Control), "2;22;23;25;26;27;28;29;30;31")
					
			Me.Page.Authorize(Ctype(Req_Contact_Email2Label, Control), "22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Req_Contact_EmailLabel, Control), "1;34")
					
			Me.Page.Authorize(Ctype(Req_Enity2, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Enity21, Control), "2;22;23;25;26;27;28;29;30;31;32;33")
					
			Me.Page.Authorize(Ctype(Request_Id, Control), "1")
											
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
            
                        
        Public Overridable Function CreateWhereClause_Prov_NameDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_Req_IslandDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
        ' Fill the Prov_Name list.
        Protected Overridable Sub PopulateProv_NameDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Prov_Name.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Prov_Name.Items.Add(New ListItem(Me.Page.ExpandResourceValue("OTWC"), "OTWC"))
                            							
            Me.Prov_Name.Items.Add(New ListItem(Me.Page.ExpandResourceValue("HTSC"), "HTSC"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Prov_Name, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Prov_Name, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Prov_Name, Request_MasterTable.Prov_Name.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Prov_Name.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Prov_Name, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        ' Fill the Req_Island list.
        Protected Overridable Sub PopulateReq_IslandDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Req_Island.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Oahu"), "Oahu"))
                            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Hawaii"), "Hawaii"))
                            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Maui"), "Maui"))
                            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Lanai"), "Lanai"))
                            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Molokai"), "Molokai"))
                            							
            Me.Req_Island.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Kauai"), "Kauai"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Req_Island, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Req_Island, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Req_Island, Request_MasterTable.Req_Island.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Req_Island.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Req_Island, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        Protected Overridable Sub Request_Id_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)


          									
                
                
        End Sub
                      
                    
        Protected Overridable Sub Prov_Name_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Prov_Name.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Prov_Name.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Prov_Name.Items.Add(New ListItem(displayText, val))
                Me.Prov_Name.SelectedIndex = Me.Prov_Name.Items.Count - 1
                Me.Page.Session.Remove(Prov_Name.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Prov_Name.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Req_Island_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Req_Island.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Req_Island.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Req_Island.Items.Add(New ListItem(displayText, val))
                Me.Req_Island.SelectedIndex = Me.Req_Island.Items.Count - 1
                Me.Page.Session.Remove(Req_Island.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Req_Island.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub ICS_SOW_Needed_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_OTWC_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub ICS_CATV_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_More_Info_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Needed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
            
        Protected Overridable Sub Req_Contact_Email_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Enity2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Funding_Src2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
            		
        Protected Overridable Sub TxtUser_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
             
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
        
        Public ReadOnly Property Cat_OTWC_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_Comments"), System.Web.UI.WebControls.TextBox)
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
            
        Public ReadOnly Property label1() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "label1"), System.Web.UI.WebControls.Label)
            End Get
        End Property
        
        Public ReadOnly Property LReg_Type1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReg_Type1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property LReq_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "LReq_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_Needed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Agency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Priority() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Priority"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Prov_Name() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_Name"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property Prov_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel"), System.Web.UI.WebControls.Literal)
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
            
        Public ReadOnly Property Req_Contact_Email() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Contact_Email1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Contact_Email2Label() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email2Label"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Contact_EmailLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_EmailLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property Req_Enity2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Enity21() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity21"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Req_Enity2Label() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2Label"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_Src2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_SrcLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_SrcLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Island() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property Req_IslandLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel"), System.Web.UI.WebControls.Literal)
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
        
        Public ReadOnly Property TxtUser_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TxtUser_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
              Public ReadOnly Property Request_Id() As BaseClasses.Web.UI.WebControls.QuickSelector
                  Get
                      Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), BaseClasses.Web.UI.WebControls.QuickSelector)
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

  