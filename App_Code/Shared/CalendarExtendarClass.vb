Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports AjaxControlToolkit

Namespace IROC2
    ''' <summary> 
    ''' Summary description for CalendarExtendarClass 
    ''' </summary> 
    Public Class CalendarExtendarClass
        Inherits AjaxControlToolkit.CalendarExtender
        ' 
        ' Add constructor logic here 
        ' 
        Public Sub New()
        End Sub
        Protected Overloads Overrides Sub OnLoad(ByVal e As EventArgs)
            Dim textBox As TextBox = DirectCast(MyBase.TargetControl, TextBox)
            If Me.IsLanguageDefaultRTL Then
                If Not Me.Page.IsPostBack Then
                    If textBox.Text = String.Empty Then
                        DirectCast(MyBase.TargetControl, TextBox).Text = DateTime.Today.ToString(MyBase.Format)
                    End If

                End If
            End If
            MyBase.OnLoad(e)
        End Sub
        Public ReadOnly Property IsLanguageDefaultRTL() As Boolean
            Get
                If String.Compare(Me.Page.Culture, "Arabic (Saudi Arabia)", StringComparison.InvariantCulture) = 0 OrElse String.Compare(Me.Page.Culture, "Thai(Thailand)", StringComparison.InvariantCulture) = 0 OrElse String.Compare(Me.Page.Culture, "Divehi (Maldives)", StringComparison.InvariantCulture) = 0 OrElse String.Compare(Me.Page.Culture, "Persian (Iran)", StringComparison.InvariantCulture) = 0 Then

                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
    End Class
End Namespace
