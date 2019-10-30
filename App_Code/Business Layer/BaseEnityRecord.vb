' This class is "generated" and will be overwritten.
' Your customizations should be made in EnityRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="EnityRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="EnityTable"></see> class.
''' </remarks>
''' <seealso cref="EnityTable"></seealso>
''' <seealso cref="EnityRecord"></seealso>

<Serializable()> Public Class BaseEnityRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As EnityTable = EnityTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub EnityRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim EnityRec As EnityRecord = CType(sender,EnityRecord)
        Validate_Inserting()
        If Not EnityRec Is Nothing AndAlso Not EnityRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub EnityRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim EnityRec As EnityRecord = CType(sender,EnityRecord)
        Validate_Updating()
        If Not EnityRec Is Nothing AndAlso Not EnityRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub EnityRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim EnityRec As EnityRecord = CType(sender,EnityRecord)
        If Not EnityRec Is Nothing AndAlso Not EnityRec.IsReadOnly Then
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
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_ID field.
	''' </summary>
	Public Function GetEnity_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.Enity_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_ID field.
	''' </summary>
	Public Function GetEnity_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Enity_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_Codes field.
	''' </summary>
	Public Function GetEnity_CodesValue() As ColumnValue
		Return Me.GetValue(TableUtils.Enity_CodesColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_Codes field.
	''' </summary>
	Public Function GetEnity_CodesFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Enity_CodesColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.Enity_Codes field.
	''' </summary>
	Public Sub SetEnity_CodesFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Enity_CodesColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.Enity_Codes field.
	''' </summary>
	Public Sub SetEnity_CodesFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Enity_CodesColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.DeptAgencyNames field.
	''' </summary>
	Public Function GetDeptAgencyNamesValue() As ColumnValue
		Return Me.GetValue(TableUtils.DeptAgencyNamesColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.DeptAgencyNames field.
	''' </summary>
	Public Function GetDeptAgencyNamesFieldValue() As String
		Return CType(Me.GetValue(TableUtils.DeptAgencyNamesColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.DeptAgencyNames field.
	''' </summary>
	Public Sub SetDeptAgencyNamesFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.DeptAgencyNamesColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.DeptAgencyNames field.
	''' </summary>
	Public Sub SetDeptAgencyNamesFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.DeptAgencyNamesColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_Type field.
	''' </summary>
	Public Function GetEnity_TypeValue() As ColumnValue
		Return Me.GetValue(TableUtils.Enity_TypeColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Enity_.Enity_Type field.
	''' </summary>
	Public Function GetEnity_TypeFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Enity_TypeColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.Enity_Type field.
	''' </summary>
	Public Sub SetEnity_TypeFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Enity_TypeColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Enity_.Enity_Type field.
	''' </summary>
	Public Sub SetEnity_TypeFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Enity_TypeColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Enity_.Enity_ID field.
	''' </summary>
	Public Property Enity_ID() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Enity_IDColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Enity_IDColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Enity_IDSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Enity_IDColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Enity_IDDefault() As String
        Get
            Return TableUtils.Enity_IDColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Enity_.Enity_Codes field.
	''' </summary>
	Public Property Enity_Codes() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Enity_CodesColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Enity_CodesColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Enity_CodesSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Enity_CodesColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Enity_CodesDefault() As String
        Get
            Return TableUtils.Enity_CodesColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Enity_.DeptAgencyNames field.
	''' </summary>
	Public Property DeptAgencyNames() As String
		Get 
			Return CType(Me.GetValue(TableUtils.DeptAgencyNamesColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.DeptAgencyNamesColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property DeptAgencyNamesSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.DeptAgencyNamesColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property DeptAgencyNamesDefault() As String
        Get
            Return TableUtils.DeptAgencyNamesColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Enity_.Enity_Type field.
	''' </summary>
	Public Property Enity_Type() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Enity_TypeColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Enity_TypeColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Enity_TypeSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Enity_TypeColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Enity_TypeDefault() As String
        Get
            Return TableUtils.Enity_TypeColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
