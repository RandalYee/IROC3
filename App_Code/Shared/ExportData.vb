Imports System.IO
Imports BaseClasses.Data
Imports System.Collections
Imports System.Data.OleDb
Imports System.Data
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel

Namespace IROC2
    Public Enum ISDDataType
        ISDNotSet = 0
        ISDString = 1
        ISDNumber = 2
        ISDDateTime = 3
        ISDBoolean = 4
        ISDInteger = 5
        ISDError = 999
    End Enum


    Public Class ISDWorkbook
        Public Worksheets As New ArrayList()

        Public Properties As New ISDWorkbookProperties()


        Private Function GenerateUniquePath(ByVal filename As String, ByVal extension As String) As String
            Dim suffix As Integer = 0
            Dim fullpath As String

            Do
                suffix += 1
                fullpath = System.Web.HttpContext.Current.Server.MapPath("../Temp/" & filename & "_" & suffix & "." & extension)
            Loop While System.IO.File.Exists(fullpath)

            Return fullpath
        End Function


        Private Function GetColumnDefinitions(ByVal cols As ArrayList, ByVal headerCells As ArrayList, ByVal dataCells As ArrayList, ByVal addType As Boolean) As String
            Dim result As String = ""
            Dim i As Integer = 0

            For Each headerCell As ISDWorksheetCell In headerCells
                If Not result.Equals("") Then
                    result += ", "
                End If
                result += "[" & headerCell.Text & "]"

                If addType Then
                    Dim dataCell As ISDWorksheetCell = DirectCast(dataCells(i), ISDWorksheetCell)

                    result += " varchar(" & Convert.ToString(cols(i)) & ")"
                End If

                i += 1
            Next

            Return result
        End Function


        Private Function GetRowData(ByVal cells As ArrayList) As String
            Dim result As String = ""
            Dim value As String = ""

            For Each cell As ISDWorksheetCell In cells
                If Not result.Equals("") Then
                    result += ", "
                End If

                value = cell.Text.Replace("'", "''")

                If value.Length > 255 Then
                    value = value.Substring(0, 255)
                End If

                result += "'" & value & "'"
            Next

            Return result
        End Function


        Public Sub Save(ByVal OutputStream As System.IO.Stream, ByVal response As System.Web.HttpResponse)
            Dim filename As String = "Export_" & Guid.NewGuid().ToString()
            Dim completePathOne As String = GenerateUniquePath(filename, "xlsx")
            Dim completePathTwo As String = GenerateUniquePath(filename, "xls")
            Dim completePath As String
            Dim tableName As String

            Dim ws As ISDWorksheet = DirectCast(Me.Worksheets(0), ISDWorksheet)
            Dim ta As ISDTable = ws.Table
            tableName = ws.Name
            Dim rows As ArrayList = ta.Rows
            Dim row0 As ISDWorksheetRow = Nothing

            If rows.Count > 0 Then
                row0 = DirectCast(rows(0), ISDWorksheetRow)
            End If

            Dim row1 As ISDWorksheetRow = row0

            If rows.Count > 1 Then
                row1 = DirectCast(rows(1), ISDWorksheetRow)
            End If

            Dim cols As ArrayList = ta.Columns
            Dim colDefs As String = GetColumnDefinitions(cols, row0.Cells, row1.Cells, True)
            Dim colNames As String = GetColumnDefinitions(cols, row0.Cells, row1.Cells, False)

            completePath = completePathTwo

            Dim hssfwb As New HSSFWorkbook()

            Dim format As IDataFormat = hssfwb.CreateDataFormat()

            Dim sh As ISheet = hssfwb.CreateSheet("Sheet1")

            Dim rIndex As Integer = 0

            Dim r As IRow = sh.CreateRow(rIndex)

            Dim c As Integer = 0


            Dim styles(row0.Cells.Count) As HSSFCellStyle

            For Each hCell As ISDWorksheetCell In row0.Cells
                Dim style As HSSFCellStyle = CType(hssfwb.CreateCellStyle(), HSSFCellStyle)
                Dim ce As ICell = r.CreateCell(c)

                ce.SetCellValue(hCell.Text)

                style.WrapText = True
                styles(c) = CType(hssfwb.CreateCellStyle(), HSSFCellStyle)
                ce.CellStyle = style
                c += 1
            Next

            For rIndex = 1 To rows.Count - 1
                Dim currentRow As ISDWorksheetRow = DirectCast(rows(rIndex), ISDWorksheetRow)

                r = sh.CreateRow(rIndex)

                c = 0
                For i As Integer = 0 To currentRow.Cells.Count - 1

                    'myValue = myValue.Replace("$", "").Replace(",", "")
                    Dim ce As ICell = r.CreateCell(c)

                    Dim style As HSSFCellStyle = styles(i)
                    Dim dCell As ISDWorksheetCell = DirectCast(currentRow.Cells(i), ISDWorksheetCell)

                    Dim formatStr As String = dCell.Format
                    If dCell.Type = ISDDataType.ISDInteger OrElse _
                        dCell.Type = ISDDataType.ISDNumber Then
                        ce.SetCellType(CellType.NUMERIC)

                        If dCell.Value IsNot Nothing Then
                            ce.SetCellValue(Convert.ToDouble(dCell.Value))
                        End If

                        If GetBuildInFormat(dCell.Format) > 0 Then
                            style.DataFormat = HSSFDataFormat.GetBuiltinFormat(dCell.Format)
                        Else

                            Dim info As System.Globalization.NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
                            If dCell.Format = "" OrElse dCell.Format Is Nothing Then
                                formatStr = "##0.00"
                            ElseIf dCell.Format.Contains("C") OrElse dCell.Format.Contains("c") Then
                                formatStr = info.CurrencySymbol & "##0.00"
                            ElseIf dCell.Format.Contains("P") OrElse dCell.Format.Contains("p") Then
                                formatStr = "##0.00" & info.PercentSymbol
                            ElseIf dCell.Format.Contains(info.CurrencySymbol) OrElse dCell.Format.Contains(info.PercentSymbol) Then
                                ' use the user given display format
                            Else
                                formatStr = "##0.00"
                            End If
                            style.DataFormat = format.GetFormat(formatStr)
                        End If
                    ElseIf dCell.Type = ISDDataType.ISDDateTime Then

                        If dCell.Value IsNot Nothing Then
	                        ce.SetCellType(CellType.NUMERIC)
                            ce.SetCellValue(Convert.ToDateTime(dCell.Value))
                        End If

                        If GetBuildInFormat(dCell.Format) > 0 Then
                            style.DataFormat = HSSFDataFormat.GetBuiltinFormat(dCell.Format)
                        Else
                            Dim info As System.Globalization.DateTimeFormatInfo = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat

                            ' convert the date format understood by Excel
                            ' see http://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.71).aspx
                            Select Case dCell.Format
                                Case "d"
                                    formatStr = info.ShortDatePattern
                                Case "D"
                                    formatStr = info.LongDatePattern
                                Case "t"
                                    formatStr = info.ShortTimePattern
                                Case "T"
                                    formatStr = info.LongTimePattern
                                Case "f"
                                    formatStr = info.LongDatePattern & " " & info.ShortTimePattern
                                Case "F"
                                    formatStr = info.FullDateTimePattern
                                Case "g"
                                    formatStr = info.ShortDatePattern & " " & info.ShortTimePattern
                                Case "G"
                                    formatStr = info.ShortDatePattern & " " & info.LongTimePattern
                                Case "M", "m"
                                    formatStr = info.MonthDayPattern
                                Case "R", "r"
                                    formatStr = info.RFC1123Pattern
                                Case "s"
                                    formatStr = info.SortableDateTimePattern
                                Case "u"
                                    formatStr = info.UniversalSortableDateTimePattern
                                Case "U"
                                    formatStr = info.FullDateTimePattern
                                Case "Y", "y"
                                    formatStr = info.YearMonthPattern
                                Case Else
                                    formatStr = info.ShortDatePattern
                            End Select

                            ' some pattern above might return t but this is not recognized by Excel, so remove it
                            formatStr = formatStr.Replace("t", "")
                            style.DataFormat = format.GetFormat(formatStr)

                        End If

                    Else
                        ce.SetCellType(CellType.STRING)
                        If dCell.Value IsNot Nothing Then
                            Dim myValue As String = dCell.Text
                            If myValue.Length > 255 Then
                                myValue = myValue.Substring(0, 255)
                            End If
                            ce.SetCellValue(myValue)
                        End If

                        If GetBuildInFormat(dCell.Format) > 0 Then
                            style.DataFormat = HSSFDataFormat.GetBuiltinFormat(dCell.Format)
                        Else
                            style.DataFormat = HSSFDataFormat.GetBuiltinFormat("TEXT")
                            style.WrapText = True
                        End If

                        End If

                        ce.CellStyle = style
                        c += 1
                Next
            Next

            Dim ms As New MemoryStream()
            hssfwb.Write(ms)

            Dim NPOIDownloadFileName As String = Me.Properties.Title

            If completePath.EndsWith(".xlsx") Then
                NPOIDownloadFileName += ".xlsx"
            Else
                NPOIDownloadFileName += ".xls"
            End If

            response.ClearHeaders()
            response.Clear()
            response.Cache.SetCacheability(System.Web.HttpCacheability.[Private])
            response.Cache.SetMaxAge(New TimeSpan(0))
            response.Cache.SetExpires(New DateTime(0))
            response.Cache.SetNoServerCaching()
            response.AppendHeader("Content-Disposition", ("attachment; filename=""" & (NPOIDownloadFileName & """")))
            response.ContentType = "application/vnd.ms-excel"

            OutputStream.Write(ms.ToArray(), 0, ms.ToArray().Length)

            Return
        End Sub


        Private Function GetBuildInFormat(ByVal format As String) As Short
            If format = "" OrElse format Is Nothing Then
                Return -1
            Else
                Return HSSFDataFormat.GetBuiltinFormat(format)
            End If
        End Function

    End Class

    Public Class ISDWorkbookProperties
        Public Title As String = ""
    End Class


    Public Class ISDWorksheet
        Public Table As New ISDTable()
        Public Name As String = ""

        Public Sub New(ByVal name__1 As String)
            Name = name__1
        End Sub
    End Class

    Public Class ISDTable
        Public Rows As New ArrayList()
        Public Columns As New ArrayList()
    End Class


    Public Class ISDWorksheetRow
        Public Cells As New ArrayList()
    End Class


    Public Class ISDWorksheetCell
        Public Value As Object = ""
        Public Type As ISDDataType = ISDDataType.ISDString
        Public StyleID As String = ""
        Public Format As String = ""

        Public ReadOnly Property Text() As String
            Get
                If Value Is Nothing Then
                    Return Nothing
                End If
                Return Value.ToString()
            End Get
        End Property

        Public Sub New()
            Value = ""
            Type = ISDDataType.ISDString
            StyleID = ""
        End Sub

        Public Sub New(ByVal text__1 As Object)
            Value = text__1
            Type = ISDDataType.ISDString
            StyleID = ""
        End Sub



        Public Sub New(ByVal text__1 As Object, ByVal styleID__2 As String)
            Value = text__1
            Type = ISDDataType.ISDString
            StyleID = styleID__2
        End Sub

        Public Sub New(ByVal text__1 As Object, ByVal type__2 As ISDDataType, ByVal styleID__3 As String, ByVal format__4 As String)
            Value = text__1
            Type = type__2
            StyleID = styleID__3
            Format = format__4
        End Sub
    End Class



    ''' <summary>
    ''' Base class to export data to CSV or Excel
    ''' </summary>
    Public MustInherit Class ExportDataBaseClass
#Region "Properties"
        Protected pageSize As Integer = 5000

        Protected _headerString As [String]
        Protected Property HeaderString() As [String]
            Get
                Return _headerString
            End Get
            Set(ByVal value As [String])
                _headerString = value
            End Set
        End Property

        Protected MustOverride ReadOnly Property Title() As String
#End Region

#Region "Constructor"
        Protected Sub New()
            HeaderString = Nothing
        End Sub

        Protected Sub New(ByVal header As [String])
            HeaderString = header
        End Sub
#End Region

#Region "Public Methods"

        ' SetsResponse header and cache 
        Public Sub SetupResponse(ByVal response As System.Web.HttpResponse, ByVal fileName As String)
            response.ClearHeaders()
            response.Clear()
            response.Cache.SetCacheability(System.Web.HttpCacheability.[Private])
            response.Cache.SetMaxAge(New TimeSpan(0))
            response.Cache.SetExpires(New DateTime(0))
            response.Cache.SetNoServerCaching()
            response.AppendHeader("Content-Disposition", ("attachment; filename=""" & (fileName & """")))
        End Sub

        Public MustOverride Sub Export(ByVal response As System.Web.HttpResponse)

#End Region
    End Class

    ' The ExportToCSVBaseClass class exports to CSV file and sends the file to the response stream.
    Public MustInherit Class ExportToCSVBaseClass
        Inherits ExportDataBaseClass
#Region "Properties"

        Private _writer As StreamWriter
        Private Property Writer() As StreamWriter
            Get
                Return _writer
            End Get
            Set(ByVal value As StreamWriter)
                _writer = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Protected Sub New()
            MyBase.New()
        End Sub

        Protected Sub New(ByVal header As [String])
            MyBase.New(header)
        End Sub
#End Region

#Region "Private Methods"

        Protected Overridable Function WriteColumnHeader(ByVal exportRawValues As Boolean) As Boolean
            ' If the DisplayString is not null then, write the contents of DisplayString as column headers
            If MyBase.HeaderString IsNot Nothing AndAlso MyBase.HeaderString <> "" Then
                Writer.Write(HeaderString.Replace("""", """"""))
                Return True
            End If

            Return False
        End Function

        Protected separator As [String] = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator

        Protected Sub WriteColumnTitle(ByVal val As String)
            Writer.Write("""" & (val.Replace("""", """""") & """" & separator))
        End Sub

        Protected Friend Sub WriteColumnData(ByVal val As Object, ByVal isString As Boolean)
            If val IsNot Nothing AndAlso (isString OrElse val.ToString().Contains(separator)) Then
                Writer.Write("""" & (val.ToString().Replace("""", """""") & """"))
            Else
                Writer.Write(val)
            End If

            Writer.Write(separator)
        End Sub

        Protected Friend Sub WriteNewRow()
            Writer.WriteLine()
        End Sub
#End Region

#Region "Public Methods"

        Public Sub StartExport(ByVal response As System.Web.HttpResponse, Optional ByVal exportRawValues As Boolean = False)
            If response Is Nothing Then
                Return
            End If

            Dim fileName As String = Title & ".csv"
            SetupResponse(response, fileName)
            response.ContentType = "text/plain"

            Writer = New StreamWriter(response.OutputStream, System.Text.Encoding.UTF8)

            '  First write out the Column Headers
            Me.WriteColumnHeader(exportRawValues)

            Writer.WriteLine()
        End Sub

        Public Sub FinishExport(ByVal response As System.Web.HttpResponse)
            Writer.Flush()

            ' Need to call Response.End() so nothing will be attached to a file
            ' System.Web.HttpResponse.End() function will throw System.Threading.ThreadAbortException
            ' indicating that the current response ends prematurely - that's what we want
            response.[End]()
        End Sub
#End Region
    End Class

    ''' <summary>
    ''' The ExportToExcelBaseClass provides common functionality 
    ''' used for exports to Excel and sends the XLS file to the response stream.
    ''' </summary>
    Public MustInherit Class ExportToExcelBaseClass
        Inherits ExportDataBaseClass
#Region "Properties"

        Private _ISDexcelBook As ISDWorkbook
        Private Property ISDExcelBook() As ISDWorkbook
            Get
                Return _ISDexcelBook
            End Get
            Set(ByVal value As ISDWorkbook)
                _ISDexcelBook = value
            End Set
        End Property

        Private _ISDexcelSheet As ISDWorksheet
        Private Property ISDExcelSheet() As ISDWorksheet
            Get
                Return _ISDexcelSheet
            End Get
            Set(ByVal value As ISDWorksheet)
                _ISDexcelSheet = value
            End Set
        End Property

        Private _ISDexcelRow As ISDWorksheetRow
        Private Property ISDExcelRow() As ISDWorksheetRow
            Get
                Return _ISDexcelRow
            End Get
            Set(ByVal value As ISDWorksheetRow)
                _ISDexcelRow = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Protected Sub New()
            MyBase.HeaderString = Nothing
        End Sub

        Protected Sub New(ByVal header As [String])
            MyBase.HeaderString = header
        End Sub
#End Region

#Region "Protected Methods"

        ' Add column to excel book, creates style for that column set's format 
        ' before call to this function empty row needs to be added
        Protected Friend Sub AddColumnToExcelBook(ByVal column As Integer, ByVal caption As String, ByVal type As ISDDataType, ByVal width As Integer, ByVal format As String)
            If ISDExcelRow Is Nothing Then
                Return
            End If

            ISDExcelRow.Cells.Add(New ISDWorksheetCell(caption, "HeaderRowStyle"))
            ISDExcelSheet.Table.Columns.Add(width)
        End Sub

        ' Add cell with data to existing row
        ' column - column number to set correct format for this cell
        ' name - column name
        ' entityType - EntityType instance, that holds types definitions for this table 
        ' val - data value for this cell
        Protected Friend Sub AddCellToExcelRow(ByVal column As Integer, ByVal type As ISDDataType, ByVal val As Object, ByVal format As String)
            Dim styleName As [String] = "Style"
            'name of the format style
            If ISDExcelRow Is Nothing Then
                Return
            End If

            ISDExcelRow.Cells.Add(New ISDWorksheetCell(val, type, (styleName & column), format))
        End Sub

        Protected Friend Sub AddRowToExcelBook()
            If ISDExcelSheet Is Nothing Then
                Return
            End If

            ISDExcelRow = New ISDWorksheetRow()
            ISDExcelSheet.Table.Rows.Add(ISDExcelRow)
        End Sub

        ' calls SetupResponse to set header and cache and saves Excel file to HttpResponse
        Protected Friend Sub SaveExcelBook(ByVal response As System.Web.HttpResponse)
            Try
                ISDExcelBook.Save(response.OutputStream, response)
            Catch ex As Exception
                Throw ex
            End Try

            ' Need to call Response.End() so nothing will be attached to a file
            ' System.Web.HttpResponse.End() function will throw System.Threading.ThreadAbortException
            ' indicating that the current response ends prematurely - that's what we want
            response.[End]()
        End Sub

        ' Creates Excel Workbook that is used for Export to Excel request.
        Protected Friend Sub CreateExcelBook()
            ISDExcelBook = New ISDWorkbook()

            ISDExcelBook.Properties.Title = Title

            ISDExcelSheet = New ISDWorksheet("Sheet1")
            ISDExcelBook.Worksheets.Add(ISDExcelSheet)

            ISDExcelRow = New ISDWorksheetRow()
            ISDExcelSheet.Table.Rows.Add(ISDExcelRow)
        End Sub
#End Region
    End Class

    Public Class ExportDataToCSV
        Inherits ExportToCSVBaseClass
#Region "Properties"
        Private data As DataForExport = Nothing
        Public Shadows pageSize As Integer = 5000

        Protected Overrides ReadOnly Property Title() As String
            Get
                Return data.Title
            End Get
        End Property
#End Region

#Region "Constructor"
        Private Sub New()
        End Sub
        'don't use this one!
        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn())
            MyBase.New()
            data = New DataForExport(tbl, wc, orderBy, columns)
        End Sub
        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy)
            MyBase.New()
            data = New DataForExport(tbl, wc, orderBy, Nothing)
        End Sub

        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn(), ByVal header As [String])
            MyBase.New(header)
            data = New DataForExport(tbl, wc, orderBy, columns)
        End Sub

        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal header As [String])
            MyBase.New(header)
            data = New DataForExport(tbl, wc, orderBy, Nothing)
        End Sub
#End Region

#Region "Private Methods"
        Public Function GetDataForExport(ByVal col As BaseColumn, ByVal rec As BaseRecord) As String
            Dim val As [String] = ""

            If col.TableDefinition.IsExpandableNonCompositeForeignKey(col) Then
                '  Foreign Key column, so we will use DFKA and String type.
                val = rec.Format(col)
            Else
                Select Case col.ColumnType
                    Case BaseColumn.ColumnTypes.Binary, BaseColumn.ColumnTypes.Image
                        Exit Select
                    Case BaseColumn.ColumnTypes.Currency, BaseColumn.ColumnTypes.Number, BaseColumn.ColumnTypes.Percentage
                        val = rec.Format(col)
                        Exit Select
                    Case Else
                        val = rec.Format(col)
                        Exit Select
                End Select
            End If
            Return val
        End Function



        Protected Overrides Function WriteColumnHeader(ByVal exportRawValues As Boolean) As Boolean
            If MyBase.WriteColumnHeader(exportRawValues) Then
                Return True
            End If

            '  If DisplayString is null, then write out the Column's name property as the header.
            For Each col As BaseColumn In data.ColumnList
                If Not (col Is Nothing) Then
                    If data.IncludeInExport(col) Then
                        If Not exportRawValues Then
                            MyBase.WriteColumnTitle(col.Name)
                        Else
                            Dim _isExpandableNonCompositeForeignKey As Boolean = col.TableDefinition.IsExpandableNonCompositeForeignKey(col)
                            If _isExpandableNonCompositeForeignKey Then
                                Dim fkColumn As ForeignKey = data.DBTable.TableDefinition.GetExpandableNonCompositeForeignKey(col)
                                Dim name As String = fkColumn.GetPrimaryKeyColumnName(col)
                                MyBase.WriteColumnTitle(name)
                            Else
                                MyBase.WriteColumnTitle(col.Name)
                            End If
                        End If
                    End If
                End If
            Next
            Return True
        End Function

        Protected Sub WriteRows()
            Dim done As Boolean = False

            Dim totalRowsReturned As Integer = 0
            '  Read pageSize records at a time and write out the CSV file.
            While Not done
                Dim recList As ArrayList = data.GetRows(pageSize)
                If recList Is Nothing Then
                    Exit While
                End If
                'we are done
                totalRowsReturned = recList.Count
                For Each rec As BaseRecord In recList
                    For Each col As BaseColumn In data.ColumnList
                        If col Is Nothing Then
                            Continue For
                        End If

                        If Not data.IncludeInExport(col) Then
                            Continue For
                        End If

                        Dim val As [String] = GetDataForExport(col, rec)

                        MyBase.WriteColumnData(val, data.IsString(col))
                    Next
                    MyBase.WriteNewRow()
                Next

                '  If we already are below the pageSize, then we are done.
                If (totalRowsReturned < pageSize) Then
                    done = True
                End If
            End While
        End Sub

#End Region

#Region "Public Methods"
        Public Overrides Sub Export(ByVal response As System.Web.HttpResponse)
            If response Is Nothing Then
                Return
            End If

            StartExport(response)
            WriteRows()
            FinishExport(response)
        End Sub
#End Region
    End Class

    ''' <summary>
    ''' The ExportDataToExcel class exports to Excel file and sends the XLS file to the response stream.
    ''' </summary>
    Public Class ExportDataToExcel
        Inherits ExportToExcelBaseClass
#Region "Properties"
        Private data As DataForExport = Nothing
        Public Shadows pageSize As Integer = 5000

        Protected Overrides ReadOnly Property Title() As String
            Get
                Return data.Title
            End Get
        End Property

#End Region

#Region "Constructor"
        Private Sub New()
        End Sub
        'don't use this one!
        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy)
            MyBase.New()
            data = New DataForExport(tbl, wc, orderBy, Nothing)
        End Sub
#End Region

#Region "Private Methods"

        Public Function GetDisplayFormat(ByVal col As ExcelColumn) As String
            Return col.DisplayFormat
        End Function

        'return true if type can be included in export data
        Protected Friend Function GetExcelDataType(ByVal col As ExcelColumn) As ISDDataType
            If col.DisplayColumn.TableDefinition.IsExpandableNonCompositeForeignKey(col.DisplayColumn) Then
                Return ISDDataType.ISDString
            End If
            Select Case col.DisplayColumn.ColumnType
                Case BaseColumn.ColumnTypes.Number, BaseColumn.ColumnTypes.Percentage
                    Return ISDDataType.ISDNumber

                Case BaseColumn.ColumnTypes.Currency
                    Return ISDDataType.ISDNumber

                Case BaseColumn.ColumnTypes.[Date]
                    Return ISDDataType.ISDDateTime

                Case BaseColumn.ColumnTypes.Very_Large_String
                    Return ISDDataType.ISDString

                Case BaseColumn.ColumnTypes.[Boolean]
                    Return ISDDataType.ISDString
                Case Else

                    Return ISDDataType.ISDString
            End Select
        End Function

        Public Function GetExcelCellWidth(ByVal col As ExcelColumn) As Integer
            If col Is Nothing Then
                Return 0
            End If

            Dim width As Integer = 50
            If col.DisplayColumn.TableDefinition.IsExpandableNonCompositeForeignKey(col.DisplayColumn) Then
                ' Set width if field is a foreign key field
                width = 100
            Else
                Select Case col.DisplayColumn.ColumnType
                    Case BaseColumn.ColumnTypes.Binary, BaseColumn.ColumnTypes.Image
                        '  Skip - do nothing for these columns
                        width = 0
                        Exit Select
                    Case BaseColumn.ColumnTypes.Currency, BaseColumn.ColumnTypes.Number, BaseColumn.ColumnTypes.Percentage
                        width = 60
                        Exit Select
                    Case BaseColumn.ColumnTypes.[String]
                        width = 255
                        Exit Select
                    Case BaseColumn.ColumnTypes.Very_Large_String
                        width = 255
                        Exit Select
                    Case Else
                        width = 50
                        Exit Select
                End Select
            End If
            Return width
        End Function



        Protected Friend Function GetValueForExcelExport(ByVal col As ExcelColumn, ByVal rec As BaseRecord) As Object
            Dim val As Object = ""
            Dim isNull As Boolean = False
            Dim deciNumber As Decimal

            If col Is Nothing Then
                Return Nothing
            End If
            'DFKA value is evaluated in the <tablename>ExportExcelButton_Click method in the <tablename>.controls file
            'if (col.DisplayColumn.TableDefinition.IsExpandableNonCompositeForeignKey(col.DisplayColumn))
            '{
            '    //  Foreign Key column, so we will use DFKA and String type.
            '    val = rec.Format(col.DisplayColumn);
            '}
            'else
            '{
            Select Case col.DisplayColumn.ColumnType

                Case BaseColumn.ColumnTypes.Number, BaseColumn.ColumnTypes.Percentage, BaseColumn.ColumnTypes.Currency
                    Dim numVal As ColumnValue = rec.GetValue(col.DisplayColumn)

                    'If the value of the column to be exported is nothing, add an empty cell to the Excel file
                    If numVal.IsNull Then
                        isNull = True
                    Else
                        deciNumber = numVal.ToDecimal()
                        val = deciNumber
                    End If
                    Exit Select
                Case BaseColumn.ColumnTypes.[Date]
                    Dim dateVal As ColumnValue = rec.GetValue(col.DisplayColumn)
                    If dateVal.IsNull Then
                        isNull = True
                    Else
                        ' Specify the default Excel format for the date field 
                        ' val = rec.Format(col.DisplayColumn, "s");
                        ' val += ".000";
                        val = rec.GetValue(col.DisplayColumn).Value
                    End If
                    Exit Select
                Case BaseColumn.ColumnTypes.Very_Large_String
                    val = rec.GetValue(col.DisplayColumn).ToString()
                    Exit Select

                Case BaseColumn.ColumnTypes.[Boolean]
                    val = rec.Format(col.DisplayColumn)
                    Exit Select
                Case Else

                    val = rec.Format(col.DisplayColumn)
                    Exit Select
            End Select
            '}
            If isNull Then
                Return Nothing
            Else
                Return val
            End If
        End Function
#End Region

#Region "Public Methods"
        Public Sub AddColumn(ByVal col As ExcelColumn)
            data.ColumnList.Add(col)
        End Sub

        Public Overrides Sub Export(ByVal response As System.Web.HttpResponse)
            Dim done As Boolean = False
            Dim val As Object

            If response Is Nothing Then
                Return
            End If

            CreateExcelBook()

            Dim width As Integer = 0
            Dim columnCounter As Integer = 0

            '  First write out the Column Headers
            For Each col As ExcelColumn In data.ColumnList
                width = GetExcelCellWidth(col)
                If data.IncludeInExport(col) Then
                    AddColumnToExcelBook(columnCounter, col.ToString(), GetExcelDataType(col), width, GetDisplayFormat(col))
                    columnCounter += 1
                End If
            Next
            ' Read pageSize records at a time and write out the Excel file.
            Dim totalRowsReturned As Integer = 0

            While Not done
                Dim recList As ArrayList = data.GetRows(pageSize)

                If recList Is Nothing Then
                    Exit While
                End If
                totalRowsReturned = recList.Count

                For Each rec As BaseRecord In recList
                    AddRowToExcelBook()
                    columnCounter = 0
                    For Each col As ExcelColumn In data.ColumnList
                        If Not data.IncludeInExport(col) Then
                            Continue For
                        End If

                        val = GetValueForExcelExport(col, rec)
                        AddCellToExcelRow(columnCounter, GetExcelDataType(col), val, col.DisplayFormat)

                        columnCounter += 1
                    Next
                Next

                ' If we already are below the pageSize, then we are done.
                If (totalRowsReturned < pageSize) Then
                    done = True
                End If
            End While

            SaveExcelBook(response)
        End Sub
#End Region

    End Class

    ''' <summary>
    ''' The DataForExport class is a support class for Exportdata.
    ''' It encapsulate access to data needs to be exported:
    ''' data rows, title, columns.
    ''' </summary>
    Class DataForExport
        Public ColumnList As New ArrayList()

        Public _tbl As BaseTable
        Public Property DBTable() As BaseTable
            Get
                Return _tbl
            End Get
            Set(ByVal value As BaseTable)
                _tbl = value
            End Set
        End Property

        Public _wc As WhereClause
        Public Property SelectWhereClause() As WhereClause
            Get
                Return _wc
            End Get
            Set(ByVal value As WhereClause)
                _wc = value
            End Set
        End Property

        Public _orderby As OrderBy
        Public Property SelectOrderBy() As OrderBy
            Get
                Return _orderby
            End Get
            Set(ByVal value As OrderBy)
                _orderby = value
            End Set
        End Property

        Public _join As BaseFilter
        Public Property SelectJoin() As BaseFilter
            Get
                Return _join
            End Get

            Set(ByVal value As BaseFilter)
                _join = value
            End Set
        End Property

        Public ReadOnly Property Title() As String
            Get
                If DBTable.TableDefinition Is Nothing Then
                    Return "Unnamed"
                End If

                Return DBTable.TableDefinition.Name
            End Get
        End Property

        Private pageIndex As Integer = 0
        Public Function GetRows(ByVal pageSize As Integer) As ArrayList

            Dim totalRows As Integer = 0

            Dim recList As ArrayList = Nothing

            '  Read pageSize records at a time and write out the CSV file.
            If SelectWhereClause.RunQuery Then
                recList = DBTable.GetRecordList(SelectJoin, SelectWhereClause.GetFilter(), Nothing, SelectOrderBy, pageIndex, pageSize, _
                 totalRows)
                pageIndex += 1
            End If

            Return recList
        End Function


        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn())
            Me.DBTable = tbl
            Me.SelectWhereClause = wc
            Me.SelectOrderBy = orderBy
            Me.SelectJoin = Nothing
            If columns IsNot Nothing Then
                ColumnList.AddRange(columns)
            End If
        End Sub

        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn(), ByVal join As BaseFilter)
            Me.DBTable = tbl
            Me.SelectWhereClause = wc
            Me.SelectOrderBy = orderBy
            Me.SelectJoin = join
            If columns IsNot Nothing Then
                ColumnList.AddRange(columns)
            End If
        End Sub

        Public Function IsString(ByVal col As BaseColumn) As Boolean
            If col Is Nothing Then
                Return False
            End If

            Select Case col.ColumnType
                Case BaseColumn.ColumnTypes.Binary, BaseColumn.ColumnTypes.Image, BaseColumn.ColumnTypes.Currency, BaseColumn.ColumnTypes.Number, BaseColumn.ColumnTypes.Percentage
                    Return False
            End Select
            Return True
        End Function
        Public Function IsString(ByVal col As ExcelColumn) As Boolean
            If col Is Nothing Then
                Return False
            End If

            Return IsString(col.DisplayColumn)
        End Function

        Public Function IncludeInExport(ByVal col As BaseColumn) As Boolean
            If col Is Nothing Then
                Return False
            End If

            Select Case col.ColumnType
                Case BaseColumn.ColumnTypes.Binary, BaseColumn.ColumnTypes.Image
                    '  Skip - do nothing for these columns
                    Return False
            End Select
            Return True
        End Function

        Public Function IncludeInExport(ByVal col As ExcelColumn) As Boolean
            If col Is Nothing Then
                Return False
            End If

            Return IncludeInExport(col.DisplayColumn)
        End Function
    End Class
    ''' <summary>
    ''' ExcelColumn class is used to set Excel format for BaseClolumn to be used for exporting data to Excel file.
    ''' </summary>
    Public Class ExcelColumn

#Region "Constructor"
        ''' <summary>
        ''' Cretes new ExcelColumn
        ''' </summary>
        ''' <param name="col">BaseColumn</param>
        ''' <param name="format">a format string from Excel's Format Cell menu. For example "dddd, mmmm dd, yyyy h:mm AM/PM;@", "#,##0.00"</param>
        Public Sub New(ByVal col As BaseColumn, ByVal format As String)
            DisplayColumn = col
            DisplayFormat = format
        End Sub
