
' This file implements the code-behind class for Edit_Request_Master.aspx.
' App_Code\Copy_of_Edit_Request_Master1.Controls.vb contains the Table, Row and Record control classes
' for the page.  Best practices calls for overriding methods in the Row or Record control classes.

#Region "Imports statements"

Option Strict On
Imports System
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
        
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Utils.StringUtils
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports BaseClasses.Data.OrderByItem.OrderDir
Imports BaseClasses.Data.BaseFilter
Imports BaseClasses.Data.BaseFilter.ComparisonOperator
Imports BaseClasses.Web.UI.WebControls
        
Imports IROC2.Business
Imports IROC2.Data
        

#End Region

  
Namespace IROC2.UI
  
Partial Public Class Edit_Request_Master
        Inherits BaseApplicationPage
' Code-behind class for the Edit_Request_Master page.
' Place your customizations in Section 1. Do not modify Section 2.
        
#Region "Section 1: Place your customizations here."



      Public Sub SetPageFocus()
      'load scripts to all controls on page so that they will retain focus on PostBack
      Me.LoadFocusScripts(Me.Page)	  
          'To set focus on page load to a specific control pass this control to the SetStartupFocus method. To get a hold of  a control
          'use FindControlRecursively method. For example:
          'Dim controlToFocus As System.Web.UI.WebControls.TextBox = DirectCast(Me.FindControlRecursively("ProductsSearch"), System.Web.UI.WebControls.TextBox)
          'Me.SetFocusOnLoad(controlToFocus)
          'If no control is passed or control does not exist this method will set focus on the first focusable control on the page.
          Me.SetFocusOnLoad()  
      End Sub
       
      Public Sub LoadData()
          ' LoadData reads database data and assigns it to UI controls.
          ' Customize by adding code before or after the call to LoadData_Base()
          ' or replace the call to LoadData_Base().
          LoadData_Base()
                  
      End Sub
      
      Private Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS as Boolean) As String
          Return EvaluateFormula_Base(formula, dataSourceForEvaluate, format, variables, includeDS)
      End Function

      Public Sub Page_InitializeEventHandlers(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ' Handles MyBase.Init. 
            ' Register the Event handler for any Events.
           Me.Page_InitializeEventHandlers_Base(sender,e)
      End Sub
      
        Protected Overrides Sub SaveControlsToSession()
            SaveControlsToSession_Base()
        End Sub


        Protected Overrides Sub ClearControlsFromSession()
            ClearControlsFromSession_Base()
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            LoadViewState_Base(savedState)
        End Sub


        Protected Overrides Function SaveViewState() As Object
            Return SaveViewState_Base()
        End Function
      
      Public Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
	            '--Ryee Load Buttons
            Me.Page.Session("MyPending_Agency1SessionVariable") = EvaluateFormula("Request_MasterRecordControl.Pending_Agency1.Text")
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
            role = Right(role, 2)
            If role = ";2" And Me.Cat_Cost_Free1.Checked = False Then
                Me.Cat_Cost_FreeLabel1.Visible = False
                Me.Cat_Cost_Free1.Visible = False
            End If
            Me.Page_PreRender_Base(sender, e)
            Me.Button_Submit.Visible = False
            Me.Button_More_Info.Visible = False
            Me.Button_SOW_Done.Visible = False
            Me.Button_CATV_Reviewd.Visible = False
            Me.Button_PROV_Work_Completed.Visible = False
            Me.Button_PROV_Entered_Target_Dt.Visible = False
            Me.Button_PROV_Send_Deploy_Status.Visible = False
            Me.Button_PROV_Send_Quote.Visible = False
            Me.Button_Req_Cancel.Visible = False
            Me.Button_Req_New_Quote.Visible = False
            Me.Button_Prov_Payment_Received.Visible = False
            Me.Button_Req_PO_Entered.Visible = False
            Me.Button_No_Cost.Visible = False
            Me.Button_Provided_Info.Visible = False
            Me.Button_PROV_Entered_Invoice_Info.Visible = False
            Me.Button_Req_Quote_Accepted.Visible = False
            Me.Button_Req_Cancel.Visible = False
            Me.Button_Prov_Connect_INET.Visible = False
            Me.Button_Req_Complete.Visible = False
            Me.Req_Completed_Dt.Visible = False
            Me.Req_Completed_Dt.Enabled = False
            Me.Cat_OTWC_Comments.Text = "catv@dcca.hawaii.gov, " & Get_Email("CATV") 'Email BCC:
            If Pending_Action_Needed1.Text = "More Info Needed" Then
                Me.Button_Provided_Info.Visible = True
            Else
                Me.Button_More_Info.Visible = True
                Me.Pending_Agency_Return.Text = ""
                Me.Req_Comments.Text = ""
                If Me.Pending_Action_Needed1.Text = "Enter Contact" Then
                    Me.Button_Submit.Visible = True
                ElseIf Me.Pending_Action_Needed1.Text = "SOW Needed" Then
                    Me.Button_SOW_Done.Visible = True
                ElseIf Me.Pending_Action_Needed1.Text = "Review Request" Then
                    Me.Pending_Agency_Return.Text = ""
                    Me.Button_CATV_Reviewd.Visible = True
                ElseIf Me.Pending_Action_Needed1.Text = "Close Request" Or Me.Pending_Action_Needed1.Text = "Cancel Request" Then
                    Me.Button_Req_Complete.Visible = True
                    Me.Req_Completed_Dt.Visible = True
                    Me.Req_Completed_Dt.Enabled = True
                ElseIf Me.Pending_Action_Needed1.Text = "Quote Review" Then
                    Me.Button_Req_Quote_Accepted.Visible = True
                    Me.Button_Req_New_Quote.Visible = True
                    Me.Button_Req_Cancel.Visible = True
                ElseIf Me.Pending_Action_Needed1.Text = "Enter P.O. Info" Then
                    Me.Button_Req_PO_Entered.Visible = True
                    If Me.Cat_Cost_Free1.Checked Then
                        Me.Button_No_Cost.Visible = True
                    End If
                    Me.SaveButton.Visible = True
                ElseIf Me.Pending_Action_Needed1.Text = "Connect To INET" Then
                    Me.Button_Prov_Connect_INET.Visible = True
                ElseIf Me.Pending_Agency1.Text = "OTWC" Or Me.Pending_Agency1.Text = "HTSC" Then
                    If Me.Pending_Action_Needed1.Text = "Quote Needed" Then
                        Me.Button_PROV_Send_Quote.Visible = True
                    ElseIf Me.Pending_Action_Needed1.Text = "Enter Target Dates" Then
                        Me.Button_PROV_Entered_Target_Dt.Visible = True
                    ElseIf Me.Pending_Action_Needed1.Text = "Status Or Complete" Then
                        Me.Button_PROV_Send_Deploy_Status.Visible = True
                        Me.Button_PROV_Work_Completed.Visible = True
                        Me.SaveButton.Visible = True
                    ElseIf Me.Pending_Action_Needed1.Text = "Enter Invoice Info" Then
                        Me.Button_PROV_Entered_Invoice_Info.Visible = True
                    ElseIf Me.Pending_Action_Needed1.Text = "Enter Payment Info" Then
                        Me.Button_Prov_Payment_Received.Visible = True
                    End If
                End If
            End If
        End Sub




        Public Overrides Sub SaveData()
            Me.SaveData_Base()
        End Sub



        Public Overrides Sub SetChartControl(ByVal chartCtrlName As String)
            Me.SetChartControl_Base(chartCtrlName)
        End Sub


        Public Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            'Override call to PreInit_Base() here to change top level master page used by this page.
            'For example for SharePoint applications uncomment next line to use Microsoft SharePoint default master page
            'If Not Me.Master Is Nothing Then Me.Master.MasterPageFile = Microsoft.SharePoint.SPContext.Current.Web.MasterUrl	
            'You may change here assignment of application theme
            Try
                Me.PreInit_Base()
            Catch ex As Exception

            End Try
        End Sub

#Region "Ajax Functions"

        <Services.WebMethod()> _
        Public Shared Function GetRecordFieldValue(ByVal tableName As String, _
                                                  ByVal recordID As String, _
                                                  ByVal columnName As String, _
                                                  ByVal fieldName As String, _
                                                  ByVal title As String, _
                                                  ByVal closeBtnText As String, _
                                                  ByVal persist As Boolean, _
                                                  ByVal popupWindowHeight As Integer, _
                                                  ByVal popupWindowWidth As Integer, _
                                                  ByVal popupWindowScrollBar As Boolean _
                                                  ) As Object()
            ' GetRecordFieldValue gets the pop up window content from the column specified by
            ' columnName in the record specified by the recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetRecordFieldValue_Base()
            ' or replace the call to  GetRecordFieldValue_Base().
            Return GetRecordFieldValue_Base(tableName, recordID, columnName, fieldName, title, closeBtnText, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        <Services.WebMethod()> _
        Public Shared Function GetImage(ByVal tableName As String, _
                                        ByVal recordID As String, _
                                        ByVal columnName As String, _
                                        ByVal title As String, _
                                        ByVal closeBtnText As String, _
                                        ByVal persist As Boolean, _
                                        ByVal popupWindowHeight As Integer, _
                                        ByVal popupWindowWidth As Integer, _
                                        ByVal popupWindowScrollBar As Boolean _
                                        ) As Object()
            ' GetImage gets the Image url for the image in the column "columnName" and
            ' in the record specified by recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetImage_Base()
            ' or replace the call to  GetImage_Base().
            Return GetImage_Base(tableName, recordID, columnName, title, closeBtnText, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        Protected Overloads Overrides Sub BasePage_PreRender(ByVal sender As Object, ByVal e As EventArgs)
            MyBase.BasePage_PreRender(sender, e)
            Base_RegisterPostback()
        End Sub





#End Region

        ' Page Event Handlers - buttons, sort, links

        Public Sub CancelButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for CancelButton.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            CancelButton_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

        Public Sub SaveButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for SaveButton.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.

            Dim x As String = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Scheduled_Deploy_Dt"")")
            If x <> "" And Me.Pending_Agency1.Text = Me.Prov_Name.Text Then
                If Mid(x, 6, 1) = "/" Then
                    x = Left(x, 10)
                ElseIf Mid(x, 5, 1) = "/" Then
                    x = Left(x, 9)
                ElseIf Mid(x, 4, 1) = "/" Then
                    x = Left(x, 8)
                End If
                x = x.Trim
                If Me.OTW_Scheduled_Deploy_Dt.Text <> x Then
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Target Start Date Has Changed.  Not Allowed For Save Button.")
                    Exit Sub
                End If
                x = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Projected_Deploy_Dt"")")
                If Mid(x, 6, 1) = "/" Then
                    x = Left(x, 10)
                ElseIf Mid(x, 5, 1) = "/" Then
                    x = Left(x, 9)
                ElseIf Mid(x, 4, 1) = "/" Then
                    x = Left(x, 8)
                End If
                x = x.Trim
                If Me.OTW_Projected_Deploy_Dt.Text <> x Then
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Target Completion Date Has Changed.  Not Allowed For Save Button.")
                    Exit Sub
                End If
            End If
            SaveButton_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub


        ' Write out the Set methods


        ' Write out the methods for DataSource

		Public Sub Button_Req_Quote_Accepted_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Req_Quote_Accepted.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            Me.Req_Status.Text = "Quote OK"  '--RY
            Me.Req_Quote_Approved.Text = CStr(Now())
            Me.Pending_Action_Needed1.Text = "Enter P.O. Info"
            If Me.Reg_Type1.Text.Trim = Me.Req_Enity2.Text.Trim Then  'Enity is Reqester.
              Me.Pending_Agency1.Text = Me.Req_Enity2.Text.Trim
          	Else
              Me.Pending_Agency1.Text = "Requester"			
         	End If
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Quote_Approved.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_Req_Quote_Accepted_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub


        Public Sub Button_Req_New_Quote_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Req_New_Quote.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            Me.Req_Status.Text = "Get Quote"  '--RY
            Me.Pending_Action_Needed1.Text = "Quote Needed"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email(Me.Prov_Name.Text)  'Email TO: Provider
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_Req_New_Quote_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_Req_Cancel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Req_Cancel.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            Me.Req_Status.Text = "Pre_Cancel"  '--RY
            Me.Pending_Action_Needed1.Text = "Cancel Request"
            Me.Pending_Agency1.Text = "CATV"
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Completed_Dt.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email("CATV") 'Email TO: CATV
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Requester & Entity & Provider
            Button_Req_Cancel_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
		Public Sub Button_PROV_Send_Quote_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_PROV_Send_Quote.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If EvaluateFormula("Session(""MyUPLOAD_Quote"")") = "" Then  '--Ryee
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Quote Upload Document!  Click Save. Then Retry.")
                Exit Sub
            End If
            Me.Req_Status.Text = "Quote Sent"
            Me.Pending_Action_Needed1.Text = "Quote Review"
           	If Me.Reg_Type1.Text.Trim = Me.Req_Enity2.Text.Trim Then  'Enity is Reqester.
                Me.Pending_Agency1.Text = Me.Req_Enity2.Text.Trim
            Else
                Me.Pending_Agency1.Text = "Requester"			
            End If
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Enity & Provider
            Button_PROV_Send_Quote_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
		Public Sub Button_PROV_Send_Deploy_Status_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_PROV_Send_Deploy_Status.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.OTW_Permit_Status.Text = "" Then  '--Ryee
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Permit Status!")
                Exit Sub
            ElseIf Me.OTW_Construction_Status.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Construction Status!")
                Exit Sub
            End If
            Dim x As String = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Scheduled_Deploy_Dt"")")
            If Mid(x, 6, 1) = "/" Then
                x = Left(x, 10)
            ElseIf Mid(x, 5, 1) = "/" Then
                x = Left(x, 9)
            ElseIf Mid(x, 4, 1) = "/" Then
                x = Left(x, 8)
            End If
            x = x.Trim
            If Me.OTW_Scheduled_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = "** Target Start Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Scheduled_Deploy_Dt.Text & ".  Reasons: "
            End If
            'x = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Projected_Deploy_Dt"")")
            'If Mid(x, 6, 1) = "/" Then
            '    x = Left(x, 10)
            'ElseIf Mid(x, 5, 1) = "/" Then
            '    x = Left(x, 9)
            'ElseIf Mid(x, 4, 1) = "/" Then
            '    x = Left(x, 8)
            'End If
            'x = x.Trim
            'If Me.OTW_Projected_Deploy_Dt.Text <> x Then
            '    Me.OTW_More_Info_Comments.Text = Me.OTW_More_Info_Comments.Text & "** Target Completion Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Projected_Deploy_Dt.Text & ".  Reasons: "
            'End If
            Me.Req_Status.Text = "INET Work"
            Me.Pending_Action_Needed1.Text = "Status Or Complete"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email(Me.Prov_Name.Text)  'Email TO: Provider
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_PROV_Send_Deploy_Status_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

        Public Sub Button_CATV_Reviewd_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_CATV_Reviewd.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.Cat_Franchise_Order_Number2.Text = "--PLEASE_SELECT--" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Need to Set Franchise Order Number!")
                Exit Sub
            End If
            Me.Req_Status.Text = "Get Quote"  '--RY
            Me.Pending_Action_Needed1.Text = "Quote Needed"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email(Me.Prov_Name.Text)  'Email TO: Provider
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_CATV_Reviewd_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

		Public Sub Button_Provided_Info_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Provided_Info.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            Dim a As String

            Me.Req_Status.Text = Pending_Prev_Status.Text   '--RY
            Me.Pending_Action_Needed1.Text = Me.Pending_Prev_Action_Needed.Text
            a = Me.Pending_Agency1.Text
            Me.Pending_Agency1.Text = Me.Pending_Agency_Return.Text
            Me.Pending_Agency_Return.Text = a
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Pending_Prev_Status.Text = ""
            Me.Pending_Prev_Action_Needed.Text = ""
            Me.Req_Comments.Text = Get_Email(Me.Pending_Agency1.Text)
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Pending_Agency_Return.Text)
            Button_Provided_Info_Click_Base(sender, args)

            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

		Public Sub Button_SOW_Done_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_SOW_Done.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If ICS_SOW_Needed.Checked = True Then
                If Me.ICS_SOW_Uploaded.Checked = False Then
                    Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "SOW Upload Misssing!")
                    Exit Sub
                End If
            End If
            Me.Req_Status.Text = "Review" '--RY
            'Me.Pending_Agency_Return.Text = Me.Pending_Agency1.Text
            Me.Pending_Agency1.Text = "CATV"
            Me.Pending_Action_Needed1.Text = "Review Request"
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email("CATV") 'Email TO: CATV
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_SOW_Done_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_Req_Complete_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Req_Complete.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.Pending_Action_Needed1.Text = "Cancel Request" Then
                Me.Req_Status.Text = "Canceled"
            Else
                Me.Req_Status.Text = "Completed"  '--RY
            End If
            Me.Pending_Action_Needed1.Text = ""
            Me.Pending_Agency1.Text = ""
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Completed_Dt.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_Req_Complete_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        '
        Public Sub Button_More_Info_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_More_Info.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            'Me.Req_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email("CATV") & ", " & Get_Email(Me.Pending_Agency_Return.Text)
            Button_More_Info_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Private Function Get_Email(ByVal agency As String) As String  '--Ryee
            If Me.Role_IDMaxControl.Text = "" Then
                Get_Email = ""
                Exit Function
            End If
            Dim max As Integer = CInt(Me.Role_IDMaxControl.Text) + 1
            Dim i As Integer
            Dim r As String
            Get_Email = ""
            If agency = "Requester" Then
                Get_Email = Me.Req_Contact_Email.Text
            Else
                For i = 1 To max
                    r = EvaluateFormula("GetColumnValue(""Role""," & i & ", ""Role_Name"")")
                    If agency = r Then
                        r = EvaluateFormula("GetColumnValue(""Role""," & i & ", ""Role_Email"")")
                        Get_Email = r
                        Exit For
                    End If
                Next
            End If
        End Function

		Public Sub Button_Submit_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Submit.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            Me.Pending_Action_Dt1.Text = System.DateTime.Now.ToShortDateString
            Me.Pending_Agency1.Text = Me.Reg_Type1.Text
            Me.Pending_Action_Needed1.Text = "SOW Needed"
            Me.Req_Comments.Text = Get_Email(Me.Reg_Type1.Text)  'Email TO: Entity
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text 'Email CC: Requester & Provider
            Button_Submit_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub



        Public Sub Button_Req_PO_Entered_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Req_PO_Entered.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            '--Ryee 
            If Me.Req_PO_No.Text = "" Or Me.Req_PO_Amt.Text = "" Or Me.Req_PO_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "PO Info Missing!")
                Exit Sub
            End If
            If CInt(Me.Req_PO_Amt.Text) < 1 Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "PO Amount Must Can't Be Zero!")
                Exit Sub
            End If
            Me.Req_Status.Text = "Schedule"  '--RY
            Me.Pending_Action_Needed1.Text = "Enter Target Dates"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email(Me.Prov_Name.Text)  'Email TO: Provider
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_Req_PO_Entered_Click_Base(sender, args)

            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_No_Cost_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_No_Cost.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            '--Ryee
            If Me.Cat_Cost_Free.Checked = False Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "This is an INET Benefit Project, PO is required!")
                Exit Sub
            End If
            Me.Req_Status.Text = "Schedule"  '--RY
            Me.Pending_Action_Needed1.Text = "Enter Target Dates"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email(Me.Prov_Name.Text)  'Email TO: Provider
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text)  'Email CC: Requester & Entity
            Button_No_Cost_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

		Public Sub Button_PROV_Work_Completed_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_PROV_Work_Completed.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.OTW_Permit_Status.Text = "" Then  '--Ryee
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Permit Status!")
                Exit Sub
            ElseIf Me.OTW_Construction_Status.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Construction Status!")
                Exit Sub
            ElseIf Me.OTW_Deployment_Start_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Actual Start Date!")
                Exit Sub
            ElseIf Me.OTW_Completed_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing Completion Date!")
                Exit Sub
            End If
            Dim x As String = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Scheduled_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Scheduled_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = "Target Start Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Scheduled_Deploy_Dt.Text & ".  Reasons: "
            End If
            x = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Projected_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Projected_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = Me.OTW_More_Info_Comments.Text & "Target Completion Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Projected_Deploy_Dt.Text & ".  Reasons: "
            End If
            If Me.Cat_Cost_Free.Checked = True Then
                Me.OTW_Invoice_No.Text = "INET Benft"
                'Me.OTW_Invoice_Dt.Text = Me.OTW_Completed_Dt.Text
                Me.OTW_Invoice_Amt.Text = "0"
                'Me.Req_Pymt_Dt.Text = Me.OTW_Completed_Dt.Text
                Me.Req_Pymt_Amt.Text = "0"
                Me.Req_Status.Text = "Pmt Done"
                Me.Pending_Action_Needed1.Text = "Connect To INET"
                If Me.Reg_Type1.Text.Trim = Me.Req_Enity2.Text.Trim Then  'Enity is Reqester.
              		Me.Pending_Agency1.Text = Me.Req_Enity2.Text.Trim
          		Else
              		Me.Pending_Agency1.Text = "Requester"			
          		End If
                Me.Pending_Action_Dt1.Text = CStr(Now())
                Me.OTW_More_Info_Comments.Text = Me.OTW_More_Info_Comments.Text & "** Invoice and Payment Is Not Required Because Project Cost Is Free."
            Else
                Me.Req_Status.Text = "Work Done"
                Me.Pending_Action_Needed1.Text = "Enter Invoice Info"
                Me.Pending_Agency1.Text = Me.Prov_Name.Text
                Me.Pending_Action_Dt1.Text = CStr(Now())
            End If
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_PROV_Work_Completed_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_PROV_Entered_Target_Dt_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_PROV_Entered_Target_Dt.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.OTW_Scheduled_Deploy_Dt.Text = "" Then '--RYee
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Target Start Date Missing!")
                Exit Sub
            End If
            If Me.OTW_Projected_Deploy_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Target Completion Date Missing!")
                Exit Sub
            End If
            Me.Req_Status.Text = "INET Work"
            Me.Pending_Action_Needed1.Text = "Status Or Complete"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_PROV_Entered_Target_Dt_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_PROV_Entered_Invoice_Info_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_PROV_Entered_Invoice_Info.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.OTW_Invoice_No.Text = "" Or Me.OTW_Invoice_Amt.Text = "" Or Me.OTW_Invoice_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Invoice Info Missing!")
                Exit Sub
            End If
            Dim x As String = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Scheduled_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Scheduled_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = "** Target Start Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Scheduled_Deploy_Dt.Text & ".  Reasons: "
            End If
            x = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Projected_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Projected_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = Me.OTW_More_Info_Comments.Text & "** Target Completion Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Projected_Deploy_Dt.Text & ".  Reasons: "
            End If
            Me.Req_Status.Text = "Need Pymt"  '--RY
            Me.Pending_Action_Needed1.Text = "Enter Payment Info"
            Me.Pending_Agency1.Text = Me.Prov_Name.Text
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_PROV_Entered_Invoice_Info_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

		Public Sub Button_Prov_Payment_Received_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Prov_Payment_Received.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            If Me.Req_Pymt_Amt.Text = "" Or Me.Req_Pymt_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Payment Info Missing!")
                Exit Sub
            End If
            Dim x As String = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Scheduled_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Scheduled_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = "** Target Start Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Scheduled_Deploy_Dt.Text & ".  Reasons: "
            End If
            x = EvaluateFormula("GetColumnValue(""Request_Master"", URL(""Request_Master""), ""OTW_Projected_Deploy_Dt"")")
            x = Left(x, 10)
            x = x.Trim
            If Me.OTW_Projected_Deploy_Dt.Text <> x Then
                Me.OTW_More_Info_Comments.Text = Me.OTW_More_Info_Comments.Text & "** Target Completion Date Has Changed. Old Date: " & x & "  New Date: " & Me.OTW_Projected_Deploy_Dt.Text & ".  Reasons: "
            End If
            Me.Req_Status.Text = "Pmt Done"  '--RY
            Me.Pending_Action_Needed1.Text = "Connect To INET"
            If Me.Reg_Type1.Text.Trim = Me.Req_Enity2.Text.Trim Then  'Enity is Reqester.
            	Me.Pending_Agency1.Text = Me.Req_Enity2.Text.Trim
          	Else
              	Me.Pending_Agency1.Text = "Requester"			
          	End If
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Me.Req_Contact_Email.Text 'Email TO: Requester
            Me.ICS_CATV_Comments.Text = Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Entity & Provider
            Button_Prov_Payment_Received_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
        Public Sub Button_Prov_Connect_INET_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for Button_Prov_Connect_INET.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            '--Ryee
            If Me.OTW_On_Net_Dt.Text = "" Then
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "Missing On-INET Date!")
                Exit Sub
            End If
            Me.Req_Status.Text = "On-INET"  '--RY
            Me.Pending_Action_Needed1.Text = "Close Request"
            Me.Pending_Agency1.Text = "CATV"
            Me.Pending_Action_Dt1.Text = CStr(Now())
            Me.Req_Comments.Text = Get_Email("CATV") 'Email TO: CATV
            Me.ICS_CATV_Comments.Text = Me.Req_Contact_Email.Text & ", " & Get_Email(Me.Reg_Type1.Text) & ", " & Get_Email(Me.Prov_Name.Text)  'Email CC: Requester & Entity & Provider
            Button_Prov_Connect_INET_Click_Base(sender, args)
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub


