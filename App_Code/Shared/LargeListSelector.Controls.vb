Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Collections.Generic
Imports BaseClasses
Imports BaseClasses.Web.UI.WebControls
Imports BaseClasses.Data
Imports BaseClasses.Data.BaseFilter.ComparisonOperator
Imports BaseClasses.Data.BaseFilter
Imports BaseClasses.Utils
Imports BaseClasses.Data.OrderByItem.OrderDir

Namespace IROC2.UI.Controls.LargeListSelector

#Region "Section 1: Place your customizations here."

    Public Class ItemsTableRecordControl
        Inherits BaseItemsTableRecordControl

    End Class

    ' The ItemsTable class implements the query used to retrieve records
    ' to be displayed in the grid.  The static query at design time is combined with the dynamic
    ' filter and search criteria.

    Public Class ItemsTable
        Inherits BaseItemsTable

    End Class

#End Region

#Region "Section 2: Do not modify this section."
    ' Base class for the ItemsTableRecordControl control on the LargeListSelector page.
    Public Class BaseItemsTableRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        Private Const ASSEMBLY_NAME As String = "IROC2.Business"

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ' Register the event handlers.
            AddHandler Me.SelectButton.Click, AddressOf SelectButton_Click

            Me.Page.RegisterPostBackTrigger(Me.SelectButton, MiscUtils.GetParentControlObject(Me, "ItemsTableControlUpdatePanel"))

        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        ' Populate the UI controls using the DataSource.
        Public Overrides Sub DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If

            Dim table As ItemsTable = DirectCast(Me.Page.FindControlRecursively("ItemsTable"), ItemsTable)
            Dim td As BaseClasses.Data.TableDefinition = table.GetTable().TableDefinition
            Dim col As BaseClasses.Data.BaseColumn = td.ColumnList.GetByAnyName(table.Field)
            Dim displayCol As BaseClasses.Data.BaseColumn = td.ColumnList.GetByAnyName(table.DisplayField)

            Me.ValueText.Text = Me.DataSource.GetValue(col).ToString()

            Dim formula As String = table.Formula()
            Dim dfka As String = ""

            If Not String.IsNullOrEmpty(formula) Then
                Me.ItemText.Text = Me.EvaluateFormula(formula, Me.DataSource, Nothing, td.TableCodeName)
            Else
                If displayCol Is Nothing Then
                    dfka = table.DisplayField
                    If dfka.Trim.StartsWith("=") Then
                        Me.ItemText.Text = Me.EvaluateFormula(dfka, Me.DataSource, Nothing, td.TableCodeName)
                    Else
                        Me.ItemText.Text = Me.DataSource.Format(col)
                    End If
                Else
                    Me.ItemText.Text = Me.DataSource.Format(displayCol)
                End If

            End If

        End Sub

        ' Read data from database.
        Public Overridable Sub LoadData()
        End Sub


        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Dim e As FormulaEvaluator = New FormulaEvaluator()


            e.DataSource = Me.DataSource

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            Return resultObj.ToString()
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, Optional ByVal format As String = Nothing, Optional ByVal name As String = "") As String
            Dim e As IROC2.Data.BaseFormulaEvaluator = New IROC2.Data.BaseFormulaEvaluator()
            If Not dataSourceForEvaluate Is Nothing Then
                e.Evaluator.Variables.Add(name, dataSourceForEvaluate)
            End If
            e.DataSource = dataSourceForEvaluate

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            If Not String.IsNullOrEmpty(format) Then
                Return IROC2.Data.BaseFormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function

        Protected Overridable Sub SelectButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            Dim table As ItemsTable = DirectCast(Me.Page.FindControlRecursively("ItemsTable"), ItemsTable)
            Me.RegisterSelectValueScript(table.Target, Me.ValueText.Text, Me.ItemText.Text)

            Dim keyForVal As String = table.Target & "_SelectedValue"
            Dim keyForDisplayText As String = table.Target & "_SelectedDisplayText"

            Me.Page.Session.Add(keyForVal, Me.ValueText.Text)
            Me.Page.Session.Add(keyForDisplayText, Me.ItemText.Text)
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
        End Sub

        Protected Overrides Function SaveViewState() As Object
            Return MyBase.SaveViewState()
        End Function

        Private _DataSource As IRecord
        Public Property DataSource() As BaseRecord
            Get
                Return CType(Me._DataSource, BaseRecord)
            End Get
            Set(ByVal value As BaseRecord)
                Me._DataSource = value
            End Set
        End Property

