    Imports System
    Imports System.Data
    Imports System.Configuration
    Imports System.Web
    Imports System.Web.Security
    Imports System.Web.UI
    Imports System.Web.UI.WebControls
    Imports System.Web.UI.WebControls.WebParts
    Imports System.Web.UI.HtmlControls
    Imports System.Text
    Imports System.IO
    
Namespace IROC2.UI
    
    ''' <summary>
    ''' Summary description for Parser: Parser for files like csv, excel etc.
    ''' </summary>
    Public MustInherit Class Parser

        ' The type of file. ie, extension of the file.
        Public Enum FileTypes
            CSV
            XLS
            XLSX
            MDB
            ACCDB
            TAB
        End Enum
        
        ' Constructor
        Public Sub New()
            MyBase.New
            
        End Sub

        ' Reset resources
        Public MustOverride Sub Reset()

        ' Get one record at a time
        Public MustOverride Function GetNextRow() As String()

        'Close parser and dispose parser object
        Public MustOverride Sub Close()

        ' Generic function to get instance of parser class based on file type.
        Public Shared Function GetParser(ByVal filePath As String, ByVal type As FileTypes) As Parser
            Dim parsr As Parser = Nothing
            Select Case (type)
                Case FileTypes.CSV
                    parsr = New CsvParser(filePath, System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ListSeparator(0))
                Case FileTypes.TAB
                    parsr = New CsvParser(filePath, CChar(vbTab))
                Case FileTypes.XLS
                    Try
                        parsr = New ExcelParser(filePath, HttpContext.Current.Session("SheetName").ToString())
                    Catch e As Exception
                        Throw New Exception(e.Message)
                    End Try
                Case FileTypes.XLSX
                    Try
                        parsr = New ExcelParser(filePath, HttpContext.Current.Session("SheetName").ToString())
                    Catch e As Exception
                        Throw New Exception(e.Message)
                    End Try
                Case FileTypes.MDB
                    Try
                        parsr = New AccessParser(filePath, HttpContext.Current.Session("TableName").ToString())
                    Catch e As Exception
                        Throw New Exception(e.Message)
                    End Try
                    Exit Select
                Case FileTypes.ACCDB
                    Try
                        parsr = New AccessParser(filePath, HttpContext.Current.Session("TableName").ToString())
                    Catch e As Exception
                        Throw New Exception(e.Message)
                    End Try
                    Exit Select
            End Select
            Return parsr
        End Function
        
    End Class
End Namespace

