' This class is "generated" and will be overwritten.
' Your customizations should be made in UploadsRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="UploadsRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="UploadsTable"></see> class.
''' </remarks>
''' <seealso cref="UploadsTable"></seealso>
''' <seealso cref="UploadsRecord"></seealso>

<Serializable()> Public Class BaseUploadsRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As UploadsTable = UploadsTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub UploadsRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim UploadsRec As UploadsRecord = CType(sender,UploadsRecord)
        Validate_Inserting()
        If Not UploadsRec Is Nothing AndAlso Not UploadsRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub UploadsRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim UploadsRec As UploadsRecord = CType(sender,UploadsRecord)
        Validate_Updating()
        If Not UploadsRec Is Nothing AndAlso Not UploadsRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub UploadsRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim UploadsRec As UploadsRecord = CType(sender,UploadsRecord)
        If Not UploadsRec Is Nothing AndAlso Not UploadsRec.IsReadOnly Then
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
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.Upload_Id field.
	''' </summary>
	Public Function GetUpload_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Upload_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.Upload_Id field.
	''' </summary>
	Public Function GetUpload_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Upload_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Request_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Request_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Function GetUPLOAD_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Function GetUPLOAD_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.UPLOAD_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Sub SetUPLOAD_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Sub SetUPLOAD_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.UPLOAD_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Sub SetUPLOAD_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Desc field.
	''' </summary>
	Public Function GetUPLOAD_DescValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_DescColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Desc field.
	''' </summary>
	Public Function GetUPLOAD_DescFieldValue() As String
		Return CType(Me.GetValue(TableUtils.UPLOAD_DescColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Desc field.
	''' </summary>
	Public Sub SetUPLOAD_DescFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_DescColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Desc field.
	''' </summary>
	Public Sub SetUPLOAD_DescFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_DescColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Comments field.
	''' </summary>
	Public Function GetUPLOAD_CommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Comments field.
	''' </summary>
	Public Function GetUPLOAD_CommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.UPLOAD_CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Comments field.
	''' </summary>
	Public Sub SetUPLOAD_CommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Comments field.
	''' </summary>
	Public Sub SetUPLOAD_CommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_File field.
	''' </summary>
	Public Function GetUPLOAD_FileValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_FileColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_File field.
	''' </summary>
	Public Function GetUPLOAD_FileFieldValue() As String
		Return CType(Me.GetValue(TableUtils.UPLOAD_FileColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_File field.
	''' </summary>
	Public Sub SetUPLOAD_FileFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_FileColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_File field.
	''' </summary>
	Public Sub SetUPLOAD_FileFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_FileColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Function GetUPLOAD_DOCValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_DOCColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Function GetUPLOAD_DOCFieldValue() As Byte()
		Return CType(Me.GetValue(TableUtils.UPLOAD_DOCColumn).ToBinary(), Byte())
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Sub SetUPLOAD_DOCFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_DOCColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Sub SetUPLOAD_DOCFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.UPLOAD_DOCColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Sub SetUPLOAD_DOCFieldValue(ByVal val As Byte ())
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_DOCColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Function GetUPLOAD_QuoteValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_QuoteColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Function GetUPLOAD_QuoteFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.UPLOAD_QuoteColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Sub SetUPLOAD_QuoteFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Sub SetUPLOAD_QuoteFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.UPLOAD_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Sub SetUPLOAD_QuoteFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Sub SetUPLOAD_QuoteFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Sub SetUPLOAD_QuoteFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_QuoteColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Created_By field.
	''' </summary>
	Public Function GetUPLOAD_Created_ByValue() As ColumnValue
		Return Me.GetValue(TableUtils.UPLOAD_Created_ByColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Uploads_.UPLOAD_Created_By field.
	''' </summary>
	Public Function GetUPLOAD_Created_ByFieldValue() As String
		Return CType(Me.GetValue(TableUtils.UPLOAD_Created_ByColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Created_By field.
	''' </summary>
	Public Sub SetUPLOAD_Created_ByFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.UPLOAD_Created_ByColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Uploads_.UPLOAD_Created_By field.
	''' </summary>
	Public Sub SetUPLOAD_Created_ByFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.UPLOAD_Created_ByColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.Upload_Id field.
	''' </summary>
	Public Property Upload_Id() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Upload_IdColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Upload_IdColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Upload_IdSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Upload_IdColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Upload_IdDefault() As String
        Get
            Return TableUtils.Upload_IdColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.Request_Id field.
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
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_Dt field.
	''' </summary>
	Public Property UPLOAD_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.UPLOAD_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_DtDefault() As String
        Get
            Return TableUtils.UPLOAD_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_Desc field.
	''' </summary>
	Public Property UPLOAD_Desc() As String
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_DescColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.UPLOAD_DescColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_DescSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_DescColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_DescDefault() As String
        Get
            Return TableUtils.UPLOAD_DescColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_Comments field.
	''' </summary>
	Public Property UPLOAD_Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.UPLOAD_CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_CommentsDefault() As String
        Get
            Return TableUtils.UPLOAD_CommentsColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_File field.
	''' </summary>
	Public Property UPLOAD_File() As String
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_FileColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.UPLOAD_FileColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_FileSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_FileColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_FileDefault() As String
        Get
            Return TableUtils.UPLOAD_FileColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_DOC field.
	''' </summary>
	Public Property UPLOAD_DOC() As Byte()
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_DOCColumn).ToBinary(), Byte())
		End Get
		Set (ByVal val As Byte ()) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.UPLOAD_DOCColumn)
		End Set
	End Property



	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_DOCSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_DOCColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_DOCDefault() As String
        Get
            Return TableUtils.UPLOAD_DOCColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_Quote field.
	''' </summary>
	Public Property UPLOAD_Quote() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_QuoteColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.UPLOAD_QuoteColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_QuoteSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_QuoteColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_QuoteDefault() As String
        Get
            Return TableUtils.UPLOAD_QuoteColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Uploads_.UPLOAD_Created_By field.
	''' </summary>
	Public Property UPLOAD_Created_By() As String
		Get 
			Return CType(Me.GetValue(TableUtils.UPLOAD_Created_ByColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.UPLOAD_Created_ByColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property UPLOAD_Created_BySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.UPLOAD_Created_ByColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property UPLOAD_Created_ByDefault() As String
        Get
            Return TableUtils.UPLOAD_Created_ByColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