#Region "Helper Properties"


        Public ReadOnly Property Formula() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Formula"), System.Web.UI.WebControls.Label)
            End Get
        End Property

        Public ReadOnly Property ValueText() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ValueText"), System.Web.UI.WebControls.Label)
            End Get
        End Property

        Public ReadOnly Property SelectButton() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "SelectButton"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property

        Public ReadOnly Property ItemText() As System.Web.UI.WebControls.Label
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ItemText"), System.Web.UI.WebControls.Label)
            End Get
        End Property
#End Region

#Region "Helper Functions"
        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

        Private Sub RegisterSelectValueScript(ByVal target As String, ByVal value As String, ByVal text As String)
            Dim scriptContent As String = String.Format( _
                "updateTarget({0}, {1}, {2});", _
                BaseClasses.Web.AspxTextWriter.CreateJScriptStringLiteral(target), _
                BaseClasses.Web.AspxTextWriter.CreateJScriptStringLiteral(value), _
                BaseClasses.Web.AspxTextWriter.CreateJScriptStringLiteral(text) _
                )
            Dim script As String = BaseClasses.Web.AspxTextWriter.CreateJScriptBlock(scriptContent)
            Me.Page.ClientScript.RegisterStartupScript(GetType(String), "SelectValueScript", script)
        End Sub

