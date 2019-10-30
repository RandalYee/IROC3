
Imports Microsoft.VisualBasic
Imports BaseClasses.Utils.DbUtils
  
Namespace IROC2.UI

  

    Public Interface IPaginationClassic

#Region "Interface Properties"
        
        ReadOnly Property CurrentPage() As System.Web.UI.WebControls.TextBox
        ReadOnly Property FirstPage() As System.Web.UI.WebControls.ImageButton
        ReadOnly Property LastPage() As System.Web.UI.WebControls.ImageButton
        ReadOnly Property NextPage() As System.Web.UI.WebControls.ImageButton
        ReadOnly Property PageSizeButton() As System.Web.UI.WebControls.LinkButton
        ReadOnly Property PreviousPage() As System.Web.UI.WebControls.ImageButton
      Property Visible() as Boolean
         

#End Region

    End Interface

  
End Namespace
  