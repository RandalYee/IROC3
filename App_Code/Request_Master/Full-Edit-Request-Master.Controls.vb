
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Full_Edit_Request_Master.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Full_Edit_Request_Master

#Region "Section 1: Place your customizations here."

    
Public Class CommentsTableControlRow
        Inherits BaseCommentsTableControlRow
        ' The BaseCommentsTableControlRow implements code for a ROW within the
        ' the CommentsTableControl table.  The BaseCommentsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of CommentsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class CommentsTableControl
        Inherits BaseCommentsTableControl

    ' The BaseCommentsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The CommentsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  
Public Class ContactsTableControlRow
        Inherits BaseContactsTableControlRow
        ' The BaseContactsTableControlRow implements code for a ROW within the
        ' the ContactsTableControl table.  The BaseContactsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of ContactsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class ContactsTableControl
        Inherits BaseContactsTableControl

    ' The BaseContactsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The ContactsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  
Public Class UploadsTableControlRow
        Inherits BaseUploadsTableControlRow
        ' The BaseUploadsTableControlRow implements code for a ROW within the
        ' the UploadsTableControl table.  The BaseUploadsTableControlRow implements the DataBind and SaveData methods.
        ' The loading of data is actually performed by the LoadData method in the base class of UploadsTableControl.

        ' This is the ideal place to add your code customizations. For example, you can override the DataBind, 
        ' SaveData, GetUIData, and Validate methods.
        

End Class

  

Public Class UploadsTableControl
        Inherits BaseUploadsTableControl

    ' The BaseUploadsTableControl class implements the LoadData, DataBind, CreateWhereClause
    ' and other methods to load and display the data in a table control.

    ' This is the ideal place to add your code customizations. You can override the LoadData and CreateWhereClause,
    ' The UploadsTableControlRow class offers another place where you can customize
    ' the DataBind, GetUIData, SaveData and Validate methods specific to each row displayed on the table.

End Class

  
Public Class Request_MasterRecordControl
        Inherits BaseRequest_MasterRecordControl
        ' The BaseRequest_MasterRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

End Class

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the CommentsTableControlRow control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in CommentsTableControlRow.
Public Class BaseCommentsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in CommentsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in CommentsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
        
              ' Show confirmation message on Click
              Me.CommentsRowDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteRecordConfirm", "IROC2") & """));")
                  
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.CommentsRowDeleteButton.Click, AddressOf CommentsRowDeleteButton_Click
              
              AddHandler Me.CommentsRowEditButton.Click, AddressOf CommentsRowEditButton_Click
              
              AddHandler Me.Comment_Topic.SelectedIndexChanged, AddressOf Comment_Topic_SelectedIndexChanged
            
              AddHandler Me.Agency.TextChanged, AddressOf Agency_TextChanged
            
              AddHandler Me.Comment.TextChanged, AddressOf Comment_TextChanged
            
              AddHandler Me.Comment_Dt.TextChanged, AddressOf Comment_Dt_TextChanged
            
              AddHandler Me.Comment_To_Agency.TextChanged, AddressOf Comment_To_Agency_TextChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Comments record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = CommentsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseCommentsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New CommentsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in CommentsTableControlRow.
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
        
                SetAgency()
                SetComment()
                SetComment_Dt()
                SetComment_To_Agency()
                SetComment_Topic()
                
                
                
      
      
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
        
        
        Public Overridable Sub SetAgency()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Agency.ID) Then
            
                Me.Agency.Text = Me.PreviousUIData(Me.Agency.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Agency is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Agency)
                              
                Me.Agency.Text = formattedValue
                
            Else 
            
                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Agency.Text = EvaluateFormula("Session(""MyPending_Agency1SessionVariable"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Comment.ID) Then
            
                Me.Comment.Text = Me.PreviousUIData(Me.Comment.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Comment TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CommentSpecified Then
                				
                ' If the Comment is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment)
                              
                Me.Comment.Text = formattedValue
                
            Else 
            
                ' Comment is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment.Text = CommentsTable.Comment.Format(CommentsTable.Comment.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_Dt()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Comment_Dt.ID) Then
            
                Me.Comment_Dt.Text = Me.PreviousUIData(Me.Comment_Dt.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Comment_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Comment_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_Dt, "g")
                              
                Me.Comment_Dt.Text = formattedValue
                
            Else 
            
                ' Comment_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_Dt.Text = EvaluateFormula("Format(Today(), ""d"")", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_To_Agency()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Comment_To_Agency.ID) Then
            
                Me.Comment_To_Agency.Text = Me.PreviousUIData(Me.Comment_To_Agency.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Comment_To_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_To_Agency is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_To_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Comment_To_AgencySpecified Then
                				
                ' If the Comment_To_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_To_Agency)
                              
                Me.Comment_To_Agency.Text = formattedValue
                
            Else 
            
                ' Comment_To_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_To_Agency.Text = CommentsTable.Comment_To_Agency.Format(CommentsTable.Comment_To_Agency.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_Topic()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            							
            ' If selection was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Comment_Topic.ID) Then
                If Me.PreviousUIData(Me.Comment_Topic.ID) Is Nothing
                    selectedValue = Nothing
                Else
                    selectedValue = Me.PreviousUIData(Me.Comment_Topic.ID).ToString()
                End If
            End If
            
        
            ' Set the Comment_Topic DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_Topic is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_Topic()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Comment_TopicSpecified Then
                            
                ' If the Comment_Topic is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Comment_Topic
            Else
                
                ' Comment_Topic is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = CommentsTable.Comment_Topic.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateComment_TopicDropDownList(selectedValue, 100)              
                        
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

      
        
        ' To customize, override this method in CommentsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
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
              
                DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in CommentsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetAgency()
            GetComment()
            GetComment_Dt()
            GetComment_To_Agency()
            GetComment_Topic()
        End Sub
        
        
        Public Overridable Sub GetAgency()
            
            ' Retrieve the value entered by the user on the Agency ASP:TextBox, and
            ' save it into the Agency field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Agency.Text, CommentsTable.Agency)			

                      
        End Sub
                
        Public Overridable Sub GetComment()
            
            ' Retrieve the value entered by the user on the Comment ASP:TextBox, and
            ' save it into the Comment field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment.Text, CommentsTable.Comment)			

                      
        End Sub
                
        Public Overridable Sub GetComment_Dt()
            
            ' Retrieve the value entered by the user on the Comment_Dt ASP:TextBox, and
            ' save it into the Comment_Dt field in DataSource DatabaseIROC%dbo.Comments record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment_Dt.Text, CommentsTable.Comment_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetComment_To_Agency()
            
            ' Retrieve the value entered by the user on the Comment_To_Agency ASP:TextBox, and
            ' save it into the Comment_To_Agency field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment_To_Agency.Text, CommentsTable.Comment_To_Agency)			

                      
        End Sub
                
        Public Overridable Sub GetComment_Topic()
         
            ' Retrieve the value entered by the user on the Comment_Topic ASP:DropDownList, and
            ' save it into the Comment_Topic field in DataSource DatabaseIROC%dbo.Comments record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Comment_Topic), CommentsTable.Comment_Topic)				
            
        End Sub
                
      
        ' To customize, override this method in CommentsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in CommentsTableControlRow.
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
          CommentsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl).ResetData = True
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
                                
                
			Me.Page.Authorize(Ctype(CommentsRowDeleteButton, Control), "1;4")
					
			Me.Page.Authorize(Ctype(CommentsRowEditButton, Control), "1;4")
											
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
        
        
                        
        Public Overridable Function CreateWhereClause_Comment_TopicDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            						
            ' This WhereClause is for the DatabaseIROC%dbo.Comments table.
            ' Examples:
            ' wc.iAND(CommentsTable.Comment_Topic, BaseFilter.ComparisonOperator.EqualsTo, "XYZ")
            ' wc.iAND(CommentsTable.Active, BaseFilter.ComparisonOperator.EqualsTo, "1")
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
        ' Fill the Comment_Topic list.
        Protected Overridable Sub PopulateComment_TopicDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Comment_Topic.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("More Info Needed"), "More Info Needed"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Info Provided"), "Info Provided"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Question Asked"), "Question Asked"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Question Answered"), "Question Answerd"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Quote"), "Quote"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("FYI"), "FYI"))
                            							
            Me.Comment_Topic.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Other"), "Other"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Comment_Topic, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Comment_Topic, selectedValue)Then

                ' construct a whereclause to query a record with DatabaseIROC%dbo.Comments.Comment_Topic = selectedValue
                Dim filter2 As CompoundFilter = New CompoundFilter(CompoundFilter.CompoundingOperators.And_Operator, Nothing)
                Dim whereClause2 As WhereClause = New WhereClause()
                filter2.AddFilter(New BaseClasses.Data.ColumnValueFilter(CommentsTable.Comment_Topic, selectedValue, BaseClasses.Data.BaseFilter.ComparisonOperator.EqualsTo, False))
                whereClause2.AddFilter(filter2, CompoundFilter.CompoundingOperators.And_Operator)

                Try
                    ' Execute the query
                    Dim rc() As CommentsRecord = CommentsTable.GetRecords(whereClause2, New OrderBy(False, False), 0, 1)
                      Dim vars As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)
                      ' if find a record, add it to the dropdown and set it as selected item
                      If rc IsNot Nothing AndAlso rc.Length = 1 Then
                      Dim itemValue As CommentsRecord = DirectCast(rc(0), CommentsRecord)
                        ' Create the item and add to the list.
                        Dim cvalue As String = Nothing
                        Dim fvalue As String = Nothing
                        If itemValue.Comment_TopicSpecified Then
                            cvalue = itemValue.Comment_Topic.ToString() 
                          Dim evaluator2 As New FormulaEvaluator
                          Dim variables2 As New System.Collections.Generic.Dictionary(Of String, Object)
                          


                          variables2.Add(itemValue.TableAccess.TableDefinition.TableCodeName, itemValue)
                          
                          fvalue = EvaluateFormula("Comment_Topic", itemValue, variables2, evaluator2)
                        
                              If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = cvalue
                              ResetSelectedItem(Me.Comment_Topic, New ListItem(fvalue, cvalue))
                            End If
                        End If
                Catch
                End Try

            End If					
                        
                
        End Sub
        
              
        ' event handler for ImageButton
        Public Overridable Sub CommentsRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Dim tc As CommentsTableControl = DirectCast(GetParentControlObject(Me, "CommentsTableControl"), CommentsTableControl)
                If Not (IsNothing(tc)) Then
                    If Not Me.IsNewRecord Then
                        tc.AddToDeletedRecordIds(DirectCast(Me, CommentsTableControlRow))
                    End If
                    Me.Visible = False
                    tc.SetFormulaControls()
                End If
              
            End If
      
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
        Public Overridable Sub CommentsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Comments/Edit-Comments.aspx?Comments={PK}"
                
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
        
        Protected Overridable Sub Comment_Topic_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Comment_Topic.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Comment_Topic.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Comment_Topic.Items.Add(New ListItem(displayText, val))
                Me.Comment_Topic.SelectedIndex = Me.Comment_Topic.Items.Count - 1
                Me.Page.Session.Remove(Comment_Topic.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Comment_Topic.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_To_Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseCommentsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseCommentsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As CommentsRecord
        Public Property DataSource() As CommentsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As CommentsRecord)
            
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
        
        Public ReadOnly Property Agency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Comment() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Comment_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Comment_To_Agency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_To_Agency"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Comment_Topic() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Topic"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property CommentsRecordRowSelection() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsRecordRowSelection"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property CommentsRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsRowEditButton"), System.Web.UI.WebControls.ImageButton)
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
            
            Dim rec As CommentsRecord = Nothing
             
        
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
            
            Dim rec As CommentsRecord = Nothing
             
        
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

         
        Public Overridable Function GetRecord() As CommentsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return CommentsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the CommentsTableControl control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in CommentsTableControl.
