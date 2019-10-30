Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports BaseClasses.Utils.StringUtils
Imports IROC2.Data

Namespace IROC2.UI

    ' Typical customizations that may be done in this class include
    '  - adding custom event handlers
    '  - overriding base class methods

    ''' <summary>
    ''' The superclass (i.e. base class) for all Designer-generated record controls in this application.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' </para>
    ''' </remarks>

    Public Class BaseApplicationRecordControl
        Inherits System.Web.UI.Control

        ''' Allow for migration from earlier versions which did not have url encryption.
        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String) As String
            Throw New Exception("This function should be implemented by inherited record control class.")
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
            Throw New Exception("This function should be implemented by inherited record control class.")
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Throw New Exception("This function should be implemented by inherited record control class.")
        End Function

        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
            Throw New Exception("This function should be implemented by inherited record control class.")
        End Function

        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Throw New Exception("This function should be implemented by inherited record control class.")
        End Function

        ''' Allow for migration from earlier versions which did not have url encryption.
        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, rec, False)
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord, ByVal bEncrypt As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, rec, bEncrypt)
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return EvaluateExpressions(redirectUrl, redirectArgument, rec, bEncrypt, includeSession)
        End Function

        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord, ByVal bEncrypt As Boolean) As String
            Const PREFIX_NO_ENCODE As String = "NoUrlEncode:"

            Dim finalRedirectUrl As String = redirectUrl
            Dim finalRedirectArgument As String = redirectArgument

            If (finalRedirectUrl Is Nothing OrElse finalRedirectUrl.Trim = "") Then
                Return finalRedirectUrl
            ElseIf (finalRedirectUrl.IndexOf("{"c) < 0) Then
                Return finalRedirectUrl
            Else
                'The old way was to pass separate URL and arguments and use String.Format to
                'do the replacement.  Example:
                '   URL:        EditProductsRecord?Products={0}
                '   Argument:   PK
                'The new way to is pass the arguments directly in the URL.  Example:
                '   URL:        EditProductsRecord?Products={PK}
                'If the old way is passsed, convert it to the new way.
                If (Len(finalRedirectArgument) > 0) Then
                    Dim arguments() As String = Split(finalRedirectArgument, ",")
                    Dim i As Integer
                    For i = 0 To (arguments.Length - 1)
                        finalRedirectUrl = finalRedirectUrl.Replace("{" & i.ToString & "}", "{" & arguments(i) & "}")
                    Next
                    finalRedirectArgument = ""
                End If

                'Evaluate all of the expressions in the RedirectURL
                'Expressions can be of the form [ControlName:][NoUrlEncode:]Key[:Value]
                Dim remainingUrl As String = finalRedirectUrl

                While (remainingUrl.IndexOf("{"c) >= 0) And (remainingUrl.IndexOf("}"c) > 0) And _
                   (remainingUrl.IndexOf("{"c) < remainingUrl.IndexOf("}"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("{"c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("}"c)
                    Dim expression As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)
                    Dim origExpression As String = expression
                    remainingUrl = remainingUrl.Substring(rightIndex + 1)

                    Dim skip As Boolean = False
                    Dim returnEmptyStringOnFail As Boolean = False
                    Dim prefix As String = Nothing

                    'Check to see if this control must evaluate the expression
                    If (expression.IndexOf(":") > 0) Then
                        prefix = expression.Substring(0, expression.IndexOf(":"))
                    End If
                    If (Not IsNothing(prefix)) AndAlso (prefix.Length > 0) AndAlso _
                       (Not (InvariantLCase(prefix) = InvariantLCase(PREFIX_NO_ENCODE))) AndAlso _
                       (Not BaseRecord.IsKnownExpressionPrefix(prefix)) Then

                        'Remove the ASCX Prefix
                        Dim IdString As String = Me.ID
                        If IdString.StartsWith("_") Then
                            IdString = IdString.Remove(0, 1)
                        End If
                        'The prefix is a control name.
                        If (prefix = IdString) Then
                            'This control is responsible for evaluating the expression,
                            'so if it can't be evaluated then return an empty string.
                            returnEmptyStringOnFail = True
                            expression = expression.Substring(expression.IndexOf(":") + 1)
                        Else
                            'It's not for this control to evaluate so skip.
                            skip = True
                        End If
                    End If

                    If (Not skip) Then
                        Dim bUrlEncode As Boolean = True
                        If (InvariantLCase(expression).StartsWith(InvariantLCase(PREFIX_NO_ENCODE))) Then
                            bUrlEncode = False
                            expression = expression.Substring(PREFIX_NO_ENCODE.Length)
                        End If
                        Dim result As Object = Nothing
                        Try
                            If (Not IsNothing(rec)) Then
                                result = rec.EvaluateExpression(expression)
                            End If
                        Catch ex As Exception
                            'Fall through
                        End Try

                        If (Not IsNothing(result)) Then
                            result = result.ToString()
                        End If
                        If (IsNothing(result)) Then
                            If (Not returnEmptyStringOnFail) Then
                                Return finalRedirectUrl
                            Else
                                result = String.Empty
                            End If
                        End If
                        If (bUrlEncode) Then
                            result = System.Web.HttpUtility.UrlEncode(DirectCast(result, String))
                            If (IsNothing(result)) Then
                                result = String.Empty
                            End If
                        End If
                        If (bEncrypt) Then
                            If Not (IsNothing(result)) Then
                                result = DirectCast(Me.Page, BaseApplicationPage).Encrypt(DirectCast(result, String))
                            End If
                        End If

                        finalRedirectUrl = finalRedirectUrl.Replace("{" & origExpression & "}", DirectCast(result, String))
                    End If
                End While
            End If

            'If there are still expressions to evaluate. Forward to the page for further processing.
            Return finalRedirectUrl
        End Function


        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Const PREFIX_NO_ENCODE As String = "NoUrlEncode:"

            Dim finalRedirectUrl As String = redirectUrl
            Dim finalRedirectArgument As String = redirectArgument

            If (finalRedirectUrl Is Nothing OrElse finalRedirectUrl.Trim = "") Then
                Return finalRedirectUrl
            ElseIf (finalRedirectUrl.IndexOf("{"c) < 0) Then
                Return finalRedirectUrl
            Else
                'The old way was to pass separate URL and arguments and use String.Format to
                'do the replacement.  Example:
                '   URL:        EditProductsRecord?Products={0}
                '   Argument:   PK
                'The new way to is pass the arguments directly in the URL.  Example:
                '   URL:        EditProductsRecord?Products={PK}
                'If the old way is passsed, convert it to the new way.
                If (Len(finalRedirectArgument) > 0) Then
                    Dim arguments() As String = Split(finalRedirectArgument, ",")
                    Dim i As Integer
                    For i = 0 To (arguments.Length - 1)
                        finalRedirectUrl = finalRedirectUrl.Replace("{" & i.ToString & "}", "{" & arguments(i) & "}")
                    Next
                    finalRedirectArgument = ""
                End If

                'Evaluate all of the expressions in the RedirectURL
                'Expressions can be of the form [ControlName:][NoUrlEncode:]Key[:Value]
                Dim remainingUrl As String = finalRedirectUrl

                While (remainingUrl.IndexOf("{"c) >= 0) And (remainingUrl.IndexOf("}"c) > 0) And _
                   (remainingUrl.IndexOf("{"c) < remainingUrl.IndexOf("}"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("{"c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("}"c)
                    Dim expression As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)
                    Dim origExpression As String = expression
                    remainingUrl = remainingUrl.Substring(rightIndex + 1)

                    Dim skip As Boolean = False
                    Dim returnEmptyStringOnFail As Boolean = False
                    Dim prefix As String = Nothing

                    'Check to see if this control must evaluate the expression
                    If (expression.IndexOf(":") > 0) Then
                        prefix = expression.Substring(0, expression.IndexOf(":"))
                    End If
                    If (Not IsNothing(prefix)) AndAlso (prefix.Length > 0) AndAlso _
                       (Not (InvariantLCase(prefix) = InvariantLCase(PREFIX_NO_ENCODE))) AndAlso _
                       (Not BaseRecord.IsKnownExpressionPrefix(prefix)) Then

                        'Remove the ASCX Prefix
                        Dim IdString As String = Me.ID
                        If IdString.StartsWith("_") Then
                            IdString = IdString.Remove(0, 1)
                        End If
                        'The prefix is a control name.
                        If (prefix = IdString) Then
                            'This control is responsible for evaluating the expression,
                            'so if it can't be evaluated then return an empty string.
                            returnEmptyStringOnFail = True
                            expression = expression.Substring(expression.IndexOf(":") + 1)
                        Else
                            'It's not for this control to evaluate so skip.
                            skip = True
                        End If
                    End If

                    If (Not skip) Then
                        Dim bUrlEncode As Boolean = True
                        If (InvariantLCase(expression).StartsWith(InvariantLCase(PREFIX_NO_ENCODE))) Then
                            bUrlEncode = False
                            expression = expression.Substring(PREFIX_NO_ENCODE.Length)
                        End If
                        Dim result As Object = Nothing
                        Try
                            If (Not IsNothing(rec)) Then
                                result = rec.EvaluateExpression(expression)
                            End If
                        Catch ex As Exception
                            'Fall through
                        End Try

                        If (Not IsNothing(result)) Then
                            result = result.ToString()
                        End If
                        If (IsNothing(result)) Then
                            If (Not returnEmptyStringOnFail) Then
                                Return finalRedirectUrl
                            Else
                                result = String.Empty
                            End If
                        End If
                        If (bUrlEncode) Then
                            result = System.Web.HttpUtility.UrlEncode(DirectCast(result, String))
                            If (IsNothing(result)) Then
                                result = String.Empty
                            End If
                        End If
                        If (bEncrypt) Then
                            If Not (IsNothing(result)) Then
                                If includeSession Then
                                    result = DirectCast(Me.Page, BaseApplicationPage).Encrypt(DirectCast(result, String))
                                Else
                                    result = BaseFormulaUtils.EncryptData(DirectCast(result, String))
                                End If
                            End If
                        End If

                        finalRedirectUrl = finalRedirectUrl.Replace("{" & origExpression & "}", DirectCast(result, String))
                    End If
                End While
            End If

            'If there are still expressions to evaluate. Forward to the page for further processing.
            Return finalRedirectUrl
        End Function

        ''' <summary>
        ''' Get the Id of the parent table control.  We navigate up the chain of
        ''' controls until we find the table control.  Note that the first table
        ''' control above the record control would be the parent.  You cannot have
        ''' a record control embedded in a different parent control other than its parent.
        ''' </summary>
        ''' <returns>The Id of the parent table control.</returns>
        Public Overridable Function GetParentTableControlID() As String
            Dim parent As BaseApplicationTableControl = Me.GetParentTableControl()
            If Not (IsNothing(parent)) Then Return parent.ID
            Return ""
        End Function

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

        ''' <summary>
        ''' Get the parent table control.  We navigate up the chain of
        ''' controls until we find the table control.  Note that the first table
        ''' control above the record control would be the parent.  You cannot have
        ''' a record control embedded in a different parent control other than its parent.
        ''' </summary>
        ''' <returns>The Id of the parent table control.</returns>
        Public Overridable Function GetParentTableControl() As BaseApplicationTableControl
            Try
                Dim parent As Control = Me.Parent
                While Not (IsNothing(parent))
                    If TypeOf parent Is BaseApplicationTableControl Then
                        Return CType(parent, BaseApplicationTableControl)
                    End If
                    parent = parent.Parent
                End While
            Catch ex As Exception
                ' Ignore and return Nothing
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' The row number of this record control within the table control.
        ''' This function is called as {TableName}TableControlRow.ROWNUM().
        ''' To make sure all the formula functions are in the same location, we call
        ''' the ROWNUM function in the FormulaUtils class, which actually does the work
        ''' and return the value.  The function in FormulaUtils will need to know the
        ''' TableControl, so it is passed as the first instance.
        ''' The row number is 1 based.
        ''' </summary>
        ''' <returns>The row number of this row relative to the other rows in the table control.</returns>
        Public Function RowNum() As Decimal
            Return FormulaUtils.RowNum(Me.GetParentTableControl(), Me)
        End Function

        ''' <summary>
        ''' The rank of this field relative to other fields in the table control.
        ''' This function is called as {TableName}TableControlRow.RANK().
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' Their respecitive ranks will be 4, 3, 1, 2, 5
        ''' To make sure all the formula functions are in the same location, we call
        ''' the RANK function in the FormulaUtils class, which actually does the work
        ''' and return the value.  The function in FormulaUtils will need to know the
        ''' TableControl, so it is passed as the first instance.
        ''' The rank is 1 based.
        ''' </summary>
        ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The rank of this row relative to the other rows in the table control..</returns>
        Public Function Rank(ByVal controlName As String) As Decimal
            Return FormulaUtils.Rank(Me.GetParentTableControl(), Me, controlName)
        End Function

        ''' <summary>
        ''' The running total of the field.
        ''' This function is called as {TableName}TableControlRow.RUNNINGTOTAL().
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' The respecitive values for running totals will be  be 57, 89, 101, 120, 218
        ''' To make sure all the formula functions are in the same location, we call
        ''' the RUNNINGTOTAL function in the FormulaUtils class, which actually does the work
        ''' and return the value.  The function in FormulaUtils will need to know the
        ''' TableControl, so it is passed as the first instance.
        ''' </summary>
        ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The running total of the row.</returns>
        Public Function RunningTotal(ByVal controlName As String) As Decimal
            Return FormulaUtils.RunningTotal(Me.GetParentTableControl(), Me, controlName)
        End Function

        ''' <summary>
        ''' Store the UI data within the current record or row control and return as hashtable
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function PreservedUIData() As Hashtable
            ' This method get the UI data within the current record and return them as Hastable
            Dim uiData As New Hashtable


            Dim controls() As Control = BaseClasses.Utils.MiscUtils.FindControlsRecursively(Me)

            For Each control As Control In controls
                If control.ID <> "" AndAlso Not uiData.ContainsKey(control.ID) Then
                    If control.GetType() Is GetType(TextBox) Then
                        Dim textbox As TextBox = DirectCast(control, TextBox)
                        uiData.Add(textbox.ID, textbox.Text)
                    ElseIf control.GetType() Is GetType(Literal) Then
                        Dim literal As Literal = DirectCast(control, Literal)
                        uiData.Add(literal.ID, literal.Text)
                    ElseIf control.GetType() Is GetType(Label) Then
                        Dim label As Label = DirectCast(control, Label)
                        uiData.Add(label.ID, label.Text)
                    ElseIf control.GetType() Is GetType(CheckBox) Then
                        Dim checkbox As CheckBox = DirectCast(control, CheckBox)
                        uiData.Add(checkbox.ID, checkbox.Checked)
                    ElseIf control.GetType() Is GetType(Button) Then
                        Dim button As Button = DirectCast(control, Button)
                        uiData.Add(button.ID, button.Text)
                    ElseIf control.GetType() Is GetType(LinkButton) Then
                        Dim linkButton As LinkButton = DirectCast(control, LinkButton)
                        uiData.Add(linkButton.ID, linkButton.Text)
                    ElseIf control.GetType() Is GetType(ListBox) Then
                        Dim listbox As ListBox = DirectCast(control, ListBox)
                        uiData.Add(listbox.ID, GetValueSelectedPageRequest(listbox))
                    ElseIf control.GetType() Is GetType(DropDownList) Then
                        Dim dropdownList As DropDownList = DirectCast(control, DropDownList)
                        uiData.Add(dropdownList.ID, GetValueSelectedPageRequest(dropdownList))
                    ElseIf control.GetType() Is GetType(DropDownList) Then
                        Dim radioButtonList As RadioButtonList = DirectCast(control, RadioButtonList)
                        uiData.Add(radioButtonList.ID, GetValueSelectedPageRequest(radioButtonList))
                    ElseIf control.GetType().GetInterface("IDatePagination") IsNot Nothing OrElse _
                            control.GetType().GetInterface("IDatePaginationMobile") IsNot Nothing Then
                        ' Save the pagination's Interval and FirstStartDate and restore it by these values later
                        Dim props() As System.Reflection.PropertyInfo = control.GetType().GetProperties()
                        Dim ht As New Hashtable
                        For Each prop As System.Reflection.PropertyInfo In props
                            Dim descriptor As System.ComponentModel.PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(control.GetType())(prop.Name)
                            If descriptor.Name = "Interval" Then
                                ht.Add("Interval", prop.GetValue(control, Nothing).ToString())
                            ElseIf descriptor.Name = "FirstStartDate" Then
                                ht.Add("FirstStartDate", prop.GetValue(control, Nothing).ToString())
                            End If
                        Next
                        uiData.Add(control.ID, ht)
                    End If
                End If
            Next
            Return uiData
        End Function

    End Class

End Namespace
