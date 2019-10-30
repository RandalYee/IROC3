
#Region "Imports statements"	  
Option Strict On
Imports System
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports BaseClasses.Web.UI.WebControls
        
Imports IROC2.Business
Imports IROC2.Data
        
#End Region	  
  
Namespace IROC2.UI

  ' Code-behind class for the DatePagination user control.
Partial Public Class DatePagination
        Inherits BaseApplicationUserControl
        Implements IDatePagination
#Region "Section 1: Place your customizations here."
     
      Public Sub LoadData()
          ' LoadData reads database data and assigns it to UI controls.
          ' Customize by adding code before or after the call to LoadData_Base()
          ' or replace the call to LoadData_Base().
          LoadData_Base()
                  
      End Sub
      
      Private Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS as Boolean) As String
          Return EvaluateFormula_Base(formula, dataSourceForEvaluate, format, variables, includeDS)
      End Function

      Public Sub Page_InitializeEventHandlers(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ' Handles MyBase.Init. 
            ' Register the Event handler for any Events.
           Me.Page_InitializeEventHandlers_Base(sender,e)
      End Sub
      
        Protected Overrides Sub SaveControlsToSession()
            SaveControlsToSession_Base()
        End Sub


        Protected Overrides Sub ClearControlsFromSession()
            ClearControlsFromSession_Base()
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            LoadViewState_Base(savedState)
        End Sub


        Protected Overrides Function SaveViewState() As Object
            Return SaveViewState_Base()
        End Function
      
      Public Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
          Me.Page_PreRender_Base(sender,e)
      End Sub


      

      Public Overrides Sub SetChartControl(ByVal chartCtrlName As String)
          Me.SetChartControl_Base(chartCtrlName)
      End Sub    
      
      
#Region "Ajax Functions"

        <Services.WebMethod()> _
        Public Shared Function GetRecordFieldValue(ByVal tableName As String, _
                                                  ByVal recordID As String, _
                                                  ByVal columnName As String, _
                                                  ByVal fieldName As String, _
                                                  ByVal title As String, _
                                                  ByVal closeBtnText As String, _
                                                  ByVal persist As Boolean, _
                                                  ByVal popupWindowHeight As Integer, _
                                                  ByVal popupWindowWidth As Integer, _
                                                  ByVal popupWindowScrollBar As Boolean _
                                                  ) As Object()
            ' GetRecordFieldValue gets the pop up window content from the column specified by
            ' columnName in the record specified by the recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetRecordFieldValue_Base()
            ' or replace the call to  GetRecordFieldValue_Base().
            Return GetRecordFieldValue_Base(tableName, recordID, columnName, fieldName, title, closeBtnText, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function

        <Services.WebMethod()> _
        Public Shared Function GetImage(ByVal tableName As String, _
                                        ByVal recordID As String, _
                                        ByVal columnName As String, _
                                        ByVal title As String, _
                                        ByVal closeBtnText As String, _
                                        ByVal persist As Boolean, _
                                        ByVal popupWindowHeight As Integer, _
                                        ByVal popupWindowWidth As Integer, _
                                        ByVal popupWindowScrollBar As Boolean _
                                        ) As Object()
            ' GetImage gets the Image url for the image in the column "columnName" and
            ' in the record specified by recordID in data base table specified by tableName.
            ' Customize by adding code before or after the call to  GetImage_Base()
            ' or replace the call to  GetImage_Base().
            Return GetImage_Base(tableName, recordID, columnName, title, closeBtnText, persist, popupWindowHeight, popupWindowWidth, popupWindowScrollBar)
        End Function
    
      Protected Overloads Overrides Sub BasePage_PreRender(ByVal sender As Object, ByVal e As EventArgs)
          MyBase.BasePage_PreRender(sender, e)
          Base_RegisterPostback()
      End Sub
      
    
      


#End Region

    ' Page Event Handlers - buttons, sort, links
    
        Public Sub NextInterval_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for NextInterval.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          NextInterval_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub NextPageInterval_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for NextPageInterval.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          NextPageInterval_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub PreviousInterval_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for PreviousInterval.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          PreviousInterval_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            
        Public Sub PreviousPageInterval_Click(ByVal sender As Object, ByVal args As EventArgs)
          ' Click handler for PreviousPageInterval.
          ' Customize by adding code before the call or replace the call to the Base function with your own code.
          PreviousPageInterval_Click_Base(sender, args)
          ' NOTE: If the Base function redirects to another page, any code here will not be executed.
        End Sub
            

        ' Write out the Set methods
        
        
        ' Write out the methods for DataSource
        

#End Region

#Region "Section 2: Do not modify this section."

        

        Private Sub SetPeriodsShown_Base(ByVal periodsShown As Integer)
            
            Me.PreviousPageInterval.Button.Text = "-" & periodsShown
            Me.PreviousPageInterval.Button.ToolTip = "-" & periodsShown
            
            Me.NextPageInterval.Button.Text = "+" & periodsShown
            Me.NextPageInterval.Button.ToolTip = "+" & periodsShown
            
        End Sub

        Private Property Interval_Base() As String
            
            Get
                
                If Me.Year1.Visible Then Return "Year"
                
                If Me.Quarter1.Visible Then Return "Quarter"
                
                If Me.Month1.Visible Then Return "Month"
                
                If Me.Week1.Visible Then Return "Week"
                
                If Me.Day1.Visible Then Return "Day"
                
                Return ""
            End Get
            Set(ByVal value As String)
                'set the selected interval link button to be invisible.
                'set the corresponded interval literal control to be visible.
                'for the rest of the interval, set the corresponded link button to be visible, and literal to be invisible.
                
                  Me.Day.Visible  = True
                  Me.Day1.Visible = False
                
                  Me.Week.Visible  = True
                  Me.Week1.Visible = False
                
                  Me.Month.Visible  = True
                  Me.Month1.Visible = False
                
                  Me.Quarter.Visible  = True
                  Me.Quarter1.Visible = False
                
                  Me.Year.Visible  = True
                  Me.Year1.Visible = False
                
                Select Case value
                    Case "Year"
                                    
                        Me.Year.Visible  = False
                        Me.Year1.Visible = True
                
                    Case "Quarter"
                
                        Me.Quarter.Visible  = False
                        Me.Quarter1.Visible = True
                
                    Case "Month"
                
                        Me.Month.Visible  = False
                        Me.Month1.Visible = True
                
                    Case "Week"
                
                        Me.Week.Visible  = False
                        Me.Week1.Visible = True
                
                    Case "Day"
                
                        Me.Day.Visible  = False
                        Me.Day1.Visible = True
                
                End Select
            End Set              
            
        End Property
        
        Private Sub ProcessNextPeriod_Base()
            If FirstStartDate = "" Then
                Return
            End If        
            Select Case Interval
                Case "Year"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddYears(1).ToShortDateString()
                Case "Quarter"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(3).ToShortDateString()
                Case "Month"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(1).ToShortDateString()
                Case "Week"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(7).ToShortDateString()
                Case "Day"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(1).ToShortDateString()
            End Select
            
        End Sub
        
        Private Sub ProcessNextPagePeriod_Base(ByVal periodsShown As Integer)
            If FirstStartDate = "" Then
                Return
            End If        
            Select Case Interval
                Case "Year"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddYears(1 * periodsShown).ToShortDateString()
                Case "Quarter"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(3 * periodsShown).ToShortDateString()
                Case "Month"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(1 * periodsShown).ToShortDateString()
                Case "Week"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(7 * periodsShown).ToShortDateString()
                Case "Day"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(1 * periodsShown).ToShortDateString()
            End Select        
        End Sub
        
        Private Sub ProcessPreviousPeriod_Base()
            If FirstStartDate = "" Then
                Return
            End If        
            Select Case Interval
                Case "Year"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddYears(-1).ToShortDateString()
                Case "Quarter"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(-3).ToShortDateString()
                Case "Month"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(-1).ToShortDateString()
                Case "Week"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(-7).ToShortDateString()
                Case "Day"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(-1).ToShortDateString()
            End Select      
        End Sub
        
        Private Sub ProcessPreviousPagePeriod_Base(ByVal periodsShown As Integer)
            If FirstStartDate = "" Then
                Return
            End If        
            Select Case Interval
                Case "Year"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddYears(-1 * periodsShown).ToShortDateString()
                Case "Quarter"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(-3 * periodsShown).ToShortDateString()
                Case "Month"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddMonths(-1 * periodsShown).ToShortDateString()
                Case "Week"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(-7 * periodsShown).ToShortDateString()
                Case "Day"
                    FirstStartDate = Convert.ToDateTime(FirstStartDate).AddDays(-1 * periodsShown).ToShortDateString()
            End Select        
        End Sub
        
        Private Property FirstStartDate_Base() As String
            Set(ByVal value As String)
                Me.StartDate1.Text = value
            End Set
            Get
                If Me.StartDate1.Text <> "" Then
                    Return Me.StartDate1.Text
                Else
                    Return ""
                End If
            End Get
        End Property
      
        Protected Sub Page_InitializeEventHandlers_Base(ByVal sender As Object, ByVal e As System.EventArgs)            		
                  
    
            ' the following code for accordion is necessary or the Me.{ControlName} will return Nothing
        
            ' Register the Event handler for any Events.
      

          ' Setup the pagination events.
        
            AddHandler Me.NextInterval.Button.Click, AddressOf NextInterval_Click
        
            AddHandler Me.NextPageInterval.Button.Click, AddressOf NextPageInterval_Click
        
            AddHandler Me.PreviousInterval.Button.Click, AddressOf PreviousInterval_Click
        
            AddHandler Me.PreviousPageInterval.Button.Click, AddressOf PreviousPageInterval_Click
        
          Me.ClearControlsFromSession()
    
          System.Web.HttpContext.Current.Session("isd_geo_location") = "<location><error>LOCATION_ERROR_DISABLED</error></location>"
    
        End Sub

        Private Sub Base_RegisterPostback()
        
        End Sub

    

       ' Handles MyBase.Load.  Read database data and put into the UI controls.
       ' If you need to, you can add additional Load handlers in Section 1.
       Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
    
            If (Not Me.IsPostBack) Then
            
            End If
            

            ' Load data only when displaying the page for the first time or if postback from child window
            If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location")) Then
                ' Read the data for all controls on the page.
                ' To change the behavior, override the DataBind method for the individual
                ' record or table UI controls.
                Me.LoadData()
            End If
        
        

    End Sub

    Public Shared Function GetRecordFieldValue_Base(ByVal tableName As String, _
                ByVal recordID As String, _
                ByVal columnName As String, _
                ByVal fieldName As String, _
                ByVal title As String, _
                ByVal closeBtnText As String, _
                ByVal persist As Boolean, _
                ByVal popupWindowHeight As Integer, _
                ByVal popupWindowWidth As Integer, _
                ByVal popupWindowScrollBar As Boolean _
                ) As Object()
        If Not IsNothing(recordID) Then
            recordID = System.Web.HttpUtility.UrlDecode(recordID)
        End If
        Dim content as String = BaseClasses.Utils.MiscUtils.GetFieldData(tableName, recordID, columnName)
    
        content = NetUtils.EncodeStringForHtmlDisplay(content)

        ' returnValue is an array of string values.
        ' returnValue(0) represents title of the pop up window.
        ' returnValue(1) represents the tooltip of the close button.
        ' returnValue(2) represents content of the text.
        ' returnValue(3) represents whether pop up window should be made persistant
        ' or it should close as soon as mouse moves out.
        ' returnValue(4), (5) represents pop up window height and width respectivly
        ' returnValue(6) represents whether pop up window should contain scroll bar.
        ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
        Dim returnValue(6) As Object
        returnValue(0) = title
        returnValue(1) = closeBtnText
        returnValue(2) = content
        returnValue(3) = persist
        returnValue(4) = popupWindowWidth
        returnValue(5) = popupWindowHeight
        returnValue(6) = popupWindowScrollBar
        Return returnValue
    End Function


    Public Shared Function GetImage_Base(ByVal tableName As String, _
                                    ByVal recordID As String, _
                                    ByVal columnName As String, _
                                    ByVal title As String, _
                                    ByVal closeBtnText As String, _
                                    ByVal persist As Boolean, _
                                    ByVal popupWindowHeight As Integer, _
                                    ByVal popupWindowWidth As Integer, _
                                    ByVal popupWindowScrollBar As Boolean _
                                    ) As Object()
        Dim content As String = "<IMG alt =""" & title & """ src =" & """../Shared/ExportFieldValue.aspx?Table=" & tableName & "&Field=" & columnName & "&Record=" & recordID & """/>"
        ' returnValue is an array of string values.
        ' returnValue(0) represents title of the pop up window.
        ' returnValue(1) represents the tooltip of the close button.
        ' returnValue(2) represents content ie, image url.
        ' returnValue(3) represents whether pop up window should be made persistant
        ' or it should close as soon as mouse moves out.
        ' returnValue(4), (5) represents pop up window height and width respectivly
        ' returnValue(6) represents whether pop up window should contain scroll bar.
        ' They can be modified by going to Attribute tab of the properties window of the control in aspx page.
        Dim returnValue(7) As Object
        returnValue(0) = title
        returnValue(1) = closeBtnText
        returnValue(2) = content
        returnValue(3) = persist
        returnValue(4) = popupWindowWidth
        returnValue(5) = popupWindowHeight
        returnValue(6) = popupWindowScrollBar
        Return returnValue
    End Function
        
      Public Sub SetChartControl_Base(ByVal chartCtrlName As String)
          ' Load data for each record and table UI control.
        
      End Sub          


    
    
        Protected Sub SaveControlsToSession_Base()
            MyBase.SaveControlsToSession()
        
        End Sub


        Protected Sub ClearControlsFromSession_Base()
            MyBase.ClearControlsFromSession()
        
        End Sub

        Protected Sub LoadViewState_Base(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
        
        End Sub


        Protected Function SaveViewState_Base() As Object
            
            Return MyBase.SaveViewState()
        End Function


      Public Sub Page_PreRender_Base(ByVal sender As Object, ByVal e As System.EventArgs)
     
            ' Load data for each record and table UI control.
                  
            ' Data bind for each chart UI control.
              
      End Sub  

    
        ' Load data from database into UI controls.
        ' Modify LoadData in Section 1 above to customize.  Or override DataBind() in
        ' the individual table and record controls to customize.
        Public Sub LoadData_Base()
            Try
              
                If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location"))  Then
                    ' Must start a transaction before performing database operations
                    DbUtils.StartTransaction()
                End If

              
     
                Me.DataBind()

                ' Load and bind data for each record and table UI control.
                
    
                ' Load data for chart.
                
            
                ' initialize aspx controls
                
                

            Catch ex As Exception
                ' An error has occured so display an error message.
                Utils.RegisterJScriptAlert(Me, "Page_Load_Error_Message", ex.Message)
            Finally
                If (Not Me.IsPostBack OrElse Me.Request("__EVENTTARGET") = "ChildWindowPostBack" OrElse ( Me.Request("__EVENTTARGET") = "isd_geo_location"))  Then
                    ' End database transaction
                      DbUtils.EndTransaction()
                End If
            End Try
        End Sub
        
        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)
        
        Public Overridable Function EvaluateFormula_Base(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Dim e As FormulaEvaluator = New FormulaEvaluator()

            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End If

            
            e.CallingControl = Me

            e.DataSource = dataSourceForEvaluate


            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If

            If Not String.IsNullOrEmpty(format) AndAlso (String.IsNullOrEmpty(formula) OrElse formula.IndexOf("Format(") < 0) Then
                Return FormulaUtils.Format(resultObj, format)
            Else
                Return resultObj.ToString()
            End If
        End Function      
        
        Public Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
          Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables, True)
        End Function


        Private Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
          Return EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True)
        End Function

        Public Function EvaluateFormula(ByVal formula As String, ByVal includeDS As Boolean) As String
          Return EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS)
        End Function

        Public Function EvaluateFormula(ByVal formula As String) As String
          Return EvaluateFormula(formula, Nothing, Nothing, Nothing, True)
        End Function
 
        

        ' Write out the Set methods
        

        ' Write out the DataSource properties and methods
                

        ' Write out event methods for the page events
        
        ' event handler for Button with Layout
        Public Sub NextInterval_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Ctype(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
                Ctype(Me.Page, BaseApplicationPage).ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            
        ' event handler for Button with Layout
        Public Sub NextPageInterval_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Ctype(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
                Ctype(Me.Page, BaseApplicationPage).ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            
        ' event handler for Button with Layout
        Public Sub PreviousInterval_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Ctype(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
                Ctype(Me.Page, BaseApplicationPage).ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            
        ' event handler for Button with Layout
        Public Sub PreviousPageInterval_Click_Base(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Ctype(Me.Page, BaseApplicationPage).RollBackTransaction(sender)
                Ctype(Me.Page, BaseApplicationPage).ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            

        Public Sub SetPeriodsShown(ByVal periodsShown As Integer) Implements IDatePagination.SetPeriodsShown
            SetPeriodsShown_Base(periodsShown)
        End Sub

        Public Property Interval() As String Implements IDatePagination.Interval
            Get
                Return Interval_Base
            End Get
            Set(ByVal value As String)
                Interval_Base = value
            End Set
        End Property
        
        Public Sub ProcessNextPeriod() Implements IDatePagination.ProcessNextPeriod
            ProcessNextPeriod_Base()
        End Sub
        
        Public Sub ProcessNextPagePeriod(ByVal periodsShown As Integer) Implements IDatePagination.ProcessNextPagePeriod
            ProcessNextPagePeriod_Base(periodsShown)
        End Sub
        
        Public Sub ProcessPreviousPeriod() Implements IDatePagination.ProcessPreviousPeriod
            ProcessPreviousPeriod_Base()
        End Sub
        
        Public Sub ProcessPreviousPagePeriod(ByVal periodsShown As Integer) Implements IDatePagination.ProcessPreviousPagePeriod
            ProcessPreviousPagePeriod_Base(periodsShown)
        End Sub
        
        Public Property FirstStartDate() As String Implements IDatePagination.FirstStartDate
            Set(ByVal value As String)
                FirstStartDate_Base = value
            End Set
            Get
                Return FirstStartDate_Base
            End Get
        End Property
      
        #Region "Interface Properties"
        
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Day() As System.Web.UI.WebControls.LinkButton Implements IDatePagination.Day
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Day"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Day1() As System.Web.UI.WebControls.Literal Implements IDatePagination.Day1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Day1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Month() As System.Web.UI.WebControls.LinkButton Implements IDatePagination.Month
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Month"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Month1() As System.Web.UI.WebControls.Literal Implements IDatePagination.Month1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Month1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property NextInterval() As IThemeButton Implements IDatePagination.NextInterval
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_NextInterval"), IThemeButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property NextPageInterval() As IThemeButton Implements IDatePagination.NextPageInterval
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_NextPageInterval"), IThemeButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property PageTitle() As System.Web.UI.WebControls.Literal Implements IDatePagination.PageTitle
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_PageTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property PreviousInterval() As IThemeButton Implements IDatePagination.PreviousInterval
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_PreviousInterval"), IThemeButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property PreviousPageInterval() As IThemeButton Implements IDatePagination.PreviousPageInterval
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_PreviousPageInterval"), IThemeButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Quarter() As System.Web.UI.WebControls.LinkButton Implements IDatePagination.Quarter
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Quarter"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Quarter1() As System.Web.UI.WebControls.Literal Implements IDatePagination.Quarter1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Quarter1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property StartDate1() As System.Web.UI.WebControls.Literal Implements IDatePagination.StartDate1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_StartDate1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Week() As System.Web.UI.WebControls.LinkButton Implements IDatePagination.Week
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Week"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Week1() As System.Web.UI.WebControls.Literal Implements IDatePagination.Week1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Week1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Year() As System.Web.UI.WebControls.LinkButton Implements IDatePagination.Year
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Year"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
                
        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        NotifyParentProperty(True), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Year1() As System.Web.UI.WebControls.Literal Implements IDatePagination.Year1
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "_Year1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
                
      Public Overrides Property Visible() As Boolean Implements IDatePagination.Visible
  
          Get
              Return MyBase.Visible
          End Get
          Set(ByVal value As Boolean)
              MyBase.Visible = value
          End Set
      End Property
            
        #End Region
  
        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

            
    
#End Region

  

End Class
  
End Namespace

  