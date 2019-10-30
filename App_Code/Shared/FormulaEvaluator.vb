Imports Microsoft.VisualBasic
Imports System.IO
Imports BaseClasses.Data
Imports Ciloci.Flee
Imports IROC2.UI
Imports IROC2.Data

Namespace IROC2

    ''' <summary>
    ''' The FormulaEvaluator class evaluates a formula passed to the Evaluate function.
    ''' You must set the DataSource and Page variables as part of this.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormulaEvaluator
        Inherits BaseFormulaEvaluator


        ''' <summary>
        ''' Record control (or row) from which this evaluator is called.  Could be Nothing
        ''' if called from the data access layer.
        ''' </summary>
        Private _callingControl As Control = Nothing
        Public Property CallingControl() As Control
            Get
                Return _callingControl
            End Get
            Set(ByVal value As Control)
                _callingControl = value
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
            Evaluator.Imports.AddType(GetType(FormulaUtils))

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
        Public Overrides Function Evaluate(ByVal expression As String) As Object
            If IsNothing(expression) Then Return Nothing
			If expression = "" Then Return ""

            ' Strip of the = in the front of the forumula - the Expression evaluator
            ' does not need it.  Also, make sure to trim the result to remove any
            ' spaces in the front and the back.
            expression = expression.TrimStart(New Char() {"="c, " "c}).Trim()

            ' Add all realted controls of this control.  This includes the calling control, its children and parents.
            AddRelatedControlVariables()

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




#Region "Private functions"
        ''' <summary>
        ''' Adds related record and table controls.
        ''' This has to navigate up to the page level and add any table or record controls.
        ''' And we have to navigate within to add any record/table controls.
        ''' And we have to go sideways to also add any controls.
        ''' Finally we have to add the page control.
        ''' This allows the expression to use any record or table control on the page
        ''' as long as it is accessible without being in a repeater.
        ''' </summary>
        Private Sub AddRelatedControlVariables()
            If IsNothing(CallingControl) Then Return

            Try
                ' STEP 1: Our strategy is to first add the current control and
                ' all of its parents.  This way, we maintain the full context of where
                ' we are.  For example, if you are in a row within a table, within another row
                ' that is within another table, then by going up the hierarchy looking for parents
                ' will preserve all of the context.
                ' Later in Step 2 we will go through the other branches.
                Dim ctl As Control = CallingControl
                While Not (IsNothing(ctl))
                    If TypeOf ctl Is BaseApplicationRecordControl OrElse TypeOf ctl Is BaseApplicationTableControl Then
                        AddControlAndChildren(ctl)
                    End If
                    ' Navigate up.
                    ctl = ctl.Parent
                End While

                ' STEP 2: Go through the other branches on the page and add all other table and 
                ' record controls on the page.
                AddControlAndChildren(CallingControl.Page)

                ' STEP 3: Add more variable for ASCX control.
                AddVariableNameWithoutUnderscore()

                ' STEP 4: Finally add the Page itself.
                Evaluator.Variables.Add("Page", CallingControl.Page)

            Catch ex As Exception
                ' Ignore and continue in case of a problem.
            End Try

        End Sub

        ''' <summary>
        ''' Add this control and all child controls of the given control.
        ''' We only add the Record and Table Controls.  No other controls need
        ''' to be added.
        ''' This function is smart enough not to add or descend down a control
        ''' that was previously added by checking whether the Id is already contained
        ''' in the Evaluator variables.  This avoids unnecessary traversal.
        ''' This function is called recursively to add any child controls.
        ''' </summary>
        Private Sub AddControlAndChildren(ByVal ctl As Control)
            ' We quit immediately if a control is already in the list of variables,
            ' because we have convered that branch already.
            Try
                If IsNothing(ctl) Then Return

                If Not (IsNothing(ctl.ID)) AndAlso Evaluator.Variables.ContainsKey(ctl.ID) Then Return

                ' If this is a record or table control, add it.
                If TypeOf ctl Is BaseApplicationRecordControl OrElse TypeOf ctl Is BaseApplicationTableControl Then
                    If Not (IsNothing(ctl.ID)) Then
                        Evaluator.Variables.Add(ctl.ID, ctl)
                    End If
                End If

                For Each child As Control In ctl.Controls
                    ' We do not want to go into a repeater because there will be multiple rows.
                    ' So we will call AddChildControls only for those controls that are NOT repeaters.
                    If Not (TypeOf child Is System.Web.UI.WebControls.Repeater) Then
                        AddControlAndChildren(child)
                    End If
                Next
            Catch ex As Exception
                ' Ignore - we do not want to give an exception if we cannot add all variables.
            End Try

        End Sub


        ''' <summary>
        ''' If the current is not ASPX page but ASCX controls, the controls in this ASCX control has id starting with underscore.
        ''' To avoid confusion in formula, we also define variable name without underscore.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AddVariableNameWithoutUnderscore()
            Dim vars As New Collections.Generic.Dictionary(Of String, Object)
            Dim enumerator As Collections.Generic.IEnumerator(Of Collections.Generic.KeyValuePair(Of String, Object)) = Me.Evaluator.Variables.GetEnumerator()
            While enumerator.MoveNext
                If enumerator.Current.Key.StartsWith("_") Then
                    Dim varNameWitoutUnderscore As String = enumerator.Current.Key.Substring(1)
                    If Not Me.Evaluator.Variables.ContainsKey(varNameWitoutUnderscore) Then
                        vars.Add(varNameWitoutUnderscore, enumerator.Current.Value)
                    End If
                End If
            End While

            Dim enumerator2 As Collections.Generic.Dictionary(Of String, Object).Enumerator = vars.GetEnumerator()
            While enumerator2.MoveNext
                Me.Evaluator.Variables.Add(enumerator2.Current.Key, enumerator2.Current.Value)
            End While
        End Sub
#End Region


    End Class

End Namespace
