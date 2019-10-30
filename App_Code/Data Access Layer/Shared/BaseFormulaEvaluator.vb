Imports Microsoft.VisualBasic
Imports System.IO
Imports BaseClasses.Data
Imports Ciloci.Flee
Imports BaseClasses.Utils

Namespace IROC2.Data

    ''' <summary>
    ''' The BaseFormulaEvaluator class evaluates a formula passed to the Evaluate function.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BaseFormulaEvaluator
        ''' <summary>
        ''' Evaluator class that actually evaluates the formula.
        ''' This is available as a public property, so additional options
        ''' can be added to the evaluator from the calling functions.
        ''' </summary>
        Protected _evaluator As ExpressionContext
        Public ReadOnly Property Evaluator() As ExpressionContext
            Get
                Return _evaluator
            End Get
        End Property

        ''' <summary>
        ''' The Variables collection allows the passing of the variables to the Evaluator
        ''' </summary>
        Public ReadOnly Property Variables() As Ciloci.Flee.VariableCollection
            Get
                Return Evaluator.Variables
            End Get
        End Property

        ''' <summary>
        ''' DataSource object from which each of the variables are
        ''' determined.  This allows direct referencing of the
        ''' fields in the DataSource.  For example, if the DataSource
        ''' is an Order_Details record, then the formula can use something like:
        '''     = UnitPrice * Quantity * (1 - Discount)
        ''' to calculate the Extended Price.
        ''' </summary>
        Private _dataSource As BaseRecord = Nothing
        Public Property DataSource() As BaseRecord
            Get
                Return _dataSource
            End Get
            Set(ByVal value As BaseRecord)
                _dataSource = value
            End Set
        End Property



        ''' <summary>
        ''' Create a new evaluator and prepare for evaluation.
        ''' </summary>
        Public Sub New(Optional ByVal mainObj As Object = Nothing)

            ' pass mainObj to contructor so that formula like = mainObj.<functionName> can be evaluated
            If mainObj Is Nothing Then
                _evaluator = New ExpressionContext()
            Else
                _evaluator = New ExpressionContext(mainObj)
            End If


            ' The order of adding types is important.  First we add our own
            ' formula functions, followed by the generic types.

            Evaluator.Imports.AddType(GetType(BaseFormulaUtils))

            ' ADVANCED.  For advanced usage, generic types can also be imported into
            ' the formula evaluator.  This is done by adding types of some generic types
            ' such as Math, DateTime, Convert, and String.  For example, if you add the
            ' Convert type, you can then use Convert.ToDecimal("string").  The second
            ' parameter to the AddType is the namespace that will be used in the formula.
            ' These functions expect a certain type.  For example, Math functions expect
            ' a Double for the most part.  If you pass a string, they will throw an exception.
            ' As such, we have written separate functions in FormulaUtils that are more
            ' loosely-typed than the standard libraries available here. 
            ' Examples:
            Evaluator.Imports.AddType(GetType(Math), "Math")
            Evaluator.Imports.AddType(GetType(DateTime), "DateTime")
            Evaluator.Imports.AddType(GetType(Convert), "Convert")
            Evaluator.Imports.AddType(GetType(String), "String")

            ' We want a loosely-typed evaluation language - so do not
            ' type-check any variables.
            Evaluator.Options.Checked = False

            ' Our policy is to always treat real numbers as Decimal instead of
            ' Double or Single to make it consistent across the entire
            ' evaluator.
            Evaluator.Options.RealLiteralDataType = RealLiteralDataType.Decimal

            ' The variable event handler handles the variables based on the DataSource.
            AddHandler _evaluator.Variables.ResolveVariableType, AddressOf variables_ResolveVariableType
            AddHandler _evaluator.Variables.ResolveVariableValue, AddressOf variables_ResolveVariableValue
        End Sub



        ''' <summary>
        ''' Evaluate the expression passed in as the string
        ''' </summary>
        ''' <param name="expression">The input whose absolute value is to be found.</param>
        ''' <returns>The result of the evaluation. Can we be any data type including string, datetime, decimal, etc.</returns>
        Public Overridable Function Evaluate(ByVal expression As String) As Object
            If IsNothing(expression) Then Return Nothing
			If expression = "" Then Return ""

            ' Strip of the = in the front of the forumula - the Expression evaluator
            ' does not need it.  Also, make sure to trim the result to remove any
            ' spaces in the front and the back.
            expression = expression.TrimStart(New Char() {"="c, " "c}).Trim()


            ' If there are any exceptions when parsing or evaluating, they are
            ' thrown so that the end user can see the error.  As such, there is no
            ' Try-Catch block here.
            Try
                Dim eDynamic As IDynamicExpression = _evaluator.CompileDynamic(expression)
                Return eDynamic.Evaluate()
            Catch ex As Exception
                Return "ERROR: " & ex.Message
            End Try
        End Function


        ''' <summary>
        ''' Return the type of the given variable if it exists in the data source.
        ''' If the Return Type is Nothing, the evaluator assumes this is an invalid
        ''' variable and tries other methods to get its value.
        ''' </summary>
        ''' <param name="sender">The sender that sent this event.</param>
        ''' <param name="e">The event argument.  Set e.VariableType.</param>
        Protected Sub variables_ResolveVariableType(ByVal sender As Object, ByVal e As ResolveVariableTypeEventArgs)
            Dim col As BaseColumn

            ' Returning Nothing indicates that we do not recognize this variable.
            e.VariableType = Nothing

            ' If no DataSource was set, we do not have variables that we can use
            ' directly.
            If IsNothing(DataSource) Then Return

            Try
                ' Find a column in the datasource using a variable name.
                col = DataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(e.VariableName)
                If IsNothing(col) Then
                    ' if the variable name ended with "DefaultValue", remmove it and then try to get the column name again.
                    If BaseClasses.Utils.InvariantLCase(e.VariableName).EndsWith("defaultvalue") Then
                        col = DataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(e.VariableName.Substring(0, e.VariableName.Length - 12))
                    End If
                End If

                If IsNothing(col) Then
                    Return
                End If

                Select Case col.ColumnType
                    Case BaseColumn.ColumnTypes.Number, _
                        BaseColumn.ColumnTypes.Percentage, _
                         BaseColumn.ColumnTypes.Star
                        ' By default, all our internal data types use Decimal.
                        ' This may result in problems when using the Math library
                        ' but it reduces the problem by allowing us to loosely-type
                        ' all data source properties.
                        e.VariableType = GetType(Decimal)

                    Case BaseColumn.ColumnTypes.Currency
                        ' Convert currency into decimal to allow easier use in formulas
                        e.VariableType = GetType(Decimal)

                    Case BaseColumn.ColumnTypes.Boolean
                        ' Boolean data types are maintained as Boolean and not
                        ' converted to Integer as the Binary data type is.
                        e.VariableType = GetType(Boolean)

                    Case BaseColumn.ColumnTypes.Credit_Card_Date, _
                        BaseColumn.ColumnTypes.Date
                        ' Use DateTme even for Credit Card Date.
                        e.VariableType = GetType(DateTime)

                    Case BaseColumn.ColumnTypes.Country, _
                        BaseColumn.ColumnTypes.Credit_Card_Number, _
                        BaseColumn.ColumnTypes.Email, _
                        BaseColumn.ColumnTypes.Password, _
                        BaseColumn.ColumnTypes.String, _
                        BaseColumn.ColumnTypes.Unique_Identifier, _
                        BaseColumn.ColumnTypes.USA_Phone_Number, _
                        BaseColumn.ColumnTypes.USA_State, _
                        BaseColumn.ColumnTypes.USA_Zip_Code, _
                        BaseColumn.ColumnTypes.Very_Large_String, _
                        BaseColumn.ColumnTypes.Web_Url
                        ' For the purpose of formula's, all of the above field types
                        ' are treated as strings.
                        e.VariableType = GetType(String)

                    Case BaseColumn.ColumnTypes.Binary, _
                        BaseColumn.ColumnTypes.File, _
                        BaseColumn.ColumnTypes.Image
                        ' For the purpose of formula's we ignore BLOB fields since they
                        ' cannot be used in any calculations or string functions.
                        e.VariableType = Nothing

                    Case Else
                        ' Unknown data type.
                        e.VariableType = Nothing
                End Select

            Catch ex As Exception
                ' Ignore the error in case we cannot find the variable or its type - simply say that
                ' the Variable Type is Nothing - implying that we do not recognize this variable.
            End Try
        End Sub


        ''' <summary>
        ''' Return the value of the given variable if it exists in the data source
        ''' </summary>
        ''' <param name="sender">The input whose absolute value is to be found.</param>
        ''' <param name="e">The input whose absolute value is to be found.</param>
        Protected Sub variables_ResolveVariableValue(ByVal sender As Object, ByVal e As ResolveVariableValueEventArgs)
            Dim col As BaseColumn

            ' Default value is Nothing
            e.VariableValue = Nothing

            ' If no DataSource was set, we do not have variables that we can use
            ' directly.  We should not get here since the request for Type should have
            ' caught this.
            If IsNothing(DataSource) Then Return

            Try

                ' Find a column in the datasource using a variable name.
                col = DataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(e.VariableName)
                If IsNothing(col) Then
                    ' if the variable name ended with "DefaultValue", remmove it and then try to get the column name again.
                    If BaseClasses.Utils.InvariantLCase(e.VariableName).EndsWith("defaultvalue") Then
                        col = DataSource.TableAccess.TableDefinition.ColumnList.GetByCodeName(e.VariableName.Substring(0, e.VariableName.Length - 12))

                        Select Case col.ColumnType
                            Case BaseColumn.ColumnTypes.Number, _
                                BaseColumn.ColumnTypes.Percentage, _
                                 BaseColumn.ColumnTypes.Star
                                ' The Number and Percentage values are saved as Single.  So we first
                                ' retrieve the Single value and then convert to Decimal.  Our policy is
                                ' always to return Decimal (never to return Single or Double) to be constent 
                                ' and avoid type conversion in the evaluator.
                                e.VariableValue = BaseFormulaUtils.ParseDecimal(col.DefaultValue)

                            Case BaseColumn.ColumnTypes.Currency
                                e.VariableValue = Me.DataSource.GetValue(col).ToDecimal

                            Case BaseColumn.ColumnTypes.Boolean
                                e.VariableValue = col.DefaultValue
                            Case BaseColumn.ColumnTypes.Credit_Card_Date, _
                                BaseColumn.ColumnTypes.Date
                                e.VariableValue = BaseFormulaUtils.ParseDate(col.DefaultValue)

                            Case BaseColumn.ColumnTypes.Country, _
                                BaseColumn.ColumnTypes.Credit_Card_Number, _
                                BaseColumn.ColumnTypes.Email, _
                                BaseColumn.ColumnTypes.Password, _
                                BaseColumn.ColumnTypes.String, _
                                BaseColumn.ColumnTypes.Unique_Identifier, _
                                BaseColumn.ColumnTypes.USA_Phone_Number, _
                                BaseColumn.ColumnTypes.USA_State, _
                                BaseColumn.ColumnTypes.USA_Zip_Code, _
                                BaseColumn.ColumnTypes.Very_Large_String, _
                                BaseColumn.ColumnTypes.Web_Url
                                e.VariableValue = col.DefaultValue

                            Case BaseColumn.ColumnTypes.File, _
                                BaseColumn.ColumnTypes.Image
                                ' Can't do anything here.
                                e.VariableValue = Nothing

                            Case Else
                                e.VariableValue = Nothing
                        End Select
                    End If


                Else


                    Select Case col.ColumnType
                        Case BaseColumn.ColumnTypes.Number, _
                            BaseColumn.ColumnTypes.Percentage, _
                             BaseColumn.ColumnTypes.Star
                            ' The Number and Percentage values are saved as Single.  So we first
                            ' retrieve the Single value and then convert to Decimal.  Our policy is
                            ' always to return Decimal (never to return Single or Double) to be constent 
                            ' and avoid type conversion in the evaluator.
                            e.VariableValue = Decimal.Parse(Me.DataSource.GetValue(col).ToDouble().ToString())

                        Case BaseColumn.ColumnTypes.Currency
                            e.VariableValue = Me.DataSource.GetValue(col).ToDecimal

                        Case BaseColumn.ColumnTypes.Boolean
                            e.VariableValue = Me.DataSource.GetValue(col).ToBoolean

                        Case BaseColumn.ColumnTypes.Credit_Card_Date, _
                            BaseColumn.ColumnTypes.Date
                            e.VariableValue = Me.DataSource.GetValue(col).ToDateTime

                        Case BaseColumn.ColumnTypes.Country, _
                            BaseColumn.ColumnTypes.Credit_Card_Number, _
                            BaseColumn.ColumnTypes.Email, _
                            BaseColumn.ColumnTypes.Password, _
                            BaseColumn.ColumnTypes.String, _
                            BaseColumn.ColumnTypes.Unique_Identifier, _
                            BaseColumn.ColumnTypes.USA_Phone_Number, _
                            BaseColumn.ColumnTypes.USA_State, _
                            BaseColumn.ColumnTypes.USA_Zip_Code, _
                            BaseColumn.ColumnTypes.Very_Large_String, _
                            BaseColumn.ColumnTypes.Web_Url
                            e.VariableValue = Me.DataSource.GetValue(col).ToString

                        Case BaseColumn.ColumnTypes.File, _
                            BaseColumn.ColumnTypes.Image
                            ' Can't do anything here.
                            e.VariableValue = Nothing

                        Case Else
                            e.VariableValue = Nothing
                    End Select


                End If


            Catch ex As Exception
                ' Ignore the error in case we cannot find the variable or its type - simply say that
                ' the Variable Type is Nothing - implying that we do not recognize this variable.
            End Try
        End Sub

        'This method returns true or false value stating whether to apply GlobalWhereClause to a particular page or not.
        'Use this method to exclude pages from applying Global Where Clauses sepcified in Batch Meister Wizard.
        Public Shared Function ShouldApplyGlobalWhereClause(ByVal globalWhereClauseFormula As String) As Boolean

            If System.Web.HttpContext.Current Is Nothing Then
                Return False
            End If

            'Comment out the following code if you want to apply GlobalWhereClause to SignIn and SignOut pages
            If Not (BaseClasses.Configuration.ApplicationSettings.Current.AuthenticationType = BaseClasses.Configuration.SecurityConstants.None) Then
                If Not BaseClasses.Configuration.ApplicationSettings.Current.SecurityDisabled Then
                    If globalWhereClauseFormula.ToLower().Contains("userid()") Or globalWhereClauseFormula.ToLower().Contains("username()") Or _
                       globalWhereClauseFormula.ToLower().Contains("roles()") Then

                        If (System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToLower().Contains(BaseClasses.Configuration.ApplicationSettings.Current.SignInPageUrl.ToString().ToLower())) Then
                            Return False
                        End If
                        If (System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToLower().Contains(BaseClasses.Configuration.ApplicationSettings.Current.SignedOutPageUrl.ToString().ToLower())) Then
                            Return False
                        End If
                        If (System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToLower().Contains(BaseClasses.Configuration.ApplicationSettings.Current.ForgotUserPageUrl.ToString().ToLower())) Then
                            Return False
                        End If
                        If (System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToLower().Contains(BaseClasses.Configuration.ApplicationSettings.Current.SendUserInfoEmailUrl.ToString().ToLower())) Then
                            Return False
                        End If

                    End If
                End If
            End If
            Return True
        End Function


    End Class

End Namespace
