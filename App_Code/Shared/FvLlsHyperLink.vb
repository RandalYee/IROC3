'
'
' Typical customizations that may be done in this class include
'  - adding custom event handlers
'  - overriding base class methods

Imports System.ComponentModel

Namespace IROC2

    ''' <summary>
    ''' Renders a hyperlink that displays the app's page in a popup window.
    ''' </summary>
    ''' <remarks>
    ''' Unlike a regular HyperLink, this control's NavigateUrl is ReadOnly and derived automatically at runtime.
    ''' <para>
    ''' </para>
    ''' </remarks>
    Public Class FvLlsHyperLink
        Inherits BaseClasses.Web.UI.WebControls.PopupWindowHyperLink

        Public Sub New()
            MyBase.New()
            Me.WindowFeatures = "width=600, height=400, resizable, scrollbars"
            Me.WindowName = "llswin"

            Me.ImageUrl = "~/Images/LargeListSelector.gif"
            'Me.Style.Add("vertical-align", "middle")
            Me.CssClass = "llslink"
            Me.ToolTip = "More"
        End Sub

        'Shadow the NavigateUrl Property to return a runtime-derived url and to make it ReadOnly.
        <Editor("System.Web.UI.Design.UrlEditor, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.Drawing.Design.UITypeEditor)), _
        Category("Navigation"), _
        DefaultValue(""), _
        Description("HyperLink_NavigateUrl"), _
        Bindable(False)> _
        Public Shadows ReadOnly Property NavigateUrl() As String
            Get
                Return Me.DeriveNavigateUrl()
            End Get
            'Set(ByVal value As String)
            '    ViewState("NavigateUrl") = value
            'End Set
        End Property

        Private _ControlToUpdate As String = ""
        <Bindable(True), Category("Behavior"), DefaultValue("")> Public Property ControlToUpdate() As String
            Get
                Return Me._ControlToUpdate
            End Get
            Set(ByVal value As String)
                Me._ControlToUpdate = value
            End Set
        End Property

        Private _MinListItems As Integer = 100
        <Bindable(True), Category("Behavior"), DefaultValue("100"), _
     Description("The minimum number of items that must be in the ControlToUpdate for this control to be visible.")> _
     Public Property MinListItems() As Integer
            Get
                Return Me._MinListItems
            End Get
            Set(ByVal value As Integer)
                If (value < 0) Then
                    value = 0
                End If
                Me._MinListItems = value
            End Set
        End Property

        Private _Table As String = ""
        <Bindable(True), Category("Behavior"), DefaultValue("")> Public Property Table() As String
            Get
                Return Me._Table
            End Get
            Set(ByVal value As String)
                Me._Table = value
            End Set
        End Property

        Private _Field As String = ""
        <Bindable(True), Category("Behavior"), DefaultValue("")> Public Property Field() As String
            Get
                Return Me._Field
            End Get
            Set(ByVal value As String)
                Me._Field = value
            End Set
        End Property

        Private _DisplayField As String = ""
        <Bindable(True), Category("Behavior"), DefaultValue("")> Public Property DisplayField() As String
            Get
                Return Me._DisplayField
            End Get
            Set(ByVal value As String)
                Me._DisplayField = value
            End Set
        End Property

        Private _Formula As String = ""
        <Bindable(True), Category("Behavior"), DefaultValue("")> Public Property Formula() As String
            Get
                Return Me._Formula
            End Get
            Set(ByVal value As String)
                Me._Formula = value
            End Set
        End Property


        Public Function GetControlToUpdate() As Control
            If (Len(Me.ControlToUpdate) > 0) Then
                Return Me.NamingContainer.FindControl(Me.ControlToUpdate)
            End If
            Return Nothing
        End Function

        Protected Function DeriveNavigateUrl() As String

            Dim c As Control = Me.GetControlToUpdate()

            Dim tableName As String = Me.Table
            Dim fieldName As String = Me.Field
            Dim displayFieldName As String = Me.DisplayField
            Dim formula As String = Me.Formula

            If (IsNothing(displayFieldName)) Then
                displayFieldName = fieldName
            End If

            ' encrypt all the fields
            tableName = CType(Me.Page, IROC2.UI.BaseApplicationPage).Encrypt(tableName)
            fieldName = CType(Me.Page, IROC2.UI.BaseApplicationPage).Encrypt(fieldName)
            displayFieldName = CType(Me.Page, IROC2.UI.BaseApplicationPage).Encrypt(displayFieldName)
            formula = CType(Me.Page, IROC2.UI.BaseApplicationPage).Encrypt(formula)

            Return String.Format( _
            "~/Shared/LargeListSelector.aspx?Table={0}&Field={1}&DisplayField={2}&Target={3}&Formula={4}&usnh=n", _
            HttpUtility.UrlEncode(tableName), _
            HttpUtility.UrlEncode(fieldName), _
            HttpUtility.UrlEncode(displayFieldName), _
            HttpUtility.UrlEncode(c.ClientID), _
            HttpUtility.UrlEncode(formula))
        End Function

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            If (Me.MinListItems > 0) Then
                'Make this control invisible if the ControlToUpdate is a list with < Me.MinListItems items.
                Dim c As Control = Me.GetControlToUpdate()
                If Not IsNothing(c) AndAlso Not c.Visible Then
                    Return
                End If
                If (TypeOf (c) Is System.Web.UI.WebControls.ListControl) Then
                    Dim lc As System.Web.UI.WebControls.ListControl = CType(c, System.Web.UI.WebControls.ListControl)
                    Dim listItemCount As Integer = lc.Items.Count
                    'Me.Visible = (listItemCount >= Me.MinListItems)
                    If (Not listItemCount >= Me.MinListItems) Then
                        Return 'Don't render the control
                    End If
                End If
            End If

            'Set the inherited NavigateUrl property's value to the shadow's (derived) value
            Dim baseNavUrl As String = MyBase.NavigateUrl
            MyBase.NavigateUrl = Me.NavigateUrl

            MyBase.Render(writer)

            'Un-set the inherited NavigateUrl property to the original value
            MyBase.NavigateUrl = baseNavUrl
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Me._ControlToUpdate = CStr(Me.ViewState.Item("ControlToUpdate"))
            Me._MinListItems = CInt(Me.ViewState.Item("MinListItems"))
            Me._Table = CStr(Me.ViewState.Item("Table"))
            Me._Field = CStr(Me.ViewState.Item("Field"))
            Me._DisplayField = CStr(Me.ViewState.Item("DisplayField"))
            Me._Formula = CStr(Me.ViewState.Item("Formula"))
        End Sub

        Protected Overrides Function SaveViewState() As Object
            Me.ViewState.Item("ControlToUpdate") = Me._ControlToUpdate
            Me.ViewState.Item("MinListItems") = Me._MinListItems
            Me.ViewState.Item("Table") = Me._Table
            Me.ViewState.Item("Field") = Me._Field
            Me.ViewState.Item("DisplayField") = Me._DisplayField
            Me.ViewState.Item("Formula") = Me._Formula
            Return MyBase.SaveViewState()
        End Function

    End Class

End Namespace


