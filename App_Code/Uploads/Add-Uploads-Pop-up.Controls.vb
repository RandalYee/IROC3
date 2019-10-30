
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' Add_Uploads_Pop_up.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.Add_Uploads_Pop_up

#Region "Section 1: Place your customizations here."

    
Public Class UploadsRecordControl
        Inherits BaseUploadsRecordControl
        ' The BaseUploadsRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        


		Public Overrides Sub Validate() 
            ' Add custom validation for any control within this panel.
            ' Example.  If you have a State ASP:Textbox control
            ' If Me.State.Text <> "CA" Then
            '    Throw New Exception("State must be CA (California).")
            ' End If

            ' The Validate method is common across all controls within
            ' this panel so you can validate multiple fields, but report
            ' one error message.
            
            '--Ryee
            Dim i As Integer
            Dim role As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles.ToString
            role = Right(role, 2)
            If Me.UPLOAD_DOC.FileName.ToString = "" Then
                Throw New Exception("Missing Uploaded Document!")
                Exit Sub
            End If
            Select Case role
                Case ";1"  'Admin No Validate.
                    Exit Sub
                Case "22", "23", "25", "26", "27", "28", "29", "30", "31"  'Agency & Entity Allowed
                    If Me.UPLOAD_Desc.Text = "Quote" Then
                        Throw New Exception("Not Autorized To Upload Quote!")
                        Exit Sub
                    ElseIf Me.UPLOAD_Desc.Text = "SOW" Then
                        Exit Sub
                    Else
                        Me.UPLOAD_Quote.Text = Nothing
                    End If
                Case "32", "33"  'Agency & Provider Not Allowed.
                    If Me.UPLOAD_Desc.Text = "SOW" Then
                        Throw New Exception("Not Autorized To Upload SOW!")
                        Exit Sub
                    ElseIf Me.UPLOAD_Desc.Text = "Quote" And Me.UPLOAD_Quote.Text = "" Then
                        Throw New Exception("Quote_Amount is Required!")
                        Exit Sub
                    ElseIf Me.UPLOAD_Desc.Text = "Quote" Then
                        i = CInt(Me.UPLOAD_Quote.Text)
                        If i <= 0 Then
                            Throw New Exception("Quote_Amount Can't be Zero!")
                            Exit Sub
                        End If
                    End If
                Case Else
                    If Me.UPLOAD_Desc.Text = "SOW" Then
                        Throw New Exception("Not Autorized To Upload SOW!")
                        Exit Sub
                    ElseIf Me.UPLOAD_Desc.Text = "Quote" Then
                        Throw New Exception("Not Autorized To Upload Quote!")
                        Exit Sub
                    Else
                        Me.UPLOAD_Quote.Text = Nothing
                    End If
            End Select
        End Sub

		Public Overrides Sub GetUPLOAD_DOC()
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
					  Me.UPLOAD_File.Text = path.Substring(LastIndex + 1).Replace("'", "_")  '--Ryee
                  
                End If
            End If
        End Sub
End Class

  

#End Region

  