'        Public Sub SendEmailOnButton_Submit_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_Submit_Click_Base()
'        End Sub
        Public Sub SendEmailOnButton_Provided_Info_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Provided_Info_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_SOW_Done_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_SOW_Done_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_CATV_Reviewd_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_CATV_Reviewd_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_PROV_Send_Quote_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_PROV_Send_Quote_Click_Base()
        End Sub
' 
        Public Sub SendEmailOnButton_PROV_Entered_Target_Dt_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_PROV_Entered_Target_Dt_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_PROV_Send_Deploy_Status_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_PROV_Send_Deploy_Status_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_PROV_Work_Completed_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_PROV_Work_Completed_Click_Base()
        End Sub
'        Public Sub SendEmailOnButton_PROV_Entered_Invoice_Info_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_PROV_Entered_Invoice_Info_Click_Base()
'        End Sub
        Public Sub SendEmailOnButton_Prov_Payment_Received_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Prov_Payment_Received_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_Prov_Connect_INET_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Prov_Connect_INET_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_Req_Complete_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Req_Complete_Click_Base()
        End Sub
        Public Sub SendEmailOnButton_Req_New_Quote_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Req_New_Quote_Click_Base()
        End Sub
'Public Sub SendEmailOnButton_Submit_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_Submit_Click_Base()
'        End Sub
Public Sub SendEmailOnButton_Submit_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Submit_Click_Base()
        End Sub
