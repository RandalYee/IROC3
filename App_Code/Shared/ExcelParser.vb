Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Collections


Namespace IROC2.UI
    ''' <summary> 
    ''' Summary description for ExcelParser 
    ''' </summary> 
    Public Class ExcelParser
        Inherits Parser
        Implements IDisposable
#Region "Private Member"

        Private m_fileName As String = String.Empty
        Private commandText As String = String.Empty
        Private command As OleDbCommand = Nothing
        Private m_connection As OleDbConnection = Nothing
        Private reader As OleDbDataReader = Nothing
        Private m_connectionString As String = String.Empty


#End Region

#Region "Properties"

        Public Property Connection() As OleDbConnection
            Get
                Return m_connection
            End Get
            Set(ByVal value As OleDbConnection)
                m_connection = value
            End Set
        End Property
        Public Property FileName() As String
            Get
                Return m_fileName
            End Get
            Set(ByVal value As String)
                m_fileName = value
            End Set
        End Property

        Friend ReadOnly Property ConnectionStringOne() As String
            Get
                Me.m_connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Me.fileName + ";" + "Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
                Return Me.m_connectionString
            End Get
        End Property
        Friend ReadOnly Property ConnectionStringTwo() As String

            Get
                Me.m_connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Me.fileName + ";" + "Extended Properties=""Excel 8.0;HDR=No;IMEX=1"""
                Return Me.m_connectionString
            End Get
        End Property


#End Region

        Public Sub New(ByVal file As String, ByVal sheetName As String)
            ' 
            ' Add constructor logic here 
            ' 
            Me.fileName = file
            Dim merror As Boolean = False
            Dim isConnectionOpen As Boolean = False
            Me.connection = New OleDbConnection(Me.ConnectionStringOne)
            Me.commandText = "SELECT * FROM [" + sheetName + "$]"
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
            If Me.m_connection.State <> ConnectionState.Closed Then

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
            Me.m_connection.Close()
            Me.m_connection = Nothing

        End Sub
#End Region

#Region "IDisposable Members"

        Private Sub Dispose() Implements IDisposable.Dispose
            'throw new NotImplementedException(); 
            If Me.reader IsNot Nothing Then
                Me.reader.Close()
                Me.reader.Dispose()
            End If
            If Me.m_connection IsNot Nothing Then
                Me.m_connection.Close()
                Me.m_connection.Dispose()
            End If

        End Sub

#End Region
    End Class
End Namespace
