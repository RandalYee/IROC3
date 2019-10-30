Imports BaseClasses.Data
Imports BaseClasses.Utils.StringUtils
Imports BaseClasses.Utils
Imports BaseClasses.Resources
Imports IROC2.Business
Imports IROC2.Data
Imports BaseClasses.Web.UI

Imports System.Web.UI.DataVisualization.Charting
Namespace IROC2.UI
    ' Typical customizations that may be done in this class include
    '  - adding custom event handlers
    '  - overriding base class methods
    '
    ''' <summary>
    ''' The superclass (i.e. base class) for all Designer-generated pages in this application.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' </para>
    ''' </remarks>


    Public Class BaseApplicationPage
        Inherits BaseClasses.Web.UI.BasePage

        Private _Enctype As String = ""
        Public Property Enctype() As String
            Get
                Return Me._Enctype
            End Get
            Set(ByVal value As String)
                Me._Enctype = value
            End Set
        End Property

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreInit
            Dim selectedTheme As String = Me.GetSelectedTheme()
            If Not String.IsNullOrEmpty(selectedTheme) Then
                Me.Page.Theme = selectedTheme
            End If
        End Sub

        'Script to set focus to the last focused control

        Private Const SCRIPT_DOFOCUS As String = "" & _
                       "<script language=""javascript"" type=""text/javascript"">" & _
                       "var ctrl = ""{ControlClientID}""; var ctrlPB = ""{CtrlIDToFocusOnPostBack}""; " & _
                       "function pageLoadedHandler1(sender, args) { " & _
                       "if(!isPostBack()) {setTimeout(""setTimeoutFocus()"", 1000);} " & _
                       "else {setTimeout(""setPostBackFocus()"", 100);}}" & _
                       "function setTimeoutFocus() { setFocus(ctrl); }" & _
                       "function setPostBackFocus() { doFocus(ctrlPB);}" & _
                       "function doFocus(ctrlID) { if((ctrlID == null) || (ctrlID == """")) return;" & _
                       "try { var objToFocus = null; try { objToFocus = document.getElementById(ctrlID); } catch(ex) {}" & _
                       "if(!(!objToFocus ||(objToFocus==null)||(objToFocus==""""))){objToFocus.focus();}} catch(ex){ }}" & _
                       "function isPostBack() {if (!document.getElementById(""{clientSideIsPostBack}"")) return false;" & _
                       "if (document.getElementById(""{clientSideIsPostBack}"").value == ""Y"") return true;" & _
                       "else return false;}" & _
                       "Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoadedHandler1);</script>"


        'Add or remove controls if you do not want to retain focus on them
        Public Sub LoadFocusScripts(ByVal CurrentControl As Control)
            If TypeOf (CurrentControl) Is TextBox OrElse TypeOf (CurrentControl) Is DropDownList OrElse TypeOf (CurrentControl) Is ListBox OrElse _
            TypeOf (CurrentControl) Is Button OrElse TypeOf (CurrentControl) Is ImageButton OrElse TypeOf (CurrentControl) Is RadioButtonList OrElse _
            TypeOf (CurrentControl) Is RadioButton OrElse TypeOf (CurrentControl) Is LinkButton Then
                DirectCast(CurrentControl, WebControl).Attributes.Add("onfocus", "try{document.getElementById(""__LASTFOCUS"").value=this.id;}catch(e){}")
            End If
            If CurrentControl.HasControls() Then
                For Each CurrentChildControl As Control In CurrentControl.Controls
                    Me.LoadFocusScripts(CurrentChildControl)
                Next
            End If
        End Sub

        Public Overridable Sub SetFocusOnLoad()
            Me.SetFocusOnLoad(Nothing)
        End Sub

        '''Sets focus to the control with ctrlClientID. If empty string is passed, sets focus to the first focusable control
        Public Overridable Sub SetFocusOnLoad(ByVal currentControl As Control)
            Dim ctrlClientID As String = ""
            If currentControl IsNot Nothing Then
                ctrlClientID = currentControl.ClientID
                'currentControl.Focus()
            End If
            If Not ClientScript.IsStartupScriptRegistered(Page.GetType(), "SetFocusOnLoad") Then
                Dim _clientSideIsPostBack As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(Me.FindControlRecursively("_clientSideIsPostBack"), System.Web.UI.HtmlControls.HtmlInputHidden)
                Dim _clientSideIsPostBackID As String = "_clientSideIsPostBack"
                If Not _clientSideIsPostBack Is Nothing Then
                    _clientSideIsPostBackID = _clientSideIsPostBack.ClientID
                End If
                Dim script As String = SCRIPT_DOFOCUS
                script = script.Replace("{ControlClientID}", ctrlClientID)
                script = script.Replace("{clientSideIsPostBack}", _clientSideIsPostBackID)
                Dim id As String = Request.Item("__LASTFOCUS")
                If String.IsNullOrEmpty(id) Then
                    id = ""
                End If
                script = script.Replace("{CtrlIDToFocusOnPostBack}", id)
                Dim sm As ScriptManager = ScriptManager.GetCurrent(Me.Page)
                If sm.IsInAsyncPostBack Then
                    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "SetFocusOnPostback", script, False)
                Else
                    ClientScript.RegisterStartupScript(Page.GetType(), "SetFocusOnLoad", script, False)
                End If

            End If
        End Sub
        '''Verifies that this is editable control
        Public Overridable Function IsControlEditable(ByVal ctrl As Control, Optional ByVal includeCheckBox As Boolean = True) As Boolean
            If TypeOf ctrl Is System.Web.UI.WebControls.TextBox OrElse _
               TypeOf ctrl Is System.Web.UI.WebControls.DropDownList OrElse _
               TypeOf ctrl Is System.Web.UI.WebControls.ListBox OrElse _
               TypeOf ctrl Is System.Web.UI.WebControls.FileUpload Then
                Return True
            ElseIf includeCheckBox AndAlso TypeOf ctrl Is System.Web.UI.WebControls.CheckBox Then
                Return True
            End If
            Return False
        End Function

        Public Overridable Function GetSelectedTheme() As String
            'First try to get selected theme from Session
            Dim Session As System.Web.SessionState.HttpSessionState = HttpContext.Current.Session
            Dim selectedTheme As String = DirectCast(Session.Item(NetUtils.CookieSelectedTheme), String)
            If Not String.IsNullOrEmpty(selectedTheme) Then
                Return selectedTheme
            End If
            'There is no theme stored in session, possibly application is opened for the very first time.
            'Try to get theme from the cookie
            selectedTheme = BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieSelectedTheme)
            If Not String.IsNullOrEmpty(selectedTheme) Then
                'make sure theme exists in application
                Dim appDir As String = ""
                Try
                    appDir = System.Web.HttpContext.Current.Server.MapPath("/")
                    If Not String.IsNullOrEmpty(appDir) Then appDir = appDir & "App_Themes"
                Catch ex As Exception

                End Try
                If String.IsNullOrEmpty(appDir) Then
                    Try
                        appDir = System.Web.HttpContext.Current.Server.MapPath("")
                        If Not String.IsNullOrEmpty(appDir) Then
                            If Not System.IO.Directory.GetParent(appDir) Is Nothing Then
                                appDir = System.IO.Directory.GetParent(appDir).FullName & "\App_Themes"
                            ElseIf appDir.IndexOf("\") > 0 Then
                                appDir = appDir.Substring(0, appDir.LastIndexOf("\")) & "\App_Themes"
                            Else
                                appDir = ""
                            End If
                        End If
                    Catch ex As Exception
                        appDir = ""
                    End Try
                End If
                If Not String.IsNullOrEmpty(appDir) AndAlso System.IO.Directory.Exists(appDir) Then
                    If System.IO.Directory.Exists(System.IO.Path.Combine(appDir, selectedTheme)) Then
                        Session.Item(NetUtils.CookieSelectedTheme) = selectedTheme
                        Return selectedTheme
                    Else
                        BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieSelectedTheme, "")
                    End If
                End If
            End If
            Return ""
        End Function

        'Retrieve selected language from session or cookie
        Public Overridable Function GetSelectedLanguage() As String
            'First try to get selected language from Session
            Dim Session As System.Web.SessionState.HttpSessionState = HttpContext.Current.Session
            Dim selectedLanguage As String = DirectCast(Session("AppCultureUI"), String)
            If Not String.IsNullOrEmpty(selectedLanguage) Then Return selectedLanguage
            'There is no theme stored in session, possibly application is opened for the very first time.
            'Try to get theme from the cookie
            selectedLanguage = BaseClasses.Utils.NetUtils.GetCookie(NetUtils.CookieSelectedLanguage)
            If Not String.IsNullOrEmpty(selectedLanguage) Then
                Try
                    Dim culInfo As System.Globalization.CultureInfo = New System.Globalization.CultureInfo(selectedLanguage)
                    Session("AppCultureUI") = selectedLanguage
                    Return selectedLanguage
                Catch
                    'if exception happened this language is not supported
                    BaseClasses.Utils.NetUtils.SetCookie(NetUtils.CookieSelectedLanguage, "")
                    selectedLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
                    Session("AppCultureUI") = selectedLanguage
                End Try
            Else
                selectedLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
                Session("AppCultureUI") = selectedLanguage
            End If

            Return selectedLanguage

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'commented out because DataBind is being called multiple times.
            '        If (Not Me.IsPostBack) Then
            '            Me.DataBind()
            '        End If
        End Sub

        ' Variable used to prevent infinite loop
        Private _modifyRedirectUrlInProgress As Boolean = False

        ' Constant used for EvaluateExpressions
        Const PREFIX_NO_ENCODE As String = "NoUrlEncode:"

        ''' Allow for migration from earlier versions which did not have url encryption.
        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, False)
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, bEncrypt)
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, bEncrypt, includeSession)
        End Function

        Public Overridable Function EvaluateExpressions( _
            ByVal redirectUrl As String, _
            ByVal redirectArgument As String, _
            ByVal bEncrypt As Boolean, _
            ByVal includeSession As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, bEncrypt, Me, includeSession)
        End Function

        Public Overridable Function EvaluateExpressions( _
           ByVal redirectUrl As String, _
           ByVal redirectArgument As String, _
           ByVal bEncrypt As Boolean, _
           ByVal targetCtl As Control, _
           ByVal includeSession As Boolean) As String

            If (_modifyRedirectUrlInProgress) Then
                Return Nothing
            Else
                _modifyRedirectUrlInProgress = True
            End If

            Dim finalRedirectUrl As String = redirectUrl
            Dim finalRedirectArgument As String = redirectArgument


            Dim remainingUrl As String = finalRedirectUrl


            ' encrypt constant value
            If bEncrypt AndAlso targetCtl.GetType() Is Page.GetType() Then
                remainingUrl &= "&"
                finalRedirectUrl &= "&"


                While (remainingUrl.IndexOf("="c) >= 0) And (remainingUrl.IndexOf("&"c) > 0) And _
                   (remainingUrl.IndexOf("="c) < remainingUrl.IndexOf("&"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("="c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("&"c)
                    Dim encryptFrom As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)

                    remainingUrl = remainingUrl.Substring(rightIndex + 1)
                    If Not encryptFrom.StartsWith("{") OrElse Not encryptFrom.EndsWith("}") Then


                        ' check if it is already encrypted
                        Dim isEncrypted As Boolean = False
                        Try
                            If Decrypt(encryptFrom) <> "" Then
                                isEncrypted = True
                            End If
                        Catch

                        End Try

                        ' if not, process encryption
                        If Not isEncrypted Then
                            Dim encryptTo As String = BaseFormulaUtils.EncryptData(DirectCast(encryptFrom, String))
                            finalRedirectUrl = finalRedirectUrl.Replace("=" & encryptFrom & "&", "=" & encryptTo & "&")
                        End If
                    End If
                End While


                finalRedirectUrl = finalRedirectUrl.Trim("&"c)
            End If

            If (finalRedirectUrl Is Nothing OrElse finalRedirectUrl.Trim = "") Then
                Return ""
            ElseIf (finalRedirectUrl.IndexOf("{"c) < 0) Then
                'RedirectUrl does not contain any format specifiers
                _modifyRedirectUrlInProgress = False
                Return finalRedirectUrl
            Else
                'The old way was to pass separate URL and arguments and use String.Format to
                'do the replacement.  Example:
                '   URL:        EditProductsRecord?Products={0}
                '   Argument:   PK
                'The new way to is pass the arguments directly in the URL.  Example:
                '   URL:        EditProductsRecord?Products={PK}
                'If the old way is passsed, convert it to the new way.
                If (Len(redirectArgument) > 0) Then
                    Dim arguments() As String = Split(redirectArgument, ",")
                    Dim i As Integer
                    For i = 0 To (arguments.Length - 1)
                        finalRedirectUrl = finalRedirectUrl.Replace("{" & i.ToString & "}", "{" & arguments(i) & "}")
                    Next

                    finalRedirectArgument = ""
                End If

                'First find all the table and record controls in the page.
                Dim controlList As New ArrayList()
                GetAllRecordAndTableControls(targetCtl, controlList, True)
                If controlList.Count = 0 Then
                    Return finalRedirectUrl
                End If

                ' Store the controls in a hashtable using the control unique name
                ' as the key for easy refrence later in the function.
                Dim controlIdList As New Hashtable
                Dim control As System.Web.UI.Control
                Dim found As Boolean = False
                For Each control In controlList
                    Dim uID As String = control.UniqueID
                    Dim pageContentIndex As Integer = uID.IndexOf("$PageContent$")
                    If pageContentIndex > 0 Then
                        If found = False Then
                            'Remove all controls without $PageContent$ prefix, because this page is used with Master Page
                            'and these entries are irrelevant
                            controlIdList.Clear()
                        End If
                        found = True
                    End If
                    If found Then
                        'If we found that Master Page is used for this page construction than disregard all controls
                        'without $PageContent$ prefix
                        If pageContentIndex > 0 Then
                            uID = uID.Substring(pageContentIndex + "$PageContent$".Length)
                            controlIdList.Add(uID, control)
                        End If
                    Else
                        'No Master Page presense found so far
                        controlIdList.Add(uID, control)
                    End If
                Next

                'Look at all of the expressions in the URL and forward processing
                'to the appropriate controls.
                'Expressions can be of the form [ControlName:][NoUrlEncode:]Key[:Value]
                Dim forwardTo As New ArrayList

                remainingUrl = finalRedirectUrl
                While (remainingUrl.IndexOf("{"c) >= 0) And (remainingUrl.IndexOf("}"c) > 0) And _
                   (remainingUrl.IndexOf("{"c) < remainingUrl.IndexOf("}"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("{"c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("}"c)
                    Dim expression As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)
                    remainingUrl = remainingUrl.Substring(rightIndex + 1)

                    Dim prefix As String = Nothing
                    If (expression.IndexOf(":") > 0) Then
                        prefix = expression.Substring(0, expression.IndexOf(":"))
                    End If
                    If (Not IsNothing(prefix)) AndAlso (prefix.Length > 0) AndAlso _
                       (Not (InvariantLCase(prefix) = InvariantLCase(PREFIX_NO_ENCODE))) AndAlso _
                       (Not BaseRecord.IsKnownExpressionPrefix(prefix)) Then
                        'The prefix is a control name.  Add it to the list of controls that
                        'need to process the URL.
                        If (controlIdList.Contains(prefix)) And (Not forwardTo.Contains(prefix)) Then
                            forwardTo.Add(prefix)
                        End If
                    End If
                End While

                'Forward the request to each control in the forwardTo list
                Dim containerId As String
                For Each containerId In forwardTo
                    Dim ctl As Control = CType(controlIdList.Item(containerId), Control)
                    If (Not IsNothing(ctl)) Then
                        If TypeOf ctl Is BaseApplicationRecordControl Then
                            finalRedirectUrl = DirectCast(ctl, BaseApplicationRecordControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt, includeSession)
                        ElseIf TypeOf ctl Is BaseApplicationTableControl Then
                            finalRedirectUrl = DirectCast(ctl, BaseApplicationTableControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt, includeSession)
                        End If
                    End If
                Next

                'If there are any unresolved expressions, let the other naming containers
                'have a crack at modifying the URL
                For Each control In controlList
                    If (forwardTo.IndexOf(control.ID) < 0) Then
                        If TypeOf control Is BaseApplicationRecordControl Then

                            finalRedirectUrl = DirectCast(control, BaseApplicationRecordControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt, includeSession)

                        ElseIf TypeOf control Is BaseApplicationTableControl Then
                            finalRedirectUrl = DirectCast(control, BaseApplicationTableControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt, includeSession)
                        End If
                    End If
                Next
            End If

            _modifyRedirectUrlInProgress = False

            Return finalRedirectUrl
        End Function

        Public Overridable Function EvaluateExpressions( _
                ByVal redirectUrl As String, _
                ByVal redirectArgument As String, _
                ByVal bEncrypt As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, bEncrypt, Me)
        End Function

        Public Overridable Function EvaluateExpressions( _
                ByVal redirectUrl As String, _
                ByVal redirectArgument As String, _
                ByVal bEncrypt As Boolean, _
                ByVal targetCtl As Control) As String

            If (_modifyRedirectUrlInProgress) Then
                Return Nothing
            Else
                _modifyRedirectUrlInProgress = True
            End If

            Dim finalRedirectUrl As String = redirectUrl
            Dim finalRedirectArgument As String = redirectArgument


            Dim remainingUrl As String = finalRedirectUrl


            ' encrypt constant value
            If bEncrypt AndAlso targetCtl.GetType() Is Page.GetType() Then
                remainingUrl &= "&"
                finalRedirectUrl &= "&"


                While (remainingUrl.IndexOf("="c) >= 0) And (remainingUrl.IndexOf("&"c) > 0) And _
                   (remainingUrl.IndexOf("="c) < remainingUrl.IndexOf("&"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("="c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("&"c)
                    Dim encryptFrom As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)

                    remainingUrl = remainingUrl.Substring(rightIndex + 1)
                    If Not encryptFrom.StartsWith("{") OrElse Not encryptFrom.EndsWith("}") Then


                        ' check if it is already encrypted
                        Dim isEncrypted As Boolean = False
                        Try
                            If Decrypt(encryptFrom) <> "" Then
                                isEncrypted = True
                            End If
                        Catch

                        End Try

                        ' if not, process encryption
                        If Not isEncrypted Then
                            Dim encryptTo As String = DirectCast(Me.Page, BaseApplicationPage).Encrypt(DirectCast(encryptFrom, String))
                            finalRedirectUrl = finalRedirectUrl.Replace("=" & encryptFrom & "&", "=" & encryptTo & "&")
                        End If
                    End If
                End While


                finalRedirectUrl = finalRedirectUrl.Trim("&"c)
            End If

            If (finalRedirectUrl Is Nothing OrElse finalRedirectUrl.Trim = "") Then
                Return ""
            ElseIf (finalRedirectUrl.IndexOf("{"c) < 0) Then
                'RedirectUrl does not contain any format specifiers
                _modifyRedirectUrlInProgress = False
                Return finalRedirectUrl
            Else
                'The old way was to pass separate URL and arguments and use String.Format to
                'do the replacement.  Example:
                '   URL:        EditProductsRecord?Products={0}
                '   Argument:   PK
                'The new way to is pass the arguments directly in the URL.  Example:
                '   URL:        EditProductsRecord?Products={PK}
                'If the old way is passsed, convert it to the new way.
                If (Len(redirectArgument) > 0) Then
                    Dim arguments() As String = Split(redirectArgument, ",")
                    Dim i As Integer
                    For i = 0 To (arguments.Length - 1)
                        finalRedirectUrl = finalRedirectUrl.Replace("{" & i.ToString & "}", "{" & arguments(i) & "}")
                    Next

                    finalRedirectArgument = ""
                End If

                'First find all the table and record controls in the page.
                Dim controlList As New ArrayList()
                GetAllRecordAndTableControls(targetCtl, controlList, True)
                If controlList.Count = 0 Then
                    Return finalRedirectUrl
                End If

                ' Store the controls in a hashtable using the control unique name
                ' as the key for easy refrence later in the function.
                Dim controlIdList As New Hashtable
                Dim control As System.Web.UI.Control
                Dim found As Boolean = False
                For Each control In controlList
                    Dim uID As String = control.UniqueID
                    Dim pageContentIndex As Integer = uID.IndexOf("$PageContent$")
                    If pageContentIndex > 0 Then
                        If found = False Then
                            'Remove all controls without $PageContent$ prefix, because this page is used with Master Page
                            'and these entries are irrelevant
                            controlIdList.Clear()
                        End If
                        found = True
                    End If
                    If found Then
                        'If we found that Master Page is used for this page construction than disregard all controls
                        'without $PageContent$ prefix
                        If pageContentIndex > 0 Then
                            uID = uID.Substring(pageContentIndex + "$PageContent$".Length)
                            controlIdList.Add(uID, control)
                        End If
                    Else
                        'No Master Page presense found so far
                        controlIdList.Add(uID, control)
                    End If
                Next

                'Look at all of the expressions in the URL and forward processing
                'to the appropriate controls.
                'Expressions can be of the form [ControlName:][NoUrlEncode:]Key[:Value]
                Dim forwardTo As New ArrayList

                remainingUrl = finalRedirectUrl
                While (remainingUrl.IndexOf("{"c) >= 0) And (remainingUrl.IndexOf("}"c) > 0) And _
                   (remainingUrl.IndexOf("{"c) < remainingUrl.IndexOf("}"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("{"c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("}"c)
                    Dim expression As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)
                    remainingUrl = remainingUrl.Substring(rightIndex + 1)

                    Dim prefix As String = Nothing
                    If (expression.IndexOf(":") > 0) Then
                        prefix = expression.Substring(0, expression.IndexOf(":"))
                    End If
                    If (Not IsNothing(prefix)) AndAlso (prefix.Length > 0) AndAlso _
                       (Not (InvariantLCase(prefix) = InvariantLCase(PREFIX_NO_ENCODE))) AndAlso _
                       (Not BaseRecord.IsKnownExpressionPrefix(prefix)) Then
                        'The prefix is a control name.  Add it to the list of controls that
                        'need to process the URL.
                        If (controlIdList.Contains(prefix)) And (Not forwardTo.Contains(prefix)) Then
                            forwardTo.Add(prefix)
                        End If
                    End If
                End While

                'Forward the request to each control in the forwardTo list
                Dim containerId As String
                For Each containerId In forwardTo
                    Dim ctl As Control = CType(controlIdList.Item(containerId), Control)
                    If (Not IsNothing(ctl)) Then
                        If TypeOf ctl Is BaseApplicationRecordControl Then
                            finalRedirectUrl = DirectCast(ctl, BaseApplicationRecordControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt)
                        ElseIf TypeOf ctl Is BaseApplicationTableControl Then
                            finalRedirectUrl = DirectCast(ctl, BaseApplicationTableControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt)
                        End If
                    End If
                Next

                'If there are any unresolved expressions, let the other naming containers
                'have a crack at modifying the URL
                For Each control In controlList
                    If (forwardTo.IndexOf(control.ID) < 0) Then
                        If TypeOf control Is BaseApplicationRecordControl Then
                            finalRedirectUrl = DirectCast(control, BaseApplicationRecordControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt)
                        ElseIf TypeOf control Is BaseApplicationTableControl Then
                            finalRedirectUrl = DirectCast(control, BaseApplicationTableControl).EvaluateExpressions(finalRedirectUrl, finalRedirectArgument, bEncrypt)
                        End If
                    End If
                Next
            End If

            _modifyRedirectUrlInProgress = False

            Return finalRedirectUrl
        End Function

        Private Sub GetAllRecordAndTableControls(ByVal ctl As Control, ByVal controlList As ArrayList, ByVal withParents As Boolean)
            If ctl Is Nothing Then
                Return
            End If

            GetAllRecordAndTableControls(ctl, controlList)

            If withParents Then
                Dim parent As Control = ctl.Parent
                While parent IsNot Nothing
                    If TypeOf (parent) Is BaseApplicationRecordControl OrElse TypeOf (parent) Is BaseApplicationTableControl Then
                        controlList.Add(parent)
                    End If
                    parent = parent.Parent
                End While
            End If
        End Sub

        Private Function GetAllRecordAndTableControls() As ArrayList
            Dim controlList As ArrayList = New ArrayList()
            GetAllRecordAndTableControls(Me, controlList)
            Return controlList
        End Function

        Private Sub GetAllRecordAndTableControls(ByVal ctl As Control, ByVal controlList As ArrayList)
            If ctl Is Nothing Then
                Return
            End If

            If TypeOf ctl Is BaseApplicationRecordControl OrElse _
               TypeOf ctl Is BaseApplicationTableControl Then
                controlList.Add(ctl)
            End If

            Dim nextCtl As Control
            For Each nextCtl In ctl.Controls()
                GetAllRecordAndTableControls(nextCtl, controlList)
            Next
        End Sub


        Public Function GetResourceValue(ByVal keyVal As String, ByVal appName As String) As String
            Return AppResources.GetResourceValue(keyVal, appName)
        End Function

        Public Function GetResourceValue(ByVal keyVal As String) As String
            Return AppResources.GetResourceValue(keyVal, Nothing)
        End Function






        Public Function ExpandResourceValue(ByVal keyVal As String) As String
            Return AppResources.ExpandResourceValue(keyVal)
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Register Control buttonCtrl with ScriptManager to perform traditional postback instead of default async postback
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[sramarao]	3/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub RegisterPostBackTrigger(ByVal buttonCtrl As System.Web.UI.Control, ByVal updatePanelCtrl As System.Web.UI.Control)
            Try
                ' Get current ScriptManager
                Dim scriptMgr As ScriptManager = ScriptManager.GetCurrent(Me.Page)
                ' If Scriptmanager not preset return.
                If scriptMgr Is Nothing Then
                    Return
                End If
                ' If buttonCtrl is not surrounded by an UpdatePanel then return.
                Dim CurrentUpdatePanel As System.Web.UI.UpdatePanel = CType(updatePanelCtrl, UpdatePanel)
                If CurrentUpdatePanel Is Nothing Then
                    Return
                End If
                If buttonCtrl Is Nothing Then
                    Return
                End If
                scriptMgr.RegisterPostBackControl(buttonCtrl)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Sub RegisterPostBackTrigger(ByVal buttonCtrl As System.Web.UI.Control)
            Try
                ' Get current ScriptManager
                Dim scriptMgr As ScriptManager = ScriptManager.GetCurrent(Me.Page)
                ' If Scriptmanager not preset return.
                If scriptMgr Is Nothing Then
                    Return
                End If
                If buttonCtrl Is Nothing Then
                    Return
                End If
                scriptMgr.RegisterPostBackControl(buttonCtrl)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Overridable Sub SaveData()

        End Sub

        Public Overridable Sub SetChartControl(ByVal chartCtrlName As String)

        End Sub

#Region " Methods to manage saving and retrieving control values to session. "
        Private _ShouldSaveControlsToSession As Boolean = False
        Public Property ShouldSaveControlsToSession() As Boolean
            Get
                Return Me._ShouldSaveControlsToSession
            End Get
            Set(ByVal value As Boolean)
                Me._ShouldSaveControlsToSession = value
            End Set
        End Property

        Protected Sub Page_SaveControls_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Unload
            If Me.ShouldSaveControlsToSession Then
                Me.SaveControlsToSession()
            End If
        End Sub

        Protected Overridable Sub SaveControlsToSession()
        End Sub

        Protected Sub Control_ClearControls_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.PreRender
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub ClearControlsFromSession()
        End Sub

        Public Sub SaveToSession( _
            ByVal control As Control, _
            ByVal value As String)

            SaveToSession(control.UniqueID, value)
        End Sub

        Public Function GetFromSession( _
            ByVal control As Control, _
            ByVal defaultValue As String) As String

            Return GetFromSession(control.UniqueID, defaultValue)
        End Function

        Public Function GetFromSession(ByVal control As Control) As String
            Return GetFromSession(control.UniqueID, Nothing)
        End Function

        Public Sub RemoveFromSession(ByVal control As Control)
            RemoveFromSession(control.UniqueID)
        End Sub

        Public Function InSession(ByVal control As Control) As Boolean
            Return InSession(control.UniqueID)
        End Function

        Public Sub SaveToSession( _
            ByVal control As Control, _
            ByVal variable As String, _
            ByVal value As String)

            SaveToSession(control.UniqueID & variable, value)
        End Sub

        Public Function GetFromSession( _
            ByVal control As Control, _
            ByVal variable As String, _
            ByVal defaultValue As String) As String

            Return GetFromSession(control.UniqueID & variable, defaultValue)
        End Function

        Public Sub RemoveFromSession( _
            ByVal control As Control, _
            ByVal variable As String)

            RemoveFromSession(control.UniqueID & variable)
        End Sub

        Public Function InSession( _
            ByVal control As Control, _
            ByVal variable As String) As Boolean

            Return InSession(control.UniqueID & variable)
        End Function

        Public Sub SaveToSession( _
            ByVal name As String, _
            ByVal value As String)

            Me.Session()(GetValueKey(name)) = value
        End Sub

        Public Function GetFromSession( _
            ByVal name As String, _
            ByVal defaultValue As String) As String

            Dim value As String = CType(Me.Session()(GetValueKey(name)), String)
            If value Is Nothing OrElse value.Trim() = "" Then
                value = defaultValue
            End If

            Return value
        End Function

        Public Function GetFromSession(ByVal name As String) As String
            Return GetFromSession(name, Nothing)
        End Function

        Public Sub RemoveFromSession(ByVal name As String)
            Me.Session.Remove(GetValueKey(name))
        End Sub

        Public Function InSession(ByVal name As String) As Boolean
            Return (Not Me.Session(GetValueKey(name)) Is Nothing)
        End Function

        Public Function GetValueKey(ByVal name As String) As String
            Return Me.Session.SessionID & Me.AppRelativeVirtualPath & name
        End Function
#End Region
#Region " Methods to encrypt and decrypt URL parameters "


        ' The URLEncryptionKey is specified in the web.config.  The rightmost three characters of the current
        ' Session Id are concatenated with the URLEncryptionKey to provide added protection.  You can change
        ' this to anything you like by changing this function for the application.
        ' This function is private and not overridable because each page cannot have its own key - it must
        ' be common across the entire application.
        Public Overridable Function Encrypt(ByVal Source As String, Optional ByVal includeSession As Boolean = True) As String
            Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
            Return CheckCrypto.Encrypt(Source, includeSession)
        End Function

        Public Overridable Function Decrypt(ByVal Source As String, Optional ByVal includeSession As Boolean = True) As String
            Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
            Return CheckCrypto.Decrypt(Source, includeSession)
        End Function

        Public Overridable Function GetDecryptedURLParameter(ByVal name As String) As String
            Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
            Return CheckCrypto.GetDecryptedURLParameter(name, Me.Request)
        End Function

        ' Encrypt url parameter which is enclosed in {}. For eg:..\Shared\SelectFileToImport?TableName=Employees
        Public Function EncryptUrlParameter(ByVal url As String) As String
            If (url Is Nothing) Then
                Return ""
            End If

            If ((url.IndexOf(Microsoft.VisualBasic.ChrW(61)) > 0)) Then
                Dim queryString() As String = url.Split(Microsoft.VisualBasic.ChrW(61))
                Dim expression As String = queryString(1)
                Dim encryptedValue As String = Encrypt(expression)
                url = url.Replace(expression, encryptedValue)

            End If
            Return url
        End Function
#End Region

#Region "Import Wizard methods"
        Public Overridable Function GetPreviousURL() As String
            Me.RemoveCurrentRequestFromSessionNavigationHistory()

            Dim snh As BaseClasses.Web.SessionNavigationHistory = Me.GetSessionNavigationHistory()
            Dim prevUrl As String = Nothing
            Dim toRemoveRequest As Boolean = False
            If Not snh Is Nothing Then
                Dim prevRequest As BaseClasses.Web.SessionNavigationHistory.RequestInfo = snh.GetCurrentRequest()
                If (Not IsNothing(prevRequest)) Then
                    If (InvariantUCase(Me.Request.Url.PathAndQuery) <> InvariantUCase(prevRequest._Url.PathAndQuery)) Then
                        'If it is different than the current URL, redirect to the previous request's URL
                        toRemoveRequest = True
                        prevUrl = prevRequest._Url.PathAndQuery
                    ElseIf ((Not IsNothing(prevRequest._UrlReferrer)) AndAlso _
                            (InvariantUCase(Me.Request.Url.PathAndQuery) <> InvariantUCase(prevRequest._UrlReferrer.PathAndQuery))) Then
                        'ElseIf it is different than the current URL, redirect to the previous request's URLReferrer
                        toRemoveRequest = True
                        prevUrl = prevRequest._UrlReferrer.PathAndQuery
                    End If
                End If
            End If

            If String.IsNullOrEmpty(prevUrl) Then
                prevUrl = BaseClasses.Configuration.ApplicationSettings.Current.DefaultPageUrl
            End If
            Return prevUrl
        End Function
#End Region

#Region "Chart control initialization"


        Public Const PIE As String = "Pie"
        Public Const LINE As String = "Line"
        Public Const BAR As String = "Bar"
        Public Const COLUMN As String = "Column"
        Public Const LabelInsideBar As String = "Label inside bar"
        Public Const ValueAtBarEnd As String = "Value at bar end"
        Public Const NothingInside As String = "Nothing"


        ''' <summary>
        ''' Creates chart control based on the passed parameters
        ''' </summary>
        ''' <param name="barThickness"> How thick the bar or column</param>
        ''' <param name="chartType">Bar, Column, Pie or Line</param>
        ''' <param name="usePalette">If true - uses Palette, otherwise - single color. For Pie chart palette is used regardless of this parameter</param>
        ''' <param name="palette">One of the palette in Windows.Forms.DataVisualization.ChartColorPalette </param>
        ''' <param name="color">One of the colors in Drawing.Color. Used for the bars, columns, or line</param>
        ''' <param name="fontFamily">One of the font familie as defined in Drawinf.FontFamily (string)</param>
        ''' <param name="fontColor">color of the font used for all texts - labels and values (from Drawing.color)</param>
        ''' <param name="backGroundColor">Background on the chart area. From Drawing.Color</param>
        ''' <param name="gridColor">The color used on all grid lines and markers. From Drawing.Color</param>
        ''' <param name="title">Title of the chart</param>
        ''' <param name="indexAxisTitle">Title on the Axis with labels</param>
        ''' <param name="valueAxisTitle">Title on the axis with values</param>
        ''' <param name="indexArray">Array of labels (String)</param>
        ''' <param name="valueArray">Array of values (Decimal)</param>
        ''' <param name="labelAngle">If 0, label on the X axis is shown horizontally, if negative, it is tilted counter clock wize, if positive,
        ''' tilted colck wise. Could be from -90 to 90. (degrees)</param>
        ''' <param name="customProperties">Added to custom properties to series. To the list of supported properties refer to
        ''' http://msdn.microsoft.com/en-us/library/dd456764.aspx</param>
        ''' <remarks></remarks>
        Public Overridable Sub InitializeChartControl(ByVal chartControl As Chart, _
                                                      ByVal indexArray() As String, _
                                                      ByVal valueArray() As Decimal, _
                                                      ByVal barThickness As Integer, _
                                                      ByVal chartType As String, _
                                                      ByVal usePalette As Boolean, _
                                                      ByVal palette As ChartColorPalette, _
                                                      ByVal color As Drawing.Color, _
                                                      ByVal backGroundColor As System.Drawing.Color, _
                                                      ByVal gridColor As System.Drawing.Color, _
                                                      ByVal fontFamily As String, _
                                                      ByVal fontColor As System.Drawing.Color, _
                                                      ByVal internalLabelColor As System.Drawing.Color, _
                                                      ByVal showInsideBar As String, _
                                                      ByVal title As String, _
                                                      ByVal indexAxisTitle As String, _
                                                      ByVal valueAxisTitle As String, _
                                                      ByVal labelAngle As Integer, _
                                                      ByVal generatePercentage As Boolean, _
                                                      ByVal labelFormat As String, _
                                                      ByVal customProperties As String)

            Dim args As New System.Collections.Generic.List(Of Object)
            args.Add(chartControl)
            args.Add(indexArray)
            args.Add(valueArray)
            args.Add(Nothing)
            args.Add(Nothing)
            args.Add(barThickness)
            args.Add(chartType)
            args.Add(usePalette)
            args.Add(palette)
            args.Add(color)
            args.Add(backGroundColor)
            args.Add(gridColor)
            args.Add(fontFamily)
            args.Add(fontColor)
            args.Add(internalLabelColor)
            args.Add(showInsideBar)
            args.Add(title)
            args.Add(indexAxisTitle)
            args.Add(valueAxisTitle)
            args.Add(labelAngle)
            args.Add(generatePercentage)
            args.Add(labelFormat)
            args.Add("")
            args.Add("")
            args.Add("")
            args.Add("")
            args.Add("")
            args.Add(customProperties)
            InitializeChartControl(args.ToArray())
        End Sub


        ''' <summary>
        ''' Creates chart control based on the passed parameters
        ''' </summary>
        ''' <param name="args"> parameters to initialize the chart
        ''' http://msdn.microsoft.com/en-us/library/dd456764.aspx</param>
        ''' <remarks>chart control or Nothing</remarks>
        Public Overridable Sub InitializeChartControl(ByVal args() As Object)

            Dim chartControl As Chart = Nothing
            Dim indexArray() As String = Nothing
            Dim valueArray() As Decimal = Nothing
            Dim legendURLArray() As String = Nothing
            Dim dataPointURLArray() As String = Nothing
            Dim barThickness As Integer = 3
            Dim chartType As String = Nothing
            Dim usePalette As Boolean = False
            Dim palette As ChartColorPalette = ChartColorPalette.None
            Dim color As Drawing.Color = Drawing.Color.White
            Dim backGroundColor As System.Drawing.Color = Drawing.Color.White
            Dim gridColor As System.Drawing.Color = Drawing.Color.Black
            Dim fontFamily As String = Nothing
            Dim fontColor As System.Drawing.Color = Drawing.Color.Black
            Dim internalLabelColor As System.Drawing.Color = Drawing.Color.Black
            Dim showInsideBar As String = ""
            Dim title As String = ""
            Dim indexAxisTitle As String = ""
            Dim valueAxisTitle As String = ""
            Dim labelAngle As Integer = 0
            Dim generatePercentage As Boolean = False
            Dim labelFormat As String = Nothing
            Dim chartTitleFontSize As String = ""
            Dim axisTitleFontSize As String = ""
            Dim scaleFontSize As String = ""
            Dim labelInsideFontSize As String = ""
            Dim customProperties As String = ""


            If args.Length > 0 AndAlso args(0) IsNot Nothing Then
                chartControl = DirectCast(args(0), Chart)
            End If
            If args.Length > 1 AndAlso args(1) IsNot Nothing Then
                indexArray = DirectCast(args(1), String())
            End If
            If args.Length > 2 AndAlso args(2) IsNot Nothing Then
                valueArray = DirectCast(args(2), Decimal())
            End If
            If args.Length > 3 AndAlso args(3) IsNot Nothing Then
                legendURLArray = DirectCast(args(3), String())
            End If
            If args.Length > 4 AndAlso args(4) IsNot Nothing Then
                dataPointURLArray = DirectCast(args(4), String())
            End If
            If args.Length > 5 AndAlso args(5) IsNot Nothing Then
                barThickness = DirectCast(args(5), Integer)
            End If
            If args.Length > 6 AndAlso args(6) IsNot Nothing Then
                chartType = DirectCast(args(6), String)
            End If
            If args.Length > 7 AndAlso args(7) IsNot Nothing Then
                usePalette = DirectCast(args(7), Boolean)
            End If
            If args.Length > 8 AndAlso args(8) IsNot Nothing Then
                palette = DirectCast(args(8), ChartColorPalette)
            End If
            If args.Length > 9 AndAlso args(9) IsNot Nothing Then
                color = DirectCast(args(9), Drawing.Color)
            End If
            If args.Length > 10 AndAlso args(10) IsNot Nothing Then
                backGroundColor = DirectCast(args(10), Drawing.Color)
            End If
            If args.Length > 11 AndAlso args(11) IsNot Nothing Then
                gridColor = DirectCast(args(11), Drawing.Color)
            End If
            If args.Length > 12 AndAlso args(12) IsNot Nothing Then
                fontFamily = DirectCast(args(12), String)
            End If
            If args.Length > 13 AndAlso args(13) IsNot Nothing Then
                fontColor = DirectCast(args(13), Drawing.Color)
            End If
            If args.Length > 14 AndAlso args(14) IsNot Nothing Then
                internalLabelColor = DirectCast(args(14), Drawing.Color)
            End If
            If args.Length > 15 AndAlso args(15) IsNot Nothing Then
                showInsideBar = DirectCast(args(15), String)
            End If
            If args.Length > 16 AndAlso args(16) IsNot Nothing Then
                title = DirectCast(args(16), String)
            End If
            If args.Length > 17 AndAlso args(17) IsNot Nothing Then
                indexAxisTitle = DirectCast(args(17), String)
            End If
            If args.Length > 18 AndAlso args(18) IsNot Nothing Then
                valueAxisTitle = DirectCast(args(18), String)
            End If
            If args.Length > 19 AndAlso args(19) IsNot Nothing Then
                labelAngle = DirectCast(args(19), Integer)
            End If
            If args.Length > 20 AndAlso args(20) IsNot Nothing Then
                generatePercentage = DirectCast(args(20), Boolean)
            End If
            If args.Length > 21 AndAlso args(21) IsNot Nothing Then
                labelFormat = DirectCast(args(21), String)
            End If
            If args.Length > 22 AndAlso args(22) IsNot Nothing Then
                chartTitleFontSize = DirectCast(args(22), String)
            End If
            If args.Length > 23 AndAlso args(23) IsNot Nothing Then
                axisTitleFontSize = DirectCast(args(23), String)
            End If
            If args.Length > 24 AndAlso args(24) IsNot Nothing Then
                scaleFontSize = DirectCast(args(24), String)
            End If
            If args.Length > 25 AndAlso args(25) IsNot Nothing Then
                labelInsideFontSize = DirectCast(args(25), String)
            End If
            If args.Length > 26 AndAlso args(26) IsNot Nothing Then
                customProperties = DirectCast(args(26), String)
            End If



            'Add chart area to the control
            Dim baseChartAreaName As String = "ChartArea"
            Dim chartAreaName As String = "ChartArea1"
            If Not chartControl.ChartAreas Is Nothing AndAlso chartControl.ChartAreas.Count > 0 Then
                Dim suffix As Integer = 1
                Dim found As Boolean = True

                While found AndAlso suffix < 100
                    chartAreaName = baseChartAreaName & suffix.ToString()
                    found = False
                    For Each ca As ChartArea In chartControl.ChartAreas
                        If ca.Name = chartAreaName Then
                            found = True
                            suffix += 1
                            Exit For
                        End If
                    Next
                End While
                If found Then Return
            End If
            Dim chartArea As ChartArea = chartControl.ChartAreas.Add(chartAreaName)

            chartArea.AxisX.TitleForeColor = fontColor
            chartArea.AxisY.TitleForeColor = fontColor

            chartArea.AxisX.TitleFont = New System.Drawing.Font(fontFamily, If(Integer.TryParse(chartTitleFontSize, 0), _
                                                                                (If(Integer.TryParse(axisTitleFontSize, 0), Integer.Parse(axisTitleFontSize), chartArea.AxisX.TitleFont.Size)) _
                                                                                    , chartArea.AxisX.TitleFont.Size))
            chartArea.AxisY.TitleFont = New System.Drawing.Font(fontFamily, If(Integer.TryParse(chartTitleFontSize, 0), _
                                                                                (If(Integer.TryParse(axisTitleFontSize, 0), Integer.Parse(axisTitleFontSize), chartArea.AxisY.TitleFont.Size)) _
                                                                                    , chartArea.AxisY.TitleFont.Size))
            chartArea.AxisY.IsLabelAutoFit = True
            chartArea.AxisX.IsLabelAutoFit = False
            chartArea.AxisX.Interval = 1
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
            chartArea.AxisX.LabelStyle.ForeColor = fontColor
            chartArea.AxisY.LabelStyle.ForeColor = fontColor
            chartArea.AxisX.LabelStyle.Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(scaleFontSize, 0), Integer.Parse(scaleFontSize), chartArea.AxisX.LabelStyle.Font.Size))
            chartArea.AxisX.LineColor = gridColor
            chartArea.AxisY.LineColor = gridColor
            chartArea.AxisX.MajorTickMark.LineColor = gridColor
            chartArea.AxisY.MajorTickMark.LineColor = gridColor
            chartArea.AxisX.LabelStyle.Enabled = True
            chartArea.AxisY.LabelStyle.Enabled = True
            chartArea.AxisX.Title = indexAxisTitle
            chartArea.AxisY.Title = valueAxisTitle
            chartArea.AxisY.LabelStyle.Format = labelFormat
            If generatePercentage Then
                chartArea.AxisY.LabelStyle.Format = "0%"
            End If
            chartArea.AxisY.LabelStyle.Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(scaleFontSize, 0), Integer.Parse(scaleFontSize), chartArea.AxisY.LabelStyle.Font.Size))
            chartArea.BackColor = backGroundColor
            'Now add Series
            Dim baseSeriesName As String = "Series"
            Dim seriesName As String = "Series1"
            If Not chartControl.Series Is Nothing AndAlso chartControl.Series.Count > 0 Then
                Dim suffix As Integer = 1
                Dim found As Boolean = True

                While found AndAlso suffix < 100
                    seriesName = baseSeriesName & suffix.ToString()
                    found = False
                    For Each s As Series In chartControl.Series
                        If s.Name = seriesName Then
                            found = True
                            suffix += 1
                            Exit For
                        End If
                    Next
                End While
                If found Then Return
            End If
            Dim series As Series = chartControl.Series.Add(seriesName)

            series.ChartArea = chartAreaName
            chartControl.Series(seriesName).Points.Clear()
            chartControl.Series(seriesName).BackGradientStyle = GradientStyle.None
            chartControl.Series(seriesName).BackHatchStyle = ChartHatchStyle.None
            chartControl.Series(seriesName).Font = New System.Drawing.Font(fontFamily, 6)
            chartControl.Series(seriesName).LabelForeColor = fontColor
            chartControl.Series(seriesName).SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes
            chartControl.AntiAliasing = AntiAliasingStyles.All

            If usePalette OrElse chartType = PIE Then
                chartControl.Series(seriesName).Palette = palette
            Else
                chartControl.Series(seriesName).Color = color
            End If

            Dim baseTitleName As String = "Title"
            Dim TitleName As String = "Title1"
            If Not chartControl.Titles Is Nothing AndAlso chartControl.Titles.Count > 0 Then
                Dim suffix As Integer = 1
                Dim found As Boolean = True

                While found AndAlso suffix < 100
                    TitleName = baseTitleName & suffix.ToString()
                    found = False
                    For Each t As Title In chartControl.Titles
                        If t.Name = TitleName Then
                            found = True
                            suffix += 1
                            Exit For
                        End If
                    Next
                End While
                If found Then Return
            End If
            Dim titleIndex As Integer = chartControl.Titles.Count - 1
            chartControl.Titles.Add(TitleName).Text = title
            titleIndex += 1
            chartControl.Titles(titleIndex).ForeColor = fontColor
            chartControl.Titles(titleIndex).Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(chartTitleFontSize, 0), Integer.Parse(chartTitleFontSize), chartArea.AxisY.TitleFont.Size))

            Dim dataSet As New System.Data.DataSet()
            Dim seriesTable As New System.Data.DataTable()
            Dim cProperties As String = customProperties
            seriesTable.Columns.Add(New System.Data.DataColumn("X", GetType(String)))
            If (labelFormat = "0") Then
                seriesTable.Columns.Add(New System.Data.DataColumn("Y", GetType(Integer)))
            Else
                seriesTable.Columns.Add(New System.Data.DataColumn("Y", GetType(Double)))
            End If

            'Append cProperties with some style qualifiers

            If Not cProperties.ToLower.Contains("DrawingStyle".ToLower) Then
                If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                cProperties &= "DrawingStyle = Emboss"
            End If

            If String.Equals(showInsideBar, LabelInsideBar, StringComparison.InvariantCultureIgnoreCase) AndAlso _
            chartType <> PIE Then

                If Not cProperties.ToLower.Contains("BarLabelStyle".ToLower) Then
                    If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                    cProperties &= "BarLabelStyle = Center"
                End If

            End If
            If chartType = PIE Then
                If showInsideBar = ValueAtBarEnd Then
                    If Not cProperties.ToLower.Contains("PieLabelStyle".ToLower) Then
                        If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                        cProperties &= "PieLabelStyle = Outside"
                    End If

                Else
                    If Not cProperties.ToLower.Contains("PieLabelStyle".ToLower) Then
                        If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                        cProperties &= "PieLabelStyle = Inside"
                    End If

                End If
                If Not cProperties.ToLower.Contains("PieDrawingStyle".ToLower) Then
                    If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                    cProperties &= "PieDrawingStyle = Concave"
                End If

            End If

            Select Case chartType
                Case BAR
                    chartArea.AxisY.LabelStyle.Angle = labelAngle
                    series.ChartType = SeriesChartType.Bar
                    If Not cProperties.ToLower.Contains("PixelPointWidth".ToLower) Then
                        Dim barWidth As String = "PixelPointWidth = " & barThickness
                        If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                        cProperties &= barWidth
                    End If
                Case COLUMN
                    chartArea.AxisX.LabelStyle.Angle = labelAngle
                    series.ChartType = SeriesChartType.Column
                    If Not cProperties.ToLower.Contains("PixelPointWidth".ToLower) Then
                        Dim barWidth As String = "PixelPointWidth = " & barThickness
                        If Not String.IsNullOrEmpty(cProperties) AndAlso Not cProperties.EndsWith(",") Then cProperties &= ","
                        cProperties &= barWidth
                    End If
                Case LINE
                    chartArea.AxisX.LabelStyle.Angle = labelAngle
                    series.ChartType = SeriesChartType.Line
                Case PIE
                    chartControl.Series(seriesName).BorderColor = System.Drawing.Color.LightGray
                    chartControl.Series(seriesName).BorderWidth = 1
                    series.ChartType = SeriesChartType.Pie
                    'Construct Legend
                    Dim baseLegendName As String = "Legend"
                    Dim legendName As String = "Legend1"
                    If Not chartControl.Legends Is Nothing AndAlso chartControl.Legends.Count > 0 Then
                        Dim suffix As Integer = 1
                        Dim found As Boolean = True
                        While found AndAlso suffix < 100
                            legendName = baseLegendName & suffix.ToString()
                            found = False
                            For Each l As Legend In chartControl.Legends
                                If l.Name = legendName Then
                                    found = True
                                    suffix += 1
                                    Exit For
                                End If
                            Next
                        End While
                        If found Then Return
                    End If
                    Dim legend As System.Web.UI.DataVisualization.Charting.Legend = chartControl.Legends.Add(legendName)
                    legend.Title = indexAxisTitle
                    legend.ForeColor = fontColor
                    legend.TitleFont = New System.Drawing.Font(fontFamily, If(Integer.TryParse(axisTitleFontSize, 0), Integer.Parse(axisTitleFontSize), legend.TitleFont.Size))
                    legend.Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(scaleFontSize, 0), Integer.Parse(scaleFontSize), legend.Font.Size))
                    legend.TitleForeColor = chartArea.AxisX.TitleForeColor
            End Select
            chartControl.Series(seriesName).CustomProperties = cProperties

            'Sanity check for label and value arrays. They should not be empty
            If indexArray Is Nothing OrElse valueArray Is Nothing Then
                Return
            End If

            'Add data to data table. For Bar chart add them in the reversed order
            Dim dimention As Integer = indexArray.Length - 1
            If dimention > valueArray.Length - 1 Then dimention = valueArray.Length - 1
            If chartType = BAR Then
                For i As Integer = dimention To 0 Step -1
                    seriesTable.Rows.Add(New Object() {indexArray(i), Convert.ToDouble(valueArray(i))})
                Next
                If legendURLArray IsNot Nothing AndAlso legendURLArray.Length > 0 Then
                    Array.Reverse(legendURLArray)
                End If
                If dataPointURLArray IsNot Nothing AndAlso dataPointURLArray.Length > 0 Then
                    Array.Reverse(dataPointURLArray)
                End If
            Else
                For i As Integer = 0 To dimention
                    seriesTable.Rows.Add(New Object() {indexArray(i), Convert.ToDouble(valueArray(i))})
                Next
            End If


            dataSet.Tables.Add(seriesTable)

            series.BorderWidth = 2
            chartControl.Series(seriesName).XValueMember = "X"
            chartControl.Series(seriesName).YValueMembers = "Y"

            chartControl.DataSource = dataSet
            If chartControl.DataSource Is Nothing Then
                Return
            Else
                chartControl.DataBind()
            End If



            'now when data bound to the chart, change some properties on particular elements (data points) of series
            If chartType = PIE Then
                For Each dp As DataPoint In chartControl.Series(seriesName).Points
                    If showInsideBar = ValueAtBarEnd Then
                        dp.LabelForeColor = fontColor
                    Else
                        dp.LabelForeColor = internalLabelColor
                    End If

                    Dim value As Double = dp.YValues(0)
                    dp.Label = value.ToString(labelFormat)
                    If Not String.IsNullOrEmpty(dp.AxisLabel) Then
                        dp.LegendText = "#AXISLABEL"
                    Else
                        dp.LegendText = " "
                    End If

                Next

                For i As Integer = 0 To chartControl.Series(seriesName).Points.Count - 1
                    Dim dp As DataPoint = chartControl.Series(seriesName).Points(i)
                    If legendURLArray IsNot Nothing AndAlso i < legendURLArray.Length Then
                        dp.LegendUrl = legendURLArray(i)
                        dp.LegendMapAreaAttributes = "target=""_blank"""
                    End If
                    If dataPointURLArray IsNot Nothing AndAlso i < dataPointURLArray.Length Then
                        dp.Url = dataPointURLArray(i)
                        dp.MapAreaAttributes = "target=""_blank"""
                    End If
                    dp.Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(scaleFontSize, 0), Integer.Parse(scaleFontSize), dp.Font.Size))

                Next

            Else
                If showInsideBar = ValueAtBarEnd Then

                    ' find out the largest value to be shown
                    Dim largestValInChart As Decimal = Decimal.MinValue
                    For Each v As Decimal In valueArray
                        If largestValInChart < v Then
                            largestValInChart = v
                        End If
                    Next


                    For Each dp As DataPoint In chartControl.Series(seriesName).Points
                        dp.MarkerStyle = MarkerStyle.None
                        Dim value As Double = dp.YValues(0)
                        dp.Label = value.ToString(labelFormat)
                        dp.LabelForeColor = fontColor
                        dp.CustomProperties = "BarLabelStyle = Outside"

                        ' for small value, show the label outside
                        ' for large value, show the label inside
                        If chartType = BAR AndAlso (largestValInChart / 2) < value Then
                            dp.LabelForeColor = internalLabelColor
                            dp.CustomProperties = "BarLabelStyle = Right"
                        End If
                    Next
                ElseIf showInsideBar = LabelInsideBar Then
                    If chartControl.Series(seriesName).Points.Count = indexArray.Length Then
                        Dim index As Integer = 0
                        Dim increment As Integer = 1
                        Dim lColor As Drawing.Color = fontColor
                        chartArea.AxisX.LabelStyle.Enabled = False
                        If chartType = BAR Then
                            lColor = internalLabelColor
                            index = indexArray.Length - 1
                            increment = -1
                        End If
                        For Each dp As DataPoint In chartControl.Series(seriesName).Points
                            dp.MarkerStyle = MarkerStyle.None
                            dp.CustomProperties = "BarLabelStyle = Center"
                            dp.LabelForeColor = lColor
                            dp.Label = indexArray(index)
                            index += increment
                        Next
                    End If
                End If
                For i As Integer = 0 To chartControl.Series(seriesName).Points.Count - 1
                    Dim dp As DataPoint = chartControl.Series(seriesName).Points(i)
                    If String.IsNullOrEmpty(dp.AxisLabel) Then
                        dp.AxisLabel = " "
                    End If
                    If legendURLArray IsNot Nothing AndAlso i < legendURLArray.Length Then
                        dp.LegendUrl = legendURLArray(i)
                        dp.LegendMapAreaAttributes = "target=""_blank"""
                    End If
                    If dataPointURLArray IsNot Nothing AndAlso i < dataPointURLArray.Length Then
                        dp.Url = dataPointURLArray(i)
                        dp.MapAreaAttributes = "target=""_blank"""
                    End If
                    dp.Font = New System.Drawing.Font(fontFamily, If(Integer.TryParse(labelInsideFontSize, 0), Integer.Parse(labelInsideFontSize), dp.Font.Size))

                Next
            End If
        End Sub