#End Region

    End Class

    ' Base class for the ItemsTable control on the LargeListSelector page.
    Public Class BaseItemsTable
        Inherits IROC2.UI.BaseApplicationTableControl

        Private Const ASSEMBLY_NAME As String = "IROC2.Business"

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init

            ' Setup the pagination events.
            AddHandler Me.Pagination.FirstPage.Click, AddressOf Pagination_FirstPage_Click
            AddHandler Me.Pagination.LastPage.Click, AddressOf Pagination_LastPage_Click
            AddHandler Me.Pagination.NextPage.Click, AddressOf Pagination_NextPage_Click
            AddHandler Me.Pagination.PageSizeButton.Click, AddressOf Pagination_PageSizeButton_Click
            AddHandler Me.Pagination.PreviousPage.Click, AddressOf Pagination_PreviousPage_Click

            ' Setup - the button events.
            AddHandler Me.SearchButton.Button.Click, AddressOf SearchButton_Click

            ' Control Initializations.
            If Not Me.Page.IsPostBack Then
                ' Initialize the table's current sort order.
                Me.CurrentSortOrder = New OrderBy(True, False)

                ' Setup default pagination settings.
                Me.PageSize = 10
                Me.PageIndex = 0
            End If

        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.RegisterAutoCloseScript()

            Try
                ' Load data only when displaying the page for the first time
                If (Not Me.Page.IsPostBack) Then

                    ' Must start a transaction before performing database operations
                    DbUtils.StartTransaction()

                    ' Load data for each record and table UI control.
                    ' Ordering is important because child controls get 
                    ' their parent ids from their parent UI controls.
                    Me.LoadData()
                    Me.DataBind()
                End If

            Catch ex As Exception
                ' An error has occured so display an error message.
                Utils.RegisterJScriptAlert(Me, "Load_Error_Message", ex.Message)
            Finally
                If Not Me.Page.IsPostBack Then
                    ' End database transaction
                    DbUtils.EndTransaction()
                End If
            End Try
        End Sub

        ' Read data from database. Returns an array of records that can be assigned
        ' to the DataSource table control property.
        Public Overridable Sub LoadData()

            ' Make sure all url parametes are passed.
            If ((Len(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Table", True)) < 1) OrElse _
                (Len(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Field", True)) < 1) OrElse _
                (Len(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "DisplayField", True)) < 1) OrElse _
                (Len(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Target", True)) < 1) _
            ) Then
                Me.DataSource = DirectCast((New ArrayList()).ToArray(GetType(BaseRecord)), BaseRecord())
                Return
            End If
            ' Save all of the URL parameters in the session for use by Ajax type-ahead control
            HttpContext.Current.Session().Add("LLSAjaxTable", Me.Table())
            HttpContext.Current.Session().Add("LLSAjaxField", Me.Field())
            HttpContext.Current.Session().Add("LLSAjaxDisplayField", Me.DisplayField())
            HttpContext.Current.Session().Add("LLSAjaxFormula", Me.Formula())

            ' The WHERE clause will be empty when displaying all records in table.
            Dim whereClause As WhereClause = CreateWhereClause()
            Dim orderBy As OrderBy = CreateOrderBy()

            ' Set the pagesize.
            Me.SetPagintionPageSize()

            ' Get the total number of records to be displayed.
            Me.TotalRecords = CInt(Me.GetTable().GetRecordListCount(Nothing, whereClause.GetFilter(), Nothing, Nothing))

            ' Go to the last page.
            If Me.TotalPages <= 0 Then
                Me.PageIndex = 0
            ElseIf Me.DisplayLastPage OrElse Me.PageIndex >= Me.TotalPages Then
                Me.PageIndex = Me.TotalPages - 1
            End If

            ' Retrieve the records and set the table DataSource.
            ' Only PageSize records are fetched starting at PageIndex (zero based).
            Dim join As BaseClasses.Data.BaseFilter = Nothing
            Me.DataSource = DirectCast(Me.GetTable().GetRecordList(join, whereClause.GetFilter(), Nothing, orderBy, Me.PageIndex, Me.PageSize, Nothing).ToArray(GetType(BaseRecord)), BaseRecord())

        End Sub

        ' Populate the UI controls.
        Public Overrides Sub DataBind()

            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If

            ' Setup the pagination controls.
            BindPaginationControls()

            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("row1"), System.Web.UI.WebControls.Repeater)
            rep.DataSource = Me.DataSource()
            rep.DataBind()

            Dim index As Integer = 0
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            Dim listDuplicatesText As New ArrayList()
            Dim listDuplicatesRecControl As New ArrayList()
            Dim fvalue As String
            Dim cvalue As String

            For Each repItem In rep.Items
                ' Loop through all rows in the table, set its DataSource and call DataBind().
                Dim recControl As ItemsTableRecordControl = DirectCast(repItem.FindControl("ItemsTableRecordControl"), ItemsTableRecordControl)
                recControl.DataSource = Me.DataSource(index)
                recControl.DataBind()

                fvalue = recControl.ItemText.Text
                cvalue = recControl.ValueText.Text

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                If (IsNothing(cvalue)) Then
                    cvalue = ""
                End If

                fvalue = fvalue.Trim()

                If (fvalue.Length > 50) Then
                    fvalue = fvalue.Substring(0, 50) + "..."
                End If

                Dim dupItemIdx As Integer = listDuplicatesText.IndexOf(fvalue)

                If (dupItemIdx >= 0) Then
                    Dim dupItem As ItemsTableRecordControl = CType(listDuplicatesRecControl(dupItemIdx), ItemsTableRecordControl)

                    dupItem.ItemText.Text = fvalue + " (ID " + dupItem.ValueText.Text.Substring(0, Math.Min(dupItem.ValueText.Text.Length, 38)) + ")"
                End If

                If (listDuplicatesText.Contains(fvalue)) Then
                    recControl.ItemText.Text = fvalue + " (ID " + cvalue.Substring(0, Math.Min(cvalue.Length, 38)) + ")"
                End If

                listDuplicatesText.Add(fvalue)
                listDuplicatesRecControl.Add(recControl)

                index += 1
            Next

        End Sub


        Protected Overridable Sub BindPaginationControls()

            ' Setup the pagination controls.

            ' Bind the buttons for CategoriesTableControl pagination.
            Me.Pagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            Me.Pagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            Me.Pagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            Me.Pagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)

            ' Bind the pagination labels.
            Me.Pagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Me.Pagination.PageSize.Text = Me.PageSize.ToString()          
            Dim totalPagesTB As Label = DirectCast(MiscUtils.FindControlRecursively(DirectCast(Me.Pagination, Control), "_TotalPages"), Label)
            If totalPagesTB IsNot Nothing Then
                totalPagesTB.Text = Me.TotalPages.ToString()
            End If
        End Sub

        Protected Overridable Sub SetPagintionPageSize()
            If Not Me.Pagination.PageSize Is Nothing AndAlso _
               Not Me.Pagination.PageSize.Text Is Nothing AndAlso _
               Me.Pagination.PageSize.Text.Trim <> "" Then
                Try
                    Me.PageSize = Integer.Parse(Me.Pagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Function CreateOrderBy() As OrderBy


            Dim displayCol As BaseClasses.Data.BaseColumn = Me.GetTable().TableDefinition.ColumnList.GetByAnyName(Me.DisplayField)


            If GetDFKAColumns().Count > 0 Then
                Dim dfkacolumns As List(Of BaseClasses.Data.BaseColumn) = GetDFKAColumns()
                For Each col As BaseClasses.Data.BaseColumn In dfkacolumns
                    If col.ColumnType.Equals(BaseColumn.ColumnTypes.String) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Number) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Email) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_State) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Zip_Code) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Phone_Number) Then
                        Me.CurrentSortOrder.Add(col, Asc)
                    End If
                Next
            Else
                Me.CurrentSortOrder.Add(displayCol, Asc)
            End If

            Return Me.CurrentSortOrder
        End Function

        Protected Overridable Function CreateWhereClause() As WhereClause
            Dim whereClause As WhereClause = New WhereClause()

            Dim displayCol As BaseClasses.Data.BaseColumn = Me.GetTable().TableDefinition.ColumnList.GetByAnyName(Me.DisplayField)

            If MiscUtils.IsValueSelected(Me.StartsWith) Then
                ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
                If Me.StartsWith.Text.StartsWith("...") Then
                    Me.StartsWith.Text = Me.StartsWith.Text.Substring(3, Me.StartsWith.Text.Length - 3)
                End If
                If Me.StartsWith.Text.EndsWith("...") Then
                    Me.StartsWith.Text = Me.StartsWith.Text.Substring(0, Me.StartsWith.Text.Length - 3)
                End If
                Me.StartsWith.Text = Me.StartsWith.Text.Trim()
                If GetDFKAColumns().Count > 0 Then
                    Dim wc As WhereClause = New WhereClause()
                    Dim dfkacolumns As List(Of BaseClasses.Data.BaseColumn) = GetDFKAColumns()
                    For Each col As BaseClasses.Data.BaseColumn In dfkacolumns
                        If col.ColumnType.Equals(BaseColumn.ColumnTypes.String) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Number) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Email) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_State) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Zip_Code) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Phone_Number) Then
                            wc.iOR(col, BaseFilter.ComparisonOperator.Starts_With, Me.StartsWith.Text, True, False)
                        End If
                    Next
                    whereClause.iAND(wc)
                Else
                    whereClause.iAND(displayCol, Starts_With, Me.StartsWith.Text, True, False)
                End If
            End If

                If MiscUtils.IsValueSelected(Me.Contains) Then
                    ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
                    If Me.Contains.Text.StartsWith("...") Then
                        Me.Contains.Text = Me.Contains.Text.Substring(3, Me.Contains.Text.Length - 3)
                    End If
                    If Me.StartsWith.Text.EndsWith("...") Then
                        Me.Contains.Text = Me.Contains.Text.Substring(0, Me.Contains.Text.Length - 3)
                    End If
                    Me.Contains.Text = Me.Contains.Text.Trim()
                If GetDFKAColumns().Count > 0 Then
                    Dim wc As WhereClause = New WhereClause()
                    Dim dfkacolumns As List(Of BaseClasses.Data.BaseColumn) = GetDFKAColumns()
                    For Each col As BaseClasses.Data.BaseColumn In dfkacolumns
                        If col.ColumnType.Equals(BaseColumn.ColumnTypes.String) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Number) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.Email) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_State) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Zip_Code) OrElse _
                           col.ColumnType.Equals(BaseColumn.ColumnTypes.USA_Phone_Number) Then
                            wc.iOR(col, BaseFilter.ComparisonOperator.Contains, Me.Contains.Text, True, False)
                        End If
                    Next
                    whereClause.iAND(wc)
                Else
                    whereClause.iAND(displayCol, ComparisonOperator.Contains, Me.Contains.Text, True, False)
                End If
            End If

            Return whereClause
        End Function


        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal bStartsWith As Boolean, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consiting of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            Dim displayCol As BaseClasses.Data.BaseColumn = Me.GetTable().TableDefinition.ColumnList.GetByAnyName(Me.DisplayField)

            ' Adds clauses if values are selected in Filter controls which are configured in the page.

            If IsValueSelected(searchText) Then
                Dim formatedSearchText As String = searchText
                ' strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
                If searchText.StartsWith("...") Then
                    formatedSearchText = searchText.Substring(3, searchText.Length - 3)
                End If
                If searchText.EndsWith("...") Then
                    formatedSearchText = searchText.Substring(0, searchText.Length - 3)
                End If
                'After stripping "...", trim any leading and trailing whitespaces 
                formatedSearchText = formatedSearchText.Trim()

                ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                Dim search As WhereClause = New WhereClause()
                If Not displayCol Is Nothing Then
                    If bStartsWith Then
                        ' Search Text specified in Starts With textbox
                        search.iOR(displayCol, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                    Else
                        ' Search Text specified in Contains textbox
                        search.iOR(displayCol, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                        search.iOR(displayCol, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators & formatedSearchText, True, False)
                    End If
                Else
                    Dim dfkacolumns As List(Of BaseClasses.Data.BaseColumn) = GetDFKAColumns()
                    For Each col As BaseClasses.Data.BaseColumn In dfkacolumns
                        If col.ColumnType.Equals(BaseColumn.ColumnTypes.String) Then
                            If (bStartsWith) Then
                                ' Search Text specified in Starts With textbox 
                                search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                            End If
                        Else
                            ' Search Text specified in Contains textbox 
                            search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                            search.iOR(col, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators + formatedSearchText, True, False)
                        End If
                    Next
                End If
                wc.iAND(search)
            End If

            If Not displayCol Is Nothing Then
                ' The Ajax call may come from one of the fields (e.g., StartsWith).  But the user may have some text in the other field.  
                ' So we need to add the clause for the other field.

                If Not (bStartsWith) Then
                    ' This was the Contains textbox that was used in Ajax, so add the StartsWith clause.
                    Dim StartsWithSearchSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "StartsWithSearch_Ajax"), String)
                    If IsValueSelected(StartsWithSearchSelectedValue) Then
                        wc.iAND(displayCol, BaseFilter.ComparisonOperator.Starts_With, StartsWithSearchSelectedValue, False, False)
                    End If
                Else
                    ' This was the StartsWith textbox that was used in Ajax, so add the Contains clause.
                    Dim ContainsSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "ContainsSearch_Ajax"), String)
                    If IsValueSelected(ContainsSelectedValue) Then
                        wc.iAND(displayCol, BaseFilter.ComparisonOperator.Contains, ContainsSelectedValue, False, False)
                    End If
                End If
            Else

                Dim dfkacolumns As List(Of BaseClasses.Data.BaseColumn) = GetDFKAColumns()
                Dim wcAllColumns As WhereClause = New WhereClause()
                For Each col As BaseClasses.Data.BaseColumn In dfkacolumns
                    If Not (bStartsWith) Then
                        ' This was the Contains textbox that was used in Ajax, so add the StartsWith clause.
                        Dim StartsWithSearchSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "StartsWithSearch_Ajax"), String)
                        If IsValueSelected(StartsWithSearchSelectedValue) Then
                            wcAllColumns.iOR(col, BaseFilter.ComparisonOperator.Starts_With, StartsWithSearchSelectedValue, False, False)
                        End If
                    Else
                        ' This was the StartsWith textbox that was used in Ajax, so add the Contains clause.
                        Dim ContainsSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "ContainsSearch_Ajax"), String)
                        If IsValueSelected(ContainsSelectedValue) Then
                            wcAllColumns.iOR(col, BaseFilter.ComparisonOperator.Contains, ContainsSelectedValue, False, False)
                        End If
                    End If
                Next
            End If

            Return wc
        End Function
        Public Overridable Function GetDFKAColumns() As List(Of BaseClasses.Data.BaseColumn)

            Dim formula As String = ""
            Dim table As ItemsTable = CType(Me.Page.FindControlRecursively("ItemsTable"), ItemsTable)

            If Not String.IsNullOrEmpty(table.Formula) Then
                formula = table.Formula
            Else
                Dim dfka As String = Me.DisplayField
                dfka = dfka.Replace(Me.Table, "")
                dfka = dfka.Replace("=", "")
                dfka = dfka.Replace(" ", "")
                formula = dfka
            End If

            Dim dfkaColumns As List(Of BaseClasses.Data.BaseColumn) = New List(Of BaseClasses.Data.BaseColumn)()
            Dim columns() As BaseClasses.Data.BaseColumn = Me.GetTable().TableDefinition.ColumnList.ToColumnArray()
            For Each col As BaseColumn In columns
                If formula.ToLower().Contains(col.CodeName.ToLower()) Then
                    formula.Replace(col.CodeName, "")
                    dfkaColumns.Add(col)
                End If
            Next
            Return dfkaColumns
        End Function

        Public Overridable Function GetAutoCompletionList(ByVal startsWithText As String, ByVal containsText As String, ByVal count As Integer) As String()
            Dim resultList As ArrayList = New ArrayList
            Dim wordList As ArrayList = New ArrayList
            Dim iteration As Integer = 0
            Dim prefixText As String = ""
            Dim displayCol As BaseClasses.Data.BaseColumn = Me.GetTable().TableDefinition.ColumnList.GetByAnyName(Me.DisplayField)

            Dim wc As WhereClause

            If Not (IsNothing(startsWithText)) AndAlso startsWithText.Trim.Length() > 0 Then
                prefixText = startsWithText
                wc = CreateWhereClause(startsWithText, True, "[!a-zA-Z0-9]")
            Else
                prefixText = containsText
                wc = CreateWhereClause(containsText, False, "[!a-zA-Z0-9]")
            End If

            While (resultList.Count < count AndAlso iteration < 5)
                ' Fetch 100 records in each iteration
                ' Dim records() As BaseRecord = Me.GetTable().G.GetRecords(wc, Nothing, iteration, 100)
                Dim join As BaseClasses.Data.BaseFilter = Nothing
                Dim records() As BaseRecord = DirectCast(Me.GetTable().GetRecordList(join, wc.GetFilter(), Nothing, Nothing, iteration, 100).ToArray(GetType(BaseRecord)), BaseRecord())
                Dim rec As BaseRecord = Nothing
                Dim resultItem As String = ""
                For Each rec In records
                    ' Exit the loop if recordList count has reached AutoTypeAheadListSize.
                    If resultList.Count >= count Then
                        Exit For
                    End If
                    ' If the field is configured to Display as Foreign key, Format() method returns the 
                    ' Display as Forien Key value instead of original field value.
                    ' Since search had to be done in multiple fields (selected in Control's page property, binding tab) in a record,
                    ' We need to find relevent field to display which matches the prefixText and is not already present in the result list.

                    resultItem = rec.Format(displayCol)

                    If InvariantUCase(resultItem).Contains(InvariantUCase(prefixText)) Then
                        Dim isAdded As Boolean = FormatSuggestions(prefixText, resultItem, 50, "AtBeginningOfMatchedString", "WordsStartingWithSearchString", "[^a-zA-Z0-9]", resultList)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                Next

                ' Exit the loop if number of records found is less as further iteration will not return any more records
                If records.Length < 100 Then
                    Exit While
                End If
                iteration += 1
            End While

            resultList.Sort()
            Dim result() As String = New String(resultList.Count - 1) {}
            Array.Copy(resultList.ToArray, result, resultList.Count)
            Return result
        End Function



        'Formats the resultItem and adds it to the list of suggestions.
        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                                 ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                                 ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                                 ByVal resultList As ArrayList) As Boolean
            Dim index As Integer = InvariantLCase(resultItem).IndexOf(InvariantLCase(prefixText))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If
            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else
                            itemToAdd = "..." & resultItem.Substring(index, Len(resultItem) - index)
                        End If
                    Else
                        If index = 0 Then
                            itemToAdd = resultItem.Substring(index, (columnLength - 3)) & "..."
                        Else
                            'Truncate the string to show only columnLength - 6 characters as begining and trailing "..." has to be appended.
                            itemToAdd = "..." & resultItem.Substring(index, columnLength - 6) & "..."
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) = columnLength Then
                            itemToAdd = "..." & resultItem.Substring(index - columnLength, index)
                        ElseIf Len(resultITem) - index < subStringBeginIndex Then
                            ' Display string from the end till columnLength value if, index is closer to the end of the string.
                            itemToAdd = "..." & resultItem.Substring(Len(resultItem) - columnLength, Len(resultItem))
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity chet at beginning of the string
                            itemToAdd = resultItem.Substring(0, columnLength) & "..."
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText
                            itemToAdd = "..." & resultItem.Substring(index - subStringBeginIndex, columnLength) & "..."
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        If index = Len(resultItem) Then   'Make decision to append "..."
                            itemToAdd = resultItem.Substring(0, index)
                        Else
                            itemToAdd = resultItem.Substring(0, index) & "..."
                        End If
                    Else
                        If index = Len(resultItem) Then
                            itemToAdd = "..." & resultItem.Substring(index - (columnLength - 3), (columnLength - 3))
                        Else
                            'Truncate the string to show only columnLength - 6 characters as begining and trailing "..." has to be appended.
                            itemToAdd = "..." & resultItem.Substring(index - (columnLength - 6), columnLength - 6) & "..."
                        End If
                    End If
                End If
                If Not itemToAdd Is Nothing AndAlso Not resultList.Contains(itemToAdd) Then
                    resultList.Add(itemToAdd)
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function



        Private Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            If Me.DataChanged Then
                Try
                    ' Must start a transaction before performing database operations
                    DbUtils.StartTransaction()

                    ' Load data for each record and table UI control.
                    ' Ordering is important because child controls get 
                    ' their parent ids from their parent UI controls.
                    Me.LoadData()
                    Me.DataBind()

                Catch ex As Exception
                    ' An error has occured so display an error message.
                    Utils.RegisterJScriptAlert(Me, "Load_Error_Message", ex.Message)
                Finally
                    ' End database transaction
                    DbUtils.EndTransaction()
                End Try
            End If
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("ItemsTable_OrderBy"), String)
            If Not orderByStr Is Nothing OrElse orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            End If

            Dim pageIndex As String = CType(ViewState("Page_Index"), String)
            If Not pageIndex Is Nothing Then
                Me.PageIndex = CInt(pageIndex)
            End If

            Dim pageSize As String = CType(ViewState("Page_Size"), String)
            If Not pageSize Is Nothing Then
                Me.PageSize = CInt(pageSize)
            End If
        End Sub

        Protected Overrides Function SaveViewState() As Object

            Me.ViewState("ItemsTable_OrderBy") = Me.CurrentSortOrder.ToXmlString()

            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize

            Return MyBase.SaveViewState()

        End Function

        ' Generate the event handling functions for pagination events.
        Public Overridable Sub Pagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
            Try
                Me.PageIndex = 0
                Me.DataChanged = True
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        ' event handler for ImageButton
        Public Overridable Sub Pagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
            Try
                Me.DisplayLastPage = True
                Me.DataChanged = True
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        ' event handler for ImageButton
        Public Overridable Sub Pagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
            Try
                Me.PageIndex += 1
                Me.DataChanged = True
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        ' event handler for Button w/ Layout
        Public Overridable Sub Pagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            Try
                Me.DataChanged = True
                Me.PageSize = Integer.Parse(Me.Pagination.PageSize.Text)
                Me.PageIndex = Integer.Parse(Me.Pagination.CurrentPage.Text) - 1
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        ' event handler for ImageButton
        Public Overridable Sub Pagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
            Try
                If Me.PageIndex > 0 Then
                    Me.PageIndex -= 1
                    Me.DataChanged = True
                End If
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        ' Generate the event handling functions for button events.
        Public Overridable Sub SearchButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            Try
                Me.DataChanged = True
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
            End Try
        End Sub

        Private _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Private _TotalRecords As Integer
        Public Property TotalRecords() As Integer
            Get
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                    Dim num As Double = Me.PageSize
                    Me.TotalPages = CInt(Math.Ceiling(value / num))
                End If

                Me._TotalRecords = value
            End Set
        End Property

        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property

        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property

        Public Property DataSource() As BaseRecord()
            Get
                Return Me._DataSource
            End Get
            Set(ByVal value() As BaseRecord)
                Me._DataSource = value
            End Set
        End Property

        Public ReadOnly Property Table() As String
            Get
                Dim errMsg As String = ""
                Dim TYPE_FORMAT As String = "{0}.{1}{2},{3}"
                Dim tableName As String = ""
                Try
                    ' Try getting from the URL.  If not, get it from the session.
                    tableName = BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Table", True)
                    tableName = HttpUtility.UrlDecode(tableName)
                Catch ex As Exception
                    ' Get from the session.  This table name already contains the prefix required, so we return directly.
                    tableName = CStr(HttpContext.Current.Session()("LLSAjaxTable"))
                    Return tableName
                End Try

                tableName = CType(Me.Page, BaseApplicationPage).Decrypt(tableName)

                tableName = tableName.Replace(" ", "_")
                tableName = tableName.Replace(".", "_")


                ' Check if it is a table.
                Try

                    Dim tableType As String = String.Format(TYPE_FORMAT, "IROC2.Business", tableName, "Table", "App_Code")
                    Type.GetType(tableType, True, True)
                    Return tableType
                Catch ex As Exception
                End Try

                ' Check if it is a view.
                Try

                    Dim viewType As String = String.Format(TYPE_FORMAT, "IROC2.Business", tableName, "View", "App_Code")
                    Type.GetType(viewType, True, True)
                    Return viewType
                Catch ex As Exception
                End Try

                ' Check if it is a query.
                Try

                    Dim queryType As String = String.Format(TYPE_FORMAT, "IROC2.Business", tableName, "Query", "App_Code")
                    Type.GetType(queryType, True, True)
                    Return queryType
                Catch ex As Exception
                End Try

                Try

                    Dim tableType As String = String.Format(TYPE_FORMAT, "IROC2.Business", "Table" & tableName, "Table", "App_Code")
                    Type.GetType(tableType, True, True)
                    Return tableType
                Catch ex As Exception
                End Try

                ' Check if it is a view.
                Try

                    Dim viewType As String = String.Format(TYPE_FORMAT, "IROC2.Business", "Table" & tableName, "View", "App_Code")
                    Type.GetType(viewType, True, True)
                    Return viewType
                Catch ex As Exception
                End Try

                ' Check if it is a query.
                Try

                    Dim queryType As String = String.Format(TYPE_FORMAT, "IROC2.Business", "Table" & tableName, "Query", "App_Code")
                    Type.GetType(queryType, True, True)
                    Return queryType
                Catch ex As Exception
                End Try

                Throw New Exception("Fail to locate business layer for " & tableName)
                Return ""
            End Get
        End Property

        Public ReadOnly Property Field() As String
            Get
                Dim fld As String = ""
                Try
                    ' Try getting from the URL.  If not, get it from the session.
                    fld = BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Field", True)
					fld = HttpUtility.UrlDecode(fld)
                Catch ex As Exception
                    ' Get from the session
                    fld = CStr(HttpContext.Current.Session()("LLSAjaxField"))
                End Try

	            fld = CType(Me.Page, BaseApplicationPage).Decrypt(fld)

                Return fld
            End Get
        End Property

        Public ReadOnly Property DisplayField() As String
            Get
                Dim fld As String = ""
                Try
                    Try
                        ' Try getting from the URL.  If not, get it from the session.
                        fld = BaseClasses.Utils.NetUtils.GetUrlParam(Me, "DisplayField", True)
	                    fld = HttpUtility.UrlDecode(fld)
                    Catch ex As Exception
                        ' Get from the session
                        fld = CStr(HttpContext.Current.Session()("LLSAjaxDisplayField"))
                    End Try

                    fld = CType(Me.Page, BaseApplicationPage).Decrypt(fld)
                Catch
                End Try
                Return fld
            End Get
        End Property

        Public ReadOnly Property Formula() As String
            Get
                Dim fld As String = ""
                Try
                    Try
                        ' Try getting from the URL.  If not, get it from the session.
                        fld = BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Formula", False, False, False)
						fld = HttpUtility.UrlDecode(fld)
                    Catch ex As Exception
                        ' Get from the session
                        fld = CStr(HttpContext.Current.Session()("LLSFormulaField"))
                    End Try

                    fld = CType(Me.Page, BaseApplicationPage).Decrypt(fld)

                Catch

                End Try

                Return fld
            End Get
        End Property

        Public ReadOnly Property Target() As String
            Get
                Return BaseClasses.Utils.NetUtils.GetUrlParam(Me, "Target", True)
            End Get
        End Property