Public Class BaseCommentsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(CommentsTable.Comment_ID, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
              ' Show confirmation message on Click
              Me.CommentsDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteConfirm", "IROC2") & """));")
      
            ' Setup the pagination events.
            
              AddHandler Me.CommentsPagination.FirstPage.Click, AddressOf CommentsPagination_FirstPage_Click
              
              AddHandler Me.CommentsPagination.LastPage.Click, AddressOf CommentsPagination_LastPage_Click
              
              AddHandler Me.CommentsPagination.NextPage.Click, AddressOf CommentsPagination_NextPage_Click
              
              AddHandler Me.CommentsPagination.PageSizeButton.Click, AddressOf CommentsPagination_PageSizeButton_Click
            
              AddHandler Me.CommentsPagination.PreviousPage.Click, AddressOf CommentsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.AgencyLabel.Click, AddressOf AgencyLabel_Click
            
              AddHandler Me.Comment_DtLabel.Click, AddressOf Comment_DtLabel_Click
            
              AddHandler Me.Comment_To_AgencyLabel.Click, AddressOf Comment_To_AgencyLabel_Click
            
              AddHandler Me.Comment_TopicLabel.Click, AddressOf Comment_TopicLabel_Click
            
              AddHandler Me.CommentLabel.Click, AddressOf CommentLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.CommentsAddButton.Click, AddressOf CommentsAddButton_Click
              
              AddHandler Me.CommentsDeleteButton.Click, AddressOf CommentsDeleteButton_Click
                      
        
          ' Setup events for others
            
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
                    Me.DataSource = DirectCast(alist.ToArray(GetType(CommentsRecord)), CommentsRecord())
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
                    For Each rc As CommentsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(CommentsRecord)), CommentsRecord())
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
            ByVal pageSize As Integer) As CommentsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(CommentsTable.Column1, True)         
            ' selCols.Add(CommentsTable.Column2, True)          
            ' selCols.Add(CommentsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return CommentsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New CommentsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(CommentsRecord)), CommentsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(CommentsTable.Column1, True)         
            ' selCols.Add(CommentsTable.Column2, True)          
            ' selCols.Add(CommentsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return CommentsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New CommentsTable
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
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetAgencyLabel()
                SetComment_DtLabel()
                SetComment_To_AgencyLabel()
                SetComment_TopicLabel()
                SetCommentLabel()
                
                
                
                
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
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(CommentsTable.Comment_ID, OrderByItem.OrderDir.Asc)
                  
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
                    
                Me.CommentsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.CommentsPagination.CurrentPage.Text = "0"
            End If
            Me.CommentsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.CommentsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for CommentsTableControl pagination.
        
            Me.CommentsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.CommentsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.CommentsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.CommentsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As CommentsTableControlRow
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
            CommentsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(CommentsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(CommentsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc
                End If
              
      HttpContext.Current.Session("CommentsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            CommentsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("CommentsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(CommentsTable.Request_Id) Then
            wc.iAND(CommentsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(CommentsTable.Request_Id).ToString())
       End If
      
            End If
          
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
        
            If Me.CommentsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.CommentsPagination.PageSize.Text)
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
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As CommentsRecord = New CommentsRecord()
        
                        If recControl.Agency.Text <> "" Then
                            rec.Parse(recControl.Agency.Text, CommentsTable.Agency)
                        End If
                        If recControl.Comment.Text <> "" Then
                            rec.Parse(recControl.Comment.Text, CommentsTable.Comment)
                        End If
                        If recControl.Comment_Dt.Text <> "" Then
                            rec.Parse(recControl.Comment_Dt.Text, CommentsTable.Comment_Dt)
                        End If
                        If recControl.Comment_To_Agency.Text <> "" Then
                            rec.Parse(recControl.Comment_To_Agency.Text, CommentsTable.Comment_To_Agency)
                        End If
                        If MiscUtils.IsValueSelected(recControl.Comment_Topic) Then
                            rec.Parse(recControl.Comment_Topic.SelectedItem.Value, CommentsTable.Comment_Topic)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New CommentsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(CommentsRecord)), CommentsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As CommentsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As CommentsTableControlRow) As Boolean
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
        
        Public Overridable Sub SetAgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_To_AgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_To_AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetComment_TopicLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Comment_TopicLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCommentLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.CommentLabel.Text = "Some value"
                    
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
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
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("CommentsTableControl_OrderBy"), String)
            
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
                Me.ViewState("CommentsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub CommentsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub CommentsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub CommentsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.CommentsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.CommentsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub CommentsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        
        Public Overridable Sub AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Agency when clicked.
              
            ' Get previous sorting state for Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_Dt when clicked.
              
            ' Get previous sorting state for Comment_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_To_AgencyLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_To_Agency when clicked.
              
            ' Get previous sorting state for Comment_To_Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_To_Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_To_Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_To_Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_To_Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Comment_TopicLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment_Topic when clicked.
              
            ' Get previous sorting state for Comment_Topic.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment_Topic)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment_Topic.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment_Topic, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment_Topic, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub CommentLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Comment when clicked.
              
            ' Get previous sorting state for Comment.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(CommentsTable.Comment)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Comment.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(CommentsTable.Comment, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Comment, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub CommentsAddButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Me.AddNewRecord = 1
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
        Public Overridable Sub CommentsDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Me.DeleteSelectedRecords(True)
                Me.SetFormulaControls()
                
          
            End If
      
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
                    _TotalRecords = CommentsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
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
        
        Public Property DataSource() As CommentsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, CommentsRecord())
            End Get
            Set(ByVal value() As CommentsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_To_AgencyLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_To_AgencyLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Comment_TopicLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_TopicLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsAddButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsAddButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property CommentsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property CommentsToggleAll() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsToggleAll"), System.Web.UI.WebControls.CheckBox)
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
                Dim recCtl As CommentsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As CommentsRecord = Nothing     
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
                Dim recCtl As CommentsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As CommentsRecord = Nothing     
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
            Dim recControl As CommentsTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.CommentsRecordRowSelection.Checked Then
                    Return counter
                End If
                counter += 1
            Next
            Return -1
        End Function
        
        Public Overridable Function GetSelectedRecordControl() As CommentsTableControlRow
            Dim selectedList() As CommentsTableControlRow = Me.GetSelectedRecordControls()
            If selectedList.Length = 0 Then
                Return Nothing
            End If
            Return selectedList(0)
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As CommentsTableControlRow()
        
            Dim selectedList As ArrayList = New ArrayList(25)
            Dim recControl As CommentsTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.CommentsRecordRowSelection IsNot Nothing AndAlso recControl.CommentsRecordRowSelection.Checked Then
                    selectedList.Add(recControl)
                End If
            Next
            Return DirectCast(selectedList.ToArray(GetType(CommentsTableControlRow)), CommentsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As CommentsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As CommentsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                    recCtl.CommentsRecordRowSelection.Checked = False
                
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

        Public Function GetRecordControls() As CommentsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("CommentsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As CommentsTableControlRow = DirectCast(repItem.FindControl("CommentsTableControlRow"), CommentsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(CommentsTableControlRow)), CommentsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the ContactsTableControlRow control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in ContactsTableControlRow.
Public Class BaseContactsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in ContactsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in ContactsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
        
              ' Show confirmation message on Click
              Me.ContactsRowDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteRecordConfirm", "IROC2") & """));")
                  
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.ContactsRowDeleteButton.Click, AddressOf ContactsRowDeleteButton_Click
              
              AddHandler Me.ContactsRowEditButton.Click, AddressOf ContactsRowEditButton_Click
              
              AddHandler Me.Address.TextChanged, AddressOf Address_TextChanged
            
              AddHandler Me.Agency1.TextChanged, AddressOf Agency1_TextChanged
            
              AddHandler Me.City.TextChanged, AddressOf City_TextChanged
            
              AddHandler Me.Email.TextChanged, AddressOf Email_TextChanged
            
              AddHandler Me.Mobile.TextChanged, AddressOf Mobile_TextChanged
            
              AddHandler Me.Name.TextChanged, AddressOf Name_TextChanged
            
              AddHandler Me.Title.TextChanged, AddressOf Title_TextChanged
            
              AddHandler Me.Type0.TextChanged, AddressOf Type0_TextChanged
            
              AddHandler Me.Work_Phone.TextChanged, AddressOf Work_Phone_TextChanged
            
              AddHandler Me.Zip.TextChanged, AddressOf Zip_TextChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Contacts record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = ContactsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseContactsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New ContactsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in ContactsTableControlRow.
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
        
                SetAddress()
                SetAgency1()
                SetCity()
                
                
                
                SetEmail()
                SetMobile()
                SetName()
                SetTitle()
                SetType0()
                SetWork_Phone()
                SetZip()
      
      
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
        
        
        Public Overridable Sub SetAddress()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Address.ID) Then
            
                Me.Address.Text = Me.PreviousUIData(Me.Address.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Address TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Address is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAddress()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AddressSpecified Then
                				
                ' If the Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Address)
                              
                Me.Address.Text = formattedValue
                
            Else 
            
                ' Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Address.Text = ContactsTable.Address.Format(ContactsTable.Address.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetAgency1()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Agency1.ID) Then
            
                Me.Agency1.Text = Me.PreviousUIData(Me.Agency1.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Agency1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetAgency1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.AgencySpecified Then
                				
                ' If the Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Agency)
                              
                Me.Agency1.Text = formattedValue
                
            Else 
            
                ' Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Agency1.Text = ContactsTable.Agency.Format(ContactsTable.Agency.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCity()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.City.ID) Then
            
                Me.City.Text = Me.PreviousUIData(Me.City.ID).ToString()
              
                Return
            End If
            
        
            ' Set the City TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.City is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCity()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.CitySpecified Then
                				
                ' If the City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.City)
                              
                Me.City.Text = formattedValue
                
            Else 
            
                ' City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.City.Text = ContactsTable.City.Format(ContactsTable.City.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetEmail()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Email.ID) Then
            
                Me.Email.Text = Me.PreviousUIData(Me.Email.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Email TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Email is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetEmail()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.EmailSpecified Then
                				
                ' If the Email is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Email)
                              
                Me.Email.Text = formattedValue
                
            Else 
            
                ' Email is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Email.Text = ContactsTable.Email.Format(ContactsTable.Email.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetMobile()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Mobile.ID) Then
            
                Me.Mobile.Text = Me.PreviousUIData(Me.Mobile.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Mobile TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Mobile is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetMobile()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.MobileSpecified Then
                				
                ' If the Mobile is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Mobile)
                              
                Me.Mobile.Text = formattedValue
                
            Else 
            
                ' Mobile is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Mobile.Text = ContactsTable.Mobile.Format(ContactsTable.Mobile.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetName()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Name.ID) Then
            
                Me.Name.Text = Me.PreviousUIData(Me.Name.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Name is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetName()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.NameSpecified Then
                				
                ' If the Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Name)
                              
                Me.Name.Text = formattedValue
                
            Else 
            
                ' Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Name.Text = ContactsTable.Name.Format(ContactsTable.Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetTitle()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Title.ID) Then
            
                Me.Title.Text = Me.PreviousUIData(Me.Title.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Title TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Title is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetTitle()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.TitleSpecified Then
                				
                ' If the Title is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Title)
                              
                Me.Title.Text = formattedValue
                
            Else 
            
                ' Title is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Title.Text = ContactsTable.Title.Format(ContactsTable.Title.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetType0()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Type0.ID) Then
            
                Me.Type0.Text = Me.PreviousUIData(Me.Type0.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Type TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Type0 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetType0()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Type0Specified Then
                				
                ' If the Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Type0)
                              
                Me.Type0.Text = formattedValue
                
            Else 
            
                ' Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Type0.Text = ContactsTable.Type0.Format(ContactsTable.Type0.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetWork_Phone()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Work_Phone.ID) Then
            
                Me.Work_Phone.Text = Me.PreviousUIData(Me.Work_Phone.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Work Phone TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Work_Phone is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetWork_Phone()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Work_PhoneSpecified Then
                				
                ' If the Work Phone is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Work_Phone)
                              
                Me.Work_Phone.Text = formattedValue
                
            Else 
            
                ' Work Phone is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Work_Phone.Text = ContactsTable.Work_Phone.Format(ContactsTable.Work_Phone.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetZip()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.Zip.ID) Then
            
                Me.Zip.Text = Me.PreviousUIData(Me.Zip.ID).ToString()
              
                Return
            End If
            
        
            ' Set the Zip TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Contacts database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Contacts record retrieved from the database.
            ' Me.Zip is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetZip()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ZipSpecified Then
                				
                ' If the Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(ContactsTable.Zip)
                              
                Me.Zip.Text = formattedValue
                
            Else 
            
                ' Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Zip.Text = ContactsTable.Zip.Format(ContactsTable.Zip.DefaultValue)
                        		
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

      
        
        ' To customize, override this method in ContactsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
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
              
                DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in ContactsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetAddress()
            GetAgency1()
            GetCity()
            GetEmail()
            GetMobile()
            GetName()
            GetTitle()
            GetType0()
            GetWork_Phone()
            GetZip()
        End Sub
        
        
        Public Overridable Sub GetAddress()
            
            ' Retrieve the value entered by the user on the Address ASP:TextBox, and
            ' save it into the Address field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Address.Text, ContactsTable.Address)			

                      
        End Sub
                
        Public Overridable Sub GetAgency1()
            
            ' Retrieve the value entered by the user on the Agency ASP:TextBox, and
            ' save it into the Agency field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Agency1.Text, ContactsTable.Agency)			

                      
        End Sub
                
        Public Overridable Sub GetCity()
            
            ' Retrieve the value entered by the user on the City ASP:TextBox, and
            ' save it into the City field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.City.Text, ContactsTable.City)			

                      
        End Sub
                
        Public Overridable Sub GetEmail()
            
            ' Retrieve the value entered by the user on the Email ASP:TextBox, and
            ' save it into the Email field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Email.Text, ContactsTable.Email)			

                      
        End Sub
                
        Public Overridable Sub GetMobile()
            
            ' Retrieve the value entered by the user on the Mobile ASP:TextBox, and
            ' save it into the Mobile field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Mobile.Text, ContactsTable.Mobile)			

                      
        End Sub
                
        Public Overridable Sub GetName()
            
            ' Retrieve the value entered by the user on the Name ASP:TextBox, and
            ' save it into the Name field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Name.Text, ContactsTable.Name)			

                      
        End Sub
                
        Public Overridable Sub GetTitle()
            
            ' Retrieve the value entered by the user on the Title ASP:TextBox, and
            ' save it into the Title field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Title.Text, ContactsTable.Title)			

                      
        End Sub
                
        Public Overridable Sub GetType0()
            
            ' Retrieve the value entered by the user on the Type ASP:TextBox, and
            ' save it into the Type field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Type0.Text, ContactsTable.Type0)			

                      
        End Sub
                
        Public Overridable Sub GetWork_Phone()
            
            ' Retrieve the value entered by the user on the Work Phone ASP:TextBox, and
            ' save it into the Work Phone field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Work_Phone.Text, ContactsTable.Work_Phone)			

                      
        End Sub
                
        Public Overridable Sub GetZip()
            
            ' Retrieve the value entered by the user on the Zip ASP:TextBox, and
            ' save it into the Zip field in DataSource DatabaseIROC%dbo.Contacts record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Zip.Text, ContactsTable.Zip)			

                      
        End Sub
                
      
        ' To customize, override this method in ContactsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in ContactsTableControlRow.
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
          ContactsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl).ResetData = True
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
                                
                
			Me.Page.Authorize(Ctype(ContactsRowDeleteButton, Control), "1;4")
					
			Me.Page.Authorize(Ctype(ContactsRowEditButton, Control), "1;4")
											
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
        
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Dim tc As ContactsTableControl = DirectCast(GetParentControlObject(Me, "ContactsTableControl"), ContactsTableControl)
                If Not (IsNothing(tc)) Then
                    If Not Me.IsNewRecord Then
                        tc.AddToDeletedRecordIds(DirectCast(Me, ContactsTableControlRow))
                    End If
                    Me.Visible = False
                    tc.SetFormulaControls()
                End If
              
            End If
      
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
        Public Overridable Sub ContactsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Contacts/Edit-Contacts.aspx?Contacts={PK}"
                
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
        
        Protected Overridable Sub Address_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Agency1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub City_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Email_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Mobile_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Name_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Title_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Type0_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Work_Phone_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Zip_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseContactsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseContactsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As ContactsRecord
        Public Property DataSource() As ContactsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As ContactsRecord)
            
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
        
        Public ReadOnly Property Address() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Address"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Agency1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property City() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "City"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property ContactsRecordRowSelection() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRecordRowSelection"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ContactsRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsRowEditButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property Email() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Email"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Mobile() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Mobile"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Name() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Name"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Title() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Title"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Type0() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Type0"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Work_Phone() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Work_Phone"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Zip() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Zip"), System.Web.UI.WebControls.TextBox)
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
            
            Dim rec As ContactsRecord = Nothing
             
        
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
            
            Dim rec As ContactsRecord = Nothing
             
        
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

         
        Public Overridable Function GetRecord() As ContactsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return ContactsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the ContactsTableControl control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in ContactsTableControl.
Public Class BaseContactsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(ContactsTable.Contact_Id, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
              ' Show confirmation message on Click
              Me.ContactsDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteConfirm", "IROC2") & """));")
      
            ' Setup the pagination events.
            
              AddHandler Me.ContactsPagination.FirstPage.Click, AddressOf ContactsPagination_FirstPage_Click
              
              AddHandler Me.ContactsPagination.LastPage.Click, AddressOf ContactsPagination_LastPage_Click
              
              AddHandler Me.ContactsPagination.NextPage.Click, AddressOf ContactsPagination_NextPage_Click
              
              AddHandler Me.ContactsPagination.PageSizeButton.Click, AddressOf ContactsPagination_PageSizeButton_Click
            
              AddHandler Me.ContactsPagination.PreviousPage.Click, AddressOf ContactsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.AddressLabel.Click, AddressOf AddressLabel_Click
            
              AddHandler Me.AgencyLabel2.Click, AddressOf AgencyLabel2_Click
            
              AddHandler Me.CityLabel.Click, AddressOf CityLabel_Click
            
              AddHandler Me.EmailLabel.Click, AddressOf EmailLabel_Click
            
              AddHandler Me.MobileLabel.Click, AddressOf MobileLabel_Click
            
              AddHandler Me.NameLabel.Click, AddressOf NameLabel_Click
            
              AddHandler Me.TitleLabel.Click, AddressOf TitleLabel_Click
            
              AddHandler Me.TypeLabel.Click, AddressOf TypeLabel_Click
            
              AddHandler Me.Work_PhoneLabel.Click, AddressOf Work_PhoneLabel_Click
            
              AddHandler Me.ZipLabel.Click, AddressOf ZipLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.ContactsAddButton.Click, AddressOf ContactsAddButton_Click
              
              AddHandler Me.ContactsDeleteButton.Click, AddressOf ContactsDeleteButton_Click
                      
        
          ' Setup events for others
            
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
                    Me.DataSource = DirectCast(alist.ToArray(GetType(ContactsRecord)), ContactsRecord())
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
                    For Each rc As ContactsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(ContactsRecord)), ContactsRecord())
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
            ByVal pageSize As Integer) As ContactsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(ContactsTable.Column1, True)         
            ' selCols.Add(ContactsTable.Column2, True)          
            ' selCols.Add(ContactsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return ContactsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New ContactsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(ContactsRecord)), ContactsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(ContactsTable.Column1, True)         
            ' selCols.Add(ContactsTable.Column2, True)          
            ' selCols.Add(ContactsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return ContactsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New ContactsTable
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
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetAddressLabel()
                SetAgencyLabel2()
                SetCityLabel()
                
                
                
                
                SetEmailLabel()
                SetMobileLabel()
                SetNameLabel()
                SetTitleLabel()
                SetTypeLabel()
                SetWork_PhoneLabel()
                SetZipLabel()
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
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(ContactsTable.Contact_Id, OrderByItem.OrderDir.Asc)
                  
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
                    
                Me.ContactsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.ContactsPagination.CurrentPage.Text = "0"
            End If
            Me.ContactsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.ContactsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for ContactsTableControl pagination.
        
            Me.ContactsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.ContactsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.ContactsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.ContactsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As ContactsTableControlRow
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
            ContactsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(ContactsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(ContactsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc
                End If
              
      HttpContext.Current.Session("ContactsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            ContactsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("ContactsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(ContactsTable.Request_Id) Then
            wc.iAND(ContactsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(ContactsTable.Request_Id).ToString())
       End If
      
            End If
          
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
        
            If Me.ContactsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.ContactsPagination.PageSize.Text)
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
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As ContactsRecord = New ContactsRecord()
        
                        If recControl.Address.Text <> "" Then
                            rec.Parse(recControl.Address.Text, ContactsTable.Address)
                        End If
                        If recControl.Agency1.Text <> "" Then
                            rec.Parse(recControl.Agency1.Text, ContactsTable.Agency)
                        End If
                        If recControl.City.Text <> "" Then
                            rec.Parse(recControl.City.Text, ContactsTable.City)
                        End If
                        If recControl.Email.Text <> "" Then
                            rec.Parse(recControl.Email.Text, ContactsTable.Email)
                        End If
                        If recControl.Mobile.Text <> "" Then
                            rec.Parse(recControl.Mobile.Text, ContactsTable.Mobile)
                        End If
                        If recControl.Name.Text <> "" Then
                            rec.Parse(recControl.Name.Text, ContactsTable.Name)
                        End If
                        If recControl.Title.Text <> "" Then
                            rec.Parse(recControl.Title.Text, ContactsTable.Title)
                        End If
                        If recControl.Type0.Text <> "" Then
                            rec.Parse(recControl.Type0.Text, ContactsTable.Type0)
                        End If
                        If recControl.Work_Phone.Text <> "" Then
                            rec.Parse(recControl.Work_Phone.Text, ContactsTable.Work_Phone)
                        End If
                        If recControl.Zip.Text <> "" Then
                            rec.Parse(recControl.Zip.Text, ContactsTable.Zip)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New ContactsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(ContactsRecord)), ContactsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As ContactsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As ContactsTableControlRow) As Boolean
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
        
        Public Overridable Sub SetAddressLabel()
                  
                  End Sub
                
        Public Overridable Sub SetAgencyLabel2()
                  
                  End Sub
                
        Public Overridable Sub SetCityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetEmailLabel()
                  
                  End Sub
                
        Public Overridable Sub SetMobileLabel()
                  
                  End Sub
                
        Public Overridable Sub SetNameLabel()
                  
                  End Sub
                
        Public Overridable Sub SetTitleLabel()
                  
                  End Sub
                
        Public Overridable Sub SetTypeLabel()
                  
                  End Sub
                
        Public Overridable Sub SetWork_PhoneLabel()
                  
                  End Sub
                
        Public Overridable Sub SetZipLabel()
                  
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
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
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("ContactsTableControl_OrderBy"), String)
            
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
                Me.ViewState("ContactsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub ContactsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub ContactsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub ContactsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.ContactsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.ContactsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub ContactsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        
        Public Overridable Sub AddressLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Address when clicked.
              
            ' Get previous sorting state for Address.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Address)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Address.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Address, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Address, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub AgencyLabel2_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Agency when clicked.
              
            ' Get previous sorting state for Agency.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Agency)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Agency.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Agency, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Agency, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub CityLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by City when clicked.
              
            ' Get previous sorting state for City.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.City)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for City.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.City, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by City, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub EmailLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Email when clicked.
              
            ' Get previous sorting state for Email.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Email)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Email.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Email, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Email, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub MobileLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Mobile when clicked.
              
            ' Get previous sorting state for Mobile.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Mobile)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Mobile.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Mobile, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Mobile, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub NameLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Name when clicked.
              
            ' Get previous sorting state for Name.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Name)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Name.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Name, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Name, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub TitleLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Title when clicked.
              
            ' Get previous sorting state for Title.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Title)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Title.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Title, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Title, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub TypeLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Type when clicked.
              
            ' Get previous sorting state for Type.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Type0)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Type.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Type0, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Type, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub Work_PhoneLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Work Phone when clicked.
              
            ' Get previous sorting state for Work Phone.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Work_Phone)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Work Phone.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Work_Phone, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Work Phone, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub ZipLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Zip when clicked.
              
            ' Get previous sorting state for Zip.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(ContactsTable.Zip)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Zip.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(ContactsTable.Zip, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Zip, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub ContactsAddButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Me.AddNewRecord = 1
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
        Public Overridable Sub ContactsDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Me.DeleteSelectedRecords(True)
                Me.SetFormulaControls()
                
          
            End If
      
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
                    _TotalRecords = ContactsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
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
        
        Public Property DataSource() As ContactsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, ContactsRecord())
            End Get
            Set(ByVal value() As ContactsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property AddressLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AddressLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property AgencyLabel2() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AgencyLabel2"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property CityLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CityLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsAddButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsAddButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property ContactsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property ContactsToggleAll() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ContactsToggleAll"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property EmailLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "EmailLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property MobileLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "MobileLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property NameLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "NameLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property TitleLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TitleLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property TypeLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TypeLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Work_PhoneLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Work_PhoneLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property ZipLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ZipLabel"), System.Web.UI.WebControls.LinkButton)
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
                Dim recCtl As ContactsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As ContactsRecord = Nothing     
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
                Dim recCtl As ContactsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As ContactsRecord = Nothing     
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
            Dim recControl As ContactsTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.ContactsRecordRowSelection.Checked Then
                    Return counter
                End If
                counter += 1
            Next
            Return -1
        End Function
        
        Public Overridable Function GetSelectedRecordControl() As ContactsTableControlRow
            Dim selectedList() As ContactsTableControlRow = Me.GetSelectedRecordControls()
            If selectedList.Length = 0 Then
                Return Nothing
            End If
            Return selectedList(0)
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As ContactsTableControlRow()
        
            Dim selectedList As ArrayList = New ArrayList(25)
            Dim recControl As ContactsTableControlRow
            For Each recControl In Me.GetRecordControls()
                If recControl.ContactsRecordRowSelection IsNot Nothing AndAlso recControl.ContactsRecordRowSelection.Checked Then
                    selectedList.Add(recControl)
                End If
            Next
            Return DirectCast(selectedList.ToArray(GetType(ContactsTableControlRow)), ContactsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As ContactsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As ContactsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
                    recCtl.ContactsRecordRowSelection.Checked = False
                
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

        Public Function GetRecordControls() As ContactsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("ContactsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As ContactsTableControlRow = DirectCast(repItem.FindControl("ContactsTableControlRow"), ContactsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(ContactsTableControlRow)), ContactsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the UploadsTableControlRow control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in UploadsTableControlRow.
Public Class BaseUploadsTableControlRow
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in UploadsTableControlRow.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
          
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in UploadsTableControlRow.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            'Call LoadFocusScripts from repeater so that onfocus attribute could be added to elements
            Me.Page.LoadFocusScripts(Me)
        
              ' Show confirmation message on Click
              Me.UploadsRowDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteRecordConfirm", "IROC2") & """));")
                  
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.UploadsRowDeleteButton.Click, AddressOf UploadsRowDeleteButton_Click
              
              AddHandler Me.UPLOAD_Comments.TextChanged, AddressOf UPLOAD_Comments_TextChanged
            
              AddHandler Me.UPLOAD_Created_By.TextChanged, AddressOf UPLOAD_Created_By_TextChanged
            
              AddHandler Me.UPLOAD_Desc.TextChanged, AddressOf UPLOAD_Desc_TextChanged
            
              AddHandler Me.UPLOAD_Dt.TextChanged, AddressOf UPLOAD_Dt_TextChanged
            
              AddHandler Me.UPLOAD_File.TextChanged, AddressOf UPLOAD_File_TextChanged
            
              AddHandler Me.UPLOAD_Quote.TextChanged, AddressOf UPLOAD_Quote_TextChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Uploads record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = UploadsTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' Since this is a row in the table, the data for this row is loaded by the 
            ' LoadData method of the BaseUploadsTableControl when the data for the entire
            ' table is loaded.
            
            Me.DataSource = New UploadsRecord()
          
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in UploadsTableControlRow.
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
        
                SetUPLOAD_Comments()
                SetUPLOAD_Created_By()
                SetUPLOAD_Desc()
                
                SetUPLOAD_DOCImage()
                SetUPLOAD_Dt()
                SetUPLOAD_File()
                SetUPLOAD_Quote()
                
      
      
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
        
        
        Public Overridable Sub SetUPLOAD_Comments()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_Comments.ID) Then
            
                Me.UPLOAD_Comments.Text = Me.PreviousUIData(Me.UPLOAD_Comments.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_CommentsSpecified Then
                				
                ' If the UPLOAD_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Comments)
                              
                Me.UPLOAD_Comments.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Comments.Text = UploadsTable.UPLOAD_Comments.Format(UploadsTable.UPLOAD_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Created_By()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_Created_By.ID) Then
            
                Me.UPLOAD_Created_By.Text = Me.PreviousUIData(Me.UPLOAD_Created_By.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_Created_By TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Created_By is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Created_By()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_Created_BySpecified Then
                				
                ' If the UPLOAD_Created_By is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Created_By)
                              
                Me.UPLOAD_Created_By.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Created_By is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Created_By.Text = UploadsTable.UPLOAD_Created_By.Format(UploadsTable.UPLOAD_Created_By.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Desc()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_Desc.ID) Then
            
                Me.UPLOAD_Desc.Text = Me.PreviousUIData(Me.UPLOAD_Desc.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_Desc TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Desc is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Desc()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DescSpecified Then
                				
                ' If the UPLOAD_Desc is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Desc)
                              
                Me.UPLOAD_Desc.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Desc is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Desc.Text = UploadsTable.UPLOAD_Desc.Format(UploadsTable.UPLOAD_Desc.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_DOCImage()
                
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DOCSpecified Then
                
                Me.UPLOAD_DOCImage.Text = Me.DataSource.UPLOAD_File
                Me.UPLOAD_DOCImage.ToolTip = "Open " & Me.UPLOAD_DOCImage.Text
				   If String.IsNullOrEmpty(Me.UPLOAD_DOCImage.Text) Then
					      Me.UPLOAD_DOCImage.Text = Page.GetResourceValue("Txt:OpenFile", "IROC2")
                Me.UPLOAD_DOCImage.ToolTip = Me.UPLOAD_DOCImage.Text
				   End If
						
                Me.UPLOAD_DOCImage.OnClientClick = "window.open('../Shared/ExportFieldValue.aspx?Table=" & _
                            Me.Page.Encrypt("Uploads") & _
                            "&Field=" & Me.Page.Encrypt("UPLOAD_DOC") & _
                            "&Record=" & Me.Page.Encrypt(HttpUtility.UrlEncode(Me.DataSource.GetID().ToString())) & _
                            "&Filename=" & Me.DataSource.UPLOAD_File & _
                            "','','left=100,top=50,width=400,height=300,resizable, scrollbars=1');return false;"
                   
                Me.UPLOAD_DOCImage.Visible = True
            Else
                Me.UPLOAD_DOCImage.Visible = False
            End If
        End Sub
                
        Public Overridable Sub SetUPLOAD_Dt()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_Dt.ID) Then
            
                Me.UPLOAD_Dt.Text = Me.PreviousUIData(Me.UPLOAD_Dt.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DtSpecified Then
                				
                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")
                              
                Me.UPLOAD_Dt.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Dt.Text = UploadsTable.UPLOAD_Dt.Format(UploadsTable.UPLOAD_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_File()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_File.ID) Then
            
                Me.UPLOAD_File.Text = Me.PreviousUIData(Me.UPLOAD_File.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_File TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_File is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_File()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_FileSpecified Then
                				
                ' If the UPLOAD_File is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_File)
                              
                Me.UPLOAD_File.Text = formattedValue
                
            Else 
            
                ' UPLOAD_File is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_File.Text = UploadsTable.UPLOAD_File.Format(UploadsTable.UPLOAD_File.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Quote()
            					
            ' If data was retrieved from UI previously, restore it
            If Me.PreviousUIData.ContainsKey(Me.UPLOAD_Quote.ID) Then
            
                Me.UPLOAD_Quote.Text = Me.PreviousUIData(Me.UPLOAD_Quote.ID).ToString()
              
                Return
            End If
            
        
            ' Set the UPLOAD_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Quote is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Quote()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_QuoteSpecified Then
                				
                ' If the UPLOAD_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Quote, "$###,###,###.##")
                              
                Me.UPLOAD_Quote.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Quote.Text = UploadsTable.UPLOAD_Quote.Format(UploadsTable.UPLOAD_Quote.DefaultValue, "$###,###,###.##")
                        		
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

      
        
        ' To customize, override this method in UploadsTableControlRow.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
        Dim parentCtrl As Request_MasterRecordControl
          
          
          parentCtrl = DirectCast(Me.Page.FindControlRecursively("Request_MasterRecordControl"), Request_MasterRecordControl)				  
              
          If (Not IsNothing(parentCtrl) AndAlso IsNothing(parentCtrl.DataSource)) 
                ' Load the record if it is not loaded yet.
                parentCtrl.LoadData()
            End If
            If (IsNothing(parentCtrl) OrElse IsNothing(parentCtrl.DataSource)) 
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:NoParentRecId", "IROC2"))
            End If
            
            Me.DataSource.Request_Id = parentCtrl.DataSource.Request_Id
              
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
              
                DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).DataChanged = True
                DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).ResetData = True
            End If
            
      
            ' update session or cookie by formula
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in UploadsTableControlRow.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetUPLOAD_Comments()
            GetUPLOAD_Created_By()
            GetUPLOAD_Desc()
            GetUPLOAD_DOC()
            GetUPLOAD_Dt()
            GetUPLOAD_File()
            GetUPLOAD_Quote()
        End Sub
        
        
        Public Overridable Sub GetUPLOAD_Comments()
            
            ' Retrieve the value entered by the user on the UPLOAD_Comments ASP:TextBox, and
            ' save it into the UPLOAD_Comments field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Comments.Text, UploadsTable.UPLOAD_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_Created_By()
            
            ' Retrieve the value entered by the user on the UPLOAD_Created_By ASP:TextBox, and
            ' save it into the UPLOAD_Created_By field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Created_By.Text, UploadsTable.UPLOAD_Created_By)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_Desc()
            
            ' Retrieve the value entered by the user on the UPLOAD_Desc ASP:TextBox, and
            ' save it into the UPLOAD_Desc field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Desc.Text, UploadsTable.UPLOAD_Desc)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_DOC()
            ' Retrieve the value entered by the user on the UPLOAD_DOC ASP:FileUpload, and
            ' save it into the UPLOAD_DOC field in DataSource DatabaseIROC%dbo.Uploads record.
            ' Custom validation should be performed in Validate, not here.
                  
            If Not Me.UPLOAD_DOC.PostedFile is Nothing then  
                If Me.UPLOAD_DOC.PostedFile.FileName.Length > 0 AndAlso Me.UPLOAD_DOC.PostedFile.ContentLength > 0 Then
                      ' Retrieve the file contents and store them in UPLOAD_DOC field.
					  Me.DataSource.Parse(MiscUtils.GetFileContent(Me.UPLOAD_DOC.PostedFile), UploadsTable.UPLOAD_DOC)
                  
					  ' If there is a FileName companion field specified, then save the file name as well.
					  ' Strip off the path and just save the part after the last \
					  Dim path As String = Me.UPLOAD_DOC.PostedFile.FileName
                      Dim LastIndex As Integer = path.LastIndexOf("\")
                      
                      Me.DataSource.UPLOAD_File = path.Substring(LastIndex + 1).Replace("'", "_")
                  
                End If
            End If
        End Sub
                
        Public Overridable Sub GetUPLOAD_Dt()
            
            ' Retrieve the value entered by the user on the UPLOAD_Dt ASP:TextBox, and
            ' save it into the UPLOAD_Dt field in DataSource DatabaseIROC%dbo.Uploads record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Dt.Text, UploadsTable.UPLOAD_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_File()
            
            ' Retrieve the value entered by the user on the UPLOAD_File ASP:TextBox, and
            ' save it into the UPLOAD_File field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_File.Text, UploadsTable.UPLOAD_File)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_Quote()
            
            ' Retrieve the value entered by the user on the UPLOAD_Quote ASP:TextBox, and
            ' save it into the UPLOAD_Quote field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Quote.Text, UploadsTable.UPLOAD_Quote)			

                      
        End Sub
                
      
        ' To customize, override this method in UploadsTableControlRow.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Return Nothing
            
        End Function
        
    

        ' To customize, override this method in UploadsTableControlRow.
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
          UploadsTable.DeleteRecord(pkValue)
          
            DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).DataChanged = True
            DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl).ResetData = True
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
                                
                
			Me.Page.Authorize(Ctype(UploadsRowDeleteButton, Control), "1;4")
											
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
        
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsRowDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Dim tc As UploadsTableControl = DirectCast(GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl)
                If Not (IsNothing(tc)) Then
                    If Not Me.IsNewRecord Then
                        tc.AddToDeletedRecordIds(DirectCast(Me, UploadsTableControlRow))
                    End If
                    Me.Visible = False
                    tc.SetFormulaControls()
                End If
              
            End If
      
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
        
        Protected Overridable Sub UPLOAD_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Created_By_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Desc_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_File_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Quote_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseUploadsTableControlRow_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseUploadsTableControlRow_Rec") = value
            End Set
        End Property
        
        Private _DataSource As UploadsRecord
        Public Property DataSource() As UploadsRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As UploadsRecord)
            
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
        
        Public ReadOnly Property UPLOAD_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Created_By() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_By"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Desc() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Desc"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_DOC() As System.Web.UI.WebControls.FileUpload
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOC"), System.Web.UI.WebControls.FileUpload)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_DOCImage() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOCImage"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_File() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_File"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Quote"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UploadsRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
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
            
            Dim rec As UploadsRecord = Nothing
             
        
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
            
            Dim rec As UploadsRecord = Nothing
             
        
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

         
        Public Overridable Function GetRecord() As UploadsRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return UploadsTable.GetRecord(Me.RecordUniqueId, True)
                
            End If
            
            ' Localization.
            
            Return Nothing
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the UploadsTableControl control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in UploadsTableControl.
Public Class BaseUploadsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
      
      
            ' Control Initializations.
            ' Initialize the table's current sort order.
            If Me.InSession(Me, "Order_By") Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
         
            Else
                   
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(UploadsTable.Upload_Id, OrderByItem.OrderDir.Asc)
              
        End If

    
    
            ' Setup default pagination settings.
        
            Me.PageSize = CInt(Me.GetFromSession(Me, "Page_Size", "10"))
            Me.PageIndex = CInt(Me.GetFromSession(Me, "Page_Index", "0"))
            
        
            
            Me.ClearControlsFromSession()
        End Sub

        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
            SaveControlsToSession_Ajax()
        
              ' Show confirmation message on Click
              Me.UploadsDeleteButton.Attributes.Add("onClick", "return (confirm(""" & (CType(Me.Page,BaseApplicationPage)).GetResourceValue("DeleteConfirm", "IROC2") & """));")
      
            ' Setup the pagination events.
            
              AddHandler Me.UploadsPagination.FirstPage.Click, AddressOf UploadsPagination_FirstPage_Click
              
              AddHandler Me.UploadsPagination.LastPage.Click, AddressOf UploadsPagination_LastPage_Click
              
              AddHandler Me.UploadsPagination.NextPage.Click, AddressOf UploadsPagination_NextPage_Click
              
              AddHandler Me.UploadsPagination.PageSizeButton.Click, AddressOf UploadsPagination_PageSizeButton_Click
            
              AddHandler Me.UploadsPagination.PreviousPage.Click, AddressOf UploadsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.UPLOAD_CommentsLabel.Click, AddressOf UPLOAD_CommentsLabel_Click
            
              AddHandler Me.UPLOAD_Created_ByLabel.Click, AddressOf UPLOAD_Created_ByLabel_Click
            
              AddHandler Me.UPLOAD_DescLabel.Click, AddressOf UPLOAD_DescLabel_Click
            
              AddHandler Me.UPLOAD_DtLabel.Click, AddressOf UPLOAD_DtLabel_Click
            
              AddHandler Me.UPLOAD_QuoteLabel.Click, AddressOf UPLOAD_QuoteLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.UploadsAddButton.Click, AddressOf UploadsAddButton_Click
              
              AddHandler Me.UploadsDeleteButton.Click, AddressOf UploadsDeleteButton_Click
                      
        
          ' Setup events for others
            
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
                    Me.DataSource = DirectCast(alist.ToArray(GetType(UploadsRecord)), UploadsRecord())
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
                    For Each rc As UploadsTableControlRow In Me.GetRecordControls()
                        If Not rc.IsNewRecord Then
                            rc.DataSource = rc.GetRecord()
                            rc.GetUIData()
                            postdata.Add(rc.DataSource)
                            UIData.Add(rc.PreservedUIData())							
                        End If
                    Next
                    Me.DataSource = DirectCast(postdata.ToArray(GetType(UploadsRecord)), UploadsRecord())
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
            ByVal pageSize As Integer) As UploadsRecord()
            
            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList     
                        

    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UploadsTable.Column1, True)         
            ' selCols.Add(UploadsTable.Column2, True)          
            ' selCols.Add(UploadsTable.Column3, True)    
   
            
            
            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
              
                Return UploadsTable.GetRecords(join, where, orderBy, Me.PageIndex, Me.PageSize)
                 
            Else
                Dim databaseTable As New UploadsTable
                databaseTable.SelectedColumns.Clear()
                databaseTable.SelectedColumns.AddRange(selCols)
                
            
                
                Dim recList As ArrayList
                orderBy.ExpandForeignKeyColums = False
                recList = databaseTable.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)
                Return CType(recList.ToArray(GetType(UploadsRecord)), UploadsRecord())
            End If            
            
        End Function        
        
        
        Public Overridable Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer


            ' By default, Select * will be executed to get a list of records.  If you want to run Select Distinct with certain column only, add the column to selCols
            Dim selCols As New ColumnList                 
               
    
            ' If you want to specify certain columns to be in the select statement, you can write code similar to the following:
            ' However, if you don't specify PK, row button click might show an error message.
            ' And make sure you write similar code in GetRecordCount as well
            ' selCols.Add(UploadsTable.Column1, True)         
            ' selCols.Add(UploadsTable.Column2, True)          
            ' selCols.Add(UploadsTable.Column3, True)          


            ' If the parameters doesn't specify specific columns in the Select statement, then run Select *
            ' Alternatively, if the parameters specifies to include PK, also run Select *
            
            If selCols.Count = 0 Then                    
                     
                Return UploadsTable.GetRecordCount(join, where)

            Else
                Dim databaseTable As New UploadsTable
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
          Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
          If rep Is Nothing Then Return
          rep.DataSource = DataSource()
          rep.DataBind()
                  
          Dim index As Integer = 0
          For Each repItem As System.Web.UI.WebControls.RepeaterItem In rep.Items
            ' Loop through all rows in the table, set its DataSource and call DataBind().
            Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
            recControl.DataSource = Me.DataSource(index)          
            If Me.UIData.Count > index Then
              recControl.PreviousUIData = Me.UIData(index)
            End If
            recControl.DataBind()
          
            recControl.Visible = Not Me.InDeletedRecordIds(recControl)
          
            index += 1
          Next
                 
            ' Call the Set methods for each controls on the panel
        
                SetUPLOAD_CommentsLabel()
                SetUPLOAD_Created_ByLabel()
                SetUPLOAD_DescLabel()
                SetUPLOAD_DOCLabel()
                SetUPLOAD_DtLabel()
                SetUPLOAD_QuoteLabel()
                
                
                
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
                    
            Me.CurrentSortOrder.Reset()
            If (Me.InSession(Me, "Order_By")) Then
                Me.CurrentSortOrder = OrderBy.FromXmlString(Me.GetFromSession(Me, "Order_By", Nothing))
            
            Else
                Me.CurrentSortOrder = New OrderBy(True, False)
            
                Me.CurrentSortOrder.Add(UploadsTable.Upload_Id, OrderByItem.OrderDir.Asc)
                  
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
                    
                Me.UploadsPagination.CurrentPage.Text = (Me.PageIndex + 1).ToString()
            Else
                Me.UploadsPagination.CurrentPage.Text = "0"
            End If
            Me.UploadsPagination.PageSize.Text = Me.PageSize.ToString()
            Me.UploadsPagination.TotalPages.Text = Me.TotalPages.ToString()

            ' Bind the buttons for UploadsTableControl pagination.
        
            Me.UploadsPagination.FirstPage.Enabled = Not (Me.PageIndex = 0)
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UploadsPagination.LastPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            If Me._TotalPages < 0 Then      ' if the total pages is not determined yet, enable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = True
            ElseIf Me._TotalPages = 0          ' if the total pages is determined and it is 0, enable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = False            
            Else                               ' if the total pages is the last page, disable last and next buttons
                Me.UploadsPagination.NextPage.Enabled = Not (Me.PageIndex = Me.TotalPages - 1)
            End If
          
            Me.UploadsPagination.PreviousPage.Enabled = Not (Me.PageIndex = 0)


        End Sub

   
    
        Public Overridable Sub SaveData()
            ' Save the data from the entire table.  Calls each row's Save Data
            ' to save their data.  This function is called by the Click handler of the
            ' Save button.  The button handler should Start/Commit/End a transaction.
            
            Dim recCtl As UploadsTableControlRow
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
            UploadsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.

              
      Dim selectedRecordKeyValue as KeyValue = New KeyValue()
    
              Dim request_MasterRecordControlObj As IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "Request_MasterRecordControl"), IROC2.UI.Controls.Full_Edit_Request_Master.Request_MasterRecordControl)
              
                If (Not IsNothing(request_MasterRecordControlObj) AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord()) AndAlso request_MasterRecordControlObj.GetRecord().IsCreated AndAlso Not IsNothing(request_MasterRecordControlObj.GetRecord().Request_Id))
                    wc.iAND(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                    selectedRecordKeyValue.AddElement(UploadsTable.Request_Id.InternalName, request_MasterRecordControlObj.GetRecord().Request_Id.ToString())
                Else
                    wc.RunQuery = False
                    Return wc
                End If
              
      HttpContext.Current.Session("UploadsTableControlWhereClause") = selectedRecordKeyValue.ToXmlString()
    
    Return wc
    End Function

    
        Public Overridable Function CreateWhereClause(ByVal searchText as String, ByVal fromSearchControl as String, ByVal AutoTypeAheadSearch as String, ByVal AutoTypeAheadWordSeparators as String) As WhereClause
            ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
            UploadsTable.Instance.InnerFilter = Nothing
            Dim wc As WhereClause = New WhereClause()
        
      ' Compose the WHERE clause consist of:
      ' 1. Static clause defined at design time.
      ' 2. User selected search criteria.
      ' 3. User selected filter criteria.

      Dim appRelativeVirtualPath As String = CType(HttpContext.Current.Session("AppRelativeVirtualPath"), String)
      
            Dim selectedRecordInRequest_MasterRecordControl as String = DirectCast(HttpContext.Current.Session("UploadsTableControlWhereClause"), String)
            
            If Not selectedRecordInRequest_MasterRecordControl Is Nothing AndAlso KeyValue.IsXmlKey(selectedRecordInRequest_MasterRecordControl) Then
                Dim selectedRecordKeyValue as KeyValue = KeyValue.XmlToKey(selectedRecordInRequest_MasterRecordControl)
                
       If Not IsNothing(selectedRecordKeyValue) AndAlso selectedRecordKeyValue.ContainsColumn(UploadsTable.Request_Id) Then
            wc.iAND(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, selectedRecordKeyValue.GetColumnValue(UploadsTable.Request_Id).ToString())
       End If
      
            End If
          
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
        
            If Me.UploadsPagination.PageSize.Text.Trim <> "" Then
                Try
                    'Me.PageSize = Integer.Parse(Me.UploadsPagination.PageSize.Text)
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
    Dim rep As System.Web.UI.WebControls.Repeater = CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
    If rep Is Nothing Then Return

    Dim repItem As System.Web.UI.WebControls.RepeaterItem
    For Each repItem In rep.Items
    ' Loop through all rows in the table, set its DataSource and call DataBind().
    
    Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)

                    If recControl.Visible AndAlso recControl.IsNewRecord() Then
                        Dim rec As UploadsRecord = New UploadsRecord()
        
                        If recControl.UPLOAD_Comments.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Comments.Text, UploadsTable.UPLOAD_Comments)
                        End If
                        If recControl.UPLOAD_Created_By.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Created_By.Text, UploadsTable.UPLOAD_Created_By)
                        End If
                        If recControl.UPLOAD_Desc.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Desc.Text, UploadsTable.UPLOAD_Desc)
                        End If
                        If recControl.UPLOAD_DOCImage.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_DOCImage.Text, UploadsTable.UPLOAD_DOC)
                        End If
                        If recControl.UPLOAD_Dt.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Dt.Text, UploadsTable.UPLOAD_Dt)
                        End If
                        If recControl.UPLOAD_File.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_File.Text, UploadsTable.UPLOAD_File)
                        End If
                        If recControl.UPLOAD_Quote.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Quote.Text, UploadsTable.UPLOAD_Quote)
                        End If
                        newUIDataList.Add(recControl.PreservedUIData())	  
                        newRecordList.Add(rec)
                    End If
                Next
            End If
            
    
            ' Add any new record to the list.
            Dim index As Integer = 0
            For index = 1 To Me.AddNewRecord
            
                newRecordList.Insert(0, New UploadsRecord())
                newUIDataList.Insert(0, New Hashtable())				
              
            Next
            Me.AddNewRecord = 0

            ' Finally, add any new records to the DataSource.
            If newRecordList.Count > 0 Then
            
                Dim finalList As ArrayList = New ArrayList(Me.DataSource)
                finalList.InsertRange(0, newRecordList)

                Me.DataSource = DirectCast(finalList.ToArray(GetType(UploadsRecord)), UploadsRecord())
              
            End If
            
            ' Add the existing UI data to this hash table
            If newUIDataList.Count > 0 Then
                Me.UIData.InsertRange(0, newUIDataList)
            End If
            
        End Sub

        
        Public Sub AddToDeletedRecordIds(ByVal rec As UploadsTableControlRow)
            If rec.IsNewRecord() Then
                Return
            End If

            If Not Me.DeletedRecordIds Is Nothing AndAlso Me.DeletedRecordIds.Trim <> "" Then
                Me.DeletedRecordIds &= ","
            End If

            Me.DeletedRecordIds &= "[" & rec.RecordUniqueId & "]"
        End Sub

        Protected Overridable Function InDeletedRecordIds(ByVal rec As UploadsTableControlRow) As Boolean
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
        
        Public Overridable Sub SetUPLOAD_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_Created_ByLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_Created_ByLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DescLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DOCLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_QuoteLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_QuoteLabel.Text = "Some value"
                    
                  End Sub
                

    
    
        Protected Overridable Sub Control_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            ' PreRender event is raised just before page is being displayed.
            Try
                DbUtils.StartTransaction
                Me.RegisterPostback()
                
                If Not Me.Page.ErrorOnPage AndAlso (Me.Page.IsPageRefresh OrElse Me.DataChanged OrElse Me.ResetData) Then
                  
                
                    ' Re-load the data and update the web page if necessary.
                    ' This is typically done during a postback (filter, search button, sort, pagination button).
                    ' In each of the other click handlers, simply set DataChanged to True to reload the data.
                    Dim added As Boolean = Me.AddNewRecord > 0
                    Me.LoadData()
                    Me.DataBind()
                    
                    If added Then
                        Me.SetFocusToAddedRow()
                    End If
                    
                End If
                
               
                				
            Catch ex As Exception
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
            Finally
                DbUtils.EndTransaction
            End Try
        End Sub
        
        'this function sets focus to the first editable element in the new added row in the editable table	
        Protected Overridable Sub SetFocusToAddedRow()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing OrElse rep.Items.Count = 0 Then Return
            Dim repItem As System.Web.UI.WebControls.RepeaterItem
            For Each repItem In rep.Items  
                'Load scripts to table rows
                Me.Page.LoadFocusScripts(repItem)
                Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
                If recControl.IsNewRecord Then
                    For Each field As Control In recControl.Controls
                        If field.Visible AndAlso Me.Page.IsControlEditable(field, False) Then
                            'set focus on the first editable field in the new row
                            field.Focus()
                            Dim updPan As UpdatePanel = DirectCast(Me.Page.FindControlRecursively("UpdatePanel1"), UpdatePanel)
                            If Not updPan Is Nothing Then updPan.Update()
                            Return
                        End If
                    Next
                    Return
                End If
            Next
        End Sub
        
        
        Protected Overrides Sub SaveControlsToSession()
            MyBase.SaveControlsToSession()

            ' Save filter controls to values to session.
        
        
            'Save pagination state to session.
         
            
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
          
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
    
            ' Clear pagination state from session.
         
    
    ' Clear table properties from the session.
    Me.RemoveFromSession(Me, "Order_By")
    Me.RemoveFromSession(Me, "Page_Index")
    Me.RemoveFromSession(Me, "Page_Size")
    
            Me.RemoveFromSession(Me, "DeletedRecordIds")  
            
        End Sub

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            MyBase.LoadViewState(savedState)

            Dim orderByStr As String = CType(ViewState("UploadsTableControl_OrderBy"), String)
            
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
                Me.ViewState("UploadsTableControl_OrderBy") = Me.CurrentSortOrder.ToXmlString()
            End If
                      
            Me.ViewState("Page_Index") = Me.PageIndex
            Me.ViewState("Page_Size") = Me.PageSize
            
            Me.ViewState("DeletedRecordIds") = Me.DeletedRecordIds
        
    
            ' Load view state for pagination control.
          
    
            Return MyBase.SaveViewState()
        End Function

        ' Generate the event handling functions for pagination events.
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_FirstPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub UploadsPagination_LastPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub UploadsPagination_NextPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        Public Overridable Sub UploadsPagination_PageSizeButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
            Me.DataChanged = True
      
            Me.PageSize = Integer.Parse(Me.UploadsPagination.PageSize.Text)
      
            Me.PageIndex = Integer.Parse(Me.UploadsPagination.CurrentPage.Text) - 1
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
        ' event handler for ImageButton
        Public Overridable Sub UploadsPagination_PreviousPage_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
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
        
        Public Overridable Sub UPLOAD_CommentsLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Comments when clicked.
              
            ' Get previous sorting state for UPLOAD_Comments.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Comments)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Comments.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Comments, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Comments, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_Created_ByLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Created_By when clicked.
              
            ' Get previous sorting state for UPLOAD_Created_By.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Created_By)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Created_By.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Created_By, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Created_By, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_DescLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Desc when clicked.
              
            ' Get previous sorting state for UPLOAD_Desc.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Desc)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Desc.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Desc, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Desc, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_DtLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Dt when clicked.
              
            ' Get previous sorting state for UPLOAD_Dt.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Dt)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Dt.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Dt, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Dt, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
        Public Overridable Sub UPLOAD_QuoteLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_Quote when clicked.
              
            ' Get previous sorting state for UPLOAD_Quote.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_Quote)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_Quote.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_Quote, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_Quote, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsAddButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            Me.AddNewRecord = 1
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
        Public Overridable Sub UploadsDeleteButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            If(Not Me.Page.IsPageRefresh) Then
        
                Me.DeleteSelectedRecords(True)
                Me.SetFormulaControls()
                
          
            End If
      
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
                    _TotalRecords = UploadsTable.GetRecordCount(CreateCompoundJoinFilter(), CreateWhereClause())
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
        
        Public Property DataSource() As UploadsRecord ()
            Get
                Return DirectCast(MyBase._DataSource, UploadsRecord())
            End Get
            Set(ByVal value() As UploadsRecord)
                Me._DataSource = value
            End Set
        End Property
       
#Region "Helper Properties"
        
        Public ReadOnly Property UPLOAD_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Created_ByLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_ByLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DescLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DescLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DOCLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOCLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_QuoteLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_QuoteLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsAddButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsAddButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsPagination"), IROC2.UI.IPaginationMedium)
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
                Dim recCtl As UploadsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UploadsRecord = Nothing     
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
                Dim recCtl As UploadsTableControlRow = Me.GetSelectedRecordControl()
                If recCtl Is Nothing AndAlso url.IndexOf("{") >= 0 Then
                    ' Localization.
                    Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
                End If
                Dim rec As UploadsRecord = Nothing     
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
        
          
        Public Overridable Function GetSelectedRecordControl() As UploadsTableControlRow
            Return Nothing
          
        End Function

        Public Overridable Function GetSelectedRecordControls() As UploadsTableControlRow()
        
            Return DirectCast((new ArrayList()).ToArray(GetType(UploadsTableControlRow)), UploadsTableControlRow())
          
        End Function

        Public Overridable Sub DeleteSelectedRecords(ByVal deferDeletion As Boolean)
            Dim recList() As UploadsTableControlRow = Me.GetSelectedRecordControls()
            If recList.Length = 0 Then
                ' Localization.
                Throw New Exception(Page.GetResourceValue("Err:NoRecSelected", "IROC2"))
            End If
            
            Dim recCtl As UploadsTableControlRow
            For Each recCtl In recList
                If deferDeletion Then
                    If Not recCtl.IsNewRecord Then
                
                        Me.AddToDeletedRecordIds(recCtl)
                  
                    End If
                    recCtl.Visible = False
                
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

        Public Function GetRecordControls() As UploadsTableControlRow()
            Dim recList As ArrayList = New ArrayList()
            Dim rep As System.Web.UI.WebControls.Repeater = CType(Me.FindControl("UploadsTableControlRepeater"), System.Web.UI.WebControls.Repeater)
            If rep Is Nothing Then Return Nothing
            Dim repItem As System.Web.UI.WebControls.RepeaterItem

            For Each repItem In rep.Items
            
                Dim recControl As UploadsTableControlRow = DirectCast(repItem.FindControl("UploadsTableControlRow"), UploadsTableControlRow)
                recList.Add(recControl)
              
            Next

            Return DirectCast(recList.ToArray(GetType(UploadsTableControlRow)), UploadsTableControlRow())
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property
                


#End Region

    

End Class

  
' Base class for the Request_MasterRecordControl control on the Full_Edit_Request_Master page.
' Do not modify this class. Instead override any method in Request_MasterRecordControl.
Public Class BaseRequest_MasterRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in Request_MasterRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in Request_MasterRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.Priority.SelectedIndexChanged, AddressOf Priority_SelectedIndexChanged
            
              AddHandler Me.Prov_Name.SelectedIndexChanged, AddressOf Prov_Name_SelectedIndexChanged
            
              AddHandler Me.Req_Island1.SelectedIndexChanged, AddressOf Req_Island1_SelectedIndexChanged
            
              AddHandler Me.Cat_Cost_Free.CheckedChanged, AddressOf Cat_Cost_Free_CheckedChanged
            
              AddHandler Me.ICS_SOW_Needed.CheckedChanged, AddressOf ICS_SOW_Needed_CheckedChanged
            
              AddHandler Me.ICS_SOW_Uploaded.CheckedChanged, AddressOf ICS_SOW_Uploaded_CheckedChanged
            
              AddHandler Me.OTW_More_Info_Flag.CheckedChanged, AddressOf OTW_More_Info_Flag_CheckedChanged
            
              AddHandler Me.OTW_On_Net.CheckedChanged, AddressOf OTW_On_Net_CheckedChanged
            
              AddHandler Me.OTW_Premise_Fiber_Work_Reqd.CheckedChanged, AddressOf OTW_Premise_Fiber_Work_Reqd_CheckedChanged
            
              AddHandler Me.Cat_Franchise_Order_Number2.TextChanged, AddressOf Cat_Franchise_Order_Number2_TextChanged
            
              AddHandler Me.Cat_OTWC_Comments.TextChanged, AddressOf Cat_OTWC_Comments_TextChanged
            
              AddHandler Me.ICS_CATV_Comments.TextChanged, AddressOf ICS_CATV_Comments_TextChanged
            
              AddHandler Me.IROC_Id.TextChanged, AddressOf IROC_Id_TextChanged
            
              AddHandler Me.OTW_Completed_Dt.TextChanged, AddressOf OTW_Completed_Dt_TextChanged
            
              AddHandler Me.OTW_Construction_Status.TextChanged, AddressOf OTW_Construction_Status_TextChanged
            
              AddHandler Me.OTW_Deployment_Start_Dt.TextChanged, AddressOf OTW_Deployment_Start_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_Amt.TextChanged, AddressOf OTW_Invoice_Amt_TextChanged
            
              AddHandler Me.OTW_Invoice_Dt.TextChanged, AddressOf OTW_Invoice_Dt_TextChanged
            
              AddHandler Me.OTW_Invoice_No.TextChanged, AddressOf OTW_Invoice_No_TextChanged
            
              AddHandler Me.OTW_Island_completed.TextChanged, AddressOf OTW_Island_completed_TextChanged
            
              AddHandler Me.OTW_Permit_Status.TextChanged, AddressOf OTW_Permit_Status_TextChanged
            
              AddHandler Me.OTW_Projected_Deploy_Dt.TextChanged, AddressOf OTW_Projected_Deploy_Dt_TextChanged
            
              AddHandler Me.OTW_Quote.TextChanged, AddressOf OTW_Quote_TextChanged
            
              AddHandler Me.OTW_Quote1.TextChanged, AddressOf OTW_Quote1_TextChanged
            
              AddHandler Me.OTW_Scheduled_Deploy_Dt.TextChanged, AddressOf OTW_Scheduled_Deploy_Dt_TextChanged
            
              AddHandler Me.Pending_Action_Dt1.TextChanged, AddressOf Pending_Action_Dt1_TextChanged
            
              AddHandler Me.Pending_Action_Needed1.TextChanged, AddressOf Pending_Action_Needed1_TextChanged
            
              AddHandler Me.Pending_Agency_Return.TextChanged, AddressOf Pending_Agency_Return_TextChanged
            
              AddHandler Me.Pending_Prev_Action_Needed.TextChanged, AddressOf Pending_Prev_Action_Needed_TextChanged
            
              AddHandler Me.Pending_Prev_Status.TextChanged, AddressOf Pending_Prev_Status_TextChanged
            
              AddHandler Me.Reg_Type1.TextChanged, AddressOf Reg_Type1_TextChanged
            
              AddHandler Me.Req_Address1.TextChanged, AddressOf Req_Address1_TextChanged
            
              AddHandler Me.Req_City1.TextChanged, AddressOf Req_City1_TextChanged
            
              AddHandler Me.Req_Comments.TextChanged, AddressOf Req_Comments_TextChanged
            
              AddHandler Me.Req_Completed_Dt.TextChanged, AddressOf Req_Completed_Dt_TextChanged
            
              AddHandler Me.Req_Contact_Email.TextChanged, AddressOf Req_Contact_Email_TextChanged
            
              AddHandler Me.Req_Dt1.TextChanged, AddressOf Req_Dt1_TextChanged
            
              AddHandler Me.Req_Enity2.TextChanged, AddressOf Req_Enity2_TextChanged
            
              AddHandler Me.Req_Funding_Src2.TextChanged, AddressOf Req_Funding_Src2_TextChanged
            
              AddHandler Me.Req_PO_Amt.TextChanged, AddressOf Req_PO_Amt_TextChanged
            
              AddHandler Me.Req_PO_Dt.TextChanged, AddressOf Req_PO_Dt_TextChanged
            
              AddHandler Me.Req_PO_No.TextChanged, AddressOf Req_PO_No_TextChanged
            
              AddHandler Me.Req_Pymt_Amt.TextChanged, AddressOf Req_Pymt_Amt_TextChanged
            
              AddHandler Me.Req_Pymt_Check_No.TextChanged, AddressOf Req_Pymt_Check_No_TextChanged
            
              AddHandler Me.Req_Pymt_Dt.TextChanged, AddressOf Req_Pymt_Dt_TextChanged
            
              AddHandler Me.Req_Quote_Approved.TextChanged, AddressOf Req_Quote_Approved_TextChanged
            
              AddHandler Me.Req_Site_Name1.TextChanged, AddressOf Req_Site_Name1_TextChanged
            
              AddHandler Me.Req_State1.TextChanged, AddressOf Req_State1_TextChanged
            
              AddHandler Me.Req_Status.TextChanged, AddressOf Req_Status_TextChanged
            
              AddHandler Me.Req_Target_Dt1.TextChanged, AddressOf Req_Target_Dt1_TextChanged
            
              AddHandler Me.Req_Zip1.TextChanged, AddressOf Req_Zip1_TextChanged
            
              AddHandler Me.Pending_Agency1.TextChanged, AddressOf Pending_Agency1_TextChanged
            
    
        End Sub

        
        Public Overridable Sub LoadData()        
                
            ' Load the data from the database into the DataSource DatabaseIROC%dbo.Request_Master record.
            ' It is better to make changes to functions called by LoadData such as
            ' CreateWhereClause, rather than making changes here.
    
            ' The RecordUniqueId is set the first time a record is loaded, and is
            ' used during a PostBack to load the record.
          
            If Me.RecordUniqueId IsNot Nothing AndAlso Me.RecordUniqueId.Trim <> "" Then
                Me.DataSource = Request_MasterTable.GetRecord(Me.RecordUniqueId, True)
          
                Return
            End If
        
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "Request_MasterRecordControlPanel"), System.Web.UI.WebControls.Panel)
            If Not Panel is Nothing Then
                Panel.visible = True
            End If
            
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New Request_MasterRecord()
            
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As Request_MasterRecord = Request_MasterTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                If Not Panel is Nothing Then
                    Panel.visible = False
                End If
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = Request_MasterTable.GetRecord(recList(0).GetID.ToXmlString(), True)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in Request_MasterRecordControl.
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
        
                SetCat_Cost_Free()
                SetCat_Cost_FreeLabel()
                SetCat_Franchise_Order_Number2()
                SetCat_Franchise_Order_NumberLabel()
                SetCat_OTWC_Comments()
                SetCat_OTWC_CommentsLabel()
                SetICS_CATV_Comments()
                SetICS_CATV_CommentsLabel()
                SetICS_SOW_Needed()
                SetICS_SOW_NeededLabel()
                SetICS_SOW_Uploaded()
                SetICS_SOW_UploadedLabel()
                SetIROC_Id()
                SetIROC_IdLabel1()
                SetOTW_Completed_Dt()
                SetOTW_Completed_DtLabel()
                SetOTW_Construction_Status()
                SetOTW_Construction_StatusLabel()
                SetOTW_Deployment_Start_Dt()
                SetOTW_Deployment_Start_DtLabel()
                SetOTW_Invoice_Amt()
                SetOTW_Invoice_AmtLabel()
                SetOTW_Invoice_Dt()
                SetOTW_Invoice_DtLabel()
                SetOTW_Invoice_No()
                SetOTW_Invoice_NoLabel()
                SetOTW_Island_completed()
                SetOTW_Island_completedLabel()
                SetOTW_More_Info_Flag()
                SetOTW_More_Info_FlagLabel()
                SetOTW_On_Net()
                SetOTW_On_NetLabel()
                SetOTW_Permit_Status()
                SetOTW_Permit_StatusLabel()
                SetOTW_Premise_Fiber_Work_Reqd()
                SetOTW_Premise_Fiber_Work_ReqdLabel()
                SetOTW_Projected_Deploy_Dt()
                SetOTW_Projected_Deploy_DtLabel()
                SetOTW_Quote()
                SetOTW_Quote1()
                SetOTW_QuoteLabel()
                SetOTW_QuoteLabel1()
                SetOTW_Scheduled_Deploy_Dt()
                SetOTW_Scheduled_Deploy_DtLabel()
                SetPending_Action_Dt1()
                SetPending_Action_DtLabel()
                SetPending_Action_Needed1()
                SetPending_Action_NeededLabel()
                SetPending_Agency_Return()
                SetPending_Agency_ReturnLabel()
                SetPending_AgencyLabel()
                SetPending_Prev_Action_Needed()
                SetPending_Prev_Action_NeededLabel()
                SetPending_Prev_Status()
                SetPending_Prev_StatusLabel()
                SetPriority()
                SetPriorityLabel()
                SetProv_Name()
                SetProv_NameLabel()
                SetReg_Type1()
                SetReg_TypeLabel1()
                SetReq_Address1()
                SetReq_AddressLabel1()
                SetReq_City1()
                SetReq_CityLabel1()
                SetReq_Comments()
                SetReq_CommentsLabel()
                SetReq_Completed_Dt()
                SetReq_Completed_DtLabel()
                SetReq_Contact_Email()
                SetReq_Contact_EmailLabel()
                SetReq_Dt1()
                SetReq_DtLabel1()
                SetReq_Enity2()
                SetReq_EnityLabel1()
                SetReq_Funding_Src2()
                SetReq_Funding_SrcLabel1()
                SetReq_Island1()
                SetReq_IslandLabel1()
                SetReq_PO_Amt()
                SetReq_PO_AmtLabel()
                SetReq_PO_Dt()
                SetReq_PO_DtLabel()
                SetReq_PO_No()
                SetReq_PO_NoLabel()
                SetReq_Pymt_Amt()
                SetReq_Pymt_AmtLabel()
                SetReq_Pymt_Check_No()
                SetReq_Pymt_Check_NoLabel()
                SetReq_Pymt_Dt()
                SetReq_Pymt_DtLabel()
                SetReq_Quote_Approved()
                SetReq_Quote_ApprovedLabel()
                SetReq_Site_Name1()
                SetReq_Site_NameLabel1()
                SetReq_State1()
                SetReq_StateLabel1()
                SetReq_Status()
                SetReq_StatusLabel()
                SetReq_Target_Dt1()
                SetReq_Target_DtLabel1()
                SetReq_Zip1()
                SetReq_ZipLabel1()
                SetRequest_Id()
                SetRequest_IdLabel()
                
                
                
                
                
                
                
                SetPending_Agency1()
      
      
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
            
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "CommentsTableControl"), CommentsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recCommentsTableControl.ResetControl()
            End IF
        
        recCommentsTableControl.LoadData()
        recCommentsTableControl.DataBind()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "ContactsTableControl"), ContactsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recContactsTableControl.ResetControl()
            End IF
        
        recContactsTableControl.LoadData()
        recContactsTableControl.DataBind()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "UploadsTableControl"), UploadsTableControl)
        
            If (shouldResetControl OrElse Me.Page.IsPageRefresh)
              recUploadsTableControl.ResetControl()
            End IF
        
        recUploadsTableControl.LoadData()
        recUploadsTableControl.DataBind()
        
        End Sub
        
        
        Public Overridable Sub SetCat_Cost_Free()
            
        
            ' Set the Cat_Cost_Free CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Cost_Free is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetCat_Cost_Free()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Cost_FreeSpecified Then
                									
                ' If the Cat_Cost_Free is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.Cat_Cost_Free.Checked = Me.DataSource.Cat_Cost_Free
            Else
            
                ' Cat_Cost_Free is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.Cat_Cost_Free.Checked = Request_MasterTable.Cat_Cost_Free.ParseValue(Request_MasterTable.Cat_Cost_Free.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_Number2()
            
        
            ' Set the Cat_Franchise_Order_Number2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_Franchise_Order_Number2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_Franchise_Order_Number2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_Franchise_Order_Number2Specified Then
                				
                ' If the Cat_Franchise_Order_Number2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_Franchise_Order_Number2)
                              
                Me.Cat_Franchise_Order_Number2.Text = formattedValue
                
            Else 
            
                ' Cat_Franchise_Order_Number2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_Franchise_Order_Number2.Text = Request_MasterTable.Cat_Franchise_Order_Number2.Format(Request_MasterTable.Cat_Franchise_Order_Number2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCat_OTWC_Comments()
            
        
            ' Set the Cat_OTWC_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Cat_OTWC_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCat_OTWC_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Cat_OTWC_CommentsSpecified Then
                				
                ' If the Cat_OTWC_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Cat_OTWC_Comments)
                              
                Me.Cat_OTWC_Comments.Text = formattedValue
                
            Else 
            
                ' Cat_OTWC_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Cat_OTWC_Comments.Text = Request_MasterTable.Cat_OTWC_Comments.Format(Request_MasterTable.Cat_OTWC_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetICS_CATV_Comments()
            
        
            ' Set the ICS_CATV_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_CATV_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetICS_CATV_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_CATV_CommentsSpecified Then
                				
                ' If the ICS_CATV_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.ICS_CATV_Comments)
                              
                Me.ICS_CATV_Comments.Text = formattedValue
                
            Else 
            
                ' ICS_CATV_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.ICS_CATV_Comments.Text = Request_MasterTable.ICS_CATV_Comments.Format(Request_MasterTable.ICS_CATV_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetICS_SOW_Needed()
            
        
            ' Set the ICS_SOW_Needed CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Needed is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetICS_SOW_Needed()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_NeededSpecified Then
                									
                ' If the ICS_SOW_Needed is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.ICS_SOW_Needed.Checked = Me.DataSource.ICS_SOW_Needed
            Else
            
                ' ICS_SOW_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.ICS_SOW_Needed.Checked = Request_MasterTable.ICS_SOW_Needed.ParseValue(Request_MasterTable.ICS_SOW_Needed.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetICS_SOW_Uploaded()
            
        
            ' Set the ICS_SOW_Uploaded CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.ICS_SOW_Uploaded is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetICS_SOW_Uploaded()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.ICS_SOW_UploadedSpecified Then
                									
                ' If the ICS_SOW_Uploaded is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.ICS_SOW_Uploaded.Checked = Me.DataSource.ICS_SOW_Uploaded
            Else
            
                ' ICS_SOW_Uploaded is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.ICS_SOW_Uploaded.Checked = Request_MasterTable.ICS_SOW_Uploaded.ParseValue(Request_MasterTable.ICS_SOW_Uploaded.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetIROC_Id()
            
        
            ' Set the IROC_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.IROC_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetIROC_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IROC_IdSpecified Then
                				
                ' If the IROC_Id is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.IROC_Id)
                              
                Me.IROC_Id.Text = formattedValue
                
            Else 
            
                ' IROC_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.IROC_Id.Text = Request_MasterTable.IROC_Id.Format(Request_MasterTable.IROC_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Completed_Dt()
            
        
            ' Set the OTW_Completed_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Completed_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Completed_DtSpecified Then
                				
                ' If the OTW_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Completed_Dt, "g")
                              
                Me.OTW_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Completed_Dt.Text = Request_MasterTable.OTW_Completed_Dt.Format(Request_MasterTable.OTW_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Construction_Status()
            
        
            ' Set the OTW_Construction_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Construction_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Construction_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Construction_StatusSpecified Then
                				
                ' If the OTW_Construction_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Construction_Status)
                              
                Me.OTW_Construction_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Construction_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Construction_Status.Text = Request_MasterTable.OTW_Construction_Status.Format(Request_MasterTable.OTW_Construction_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_Dt()
            
        
            ' Set the OTW_Deployment_Start_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Deployment_Start_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Deployment_Start_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Deployment_Start_DtSpecified Then
                				
                ' If the OTW_Deployment_Start_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Deployment_Start_Dt, "g")
                              
                Me.OTW_Deployment_Start_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Deployment_Start_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Deployment_Start_Dt.Text = Request_MasterTable.OTW_Deployment_Start_Dt.Format(Request_MasterTable.OTW_Deployment_Start_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Amt()
            
        
            ' Set the OTW_Invoice_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_AmtSpecified Then
                				
                ' If the OTW_Invoice_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Amt, "C")
                              
                Me.OTW_Invoice_Amt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Amt.Text = Request_MasterTable.OTW_Invoice_Amt.Format(Request_MasterTable.OTW_Invoice_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_Dt()
            
        
            ' Set the OTW_Invoice_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_DtSpecified Then
                				
                ' If the OTW_Invoice_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_Dt, "d")
                              
                Me.OTW_Invoice_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_Dt.Text = Request_MasterTable.OTW_Invoice_Dt.Format(Request_MasterTable.OTW_Invoice_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Invoice_No()
            
        
            ' Set the OTW_Invoice_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Invoice_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Invoice_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Invoice_NoSpecified Then
                				
                ' If the OTW_Invoice_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Invoice_No)
                              
                Me.OTW_Invoice_No.Text = formattedValue
                
            Else 
            
                ' OTW_Invoice_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Invoice_No.Text = Request_MasterTable.OTW_Invoice_No.Format(Request_MasterTable.OTW_Invoice_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Island_completed()
            
        
            ' Set the OTW_Island completed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Island_completed is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Island_completed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Island_completedSpecified Then
                				
                ' If the OTW_Island completed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Island_completed)
                              
                Me.OTW_Island_completed.Text = formattedValue
                
            Else 
            
                ' OTW_Island completed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Island_completed.Text = Request_MasterTable.OTW_Island_completed.Format(Request_MasterTable.OTW_Island_completed.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_More_Info_Flag()
            
        
            ' Set the OTW_More_Info_Flag CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_More_Info_Flag is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_More_Info_Flag()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_More_Info_FlagSpecified Then
                									
                ' If the OTW_More_Info_Flag is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_More_Info_Flag.Checked = Me.DataSource.OTW_More_Info_Flag
            Else
            
                ' OTW_More_Info_Flag is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_More_Info_Flag.Checked = Request_MasterTable.OTW_More_Info_Flag.ParseValue(Request_MasterTable.OTW_More_Info_Flag.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetOTW_On_Net()
            
        
            ' Set the OTW_On-Net CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_On_Net is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_On_Net()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_On_NetSpecified Then
                									
                ' If the OTW_On-Net is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_On_Net.Checked = Me.DataSource.OTW_On_Net
            Else
            
                ' OTW_On-Net is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_On_Net.Checked = Request_MasterTable.OTW_On_Net.ParseValue(Request_MasterTable.OTW_On_Net.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetOTW_Permit_Status()
            
        
            ' Set the OTW_Permit_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Permit_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Permit_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Permit_StatusSpecified Then
                				
                ' If the OTW_Permit_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Permit_Status)
                              
                Me.OTW_Permit_Status.Text = formattedValue
                
            Else 
            
                ' OTW_Permit_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Permit_Status.Text = Request_MasterTable.OTW_Permit_Status.Format(Request_MasterTable.OTW_Permit_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_Reqd()
            
        
            ' Set the OTW_Premise Fiber Work Reqd CheckBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Premise_Fiber_Work_Reqd is the ASP:CheckBox on the webpage.

            ' You can modify this method directly, or replace it with a call to
            ' MyBase.SetOTW_Premise_Fiber_Work_Reqd()
            ' and add your own code before or after the call to the MyBase function.

                    
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Premise_Fiber_Work_ReqdSpecified Then
                									
                ' If the OTW_Premise Fiber Work Reqd is non-NULL, then format the value.
                ' The Format method will use the Display Format
                Me.OTW_Premise_Fiber_Work_Reqd.Checked = Me.DataSource.OTW_Premise_Fiber_Work_Reqd
            Else
            
                ' OTW_Premise Fiber Work Reqd is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Not Me.DataSource.IsCreated Then
                    Me.OTW_Premise_Fiber_Work_Reqd.Checked = Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.ParseValue(Request_MasterTable.OTW_Premise_Fiber_Work_Reqd.DefaultValue).ToBoolean()
                End If
                    				
            End If
                
        End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_Dt()
            
        
            ' Set the OTW_Projected_Deploy_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Projected_Deploy_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Projected_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Projected_Deploy_DtSpecified Then
                				
                ' If the OTW_Projected_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Projected_Deploy_Dt, "g")
                              
                Me.OTW_Projected_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Projected_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Projected_Deploy_Dt.Text = Request_MasterTable.OTW_Projected_Deploy_Dt.Format(Request_MasterTable.OTW_Projected_Deploy_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Quote()
            
        
            ' Set the OTW_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                Me.OTW_Quote.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Quote1()
            
        
            ' Set the OTW_Quote TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Quote1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Quote1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_QuoteSpecified Then
                				
                ' If the OTW_Quote is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Quote)
                              
                Me.OTW_Quote1.Text = formattedValue
                
            Else 
            
                ' OTW_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Quote1.Text = Request_MasterTable.OTW_Quote.Format(Request_MasterTable.OTW_Quote.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_Dt()
            
        
            ' Set the OTW_Scheduled_Deploy_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.OTW_Scheduled_Deploy_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetOTW_Scheduled_Deploy_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.OTW_Scheduled_Deploy_DtSpecified Then
                				
                ' If the OTW_Scheduled_Deploy_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt, "g")
                              
                Me.OTW_Scheduled_Deploy_Dt.Text = formattedValue
                
            Else 
            
                ' OTW_Scheduled_Deploy_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.OTW_Scheduled_Deploy_Dt.Text = Request_MasterTable.OTW_Scheduled_Deploy_Dt.Format(Request_MasterTable.OTW_Scheduled_Deploy_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Dt1()
            
        
            ' Set the Pending Action_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending Action_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Dt, "g")
                              
                Me.Pending_Action_Dt1.Text = formattedValue
                
            Else 
            
                ' Pending Action_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Dt1.Text = EvaluateFormula("Format(Now(), ""D"")", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Action_Needed1()
            
        
            ' Set the Pending_Action_Needed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Action_Needed1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Action_Needed1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Action_Needed)
                              
                Me.Pending_Action_Needed1.Text = formattedValue
                
            Else 
            
                ' Pending_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Action_Needed1.Text = EvaluateFormula("""Incomplete Request""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Agency_Return()
            
        
            ' Set the Pending_Agency_Return TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency_Return is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency_Return()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Agency_ReturnSpecified Then
                				
                ' If the Pending_Agency_Return is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency_Return)
                              
                Me.Pending_Agency_Return.Text = formattedValue
                
            Else 
            
                ' Pending_Agency_Return is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency_Return.Text = Request_MasterTable.Pending_Agency_Return.Format(Request_MasterTable.Pending_Agency_Return.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Prev_Action_Needed()
            
        
            ' Set the Pending_Prev_Action_Needed TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Action_Needed is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Action_Needed()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_Action_NeededSpecified Then
                				
                ' If the Pending_Prev_Action_Needed is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Action_Needed)
                              
                Me.Pending_Prev_Action_Needed.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Action_Needed is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Action_Needed.Text = Request_MasterTable.Pending_Prev_Action_Needed.Format(Request_MasterTable.Pending_Prev_Action_Needed.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Prev_Status()
            
        
            ' Set the Pending_Prev_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Prev_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Prev_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Pending_Prev_StatusSpecified Then
                				
                ' If the Pending_Prev_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Prev_Status)
                              
                Me.Pending_Prev_Status.Text = formattedValue
                
            Else 
            
                ' Pending_Prev_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Prev_Status.Text = Request_MasterTable.Pending_Prev_Status.Format(Request_MasterTable.Pending_Prev_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPriority()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Priority DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Priority is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPriority()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.PrioritySpecified Then
                            
                ' If the Priority is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Priority.ToString()
            Else
                
                ' Priority is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Priority.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulatePriorityDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetProv_Name()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Prov_Name DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Prov_Name is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetProv_Name()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Prov_NameSpecified Then
                            
                ' If the Prov_Name is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Prov_Name
            Else
                
                ' Prov_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Prov_Name.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateProv_NameDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetReg_Type1()
            
        
            ' Set the Reg_Type TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Reg_Type1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReg_Type1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Reg_TypeSpecified Then
                				
                ' If the Reg_Type is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Reg_Type)
                              
                Me.Reg_Type1.Text = formattedValue
                
            Else 
            
                ' Reg_Type is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Reg_Type1.Text = Request_MasterTable.Reg_Type.Format(Request_MasterTable.Reg_Type.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Address1()
            
        
            ' Set the Req_Address TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Address1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Address1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_AddressSpecified Then
                				
                ' If the Req_Address is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Address)
                              
                Me.Req_Address1.Text = formattedValue
                
            Else 
            
                ' Req_Address is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Address1.Text = Request_MasterTable.Req_Address.Format(Request_MasterTable.Req_Address.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_City1()
            
        
            ' Set the Req_City TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_City1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_City1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CitySpecified Then
                				
                ' If the Req_City is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_City)
                              
                Me.Req_City1.Text = formattedValue
                
            Else 
            
                ' Req_City is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_City1.Text = Request_MasterTable.Req_City.Format(Request_MasterTable.Req_City.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Comments()
            
        
            ' Set the Req_Comments TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Comments is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_CommentsSpecified Then
                				
                ' If the Req_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Comments)
                              
                Me.Req_Comments.Text = formattedValue
                
            Else 
            
                ' Req_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Comments.Text = Request_MasterTable.Req_Comments.Format(Request_MasterTable.Req_Comments.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Completed_Dt()
            
        
            ' Set the Req_Completed_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Completed_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Completed_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Completed_DtSpecified Then
                				
                ' If the Req_Completed_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Completed_Dt, "g")
                              
                Me.Req_Completed_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Completed_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Completed_Dt.Text = Request_MasterTable.Req_Completed_Dt.Format(Request_MasterTable.Req_Completed_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Contact_Email()
            
        
            ' Set the Req_Contact_Email2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Contact_Email is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Contact_Email()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Contact_Email2Specified Then
                				
                ' If the Req_Contact_Email2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Contact_Email2)
                              
                Me.Req_Contact_Email.Text = formattedValue
                
            Else 
            
                ' Req_Contact_Email2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Contact_Email.Text = Request_MasterTable.Req_Contact_Email2.Format(Request_MasterTable.Req_Contact_Email2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Dt1()
            
        
            ' Set the Req_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Dt, "g")
                              
                Me.Req_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Dt1.Text = EvaluateFormula("Format(Today(), ""d"")", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Enity2()
            
        
            ' Set the Req_Enity2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Enity2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Enity2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Enity2Specified Then
                				
                ' If the Req_Enity2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Enity2)
                              
                Me.Req_Enity2.Text = formattedValue
                
            Else 
            
                ' Req_Enity2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Enity2.Text = Request_MasterTable.Req_Enity2.Format(Request_MasterTable.Req_Enity2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Funding_Src2()
            
        
            ' Set the Req_Funding_Src2 TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Funding_Src2 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Funding_Src2()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Funding_Src2Specified Then
                				
                ' If the Req_Funding_Src2 is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Funding_Src2)
                              
                Me.Req_Funding_Src2.Text = formattedValue
                
            Else 
            
                ' Req_Funding_Src2 is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Funding_Src2.Text = Request_MasterTable.Req_Funding_Src2.Format(Request_MasterTable.Req_Funding_Src2.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Island1()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the Req_Island DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Island1 is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Island1()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_IslandSpecified Then
                            
                ' If the Req_Island is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.Req_Island
            Else
                
                ' Req_Island is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = Request_MasterTable.Req_Island.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateReq_Island1DropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetReq_PO_Amt()
            
        
            ' Set the Req_PO_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_AmtSpecified Then
                				
                ' If the Req_PO_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Amt, "C")
                              
                Me.Req_PO_Amt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Amt.Text = Request_MasterTable.Req_PO_Amt.Format(Request_MasterTable.Req_PO_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_Dt()
            
        
            ' Set the Req_PO_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_DtSpecified Then
                				
                ' If the Req_PO_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_Dt, "d")
                              
                Me.Req_PO_Dt.Text = formattedValue
                
            Else 
            
                ' Req_PO_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_Dt.Text = Request_MasterTable.Req_PO_Dt.Format(Request_MasterTable.Req_PO_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_PO_No()
            
        
            ' Set the Req_PO_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_PO_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_PO_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_PO_NoSpecified Then
                				
                ' If the Req_PO_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_PO_No)
                              
                Me.Req_PO_No.Text = formattedValue
                
            Else 
            
                ' Req_PO_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_PO_No.Text = Request_MasterTable.Req_PO_No.Format(Request_MasterTable.Req_PO_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Amt()
            
        
            ' Set the Req_Pymt_Amt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Amt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Amt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_AmtSpecified Then
                				
                ' If the Req_Pymt_Amt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Amt, "C")
                              
                Me.Req_Pymt_Amt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Amt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Amt.Text = Request_MasterTable.Req_Pymt_Amt.Format(Request_MasterTable.Req_Pymt_Amt.DefaultValue, "C")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Check_No()
            
        
            ' Set the Req_Pymt_Check_No TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Check_No is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Check_No()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_Check_NoSpecified Then
                				
                ' If the Req_Pymt_Check_No is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Check_No)
                              
                Me.Req_Pymt_Check_No.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Check_No is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Check_No.Text = Request_MasterTable.Req_Pymt_Check_No.Format(Request_MasterTable.Req_Pymt_Check_No.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Pymt_Dt()
            
        
            ' Set the Req_Pymt_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Pymt_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Pymt_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Pymt_DtSpecified Then
                				
                ' If the Req_Pymt_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Pymt_Dt, "d")
                              
                Me.Req_Pymt_Dt.Text = formattedValue
                
            Else 
            
                ' Req_Pymt_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Pymt_Dt.Text = Request_MasterTable.Req_Pymt_Dt.Format(Request_MasterTable.Req_Pymt_Dt.DefaultValue, "d")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Quote_Approved()
            
        
            ' Set the Req_Quote_Approved TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Quote_Approved is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Quote_Approved()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Quote_ApprovedSpecified Then
                				
                ' If the Req_Quote_Approved is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Quote_Approved, "g")
                              
                Me.Req_Quote_Approved.Text = formattedValue
                
            Else 
            
                ' Req_Quote_Approved is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Quote_Approved.Text = Request_MasterTable.Req_Quote_Approved.Format(Request_MasterTable.Req_Quote_Approved.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Site_Name1()
            
        
            ' Set the Req_Site_Name TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Site_Name1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Site_Name1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Site_NameSpecified Then
                				
                ' If the Req_Site_Name is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Site_Name)
                              
                Me.Req_Site_Name1.Text = formattedValue
                
            Else 
            
                ' Req_Site_Name is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Site_Name1.Text = Request_MasterTable.Req_Site_Name.Format(Request_MasterTable.Req_Site_Name.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_State1()
            
        
            ' Set the Req_State TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_State1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_State1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Req_State is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_State)
                              
                Me.Req_State1.Text = formattedValue
                
            Else 
            
                ' Req_State is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_State1.Text = EvaluateFormula("""HI""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Status()
            
        
            ' Set the Req_Status TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Status is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Status()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_StatusSpecified Then
                				
                ' If the Req_Status is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Status)
                              
                Me.Req_Status.Text = formattedValue
                
            Else 
            
                ' Req_Status is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Status.Text = Request_MasterTable.Req_Status.Format(Request_MasterTable.Req_Status.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Target_Dt1()
            
        
            ' Set the Req_Target_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Target_Dt1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Target_Dt1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_Target_DtSpecified Then
                				
                ' If the Req_Target_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Target_Dt, "g")
                              
                Me.Req_Target_Dt1.Text = formattedValue
                
            Else 
            
                ' Req_Target_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Target_Dt1.Text = Request_MasterTable.Req_Target_Dt.Format(Request_MasterTable.Req_Target_Dt.DefaultValue, "g")
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetReq_Zip1()
            
        
            ' Set the Req_Zip TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Req_Zip1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetReq_Zip1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Req_ZipSpecified Then
                				
                ' If the Req_Zip is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Req_Zip)
                              
                Me.Req_Zip1.Text = formattedValue
                
            Else 
            
                ' Req_Zip is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Req_Zip1.Text = Request_MasterTable.Req_Zip.Format(Request_MasterTable.Req_Zip.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRequest_Id()
            
        
            ' Set the Request_Id Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Request_Id is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Request_IdSpecified Then
                				
                ' If the Request_Id is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = ""
                Dim _isExpandableNonCompositeForeignKey As Boolean = Request_MasterTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(Request_MasterTable.Request_Id)
                If _isExpandableNonCompositeForeignKey AndAlso Request_MasterTable.Request_Id.IsApplyDisplayAs Then
                                  
                       formattedValue = Request_MasterTable.GetDFKA(Me.DataSource.Request_Id.ToString(),Request_MasterTable.Request_Id, Nothing)
                                    
                       If (formattedValue Is Nothing) Then
                              formattedValue = Me.DataSource.Format(Request_MasterTable.Request_Id)
                       End If
                Else
                       formattedValue = Me.DataSource.Request_Id.ToString()
                End If
                                
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Request_Id.Text = formattedValue
                
            Else 
            
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Request_Id.Text = Request_MasterTable.Request_Id.Format(Request_MasterTable.Request_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetPending_Agency1()
            
        
            ' Set the Pending_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Request_Master database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Request_Master record retrieved from the database.
            ' Me.Pending_Agency1 is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetPending_Agency1()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Pending_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(Request_MasterTable.Pending_Agency)
                              
                Me.Pending_Agency1.Text = formattedValue
                
            Else 
            
                ' Pending_Agency is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Pending_Agency1.Text = EvaluateFormula("""REQUESTOR""", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCat_Cost_FreeLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_Cost_FreeLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetCat_Franchise_Order_NumberLabel()
                  
                  End Sub
                
        Public Overridable Sub SetCat_OTWC_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Cat_OTWC_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_CATV_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.ICS_CATV_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetICS_SOW_NeededLabel()
                  
                  End Sub
                
        Public Overridable Sub SetICS_SOW_UploadedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetIROC_IdLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.IROC_IdLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetOTW_Completed_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Construction_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Deployment_Start_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Invoice_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Island_completedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_More_Info_FlagLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_On_NetLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Permit_StatusLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Premise_Fiber_Work_ReqdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Projected_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_QuoteLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetOTW_Scheduled_Deploy_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetPending_Action_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Action_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Agency_ReturnLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Agency_ReturnLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_AgencyLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_AgencyLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Prev_Action_NeededLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Prev_Action_NeededLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPending_Prev_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Pending_Prev_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetPriorityLabel()
                  
                  End Sub
                
        Public Overridable Sub SetProv_NameLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Prov_NameLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReg_TypeLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Reg_TypeLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_AddressLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_AddressLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_CityLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_CityLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Completed_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Completed_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Contact_EmailLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Contact_EmailLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_EnityLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_EnityLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Funding_SrcLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Funding_SrcLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_IslandLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_IslandLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_PO_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_PO_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_PO_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_AmtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_Check_NoLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Pymt_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Quote_ApprovedLabel()
                  
                  End Sub
                
        Public Overridable Sub SetReq_Site_NameLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Site_NameLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_StateLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StateLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_StatusLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_StatusLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_Target_DtLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_Target_DtLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetReq_ZipLabel1()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Req_ZipLabel1.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetRequest_IdLabel()
                  
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

      
        
        ' To customize, override this method in Request_MasterRecordControl.
        Public Overridable Sub SaveData()
            ' Saves the associated record in the database.
            ' SaveData calls Validate and Get methods - so it may be more appropriate to
            ' customize those methods.

            ' 1. Load the existing record from the database. Since we save the entire record, this ensures 
            ' that fields that are not displayed are also properly initialized.
            Me.LoadData()
        
          Dim Panel As System.Web.UI.WebControls.Panel = CType(MiscUtils.FindControlRecursively(Me, "Request_MasterRecordControlPanel"), System.Web.UI.WebControls.Panel)

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
          
        Dim recCommentsTableControl as CommentsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "CommentsTableControl"), CommentsTableControl)
        recCommentsTableControl.SaveData()
        
        Dim recContactsTableControl as ContactsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "ContactsTableControl"), ContactsTableControl)
        recContactsTableControl.SaveData()
        
        Dim recUploadsTableControl as UploadsTableControl = DirectCast(MiscUtils.FindControlRecursively(Me.Page, "UploadsTableControl"), UploadsTableControl)
        recUploadsTableControl.SaveData()
        
        End Sub

        ' To customize, override this method in Request_MasterRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetCat_Cost_Free()
            GetCat_Franchise_Order_Number2()
            GetCat_OTWC_Comments()
            GetICS_CATV_Comments()
            GetICS_SOW_Needed()
            GetICS_SOW_Uploaded()
            GetIROC_Id()
            GetOTW_Completed_Dt()
            GetOTW_Construction_Status()
            GetOTW_Deployment_Start_Dt()
            GetOTW_Invoice_Amt()
            GetOTW_Invoice_Dt()
            GetOTW_Invoice_No()
            GetOTW_Island_completed()
            GetOTW_More_Info_Flag()
            GetOTW_On_Net()
            GetOTW_Permit_Status()
            GetOTW_Premise_Fiber_Work_Reqd()
            GetOTW_Projected_Deploy_Dt()
            GetOTW_Quote()
            GetOTW_Quote1()
            GetOTW_Scheduled_Deploy_Dt()
            GetPending_Action_Dt1()
            GetPending_Action_Needed1()
            GetPending_Agency_Return()
            GetPending_Prev_Action_Needed()
            GetPending_Prev_Status()
            GetPriority()
            GetProv_Name()
            GetReg_Type1()
            GetReq_Address1()
            GetReq_City1()
            GetReq_Comments()
            GetReq_Completed_Dt()
            GetReq_Contact_Email()
            GetReq_Dt1()
            GetReq_Enity2()
            GetReq_Funding_Src2()
            GetReq_Island1()
            GetReq_PO_Amt()
            GetReq_PO_Dt()
            GetReq_PO_No()
            GetReq_Pymt_Amt()
            GetReq_Pymt_Check_No()
            GetReq_Pymt_Dt()
            GetReq_Quote_Approved()
            GetReq_Site_Name1()
            GetReq_State1()
            GetReq_Status()
            GetReq_Target_Dt1()
            GetReq_Zip1()
            GetRequest_Id()
            GetPending_Agency1()
        End Sub
        
        
        Public Overridable Sub GetCat_Cost_Free()
        
        
            ' Retrieve the value entered by the user on the Cat_Cost_Free ASP:CheckBox, and
            ' save it into the Cat_Cost_Free field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.Cat_Cost_Free = Me.Cat_Cost_Free.Checked
                    
        End Sub
                
        Public Overridable Sub GetCat_Franchise_Order_Number2()
            
            ' Retrieve the value entered by the user on the Cat_Franchise_Order_Number2 ASP:TextBox, and
            ' save it into the Cat_Franchise_Order_Number2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_Franchise_Order_Number2.Text, Request_MasterTable.Cat_Franchise_Order_Number2)			

                      
        End Sub
                
        Public Overridable Sub GetCat_OTWC_Comments()
            
            ' Retrieve the value entered by the user on the Cat_OTWC_Comments ASP:TextBox, and
            ' save it into the Cat_OTWC_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Cat_OTWC_Comments.Text, Request_MasterTable.Cat_OTWC_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetICS_CATV_Comments()
            
            ' Retrieve the value entered by the user on the ICS_CATV_Comments ASP:TextBox, and
            ' save it into the ICS_CATV_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.ICS_CATV_Comments.Text, Request_MasterTable.ICS_CATV_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetICS_SOW_Needed()
        
        
            ' Retrieve the value entered by the user on the ICS_SOW_Needed ASP:CheckBox, and
            ' save it into the ICS_SOW_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.ICS_SOW_Needed = Me.ICS_SOW_Needed.Checked
                    
        End Sub
                
        Public Overridable Sub GetICS_SOW_Uploaded()
        
        
            ' Retrieve the value entered by the user on the ICS_SOW_Uploaded ASP:CheckBox, and
            ' save it into the ICS_SOW_Uploaded field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.ICS_SOW_Uploaded = Me.ICS_SOW_Uploaded.Checked
                    
        End Sub
                
        Public Overridable Sub GetIROC_Id()
            
            ' Retrieve the value entered by the user on the IROC_Id ASP:TextBox, and
            ' save it into the IROC_Id field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.IROC_Id.Text, Request_MasterTable.IROC_Id)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Completed_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Completed_Dt ASP:TextBox, and
            ' save it into the OTW_Completed_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Completed_Dt.Text, Request_MasterTable.OTW_Completed_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Construction_Status()
            
            ' Retrieve the value entered by the user on the OTW_Construction_Status ASP:TextBox, and
            ' save it into the OTW_Construction_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Construction_Status.Text, Request_MasterTable.OTW_Construction_Status)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Deployment_Start_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Deployment_Start_Dt ASP:TextBox, and
            ' save it into the OTW_Deployment_Start_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Deployment_Start_Dt.Text, Request_MasterTable.OTW_Deployment_Start_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Amt()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_Amt ASP:TextBox, and
            ' save it into the OTW_Invoice_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_Amt.Text, Request_MasterTable.OTW_Invoice_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_Dt ASP:TextBox, and
            ' save it into the OTW_Invoice_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_Dt.Text, Request_MasterTable.OTW_Invoice_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Invoice_No()
            
            ' Retrieve the value entered by the user on the OTW_Invoice_No ASP:TextBox, and
            ' save it into the OTW_Invoice_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Invoice_No.Text, Request_MasterTable.OTW_Invoice_No)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Island_completed()
            
            ' Retrieve the value entered by the user on the OTW_Island completed ASP:TextBox, and
            ' save it into the OTW_Island completed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Island_completed.Text, Request_MasterTable.OTW_Island_completed)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_More_Info_Flag()
        
        
            ' Retrieve the value entered by the user on the OTW_More_Info_Flag ASP:CheckBox, and
            ' save it into the OTW_More_Info_Flag field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_More_Info_Flag = Me.OTW_More_Info_Flag.Checked
                    
        End Sub
                
        Public Overridable Sub GetOTW_On_Net()
        
        
            ' Retrieve the value entered by the user on the OTW_On-Net ASP:CheckBox, and
            ' save it into the OTW_On-Net field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_On_Net = Me.OTW_On_Net.Checked
                    
        End Sub
                
        Public Overridable Sub GetOTW_Permit_Status()
            
            ' Retrieve the value entered by the user on the OTW_Permit_Status ASP:TextBox, and
            ' save it into the OTW_Permit_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Permit_Status.Text, Request_MasterTable.OTW_Permit_Status)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Premise_Fiber_Work_Reqd()
        
        
            ' Retrieve the value entered by the user on the OTW_Premise Fiber Work Reqd ASP:CheckBox, and
            ' save it into the OTW_Premise Fiber Work Reqd field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Custom validation should be performed in Validate, not here.
            
            
            Me.DataSource.OTW_Premise_Fiber_Work_Reqd = Me.OTW_Premise_Fiber_Work_Reqd.Checked
                    
        End Sub
                
        Public Overridable Sub GetOTW_Projected_Deploy_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Projected_Deploy_Dt ASP:TextBox, and
            ' save it into the OTW_Projected_Deploy_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Projected_Deploy_Dt.Text, Request_MasterTable.OTW_Projected_Deploy_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Quote()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote.Text, Request_MasterTable.OTW_Quote)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Quote1()
            
            ' Retrieve the value entered by the user on the OTW_Quote ASP:TextBox, and
            ' save it into the OTW_Quote field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Quote1.Text, Request_MasterTable.OTW_Quote)			

                      
        End Sub
                
        Public Overridable Sub GetOTW_Scheduled_Deploy_Dt()
            
            ' Retrieve the value entered by the user on the OTW_Scheduled_Deploy_Dt ASP:TextBox, and
            ' save it into the OTW_Scheduled_Deploy_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.OTW_Scheduled_Deploy_Dt.Text, Request_MasterTable.OTW_Scheduled_Deploy_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Action_Dt1()
            
            ' Retrieve the value entered by the user on the Pending Action_Dt ASP:TextBox, and
            ' save it into the Pending Action_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Dt1.Text, Request_MasterTable.Pending_Action_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Action_Needed1()
            
            ' Retrieve the value entered by the user on the Pending_Action_Needed ASP:TextBox, and
            ' save it into the Pending_Action_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Action_Needed1.Text, Request_MasterTable.Pending_Action_Needed)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Agency_Return()
            
            ' Retrieve the value entered by the user on the Pending_Agency_Return ASP:TextBox, and
            ' save it into the Pending_Agency_Return field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency_Return.Text, Request_MasterTable.Pending_Agency_Return)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Prev_Action_Needed()
            
            ' Retrieve the value entered by the user on the Pending_Prev_Action_Needed ASP:TextBox, and
            ' save it into the Pending_Prev_Action_Needed field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Prev_Action_Needed.Text, Request_MasterTable.Pending_Prev_Action_Needed)			

                      
        End Sub
                
        Public Overridable Sub GetPending_Prev_Status()
            
            ' Retrieve the value entered by the user on the Pending_Prev_Status ASP:TextBox, and
            ' save it into the Pending_Prev_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Prev_Status.Text, Request_MasterTable.Pending_Prev_Status)			

                      
        End Sub
                
        Public Overridable Sub GetPriority()
         
            ' Retrieve the value entered by the user on the Priority ASP:DropDownList, and
            ' save it into the Priority field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Priority), Request_MasterTable.Priority)				
            
        End Sub
                
        Public Overridable Sub GetProv_Name()
         
            ' Retrieve the value entered by the user on the Prov_Name ASP:DropDownList, and
            ' save it into the Prov_Name field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Prov_Name), Request_MasterTable.Prov_Name)				
            
        End Sub
                
        Public Overridable Sub GetReg_Type1()
            
            ' Retrieve the value entered by the user on the Reg_Type ASP:TextBox, and
            ' save it into the Reg_Type field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Reg_Type1.Text, Request_MasterTable.Reg_Type)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Address1()
            
            ' Retrieve the value entered by the user on the Req_Address ASP:TextBox, and
            ' save it into the Req_Address field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Address1.Text, Request_MasterTable.Req_Address)			

                      
        End Sub
                
        Public Overridable Sub GetReq_City1()
            
            ' Retrieve the value entered by the user on the Req_City ASP:TextBox, and
            ' save it into the Req_City field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_City1.Text, Request_MasterTable.Req_City)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Comments()
            
            ' Retrieve the value entered by the user on the Req_Comments ASP:TextBox, and
            ' save it into the Req_Comments field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Comments.Text, Request_MasterTable.Req_Comments)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Completed_Dt()
            
            ' Retrieve the value entered by the user on the Req_Completed_Dt ASP:TextBox, and
            ' save it into the Req_Completed_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Completed_Dt.Text, Request_MasterTable.Req_Completed_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Contact_Email()
            
            ' Retrieve the value entered by the user on the Req_Contact_Email2 ASP:TextBox, and
            ' save it into the Req_Contact_Email2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Contact_Email.Text, Request_MasterTable.Req_Contact_Email2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Dt1()
            
            ' Retrieve the value entered by the user on the Req_Dt ASP:TextBox, and
            ' save it into the Req_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Dt1.Text, Request_MasterTable.Req_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Enity2()
            
            ' Retrieve the value entered by the user on the Req_Enity2 ASP:TextBox, and
            ' save it into the Req_Enity2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Enity2.Text, Request_MasterTable.Req_Enity2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Funding_Src2()
            
            ' Retrieve the value entered by the user on the Req_Funding_Src2 ASP:TextBox, and
            ' save it into the Req_Funding_Src2 field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Funding_Src2.Text, Request_MasterTable.Req_Funding_Src2)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Island1()
         
            ' Retrieve the value entered by the user on the Req_Island ASP:DropDownList, and
            ' save it into the Req_Island field in DataSource DatabaseIROC%dbo.Request_Master record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.Req_Island1), Request_MasterTable.Req_Island)				
            
        End Sub
                
        Public Overridable Sub GetReq_PO_Amt()
            
            ' Retrieve the value entered by the user on the Req_PO_Amt ASP:TextBox, and
            ' save it into the Req_PO_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_Amt.Text, Request_MasterTable.Req_PO_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_PO_Dt()
            
            ' Retrieve the value entered by the user on the Req_PO_Dt ASP:TextBox, and
            ' save it into the Req_PO_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_Dt.Text, Request_MasterTable.Req_PO_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_PO_No()
            
            ' Retrieve the value entered by the user on the Req_PO_No ASP:TextBox, and
            ' save it into the Req_PO_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_PO_No.Text, Request_MasterTable.Req_PO_No)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Amt()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Amt ASP:TextBox, and
            ' save it into the Req_Pymt_Amt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the amount to ensure it is of the proper format
            ' and valid.  The format is verified based on the current culture 
            ' settings including the currency symbol and decimal separator
            ' (no currency conversion is performed).
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Amt.Text, Request_MasterTable.Req_Pymt_Amt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Check_No()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Check_No ASP:TextBox, and
            ' save it into the Req_Pymt_Check_No field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Check_No.Text, Request_MasterTable.Req_Pymt_Check_No)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Pymt_Dt()
            
            ' Retrieve the value entered by the user on the Req_Pymt_Dt ASP:TextBox, and
            ' save it into the Req_Pymt_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Pymt_Dt.Text, Request_MasterTable.Req_Pymt_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Quote_Approved()
            
            ' Retrieve the value entered by the user on the Req_Quote_Approved ASP:TextBox, and
            ' save it into the Req_Quote_Approved field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Quote_Approved.Text, Request_MasterTable.Req_Quote_Approved)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Site_Name1()
            
            ' Retrieve the value entered by the user on the Req_Site_Name ASP:TextBox, and
            ' save it into the Req_Site_Name field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Site_Name1.Text, Request_MasterTable.Req_Site_Name)			

                      
        End Sub
                
        Public Overridable Sub GetReq_State1()
            
            ' Retrieve the value entered by the user on the Req_State ASP:TextBox, and
            ' save it into the Req_State field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_State1.Text, Request_MasterTable.Req_State)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Status()
            
            ' Retrieve the value entered by the user on the Req_Status ASP:TextBox, and
            ' save it into the Req_Status field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Status.Text, Request_MasterTable.Req_Status)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Target_Dt1()
            
            ' Retrieve the value entered by the user on the Req_Target_Dt ASP:TextBox, and
            ' save it into the Req_Target_Dt field in DataSource DatabaseIROC%dbo.Request_Master record.
            ' Parse will also validate the date to ensure it is of the proper format
            ' and a valid date.  The format is verified based on the current culture 
            ' settings including the order of month, day and year and the separator character.
            ' Parse throws an exception if the date is invalid.
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Target_Dt1.Text, Request_MasterTable.Req_Target_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetReq_Zip1()
            
            ' Retrieve the value entered by the user on the Req_Zip ASP:TextBox, and
            ' save it into the Req_Zip field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Req_Zip1.Text, Request_MasterTable.Req_Zip)			

                      
        End Sub
                
        Public Overridable Sub GetRequest_Id()
            
        End Sub
                
        Public Overridable Sub GetPending_Agency1()
            
            ' Retrieve the value entered by the user on the Pending_Agency ASP:TextBox, and
            ' save it into the Pending_Agency field in DataSource DatabaseIROC%dbo.Request_Master record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Pending_Agency1.Text, Request_MasterTable.Pending_Agency)			

                      
        End Sub
                
      
        ' To customize, override this method in Request_MasterRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            Request_MasterTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.

            
            ' Retrieve the record id from the URL parameter.
              
                  Dim recId As String = DirectCast(Me.Page, BaseApplicationPage).Decrypt(Me.Page.Request.QueryString.Item("Request_Master"))
                
            If recId Is Nothing OrElse recId.Trim = "" Then
                ' Get the error message from the application resource file.
                Throw New Exception(Page.GetResourceValue("Err:UrlParamMissing", "IROC2").Replace("{URL}", "Request_Master"))
            End If
            HttpContext.Current.Session("QueryString in Full-Edit-Request-Master") = recId
              
            If KeyValue.IsXmlKey(recId) Then
                ' Keys are typically passed as XML structures to handle composite keys.
                ' If XML, then add a Where clause based on the Primary Key in the XML.
                Dim pkValue As KeyValue = KeyValue.XmlToKey(recId)
                
                wc.iAND(Request_MasterTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, pkValue.GetColumnValueString(Request_MasterTable.Request_Id))
        
            Else
                ' The URL parameter contains the actual value, not an XML structure.
                
                wc.iAND(Request_MasterTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, recId)
        
            End If
              
            Return wc
          
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            Request_MasterTable.Instance.InnerFilter = Nothing
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
        
    

        ' To customize, override this method in Request_MasterRecordControl.
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
          Request_MasterTable.DeleteRecord(pkValue)
          
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
                                
                
			Me.Page.Authorize(Ctype(IROC_Id, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_Dt1, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_DtLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_Needed1, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Action_NeededLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency_Return, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Agency_ReturnLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_AgencyLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_Needed, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Action_NeededLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_Status, Control), "1")
					
			Me.Page.Authorize(Ctype(Pending_Prev_StatusLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Comments, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_CommentsLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_Contact_Email, Control), "1;2;4")
					
			Me.Page.Authorize(Ctype(Req_Status, Control), "1")
					
			Me.Page.Authorize(Ctype(Req_StatusLabel, Control), "1")
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel"), Control), "NOT_ANONYMOUS")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel1"), Control), "1;4")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel2"), Control), "1;4")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel3"), Control), "1;2;4;5")
			End If
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
			    Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				Me.Page.Authorize(Ctype(parentTC.FindControl("TabPanel4"), Control), "1;2;4")
			End If
					
			Me.Page.Authorize(Ctype(Pending_Agency1, Control), "1")
					
			If Not CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control) is Nothing Then
				Dim parentTC As Control = CType(Me.FindControl("Request_MasterRecordControlTabContainer"), Control)
				parentTC.Visible = MiscUtils.IsTabContainerVisible(parentTC)
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
            
                        
        Public Overridable Function CreateWhereClause_PriorityDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_Prov_NameDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
                        
        Public Overridable Function CreateWhereClause_Req_Island1DropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
        ' Fill the Priority list.
        Protected Overridable Sub PopulatePriorityDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Priority.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Highest"), "1"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("High"), "2"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Medium"), "3"))
                            							
            Me.Priority.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Low"), "4"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Priority, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Priority, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Priority, Request_MasterTable.Priority.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Priority.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Priority, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        ' Fill the Prov_Name list.
        Protected Overridable Sub PopulateProv_NameDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Prov_Name.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Prov_Name.Items.Add(New ListItem(Me.Page.ExpandResourceValue("OTWC"), "OTWC"))
                            							
            Me.Prov_Name.Items.Add(New ListItem(Me.Page.ExpandResourceValue("HTSC"), "HTSC"))
                            		  			
            ' 2. Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Prov_NameDropDownList function.
            ' It is better to customize the where clause there.
            
            Dim wc As WhereClause = CreateWhereClause_Prov_NameDropDownList()
            ' Create the ORDER BY clause to sort based on the displayed value.			
                
                
            ' 3. Read a total of maxItems from the database and insert them								
            Dim orderBy As OrderBy = New OrderBy(False, False)
             orderBy.Add(Request_MasterTable.Prov_Name, OrderByItem.OrderDir.Asc)
            
            Dim itemValue As String
            Dim listDuplicates As New ArrayList()

            For Each itemValue In Request_MasterTable.GetValues(Request_MasterTable.Prov_Name, wc, orderBy, maxItems)
                ' Create the dropdown list item and add it to the list.
                Dim fvalue As String = Request_MasterTable.Prov_Name.Format(itemValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = itemValue
                Dim dupItem As ListItem = Me.Prov_Name.Items.FindByText(fvalue)
          
                If Not IsNothing(dupItem) Then
                    listDuplicates.Add(fvalue)
                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                        dupItem.Text = fvalue & " (ID " & dupItem.Value & ")"
                    End If
                End If

                Dim newItem As ListItem = New ListItem(fvalue, itemValue)
                Me.Prov_Name.Items.Add(newItem)

                If listDuplicates.Contains(fvalue) AndAlso Not String.IsNullOrEmpty(itemValue) Then
                    newItem.Text = fvalue & " (ID " & itemValue & ")"
                End If
            Next
                            
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Prov_Name, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Prov_Name, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Prov_Name, Request_MasterTable.Prov_Name.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Prov_Name.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Prov_Name, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        ' Fill the Req_Island1 list.
        Protected Overridable Sub PopulateReq_Island1DropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.Req_Island1.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Hawaii"), "Hawaii"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Maui"), "Maui"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Lanai"), "Lanai"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Molokai"), "Molokai"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Oahu"), "Oahu"))
                            							
            Me.Req_Island1.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Kauai"), "Kauai"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.Req_Island1, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Req_Island1, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.Req_Island1, Request_MasterTable.Req_Island.Format(selectedValue))Then
                Dim fvalue As String = Request_MasterTable.Req_Island.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.Req_Island1, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        Protected Overridable Sub Priority_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Priority.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Priority.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Priority.Items.Add(New ListItem(displayText, val))
                Me.Priority.SelectedIndex = Me.Priority.Items.Count - 1
                Me.Page.Session.Remove(Priority.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Priority.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Prov_Name_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Prov_Name.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Prov_Name.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Prov_Name.Items.Add(New ListItem(displayText, val))
                Me.Prov_Name.SelectedIndex = Me.Prov_Name.Items.Count - 1
                Me.Page.Session.Remove(Prov_Name.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Prov_Name.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Req_Island1_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(Req_Island1.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(Req_Island1.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.Req_Island1.Items.Add(New ListItem(displayText, val))
                Me.Req_Island1.SelectedIndex = Me.Req_Island1.Items.Count - 1
                Me.Page.Session.Remove(Req_Island1.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(Req_Island1.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub Cat_Cost_Free_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Needed_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub ICS_SOW_Uploaded_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_More_Info_Flag_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_On_Net_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub OTW_Premise_Fiber_Work_Reqd_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

        End Sub
            
        Protected Overridable Sub Cat_Franchise_Order_Number2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Cat_OTWC_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub ICS_CATV_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub IROC_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Construction_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Deployment_Start_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Invoice_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Island_completed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Permit_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Projected_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Quote1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub OTW_Scheduled_Deploy_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Action_Needed1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency_Return_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Action_Needed_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Prev_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Reg_Type1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Address1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_City1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Completed_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Contact_Email_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Enity2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Funding_Src2_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_PO_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Amt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Check_No_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Pymt_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Quote_Approved_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Site_Name1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_State1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Status_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Target_Dt1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Req_Zip1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Pending_Agency1_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseRequest_MasterRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseRequest_MasterRecordControl_Rec") = value
            End Set
        End Property
        
        Private _DataSource As Request_MasterRecord
        Public Property DataSource() As Request_MasterRecord     
            Get
                Return Me._DataSource
            End Get
            
            Set(ByVal value As Request_MasterRecord)
            
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
        
        Public ReadOnly Property Cat_Cost_Free() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_Free"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Cost_FreeLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Cost_FreeLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_Franchise_Order_Number2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_Number2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_Franchise_Order_NumberLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_Franchise_Order_NumberLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Cat_OTWC_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Cat_OTWC_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Cat_OTWC_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_CATV_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_CATV_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_CATV_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_Needed() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Needed"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property ICS_SOW_Uploaded() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_Uploaded"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property ICS_SOW_UploadedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "ICS_SOW_UploadedLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property IROC_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property IROC_IdLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "IROC_IdLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Completed_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Completed_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Completed_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Construction_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Construction_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Construction_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Deployment_Start_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Deployment_Start_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Deployment_Start_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Invoice_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Invoice_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Invoice_NoLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Island_completed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Island_completedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Island_completedLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_More_Info_Flag() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_Flag"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_More_Info_FlagLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_More_Info_FlagLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_On_Net() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_Net"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_On_NetLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_On_NetLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Permit_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Permit_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Permit_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Premise_Fiber_Work_Reqd() As System.Web.UI.WebControls.CheckBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_Reqd"), System.Web.UI.WebControls.CheckBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Premise_Fiber_Work_ReqdLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Projected_Deploy_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Projected_Deploy_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Projected_Deploy_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Quote1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Quote1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_QuoteLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_QuoteLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_QuoteLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property OTW_Scheduled_Deploy_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property OTW_Scheduled_Deploy_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "OTW_Scheduled_Deploy_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Dt1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Action_Needed1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_Needed1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Action_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Action_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency_Return() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_Return"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Agency_ReturnLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency_ReturnLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_AgencyLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_Action_Needed() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_Needed"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_Action_NeededLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Action_NeededLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Prev_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Pending_Prev_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Prev_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Priority() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Priority"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property PriorityLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "PriorityLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Prov_Name() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_Name"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property Prov_NameLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Prov_NameLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Reg_Type1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_Type1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Reg_TypeLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Reg_TypeLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Address1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Address1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_AddressLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_AddressLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_City1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_City1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_CityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Completed_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Completed_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Completed_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Contact_Email() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_Email"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Contact_EmailLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Contact_EmailLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Dt1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Enity2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Enity2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_EnityLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_EnityLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Funding_Src2() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_Src2"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Funding_SrcLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Funding_SrcLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Island1() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Island1"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property Req_IslandLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_IslandLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_PO_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_PO_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_PO_NoLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Amt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Amt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_AmtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_AmtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Check_No() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_No"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_Check_NoLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Check_NoLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Pymt_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Pymt_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Pymt_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Quote_Approved() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_Approved"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Quote_ApprovedLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Quote_ApprovedLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Site_Name1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_Name1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Site_NameLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Site_NameLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_State1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_State1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_StateLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StateLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Status() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Status"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_StatusLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_StatusLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Target_Dt1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_Dt1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_Target_DtLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Target_DtLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Req_Zip1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_Zip1"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Req_ZipLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Req_ZipLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_Id() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property Request_IdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_MasterTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_MasterTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Pending_Agency1() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Pending_Agency1"), System.Web.UI.WebControls.TextBox)
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
            
            Dim rec As Request_MasterRecord = Nothing
             
        
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
            
            Dim rec As Request_MasterRecord = Nothing
             
        
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

         
        Public Overridable Function GetRecord() As Request_MasterRecord
            If Not Me.DataSource Is Nothing Then
                Return Me.DataSource
            End If
            
            If Not Me.RecordUniqueId Is Nothing Then
                
                Return Request_MasterTable.GetRecord(Me.RecordUniqueId, True)
                
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

  