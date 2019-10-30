﻿
' This file implements the TableControl, TableControlRow, and RecordControl classes for the 
' MoreInfo_Add_Comments_Pop_up.aspx page.  The Row or RecordControl classes are the 
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

  
Namespace IROC2.UI.Controls.MoreInfo_Add_Comments_Pop_up

#Region "Section 1: Place your customizations here."

    
Public Class CommentsRecordControl
        Inherits BaseCommentsRecordControl
        ' The BaseCommentsRecordControl implements the LoadData, DataBind and other
        ' methods to load and display the data in a table control.

        ' This is the ideal place to add your code customizations. For example, you can override the LoadData, 
        ' CreateWhereClause, DataBind, SaveData, GetUIData, and Validate methods.
        

    End Class
    '
#End Region



#Region "Section 2: Do not modify this section."
    
    
' Base class for the CommentsRecordControl control on the MoreInfo_Add_Comments_Pop_up page.
' Do not modify this class. Instead override any method in CommentsRecordControl.
Public Class BaseCommentsRecordControl
        Inherits IROC2.UI.BaseApplicationRecordControl

        '  To customize, override this method in CommentsRecordControl.
        Protected Overridable Sub Control_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
      
           Dim url As String = ""
            ' Setup the filter and search events.
            
            Me.ClearControlsFromSession()
        End Sub

        '  To customize, override this method in CommentsRecordControl.
        Protected Overridable Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
              ' Setup the pagination events.	  
                     
        
              ' Register the event handlers.
              Dim url As String = ""        
          
              AddHandler Me.Comment.TextChanged, AddressOf Comment_TextChanged
            
              AddHandler Me.Created_By.TextChanged, AddressOf Created_By_TextChanged
            
              AddHandler Me.Email_Out.TextChanged, AddressOf Email_Out_TextChanged
            
              AddHandler Me.Agency.TextChanged, AddressOf Agency_TextChanged
            
              AddHandler Me.Comment_Dt.TextChanged, AddressOf Comment_Dt_TextChanged
            
              AddHandler Me.Comment_To_Agency.TextChanged, AddressOf Comment_To_Agency_TextChanged
            
              AddHandler Me.Comment_Topic.TextChanged, AddressOf Comment_Topic_TextChanged
            					
              AddHandler Me.Entity.TextChanged, AddressOf Entity_TextChanged
                    					
              AddHandler Me.Provider.TextChanged, AddressOf Provider_TextChanged
                    
              AddHandler Me.TypeList.SelectedIndexChanged, AddressOf TypeList_SelectedIndexChanged
                
    
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
        
            ' This is the first time a record is being retrieved from the database.
            ' So create a Where Clause based on the staic Where clause specified
            ' on the Query wizard and the dynamic part specified by the end user
            ' on the search and filter controls (if any).
            
            Dim wc As WhereClause = Me.CreateWhereClause()
          
            ' If there is no Where clause, then simply create a new, blank record.
             
            If wc Is Nothing OrElse Not wc.RunQuery Then
                Me.DataSource = New CommentsRecord()
            
                Return
            End If
          
            ' Retrieve the record from the database.  It is possible
            
            Dim recList() As CommentsRecord = CommentsTable.GetRecords(wc, Nothing, 0, 2)
            If recList.Length = 0 Then
                ' There is no data for this Where clause.
                wc.RunQuery = False
                
                Return
            End If
            
            ' Set DataSource based on record retrieved from the database.
            Me.DataSource = CType(CommentsRecord.Copy(recList(0), False), CommentsRecord)
                  
    
    
        End Sub

        ' Populate the UI controls using the DataSource.  To customize, override this method in CommentsRecordControl.
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
          
                  LoadData_Role_IDMaxQuery()
       
                  LoadData_Role_IDMaxQuery1()
       
      
      
            ' Call the Set methods for each controls on the panel
        
                SetAgencyLabel()
                SetComment()
                SetComment_DtLabel()
                SetComment_To_AgencyLabel()
                SetComment_TopicLabel()
                SetCommentLabel()
                
                SetCreated_By()
                SetCreated_ByLabel()
                SetEmail_Out()
                SetEmail_OutLabel()
                SetEntity()
                SetProvider()
                SetRequest_IdLabel()
                
                
                SetTypeList()
                SetAgency()
                SetComment_Dt()
                SetComment_To_Agency()
                SetComment_Topic()
                SetRequest_Id()
      
      
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
        
        
        Public Overridable Sub SetComment()
            
        
            ' Set the Comment TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Comment is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment)
                              
                Me.Comment.Text = formattedValue
                
            Else 
            		
                End If
                 
        End Sub
                
        Public Overridable Sub SetCreated_By()
            
        
            ' Set the Created_By TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Created_By is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetCreated_By()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Created_By is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Created_By)
                              
                Me.Created_By.Text = formattedValue
                
            Else 
            
                ' Created_By is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Created_By.Text = EvaluateFormula("UserName()", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetEmail_Out()
            
        
            ' Set the Email_Out TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Email_Out is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetEmail_Out()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.Email_OutSpecified Then
                				
                ' If the Email_Out is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Email_Out)
                              
                Me.Email_Out.Text = formattedValue
                
            Else 
            
                ' Email_Out is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Email_Out.Text = CommentsTable.Email_Out.Format(CommentsTable.Email_Out.DefaultValue)
                        		
                End If
                 
        End Sub
                
        Public Overridable Sub SetAgency()
            
        
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
        
                Me.Agency.Text = EvaluateFormula("URL(""Agency"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_Dt()
            
        
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
        
                Me.Comment_Dt.Text = EvaluateFormula("Now()", Me.DataSource, "g")		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_To_Agency()
            
        
            ' Set the Comment_To_Agency TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_To_Agency is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_To_Agency()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Comment_To_Agency is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_To_Agency)
                              
                Me.Comment_To_Agency.Text = formattedValue
                
            Else 
            		
                End If
                 
        End Sub
                
        Public Overridable Sub SetComment_Topic()
            
        
            ' Set the Comment_Topic TextBox on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Comment_Topic is the ASP:TextBox on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetComment_Topic()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Comment_Topic is non-NULL, then format the value.

                ' The Format method will use the Display Format
                Dim formattedValue As String = Me.DataSource.Format(CommentsTable.Comment_Topic)
                              
                Me.Comment_Topic.Text = formattedValue
                
            Else 
            
                ' Comment_Topic is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Comment_Topic.Text = EvaluateFormula("URL(""Topic"")", Me.DataSource)		
                End If
                 
        End Sub
                
        Public Overridable Sub SetRequest_Id()
            
        
            ' Set the Request_Id Literal on the webpage with value from the
            ' DatabaseIROC%dbo.Comments database record.

            ' Me.DataSource is the DatabaseIROC%dbo.Comments record retrieved from the database.
            ' Me.Request_Id is the ASP:Literal on the webpage.
            
            ' You can modify this method directly, or replace it with a call to
            '     MyBase.SetRequest_Id()
            ' and add your own code before or after the call to the MyBase function.

            
                  
            If Me.DataSource IsNot Nothing AndAlso Me.DataSource.IsCreated Then
                				
                ' If the Request_Id is non-NULL, then format the value.

                ' The Format method will return the Display Foreign Key As (DFKA) value
                Dim formattedValue As String = Me.DataSource.Request_Id.ToString()
                                
                            
                formattedValue = HttpUtility.HtmlEncode(formattedValue)
                Me.Request_Id.Text = formattedValue
                
            Else 
            
                ' Request_Id is NULL in the database, so use the Default Value.  
                ' Default Value could also be NULL.
        
                Me.Request_Id.Text = EvaluateFormula("URL(""Request_Id"")", Me.DataSource)		
                End If
                 
        End Sub
                
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
                
        Public Overridable Sub SetCreated_ByLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Created_ByLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetEmail_OutLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Email_OutLabel.Text = "Some value"
                    
                  End Sub
                
        Public Overridable Sub SetEntity()
                  
                      Me.Entity.Text = EvaluateFormula("URL(""Entity"")")
                    
                  End Sub
                
        Public Overridable Sub SetProvider()
                  
                      Me.Provider.Text = EvaluateFormula("URL(""Prov"")")
                    
                  End Sub
                
        Public Overridable Sub SetRequest_IdLabel()
                  
                      'Code for the text property is generated inside the .aspx file.
                      'To override this property you can uncomment the following property and add your own value.
                      'Me.Request_IdLabel.Text = "Some value"
                    
                  End Sub
                


        Public Overridable Sub SetTypeList()
            
            Me.PopulateTypeListDropDownList(Nothing, 100)
                
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
                
                ' add datasource as variables for formula evaluation
                  
                If Role_IDMaxQuery IsNot Nothing AndAlso Role_IDMaxQuery.Initialized Then e.Variables.Add("Role_IDMaxQuery", Role_IDMaxQuery)                                                       
                        
                If Role_IDMaxQuery1 IsNot Nothing AndAlso Role_IDMaxQuery1.Initialized Then e.Variables.Add("Role_IDMaxQuery1", Role_IDMaxQuery1)                                                       
                        
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

      
        
        ' To customize, override this method in CommentsRecordControl.
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
                                    
      
            ' Setting the DataChanged to True results in the page being refreshed with
            ' the most recent data from the database.  This happens in PreRender event
            ' based on the current sort, search and filter criteria.
            Me.DataChanged = True
            Me.ResetData = True
            
            ' For Master-Detail relationships, save data on the Detail table(s)
          
        End Sub

        ' To customize, override this method in CommentsRecordControl.
        Public Overridable Sub GetUIData()
            ' The GetUIData method retrieves the updated values from the user interface 
            ' controls into a database record in preparation for saving or updating.
            ' To do this, it calls the Get methods for each of the field displayed on 
            ' the webpage.  It is better to make changes in the Get methods, rather 
            ' than making changes here.
      
            ' Call the Get methods for each of the user interface controls.
        
            GetComment()
            GetCreated_By()
            GetEmail_Out()
            GetAgency()
            GetComment_Dt()
            GetComment_To_Agency()
            GetComment_Topic()
            GetRequest_Id()
        End Sub
        
        
        Public Overridable Sub GetComment()
            
            ' Retrieve the value entered by the user on the Comment ASP:TextBox, and
            ' save it into the Comment field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment.Text, CommentsTable.Comment)			

                      
        End Sub
                
        Public Overridable Sub GetCreated_By()
            
            ' Retrieve the value entered by the user on the Created_By ASP:TextBox, and
            ' save it into the Created_By field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Created_By.Text, CommentsTable.Created_By)			

                      
        End Sub
                
        Public Overridable Sub GetEmail_Out()
            
            ' Retrieve the value entered by the user on the Email_Out ASP:TextBox, and
            ' save it into the Email_Out field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Email_Out.Text, CommentsTable.Email_Out)			

                      
        End Sub
                
        Public Overridable Sub GetAgency()
            
            ' Retrieve the value entered by the user on the Agency ASP:TextBox, and
            ' save it into the Agency field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(EvaluateFormula("CommentsRecordControl.Agency.Text"), CommentsTable.Agency)			

                      
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
            Me.DataSource.Parse(EvaluateFormula("CommentsRecordControl.Comment_Dt.Text"), CommentsTable.Comment_Dt)			

                      
        End Sub
                
        Public Overridable Sub GetComment_To_Agency()
            
            ' Retrieve the value entered by the user on the Comment_To_Agency ASP:TextBox, and
            ' save it into the Comment_To_Agency field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment_To_Agency.Text, CommentsTable.Comment_To_Agency)			

                      
        End Sub
                
        Public Overridable Sub GetComment_Topic()
            
            ' Retrieve the value entered by the user on the Comment_Topic ASP:TextBox, and
            ' save it into the Comment_Topic field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(Me.Comment_Topic.Text, CommentsTable.Comment_Topic)			

                      
        End Sub
                
        Public Overridable Sub GetRequest_Id()
            
            ' Retrieve the value entered by the user on the Request_Id ASP:Literal, and
            ' save it into the Request_Id field in DataSource DatabaseIROC%dbo.Comments record.
            
            ' Custom validation should be performed in Validate, not here.
            
            'Save the value to data source
            Me.DataSource.Parse(EvaluateFormula("CommentsRecordControl.Request_Id.Text"), CommentsTable.Request_Id)			

                      
        End Sub
                
      
        ' To customize, override this method in CommentsRecordControl.
        
        Public Overridable Function CreateWhereClause() As WhereClause
        
            Dim wc As WhereClause
            CommentsTable.Instance.InnerFilter = Nothing
            wc = New WhereClause()
            
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected filter criteria.
            ' 3. User selected search criteria.
            
            ' Retrieve the record id from the URL parameter.
            Dim recId As String = Me.Page.Request.QueryString.Item("Comments")
            If recId Is Nothing OrElse recId.Trim = "" Then
                
                Return Nothing
                
            End If
              
                  recId = DirectCast(Me.Page, BaseApplicationPage).Decrypt(recId)
                  If recId Is Nothing OrElse recId.Trim = "" Then
                  
                      Return Nothing
                  
                  End If
                
            HttpContext.Current.Session("QueryString in MoreInfo-Add-Comments-Pop-up") = recId
                
            If KeyValue.IsXmlKey(recId) Then
                ' Keys are typically passed as XML structures to handle composite keys.
                ' If XML, then add a Where clause based on the Primary Key in the XML.
                Dim pkValue As KeyValue = KeyValue.XmlToKey(recId)
                 
                wc.iAND(CommentsTable.Comment_ID, BaseFilter.ComparisonOperator.EqualsTo, pkValue.GetColumnValueString(CommentsTable.Comment_ID))
        
                    Else
                    ' The URL parameter contains the actual value, not an XML structure.
                    
                wc.iAND(CommentsTable.Comment_ID, BaseFilter.ComparisonOperator.EqualsTo, recId)
        
            End If
                
            Return wc
            
        End Function
        
        ' This CreateWhereClause is used for loading list of suggestions for Auto Type-Ahead feature.
        
        Public Overridable Function CreateWhereClause(ByVal searchText As String, ByVal fromSearchControl As String, ByVal AutoTypeAheadSearch As String, ByVal AutoTypeAheadWordSeparators As String) As WhereClause
            CommentsTable.Instance.InnerFilter = Nothing
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
        
        Protected _Role_IDMaxQuery As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery As DataSource          
            Get               
                Return _Role_IDMaxQuery
            End Get
        End Property
       
        Protected _Role_IDMaxQuery1 As New DataSource
        Public Overridable ReadOnly Property Role_IDMaxQuery1 As DataSource          
            Get               
                Return _Role_IDMaxQuery1
            End Get
        End Property
       
        Public Overridable Sub LoadData_Role_IDMaxQuery()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery.DataChanged = True
          
              Me._Role_IDMaxQuery.Initialize("Role_IDMaxQuery", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery()
              Me._Role_IDMaxQuery.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery.LoadData(False, Me._Role_IDMaxQuery.PageSize, Me._Role_IDMaxQuery.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Sub LoadData_Role_IDMaxQuery1()      
        
              If Not(Me.ResetData OrElse Me.DataChanged OrElse _Role_IDMaxQuery1.DataChanged) AndAlso Me.Page.IsPostBack AndAlso Me.Page.Request("__EVENTTARGET") <> "isd_geo_location" Then Return
          
              _Role_IDMaxQuery1.DataChanged = True
          
              Me._Role_IDMaxQuery1.Initialize("Role_IDMaxQuery1", RoleTable.Instance, 0, 0)                                            
              
               
              ' Add the primary key of the record
              Dim wc as WhereClause = CreateWhereClause_Role_IDMaxQuery1()
              Me._Role_IDMaxQuery1.WhereClause.iAND(wc)                      
          
              ' Define selects
          
              Me._Role_IDMaxQuery1.AddSelectItem(New SelectItem(SelectItem.Operation.MAX, New SelectItem(RoleTable.Role_ID, RoleTable.Instance, false, "", ""), "Role_IDMax"))
              
              ' Define joins if there are any
          
              Me._Role_IDMaxQuery1.LoadData(False, Me._Role_IDMaxQuery1.PageSize, Me._Role_IDMaxQuery1.PageIndex)                       
          
              
        End Sub
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
        Public Overridable Function CreateWhereClause_Role_IDMaxQuery1() As WhereClause
        
        
            Dim wc As WhereClause = New WhereClause()
            ' Compose the WHERE clause consist of:
            ' 1. Static clause defined at design time.
            ' 2. User selected search criteria.
            ' 3. User selected filter criteria.
            
                      
            Return wc
        End Function
      
    

        ' To customize, override this method in CommentsRecordControl.
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
                                
                
			Me.Page.Authorize(Ctype(Email_Out, Control), "1")
					
			Me.Page.Authorize(Ctype(Email_OutLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Request_IdLabel, Control), "1")
					
			Me.Page.Authorize(Ctype(Request_Id, Control), "1")
											
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
            
        Public Overridable Function CreateWhereClause_TypeListDropDownList() As WhereClause
            ' By default, we simply return a new WhereClause.
            ' Add additional where clauses to restrict the items shown in the dropdown list.
            
            Dim wc As WhereClause = New WhereClause()
            Return wc
            				
        End Function
        

        ' Fill the TypeList list.
        Protected Overridable Sub PopulateTypeListDropDownList( _
                ByVal selectedValue As String, _
                ByVal maxItems As Integer)
                
            Me.TypeList.Items.Clear()

                      
                    
            ' 1. Setup the static list items        
            							
            Me.TypeList.Items.Add(New ListItem(Me.Page.ExpandResourceValue("{Txt:PleaseSelect}"), "--PLEASE_SELECT--"))
                            							
            Me.TypeList.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Requester"), "Requester"))
                            							
            Me.TypeList.Items.Add(New ListItem(Me.Page.ExpandResourceValue("Entity"), "Entity"))
                            							
            Me.TypeList.Items.Add(New ListItem(Me.Page.ExpandResourceValue("CATV"), "CATV"))
                            							
            Me.TypeList.Items.Add(New ListItem(Me.Page.ExpandResourceValue("INET Provider"), "Provider"))
                            		  
            ' Skip step 2 and 3 because no need to load data from database and insert data
                    
                    
            ' 4. Set the selected value (insert if not already present).
              
            If Not selectedValue Is Nothing AndAlso _
                selectedValue.Trim <> "" AndAlso _
                Not SetSelectedValue(Me.TypeList, selectedValue) AndAlso _
                Not SetSelectedDisplayText(Me.TypeList, selectedValue)Then

            
            End If					
                
                
        End Sub
                
        Protected Overridable Sub Comment_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Created_By_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Email_Out_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_Dt_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_To_Agency_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            
        Protected Overridable Sub Comment_Topic_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
                    
              End Sub
            		
        Protected Overridable Sub Entity_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
             
        End Sub
                    		
        Protected Overridable Sub Provider_TextChanged(ByVal sender As Object, ByVal args As EventArgs)                
             
        End Sub
                    
        Protected Overridable Sub TypeList_SelectedIndexChanged(ByVal sender As Object, ByVal args As EventArgs)                
             

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
                Return CType(Me.ViewState("BaseCommentsRecordControl_Rec"), String)
            End Get
            Set(ByVal value As String)
                Me.ViewState("BaseCommentsRecordControl_Rec") = value
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
        
        Public ReadOnly Property AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "AgencyLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Comment() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Comment_DtLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_DtLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Comment_To_AgencyLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_To_AgencyLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Comment_TopicLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_TopicLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property CommentLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property CommentsTitle() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "CommentsTitle"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Created_By() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Created_By"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Created_ByLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Created_ByLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Email_Out() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Email_Out"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Email_OutLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Email_OutLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property Entity() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Entity"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property Provider() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Provider"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
        
        Public ReadOnly Property Request_IdLabel() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_IdLabel"), System.Web.UI.WebControls.Literal)
            End Get
        End Property
        
        Public ReadOnly Property TypeList() As System.Web.UI.WebControls.DropDownList
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "TypeList"), System.Web.UI.WebControls.DropDownList)
            End Get
        End Property
        
        Public ReadOnly Property Agency() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Agency"), System.Web.UI.WebControls.TextBox)
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
            
        Public ReadOnly Property Comment_Topic() As System.Web.UI.WebControls.TextBox
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Comment_Topic"), System.Web.UI.WebControls.TextBox)
            End Get
        End Property
            
        Public ReadOnly Property Request_Id() As System.Web.UI.WebControls.Literal
            Get
                Return CType(BaseClasses.Utils.MiscUtils.FindControlRecursively(Me, "Request_Id"), System.Web.UI.WebControls.Literal)
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
            
            
            Return New CommentsRecord()
            
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

  