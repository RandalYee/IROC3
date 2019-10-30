
' This file implements the code-behind class for SignIn.aspx.
' App_Code\SignIn.Controls.vb contains the Table, Row and Record control classes
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
  
Partial Public Class SignIn
        Inherits BaseApplicationPage
' Code-behind class for the SignIn page.
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
      
        ' Login methods perform user authentication, log user in and set roles for user using values in username and password text boxes. 
        ' These values could be entered by user or stored in cookie and populated from cookie. Password is stored in encrypted form.
        ' You may overwrite Login methods here with your functionality
        Public Sub Login(ByVal redirectUrl As String)
            Me.Login_Base(redirectUrl)
        End Sub

        Public Sub Login(ByVal bRedirectOnSuccess As Boolean)
            Me.Login_Base(bRedirectOnSuccess)
        End Sub

        ' This method stored values from username and password textboxes if login was successful into cookie. Password value is 
        ' stored in encrypted form. This method also stores state of all three checkboxes.
        Protected Sub SetCookie()
            Me.SetCookie_Base()
        End Sub

        ' This method clears username and password from cookies if login failed.
        Protected Sub ResetAutoLogin()
            Me.ResetAutoLogin_Base()
        End Sub

        ' This method clears username and password value from cookie if corresponding checkboxes are unchecked and
        ' window is being closed and Cancel button was not clicked. If Cancel button was clicked this method does not
        ' clear values.
        Protected Sub StoreCookieOnClose()
            Me.StoreCookieOnClose_Base()
        End Sub

        ' This method sets value for AutoLogin checkbox in cookie when checkbox state changed. 
        ' Note that if you delete checkbox CheckBoxAutoLogin_CheckedChanged_Base() become an empty method doing nothing
        Protected Sub CheckBoxAutoLogin_CheckedChanged()
            Me.CheckBoxAutoLogin_CheckedChanged_Base()
        End Sub

        ' This method stores value of the Remember Password checkbox in cookie and preserves password value which is
        ' substituted with ****** pattern in the textbox.
        ' Note that if you delete checkbox CheckBoxPass_CheckedChanged_Base() become an empty method doing nothing		
        Protected Sub CheckBoxPass_CheckedChanged()
            Me.CheckBoxPass_CheckedChanged_Base()
        End Sub
      
        ' This method stores value of Remember User checkbox in cookie
        ' Note that if you delete checkbox CheckBoxUN_CheckedChanged_Base() become an empty method doing nothing		
        Protected Sub CheckBoxUN_CheckedChanged()
            Me.CheckBoxUN_CheckedChanged_Base()
        End Sub
        
        ' This method allows to preserve settings during post back. Settings of checkboxes and values of textboxes
        ' are stored in session (password value is stored in encrypted form) and retrieved from session after postback.
        ' Also original values are stored and if user clicks Cancel they are retrieved and preserved
        Protected Sub SignIn_PreRender()
            Me.SignIn_PreRender_Base()
        End Sub

        ' This method is called when login is failed. It also reaises Login Failed event.
        Protected Sub ProcessLoginFailed(ByVal message As String, ByVal userName As String)
            Me.ProcessLoginFailed_Base(message, userName)
        End Sub
  
       ' This method is called when login is succeeded. 
        Protected Sub RedirectOnSuccess()
            Me.RedirectOnSuccess_Base()
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
    
        Public Sub EmailLinkButton_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for EmailLinkButton.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          EmailLinkButton_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub CancelButton_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for CancelButton.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          CancelButton_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub OKButton_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for OKButton.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          OKButton_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            

        ' Write out the Set methods
        
        
        ' Write out the methods for DataSource
        

#End Region