Public Sub SendEmailOnButton_Req_Quote_Accepted_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Req_Quote_Accepted_Click_Base()
        End Sub
'Public Sub SendEmailOnButton_PROV_Entered_Invoice_Info_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_PROV_Entered_Invoice_Info_Click_Base()
'        End Sub
'Public Sub SendEmailOnButton_No_Cost_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_No_Cost_Click_Base()
'        End Sub
Public Sub SendEmailOnButton_PROV_Entered_Invoice_Info_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_PROV_Entered_Invoice_Info_Click_Base()
        End Sub
Public Sub SendEmailOnButton_Req_Cancel_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Req_Cancel_Click_Base()
        End Sub
'Public Sub SendEmailOnButton_No_Cost_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_No_Cost_Click_Base()
'        End Sub
'Public Sub SendEmailOnButton_No_Cost_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_No_Cost_Click_Base()
'        End Sub
'Public Sub SendEmailOnButton_Req_PO_Entered_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_Req_PO_Entered_Click_Base()
'        End Sub
Public Sub SendEmailOnButton_No_Cost_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_No_Cost_Click_Base()
        End Sub
'Public Sub SendEmailOnButton_Req_PO_Entered_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_Req_PO_Entered_Click_Base()
'        End Sub
'Public Sub SendEmailOnButton_Req_PO_Entered_Click()
'
'            ' Customize by adding code before the call or replace the call to the Base function with your own code.
'            SendEmailOnButton_Req_PO_Entered_Click_Base()
'        End Sub
Public Sub SendEmailOnButton_Req_PO_Entered_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnButton_Req_PO_Entered_Click_Base()
        End Sub
