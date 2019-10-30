Imports System
Imports System.Data
Imports System.Collections
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports BaseClasses.Web.UI.WebControls
Imports IROC2.Business
Imports IROC2.Data
Imports IROC2.UI.Controls.LargeListSelector
Namespace IROC2.UI

    ' Code-behind class for the LargeListSelector page.
    ' Place your customizations in Section 1. Do not modify Section 2.
    Partial Public Class LargeListSelector
        Inherits BaseApplicationPage


#Region "Section 1: Place your customizations here."
        Public Sub New()
            Me.IsUpdatesSessionNavigationHistory = False
        End Sub

        ' LoadData reads database data and assigns it to UI controls.
        ' Customize by adding code before or after the call to LoadData_Base()
        ' or replace the call to LoadData_Base().
        Public Sub LoadData()
            LoadData_Base()
        End Sub

        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            Me.Page_PreInit_Base()
        End Sub
#Region "Ajax Functions"

    
    
        <Services.WebMethod()> _
        Public Shared Function GetAutoCompletionList_StartsWith(ByVal prefixText As String, ByVal count As Integer) As String()
            ' GetEmployeesSearchAreaCompletionList gets the list of suggestions from the database.
            ' prefixText is the search text typed by the user .
            ' count specifies the number of suggestions to be returned.
            ' Customize by adding code before or after the call to  GetAutoCompletionList_EmployeesSearchArea()
            ' or replace the call to GetAutoCompletionList_EmployeesSearchArea().
            Return GetAutoCompletionList_Base(prefixText, Nothing, count)
        End Function
      
    
        <Services.WebMethod()> _
        Public Shared Function GetAutoCompletionList_Contains(ByVal prefixText As String, ByVal count As Integer) As String()
            ' GetEmployeesSearchAreaCompletionList gets the list of suggestions from the database.
            ' prefixText is the search text typed by the user .
            ' count specifies the number of suggestions to be returned.
            ' Customize by adding code before or after the call to  GetAutoCompletionList_EmployeesSearchArea()
            ' or replace the call to GetAutoCompletionList_EmployeesSearchArea().
            Return GetAutoCompletionList_Base(Nothing, prefixText, count)
        End Function
        
#End Region


#End Region

#Region "Section 2: Do not modify this section."


        Protected Sub Page_PreInit_Base()
            'This is multi-color theme, so assign proper theme
            Dim selectedTheme As String = Me.GetSelectedTheme()
            If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
        End Sub

        ' Handles MyBase.Load.  If you need to, you can add additional Load handlers in Section 1.
        ' Read database data and put into the UI controls.
        Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Load data only when displaying the page for the first time
            If (Not Me.IsPostBack) Then

                ' Check if user has access to this page.  Redirects to either sign-in page 
                ' or 'no access' page if not. Does not do anything if role-based security 
                ' is not turned on, but you can override to add your own security.
                Me.Authorize(Me.GetAuthorizedRoles())

                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()
            End If
        End Sub
        
        Public Shared Function GetAutoCompletionList_Base(ByVal startsWithText As String, ByVal containsText As String, ByVal count As Integer) As String()
            ' Since this method is a shared/static method it does not maintain information about page or controls within the page.
            ' Hence we can not invoke any method associated with any controls.
            ' So, if we need to use any control in the page we need to instantiate it.
            Dim control As IROC2.UI.Controls.LargeListSelector.ItemsTable
            control = New IROC2.UI.Controls.LargeListSelector.ItemsTable
            Return control.GetAutoCompletionList(startsWithText, containsText, count)
        End Function


        ' Load data from database into UI controls. 
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()
            Try
                ' Load data only when displaying the page for the first time
                If (Not Me.IsPostBack) Then

                    ' Must start a transaction before performing database operations
                    DbUtils.StartTransaction()

                    ' Load data for each record and table UI control.
                    ' Ordering is important because child controls get 
                    ' their parent ids from their parent UI controls.

                End If

            Catch ex As Exception
                ' An error has occured so display an error message.
                Utils.RegisterJScriptAlert(Me, "Page_Load_Error_Message", ex.Message)
            Finally
                If Not Me.IsPostBack Then
                    ' End database transaction
                    DbUtils.EndTransaction()
                End If
            End Try
        End Sub

        Protected Overrides Sub UpdateSessionNavigationHistory()
            'Do nothing
        End Sub

#End Region

    End Class

End Namespace