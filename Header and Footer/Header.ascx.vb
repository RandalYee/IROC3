
#Region "Imports statements"	  
Option Strict On
Imports System
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports BaseClasses.Web.UI.WebControls
        
Imports IROC2.Business
Imports IROC2.Data
        
#End Region	  
  
Namespace IROC2.UI

  ' Code-behind class for the Header user control.
Partial Public Class Header
        Inherits BaseApplicationUserControl
        Implements IHeader
#Region "Section 1: Place your customizations here."
     
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


      
      Public Sub LogOut()
          ' By default application logs out user on the load of SignOut page. To call logout method explicitely here
          ' uncomment the following call to security layer:
          ' DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.Logout(CType(Me.Page, BaseApplicationPage))
      End Sub
      
      Public Sub ThemeSelector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
          Me.ThemeSelector_SelectedIndexChanged_Base(sender)
      End Sub

      Public Overrides Sub SetChartControl(ByVal chartCtrlName As String)
          Me.SetChartControl_Base(chartCtrlName)
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
    
        Public Sub SIOImage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
          ' Click handler for SIOImage.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          SIOImage_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub SignIn_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for SignIn.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          SignIn_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            

        ' Write out the Set methods
        
        
        ' Write out the methods for DataSource
        

#End Region

#Region "Section 2: Do not modify this section."

        Protected Sub Page_InitializeEventHandlers_Base(ByVal sender As Object, ByVal e As System.EventArgs)            		
                  
    
            ' the following code for accordion is necessary or the Me.{ControlName} will return Nothing
        
            AddHandler Me.ThemeSelector.SelectedIndexChanged, AddressOf ThemeSelector_SelectedIndexChanged
            ' Register the Event handler for any Events.
      

          ' Setup the pagination events.
        
              AddHandler Me.SIOImage.Click, AddressOf SIOImage_Click
              
              AddHandler Me.SignIn.Click, AddressOf SignIn_Click
            
          Me.ClearControlsFromSession()
    
          System.Web.HttpContext.Current.Session("isd_geo_location") = "<location><error>LOCATION_ERROR_DISABLED</error></location>"
    
        End Sub

        Private Sub Base_RegisterPostback()
        
        End Sub

    

       ' Handles MyBase.Load.  Read database data and put into the UI controls.
       ' If you need to, you can add additional Load handlers in Section 1.
       Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
            Me.ThemeSelector.Visible = True	
            Me.Divider0.Visible = True 
            Me.LanguageSelector.Visible = False
            Me.Divider1.Visible = False
            Me.UserStatusInit() 
            Me.PrintButtonInit() 
            Me.SignInButtonInit() 
            Me.LeftRightImageInit()
            Me.SkipNavigationLinks.Visible = False 
    
            If (Not Me.IsPostBack) Then
            
                If Not String.IsNullOrEmpty(Me.Page.ClientQueryString) Then
                     Me.SkipNavigationLinks.NavigateUrl = Me.Page.AppRelativeVirtualPath & "?" & Me.Page.ClientQueryString & Me.SkipNavigationLinks.NavigateUrl
                Else
                     Me.SkipNavigationLinks.NavigateUrl = Me.Page.AppRelativeVirtualPath & Me.SkipNavigationLinks.NavigateUrl
                End If               			   
            
            End If
            

            ' Load data only when displaying the page for the first time or if postback from child window
            If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location")) Then
                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()
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


      Public Sub Page_PreRender_Base(ByVal sender As Object, ByVal e As System.EventArgs)
     
            'Call initialize function for theme selector for multi-color theme here
            
            Me.InitializeThemeSelector_Base()
            ' Load data for each record and table UI control.
                  
            ' Data bind for each chart UI control.
              
      End Sub  

    
      'Initializes Sign In status text.
      Protected Overridable Sub UserStatusInit()
      
            Select Case DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.GetUserStatus()
              Case Nothing
                Me.UserStatusLbl.Text = GetResourceValue("Txt:UserNotSignedIn", "IROC2")
              Case ""
                Me.UserStatusLbl.Text = GetResourceValue("Txt:UserNotSignedIn", "IROC2")
              Case Else
                Me.UserStatusLbl.Text = GetResourceValue("Txt:Hello", "IROC2")
                Me.UserStatusLbl.Text +=DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.GetUserStatus()
            End Select
             
        End Sub
        
        'Initializes Print Button.
        Protected Overridable Sub PrintButtonInit()
        
          Me.SignInBarPrintButton.Visible = False
          Me.Divider2.Visible = False 
        End Sub
       
        'Initializes Theme Selector for multi-color theme
        Protected Sub InitializeThemeSelector_Base()          
            Dim selectedTheme As String = CType(Me.Page, BaseApplicationPage).GetSelectedTheme()         
            If String.IsNullOrEmpty(selectedTheme) Then
                    selectedTheme = Me.Page.Theme
            End If
            
            'Now sort themes according to their localized name. You may override this method and sorrt them differently
            Dim themeList As Generic.List(Of WebControls.ListItem) = New Generic.List(Of WebControls.ListItem)
            Dim comparer As BaseClasses.Utils.ListItemComparer = New BaseClasses.Utils.ListItemComparer(True, ListItemComparer.SortBy.Text)
            For Each li As WebControls.ListItem In Me.ThemeSelector.Items
          'To use localized name create an entry in the language specific resource file for each Txt:Theme_Name
          'I.e. if your Theme's name is 'Fire Engine' your resource key should be "Txt:Fire_Engine"			
                Dim locName As String = Me.GetResourceValue("Txt:" & li.Text.Replace(" ","_"), "IROC2")
                If Not String.IsNullOrEmpty(locName) Then li.Text = locName
                themeList.Add(li)
            Next
           
            Me.ThemeSelector.Items.Clear()
            themeList.Sort(comparer)
            Me.ThemeSelector.Items.AddRange(themeList.ToArray())	
            
            If Not String.IsNullOrEmpty(selectedTheme) Then
                For index As Integer = 0 To Me.ThemeSelector.Items.Count - 1
                    If Me.ThemeSelector.Items(index).Value = selectedTheme Then
                        Me.ThemeSelector.SelectedIndex = index
                        Exit For
                    End If
                Next
            End If
            
        End Sub
        
        'Sets selected theme to session and cookie
        Protected Sub ThemeSelector_SelectedIndexChanged_Base(ByVal sender As Object)
            Dim selectedTheme As String = DirectCast(sender, DropDownList).SelectedItem.Value
            Dim Session As System.Web.SessionState.HttpSessionState = HttpContext.Current.Session
            Session.Item(NetUtils.CookieSelectedTheme) = selectedTheme
            BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieSelectedTheme, selectedTheme)
            Dim url As String = CType(Me.Page, BaseApplicationPage).Request.Url.AbsoluteUri
            CType(Me.Page, BaseApplicationPage).Response.Redirect(url)
        End Sub
      
    'Initializes LeftImage and RightImage.
    'You can change the behavior of this method in Section 1.
    Protected Overridable Sub LeftRightImageInit()
  
      If Me.LeftImage.Visible = True AndAlso _
         Me.LanguageSelector.Visible = False AndAlso _
             Me.SignInBarPrintButton.Visible = False AndAlso _
             Me.SignIn.Visible = False AndAlso _
             Me.SIOImage.Visible = False AndAlso _
             Me.ThemeSelector.Visible = False Then
                    Me.LeftImage.Visible = False
          End If 
      If Me.RightImage.Visible = True AndAlso _
         Me.LanguageSelector.Visible = False AndAlso _
             Me.SignInBarPrintButton.Visible = False AndAlso _
             Me.SignIn.Visible = False AndAlso _
             Me.SIOImage.Visible = False AndAlso _
             Me.ThemeSelector.Visible = False Then
                    Me.RightImage.Visible = False
          End If 		
    End Sub
    
        'Initializes SignIn LinkButton.
        'You can change the behavior of this method in Section 1.
        Protected Overridable Sub SignInButtonInit()
        
            Me.UserStatusLbl.Visible = False  
            If (BaseClasses.Configuration.ApplicationSettings.Current.AuthenticationType = BaseClasses.Configuration.SecurityConstants.None) Then
            
                Me.SIOImage.Visible = False  
                Me.SignIn.Visible = False    
        Me.Divider2.Visible = False
            Else
              
                Me.SIOImage.Visible = True  
                Me.SignIn.Visible = True 
                Me.UserStatusLbl.Visible = True 
            End If
          
                   
      Select Case (DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.GetUserStatus())
            Case Nothing, ""
              
                      Me.SignIn.Text = GetResourceValue("Txt:SignIn", "IROC2")
                      Me.SignIn.ToolTip = GetResourceValue("Txt:SignIn", "IROC2")
                    
          Me.SIOImage.ImageUrl = "../Images/SignInBarSignIn.gif"
          Me.SIOImage.Attributes.Add("onmouseover", "this.src='../Images/SignInBarSignInOver.gif'")
          Me.SIOImage.Attributes.Add("onmouseout", "this.src='../Images/SignInBarSignIn.gif'")
          Me.SIOImage.ToolTip = GetResourceValue("Txt:SignIn", "IROC2")
          
      Case Else
          
                Me.SignIn.Text = GetResourceValue("Txt:SignOut", "IROC2")
                Me.SignIn.ToolTip = GetResourceValue("Txt:SignOut", "IROC2")
              
          Me.SIOImage.ImageUrl = "../Images/SignInBarSignOut.gif"
          Me.SIOImage.Attributes.Add("onmouseover", "this.src='../Images/SignInBarSignOutOver.gif'")
          Me.SIOImage.Attributes.Add("onmouseout", "this.src='../Images/SignInBarSignOut.gif'")
          Me.SIOImage.ToolTip = GetResourceValue("Txt:SignOut", "IROC2")
          
        End Select
        End Sub
        'Performs SignIn and SignOut.
        Protected Overridable Sub SignInOutProceed(ByVal sender As Object)
          Dim url As String
          Dim deviceSize As String = DirectCast(Me.Page, BaseApplicationPage).CheckDeviceSize()
          Dim shouldRedirect As Boolean
          Select Case (DirectCast(Me.Page, BaseApplicationPage).CurrentSecurity.GetUserStatus())
          Case Nothing, ""
            If ( StringUtils.InvariantUCase(deviceSize).Equals(StringUtils.InvariantUCase("Small")) ) Then
              url = BaseClasses.Configuration.ApplicationSettings.Current.MobileSignInPageUrl()
            Else
              url = BaseClasses.Configuration.ApplicationSettings.Current.SignInPageUrl()
            End If

            url = ".." + url.Substring(BaseClasses.Configuration.ApplicationSettings.Current.AppRootPath.Length-1)
            shouldRedirect = True
            Try
              DbUtils.StartTransaction()
              url = CType(Me.Page, BaseApplicationPage).ModifyRedirectUrl(url, "", False)
              CType(Me.Page, BaseApplicationPage).CommitTransaction(sender)
            Catch ex As Exception
              CType(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
              shouldRedirect = False
              CType(Me.Page, BaseApplicationPage).ErrorOnPage = True
              BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
              DbUtils.EndTransaction()
            End Try
            If shouldRedirect Then
              CType(Me.Page, BaseApplicationPage).Response.Redirect(url)
            End If
          Case Else
            if ( StringUtils.InvariantUCase(deviceSize).Equals(StringUtils.InvariantUCase("Small")) ) Then
              url = BaseClasses.Configuration.ApplicationSettings.Current.MobileSignedOutPageUrl()
            Else
              url = BaseClasses.Configuration.ApplicationSettings.Current.SignedOutPageUrl()
            End If
            url = ".." + url.Substring(BaseClasses.Configuration.ApplicationSettings.Current.AppRootPath.Length-1)
            If Not String.IsNullOrEmpty(DirectCast(Session("AppCultureUI"), String)) Then
              url = url + "?cultureui=" + DirectCast(Session("AppCultureUI"), String)
            End If
            shouldRedirect = True
            Try
              DbUtils.StartTransaction()
              Me.LogOut()
              url = CType(Me.Page, BaseApplicationPage).ModifyRedirectUrl(url, "", False)
              CType(Me.Page, BaseApplicationPage).CommitTransaction(sender)
            Catch ex As Exception
              CType(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
              shouldRedirect = False
              CType(Me.Page, BaseApplicationPage).ErrorOnPage = True
              BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
              DbUtils.EndTransaction()
            End Try
            If shouldRedirect Then
              CType(Me.Page, BaseApplicationPage).ShouldSaveControlsToSession = True
            CType(Me.Page, BaseApplicationPage).Response.Redirect(url)
            End If
          End Select
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
        
        ' event handler for ImageButton
        Public Sub SIOImage_Click_Base(ByVal sender As Object, ByVal args As ImageClickEventArgs)
                               
              Me.SignInOutProceed(sender)            
                        
        End Sub
        
        ' event handler for LinkButton
        Public Sub SignIn_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
              Me.SignInOutProceed(sender)
                
        End Sub
            
        #Region "Interface Properties"
        
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Divider0() As System.Web.UI.WebControls.Image Implements IHeader.Divider0
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Divider0"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Divider1() As System.Web.UI.WebControls.Image Implements IHeader.Divider1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Divider1"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Divider2() As System.Web.UI.WebControls.Image Implements IHeader.Divider2
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Divider2"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property LeftImage() As System.Web.UI.WebControls.Image Implements IHeader.LeftImage
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_LeftImage"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Logo() As System.Web.UI.WebControls.Image Implements IHeader.Logo
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Logo"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property RightImage() As System.Web.UI.WebControls.Image Implements IHeader.RightImage
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_RightImage"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property SignIn() As System.Web.UI.WebControls.LinkButton Implements IHeader.SignIn
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_SignIn"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property SignInBarPrintButton() As System.Web.UI.WebControls.Image Implements IHeader.SignInBarPrintButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_SignInBarPrintButton"), System.Web.UI.WebControls.Image)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property SIOImage() As System.Web.UI.WebControls.ImageButton Implements IHeader.SIOImage
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_SIOImage"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property SkipNavigationLinks() As System.Web.UI.WebControls.HyperLink Implements IHeader.SkipNavigationLinks
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_SkipNavigationLinks"), System.Web.UI.WebControls.HyperLink)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property UserStatusLbl() As System.Web.UI.WebControls.Label Implements IHeader.UserStatusLbl
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_UserStatusLbl"), System.Web.UI.WebControls.Label)
            End Get
        End Property
                
      Public Overrides Property Visible() As Boolean Implements IHeader.Visible
  
          Get
              Return MyBase.Visible
          End Get
          Set(ByVal value As Boolean)
              MyBase.Visible = value
          End Set
      End Property
            
        #End Region
  
        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

            
    
#End Region

  

End Class
  
End Namespace

  