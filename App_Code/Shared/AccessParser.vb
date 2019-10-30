Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace IROC2.UI
    ''' <summary> 
    ''' Summary description for AccessParser 
    ''' </summary> 
    Public Class AccessParser
        Inherits Parser
        Implements IDisposable
#Region "Private Member"

        Private fileName As String = String.Empty
        Private commandText As String = String.Empty
        Private command As OleDbCommand = Nothing
        Private connection As OleDbConnection = Nothing
        Private reader As OleDbDataReader = Nothing
        Private m_connectionString As String = String.Empty
        Private _tableName As String = String.Empty

#End Region
#Region "Properties"
        Friend ReadOnly Property ConnectionStringOne() As String

            Get
                If HttpContext.Current.Session("pwd") IsNot Nothing Then
                    Me.m_connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Me.fileName + ";" + "Jet OLEDB:Database Password=" + HttpContext.Current.Session("pwd").ToString() + ";"
                    Return Me.m_connectionString
                Else
                    Me.m_connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Me.fileName + ";" + "Persist Security Info=False;"
                    Return Me.m_connectionString
                End If
            End Get
        End Property
        Friend ReadOnly Property ConnectionStringTwo() As String
            Get
                Me.m_connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Me.fileName + ";"
                Return Me.m_connectionString
            End Get
        End Property
        Friend ReadOnly Property TableName() As String
            Get
                If Not IsValidTableName(Me._tableName) Then
                    Dim aliasName As String = Me._tableName.Replace(" ", "_") & "_"
                    Return String.Format("[{0}][{1}]", Me._tableName, aliasName)
                Else
                    Return Me._tableName
                End If
            End Get
        End Property

        Private Function IsValidTableName(ByVal tableName As String) As Boolean

            Dim specialChar As Char() = New Char() {"~"c, "-"c, "!"c, "@"c, "#"c, "$"c, "%"c, "^"c, "&"c, "*"c, "("c, ")"c, "`"c, "|"c, "\"c, ":"c, ";"c, "'"c, "<"c, ","c, ">"c, "."c, "/"c, "?"c, "["c, "]"c, "{"c, "}"c}
            If tableName.IndexOfAny(specialChar) > -1 Then
                Return False
            Else
                Return True
            End If
        End Function
#End Region


        Public Sub New(ByVal file As String, ByVal tableName As String)
            ' 
            ' Add constructor logic here 
            ' 
            Me.fileName = file
            Dim merror As Boolean = False
            Dim isConnectionOpen As Boolean = False
            Me._tableName = tableName
            Me.connection = New OleDbConnection(Me.ConnectionStringOne)
            Me.commandText = "SELECT * FROM " + Me.TableName
            Me.command = New OleDbCommand(Me.commandText, Me.connection)

            Try
                Me.connection.Open()
                isConnectionOpen = True
                Me.reader = Me.command.ExecuteReader()
            Catch ex As Exception
                If Not isConnectionOpen Then
                    Me.connection = Nothing
                    Me.command = Nothing
                    Me.connection = New OleDbConnection(Me.ConnectionStringTwo)
                    Me.command = New OleDbCommand(Me.commandText, Me.connection)
                    Try
                        Me.connection.Open()

                        Me.reader = Me.command.ExecuteReader()
                    Catch exe As Exception
                        merror = True
                        Throw New Exception(exe.Message)
                    End Try
                    If merror Then
                        If Me.connection.State = ConnectionState.Open AndAlso Me.connection IsNot Nothing Then
                            Me.connection.Close()
                        End If
                        Throw ex
                    End If
                Else
                    If Me.connection.State = ConnectionState.Open AndAlso Me.connection IsNot Nothing Then
                        Me.connection.Close()
                    End If
                    Throw ex
                End If

            End Try

        End Sub
#Region "Parser member"

        Public Overloads Overrides Sub Reset()
            ' throw new NotImplementedException(); 
        End Sub

        Public Overloads Overrides Function GetNextRow() As String()
            Dim row As New ArrayList()
            Dim columnIndex As Integer = 0
            If Me.connection.State <> ConnectionState.Closed Then

                If Me.reader.Read() Then
                    For columns As Integer = 0 To Me.reader.FieldCount - 1
                        Try
                            row.Add(Me.reader(columnIndex).ToString())
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                        columnIndex += 1
                    Next
                End If
            End If
            If row.Count <> 0 Then
                Return DirectCast(row.ToArray(GetType(String)), String())
            End If

            Return Nothing
        End Function

        Public Overloads Overrides Sub Close()
            Me.reader.Close()
            Me.reader = Nothing
            Me.connection.Close()
            Me.connection = Nothing

        End Sub
#End Region

#Region "IDisposable Members"

        Private Sub Dispose() Implements IDisposable.Dispose
            'throw new NotImplementedException(); 
            If Me.reader IsNot Nothing Then
                Me.reader.Close()
                Me.reader.Dispose()
            End If
            If Me.connection IsNot Nothing Then
                Me.connection.Close()
                Me.connection.Dispose()
            End If

        End Sub

#End Region
    End Class
End Namespace