#Region "Section 2: Do not modify this section."

    ' SignInState is a class to store values of cookies in the session state. It is also used by SignOut.ascx.vb(cs)
    Private signInState As SignInState

        Protected Sub Page_InitializeEventHandlers_Base(ByVal sender As Object, ByVal e As System.EventArgs)            		
           
            ' This page does not have FileInput  control inside repeater which requires "multipart/form-data" form encoding, but it might
            'include ascx controls which in turn do have FileInput controls inside repeater. So check if they set Enctype property.
            If Not String.IsNullOrEmpty(Me.Enctype) Then Me.Page.Form.Enctype = Me.Enctype
                 
    
            ' the following code for accordion is necessary or the Me.{ControlName} will return Nothing
        
            ' Register the Event handler for any Events.
      
            AddHandler Me.RememberUserName.CheckedChanged, AddressOf RememberUserName_CheckedChanged
      
            AddHandler Me.RememberPassword.CheckedChanged, AddressOf RememberPassword_CheckedChanged
      
            AddHandler Me.AutomaticallySignIn.CheckedChanged, AddressOf AutomaticallySignIn_CheckedChanged
      

          ' Setup the pagination events.
        
              AddHandler Me.EmailLinkButton.Click, AddressOf EmailLinkButton_Click
            
            AddHandler Me.CancelButton.Button.Click, AddressOf CancelButton_Click
        
            AddHandler Me.OKButton.Button.Click, AddressOf OKButton_Click
        
          Me.ClearControlsFromSession()
    
          System.Web.HttpContext.Current.Session("isd_geo_location") = "<location><error>LOCATION_ERROR_DISABLED</error></location>"
    
        End Sub

        Private Sub Base_RegisterPostback()
        
        End Sub

    

       ' Handles MyBase.Load.  Read database data and put into the UI controls.
       ' If you need to, you can add additional Load handlers in Section 1.
       Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
           Me.SetPageFocus()
    
    
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
        
        
            Page.Title = GetResourceValue("Title:SignIn") + ""
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
        
            Me.SuccessURL = CStr(Me.ViewState.Item("SuccessURL"))
            Me.SuccessURLParam = CStr(Me.ViewState.Item("SuccessURLParam"))          
        
        End Sub


        Protected Function SaveViewState_Base() As Object
        
            Me.ViewState.Item("SuccessURL") = Me.SuccessURL
            Me.ViewState.Item("SuccessURLParam") = Me.SuccessURLParam
            
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
              
                'If you overwrite LoadDate do not forget to include call to this constructor!
                Me.signInState = New SignInState
                Me.CookieInit()
              
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
        
        ' event handler for LinkButton
        Public Sub EmailLinkButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
            Dim url As String = BaseClasses.Configuration.ApplicationSettings.Current.ForgotUserPageUrl()
                    
            If Not String.IsNullOrEmpty(Me.UserName.Text) Then
                url &= "?Username=" & Me.UserName.Text
            End If
                
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
            ElseIf Not Target Is Nothing AndAlso _
                        Not shouldRedirect Then
            Me.ShouldSaveControlsToSession = True
            Me.CloseWindow(True)
        
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub CancelButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
                Dim state As UI.SignInState = New SignInState
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberName(), state.OriginalRememberUser)
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberPassword(), state.OriginalRememberPassword)
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieUserName(), state.OriginalUserName)
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookiePassword(), state.OriginalPassword)
                state.IsCancelled = True     

                target = Me.Page.Request.QueryString.Item("Target")
                If Not String.IsNullOrEmpty(target) Then
                    shouldRedirect = False
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ClosePopup", "closePopupPage();", True)                   
                End If
      
            Catch ex As Exception
            
                shouldRedirect = False
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
            If shouldRedirect Then
                Me.RedirectBack()
            End If
        End Sub
            
        ' event handler for Button with Layout
        Public Sub OKButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
                Me.Login("")
      
            Catch ex As Exception
            
                Me.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