#End Region

#Region "Section 2: Do not modify this section."

        Protected Sub Page_InitializeEventHandlers_Base(ByVal sender As Object, ByVal e As System.EventArgs)            		
           
            ' This page does not have FileInput  control inside repeater which requires "multipart/form-data" form encoding, but it might
            'include ascx controls which in turn do have FileInput controls inside repeater. So check if they set Enctype property.
            If Not String.IsNullOrEmpty(Me.Enctype) Then Me.Page.Form.Enctype = Me.Enctype
                 
    
            ' the following code for accordion is necessary or the Me.{ControlName} will return Nothing
        
            ' Register the Event handler for any Events.
      

          ' Setup the pagination events.
        
            AddHandler Me.Button_CATV_Reviewd.Button.Click, AddressOf Button_CATV_Reviewd_Click
        
            Me.Button_CATV_Reviewd.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_More_Info.Button.Click, AddressOf Button_More_Info_Click
        
            Me.Button_More_Info.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_No_Cost.Button.Click, AddressOf Button_No_Cost_Click
        
            Me.Button_No_Cost.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Prov_Connect_INET.Button.Click, AddressOf Button_Prov_Connect_INET_Click
        
            Me.Button_Prov_Connect_INET.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_PROV_Entered_Invoice_Info.Button.Click, AddressOf Button_PROV_Entered_Invoice_Info_Click
        
            Me.Button_PROV_Entered_Invoice_Info.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_PROV_Entered_Target_Dt.Button.Click, AddressOf Button_PROV_Entered_Target_Dt_Click
        
            Me.Button_PROV_Entered_Target_Dt.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Prov_Payment_Received.Button.Click, AddressOf Button_Prov_Payment_Received_Click
        
            Me.Button_Prov_Payment_Received.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_PROV_Send_Deploy_Status.Button.Click, AddressOf Button_PROV_Send_Deploy_Status_Click
        
            Me.Button_PROV_Send_Deploy_Status.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_PROV_Send_Quote.Button.Click, AddressOf Button_PROV_Send_Quote_Click
        
            Me.Button_PROV_Send_Quote.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_PROV_Work_Completed.Button.Click, AddressOf Button_PROV_Work_Completed_Click
        
            Me.Button_PROV_Work_Completed.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Provided_Info.Button.Click, AddressOf Button_Provided_Info_Click
        
            Me.Button_Provided_Info.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Req_Cancel.Button.Click, AddressOf Button_Req_Cancel_Click
        
            Me.Button_Req_Cancel.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Req_Complete.Button.Click, AddressOf Button_Req_Complete_Click
        
            Me.Button_Req_Complete.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Req_New_Quote.Button.Click, AddressOf Button_Req_New_Quote_Click
        
            Me.Button_Req_New_Quote.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Req_PO_Entered.Button.Click, AddressOf Button_Req_PO_Entered_Click
        
            Me.Button_Req_PO_Entered.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Req_Quote_Accepted.Button.Click, AddressOf Button_Req_Quote_Accepted_Click
        
            Me.Button_Req_Quote_Accepted.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_SOW_Done.Button.Click, AddressOf Button_SOW_Done_Click
        
            Me.Button_SOW_Done.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.Button_Submit.Button.Click, AddressOf Button_Submit_Click
        
            Me.Button_Submit.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
            AddHandler Me.CancelButton.Button.Click, AddressOf CancelButton_Click
        
            AddHandler Me.SaveButton.Button.Click, AddressOf SaveButton_Click
        
            Me.SaveButton.Button.Attributes.Add("onclick", "SubmitHRefOnce(this, """ & Me.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
        
          Me.ClearControlsFromSession()
    
          System.Web.HttpContext.Current.Session("isd_geo_location") = "<location><error>LOCATION_ERROR_DISABLED</error></location>"
    
        End Sub

        Private Sub Base_RegisterPostback()
        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_CATV_Reviewd"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_More_Info"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_No_Cost"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Prov_Connect_INET"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_PROV_Entered_Invoice_Info"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_PROV_Entered_Target_Dt"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Prov_Payment_Received"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_PROV_Send_Deploy_Status"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_PROV_Send_Quote"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_PROV_Work_Completed"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Provided_Info"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Req_Cancel"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Req_Complete"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Req_New_Quote"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Req_PO_Entered"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Req_Quote_Accepted"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_SOW_Done"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"Button_Submit"))
                        
              Me.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"SaveButton"))
                        
        End Sub

    

       ' Handles MyBase.Load.  Read database data and put into the UI controls.
       ' If you need to, you can add additional Load handlers in Section 1.
       Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
           Me.SetPageFocus()
    
            ' Check if user has access to this page.  Redirects to either sign-in page
            ' or 'no access' page if not. Does not do anything if role-based security
            ' is not turned on, but you can override to add your own security.
            Me.Authorize("NOT_ANONYMOUS")
			Me.Authorize(Ctype(Button_CATV_Reviewd, Control), "1;23")
					
			Me.Authorize(Ctype(Button_No_Cost, Control), "1;2")
					
			Me.Authorize(Ctype(Button_Prov_Connect_INET, Control), "1;2")
					
			Me.Authorize(Ctype(Button_PROV_Entered_Invoice_Info, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_PROV_Entered_Target_Dt, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_Prov_Payment_Received, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_PROV_Send_Deploy_Status, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_PROV_Send_Quote, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_PROV_Work_Completed, Control), "1;32;33")
					
			Me.Authorize(Ctype(Button_Req_Cancel, Control), "1;2")
					
			Me.Authorize(Ctype(Button_Req_Complete, Control), "1;23")
					
			Me.Authorize(Ctype(Button_Req_New_Quote, Control), "1;2")
					
			Me.Authorize(Ctype(Button_Req_PO_Entered, Control), "1;2")
					
			Me.Authorize(Ctype(Button_Req_Quote_Accepted, Control), "1;2")
					
			Me.Authorize(Ctype(Button_SOW_Done, Control), "1;22;23;25;26;27;28;29;30;31")
					
			Me.Authorize(Ctype(Request_MasterRecordControl, Control), "NOT_ANONYMOUS")
					
    
            If (Not Me.IsPostBack) Then
            
                ' Setup the header text for the validation summary control.
                Me.ValidationSummary1.HeaderText = GetResourceValue("ValidationSummaryHeaderText", "IROC2")
              
            End If
            
            'set value of the hidden control depending on the postback. It will be used by SetFocus script on the client side.	
            Dim clientSideIsPostBack As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(Me.FindControlRecursively("_clientSideIsPostBack"), System.Web.UI.HtmlControls.HtmlInputHidden)
            If Not clientSideIsPostBack Is Nothing Then
                If Me.IsPostBack AndAlso Not Me.Request("__EVENTTARGET") = "ChildWindowPostBack" Then
                    clientSideIsPostBack.Value = "Y"
                Else
                    clientSideIsPostBack.Value = "N"
                End If
            End If

            ' Load data only when displaying the page for the first time or if postback from child window
            If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location")) Then
                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()
            End If
        
        
            Page.Title = GetResourceValue("Title:Edit") + " Request Master"
        If Not IsPostBack Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "PopupScript", "openPopupPage('QPageSize');", True)
        End If
    

    End Sub

    Public Shared Function GetRecordFieldValue_Base(ByVal tableName As String, _
                ByVal recordID As String, _
                ByVal columnName As String, _
                ByVal fieldName As String, _
                ByVal title As String, _
                ByVal closeBtnText As String, _
                ByVal persist As Boolean, _
                ByVal popupWindowHeight As Integer, _
                ByVal popupWindowWidth As Integer, _
                ByVal popupWindowScrollBar As Boolean _
                ) As Object()
        If Not IsNothing(recordID) Then
            recordID = System.Web.HttpUtility.UrlDecode(recordID)
        End If
        Dim content as String = BaseClasses.Utils.MiscUtils.GetFieldData(tableName, recordID, columnName)
    
        content = NetUtils.EncodeStringForHtmlDisplay(content)

        ' returnValue is an array of string values.
        ' returnValue(0) represents title of the pop up window.
        ' returnValue(1) represents the tooltip of the close button.
        ' returnValue(2) represents content of the text.
        ' returnValue(3) represents whether pop up window should be made persistant
        ' or it should close as soon as mouse moves out.
        ' returnValue(4), (5) represents pop up window height and width respectivly
        ' returnValue(6) represents whether pop up window should contain scroll bar.
        ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
        Dim returnValue(6) As Object
        returnValue(0) = title
        returnValue(1) = closeBtnText
        returnValue(2) = content
        returnValue(3) = persist
        returnValue(4) = popupWindowWidth
        returnValue(5) = popupWindowHeight
        returnValue(6) = popupWindowScrollBar
        Return returnValue
    End Function


    Public Shared Function GetImage_Base(ByVal tableName As String, _
                                    ByVal recordID As String, _
                                    ByVal columnName As String, _
                                    ByVal title As String, _
                                    ByVal closeBtnText As String, _
                                    ByVal persist As Boolean, _
                                    ByVal popupWindowHeight As Integer, _
                                    ByVal popupWindowWidth As Integer, _
                                    ByVal popupWindowScrollBar As Boolean _
                                    ) As Object()
        Dim content As String = "<IMG alt =""" & title & """ src =" & """../Shared/ExportFieldValue.aspx?Table=" & tableName & "&Field=" & columnName & "&Record=" & recordID & """/>"
        ' returnValue is an array of string values.
        ' returnValue(0) represents title of the pop up window.
        ' returnValue(1) represents the tooltip of the close button.
        ' returnValue(2) represents content ie, image url.
        ' returnValue(3) represents whether pop up window should be made persistant
        ' or it should close as soon as mouse moves out.
        ' returnValue(4), (5) represents pop up window height and width respectivly
        ' returnValue(6) represents whether pop up window should contain scroll bar.
        ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
        Dim returnValue(7) As Object
        returnValue(0) = title
        returnValue(1) = closeBtnText
        returnValue(2) = content
        returnValue(3) = persist
        returnValue(4) = popupWindowWidth
        returnValue(5) = popupWindowHeight
        returnValue(6) = popupWindowScrollBar
        Return returnValue
    End Function
        
      Public Sub SetChartControl_Base(ByVal chartCtrlName As String)
          ' Load data for each record and table UI control.
        
      End Sub          


    
      
      Public Sub SaveData_Base()
              
        Me.Request_MasterRecordControl.SaveData()
        
      End Sub
      
      

        
    
        Protected Sub SaveControlsToSession_Base()
            MyBase.SaveControlsToSession()
        
        End Sub


        Protected Sub ClearControlsFromSession_Base()
            MyBase.ClearControlsFromSession()
        
        End Sub

        Protected Sub LoadViewState_Base(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
        
        End Sub


        Protected Function SaveViewState_Base() As Object
            
            Return MyBase.SaveViewState()
        End Function


      Public Sub PreInit_Base()
      'If it is SharePoint application this function performs dynamic Master Page assignment.
      
            ' if url parameter specified a master apge, load it here
            If Me.Page.Request("MasterPage") <> "" Then
                Dim masterPage As String = DirectCast(Me.Page, BaseApplicationPage).GetDecryptedURLParameter("MasterPage")          
                Me.Page.MasterPageFile = masterPage
            End If
                  
    
      End Sub
      
      Public Sub Page_PreRender_Base(ByVal sender As Object, ByVal e As System.EventArgs)
     
            ' Load data for each record and table UI control.
                  
            ' Data bind for each chart UI control.
              
      End Sub  

    
        ' Load data from database into UI controls.
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()
            Try
              
                If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location"))  Then
                    ' Must start a transaction before performing database operations
                    DbUtils.StartTransaction()
                End If

              
     
                Me.DataBind()

                ' Load and bind data for each record and table UI control.
                        
        Me.Request_MasterRecordControl.LoadData()
        Me.Request_MasterRecordControl.DataBind()
        
    
                ' Load data for chart.
                
            
                ' initialize aspx controls
                
                

            Catch ex As Exception
                ' An error has occured so display an error message.
                Utils.RegisterJScriptAlert(Me, "Page_Load_Error_Message", ex.Message)
            Finally
                If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location"))  Then
                    ' End database transaction
                      DbUtils.EndTransaction()
                End If
            End Try
        End Sub
        
        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)
        
        Public Overridable Function EvaluateFormula_Base(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Dim e As FormulaEvaluator = New FormulaEvaluator()

            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End If

            
            e.CallingControl = Me

            e.DataSource = dataSourceForEvaluate


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
        
        Public Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
          Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables, True)
        End Function


        Private Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
          Return EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True)
        End Function

        Public Function EvaluateFormula(ByVal formula As String, ByVal includeDS As Boolean) As String
          Return EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS)
        End Function

        Public Function EvaluateFormula(ByVal formula As String) As String
          Return EvaluateFormula(formula, Nothing, Nothing, Nothing, True)
        End Function
 
        

        ' Write out the Set methods
        

        ' Write out the DataSource properties and methods
                

        ' Write out event methods for the page events
        
        ' event handler for Button with Layout
        Public Sub Button_CATV_Reviewd_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=CATV&Topic=Review Completed&To_Agency=Everyone"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_CATV_Reviewd_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_More_Info_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/MoreInfo-Add-Comments-Pop-up.aspx?Request_id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Pending_Agency}&Topic=Need More Info&Prov={Request_MasterRecordControl:FV:Prov_Name}&Entity={Request_MasterRecordControl:FV:Reg_Type}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_No_Cost_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=INET Benefit-No  PO&To_Agency={Request_MasterRecordControl:FV:Prov_Name}&Comment=PO Is Not Required Because Project Is INET Benefit."
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_No_Cost_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Prov_Connect_INET_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=On-INET&To_Agency=CATV"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Prov_Connect_INET_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_PROV_Entered_Invoice_Info_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Entered Invoice Info&To_Agency=Requester&Comment={Request_MasterRecordControl:FV:OTW_More_Info_Comments}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_PROV_Entered_Invoice_Info_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_PROV_Entered_Target_Dt_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Entered Target Dates&To_Agency=Requester"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_PROV_Entered_Target_Dt_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Prov_Payment_Received_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Payment Received&To_Agency=Requester&Comment={Request_MasterRecordControl:FV:OTW_More_Info_Comments}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Prov_Payment_Received_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_PROV_Send_Deploy_Status_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Project Status&To_Agency=Requester&Comment={Request_MasterRecordControl:FV:OTW_More_Info_Comments}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_PROV_Send_Deploy_Status_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_PROV_Send_Quote_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Quote Sent&To_Agency=Requester"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_PROV_Send_Quote_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_PROV_Work_Completed_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Prov_Name}&Topic=Work Completed&To_Agency=Requester&Comment={Request_MasterRecordControl:FV:OTW_More_Info_Comments}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_PROV_Work_Completed_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Provided_Info_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Pending_Agency_Return}&To_Agency={Request_MasterRecordControl:FV:Pending_Agency}&Topic=Info Provided"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Provided_Info_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Req_Cancel_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=Request Canceled&To_Agency=CATV&Comment=Reason:"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Req_Cancel_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Req_Complete_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=CATV&Topic=Request Completed&To_Agency=Requester"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Req_Complete_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Req_New_Quote_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=Quote Rejected&To_Agency={Request_MasterRecordControl:FV:Prov_Name}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Req_New_Quote_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Req_PO_Entered_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=Entered P.O. Info&To_Agency={Request_MasterRecordControl:FV:Prov_Name}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Req_PO_Entered_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Req_Quote_Accepted_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requster&Topic=Quote Accepted&To_Agency={Request_MasterRecordControl:FV:Prov_Name}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Req_Quote_Accepted_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_SOW_Done_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency={Request_MasterRecordControl:FV:Reg_Type}&Topic=SOW Done&To_Agency=Requester"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_SOW_Done_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub Button_Submit_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Action-Add-Comments-Pop-up.aspx?Request_Id={Request_MasterRecordControl:FV:Request_Id}&Agency=Requester&Topic=New Request&To_Agency={Request_MasterRecordControl:FV:Reg_Type}"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            
      url = Me.ModifyRedirectUrl(url, "",True)
              Me.CommitTransaction(sender)
                SendEmailOnButton_Submit_Click()
    
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub CancelButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Group-By-Request-Master-Table.aspx"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
      url = Me.ModifyRedirectUrl(url, "",True)
              
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.ShouldSaveControlsToSession = True
                Me.Response.Redirect(url)
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub SaveButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            Me.CommitTransaction(sender)
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.RollBackTransaction(sender)
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            
    Public  Sub SendEmailOnButton_CATV_Reviewd_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("CATV+has+Completed+Review+For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_No_Cost_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Requester+INET+Benefit%2c+No+P.O.+Needed+For+INET.+-+Notice+to+Proceed+For+INET++%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Prov_Connect_INET_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Connected+To+INET+For+Inet+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_PROV_Entered_Invoice_Info_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Entered+Invoice+Information+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_PROV_Entered_Target_Dt_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Entered+Target+Start+and+Completion+Dates+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Prov_Payment_Received_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Has+Received+All+Payments+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_PROV_Send_Deploy_Status_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Sent+Project+Status+For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_PROV_Send_Quote_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Uploaded+Quote+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_PROV_Work_Completed_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Provider+Work+Completed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Provided_Info_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("More+Info+Provided+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Req_Cancel_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Requester+Canceled+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Req_Complete_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Request+Completed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d%0d%0a"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Req_New_Quote_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Requester+Rejected+Quote.+New+Quote+Needed+From+Provider+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Req_PO_Entered_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Requester+Entered+PO+Information+and+Issues+Notice+to+Proceed+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Req_Quote_Accepted_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Quote+Accepted+By+Requester+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_SOW_Done_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("SOW+Completed++For+INET+Request+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
      
    Public  Sub SendEmailOnButton_Submit_Click_Base()

      Dim email As BaseClasses.Utils.MailSenderInThread
        
      ' For page control
      Dim SendEmail1From As String
      ' If From Address has from of expression {SomeRecordControl:FK:Email}
      ' which are taken from properties dialog
      ' substitute expression with actuall value
      ' Email address can have format "Display Name <emailAddress@companyName.com>"
      SendEmail1From = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("catv%40dcca.hawaii.gov"), "", False, Me)

      Dim SendEmail1To As String
      ' Email Addresses should be separated by comma
      ' Display Name <emailAddress@companyName.com>, Display Name <emailAddress@companyName.com>
      ' or
      ' emalAddress1@companyname.com, emalAddress2@companyname.com
      SendEmail1To = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aReq_Comments%7d"), "", False, Me)

          
      Dim SendEmail1CC As String
      SendEmail1CC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aICS_CATV_Comments%7d"), "", False, Me)
          
      Dim SendEmail1BCC As String
      SendEmail1BCC = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFV%3aCat_OTWC_Comments%7d"), "", False, Me)
          
      Dim SendEmail1Subject As String 
      'In case Subject includes expressions substitute them with values
      SendEmail1Subject = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("New+INET+Request+Created.+Upload+SOW+For+INET+%23%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aIROC_Id%7d"), "", False, Me)
          
      Dim SendEmail1Content As String
      'In case content has expressions substitude then with values
      SendEmail1Content = Me.EvaluateExpressions(System.Web.HttpUtility.UrlDecode("Agency%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Enity2%7d%0d%0aEntity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReg_Type%7d%0d%0aNetwork+Provider%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aProv_Name%7d%0d%0a%0d%0aSite+Name%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Site_Name%7d%0d%0aCity%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_City%7d%0d%0aIsland%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Island%7d%0d%0a%0d%0aRequest+Status%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aReq_Status%7d%0d%0aAction+Needed+By%3a+%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Agency%7d%0d%0aAction+Needed%3a%7bRequest_MasterRecordControl%3aNoUrlEncode%3aFDV%3aPending_Action_Needed%7d"), "", False, Me)
            
      email = New BaseClasses.Utils.MailSenderInThread
      email.AddFrom(SendEmail1From)
      email.AddTo(SendEmail1To)
          
      email.AddCC(SendEmail1CC)
          
      email.AddBCC(SendEmail1BCC)
          
      email.SetSubject(SendEmail1Subject)
          
      email.SetContent(SendEmail1Content)
            
      email.SendMessage()
        
    End Sub
          
    
#End Region

        Private Function Format(ByVal p1 As Date, ByVal p2 As String) As String
            Throw New NotImplementedException
        End Function

     


    End Class
  
End Namespace
  