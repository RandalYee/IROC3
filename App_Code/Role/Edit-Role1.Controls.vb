﻿
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Edit_Role1.aspx page.  The Row or RecordControl classes are the 
' ideal place to add code customizations. For example, you can override the LoadData, 
' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.

#Region "Imports statements"

Option Strict On
Imports Microsoft.VisualBasic
Imports BaseClasses.Web.UI.WebControls
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.Script.Serialization
        
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports ReportTools.ReportCreator
Imports ReportTools.Shared

  
        
Imports IROC2.Business
Imports IROC2.Data
Imports IROC2.UI
        

#End Region

  
Namespace IROC2.UI.Controls.Edit_Role1

#Region "Section 1: Place your customizations here."

    
Public Class UsersTableControlRow
        Inherits BaseUsersTableControlRow
        ' The BaseUsersTableControlRow implements code for a ROW within the
        ' the UsersTableControl table.  The BaseUsersTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of UsersTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class UsersTableControl
        Inherits BaseUsersTableControl

    ' The BaseUsersTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The UsersTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  
Public Class RoleRecordControl
        Inherits BaseRoleRecordControl
        ' The BaseRoleRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the UsersTableControlRow control on the Edit_Role1 page.
' Do not modify this class. Instead override any method in UsersTableControlRow.
Public Class BaseUsersTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in UsersTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in UsersTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
                    
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.UsersRecordRowSelection.CheckedChanged, AddressOf UsersRecordRowSelection_CheckedChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Users record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = UsersTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseUsersTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New UsersRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in UsersTableControlRow.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetEmail()
                SetIsActive()
                SetUser_Name()
                
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
      RegisterRowForHiddenVariableSelection()
    
        End Sub
        
        
        Public Overridable Sub RegisterRowForHiddenVariableSelection()
          
            Dim roleRecordControlObj As RoleRecordControl = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me.Page, "RoleRecordControl"),  IROC2.UI.Controls.Edit_Role1.RoleRecordControl)     
	          
            Dim Id As String = ""
                     
            If (Not IsNothing(roleRecordControlObj) AndAlso Not IsNothing(roleRecordControlObj.GetRecord()) AndAlso roleRecordControlObj.GetRecord().IsCreated()) Then
               Id = roleRecordControlObj.GetRecord().GetID().ToXmlString()
            End If 
                          
            Dim usersTableControlObj As UsersTableControl = DirectCast(MiscUtils.GetParentControlObject(Me, "UsersTableControl"), IROC2.UI.Controls.Edit_Role1.UsersTableControl)
            Dim addvalues As System.Web.UI.HtmlControls.HtmlInputHidden = _
            DirectCast(usersTableControlObj.FindControl("_AddValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim removeValues As System.Web.UI.HtmlControls.HtmlInputHidden = _
            DirectCast(usersTableControlObj.FindControl("_RemoveValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden)

            Me.UsersRecordRowSelection.Attributes.Item("onclick") = "AddRemoveValuesForMTM('" & Me.UsersRecordRowSelection.ClientID & "','" & addvalues.ClientID & "','" & removeValues.ClientID & "', '" & Me.RecordUniqueId & ";" & Id & "');"
            
        End Sub 
        
        Public Overridable Sub SetEmail()
            
        
            ' Set the Email Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Users database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Users record retrieved from the database.
            ' Me.Email is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetEmail()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.EmailSpecified Then
                				
                ' If the Email is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UsersTable.Email)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Email.Text = formattedValue
                
            Else 
            
                ' Email is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Email.Text = UsersTable.Email.Format(UsersTable.Email.DefaultValue)
                        		
                End If
                 
            ' If the Email is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.Email.Text Is Nothing _
                OrElse Me.Email.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.Email.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetIsActive()
            
        
            ' Set the IsActive Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Users database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Users record retrieved from the database.
            ' Me.IsActive is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIsActive()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsActiveSpecified Then
                				
                ' If the IsActive is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UsersTable.IsActive)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.IsActive.Text = formattedValue
                
            Else 
            
                ' IsActive is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IsActive.Text = UsersTable.IsActive.Format(UsersTable.IsActive.DefaultValue)
                        		
                End If
                 
            ' If the IsActive is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.IsActive.Text Is Nothing _
                OrElse Me.IsActive.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.IsActive.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUser_Name()
            
        
            ' Set the User_Name Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Users database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Users record retrieved from the database.
            ' Me.User_Name is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUser_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.User_NameSpecified Then
                				
                ' If the User_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UsersTable.User_Name)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.User_Name.Text = formattedValue
                
            Else 
            
                ' User_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.User_Name.Text = UsersTable.User_Name.Format(UsersTable.User_Name.DefaultValue)
                        		
                End If
                 
            ' If the User_Name is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.User_Name.Text Is Nothing _
                OrElse Me.User_Name.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.User_Name.Text = "&nbsp;"
            End If
                  
        End Sub
                

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

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
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in UsersTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
                DirectCast(GetParentControlObject(Me, "UsersTableControl"), UsersTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "UsersTableControl"), UsersTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in UsersTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetEmail()
            GetIsActive()
            GetUser_Name()
        End Sub
        
        
        Public Overridable Sub GetEmail()
            
        End Sub
                
        Public Overridable Sub GetIsActive()
            
        End Sub
                
        Public Overridable Sub GetUser_Name()
            
        End Sub
                
      
        ' To customize, override this method in UsersTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in UsersTableControlRow.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          UsersTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "UsersTableControl"), UsersTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "UsersTableControl"), UsersTableControl).ResetData = True
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                						
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
              Protected Overridable Sub UsersRecordRowSelection_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)
                  HttpContext.Current.Session.Add("UsersRecordRowSelectionDataChanged", "True")
              End Sub
            
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseUsersTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseUsersTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As UsersRecord
        Public Property DataSource() As UsersRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As UsersRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property Email() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Email"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property IsActive() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IsActive"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property User_Name() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "User_Name"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UsersRecordRowSelection() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersRecordRowSelection"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As UsersRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As UsersRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As UsersRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return UsersTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Throw New Exception(Page.GetResourceValue("Err:RetrieveRec", "IROC2"))
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the UsersTableControl control on the Edit_Role1 page.
' Do not modify this class. Instead override any method in UsersTableControl.
Public Class BaseUsersTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.IsActiveFilter) 				
                    initialVal = Me.GetFromSession(Me.IsActiveFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""IsActive"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Me.IsActiveFilter.Items.Add(New ListItem(initialVal, initialVal))
                            
                        Me.IsActiveFilter.SelectedValue = initialVal
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.UsersSearch) 				
                    initialVal = Me.GetFromSession(Me.UsersSearch)
                
              End If
              
                If initialVal <> ""				
                        
                        Me.UsersSearch.Text = initialVal
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.UsersShowSelectedFilter) 				
                    initialVal = Me.GetFromSession(Me.UsersShowSelectedFilter)
                
                End If
                
                If initialVal <> ""				
                   Me.UsersShowSelectedFilter.Items.Add(New ListItem(initialVal, initialVal))
                   Me.UsersShowSelectedFilter.SelectedValue = initialVal
                End If                
            End If
          
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
            ' Setup the pagination events.
            
              AddHandler Me.UsersPagination.FirstPage.Click, AddressOf UsersPagination_FirstPage_Click
              
              AddHandler Me.UsersPagination.LastPage.Click, AddressOf UsersPagination_LastPage_Click
              
              AddHandler Me.UsersPagination.NextPage.Click, AddressOf UsersPagination_NextPage_Click
              
              AddHandler Me.UsersPagination.PageSizeButton.Click, AddressOf UsersPagination_PageSizeButton_Click
            
              AddHandler Me.UsersPagination.PreviousPage.Click, AddressOf UsersPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.EmailLabel.Click, AddressOf EmailLabel_Click
            
              AddHandler Me.IsActiveLabel.Click, AddressOf IsActiveLabel_Click
            
              AddHandler Me.User_NameLabel.Click, AddressOf User_NameLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.UsersNewButton.Click, AddressOf UsersNewButton_Click
              
              AddHandler Me.UsersRefreshButton.Click, AddressOf UsersRefreshButton_Click
              
              AddHandler Me.UsersResetButton.Click, AddressOf UsersResetButton_Click
              
              AddHandler Me.UsersSaveButton.Click, AddressOf UsersSaveButton_Click
              
              Me.UsersSaveButton.Attributes.Add("onclick", "SubmitHRefOnceForMTM(this, """ & Me.Page.GetResourceValue("Txt:SaveRecord", "IROC2") & """);")
            
            AddHandler Me.UsersSearchButton.Button.Click, AddressOf UsersSearchButton_Click
        
              AddHandler Me.IsActiveFilter.SelectedIndexChanged, AddressOf IsActiveFilter_SelectedIndexChanged
                    
        
          ' Setup events for others
            
          AddHandler Me.UsersShowSelectedFilter.SelectedIndexChanged, AddressOf UsersShowSelectedFilter_SelectedIndexChanged
        
        End Sub
        
        
        Public Overridable Sub LoadData()        
        
            ' Read data from database. Returns an array of records that can be assigned
            ' to the DataSource table control property.
            Try	
                Dim joinFilter As CompoundFilter = CreateCompoundJoinFilter()
                
                ' The WHERE clause will be empty when displaying all records in table.
                Dim wc As WhereClause = CreateWhereClause()
                If wc IsNot Nothing AndAlso Not wc.RunQuery Then
                    ' Initialize an empty array of records
                    Dim alist As New ArrayList(0)
                    Me.DataSource = DirectCast(alist.ToArray(GetType(UsersRecord)), UsersRecord())
                    ' Add records to the list if needed.
                    Me.AddNewRecords()
                    Me._TotalRecords = 0
                    Me._TotalPages = 0
                    Return
                End If

                ' Call OrderBy to determine the order - either use the order defined
                ' on the Query Wizard, or specified by user (by clicking on column heading)
                Dim orderBy As OrderBy = CreateOrderBy()
                
                ' Get the pagesize from the pagesize control.
                Me.GetPageSize()
                               
                If Me.DisplayLastPage Then
                    Dim totalRecords As Integer = If(Me._TotalRecords < 0, GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause()), Me._TotalRecords)
                     
                      Dim totalPages As Integer = CInt(Math.Ceiling(totalRecords / Me.PageSize))
                    
                    Me.PageIndex = totalPages - 1
                End If                               
                
                ' Make sure PageIndex (current page) and PageSize are within bounds.
                If Me.PageIndex < 0 Then
                    Me.PageIndex = 0
                End If
                If Me.PageSize < 1 Then
                    Me.PageSize = 1
                End If
                
                ' Retrieve the records and set the table DataSource.
                ' Only PageSize records are fetched starting at PageIndex (zero based).
                If Me.AddNewRecord > 0 Then
                ' Make sure to preserve the previously entered data on new rows.
                    Dim postdata As New ArrayList
                    For Each rc As UsersTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(UsersRecord)), UsersRecord())
                Else  ' Get the records from the database	
                        Me.DataSource = GetRecords(joinFilter, wc, orderBy, Me.PageIndex, Me.PageSize)
                      
                End If
                
                ' if the datasource contains no records contained in database, then load the last page.
                If (DbUtils.GetCreatedRecords(Me.DataSource).Length = 0 AndAlso Not Me.DisplayLastPage) Then
                      Me.DisplayLastPage = True
                      LoadData()
                Else
                
                    ' Add any new rows desired by the user.
                    Me.AddNewRecords()
                       

                    ' Initialize the page and grand totals. now
                
                End If
    
            Catch ex As Exception
                ' Report the error message to the end user
                Dim msg As String = ex.Message
                If ex.InnerException IsNot Nothing Then
                    msg = msg & " InnerException: " & ex.InnerException.Message
                End If
                Throw New Exception(msg, ex.InnerException)
            End Try
        End Sub
        
        Public Overridable Function GetRecords( _
            ByVal join As BaseFilter, _
            ByVal where As WhereClause, _
            ByVal orderBy As OrderBy, _
            ByVal pageIndex As Integer, _
            ByVal pageSize As Integer) As UsersRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UsersTable.Column1, True)         
            ' selCols.Add(UsersTable.Column2, True)          
            ' selCols.Add(UsersTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return UsersTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New UsersTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(UsersRecord)), UsersRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UsersTable.Column1, True)         
            ' selCols.Add(UsersTable.Column2, True)          
            ' selCols.Add(UsersTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return UsersTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New UsersTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)           
                
                
                Return CInt(databaseTable.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
            End If

        End Function        
        
      
    
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record for each row in the table.  To do this, it calls the
            ' DataBind for each of the rows.
            ' DataBind also populates any filters above the table, and sets the pagination
            ' control to the correct number of records and the current page number.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
                Return
            End If
            
            'LoadData for DataSource for chart and report if they exist
               
            ' Setup the pagination controls.
            BindPaginationControls()

      
        
          ' Bind the repeater with the list of records to expand the UI.
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
          
          Dim Id As String = GetParentControlPrimaryKey()
            
          Dim addVar As ListItemCollection = New ListItemCollection()
          Dim removeVar As ListItemCollection = New ListItemCollection()
          GetValuesFromHiddenVariable(addVar, removeVar)
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As UsersTableControlRow = DirectCast(repItem.FindControl("UsersTableControlRow"), UsersTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            Dim User_ID As String = recControl.GetRecord().User_ID().ToString()
            
            Dim hasChanged As Boolean = False

            If Not IsNothing(addVar) Then
                For Each item As ListItem In addVar
                    Dim addVal() As String = item.ToString().Split(CChar(";"))
                    If User_ID = KeyValue.XmlToKey(addVal(0)).ColumnValueByName("User_ID") AndAlso id = KeyValue.XmlToKey(addVal(1)).ColumnValueByName("Role_ID") Then
                        recControl.UsersRecordRowSelection.Checked = True
                        hasChanged = True
                    End If
                Next
            End If

            If Not IsNothing(removeVar) Then
                For Each item As ListItem In removeVar
                    Dim remVal() As String = item.ToString().Split(CChar(";"))
                    if User_ID = KeyValue.XmlToKey(remVal(0)).ColumnValueByName("User_ID") AndAlso id = KeyValue.XmlToKey(remVal(1)).ColumnValueByName("Role_ID") Then
                        recControl.UsersRecordRowSelection.Checked = False
                        hasChanged = True
                    End If
                Next
            End If
                
            If Not hasChanged Then
                Dim wc As New WhereClause
                Dim jFilter As CompoundFilter = New CompoundFilter()
                wc.iAND(Users_RoleTable.Instance.Role_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, Id)
                wc.iAND(Users_RoleTable.Instance.User_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, User_ID)

                If Users_RoleTable.GetRecordCount(jFilter, wc) > 0 Then
                   recControl.UsersRecordRowSelection.Checked = True
                Else
                   recControl.UsersRecordRowSelection.Checked = False
                End If
            End If
            
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetEmailLabel()
                SetIsActiveFilter()
                SetIsActiveLabel()
                SetIsActiveLabel1()
                SetUser_NameLabel()
                
                
                
                
                
                SetUsersSearch()
                
                
                
                SetUsersShowSelectedFilterLabel()
          SetUsersShowSelectedFilter()
        
            ' setting the state of expand or collapse alternative rows
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
      
        Public Overridable Sub RegisterPostback()
        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"UsersSaveButton"))
                        
        
        End Sub

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e as FormulaEvaluator) As String
            If e Is Nothing
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()
            
            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If
            
            If includeDS
                
            End If
            
            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

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

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function




        Public Overridable Sub ResetControl()
                    
            Me.IsActiveFilter.ClearSelection()
            
           Me.UsersShowSelectedFilter.ClearSelection()
         
            Me.UsersSearch.Text = ""
            
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
                
            End If
                
            Me.PageIndex = 0
        End Sub

        Public Overridable Sub ResetPageControl()
            Me.PageIndex = 0
        End Sub
        
        Protected Overridable Sub BindPaginationControls()
            ' Setup the pagination controls.

            ' Bind the pagination labels.
        
            If DbUtils.GetCreatedRecords(Me.DataSource).Length > 0 Then                      
                    
                Me.UsersPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.UsersPagination.CurrentPage.Text = "0"
            End If
            Me.UsersPagination.PageSize.Text = Me.PageSize.ToString()
            Me.UsersPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for UsersTableControl pagination.
        
            Me.UsersPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UsersPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UsersPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UsersPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UsersPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UsersPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UsersPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.UsersPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
      Public Overridable Function GetParentControlPrimaryKey() As String
          
             Dim roleRecordControlObj As RoleRecordControl = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me.Page, "RoleRecordControl"),  IROC2.UI.Controls.Edit_Role1.RoleRecordControl)
           
            Dim id As String = ""
         
            If (Not IsNothing(roleRecordControlObj) AndAlso Not IsNothing(roleRecordControlObj.GetRecord()) AndAlso (roleRecordControlObj.GetRecord().IsCreated)) Then
              
              id = roleRecordControlObj.GetRecord().Role_ID.ToString()
              
            End If 
     
            Return id       
        End Function
        
        Public Overridable Sub DeleteValuesFromHiddenVariable()
            Dim Role_ID As String = GetParentControlPrimaryKey()
            
            Dim addVar As ListItemCollection = New ListItemCollection()
            Dim removeVar As ListItemCollection = New ListItemCollection()

            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            serializer.RegisterConverters(new System.Web.Script.Serialization.JavaScriptConverter() {New System.Web.Script.Serialization.ListItemCollectionConverter()})

            Dim addValues As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(Me.Page.FindControlRecursively("_AddValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden) 
            If Not IsNothing(addValues) Then
              addVar = serializer.Deserialize(Of ListItemCollection)(addValues.Value)
            End If

            Dim removeValues As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(Me.Page.FindControlRecursively("_RemoveValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden)
            If Not IsNothing(removeValues) Then
                removeVar = serializer.Deserialize(Of ListItemCollection)(removeValues.Value)
            End If

            Dim newAddVar As ListItemCollection  = new ListItemCollection()
            Dim newRemoveVar As ListItemCollection = new ListItemCollection()
            
            If Not IsNothing(addVar) Then
                For Each item As ListItem in addVar
                    Dim addVal As String() = item.ToString().Split(CChar(";"))
                    If Role_ID <> KeyValue.XmlToKey(addVal(1)).ColumnValueByName("Role_ID") Then
                        newAddVar.Add(item)
                    End If
                Next
            End If

            If Not IsNothing(removeVar)
                For Each item As ListItem in removeVar
                    Dim remVal As String() = item.ToString().Split(CChar(";"))
                    If Role_ID <> KeyValue.XmlToKey(remVal(1)).ColumnValueByName("Role_ID") Then
                        newRemoveVar.Add(item)
                    End If
                Next
            End If

            If newRemoveVar.Count > 0 Then
                removeValues.Value = serializer.Serialize(newRemoveVar)
            Else
                removeValues.Value = ""
            End If
                
            If newAddVar.Count > 0 Then
                addvalues.Value = serializer.Serialize(newAddVar)
            Else
                addvalues.Value = ""
            End If

            Me.DataChanged = True
        End Sub

        Public Overridable Sub GetValuesFromHiddenVariable(ByRef addVar As ListItemCollection, ByRef removeVar As ListItemCollection)        
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            serializer.RegisterConverters(New System.Web.Script.Serialization.JavaScriptConverter() {New System.Web.Script.Serialization.ListItemCollectionConverter()})
            
            Dim addvalues As System.Web.UI.HtmlControls.HtmlInputHidden = _
                DirectCast(Me.FindControl("_AddValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden)
            addVar = serializer.Deserialize(Of ListItemCollection)(addvalues.Value)

            Dim removeValues As System.Web.UI.HtmlControls.HtmlInputHidden = _
                DirectCast(Me.FindControl("_RemoveValuesUsersTableControl"), System.Web.UI.HtmlControls.HtmlInputHidden)
            removeVar = serializer.Deserialize(Of ListItemCollection)(removeValues.Value)
        End Sub
  
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim addVar As ListItemCollection = New ListItemCollection()
            Dim removeVar As ListItemCollection = New ListItemCollection()
            GetValuesFromHiddenVariable(addVar, removeVar)
            
            Dim isChanged As String = CType(HttpContext.Current.Session.Item("UsersRecordRowSelectionDataChanged"), String)
            If Not String.IsNullOrEmpty(isChanged) Then
                If isChanged.Equals("True") Then                
                    Dim Role_ID As String = ""
                    Dim User_ID As String = ""
                    
                   Role_ID = GetParentControlPrimaryKey()
                    
                    Try                       
                       If Not IsNothing(addVar) Then
                          For Each item As ListItem In addVar                                
                                Dim addVal() As String = item.ToString().Split(CChar(";"))
                                User_ID = KeyValue.XmlToKey(addVal(0).ToString).ColumnValueByName("User_ID")
                                If Role_ID = KeyValue.XmlToKey(addVal(1)).ColumnValueByName("Role_ID") Then
                                    Dim wc As New WhereClause
                                    Dim jFilter As CompoundFilter = New CompoundFilter()
                                    wc.iAND(Users_RoleTable.Instance.Role_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, Role_ID)
                                    wc.iAND(Users_RoleTable.Instance.User_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, User_ID)
    
                                    If Users_RoleTable.GetRecordCount(jFilter, wc) = 0 Then
                                        Dim rec As Users_RoleRecord = New Users_RoleRecord
                                        rec.Parse(User_ID, rec.TableAccess.TableDefinition.ColumnList.GetByAnyName("User_ID"))
                                        rec.Parse(Role_ID, rec.TableAccess.TableDefinition.ColumnList.GetByAnyName("Role_ID"))
                                        rec.Save()
                                    End If
                                End If
                            Next
                        End If

                        If Not IsNothing(removeVar) Then
                            For Each item As ListItem In removeVar
                                Dim remVal() As String = item.ToString().Split(CChar(";"))
                                User_ID = KeyValue.XmlToKey(remVal(0).ToString).ColumnValueByName("User_ID")
                                If Role_ID = KeyValue.XmlToKey(remVal(1)).ColumnValueByName("Role_ID") Then
                                    Dim myKeyValue As New BaseClasses.Data.KeyValue
                                    myKeyValue.AddElement(Users_RoleTable.Instance.Role_IDColumn.InternalName, Role_ID)
                                    myKeyValue.AddElement(Users_RoleTable.Instance.User_IDColumn.InternalName, User_ID)

                                    Dim wc As New WhereClause
                                    Dim jFilter As CompoundFilter = New CompoundFilter()
                                    wc.iAND(Users_RoleTable.Instance.Role_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, Role_ID)
                                    wc.iAND(Users_RoleTable.Instance.User_IDColumn, BaseFilter.ComparisonOperator.EqualsTo, User_ID)                                
                                
                                    If Users_RoleTable.GetRecordCount(jFilter, wc) > 0 Then
                                        Users_RoleTable.DeleteRecord(myKeyValue)
                                    End If
                                End If
                            Next
                        End If
                      
                    Catch ex As Exception
                        Me.Page.ErrorOnPage = True
                        ' Report the error message to the end user
                        Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
                    Finally                      
                    End Try
                End If
                HttpContext.Current.Session.Remove("UsersRecordRowSelectionDataChanged")
                HttpContext.Current.Session.Add("UsersRecordRowSelectionDataChanged", "False")
                DeleteValuesFromHiddenVariable()
            End If
            
            Dim recCtl As UsersTableControlRow
            For Each recCtl In Me.GetRecordControls()
        
                If Me.InDeletedRecordIds(recCtl) Then
                    ' Delete any pending deletes. 
                    recCtl.Delete()
                Else
                    If recCtl.Visible Then
                        recCtl.SaveData()
                    End If
                End If
          
            Next
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
          
            ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
            For Each recCtl In Me.GetRecordControls()
                recCtl.IsNewRecord = False
            Next
    
      
            ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
            Me.DeletedRecordIds = Nothing
      
        End Sub

        Public Overridable Function CreateCompoundJoinFilter() As CompoundFilter
            Dim jFilter As CompoundFilter = New CompoundFilter()
        
         If Not IsNothing(Me.Page) Then           
            Dim Id As String = GetParentControlPrimaryKey()    
       
            If MiscUtils.IsValueSelected(Me.UsersShowSelectedFilter) AndAlso Not String.IsNullOrEmpty(Id) Then
                jFilter.AddJoin(UsersTable.User_ID, Nothing, Users_RoleTable.User_ID, Nothing)                      
            End If  
               
         End If                              
      
            Return jFilter
        End Function

        
          Public Overridable Function CreateOrderBy() As OrderBy
          ' The CurrentSortOrder is initialized to the sort order on the
          ' Query Wizard.  It may be modified by the Click handler for any of
          ' the column heading to sort or reverse sort by that column.
          ' You can add your own sort order, or modify it on the Query Wizard.
          Return Me.CurrentSortOrder
          End Function
      
        Public Overridable Function CreateWhereClause() As WhereClause
            'This CreateWhereClause is used for loading the data.
            UsersTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
            If IsValueSelected(Me.IsActiveFilter) Then
    
                wc.iAND(UsersTable.IsActive, BaseFilter.ComparisonOperator.EqualsTo, MiscUtils.GetSelectedValue(Me.IsActiveFilter, Me.GetFromSession(Me.IsActiveFilter)), False, False)
            
            End If
                  
                
                       
            If IsValueSelected(Me.UsersSearch) Then
              If Me.UsersSearch.Text = BaseClasses.Resources.AppResources.GetResourceValue("Txt:SearchForEllipsis", Nothing) Then
                 Me.UsersSearch.Text = ""
              Else
              ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
              
                    If Me.UsersSearch.Text.StartsWith("...") Then
                        Me.UsersSearch.Text = Me.UsersSearch.Text.SubString(3,Me.UsersSearch.Text.Length-3)
                    End If
                    If Me.UsersSearch.Text.EndsWith("...") then
                        Me.UsersSearch.Text = Me.UsersSearch.Text.SubString(0,Me.UsersSearch.Text.Length-3)
                        ' Strip the last word as well as it is likely only a partial word
                        Dim endindex As Integer = UsersSearch.Text.Length - 1
                        While (Not Char.IsWhiteSpace(UsersSearch.Text(endindex)) AndAlso endindex > 0)
                            endindex -= 1
                        End While
                        If endindex > 0 Then
                            UsersSearch.Text = UsersSearch.Text.Substring(0, endindex)
                        End If
              End If
            End If
            
              Dim formatedSearchText As String = MiscUtils.GetSelectedValue(Me.UsersSearch, Me.GetFromSession(Me.UsersSearch))
                
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(Me.UsersSearch) Then 
        ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
      Dim cols As New ColumnList    
        
      cols.Add(UsersTable.User_Name, True)
      
      cols.Add(UsersTable.Email, True)
      
      For Each col As BaseColumn in cols
      
                    search.iOR(col, BaseFilter.ComparisonOperator.Contains, MiscUtils.GetSelectedValue(Me.UsersSearch, Me.GetFromSession(Me.UsersSearch)), True, False)
        
      Next
    
                    wc.iAND(search)
                End If
            End If
                  
          If MiscUtils.IsValueSelected(Me.UsersShowSelectedFilter) Then  
                        
            Dim Id As String = GetParentControlPrimaryKey()
            
            If Not String.IsNullOrEmpty(Id) Then
               wc.iAND(Users_RoleTable.Role_ID, BaseFilter.ComparisonOperator.EqualsTo, Id, False, False)
            End If
          End If  
          
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            UsersTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
            Dim IsActiveFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "IsActiveFilter_Ajax"), String)
            If IsValueSelected(IsActiveFilterSelectedValue) Then
    
                 wc.iAND(UsersTable.IsActive, BaseFilter.ComparisonOperator.EqualsTo, IsActiveFilterSelectedValue, false, False)
             
             End If
                      
            If IsValueSelected(searchText) and fromSearchControl = "UsersSearch" Then
                Dim formatedSearchText as String = searchText
                ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
                If searchText.StartsWith("...") Then
                    formatedSearchText = searchText.SubString(3,searchText.Length-3)
                End If
                If searchText.EndsWith("...") Then
                    formatedSearchText = searchText.SubString(0,searchText.Length-3)
                    ' Strip the last word as well as it is likely only a partial word
                    Dim endindex As Integer = searchText.Length - 1
                    While (Not Char.IsWhiteSpace(searchText(endindex)) AndAlso endindex > 0)
                        endindex -= 1
                    End While
                    If endindex > 0 Then
                        searchText = searchText.Substring(0, endindex)
                    End If
                End If
                'After stripping "...", trim any leading and trailing whitespaces 
                formatedSearchText = formatedSearchText.Trim()
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(formatedSearchText) Then
                      ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
                    If InvariantLCase(AutoTypeAheadSearch).equals("wordsstartingwithsearchstring") Then
                
      Dim cols As New ColumnList    
        
      cols.Add(UsersTable.User_Name, True)
      
      cols.Add(UsersTable.Email, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators & formatedSearchText, True, False)
                
      Next
    
                    Else
                        
      Dim cols As New ColumnList    
        
      cols.Add(UsersTable.User_Name, True)
      
      cols.Add(UsersTable.Email, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, formatedSearchText, True, False)
      Next
    
                    End If
                    wc.iAND(search)
                End If
            End If
                  
      
      
            Return wc
        End Function
          
        Public Overridable Function GetAutoCompletionList_UsersSearch(ByVal prefixText As String, ByVal count As Integer) As String()
            Dim resultList As ArrayList = New ArrayList
            Dim wordList As ArrayList = New ArrayList
            
            Dim filterJoin As CompoundFilter = CreateCompoundJoinFilter()
            If count = 0 Then count = 10
            Dim wc As WhereClause = CreateWhereClause(prefixText,"UsersSearch", "WordsStartingWithSearchString", "[^a-zA-Z0-9]")
            Dim recordList () As IROC2.Business.UsersRecord = UsersTable.GetRecords(filterJoin, wc, Nothing, 0, count,count)
            Dim rec As UsersRecord = Nothing
            Dim resultItem As String = ""
            For Each rec In recordList 
                ' Exit the loop if recordList count has reached AutoTypeAheadListSize.
                If resultList.Count >= count then
                    Exit For
                End If
                ' If the field is configured to Display as Foreign key, Format() method returns the 
                ' Display as Forien Key value instead of original field value.
                ' Since search had to be done in multiple fields (selected in Control's page property, binding tab) in a record,
                ' We need to find relevent field to display which matches the prefixText and is not already present in the result list.
        
                resultItem = rec.Format(UsersTable.User_Name)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If UsersTable.User_Name.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "WordsStartingWithSearchString", "[^a-zA-Z0-9]", resultList, UsersTable.User_Name.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
                resultItem = rec.Format(UsersTable.Email)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If UsersTable.Email.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "WordsStartingWithSearchString", "[^a-zA-Z0-9]", resultList, UsersTable.Email.IsFullTextSearchable)
                        If isAdded Then
                            Continue For
                        End If
                    End If
                End If
      
            Next                
             
            resultList.Sort()
            Dim result() As String = New String(resultList.Count - 1) {}
            Array.Copy(resultList.ToArray, result, resultList.Count)
            Return result
        End Function
          

         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function

        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                   
                    resultList.Add(itemToAdd)
          				
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    
        Protected Overridable Sub GetPageSize()
        
            If Me.UsersPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.UsersPagination.PageSize.Text)
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overridable Sub AddNewRecords()
            
            Dim newRecordList As ArrayList = New ArrayList()
          
    Dim newUIDataList As System.Collections.Generic.List(Of Hashtable) = New System.Collections.Generic.List(Of Hashtable)()

    ' Loop though all the record controls and if the record control
    ' does not have a unique record id set, then create a record
    ' and add to the list.
    If Not Me.ResetData Then
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As UsersTableControlRow = DirectCast(repItem.FindControl("UsersTableControlRow"), UsersTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As UsersRecord = New UsersRecord()
        
                        If recControl.Email.Text <> "" Then
                            rec.Parse(recControl.Email.Text, UsersTable.Email)
                        End If
                        If recControl.IsActive.Text <> "" Then
                            rec.Parse(recControl.IsActive.Text, UsersTable.IsActive)
                        End If
                        If recControl.User_Name.Text <> "" Then
                            rec.Parse(recControl.User_Name.Text, UsersTable.User_Name)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New UsersRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(UsersRecord)), UsersRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As UsersTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As UsersTableControlRow) As Boolean
            If Me.DeletedRecordIds Is Nothing OrElse Me.DeletedRecordIds.Trim = "" Then
                Return False
            End If

            Return Me.DeletedRecordIds.IndexOf("[" & rec.RecordUniqueId & "]") >= 0
        End Function

        Private _DeletedRecordIds As String
        Public Property DeletedRecordIds() As String
            Get
                Return Me._DeletedRecordIds
            End Get
            Set(ByVal value As String)
                Me._DeletedRecordIds = value
            End Set
        End Property
        
      
        ' Create Set, WhereClause, and Populate Methods
        
        Public Overridable Sub SetEmailLabel()
                  
                  End Sub
                
        Public Overridable Sub SetIsActiveLabel()
                  
                  End Sub
                
        Public Overridable Sub SetIsActiveLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetUser_NameLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUsersShowSelectedFilterLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UsersShowSelectedFilterLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetIsActiveFilter()

            
                Me.PopulateIsActiveFilter(GetSelectedValue(Me.IsActiveFilter,  GetFromSession(Me.IsActiveFilter)), 500)					
                    
              End Sub	
            
        Public Overridable Sub SetUsersSearch()

            
              End Sub	
            
        Public Overridable Sub SetUsersShowSelectedFilter()
                    
           Me.PopulateUsersShowSelectedFilter(GetSelectedValue(Me.UsersShowSelectedFilter,  GetFromSession(Me.UsersShowSelectedFilter)))					
        End Sub	
      
        ' Get the filters' data for IsActiveFilter
        Protected Overridable Sub PopulateIsActiveFilter(ByVal selectedValue As String, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Me.IsActiveFilter.Items.Clear()
            Dim wc As WhereClause = Me.CreateWhereClause_IsActiveFilter()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_IsActiveFilter function.
            ' It is better to customize the where clause there.
                
            ' Setup the static list items        
            
            ' Add the All item.
            Me.IsActiveFilter.Items.Insert(0, new ListItem(Me.Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
                            
            
            
            Dim orderBy As OrderBy = New OrderBy(False, False)
            orderBy.Add(UsersTable.IsActive, OrderByItem.OrderDir.Asc)                
            
            	

            Dim values(-1) As String
            If wc.RunQuery Then
            
                values = UsersTable.GetValues(UsersTable.IsActive, wc, orderBy, maxItems)
            
            End If
            
                  
            Dim cvalue As String
            
            Dim listDuplicates As New ArrayList()
            For Each cvalue In values
                ' Create the item and add to the list.
                Dim fvalue As String
                If ( UsersTable.IsActive.IsColumnValueTypeBoolean()) Then
                    fvalue = cvalue
                Else
                    fvalue = UsersTable.IsActive.Format(cvalue)
                End If

                If (IsNothing(fvalue)) Then
                    fvalue = ""
                End If

                fvalue = fvalue.Trim()

                If ( fvalue.Length > 50 ) Then
                    fvalue = fvalue.Substring(0, 50) & "..."
                End If

                Dim dupItem As ListItem = Me.IsActiveFilter.Items.FindByText(fvalue)
                
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                Me.IsActiveFilter.Items.Add(newItem)

                If listDuplicates.Contains(fvalue)  AndAlso Not String.IsNullOrEmpty(cvalue) Then
                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                End If
            Next
                    
            ' Set the selected value.
            SetSelectedValue(Me.IsActiveFilter, selectedValue)
                              
        End Sub
            
          Protected Overridable Sub PopulateUsersShowSelectedFilter(ByVal selectedValue As String)
          Me.UsersShowSelectedFilter.Items.Clear()

          ' 1. Setup the static list items
          
                Me.UsersShowSelectedFilter.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:ShowAll}"), "--ANY--"))
              
                Me.UsersShowSelectedFilter.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:ShowIncluded}"), "--Included--"))
              
              ' Set the selected value.
              SetSelectedValue(Me.UsersShowSelectedFilter, selectedValue)
            
          End Sub
        
              

        Public Overridable Function CreateWhereClause_IsActiveFilter() As WhereClause
          
            ' Create a where clause for the filter IsActiveFilter.
            ' This function is called by the Populate method to load the items 
            ' in the IsActiveFilterDropDownList
            
            Dim wc As WhereClause= New WhereClause()
            Return wc
            
        End Function			
            

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    
                    Me.LoadData()
                    Me.DataBind()
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
            Me.SaveToSession(Me.IsActiveFilter, Me.IsActiveFilter.SelectedValue)
                  
            Me.SaveToSession(Me.UsersSearch, Me.UsersSearch.Text)
                  
        
            'Save pagination state to session.
        
          Me.SaveToSession(Me.UsersShowSelectedFilter, Me.UsersShowSelectedFilter.SelectedValue)
         
            
            ' Save table control properties to the session.
            If Not Me.CurrentSortOrder Is Nothing Then
            Me.SaveToSession(Me, "Order_By", Me.CurrentSortOrder.ToXmlString())
            End If
            
            Me.SaveToSession(Me, "Page_Index", Me.PageIndex.ToString())
            Me.SaveToSession(Me, "Page_Size", Me.PageSize.ToString())
        
            Me.SaveToSession(Me, "DeletedRecordIds", Me.DeletedRecordIds)  
        
        End Sub
        
        Protected  Sub SaveControlsToSession_Ajax()
            ' Save filter controls to values to session.
          
      Me.SaveToSession("IsActiveFilter_Ajax", Me.IsActiveFilter.SelectedValue)
              
      Me.SaveToSession("UsersSearch_Ajax", Me.UsersSearch.Text)
              
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
            Me.RemoveFromSession(Me.IsActiveFilter)
            Me.RemoveFromSession(Me.UsersSearch)
    
            ' Clear pagination state from session.
        
        Me.RemoveFromSession(Me.UsersShowSelectedFilter)
       
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("UsersTableControl_OrderBy"), String)
            
            If orderByStr IsNot Nothing AndAlso orderByStr.Trim <> "" Then
                Me.CurrentSortOrder = BaseClasses.Data.OrderBy.FromXmlString(orderByStr)
            
            Else 
                Me.CurrentSortOrder = New OrderBy(True, False)
            
            End If
            
    Dim pageIndex As String = CType(ViewState("Page_Index"), String)
    If pageIndex IsNot Nothing Then
    Me.PageIndex = CInt(pageIndex)
    End If

    Dim pageSize As String = CType(ViewState("Page_Size"), String)
    If Not pageSize Is Nothing Then
    Me.PageSize = CInt(pageSize)
    End If

    
    
            ' Load view state for pagination control.
        
            Me.DeletedRecordIds = CType(Me.ViewState("DeletedRecordIds"), String)
        
        End Sub

        Protected Overrides Function SaveViewState() As Object
            
            If Me.CurrentSortOrder IsNot Nothing Then
                Me.ViewState("UsersTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub UsersPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex = 0
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UsersPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.DisplayLastPage = True
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UsersPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            Me.PageIndex += 1
            Me.DataChanged = True
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub UsersPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.UsersPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.UsersPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub UsersPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
            If Me.PageIndex > 0 Then
                Me.PageIndex -= 1
                Me.DataChanged = True
            End If
      
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        

        ' Generate the event handling functions for sorting events.
        
        Public Overridable Sub EmailLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Email when clicked.
              
            ' Get previous sorting state for Email.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UsersTable.Email)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Email.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UsersTable.Email, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Email, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub IsActiveLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by IsActive when clicked.
              
            ' Get previous sorting state for IsActive.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UsersTable.IsActive)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for IsActive.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UsersTable.IsActive, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by IsActive, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub User_NameLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by User_Name when clicked.
              
            ' Get previous sorting state for User_Name.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UsersTable.User_Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for User_Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UsersTable.User_Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by User_Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub UsersNewButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Users/Add-Users.aspx"
                
        Dim shouldRedirect As Boolean = True
        Dim target As String = ""
      
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            url = Me.ModifyRedirectUrl(url, "",True)
            url = Me.Page.ModifyRedirectUrl(url, "",True)
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                shouldRedirect = False
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
            If shouldRedirect Then
                Me.Page.ShouldSaveControlsToSession = True
                Me.Page.Response.Redirect(url)
            End If              
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UsersRefreshButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
                    DeleteValuesFromHiddenVariable()
                  
            Dim RoleRecordControlObj as RoleRecordControl = DirectCast(Me.Page.FindControlRecursively("RoleRecordControl"), RoleRecordControl)
            RoleRecordControlObj.ResetData = True
                        
            
            Dim UsersTableControlObj as UsersTableControl = DirectCast(Me.Page.FindControlRecursively("UsersTableControl"), UsersTableControl)
            UsersTableControlObj.ResetData = True
                        
            UsersTableControlObj.RemoveFromSession(UsersTableControlObj, "DeletedRecordIds")
            UsersTableControlObj.DeletedRecordIds = Nothing
            
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UsersResetButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
              Me.IsActiveFilter.ClearSelection()
              Me.UsersSearch.Text = ""
          Me.UsersShowSelectedFilter.ClearSelection()
          
          DeleteValuesFromHiddenVariable()
          
              Me.CurrentSortOrder.Reset()
              If Me.InSession(Me, "Order_By") Then
                  Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
              Else
                  Me.CurrentSortOrder = New OrderBy(True, False)
                  

              End If
              

        ' Setting the DataChanged to True results in the page being refreshed with
        ' the most recent data from the database.  This happens in PreRender event
        ' based on the current sort, search and filter criteria.
        Me.DataChanged = True
            
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UsersSaveButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
        
              If (Not Me.Page.IsPageRefresh) Then         
                  Me.SaveData()
              End If        
        
            Me.Page.CommitTransaction(sender)
          ' Set IsNewRecord to False for all records - since everything has been saved and is no longer "new"
          Dim recCtl As UsersTableControlRow
          For Each recCtl in Me.GetRecordControls()
            
            recCtl.IsNewRecord = False
          Next
    
      
          ' Set DeletedRecordsIds to Nothing since we have deleted all pending deletes.
          
                Me.DeletedRecordIds = Nothing
            
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
                  
        End Sub
        
        ' event handler for Button with Layout
        Public Overridable Sub UsersSearchButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
          Me.DataChanged = True
          
          DeleteValuesFromHiddenVariable()
          
            Catch ex As Exception
            
       ' Upon error, rollback the transaction
                Me.Page.RollBackTransaction(sender)
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
                DbUtils.EndTransaction
            End Try
    
        End Sub
            
      

        ' Generate the event handling functions for filter and search events.
        
        ' event handler for FieldFilter
        Protected Overridable Sub IsActiveFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
           Me.DataChanged = True
           
          	                   
              
        End Sub
            
          ' event handler for DropDownList
          Protected Overridable Sub UsersShowSelectedFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
        
            Try
                  DbUtils.StartTransaction()
                  DeleteValuesFromHiddenVariable()
                  DbUtils.CommitTransaction()
            Catch ex As Exception
                  ' Upon error, rollback the transaction
                  DbUtils.RollBackTransaction()
                  Me.Page.ErrorOnPage = True
                  ' Report the error message to the end user
                  BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                  DbUtils.EndTransaction()
            End Try
            
            Me.DataChanged = True
        End Sub
        
    
        ' Generate the event handling functions for others
        
      
        Private _UIData As New System.Collections.Generic.List(Of Hashtable)
        Public Property UIData() As System.Collections.Generic.List(Of Hashtable)
            Get
                Return Me._UIData
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of Hashtable))
                Me._UIData = value
            End Set
        End Property
        
        ' pagination properties
        Protected _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property

        Protected _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property

        Protected _TotalRecords As Integer = -1
        Public Property TotalRecords() As Integer
            Get
                If _TotalRecords < 0 
                    _TotalRecords = UsersTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
                End If
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                  
                End If
                Me._TotalRecords = value
            End Set
        End Property

        
    
        Protected _TotalPages As Integer = -1
        Public Property TotalPages() As Integer
            Get
                If _TotalPages < 0 Then
                
                    Me.TotalPages = CInt(Math.Ceiling(TotalRecords / Me.PageSize))
                  
                End If                
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property

        Protected _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal value As Boolean)
                Me._DataChanged = value
            End Set
        End Property
        
        Private _ResetData As Boolean = False
        Public Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal value As Boolean)
                Me._ResetData = value
            End Set
        End Property

        Private _AddNewRecord As Integer = 0
        Public Property AddNewRecord() As Integer
            Get
                Return Me._AddNewRecord
            End Get
            Set(ByVal value As Integer)
                Me._AddNewRecord = value
            End Set
        End Property

        
        Private _CurrentSortOrder As OrderBy = Nothing
        Public Property CurrentSortOrder() As OrderBy
            Get
                Return Me._CurrentSortOrder
            End Get
            Set(ByVal value As BaseClasses.Data.OrderBy)
                Me._CurrentSortOrder = value
            End Set
        End Property
        
        Public Property DataSource() As UsersRecord ()
            Get
                Return DirectCast(MyBase._DataSource, UsersRecord())
            End Get
            Set(ByVal value() As UsersRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property EmailLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "EmailLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property IsActiveFilter() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IsActiveFilter"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
        
        Public ReadOnly Property IsActiveLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IsActiveLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property IsActiveLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IsActiveLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property User_NameLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "User_NameLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UsersNewButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersNewButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UsersPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property UsersRefreshButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersRefreshButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UsersResetButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersResetButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UsersSaveButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersSaveButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UsersSearch() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersSearch"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property UsersSearchButton() As IROC2.UI.IThemeButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersSearchButton"), IROC2.UI.IThemeButton)
          End Get
          End Property
        
        Public ReadOnly Property UsersShowSelectedFilter() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersShowSelectedFilter"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property UsersShowSelectedFilterLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UsersShowSelectedFilterLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"
        
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
      
      
        Public Overrides Overloads Function ModifyRedirectUrl(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me,includeSession)
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As UsersTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UsersRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            End If
            Return url
        End Function
        
        Public Overrides Overloads Function EvaluateExpressions(url As String, arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Dim needToProcess As Boolean = AreAnyUrlParametersForMe(url, arg)
            If (needToProcess) Then
                Dim recCtl As UsersTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UsersRecord = Nothing     
                If recCtl IsNot Nothing Then
                    rec = recCtl.GetRecord()
                End If
                If includeSession then
                    Return EvaluateExpressions(url, arg, rec, bEncrypt)
                Else
                    Return EvaluateExpressions(url, arg, rec, bEncrypt,False)
                End If
            End If
            Return url
        End Function
        
          
        Public Overridable Function GetSelectedRecordIndex() As Integer
            Dim counter As Integer = 0
            Dim recControl As UsersTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.UsersRecordRowSelection.Checked Then
                    Return counter
                End If
                counter += 1
            Next
            Return -1
        End Function
        
        Public Overridable Function GetSelectedRecordControl() As UsersTableControlRow
            Dim selectedList() As UsersTableControlRow = Me.GetSelectedRecordControls()
            If selectedList.Length = 0 Then
                Return Nothing
            End If
            Return selectedList(0)
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As UsersTableControlRow()
        
            Dim selectedList As ArrayList = New ArrayList(25)
            Dim recControl As UsersTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.UsersRecordRowSelection IsNot Nothing AndAlso recControl.UsersRecordRowSelection.Checked Then
                    selectedList.Add(recControl)
                End If
            Next
            Return DirectCast(selectedList.ToArray(GetType(UsersTableControlRow)), UsersTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As UsersTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As UsersTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                    recCtl.UsersRecordRowSelection.Checked = False
                
                Else
                
                    recCtl.Delete()
                    
                    ' Setting the DataChanged to True results in the page being refreshed with
                    ' the most recent data from the database.  This happens in PreRender event
                    ' based on the current sort, search and filter criteria.
                    Me.DataChanged = True
                    Me.ResetData = True
                  
                End If
            Next
        End Sub

        Public Function GetRecordControls() As UsersTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("UsersTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As UsersTableControlRow = DirectCast(repItem.FindControl("UsersTableControlRow"), UsersTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(UsersTableControlRow)), UsersTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the RoleRecordControl control on the Edit_Role1 page.
' Do not modify this class. Instead override any method in RoleRecordControl.
Public Class BaseRoleRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in RoleRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in RoleRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.Role_Email.TextChanged, AddressOf Role_Email_TextChanged
            
              AddHandler Me.Role_Name.TextChanged, AddressOf Role_Name_TextChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Role record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = RoleTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "RoleRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New RoleRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As RoleRecord = RoleTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = RoleTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in RoleRecordControl.
        Public Overrides Sub DataBind()
            ' The DataBind method binds the user interface controls to the values
            ' from the database record.  To do this, it calls the Set methods for 
            ' each of the field displayed on the webpage.  It is better to make 
            ' changes in the Set methods, rather than making changes here.
            
            MyBase.DataBind()

            ' Make sure that the DataSource is initialized.
            If Me.DataSource Is Nothing Then
              
                Return
            End If
             
   
            'LoadData for DataSource for chart and report if they exist
          
      
      
            ' Call the Set methods for each controls on the panel
        
                SetRole_Email()
                SetRole_EmailLabel()
                SetRole_Name()
                SetRole_NameLabel()
                
      
      
            Me.IsNewRecord = True
            
            If Me.DataSource.IsCreated Then
                Me.IsNewRecord = False
                
                If Me.DataSource.GetID IsNot Nothing Then
                    Me.RecordUniqueId = Me.DataSource.GetID.ToXmlString()
                End If
                
            End If
          
            ' Now load data for each record and table child UI controls.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
            Dim shouldResetControl As Boolean = False
            
        End Sub
        
        
        Public Overridable Sub SetRole_Email()
            
        
            ' Set the Role_Email TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Role database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Role record retrieved from the database.
            ' Me.Role_Email is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRole_Email()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Role_EmailSpecified Then
                				
                ' If the Role_Email is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(RoleTable.Role_Email)
                              
                Me.Role_Email.Text = formattedValue
                
            Else 
            
                ' Role_Email is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Role_Email.Text = RoleTable.Role_Email.Format(RoleTable.Role_Email.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRole_Name()
            
        
            ' Set the Role_Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Role database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Role record retrieved from the database.
            ' Me.Role_Name is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRole_Name()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Role_NameSpecified Then
                				
                ' If the Role_Name is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = Me.DataSource.Role_Name.ToString()
                                
                            
                Me.Role_Name.Text = formattedValue
                
            Else 
            
                ' Role_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Role_Name.Text = RoleTable.Role_Name.DefaultValue		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRole_EmailLabel()
                  
                  End Sub
                
        Public Overridable Sub SetRole_NameLabel()
                  
                  End Sub
                
        Public Overridable Sub ResetControl()
          
        End Sub
        

        Public EvaluateFormulaDelegate As BaseClasses.Data.DataSource.EvaluateFormulaDelegate = New BaseClasses.Data.DataSource.EvaluateFormulaDelegate(AddressOf Me.EvaluateFormula)

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean, ByVal e As FormulaEvaluator) As String
            If e Is Nothing Then
                e = New FormulaEvaluator()
            End If
            
            e.Variables.Clear()

            
            ' add variables for formula evaluation
            If variables IsNot Nothing Then
                Dim enumerator As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object)) = variables.GetEnumerator()
                While enumerator.MoveNext()
                    e.Variables.Add(enumerator.Current.Key, enumerator.Current.Value)
                End While
            End If

            If includeDS
                
            End IF
            
            
            ' Other variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            If dataSourceForEvaluate Is Nothing Then

                e.DataSource = Me.DataSource

            Else
                e.DataSource = dataSourceForEvaluate
            End If

            ' Define the calling control.  This is used to add other 
            ' related table and record controls as variables.
            e.CallingControl = Me

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
        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate as BaseClasses.Data.BaseRecord, ByVal format as String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal includeDS As Boolean) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format,variables ,includeDS, Nothing)        
        End Function        

        
        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object)) As String
            Return EvaluateFormula(formula, dataSourceForEvaluate, format, variables ,True, Nothing)        
        End Function        

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal format As String) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, format, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord, ByVal variables As System.Collections.Generic.IDictionary(Of String, Object), ByVal e as FormulaEvaluator) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, variables, True, e)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord) As String
            Return Me.EvaluateFormula(formula, dataSourceForEvaluate, Nothing, Nothing, True, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String, ByVal includeDS as Boolean) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, includeDS, Nothing)
        End Function

        Public Overridable Function EvaluateFormula(ByVal formula As String) As String
            Return Me.EvaluateFormula(formula, Nothing, Nothing, Nothing, True, Nothing)
        End Function


        Public Overridable Sub RegisterPostback()       
        
        
        End Sub

      
        
        ' To customize, override this method in RoleRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "RoleRecordControlPanel"), System.Web.UI.WebControls.Panel)

          If ((Not IsNothing(Panel)) AndAlso (Not Panel.Visible)) OrElse IsNothing(Me.DataSource) Then
              Return
          End If
          
              
            ' 2. Perform any custom validation.
            Me.Validate()

            
            ' 3. Set the values in the record with data from UI controls.
            ' This calls the Get() method for each of the user interface controls.
            Me.GetUIData()

            ' 4. Save in the database.
            ' We should not save the record if the data did not change. This
            ' will save a database hit and avoid triggering any database triggers.
             
            If Me.DataSource.IsAnyValueChanged Then
                ' Save record to database but do not commit yet.
                ' Auto generated ids are available after saving for use by child (dependent) records.
                Me.DataSource.Save()
              
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in RoleRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetRole_Email()
            GetRole_Name()
        End Sub
        
        
        Public Overridable Sub GetRole_Email()
            
            ' Retrieve the value entered by the user on the Role_Email ASP:TextBox, and
            ' save it into the Role_Email field in DataSource DatabaseIROC%dbo.Role record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Role_Email.Text, RoleTable.Role_Email)			

                      
        End Sub
                
        Public Overridable Sub GetRole_Name()
            
            ' Retrieve the value entered by the user on the Role_Name ASP:TextBox, and
            ' save it into the Role_Name field in DataSource DatabaseIROC%dbo.Role record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Role_Name.Text, RoleTable.Role_Name)			

                      
        End Sub
                
      
        ' To customize, override this method in RoleRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            RoleTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
            ' Retrieve the record id from the URL parameter.
              
                  Dim recId As String = DirectCast(Me.Page, BaseApplicationPage).Decrypt(Me.Page.Request.QueryString.Item("Role"))
                
            If recId Is Nothing OrElse recId.Trim = "" Then
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:UrlParamMissing", "IROC2").Replace("{URL}", "Role"))
            End If
            HttpContext.Current.Session("QueryString in Edit-Role1") = recId
              
            If KeyValue.IsXmlKey(recId) Then
                ' Keys are typically passed as XML structures to handle composite keys.
                ' If XML, then add a Where clause based on the Primary Key in the XML.
                Dim pkValue As KeyValue = KeyValue.XmlToKey(recId)
                
                wc.iAND(RoleTable.Role_ID, BaseFilter.ComparisonOperator.EqualsTo, pkValue.GetColumnValueString(RoleTable.Role_ID))
        
            Else
                ' The URL parameter contains the actual value, not an XML structure.
                
                wc.iAND(RoleTable.Role_ID, BaseFilter.ComparisonOperator.EqualsTo, recId)
        
            End If
              
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            RoleTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)

            
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
       
          
            Return wc
        End Function
          
         
         Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                         ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                         ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                         ByVal resultList As ArrayList) As Boolean
              Return FormatSuggestions(prefixText, resultItem, columnLength, AutoTypeAheadDisplayFoundText, _
                                       autoTypeAheadSearch, AutoTypeAheadWordSeparators, _
                                       resultList, False)
         End Function                                       
         
        'Formats the resultItem and adds it to the list of suggestions.
        Public Overridable Function FormatSuggestions(ByVal prefixText As String, ByVal resultItem As String, _
                                               ByVal columnLength As Integer, ByVal AutoTypeAheadDisplayFoundText As String, _
                                               ByVal autoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String, _
                                               ByVal resultList As ArrayList, ByVal stripHTML As Boolean) As Boolean
            If stripHTML Then
                prefixText = StringUtils.ConvertHTMLToPlainText(prefixText)
                resultItem = StringUtils.ConvertHTMLToPlainText(resultItem)
            End If
            'Formats the resultItem and adds it to the list of suggestions.
            Dim index As Integer = resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).IndexOf(prefixText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))
            Dim itemToAdd As String = ""
            Dim isFound As Boolean = False
            Dim isAdded As Boolean = False
            ' Get the index where prfixt is at the beginning of resultItem. If not found then, index of word which begins with prefixText.
            If InvariantLCase(autoTypeAheadSearch).equals("wordsstartingwithsearchstring") And Not index = 0 Then
                ' Expression to find word which contains AutoTypeAheadWordSeparators followed by prefixText
                Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                If regex1.IsMatch(resultItem) Then
                    index = regex1.Match(resultItem).Index
                    isFound = True
                End If
                ' If the prefixText is found immediatly after white space then starting of the word is found so don not search any further
                If Not resultItem(index).ToString() = " " Then
                    ' Expression to find beginning of the word which contains AutoTypeAheadWordSeparators followed by prefixText
                    Dim regex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + AutoTypeAheadWordSeparators + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    If regex.IsMatch(resultItem) Then
                        index = regex.Match(resultItem).Index
                        isFound = True
                    End If
                End If
            End If

            ' If autoTypeAheadSearch value is wordsstartingwithsearchstring then, extract the substring only if the prefixText is found at the 
            ' beginning of the resultItem (index = 0) or a word in resultItem is found starts with prefixText. 
            If index = 0 Or isFound Or InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") Then
                If InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atbeginningofmatchedstring") Then
                    ' Expression to find beginning of the word which contains prefixText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\\S*" + prefixText, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    '  Find the beginning of the word which contains prefexText
                    If (StringUtils.InvariantLCase(autoTypeAheadSearch).Equals("anywhereinstring") AndAlso regex1.IsMatch(resultItem)) Then
                        index = regex1.Match(resultItem).Index
                        isFound = True
                    End If
                    ' Display string from the index till end of the string if sub string from index till end is less than columnLength value.
                    If Len(resultItem) - index <= columnLength Then
                        If index = 0 Then
                            itemToAdd = resultItem
                        Else                            
                            itemToAdd = resultItem.Substring(index)
                        End If
                    Else                       
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index, index + columnLength, StringUtils.Direction.forward)
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("inmiddleofmatchedstring") Then
                    Dim subStringBeginIndex As Integer = CType(columnLength / 2, Integer)
                    If Len(resultItem) <= columnLength Then
                        itemToAdd = resultItem
                    Else
                        ' Sanity check at end of the string
                        If index + Len(prefixText) >= Len(resultItem) - 1 OrElse _
                        Len(resultItem) - index < subStringBeginIndex Then                           
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, Len(resultItem) - 1 - columnLength, Len(resultItem) - 1, StringUtils.Direction.backward)
                        ElseIf index <= subStringBeginIndex Then
                            ' Sanity check at beginning of the string                          
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, 0, columnLength, StringUtils.Direction.forward)
                        Else
                            ' Display string containing text before the prefixText occures and text after the prefixText                         
                            itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - subStringBeginIndex, index - subStringBeginIndex + columnLength, StringUtils.Direction.both)
                        End If
                    End If
                ElseIf InvariantLCase(AutoTypeAheadDisplayFoundText).equals("atendofmatchedstring") Then
                    ' Expression to find ending of the word which contains prefexText
                    Dim regex1 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("\s", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    ' Find the ending of the word which contains prefexText
                    If regex1.IsMatch(resultItem, index + 1) Then
                        index = regex1.Match(resultItem, index + 1).Index
                    Else
                        ' If the word which contains prefexText is the last word in string, regex1.IsMatch returns false.
                        index = resultItem.Length
                    End If
                    If index > Len(resultItem) Then
                        index = Len(resultItem)
                    End If
                    ' If text from beginning of the string till index is less than columnLength value then, display string from the beginning till index.
                    If index <= columnLength Then
                        itemToAdd = resultItem.Substring(0, index)
                    Else
                        itemToAdd = StringUtils.GetSubstringWithWholeWords(resultItem, index - columnLength, index, StringUtils.Direction.backward)
                    End If
                End If

                ' Remove newline character from itemToAdd
                Dim prefixTextIndex As Integer = itemToAdd.IndexOf(prefixText, StringComparison.CurrentCultureIgnoreCase)
                If prefixTextIndex < 0 Then Return False
                ' If itemToAdd contains any newline after the search text then show text only till newline
                Dim regex2 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Dim newLineIndexAfterPrefix As Integer = -1
                If regex2.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexAfterPrefix = regex2.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexAfterPrefix > -1) Then
                    itemToAdd = itemToAdd.Substring(0, newLineIndexAfterPrefix)
                End If
                ' If itemToAdd contains any newline before search text then show text which comes after newline
                Dim regex3 As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(" & vbCrLf & "|" & vbLf & ")", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.RightToLeft))
                Dim newLineIndexBeforePrefix As Integer = -1
                If regex3.IsMatch(itemToAdd, prefixTextIndex) Then
                    newLineIndexBeforePrefix = regex3.Match(itemToAdd, prefixTextIndex).Index
                End If
                If (newLineIndexBeforePrefix > -1) Then
                    itemToAdd = itemToAdd.Substring((newLineIndexBeforePrefix + regex3.Match(itemToAdd, prefixTextIndex).Length))
                End If

                If Not String.IsNullOrEmpty(itemToAdd) AndAlso Not resultList.Contains(itemToAdd) Then
                    resultList.Add(itemToAdd)
                    isAdded = True
                End If
            End If
            Return isAdded
        End Function
        
    

        ' To customize, override this method in RoleRecordControl.
        Public Overridable Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
                
        End Sub

        Public Overridable Sub Delete()
        
            If Me.IsNewRecord() Then
                Return
            End If

            Dim pkValue As KeyValue = KeyValue.XmlToKey(Me.RecordUniqueId)
          RoleTable.DeleteRecord(pkValue)
          
        End Sub

        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction()
                Me.RegisterPostback()

                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Me.LoadData()
                    Me.DataBind()			
                End If
                                
                						
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction()
            End Try
        End Sub
        
            
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()
        
    
            'Save pagination state to session.
          
        End Sub
        
        
    
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

        

            ' Clear pagination state from session.
        
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim isNewRecord As String = CType(ViewState("IsNewRecord"), String)
            If Not isNewRecord Is Nothing AndAlso isNewRecord.Trim <> "" Then
                Me.IsNewRecord = Boolean.Parse(isNewRecord)
            End If
            
            Dim myCheckSum As String = CType(ViewState("CheckSum"), String)
            If Not myCheckSum Is Nothing AndAlso myCheckSum.Trim <> "" Then
                Me.CheckSum = myCheckSum
            End If
            
    
            ' Load view state for pagination control.
                 
        End Sub

        Protected Overrides Function SaveViewState() As Object
            ViewState("IsNewRecord") = Me.IsNewRecord.ToString()
            ViewState("CheckSum") = Me.CheckSum
            
    
            ' Load view state for pagination control.
                  
            Return MyBase.SaveViewState()
        End Function
        
        
        ' Generate the event handling functions for pagination events.
            
      
        ' Generate the event handling functions for filter and search events.
            
        Protected Overridable Sub Role_Email_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Role_Name_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
   
        Private _PreviousUIData As New Hashtable
        Public Overridable Property PreviousUIData() As Hashtable
            Get
                Return _PreviousUIData
            End Get
            Set(ByVal value As Hashtable)
                _PreviousUIData = value
            End Set
        End Property   
   
        Private _IsNewRecord As Boolean = True
        Public Overridable Property IsNewRecord() As Boolean
            Get
                Return Me._IsNewRecord
            End Get
            Set(ByVal value As Boolean)
                Me._IsNewRecord = value
            End Set
        End Property

        Private _DataChanged As Boolean = False
        Public Overridable Property DataChanged() As Boolean
            Get
                Return Me._DataChanged
            End Get
            Set(ByVal Value As Boolean)
                Me._DataChanged = Value
            End Set
        End Property

        Private _ResetData As Boolean = False
        Public Overridable Property ResetData() As Boolean
            Get
                Return Me._ResetData
            End Get
            Set(ByVal Value As Boolean)
                Me._ResetData = Value
            End Set
        End Property
        
        Public Property RecordUniqueId() As String
            Get
                Return CType(Me.ViewState("BaseRoleRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseRoleRecordControl_Rec") = value
            End Set
        End Property
        
        Private _DataSource As RoleRecord
        Public Property DataSource() As RoleRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As RoleRecord)
            
                Me._DataSource = value
            End Set
        End Property

        

        Private _checkSum As String
        Public Overridable Property CheckSum() As String
            Get
                Return Me._checkSum
            End Get
            Set(ByVal value As String)
                Me._checkSum = value
            End Set
        End Property
        
        Private _TotalPages As Integer
        Public Property TotalPages() As Integer
            Get
                Return Me._TotalPages
            End Get
            Set(ByVal value As Integer)
                Me._TotalPages = value
            End Set
        End Property
        
        Private _PageIndex As Integer
        Public Property PageIndex() As Integer
            Get
                ' Return the PageIndex
                Return Me._PageIndex
            End Get
            Set(ByVal value As Integer)
                Me._PageIndex = value
            End Set
        End Property
    
        Private _PageSize As Integer
        Public Property PageSize() As Integer
            Get
                Return Me._PageSize
            End Get
            Set(ByVal value As Integer)
                Me._PageSize = value
            End Set
        End Property
    
        Private _TotalRecords As Integer
        Public Property TotalRecords() As Integer
            Get
                Return Me._TotalRecords
            End Get
            Set(ByVal value As Integer)
                If Me.PageSize > 0 Then
                    Me.TotalPages = CInt(Math.Ceiling(value / Me.PageSize))
                End If

                Me._TotalRecords = value
            End Set
        End Property
        
        Private _DisplayLastPage As Boolean
        Public Property DisplayLastPage() As Boolean
            Get
                Return Me._DisplayLastPage
            End Get
            Set(ByVal value As Boolean)
                Me._DisplayLastPage = value
            End Set
        End Property
        
        

#Region "Helper Properties"
        
        Public ReadOnly Property Role_Email() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Role_Email"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Role_EmailLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Role_EmailLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Role_Name() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Role_Name"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Role_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Role_NameLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property RoleTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "RoleTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
#End Region

#Region "Helper Functions"

        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function
        
        Public Overrides Overloads Function ModifyRedirectUrl(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean, ByVal includeSession As Boolean) As String
            Return Me.Page.EvaluateExpressions(url, arg, bEncrypt, Me)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean) As String
            
            Dim rec As RoleRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            Return EvaluateExpressions(url, arg, rec, bEncrypt)
        End Function

        Public Overrides Overloads Function EvaluateExpressions(ByVal url As String, ByVal arg As String, ByVal bEncrypt As Boolean,ByVal includeSession as Boolean) As String
            
            Dim rec As RoleRecord = Nothing
             
        
            Try
                rec = Me.GetRecord()
            Catch ex As Exception
                ' Do nothing
            End Try

            If rec Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                ' Localization.
                
            Throw New Exception(Page.GetResourceValue("Err:RecDataSrcNotInitialized", "IROC2"))
                    
            End If
            If includeSession  Then
                Return EvaluateExpressions(url, arg, rec, bEncrypt)
            Else
                Return EvaluateExpressions(url, arg, rec, bEncrypt,False)  
            End If
        End Function

         
        Public Overridable Function GetRecord() As RoleRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return RoleTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Throw New Exception(Page.GetResourceValue("Err:RetrieveRec", "IROC2"))
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

#End Region
    
  
End Namespace

  