#Region "Event Handlers"
        Private Sub LoginSucceededHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoginSucceeded
            Me.SetCookie()
        End Sub

        Private Sub LoginFailedHandler(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoginFailed
            Me.ResetAutoLogin()
        End Sub

        Private Sub OnCloseWindow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Unload
            Me.StoreCookieOnClose()
        End Sub

        'sets names to their current values before page loads. Need to do that because checkboxes trigger PostBack event and 
        'values of textboxes would not be remembered otherwise
        Private Sub SignIn_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            Me.SignIn_PreRender()
        End Sub
        
        Private Sub RememberUserName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.CheckBoxUN_CheckedChanged()
        End Sub
        
        Private Sub RememberPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.CheckBoxPass_CheckedChanged()
        End Sub
        
        Private Sub AutomaticallySignIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.CheckBoxAutoLogin_CheckedChanged()
        End Sub
        
#End Region


#Region "Cookie Initialization"
        'CookieInit initializes all cookie values.
        Private Sub CookieInit()
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            Me.UserName.TabIndex = 1
            Me.Password.TabIndex = 2
            Me.RememberUserName.TabIndex = 3
            Me.RememberUserName.AutoPostBack = True
            Me.RememberPassword.TabIndex = 4
            Me.RememberPassword.AutoPostBack = True
            Me.AutomaticallySignIn.TabIndex = 5
                       
            Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
            Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey

            'isCancelled is set to true when cancel button is pressed
            Me.signInState.IsCancelled = False
            Me.signInState.UserName = (BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieUserName()))

            'OriginalUserName and other Original... members of signInState keep original values which are used when 
            'Cancel button is pressed to set all cookies to their original values. That is necessary to do because
            'cookie are being modified when checkboxes are triggered.
            Me.signInState.OriginalUserName = Me.signInState.UserName
            If (Not (Me.signInState.UserName Is Nothing)) AndAlso Me.signInState.UserName.Trim <> "" Then
                Me.signInState.UserName = CheckCrypto.Decrypt(Me.signInState.UserName, key, System.Text.Encoding.Unicode, False)
            Else
                Me.signInState.UserName = ""
            End If
            Me.signInState.Password = (BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookiePassword()))
            Me.signInState.OriginalPassword = Me.signInState.Password
            If (Not (Me.signInState.Password Is Nothing)) AndAlso Me.signInState.Password.Trim <> "" Then
                Me.signInState.Password = CheckCrypto.Decrypt(Me.signInState.Password, key, System.Text.Encoding.Unicode, False)
            Else
                Me.signInState.Password = ""
            End If
            Dim rUser As String = (BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieRememberName()))
            Me.signInState.OriginalRememberUser = rUser

            'Need to check if check boxes are set to visible in Application Generation Options. If not - do not show them and
            'set to false their values
            If StringUtils.InvariantLCase(BaseClasses.Configuration.ApplicationSettings.Current.ShowRememberUserCheckBox) = "false" Then
            
                Me.RememberUserName.Visible = False
                Me.RememberUserName.Enabled = False
                Me.RememberUserNameLabel.Visible = False
                Me.RememberUserNameLabel.Enabled = False
                Me.signInState.IsUNToRemember = False
            Else
                If (Not (rUser Is Nothing)) AndAlso (rUser.ToLower() = "true") Then
                    Me.signInState.IsUNToRemember = True
                Else
                    Me.signInState.IsUNToRemember = False
                End If

            End If

            Dim rPassword As String = (BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieRememberPassword()))
            Me.signInState.OriginalRememberPassword = rPassword
            If StringUtils.InvariantLCase(BaseClasses.Configuration.ApplicationSettings.Current.ShowRememberPasswordCheckBox) = "false" Then
            
                Me.RememberPassword.Enabled = False
                Me.RememberPassword.Visible = False
                Me.RememberPasswordLabel.Visible = False
                Me.RememberPasswordLabel.Enabled = False
                Me.signInState.IsPassToRemember = False
            Else
                If Not (rPassword Is Nothing) AndAlso (rPassword.ToLower() = "true") Then
                    Me.signInState.IsPassToRemember = True
                Else
                    Me.signInState.IsPassToRemember = False
                End If
            End If

            If (Me.signInState.IsUNToRemember) Then
                If (Me.signInState.UserName <> "") Then
                    Me.RememberUserName.Checked = Me.signInState.IsUNToRemember
                    Me.UserName.Text = Me.signInState.UserName
                End If
            End If
            
            If (Me.signInState.Password <> "") Then
                Me.RememberPassword.Checked = Me.signInState.IsPassToRemember
                If (Me.Password.Text <> "**********" And Me.Password.Text.Trim <> "") Then
                    Me.signInState.Password = Me.Password.Text
                Else
                    Me.Password.Text = Me.signInState.Password
                End If
                Me.signInState.LoginPassword = Me.signInState.Password
                Me.Password.Attributes.Add("value", "**********")
            ElseIf Me.Password.Text = "" Then
                Me.Password.Attributes.Add("value", "")
                Me.signInState.LoginPassword = ""
            Else
                Me.signInState.LoginPassword = ""
            End If

            Dim isAutoLogin As String = BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieAutoLogin())
            If StringUtils.InvariantLCase(BaseClasses.Configuration.ApplicationSettings.Current.ShowAutoSignInCheckBox) = "false" Then
                Me.AutomaticallySignIn.Visible = False
                Me.AutomaticallySignIn.Enabled = False
                Me.AutomaticallySignInLabel.Visible = False
                Me.AutomaticallySignInLabel.Enabled = False
                Me.signInState.IsAutoLogin = False
            End If

            'Get value of automatically login cookie, if not set AND security used is Active Directory, than use
            'default value which is True to allow user be automatically signed in with his current credentials
            If (isAutoLogin Is Nothing Or isAutoLogin = "") Then
                Select Case BaseClasses.Configuration.ApplicationSettings.Current.AuthenticationType
                    Case BaseClasses.Configuration.SecurityConstants.ActiveDirectorySecurity
                        BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieAutoLogin(), "True")
                        isAutoLogin = "True"
                    Case BaseClasses.Configuration.SecurityConstants.WindowsSecurity
                        BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieAutoLogin(), "True")
                        isAutoLogin = "True"						
                    Case BaseClasses.Configuration.SecurityConstants.ProprietorySecurity
                        BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieAutoLogin(), "False")
                        isAutoLogin = "False"
                    Case BaseClasses.Configuration.SecurityConstants.None
                        BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieAutoLogin(), "False")
                        isAutoLogin = "False"
                End Select
            End If

            If (isAutoLogin.ToLower = "true" And Me.signInState.IsAutoLogin) Then
                Me.AutomaticallySignIn.Checked = True
                If ((Not Me.signInState.IsUNToRemember) Or (Not Me.signInState.IsPassToRemember)) Then
                    Me.UserName.Text = ""
                    Me.Password.Attributes.Add("value", "")
                    Me.signInState.LoginPassword = ""
                End If
                Me.Login(True)
            Else
                Me.AutomaticallySignIn.Checked = False
            End If

        End Sub
        
        
        'Sets cookies when login succeeded

        Private Sub SetCookie_Base()
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
            Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
            If (Me.signInState.IsUNToRemember) Then
                Dim uNameEncrypted As String = CheckCrypto.Encrypt(Me.UserName.Text, key, System.Text.Encoding.Unicode, False)
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieUserName(), uNameEncrypted)
            Else
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieUserName(), "")
            End If
            If (Me.signInState.IsPassToRemember) Then
                If (Me.Password.Text <> "**********" And Me.Password.Text.Trim <> "") Then
                    Me.signInState.Password = Me.Password.Text
                End If
                Dim passwordEncrypted As String = CheckCrypto.Encrypt(Me.signInState.Password, key, System.Text.Encoding.Unicode, False)
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookiePassword(), passwordEncrypted)
            Else
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookiePassword(), "")
            End If
            BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberName(), Me.signInState.IsUNToRemember.ToString())
            BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberPassword(), Me.signInState.IsPassToRemember.ToString())
            Me.signInState.IsAutoLogin = True
        End Sub

        'Resets AutoLogin when login failed
        Private Sub ResetAutoLogin_Base()
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            Me.signInState.IsAutoLogin = False
            If (Not Me.signInState.IsUNToRemember) Then
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieUserName(), "")
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberName(), Me.signInState.IsUNToRemember.ToString())
            End If
            If (Not Me.signInState.IsPassToRemember) Then
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookiePassword(), "")
                BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberPassword(), Me.signInState.IsPassToRemember.ToString())
            End If
        End Sub

        Public Sub StoreCookieOnClose_Base()
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            'Check if Cancel button clicked. If not and any "remember" box is unchecked, clear content
            If (Not Me.signInState.IsCancelled) Then
                If (Not Me.signInState.IsUNToRemember) Then
                    BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberName(), Boolean.FalseString)
                    BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieUserName(), "")
                End If
                If (Not Me.signInState.IsPassToRemember) Then
                    BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieRememberPassword(), Boolean.FalseString)
                    BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookiePassword(), "")
                End If
            End If
        End Sub

        'This method handles change of state for AutoLogin checkbox if this checkbox is present.
        'If checkbox was removed from the page this method has empty content.
        Private Sub CheckBoxAutoLogin_CheckedChanged_Base()
        
            Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
            Dim isAutoLogin As Boolean = Me.AutomaticallySignIn.Checked
            BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieAutoLogin(), isAutoLogin.ToString())
        End Sub

        'This method handles change of state for Remember Password checkbox if this checkbox is present.
        'If checkbox was removed from the page this method has empty content.
        Private Sub CheckBoxPass_CheckedChanged_Base()
        
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            If (Me.RememberPassword.Checked = True) Then
                Me.signInState.IsPassToRemember = True
                If (Me.Password.Text <> "**********") Then
                    Me.signInState.Password = Me.Password.Text
                End If
            Else
                Me.signInState.IsPassToRemember = False
                If (Me.Password.Text <> "**********" And Me.Password.Text.Trim <> "") Then
                    Me.signInState.Password = Me.Password.Text
                End If
            End If
        End Sub

        'This method handles change of state for Remember UserName checkbox if this checkbox is present.
        'If checkbox was removed from the page this method has empty content.       
        Private Sub CheckBoxUN_CheckedChanged_Base()
        
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If
            If (Me.RememberUserName.Checked = True) Then
                Me.signInState.IsUNToRemember = True
                If (Me.Password.Text <> "**********") Then
                    Me.signInState.Password = Me.Password.Text
                End If
            Else
                Me.signInState.IsUNToRemember = False
                Me.signInState.UserName = ""
                If (Me.Password.Text <> "**********" And Me.Password.Text.Trim <> "") Then
                    Me.signInState.Password = Me.Password.Text
                End If
            End If
        End Sub

        Private Sub SignIn_PreRender_Base()

        
        ' If a UserIdentity table with a UserEmail column is not defined, do not show the email password link
        Dim userTable As IUserIdentityTable = CType(BaseClasses.Configuration.ApplicationSettings.Current.GetUserIdentityTable(), IUserIdentityTable)
        Me.EmailLinkButton.Visible = (Not (IsNothing(userTable) OrElse IsNothing(userTable.UserEmailColumn()))) _
        AndAlso BaseClasses.Configuration.ApplicationSettings.Current.AuthenticationType = BaseClasses.Configuration.SecurityConstants.ProprietorySecurity
      
            If Me.signInState Is Nothing Then
                Me.signInState = New SignInState
            End If

            If (Me.signInState.IsUNToRemember) Then
                If (Me.signInState.UserName <> "") Then
                    Me.RememberUserName.Checked = Me.signInState.IsUNToRemember
                    Me.UserName.Text = Me.signInState.UserName
                End If
            End If
            
            If (Me.signInState.Password <> "") Then
                Me.RememberPassword.Checked = Me.signInState.IsPassToRemember
                If (Me.Password.Text <> "**********" And Me.Password.Text.Trim <> "") Then
                    Me.signInState.Password = Me.Password.Text
                Else
                    Me.Password.Text = Me.signInState.Password
                End If
                Me.signInState.LoginPassword = Me.signInState.Password
                Me.Password.Attributes.Add("value", "**********")
            ElseIf Me.Password.Text = "" Then
                Me.Password.Attributes.Add("value", "")
                Me.signInState.LoginPassword = ""
            Else
                Me.signInState.LoginPassword = ""
            End If

        End Sub
