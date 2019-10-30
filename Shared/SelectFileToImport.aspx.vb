' This file implements the code-behind class for SelectFileToImport.aspx.

#region "Imports statements"

Imports System
Imports System.Data
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports BaseClasses.Web.UI.WebControls
Imports IROC2.Business
Imports IROC2.Data

#end region

Namespace IROC2.UI
    
    
    Partial Public Class SelectFileToImport
        Inherits BaseApplicationPage
#Region "Section 1: Place your customizations here."

        Public Sub New()
            MyBase.New()
            Me.Initialize()


        End Sub

        Public ReadOnly Property TableName() As String
            Get
                Return Me.Decrypt(BaseClasses.Utils.NetUtils.GetUrlParam(Me, "TableName", True))
            End Get
        End Property
        Public ReadOnly Property AppName() As String
            Get
                Return BaseClasses.Configuration.ApplicationSettings.Current.GetAppSetting(BaseClasses.Configuration.ApplicationSettings.ConfigurationKey.ApplicationName)
            End Get
        End Property

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            Me.Page_PreInit_Base()
        End Sub

        Public Sub LoadData()
            ' LoadData reads database data and assigns it to UI controls.
            ' Customize by adding code before or after the call to LoadData_Base()
            ' or replace the call to LoadData_Base().
            LoadData_Base()

            Me.Page.Title = Me.GetResourceValue("Import:Step1", Me.AppName)
            Me.InfoLabel.Text = Me.GetResourceValue("Import:InfoText", Me.AppName)
            Me.fileInfo.Text = Me.GetResourceValue("Import:FileInfoText", Me.AppName)
            Me.rbtnCSV.Text = Me.GetResourceValue("Import:CSVText", Me.AppName) & " [" & System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ListSeparator & "]"
            Me.rbtnTAB.Text = Me.GetResourceValue("Import:TABText", Me.AppName)
            Me.rbtnExcel.Text = Me.GetResourceValue("Import:ExcelText", Me.AppName)
            Me.rbtnAccess.Text = Me.GetResourceValue("Import:AccessText", Me.AppName)
            Me.AccessPassword.Text = Me.GetResourceValue("Import:AccessPassword", Me.AppName)
            Me.AccessTableName.Text = Me.GetResourceValue("Import:AccessTable", Me.AppName)
            Me.ExcelSheetname.Text = Me.GetResourceValue("Import:ExcelSheet", Me.AppName)
            Me.AccessPasswordOptional.Text = Me.GetResourceValue("Import:AccessPasswordOptional", Me.AppName)

            Me.txtAccessPassword.Enabled = False
            Me.txtAccessTableName.Enabled = False
            Me.txtExcelSheetname.Enabled = False


        End Sub
