
Imports System
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections
Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports BaseClasses.Web.UI.WebControls

Namespace IROC2.UI
    ''' <summary>
    ''' Summary description for ImportDataItems
    ''' </summary>
    Public Class ImportDataItems
        Dim NumberOfRecordImported As Long = 0
        Dim RowCount As Long = 1
        Dim ColumnCount As Integer = 1
        Private Const SEPARATOR As String = ", "
        
#Region "Properties"

        ''' <summary>
        ''' The path of the file from which data is to be retrieved for import.
        ''' </summary>
        Private _fPath As String

        Public Property FilePath() As String
            Get
                Return _fPath
            End Get
            Set(ByVal value As String)
                _fPath = value
            End Set
        End Property

        ' <summary>
        ' Type of the file to be imported
        ' </summary>
        Private _fType As Parser.FileTypes

        Public Property FileType() As Parser.FileTypes
            Get
                Return _fType
            End Get
            Set(ByVal value As Parser.FileTypes)
                _fType = value
            End Set
        End Property

        ''' <summary>
        ''' The database table to which the records from CSV file has to be imported.
        ''' </summary>
        Private _tbl As BaseTable

        Private Property DBTable() As BaseTable
            Get
                Return Me._tbl
            End Get
            Set(ByVal value As BaseTable)
                Me._tbl = value
            End Set
        End Property

        ''' <summary>
        ''' Stores the list of column names for which the data from CSV file is to be imported to database table..
        ''' </summary>
        Private _columnNameList As ArrayList

        Private Property ColumnNameList() As ArrayList
            Get
                Return Me._columnNameList
            End Get
            Set(ByVal value As ArrayList)
                Me._columnNameList = value
            End Set
        End Property

        ''' <summary>
        ''' Stores the list of checkboxes which indicate whether corresponding column should be imported or not.
        ''' </summary>
        Private _cbxList As ArrayList

        Private Property ImportList() As ArrayList
            Get
                Return Me._cbxList
            End Get
            Set(ByVal value As ArrayList)
                Me._cbxList = value
            End Set
        End Property
#End Region

#Region "Constructor"
        Public Sub New(ByVal path As String, ByVal type As Parser.FileTypes, ByVal bTable As BaseTable, ByVal ddListSelected As ArrayList, ByVal chkBoxList As ArrayList)
            MyBase.New()
            '
            ' Add constructor logic here
            '
            Me.DBTable = bTable
            Me.ColumnNameList = ddListSelected
            Me.ImportList = chkBoxList
            Me.FilePath = path
            Me.FileType = type
        End Sub

#End Region



#Region "Methods"

        Private Sub AddSkippedRecordToList(ByRef recordsList As Generic.List(Of BaseClasses.Utils.SkippedLine), _
        ByVal RowCount As Long, ByVal rowValues() As String, ByVal exMsg As String)
            If Not exMsg Is Nothing AndAlso Not exMsg.Trim = "" Then
                exMsg = exMsg.Replace("'", "\'")
            End If
            Dim skippedRecord As BaseClasses.Utils.SkippedLine = New BaseClasses.Utils.SkippedLine("", exMsg, RowCount)
            For Each rv As String In rowValues
                If Not rv Is Nothing AndAlso rv.Trim <> "" Then skippedRecord.LineContent &= rv & SEPARATOR
            Next
            If skippedRecord.LineContent.EndsWith(", ") Then
                skippedRecord.LineContent = skippedRecord.LineContent.Substring(0, skippedRecord.LineContent.Length - 2)
            End If

            recordsList.Add(skippedRecord)
        End Sub

        ''' <summary>
        ''' Reads  rows of values for CSV file and import it to Database.
        ''' </summary>
        Public Function ImportRecords(ByVal isImportFirstRowChecked As Boolean, ByVal isResolvedForeignKeysChecked As Boolean) As BaseClasses.Utils.ImportedResults
            Dim success As Boolean = False
            Dim parsr As Parser = Nothing
            Dim results As BaseClasses.Utils.ImportedResults = New BaseClasses.Utils.ImportedResults
            Try
                If ((Me.FilePath Is Nothing) _
                            OrElse ((Me.DBTable Is Nothing) _
                            OrElse ((Me.ColumnNameList Is Nothing) _
                            OrElse (Me.ImportList Is Nothing)))) Then
                    Return results
                End If
                DbUtils.StartTransaction()
                parsr = Parser.GetParser(Me.FilePath, Me.FileType)
                Dim rowValues() As String = parsr.GetNextRow
                ' get the first row
                If (Not isImportFirstRowChecked _
                            AndAlso (Not (rowValues) Is Nothing)) Then
                    Try
                        DoImport(rowValues, isResolvedForeignKeysChecked)
                        RowCount += 1

                    Catch ex As Exception
                        results.NumberOfSkipped += 1
                        Me.AddSkippedRecordToList(results.ListOfSkipped, RowCount + results.NumberOfSkipped, rowValues, ex.Message)
                    End Try


                End If

                While (Not (rowValues) Is Nothing)
                    rowValues = parsr.GetNextRow
                    If (Not (rowValues) Is Nothing) Then
                        Try
                            DoImport(rowValues, isResolvedForeignKeysChecked)
                            RowCount += 1

                        Catch ex As Exception
                            results.NumberOfSkipped += 1
                            Me.AddSkippedRecordToList(results.ListOfSkipped, RowCount + results.NumberOfSkipped, rowValues, ex.Message)
                        End Try

                    End If

                End While
                DbUtils.CommitTransaction()
                parsr.Close()

                success = True
                ' turn on success only when all the rows are imported ie, saved into database.
            Catch e As Exception
                DbUtils.RollBackTransaction()
                results.NumberOfImported = 0
                parsr.Close()
                Dim errorMsg As String = e.Message
                If File.Exists(Me.FilePath) Then
                    File.Delete(Me.FilePath)
                End If
                errorMsg = String.Format("- " & errorMsg & Environment.NewLine & "- Import error occurred at Row = {0},Column = {1}", RowCount, ColumnCount)
                Throw New Exception(errorMsg)
            Finally
                DbUtils.EndTransaction()
                If (File.Exists(Me.FilePath)) Then
                    File.Delete(Me.FilePath)
                End If
            End Try
            results.NumberOfImported = NumberOfRecordImported
            Return results
        End Function

        ''' <summary>
        ''' Creates a database record and calls UpdateColumnValuesInRecord to set the record values.
        ''' </summary>
        Private Sub DoImport(ByVal rowValues() As String, ByVal isResolvedForeignKeysChecked As Boolean)
            Dim r As IRecord
            r = Me.DBTable.CreateRecord
            If (UpdateColumnValuesInRecord(rowValues, r, isResolvedForeignKeysChecked)) Then
                r.Save()
                NumberOfRecordImported = NumberOfRecordImported + 1
            End If
        End Sub

        ''' <summary>
        ''' Sets a database record values with values retrieved from CSV file.
        ''' </summary>
        ''' <param name="rowValues"></param>
        ''' <param name="record"></param>
        Private Function UpdateColumnValuesInRecord(ByVal rowValues() As String, ByVal record As IRecord, ByVal isResolvedForeignKeysChecked As Boolean) As Boolean
            Dim j As Integer = 0
            Dim isRecordUpdated As Boolean = False
            ColumnCount = 1
            For Each data As String In rowValues
                ColumnCount = ColumnCount + 1
                If j > Me.ImportList.Count - 1 Then
                    Return isRecordUpdated
                End If
                Try


                    If ((Me.ColumnNameList(j).ToString <> "") _
                                AndAlso CType(Me.ImportList(j), CheckBox).Checked) Then
                        Dim fkColumn As ForeignKey = Nothing
                        Dim currentColumn As BaseColumn = Me.DBTable.TableDefinition.ColumnList.GetByAnyName(CType(Me.ColumnNameList(j), String))
                        If isResolvedForeignKeysChecked Then
                            fkColumn = Me.DBTable.TableDefinition.GetForeignKeyByColumnName(currentColumn.InternalName)
                        End If
                        Dim colValue As String = ""
                        ' Check if the foreign key has DFKA. If so, then check the calue from csv file agains the DFKA column in the parent/foreign key table.
                        ' If a match is found retrieve its ID and set that as value to be insterted in the current table where you are adding records.
                        If (Not (fkColumn) Is Nothing) Then
                            Dim originalTableDef As TableDefinition = fkColumn.PrimaryKeyTableDefinition
                            Dim originalBaseTable As BaseTable = originalTableDef.CreateBaseTable
                            Dim wc As WhereClause = Nothing
                            Dim records As ArrayList = New ArrayList
                            Dim pkColumn As BaseColumn = CType(originalTableDef.PrimaryKey.Columns(0), BaseColumn)
                            'Index is zero because we handle only those tables which has single PK column not composite keys.
                            If ((Not (fkColumn.PrimaryKeyDisplayColumns) Is Nothing) _
                                        AndAlso (fkColumn.PrimaryKeyDisplayColumns <> "") AndAlso (Not fkColumn.PrimaryKeyDisplayColumns.Trim().StartsWith("="))) Then
                                wc = New WhereClause(originalTableDef.ColumnList.GetByAnyName(fkColumn.PrimaryKeyDisplayColumns), BaseFilter.ComparisonOperator.EqualsTo, data)
                            ElseIf ((Not (fkColumn.PrimaryKeyDisplayColumns) Is Nothing) _
                                        AndAlso (fkColumn.PrimaryKeyDisplayColumns <> "") AndAlso (fkColumn.PrimaryKeyDisplayColumns.Trim().StartsWith("="))) Then
                                Dim primaryKeyDisplay As String = GetDFKA(fkColumn)
                                If Not IsNothing(primaryKeyDisplay) Then
                                    wc = New WhereClause(originalTableDef.ColumnList.GetByAnyName(primaryKeyDisplay), BaseFilter.ComparisonOperator.EqualsTo, data)
                                Else
                                    wc = New WhereClause(pkColumn, BaseFilter.ComparisonOperator.EqualsTo, data)
                                End If
                            Else
                                ' if the foreign key does not have DFKA then just check in the foreign key table if the id exists. If not create a record with the specified ID
                                ' before adding to current table
                                wc = New WhereClause(pkColumn, BaseFilter.ComparisonOperator.EqualsTo, data)
                            End If
                            Dim join As BaseClasses.Data.BaseFilter = Nothing
                            records = originalBaseTable.GetRecordList(join, wc.GetFilter, Nothing, Nothing, 0, 100)
                            If (records.Count > 0) Then
                                ' take the first record and retrieve its ID.
                                Dim rec As BaseRecord = CType(records(0), BaseRecord)
                                colValue = rec.GetValue(pkColumn).ToString
                            Else
                                '  IF there is not match found then you have to create a record in the foreign key table with DFKA value and then retreive its ID
                                If ((Not (data) Is Nothing) _
                                            And (data <> "")) Then
                                    Dim tempRec As IRecord
                                    If ((Not (fkColumn.PrimaryKeyDisplayColumns) Is Nothing) _
                                                AndAlso (fkColumn.PrimaryKeyDisplayColumns <> "") AndAlso (Not fkColumn.PrimaryKeyDisplayColumns.Trim().StartsWith("="))) Then
                                        tempRec = originalBaseTable.CreateRecord
                                        Dim tableDef As TableDefinition = originalBaseTable.TableDefinition
                                        For Each newCol As BaseColumn In tableDef.Columns
                                            If fkColumn.PrimaryKeyDisplayColumns = newCol.InternalName Then
                                                tempRec.SetValue(data, newCol.UniqueName)
                                            End If
                                        Next
                                    Else
                                        tempRec = originalBaseTable.CreateRecord(data)
                                    End If
                                    tempRec.Save()
                                    colValue = tempRec.GetValue(pkColumn).ToString
                                End If
                                'colValue = data
                            End If
                        Else
                            colValue = data
                        End If
                        ' set the table row's column for value
                        record.SetValue(colValue, currentColumn.UniqueName)
                        isRecordUpdated = True
                    End If
                    j = (j + 1)
                Catch ex As Exception
                    Throw New Exception(ex.InnerException.Message)
                End Try

            Next
            Return isRecordUpdated
        End Function

        Public Shared Function GetDFKA(ByVal fkColumn As ForeignKey) As String 'ByVal rec As BaseRecord,
            Dim isDFKA As Boolean = False
            If fkColumn Is Nothing Then
                Return Nothing
            End If
            Dim _DFKA As String = fkColumn.PrimaryKeyDisplayColumns

            ' if the formula is in the format of "= <Primary table>.<Field name>, then pull out the data from the rec object instead of doing formula evaluation 
            Dim tableCodeName As String = fkColumn.PrimaryKeyTableDefinition.TableCodeName
            Dim column As String = _DFKA.Trim("="c).Trim()
            If column.StartsWith(tableCodeName & ".", StringComparison.InvariantCultureIgnoreCase) Then
                column = column.Substring(tableCodeName.Length + 1)
            End If

            For Each c As BaseColumn In fkColumn.PrimaryKeyTableDefinition.Columns
                If column = c.CodeName Then
                    isDFKA = True
                    Exit For
                End If
            Next

            If isDFKA Then
                Return column
            Else
                Return Nothing
            End If
        End Function
#End Region
    End Class
End Namespace