' This class is "generated" and will be overwritten.
' Your customizations should be made in CommentsRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="CommentsRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="CommentsTable"></see> class.
''' </remarks>
''' <seealso cref="CommentsTable"></seealso>
''' <seealso cref="CommentsRecord"></seealso>

<Serializable()> Public Class BaseCommentsRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As CommentsTable = CommentsTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub CommentsRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim CommentsRec As CommentsRecord = CType(sender,CommentsRecord)
        Validate_Inserting()
        If Not CommentsRec Is Nothing AndAlso Not CommentsRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub CommentsRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim CommentsRec As CommentsRecord = CType(sender,CommentsRecord)
        Validate_Updating()
        If Not CommentsRec Is Nothing AndAlso Not CommentsRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub CommentsRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim CommentsRec As CommentsRecord = CType(sender,CommentsRecord)
        If Not CommentsRec Is Nothing AndAlso Not CommentsRec.IsReadOnly Then
                End If
    End Sub
    
   'Evaluates Validate when->Inserting formulas specified at the data access layer
   Public Overridable Sub Validate_Inserting ()
		Dim fullValidationMessage As String = ""
		Dim validationMessage As String = ""

		dim formula as String = ""


		If validationMessage <> "" AndAlso validationMessage.ToLower() <> "true" Then
			fullValidationMessage &= validationMessage & vbCrLf
		End If

		If fullValidationMessage <> "" Then
			Throw New Exception(fullValidationMessage)
		End If 
	End Sub
	
	'Evaluates Validate when->Updating formulas specified at the data access layer
   Public Overridable Sub Validate_Updating ()
		Dim fullValidationMessage As String = ""
		Dim validationMessage As String = ""

		dim formula as String = ""


		If validationMessage <> "" AndAlso validationMessage.ToLower() <> "true" Then
			fullValidationMessage &= validationMessage & vbCrLf
		End If

		If fullValidationMessage <> "" Then
			Throw New Exception(fullValidationMessage)
		End If 
	End Sub
 
	Public Overridable Function EvaluateFormula(ByVal formula As String, Optional ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord = Nothing, Optional ByVal format As String = Nothing) As String

		Dim e As Data.BaseFormulaEvaluator = New Data.BaseFormulaEvaluator()

            ' All variables referred to in the formula are expected to be
            ' properties of the DataSource.  For example, referring to
            ' UnitPrice as a variable will refer to DataSource.UnitPrice
            e.DataSource = dataSourceForEvaluate

            Dim resultObj As Object = e.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
        	Return resultObj.ToString()
	End Function







#Region "Convenience methods to get/set values of fields"

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_ID field.
	''' </summary>
	Public Function GetComment_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.Comment_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_ID field.
	''' </summary>
	Public Function GetComment_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Comment_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Request_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Request_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Agency field.
	''' </summary>
	Public Function GetAgencyValue() As ColumnValue
		Return Me.GetValue(TableUtils.AgencyColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Agency field.
	''' </summary>
	Public Function GetAgencyFieldValue() As String
		Return CType(Me.GetValue(TableUtils.AgencyColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_To_Agency field.
	''' </summary>
	Public Function GetComment_To_AgencyValue() As ColumnValue
		Return Me.GetValue(TableUtils.Comment_To_AgencyColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_To_Agency field.
	''' </summary>
	Public Function GetComment_To_AgencyFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Comment_To_AgencyColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_To_Agency field.
	''' </summary>
	Public Sub SetComment_To_AgencyFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Comment_To_AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_To_Agency field.
	''' </summary>
	Public Sub SetComment_To_AgencyFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Comment_To_AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_Topic field.
	''' </summary>
	Public Function GetComment_TopicValue() As ColumnValue
		Return Me.GetValue(TableUtils.Comment_TopicColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_Topic field.
	''' </summary>
	Public Function GetComment_TopicFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Comment_TopicColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_Topic field.
	''' </summary>
	Public Sub SetComment_TopicFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Comment_TopicColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_Topic field.
	''' </summary>
	Public Sub SetComment_TopicFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Comment_TopicColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment field.
	''' </summary>
	Public Function GetCommentValue() As ColumnValue
		Return Me.GetValue(TableUtils.CommentColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment field.
	''' </summary>
	Public Function GetCommentFieldValue() As String
		Return CType(Me.GetValue(TableUtils.CommentColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment field.
	''' </summary>
	Public Sub SetCommentFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.CommentColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment field.
	''' </summary>
	Public Sub SetCommentFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.CommentColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Function GetComment_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Comment_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Function GetComment_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Comment_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Sub SetComment_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Comment_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Sub SetComment_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Comment_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Sub SetComment_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Comment_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Email_Out field.
	''' </summary>
	Public Function GetEmail_OutValue() As ColumnValue
		Return Me.GetValue(TableUtils.Email_OutColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Email_Out field.
	''' </summary>
	Public Function GetEmail_OutFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Email_OutColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Email_Out field.
	''' </summary>
	Public Sub SetEmail_OutFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Email_OutColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Email_Out field.
	''' </summary>
	Public Sub SetEmail_OutFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Email_OutColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Created_By field.
	''' </summary>
	Public Function GetCreated_ByValue() As ColumnValue
		Return Me.GetValue(TableUtils.Created_ByColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Comments_.Created_By field.
	''' </summary>
	Public Function GetCreated_ByFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Created_ByColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Created_By field.
	''' </summary>
	Public Sub SetCreated_ByFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Created_ByColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Comments_.Created_By field.
	''' </summary>
	Public Sub SetCreated_ByFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Created_ByColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Comment_ID field.
	''' </summary>
	Public Property Comment_ID() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Comment_IDColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Comment_IDColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Comment_IDSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Comment_IDColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Comment_IDDefault() As String
        Get
            Return TableUtils.Comment_IDColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Request_Id field.
	''' </summary>
	Public Property Request_Id() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Request_IdColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Request_IdColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Request_IdSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Request_IdColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Request_IdDefault() As String
        Get
            Return TableUtils.Request_IdColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Agency field.
	''' </summary>
	Public Property Agency() As String
		Get 
			Return CType(Me.GetValue(TableUtils.AgencyColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.AgencyColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property AgencySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.AgencyColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property AgencyDefault() As String
        Get
            Return TableUtils.AgencyColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Comment_To_Agency field.
	''' </summary>
	Public Property Comment_To_Agency() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Comment_To_AgencyColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Comment_To_AgencyColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Comment_To_AgencySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Comment_To_AgencyColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Comment_To_AgencyDefault() As String
        Get
            Return TableUtils.Comment_To_AgencyColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Comment_Topic field.
	''' </summary>
	Public Property Comment_Topic() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Comment_TopicColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Comment_TopicColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Comment_TopicSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Comment_TopicColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Comment_TopicDefault() As String
        Get
            Return TableUtils.Comment_TopicColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Comment field.
	''' </summary>
	Public Property Comment() As String
		Get 
			Return CType(Me.GetValue(TableUtils.CommentColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.CommentColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property CommentSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.CommentColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property CommentDefault() As String
        Get
            Return TableUtils.CommentColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Comment_Dt field.
	''' </summary>
	Public Property Comment_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Comment_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Comment_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Comment_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Comment_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Comment_DtDefault() As String
        Get
            Return TableUtils.Comment_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Email_Out field.
	''' </summary>
	Public Property Email_Out() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Email_OutColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Email_OutColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Email_OutSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Email_OutColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Email_OutDefault() As String
        Get
            Return TableUtils.Email_OutColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Comments_.Created_By field.
	''' </summary>
	Public Property Created_By() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Created_ByColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Created_ByColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Created_BySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Created_ByColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Created_ByDefault() As String
        Get
            Return TableUtils.Created_ByColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
