
Imports Microsoft.VisualBasic
Imports BaseClasses.Utils.DbUtils
  
Namespace IROC2.UI

  

    Public Interface IDatePagination

#Region "Interface Properties"
        
        ReadOnly Property Day() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property Day1() As System.Web.UI.WebControls.Literal
        ReadOnly Property Month() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property Month1() As System.Web.UI.WebControls.Literal
        ReadOnly Property NextInterval() As IThemeButton
        ReadOnly Property NextPageInterval() As IThemeButton
        ReadOnly Property PageTitle() As System.Web.UI.WebControls.Literal
        ReadOnly Property PreviousInterval() As IThemeButton
        ReadOnly Property PreviousPageInterval() As IThemeButton
        ReadOnly Property Quarter() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property Quarter1() As System.Web.UI.WebControls.Literal
        ReadOnly Property StartDate1() As System.Web.UI.WebControls.Literal
        ReadOnly Property Week() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property Week1() As System.Web.UI.WebControls.Literal
        ReadOnly Property Year() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property Year1() As System.Web.UI.WebControls.Literal
      Property Visible() as Boolean
                             
      Property Interval() As String    
      Sub ProcessPreviousPeriod()
      Sub ProcessPreviousPagePeriod(ByVal periodsShown As Integer)
      Sub ProcessNextPeriod()
      Sub ProcessNextPagePeriod(ByVal periodsShown As Integer)
      Sub SetPeriodsShown(ByVal periodsShown As Integer)
      Property FirstStartDate() As String
        

#End Region

    End Interface

  
End Namespace
  