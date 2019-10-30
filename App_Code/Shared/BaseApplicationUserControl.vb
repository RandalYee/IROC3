Imports BaseClasses.Data
Imports BaseClasses.Utils.StringUtils


Namespace IROC2.UI

' Typical customizations that may be done in this class include
'  - adding custom event handlers
'  - overriding base class methods

''' <summary>
''' The superclass (i.e. base class) for all Designer-generated user controls in this application.
''' </summary>
''' <remarks>
''' <para>
''' </para>
''' </remarks>

	Public Class BaseApplicationUserControl
        Inherits BaseClasses.Web.UI.BaseUserControl

        ' Variable used to prevent infinite loop
        Private _modifyRedirectUrlInProgress As Boolean = False

        ''' Allow for migration from earlier versions which did not have url encryption.
        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, False)
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, bEncrypt)
        End Function

        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
            Const PREFIX_NO_ENCODE As String = "NoUrlEncode:"

            If (_modifyRedirectUrlInProgress) Then
                Return Nothing
            Else
                _modifyRedirectUrlInProgress = True
            End If

            Dim finalRedirectUrl As String = redirectUrl
            Dim finalRedirectArgument As String = redirectArgument

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
                Dim controlList As ArrayList = GetAllRecordAndTableControls()
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
                Dim remainingUrl As String = finalRedirectUrl
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
            Try
                Dim resObj As Object = GetGlobalResourceObject(appName, keyVal)
                If Not resObj Is Nothing Then
                    Return resObj.ToString()
                End If
                Return ""
            Catch
                Return ""
            End Try

        End Function

        Public Function GetResourceValue(ByVal keyVal As String) As String
            Try
                Dim appname As String = BaseClasses.Configuration.ApplicationSettings.Current.GetAppSetting(BaseClasses.Configuration.ApplicationSettings.ConfigurationKey.ApplicationName)
                Dim resObj As Object = GetGlobalResourceObject(appname, keyVal)
                If Not resObj Is Nothing Then
                    Return resObj.ToString()
                End If
                Return ""
            Catch
                Return ""
            End Try

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

        Protected Sub Control_SaveControls_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Unload
            If DirectCast(Me.Page, BaseApplicationPage).ShouldSaveControlsToSession Then
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

            Me.Page.Session()(GetValueKey(name)) = value
        End Sub

        Public Function GetFromSession( _
            ByVal name As String, _
            ByVal defaultValue As String) As String

            Dim value As String = CType(Me.Page.Session()(GetValueKey(name)), String)
            If value Is Nothing OrElse value.Trim() = "" Then
                value = defaultValue
            End If

            Return value
        End Function

        Public Function GetFromSession(ByVal name As String) As String
            Return GetFromSession(name, Nothing)
        End Function

        Public Sub RemoveFromSession(ByVal name As String)
            Me.Page.Session.Remove(GetValueKey(name))
        End Sub

        Public Function InSession(ByVal name As String) As Boolean
            Return (Not Me.Page.Session(GetValueKey(name)) Is Nothing)
        End Function

        Public Function GetValueKey(ByVal name As String) As String
            Return Me.Page.Session.SessionID & Me.Page.AppRelativeVirtualPath & name
        End Function
#End Region

    End Class

End Namespace