#End Region
#Region "Properties"
        Private _column As BaseColumn
        Public Property DisplayColumn() As BaseColumn
            Get
                Return _column
            End Get
            Set(ByVal value As BaseColumn)
                _column = value
            End Set
        End Property

        Private _format As String
        Public Property DisplayFormat() As String
            Get
                Return _format
            End Get
            Set(ByVal value As String)
                _format = value
            End Set
        End Property
#End Region

#Region "Public Methods"
        Public Overrides Function ToString() As String
            Return DisplayColumn.Name
        End Function
#End Region
    End Class


    ''' <summary>
    ''' This class is redundant. It is left here for backward compatibility.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ExportData
#Region "Private members"
        Private _exportDataToCSV As ExportDataToCSV = Nothing
        Private _exportDataToExcel As ExportDataToExcel = Nothing
#End Region

#Region "Constructor"
        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn())
            _exportDataToCSV = New ExportDataToCSV(tbl, wc, orderBy, columns)
        End Sub

        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy)
            _exportDataToCSV = New ExportDataToCSV(tbl, wc, orderBy)
            _exportDataToExcel = New ExportDataToExcel(tbl, wc, orderBy)
        End Sub

        Public Sub New(ByVal tbl As BaseTable, ByVal wc As WhereClause, ByVal orderBy As OrderBy, ByVal columns As BaseColumn(), ByVal header As [String])
            _exportDataToCSV = New ExportDataToCSV(tbl, wc, orderBy, columns, header)
        End Sub
#End Region
        Public Sub AddColumn(ByVal col As ExcelColumn)
            If _exportDataToExcel IsNot Nothing Then
                _exportDataToExcel.AddColumn(col)
            End If
        End Sub
        Public Sub ExportToCSV(ByVal response As System.Web.HttpResponse)
            If _exportDataToCSV IsNot Nothing Then
                _exportDataToCSV.Export(response)
            End If
        End Sub
        Public Sub ExportToExcel(ByVal response As System.Web.HttpResponse)
            If _exportDataToExcel IsNot Nothing Then
                _exportDataToExcel.Export(response)
            End If
        End Sub
    End Class
End Namespace