
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils.StringUtils
Imports System.Web.UI.WebControls
Imports IROC2.Data

    Namespace IROC2.UI

        ' Typical customizations that may be done in this class include
        '  - adding custom event handlers
        '  - overriding base class methods

        ''' <summary>
        ''' The superclass (i.e. base class) for all Designer-generated pages in this application.
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' </para>
        ''' </remarks>


        Public Class BaseApplicationTableControl
            Inherits System.Web.UI.Control

        Protected _DataSource() As BaseRecord = Nothing

            ''' <summary>
            ''' The name of the row controls.  By convention, "Row" is appended to the
            ''' end of the name of the table control.  So OrdersTableControl will have
            ''' OrdersTableControlRow controls.
            ''' </summary>
            Public Overridable ReadOnly Property RowName() As String
                Get
                    Return Me.ID & "Row"
                End Get
            End Property

            ''' <summary>
            ''' The name of the repeater controls.  By convention, "Repeater" is appended to the
            ''' end of the name of the table control.  So OrdersTableControl will have
            ''' OrdersTableControlRepeater controls.  The Row controls defined above are
            ''' within the Repeater control.
            ''' </summary>
            Public Overridable ReadOnly Property RepeaterName() As String
                Get
                    Return Me.ID & "Repeater"
                End Get
            End Property

            ''' Allow for migration from earlier versions which did not have url encryption.
            Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String) As String
                Throw New Exception("This function should be implemented by inherited table control class.")
            End Function

            Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
                Throw New Exception("This function should be implemented by inherited table control class.")
        End Function

        Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Throw New Exception("This function should be implemented by inherited table control class.")
        End Function


            Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean) As String
                Throw New Exception("This function should be implemented by inherited table control class.")
        End Function

        Public Overridable Function EvaluateExpressions(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Throw New Exception("This function should be implemented by inherited table control class.")
        End Function

            ''' Allow for migration from earlier versions which did not have url encryption.
            Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord) As String
                Return EvaluateExpressions(redirectUrl, redirectArgument, rec, False)
            End Function

            Public Overridable Function ModifyRedirectUrl(ByVal redirectUrl As String, ByVal redirectArgument As String, ByVal rec As IRecord, ByVal bEncrypt As Boolean) As String
                Return EvaluateExpressions(redirectUrl, redirectArgument, rec, bEncrypt)
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


            Public Function AreAnyUrlParametersForMe(ByVal url As String, ByVal arg As String) As Boolean
                Const PREFIX_NO_ENCODE As String = "NoUrlEncode:"
                Dim finalRedirectUrl As String = url
                Dim finalRedirectArgument As String = arg
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
                Dim skip As Boolean = False
                While (remainingUrl.IndexOf("{"c) >= 0) And (remainingUrl.IndexOf("}"c) > 0) And _
                   (remainingUrl.IndexOf("{"c) < remainingUrl.IndexOf("}"c))

                    Dim leftIndex As Integer = remainingUrl.IndexOf("{"c)
                    Dim rightIndex As Integer = remainingUrl.IndexOf("}"c)
                    Dim expression As String = remainingUrl.Substring(leftIndex + 1, rightIndex - leftIndex - 1)
                    Dim origExpression As String = expression
                    remainingUrl = remainingUrl.Substring(rightIndex + 1)

                    Dim returnEmptyStringOnFail As Boolean = False
                    Dim prefix As String = Nothing

                    'Check to see if this control must evaluate the expression
                    If (expression.IndexOf(":") > 0) Then
                        prefix = expression.Substring(0, expression.IndexOf(":"))
                    End If
                    If (Not IsNothing(prefix)) AndAlso (prefix.Length > 0) AndAlso _
                       (Not (InvariantLCase(prefix) = InvariantLCase(PREFIX_NO_ENCODE))) AndAlso _
                       (Not BaseRecord.IsKnownExpressionPrefix(prefix)) Then
                        'The prefix is a control name.
                        If (prefix = Me.ID) Then
                            skip = False
                            Exit While
                        Else
                            'It's not for this control to evaluate so skip.
                            skip = True
                        End If
                    End If
                End While

                If skip Then
                    Return False
                End If
                Return True

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
            ''' This function returns the list of record controls within the table control.
            ''' There is a more specific GetRecordControls function generated in the 
            ''' derived classes, but in some cases, we do not know the specific type of
            ''' the table control, so we need to call this method. This is also used by the
            ''' Formula evaluator to perform Sum, Count and CountA functions.
            ''' </summary>
            Public Function GetBaseRecordControls() As BaseApplicationRecordControl()
                Dim recList As ArrayList = New ArrayList()

                ' First get the repeater inside the Table Control.
                Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl(Me.RepeaterName), System.Web.UI.WebControls.Repeater)
                If IsNothing(rep) OrElse IsNothing(rep.Items) Then Return Nothing

                ' We now go inside the repeater to find all the record controls.  
                ' Note that we only find the first level record controls. We do not
                ' descend down and find other record controls belonging to tables-inside-table.
                Dim repItem As System.Web.UI.WebControls.RepeaterItem

                For Each repItem In rep.Items
                    Dim recControl As BaseApplicationRecordControl = DirectCast(repItem.FindControl(Me.RowName), BaseApplicationRecordControl)
                    If Not (IsNothing(recControl)) Then recList.Add(recControl)
                Next

                Return DirectCast(recList.ToArray(GetType(BaseApplicationRecordControl)), BaseApplicationRecordControl())
            End Function

            ''' <summary>
            ''' Sum the values of the displayed controls.  The controlName must be
            ''' a textbox, label or literal.
            ''' This function is called as [Products]TableControl.SUM("UnitPrice").
            ''' To make sure all the formula functions are in the same location, we call
            ''' the SUM function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total of adding the value contained in each of the fields.</returns>
            Public Function Sum(ByVal controlName As String) As Decimal
                Return FormulaUtils.Sum(Me, controlName)
        End Function

        ''' <summary>
        ''' Sum the values of the displayed controls.  The controlName must be
        ''' a textbox, label or literal.
        ''' This function is called as [Products]TableControl.TOTAL("UnitPrice").
        ''' To make sure all the formula functions are in the same location, we call
        ''' the TOTAL function in the FormulaUtils class, which actually does the work
        ''' and return the value.  The function in FormulaUtils will need to know the
        ''' TableControl, so it is passed as the first instance.
        ''' </summary>
        ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The total of adding the value contained in each of the fields.</returns>
        Public Function Total(ByVal controlName As String) As Decimal
            Return FormulaUtils.Total(Me, controlName)
        End Function

            ''' <summary>
            ''' Finds the maximum among the values of the displayed controls.  The ctlName must be
            ''' a textbox, label or literal.
            ''' This function should be called as [Products]TableControl.Max("UnitPrice"), not
            ''' as shown here. The MAX function in the BaseApplicationTableControl will call this
            ''' function to actually perform the work - so that we can keep all of the formula
            ''' functions together in one place.
            ''' </summary>
            ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The maximum among the values contained in each of the fields.</returns>
            Public Function Max(ByVal ctlName As String) As Decimal
                Return FormulaUtils.Max(Me, ctlName)
            End Function

            ''' <summary>
            ''' Finds the minimum among the values of the displayed controls.  The ctlName must be
            ''' a textbox, label or literal.
            ''' This function should be called as [Products]TableControl.Min("UnitPrice"), not
            ''' as shown here. The MIN function in the BaseApplicationTableControl will call this
            ''' function to actually perform the work - so that we can keep all of the formula
            ''' functions together in one place.
            ''' </summary>
            ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The minimum among the values contained in each of the fields.</returns>
            Public Function Min(ByVal ctlName As String) As Decimal
                Return FormulaUtils.Min(Me, ctlName)
            End Function

            ''' <summary>
            ''' Count the number of rows in the table control. 
            ''' This function is called as [Products]TableControl.COUNT().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the COUNT function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Count(ByVal controlName As String) As Decimal
                Return FormulaUtils.Count(Me, controlName)
            End Function

            ''' <summary>
            ''' Count the number of rows in the table control that are non-blank.
            ''' This function is called as [Products]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the COUNTA function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function CountA(ByVal controlName As String) As Decimal
                Return FormulaUtils.CountA(Me, controlName)
            End Function

            ''' <summary>
            ''' Mean of the rows in the table control.
            ''' This function is called as [Product]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the MEAN function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Mean(ByVal controlName As String) As Decimal
                Return FormulaUtils.Mean(Me, controlName)
            End Function

            ''' <summary>
            ''' Average of the rows in the table control.
            ''' This function is called as [Product]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the AVERAGE function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Average(ByVal controlName As String) As Decimal
                Return FormulaUtils.Average(Me, controlName)
            End Function

            ''' <summary>
            ''' Mode of the rows in the table control.
            ''' This function is called as [Product]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the MODE function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Mode(ByVal controlName As String) As Decimal
                Return FormulaUtils.Mode(Me, controlName)
            End Function

            ''' <summary>
            ''' Median of the rows in the table control.
            ''' This function is called as [Product]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the MEDIAN function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Median(ByVal controlName As String) As Decimal
                Return FormulaUtils.Median(Me, controlName)
            End Function

            ''' <summary>
            ''' Range of the rows in the table control.
            ''' This function is called as [Product]TableControl.COUNTA().
            ''' To make sure all the formula functions are in the same location, we call
            ''' the RANGE function in the FormulaUtils class, which actually does the work
            ''' and return the value.  The function in FormulaUtils will need to know the
            ''' TableControl, so it is passed as the first instance.
            ''' </summary>
            ''' <param name="controlName">The string name of the UI control (e.g., "UnitPrice") </param>
            ''' <returns>The total number of rows in the table control.</returns>
            Public Function Range(ByVal controlName As String) As Decimal
                Return FormulaUtils.Range(Me, controlName)
            End Function

        ''' 
        ''' Create javascript function, ClearSelection which is called when Clear button is clicked
        ''' 
        ''' 
        Public Overridable Sub RegisterJSClearSelection()
            Dim multiSelection As Boolean = False

            If Not String.IsNullOrEmpty(Page.Request("Mode")) Then
                multiSelection = System.Web.HttpUtility.UrlDecode(Page.Request("Mode")) = "FieldFilterMultiSelection"
            End If


            ' qsSelectionID is a special control.  It is used to remember the current selection(s).
            ' It is not shown on the layout of Design Mode.  But you can see it by right-clicking on Design Mode and followed by Page Directives...
            Dim qsSelectionID As String = ""
            Dim qsSelection As BaseClasses.Web.UI.WebControls.QuickSelector = DirectCast(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me.Page, "QSSelection"), BaseClasses.Web.UI.WebControls.QuickSelector)
            If qsSelection IsNot Nothing Then
                qsSelectionID = qsSelection.ClientID
            End If
            Dim csName As [String] = "ClearSelection"
            Dim csType As Type = Me.[GetType]()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            If Not cs.IsClientScriptBlockRegistered(csType, csName) Then
                Dim csText As New StringBuilder()
                csText.AppendLine("<script type=""text/javascript""> function ClearSelection() {")

                ' Clear the selection from QSSelection control 
                csText.AppendLine("updateQuickSelectorItems('" & qsSelectionID & "', new Array(), 'Replace', false);")

                If multiSelection Then
                    ' if it is multi selection, remove clear the row hightlight by changing the class name.
                    csText.AppendLine("replaceClassName('tr', 'QStrSelected', 'QStr');")
                Else
                    ' if it is single selection, close the popup.
                    csText.AppendLine("CommitSelection();")
                End If
                csText.AppendLine("} ")
                csText.AppendLine("</script>")
                cs.RegisterClientScriptBlock(csType, csName, csText.ToString())
            End If
        End Sub


        ''' 
        ''' Create javascript function, CommitSelection which is called when OK button is clicked
        ''' 
        ''' 
        Public Overridable Sub RegisterJSCommitSelection()
            Dim emptyValue As String = ""
            Dim emptyDisplayText As String = ""
            Dim target As String = ""
            If Not String.IsNullOrEmpty(Page.Request("Target")) Then
                target = Page.Request("Target")
            End If

            If Not String.IsNullOrEmpty(Page.Request("EmptyValue")) Then
                emptyValue = CType(Me.Page, BaseApplicationPage).GetDecryptedURLParameter("EmptyValue")
            End If
            If Not String.IsNullOrEmpty(Page.Request("EmptyDisplayText")) Then
                emptyDisplayText = CType(Me.Page, BaseApplicationPage).GetDecryptedURLParameter("EmptyDisplayText")
            End If


            Dim qsSelectionID As String = ""
            Dim qsSelection As BaseClasses.Web.UI.WebControls.QuickSelector = DirectCast(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me.Page, "QSSelection"), BaseClasses.Web.UI.WebControls.QuickSelector)
            If qsSelection IsNot Nothing Then
                qsSelectionID = qsSelection.ClientID
            End If
            Dim csName As [String] = "CommitSelection"
            Dim csType As Type = Me.[GetType]()

            ' Get a ClientScriptManager reference from the Page class.
            ' Create CommitSelection function.  QSSelection has no selected items, Update the target control to be --PLEASE_SELECT--
            Dim cs As ClientScriptManager = Page.ClientScript
            If Not cs.IsClientScriptBlockRegistered(csType, csName) Then
                Dim csText As New StringBuilder()
                Dim valueID As String = qsSelectionID & "_Value"
                csText.AppendLine("<script type=""text/javascript""> function CommitSelection() {")
                csText.AppendLine("     var w = getParentWindow();")
                csText.AppendLine("     if (w == window) {return;}")
                csText.AppendLine("     var listItems = new Array()")
                csText.AppendLine("     var valCtrl = document.getElementById('" & valueID & "');")
                csText.AppendLine("     if (valCtrl.value != '') {")
                csText.AppendLine("         listItems = JSON.parse(valCtrl.value).List;")
                csText.AppendLine("     }")
                csText.AppendLine("     if (listItems.length == 0){")
                csText.AppendLine("         w.updateQuickSelectorItem('" & target & "', '" & emptyValue & "', '" & emptyDisplayText & "', 'Replace', true);")
                csText.AppendLine("     }")
                csText.AppendLine("     else {")
                csText.AppendLine("         w.updateQuickSelectorItems('" & target & "', listItems, 'Replace', true);")
                csText.AppendLine("     } ")
                csText.AppendLine("} ")
                csText.AppendLine("</script>")
                cs.RegisterClientScriptBlock(csType, csName, csText.ToString())
            End If
        End Sub

        ''' <summary>
        ''' Method will loop through the literal controls inside the repeater.
        ''' Assign the id value if found the duplicate items
        ''' </summary>
        ''' <param name="ids">Name of the literal controls who has duplicate values</param>
        Public Overridable Sub InitializeDuplicateItems(ByVal ids As ArrayList)
            If ids.Count = 0 Then
                Return
            End If

            Dim listOfDups As New ArrayList()
            Dim itemsList As New ListItemCollection()
            Dim index As Integer = 0

            If ids.Count = 1 Then
                Dim rep As System.Web.UI.WebControls.Repeater = DirectCast(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, Me.RepeaterName), System.Web.UI.WebControls.Repeater)
                For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
                    Dim pkRecord As PrimaryKeyRecord = DirectCast(Me._DataSource(index), PrimaryKeyRecord)
                    Dim recControl As BaseApplicationRecordControl = DirectCast(repItem.FindControl(Me.RowName), BaseApplicationRecordControl)
                    For Each ctrlItem As System.Web.UI.Control In recControl.Controls
                        Dim ltlCtrl As Literal
                        Dim lblCtrl As Label
                        Dim lbtnCtrl As LinkButton
                        Dim txtValue As String = ""
                        If ctrlItem.ID = ids(0).ToString() Then
                            If TypeOf ctrlItem Is System.Web.UI.WebControls.Literal Then
                                ltlCtrl = DirectCast(ctrlItem, System.Web.UI.WebControls.Literal)
                                txtValue = ltlCtrl.Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.Label Then
                                lblCtrl = DirectCast(ctrlItem, System.Web.UI.WebControls.Label)
                                txtValue = lblCtrl.Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.LinkButton Then
                                lbtnCtrl = DirectCast(ctrlItem, System.Web.UI.WebControls.LinkButton)
                                txtValue = lbtnCtrl.Text
                            End If

                            If txtValue <> "" Then
                                Dim dupItem As ListItem = itemsList.FindByText(txtValue)
                                If dupItem IsNot Nothing Then
                                    listOfDups.Add(dupItem.Text)
                                    dupItem.Text = dupItem.Text + " (ID " + dupItem.Value & ")"
                                End If

                                Dim newItem As New ListItem(txtValue, pkRecord.GetID().ToDisplayString())
                                itemsList.Add(newItem)

                                If listOfDups.Contains(newItem.Text) Then
                                    newItem.Text = newItem.Text + " (ID " + newItem.Value & ")"
                                End If
                                Exit For
                            End If
                        End If
                    Next
                    index += 1
                Next

                index = 0
                For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
                    Dim recControl As BaseApplicationRecordControl = DirectCast(repItem.FindControl(Me.RowName), BaseApplicationRecordControl)
                    For Each ctrlItem As System.Web.UI.Control In recControl.Controls
                        If ctrlItem.ID = ids(0).ToString() Then
                            If TypeOf ctrlItem Is System.Web.UI.WebControls.Literal AndAlso itemsList.Count <> 0 Then
                                Dim ltCtrl As Literal = DirectCast(ctrlItem, System.Web.UI.WebControls.Literal)
                                ltCtrl.Text = itemsList(index).Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.Label AndAlso itemsList.Count <> 0 Then
                                Dim ltCtrl As Label = DirectCast(ctrlItem, System.Web.UI.WebControls.Label)
                                ltCtrl.Text = itemsList(index).Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.LinkButton AndAlso itemsList.Count <> 0 Then
                                Dim ltCtrl As LinkButton = DirectCast(ctrlItem, System.Web.UI.WebControls.LinkButton)
                                ltCtrl.Text = itemsList(index).Text
                            End If
                        End If
                    Next
                    index += 1
                Next
            ElseIf ids.Count = 2 Then
                Dim rep As System.Web.UI.WebControls.Repeater = DirectCast(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, Me.RepeaterName), System.Web.UI.WebControls.Repeater)
                For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
                    Dim count As Integer = 0
                    Dim ltText As String = ""
                    Dim pkRecord As PrimaryKeyRecord = DirectCast(Me._DataSource(index), PrimaryKeyRecord)
                    Dim recControl As BaseApplicationRecordControl = DirectCast(repItem.FindControl(Me.RowName), BaseApplicationRecordControl)
                    For Each ctrlItem As System.Web.UI.Control In recControl.Controls
                        If ctrlItem.ID = ids(0).ToString() OrElse ctrlItem.ID = ids(1).ToString() Then
                            If TypeOf ctrlItem Is System.Web.UI.WebControls.Literal Then
                                Dim ltCtrl As Literal = DirectCast(ctrlItem, System.Web.UI.WebControls.Literal)
                                ltText += ltCtrl.Text

                                count += 1
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.Label Then
                                Dim ltCtrl As Label = DirectCast(ctrlItem, System.Web.UI.WebControls.Label)
                                ltText += ltCtrl.Text

                                count += 1
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.LinkButton Then
                                Dim ltCtrl As LinkButton = DirectCast(ctrlItem, System.Web.UI.WebControls.LinkButton)
                                ltText += ltCtrl.Text

                                count += 1
                            End If
                        End If

                        If count = ids.Count Then
                            Dim dupItem As ListItem = itemsList.FindByText(ltText)
                            If dupItem IsNot Nothing Then
                                listOfDups.Add(dupItem.Text)
                                dupItem.Text = " (ID " + dupItem.Value & ")"
                            End If

                            Dim newItem As New ListItem(ltText, pkRecord.GetID().ToDisplayString())
                            itemsList.Add(newItem)

                            If listOfDups.Contains(newItem.Text) Then
                                newItem.Text = " (ID " + newItem.Value & ")"
                            End If
                            Exit For
                        End If
                    Next
                    index += 1
                Next

                index = 0
                For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
                    Dim recControl As BaseApplicationRecordControl = DirectCast(repItem.FindControl(Me.RowName), BaseApplicationRecordControl)
                    For Each ctrlItem As System.Web.UI.Control In recControl.Controls
                        If (ctrlItem.ID = ids(0).ToString() OrElse ctrlItem.ID = ids(1).ToString()) AndAlso itemsList.Count <> 0 Then
                            If TypeOf ctrlItem Is System.Web.UI.WebControls.Literal AndAlso itemsList(index).Text.Contains(" (ID ") Then
                                Dim ltCtrl As Literal = DirectCast(ctrlItem, System.Web.UI.WebControls.Literal)
                                ltCtrl.Text = ltCtrl.Text + itemsList(index).Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.Label AndAlso itemsList(index).Text.Contains(" (ID ") Then
                                Dim ltCtrl As Label = DirectCast(ctrlItem, System.Web.UI.WebControls.Label)
                                ltCtrl.Text = ltCtrl.Text + itemsList(index).Text
                            ElseIf TypeOf ctrlItem Is System.Web.UI.WebControls.LinkButton AndAlso itemsList(index).Text.Contains(" (ID ") Then
                                Dim ltCtrl As LinkButton = DirectCast(ctrlItem, System.Web.UI.WebControls.LinkButton)
                                ltCtrl.Text = ltCtrl.Text + itemsList(index).Text
                            End If
                        End If
                    Next
                    index += 1
                Next
            End If
        End Sub

    End Class

    End Namespace