#End Region

        ''' <summary>
        ''' Forms the ExportFieldValue URL for the Image to Render
        ''' For Instance - "../Shared/ExportFieldValue.aspx?"
        ''' </summary>
        ''' <returns>ExportFieldValue URL for the Image with the Background styles</returns>
        Public Function GetImageWithOverlaidText(ByVal imgFieldName As String, ByVal dataSource As PrimaryKeyRecord, ByVal otherFieldName As Object, ByVal redirectURL As String) As String
            If IsNothing(dataSource) Then Return ""

            Dim imgURL As String = ""
            If Not String.IsNullOrEmpty(imgFieldName) Then
                Dim col As BaseColumn = dataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(imgFieldName)

                If IsNothing(col) Then
                    Return "Invalid column name For image type"
                End If

                Select Case col.ColumnType
                    Case BaseColumn.ColumnTypes.Binary, _
                            BaseColumn.ColumnTypes.Image
                        imgURL = dataSource.FormatImageUrl(col, Encrypt(col.TableDefinition.TableCodeName), Encrypt(col.UniqueName), Encrypt(dataSource.GetID().ToXmlString()))
                End Select
            End If

            Return GetImageWithOverlaidText(imgURL, otherFieldName, redirectURL)
        End Function

        ''' <summary>
        ''' Forms the ExportFieldValue URL for the Image to Render
        ''' For Instance - "../Shared/ExportFieldValue.aspx?"
        ''' </summary>
        ''' <returns>ExportFieldValue URL for the Image with the Background styles</returns>
        Public Function GetImageWithOverlaidText(ByVal imgFieldName As String, ByVal dataSource As KeylessRecord, ByVal otherFieldName As Object, ByVal redirectURL As String) As String
            If IsNothing(dataSource) Then Return ""

            Dim imgURL As String = ""
            If Not String.IsNullOrEmpty(imgFieldName) Then
                Dim col As BaseColumn = dataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(imgFieldName)

                If IsNothing(col) Then
                    Return "Invalid column name For image type"
                End If

                Select Case col.ColumnType
                    Case BaseColumn.ColumnTypes.Binary, _
                            BaseColumn.ColumnTypes.Image
                        imgURL = dataSource.FormatImageUrl(col, Encrypt(col.TableDefinition.TableCodeName), Encrypt(col.UniqueName), Encrypt(dataSource.GetDefaultID().ToXmlString()))
                End Select
            End If

            Return GetImageWithOverlaidText(imgURL, otherFieldName, redirectURL)
        End Function

        ''' <summary>
        ''' Add the style for the image to appear in the background
        ''' </summary>
        ''' <returns>ExportFieldValue URL for the Image with the Background styles</returns>
        Public Function GetImageWithOverlaidText(ByVal imgURL As String, ByVal otherFieldName As Object, ByVal redirectURL As String) As String
            Dim fieldValue As String = ""
            If Not IsNothing(otherFieldName) Then
                fieldValue = otherFieldName.ToString()
            End If

            Dim redirectAndImageURLString As String = ""
            If String.IsNullOrEmpty(redirectURL) Then
                If String.IsNullOrEmpty(imgURL) Then
                    redirectAndImageURLString = "<div class=""galleryBackgroundImage"">"
                Else
                    redirectAndImageURLString = "<div class=""galleryBackgroundImage"" style=""background-image: url('" + imgURL + "');"">"
                End If
            Else
                If String.IsNullOrEmpty(imgURL) Then
                    redirectAndImageURLString = "<div onClick=""document.location.href='" + redirectURL + "'"" class=""galleryBackgroundImage"">"
                Else
                    redirectAndImageURLString = "<div onClick=""document.location.href='" + redirectURL + "'"" class=""galleryBackgroundImage"" style=""background-image: url('" + imgURL + "');"">"
                End If
            End If

            Dim fieldString As String = ""
            If String.IsNullOrEmpty(fieldValue) Then
                fieldString = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width: 100%;""><tr><td class=""galleryDescriptionBackground""></td></tr></table></div>"
            Else
                Dim param As String = "<span class=""galleryTitle"">" + fieldValue + "</span><br/>"
                fieldString = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width: 100%;""><tr><td class=""galleryDescriptionBackground""><div class=""galleryTitleCrop"">" + param + "</div></td></tr></table></div>"
            End If

            Return redirectAndImageURLString & fieldString
        End Function

        ' sort the list item using bubble sort
        <System.Web.Services.WebMethod()> _
        Public Shared Function SortListItems(ByVal str As String) As String
            ' the input is JSON in string which is passed by 
            Dim list As ListItemCollection = MiscUtils.DeserializeJSON(str)
            Dim items As ListItem() = New ListItem(list.Count - 1) {}
            list.CopyTo(items, 0)
            Dim temp As ListItem
            For write As Integer = 0 To items.Length - 1
                For sort As Integer = 0 To items.Length - 2
                    If [String].Compare(items(sort).Text, items(sort + 1).Text) > 0 Then
                        temp = items(sort + 1)
                        items(sort + 1) = items(sort)
                        items(sort) = temp

                    End If

                Next
            Next
            list.Clear()
            list.AddRange(items)
            Return MiscUtils.SerializeJSON(list)
        End Function

    End Class

End Namespace