#Region "Ajax Functions"

        <System.Web.Services.WebMethod()> _
        Public Shared Function GetRecordFieldValue(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            ' GetRecordFieldValue gets the pop up window content from the column specified by
            ' columnName in the record specified by the recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetRecordFieldValue_Base()
            ' or replace the call to  GetRecordFieldValue_Base().
            Return GetRecordFieldValue_Base(tableName, recordID, columnName, title, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        <System.Web.Services.WebMethod()> _
        Public Shared Function GetImage(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            ' GetImage gets the Image url for the image in the column "columnName" and
            ' in the record specified by recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetImage_Base()
            ' or replace the call to  GetImage_Base().
            Return GetImage_Base(tableName, recordID, columnName, title, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

#End Region
        ' Page Event Handlers - buttons, sort, links
        Public Sub NextButton_Click(ByVal sender As Object, ByVal args As EventArgs)
            NextButton_Click_Base(sender, args)
        End Sub

#End Region

#Region "Section 2: Do not modify this section."



        Private Sub Initialize()
            ' Called by the class constructor to initialize event handlers for Init and Load
            ' You can customize by modifying the constructor in Section 1.
            AddHandler Init, AddressOf Me.Page_InitializeEventHandlers
            AddHandler Load, AddressOf Me.Page_Load
        End Sub

        ' Handles base.Init. Registers event handler for any button, sort or links.
        ' You can add additional Init handlers in Section 1.
        Protected Overridable Sub Page_InitializeEventHandlers(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Register the Event handler for any Events.

            AddHandler NextButton.Button.Click, AddressOf Me.NextButton_Click

        End Sub

        Protected Sub Page_PreInit_Base()
            'If this is multi-color theme assign proper theme
            Dim selectedTheme As String = Me.GetSelectedTheme()
            If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
        End Sub

        ' Handles base.Load.  Read database data and put into the UI controls.
        ' You can add additional Load handlers in Section 1.
        Protected Overridable Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Check if user has access to this page.  Redirects to either sign-in page
            ' or 'no access' page if not. Does not do anything if role-based security
            ' is not turned on, but you can override to add your own security.
            Me.Authorize(Me.GetAuthorizedRoles)
            ' Load data only when displaying the page for the first time
            If Not Me.IsPostBack Then
                ' Setup the header text for the validation summary control.
                Me.ValidationSummary1.HeaderText = GetResourceValue("ValidationSummaryHeaderText", Me.AppName)
                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()

            End If
        End Sub

        Public Shared Function GetRecordFieldValue_Base(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            Dim content As String = NetUtils.EncodeStringForHtmlDisplay(BaseClasses.Utils.MiscUtils.GetFieldData(tableName, recordID, columnName))
            ' returnValue is an array of string values.
            ' returnValue(0) represents title of the pop up window.
            ' returnValue(1) represents content ie, image url.
            ' returnValue(2) represents whether pop up window should be made persistant
            ' or it should close as soon as mouse moves out.
            ' returnValue(3), (4) represents pop up window height and width respectivly
            ' returnValue(5) represents whether pop up window should contain scroll bar.
            ' (0),(2),(3) and (4) is initially set as pass through attribute.
            ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
            Dim returnValue() As Object = New Object((6) - 1) {}
            returnValue(0) = title
            returnValue(1) = content
            returnValue(2) = persist
            returnValue(3) = popupWindowWidth
            returnValue(4) = popupWindowHeight
            returnValue(5) = popupWindowScrollBar
            Return returnValue
        End Function

        Public Shared Function GetImage_Base(ByVal tableName As String, ByVal recordID As String, ByVal columnName As String, ByVal title As String, ByVal persist As Boolean, ByVal popupWindowHeight As Integer, ByVal popupWindowWidth As Integer, ByVal popupWindowScrollBar As Boolean) As Object()
            Dim content As String = ("<IMG alt =\""" + title + "\"" src =" + ("\""../Shared/ExportFieldValue.aspx?Table=" _
                        + (tableName + ("&Field=" _
                        + (columnName + ("&Record=" _
                        + (recordID + "\""/>")))))))
            ' returnValue is an array of string values.
            ' returnValue(0) represents title of the pop up window.
            ' returnValue(1) represents content ie, image url.
            ' returnValue(2) represents whether pop up window should be made persistant
            ' or it should close as soon as mouse moves out.
            ' returnValue(3), (4) represents pop up window height and width respectivly
            ' returnValue(5) represents whether pop up window should contain scroll bar.
            ' (0),(2),(3), (4) and (5) is initially set as pass through attribute.
            ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
            Dim returnValue() As Object = New Object((6) - 1) {}
            returnValue(0) = title
            returnValue(1) = content
            returnValue(2) = persist
            returnValue(3) = popupWindowWidth
            returnValue(4) = popupWindowHeight
            returnValue(5) = popupWindowScrollBar
            Return returnValue
        End Function

        ' Load data from database into UI controls.
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()

        End Sub

        ' event handler for Button with Layout
        Public Sub NextButton_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
            Dim inputFile As System.Web.UI.HtmlControls.HtmlInputFile
            inputFile = DirectCast((Me.Page.FindControl("InputFile")), System.Web.UI.HtmlControls.HtmlInputFile)

            Dim tmpPath As String = String.Empty


            If (Not (inputFile.PostedFile Is Nothing) AndAlso (inputFile.PostedFile.ContentLength > 0)) Then
                If ValidateFileTypeSupported(inputFile.PostedFile.FileName) Then
                    SyncLock Me
                        tmpPath = Server.MapPath("../Temp/" + Guid.NewGuid().ToString())
                    End SyncLock
                    Me.Page.Session("FilePath") = tmpPath

                    Try
                        inputFile.PostedFile.SaveAs(tmpPath)
                        ' pass the table name with encryption. 
                        Me.Page.Response.Redirect("ImportData.aspx?TableName=" + Me.Encrypt(Me.TableName))
                    Catch
                        Dim msg As String = Me.GetResourceValue("Import:FailedToSaveFile", Me.AppName)
                        BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", msg)
                    End Try
                Else

                    BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", Me.GetResourceValue("Import:FileTypeMsg", Me.AppName))
                End If
            Else
                BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", Me.GetResourceValue("Import:SelectFile", Me.AppName))
            End If
        End Sub
        Protected Sub rbtnCSV_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            'Me.pnlCSV.Enabled = True
            'Me.pnlTAB.Enabled = False
            'Me.pnlExcel.Enabled = False
            'Me.pnlAccess.Enabled = False
            Me.txtAccessPassword.Enabled = False
            Me.txtAccessTableName.Enabled = False
            Me.txtExcelSheetname.Enabled = False
        End Sub
        Protected Sub rbtnTAB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            'Me.pnlCSV.Enabled = False
            'Me.pnlTAB.Enabled = True
            'Me.pnlExcel.Enabled = False
            'Me.pnlAccess.Enabled = False
            Me.txtAccessPassword.Enabled = False
            Me.txtAccessTableName.Enabled = False
            Me.txtExcelSheetname.Enabled = False
        End Sub
        Protected Sub rbtnExcel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            'Me.pnlCSV.Enabled = False
            'Me.pnlTAB.Enabled = False
            'Me.pnlExcel.Enabled = True
            'Me.pnlAccess.Enabled = False
            Me.txtAccessPassword.Enabled = False
            Me.txtAccessTableName.Enabled = False
            Me.txtExcelSheetname.Enabled = True
            Me.txtExcelSheetname.Focus()
        End Sub
        Protected Sub rbtnAccess_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            'Me.pnlCSV.Enabled = False
            'Me.pnlTAB.Enabled = False
            'Me.pnlExcel.Enabled = False
            'Me.pnlAccess.Enabled = True
            Me.txtAccessPassword.Enabled = True
            Me.txtAccessTableName.Enabled = True
            Me.txtExcelSheetname.Enabled = False
            Me.txtAccessTableName.Focus()
        End Sub


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' To validate supported file type for Import 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[nparmar]	5/2008	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ValidateFileTypeSupported(ByVal FileName As String) As Boolean
            If (FileName Is Nothing) Then
                Return False
            End If

            Dim extension As String = BaseClasses.Utils.FileUtils.GetFileExtension(FileName).ToUpper()

            If (extension = "MDB" OrElse extension = "ACCDB") AndAlso (Me.rbtnCSV.Checked OrElse Me.rbtnTAB.Checked OrElse Me.rbtnExcel.Checked) Then
                Return False
            End If

            If (extension = "XLS" OrElse extension = "XLSX") AndAlso (Me.rbtnCSV.Checked OrElse Me.rbtnTAB.Checked OrElse Me.rbtnAccess.Checked) Then
                Return False
            End If

            If Me.rbtnCSV.Checked Then
                Session("FileType") = "CSV"
                Return True
            End If

            If Me.rbtnTAB.Checked Then
                Session("FileType") = "TAB"
                Return True
            End If

            If Me.rbtnExcel.Checked Then
                Select Case extension
                    Case "XLS"
                        Session("FileType") = "XLS"
                    Case "XLSX"
                        Session("FileType") = "XLSX"
                End Select

                If Me.txtExcelSheetname.Text <> "" Then
                    Session("SheetName") = Me.txtExcelSheetname.Text
                Else
                    Session("SheetName") = "Sheet1"
                End If

                Return True
            End If

            If Me.rbtnAccess.Checked Then
                Select Case extension
                    Case "MDB"
                        Session("FileType") = "MDB"
                    Case "ACCDB"
                        Session("FileType") = "ACCDB"
                End Select

                If Me.txtAccessTableName.Text <> "" Then
                    Session("TableName") = Me.txtAccessTableName.Text
                Else
                    Session("TableName") = "Table1"
                End If

                If Me.txtAccessPassword.Text <> "" Then
                    Session("pwd") = Me.txtAccessPassword.Text
                End If

                Return True
            End If

            Session("FileType") = ""
            Return False
        End Function
        Protected Overrides Sub UpdateSessionNavigationHistory()
            'Do Nothing
        End Sub
#End Region

    End Class
End Namespace