#End Region

#Region " Login Methods "
        Public Overridable Sub Login_Base(ByVal redirectUrl As String)
            If Not redirectUrl Is Nothing AndAlso redirectUrl <> "" Then
                Login_Base(False)
            Else
                Login_Base(True)
            End If
        End Sub

        'Performs the login. Passes username and password to current security SetLoginInfo method to validate user
        'If successful raises LoginSucceeded event and redirects back to page, if fails calls ProcessLoginFailed
        Public Overridable Sub Login_Base(ByVal bRedirectOnSuccess As Boolean)
            Dim strUserName As String = ""
            strUserName = Me.UserName.Text
            Dim strPassword As String = ""
            strPassword = Me.Password.Text
            If (Me.Password.Text = "**********" Or Me.Password.Text = "") Then
                Dim state As SignInState = New SignInState
                strPassword = state.LoginPassword
            End If
            Dim errMessage As String = ""
            Dim clientIPAddress As String = Me.Page.Request.ServerVariables("REMOTE_ADDR") & " (HTML)"
            
            Dim bSuccess As Boolean = False
            Try
                'SetLoginInfo will do the work of authenticating the name and password
                bSuccess = DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.SetLoginInfo(strUserName, strPassword, errMessage)
            Catch ex As System.Threading.ThreadAbortException
                Throw ex
            Catch e As System.Exception
                ProcessLoginFailed(ERR_INTERNAL_ERROR & " " & e.Message, "")
            End Try

            'success!
            If (bSuccess) Then
                RaiseEvent LoginSucceeded(Me, New System.EventArgs())

                If bRedirectOnSuccess Then
                    RedirectOnSuccess()
                End If
            Else
                If Not errMessage Is Nothing AndAlso errMessage <> "" Then
                    ProcessLoginFailed(errMessage, strUserName)
                Else
                    ProcessLoginFailed(ERR_INVALID_LOGIN_INFO, strUserName)
                End If
            End If
        End Sub

        Protected Sub RedirectOnSuccess_Base()
            If (Len(Trim(Me.SuccessURL)) > 0) Then
                Me.Page.Response.Redirect(Me.SuccessURL)
            Else
                CType(Me.Page, BaseClasses.Web.UI.BasePage).RedirectBack(True)
            End If
        End Sub


        'Login failed, so redirect back to the login page passing information on the URL
        Protected Sub ProcessLoginFailed_Base(ByVal message As String, ByVal userName As String)

          RaiseEvent LoginFailed(Me, New System.EventArgs())

          Dim url As String
          Dim deviceSize As String = DirectCast(Me.Page, BaseApplicationPage).CheckDeviceSize()
          If ( StringUtils.InvariantUCase(deviceSize).Equals(StringUtils.InvariantUCase("Small")) ) Then
            url = BaseClasses.Configuration.ApplicationSettings.Current.MobileSignInPageUrl() & "?message=" & Me.Page.Server.UrlEncode(message)
          Else
            url = BaseClasses.Configuration.ApplicationSettings.Current.SignInPageUrl() & "?message=" & Me.Page.Server.UrlEncode(message)
          End If
            
          If Not Me.SuccessURLParam Is Nothing AndAlso Me.SuccessURLParam.Trim.Length > 0 Then
            url &= "&" & Me.SuccessURLParam & "=" & Me.SuccessURL
          End If

          If (Trim(userName) <> "") Then
            url = url & "&UserName=" & Trim(userName)
          End If
          url = url & "&mode=yes"
          
          If (Trim(Me.Page.Request("MasterPage")) <> "") Then
            url = url & "&MasterPage=" & Me.Page.Request("MasterPage")
          End If
          
          If (Trim(Me.Page.Request("Target")) <> "") Then
            url = url & "&Target=" & Me.Page.Request("Target")
          End If
          
        DirectCast(Me.Page, BaseApplicationPage).SystemUtils.shouldRollBackTransaction = True
        CType(Me.Page, BaseClasses.Web.UI.BasePage).RemoveCurrentRequestFromSessionNavigationHistory()
        BaseClasses.Utils.NetUtils.SetCookie(BaseClasses.Utils.NetUtils.CookieAutoLogin(), "False")
        Dim Session As System.Web.SessionState.HttpSessionState = System.Web.HttpContext.Current.Session
        Session.Abandon()
        Me.Page.Response.Redirect(url)
        Me.Page.Response.End()
        End Sub
        #End Region

        #Region " Constants "
        Const INVALID_USER_INFO As Integer = -2147467259
        #End Region

        #Region " Events "
        Public Event LoginSucceeded(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event LoginFailed(ByVal sender As Object, ByVal e As System.EventArgs)
        #End Region

        #Region " Public Properties "
        'URL to redirect to when login is successful
        Protected _successURL As String
        Public Property SuccessURL() As String
        Get
        Return Me._successURL
        End Get
        Set(ByVal Value As String)
        Me._successURL = Value
        End Set
        End Property

        'URL parameter name for SuccessURL
        Protected _successURLParm As String
        Public Property SuccessURLParam() As String
        Get
        Return Me._successURLParm
        End Get
        Set(ByVal Value As String)
        Me._successURLParm = Value
        End Set
        End Property

        #End Region

        #Region " Misc Methods "

        'Sets the text of the login message
        Protected Overrides Sub OnDataBinding(ByVal e As System.EventArgs)
        MyBase.OnDataBinding(e)

        Dim strMessage As String = Me.Page.Request.QueryString("Message")
        If Not (IsNothing(strMessage)) Then
        strMessage = strMessage.Replace("<br>", vbCrLf)
                strMessage = Me.Page.Server.HtmlEncode(strMessage)
            End If

            Me.UserName.Text = Me.Page.Request.QueryString("UserName")
            If Not (IsNothing(Me.UserName.Text)) Then
                Me.UserName.Text = Me.Page.Server.HtmlEncode(Me.UserName.Text)
            End If

            If Not Me.SuccessURLParam Is Nothing AndAlso Me.SuccessURLParam.Trim.Length > 0 Then
                Me.SuccessURL = Me.Page.Request.QueryString(Me.SuccessURLParam.Trim)
                If (Not Me.SuccessURL Is Nothing) Then
                    Me.SuccessURL = Me.SuccessURL.Trim()
                    Me.SuccessURL = Me.Page.Server.HtmlEncode(Me.SuccessURL)
                End If
            End If

            ' Set the Login Message
            If (Not (IsNothing(strMessage))) Then
                Me.LoginMessage.Text = strMessage
            ElseIf (Not (IsNothing(Me.SuccessURL)) AndAlso Me.SuccessURL <> "") Then
                Me.LoginMessage.Text = LOGIN_MSG_SESSION_INVALID
            Else
                Me.LoginMessage.Text = LOGIN_MSG
            End If
      End Sub

#End Region

#Region " Protected Properties "

      Public ReadOnly Property ERR_INVALID_LOGIN_INFO() As String
        Get
          Return DirectCast(Me.Page, BaseApplicationPage).GetResourceValue("Err:InvalidLoginInfo", "IROC2")
        End Get

      End Property

      Public ReadOnly Property ERR_INTERNAL_ERROR() As String
          Get
              Return DirectCast(Me.Page, BaseApplicationPage).GetResourceValue("Err:InternalErrorLogin", "IROC2")
          End Get

      End Property

      Public ReadOnly Property LOGIN_MSG() As String
          Get
              Return DirectCast(Me.Page, BaseApplicationPage).GetResourceValue("Txt:LoginMsg", "IROC2")
          End Get

      End Property

      Public ReadOnly Property LOGIN_MSG_SESSION_INVALID() As String
          Get
              Return DirectCast(Me.Page, BaseApplicationPage).GetResourceValue("Txt:LoginMsgSessionInvalid", "IROC2")
          End Get

      End Property

#End Region

          
    
#End Region

  
End Class
  
End Namespace
  