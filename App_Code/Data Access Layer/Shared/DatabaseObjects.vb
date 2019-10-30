Imports BaseClasses
Imports BaseClasses.Data
Imports System.Text.RegularExpressions


''' <summary>
''' The DatabaseObjects class contains a set of functions that provide
''' access to the database by using table or field names.  The class
''' allows conversion of names into the proper table object and
''' retrieval of values for field name.
''' </summary>
''' <remarks></remarks>
Public Class DatabaseObjects

    Private Const ASSEMBLY_NAME As String = "App_Code"
    Private Const BUSINESS_NAMESPACE As String = "IROC2.Business"


    ''' <summary>
    ''' Returns the BaseTable object for the given table name.
    ''' Determines if this is a Table, View or Query - and then
    ''' calls GetType to retrieve and return the object.
    ''' </summary>
    ''' <param name="tableName">tableName whose object is desired</param>
    ''' <returns>A BaseTable object for the given table name.</returns>
    Public Shared Function GetTableObject(ByVal tableName As String) As BaseTable
        Dim expandedTableName As String = String.Empty
        Dim TYPE_FORMAT As String = "{0}.{1}{2},{3}"

        Dim rgx As Regex = new Regex("[^a-zA-Z0-9]")
        tableName = rgx.Replace(tableName, "_")

        ' First see if it is a table.
        Try
            expandedTableName = String.Format(TYPE_FORMAT, BUSINESS_NAMESPACE, tableName, "Table", ASSEMBLY_NAME)
            Type.GetType(expandedTableName, True, True)
        Catch
            ' It was not really a table name - so reset and try again with a view or a query.
            expandedTableName = String.Empty
        End Try

        ' Check if it is a view.
        If expandedTableName = String.Empty Then
            Try
                expandedTableName = String.Format(TYPE_FORMAT, BUSINESS_NAMESPACE, tableName, "View", ASSEMBLY_NAME)
                Type.GetType(expandedTableName, True, True)
            Catch
                ' It was not really a view name - so reset and try again with a query.
                expandedTableName = String.Empty
            End Try
        End If


        ' Check if it is a query.
        If expandedTableName = String.Empty Then
            Try
                expandedTableName = String.Format(TYPE_FORMAT, BUSINESS_NAMESPACE, tableName, "Query", ASSEMBLY_NAME)
                Type.GetType(expandedTableName, True, True)
            Catch
                ' Still no luck.
                expandedTableName = String.Empty
            End Try
        End If


        If expandedTableName <> String.Empty Then
            ' OK, looks like we found an object.
            Try
                Dim t As BaseTable = BaseTable.CreateInstance(expandedTableName)
                Return t
            Catch
                ' Ignore, fall through and return Nothing
            End Try
        End If

        ' Could not find a table.
        Return Nothing
    End Function

End Class
