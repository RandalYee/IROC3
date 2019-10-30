' This file implements the code-behind class for ImportData.aspx.

#region"Imports statements"

Imports System
Imports System.Data
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports BaseClasses.Web.UI.WebControls

Imports IROC2.Business
Imports IROC2.Data

Imports System.Text
Imports System.IO



#end region

Namespace IROC2.UI
    
    
    Partial Public Class ImportData
        Inherits BaseApplicationPage

#Region "Section 1: Place your customizations here."
        ' Code-behind class for the ImportData page.
        ' Place your customizations in Section 1. Do not modify Section 2.
        Private Const MAXIMUMCHAR As Integer = 100
        Private Const CHARLIMIT As Integer = 2000
        Private Const ENDING As String = "..."
        Private Const SKIPTHRESHOLD As Integer = 25

        Public Sub New()
            MyBase.New()
            Me.Initialize()
            AddHandler Init, AddressOf Me.MyInit
        End Sub

        Public ReadOnly Property AppName() As String
            Get
                Return BaseClasses.Configuration.ApplicationSettings.Current.GetAppSetting(BaseClasses.Configuration.ApplicationSettings.ConfigurationKey.ApplicationName)
            End Get
        End Property

        Public ReadOnly Property TableName() As String
            Get
                Return Me.Decrypt(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "TableName", True))
            End Get
        End Property

        Public ReadOnly Property FilePath() As String
            Get
                Return CType(Session("FilePath"), String)
            End Get
        End Property

        Public Sub LoadData()
            ' LoadData reads database data and assigns it to UI controls.
            ' Customize by adding code before or after the call to LoadData_Base()
            ' or replace the call to LoadData_Base().
            LoadData_Base()

        End Sub

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            Me.Page_PreInit_Base()
        End Sub

        <System.Web.Services.WebMethod()> _
        Public Shared Function GetRecordFieldValue(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            ' GetRecordFieldValue gets the pop up window content from the column specified by
            ' columnName in the record specified by the recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetRecordFieldValue_Base()
            ' or replace the call to  GetRecordFieldValue_Base().
            Return GetRecordFieldValue_Base(tableName, recordID, columnName, title, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        <System.Web.Services.WebMethod()> _
        Public Shared Function GetImage(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            ' GetImage gets the Image url for the image in the column "columnName" and
            ' in the record specified by recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetImage_Base()
            ' or replace the call to  GetImage_Base().
            Return GetImage_Base(tableName, recordID, columnName, title, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        Private Sub MyInit(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not (Session("FilePath") Is Nothing) Then
                ' Retrieve information from session.
                Dim updatedRecordID As String = CType(Session("FilePath"), String)
                ParseCSVFile()
            End If
            Me.Page.Title = Me.GetResourceValue("Import:Step2", Me.AppName)
            Me.ImportFirstRowCheckBox.Checked = True
            Me.ImportResolveForeignKeys.Checked = True
        End Sub


        Public Sub PreviousButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for PreviousButton.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            'PreviousButton_Click_Base(sender, args);
            If (File.Exists(Me.FilePath)) Then
                File.Delete(Me.FilePath)
            End If
            Me.Page.Response.Redirect(("SelectFileToImport.aspx?TableName=" + Me.Encrypt(Me.TableName)))
            ' pass the table name as it is, without decryption.
            ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub

        'This is the Import button click
        Public Sub ImportButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Click handler for ImportButton.
            ' Customize by adding code before the call or replace the call to the Base function with your own code.
            'ImportButton_Click_Base(sender, args);
            ImportButton_Click_Base(sender, args)
        End Sub


        Public Function GetTable() As BaseClasses.Data.BaseTable
            Try
                Return DatabaseObjects.GetTableObject(Me.TableName)
            Catch ex As System.Exception
                Return DatabaseObjects.GetTableObject(Me.TableName)
            End Try
        End Function

#End Region

#Region "Section 2: Do not modify this section."

        Private Sub Initialize()
            ' Called by the class constructor to initialize event handlers for Init and Load
            ' You can customize by modifying the constructor in Section 1.
            AddHandler Init, AddressOf Me.Page_InitializeEventHandlers
            AddHandler Load, AddressOf Me.Page_Load
        End Sub

        ' Handles base.Init. Registers event handler for any button, sort or links.
        ' You can add additional Init handlers in Section 1.
        Protected Overridable Sub Page_InitializeEventHandlers(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Register the Event handler for any Events.
            AddHandler ImportButton.Button.Click, AddressOf Me.ImportButton_Click
            AddHandler PreviousButton.Button.Click, AddressOf Me.PreviousButton_Click
        End Sub

        Protected Sub Page_PreInit_Base()
            'If this is multi-color theme assign proper theme
            Dim selectedTheme As String = Me.GetSelectedTheme()
            If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
        End Sub

        ' Handles base.Load.  Read database data and put into the UI controls.
        ' You can add additional Load handlers in Section 1.
        Protected Overridable Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Check if user has access to this page.  Redirects to either sign-in page
            ' or 'no access' page if not. Does not do anything if role-based security
            ' is not turned on, but you can override to add your own security.
            Me.Authorize(Me.GetAuthorizedRoles)
            ' Load data only when displaying the page for the first time
            If Not Me.IsPostBack Then
                ' Setup the header text for the validation summary control.
                Me.ValidationSummary1.HeaderText = GetResourceValue("ValidationSummaryHeaderText", Me.AppName)
                ' Show message on Click

                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()

            End If
        End Sub

        Public Shared Function GetRecordFieldValue_Base(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            Dim content As String = NetUtils.EncodeStringForHtmlDisplay(BaseClasses.Utils.MiscUtils.GetFieldData(tableName, recordID, columnName))
            ' returnValue is an array of string values.
            ' returnValue(0) represents title of the pop up window.
            ' returnValue(1) represents content ie, image url.
            ' returnValue(2) represents whether pop up window should be made persistant
            ' or it should close as soon as mouse moves out.
            ' returnValue(3), (4) represents pop up window height and width respectivly
            ' returnValue(5) represents whether pop up window should contain scroll bar.
            ' (0),(2),(3) and (4) is initially set as pass through attribute.
            ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
            Dim returnValue() As Object = New Object((6) - 1) {}
            returnValue(0) = title
            returnValue(1) = content
            returnValue(2) = persist
            returnValue(3) = popupWindowWidth
            returnValue(4) = popupWindowHeight
            returnValue(5) = popupWindowScrollBar
            Return returnValue
        End Function

        Public Shared Function GetImage_Base(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            Dim content As String = ("<IMG alt =\""" + title + "\"" src =" + ("\""../Shared/ExportFieldValue.aspx?Table=" _
                        + (tableName + ("&Field=" _
                        + (columnName + ("&Record=" _
                        + (recordID + "\""/>")))))))
            ' returnValue is an array of string values.
            ' returnValue(0) represents title of the pop up window.
            ' returnValue(1) represents content ie, image url.
            ' returnValue(2) represents whether pop up window should be made persistant
            ' or it should close as soon as mouse moves out.
            ' returnValue(3), (4) represents pop up window height and width respectivly
            ' returnValue(5) represents whether pop up window should contain scroll bar.
            ' (0),(2),(3), (4) and (5) is initially set as pass through attribute.
            ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
            Dim returnValue() As Object = New Object((6) - 1) {}
            returnValue(0) = title
            returnValue(1) = content
            returnValue(2) = persist
            returnValue(3) = popupWindowWidth
            returnValue(4) = popupWindowHeight
            returnValue(5) = popupWindowScrollBar
            Return returnValue
        End Function

        ' Load data from database into UI controls.
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()
            Me.ImportFirstRowCheckBox.Text = GetResourceValue("Import:FirstRowText", Me.AppName)
            Me.ImportResolveForeignKeys.Text = GetResourceValue("Import:ResolveForeignKeys", Me.AppName)
            Me.DataBind()
        End Sub

        ' Write out event methods for the page events
        ' event handler for Button with Layout
        Public Sub ImportButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
            Dim bt As BaseTable = Me.GetTable
            Dim success As Boolean = False
            Dim recordsImported As BaseClasses.Utils.ImportedResults = Nothing
            Try
                ' Get the column names list and importChkBox list.
                Dim disp As Table = CType(Me.Page.FindControl("DisplayTable"), Table)
                Dim cellcount As Integer = disp.Rows(0).Cells.Count
                Dim ddListSelected As ArrayList = New ArrayList
                Dim chkBoxList As ArrayList = New ArrayList
                Dim rc As Integer = 0
                Do While (rc _
                            < (cellcount - 1))
                    Dim dd As DropDownList = CType(disp.FindControl(("dropDownList" & rc)), DropDownList)
                    If ddListSelected.Contains(dd.SelectedValue) AndAlso dd.SelectedValue <> "" Then
                        MiscUtils.RegisterJScriptAlert(Me, "Duplicate Column", Me.GetResourceValue("Import:DuplicateColumn", Me.AppName).Replace("{ColumnName}", dd.SelectedValue))
                        Return
                    End If
                    ddListSelected.Add(dd.SelectedValue)
                    Dim chkBox As CheckBox = CType(disp.FindControl(("importChkBox" & rc)), CheckBox)
                    chkBoxList.Add(chkBox)
                    'Store the index of the column which matches with the column name selected in the ColumnList drop down list.
                    ' This will be used later to updated a row based on this index
                    'if (dd.SelectedValue == this.ColumnsList.SelectedValue)
                    '    columnIndex = rc;
                    rc = (rc + 1)
                Loop
                ' Validate selected columns.
                If Not validateColumns(ddListSelected, chkBoxList, bt) Then
                    Return
                End If
                Dim imp As ImportDataItems = New ImportDataItems(Me.FilePath, GetFileType(), bt, ddListSelected, chkBoxList)
                recordsImported = imp.ImportRecords(Me.ImportFirstRowCheckBox.Checked, Me.ImportResolveForeignKeys.Checked)
            Catch e As Exception
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, "ErrorMsg", ("alert(" _
                                & (BaseClasses.Web.AspxTextWriter.CreateJScriptStringLiteral(e.Message) & ");")), True)
            End Try
            If recordsImported Is Nothing Then recordsImported = New BaseClasses.Utils.ImportedResults
            Dim script As String = Me.ConstructScriptForSkippedRecords(recordsImported)
            If script.Contains("<script>") Then
                ClientScript.RegisterStartupScript(Page.GetType(), "CloseWindow", script)
            Else
                WriteTextFileForSkippedRecords(script)
            End If
        End Sub

        Private Function ConstructScriptForSkippedRecords(ByVal recordsImported As BaseClasses.Utils.ImportedResults) As String
            Dim msg As String = Me.GetResourceValue("Import:Success", Me.AppName).Replace("{Records}", recordsImported.NumberOfImported.ToString())  'NumberOfRecordImported(0).ToString())
            Dim msg2 As String = Me.GetResourceValue("Import:Skipped", Me.AppName).Replace("{Records}", recordsImported.NumberOfSkipped.ToString()) 'NumberOfRecordImported(1).ToString())
            Dim script As String = ""
            Dim symbolsCount As Integer = 0
            script &= "<script>"
            If recordsImported.NumberOfSkipped > 0 Then
                script &= "CloseWindow('" & msg & "','" & msg2

                Dim msg3 As String = Me.GetResourceValue("Import:FirstSkippedRecords", Me.AppName) '"Skipped Records (Line number: record):"

                symbolsCount += msg.Length + msg2.Length + msg3.Length

                Dim linesMsg As String = ""
                Dim index As Integer = 0
                For Each rec As BaseClasses.Utils.SkippedLine In recordsImported.ListOfSkipped
                    Dim newLineEntry As String = ""
                    If recordsImported.NumberOfSkipped >= SKIPTHRESHOLD OrElse (recordsImported.NumberOfSkipped > 0 AndAlso recordsImported.NumberOfImported > 0) Then
                        newLineEntry = Me.ConstructLineEntryForTextFile(rec, MAXIMUMCHAR)
                    Else
                        newLineEntry = Me.ConstructLineEntry(rec, MAXIMUMCHAR)
                    End If
                    If newLineEntry.Length + symbolsCount < CHARLIMIT Then
                        linesMsg &= newLineEntry
                        symbolsCount += newLineEntry.Length
                        index += 1
                    Else
                        Exit For
                    End If
                Next
                If index < recordsImported.ListOfSkipped.Count Then
                    msg3 = Me.GetResourceValue("Import:FirstSkippedRecords", Me.AppName).Replace("{Number}", index.ToString)
                Else
                    msg3 = Me.GetResourceValue("Import:SkippedRecords", Me.AppName)
                End If
                If recordsImported.NumberOfSkipped >= SKIPTHRESHOLD OrElse (recordsImported.NumberOfSkipped > 0 AndAlso recordsImported.NumberOfImported > 0) Then
                    script = ""
                    If recordsImported.NumberOfImported > 0 Then
                        script &= msg & vbCrLf
                    End If
                    script &= msg3 & vbCrLf
                    script &= linesMsg
                    Return script
                Else
                    script &= "\n" & "\n" & msg3
                    script &= linesMsg
                    script &= "');"
                End If
            Else
                script &= "CloseWindow('" & msg & "','" & msg2 & "');"
            End If
            script &= "</" + "script>"
            Return script
        End Function

        Private Function ConstructLineEntry(ByVal skippedLine As BaseClasses.Utils.SkippedLine, ByVal maximumChar As Integer) As String
            Dim result As String = ""
            Try
                result &= "\n\n" & Me.GetResourceValue("Import:LineNumber", Me.AppName).Replace("{Number}", skippedLine.LineNumber.ToString)
                Dim truncatedContent As String = skippedLine.LineContent.Replace("'", "\'")
                If truncatedContent.Length > maximumChar Then
                    truncatedContent = truncatedContent.Substring(0, maximumChar - 3) & ENDING
                End If
                result &= " " & truncatedContent
                If skippedLine.ErrorMessage.Trim <> "" Then
                    result &= "\n" & Me.GetResourceValue("Import:ErrorMessage", Me.AppName) & " " & skippedLine.ErrorMessage
                End If
            Catch
                Return ""
            End Try

            Return result
        End Function
        Private Function ConstructLineEntryForTextFile(ByVal skippedLine As BaseClasses.Utils.SkippedLine, ByVal maximumChar As Integer) As String
            Dim result As String = ""
            Try
                result &= Me.GetResourceValue("Import:LineNumber", Me.AppName).Replace("{Number}", skippedLine.LineNumber.ToString)
                Dim truncatedContent As String = skippedLine.LineContent.Replace("'", "\'")
                If truncatedContent.Length > maximumChar Then
                    truncatedContent = " " & truncatedContent.Substring(0, maximumChar - 3) & ENDING
                End If
                result &= " " & truncatedContent & vbCrLf
                If skippedLine.ErrorMessage.Trim <> "" Then
                    result &= "     " & Me.GetResourceValue("Import:ErrorMessage", Me.AppName) & " " & skippedLine.ErrorMessage & vbCrLf
                End If
            Catch
                Return ""
            End Try

            Return result
        End Function


        Public Sub WriteTextFileForSkippedRecords(ByVal script As String)
            Dim name As String = Me.GetResourceValue("Import:SkippedRecords", Me.AppName)
            If name.Contains(":") Then
                name.Replace(":", "")
                name.Trim()
            End If
            Dim fileName As String = name & ".txt"
            SetupResponse(Response, fileName)
            Response.ContentType = "text/plain"
            Dim Writer As StreamWriter = New StreamWriter(Response.OutputStream, System.Text.Encoding.UTF8)
            Writer.Write(script)
            Writer.Flush()
            Response.End()
        End Sub

        Public Sub SetupResponse(ByVal response As System.Web.HttpResponse, ByVal fileName As String)
            response.ClearHeaders()
            response.Clear()
            response.Cache.SetCacheability(System.Web.HttpCacheability.[Private])
            response.Cache.SetMaxAge(New TimeSpan(0))
            response.Cache.SetExpires(New DateTime(0))
            response.Cache.SetNoServerCaching()
            response.AppendHeader("Content-Disposition", ("attachment; filename=""" & (fileName & """")))
        End Sub

        ' event handler for Button with Layout
        Public Sub PreviousButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
            Try

            Catch ex As Exception
                Me.ErrorOnPage = True
                BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally

            End Try
        End Sub
        ''' <summary>
        ''' Parses CSV file and retrieves five rows and populates ASP DataTable.
        ''' </summary>
        Public Sub ParseCSVFile()
            If File.Exists(Me.FilePath) Then
                Dim bt As BaseTable = Me.GetTable
                Dim td As TableDefinition = Nothing
                If (Not (bt) Is Nothing) Then
                    td = bt.TableDefinition
                End If
                Try
                    Dim parser As Parser = parser.GetParser(Me.FilePath, GetFileType())
                    'new CsvParser(path);
                    Dim checkboxChecked As String = CType(Session("checked"), String)
                    Dim columnListAspTableRow As TableRow = New TableRow
                    Dim columnAspTableRow As TableRow = New TableRow
                    Dim importAspTableRow As TableRow = New TableRow
                    ' Add first row with header label
                    Dim columnHeaderTableCell As TableCell = New TableCell
                    Dim importHeaderTableCell As TableCell = New TableCell
                    Dim columnListHeaderTableCell As TableCell = New TableCell
                    Dim columnHeaderLabel As Label = New Label
                    columnHeaderLabel.ID = "columnLabelHeader"
                    columnHeaderLabel.Text = GetResourceValue("Import:Column", Me.AppName) 'Column

                    Dim importLabel As Label = New Label
                    importLabel.ID = "importLabelHeader"
                    importLabel.Text = GetResourceValue("Import:Import", Me.AppName) 'Import

                    Dim columnListLabel As Label = New Label
                    columnListLabel.ID = "columnListLabelHeader"
                    '"Column names list"
                    columnListLabel.Text = GetResourceValue("Import:ColumnNames", Me.AppName)
                    columnHeaderTableCell.Controls.Add(columnHeaderLabel)
                    columnAspTableRow.Cells.Add(columnHeaderTableCell)
                    importHeaderTableCell.Controls.Add(importLabel)
                    importAspTableRow.Cells.Add(importHeaderTableCell)
                    columnListHeaderTableCell.Controls.Add(columnListLabel)
                    columnListHeaderTableCell.Wrap = False
                    columnListAspTableRow.Cells.Add(columnListHeaderTableCell)
                    DisplayTable.Rows.Add(columnAspTableRow)
                    DisplayTable.Rows.Add(importAspTableRow)
                    DisplayTable.Rows.Add(columnListAspTableRow)
                    Dim rowIndex As Integer = 0
                    Dim i As Integer = 0

                    ' Read 5 rows from csv file and display them in a Data Table.

                    While (rowIndex < 5)
                        Dim collValues() As String = parser.GetNextRow()
                        If collValues Is Nothing Then
                            parser.Close()
                            Return
                        End If
                        If collValues(0) Is Nothing Then
                            Continue While
                        End If
                        'Create column names dropdownList, import checkbox and Columns header
                        If (rowIndex = 0) Then

                            For Each value As String In collValues
                                Dim aspTableCell As TableCell = New TableCell
                                Dim x As DropDownList = New DropDownList
                                x.ID = ("dropDownList" & i)
                                x.CssClass = "fili"
                                x.Items.Add("")
                                'this.ColumnsList.Items.Add(DDLIST_TEXT);
                                'Adding column names to drop down list which are retrieved from database
                                For Each column As BaseColumn In td.Columns
                                    Dim item As New ListItem()
                                    item.Text = column.Name
                                    item.Value = column.InternalName
                                    x.Items.Add(item)
                                Next
                                aspTableCell.Controls.Add(x)
                                columnListAspTableRow.Cells.Add(aspTableCell)
                                Dim columnTableCell As TableCell = New TableCell
                                Dim importTableCell As TableCell = New TableCell
                                Dim columnLabel As Label = New Label
                                columnLabel.ID = ("columnLabel" & i)
                                columnLabel.Text = (i + 1).ToString
                                Dim importChkBox As CheckBox = New CheckBox
                                importChkBox.ID = ("importChkBox" & i)
                                ' center align the check boxes and column numbers
                                importTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center
                                columnTableCell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center
                                columnTableCell.Controls.Add(columnLabel)
                                columnAspTableRow.Cells.Add(columnTableCell)
                                importTableCell.Controls.Add(importChkBox)
                                importAspTableRow.Cells.Add(importTableCell)
                                If ((Not (value) Is Nothing) _
                                            AndAlso (Not (x.Items.FindByText(value)) Is Nothing)) Then
                                    x.Items.FindByText(value).Selected = True
                                    importChkBox.Checked = True
                                End If
                                i = (i + 1)
                            Next
                        End If
                        ' reads through temp table and creates table cell and rows out of it and adds it to Display table
                        Dim aspTableRow As TableRow = New TableRow
                        ' let the first cell contains row number.
                        Dim firstTableCell As TableCell = New TableCell
                        firstTableCell.Text = (rowIndex + 1).ToString
                        aspTableRow.Cells.Add(firstTableCell)
                        For Each value As String In collValues
                            Dim aspTableCell As TableCell = New TableCell
                            If (value.Length > 100) Then
                                aspTableCell.Text = HttpUtility.HtmlEncode(value.Substring(0, 100) & "...")
                            Else
                                aspTableCell.Text = HttpUtility.HtmlEncode(value)
                            End If
                            aspTableRow.Cells.Add(aspTableCell)
                        Next
                        DisplayTable.Rows.Add(aspTableRow)
                        rowIndex = (rowIndex + 1)

                    End While
                    parser.Close()
                Catch ex As Exception
                    MiscUtils.RegisterJScriptAlert(Me, "Import_Error_Message", ex.Message)
                    Me.ImportButton.Button.Enabled = False
                End Try
            Else
                BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", "file not found")
            End If
        End Sub

        ''' <summary>
        ''' Perform validation on selected columns
        ''' </summary>
        ''' <param name="ddListSelected"></param>
        ''' <param name="chkBoxList"></param>
        ''' <param name="bTable"></param>
        ''' <returns></returns>
        Public Function validateColumns(ByVal ddListSelected As ArrayList, ByVal chkBoxList As ArrayList, ByVal bTable As BaseTable) As Boolean
            Dim j As Integer = 0

            While (j < ddListSelected.Count)
                If ((ddListSelected(j).ToString <> "") _
                            AndAlso CType(chkBoxList(j), CheckBox).Checked) Then
                    Dim currentColumn As BaseColumn = bTable.TableDefinition.ColumnList.GetByAnyName(CType(ddListSelected(j), String))
                    'Dim fkColumn As ForeignKey = bTable.TableDefinition.GetForeignKeyByColumnName(currentColumn.InternalName)
                    '' Check if the foreign key has DFKA. If so, then check the value from csv file against the DFKA column in the parent/foreign key table.
                    '' If a match is found retrieve its ID and set that as value to be inserted in the current table where you are adding records.
                    'If ((Not (fkColumn) Is Nothing) _
                    '            AndAlso fkColumn.IsCompositeKey) Then
                    '    Throw New Exception(Me.GetResourceValue("Import:CompositeColumn", Me.AppName))
                    '    Return False
                    'End If
                    'If currentColumn.IsPrimaryKeyElement Then
                    '    MiscUtils.RegisterJScriptAlert(Me, "Import_Error_Message", Me.GetResourceValue("Import:PrimaryKey", Me.AppName).Replace("{ColumnName}", currentColumn.Name))
                    '    Return False
                    'End If
                    If currentColumn.IsValuesComputed Then
                        MiscUtils.RegisterJScriptAlert(Me, "Import_Error_Message", Me.GetResourceValue("Import:ReadOnly", Me.AppName).Replace("{ColumnName}", currentColumn.Name))
                        Return False
                    End If

                End If
                j = (j + 1)

            End While
            Return True
        End Function

        Public Function GetFileType() As Parser.FileTypes
            Dim type As String = String.Empty
            If Session("FileType") IsNot Nothing Then
                If Session("FileType").ToString() <> "" Then
                    type = Session("FileType").ToString()
                    Select Case type
                        Case "CSV"
                            Return Parser.FileTypes.CSV
                        Case "TAB"
                            Return Parser.FileTypes.TAB
                        Case "XLS"
                            Return Parser.FileTypes.XLS
                        Case "XLSX"
                            Return Parser.FileTypes.XLSX
                        Case "MDB"
                            Me.ImportFirstRowCheckBox.Checked = False
                            Me.ImportFirstRowCheckBox.Enabled = False
                            Return Parser.FileTypes.MDB
                        Case "ACCDB"
                            Me.ImportFirstRowCheckBox.Checked = False
                            Me.ImportFirstRowCheckBox.Enabled = False
                            Return Parser.FileTypes.ACCDB
                    End Select
                End If
            End If
            Return Parser.FileTypes.CSV

        End Function

        Protected Overrides Sub UpdateSessionNavigationHistory()
            'Do Nothing
        End Sub
#End Region
    End Class
End Namespace