#Region "Section 2: Do not modify this section."
    
    
' Base class for the UploadsRecordControl control on the Add_Uploads_Pop_up page.
' Do not modify this class. Instead override any method in UploadsRecordControl.
Public Class BaseUploadsRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in UploadsRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in UploadsRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.UPLOAD_Desc.SelectedIndexChanged, AddressOf UPLOAD_Desc_SelectedIndexChanged
            
              AddHandler Me.UPLOAD_Comments.TextChanged, AddressOf UPLOAD_Comments_TextChanged
            
              AddHandler Me.UPLOAD_Created_By.TextChanged, AddressOf UPLOAD_Created_By_TextChanged
            
              AddHandler Me.UPLOAD_Dt.TextChanged, AddressOf UPLOAD_Dt_TextChanged
            
              AddHandler Me.UPLOAD_File.TextChanged, AddressOf UPLOAD_File_TextChanged
            
              AddHandler Me.Request_Id.TextChanged, AddressOf Request_Id_TextChanged
            
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
        
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New UploadsRecord()
            
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As UploadsRecord = UploadsTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = CType(UploadsRecord.Copy(recList(0), False), UploadsRecord)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in UploadsRecordControl.
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
        
                SetRequest_IdLabel()
                SetUPLOAD_Comments()
                SetUPLOAD_CommentsLabel()
                SetUPLOAD_Created_By()
                SetUPLOAD_Created_ByLabel()
                SetUPLOAD_DescLabel()
                
                SetUPLOAD_DOCLabel()
                SetUPLOAD_Dt()
                SetUPLOAD_DtLabel()
                SetUPLOAD_File()
                SetUPLOAD_FileLabel()
                SetUPLOAD_QuoteLabel()
                
                SetRequest_Id()
                SetUPLOAD_Desc()
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
            
        
            ' Set the UPLOAD_Created_By TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Created_By is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Created_By()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the UPLOAD_Created_By is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Created_By)
                              
                Me.UPLOAD_Created_By.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Created_By is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Created_By.Text = EvaluateFormula("UserName()", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Dt()
            
        
            ' Set the UPLOAD_Dt TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Dt is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Dt()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the UPLOAD_Dt is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Dt, "g")
                              
                Me.UPLOAD_Dt.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Dt is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Dt.Text = EvaluateFormula("Now()", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_File()
            
        
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
                
        Public Overridable Sub SetRequest_Id()
            
        
            ' Set the Request_Id TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.Request_Id is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Request_Id is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = Me.DataSource.Request_Id.ToString()
                                
                            
                Me.Request_Id.Text = formattedValue
                
            Else 
            
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Request_Id.Text = EvaluateFormula("URL(""Request_Master"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetUPLOAD_Desc()
            

            Dim selectedValue As String = Nothing
            
            ' figure out the selectedValue
                  
            
        
            ' Set the UPLOAD_Desc DropDownList on the webpage with value from the
            ' DatabaseIROC%dbo.Uploads database record.
            
            ' Me.DataSource is the DatabaseIROC%dbo.Uploads record retrieved from the database.
            ' Me.UPLOAD_Desc is the ASP:DropDownList on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetUPLOAD_Desc()
            ' and add your own code before or after the call to the MyBase function.

            
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.UPLOAD_DescSpecified Then
                            
                ' If the UPLOAD_Desc is non-NULL, then format the value.
                ' The Format method will use the Display Format
                selectedValue = Me.DataSource.UPLOAD_Desc
            Else
                
                ' UPLOAD_Desc is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
                If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                    selectedValue = Nothing
                Else
                    selectedValue = UploadsTable.UPLOAD_Desc.DefaultValue
                End If
                				
            End If			
                
            
                  
            ' Populate the item(s) to the control
            
            Me.PopulateUPLOAD_DescDropDownList(selectedValue, 100)              
                        
        End Sub
                
        Public Overridable Sub SetUPLOAD_Quote()
            
        
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
                Dim formattedValue As String = Me.DataSource.Format(UploadsTable.UPLOAD_Quote)
                              
                Me.UPLOAD_Quote.Text = formattedValue
                
            Else 
            
                ' UPLOAD_Quote is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.UPLOAD_Quote.Text = UploadsTable.UPLOAD_Quote.Format(UploadsTable.UPLOAD_Quote.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRequest_IdLabel()
                  
                  End Sub
                
        Public Overridable Sub SetUPLOAD_CommentsLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_CommentsLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_Created_ByLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_Created_ByLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DescLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DescLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DOCLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DOCLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_DtLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_DtLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_FileLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_FileLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetUPLOAD_QuoteLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.UPLOAD_QuoteLabel.Text = "Some value"
                    
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

      
        
        ' To customize, override this method in UploadsRecordControl.
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
              
            End If
            
      
            ' update session or cookie by formula
            
            Me.Page.Session("MyUPLOAD_Request_Id") = EvaluateFormula("UploadsRecordControl.Request_Id.Text")		
                
            Me.Page.Session("MyUPLOAD_Desc") = EvaluateFormula("UploadsRecordControl.UPLOAD_Desc.SelectedValue")		
                
            Me.Page.Session("MyUPLOAD_Quote") = EvaluateFormula("UploadsRecordControl.UPLOAD_Quote.Text")		
                                        
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in UploadsRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetUPLOAD_Comments()
            GetUPLOAD_Created_By()
            GetUPLOAD_DOC()
            GetUPLOAD_Dt()
            GetUPLOAD_File()
            GetRequest_Id()
            GetUPLOAD_Desc()
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
                
        Public Overridable Sub GetRequest_Id()
            
            ' Retrieve the value entered by the user on the Request_Id ASP:TextBox, and
            ' save it into the Request_Id field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Request_Id.Text, UploadsTable.Request_Id)			

                      
        End Sub
                
        Public Overridable Sub GetUPLOAD_Desc()
         
            ' Retrieve the value entered by the user on the UPLOAD_Desc ASP:DropDownList, and
            ' save it into the UPLOAD_Desc field in DataSource DatabaseIROC%dbo.Uploads record.
                        
            ' Custom validation should be performed in Validate, not here.
            
            Me.DataSource.Parse(GetValueSelectedPageRequest(Me.UPLOAD_Desc), UploadsTable.UPLOAD_Desc)				
            
        End Sub
                
        Public Overridable Sub GetUPLOAD_Quote()
            
            ' Retrieve the value entered by the user on the UPLOAD_Quote ASP:TextBox, and
            ' save it into the UPLOAD_Quote field in DataSource DatabaseIROC%dbo.Uploads record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.UPLOAD_Quote.Text, UploadsTable.UPLOAD_Quote)			

                      
        End Sub
                
      
        ' To customize, override this method in UploadsRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            UploadsTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            
            ' Retrieve the record id from the URL parameter.
            Dim recId As String = Me.Page.Request.QueryString.Item("Uploads")
            If recId Is Nothing OrElse recId.Trim = "" Then
                
                Return Nothing
                
            End If
              
                  recId = DirectCast(Me.Page, BaseApplicationPage).Decrypt(recId)
                  If recId Is Nothing OrElse recId.Trim = "" Then
                  
                      Return Nothing
                  
                  End If
                
            HttpContext.Current.Session("QueryString in Add-Uploads-Pop-up") = recId
                
            If KeyValue.IsXmlKey(recId) Then
                ' Keys are typically passed as XML structures to handle composite keys.
                ' If XML, then add a Where clause based on the Primary Key in the XML.
                Dim pkValue As KeyValue = KeyValue.XmlToKey(recId)
                 
                wc.iAND(UploadsTable.Upload_Id, BaseFilter.ComparisonOperator.EqualsTo, pkValue.GetColumnValueString(UploadsTable.Upload_Id))
        
                    Else
                    ' The URL parameter contains the actual value, not an XML structure.
                    
                wc.iAND(UploadsTable.Upload_Id, BaseFilter.ComparisonOperator.EqualsTo, recId)
        
            End If
                
            Return wc
            
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            UploadsTable.Instance.InnerFilter = Nothing
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
        
    

        ' To customize, override this method in UploadsRecordControl.
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
                                
                
			Me.Page.Authorize(Ctype(UPLOAD_Quote, Control), "1;32;33")
											
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
            
                        
        Public Overridable Function CreateWhereClause_UPLOAD_DescDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
                  
        ' Fill the UPLOAD_Desc list.
        Protected Overridable Sub PopulateUPLOAD_DescDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
            		  					                
            Me.UPLOAD_Desc.Items.Clear()
            
                    
            ' 1. Setup the static list items        
            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("SOW"), "SOW"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Quote"), "Quote"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Notes"), "Notes"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Permit"), "Permit"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Invoice"), "Invoice"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Purchase Order"), "PO"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Payment"), "Payment"))
                            							
            Me.UPLOAD_Desc.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Other"), "Other"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.UPLOAD_Desc, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.UPLOAD_Desc, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.UPLOAD_Desc, UploadsTable.UPLOAD_Desc.Format(selectedValue))Then
                Dim fvalue As String = UploadsTable.UPLOAD_Desc.Format(selectedValue)
                If fvalue Is Nothing OrElse fvalue.Trim() = "" Then fvalue = selectedValue
                ResetSelectedItem(Me.UPLOAD_Desc, New ListItem(fvalue, selectedValue))
            End If					
            
                
        End Sub
        
              
        Protected Overridable Sub UPLOAD_Desc_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)

            ' for the value inserted by quick add button or large list selector, 
            ' the value is necessary to be inserted by this event during postback 
            Dim val As String = CType(Me.Page.Session()(UPLOAD_Desc.ClientID & "_SelectedValue"), String)
            Dim displayText As String = CType(Me.Page.Session()(UPLOAD_Desc.ClientID & "_SelectedDisplayText"), String)
            If displayText <> "" AndAlso val <> "" Then
                Me.UPLOAD_Desc.Items.Add(New ListItem(displayText, val))
                Me.UPLOAD_Desc.SelectedIndex = Me.UPLOAD_Desc.Items.Count - 1
                Me.Page.Session.Remove(UPLOAD_Desc.ClientID & "_SelectedValue")
                Me.Page.Session.Remove(UPLOAD_Desc.ClientID & "_SelectedDisplayText")
            End If

          									
                
                
        End Sub
            
        Protected Overridable Sub UPLOAD_Comments_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Created_By_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub UPLOAD_File_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Request_Id_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
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
                Return CType(Me.ViewState("BaseUploadsRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseUploadsRecordControl_Rec") = value
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
        
        Public ReadOnly Property Request_IdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Comments() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Comments"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_CommentsLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_CommentsLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Created_By() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_By"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Created_ByLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Created_ByLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DescLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DescLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_DOC() As System.Web.UI.WebControls.FileUpload
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOC"), System.Web.UI.WebControls.FileUpload)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_DOCLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DOCLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_Dt() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Dt"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_File() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_File"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_FileLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_FileLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UPLOAD_QuoteLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_QuoteLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property UploadsTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UploadsTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Request_Id() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Desc() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Desc"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
            
        Public ReadOnly Property UPLOAD_Quote() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "UPLOAD_Quote"), System.Web.UI.WebControls.TextBox)
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
            
            
            Return New UploadsRecord()
            
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

  