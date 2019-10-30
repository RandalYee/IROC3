Imports AjaxControlToolkit.HTMLEditor
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel

'This class is used by Edit Table pages 

Namespace IROC2.UI

    Public Class CustomEditor
        Inherits Editor

        Dim fontName As New AjaxControlToolkit.HTMLEditor.ToolbarButton.FontName()
        Dim fontSize As New AjaxControlToolkit.HTMLEditor.ToolbarButton.FontSize()

        ''' <summary>
        ''' Disables the tabbing for the FontName and FontSize dropdown list
        ''' When user tabs from other control to the editor, it should ignore FontName and FontSize dropdown list
        ''' and takes the cursor directly inside the editor textbox 
        ''' </summary>
        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            MyBase.OnPreRender(e)
            fontName.IgnoreTab = True
            fontSize.IgnoreTab = True
        End Sub

        ''' <summary>
        ''' This method is responsible for adding buttons on the TopToolbar of the editor
        ''' Remove or Add the buttons provided by AjaxControlToolkit
        ''' </summary>
        Protected Overrides Sub FillTopToolbar()

            Dim options As Collection(Of AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption)
            Dim [option] As AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Undo())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Redo())

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Bold())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Italic())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Underline())

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.FixedBackColor())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.BackColorSelector())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.FixedForeColor())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.ForeColorSelector())

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.OrderedList())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.BulletedList())

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyCenter())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyFull())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyLeft())
            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyRight())

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(fontName)

            options = fontName.Options
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "arial,helvetica,sans-serif"
            [option].Text = "Arial"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "courier new,courier,monospace"
            [option].Text = "Courier New"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "georgia,times new roman,times,serif"
            [option].Text = "Georgia"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "tahoma,arial,helvetica,sans-serif"
            [option].Text = "Tahoma"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "times new roman,times,serif"
            [option].Text = "Times New Roman"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "verdana,arial,helvetica,sans-serif"
            [option].Text = "Verdana"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "impact"
            [option].Text = "Impact"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "wingdings"
            [option].Text = "WingDings"
            options.Add([option])

            TopToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator())
            TopToolbar.Buttons.Add(fontSize)

            options = fontSize.Options
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "8pt"
            [option].Text = "1 ( 8 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "10pt"
            [option].Text = "2 (10 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "12pt"
            [option].Text = "3 (12 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "14pt"
            [option].Text = "4 (14 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "18pt"
            [option].Text = "5 (18 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "24pt"
            [option].Text = "6 (24 pt)"
            options.Add([option])
            [option] = New AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption()
            [option].Value = "36pt"
            [option].Text = "7 (36 pt)"
            options.Add([option])
        End Sub

        ''' <summary>
        ''' This method is responsible for adding buttons on the BottomToolbar of the editor
        ''' Remove or Add the buttons provided by AjaxControlToolkit
        ''' </summary>
        Protected Overrides Sub FillBottomToolbar()
            BottomToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.DesignMode())
            BottomToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.PreviewMode())
            BottomToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HtmlMode())
        End Sub

    End Class

End Namespace