#Region "Helper Properties"
        Public ReadOnly Property StartsWith() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "StartsWith"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property

        Public ReadOnly Property Contains() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Contains"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property

        Public ReadOnly Property SearchButton() As IROC2.UI.IThemeButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "SearchButton"), IROC2.UI.IThemeButton)
            End Get
        End Property

        Public ReadOnly Property Pagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pagination"), IROC2.UI.IPaginationMedium)
            End Get
        End Property
#End Region

#Region "Helper Functions"

        ' What do we generate when there is no selection box for the record?
        Public Overloads Overrides Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.ModifyRedirectUrl(url, arg, Nothing, False)
        End Function

        Public Function GetRecordControls() As ItemsTableRecordControl()

            Dim recList As ArrayList = New ArrayList()

            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("row1"), System.Web.UI.WebControls.Repeater)
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items
                Dim recControl As ItemsTableRecordControl = DirectCast(repItem.FindControl("ItemsTableRecordControl"), ItemsTableRecordControl)
                recList.Add(recControl)
            Next

            Return DirectCast(recList.ToArray(GetType(ItemsTableRecordControl)), ItemsTableRecordControl())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

        Private Sub RegisterAutoCloseScript()
            'If (Me.IsPostBack) Then
            '    Return
            'End If
            If (BaseClasses.Utils.StringUtils.InvariantUCase(Me.Page.Request.Browser.Browser).IndexOf("IE") < 0) Then
                Return
            End If
            If (Me.Page.Request.Browser.MajorVersion < 5) Then
                Return
            End If

            'attach a function to the parent window's onunload event
            'that will close the current window
            Dim script As String = BaseClasses.Web.AspxTextWriter.CreateJScriptBlock( _
                "function onParentUnload() { window.close(); }" & vbCrLf & _
                "if (window.opener && !window.opener.closed) { window.opener.attachEvent('onunload', onParentUnload);}")
            Me.Page.ClientScript.RegisterClientScriptBlock(GetType(String), "AutoCloseScript", script)
        End Sub

        Public Function GetTable() As BaseClasses.Data.BaseTable
            Dim tn As String = Me.Table
            Try
                Return BaseClasses.Data.BaseTable.CreateInstance(tn)
            Catch e As System.Exception
                tn = String.Format("{0}.{1}Access,{2}", "IROC2", Replace(tn, " ", "_"), "IROC2")
                Return BaseClasses.Data.BaseTable.CreateInstance(tn)
            End Try
        End Function
#End Region

    End Class

#End Region

End Namespace