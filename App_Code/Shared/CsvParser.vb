    Imports System
    Imports System.Data
    Imports System.Configuration
    Imports System.ComponentModel
    Imports System.Web
    Imports System.Web.Security
    Imports System.Web.UI
    Imports System.Web.UI.WebControls
    Imports System.Web.UI.WebControls.WebParts
    Imports System.Web.UI.HtmlControls
    Imports System.Text
    Imports System.IO
    Imports System.Collections
    
    
Namespace IROC2.UI
    ''' <summary>
    ''' Summary description for CsvParser: Parses CSV file and returns one row at a time.
    ''' Since the code is the same for CSV or TAB, this class is used for parsing both types of files.
    ''' </summary>
    Public Class CsvParser
        Inherits Parser
        
        Private sr As StreamReader = Nothing
        
        Private csvStrm As CsvStream = Nothing
        
        Private fileName As String = Nothing

        Private separator As Char = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ListSeparator(0)
        
        Public Sub New(ByVal fName As String)
            MyBase.New
            '
            ' Add constructor logic here
            '
            fileName = fName
            separator = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ListSeparator(0)
            Reset()
        End Sub

        Public Sub New(ByVal fName As String, ByVal fSeparator As Char)
            MyBase.New()
            '
            ' Add constructor logic here
            '
            fileName = fName
            separator = fSeparator
            Reset()
        End Sub


        ' Resets resourses
        Public Overrides Sub Reset()
            If (Not (fileName) Is Nothing) Then
                sr = New StreamReader(fileName)
                csvStrm = New CsvStream(sr, separator)
            End If
        End Sub

        ' Gets one row at a time.
        Public Overrides Function GetNextRow() As String()
            Return csvStrm.GetNextRow
        End Function
        Public Overrides Sub Close()
            csvStrm.Close()
        End Sub

        ' CsvStream is the helper class which  parses the file.
        Private Class CsvStream
            Implements IDisposable
            
            Private stream As TextReader
            
            Private EOS As Boolean = False
            
            Private EOL As Boolean = False
            
            Private buffer() As Char = New Char((4096) - 1) {}
            
            Private pos As Integer = 0
            
            Private length As Integer = 0

            Private separator As Char = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ListSeparator(0)

            Public Sub New(ByVal s As TextReader, ByVal fSeparator As Char)
                MyBase.New()
                stream = s
                separator = fSeparator
            End Sub
            
            Public Function GetNextRow() As String()
                Dim row As ArrayList = New ArrayList
                
                While True
                    Dim item As String = GetNextItem
                    If (item Is Nothing) Then
                        If (row.Count = 0) Then
                            Return Nothing
                        Else
                            If (row(row.Count - 1).ToString = "") Then
                                row.RemoveAt((row.Count - 1))
                            End If
                            If (row.Count <> 0) Then
                                Return CType(row.ToArray(GetType(System.String)), String())
                            End If
                        End If
                    Else
                        row.Add(item)
                    End If
                End While
                Return Nothing
            End Function
            Public Sub Close()
                If stream IsNot Nothing Then
                    Me.Dispose()
                End If
            End Sub
            Public Function GetNextItem() As String
                If EOL Then
                    ' previous item was last in line, start new line
                    EOL = False
                    Return Nothing
                End If

                Dim quoted As Boolean = False
                Dim predata As Boolean = True
                Dim postdata As Boolean = False
                Dim item As New StringBuilder()

                While True
                    Dim c As Char = GetNextChar(True)
                    If EOS Then
                        If item.Length > 0 Then
                            Return item.ToString()
                        Else
                            Return Nothing
                        End If
                    End If

                    If (postdata OrElse Not quoted) AndAlso c = separator Then
                        Return item.ToString()
                        ' end of item, return
                    End If

                    If (predata OrElse postdata OrElse Not quoted) AndAlso (c = Chr(10) OrElse c = Chr(13)) Then
                        ' we are at the end of the line, eat newline characters and exit
                        EOL = True
                        If c = Chr(13) AndAlso GetNextChar(False) = Chr(10) Then
                            GetNextChar(True)
                            ' new line sequence is 0D0A
                        End If
                        Return item.ToString()
                    End If

                    If predata AndAlso c = " "c Then
                        Continue While
                        ' whitespace preceeding data, discard
                    End If

                    If predata AndAlso (c = """"c OrElse c = "'"c) Then
                        ' quoted data is starting
                        quoted = True
                        predata = False
                        Continue While
                    End If

                    If predata Then
                        ' data is starting without quotes
                        predata = False
                        item.Append(c)
                        Continue While
                    End If

                    If (c = """"c OrElse c = "'"c) AndAlso quoted Then
                        If GetNextChar(False) = """"c Then
                            item.Append(GetNextChar(True))
                        Else
                            postdata = True
                            ' double quotes within quoted string means add a quote       
                            ' end-quote reached
                        End If
                        Continue While
                    End If

                    ' all cases covered, character must be data
                    item.Append(c)
                End While
                Return Nothing
            End Function
            
            Public Function GetNextChar(ByVal eat As Boolean) As Char
                If (pos >= length) Then
                    length = stream.ReadBlock(buffer, 0, buffer.Length)
                    If (length = 0) Then
                        EOS = True
                        Return Microsoft.VisualBasic.ChrW(92)
                    End If
                    pos = 0
                End If
                If eat Then
                    pos = pos + 1
                    Return buffer(pos - 1)
                Else
                    Return buffer(pos)
                End If
            End Function
            Public Sub Dispose() Implements IDisposable.Dispose

                If stream IsNot Nothing Then
                    stream.Close()
                    stream.Dispose()
                    stream = Nothing
                End If

            End Sub
        End Class
    End Class
End Namespace

