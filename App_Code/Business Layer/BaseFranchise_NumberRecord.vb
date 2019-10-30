' This class is "generated" and will be overwritten.
' Your customizations should be made in Franchise_NumberRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="Franchise_NumberRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="Franchise_NumberTable"></see> class.
''' </remarks>
''' <seealso cref="Franchise_NumberTable"></seealso>
''' <seealso cref="Franchise_NumberRecord"></seealso>

<Serializable()> Public Class BaseFranchise_NumberRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As Franchise_NumberTable = Franchise_NumberTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub Franchise_NumberRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim Franchise_NumberRec As Franchise_NumberRecord = CType(sender,Franchise_NumberRecord)
        Validate_Inserting()
        If Not Franchise_NumberRec Is Nothing AndAlso Not Franchise_NumberRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub Franchise_NumberRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim Franchise_NumberRec As Franchise_NumberRecord = CType(sender,Franchise_NumberRecord)
        Validate_Updating()
        If Not Franchise_NumberRec Is Nothing AndAlso Not Franchise_NumberRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub Franchise_NumberRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim Franchise_NumberRec As Franchise_NumberRecord = CType(sender,Franchise_NumberRecord)
        If Not Franchise_NumberRec Is Nothing AndAlso Not Franchise_NumberRec.IsReadOnly Then
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
	''' This is a convenience method that provides direct access to the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Function GetFranchise_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.Franchise_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Function GetFranchise_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Franchise_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Sub SetFranchise_IDFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Franchise_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Sub SetFranchise_IDFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Franchise_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Sub SetFranchise_IDFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Franchise_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Sub SetFranchise_IDFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Franchise_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Sub SetFranchise_IDFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Franchise_IDColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Franchise_Number_.Franchise_Order_Number field.
	''' </summary>
	Public Function GetFranchise_Order_NumberValue() As ColumnValue
		Return Me.GetValue(TableUtils.Franchise_Order_NumberColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Franchise_Number_.Franchise_Order_Number field.
	''' </summary>
	Public Function GetFranchise_Order_NumberFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Franchise_Order_NumberColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_Order_Number field.
	''' </summary>
	Public Sub SetFranchise_Order_NumberFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Franchise_Order_NumberColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Franchise_Number_.Franchise_Order_Number field.
	''' </summary>
	Public Sub SetFranchise_Order_NumberFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Franchise_Order_NumberColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Franchise_Number_.Franchise_ID field.
	''' </summary>
	Public Property Franchise_ID() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Franchise_IDColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Franchise_IDColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Franchise_IDSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Franchise_IDColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Franchise_IDDefault() As String
        Get
            Return TableUtils.Franchise_IDColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Franchise_Number_.Franchise_Order_Number field.
	''' </summary>
	Public Property Franchise_Order_Number() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Franchise_Order_NumberColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Franchise_Order_NumberColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Franchise_Order_NumberSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Franchise_Order_NumberColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Franchise_Order_NumberDefault() As String
        Get
            Return TableUtils.Franchise_Order_NumberColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
