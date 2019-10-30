
' This file implements the code-behind class for ForgotUser.aspx.
' App_Code\ForgotUser.Controls.vb contains the Table, Row and Record control classes
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
  
Partial Public Class ForgotUser
        Inherits BaseApplicationPage
' Code-behind class for the ForgotUser page.
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
          Me.Page_PreRender_Base(sender,e)
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
    
        Public Sub SendButton_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for SendButton.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          SendButton_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub SendEmailOnSendButton_Click()

            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            SendEmailOnSendButton_Click_Base()
        End Sub
      

        ' Write out the Set methods
        
        
        ' Write out the methods for DataSource
        

#End Region

#Region "Section 2: Do not modify this section."

        Protected Sub Page_InitializeEventHandlers_Base(ByVal sender As Object, ByVal e As System.EventArgs)            		
           
            ' This page does not have FileInput  control inside repeater which requires "multipart/form-data" form encoding, but it might
            'include ascx controls which in turn do have FileInput controls inside repeater. So check if they set Enctype property.
            If Not String.IsNullOrEmpty(Me.Enctype) Then Me.Page.Form.Enctype = Me.Enctype
                 
    
            ' the following code for accordion is necessary or the Me.{ControlName} will return Nothing
        
            ' Register the Event handler for any Events.
      

          ' Setup the pagination events.
        
            AddHandler Me.SendButton.Button.Click, AddressOf SendButton_Click
        
          Me.ClearControlsFromSession()
    
          System.Web.HttpContext.Current.Session("isd_geo_location") = "<location><error>LOCATION_ERROR_DISABLED</error></location>"
    
        End Sub

        Private Sub Base_RegisterPostback()
        
        End Sub

    
        Public Sub New()
            Me.IsUpdatesSessionNavigationHistory = False
        End Sub
    

       ' Handles MyBase.Load.  Read database data and put into the UI controls.
       ' If you need to, you can add additional Load handlers in Section 1.
       Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
           Me.SetPageFocus()
    
            ' Check if user has access to this page.  Redirects to either sign-in page
            ' or 'no access' page if not. Does not do anything if role-based security
            ' is not turned on, but you can override to add your own security.
            Me.Authorize("")
    
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
        
        
            Page.Title = GetResourceValue("Title:ForgotUser") + ""
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
          
            InitializeEmail()
        
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
        Public Sub SendButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
                SendEmailOnSendButton_Click()
    
            Catch ex As Exception
            
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
                ' when there is an error sending email, redirect back to this page to do it again
                'get the user name from any argument
      
                Dim uname As String = CType(Me.Page, BaseApplicationPage).Decrypt(Me.Request.QueryString("Username"))
                uname = CType(Me.Page, BaseApplicationPage).Encrypt(uname)
        
                Dim uarg As String = "?Username=" & uname & "&Error=" & ex.Message & "&Email=" & Me.Emailaddress.Text
      
                Dim myUrl As String = BaseClasses.Configuration.ApplicationSettings.Current.ForgotUserPageUrl()
        
                Response.ClearContent()
                Response.Redirect(myUrl & uarg)
                Response.End()
    
            Finally
    
            End Try
    
        End Sub
            

        Public Sub SendEmailOnSendButton_Click_Base()
            SendPasswordToUser(True)
        End Sub


        ' Initialize the email field from a Username argument
        Public Sub InitializeEmail()

        If Me.IsPostBack Then Return
        
            'if there is a captcha control, then check that keys have been configured.
            Dim keyinit As String = "Enter"
            If recaptcha.PrivateKey.StartsWith(keyinit) OrElse recaptcha.PublicKey.StartsWith(keyinit) Then
                Me.FillRecaptchaLabel.Text = "You must configure the reCaptcha control with your key values before you use it."

                ' find any recaptcha_response_holder and make it invisible
                Dim pnlRecaptcha As Object = Me.FindControlRecursively("recaptcha_response_holder")
                If Not IsNull(pnlRecaptcha) Then
                    CType(pnlRecaptcha, System.Web.UI.Control).Visible = False
                End If
            End If
      
            'get the user name and error message from any arguments
              
            Dim uname As String = CType(Me.Page, BaseApplicationPage).Decrypt(Me.Request.QueryString("Username"))
                
            Dim uerror As String = Me.Request.QueryString("Error")
            Dim emailarg As String = Me.Request.QueryString("Email")
            Me.Emailaddress.Text = ""

            ' if there is a user name given, start with any email address for it.
            Dim uemail As String = ""
            If Not String.IsNullOrEmpty(emailarg) Then
                ' initialize the email address with the value in the argument
                uemail = emailarg
                If Not String.IsNullOrEmpty(uemail) Then
                    Me.Emailaddress.Text = uemail
                End If
            ElseIf Not String.IsNullOrEmpty(uname) Then

                ' get the user record from the DB
                Dim rec As IUserIdentityRecord = Nothing
                Try
                    rec = SystemUtils.GetUserInfoNoPassword(uname)
                Catch ex As Exception
                    rec = Nothing
                End Try
                If Not IsNothing(rec) Then

                    ' then initialize the email address with the value in the record
                    uemail = rec.GetUserEmail()
                    If Not String.IsNullOrEmpty(uemail) Then
                        Me.Emailaddress.Text = uemail
                    End If
                End If
            End If

            If Not String.IsNullOrEmpty(uerror) Then
                Me.ForgotUserInfoLabel.Visible = False
                Me.ForgotUserErrorLabel.Visible = True
                Me.ForgotUserErrorLabel.Text = uerror
            Else
                Me.ForgotUserErrorLabel.Text = ""
                Me.ForgotUserInfoLabel.Visible = True
                Me.ForgotUserErrorLabel.Visible = False
            End If
        End Sub


        'Send the user password to the user email
        'If link button was removed from the page this method has empty content.
        Private Sub SendPasswordToUser(usecaptcha As Boolean)
            'if there is a user identity table, with an email address field,
            'then send the user name and password to the user email
      
            If usecaptcha Then
            If Not Me.Page.IsValid() Then
                Dim exc As New Exception(Me.recaptcha.ErrorMessage)
                Throw exc
            End If
            End If
      
            ' The email address is required by validation
            Dim uemail As String = Me.Emailaddress.Text

            ' lookup the email address in the user identity table and abort if not present

            ' send the login info to the user email
            Dim email As New BaseClasses.Utils.MailSenderInThread()
            email.AddTo(uemail)

            ' use the from email address in the smtp section of the web.config, if available
            Dim fromadr As String = uemail
            Dim obj As Object = System.Web.Configuration.WebConfigurationManager.GetSection("system.net/mailSettings/smtp")
            If Not IsNull(obj) Then
                Dim smtpcfg As System.Net.Configuration.SmtpSection
                smtpcfg = CType(obj, System.Net.Configuration.SmtpSection)
                fromadr = smtpcfg.From
            End If
            email.AddFrom(fromadr)

            email.SetSubject(GetResourceValue("Txt:GetSignin"))

            ' Be sure the URL is processed for substitution and encryption
            Dim uarg As String = CType(Me.Page, BaseApplicationPage).Encrypt(uemail, False)
            Dim cultarg As String = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
            If Not String.IsNullOrEmpty(cultarg) Then
                cultarg = System.Web.HttpUtility.UrlEncode(cultarg)
                cultarg = BaseClasses.Web.UI.BasePage.APPLICATION_CULTURE_UI_URL_PARAM & "=" & cultarg
            End If

            Dim SendEmailContentURL As String
            Dim pgUrl As String = BaseClasses.Configuration.ApplicationSettings.Current.SendUserInfoEmailUrl()
            If pgUrl.StartsWith("/") Then
                pgUrl = pgUrl.Substring(1)
            End If

            SendEmailContentURL = pgUrl & "?Email=" & System.Web.HttpUtility.UrlEncode(uarg)
            If Not String.IsNullOrEmpty(cultarg) Then
                SendEmailContentURL &= "&" & cultarg
            End If

            email.AreImagesEmbedded = True
            email.RemoveJS = True
            email.SetIsHtmlContent(True)
            email.SetContentURL(SendEmailContentURL, Me)

            Try
                email.SendMessage()
            Catch ex As Exception
                Dim msg As String = GetResourceValue("Msg:SendToFailed") & " " & uemail & "<br />" & ex.Message
                Dim exc As New Exception(msg)
                Throw exc
            End Try

            Me.ForgotUserInfoLabel.Visible = True
            Me.ForgotUserInfoLabel.Text = GetResourceValue("Msg:PwdEmailed") & " " & uemail
            Me.ForgotUserErrorLabel.Text = ""
            Me.ForgotUserErrorLabel.Visible = False
            Me.EnterEmailLabel.Visible = False
            Me.Emailaddress.Visible = False
      
            Me.FillRecaptchaLabel.Visible = False
            
            Me.recaptcha.SkipRecaptcha = True
            Me.recaptcha.Visible = False
      
            Me.SendButton.Visible = False
        End Sub
        
    
#End Region

  
End Class
  
End Namespace
  