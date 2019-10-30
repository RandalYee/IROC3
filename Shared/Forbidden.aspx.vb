Namespace IROC2.UI

    ' Code-behind class for the Forbidden page.
    ' Place your customizations in Section 1. Do not modify Section 2.
    Partial Public Class Forbidden
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

        Public Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            'Override call to PreInit_Base() here to change top level master page used by this page, for example uncomment
            'next line to use Microsoft SharePoint default master page
            'If Not Me.Master Is Nothing Then Me.Master.MasterPageFile = Microsoft.SharePoint.SPContext.Current.Web.MasterUrl	
            'You may change here assignment of application theme
            Me.PreInit_Base()
        End Sub
#End Region

#Region "Section 2: Do not modify this section."

        ' Handles MyBase.Load.  If you need to, you can add additional Load handlers in Section 1.
        ' Read database data and put into the UI controls.
        Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Load data only when displaying the page for the first time
            If (Not Me.IsPostBack) Then

                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()
	            System.Web.UI.ScriptManager.RegisterStartupScript(Me, Me.GetType(), "PopupScript", "openPopupPage('QPageSize');", True)

            End If

        End Sub


        ' Load data from database into UI controls. 
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()
            Me.DataBind()
        End Sub

        Protected Overrides Sub UpdateSessionNavigationHistory()
            'Do nothing
        End Sub

        Public Sub PreInit_Base()

            'If it is SharePoint application this function performs dynamic Master Page assignment.
            'If application uses multi-color theme this function performs dynamic theme assignment.
            'This is multi-color theme, so assign proper theme
            Dim selectedTheme As String = Me.GetSelectedTheme()
            If Not String.IsNullOrEmpty(selectedTheme) Then Me.Page.Theme = selectedTheme
            ' if url parameter specified a master apge, load it here
            If Me.Page.Request("MasterPage") <> "" Then
                Dim masterPage As String = DirectCast(Me.Page, BaseApplicationPage).GetDecryptedURLParameter("MasterPage")          
                Me.Page.MasterPageFile = masterPage
            Else
                Me.Page.MasterPageFile = "../Master Pages/Blank.master"
            End If
        End Sub
#End Region

    End Class

End Namespace