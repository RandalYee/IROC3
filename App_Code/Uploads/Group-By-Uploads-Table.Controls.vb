﻿
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Group_By_Uploads_Table.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Group_By_Uploads_Table

#Region "Section 1: Place your customizations here."

    
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

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the UploadsTableControlRow control on the Group_By_Uploads_Table page.
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
              
              AddHandler Me.UploadsRowEditButton.Click, AddressOf UploadsRowEditButton_Click
              
              AddHandler Me.UploadsRowExpandCollapseRowButton.Click, AddressOf UploadsRowExpandCollapseRowButton_Click
              
              AddHandler Me.Request_Id.Click, AddressOf Request_Id_Click
            
    
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
        
                SetRequest_Id()
                SetUPLOAD_Comments()
                SetUPLOAD_Desc()
                SetUPLOAD_Dt()
                SetUPLOAD_File()
                
                
                
      
      
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
        
        
        Public Overridable Sub SetRequest_Id()
            
        
            ' Set the Request_Id LinkButton on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.Request_Id is the ASP:LinkButton on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Request_IdSpecified Then
                				
                ' If the Request_Id is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = ""
                Dim _isExpandableNonCompositeForeignKey As Boolean = UploadsTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(UploadsTable.Request_Id)
                If _isExpandableNonCompositeForeignKey AndAlso UploadsTable.Request_Id.IsApplyDisplayAs Then
                                  
                       formattedValue = UploadsTable.GetDFKA(Me.DataSource.Request_Id.ToString(),UploadsTable.Request_Id, Nothing)
                                    
                       If (formattedValue Is Nothing) Then
                              formattedValue = Me.DataSource.Format(UploadsTable.Request_Id)
                       End If
                Else
                       formattedValue = Me.DataSource.Request_Id.ToString()
                End If
                                
                Me.Request_Id.Text = formattedValue
                
                Me.Request_Id.ToolTip = "Go to " & Me.Request_Id.Text.Replace("<wbr/>", "")
                
            Else 
            
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Request_Id.Text = UploadsTable.Request_Id.Format(UploadsTable.Request_Id.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Comments()
            
        
            ' Set the UPLOAD_Comments Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Comments is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Comments()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_CommentsSpecified Then
                				
                ' If the UPLOAD_Comments is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Comments)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Comments.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Comments is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Comments.Text = UploadsTable.UPLOAD_Comments.Format(UploadsTable.UPLOAD_Comments.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Comments is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Comments.Text Is Nothing _
                OrElse Me.UPLOAD_Comments.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Comments.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_Desc()
            
        
            ' Set the UPLOAD_Desc Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Desc is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Desc()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DescSpecified Then
                				
                ' If the UPLOAD_Desc is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Desc)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Desc.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Desc is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Desc.Text = UploadsTable.UPLOAD_Desc.Format(UploadsTable.UPLOAD_Desc.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_Desc is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Desc.Text Is Nothing _
                OrElse Me.UPLOAD_Desc.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Desc.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_Dt()
            
        
            ' Set the UPLOAD_Dt Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Dt is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DtSpecified Then
                				
                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_Dt.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Dt.Text = UploadsTable.UPLOAD_Dt.Format(UploadsTable.UPLOAD_Dt.DefaultValue, "g")
                        		
                End If
                 
            ' If the UPLOAD_Dt is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_Dt.Text Is Nothing _
                OrElse Me.UPLOAD_Dt.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_Dt.Text = "&nbsp;"
            End If
                  
        End Sub
                
        Public Overridable Sub SetUPLOAD_File()
            
        
            ' Set the UPLOAD_File Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_File is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_File()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_FileSpecified Then
                				
                ' If the UPLOAD_File is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_File)
                              
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.UPLOAD_File.Text = formattedValue
                
            Else 
            
                ' UPLOAD_File is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_File.Text = UploadsTable.UPLOAD_File.Format(UploadsTable.UPLOAD_File.DefaultValue)
                        		
                End If
                 
            ' If the UPLOAD_File is NULL or blank, then use the value specified  
            ' on Properties.
            If Me.UPLOAD_File.Text Is Nothing _
                OrElse Me.UPLOAD_File.Text.Trim() = "" Then
                ' Set the value specified on the Properties.
                Me.UPLOAD_File.Text = "&nbsp;"
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
        
            GetRequest_Id()
            GetUPLOAD_Comments()
            GetUPLOAD_Desc()
            GetUPLOAD_Dt()
            GetUPLOAD_File()
        End Sub
        
        
        Public Overridable Sub GetRequest_Id()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Comments()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Desc()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Dt()
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_File()
            
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
        
                  Me.Delete()
              
            End If
      Me.Page.CommitTransaction(sender)
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
        Public Overridable Sub UploadsRowEditButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Uploads/Edit-Uploads.aspx?Uploads={PK}"
                
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
        Public Overridable Sub UploadsRowExpandCollapseRowButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
          Dim panelControl as UploadsTableControl = DirectCast(MiscUtils.GetParentControlObject(Me, "UploadsTableControl"), UploadsTableControl)

          Dim repeatedRows() as UploadsTableControlRow = panelControl.GetRecordControls()
          For Each repeatedRow as UploadsTableControlRow in repeatedRows
              Dim altRow as System.Web.UI.Control= DirectCast(MiscUtils.FindControlRecursively(repeatedRow, "UploadsTableControlAltRow"), System.Web.UI.Control)
              If (altRow IsNot Nothing) Then
                  If (sender Is repeatedRow.UploadsRowExpandCollapseRowButton) Then
                      altRow.Visible = Not altRow.Visible
                  
                  End If                      
                  If (altRow.Visible) Then        
                   
                     repeatedRow.UploadsRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow.gif"
                     repeatedRow.UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over.gif'")
                     repeatedRow.UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow.gif'")
                                     
                  Else
                   
                     repeatedRow.UploadsRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow2.gif"
                     repeatedRow.UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over2.gif'")
                     repeatedRow.UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow2.gif'")
                   
                  End If
              Else
                  Me.Page.Response.Redirect("../Shared/ConfigureCollapseExpandRowBtn.aspx")
              End If
          Next
          
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for LinkButton
        Public Overridable Sub Request_Id_Click(ByVal sender As Object, ByVal args As EventArgs)
              
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Request_Master/Show-Request-Master.aspx?Request_Master={UploadsTableControlRow:FK:Uploads_FK00}"
                
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
        
        Public ReadOnly Property Request_Id() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Comments() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Comments"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Desc() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Desc"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Dt() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Dt"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_File() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_File"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
            
        Public ReadOnly Property UploadsRowDeleteButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsRowDeleteButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsRowEditButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsRowEditButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsRowExpandCollapseRowButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsRowExpandCollapseRowButton"), System.Web.UI.WebControls.ImageButton)
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
            
            Throw New Exception(Page.GetResourceValue("Err:RetrieveRec", "IROC2"))
                
        End Function

        Public Shadows ReadOnly Property Page() As BaseApplicationPage
            Get
                Return DirectCast(MyBase.Page, BaseApplicationPage)
            End Get
        End Property

#End Region

End Class

  

' Base class for the UploadsTableControl control on the Group_By_Uploads_Table page.
' Do not modify this class. Instead override any method in UploadsTableControl.
Public Class BaseUploadsTableControl
        Inherits IROC2.UI.BaseApplicationTableControl

        

        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
  
      
    
           ' Setup the filter and search.
        
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.Request_IdFilter) 				
                    initialVal = Me.GetFromSession(Me.Request_IdFilter)
                
                Else
                    
                    initialVal = EvaluateFormula("URL(""Request_Id"")")
                
              End If
              
                If initialVal <> ""				
                        
                        Dim Request_IdFilteritemListFromSession() As String = initialVal.Split(","c)
                        Dim index As Integer = 0
                        For Each item As String In Request_IdFilteritemListFromSession
                            If index = 0 AndAlso _
                               item.ToString.Equals("") Then
                            Else
                                Me.Request_IdFilter.Items.Add(item)
                                Me.Request_IdFilter.Items.Item(index).Selected = True
                                index += 1
                            End If
                        Next
                        Dim listItem As ListItem
                        For Each listItem In Me.Request_IdFilter.Items
                            listItem.Selected = True
                        Next
                            
                    End If
                
            End If
            If Not Me.Page.IsPostBack Then
                Dim initialVal As String = ""
                If  Me.InSession(Me.UploadsSearch) 				
                    initialVal = Me.GetFromSession(Me.UploadsSearch)
                
              End If
              
                If initialVal <> ""				
                        
                        Me.UploadsSearch.Text = initialVal
                            
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
            
              AddHandler Me.UploadsPagination.FirstPage.Click, AddressOf UploadsPagination_FirstPage_Click
              
              AddHandler Me.UploadsPagination.LastPage.Click, AddressOf UploadsPagination_LastPage_Click
              
              AddHandler Me.UploadsPagination.NextPage.Click, AddressOf UploadsPagination_NextPage_Click
              
              AddHandler Me.UploadsPagination.PageSizeButton.Click, AddressOf UploadsPagination_PageSizeButton_Click
            
              AddHandler Me.UploadsPagination.PreviousPage.Click, AddressOf UploadsPagination_PreviousPage_Click
                          
            Dim url As String = ""
            ' Setup the sorting events.
          
              AddHandler Me.Request_IdLabel.Click, AddressOf Request_IdLabel_Click
            
              AddHandler Me.UPLOAD_CommentsLabel.Click, AddressOf UPLOAD_CommentsLabel_Click
            
              AddHandler Me.UPLOAD_DescLabel.Click, AddressOf UPLOAD_DescLabel_Click
            
              AddHandler Me.UPLOAD_DtLabel.Click, AddressOf UPLOAD_DtLabel_Click
            
              AddHandler Me.UPLOAD_FileLabel.Click, AddressOf UPLOAD_FileLabel_Click
            
            ' Setup the button events.
          
              AddHandler Me.UploadsExportExcelButton.Click, AddressOf UploadsExportExcelButton_Click
              							
              Me.UploadsImportButton.PostBackUrl = "../Shared/SelectFileToImport.aspx?TableName=Uploads" 
              Me.UploadsImportButton.Attributes.Item("onClick") = "window.open('" & Me.Page.EncryptUrlParameter(Me.UploadsImportButton.PostBackUrl) & "','importWindow', 'width=700, height=500,top=' +(screen.availHeight-500)/2 + ',left=' + (screen.availWidth-700)/2+ ', resizable=yes, scrollbars=yes,modal=yes'); return false;"
                        
              AddHandler Me.UploadsImportButton.Click, AddressOf UploadsImportButton_Click
              
              AddHandler Me.UploadsNewButton.Click, AddressOf UploadsNewButton_Click
              
              AddHandler Me.UploadsPDFButton.Click, AddressOf UploadsPDFButton_Click
              
              AddHandler Me.UploadsResetButton.Click, AddressOf UploadsResetButton_Click
              
              AddHandler Me.UploadsWordButton.Click, AddressOf UploadsWordButton_Click
              
            AddHandler Me.UploadsSearchButton.Button.Click, AddressOf UploadsSearchButton_Click
        
              url = Me.ModifyRedirectUrl("../Request_Master/Request-Master-QuickSelector.aspx", "", True)
              url = Me.Page.ModifyRedirectUrl(url, "", True)                  
              Me.Request_IdFilter.PostBackUrl = url & "?Target=" & Me.Request_IdFilter.ClientID & "&DFKA=" & CType(Me.Page, BaseApplicationPage).Encrypt("Req_Site_Name")& "&IndexField=" & CType(Me.Page, BaseApplicationPage).Encrypt("Request_Id")& "&EmptyValue=" & CType(Me.Page, BaseApplicationPage).Encrypt("--ANY--") & "&EmptyDisplayText=" & CType(Me.Page, BaseApplicationPage).Encrypt(Me.Page.GetResourceValue("Txt:All"))
              Me.Request_IdFilter.Attributes.Item("onClick") = "initializePopupPage(this, '" & Me.Request_IdFilter.PostBackUrl & "', true, event); return false;"                  
                
              AddHandler Me.Request_IdFilter.SelectedIndexChanged, AddressOf Request_IdFilter_SelectedIndexChanged                  
                        
        
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
          
          ' Improve performance by prefetching display as records.
          Me.PreFetchForeignKeyValues()
             
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
        
                SetRequest_IdFilter()
                SetRequest_IdLabel()
                SetRequest_IdLabel1()
                SetUPLOAD_CommentsLabel()
                SetUPLOAD_DescLabel()
                SetUPLOAD_DtLabel()
                SetUPLOAD_FileLabel()
                
                
                
                
                
                
                SetUploadsSearch()
                
                
                
                
            ' setting the state of expand or collapse alternative rows
      
            Dim expandFirstRow As Boolean= True
        
            Dim recControls() As UploadsTableControlRow = Me.GetRecordControls()
            For i As Integer = 0 to recControls.Length - 1
                Dim altRow As System.Web.UI.Control = DirectCast(MiscUtils.FindControlRecursively(recControls(i), "UploadsTableControlAltRow"), System.Web.UI.Control)
                If (altRow IsNot Nothing) Then
                    If (expandFirstRow AndAlso i = 0) Then                
                        altRow.Visible = True
                   
                         recControls(i).UploadsRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow.gif"
                         recControls(i).UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over.gif'")
                         recControls(i).UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow.gif'")
                   
                    Else                
                        altRow.Visible = False
                   
                         recControls(i).UploadsRowExpandCollapseRowButton.ImageUrl = "../Images/icon_expandcollapserow2.gif"
                         recControls(i).UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseover", "this.src='../Images/icon_expandcollapserow_over2.gif'")
                         recControls(i).UploadsRowExpandCollapseRowButton.Attributes.Add("onmouseout", "this.src='../Images/icon_expandcollapserow2.gif'")
                   
                    End If
                End If
            Next
      
    
            ' Load data for each record and table UI control.
            ' Ordering is important because child controls get 
            ' their parent ids from their parent UI controls.
                
      
            ' this method calls the set method for controls with special formula like running total, sum, rank, etc
            SetFormulaControls()
            
                    
            
      End Sub
      
        Public Overridable Sub SetFormulaControls()
            ' this method calls Set methods for the control that has special formula
        
        

    End Sub

    
          Public Sub PreFetchForeignKeyValues()
          If (IsNothing(Me.DataSource))
            Return
          End If
          
            Me.Page.PregetDfkaRecords(UploadsTable.Request_Id, Me.DataSource)
          
          End Sub
        
      
        Public Overridable Sub RegisterPostback()
        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"UploadsExportExcelButton"))
                        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"UploadsPDFButton"))
                        
              Me.Page.RegisterPostBackTrigger(MiscUtils.FindControlRecursively(Me,"UploadsWordButton"))
                        
        
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
                    
            Me.Request_IdFilter.ClearSelection()
            
            Me.UploadsSearch.Text = ""
            
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

              
            If IsValueSelected(Me.Request_IdFilter) Then
    
                Dim item As ListItem
                Dim selectedItemCount As Integer = 0
                For Each item In Me.Request_IdFilter.Items
                    If item.Selected Then
                        selectedItemCount += 1
                        
                    End If
                Next
                
                Dim filter As WhereClause = New WhereClause
                For Each item In Me.Request_IdFilter.Items
                    If item.Selected AndAlso (item.Value = "--ANY--" OrElse item.Value = "--PLEASE_SELECT--") AndAlso selectedItemCount > 1 Then
                        item.Selected = False
                    End If
                    If item.Selected Then
                        filter.iOR(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, item.Value, False, False)
                    End If
                Next
                wc.iAND(filter)
                
            End If
                  
                
                       
            If IsValueSelected(Me.UploadsSearch) Then
              If Me.UploadsSearch.Text = BaseClasses.Resources.AppResources.GetResourceValue("Txt:SearchForEllipsis", Nothing) Then
                 Me.UploadsSearch.Text = ""
              Else
              ' Strip "..." from begin and ending of the search text, otherwise the search will return 0 values as in database "..." is not stored.
              
                    If Me.UploadsSearch.Text.StartsWith("...") Then
                        Me.UploadsSearch.Text = Me.UploadsSearch.Text.SubString(3,Me.UploadsSearch.Text.Length-3)
                    End If
                    If Me.UploadsSearch.Text.EndsWith("...") then
                        Me.UploadsSearch.Text = Me.UploadsSearch.Text.SubString(0,Me.UploadsSearch.Text.Length-3)
                        ' Strip the last word as well as it is likely only a partial word
                        Dim endindex As Integer = UploadsSearch.Text.Length - 1
                        While (Not Char.IsWhiteSpace(UploadsSearch.Text(endindex)) AndAlso endindex > 0)
                            endindex -= 1
                        End While
                        If endindex > 0 Then
                            UploadsSearch.Text = UploadsSearch.Text.Substring(0, endindex)
                        End If
              End If
            End If
            
              Dim formatedSearchText As String = MiscUtils.GetSelectedValue(Me.UploadsSearch, Me.GetFromSession(Me.UploadsSearch))
                
                ' After stripping "..." see if the search text is null or empty.
                If IsValueSelected(Me.UploadsSearch) Then 
        ' These clauses are added depending on operator and fields selected in Control's property page, bindings tab.
                    Dim search As WhereClause = New WhereClause()
                    
      Dim cols As New ColumnList    
        
      cols.Add(UploadsTable.UPLOAD_Desc, True)
      
      For Each col As BaseColumn in cols
      
                    search.iOR(col, BaseFilter.ComparisonOperator.Contains, MiscUtils.GetSelectedValue(Me.UploadsSearch, Me.GetFromSession(Me.UploadsSearch)), True, False)
        
      Next
    
                    wc.iAND(search)
                End If
            End If
                  
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
      
            ' Adds clauses if values are selected in Filter controls which are configured in the page.
          
            Dim Request_IdFilterSelectedValue As String = CType(HttpContext.Current.Session()(HttpContext.Current.Session.SessionID & appRelativeVirtualPath & "Request_IdFilter_Ajax"), String)
            If IsValueSelected(Request_IdFilterSelectedValue) Then
    
            If Not isNothing(Request_IdFilterSelectedValue) Then
                Dim Request_IdFilteritemListFromSession() As String = Request_IdFilterSelectedValue.Split(","c)
                Dim index As Integer = 0
                
                Dim filter As WhereClause = New WhereClause
                For Each item As String In Request_IdFilteritemListFromSession
                    If index = 0 AndAlso item.ToString.Equals("") Then
                    Else
                        filter.iOR(UploadsTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, item, False, False)
                        index += 1
                    End If
                Next
                wc.iAND(filter)
                
             End If
                
             End If
                      
            If IsValueSelected(searchText) and fromSearchControl = "UploadsSearch" Then
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
        
      cols.Add(UploadsTable.UPLOAD_Desc, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Starts_With, formatedSearchText, True, False)
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, AutoTypeAheadWordSeparators & formatedSearchText, True, False)
                
      Next
    
                    Else
                        
      Dim cols As New ColumnList    
        
      cols.Add(UploadsTable.UPLOAD_Desc, True)
      
      For Each col As BaseColumn in cols
      
                        search.iOR(col, BaseFilter.ComparisonOperator.Contains, formatedSearchText, True, False)
      Next
    
                    End If
                    wc.iAND(search)
                End If
            End If
                  
      
      
            Return wc
        End Function
          
        Public Overridable Function GetAutoCompletionList_UploadsSearch(ByVal prefixText As String, ByVal count As Integer) As String()
            Dim resultList As ArrayList = New ArrayList
            Dim wordList As ArrayList = New ArrayList
            
            Dim filterJoin As CompoundFilter = CreateCompoundJoinFilter()
            If count = 0 Then count = 10
            Dim wc As WhereClause = CreateWhereClause(prefixText,"UploadsSearch", "WordsStartingWithSearchString", "[^a-zA-Z0-9]")
            Dim recordList () As IROC2.Business.UploadsRecord = UploadsTable.GetRecords(filterJoin, wc, Nothing, 0, count,count)
            Dim rec As UploadsRecord = Nothing
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
        
                resultItem = rec.Format(UploadsTable.UPLOAD_Desc)
                If resultItem IsNot Nothing Then
                    Dim prText As String = prefixText
                    If UploadsTable.UPLOAD_Desc.IsFullTextSearchable Then
                         Dim ft As FullTextExpression = New FullTextExpression()
                         prText = ft.GetFirstNonExcludedTerm(prText)
                    End If
                    If Not String.IsNullOrEmpty(prText) AndAlso resultItem.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture).Contains(prText.ToUpper(System.Threading.Thread.CurrentThread.CurrentCulture))  Then
  
                        Dim isAdded As Boolean = FormatSuggestions(prText, resultItem, 50, "InMiddleOfMatchedString", "WordsStartingWithSearchString", "[^a-zA-Z0-9]", resultList, UploadsTable.UPLOAD_Desc.IsFullTextSearchable)
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
        
                        If recControl.Request_Id.Text <> "" Then
                            rec.Parse(recControl.Request_Id.Text, UploadsTable.Request_Id)
                        End If
                        If recControl.UPLOAD_Comments.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Comments.Text, UploadsTable.UPLOAD_Comments)
                        End If
                        If recControl.UPLOAD_Desc.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Desc.Text, UploadsTable.UPLOAD_Desc)
                        End If
                        If recControl.UPLOAD_Dt.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_Dt.Text, UploadsTable.UPLOAD_Dt)
                        End If
                        If recControl.UPLOAD_File.Text <> "" Then
                            rec.Parse(recControl.UPLOAD_File.Text, UploadsTable.UPLOAD_File)
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
        
        Public Overridable Sub SetRequest_IdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetRequest_IdLabel1()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_CommentsLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DescLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DtLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_FileLabel()
                  
                  End Sub
                
        Public Overridable Sub SetRequest_IdFilter()

            
            Dim Request_IdFilterselectedFilterItemList As New ArrayList()
            Dim Request_IdFilteritemsString As String = Nothing
            If (Me.InSession(Me.Request_IdFilter)) Then
                Request_IdFilteritemsString = Me.GetFromSession(Me.Request_IdFilter)
            End If
            
            If (Request_IdFilteritemsString IsNot Nothing) Then
                Dim Request_IdFilteritemListFromSession() As String = Request_IdFilteritemsString.Split(","c)
                For Each item as String In Request_IdFilteritemListFromSession
                    Request_IdFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            		
            Me.PopulateRequest_IdFilter(GetSelectedValueList(Me.Request_IdFilter, Request_IdFilterselectedFilterItemList), 500)
                    
              End Sub	
            
        Public Overridable Sub SetUploadsSearch()

            
              End Sub	
            
        ' Get the filters' data for Request_IdFilter
        Protected Overridable Sub PopulateRequest_IdFilter(ByVal selectedValue As ArrayList, ByVal maxItems As Integer)
                    
            'Setup the WHERE clause.
            
            Dim wc As WhereClause = Me.CreateWhereClause_Request_IdFilter()
            Me.Request_IdFilter.Items.Clear()
            		  			
            ' Set up the WHERE and the ORDER BY clause by calling the CreateWhereClause_Request_IdFilter function.
            ' It is better to customize the where clause there.
                

            Dim orderBy As OrderBy = New OrderBy(false, false)			
            
            Dim variables As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)

            	

            Dim noValueFormat As String = Page.GetResourceValue("Txt:Other", "IROC2")
            

            Dim itemValues() As Request_MasterRecord = Nothing
            
            If wc.RunQuery
                Dim counter As Integer = 0
                Dim pageNum As Integer = 0
                Dim evaluator As New FormulaEvaluator
                Dim listDuplicates As New ArrayList()

                
                
                Do
                    
                    itemValues = Request_MasterTable.GetRecords(wc, orderBy, pageNum, maxItems)
                                    
                    For each itemValue As Request_MasterRecord In itemValues
                        ' Create the item and add to the list.
                        Dim cvalue As String = Nothing
                        Dim fvalue As String = Nothing
                        If itemValue.Request_IdSpecified Then
                            cvalue = itemValue.Request_Id.ToString()

                            If counter < maxItems AndAlso Me.Request_IdFilter.Items.FindByValue(cvalue) Is Nothing  Then
                            
                                Dim _isExpandableNonCompositeForeignKey As Boolean = UploadsTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(UploadsTable.Request_Id)
                                If _isExpandableNonCompositeForeignKey AndAlso UploadsTable.Request_Id.IsApplyDisplayAs Then
                                    fvalue = UploadsTable.GetDFKA(itemValue, UploadsTable.Request_Id)
                                End If
                                If (Not _isExpandableNonCompositeForeignKey) Or (String.IsNullOrEmpty(fvalue)) Then
                                    fvalue = itemValue.Format(Request_MasterTable.Req_Site_Name)
                                End If
                                    
                                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = cvalue

                                If (IsNothing(fvalue)) Then
                                   fvalue = ""
                                End If

                                fvalue = fvalue.Trim()

                                If ( fvalue.Length > 50 ) Then
                                   fvalue = fvalue.Substring(0, 50) & "..."
                                End If

                                Dim dupItem As ListItem = Me.Request_IdFilter.Items.FindByText(fvalue)
                
                                If Not IsNothing(dupItem) Then
                                    listDuplicates.Add(fvalue)
                                    If Not String.IsNullOrEmpty(dupItem.Value) Then
                                        dupItem.Text = fvalue & " (ID " & dupItem.Value.Substring(0, Math.Min(dupItem.Value.Length,38)) & ")"
                                    End If
                                End If

                                Dim newItem As ListItem = New ListItem(fvalue, cvalue)
                                Me.Request_IdFilter.Items.Add(newItem)

                                If listDuplicates.Contains(fvalue) AndAlso Not String.IsNullOrEmpty(cvalue) Then
                                    newItem.Text = fvalue & " (ID " & cvalue.Substring(0, Math.Min(cvalue.Length,38)) & ")"
                                End If

                                counter += 1			  
                            End If
                        End If
                    Next
                    pageNum += 1
                Loop While (itemValues.Length = maxItems AndAlso counter < maxItems)
            End If			
            


                 
            Me.Request_IdFilter.SetFieldMaxLength(50)
                                 
                  
            ' Add the selected value.
            If Me.Request_IdFilter.Items.Count = 0 Then
                Me.Request_IdFilter.Items.Add(New ListItem(Page.GetResourceValue("Txt:All", "IROC2"), "--ANY--"))
            End If
            
            ' Mark all items to be selected.
            For Each item As ListItem in Me.Request_IdFilter.Items
                item.Selected = True
            Next
                              
        End Sub
            
              

        Public Overridable Function CreateWhereClause_Request_IdFilter() As WhereClause
          
            ' Create a where clause for the filter Request_IdFilter.
            ' This function is called by the Populate method to load the items 
            ' in the Request_IdFilterQuickSelector
            
            Dim Request_IdFilterselectedFilterItemList As New ArrayList()
            Dim Request_IdFilteritemsString As String = Nothing
            If (Me.InSession(Me.Request_IdFilter)) Then
                Request_IdFilteritemsString = Me.GetFromSession(Me.Request_IdFilter)
            End If
            
            If (Request_IdFilteritemsString IsNot Nothing) Then
                Dim Request_IdFilteritemListFromSession() As String = Request_IdFilteritemsString.Split(","c)
                For Each item as String In Request_IdFilteritemListFromSession
                    Request_IdFilterselectedFilterItemList.Add(item)
                Next
            End If
              
            Request_IdFilterselectedFilterItemList = GetSelectedValueList(Me.Request_IdFilter, Request_IdFilterselectedFilterItemList) 
            Dim wc As New WhereClause
            If Request_IdFilterselectedFilterItemList Is Nothing OrElse Request_IdFilterselectedFilterItemList.Count = 0 Then
                wc.RunQuery = False
            Else            
                For Each item As String In Request_IdFilterselectedFilterItemList
              
            	  
                    wc.iOR(Request_MasterTable.Request_Id, BaseFilter.ComparisonOperator.EqualsTo, item)                  
                  
                                 
                Next
            End If
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
        
            Dim Request_IdFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Request_IdFilter, Nothing)
            Dim Request_IdFilterSessionString As String = ""
            If Not Request_IdFilterselectedFilterItemList is Nothing Then
            For Each item As String In Request_IdFilterselectedFilterItemList
                Request_IdFilterSessionstring = Request_IdFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession(Me.Request_IdFilter, Request_IdFilterSessionstring)
                  
            Me.SaveToSession(Me.UploadsSearch, Me.UploadsSearch.Text)
                  
        
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
          
            Dim Request_IdFilterselectedFilterItemList As ArrayList = GetSelectedValueList(Me.Request_IdFilter, Nothing)
            Dim Request_IdFilterSessionString As String = ""
            If Not Request_IdFilterselectedFilterItemList is Nothing Then
            For Each item As String In Request_IdFilterselectedFilterItemList
                Request_IdFilterSessionstring = Request_IdFilterSessionstring & "," & item
            Next
            End If
            Me.SaveToSession("Request_IdFilter_Ajax", Request_IdFilterSessionString)
          
      Me.SaveToSession("UploadsSearch_Ajax", Me.UploadsSearch.Text)
              
            HttpContext.Current.Session("AppRelativeVirtualPath") = Me.Page.AppRelativeVirtualPath
         
        End Sub
        
        Protected Overrides Sub ClearControlsFromSession()
            MyBase.ClearControlsFromSession()

            ' Clear filter controls values from the session.
        
            Me.RemoveFromSession(Me.Request_IdFilter)
            Me.RemoveFromSession(Me.UploadsSearch)
    
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
        
        Public Overridable Sub Request_IdLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by Request_Id when clicked.
              
            ' Get previous sorting state for Request_Id.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.Request_Id)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for Request_Id.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.Request_Id, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by Request_Id, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            
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
            
        Public Overridable Sub UPLOAD_FileLabel_Click(ByVal sender As Object, ByVal args As EventArgs)
            ' Sorts by UPLOAD_File when clicked.
              
            ' Get previous sorting state for UPLOAD_File.
            
            Dim sd As OrderByItem = Me.CurrentSortOrder.Find(UploadsTable.UPLOAD_File)
            If sd Is Nothing OrElse (Me.CurrentSortOrder.Items IsNot Nothing Andalso Me.CurrentSortOrder.Items.Length > 1) Then
                ' First time sort, so add sort order for UPLOAD_File.
                Me.CurrentSortOrder.Reset()

    
              'If default sort order was GeoProximity, create new CurrentSortOrder of OrderBy type
              If TypeOf Me.CurrentSortOrder Is GeoOrderBy Then Me.CurrentSortOrder = New OrderBy(True, False)
              
              Me.CurrentSortOrder.Add(UploadsTable.UPLOAD_File, OrderByItem.OrderDir.Asc)
            
            Else
                ' Previously sorted by UPLOAD_File, so just reverse.
                sd.Reverse()
            End If
            
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
              
        End Sub
            

        ' Generate the event handling functions for button events.
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsExportExcelButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
            ' To customize the columns or the format, override this function in Section 1 of the page 
            ' and modify it to your liking.
            ' Build the where clause based on the current filter and search criteria
            ' Create the Order By clause based on the user's current sorting preference.
          
              Dim wc As WhereClause = CreateWhereClause
              Dim orderBy As OrderBy = Nothing
              
              orderBy = CreateOrderBy
              
              Dim done As Boolean = False
              Dim val As Object = ""
              ' Read pageSize records at a time and write out the Excel file.
              Dim totalRowsReturned As Integer = 0
          
              Dim join As CompoundFilter = CreateCompoundJoinFilter()
              Me.TotalRecords = UploadsTable.GetRecordCount(join, wc)
              If Me.TotalRecords > 10000 Then
          
              ' Add each of the columns in order of export.
              Dim columns() as BaseColumn = New BaseColumn() { _
                         UploadsTable.Request_Id, _ 
             UploadsTable.UPLOAD_Dt, _ 
             UploadsTable.UPLOAD_Desc, _ 
             UploadsTable.UPLOAD_Comments, _ 
             UploadsTable.UPLOAD_File, _ 
             Nothing}
              Dim  exportData as ExportDataToCSV = New ExportDataToCSV(UploadsTable.Instance, wc, orderBy, columns)
              exportData.StartExport(Me.Page.Response, True)

              Dim dataForCSV As DataForExport = New DataForExport(UploadsTable.Instance, wc, orderBy, columns, join)

              '  Read pageSize records at a time and write out the CSV file.
              While (Not done)
                  Dim recList As ArrayList = dataForCSV.GetRows(exportData.pageSize)
                  If recList Is Nothing Then
                      Exit While 'no more records we are done
                  End If

                  totalRowsReturned = recList.Count
                  For Each rec As BaseRecord In recList
                      For Each col As BaseColumn In dataForCSV.ColumnList
                          If col Is Nothing Then
                              Continue For
                          End If

                          If Not dataForCSV.IncludeInExport(col) Then
                              Continue For
                          End If

                          val = rec.GetValue(col).ToString()
                          exportData.WriteColumnData(val, dataForCSV.IsString(col))

                      Next col
                      exportData.WriteNewRow()
                  Next rec

                  '  If we already are below the pageSize, then we are done.
                  If totalRowsReturned < exportData.pageSize Then
                      done = True
                  End If
              End While
              exportData.FinishExport(Me.Page.Response)
          Else
          
              ' Create an instance of the Excel report class with the table class, where clause and order by.
              Dim excelReport As ExportDataToExcel = New ExportDataToExcel(UploadsTable.Instance, wc, orderBy)
              ' Add each of the columns in order of export.
              ' To customize the data type, change the second parameter of the new ExcelColumn to be
              ' a format string from Excel's Format Cell menu. For example "dddd, mmmm dd, yyyy h:mm AM/PM;@", "#,##0.00"

              If Me.Page.Response Is Nothing Then
                Return
              End If

              excelReport.CreateExcelBook()

              Dim width As Integer = 0
              Dim columnCounter As Integer = 0
              Dim data As DataForExport = New DataForExport(UploadsTable.Instance, wc, orderBy, Nothing, join)
                       data.ColumnList.Add(New ExcelColumn(UploadsTable.Request_Id, "Default"))
             data.ColumnList.Add(New ExcelColumn(UploadsTable.UPLOAD_Dt, "Short Date"))
             data.ColumnList.Add(New ExcelColumn(UploadsTable.UPLOAD_Desc, "Default"))
             data.ColumnList.Add(New ExcelColumn(UploadsTable.UPLOAD_Comments, "Default"))
             data.ColumnList.Add(New ExcelColumn(UploadsTable.UPLOAD_File, "Default"))


              For Each col As ExcelColumn In data.ColumnList
                  width = excelReport.GetExcelCellWidth(col)
                  If data.IncludeInExport(col) Then
                      excelReport.AddColumnToExcelBook(columnCounter, col.ToString(), excelReport.GetExcelDataType(col), width, excelReport.GetDisplayFormat(col))
                      columnCounter = columnCounter + 1
                  End If
              Next col
              
              While (Not done)
                  Dim recList As ArrayList = data.GetRows(excelReport.pageSize)

                  If recList Is Nothing Then
                      Exit While 'no more records we are done
                  End If

                  totalRowsReturned = recList.Count

                  For Each rec As BaseRecord In recList
                      excelReport.AddRowToExcelBook()
                      columnCounter = 0

                      For Each col As ExcelColumn In data.ColumnList
                          If Not data.IncludeInExport(col) Then
                              Continue For
                          End If

                          Dim _isExpandableNonCompositeForeignKey As Boolean = col.DisplayColumn.TableDefinition.IsExpandableNonCompositeForeignKey(col.DisplayColumn)
                          If _isExpandableNonCompositeForeignKey AndAlso col.DisplayColumn.IsApplyDisplayAs Then
                              val = UploadsTable.GetDFKA(rec.GetValue(col.DisplayColumn).ToString(), col.DisplayColumn, Nothing)
                              If val Is Nothing Then
                                  val = rec.Format(col.DisplayColumn)
                              End If
                          Else
                              val = excelReport.GetValueForExcelExport(col, rec)
                          End If
                          excelReport.AddCellToExcelRow(columnCounter, excelReport.GetExcelDataType(col), val, col.DisplayFormat)

                          columnCounter = columnCounter + 1
                      Next col
                  Next rec

                  ' If we already are below the pageSize, then we are done.
                  If totalRowsReturned < excelReport.pageSize Then
                      done = True
                  End If
              End While

              excelReport.SaveExcelBook(Me.Page.Response)
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
        Public Overridable Sub UploadsImportButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
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
        Public Overridable Sub UploadsNewButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
            ' The redirect URL is set on the Properties, Custom Properties or Actions.
            ' The ModifyRedirectURL call resolves the parameters before the
            ' Response.Redirect redirects the page to the URL.  
            ' Any code after the Response.Redirect call will not be executed, since the page is
            ' redirected to the URL.
            
              
                  Dim url As String = "../Uploads/Add-Uploads.aspx"
                
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
        Public Overridable Sub UploadsPDFButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
                Dim report As PDFReport = New PDFReport() 
                report.SpecificReportFileName = Page.Server.MapPath("Group-By-Uploads-Table.UploadsPDFButton.report")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Uploads"
                ' If Group-By-Uploads-Table.UploadsPDFButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.   
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column   			
                 report.AddColumn(UploadsTable.Request_Id.Name, ReportEnum.Align.Left, "${Request_Id}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_Dt.Name, ReportEnum.Align.Left, "${UPLOAD_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(UploadsTable.UPLOAD_Desc.Name, ReportEnum.Align.Left, "${UPLOAD_Desc}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_Comments.Name, ReportEnum.Align.Left, "${UPLOAD_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_File.Name, ReportEnum.Align.Left, "${UPLOAD_File}", ReportEnum.Align.Left, 30)

          
                Dim rowsPerQuery As Integer = 5000 
                Dim recordCount As Integer = 0 
                                
                report.Page = Page.GetResourceValue("Txt:Page", "IROC2")
                report.ApplicationPath = Me.Page.MapPath(Page.Request.ApplicationPath)
            
                Dim whereClause As WhereClause = CreateWhereClause
                Dim orderBy As OrderBy = CreateOrderBy
              Dim joinFilter As BaseFilter = CreateCompoundJoinFilter()
            
                Dim pageNum As Integer = 0 
                Dim totalRows As Integer = UploadsTable.GetRecordCount(joinFilter,whereClause)
                Dim columns As ColumnList = UploadsTable.GetColumnList()
                Dim records As UploadsRecord() = Nothing
            
                Do 
                    
                    records = UploadsTable.GetRecords(joinFilter,whereClause, orderBy, pageNum, rowsPerQuery)
                    If Not (records Is Nothing) AndAlso records.Length > 0 AndAlso whereClause.RunQuery Then
                      For Each record As UploadsRecord In records 
                    
                            ' AddData method takes four parameters   
                            ' The 1st parameters represent the data format
                            ' The 2nd parameters represent the data value
                            ' The 3rd parameters represent the default alignment of column using the data
                            ' The 4th parameters represent the maximum length of the data value being shown
                                                         If BaseClasses.Utils.MiscUtils.IsNull(record.Request_Id) Then
                                 report.AddData("${Request_Id}", "",ReportEnum.Align.Left)
                             Else 
                                 Dim _isExpandableNonCompositeForeignKey as Boolean
                                 Dim _DFKA as String = ""
                                 _isExpandableNonCompositeForeignKey = UploadsTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(UploadsTable.Request_Id)
                                 _DFKA = UploadsTable.GetDFKA(record.Request_Id.ToString(), UploadsTable.Request_Id,Nothing)
                                 If _isExpandableNonCompositeForeignKey AndAlso  (not _DFKA  Is Nothing)  AndAlso  UploadsTable.Request_Id.IsApplyDisplayAs Then
                                     report.AddData("${Request_Id}", _DFKA,ReportEnum.Align.Left)
                                 Else 
                                     report.AddData("${Request_Id}", record.Format(UploadsTable.Request_Id), ReportEnum.Align.Left)
                                 End If
                             End If
                             report.AddData("${UPLOAD_Dt}", record.Format(UploadsTable.UPLOAD_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_Desc}", record.Format(UploadsTable.UPLOAD_Desc), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_Comments}", record.Format(UploadsTable.UPLOAD_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_File}", record.Format(UploadsTable.UPLOAD_File), ReportEnum.Align.Left, 300)

                            report.WriteRow 
                        Next 
                        pageNum = pageNum + 1
                        recordCount += records.Length 
                    End If 
                Loop While Not (records Is Nothing) AndAlso recordCount < totalRows  AndAlso whereClause.RunQuery 
                
                report.Close 
                BaseClasses.Utils.NetUtils.WriteResponseBinaryAttachment(Me.Page.Response, report.Title + ".pdf", report.ReportInByteArray, 0, true)
          
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
        Public Overridable Sub UploadsResetButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
              Me.Request_IdFilter.ClearSelection()
              Me.UploadsSearch.Text = ""
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
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
                  
        End Sub
        
        ' event handler for ImageButton
        Public Overridable Sub UploadsWordButton_Click(ByVal sender As Object, ByVal args As ImageClickEventArgs)
        
    Try
    
      ' Enclose all database retrieval/update code within a Transaction boundary
                DbUtils.StartTransaction
                
                Dim report As WordReport = New WordReport
                report.SpecificReportFileName = Page.Server.MapPath("Group-By-Uploads-Table.UploadsWordButton.word")
                ' report.Title replaces the value tag of page header and footer containing ${ReportTitle}
                report.Title = "Uploads"
                ' If Group-By-Uploads-Table.UploadsWordButton.report specifies a valid report template,
                ' AddColumn method will generate a report template.
                ' Each AddColumn method-call specifies a column
                ' The 1st parameter represents the text of the column header
                ' The 2nd parameter represents the horizontal alignment of the column header
                ' The 3rd parameter represents the text format of the column detail
                ' The 4th parameter represents the horizontal alignment of the column detail
                ' The 5th parameter represents the relative width of the column
                 report.AddColumn(UploadsTable.Request_Id.Name, ReportEnum.Align.Left, "${Request_Id}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_Dt.Name, ReportEnum.Align.Left, "${UPLOAD_Dt}", ReportEnum.Align.Left, 20)
                 report.AddColumn(UploadsTable.UPLOAD_Desc.Name, ReportEnum.Align.Left, "${UPLOAD_Desc}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_Comments.Name, ReportEnum.Align.Left, "${UPLOAD_Comments}", ReportEnum.Align.Left, 30)
                 report.AddColumn(UploadsTable.UPLOAD_File.Name, ReportEnum.Align.Left, "${UPLOAD_File}", ReportEnum.Align.Left, 30)

              Dim whereClause As WhereClause = CreateWhereClause
              
              Dim orderBy As OrderBy = CreateOrderBy
              Dim joinFilter As BaseFilter = CreateCompoundJoinFilter()
                
                Dim rowsPerQuery As Integer = 5000
                Dim pageNum As Integer = 0
                Dim recordCount As Integer = 0
                Dim totalRows As Integer = UploadsTable.GetRecordCount(joinFilter,whereClause)

                report.Page = Page.GetResourceValue("Txt:Page", "IROC2")
                report.ApplicationPath = Me.Page.MapPath(Page.Request.ApplicationPath)

                Dim columns As ColumnList = UploadsTable.GetColumnList()
                Dim records As UploadsRecord() = Nothing
                Do
                    records = UploadsTable.GetRecords(joinFilter,whereClause, orderBy, pageNum, rowsPerQuery)
                    
                    If Not (records Is Nothing) AndAlso records.Length > 0 AndAlso whereClause.RunQuery Then
                      For Each record As UploadsRecord In records
                            ' AddData method takes four parameters
                            ' The 1st parameters represent the data format
                            ' The 2nd parameters represent the data value
                            ' The 3rd parameters represent the default alignment of column using the data
                            ' The 4th parameters represent the maximum length of the data value being shown
                             If BaseClasses.Utils.MiscUtils.IsNull(record.Request_Id) Then
                                 report.AddData("${Request_Id}", "",ReportEnum.Align.Left)
                             Else 
                                 Dim _isExpandableNonCompositeForeignKey as Boolean
                                 Dim _DFKA as String = ""
                                 _isExpandableNonCompositeForeignKey = UploadsTable.Instance.TableDefinition.IsExpandableNonCompositeForeignKey(UploadsTable.Request_Id)
                                 _DFKA = UploadsTable.GetDFKA(record.Request_Id.ToString(), UploadsTable.Request_Id,Nothing)
                                 If _isExpandableNonCompositeForeignKey AndAlso  (not _DFKA  Is Nothing)  AndAlso  UploadsTable.Request_Id.IsApplyDisplayAs Then
                                     report.AddData("${Request_Id}", _DFKA,ReportEnum.Align.Left)
                                 Else 
                                     report.AddData("${Request_Id}", record.Format(UploadsTable.Request_Id), ReportEnum.Align.Left)
                                 End If
                             End If
                             report.AddData("${UPLOAD_Dt}", record.Format(UploadsTable.UPLOAD_Dt), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_Desc}", record.Format(UploadsTable.UPLOAD_Desc), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_Comments}", record.Format(UploadsTable.UPLOAD_Comments), ReportEnum.Align.Left, 300)
                             report.AddData("${UPLOAD_File}", record.Format(UploadsTable.UPLOAD_File), ReportEnum.Align.Left, 300)

                            report.WriteRow
                        Next
                        pageNum = pageNum + 1
                        recordCount += records.Length
                    End If
                Loop While Not (records Is Nothing) AndAlso recordCount < totalRows AndAlso whereClause.RunQuery 
                report.save
                BaseClasses.Utils.NetUtils.WriteResponseBinaryAttachment(Me.Page.Response, report.Title + ".doc", report.ReportInByteArray, 0, true)
          
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
        Public Overridable Sub UploadsSearchButton_Click(ByVal sender As Object, ByVal args As EventArgs)
              
    Try
    
          Me.DataChanged = True
          
            Catch ex As Exception
            
                Me.Page.ErrorOnPage = True
    
                ' Report the error message to the end user
                Utils.MiscUtils.RegisterJScriptAlert(Me, "BUTTON_CLICK_MESSAGE", ex.Message)
    
            Finally
    
            End Try
    
        End Sub
            
      

        ' Generate the event handling functions for filter and search events.
        
        ' event handler for FieldFilter
        Protected Overridable Sub Request_IdFilter_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
           ' Setting the DataChanged to True results in the page being refreshed with
           ' the most recent data from the database.  This happens in PreRender event
           ' based on the current sort, search and filter criteria.
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
        
        Public ReadOnly Property Request_IdFilter() As BaseClasses.Web.UI.WebControls.QuickSelector
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdFilter"), BaseClasses.Web.UI.WebControls.QuickSelector)
            End Get
        End Property
        
        Public ReadOnly Property Request_IdLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property Request_IdLabel1() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel1"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_CommentsLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_CommentsLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DescLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DescLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DtLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DtLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_FileLabel() As System.Web.UI.WebControls.LinkButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_FileLabel"), System.Web.UI.WebControls.LinkButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsExportExcelButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsExportExcelButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsImportButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsImportButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsNewButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsNewButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsPagination() As IROC2.UI.IPaginationMedium
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsPagination"), IROC2.UI.IPaginationMedium)
          End Get
          End Property
        
        Public ReadOnly Property UploadsPDFButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsPDFButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsResetButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsResetButton"), System.Web.UI.WebControls.ImageButton)
            End Get
        End Property
        
        Public ReadOnly Property UploadsSearch() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsSearch"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property UploadsSearchButton() As IROC2.UI.IThemeButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsSearchButton"), IROC2.UI.IThemeButton)
          End Get
          End Property
        
        Public ReadOnly Property UploadsTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UploadsWordButton() As System.Web.UI.WebControls.ImageButton
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsWordButton"), System.Web.UI.WebControls.ImageButton)
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

  

#End Region
    
  
End Namespace

  